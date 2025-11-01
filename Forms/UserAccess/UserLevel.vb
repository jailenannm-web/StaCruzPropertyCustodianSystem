Imports System
Imports System.Windows.Forms
Imports System.Drawing
Public Class UserLevel
    ' This code runs automatically when the Form is created and displayed.
    Private Sub Label2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the background color to Transparent
        Label2.BackColor = Color.Transparent
    End Sub

    Private Sub Label3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.BackColor = Color.Transparent
    End Sub

    Private Sub Label4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.BackColor = Color.Transparent
    End Sub

    Private Sub btn_SuperAdmin_Click(sender As Object, e As EventArgs) Handles btn_SuperAdmin.Click
        Dim superAdminForm As New SuperAdmin_Login()
        superAdminForm.Show()
        Me.Hide()
    End Sub

    Private Sub btn_Admin_Click(sender As Object, e As EventArgs) Handles btn_Admin.Click
        Dim adminForm As New Login()
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub btn_Staff_Click(sender As Object, e As EventArgs) Handles btn_Staff.Click
        Dim adminForm As New Login()
        StaffLogin.Show()
        Me.Hide()
    End Sub
End Class
