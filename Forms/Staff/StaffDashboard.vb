Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Public Class StaffDashboard
    Private isSidebarExpanded As Boolean = True
    Private sidebarExpandedWidth As Integer = 250
    Private sidebarCollapsedWidth As Integer = 60


    Private Sub SetActiveButton(ByVal activeBtn As Button)

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
        pnlFormLoader.Visible = True

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
        pnlFormLoader.Visible = True

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
        Dim logout As New logout()
        logout.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles comboMonth.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

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

    Private Sub dgvHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub admin_panel_borrowed_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub admin_panel_borrowed_Click_1(sender As Object, e As EventArgs) Handles admin_panel_borrowed.Click

    End Sub

    Private Sub RoundedPanel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub admin_panel_PendingRequests_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub pnlSidebar_Paint(sender As Object, e As PaintEventArgs) Handles pnlSidebar.Paint

    End Sub

    Private Sub tmrSidebar_Tick(sender As Object, e As EventArgs) Handles tmrSidebar.Tick

    End Sub

    Private Sub pnlMain_Paint(sender As Object, e As PaintEventArgs) Handles pnlMain.Paint

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub txtPersonalHistory_Click(sender As Object, e As EventArgs) Handles txtPersonalHistory.Click

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub



    Private Sub icStaff_Click(sender As Object, e As EventArgs) Handles icStaff.Click

    End Sub

    Private Sub txtStaff_Click(sender As Object, e As EventArgs) Handles txtStaff.Click

    End Sub

    Private Sub btnMaintenanceReq_Click(sender As Object, e As EventArgs) Handles btnMaintenanceReq.Click
        ' --- This code expands the sidebar ---
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnProfile)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New MaintenanceRequest())
    End Sub
End Class