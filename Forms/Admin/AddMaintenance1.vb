Imports System
Imports System.Windows.Forms

Public Class AddMaintenance1
    Inherits UserControl

    Private canModifyMaintenance As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub AddMaintenance1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If Not EnsureModifyPermission() Then
            Return
        End If
        MessageBox.Show("Maintenance record saved.")
        ' Add your save logic here
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub admin_label_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_label_DepartmentManagement.Click
    End Sub

    Private Sub propertyLocation_TextChanged(sender As Object, e As EventArgs) Handles propertyLocation.TextChanged
    End Sub

    Private Sub SAAddM_NextSched_Click(sender As Object, e As EventArgs) Handles SAAddM_NextSched.Click
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_MaintenanceManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        canModifyMaintenance = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyMaintenance)
        If Not canModifyMaintenance Then
            MessageBox.Show("You have view-only access to Maintenance Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class

