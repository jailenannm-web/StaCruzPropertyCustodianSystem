Imports System.Windows.Forms
Imports System.Linq
Imports System
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class BorrowingAndReturnSlip
    Private Sub Label16_Click(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub BorrowingAndReturnSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles RoundedButton4.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Close()
    End Sub
End Class