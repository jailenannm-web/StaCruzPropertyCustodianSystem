Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class frmInventory
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub btnOpenTransaction_Click(sender As Object, e As EventArgs)
        Dim addForm As New PropertyTransaction()
        addForm.Show()
    End Sub

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnrequestproperty_Click(sender As Object, e As EventArgs) Handles btnrequestproperty.Click
        Dim addRequest As New AddPropertyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub btnrequestsupply_Click(sender As Object, e As EventArgs) Handles btnrequestsupply.Click
        Dim addRequest As New AddSupplyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

End Class