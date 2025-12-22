Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Collections.Generic

Public Class UC_UserManagement
    Inherits UserControl

    Private currentAdminID As Integer?
    Private currentAdminType As String = ""
    Private currentAdminUsername As String = ""
    Private currentRoleFilter As String = ""
    Private currentStatusFilter As String = ""
    Private isInitializingFilters As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf UC_UserManagement_Load
    End Sub

    Private Sub UC_UserManagement_Load(sender As Object, e As EventArgs)
        ConfigureGrid()
        ConfigureFilterControls()
        LoadAdminContext()

        RefreshUserTable()

        ' Wire up search textbox if present
        Dim searchNames As String() = {"pm_search", "usermanagementsearchbar", "txtSearch", "txtbox_search", "admin_txtbox_search", "searchBox"}
        For Each nm As String In searchNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                Dim tb As TextBox = CType(found(0), TextBox)
                RemoveHandler tb.TextChanged, AddressOf UserSearch_TextChanged
                AddHandler tb.TextChanged, AddressOf UserSearch_TextChanged
                Exit For
            End If
        Next
    End Sub



    Private Sub ConfigureGrid()
        pm_table.AutoGenerateColumns = False
        pm_table.AllowUserToAddRows = False
        pm_table.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        pm_table.MultiSelect = False
        pm_table.Rows.Clear()
        pm_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        For Each column As DataGridViewColumn In pm_table.Columns
            column.SortMode = DataGridViewColumnSortMode.Automatic
        Next
        
        ' Hide columns that should not be displayed
        ' Show only: userId, username, fullName, contactNumber, email, fullAddress, role
        If pm_table.Columns.Contains("createdAt") Then pm_table.Columns("createdAt").Visible = False
        If pm_table.Columns.Contains("updatedAt") Then pm_table.Columns("updatedAt").Visible = False
        If pm_table.Columns.Contains("firstName") Then pm_table.Columns("firstName").Visible = False
        If pm_table.Columns.Contains("middleName") Then pm_table.Columns("middleName").Visible = False
        If pm_table.Columns.Contains("lastName") Then pm_table.Columns("lastName").Visible = False
        If pm_table.Columns.Contains("departmentId") Then pm_table.Columns("departmentId").Visible = False
        If pm_table.Columns.Contains("employeeId") Then pm_table.Columns("employeeId").Visible = False
        If pm_table.Columns.Contains("passwordEncrypted") Then pm_table.Columns("passwordEncrypted").Visible = False
        If pm_table.Columns.Contains("lastLogin") Then pm_table.Columns("lastLogin").Visible = False
    End Sub

    Private Sub ConfigureFilterControls()
        If cboRoleFilter Is Nothing OrElse cboStatusFilter Is Nothing Then Return
        isInitializingFilters = True
        Try
            cboRoleFilter.Items.Clear()
            cboRoleFilter.Items.Add("All Roles")
            cboRoleFilter.Items.Add("Admin")
            cboRoleFilter.Items.Add("SuperAdmin")
            cboRoleFilter.Items.Add("Custodian")
            cboRoleFilter.Items.Add("Staff")
            cboRoleFilter.SelectedIndex = 0

            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.Add("All Status")
            cboStatusFilter.Items.Add("Active")
            cboStatusFilter.Items.Add("Inactive")
            cboStatusFilter.SelectedIndex = 0
        Finally
            isInitializingFilters = False
        End Try
    End Sub

    Private Sub LoadAdminContext()
        Dim savedUsername As String = My.Settings.LoggedInuser
        If String.IsNullOrWhiteSpace(savedUsername) Then Return

        Dim context = DatabaseConnection.GetAdminContextByUsername(savedUsername)
        If context Is Nothing OrElse context.Count = 0 Then Return

        If context.ContainsKey("user_id") Then
            Dim parsed As Integer
            If Integer.TryParse(context("user_id"), parsed) Then
                currentAdminID = parsed
            End If
        End If

        If context.ContainsKey("user_type") Then
            currentAdminType = context("user_type")
        End If

        If context.ContainsKey("username") Then
            currentAdminUsername = context("username")
        Else
            currentAdminUsername = savedUsername
        End If
    End Sub

    Private Sub RefreshUserTable()
        Try
            pm_table.Rows.Clear()

            ' Use GetAllUsers to get both Admin/SuperAdmin (from users table) and Staff (from staff_accounts table)
            Dim records As DataTable = DatabaseConnection.GetAllUsers(currentStatusFilter, currentRoleFilter, "")

            ' Store original data for search
            If records IsNot Nothing AndAlso records.Rows.Count > 0 Then
                originalUserData = records.Copy()
            Else
                originalUserData = Nothing
                ' Show message only if filters are active (not on initial load)
                If Not String.IsNullOrEmpty(currentStatusFilter) OrElse Not String.IsNullOrEmpty(currentRoleFilter) Then
                    ' Filters are active but no results - this is expected
                End If
            End If

            For Each record As DataRow In records.Rows
                ' ===== BUILD FULL NAME FROM 4 COLUMNS =====
                Dim firstName As String = SafeValue(record, "firstName")
                Dim middleName As String = SafeValue(record, "middleName")
                Dim lastName As String = SafeValue(record, "lastName")
                Dim suffix As String = SafeValue(record, "suffix")
                Dim fullName As String = $"{firstName} {If(String.IsNullOrWhiteSpace(middleName), "", middleName & " ")}{lastName}{If(String.IsNullOrWhiteSpace(suffix), "", " " & suffix)}".Trim()

                ' Format dates
                Dim createdAtValue As String = ""
                If record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt") Then
                    createdAtValue = FormatDateValue(record("createdAt"))
                End If

                Dim updatedAtValue As String = ""
                If record.Table.Columns.Contains("updatedAt") AndAlso Not record.IsNull("updatedAt") Then
                    updatedAtValue = FormatDateValue(record("updatedAt"))
                ElseIf record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt") Then
                    updatedAtValue = FormatDateValue(record("createdAt"))
                End If

                Dim lastLoginValue As String = ""
                If record.Table.Columns.Contains("lastLogin") AndAlso Not record.IsNull("lastLogin") Then
                    lastLoginValue = FormatDateValue(record("lastLogin"))
                End If

                ' ===== BUILD FULL ADDRESS FROM PROVINCE, MUNICIPALITY, BARANGAY =====
                Dim province As String = SafeValue(record, "province_city")
                Dim municipality As String = SafeValue(record, "municipality")
                Dim barangay As String = SafeValue(record, "barangay")
                
                Dim addressParts As New List(Of String)
                If Not String.IsNullOrWhiteSpace(barangay) Then addressParts.Add(barangay)
                If Not String.IsNullOrWhiteSpace(municipality) Then addressParts.Add(municipality)
                If Not String.IsNullOrWhiteSpace(province) Then addressParts.Add(province)
                
                Dim fullAddress As String = String.Join(", ", addressParts)
                If String.IsNullOrWhiteSpace(fullAddress) Then fullAddress = "N/A"
                
                ' Get role from user_type field
                Dim userRole As String = SafeValue(record, "user_type")
                If String.IsNullOrWhiteSpace(userRole) Then userRole = "N/A"

                ' ===== ADD ROW TO DATAGRIDVIEW IN CORRECT COLUMN ORDER =====
                ' Column order from Designer: userId, createdAt, updatedAt, username, firstName, middleName, lastName, 
                '                            fullName, departmentId, employeeId, contactNumber, email, fullAddress, role, passwordEncrypted, lastLogin
                Dim rowIndex As Integer = pm_table.Rows.Add(
                    SafeValue(record, "userId"),                    ' userId
                    createdAtValue,                                  ' createdAt
                    updatedAtValue,                                  ' updatedAt
                    SafeValue(record, "username"),                  ' username
                    firstName,                                       ' firstName
                    middleName,                                      ' middleName
                    lastName,                                        ' lastName
                    fullName,                                        ' fullName
                    SafeValue(record, "departmentId"),              ' departmentId
                    SafeValue(record, "employeeId"),                ' employeeId
                    SafeValue(record, "contactNumber"),            ' contactNumber
                    SafeValue(record, "email"),                     ' email
                    fullAddress,                                     ' fullAddress
                    userRole,                                        ' role
                    "******",                                        ' passwordEncrypted (hidden)
                    lastLoginValue                                   ' lastLogin
                )

                Dim dateAssignedValue As Object = DBNull.Value
                If record.Table.Columns.Contains("dateAssigned") AndAlso Not record.IsNull("dateAssigned") Then
                    dateAssignedValue = record("dateAssigned")
                ElseIf record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt") Then
                    dateAssignedValue = record("createdAt")
                End If

                pm_table.Rows(rowIndex).Tag = New UserRowMetadata With {
                    .Username = SafeValue(record, "username"),
                    .EmployeeID = SafeValue(record, "employeeId"),
                    .DateAssigned = dateAssignedValue,
                    .CreatedAt = If(
                        record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt"),
                        record("createdAt"),
                        DBNull.Value
                    )
                }
            Next


            ' Update total count
            Dim totalLabel As Label = Nothing
            Dim foundControls() As Control = Me.Controls.Find("ttlusermanagement", True)
            If foundControls.Length > 0 Then
                totalLabel = TryCast(foundControls(0), Label)
            End If
            If totalLabel IsNot Nothing Then
                totalLabel.Text = If(records IsNot Nothing, records.Rows.Count.ToString(), "0")
            End If

            ' Debug output
            System.Diagnostics.Debug.WriteLine("[v0] User Management - Loaded " & If(records IsNot Nothing, records.Rows.Count, 0) & " users")

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] RefreshUserTable Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Unable to load user accounts: " & ex.Message,
                        "User Management", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Shared Function SafeValue(record As DataRow, columnName As String) As String
        If Not record.Table.Columns.Contains(columnName) Then Return ""
        Dim value = record(columnName)
        Return If(value Is DBNull.Value OrElse value Is Nothing, "", value.ToString())
    End Function

    Private Shared Function FormatDateValue(value As Object) As String
        If value Is Nothing OrElse value Is DBNull.Value Then Return ""
        Dim parsed As Date
        If Date.TryParse(value.ToString(), parsed) Then
            Return parsed.ToString("yyyy-MM-dd")
        End If
        Return value.ToString()
    End Function

    Private Function GetSelectedRow() As DataGridViewRow
        If pm_table.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user record first.",
                            "User Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End If
        Return pm_table.SelectedRows(0)
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - btnAdd_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - IsSuperAdmin: " & SessionContext.IsSuperAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - IsAdmin: " & SessionContext.IsAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - ParentForm Type: " & If(Me.ParentForm IsNot Nothing, Me.ParentForm.GetType().Name, "NULL"))
        
        ' Use AddUserManagement instead of StaffRegister for Admin/SuperAdmin
        ' Check SADashboard first (parent class of SuperAdminDashboard)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            Try
                saDashboard.LoadUserControl(New AddUserManagement())
                System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - AddUserManagement loaded into SADashboard")
                Return
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] SADashboard LoadUserControl Error: " & ex.Message)
            End Try
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            Try
                superAdminDashboard.LoadUserControl(New AddUserManagement())
                Return
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] SuperAdmin LoadUserControl Error: " & ex.Message)
            End Try
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Try
                parentDashboard.LoadUserControl(New AddUserManagement())
                Return
            Catch
                ' Fallback: show as dialog
                Dim frm As New AddUserManagement()
                frm.Show()
                Return
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - btnEdit_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - Selected Rows: " & pm_table.SelectedRows.Count)
        
        Dim selectedRow = GetSelectedRow()
        If selectedRow Is Nothing Then Return

        Dim metadata As UserRowMetadata = TryCast(selectedRow.Tag, UserRowMetadata)
        If metadata Is Nothing Then metadata = New UserRowMetadata()

        ' Get user data from database using userId
        Dim userIdStr As String = If(selectedRow.Cells("userId").Value IsNot Nothing, selectedRow.Cells("userId").Value.ToString(), "")
        Dim userId As Integer
        If Not Integer.TryParse(userIdStr, userId) Then
            MessageBox.Show("Invalid user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open EditProfile as a dialog form (user requested EditProfile)
        ' Note: EditProfile currently loads the current user's profile
        ' For editing other users, we'll use EditUser UserControl instead
        Dim editForm As New EditUser()
        editForm.SetAuditContext(currentAdminID, currentAdminType, currentAdminUsername)

        Dim dateAssignedValue As Date = Date.Today
        If metadata.DateAssigned IsNot Nothing AndAlso metadata.DateAssigned IsNot DBNull.Value Then
            Date.TryParse(metadata.DateAssigned.ToString(), dateAssignedValue)
        End If

        ' Get full user data from database
        Dim userData As DataRow = DatabaseConnection.GetUserById(userId)
        If userData Is Nothing Then
            MessageBox.Show("User data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Load user data into edit form
        ' LoadUserData signature: userID, firstName, middleName, lastName, suffixValue, position, 
        '                        departmentID, employeeID, contactNumber, email, userRole, 
        '                        provinceValue, municipalityValue, barangayValue, password, dateRegistered, username
        editForm.LoadUserData(
            userIdStr,                                      ' userID
            SafeValue(userData, "firstName"),              ' firstName
            SafeValue(userData, "middleName"),             ' middleName
            SafeValue(userData, "lastName"),               ' lastName
            SafeValue(userData, "suffix"),                 ' suffixValue
            SafeValue(userData, "position"),               ' position
            SafeValue(userData, "departmentId"),           ' departmentID
            SafeValue(userData, "employeeId"),             ' employeeID
            SafeValue(userData, "contactNumber"),          ' contactNumber
            SafeValue(userData, "email"),                  ' email
            SafeValue(userData, "role"),                   ' userRole (FIXED: was "username")
            SafeValue(userData, "province"),               ' provinceValue
            SafeValue(userData, "municipal"),              ' municipalityValue
            SafeValue(userData, "barangay"),               ' barangayValue
            "",                                            ' password (empty - not loading)
            dateAssignedValue,                             ' dateRegistered
            SafeValue(userData, "username")                ' username
        )

        ' Check SADashboard first (parent class), then SuperAdminDashboard, then AdminDashboard
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(editForm)
            System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - EditUser loaded into SADashboard")
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            superAdminDashboard.LoadUserControl(editForm)
            Return
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - btnDelete_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_UserManagement - Selected Rows: " & pm_table.SelectedRows.Count)
        
        Dim selectedRow = GetSelectedRow()
        If selectedRow Is Nothing Then Return

        Dim userIDValue As Integer
        If Not Integer.TryParse(selectedRow.Cells("userID").Value.ToString(), userIDValue) Then
            MessageBox.Show("Invalid user selected.", "User Management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fullName As String = $"{selectedRow.Cells("firstName").Value} {selectedRow.Cells("lastName").Value}".Trim()
        Dim confirmation = MessageBox.Show($"Delete the account for {fullName}? This action cannot be undone.",
                                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmation <> DialogResult.Yes Then Return

        Dim success = DatabaseConnection.DeleteAdminAccount(userIDValue,
                                                            currentAdminID,
                                                            currentAdminType,
                                                            currentAdminUsername,
                                                            "",
                                                            "User Management",
                                                            "User Account")
        If success Then
            MessageBox.Show("User account deleted.", "User Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshUserTable()
        End If
    End Sub

    Private Sub ResetFilters()
        currentRoleFilter = ""
        currentStatusFilter = ""

        If TypeOf cboRoleFilter Is ComboBox Then
            If cboRoleFilter.Items.Count > 0 Then
                cboRoleFilter.SelectedIndex = 0
            End If
        End If

        If TypeOf cboStatusFilter Is ComboBox Then
            If cboStatusFilter.Items.Count > 0 Then
                cboStatusFilter.SelectedIndex = 0
            End If
        End If

        RefreshUserTable()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        ResetFilters()
    End Sub

    Private Sub cboRoleFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRoleFilter.SelectedIndexChanged
        If isInitializingFilters Then Return
        currentRoleFilter = If(cboRoleFilter.SelectedIndex <= 0, "", cboRoleFilter.SelectedItem.ToString())
        RefreshUserTable()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        If isInitializingFilters Then Return
        currentStatusFilter = If(cboStatusFilter.SelectedIndex <= 0, "", cboStatusFilter.SelectedItem.ToString())
        RefreshUserTable()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshUserTable()
    End Sub

    Private Sub pm_table_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles pm_table.CellDoubleClick
        If e.RowIndex >= 0 Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Class UserRowMetadata
        Public Property Username As String = ""
        Public Property EmployeeID As String = ""
        Public Property DateAssigned As Object = Nothing
        Public Property CreatedAt As Object = Nothing
    End Class

    Private Sub pm_table_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pm_table.CellContentClick

    End Sub

    Private Sub UC_UserManagement_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private originalUserData As DataTable = Nothing
    Private isSearchingUsers As Boolean = False

    Private Sub UserSearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        ApplyUserSearch(tb.Text)
    End Sub

    Private Sub ApplyUserSearch(searchText As String)
        If originalUserData Is Nothing Then
            ' Store original data on first search
            Try
                Dim dt As DataTable = DatabaseConnection.GetAllUsers(currentStatusFilter, currentRoleFilter, "")
                If dt IsNot Nothing Then
                    originalUserData = dt.Copy()
                End If
            Catch
                Return
            End Try
        End If

        If originalUserData Is Nothing Then Return
        If isSearchingUsers Then Return
        isSearchingUsers = True

        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())

            If String.IsNullOrEmpty(searchLower) Then
                RefreshUserTable()
                isSearchingUsers = False
                Return
            End If

            ' Filter original data
            Dim filtered = originalUserData.AsEnumerable().Where(Function(row)
                                                                     Dim firstName As String = If(row.Table.Columns.Contains("firstName") AndAlso Not IsDBNull(row("firstName")), row("firstName").ToString().ToLower(), String.Empty)
                                                                     Dim middleName As String = If(row.Table.Columns.Contains("middleName") AndAlso Not IsDBNull(row("middleName")), row("middleName").ToString().ToLower(), String.Empty)
                                                                     Dim lastName As String = If(row.Table.Columns.Contains("lastName") AndAlso Not IsDBNull(row("lastName")), row("lastName").ToString().ToLower(), String.Empty)
                                                                     Dim username As String = If(row.Table.Columns.Contains("username") AndAlso Not IsDBNull(row("username")), row("username").ToString().ToLower(), String.Empty)
                                                                     Dim email As String = If(row.Table.Columns.Contains("email") AndAlso Not IsDBNull(row("email")), row("email").ToString().ToLower(), String.Empty)
                                                                     Dim employeeId As String = If(row.Table.Columns.Contains("employeeId") AndAlso Not IsDBNull(row("employeeId")), row("employeeId").ToString().ToLower(), String.Empty)
                                                                     Dim position As String = If(row.Table.Columns.Contains("position") AndAlso Not IsDBNull(row("position")), row("position").ToString().ToLower(), String.Empty)

                                                                     Return firstName.Contains(searchLower) OrElse middleName.Contains(searchLower) OrElse lastName.Contains(searchLower) OrElse username.Contains(searchLower) OrElse email.Contains(searchLower) OrElse employeeId.Contains(searchLower) OrElse position.Contains(searchLower)
                                                                 End Function)

            ' Clear and repopulate grid
            pm_table.Rows.Clear()
            For Each record As DataRow In filtered
                Dim firstName As String = SafeValue(record, "firstName")
                Dim middleName As String = SafeValue(record, "middleName")
                Dim lastName As String = SafeValue(record, "lastName")
                Dim suffix As String = SafeValue(record, "suffix")
                Dim fullName As String = $"{firstName} {If(String.IsNullOrWhiteSpace(middleName), "", middleName & " ")}{lastName}{If(String.IsNullOrWhiteSpace(suffix), "", " " & suffix)}".Trim()

                Dim createdAtValue As String = ""
                If record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt") Then
                    createdAtValue = FormatDateValue(record("createdAt"))
                End If

                Dim updatedAtValue As String = ""
                If record.Table.Columns.Contains("updatedAt") AndAlso Not record.IsNull("updatedAt") Then
                    updatedAtValue = FormatDateValue(record("updatedAt"))
                ElseIf record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt") Then
                    updatedAtValue = FormatDateValue(record("createdAt"))
                End If

                Dim lastLoginValue As String = ""
                If record.Table.Columns.Contains("lastLogin") AndAlso Not record.IsNull("lastLogin") Then
                    lastLoginValue = FormatDateValue(record("lastLogin"))
                End If

                ' Build full address for search results
                Dim province As String = SafeValue(record, "province_city")
                Dim municipality As String = SafeValue(record, "municipality")
                Dim barangay As String = SafeValue(record, "barangay")
                
                Dim addressParts As New List(Of String)
                If Not String.IsNullOrWhiteSpace(barangay) Then addressParts.Add(barangay)
                If Not String.IsNullOrWhiteSpace(municipality) Then addressParts.Add(municipality)
                If Not String.IsNullOrWhiteSpace(province) Then addressParts.Add(province)
                
                Dim fullAddress As String = String.Join(", ", addressParts)
                If String.IsNullOrWhiteSpace(fullAddress) Then fullAddress = "N/A"
                
                Dim userRole As String = SafeValue(record, "user_type")
                If String.IsNullOrWhiteSpace(userRole) Then userRole = "N/A"

                Dim rowIndex As Integer = pm_table.Rows.Add(
                    SafeValue(record, "userId"),
                    createdAtValue,
                    updatedAtValue,
                    SafeValue(record, "username"),
                    firstName,
                    middleName,
                    lastName,
                    fullName,
                    SafeValue(record, "departmentId"),
                    SafeValue(record, "employeeId"),
                    SafeValue(record, "contactNumber"),
                    SafeValue(record, "email"),
                    fullAddress,
                    userRole,
                    "******",
                    lastLoginValue
                )

                Dim dateAssignedValue As Object = DBNull.Value
                If record.Table.Columns.Contains("dateAssigned") AndAlso Not record.IsNull("dateAssigned") Then
                    dateAssignedValue = record("dateAssigned")
                ElseIf record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt") Then
                    dateAssignedValue = record("createdAt")
                End If

                pm_table.Rows(rowIndex).Tag = New UserRowMetadata With {
                    .Username = SafeValue(record, "username"),
                    .EmployeeID = SafeValue(record, "employeeId"),
                    .DateAssigned = dateAssignedValue,
                    .CreatedAt = If(record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt"), record("createdAt"), DBNull.Value)
                }
            Next

            ' Update total count
            Dim totalLabel As Label = Nothing
            Dim foundControls() As Control = Me.Controls.Find("ttlusermanagement", True)
            If foundControls.Length > 0 Then
                totalLabel = TryCast(foundControls(0), Label)
            End If
            If totalLabel IsNot Nothing Then
                totalLabel.Text = filtered.Count().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearchingUsers = False
        End Try
    End Sub

    Private Sub maintenancerequestmanagementsearchbar_TextChanged(sender As Object, e As EventArgs) Handles usermanagementsearchbar.TextChanged

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class
