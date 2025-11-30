Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class UC_MaintenanceManagement
    Inherits UserControl

    Private canModifyMaintenance As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyMaintenance = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyMaintenance)
        ApplyRoleRestrictions()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub UC_MaintenanceManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ApplyRoleRestrictions()
        btnApprove.Enabled = canModifyMaintenance
       btnAssign.Enabled = canModifyMaintenance
    End Sub

    Private Sub ShowMaintenanceRestriction()
        MessageBox.Show("You have view-only access to Maintenance Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If Not canModifyMaintenance Then
            ShowMaintenanceRestriction()
            Return
        End If
        ' Get reference to the parent dashboard form
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)

        If parentDashboard IsNot Nothing Then
            ' Load the AddSupply UserControl
            parentDashboard.LoadUserControl(New AddMaintenance1())
        Else
            ' Fallback: add directly to the parent container
            Dim addSupplyUC As New AddMaintenance1()
            Me.Parent.Controls.Add(addSupplyUC)
            addSupplyUC.BringToFront()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If Not canModifyMaintenance Then
            ShowMaintenanceRestriction()
            Return
        End If
        ' Get reference to the parent dashboard form
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)

        If parentDashboard IsNot Nothing Then
            ' Load the AddSupply UserControl
            parentDashboard.LoadUserControl(New AddMaintenance1())
        Else
            ' Fallback: add directly to the parent container
            Dim addSupplyUC As New EditMaintenance1()
            Me.Parent.Controls.Add(addSupplyUC)
            addSupplyUC.BringToFront()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

    End Sub

    Private Sub btnGenerateMaintenance_Click(sender As Object, e As EventArgs) Handles btnGenerateMaintenance.Click

        Dim addRequest As New MaintenanceReport()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(MaintenanceReport)
    End Sub

End Class
