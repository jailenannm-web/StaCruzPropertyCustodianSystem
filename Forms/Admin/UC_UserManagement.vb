Imports System
Imports System.Data
Imports System.Windows.Forms

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

        RefreshUserTable()

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

            For Each record As DataRow In records.Rows

                ' ===== BUILD FULL NAME FROM 4 COLUMNS =====
                Dim firstName As String = SafeValue(record, "firstName")
                Dim middleName As String = SafeValue(record, "middleName")
                Dim lastName As String = SafeValue(record, "lastName")
                Dim suffix As String = SafeValue(record, "suffix")

                ' ===== ADD ROW TO DATAGRIDVIEW IN CORRECT COLUMN ORDER =====
                ' Column order: UserID, date_assigned, firstName, middleName, lastName, suffixAdmin, positionAdmin, 
                '                DepartmentID, EmployeeID, contactNumber, email, usernameAdmin, passwordAdmin, 
                '                provinceAdmin, municipality, barangay, Role, Status
                Dim rowIndex As Integer = pm_table.Rows.Add(
                    SafeValue(record, "userId"),                    ' UserID
                    FormatDateValue(                                 ' dateAssigned
                        If(record.Table.Columns.Contains("dateAssigned") AndAlso Not record.IsNull("dateAssigned"),
                           record("dateAssigned"),
                           If(record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt"),
                              record("createdAt"),
                              DBNull.Value))
                    ),
                    firstName,                                       ' firstName
                    middleName,                                      ' middleName
                    lastName,                                        ' lastName
                    suffix,                                          ' suffixAdmin
                    SafeValue(record, "position"),                   ' positionAdmin (using position from DB)
                    SafeValue(record, "departmentId"),              ' DepartmentID
                    SafeValue(record, "employeeId"),               ' EmployeeID
                    SafeValue(record, "contactNumber"),             ' contactNumber
                    SafeValue(record, "email"),                     ' email
                    SafeValue(record, "username"),                   ' usernameAdmin
                    "******",                                        ' passwordAdmin (hidden)
                    SafeValue(record, "province_city"),             ' provinceAdmin
                    SafeValue(record, "municipality"),               ' municipality
                    SafeValue(record, "barangay"),                   ' barangay
                    SafeValue(record, "user_type"),                  ' Role
                    SafeValue(record, "status")                      ' Status
                )

                Dim dateAssignedValue As Object = DBNull.Value

                If record.Table.Columns.Contains("dateAssigned") AndAlso Not record.IsNull("dateAssigned") Then
                    dateAssignedValue = record("dateAssigned")
                ElseIf record.Table.Columns.Contains("createdAt") AndAlso Not record.IsNull("createdAt") Then
                    dateAssignedValue = record("createdAt")
                End If

                pm_table.Rows(rowIndex).Tag = New UserRowMetadata With {
                    .Username = SafeValue(record, "username"),
                    .EmployeeID = SafeValue(record, "employee_id"),
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
                totalLabel.Text = records.Rows.Count.ToString()
            End If

        Catch ex As Exception
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
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Dim addForm As New AddUserManagement()

            parentDashboard.LoadUserControl(addForm)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim selectedRow = GetSelectedRow()
        If selectedRow Is Nothing Then Return

        Dim metadata As UserRowMetadata = TryCast(selectedRow.Tag, UserRowMetadata)
        If metadata Is Nothing Then metadata = New UserRowMetadata()

        Dim editForm As New EditUser()
        editForm.SetAuditContext(currentAdminID, currentAdminType, currentAdminUsername)

        Dim dateAssignedValue As Date = Date.Today
        If metadata.DateAssigned IsNot Nothing AndAlso metadata.DateAssigned IsNot DBNull.Value Then
            Date.TryParse(metadata.DateAssigned.ToString(), dateAssignedValue)
        End If

        editForm.LoadUserData(
        selectedRow.Cells("userID").Value.ToString(),
        selectedRow.Cells("firstName").Value.ToString(),
        selectedRow.Cells("middleName").Value.ToString(),
        selectedRow.Cells("lastName").Value.ToString(),
        selectedRow.Cells("suffixAdmin").Value.ToString(),
        selectedRow.Cells("positionAdmin").Value.ToString(),
        selectedRow.Cells("departmentID").Value.ToString(),
        metadata.EmployeeID,
        selectedRow.Cells("contactNumber").Value.ToString(),
        selectedRow.Cells("email").Value.ToString(),
        selectedRow.Cells("usernameAdmin").Value.ToString(),  ' userRole
        selectedRow.Cells("provinceAdmin").Value.ToString(),
        selectedRow.Cells("municipality").Value.ToString(),
        selectedRow.Cells("barangay").Value.ToString(),
        "",
        dateAssignedValue,
        metadata.Username
    )

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
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
End Class
