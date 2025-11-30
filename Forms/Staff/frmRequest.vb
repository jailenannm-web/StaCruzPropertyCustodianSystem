Imports System
Imports System.Windows.Forms
Public Class frmRequest
    Private Sub lblRequest_Click(sender As Object, e As EventArgs) Handles lblRequest.Click

    End Sub

    Private Sub btn_AddRequest_Click(sender As Object, e As EventArgs) 

        Dim addUserForm As New frmPropertyRequest()

        addUserForm.ShowDialog()


    End Sub

End Class