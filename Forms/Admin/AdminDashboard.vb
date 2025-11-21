Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic
Imports StaCruzPropertyCustodianSystem.Resources.Controls


Public Class AdminDashboard
    ' Currently loaded UserControl
    Private currentUC As UserControl = Nothing
    Private _isDashboardLoading As Boolean

    ' ----------------------
    ' Form Load
    ' ----------------------
    Private Async Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make profile picture circular
        MakeProfileCircular()
        ConfigureQuickAccessButtons()
        Await LoadDashboardAsync()
    End Sub

    Private Sub MakeProfileCircular()
        If admin_picProfile.Width > 0 AndAlso admin_picProfile.Height > 0 Then
            Dim gp As New GraphicsPath()
            gp.AddEllipse(0, 0, admin_picProfile.Width - 1, admin_picProfile.Height - 1)
            admin_picProfile.Region = New Region(gp)
        End If
    End Sub

    ' ----------------------
    ' Load UserControl into Main Panel
    ' ----------------------
    Public Sub LoadUserControl(uc As UserControl)
        Try
            ' Clear previous controls
            admin_PanelMain.Controls.Clear()
            currentUC = uc

            ' Add new UserControl
            admin_PanelMain.Controls.Add(uc)
            uc.Dock = DockStyle.Fill
            uc.BringToFront()
            uc.Focus()

            ' Debug info (optional)
            Debug.WriteLine("Loaded UC: " & uc.Name)
            Debug.WriteLine("Panel Size: " & admin_PanelMain.ClientSize.ToString())
            Debug.WriteLine("UC Size: " & uc.Size.ToString())

        Catch ex As Exception
            MessageBox.Show("Error loading UserControl: " & ex.Message)
        End Try
    End Sub

    Private Sub ConfigureQuickAccessButtons()
        admin_btn_hello.Text = "Property"
        admin_btn_updateinventory.Text = "Supplies"
        admin_btn_generatereport.Text = "Reports"
        admin_btn_viewallprop.Text = "Maintenance"

        admin_panel_PendingRequests.Cursor = Cursors.Hand
        Label1.Cursor = Cursors.Hand
        Label5.Cursor = Cursors.Hand
    End Sub

    Private Async Function LoadDashboardAsync() As Task
        If _isDashboardLoading Then Return
        _isDashboardLoading = True
        Cursor = Cursors.WaitCursor

        Try
            Dim summaryTask = Task.Run(Function() DatabaseConnection.GetAdminDashboardSummary())
            Dim propertyCategoryTask = Task.Run(Function() DatabaseConnection.GetPropertyCountsByCategory())
            Dim supplyBreakdownTask = Task.Run(Function() DatabaseConnection.GetSupplyInventoryBreakdown())
            Dim requestStatusTask = Task.Run(Function() DatabaseConnection.GetRequestStatusCounts())
            Dim supplyStatusTask = Task.Run(Function() DatabaseConnection.GetSupplyStatusCounts())
            Dim propertyConditionTask = Task.Run(Function() DatabaseConnection.GetPropertyConditionCounts())
            Dim maintenanceStatusTask = Task.Run(Function() DatabaseConnection.GetMaintenanceStatusCounts())
            Dim requestTrendTask = Task.Run(Function() DatabaseConnection.GetBorrowingTrendData(6))
            Dim departmentUsageTask = Task.Run(Function() DatabaseConnection.GetDepartmentInventoryDistribution())

            Await Task.WhenAll(summaryTask, propertyCategoryTask, supplyBreakdownTask, requestStatusTask,
                               supplyStatusTask, propertyConditionTask, maintenanceStatusTask,
                               requestTrendTask, departmentUsageTask)

            Dim summary = summaryTask.Result
            UpdateSummaryCards(summary)

            BindChartData(SAChart_TotalProperty, propertyCategoryTask.Result, SeriesChartType.StackedBar)
            BindChartData(SAChart_TotalSupplies, supplyBreakdownTask.Result, SeriesChartType.StackedBar100)
            BindChartData(SAChart_PendingRequest, requestStatusTask.Result, SeriesChartType.Pie)
            BindChartData(SAChart_InventoryStatusOverview, supplyStatusTask.Result, SeriesChartType.Doughnut)
            BindChartData(SAChart_PropertyConditionStatus, propertyConditionTask.Result, SeriesChartType.StackedBar)
            BindChartData(SAChart_ScheduleMaintenance, maintenanceStatusTask.Result, SeriesChartType.Pie)
            BindChartData(SAChart_RequestTrends, requestTrendTask.Result, SeriesChartType.Line, showValueLabels:=False)
            BindChartData(SAChart_RecentPropertyRequests, departmentUsageTask.Result, SeriesChartType.Column)
            BindChartData(SAChart_SystemAlerts, BuildAlertsData(summary), SeriesChartType.Pie)
        Catch ex As Exception
            Debug.WriteLine("Dashboard load error: " & ex.Message)
            MessageBox.Show("Unable to load dashboard data. Please try again or check the database connection.",
                            "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Cursor = Cursors.Default
            _isDashboardLoading = False
        End Try
    End Function

    Private Sub UpdateSummaryCards(summary As Dictionary(Of String, Integer))
        If summary Is Nothing Then Return

        Label4.Text = SafeSummaryRead(summary, "total_properties").ToString("N0")
        Label5.Text = SafeSummaryRead(summary, "pending_requests").ToString("N0")
        Label6.Text = $"{SafeSummaryRead(summary, "borrowed_items"):N0} / {SafeSummaryRead(summary, "returned_items"):N0}"
        Label2.Text = SafeSummaryRead(summary, "needs_repair").ToString("N0")

        ApplyChartTitle(SAChart_TotalSupplies, $"Total Supplies: {SafeSummaryRead(summary, "total_supplies"):N0}")
        ApplyChartTitle(SAChart_PendingRequest,
                        $"Pending/Approved/Declined: {SafeSummaryRead(summary, "pending_requests"):N0}/" &
                        $"{SafeSummaryRead(summary, "approved_requests"):N0}/{SafeSummaryRead(summary, "declined_requests"):N0}")
        ApplyChartTitle(SAChart_ScheduleMaintenance,
                        $"Open Maintenance Alerts: {SafeSummaryRead(summary, "maintenance_alerts"):N0}")
        ApplyChartTitle(SAChart_SystemAlerts,
                        $"Warranty Alerts: {SafeSummaryRead(summary, "warranty_alerts"):N0}")
    End Sub

    Private Sub ApplyChartTitle(chart As Chart, titleText As String)
        If chart Is Nothing Then Return
        chart.Titles.Clear()
        chart.Titles.Add(titleText)
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

    Private Function BuildAlertsData(summary As Dictionary(Of String, Integer)) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("label", GetType(String))
        dt.Columns.Add("total", GetType(Integer))

        dt.Rows.Add("Maintenance Alerts", SafeSummaryRead(summary, "maintenance_alerts"))
        dt.Rows.Add("Warranty Alerts", SafeSummaryRead(summary, "warranty_alerts"))

        Return dt
    End Function

    Private Shared Function SafeSummaryRead(summary As Dictionary(Of String, Integer), key As String) As Integer
        If summary Is Nothing Then Return 0
        If summary.ContainsKey(key) Then
            Return summary(key)
        End If
        Return 0
    End Function

    ' ----------------------
    ' Handle Form Resize
    ' ----------------------
    Private Sub Dashboard_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' DockStyle.Fill ensures UC resizes automatically
        currentUC?.Refresh()
    End Sub

    ' ----------------------
    ' Button Click Handlers
    ' ----------------------

    ' User Management
    Private Sub admin_btn_UserManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_UserManagement.Click
        LoadUserControl(New UC_UserManagement())
    End Sub

    ' Property Request Management
    Private Sub admin_btn_PropertyRequestManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_PropertyRequestManagement.Click
        admin_btn_PropertyRequestManagement.Text = "Property Request" & vbCrLf & "Management"
        LoadUserControl(New UC_PropertyRequestManagement())
    End Sub

    ' Dashboard Button (optional example)
    Private Async Sub admin_btn_dashboard_Click(sender As Object, e As EventArgs) Handles admin_btn_dashboard.Click
        Await LoadDashboardAsync()
    End Sub

    ' Properties Button
    Private Sub admin_btn_properties_Click(sender As Object, e As EventArgs)
        ' Load the property management UserControl which shows supplies
        LoadUserControl(New UC_PropertyManagement())
    End Sub

    ' Pending Requests Button
    Private Sub admin_btn_PendingRequests_Click(sender As Object, e As EventArgs)
        ' Load your pending requests UserControl
        ' LoadUserControl(New UC_PendingRequests())
    End Sub

    ' Search TextBox
    Private Sub admin_txtbox_search_TextChanged(sender As Object, e As EventArgs) Handles admin_txtbox_search.TextChanged
        ' Optional: Add search filtering logic here
    End Sub

    ' Profile Picture Click
    Private Sub admin_picProfile_Click(sender As Object, e As EventArgs) Handles admin_picProfile.Click
        ' Optional: Open profile settings
    End Sub

    ' Profile Title Click
    Private Sub admin_TitleProfile_Click(sender As Object, e As EventArgs) Handles admin_TitleProfile.Click
        ' Optional: Open profile details
    End Sub

    ' Dashboard Label Click
    Private Sub admin_label_Dashboard_Click(sender As Object, e As EventArgs) Handles admin_label_Dashboard.Click
        ' Optional: navigate to dashboard
    End Sub

    ' Quick Access Label Click
    Private Sub admin_label_quickaccess_Click(sender As Object, e As EventArgs)
        ' Optional: open quick access panel
    End Sub

    Private Sub admin_btn_hello_Click(sender As Object, e As EventArgs)
        admin_btn_PropertyManagement.PerformClick()
    End Sub

    Private Sub admin_btn_updateinventory_Click(sender As Object, e As EventArgs)
        admin_btn_SuppliesManagement.PerformClick()
    End Sub

    Private Sub admin_btn_generatereport_Click(sender As Object, e As EventArgs)
        admin_btn_reports.PerformClick()
    End Sub

    Private Sub admin_btn_viewallprop_Click(sender As Object, e As EventArgs)
        admin_btn_MaintenanceManagement.PerformClick()
    End Sub

    Private Sub PendingRequestsCard_Click(sender As Object, e As EventArgs) Handles admin_panel_PendingRequests.Click, Label1.Click, Label5.Click
        admin_btn_PropertyRequestManagement.PerformClick()
    End Sub

    Private Sub admin_btn_PropertyManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_PropertyManagement.Click
        LoadUserControl(New UC_PropertyManagement())
    End Sub

    Private Sub admin_btn_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_DepartmentManagement.Click
        LoadUserControl(New UC_DepartmentManagement())
    End Sub

    ' Added new button handler for Supplies Management if separate
    Private Sub admin_btn_SuppliesManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_SuppliesManagement.Click
        ' Load property management which shows all supplies
        LoadUserControl(New UC_PropertyManagement1())
    End Sub

    Private Sub admin_PanelMain_Paint(sender As Object, e As PaintEventArgs) Handles admin_PanelMain.Paint

    End Sub

    Private Sub admin_btn_MaintenanceManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_MaintenanceManagement.Click
        LoadUserControl(New UC_MaintenanceManagement())
    End Sub

    Private Sub admin_btn_reports_Click(sender As Object, e As EventArgs) Handles admin_btn_reports.Click
        LoadUserControl(New UC_Reports())
    End Sub

    Private Sub admin_PanelSidebar_Paint(sender As Object, e As PaintEventArgs) Handles admin_PanelSidebar.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RoundedPanel12_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TableLayoutPanel4_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub SAChart_RequestTrends_Click(sender As Object, e As EventArgs) Handles SAChart_RequestTrends.Click

    End Sub

    Private Sub SAChart_SystemAlerts_Click(sender As Object, e As EventArgs) Handles SAChart_SystemAlerts.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    ' Other controls (PictureBoxes, Panels, etc.) can be added similarly

End Class
