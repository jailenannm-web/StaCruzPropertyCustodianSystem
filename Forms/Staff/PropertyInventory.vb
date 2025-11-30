Imports System
Imports System.Windows.Forms

Public Class PropertyInventory
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub
    Private Sub btnrequestproperty_Click(sender As Object, e As System.EventArgs)
        Dim addRequest As New AddPropertyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnrequestproperty_Click_1(sender As Object, e As System.EventArgs) Handles btnrequestproperty.Click
        Dim addPropertyInventory As New AddPropertyRequest()

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addPropertyInventory)
    End Sub
End Class
