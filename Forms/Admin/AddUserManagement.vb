Imports System
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class AddUserManagement
    Inherits UserControl

    Private currentAdminID As Integer?
    Private currentAdminType As String = ""
    Private currentAdminUsername As String = ""
    Private departmentDirectory As DataTable

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf AddUserManagement_Load
    End Sub

    Public Sub SetAuditContext(adminID As Integer?, adminType As String, adminUsername As String)
        currentAdminID = adminID
        currentAdminType = adminType
        currentAdminUsername = adminUsername
    End Sub

    Private Sub AddUserManagement_Load(sender As Object, e As EventArgs)
        ResetForm()
        LoadDepartmentDropdown()
        Role.SelectedIndex = -1
    End Sub

    Private Sub LoadDepartmentDropdown()
        Try
            departmentID.Items.Clear()
            Dim deptTable As DataTable = DatabaseConnection.GetDepartmentLookup(True)
            departmentID.DisplayMember = "department_name"
            departmentID.ValueMember = "department_id"
            departmentID.DataSource = deptTable
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentDropdown Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ResetForm()
        userID.Text = ""
        firstName.Clear()
        middleName.Clear()
        lastName.Clear()
        EmployeeID.Clear()
        contactNumber.Clear()
        email.Clear()
        passwordAdmin.Clear()
        passwordAdmin.Clear()
        departmentID.SelectedIndex = -1
        suffixAdmin.SelectedIndex = -1
        positionAdmin.SelectedIndex = -1
        provinceAdmin.SelectedIndex = -1
        municipality.SelectedIndex = -1
        barangay.SelectedIndex = -1
    End Sub

    ' Save button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles um_edituser_save.Click
        Dim validationMessage As String = ValidateFields()
        If Not String.IsNullOrEmpty(validationMessage) Then
            MessageBox.Show(validationMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim employeeCode As String = EmployeeID.Text.Trim()
        Dim usernameValue As String = If(String.IsNullOrWhiteSpace(employeeCode), email.Text.Trim(), employeeCode)
        If String.IsNullOrWhiteSpace(usernameValue) Then
            usernameValue = (firstName.Text.Trim() & "." & lastName.Text.Trim()).ToLowerInvariant()
        End If

        Dim roleValue As String = GetComboValue(Role, "")
        If String.IsNullOrWhiteSpace(roleValue) Then
            MessageBox.Show("Please select a role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Normalize role value to match database enum
        If roleValue = "SuperAdmin" Then roleValue = "SuperAdmin"
        If roleValue = "Admin" Then roleValue = "Admin"
        If roleValue = "Custodian" Then roleValue = "Custodian"
        If roleValue = "Staff" Then roleValue = "Staff"
        Dim positionValue As String = GetComboValue(positionAdmin, If(String.IsNullOrWhiteSpace(roleValue), "Administrator", roleValue))

        ' Get department ID from dropdown if selected
        ' Get department ID from dropdown if selected
        Dim selectedDeptID As Integer? = Nothing

        If departmentID.SelectedIndex >= 0 AndAlso departmentID.SelectedItem IsNot Nothing Then
            Dim deptValue As Object = departmentID.SelectedValue

            If deptValue IsNot Nothing Then

                ' If SelectedValue is DataRowView
                If TypeOf deptValue Is DataRowView Then
                    Dim drv As DataRowView = CType(deptValue, DataRowView)

                    ' FIXED: use Row.IsNull instead of IsDBNull
                    If drv.Row.Table.Columns.Contains("department_id") AndAlso
               Not drv.Row.IsNull("department_id") Then

                        Integer.TryParse(drv.Row("department_id").ToString(), selectedDeptID)
                    End If

                    ' If SelectedValue is already an Integer
                ElseIf TypeOf deptValue Is Integer Then
                    selectedDeptID = CInt(deptValue)

                End If
            End If
        End If


        Dim success As Boolean = DatabaseConnection.AddAdminAccount(
            firstName.Text.Trim(),
            lastName.Text.Trim(),
            email.Text.Trim(),
            usernameValue,
            passwordAdmin.Text,
            middleName:=middleName.Text.Trim(),
            suffix:=GetComboValue(suffixAdmin),
            position:=positionValue,
            departmentID:=selectedDeptID,
            contactNumber:=contactNumber.Text.Trim(),
            houseNoStreet:="",
            barangay:=GetComboValue(barangay),
            municipality:=GetComboValue(municipality),
            provinceCity:=GetComboValue(provinceAdmin),
            employeeID:=employeeCode,
            userType:=roleValue,
            createdByID:=currentAdminID,
            createdByType:=currentAdminType,
            createdByName:=currentAdminUsername,
            ipAddress:="",
            moduleName:="User Management",
            entityLabel:="User Account"
        )

        If success Then
            MessageBox.Show("User account created successfully.",
                            "User Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBackToList()
        End If
    End Sub

    ' Back button
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles um_edituser_backbtn.Click
        NavigateBackToList()
    End Sub

    Private Sub NavigateBackToList()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_UserManagement())
        End If
    End Sub

    Private Function ValidateFields() As String
        If String.IsNullOrWhiteSpace(firstName.Text) Then Return "First name is required."
        If String.IsNullOrWhiteSpace(lastName.Text) Then Return "Last name is required."
        If String.IsNullOrWhiteSpace(email.Text) Then Return "Email is required."

        Dim roleValue As String = GetComboValue(Role, "")
        If String.IsNullOrWhiteSpace(roleValue) Then Return "Please select a user role."
        If String.IsNullOrWhiteSpace(EmployeeID.Text) Then Return "Employee ID is required."
        If String.IsNullOrWhiteSpace(passwordAdmin.Text) Then Return "Please provide an initial password."
        Return ""
    End Function



    Private Shared Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        If combo.SelectedIndex >= 0 AndAlso combo.SelectedItem IsNot Nothing Then
            Return combo.SelectedItem.ToString()
        End If
        Dim manualValue As String = combo.Text
        If Not String.IsNullOrWhiteSpace(manualValue) Then
            Return manualValue.Trim()
        End If
        Return If(String.IsNullOrWhiteSpace(fallback), "", fallback)
    End Function

End Class
