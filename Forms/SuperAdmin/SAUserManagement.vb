Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class SAUserManagement
    Private Sub SAUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ' 1. Create a new instance of your form
        Dim addUserForm As New SAAddAccountUserManagement()

        ' 2. Show it as a dialog, which pauses the code here
        '    until the "addUserForm" is closed.
        addUserForm.ShowDialog()

        ' 3. (Optional but recommended)
        '    After the form is closed, refresh your user list
        '    to show the new person you just added.
        '    RefreshUserList() ' (You would create this sub)

    End Sub

End Class