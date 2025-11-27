Imports System
Imports System.Windows.Forms
Public Class EditUser
    Inherits UserControl

    Private currentAdminID As Integer?
    Private currentAdminType As String = ""
    Private currentAdminUsername As String = ""
    Private editingUsername As String = ""

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf EditUser_Load
    End Sub

    Public Sub SetAuditContext(adminID As Integer?, adminType As String, adminUsername As String)
        currentAdminID = adminID
        currentAdminType = adminType
        currentAdminUsername = adminUsername
    End Sub

    Private Sub EditUser_Load(sender As Object, e As EventArgs)
        PopulateDropdowns()
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
                            houseNumber As String,
                            password As String,
                            dateRegistered As Date,
                            statusValue As String,
                            username As String)

        PopulateDropdowns()

        Me.userID.Text = userID
        Me.firstName.Text = firstName
        Me.middleName.Text = middleName
        Me.lastName.Text = lastName
        Me.departmentID.Text = departmentID
        Me.employeeID.Text = employeeID
        Me.contactNumber.Text = contactNumber
        Me.email.Text = email
        Me.houseNumber.Text = houseNumber
        Me.password.Text = password

        SetComboValue(suffixAdmin, suffixValue)
        SetComboValue(positionAdmin, position)
        SetComboValue(ComboBox1, userRole)
        SetComboValue(Me.province, provinceValue)
        SetComboValue(Me.municipality, municipalityValue)
        SetComboValue(Me.barangay, barangayValue)
        SetComboValue(statusAdmin, statusValue)

        Me.dateRegistered.Value = dateRegistered
        editingUsername = username
    End Sub

    Private Sub PopulateDropdowns()
        If ComboBox1.Items.Count = 0 Then
            ComboBox1.Items.AddRange(New Object() {"Admin", "SuperAdmin"})
        End If
        If statusAdmin.Items.Count = 0 Then
            statusAdmin.Items.AddRange(New Object() {"Active", "Inactive"})
        End If
        If suffixAdmin.Items.Count = 0 Then
            suffixAdmin.Items.AddRange(New Object() {"", "JR.", "SR.", "II", "III", "IV"})
        End If
    End Sub


    ' Save button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles um_edituser_save.Click
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

        Dim deptID As Integer? = Nothing
        Dim deptParsed As Integer
        If Integer.TryParse(departmentID.Text.Trim(), deptParsed) Then
            deptID = deptParsed
        End If

        Dim roleValue As String = GetComboValue(ComboBox1, "Admin")
        Dim statusValue As String = GetComboValue(statusAdmin, "Active")
        Dim positionValue As String = GetComboValue(positionAdmin, "Administrator")

        Dim updateSuccess As Boolean = DatabaseConnection.UpdateAdminAccount(
            adminIDValue,
            firstName.Text.Trim(),
            lastName.Text.Trim(),
            email.Text.Trim(),
            editingUsername,
            middleName:=middleName.Text.Trim(),
            suffix:=GetComboValue(suffixAdmin),
            position:=positionValue,
            departmentID:=deptID,
            contactNumber:=contactNumber.Text.Trim(),
            houseNoStreet:=houseNumber.Text.Trim(),
            barangay:=GetComboValue(barangay),
            municipality:=GetComboValue(municipality),
            provinceCity:=GetComboValue(province),
            dateAssigned:=dateRegistered.Value,
            employeeID:=employeeID.Text.Trim(),
            userType:=roleValue,
            status:=statusValue,
            updatedByID:=currentAdminID,
            updatedByType:=currentAdminType,
            updatedByName:=currentAdminUsername,
            ipAddress:="",
            moduleName:="User Management",
            entityLabel:="User Account"
        )

        If updateSuccess Then
            If Not String.IsNullOrWhiteSpace(password.Text) Then
                DatabaseConnection.ResetAdminPassword(adminIDValue,
                                                      password.Text,
                                                      currentAdminID,
                                                      currentAdminType,
                                                      currentAdminUsername,
                                                      "",
                                                      "User Management",
                                                      "User Account")
            End If

            MessageBox.Show("User account updated.", "User Management",
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
        If ComboBox1.SelectedIndex = -1 Then Return "Please select a user role."
        If statusAdmin.SelectedIndex = -1 Then Return "Please select an account status."
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
End Class
