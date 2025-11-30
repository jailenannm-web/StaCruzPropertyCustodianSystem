Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class EditPropertyManagement
    Inherits UserControl

    Private PropertyIDValue As Integer
    Private propertyRecord As DataRow
    Private canModifyProperties As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf EditPropertyManagement_Load
    End Sub

    Private Sub EditPropertyManagement_Load(sender As Object, e As EventArgs)
        If Not EnsureModifyPermission() Then
            Return
        End If
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        If cboCategory.Items.Count = 0 Then
            cboCategory.Items.AddRange(New Object() {
                "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                "Laboratory Apparatus", "Books and Publications",
                "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
            })
        End If

        If conditionStatusCmbo.Items.Count = 0 Then
            conditionStatusCmbo.Items.AddRange(New Object() {"good", "needs repair", "damaged"})
        End If
    End Sub

    Public Sub LoadProperty(propertyID As Integer)
        PropertyIDValue = propertyID
        propertyRecord = DatabaseConnection.GetPropertyForEdit(propertyID)
        If propertyRecord Is Nothing Then
            MessageBox.Show("Unable to find the selected property.", "Property Management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NavigateBack()
            Return
        End If

        txtpropertyID.Text = propertyID.ToString()
        txtPropertyName.Text = SafeValue("item_name")
        SelectComboValue(cboCategory, SafeValue("category"))
        txtSerialNumber.Text = SafeValue("serial_number")
        txtSupplier.Text = SafeValue("supplier_name")
        SelectComboValue(conditionStatusCmbo, SafeValue("condition_status"))
        txtCost.Text = SafeDecimal("acquisition_cost").ToString("0.00")
        dtpDatePurchased.Value = ParseDate("acquisition_date", Date.Today)
        dtpWarrantyExpiration.Value = ParseDate("updated_at", Date.Today)
        txtAssignedEmployee.Text = SafeValue("custodian_id")
        txtAssignedDepartment.Text = SafeValue("department_id")
        txtLocation.Text = SafeValue("location")
        txtRemarks.Text = SafeValue("description")
        dtpDateCreated.Value = ParseDate("created_at", Date.Today)
        dtpDateUpdated.Value = ParseDate("updated_at", Date.Today)
    End Sub

    Public Sub LoadPropertyData(
        propertyID As Integer,
        propertyName As String,
        category As String,
        serialNumber As String,
        supplier As String,
        conditionStatus As String,
        cost As Decimal,
        datePurchased As Date,
        warrantyExpiration As Date,
        assignedEmployee As String,
        assignedDepartment As String,
        location As String,
        remarks As String,
        dateCreated As Date,
        dateUpdated As Date)

        PropertyIDValue = propertyID
        txtpropertyID.Text = propertyID.ToString()
        txtPropertyName.Text = propertyName
        SelectComboValue(cboCategory, category)
        txtSerialNumber.Text = serialNumber
        txtSupplier.Text = supplier
        SelectComboValue(conditionStatusCmbo, conditionStatus)
        txtCost.Text = cost.ToString("0.00")
        dtpDatePurchased.Value = datePurchased
        dtpWarrantyExpiration.Value = warrantyExpiration
        txtAssignedEmployee.Text = assignedEmployee
        txtAssignedDepartment.Text = assignedDepartment
        txtLocation.Text = location
        txtRemarks.Text = remarks
        dtpDateCreated.Value = dateCreated
        dtpDateUpdated.Value = dateUpdated
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not canModifyProperties AndAlso Not EnsureModifyPermission() Then
            Return
        End If
        If txtPropertyName.Text.Trim().Length = 0 Then
            MessageBox.Show("Property name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim costValue As Decimal
        If Not Decimal.TryParse(txtCost.Text, costValue) Then
            MessageBox.Show("Please enter a valid acquisition cost.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmation = MessageBox.Show("Save changes to this property?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmation <> DialogResult.Yes Then Return

        Dim custodianId As Integer? = ParseNullableInt(txtAssignedEmployee.Text)
        Dim departmentId As Integer? = ParseNullableInt(txtAssignedDepartment.Text)
        Dim statusValue As String = If(propertyRecord IsNot Nothing, SafeValue("status"), "active")

        Dim updateOk = DatabaseConnection.UpdateProperty(
            PropertyIDValue,
            txtPropertyName.Text.Trim(),
            GetComboValue(cboCategory, "Others"),
            txtRemarks.Text.Trim(),
            txtSerialNumber.Text.Trim(),
            GetComboValue(conditionStatusCmbo, "good"),
            txtLocation.Text.Trim(),
            custodianId,
            departmentId,
            warrantyDetails:=txtRemarks.Text.Trim(),
            acquisitionDate:=dtpDatePurchased.Value,
            acquisitionCost:=costValue,
            supplierName:=txtSupplier.Text.Trim(),
            supplierContact:="",
            status:=statusValue)

        If updateOk Then
            MessageBox.Show("Property updated successfully!", "Property Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        NavigateBack()
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyManagement1())
        Else
            MessageBox.Show("Parent form not detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function SafeValue(columnName As String) As String
        If propertyRecord Is Nothing OrElse Not propertyRecord.Table.Columns.Contains(columnName) Then Return ""
        Dim value = propertyRecord(columnName)
        Return If(value Is Nothing OrElse value Is DBNull.Value, "", value.ToString())
    End Function

    Private Function SafeDecimal(columnName As String) As Decimal
        Dim textValue As String = SafeValue(columnName)
        Dim parsed As Decimal
        If Decimal.TryParse(textValue, parsed) Then Return parsed
        Return 0D
    End Function

    Private Function ParseDate(columnName As String, fallback As Date) As Date
        Dim textValue As String = SafeValue(columnName)
        Dim parsed As Date
        If Date.TryParse(textValue, parsed) Then Return parsed
        Return fallback
    End Function

    Private Sub SelectComboValue(combo As ComboBox, value As String)
        If combo Is Nothing Then Return
        If String.IsNullOrWhiteSpace(value) Then
            combo.SelectedIndex = -1
            combo.Text = ""
            Return
        End If

        Dim index = combo.Items.IndexOf(value)
        If index >= 0 Then
            combo.SelectedIndex = index
        Else
            combo.SelectedIndex = -1
            combo.Text = value
        End If
    End Sub

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

    Private Shared Function ParseNullableInt(text As String) As Integer?
        If String.IsNullOrWhiteSpace(text) Then Return Nothing
        Dim candidate = text.Trim()
        If candidate.Contains("-") Then
            candidate = candidate.Split("-"c)(0).Trim()
        End If
        Dim parsed As Integer
        If Integer.TryParse(candidate, parsed) Then Return parsed
        Return Nothing
    End Function

    Private Function EnsureModifyPermission() As Boolean
        canModifyProperties = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyProperties)
        If Not canModifyProperties Then
            MessageBox.Show("You have view-only access to Property Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class
