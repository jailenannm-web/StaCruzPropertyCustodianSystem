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
    End Sub

    Private Sub ResetForm()
        userID.Text = ""
        firstName.Clear()
        middleName.Clear()
        lastName.Clear()
        employeeID.Clear()
        contactNumber.Clear()
        email.Clear()
        passwordAddUser.Clear()
        passwordAddUser.Clear()
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


        Dim employeeCode As String = employeeID.Text.Trim()
        Dim usernameValue As String = If(String.IsNullOrWhiteSpace(employeeCode), email.Text.Trim(), employeeCode)
        If String.IsNullOrWhiteSpace(usernameValue) Then
            usernameValue = (firstName.Text.Trim() & "." & lastName.Text.Trim()).ToLowerInvariant()
        End If

        Dim roleValue As String = GetComboValue(departmentID, "Admin")
        Dim userTypeValue As String = If(String.Equals(roleValue, "SuperAdmin", StringComparison.OrdinalIgnoreCase), "SuperAdmin", "Admin")
        Dim positionValue As String = GetComboValue(positionAdmin, If(String.IsNullOrWhiteSpace(roleValue), "Administrator", roleValue))

        Dim success As Boolean = DatabaseConnection.AddAdminAccount(
            firstName.Text.Trim(),
            lastName.Text.Trim(),
            email.Text.Trim(),
            usernameValue,
            passwordAddUser.Text,
            middleName:=middleName.Text.Trim(),
            suffix:=GetComboValue(suffixAdmin),
            position:=positionValue,
            contactNumber:=contactNumber.Text.Trim(),
            houseNoStreet:=passwordAddUser.Text.Trim(),
            barangay:=GetComboValue(barangay),
            municipality:=GetComboValue(municipality),
            provinceCity:=GetComboValue(provinceAdmin),
            employeeID:=employeeCode,
            userType:=userTypeValue,
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
        If Not IsValidEmail(email.Text) Then Return "Please enter a valid email address."
        If departmentID.SelectedIndex = -1 Then Return "Please select a user role."
        If String.IsNullOrWhiteSpace(employeeID.Text) Then Return "Employee ID is required."
        If String.IsNullOrWhiteSpace(passwordAddUser.Text) Then Return "Please provide an initial password."
        Return ""
    End Function

    Private Shared Function IsValidEmail(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return False
        Dim pattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Return Regex.IsMatch(value.Trim(), pattern, RegexOptions.IgnoreCase)
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

End Class
