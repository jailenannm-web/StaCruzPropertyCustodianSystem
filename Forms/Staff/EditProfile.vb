Imports System

Public Class EditProfile

    Private Sub btn_Cancel_Click(sender As Object, e As System.EventArgs) Handles btn_Cancel.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Hide()
    End Sub

End Class