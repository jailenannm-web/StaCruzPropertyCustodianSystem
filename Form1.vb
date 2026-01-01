Imports System
Imports System.Windows.Forms

Public Class Form1


    Private Sub btn_Logic_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim SADashboard As New SADashboard()
        SADashboard.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub

    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        Dim login As New StaffLogin()
        StaffLogin.Show()   ' Show the register form
        Me.Hide()
    End Sub
End Class