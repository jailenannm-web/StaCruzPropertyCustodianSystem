Imports System.Windows.Forms

Public Class MaintenanceRequest
    Private Sub MaintenanceRequest_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As System.EventArgs) Handles RoundedButton1.Click
        Dim addMaintenanceRequest As New MaintenanceRequestForm()


        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addMaintenanceRequest)
    End Sub
End Class
