Public Class SuperAdmin_Login

    Private Sub btn_Cancel_Click(sender As Object, e As System.EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Close()
    End Sub


End Class