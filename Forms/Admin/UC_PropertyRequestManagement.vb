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

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblpropertyrequestmanagement.CellContentClick
        If e.RowIndex >= 0 AndAlso tblpropertyrequestmanagement.Columns.Contains("action_edit") AndAlso
           e.ColumnIndex = tblpropertyrequestmanagement.Columns("action_edit").Index Then

            Dim reqIDValue As Object = tblpropertyrequestmanagement.Rows(e.RowIndex).Cells("request_id").Value
            Dim reqID As String = If(reqIDValue IsNot Nothing, reqIDValue.ToString(), "")
            MessageBox.Show("Edit Request: " & reqID, "Action", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Example: open edit request UC
            ' Dim uc As New UC_EditRequest()
            ' uc.LoadRequestData(reqID)
            ' Me.Parent.Controls.Add(uc) : uc.BringToFront()
        End If
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        MessageBox.Show("Delete request functionality here")
    End Sub

    Private Sub assign_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian
        ' Validate that a request is selected
        If tblpropertyrequestmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property request to assign.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = tblpropertyrequestmanagement.SelectedRows(0)

        ' Get request ID from selected row
        Dim requestIDValue As Object = Nothing
        If tblpropertyrequestmanagement.Columns.Contains("request_id") Then
            requestIDValue = selectedRow.Cells("request_id").Value
        ElseIf tblpropertyrequestmanagement.Columns.Contains("RequestID") Then
            requestIDValue = selectedRow.Cells("RequestID").Value
        ElseIf tblpropertyrequestmanagement.Columns.Count > 0 Then
            ' Try first column as request ID
            requestIDValue = selectedRow.Cells(0).Value
        End If

        If requestIDValue Is Nothing OrElse String.IsNullOrEmpty(requestIDValue.ToString()) Then
            MessageBox.Show("Invalid request selected. Please select a valid property request.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get request status to validate
        Dim requestStatus As String = ""
        If tblpropertyrequestmanagement.Columns.Contains("status") Then
            requestStatus = If(selectedRow.Cells("status").Value IsNot Nothing, selectedRow.Cells("status").Value.ToString(), "")
        ElseIf tblpropertyrequestmanagement.Columns.Contains("Status") Then
            requestStatus = If(selectedRow.Cells("Status").Value IsNot Nothing, selectedRow.Cells("Status").Value.ToString(), "")
        End If

        ' Only allow assigning approved or pending requests
        If Not String.IsNullOrEmpty(requestStatus) AndAlso requestStatus.ToLower() = "rejected" Then
            MessageBox.Show("Cannot assign a rejected request. Please select an approved or pending request.", "Invalid Request Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Dim assignForm As New AssignRequestManagement()
            ' Pass request ID to assign form if it has a method to load request data
            Try
                ' Try to set request ID using reflection or a public property
                Dim requestIDProp = assignForm.GetType().GetProperty("RequestID")
                If requestIDProp IsNot Nothing Then
                    requestIDProp.SetValue(assignForm, requestIDValue.ToString())
                End If
            Catch
                ' If property doesn't exist, continue anyway
            End Try
            parentDashboard.LoadUserControl(assignForm)
        End If
    End Sub

    Private Sub UC_PropertyRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequestData()
        ApplyPermissionState()
    End Sub

    Private Sub ApplyPermissionState()
        ' Super Admin, Admin, and Custodian have full access - ALL buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnApprove IsNot Nothing Then btnApprove.Enabled = hasFullAccess
        If btnReject IsNot Nothing Then btnReject.Enabled = hasFullAccess
        If assign IsNot Nothing Then assign.Enabled = hasFullAccess
        If prm_btn_update IsNot Nothing Then prm_btn_update.Enabled = hasFullAccess

    End Sub

    Private Sub LoadRequestData()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
            tblpropertyrequestmanagement.DataSource = dt
            tblpropertyrequestmanagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            tblpropertyrequestmanagement.ReadOnly = True
            tblpropertyrequestmanagement.AllowUserToAddRows = False
            tblpropertyrequestmanagement.AllowUserToDeleteRows = False
            tblpropertyrequestmanagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            
            ' Update total count
            Dim totalLabel As Label = Nothing
            Dim foundControls() As Control = Me.Controls.Find("ttlpropertyrequestmanagement", True)
            If foundControls.Length > 0 Then
                totalLabel = TryCast(foundControls(0), Label)
            End If
            If totalLabel IsNot Nothing Then
                totalLabel.Text = If(dt IsNot Nothing AndAlso dt.Rows.Count > 0, dt.Rows.Count.ToString(), "0")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading property requests: " & GetUserFriendlyErrorMessage(ex, "load property requests"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetUserFriendlyErrorMessage(ex As Exception, action As String) As String
        If ex Is Nothing Then Return "An unexpected error occurred."
        If ex.Message.Contains("SupplyID") OrElse ex.Message.Contains("Column named") Then
            Return "Data structure error. Please contact system administrator."
        End If
        Return "Unable to " & action & ". " & ex.Message
    End Function



    ' ----------------------------------------------------------------------
    ' PRINT PAR LOGIC — FULLY CONNECTED TO PROPERTYCARD
    ' ----------------------------------------------------------------------
    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click
        Dim InventoryCustodianSlip As New InventoryCustodianSlip()
        InventoryCustodianSlip.Show()
    End Sub

    Private Sub issuePropertyCard_Click(sender As Object, e As EventArgs) Handles issuePropertyCard.Click

        If tblpropertyrequestmanagement.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a row first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = tblpropertyrequestmanagement.CurrentRow

        ' Convert DataGridViewRow → DataRow (or pass values manually)
        Dim dt As DataTable = CType(tblpropertyrequestmanagement.DataSource, DataTable)
        Dim dataRow As DataRow = dt.Rows(row.Index)

        Dim cardForm As New PropertyCard(dataRow)
        cardForm.Show()
    End Sub


    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If tblpropertyrequestmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = tblpropertyrequestmanagement.SelectedRows(0)
            Dim dt As DataTable = TryCast(tblpropertyrequestmanagement.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim requestIDValue As Object = If(dt.Columns.Contains("request_id"), dataRow("request_id"), Nothing)
            Dim requestIDStr As String = If(requestIDValue IsNot Nothing AndAlso Not IsDBNull(requestIDValue), requestIDValue.ToString(), "")
            If String.IsNullOrEmpty(requestIDStr) OrElse Not Integer.TryParse(requestIDStr, Nothing) Then
                MessageBox.Show("Invalid request selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim requestID As Integer = Integer.Parse(requestIDStr)
            Dim statusValue As Object = If(dt.Columns.Contains("status"), dataRow("status"), Nothing)
            Dim currentStatus As String = If(statusValue IsNot Nothing AndAlso Not IsDBNull(statusValue), statusValue.ToString().ToLower(), "")

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
        Catch ex As Exception
            MessageBox.Show("Error approving request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If tblpropertyrequestmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = tblpropertyrequestmanagement.SelectedRows(0)
            Dim dt As DataTable = TryCast(tblpropertyrequestmanagement.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim requestIDValue As Object = If(dt.Columns.Contains("request_id"), dataRow("request_id"), Nothing)
            Dim requestIDStr As String = If(requestIDValue IsNot Nothing AndAlso Not IsDBNull(requestIDValue), requestIDValue.ToString(), "")
            If String.IsNullOrEmpty(requestIDStr) OrElse Not Integer.TryParse(requestIDStr, Nothing) Then
                MessageBox.Show("Invalid request selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim requestID As Integer = Integer.Parse(requestIDStr)
            Dim statusValue As Object = If(dt.Columns.Contains("status"), dataRow("status"), Nothing)
            Dim currentStatus As String = If(statusValue IsNot Nothing AndAlso Not IsDBNull(statusValue), statusValue.ToString().ToLower(), "")

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
        Catch ex As Exception
            MessageBox.Show("Error rejecting request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs) Handles prm_btn_update.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        If Not isSuperAdmin Then

            Return
        End If

        LoadRequestData()
        MessageBox.Show("Request list refreshed.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AssignRequestManagement())
        End If
    End Sub

End Class
