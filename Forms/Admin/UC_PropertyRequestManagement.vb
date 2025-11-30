Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

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

            Dim reqID As String = prm_table1.Rows(e.RowIndex).Cells("request_id").Value?.ToString()
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

    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click

    End Sub

    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs) Handles prm_btn_update.Click

    End Sub
End Class
