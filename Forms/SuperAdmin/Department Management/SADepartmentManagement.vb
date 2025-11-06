Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class SADepartmentManagement
    Private pnlFormLoader As Object

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub pnlSearch_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlCategories_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub comboCategoris_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblSuppliesManagement_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlStatus_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub comboStatus_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAddDepartent_Click(sender As Object, e As EventArgs)



        ' 1. Create a new instance of your form
        Dim addUserForm As New SAAddDepartmentManagement()

        ' 2. Show it as a dialog, which pauses the code here
        '    until the "addUserForm" is closed.
        addUserForm.ShowDialog()

        ' 3. (Optional but recommended)
        '    After the form is closed, refresh your user list
        '    to show the new person you just added.
        '    RefreshUserList() ' (You would create this sub)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SADepartmentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub loadFormIntoPanel(ByVal formToLoad As Form)
        ' Clear any other form out of the panel
        If pnlFormLoader.Controls.Count > 0 Then
            pnlFormLoader.Controls.Clear()
        End If

        ' --- Setup the new form ---
        formToLoad.TopLevel = False  ' This is key for nesting
        formToLoad.Dock = DockStyle.Fill ' Make it fill the panel

        ' --- Add the new form to the panel ---
        pnlFormLoader.Controls.Add(formToLoad)
        pnlFormLoader.Tag = formToLoad
        formToLoad.Show() ' Show the form

        ' --- Show the panel ---
        pnlFormLoader.Visible = True
        pnlFormLoader.BringToFront() ' Make sure it's on top of pnlMain
    End Sub

    Private Sub RoundedPanel2_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel2.Paint

    End Sub
End Class