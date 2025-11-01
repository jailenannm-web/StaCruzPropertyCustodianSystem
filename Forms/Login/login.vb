Imports System

Public Class Login


    Private Sub btn_Cancel_Click(sender As Object, e As System.EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Panel1.Paint

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

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class