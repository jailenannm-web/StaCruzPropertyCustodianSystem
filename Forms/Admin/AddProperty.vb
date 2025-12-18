Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Public Class AddProperty
    Inherits UserControl

    Private departmentDirectory As DataTable
    Private custodianDirectory As DataTable
    Private canModifyProperties As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf AddProperty_Load
    End Sub

    Private Sub AddProperty_Load(sender As Object, e As EventArgs)

        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        category.Items.Clear()
        category.Items.AddRange(New Object() {
            "Furniture", "Equipment", "Office Supplies", "IT Equipment",
            "Laboratory Apparatus", "Books and Publications",
            "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
        })
        If category.Items.Count > 0 Then category.SelectedIndex = 0

        condition.Items.Clear()
        ' Match database ENUM values: 'Good', 'Needs Repair', 'Damaged'
        condition.Items.AddRange(New Object() {"Good", "Needs Repair", "Damaged"})
        If condition.Items.Count > 0 Then condition.SelectedIndex = 0

        LoadDepartments()
        LoadCustodians()
        LoadSuppliers()

        acquisitionDate.Value = Date.Today
        warrantyExpirationDate.Value = Date.Today.AddYears(1)
    End Sub

    Private Sub LoadSuppliers()
        Try
            Dim suppliersTable As DataTable = DatabaseConnection.GetSuppliers()
            If suppliersTable IsNot Nothing AndAlso suppliersTable.Rows.Count > 0 Then
                ' Find supplier control - it might be a ComboBox or TextBox
                Dim supplierControl As Control = Me.Controls.Find("supplier", True).FirstOrDefault()
                If supplierControl IsNot Nothing AndAlso TypeOf supplierControl Is ComboBox Then
                    Dim supplierCombo As ComboBox = CType(supplierControl, ComboBox)
                    supplierCombo.DataSource = suppliersTable
                    supplierCombo.DisplayMember = "supplier_name"
                    supplierCombo.ValueMember = "supplier_name"
                    supplierCombo.SelectedIndex = -1
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty.LoadSuppliers Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            departmentDirectory = DatabaseConnection.GetDepartmentLookup(True)
            If departmentDirectory IsNot Nothing AndAlso departmentDirectory.Rows.Count > 0 Then
                departmentId.DataSource = departmentDirectory
                departmentId.DisplayMember = "department_name"
                departmentId.ValueMember = "department_id"
                departmentId.SelectedIndex = 0
            Else
                departmentId.Items.Clear()
                departmentId.Items.Add("No Departments Available")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty.LoadDepartments Exception: " & ex.Message)
            MessageBox.Show("Failed to load departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' Replace LoadCustodians with this safer implementation
    Private Sub LoadCustodians(Optional departmentID As Integer? = Nothing)
        Try
            Dim usersTable As DataTable = Nothing
            If departmentID.HasValue Then
                usersTable = DatabaseConnection.GetUsersByDepartment(departmentID.Value)
            Else
                usersTable = DatabaseConnection.GetActiveUsersForAssignment(New String() {"Admin", "Custodian", "Staff"})
            End If

            ' Always clear any existing DataSource before modifying Items
            If assignedTo.DataSource IsNot Nothing Then
                assignedTo.DataSource = Nothing
            End If

            If usersTable Is Nothing OrElse usersTable.Rows.Count = 0 Then
                assignedTo.Items.Clear()
                assignedTo.Items.Add("No users available")
                custodianDirectory = Nothing
                Return
            End If

            ' Keep local copy for ResolveCustodianId
            custodianDirectory = usersTable.Copy()

            assignedTo.DisplayMember = "fullName"
            assignedTo.ValueMember = "userId"
            assignedTo.DataSource = usersTable
            assignedTo.SelectedIndex = -1
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty.LoadCustodians Exception: " & ex.Message)
            If assignedTo.DataSource IsNot Nothing Then assignedTo.DataSource = Nothing
            assignedTo.Items.Clear()
            assignedTo.Items.Add("Error loading users")
        End Try
    End Sub
    Private Sub departmentId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles departmentId.SelectedIndexChanged
        ' Reload users when department changes
        Dim deptID As Integer? = ResolveDepartmentId()
        LoadCustodians(deptID)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim validationError = ValidateFields()
        If Not String.IsNullOrEmpty(validationError) Then
            MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim departmentId As Integer? = ResolveDepartmentId()
        Dim custodianId As Integer? = ResolveCustodianId()

        ' Parse acquisition cost
        Dim acquisitionCostValue As Decimal = 0
        If Not String.IsNullOrWhiteSpace(totalCost.Text) Then
            If Not Decimal.TryParse(totalCost.Text.Trim(), acquisitionCostValue) Then
                MessageBox.Show("Please enter a valid acquisition cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                totalCost.Focus()
                Return
            End If
        End If

        ' Get description from description field
        Dim descriptionValue As String = ""
        If description IsNot Nothing Then
            descriptionValue = description.Text.Trim()
        End If

        ' Get property number if available
        Dim propertyNumberValue As String = ""
        If description IsNot Nothing Then
            propertyNumberValue = description.Text.Trim()
        End If

        Try
            Dim success = DatabaseConnection.AddProperty(
                propertyId.Text.Trim(),                            ' propertyName
                GetComboValue(category, "Others"),                       ' category
                descriptionValue,                                        ' description
                serialNumber.Text.Trim(),                                   ' serialNumber
                acquisitionDate.Value,                                  ' acquisitionDate
                acquisitionCostValue,                                   ' acquisitionCost
                "",                                                      ' supplierName (not in current schema)
                "",                                                      ' supplierContact (not in current schema)
                GetComboValue(condition, "Good"),                       ' conditionStatus
                If(ResolveDepartmentId().HasValue, "Department Location", "Main Building"), ' location (default since no input field)
                custodianId,                                             ' custodianID
                departmentId,                                            ' departmentID
                warrantyExpirationDate.Value.ToShortDateString(),       ' warrantyDetails
                Nothing,                                                 ' lifeSpan
                propertyNumberValue                                      ' propertyNumber
            )

            If success Then
                NavigateBackToList()
            End If
        Catch ex As Exception
            MessageBox.Show("Error adding property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AddProperty btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBackToList()
    End Sub

    Private Sub NavigateBackToList()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyManagement1())
        End If
    End Sub

    Private Function ValidateFields() As String
        If String.IsNullOrWhiteSpace(propertyId.Text) Then Return "Property name is required."
        If category.SelectedIndex = -1 Then Return "Please select a category."
        ' Validate acquisition cost from the correct field
        If String.IsNullOrWhiteSpace(totalCost.Text) Then Return "Acquisition cost is required."
        Dim costValue As Decimal = 0
        If Not Decimal.TryParse(totalCost.Text.Trim(), costValue) OrElse costValue <= 0 Then
            Return "Acquisition cost must be a valid number greater than zero."
        End If
        ' Location is required but no input field exists - use default or department location
        Return ""
    End Function

    Private Function ResolveCustodianId() As Integer?
        Try
            Dim rawValue As String = assignedTo.Text.Trim()
            If String.IsNullOrWhiteSpace(rawValue) Then Return Nothing

            Dim candidate As String = rawValue
            If rawValue.Contains("-") Then
                candidate = rawValue.Split("-"c)(0).Trim()
            End If

            Dim parsed As Integer
            If Integer.TryParse(candidate, parsed) Then Return parsed

            If custodianDirectory IsNot Nothing Then
            Dim match = custodianDirectory.AsEnumerable().
                FirstOrDefault(Function(r) String.Equals(r("fullName").ToString(), rawValue, StringComparison.OrdinalIgnoreCase))
                If match IsNot Nothing Then
                    Return Convert.ToInt32(match("userId"))
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ResolveCustodianId Exception: " & ex.Message)
        End Try
        Return Nothing
    End Function

    Private Function ResolveDepartmentId() As Integer?
        Try
            If departmentDirectory Is Nothing OrElse departmentDirectory.Rows.Count = 0 Then Return Nothing

            Dim value = departmentId.SelectedValue
            If value IsNot Nothing Then
                ' Handle DataRowView
                If TypeOf value Is DataRowView Then
                    Dim drv As DataRowView = CType(value, DataRowView)
                    If drv.Row.Table.Columns.Contains("department_id") AndAlso Not drv.Row.IsNull("department_id") Then
                        Dim parsed As Integer
                        If Integer.TryParse(drv.Row("department_id").ToString(), parsed) Then
                            Return parsed
                        End If
                    End If
                Else
                    ' Handle direct integer value
                    Dim parsed As Integer
                    If Integer.TryParse(value.ToString(), parsed) Then
                        Return parsed
                    End If
                End If
            End If

            ' Fallback to text matching
            Dim textValue As String = departmentId.Text?.Trim()
            If String.IsNullOrWhiteSpace(textValue) Then Return Nothing

            Dim match = departmentDirectory.AsEnumerable().
                FirstOrDefault(Function(r) String.Equals(r("department_name").ToString(), textValue, StringComparison.OrdinalIgnoreCase))
            If match IsNot Nothing Then
                Return Convert.ToInt32(match("department_id"))
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ResolveDepartmentId Exception: " & ex.Message)
        End Try
        Return Nothing
    End Function

    Private Function GetSupplierValue() As String
        ' Supplier field removed from schema - return empty string
        Return ""
    End Function

    Private Shared Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        If combo.SelectedItem Is Nothing Then
            Dim textValue = combo.Text
            If Not String.IsNullOrWhiteSpace(textValue) Then
                Return textValue.Trim()
            End If
            Return fallback
        End If
        Return combo.SelectedItem.ToString()
    End Function



    Private Sub conditionStatusCmbo_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub datePurchasedDate_ValueChanged(sender As Object, e As EventArgs) Handles acquisitionDate.ValueChanged

    End Sub

    Private Sub AddProperty_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub location_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
