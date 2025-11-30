Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

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

    Private Sub ShowRequestRestrictionMessage()
        MessageBox.Show("You have view-only access to Property Request Management.",
                        "Access Restricted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If

        MessageBox.Show("Delete request functionality here")
    End Sub

    Private Sub assign_Click(sender As Object, e As EventArgs)
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If

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
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        ' Both Super Admin and Admin can Update, Approve, and Reject
        If btnApprove IsNot Nothing Then btnApprove.Enabled = (isSuperAdmin OrElse isAdmin)
        If btnReject IsNot Nothing Then btnReject.Enabled = (isSuperAdmin OrElse isAdmin)
        If prm_btn_update IsNot Nothing Then prm_btn_update.Enabled = (isSuperAdmin OrElse isAdmin)
    End Sub

    Private Sub ShowMaintenanceRequestRestrictionMessage()
        MessageBox.Show("You have view-only access to Maintenance Request Management.",
                        "Access Restricted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    ' ----------------------------------------------------------------------
    ' PRINT PAR LOGIC — FULLY CONNECTED TO PROPERTYCARD
    ' ----------------------------------------------------------------------
    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click
        ' TODO: Implement maintenance report generation
        MessageBox.Show("Maintenance report generation feature will be implemented.", "Feature Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        If Not (isSuperAdmin OrElse isAdmin) Then
            ShowMaintenanceRequestRestrictionMessage()
            Return
        End If

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
            MessageBox.Show("Error approving maintenance request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        If Not (isSuperAdmin OrElse isAdmin) Then
            ShowMaintenanceRequestRestrictionMessage()
            Return
        End If

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
            MessageBox.Show("Error rejecting maintenance request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs) Handles prm_btn_update.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        If Not (isSuperAdmin OrElse isAdmin) Then
            ShowMaintenanceRequestRestrictionMessage()
            Return
        End If

        LoadMaintenanceRequestData()
        MessageBox.Show("Maintenance request list refreshed.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
