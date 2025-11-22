Imports System

Public Class logout

    Private Sub btn_Login_Click(sender As Object, e As System.EventArgs) Handles btn_Login.Click
        Me.Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click

    End Sub

    Private Sub btn_Logic_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim SADashboard As New SADashboard()
        SADashboard.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub
End Class