Imports System
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Public Class AddUserManagement1
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

    Private Sub ShowManageRestriction()
        ' No restrictions for Super Admin, Admin, and Custodian
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If hasFullAccess Then
            Return
        End If
        MessageBox.Show("You have view-only access to User Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
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


        Me.userID.Text = userID
        Me.firstName.Text = firstName
        Me.middleName.Text = middleName
        Me.lastName.Text = lastName
        Me.departmentID.Text = departmentID
        Me.employeeID.Text = employeeID
        Me.contactNumber.Text = contactNumber
        Me.email.Text = email
        Me.UserName.Text = houseNumber
        Me.password.Text = password

        SetComboValue(suffixAdmin, suffixValue)
        SetComboValue(positionAdmin, position)


        SetComboValue(Me.municipality, municipalityValue)
        SetComboValue(Me.barangay, barangayValue)


        editingUsername = username
        currentUserType = userRole ' Store the current user type
    End Sub

    Private Sub LoadDepartmentOptions()
        Try
            departmentDirectory = modDB.GetDepartmentLookup(True)
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


    Private Shared Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        If combo.SelectedItem Is Nothing Then
            Dim manualValue As String = combo.Text
            If Not String.IsNullOrWhiteSpace(manualValue) Then
                Return manualValue.Trim()
            End If
            Return If(String.IsNullOrWhiteSpace(fallback), "", fallback)
        End If
        
        ' Handle DataRowView case - extract the actual value
        If TypeOf combo.SelectedItem Is DataRowView Then
            Dim drv As DataRowView = CType(combo.SelectedItem, DataRowView)
            ' Try to get the value using ValueMember first
            If Not String.IsNullOrEmpty(combo.ValueMember) AndAlso drv.Row.Table.Columns.Contains(combo.ValueMember) Then
                Return drv.Row(combo.ValueMember).ToString()
            End If
            ' Fallback to DisplayMember
            If Not String.IsNullOrEmpty(combo.DisplayMember) AndAlso drv.Row.Table.Columns.Contains(combo.DisplayMember) Then
                Return drv.Row(combo.DisplayMember).ToString()
            End If
        End If
        
        ' Try SelectedValue as fallback
        If combo.SelectedValue IsNot Nothing Then
            Return combo.SelectedValue.ToString()
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

    Private Shared Function IsValidEmail(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return False
        Return Regex.IsMatch(value.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase)
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

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub municipality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles municipality.SelectedIndexChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub barangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles barangay.SelectedIndexChanged

    End Sub
End Class
