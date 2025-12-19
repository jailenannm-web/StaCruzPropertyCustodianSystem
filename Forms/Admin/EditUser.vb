Imports System
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Public Class EditUser
    Inherits UserControl

    Private currentAdminID As Integer?
    Private currentAdminType As String = ""
    Private currentAdminUsername As String = ""
    Private editingUsername As String = ""
    Private currentUserType As String = "" ' Store the current user type being edited
    Private departmentDirectory As DataTable
    Private canManageUsers As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf EditUser_Load
    End Sub

    Public Sub SetAuditContext(adminID As Integer?, adminType As String, adminUsername As String)
        currentAdminID = adminID
        currentAdminType = adminType
        currentAdminUsername = adminUsername
        canManageUsers = SessionContext.HasPermission(SessionContext.ModulePermission.ManageUsers)
        ApplyPermissionState()
    End Sub

    Private Sub EditUser_Load(sender As Object, e As EventArgs)
        LoadDepartmentOptions()
        If Not canManageUsers Then
            canManageUsers = SessionContext.HasPermission(SessionContext.ModulePermission.ManageUsers)
            ApplyPermissionState()
        End If
    End Sub

    Private Sub ApplyPermissionState()
        If um_edituser_save IsNot Nothing Then
            um_edituser_save.Enabled = canManageUsers
        End If
    End Sub


    ' Load user data into the fields
    Public Sub LoadUserData(userID As String,
                            firstName As String,
                            middleName As String,
                            lastName As String,
                            suffixValue As String,
                            position As String,
                            departmentID As String,
                            employeeID As String,
                            contactNumber As String,
                            email As String,
                            userRole As String,
                            provinceValue As String,
                            municipalityValue As String,
                            barangayValue As String,
                            password As String,
                            dateRegistered As Date,
                            username As String)


        Me.userID.Text = userID
        Me.firstName.Text = firstName
        Me.middleName.Text = middleName
        Me.lastName.Text = lastName
        Me.departmentID.Text = departmentID
        Me.employeeID.Text = employeeID
        Me.contactNumber.Text = contactNumber
        Me.email.Text = email
        Me.password.Text = password

        SetComboValue(suffixAdmin, suffixValue)
        SetComboValue(positionAdmin, position)
        SetComboValue(usernameAdmin, userRole)
        SetComboValue(Me.province, provinceValue)
        SetComboValue(Me.municipality, municipalityValue)
        SetComboValue(Me.barangay, barangayValue)

        editingUsername = username
        currentUserType = userRole ' Store the current user type
    End Sub

    Private Sub LoadDepartmentOptions()
        Try
            departmentDirectory = DatabaseConnection.GetDepartmentLookup(True)
            If departmentDirectory Is Nothing Then Return

            Dim suggestions As New AutoCompleteStringCollection()
            For Each row As DataRow In departmentDirectory.Rows
                suggestions.Add($"{row("department_id")} - {row("department_name")}")
            Next

            departmentID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            departmentID.AutoCompleteSource = AutoCompleteSource.CustomSource
            departmentID.AutoCompleteCustomSource = suggestions
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditUser.LoadDepartmentOptions Exception: " & ex.Message)
        End Try
    End Sub


    ' Save button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles um_edituser_save.Click
        If Not canManageUsers Then

            Return
        End If
        Dim validationMessage As String = ValidateFields()
        If Not String.IsNullOrEmpty(validationMessage) Then
            MessageBox.Show(validationMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim adminIDValue As Integer
        If Not Integer.TryParse(userID.Text, adminIDValue) Then
            MessageBox.Show("Invalid user identifier.", "User Management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim deptID As Integer? = ResolveDepartmentId()

        Dim roleValue As String = GetComboValue(usernameAdmin, currentUserType)
        ' Determine the new user type from dropdown
        Dim newUserTypeValue As String = If(String.Equals(roleValue, "SuperAdmin", StringComparison.OrdinalIgnoreCase), "SuperAdmin",
                                            If(String.Equals(roleValue, "Staff", StringComparison.OrdinalIgnoreCase), "Staff", "Admin"))

        ' Use current user type to determine which table to update (can't change Staff to Admin or vice versa in single update)
        ' For Staff accounts, keep as Staff. For Admin/SuperAdmin, allow role changes between Admin and SuperAdmin
        Dim tableUserType As String = currentUserType
        If String.IsNullOrEmpty(tableUserType) Then
            tableUserType = newUserTypeValue
        End If

        ' If current is Staff, new type must also be Staff
        If tableUserType = "Staff" AndAlso newUserTypeValue <> "Staff" Then
            MessageBox.Show("Cannot change Staff account to Admin or SuperAdmin. Staff accounts must remain as Staff.",
                           "Role Change Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' If current is Admin/SuperAdmin, new type must also be Admin or SuperAdmin
        If (tableUserType = "Admin" OrElse tableUserType = "SuperAdmin") AndAlso newUserTypeValue = "Staff" Then
            MessageBox.Show("Cannot change Admin/SuperAdmin account to Staff. Please create a new Staff account instead.",
                           "Role Change Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim positionValue As String = GetComboValue(positionAdmin, If(String.IsNullOrWhiteSpace(roleValue), "Administrator", roleValue))

        ' Use unified UpdateUserAccount function that handles both Admin/SuperAdmin and Staff
        Dim updateSuccess As Boolean = DatabaseConnection.UpdateUserAccount(
            adminIDValue,
            tableUserType, ' Use current user type to determine which table to update
            firstName.Text.Trim(),
            lastName.Text.Trim(),
            email.Text.Trim(),
            editingUsername,
            middleName:=middleName.Text.Trim(),
            suffix:=GetComboValue(suffixAdmin),
            position:=positionValue,
            departmentID:=deptID,
            contactNumber:=contactNumber.Text.Trim(),
            barangay:=GetComboValue(barangay),
            municipality:=GetComboValue(municipality),
            provinceCity:=GetComboValue(province),
            employeeID:=employeeID.Text.Trim(),
            newUserType:=newUserTypeValue, ' New role (only applies to Admin/SuperAdmin)
            updatedByID:=currentAdminID,
            updatedByType:=currentAdminType,
            updatedByName:=currentAdminUsername,
            ipAddress:="",
            moduleName:="User Management",
            entityLabel:="User Account"
        )

        If updateSuccess Then
            If Not String.IsNullOrWhiteSpace(password.Text) Then
                ' Use unified ResetUserPassword function that handles both Admin/SuperAdmin and Staff
                DatabaseConnection.ResetUserPassword(adminIDValue,
                                                     tableUserType, ' Use current user type to determine which table to update
                                                     password.Text,
                                                     currentAdminID,
                                                     currentAdminType,
                                                     currentAdminUsername,
                                                     "",
                                                     "User Management",
                                                     "User Account")
            End If

            MessageBox.Show("User account updated successfully.", "User Management",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If usernameAdmin.SelectedIndex = -1 Then Return "Please select a user role."
        Return ""
    End Function

    Private Shared Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        If combo.SelectedItem Is Nothing Then
            Dim manualValue As String = combo.Text
            If Not String.IsNullOrWhiteSpace(manualValue) Then
                Return manualValue.Trim()
            End If
            Return If(String.IsNullOrWhiteSpace(fallback), "", fallback)
        End If
        Return combo.SelectedItem.ToString()
    End Function

    Private Function ResolveDepartmentId() As Integer?
        Dim rawValue As String = departmentID.Text.Trim()
        If String.IsNullOrWhiteSpace(rawValue) Then Return Nothing
        Dim candidate As String = rawValue
        If rawValue.Contains("-") Then
            candidate = rawValue.Split("-"c)(0).Trim()
        End If
        Dim parsed As Integer
        If Integer.TryParse(candidate, parsed) Then
            Return parsed
        End If
        Return Nothing
    End Function



    Private Sub SetComboValue(combo As ComboBox, value As String)
        If combo Is Nothing Then Return
        If String.IsNullOrWhiteSpace(value) Then
            combo.SelectedIndex = -1
            Return
        End If

        Dim index As Integer = combo.Items.IndexOf(value)
        If index >= 0 Then
            combo.SelectedIndex = index
        Else
            combo.SelectedIndex = -1
            combo.Text = value
        End If
    End Sub

    Private Sub uc_um_edituser_Paint(sender As Object, e As PaintEventArgs) Handles uc_um_edituser.Paint

    End Sub

    Private Sub EditUser_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
