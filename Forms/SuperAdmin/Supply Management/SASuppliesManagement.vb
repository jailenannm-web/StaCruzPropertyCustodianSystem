Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class SASuppliesManagement
    Private Sub SASuppliesManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAddSupply_Click(sender As Object, e As EventArgs) Handles btnAddSupply.Click

        ' 1. Create a new instance of your form
        Dim addUserForm As New SAAddSuppliesManagement()

        ' 2. Show it as a dialog, which pauses the code here
        '    until the "addUserForm" is closed.
        addUserForm.ShowDialog()

        ' 3. (Optional but recommended)
        '    After the form is closed, refresh your user list
        '    to show the new person you just added.
        '    RefreshUserList() ' (You would create this sub)
    End Sub

    Private Sub pnlCategories_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class