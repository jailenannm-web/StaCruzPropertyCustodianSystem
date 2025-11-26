Imports System
Imports System.Transactions
Imports System.Windows.Forms

Public Class PropertyTransaction
    Private Sub admin_label_Dashboard_Click(sender As Object, e As System.EventArgs) Handles admin_label_Dashboard.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub pnlTransaction_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlTransaction.Paint

    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As System.EventArgs) Handles RoundedButton1.Click
        ' Clear any existing controls in the panel
        pnlTransaction.Controls.Clear()

        ' Create a new instance of the form
        Dim transactionForm As New TrnsBorrowItem()

        ' Make the form a child of the panel
        transactionForm.TopLevel = False
        transactionForm.FormBorderStyle = FormBorderStyle.None
        transactionForm.Dock = DockStyle.Fill

        ' Add the form to the panel and show it
        pnlTransaction.Controls.Add(transactionForm)
        transactionForm.Show()

    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        ' Clear any existing controls in the panel
        pnlTransaction.Controls.Clear()

        ' Create a new instance of the form
        Dim transactionForm As New TrnsReturnItem()

        ' Make the form a child of the panel
        transactionForm.TopLevel = False
        transactionForm.FormBorderStyle = FormBorderStyle.None
        transactionForm.Dock = DockStyle.Fill

        ' Add the form to the panel and show it
        pnlTransaction.Controls.Add(transactionForm)
        transactionForm.Show()
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        ' Clear any existing controls in the panel
        pnlTransaction.Controls.Clear()

        ' Create a new instance of the form
        Dim transactionForm As New TrnsRepairItem()

        ' Make the form a child of the panel
        transactionForm.TopLevel = False
        transactionForm.FormBorderStyle = FormBorderStyle.None
        transactionForm.Dock = DockStyle.Fill

        ' Add the form to the panel and show it
        pnlTransaction.Controls.Add(transactionForm)
        transactionForm.Show()
    End Sub
End Class