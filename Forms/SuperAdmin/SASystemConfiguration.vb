Public Class SASystemConfiguration
    Private Sub SASystemConfiguration_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblSystemConfig_Click(sender As Object, e As System.EventArgs) Handles lblSystemConfig.Click
        ' Optional: Another hidden opening trigger
    End Sub

    Public Sub OpenConfig()
        Me.Show()
        Me.BringToFront()
    End Sub
End Class
