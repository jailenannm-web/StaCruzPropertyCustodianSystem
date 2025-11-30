Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq


Public Class UC_PropertyRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
    End Sub

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles prm_table1.CellContentClick
        If e.RowIndex >= 0 AndAlso prm_table1.Columns.Contains("action_edit") AndAlso
           e.ColumnIndex = prm_table1.Columns("action_edit").Index Then

            Dim reqIDValue As Object = prm_table1.Rows(e.RowIndex).Cells("request_id").Value
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

    Private Sub UC_PropertyRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequestData()
        ApplyPermissionState()
    End Sub

    Private Sub LoadRequestData()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
            prm_table1.DataSource = dt
            prm_table1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            prm_table1.ReadOnly = True
            prm_table1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            
            ' Update total count
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Find the total label control - adjust name if needed
                Dim totalLabel As Label = TryCast(Me.Controls.Find("ttlpropertymanagement", True).FirstOrDefault(), Label)
                If totalLabel IsNot Nothing Then
                    totalLabel.Text = "TOTAL: " & dt.Rows.Count.ToString()
                End If
            Else
                Dim totalLabel As Label = TryCast(Me.Controls.Find("ttlpropertymanagement", True).FirstOrDefault(), Label)
                If totalLabel IsNot Nothing Then
                    totalLabel.Text = "TOTAL: 0"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading property requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyPermissionState()
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        ' Super Admin can do all actions, Admin can only Approve/Reject
        If btnApprove IsNot Nothing Then btnApprove.Enabled = (isSuperAdmin OrElse isAdmin)
        If btnReject IsNot Nothing Then btnReject.Enabled = (isSuperAdmin OrElse isAdmin)
        If assign IsNot Nothing Then assign.Enabled = isSuperAdmin
        If prm_btn_update IsNot Nothing Then prm_btn_update.Enabled = isSuperAdmin
    End Sub

    ' ----------------------------------------------------------------------
    ' PRINT PAR LOGIC — FULLY CONNECTED TO PROPERTYCARD
    ' ----------------------------------------------------------------------
    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click
        Dim InventoryCustodianSlip As New InventoryCustodianSlip()
        InventoryCustodianSlip.Show()
    End Sub

    Private Sub issuePropertyCard_Click(sender As Object, e As EventArgs) Handles issuePropertyCard.Click

        If prm_table1.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a row first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = prm_table1.CurrentRow

        ' Convert DataGridViewRow → DataRow (or pass values manually)
        Dim dt As DataTable = CType(prm_table1.DataSource, DataTable)
        Dim dataRow As DataRow = dt.Rows(row.Index)

        Dim cardForm As New PropertyCard(dataRow)
        cardForm.Show()
    End Sub


    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If

        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
        Dim requestIDValue As Object = selectedRow.Cells("request_id").Value
        Dim requestIDStr As String = If(requestIDValue IsNot Nothing, requestIDValue.ToString(), "")
        If String.IsNullOrEmpty(requestIDStr) OrElse Not Integer.TryParse(requestIDStr, Nothing) Then
            MessageBox.Show("Invalid request selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim requestID As Integer = Integer.Parse(requestIDStr)
        Dim statusValue As Object = selectedRow.Cells("Status").Value
        Dim currentStatus As String = If(statusValue IsNot Nothing, statusValue.ToString().ToLower(), "")

        If currentStatus = "approved" Then
            MessageBox.Show("This request is already approved.", "Already Approved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If currentStatus = "rejected" Then
            MessageBox.Show("This request has been rejected and cannot be approved.", "Request Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim remarks As String = InputBox("Enter approval remarks (optional):", "Approve Request", "")
        Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

        If DatabaseConnection.ApprovePropertyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole) Then
            MessageBox.Show("Request approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadRequestData()
        Else
            MessageBox.Show("Failed to approve request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If

        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
        Dim requestIDValue As Object = selectedRow.Cells("request_id").Value
        Dim requestIDStr As String = If(requestIDValue IsNot Nothing, requestIDValue.ToString(), "")
        If String.IsNullOrEmpty(requestIDStr) OrElse Not Integer.TryParse(requestIDStr, Nothing) Then
            MessageBox.Show("Invalid request selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim requestID As Integer = Integer.Parse(requestIDStr)
        Dim statusValue As Object = selectedRow.Cells("Status").Value
        Dim currentStatus As String = If(statusValue IsNot Nothing, statusValue.ToString().ToLower(), "")

        If currentStatus = "rejected" Then
            MessageBox.Show("This request is already rejected.", "Already Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If currentStatus = "approved" Then
            Dim result As DialogResult = MessageBox.Show("This request is already approved. Do you want to reject it anyway?", "Request Already Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result <> DialogResult.Yes Then
                Return
            End If
        End If

        Dim remarks As String = InputBox("Enter rejection reason (required):", "Reject Request", "")
        If String.IsNullOrWhiteSpace(remarks) Then
            MessageBox.Show("Rejection reason is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

        If DatabaseConnection.RejectPropertyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
            MessageBox.Show("Request rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadRequestData()
        Else
            MessageBox.Show("Failed to reject request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs) Handles prm_btn_update.Click
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If

        LoadRequestData()
        MessageBox.Show("Request list refreshed.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
