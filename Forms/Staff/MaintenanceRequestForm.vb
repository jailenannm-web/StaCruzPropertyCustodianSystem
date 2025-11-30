Public Class MaintenanceRequestForm
    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Hide()
    End Sub
End Class
