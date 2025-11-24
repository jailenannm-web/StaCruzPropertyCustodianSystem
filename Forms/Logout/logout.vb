Imports System
Imports System.Windows.Forms

Public Class logout


    Private Sub btn_Logic_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim SADashboard As New SADashboard()
        SADashboard.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub
End Class