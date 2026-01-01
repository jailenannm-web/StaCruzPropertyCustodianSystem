Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Partial Class SADashboard
    Inherits System.Windows.Forms.Form
    
    Private tmrSidebar As Object
    Private currentUC As UserControl = Nothing
    Private _isDashboardLoading As Boolean

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ' Clear any loaded user controls to show dashboard
        If pnlFormLoader IsNot Nothing Then
            pnlFormLoader.Controls.Clear()
            ' Make sure the TableLayoutPanel1 (dashboard content) is visible
            If TableLayoutPanel1 IsNot Nothing Then
                TableLayoutPanel1.Visible = True
                pnlFormLoader.Controls.Add(TableLayoutPanel1)
                TableLayoutPanel1.BringToFront()
            End If
        End If
        currentUC = Nothing

        ' --- This code changes the active button color ---
        SetActiveButton(btnDashboard)
        ' Reload charts when dashboard button is clicked
        LoadDashboardChartsAsync()
        ' Reload supply stats
        LoadSupplyStats()
        
        System.Diagnostics.Debug.WriteLine("[v0] SADashboard - Dashboard button clicked, showing dashboard")
    End Sub

    Private Sub SADashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load supply statistics when dashboard loads
        LoadSupplyStats()
        ' Load charts asynchronously
        LoadDashboardChartsAsync()
    End Sub

    Public Sub LoadUserControl(uc As UserControl)
        Try
            ' Store TableLayoutPanel1 reference before clearing (if it exists)
            Dim dashboardContent As Control = Nothing
            For Each ctrl As Control In pnlFormLoader.Controls
                If ctrl.Name = "TableLayoutPanel1" Then
                    dashboardContent = ctrl
                    Exit For
                End If
            Next
            
            ' Clear previous controls
            pnlFormLoader.Controls.Clear()
            currentUC = uc

            ' Add new UserControl
            pnlFormLoader.Controls.Add(uc)
            uc.Dock = DockStyle.Fill
            uc.BringToFront()
            uc.Focus()

            ' Debug info (optional)
            Debug.WriteLine("Loaded UC: " & uc.Name)
            Debug.WriteLine("Panel Size: " & pnlFormLoader.ClientSize.ToString())
            Debug.WriteLine("UC Size: " & uc.Size.ToString())

        Catch ex As Exception
            MessageBox.Show("Error loading UserControl: " & ex.Message)
        End Try
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

        ' Add any other buttons you have...

        ' --- 2. Set the ONE active button to the new color ---
        activeBtn.BackColor = colorActive
    End Sub

    ' Added method to display supply statistics on dashboard
    Private Sub LoadSupplyStats()
        Try
            ' Get all supplies from database
            Dim suppliesTable As DataTable = modDB.GetAllSupplies()

            ' Display in dashboard (you'll need to add labels/controls for this)
            ' Example: lblTotalSupplies.Text = suppliesTable.Rows.Count.ToString()
            System.Diagnostics.Debug.WriteLine("[v0] Dashboard - Total Supplies: " & suppliesTable.Rows.Count)

            ' You can also calculate low stock items
            Dim lowStockCount As Integer = 0
            For Each row As DataRow In suppliesTable.Rows
                ' Use stockStatus column (not Status)
                If row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")) Then
                    If row("stockStatus").ToString() = "Low Stock" Then
                        lowStockCount += 1
                    End If
                End If
            Next

            System.Diagnostics.Debug.WriteLine("[v0] Dashboard - Low Stock Items: " & lowStockCount)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadSupplyStats Error: " & ex.Message)
        End Try
    End Sub

    Private Async Sub LoadDashboardChartsAsync()
        If _isDashboardLoading Then Return
        _isDashboardLoading = True
        Cursor = Cursors.WaitCursor

        Try
            Dim propertyCategoryTask As Task(Of DataTable) = Task.Run(Function() modDB.GetPropertyCountsByCategory())
            Dim supplyBreakdownTask As Task(Of DataTable) = Task.Run(Function() modDB.GetSupplyInventoryBreakdown())
            Dim requestStatusTask As Task(Of DataTable) = Task.Run(Function() modDB.GetRequestStatusCounts())
            Dim supplyStatusTask As Task(Of DataTable) = Task.Run(Function() modDB.GetSupplyStatusCounts())
            Dim propertyConditionTask As Task(Of DataTable) = Task.Run(Function() modDB.GetPropertyConditionCounts())
            Dim maintenanceStatusTask As Task(Of DataTable) = Task.Run(Function() modDB.GetMaintenanceStatusCounts())
            Dim requestTrendTask As Task(Of DataTable) = Task.Run(Function() modDB.GetBorrowingTrendData(6))
            Dim departmentUsageTask As Task(Of DataTable) = Task.Run(Function() modDB.GetDepartmentInventoryDistribution())

            Await Task.WhenAll(propertyCategoryTask, supplyBreakdownTask, requestStatusTask,
                               supplyStatusTask, propertyConditionTask, maintenanceStatusTask,
                               requestTrendTask, departmentUsageTask)

            BindChartData(SAChart_TotalProperty, Await propertyCategoryTask, SeriesChartType.StackedBar)
            BindChartData(SAChart_TotalSupplies, Await supplyBreakdownTask, SeriesChartType.StackedBar100)
            BindChartData(SAChart_PendingRequest, Await requestStatusTask, SeriesChartType.Pie)
            BindChartData(SAChart_InventoryStatusOverview, Await supplyStatusTask, SeriesChartType.Doughnut)
            BindChartData(SAChart_PropertyConditionStatus, Await propertyConditionTask, SeriesChartType.StackedBar)
            BindChartData(SAChart_ScheduleMaintenance, Await maintenanceStatusTask, SeriesChartType.Pie)
            BindChartData(SAChart_RequestTrends, Await requestTrendTask, SeriesChartType.Line, showValueLabels:=False)
            BindChartData(SAChart_RecentPropertyRequests, Await departmentUsageTask, SeriesChartType.Column)
        Catch ex As Exception
            Debug.WriteLine("Dashboard chart load error: " & ex.Message)
            ' Don't show error dialog for charts - just log it
        Finally
            Cursor = Cursors.Default
            _isDashboardLoading = False
        End Try
    End Sub

    Private Sub BindChartData(chart As Chart,
                              data As DataTable,
                              chartType As SeriesChartType,
                              Optional showValueLabels As Boolean = True,
                              Optional emptyLabel As String = "No data available")
        If chart Is Nothing Then Return

        If chart.Series.Count = 0 Then
            chart.Series.Add(New Series("Series1"))
        End If

        Dim series = chart.Series(0)
        series.Points.Clear()
        series.ChartType = chartType
        series.IsValueShownAsLabel = showValueLabels
        series.ToolTip = "#VALX: #VALY{N0}"

        Dim hasLegend As Boolean = chart.Legends.Count > 0

        If data Is Nothing OrElse data.Rows.Count = 0 Then
            Dim idx = series.Points.AddY(0)
            Dim point = series.Points(idx)
            point.AxisLabel = emptyLabel
            point.Label = emptyLabel
            If hasLegend Then chart.Legends(0).Enabled = False
            Return
        End If

        For Each row As DataRow In data.Rows
            Dim total As Double
            Double.TryParse(row("total").ToString(), total)
            Dim idx = series.Points.AddXY(row("label").ToString(), total)
            Dim point = series.Points(idx)
            point.ToolTip = $"{row("label")}: {total:N0}"
            If showValueLabels Then
                point.Label = total.ToString("N0")
            Else
                point.Label = ""
            End If
        Next

        If chartType = SeriesChartType.Line Then
            series.MarkerStyle = MarkerStyle.Circle
            series.MarkerSize = 7
            If chart.ChartAreas.Count > 0 Then
                chart.ChartAreas(0).AxisX.Interval = 1
            End If
        End If

        If hasLegend Then
            chart.Legends(0).Enabled = True
        End If
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
        LoadUserControl(New UC_UserManagement())

    End Sub


    Private Sub btnPropertyManagement_Click(sender As Object, e As EventArgs) Handles btnPropertyManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnPropertyManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        LoadUserControl(New UC_PropertyManagement1())
    End Sub


    Private Sub btnDepartmentManagement_Click(sender As Object, e As EventArgs) Handles btnDepartmentManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnDepartmentManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        LoadUserControl(New UC_DepartmentManagement())
    End Sub

    Private Sub btnPropertyRequestManagement_Click(sender As Object, e As EventArgs) Handles btnPropertyRequestManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnPropertyRequestManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        LoadUserControl(New UC_PropertyRequestManagement())
    End Sub

    Private Sub btnMaintenance_Click(sender As Object, e As EventArgs) Handles btnMaintenanceManagement.Click

        ' --- This code changes the active button color ---
        SetActiveButton(btnMaintenanceManagement)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        LoadUserControl(New UC_MaintenanceManagement())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        LoadUserControl(New UC_Reports())
    End Sub



    Private Sub pnlFormLoader_Paint(sender As Object, e As PaintEventArgs) Handles pnlFormLoader.Paint

    End Sub

    Private Sub btnSuppliesManagement_Click(sender As Object, e As EventArgs) Handles btnSuppliesManagement.Click
        SetActiveButton(btnSuppliesManagement)
        LoadUserControl(New UC_SupplyManagement())
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
        Dim logout As New Form1()
        logout.Show() ' Show the register form
        Me.Hide() ' Hide current login form instead of closing it
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

    Private Sub RoundedPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtboxSearch_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub comboFilter_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAddProperty_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAddSupply_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnGenerateReports_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub icStaff_Click(sender As Object, e As EventArgs) Handles icStaff.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub lblSuperAdmin_Click(sender As Object, e As EventArgs) Handles lblSuperAdmin.Click

    End Sub

    Private Sub btn_MaintenanceRequest_Click(sender As Object, e As EventArgs) Handles btn_MaintenanceRequest.Click

    End Sub

    Private Sub admin_btn_suppliesRequestManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_suppliesRequestManagement.Click
        SetActiveButton(admin_btn_suppliesRequestManagement)
        LoadUserControl(New UC_SupplyManagement())
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadUserControl(New audit())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadUserControl(New UC_MaintenanceRequestManagement)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadUserControl(New UC_SupplyRequestManagement)
    End Sub

End Class
