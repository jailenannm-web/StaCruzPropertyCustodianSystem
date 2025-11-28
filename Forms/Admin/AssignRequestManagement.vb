Imports System
Imports System.Windows.Forms

Public Class AssignRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub AssignRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If Not EnsureModifyPermission() Then
            Return
        End If
        MessageBox.Show("Property Request added successfully!")
        ' Add your save logic here
    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyRequestManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
        If Not canModifyRequests Then
            MessageBox.Show("You have view-only access to Property Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class

