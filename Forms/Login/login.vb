Imports System
Imports System.Windows.Forms

Public Class Login

    ' Login button click
    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        Dim username As String = txb_Username.Text
        Dim password As String = Txb_Password.Text

        ' TODO: Add authentication logic for SuperAdmin/Admin
        ' Example: If username = "superadmin" Then open SuperAdminDashboard
        If username = "superadmin" Then
            Dim dashboard As New SuperAdminDashboard()
            dashboard.Show()
            Me.Close()
        ElseIf username = "admin" Then
            Dim dashboard As New AdminDashboard()
            dashboard.Show()
            Me.Close()
        Else
            MessageBox.Show("Invalid credentials.")
        End If
    End Sub

    ' Cancel button click
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Close()
    End Sub

End Class
