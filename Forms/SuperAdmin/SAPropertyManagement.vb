Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class SAPropertyManagement
    Private pnlFormLoader As Object

    Private Sub RoundedPanel4_Paint(sender As Object, e As PaintEventArgs) Handles pnlStatus.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnAddSupply_Click(sender As Object, e As EventArgs) Handles btnAddSupply.Click


        ' 1. Create a new instance of your form
        Dim addUserForm As New SAAddPropertyManagement()

        ' 2. Show it as a dialog, which pauses the code here
        '    until the "addUserForm" is closed.
        addUserForm.ShowDialog()

        ' 3. (Optional but recommended)
        '    After the form is closed, refresh your user list
        '    to show the new person you just added.
        '    RefreshUserList() ' (You would create this sub)
    End Sub
End Class