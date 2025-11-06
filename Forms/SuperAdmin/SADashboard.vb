Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Partial Class SADashboard
    Private tmrSidebar As Object

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnDashboard)
        ' No form load here to avoid recursively loading SADashboard into itself
    End Sub

    Private Sub SADashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Function sidebarCollapsedWidth() As Integer
        Throw New NotImplementedException()
    End Function

    Private Function isSidebarExpanded() As Boolean
        Throw New NotImplementedException()
    End Function

    Private Sub SetActiveButton(ByVal activeBtn As Button)
        ' Define your colors
        Dim colorActive As Color = Color.FromArgb(70, 90, 120) ' Your lighter blue
        Dim colorDefault As Color = Color.FromArgb(35, 40, 60) ' Your dark blue

        ' --- 1. Reset ALL buttons to the default color ---
        ' Make sure to add all your menu buttons to this list
        ' (I'm guessing their names, update them if they are different)
        btnDashboard.BackColor = colorDefault
        btnUserManagement.BackColor = colorDefault
        btnPropertyManagement.BackColor = colorDefault
        btnSuppliesManagement.BackColor = colorDefault
        btnDepartmentManagement.BackColor = colorDefault
        btnPropertyRequestManagement.BackColor = colorDefault
        btnMaintenanceManagement.BackColor = colorDefault
        btnReports.BackColor = colorDefault
        btnSystemConfig.BackColor = colorDefault
        ' Add any other buttons you have...

        ' --- 2. Set the ONE active button to the new color ---
        activeBtn.BackColor = colorActive
    End Sub




    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs) Handles btnUserManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnUserManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SAUserManagement())
    End Sub

    Public Sub loadFormIntoPanel(ByVal formToLoad As Form)
        ' Skip at design-time so the WinForms designer can open safely
        If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
            Return
        End If
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

    Private Sub btnPropertyManagement_Click(sender As Object, e As EventArgs) Handles btnPropertyManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnPropertyManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SAPropertyManagement())
    End Sub


    Private Sub btnDepartmentManagement_Click(sender As Object, e As EventArgs) Handles btnDepartmentManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnDepartmentManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SADepartmentManagement())
    End Sub

    Private Sub btnPropertyRequestManagement_Click(sender As Object, e As EventArgs) Handles btnPropertyRequestManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnPropertyRequestManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SAPropertyRequestManagement())
    End Sub

    Private Sub btnMaintenanceManagement_Click(sender As Object, e As EventArgs) Handles btnMaintenanceManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnMaintenanceManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SAMaintenenanceManagement())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnReports)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SAReportsManagement())
    End Sub

    Private Sub btnSystemConfig_Click(sender As Object, e As EventArgs) Handles btnSystemConfig.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnSystemConfig)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SASystemConfiguration())
    End Sub

    Private Sub pnlFormLoader_Paint(sender As Object, e As PaintEventArgs) Handles pnlFormLoader.Paint

    End Sub

    Private Sub btnSuppliesManagement_Click(sender As Object, e As EventArgs) Handles btnSuppliesManagement.Click
        ' --- This code changes the active button color ---
        SetActiveButton(btnSuppliesManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SASuppliesManagement())
    End Sub
End Class

