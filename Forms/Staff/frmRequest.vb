Imports System
Imports System.Windows.Forms
Public Class frmRequest
    Private Sub lblRequest_Click(sender As Object, e As EventArgs) Handles lblRequest.Click

    End Sub

    Private Sub btn_AddRequest_Click(sender As Object, e As EventArgs) Handles btn_Request.Click

        Dim addUserForm As New frmPropertyRequest()

        addUserForm.ShowDialog()


    End Sub

    Private Sub btn_Request_Click(sender As Object, e As EventArgs) Handles btn_Request.Click

    End Sub
End Class