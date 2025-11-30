Imports System
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq


Public Class UC_SupplyRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
    End Sub

    Private Sub UC_SupplyRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplyRequestData()
        ApplyPermissionState()
    End Sub

    Private Sub LoadSupplyRequestData()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllSuppliesRequests()
            If prm_table1 IsNot Nothing Then
                prm_table1.DataSource = dt
                prm_table1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                prm_table1.ReadOnly = True
                prm_table1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

                ' Update total count
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
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
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supply requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyPermissionState()
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        ' Both Super Admin and Admin can Approve/Reject
        If btnApprove IsNot Nothing Then btnApprove.Enabled = (isSuperAdmin OrElse isAdmin)
        If btnReject IsNot Nothing Then btnReject.Enabled = (isSuperAdmin OrElse isAdmin)
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        If Not (isSuperAdmin OrElse isAdmin) Then
            MessageBox.Show("You have view-only access to Supply Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
            Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim requestID As Integer = Convert.ToInt32(dataRow("request_id"))
            Dim currentStatus As String = If(IsDBNull(dataRow("status")), "", dataRow("status").ToString().ToLower())

            If currentStatus = "rejected" Then
                MessageBox.Show("This request is already rejected.", "Already Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim remarks As String = InputBox("Enter rejection reason (required):", "Reject Supply Request", "")
            If String.IsNullOrWhiteSpace(remarks) Then
                MessageBox.Show("Rejection reason is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            If DatabaseConnection.RejectSupplyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Supply request rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSupplyRequestData()
            Else
                MessageBox.Show("Failed to reject supply request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error rejecting supply request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        If Not (isSuperAdmin OrElse isAdmin) Then
            MessageBox.Show("You have view-only access to Supply Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
            Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim requestID As Integer = Convert.ToInt32(dataRow("request_id"))
            Dim currentStatus As String = If(IsDBNull(dataRow("status")), "", dataRow("status").ToString().ToLower())

            If currentStatus = "approved" Then
                MessageBox.Show("This request is already approved.", "Already Approved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If currentStatus = "rejected" Then
                MessageBox.Show("This request has been rejected and cannot be approved.", "Request Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim remarks As String = InputBox("Enter approval remarks (optional):", "Approve Supply Request", "")
            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            If DatabaseConnection.ApproveSupplyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Supply request approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSupplyRequestData()
            Else
                MessageBox.Show("Failed to approve supply request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error approving supply request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub issueRequisition_Click(sender As Object, e As EventArgs) Handles issueRequisition.Click
        Dim addSupplyRequestManagement As New RequisitionIssueSlip()
        addSupplyRequestManagement.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addSupplyRequestManagement)
    End Sub

    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click

    End Sub

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles prm_table1.CellContentClick

    End Sub
End Class
