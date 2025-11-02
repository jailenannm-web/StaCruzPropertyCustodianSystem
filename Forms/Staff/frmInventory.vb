Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class frmInventory

    Private placeholderText As String = "Search"

    Private Sub txtPersonalHistory_Click(sender As Object, e As EventArgs) Handles lblInventory.Click

    End Sub

    Private Sub RoundedPanel2_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel2.Paint

    End Sub

    Private Sub RoundedPanel4_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel4.Paint

    End Sub


    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        ' If the text is the placeholder, clear it
        If txtSearch.Text = placeholderText Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.White ' Or your normal text color
        End If
    End Sub

    Private Sub frmViewInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSearch.Text = placeholderText
        txtSearch.ForeColor = Color.Gray
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        ' If the text is empty, put the placeholder back
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = placeholderText
            txtSearch.ForeColor = Color.White
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub comboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCategory.SelectedIndexChanged

    End Sub

    Private Sub dgvInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellContentClick

    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class