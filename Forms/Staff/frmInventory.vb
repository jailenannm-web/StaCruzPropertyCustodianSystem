Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class frmInventory
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub btnOpenTransaction_Click(sender As Object, e As EventArgs) Handles btnOpenTransaction.Click
        Dim addForm As New PropertyTransaction()
        addForm.Show()
    End Sub

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class