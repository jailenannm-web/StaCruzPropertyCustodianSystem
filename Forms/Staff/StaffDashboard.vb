Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Imports StaCruzPropertyCustodianSystem.Resources.Controls

Public Class StaffDashboard
    Inherits Form

    Private isSidebarExpanded As Boolean = True
    Private sidebarExpandedWidth As Integer = 250
    Private sidebarCollapsedWidth As Integer = 60

    ' Sidebar animation timer is already declared in Designer as WithEvents
    ' Friend WithEvents tmrSidebar As Timer

    Private Sub StaffDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set timer interval
        tmrSidebar.Interval = 1
        SetActiveButton(btnDashboard)
        pnlFormLoader.Visible = False
    End Sub

    Private Sub tmrSidebar_Tick(sender As Object, e As EventArgs) Handles tmrSidebar.Tick
        If isSidebarExpanded Then
            pnlSidebar.Width -= 20
            If pnlSidebar.Width <= sidebarCollapsedWidth Then
                pnlSidebar.Width = sidebarCollapsedWidth
                isSidebarExpanded = False
                tmrSidebar.Stop()
                For Each btn As Button In pnlSidebar.Controls.OfType(Of Button)()
                    btn.Text = ""
                    btn.ImageAlign = ContentAlignment.MiddleCenter
                Next
            End If
        Else
            pnlSidebar.Width += 20
            If pnlSidebar.Width >= sidebarExpandedWidth Then
                pnlSidebar.Width = sidebarExpandedWidth
                isSidebarExpanded = True
                tmrSidebar.Stop()
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
        Dim colorActive As Color = Color.FromArgb(70, 90, 120)
        Dim colorDefault As Color = Color.FromArgb(35, 40, 60)

        ' Reset all buttons
        btnDashboard.BackColor = colorDefault
        btnProfile.BackColor = colorDefault
        btnPropertyRequest.BackColor = colorDefault
        btnViewInventory.BackColor = colorDefault
        btnMyRequest.BackColor = colorDefault
        btnBorrowedItem.BackColor = colorDefault
        btnReports.BackColor = colorDefault

        ' Highlight active button
        activeBtn.BackColor = colorActive
    End Sub

    Private Sub ToggleSidebar()
        If Not tmrSidebar.Enabled Then
            tmrSidebar.Start()
        End If
    End Sub

    Private Sub pnlSidebar_Click(sender As Object, e As EventArgs) Handles pnlSidebar.Click
        ToggleSidebar()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If Not isSidebarExpanded Then ToggleSidebar()
        SetActiveButton(btnDashboard)
        pnlFormLoader.Visible = False
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        If Not isSidebarExpanded Then ToggleSidebar()
        SetActiveButton(btnProfile)
        loadFormIntoPanel(New frmProfile())
    End Sub

    Private Sub btnPropertyRequest_Click(sender As Object, e As EventArgs) Handles btnPropertyRequest.Click
        If Not isSidebarExpanded Then ToggleSidebar()
        SetActiveButton(btnPropertyRequest)
        loadFormIntoPanel(New frmPropertyRequest())
    End Sub

    Private Sub btnViewInventory_Click(sender As Object, e As EventArgs) Handles btnViewInventory.Click
        If Not isSidebarExpanded Then ToggleSidebar()
    End Sub

    Private Sub btnBorrowedItem_Click(sender As Object, e As EventArgs) Handles btnBorrowedItem.Click
        If Not isSidebarExpanded Then ToggleSidebar()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        If Not isSidebarExpanded Then ToggleSidebar()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If Not isSidebarExpanded Then ToggleSidebar()
    End Sub

    Private Sub comboMonth_Click(sender As Object, e As EventArgs) Handles comboMonth.Click
        ' Optional click logic
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Optional logic for ComboBox1
    End Sub

    Private Sub pnlFormLoader_Paint(sender As Object, e As PaintEventArgs) Handles pnlFormLoader.Paint
        ' Optional paint logic
    End Sub

    ' Load a form inside pnlFormLoader
    Private Sub loadFormIntoPanel(ByVal formToLoad As Form)
        If pnlFormLoader.Controls.Count > 0 Then pnlFormLoader.Controls.Clear()
        formToLoad.TopLevel = False
        formToLoad.Dock = DockStyle.Fill
        pnlFormLoader.Controls.Add(formToLoad)
        pnlFormLoader.Tag = formToLoad
        formToLoad.Show()
        pnlFormLoader.Visible = True
        pnlFormLoader.BringToFront()
    End Sub

End Class
