Imports System
Imports System.Windows.Forms

Public Class StaffRegister

    ' Register button click
    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
        ' TODO: Add your registration logic (e.g., save user to file/database)

        MessageBox.Show("Registration successful!")

        ' After registration, go back to StaffLogin
        Dim loginForm As New StaffLogin()
        loginForm.Show()
        Me.Close()
    End Sub

    ' Cancel button click
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim loginForm As New StaffLogin()
        loginForm.Show()
        Me.Close()
    End Sub

End Class
