Imports System
Imports System.Windows.Forms

Public Class SupplyInventory
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub
    Private Sub btnrequestsupply_Click(sender As Object, e As System.EventArgs)
        Dim addRequest As New AddSupplyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnrequestsupply_Click_1(sender As Object, e As System.EventArgs) Handles btnrequestsupply.Click
        Dim addSupplyInventory As New AddSupplyRequest()

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addSupplyInventory)
    End Sub

End Class
