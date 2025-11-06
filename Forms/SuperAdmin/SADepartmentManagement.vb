Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class SADepartmentManagement
    Private pnlFormLoader As Object

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub pnlSearch_Paint(sender As Object, e As PaintEventArgs) Handles pnlSearch.Paint

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub pnlCategories_Paint(sender As Object, e As PaintEventArgs) Handles pnlCategories.Paint

    End Sub

    Private Sub comboCategoris_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCategoris.SelectedIndexChanged

    End Sub

    Private Sub lblSuppliesManagement_Click(sender As Object, e As EventArgs) Handles lblSuppliesManagement.Click

    End Sub

    Private Sub pnlStatus_Paint(sender As Object, e As PaintEventArgs) Handles pnlStatus.Paint

    End Sub

    Private Sub comboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboStatus.SelectedIndexChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnAddDepartent_Click(sender As Object, e As EventArgs) Handles btnAddDepartent.Click



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

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles lblBudget.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles lblActiveDep.Click

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
End Class