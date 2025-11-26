Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class UC_UserManagement
    Inherits UserControl

    Private currentAdminID As Integer?
    Private currentAdminType As String = ""
    Private currentAdminUsername As String = ""

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf UC_UserManagement_Load
    End Sub

    Private Sub UC_UserManagement_Load(sender As Object, e As EventArgs)
        ConfigureGrid()
        LoadAdminContext()
        RefreshUserTable()
    End Sub

    Private Sub ConfigureGrid()
        pm_table.AutoGenerateColumns = False
        pm_table.AllowUserToAddRows = False
        pm_table.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        pm_table.MultiSelect = False
        pm_table.Rows.Clear()
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

    Private Sub RefreshUserTable(Optional searchKeyword As String = "")
        Try
            pm_table.Rows.Clear()
            Dim records As DataTable = DatabaseConnection.GetAdminAccounts("", "", searchKeyword)

            For Each record As DataRow In records.Rows
                Dim rowIndex As Integer = pm_table.Rows.Add(
                    SafeValue(record, "user_id"),
                    SafeValue(record, "first_name"),
                    SafeValue(record, "middle_name"),
                    SafeValue(record, "last_name"),
                    SafeValue(record, "suffix"),
                    SafeValue(record, "position"),
                    SafeValue(record, "department_id"),
                    SafeValue(record, "contact_number"),
                    SafeValue(record, "email"),
                    SafeValue(record, "user_type"),
                    SafeValue(record, "province_city"),
                    SafeValue(record, "municipality"),
                    SafeValue(record, "barangay"),
                    SafeValue(record, "house_no_street"),
                    "********",
                    FormatDateValue(record("created_at")),
                    SafeValue(record, "status")
                )

                pm_table.Rows(rowIndex).Tag = New UserRowMetadata With {
                    .Username = SafeValue(record, "username"),
                    .EmployeeID = SafeValue(record, "employee_id"),
                    .DateAssigned = record("date_assigned"),
                    .CreatedAt = record("created_at")
                }
            Next
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
            addForm.SetAuditContext(currentAdminID, currentAdminType, currentAdminUsername)
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
            selectedRow.Cells("suffix").Value.ToString(),
            selectedRow.Cells("positionUser").Value.ToString(),
            selectedRow.Cells("departmentID").Value.ToString(),
            metadata.EmployeeID,
            selectedRow.Cells("contactNumber").Value.ToString(),
            selectedRow.Cells("email").Value.ToString(),
            selectedRow.Cells("userRole").Value.ToString(),
            selectedRow.Cells("province").Value.ToString(),
            selectedRow.Cells("municipalityCity").Value.ToString(),
            selectedRow.Cells("barangay").Value.ToString(),
            selectedRow.Cells("houseNumber").Value.ToString(),
            "",
            dateAssignedValue,
            selectedRow.Cells("accountStatus").Value.ToString(),
            metadata.Username
        )

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RefreshUserTable()
    End Sub

    Private Class UserRowMetadata
        Public Property Username As String = ""
        Public Property EmployeeID As String = ""
        Public Property DateAssigned As Object = Nothing
        Public Property CreatedAt As Object = Nothing
    End Class
End Class
