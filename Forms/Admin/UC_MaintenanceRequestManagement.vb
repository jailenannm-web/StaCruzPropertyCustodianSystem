Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_MaintenanceRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
    End Sub

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellContentClick
        If e.RowIndex >= 0 AndAlso propertyManagementGrid.Columns.Contains("action_edit") AndAlso
           e.ColumnIndex = propertyManagementGrid.Columns("action_edit").Index Then

            Dim reqID As String = propertyManagementGrid.Rows(e.RowIndex).Cells("request_id").Value?.ToString()
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
        ' You can load table data here if needed
    End Sub

    ' ----------------------------------------------------------------------
    ' PRINT PAR LOGIC — FULLY CONNECTED TO PROPERTYCARD
    ' ----------------------------------------------------------------------
    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click

    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click

    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click

    End Sub

    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs) Handles prm_btn_update.Click

    End Sub
End Class
