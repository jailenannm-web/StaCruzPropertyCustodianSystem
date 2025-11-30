Imports System
Imports System.Windows.Forms

Public Class AddPropertyRequest
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Optional: Add a Back button like in EditUser
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Hide()
    End Sub



    ' Optional: Add Save button logic
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Property Request added successfully!")
        ' Add your save logic here
    End Sub

    Private Sub approvedDate_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub purpose_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub request_date_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub status_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub approved_by_Click(sender As Object, e As EventArgs) Handles approved_by.Click

    End Sub

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub AddPropertyRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class