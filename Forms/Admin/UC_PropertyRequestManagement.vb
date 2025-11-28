Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_PropertyRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
        ApplyRolePermissions()
    End Sub


    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles prm_table1.CellContentClick
        If e.RowIndex >= 0 AndAlso prm_table1.Columns.Contains("action_edit") AndAlso e.ColumnIndex = prm_table1.Columns("action_edit").Index Then
            Dim reqID As String = prm_table1.Rows(e.RowIndex).Cells("request_id").Value?.ToString()
            MessageBox.Show("Edit Request: " & reqID, "Action", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Example to load edit UC
            ' Dim uc As New UC_EditRequest()
            ' uc.LoadRequestData(reqID)
            ' Me.Parent.Controls.Add(uc) : uc.BringToFront()
        End If
    End Sub

    Private Sub ApplyRolePermissions()
        btnAdd.Enabled = canModifyRequests
        btnDelete.Enabled = canModifyRequests
        assign.Enabled = canModifyRequests
    End Sub

    Private Sub ShowRequestRestrictionMessage()
        MessageBox.Show("You have view-only access to Property Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If
        MessageBox.Show("Delete request functionality here")
    End Sub

    Private Sub assign_Click(sender As Object, e As EventArgs) Handles assign.Click
        If Not canModifyRequests Then
            ShowRequestRestrictionMessage()
            Return
        End If
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AssignRequestManagement())
        End If
    End Sub
End Class
