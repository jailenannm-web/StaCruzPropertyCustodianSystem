Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class frmProfile

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim btn_Edit As New EditProfile()
        EditProfile.Show()
        Me.Hide()

    End Sub

    Private Sub frmProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class


