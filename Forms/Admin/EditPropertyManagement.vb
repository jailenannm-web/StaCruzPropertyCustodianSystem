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
            ' Match database ENUM values: 'Good', 'Needs Repair', 'Damaged'
            conditionStatusCmbo.Items.AddRange(New Object() {"Good", "Needs Repair", "Damaged"})
        End If

        ' Load departments
        LoadDepartments()
        LoadSuppliers()

        ' Wire up department change event for cascading employee dropdown
        AddHandler txtAssignedDepartment.SelectedIndexChanged, AddressOf txtAssignedDepartment_SelectedIndexChanged
    End Sub

    Private Sub LoadSuppliers()
        Try
            Dim suppliersTable As DataTable = DatabaseConnection.GetSuppliers()
            If suppliersTable IsNot Nothing AndAlso suppliersTable.Rows.Count > 0 Then
                If txtSupplier IsNot Nothing AndAlso TypeOf txtSupplier Is ComboBox Then
                    Dim supplierCombo As ComboBox = CType(txtSupplier, ComboBox)
                    supplierCombo.DataSource = suppliersTable
                    supplierCombo.DisplayMember = "supplier_name"
                    supplierCombo.ValueMember = "supplier_name"
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditPropertyManagement.LoadSuppliers Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            Dim deptTable As DataTable = DatabaseConnection.GetDepartmentLookup(True)
            If deptTable IsNot Nothing AndAlso deptTable.Rows.Count > 0 Then
                txtAssignedDepartment.DataSource = deptTable
                txtAssignedDepartment.DisplayMember = "department_name"
                txtAssignedDepartment.ValueMember = "department_id"
            Else
                txtAssignedDepartment.Items.Clear()
                txtAssignedDepartment.Items.Add("No Departments Available")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditPropertyManagement.LoadDepartments Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadEmployeesByDepartment(departmentID As Integer)
        Try
            Dim usersTable As DataTable = DatabaseConnection.GetUsersByDepartment(departmentID)
            If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 Then
                txtAssignedEmployee.DataSource = usersTable
                txtAssignedEmployee.DisplayMember = "fullName"
                txtAssignedEmployee.ValueMember = "userId"
            Else
                txtAssignedEmployee.Items.Clear()
                txtAssignedEmployee.Items.Add("No employees in this department")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditPropertyManagement.LoadEmployeesByDepartment Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub txtAssignedDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' When department changes, reload employees for that department
        If txtAssignedDepartment.SelectedValue IsNot Nothing Then
            Dim deptID As Integer
            If TypeOf txtAssignedDepartment.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(txtAssignedDepartment.SelectedValue, DataRowView)
                If Integer.TryParse(drv.Row("department_id").ToString(), deptID) Then
                    LoadEmployeesByDepartment(deptID)
                End If
            ElseIf Integer.TryParse(txtAssignedDepartment.SelectedValue.ToString(), deptID) Then
                LoadEmployeesByDepartment(deptID)
            End If
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
        txtPropertyName.Text = SafeValue("itemName")
        SelectComboValue(cboCategory, SafeValue("category"))
        txtSerialNumber.Text = SafeValue("serialNumber")
        ' Set supplier from dropdown if it's a ComboBox, otherwise use TextBox
        Dim supplierValue As String = SafeValue("supplier")
        If txtSupplier IsNot Nothing Then
            If TypeOf txtSupplier Is ComboBox Then
                Dim supplierCombo As ComboBox = CType(txtSupplier, ComboBox)
                Dim supplierIndex As Integer = supplierCombo.FindStringExact(supplierValue)
                If supplierIndex >= 0 Then
                    supplierCombo.SelectedIndex = supplierIndex
                Else
                    supplierCombo.Text = supplierValue
                End If
            Else
                txtSupplier.Text = supplierValue
            End If
        End If
        ' Fix condition value to match dropdown options
        Dim conditionValue As String = SafeValue("condition")
        If String.IsNullOrEmpty(conditionValue) Then conditionValue = "New"
        ' Map old values to new values
        If conditionValue.Equals("Needs Repair", StringComparison.OrdinalIgnoreCase) Then conditionValue = "For Repair"
        If conditionValue.Equals("good", StringComparison.OrdinalIgnoreCase) Then conditionValue = "Good"
        If conditionValue.Equals("damaged", StringComparison.OrdinalIgnoreCase) Then conditionValue = "Damaged"
        SelectComboValue(conditionStatusCmbo, conditionValue)
        txtCost.Text = SafeDecimal("acquisitionCost").ToString("0.00")
        dtpDatePurchased.Value = ParseDate("acquisitionDate", Date.Today)
        dtpWarrantyExpiration.Value = ParseDate("updatedAt", Date.Today)

        ' Show employee name instead of ID
        Dim employeeName As String = SafeValue("assignedEmployee")
        If String.IsNullOrEmpty(employeeName) Then
            Dim assignedToID As String = SafeValue("assignedTo")
            If Not String.IsNullOrEmpty(assignedToID) Then
                employeeName = "User ID: " & assignedToID
            End If
        End If
        txtAssignedEmployee.Text = employeeName

        ' Load department dropdown and set selected value
        Dim deptID As String = SafeValue("departmentId")
        If Not String.IsNullOrEmpty(deptID) Then
            Dim deptIDInt As Integer
            If Integer.TryParse(deptID, deptIDInt) Then
                ' Refresh departments and employees for the selected department
                LoadDepartments()
                LoadEmployeesByDepartment(deptIDInt)

                ' Prefer direct SelectedValue assignment; fallback to item scan if needed
                Try
                    txtAssignedDepartment.SelectedValue = deptIDInt
                Catch
                    For i As Integer = 0 To txtAssignedDepartment.Items.Count - 1
                        If TypeOf txtAssignedDepartment.Items(i) Is DataRowView Then
                            Dim drv As DataRowView = CType(txtAssignedDepartment.Items(i), DataRowView)
                            If drv.Row("department_id").ToString() = deptID Then
                                txtAssignedDepartment.SelectedIndex = i
                                Exit For
                            End If
                        End If
                    Next
                End Try
            End If
        End If

        txtLocation.Text = SafeValue("location")
        txtRemarks.Text = SafeValue("description")
        dtpDateCreated.Value = ParseDate("createdAt", Date.Today)
        dtpDateUpdated.Value = ParseDate("updatedAt", Date.Today)
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
        ' No restrictions for Super Admin, Admin, and Custodian
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()

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

        ' Get selected employee ID from dropdown
        Dim custodianId As Integer? = Nothing
        If txtAssignedEmployee.SelectedValue IsNot Nothing Then
            If TypeOf txtAssignedEmployee.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(txtAssignedEmployee.SelectedValue, DataRowView)
                Dim parsed As Integer
                If Integer.TryParse(drv.Row("userId").ToString(), parsed) Then
                    custodianId = parsed
                End If
            Else
                Dim parsed As Integer
                If Integer.TryParse(txtAssignedEmployee.SelectedValue.ToString(), parsed) Then
                    custodianId = parsed
                End If
            End If
        End If

        ' Get selected department ID from dropdown
        Dim departmentId As Integer? = Nothing
        If txtAssignedDepartment.SelectedValue IsNot Nothing Then
            If TypeOf txtAssignedDepartment.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(txtAssignedDepartment.SelectedValue, DataRowView)
                Dim parsed As Integer
                If Integer.TryParse(drv.Row("department_id").ToString(), parsed) Then
                    departmentId = parsed
                End If
            Else
                Dim parsed As Integer
                If Integer.TryParse(txtAssignedDepartment.SelectedValue.ToString(), parsed) Then
                    departmentId = parsed
                End If
            End If
        End If
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


End Class