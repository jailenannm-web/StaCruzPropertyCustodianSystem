Public Class SuperAdmin_Login

    Private Sub btn_Cancel_Click(sender As Object, e As System.EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_Login_Click(sender As Object, e As System.EventArgs) Handles btn_Login.Click
        ' 1. Create a new instance of the Dashboard form.
        Dim dashboardForm As New DashBoard()

        ' 2. Show the new form.
        dashboardForm.Show()

        ' 3. Close the current Login form.
        Me.Close()
    End Sub
End Class