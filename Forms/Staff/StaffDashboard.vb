Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class StaffDashboard
    Private isSidebarExpanded As Boolean = True
    Private sidebarExpandedWidth As Integer = 250
    Private sidebarCollapsedWidth As Integer = 60

    Private Sub tmrSidebar_Tick(sender As Object, e As EventArgs) Handles tmrSidebar.Tick

        If isSidebarExpanded Then
            ' --- COLLAPSE ---
            pnlSidebar.Width -= 20

            If pnlSidebar.Width <= sidebarCollapsedWidth Then
                ' Stop the animation
                pnlSidebar.Width = sidebarCollapsedWidth
                isSidebarExpanded = False
                tmrSidebar.Stop()

                ' --- HIDE TEXT ---
                For Each btn As Button In pnlSidebar.Controls.OfType(Of Button)()
                    btn.Text = ""
                    btn.ImageAlign = ContentAlignment.MiddleCenter
                Next
            End If
        Else
            ' --- EXPAND ---
            pnlSidebar.Width += 20

            If pnlSidebar.Width >= sidebarExpandedWidth Then
                ' Stop the animation
                pnlSidebar.Width = sidebarExpandedWidth
                isSidebarExpanded = True
                tmrSidebar.Stop()

                ' --- SHOW TEXT ---
                For Each btn As Button In pnlSidebar.Controls.OfType(Of Button)()
                    If btn.Tag IsNot Nothing Then
                        btn.Text = btn.Tag.ToString()
                    End If
                    btn.ImageAlign = ContentAlignment.MiddleLeft
                Next
            End If
        End If

    End Sub

    Private Sub SetActiveButton(ByVal activeBtn As Button)
        ' Define your colors
        Dim colorActive As Color = Color.FromArgb(70, 90, 120) ' Your lighter blue
        Dim colorDefault As Color = Color.FromArgb(35, 40, 60) ' Your dark blue

        ' --- 1. Reset ALL buttons to the default color ---
        ' Make sure to add all your menu buttons to this list
        ' (I'm guessing their names, update them if they are different)
        btnDashboard.BackColor = colorDefault
        btnProfile.BackColor = colorDefault
        btnPropertyRequest.BackColor = colorDefault
        btnViewInventory.BackColor = colorDefault
        btnMyRequest.BackColor = colorDefault
        btnBorrowedItem.BackColor = colorDefault
        btnReports.BackColor = colorDefault
        ' Add any other buttons you have...

        ' --- 2. Set the ONE active button to the new color ---
        activeBtn.BackColor = colorActive
    End Sub

    Private Sub ToggleSidebar()
        ' Only start the timer if it's not already animating
        If Not tmrSidebar.Enabled Then
            tmrSidebar.Start()
        End If
    End Sub





    Private Sub StaffDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set Dashboard as the active button on startup
        SetActiveButton(btnDashboard)

        ' --- ADD THIS LINE ---
        ' Hide the form loader panel to show your pnlMain
        pnlFormLoader.Visible = False

        ' (Your other load code... like sidebar setup)
    End Sub

    Private Sub pnlSidebar_Click(sender As Object, e As EventArgs) Handles pnlSidebar.Click
        ToggleSidebar()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ' --- THIS CHECK IS STILL NEEDED ---
        If Not isSidebarExpanded Then
            ' If the panel is collapsed, expand it.
            ToggleSidebar()
        End If
        ' --- END OF CHECK ---

        SetActiveButton(btnDashboard)
        pnlFormLoader.Visible = False

    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        ' --- This code expands the sidebar ---
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnProfile)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New frmProfile())
    End Sub

    Private Sub btnPropertyRequest_Click(sender As Object, e As EventArgs) Handles btnPropertyRequest.Click
        ' --- Expands sidebar if collapsed ---
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- Highlights the active button ---
        SetActiveButton(btnPropertyRequest) ' (Make sure this button name is in your SetActiveButton sub)

        ' --- Loads the new form ---
        loadFormIntoPanel(New frmPropertyRequest())
    End Sub

    Private Sub btnViewInventory_Click(sender As Object, e As EventArgs) Handles btnViewInventory.Click
        ' --- Expands sidebar if collapsed ---
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If
        SetActiveButton(btnViewInventory)

        ' --- Highlights the active button ---
        ' (Make sure btnViewInventory is in your SetActiveButton sub)
        SetActiveButton(btnViewInventory)

        ' --- Loads the new form ---
        loadFormIntoPanel(New frmInventory())
    End Sub

    Private Sub btnBorrowedItem_Click(sender As Object, e As EventArgs) Handles btnBorrowedItem.Click
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnBorrowedItem)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New frmBorrowedItem())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnReports)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New frmReports())

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' If the panel is collapsed, expand it.
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles comboMonth.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub pnlFormLoader_Paint(sender As Object, e As PaintEventArgs) Handles pnlFormLoader.Paint

    End Sub

    ' This code is in your StaffDashboard.vb
    ' This sub will load any form you give it into your panel
    Private Sub loadFormIntoPanel(ByVal formToLoad As Form)
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

    Private Sub dgvHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellContentClick

    End Sub

    Private Sub btnMyRequest_Click(sender As Object, e As EventArgs) Handles btnMyRequest.Click
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnMyRequest)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New frmRequest())
    End Sub
End Class