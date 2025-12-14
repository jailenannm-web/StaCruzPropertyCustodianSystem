Imports System
Imports System.Windows.Forms

Public Class AddSupply
    Inherits UserControl

    Private canModifySupplies As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub AddSupply_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
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
        Dim supplyIDValue As String = If(String.IsNullOrWhiteSpace(description.Text), Guid.NewGuid().ToString().Substring(0, 8), description.Text.Trim())
        Dim supplyNameValue As String = itemName.Text.Trim()
        Dim categoryValue As String = If(category.SelectedIndex >= 0, category.SelectedItem.ToString(), category.Text.Trim())
        Dim stockValue As Integer = CInt(quantity.Value)
        Dim unitCostValue As Decimal = 0
        Dim totalValue As Decimal = 0
        Dim locationValue As String = ""
        Dim descriptionValue As String = If(supplier IsNot Nothing, supplier.Text.Trim(), "")
        Dim uomValue As String = "pcs" ' Default unit of measure
        Dim supplierIDValue As String = If(unitCost IsNot Nothing, unitCost.Text.Trim(), "")

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

        ' Call DatabaseConnection.AddSupply
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
            supplierIDValue
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
End Class

