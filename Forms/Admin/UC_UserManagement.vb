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

        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub admin_label_Dashboard_Click(sender As Object, e As EventArgs) Handles admin_label_Dashboard.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub uc_um_position_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddUserManagement())
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New EditUser())
        End If
    End Sub

End Class
