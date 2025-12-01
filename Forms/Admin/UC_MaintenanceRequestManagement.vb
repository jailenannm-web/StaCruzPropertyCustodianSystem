Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class UC_MaintenanceRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyMaintenance)
    End Sub

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellContentClick
        If e.RowIndex >= 0 AndAlso propertyManagementGrid.Columns.Contains("action_edit") AndAlso
           e.ColumnIndex = propertyManagementGrid.Columns("action_edit").Index Then

            Dim reqIDValue As Object = propertyManagementGrid.Rows(e.RowIndex).Cells("request_id").Value
            Dim reqID As String = If(reqIDValue IsNot Nothing, reqIDValue.ToString(), "")
            MessageBox.Show("Edit Request: " & reqID, "Action", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Example: open edit request UC
            ' Dim uc As New UC_EditRequest()
            ' uc.LoadRequestData(reqID)
            ' Me.Parent.Controls.Add(uc) : uc.BringToFront()
        End If
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        If Not isSuperAdmin Then

            Return
        End If

        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            Dim dt As DataTable = TryCast(propertyManagementGrid.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim requestID As Integer = Convert.ToInt32(dataRow("request_id"))

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this maintenance request? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                ' Delete maintenance request using DatabaseConnection
                Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                    Using cmd As New MySqlCommand("DELETE FROM maintenance_requests WHERE request_id = @requestID", conn)
                        cmd.Parameters.AddWithValue("@requestID", requestID)
                        If cmd.ExecuteNonQuery() > 0 Then
                            MessageBox.Show("Maintenance request deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadMaintenanceRequestData()
                        Else
                            MessageBox.Show("Failed to delete maintenance request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                    If conn.State = ConnectionState.Open Then conn.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting maintenance request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub assign_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AssignRequestManagement())
        End If
    End Sub

    Private Sub UC_MaintenanceRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMaintenanceRequestData()
        ApplyPermissionState()
    End Sub

    Private Sub LoadMaintenanceRequestData()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllMaintenanceRequests()
            propertyManagementGrid.DataSource = dt
            propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            propertyManagementGrid.ReadOnly = True
            propertyManagementGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ttlpropertymanagement.Text = dt.Rows.Count.ToString()
            Else
                ttlpropertymanagement.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ttlpropertymanagement.Text = "0"
        End Try
    End Sub

    Private Sub ApplyPermissionState()
        ' Super Admin, Admin, and Custodian have full access - ALL buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnApprove IsNot Nothing Then btnApprove.Enabled = hasFullAccess
        If btnReject IsNot Nothing Then btnReject.Enabled = hasFullAccess
        If prm_btn_update IsNot Nothing Then prm_btn_update.Enabled = hasFullAccess
        If btnAdd IsNot Nothing Then btnAdd.Enabled = hasFullAccess
        If btnDelete IsNot Nothing Then btnDelete.Enabled = hasFullAccess
    End Sub


    ' ----------------------------------------------------------------------
    ' PRINT PAR LOGIC — FULLY CONNECTED TO PROPERTYCARD
    ' ----------------------------------------------------------------------
    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click
        ' TODO: Implement maintenance report generation
        MessageBox.Show("Maintenance report generation feature will be implemented.", "Feature Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            Dim dt As DataTable = TryCast(propertyManagementGrid.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim requestID As Integer = Convert.ToInt32(dataRow("request_id"))
            Dim currentStatus As String = If(IsDBNull(dataRow("status")), "", dataRow("status").ToString().ToLower())

            If currentStatus = "completed" OrElse currentStatus = "approved" OrElse currentStatus = "in progress" Then
                MessageBox.Show("This maintenance request is already processed.", "Already Processed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim remarks As String = InputBox("Enter approval remarks (optional):", "Approve Maintenance Request", "")
            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            ' Update maintenance request status to approved
            If DatabaseConnection.ApproveMaintenanceRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Maintenance request approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMaintenanceRequestData()
            Else
                MessageBox.Show("Failed to approve maintenance request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while approving the maintenance request."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to approve the maintenance request. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            Dim dt As DataTable = TryCast(propertyManagementGrid.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim requestID As Integer = Convert.ToInt32(dataRow("request_id"))
            Dim currentStatus As String = If(IsDBNull(dataRow("status")), "", dataRow("status").ToString().ToLower())

            If currentStatus = "rejected" Then
                MessageBox.Show("This maintenance request is already rejected.", "Already Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim remarks As String = InputBox("Enter rejection reason (required):", "Reject Maintenance Request", "")
            If String.IsNullOrWhiteSpace(remarks) Then
                MessageBox.Show("Rejection reason is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            ' Update maintenance request status to rejected
            If DatabaseConnection.RejectMaintenanceRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Maintenance request rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMaintenanceRequestData()
            Else
                MessageBox.Show("Failed to reject maintenance request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while rejecting the maintenance request."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to reject the maintenance request. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs) Handles prm_btn_update.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        LoadMaintenanceRequestData()
        MessageBox.Show("Maintenance request list refreshed.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
