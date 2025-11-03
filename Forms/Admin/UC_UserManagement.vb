Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports StaCruzPropertyCustodianSystem.Resources.Controls
Public Class UC_UserManagement
    Inherits UserControl

    Public Sub New()
        InitializeComponent()

        ' Make this UserControl automatically fill the parent panel
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub admin_label_Dashboard_Click(sender As Object, e As EventArgs) Handles admin_label_Dashboard.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles uc_um_fullname.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles uc_um_userposition.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles uc_um_userFullName.TextChanged

    End Sub

    Private Sub uc_um_position_Click(sender As Object, e As EventArgs) Handles uc_um_position.Click

    End Sub

    Private Sub uc_um_edit_Click(sender As Object, e As EventArgs) Handles uc_um_edit.Click
        ' Create the EditUser UserControl
        Dim ucEdit As New EditUser()

        ' Pass the current user data
        ucEdit.LoadUserData(
        uc_um_userFullName.Text,
        uc_um_userposition.Text,
        "user@example.com",      ' Replace with actual email
        "username123",           ' Replace with actual username
        "password123",           ' Replace with actual password
        "123 Main St",           ' Replace with actual address
        "Assignment1",           ' Replace with actual assignment
        "EMP001",                ' Replace with actual employee ID
        "Active",                ' Replace with actual status
        "LastLoginInfo",         ' Replace with actual last login
        "01/01/2025"             ' Replace with actual created date
    )

        ' Load EditUser in the Dashboard panel
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(ucEdit)
        End If
    End Sub
End Class
