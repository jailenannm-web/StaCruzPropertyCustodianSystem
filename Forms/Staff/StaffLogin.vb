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
    Private Sub btn_Login_Click(sender As Object, e As EventArgs)
        ' Example: Check username/password (replace with your logic) 
        Dim username As String = txb_Username.Text
        Dim password As String = txb_Password.Text


        ' TODO: Add actual authentication here

        ' If login successful, open the StaffDashboard
        Dim staffDashboard As New StaffDashboard()
        staffDashboard.Show()
        Me.Close()
    End Sub

    ' Cancel button click


    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_Login_Click_1(sender As Object, e As EventArgs) Handles btn_Login.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub txb_Password_TextChanged(sender As Object, e As EventArgs) Handles txb_Password.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub txb_Username_TextChanged(sender As Object, e As EventArgs) Handles txb_Username.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class