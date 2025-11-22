Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Partial Class SADashboard
    Private tmrSidebar As Object

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnDashboard)
        ' No form load here to avoid recursively loading SADashboard into itself
    End Sub

    Private Sub SADashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load supply statistics when dashboard loads
        LoadSupplyStats()
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

    ' Added method to display supply statistics on dashboard
    Private Sub LoadSupplyStats()
        Try
            ' Get all supplies from database
            Dim suppliesTable As DataTable = DatabaseConnection.GetAllSupplies()

            ' Display in dashboard (you'll need to add labels/controls for this)
            ' Example: lblTotalSupplies.Text = suppliesTable.Rows.Count.ToString()
            System.Diagnostics.Debug.WriteLine("[v0] Dashboard - Total Supplies: " & suppliesTable.Rows.Count)

            ' You can also calculate low stock items
            Dim lowStockCount As Integer = 0
            For Each row As DataRow In suppliesTable.Rows
                If row("Status").ToString() = "Low Stock" Then
                    lowStockCount += 1
                End If
            Next

            System.Diagnostics.Debug.WriteLine("[v0] Dashboard - Low Stock Items: " & lowStockCount)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadSupplyStats Error: " & ex.Message)
        End Try
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

    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs) Handles btnUserManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnUserManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SAUserManagement())
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

    Private Sub btnMaintenance_Click(sender As Object, e As EventArgs) Handles btnMaintenanceManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnMaintenanceManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New SAMaintenace())
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

    Private Sub SAChart_TotalSupplies_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RoundedPanel9_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub RoundedPanel11_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel11.Paint

    End Sub


    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim logout As New logout()
        logout.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub

    Private Sub pnlSidebar_Paint(sender As Object, e As PaintEventArgs) Handles pnlSidebar.Paint

    End Sub

    Private Sub lblPropertyCustodian_Click(sender As Object, e As EventArgs) Handles lblPropertyCustodian.Click

    End Sub

    Private Sub lblScheduleMaintenance_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblPropertyConditionStatus_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblInventoryStatusOverview_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblPendingRequest_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblTotalSupplies_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblTotalProperty_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblRequestTrends_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblRecentPRopertyRequests_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblSystemAlerts_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub RoundedPanel9_Paint_1(sender As Object, e As PaintEventArgs) Handles RoundedPanel9.Paint

    End Sub

    Private Sub SAChart_RecentPropertyRequests_Click(sender As Object, e As EventArgs) Handles SAChart_RecentPropertyRequests.Click

    End Sub

    Private Sub RoundedPanel5_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel5.Paint

    End Sub

    Private Sub SAChart_ScheduleMaintenance_Click(sender As Object, e As EventArgs) Handles SAChart_ScheduleMaintenance.Click

    End Sub

    Private Sub RoundedPanel4_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel4.Paint

    End Sub

    Private Sub SAChart_PendingRequest_Click(sender As Object, e As EventArgs) Handles SAChart_PendingRequest.Click

    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint

    End Sub

    Private Sub SAChart_TotalSupplies_Click_1(sender As Object, e As EventArgs) Handles SAChart_TotalSupplies.Click

    End Sub

    Private Sub RoundedPanel2_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel2.Paint

    End Sub

    Private Sub SAChart_TotalProperty_Click(sender As Object, e As EventArgs) Handles SAChart_TotalProperty.Click

    End Sub

    Private Sub RoundedPanel8_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel8.Paint

    End Sub

    Private Sub SAChart_RequestTrends_Click(sender As Object, e As EventArgs) Handles SAChart_RequestTrends.Click

    End Sub

    Private Sub RoundedPanel6_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel6.Paint

    End Sub

    Private Sub SAChart_InventoryStatusOverview_Click(sender As Object, e As EventArgs) Handles SAChart_InventoryStatusOverview.Click

    End Sub

    Private Sub RoundedPanel10_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel10.Paint

    End Sub

    Private Sub SAChart_PropertyConditionStatus_Click(sender As Object, e As EventArgs) Handles SAChart_PropertyConditionStatus.Click

    End Sub

    Private Sub SAChart_SystemAlerts_Click(sender As Object, e As EventArgs) Handles SAChart_SystemAlerts.Click

    End Sub

    Private Sub RoundedPanel1_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel1.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub txtboxSearch_TextChanged(sender As Object, e As EventArgs) Handles txtboxSearch.TextChanged

    End Sub

    Private Sub comboFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFilter.SelectedIndexChanged

    End Sub

    Private Sub btnAddProperty_Click(sender As Object, e As EventArgs) Handles btnAddProperty.Click

    End Sub

    Private Sub btnAddSupply_Click(sender As Object, e As EventArgs) Handles btnAddSupply.Click

    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click

    End Sub

    Private Sub btnGenerateReports_Click(sender As Object, e As EventArgs) Handles btnGenerateReports.Click

    End Sub

    Private Sub icStaff_Click(sender As Object, e As EventArgs) Handles icStaff.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub lblSuperAdmin_Click(sender As Object, e As EventArgs) Handles lblSuperAdmin.Click

    End Sub
End Class
