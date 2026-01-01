Imports System
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Diagnostics

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
        LoadSuffixDropdown()
        LoadDepartmentDropdown()
        LoadProvinceDropdown()
        role.SelectedIndex = -1
    End Sub

    Private Sub LoadSuffixDropdown()
        Try
            suffix.Items.Clear()
            suffix.Items.Add("None")
            suffix.Items.Add("Jr.")
            suffix.Items.Add("Sr.")
            suffix.Items.Add("II")
            suffix.Items.Add("III")
            suffix.Items.Add("IV")
            suffix.SelectedIndex = 0 ' Default to "None"
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadSuffixDropdown Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartmentDropdown()
        Try
            departmentId.Items.Clear()
            Dim deptTable As DataTable = modDB.GetDepartmentLookup(True)
            If deptTable IsNot Nothing AndAlso deptTable.Rows.Count > 0 Then
                departmentId.DisplayMember = "department_name"
                departmentId.ValueMember = "department_id"
                departmentId.DataSource = deptTable
            Else
                ' Add empty option if no departments
                departmentId.Items.Add("No Departments Available")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentDropdown Error: " & ex.Message)
            MessageBox.Show("Failed to load departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadProvinceDropdown()
        Try
            RemoveHandler province.SelectedIndexChanged, AddressOf province_SelectedIndexChanged
            province.Items.Clear()
            Dim provinces As DataTable = modDB.GetProvinces()
            If provinces IsNot Nothing AndAlso provinces.Rows.Count > 0 Then
                province.DisplayMember = "province_name"
                province.ValueMember = "province_id"
                province.DataSource = provinces
            Else
                ' If no province table exists, add common provinces manually
                province.Items.Add("Metro Manila")
                province.Items.Add("Cavite")
                province.Items.Add("Laguna")
                province.Items.Add("Batangas")
                province.Items.Add("Rizal")
                province.Items.Add("Quezon")
            End If
            ' optionally: province.SelectedIndex = -1
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadProvinceDropdown Error: " & ex.Message)
            ' If GetProvinces doesn't exist, add common provinces manually
            province.Items.Add("Metro Manila")
            province.Items.Add("Cavite")
            province.Items.Add("Laguna")
            province.Items.Add("Batangas")
            province.Items.Add("Rizal")
            province.Items.Add("Quezon")
        Finally
            AddHandler province.SelectedIndexChanged, AddressOf province_SelectedIndexChanged
        End Try
    End Sub

    Private Sub province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles province.SelectedIndexChanged
        If province.SelectedIndex < 0 Then Return
        LoadMunicipalityDropdown()
    End Sub

    Private Sub LoadMunicipalityDropdown()
        Try
            ' Ensure unbound before modifying
            If municipal.DataSource IsNot Nothing Then municipal.DataSource = Nothing
            municipal.Items.Clear()

            ' Get the actual province name from the selected item
            Dim selectedProvince As String = ""

            If province.SelectedItem IsNot Nothing Then
                ' Check if it's a DataRowView
                If TypeOf province.SelectedItem Is DataRowView Then
                    Dim drv As DataRowView = CType(province.SelectedItem, DataRowView)
                    ' Get the province_name from the DataRowView
                    If drv.Row.Table.Columns.Contains("province_name") Then
                        selectedProvince = drv.Row("province_name").ToString()
                    End If
                ElseIf TypeOf province.SelectedItem Is DataRow Then
                    Dim dr As DataRow = CType(province.SelectedItem, DataRow)
                    If dr.Table.Columns.Contains("province_name") Then
                        selectedProvince = dr("province_name").ToString()
                    End If
                Else
                    ' It's a simple string
                    selectedProvince = province.SelectedItem.ToString()
                End If
            ElseIf province.SelectedValue IsNot Nothing Then
                ' Fallback to SelectedValue
                selectedProvince = province.SelectedValue.ToString()
            End If

            If String.IsNullOrEmpty(selectedProvince) Then Return

            Dim municipalities As DataTable = modDB.GetMunicipalities(selectedProvince)
            If municipalities IsNot Nothing AndAlso municipalities.Rows.Count > 0 Then
                municipal.DisplayMember = "municipality_name"
                municipal.ValueMember = "municipality_name"
                municipal.DataSource = municipalities
            Else
                municipal.Items.Add("Select Municipality")
            End If
            ' Unbind barangay similarly
            If barangay.DataSource IsNot Nothing Then barangay.DataSource = Nothing
            barangay.Items.Clear()
        Catch ex As Exception
            Debug.WriteLine("[v0] LoadMunicipalityDropdown Error: " & ex.Message)
            municipal.DataSource = Nothing
            municipal.Items.Clear()
            municipal.Items.Add("Select Municipality")
        End Try
    End Sub

    Private Sub municipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles municipal.SelectedIndexChanged
        If municipal.SelectedIndex < 0 Then Return
        LoadBarangayDropdown()
    End Sub

    Private Sub LoadBarangayDropdown()
        Try
            ' CRITICAL: Unbind DataSource BEFORE clearing items to avoid "Items collection cannot be modified" error
            If barangay.DataSource IsNot Nothing Then
                barangay.DataSource = Nothing
            End If
            barangay.Items.Clear()

            ' Get the actual municipality name from the selected item
            Dim selectedMunicipality As String = ""

            If municipal.SelectedItem IsNot Nothing Then
                ' Check if it's a DataRowView
                If TypeOf municipal.SelectedItem Is DataRowView Then
                    Dim drv As DataRowView = CType(municipal.SelectedItem, DataRowView)
                    ' Get the municipality_name from the DataRowView
                    If drv.Row.Table.Columns.Contains("municipality_name") Then
                        selectedMunicipality = drv.Row("municipality_name").ToString()
                    End If
                ElseIf TypeOf municipal.SelectedItem Is DataRow Then
                    Dim dr As DataRow = CType(municipal.SelectedItem, DataRow)
                    If dr.Table.Columns.Contains("municipality_name") Then
                        selectedMunicipality = dr("municipality_name").ToString()
                    End If
                Else
                    ' It's a simple string
                    selectedMunicipality = municipal.SelectedItem.ToString()
                End If
            ElseIf municipal.SelectedValue IsNot Nothing Then
                ' Fallback to SelectedValue
                selectedMunicipality = municipal.SelectedValue.ToString()
            End If

            If String.IsNullOrEmpty(selectedMunicipality) Then Return

            Dim barangays As DataTable = modDB.GetBarangays(selectedMunicipality)
            If barangays IsNot Nothing AndAlso barangays.Rows.Count > 0 Then
                barangay.DisplayMember = "barangay_name"
                barangay.ValueMember = "barangay_name"
                barangay.DataSource = barangays
            Else
                barangay.Items.Add("Select Barangay")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadBarangayDropdown Error: " & ex.Message)
            If barangay.DataSource IsNot Nothing Then
                barangay.DataSource = Nothing
            End If
            barangay.Items.Clear()
            barangay.Items.Add("Select Barangay")
        End Try
    End Sub

    Private Sub ResetForm()
        ' userID field removed - no need to clear
        firstName.Clear()
        middleName.Clear()
        lastName.Clear()
        employeeId.Clear()
        contactNumber.Clear()
        email.Clear()
        passwordEncrypted.Clear()
        username.Clear()
        departmentId.SelectedIndex = -1
        If suffix.Items.Count > 0 Then suffix.SelectedIndex = 0 ' Reset to "None"
        position.SelectedIndex = -1
        role.SelectedIndex = -1
        province.SelectedIndex = -1
        If municipal.DataSource IsNot Nothing Then
            municipal.DataSource = Nothing
        End If
        municipal.Items.Clear()
        If barangay.DataSource IsNot Nothing Then barangay.DataSource = Nothing Else barangay.Items.Clear()
        province.SelectedIndex = -1
    End Sub

    ' Save button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles um_edituser_save.Click
        Dim validationMessage As String = ValidateFields()
        If Not String.IsNullOrEmpty(validationMessage) Then
            MessageBox.Show(validationMessage, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim employeeCode As String = employeeId.Text.Trim()
        ' Use the username field value if provided, otherwise generate from name
        Dim usernameValue As String = username.Text.Trim()
        If String.IsNullOrWhiteSpace(usernameValue) Then
            ' Generate username from first.last if username field is empty
            usernameValue = (firstName.Text.Trim() & "." & lastName.Text.Trim()).ToLowerInvariant()
        End If

        Dim roleValue As String = GetComboValue(role, "")
        If String.IsNullOrWhiteSpace(roleValue) Then
            MessageBox.Show("Please select a role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Normalize role value to match database enum
        If roleValue = "SuperAdmin" Then roleValue = "SuperAdmin"
        If roleValue = "Admin" Then roleValue = "Admin"
        If roleValue = "Custodian" Then roleValue = "Custodian"
        If roleValue = "Staff" Then roleValue = "Staff"
        Dim positionValue As String = GetComboValue(position, If(String.IsNullOrWhiteSpace(roleValue), "Administrator", roleValue))

        ' Get department ID from dropdown if selected
        ' Get department ID from dropdown if selected
        Dim selectedDeptID As Integer? = Nothing

        If departmentId.SelectedIndex >= 0 AndAlso departmentId.SelectedItem IsNot Nothing Then
            Dim deptValue As Object = departmentId.SelectedValue

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


        Dim success As Boolean = modDB.AddAdminAccount(
            firstName.Text.Trim(),
            lastName.Text.Trim(),
            email.Text.Trim(),
            usernameValue,
            passwordEncrypted.Text,
            middleName:=middleName.Text.Trim(),
            suffix:=If(GetComboValue(suffix) = "None" OrElse String.IsNullOrWhiteSpace(GetComboValue(suffix)), "", GetComboValue(suffix)),
            position:=positionValue,
            departmentID:=selectedDeptID,
            contactNumber:=contactNumber.Text.Trim(),
            houseNoStreet:="",
            barangay:=GetComboValue(barangay),
            municipality:=GetComboValue(municipal),
            provinceCity:=GetComboValue(province),
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
        ' Check SADashboard first (parent class)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            Dim newUC As New UC_UserManagement()
            saDashboard.LoadUserControl(newUC)
            ' Refresh the table after loading
            newUC.RefreshUserTable()
            System.Diagnostics.Debug.WriteLine("[v0] AddUserManagement - Navigated back to UC_UserManagement (SADashboard)")
            Return
        End If

        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            Dim newUC As New UC_UserManagement()
            superAdminDashboard.LoadUserControl(newUC)
            ' Refresh the table after loading
            newUC.RefreshUserTable()
            System.Diagnostics.Debug.WriteLine("[v0] AddUserManagement - Navigated back to UC_UserManagement (SuperAdminDashboard)")
            Return
        End If

        ' Try to find AdminDashboard
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Dim newUC As New UC_UserManagement()
            parentDashboard.LoadUserControl(newUC)
            ' Refresh the table after loading
            newUC.RefreshUserTable()
            System.Diagnostics.Debug.WriteLine("[v0] AddUserManagement - Navigated back to UC_UserManagement (AdminDashboard)")
        Else
            ' Search up the control hierarchy
            Dim currentParent As Control = Me.Parent
            While currentParent IsNot Nothing
                Dim adminDash = TryCast(currentParent, AdminDashboard)
                If adminDash IsNot Nothing Then
                    Dim newUC As New UC_UserManagement()
                    adminDash.LoadUserControl(newUC)
                    ' Refresh the table after loading
                    newUC.RefreshUserTable()
                    System.Diagnostics.Debug.WriteLine("[v0] AddUserManagement - Found AdminDashboard in hierarchy")
                    Exit While
                End If

                Dim saDash = TryCast(currentParent, SADashboard)
                If saDash IsNot Nothing Then
                    Dim newUC As New UC_UserManagement()
                    saDash.LoadUserControl(newUC)
                    ' Refresh the table after loading
                    newUC.RefreshUserTable()
                    System.Diagnostics.Debug.WriteLine("[v0] AddUserManagement - Found SADashboard in hierarchy")
                    Exit While
                End If

                currentParent = currentParent.Parent
            End While
        End If
    End Sub

    Private Function ValidateFields() As String
        If String.IsNullOrWhiteSpace(firstName.Text) Then Return "First name is required."
        If String.IsNullOrWhiteSpace(lastName.Text) Then Return "Last name is required."
        If String.IsNullOrWhiteSpace(email.Text) Then Return "Email is required."

        Dim roleValue As String = GetComboValue(role, "")
        If String.IsNullOrWhiteSpace(roleValue) Then Return "Please select a user role."
        If String.IsNullOrWhiteSpace(employeeId.Text) Then Return "Employee ID is required."
        If String.IsNullOrWhiteSpace(passwordEncrypted.Text) Then Return "Please provide an initial password."
        Return ""
    End Function



    Private Shared Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        
        If combo.SelectedIndex >= 0 AndAlso combo.SelectedItem IsNot Nothing Then
            ' Handle DataRowView case - extract the actual value
            If TypeOf combo.SelectedItem Is DataRowView Then
                Dim drv As DataRowView = CType(combo.SelectedItem, DataRowView)
                ' Try to get the value using DisplayMember first (for location fields)
                If Not String.IsNullOrEmpty(combo.DisplayMember) AndAlso drv.Row.Table.Columns.Contains(combo.DisplayMember) Then
                    Return drv.Row(combo.DisplayMember).ToString()
                End If
                ' Fallback to ValueMember
                If Not String.IsNullOrEmpty(combo.ValueMember) AndAlso drv.Row.Table.Columns.Contains(combo.ValueMember) Then
                    Return drv.Row(combo.ValueMember).ToString()
                End If
                ' If neither works, get first column value
                If drv.Row.Table.Columns.Count > 0 Then
                    Return drv.Row(0).ToString()
                End If
            End If
            
            ' For non-DataRowView items (strings, etc.)
            Return combo.SelectedItem.ToString()
        End If
        
        ' Try manual text entry
        Dim manualValue As String = combo.Text
        If Not String.IsNullOrWhiteSpace(manualValue) Then
            Return manualValue.Trim()
        End If
        
        Return If(String.IsNullOrWhiteSpace(fallback), "", fallback)
    End Function

End Class