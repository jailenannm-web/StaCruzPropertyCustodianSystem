Imports System
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


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
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supply requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyPermissionState()
        If btnApprove IsNot Nothing Then btnApprove.Enabled = canModifyRequests
        If btnReject IsNot Nothing Then btnReject.Enabled = canModifyRequests
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If Not canModifyRequests Then
            MessageBox.Show("You have view-only access to Supply Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' TODO: Implement reject functionality
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If Not canModifyRequests Then
            MessageBox.Show("You have view-only access to Supply Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' TODO: Implement approve functionality
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
