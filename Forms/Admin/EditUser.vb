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
        
        ' Check if department value was stored in Tag and set it now
        If Me.departmentId IsNot Nothing AndAlso Me.departmentId.Tag IsNot Nothing Then
            Dim deptIdValue As String = Me.departmentId.Tag.ToString()
            Me.departmentId.Tag = Nothing
            SetDepartmentValue(deptIdValue)
        End If
        
        ' Load location dropdowns first to ensure they're available
        LoadLocationDropdowns()
        
        ' Check if address values were stored in Tag and need to be set now
        If Me.province.Tag IsNot Nothing Then
            Dim provinceVal As String = Me.province.Tag.ToString()
            Dim municipalVal As String = If(Me.municipal.Tag IsNot Nothing, Me.municipal.Tag.ToString(), "")
            Dim barangayVal As String = If(Me.barangay.Tag IsNot Nothing, Me.barangay.Tag.ToString(), "")
            
            ' Clear tags
            Me.province.Tag = Nothing
            Me.municipal.Tag = Nothing
            Me.barangay.Tag = Nothing
            
            ' Set values now that dropdowns are loaded
            SetLocationValues(provinceVal, municipalVal, barangayVal)
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
        Me.employeeID.Text = employeeID
        Me.contactNumber.Text = contactNumber
        Me.email.Text = email
        Me.passwordEncrypted.Text = password
        Me.username.Text = username

        ' Set suffix - handle empty/null as "None"
        Dim suffixToSet As String = If(String.IsNullOrWhiteSpace(suffixValue), "None", suffixValue)
        SetComboValue(suffixAdmin, suffixToSet)
        
        SetComboValue(positionAdmin, position)
        SetComboValue(role, userRole) ' This sets the role dropdown
        
        ' Set department dropdown properly - ensure it's set AFTER LoadDepartmentOptions
        ' Store the value to set after form is fully loaded
        If departmentDirectory Is Nothing Then
            ' Departments not yet loaded, will be loaded in EditUser_Load
            ' Store value in Tag for later
            If Me.departmentId IsNot Nothing Then
                Me.departmentId.Tag = departmentID
            End If
        Else
            ' Already loaded, set now
            SetDepartmentValue(departmentID)
        End If
        
        ' Store address values to set after dropdowns are loaded
        ' Set location dropdowns after ensuring they're populated
        ' The Load event will populate dropdowns, then we set the values
        If Me.province.DataSource Is Nothing Then
            ' Dropdowns not yet loaded, store values for later
            Me.province.Tag = provinceValue
            Me.municipal.Tag = municipalityValue
            Me.barangay.Tag = barangayValue
        Else
            ' Dropdowns already loaded, set values now
            SetLocationValues(provinceValue, municipalityValue, barangayValue)
        End If

        editingUsername = username
        currentUserType = userRole ' Store the current user type
    End Sub
    
    Private Sub SetLocationValues(provinceValue As String, municipalityValue As String, barangayValue As String)
        ' Remove event handlers temporarily to prevent cascading updates
        RemoveHandler province.SelectedIndexChanged, AddressOf Province_SelectedIndexChanged
        RemoveHandler municipal.SelectedIndexChanged, AddressOf Municipality_SelectedIndexChanged
        
        Try
            ' Ensure province dropdown is loaded first
            If Me.province.DataSource Is Nothing Then
                LoadLocationDropdowns()
            End If
            
            ' Set province first
            If Not String.IsNullOrEmpty(provinceValue) Then
                SetComboValueWithDataRow(Me.province, provinceValue)
                
                ' Wait a moment for the selection to register, then load municipalities
                System.Threading.Thread.Sleep(100)
                Application.DoEvents()
                
                ' Load municipalities for selected province
                Dim municipalitiesTable As DataTable = modDB.GetMunicipalities(provinceValue)
                If municipalitiesTable IsNot Nothing AndAlso municipalitiesTable.Rows.Count > 0 Then
                    municipal.DataSource = Nothing
                    municipal.Items.Clear()
                    municipal.DataSource = municipalitiesTable
                    municipal.DisplayMember = "municipality_name"
                    municipal.ValueMember = "municipality_name"
                    
                    ' Wait a moment for the DataSource to be set
                    System.Threading.Thread.Sleep(100)
                    Application.DoEvents()
                    
                    ' Set municipality value
                    If Not String.IsNullOrEmpty(municipalityValue) Then
                        SetComboValueWithDataRow(Me.municipal, municipalityValue)
                        
                        ' Wait a moment for the selection to register, then load barangays
                        System.Threading.Thread.Sleep(100)
                        Application.DoEvents()
                        
                        ' Load barangays for selected municipality
                        Dim barangaysTable As DataTable = modDB.GetBarangays(municipalityValue)
                        If barangaysTable IsNot Nothing AndAlso barangaysTable.Rows.Count > 0 Then
                            barangay.DataSource = Nothing
                            barangay.Items.Clear()
                            barangay.DataSource = barangaysTable
                            barangay.DisplayMember = "barangay_name"
                            barangay.ValueMember = "barangay_name"
                            
                            ' Wait a moment for the DataSource to be set
                            System.Threading.Thread.Sleep(100)
                            Application.DoEvents()
                            
                            ' Set barangay value
                            If Not String.IsNullOrEmpty(barangayValue) Then
                                SetComboValueWithDataRow(Me.barangay, barangayValue)
                            End If
                        End If
                    End If
                End If
            End If
        Finally
            ' Re-add event handlers
            AddHandler province.SelectedIndexChanged, AddressOf Province_SelectedIndexChanged
            AddHandler municipal.SelectedIndexChanged, AddressOf Municipality_SelectedIndexChanged
        End Try
    End Sub
    
    Private Sub SetDepartmentValue(deptID As String)
        If Me.departmentId Is Nothing Then Return
        If String.IsNullOrWhiteSpace(deptID) Then
            Me.departmentId.SelectedIndex = -1
            Return
        End If
        
        Dim deptIdInt As Integer
        If Integer.TryParse(deptID, deptIdInt) Then
            ' Try to find the department by ID in the ComboBox
            If TypeOf Me.departmentId Is ComboBox Then
                Dim combo As ComboBox = CType(Me.departmentId, ComboBox)
                If combo.DataSource IsNot Nothing AndAlso TypeOf combo.DataSource Is DataTable Then
                    Dim dt As DataTable = CType(combo.DataSource, DataTable)
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(i)("department_id").ToString() = deptID Then
                            combo.SelectedIndex = i
                            Return
                        End If
                    Next
                End If
                ' Try using SelectedValue
                combo.SelectedValue = deptIdInt
            End If
        End If
    End Sub

    Private Sub LoadDepartmentOptions()
        Try
            departmentDirectory = modDB.GetDepartmentLookup(True)
            If departmentDirectory Is Nothing Then Return

            ' Convert departmentID TextBox to ComboBox if it isn't already
            If TypeOf departmentID Is ComboBox Then
                Dim deptCombo As ComboBox = CType(departmentID, ComboBox)
                deptCombo.DataSource = departmentDirectory
                deptCombo.DisplayMember = "department_name"
                deptCombo.ValueMember = "department_id"
                deptCombo.SelectedIndex = -1
            Else
                ' Fallback for TextBox with autocomplete
                Dim suggestions As New AutoCompleteStringCollection()
                For Each row As DataRow In departmentDirectory.Rows
                    suggestions.Add($"{row("department_id")} - {row("department_name")}")
                Next

                departmentID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                departmentID.AutoCompleteSource = AutoCompleteSource.CustomSource
                departmentID.AutoCompleteCustomSource = suggestions
            End If
            
            ' Load location dropdowns (Province, Municipality, Barangay)
            LoadLocationDropdowns()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditUser.LoadDepartmentOptions Exception: " & ex.Message)
        End Try
    End Sub
    
    Private Sub LoadLocationDropdowns()
        Try
            ' Load Province dropdown with proper DisplayMember/ValueMember
            Dim provincesTable As DataTable = modDB.GetProvinces()
            If provincesTable IsNot Nothing AndAlso provincesTable.Rows.Count > 0 Then
                province.DataSource = provincesTable
                province.DisplayMember = "province_name"
                province.ValueMember = "province_name"
                province.SelectedIndex = -1
            End If
            
            ' Add event handlers for cascading dropdowns
            AddHandler province.SelectedIndexChanged, AddressOf Province_SelectedIndexChanged
            AddHandler municipal.SelectedIndexChanged, AddressOf Municipality_SelectedIndexChanged
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditUser.LoadLocationDropdowns Exception: " & ex.Message)
        End Try
    End Sub
    
    Private Sub Province_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ' Clear municipality and barangay first
            municipal.DataSource = Nothing
            municipal.Items.Clear()
            barangay.DataSource = Nothing
            barangay.Items.Clear()
            
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
            
            If Not String.IsNullOrEmpty(selectedProvince) Then
                System.Diagnostics.Debug.WriteLine("[v0] Province selected: " & selectedProvince)
                
                Dim municipalitiesTable As DataTable = modDB.GetMunicipalities(selectedProvince)
                
                If municipalitiesTable IsNot Nothing AndAlso municipalitiesTable.Rows.Count > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Loaded " & municipalitiesTable.Rows.Count & " municipalities")
                    municipal.DataSource = municipalitiesTable
                    municipal.DisplayMember = "municipality_name"
                    municipal.ValueMember = "municipality_name"
                    municipal.SelectedIndex = -1
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] No municipalities loaded")
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditUser.Province_SelectedIndexChanged Exception: " & ex.Message)
            MessageBox.Show("Error loading municipalities: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    
    Private Sub Municipality_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ' Clear barangay first
            barangay.DataSource = Nothing
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
            
            If Not String.IsNullOrEmpty(selectedMunicipality) Then
                System.Diagnostics.Debug.WriteLine("[v0] Municipality selected: " & selectedMunicipality)
                
                Dim barangaysTable As DataTable = modDB.GetBarangays(selectedMunicipality)
                
                If barangaysTable IsNot Nothing AndAlso barangaysTable.Rows.Count > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Loaded " & barangaysTable.Rows.Count & " barangays")
                    barangay.DataSource = barangaysTable
                    barangay.DisplayMember = "barangay_name"
                    barangay.ValueMember = "barangay_name"
                    barangay.SelectedIndex = -1
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] No barangays loaded")
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EditUser.Municipality_SelectedIndexChanged Exception: " & ex.Message)
            MessageBox.Show("Error loading barangays: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        Dim roleValue As String = GetComboValue(role, currentUserType)
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

        ' Username validation is handled by the UpdateUserAccount function internally
        ' No need for separate uniqueness check here as the function will validate
        
        ' Get the updated username from the form (not the original)
        Dim updatedUsername As String = username.Text.Trim()
        If String.IsNullOrWhiteSpace(updatedUsername) Then
            MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            username.Focus()
            Return
        End If
        
        ' Use unified UpdateUserAccount function that handles both Admin/SuperAdmin and Staff
        Dim updateSuccess As Boolean = modDB.UpdateUserAccount(
            adminIDValue,
            tableUserType, ' Use current user type to determine which table to update
            firstName.Text.Trim(),
            lastName.Text.Trim(),
            email.Text.Trim(),
            updatedUsername, ' Use the updated username from the form
            middleName:=middleName.Text.Trim(),
            suffix:=GetComboValue(suffixAdmin),
            position:=positionValue,
            departmentID:=deptID,
            contactNumber:=contactNumber.Text.Trim(),
            barangay:=GetComboValue(barangay),
            municipality:=GetComboValue(municipal),
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
            If Not String.IsNullOrWhiteSpace(passwordEncrypted.Text) Then
                ' Use unified ResetUserPassword function that handles both Admin/SuperAdmin and Staff
                modDB.ResetUserPassword(adminIDValue,
                                                     tableUserType, ' Use current user type to determine which table to update
                                                     passwordEncrypted.Text,
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
        ' Check SADashboard first
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            Dim newUC As New UC_UserManagement()
            saDashboard.LoadUserControl(newUC)
            ' Refresh the table after loading
            newUC.RefreshUserTable()
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            Dim newUC As New UC_UserManagement()
            superAdminDashboard.LoadUserControl(newUC)
            ' Refresh the table after loading
            newUC.RefreshUserTable()
            Return
        End If
        
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Dim newUC As New UC_UserManagement()
            parentDashboard.LoadUserControl(newUC)
            ' Refresh the table after loading
            newUC.RefreshUserTable()
        End If
    End Sub

    Private Function ValidateFields() As String
        If String.IsNullOrWhiteSpace(firstName.Text) Then Return "First name is required."
        If String.IsNullOrWhiteSpace(lastName.Text) Then Return "Last name is required."
        If String.IsNullOrWhiteSpace(email.Text) Then Return "Email is required."
        ' Role validation - if role has no selection, use currentUserType
        If role.SelectedIndex = -1 AndAlso String.IsNullOrWhiteSpace(currentUserType) Then 
            Return "Please select a user role."
        End If
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
            ' If neither works, get first column value
            If drv.Row.Table.Columns.Count > 0 Then
                Return drv.Row(0).ToString()
            End If
        End If
        
        ' Try SelectedValue as fallback
        If combo.SelectedValue IsNot Nothing Then
            Return combo.SelectedValue.ToString()
        End If
        
        Return combo.SelectedItem.ToString()
    End Function

    Private Function ResolveDepartmentId() As Integer?
        If TypeOf departmentID Is ComboBox Then
            Dim combo As ComboBox = CType(departmentID, ComboBox)
            If combo.SelectedValue IsNot Nothing Then
                Dim parsedValue As Integer
                If Integer.TryParse(combo.SelectedValue.ToString(), parsedValue) Then
                    Return parsedValue
                End If
            End If
        End If
        
        ' Fallback for TextBox
        Dim rawValue As String = departmentID.Text.Trim()
        If String.IsNullOrWhiteSpace(rawValue) Then Return Nothing
        Dim candidate As String = rawValue
        If rawValue.Contains("-") Then
            candidate = rawValue.Split("-"c)(0).Trim()
        End If
        Dim parsedInt As Integer
        If Integer.TryParse(candidate, parsedInt) Then
            Return parsedInt
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
    
    Private Sub SetComboValueWithDataRow(combo As ComboBox, value As String)
        If combo Is Nothing Then Return
        If String.IsNullOrWhiteSpace(value) Then
            combo.SelectedIndex = -1
            Return
        End If

        ' If combo has a DataSource with DataTable, search through the DataSource
        If combo.DataSource IsNot Nothing AndAlso TypeOf combo.DataSource Is DataTable Then
            Dim dt As DataTable = CType(combo.DataSource, DataTable)
            Dim displayMember As String = If(String.IsNullOrEmpty(combo.DisplayMember), "", combo.DisplayMember)
            Dim valueMember As String = If(String.IsNullOrEmpty(combo.ValueMember), "", combo.ValueMember)
            
            ' Search for matching value in the DataTable
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim row As DataRow = dt.Rows(i)
                ' Try to match against ValueMember or DisplayMember
                If Not String.IsNullOrEmpty(valueMember) AndAlso dt.Columns.Contains(valueMember) Then
                    If row(valueMember).ToString().Equals(value, StringComparison.OrdinalIgnoreCase) Then
                        combo.SelectedIndex = i
                        Return
                    End If
                End If
                If Not String.IsNullOrEmpty(displayMember) AndAlso dt.Columns.Contains(displayMember) Then
                    If row(displayMember).ToString().Equals(value, StringComparison.OrdinalIgnoreCase) Then
                        combo.SelectedIndex = i
                        Return
                    End If
                End If
            Next
            ' If not found, set to -1
            combo.SelectedIndex = -1
        ElseIf combo.Items.Count > 0 Then
            ' Try regular string matching
            For i As Integer = 0 To combo.Items.Count - 1
                If combo.Items(i).ToString().Equals(value, StringComparison.OrdinalIgnoreCase) Then
                    combo.SelectedIndex = i
                    Return
                End If
            Next
            combo.SelectedIndex = -1
        Else
            ' Use regular SetComboValue for string items
            SetComboValue(combo, value)
        End If
    End Sub

    Private Sub uc_um_edituser_Paint(sender As Object, e As PaintEventArgs) Handles uc_um_edituser.Paint

    End Sub
End Class
