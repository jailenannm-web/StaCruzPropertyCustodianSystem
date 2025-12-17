Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Linq

Public Class AddSupply
    Inherits UserControl

    Private canModifySupplies As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub AddSupply_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
        LoadDropdowns()
    End Sub

    Private Sub LoadDropdowns()
        Try
            ' Load categories
            Dim categoriesTable As DataTable = DatabaseConnection.GetCategories("supply")
            If categoriesTable IsNot Nothing AndAlso categoriesTable.Rows.Count > 0 Then
                category.DataSource = categoriesTable
                category.DisplayMember = "category_name"
                category.ValueMember = "category_name"
            Else
                category.Items.Clear()
                category.Items.AddRange(New String() {"Office Supplies", "Cleaning Supplies", "Medical Supplies", "Stationery", "Electronics", "Other"})
            End If

            ' Load suppliers
            Dim suppliersTable As DataTable = DatabaseConnection.GetSuppliers()
            If suppliersTable IsNot Nothing AndAlso suppliersTable.Rows.Count > 0 Then
                supplier.DataSource = suppliersTable
                supplier.DisplayMember = "supplier_name"
                supplier.ValueMember = "supplier_name"
            Else
                supplier.Items.Clear()
                supplier.Items.AddRange(New String() {"Local Supplier", "National Supplier", "International Supplier", "Government Supplier"})
            End If

            ' Load locations
            Dim locationsTable As DataTable = DatabaseConnection.GetLocations()
            If locationsTable IsNot Nothing AndAlso locationsTable.Rows.Count > 0 Then
                location.DataSource = locationsTable
                location.DisplayMember = "location_name"
                location.ValueMember = "location_name"
            Else
                location.Items.Clear()
                location.Items.AddRange(New String() {"Main Building", "Annex Building", "Warehouse", "Storage Room", "Office"})
            End If

            ' Load unit of measure
            Dim uomTable As DataTable = DatabaseConnection.GetUnitOfMeasureOptions()
            If uomTable IsNot Nothing AndAlso uomTable.Rows.Count > 0 Then
                unitOfMeasur.DataSource = uomTable
                unitOfMeasur.DisplayMember = "uom_name"
                unitOfMeasur.ValueMember = "uom_name"
                unitOfMeasur.SelectedIndex = 0 ' Default to "pcs"
            Else
                unitOfMeasur.Items.Clear()
                unitOfMeasur.Items.AddRange(New String() {"pcs", "box", "pack", "set", "unit", "piece", "bottle", "can", "roll", "ream"})
                unitOfMeasur.SelectedIndex = 0
            End If

            ' Description can be a text field or dropdown - for now keep it as text input
            ' If you want it as dropdown, populate from existing descriptions
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDropdowns Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Super Admin bypasses all restrictions
        If Not SessionContext.IsSuperAdmin() Then
            If Not EnsureModifyPermission() Then
                Return
            End If
        End If

        ' Validate required fields
        If String.IsNullOrWhiteSpace(itemName.Text) Then
            MessageBox.Show("Supply name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            itemName.Focus()
            Return
        End If

        If category.SelectedIndex = -1 AndAlso String.IsNullOrWhiteSpace(category.Text) Then
            MessageBox.Show("Please select or enter a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            category.Focus()
            Return
        End If

        If quantity.Value <= 0 Then
            MessageBox.Show("Stock quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            quantity.Focus()
            Return
        End If

        ' Get values from form
        Dim supplyIDValue As String = "" ' Not used - supplyId is auto-increment
        Dim supplyNameValue As String = itemName.Text.Trim()
        Dim categoryValue As String = ""
        If category.SelectedIndex >= 0 AndAlso category.SelectedItem IsNot Nothing Then
            If TypeOf category.SelectedItem Is DataRowView Then
                categoryValue = CType(category.SelectedItem, DataRowView)("category_name").ToString()
            Else
                categoryValue = category.SelectedItem.ToString()
            End If
        Else
            categoryValue = category.Text.Trim()
        End If
        Dim stockValue As Integer = CInt(quantity.Value)
        Dim unitCostValue As Decimal = CDec(unitCost.Value)
        Dim totalValue As Decimal = CDec(totalCost.Value)
        Dim locationValue As String = ""
        If location.SelectedIndex >= 0 AndAlso location.SelectedItem IsNot Nothing Then
            If TypeOf location.SelectedItem Is DataRowView Then
                locationValue = CType(location.SelectedItem, DataRowView)("location_name").ToString()
            Else
                locationValue = location.SelectedItem.ToString()
            End If
        Else
            locationValue = location.Text.Trim()
        End If
        Dim descriptionValue As String = If(description IsNot Nothing, If(description.SelectedIndex >= 0, description.SelectedItem.ToString(), description.Text.Trim()), "")
        Dim uomValue As String = "pcs"
        If unitOfMeasur.SelectedIndex >= 0 AndAlso unitOfMeasur.SelectedItem IsNot Nothing Then
            If TypeOf unitOfMeasur.SelectedItem Is DataRowView Then
                uomValue = CType(unitOfMeasur.SelectedItem, DataRowView)("uom_name").ToString()
            Else
                uomValue = unitOfMeasur.SelectedItem.ToString()
            End If
        Else
            uomValue = unitOfMeasur.Text.Trim()
        End If
        Dim supplierIDValue As String = ""
        If supplier.SelectedIndex >= 0 AndAlso supplier.SelectedItem IsNot Nothing Then
            If TypeOf supplier.SelectedItem Is DataRowView Then
                supplierIDValue = CType(supplier.SelectedItem, DataRowView)("supplier_name").ToString()
            Else
                supplierIDValue = supplier.SelectedItem.ToString()
            End If
        Else
            supplierIDValue = supplier.Text.Trim()
        End If

        ' Try to get unit cost from TextBox1 if it exists
        Try
            If Me.Controls.Find("TextBox1", True).Length > 0 Then
                Dim unitCostTxt As TextBox = TryCast(Me.Controls.Find("TextBox1", True)(0), TextBox)
                If unitCostTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(unitCostTxt.Text) Then
                    If Decimal.TryParse(unitCostTxt.Text, unitCostValue) Then
                        totalValue = unitCostValue * stockValue
                    End If
                End If
            End If
        Catch
        End Try

        ' Try to get location from TextBox2 if it exists
        Try
            If Me.Controls.Find("TextBox2", True).Length > 0 Then
                Dim locationTxt As TextBox = TryCast(Me.Controls.Find("TextBox2", True)(0), TextBox)
                If locationTxt IsNot Nothing Then
                    locationValue = locationTxt.Text.Trim()
                End If
            End If
        Catch
        End Try

        ' Get dateReceived from DateTimePicker if available
        Dim dateReceivedValue As Date? = Nothing
        Try
            ' Find the control by name (Designer control should be accessible)
            Dim foundControls() As Control = Me.Controls.Find("dateReceived", True)
            If foundControls.Length > 0 Then
                Dim datePicker As DateTimePicker = TryCast(foundControls(0), DateTimePicker)
                If datePicker IsNot Nothing Then
                    dateReceivedValue = datePicker.Value
                Else
                    dateReceivedValue = Date.Today
                End If
            Else
                dateReceivedValue = Date.Today
            End If
        Catch
            dateReceivedValue = Date.Today
        End Try

        ' Call DatabaseConnection.AddSupply (sourceOfFunds is handled inside the function)
        Dim success As Boolean = DatabaseConnection.AddSupply(
            supplyIDValue,
            supplyNameValue,
            categoryValue,
            stockValue,
            unitCostValue,
            totalValue,
            "Available", ' status
            locationValue,
            descriptionValue,
            uomValue,
            10, ' reorderLevel (default)
            supplierIDValue,
            dateReceivedValue ' dateReceived parameter
        )

        If success Then
            MessageBox.Show("Supply added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub admin_label_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_label_DepartmentManagement.Click
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_SupplyManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        ' No restrictions for Super Admin, Admin, and Custodian
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If hasFullAccess Then
            Return True
        End If
        ' For other roles, check permission
        canModifySupplies = SessionContext.HasPermission(SessionContext.ModulePermission.ModifySupplies)
        If Not canModifySupplies Then
            MessageBox.Show("You have view-only access to Supplies Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles supplier.SelectedIndexChanged

    End Sub
End Class

