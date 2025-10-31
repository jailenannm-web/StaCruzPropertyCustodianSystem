Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices

Public Class StaffLogin

    ' Click on "Don't have account yet" label to go to StaffRegister
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        ' Create a new instance of StaffRegister form
        Dim registerForm As New StaffRegister()
        registerForm.Show()   ' Show the register form
        Me.Close()            ' Close current login form
    End Sub

    ' Login button click (you can add your login logic here)
    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        ' Example: Check username/password (replace with your logic)
        Dim username As String = txb_Username.Text
        Dim password As String = Txb_Password.Text

        ' TODO: Add actual authentication here

        ' If login successful, open the StaffDashboard
        Dim staffDashboard As New StaffDashboard()
        staffDashboard.Show()
        Me.Close()
    End Sub

    ' Cancel button click
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        ' Go back to general User form
        Dim loginForm As New StaffLogin()
        loginForm.Show()  ' This is OK because StaffLogin is a Form
        Me.Close()       ' Close the StaffLogin form
    End Sub

End Class
