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

    ' New: load a Form into the dashboard panel (same behavior as other dashboards)
    Public Sub LoadFormIntoPanel(ByVal formToLoad As Form)
        Try
            If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
                Return
            End If

            If admin_PanelMain.Controls.Count > 0 Then
                admin_PanelMain.Controls.Clear()
            End If

            formToLoad.TopLevel = False
            formToLoad.Dock = DockStyle.Fill

            admin_PanelMain.Controls.Add(formToLoad)
            admin_PanelMain.Tag = formToLoad
            formToLoad.Show()

            admin_PanelMain.Visible = True
            admin_PanelMain.BringToFront()
        Catch ex As Exception
            MessageBox.Show("Error loading form into panel: " & ex.Message)
        End Try
    End Sub

    Private Async Function LoadDashboardAsync() As Task
        If _isDashboardLoading Then Return
        _isDashboardLoading = True
        Cursor = Cursors.WaitCursor

        Try
            Dim summaryTask As Task(Of Dictionary(Of String, Integer)) = Task.Run(Function() DatabaseConnection.GetAdminDashboardSummary())
            Dim propertyCategoryTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetPropertyCountsByCategory())
            Dim supplyBreakdownTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetSupplyInventoryBreakdown())
            Dim requestStatusTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetRequestStatusCounts())
            Dim supplyStatusTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetSupplyStatusCounts())
            Dim propertyConditionTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetPropertyConditionCounts())
            Dim maintenanceStatusTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetMaintenanceStatusCounts())
            Dim requestTrendTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetBorrowingTrendData(6))
            Dim departmentUsageTask As Task(Of DataTable) = Task.Run(Function() DatabaseConnection.GetDepartmentInventoryDistribution())

            Await Task.WhenAll(summaryTask, propertyCategoryTask, supplyBreakdownTask, requestStatusTask,
                               supplyStatusTask, propertyConditionTask, maintenanceStatusTask,
                               requestTrendTask, departmentUsageTask)

            Dim summary = Await summaryTask
            UpdateSummaryCards(summary)

            BindChartData(SAChart_TotalProperty, Await propertyCategoryTask, SeriesChartType.StackedBar)
            BindChartData(SAChart_TotalSupplies, Await supplyBreakdownTask, SeriesChartType.StackedBar100)
            BindChartData(SAChart_PendingRequest, Await requestStatusTask, SeriesChartType.Pie)
            BindChartData(SAChart_InventoryStatusOverview, Await supplyStatusTask, SeriesChartType.Doughnut)
            BindChartData(SAChart_PropertyConditionStatus, Await propertyConditionTask, SeriesChartType.StackedBar)
            BindChartData(SAChart_ScheduleMaintenance, Await maintenanceStatusTask, SeriesChartType.Pie)
            BindChartData(SAChart_RequestTrends, Await requestTrendTask, SeriesChartType.Line, showValueLabels:=False)
            BindChartData(SAChart_RecentPropertyRequests, Await departmentUsageTask, SeriesChartType.Column)
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
        admin_btn_PropertyRequestManagement.Text = "Property Request" & Environment.NewLine & "Management"
        LoadUserControl(New UC_PropertyRequestManagement())
    End Sub

    ' Dashboard Button (optional example)
    Private Async Sub admin_btn_dashboard_Click(sender As Object, e As EventArgs) Handles admin_btn_dashboard.Click
        ' Clear any loaded user controls to show dashboard
        ' admin_panel_container.Controls.Clear()
        
        ' Make sure dashboard stat panels are visible
        ' If admin_panel_total IsNot Nothing Then admin_panel_total.Visible = True
        ' If admin_panel_property IsNot Nothing Then admin_panel_property.Visible = True
        ' If admin_panel_supply IsNot Nothing Then admin_panel_supply.Visible = True
        ' If admin_panel_maintenance IsNot Nothing Then admin_panel_maintenance.Visible = True
        
        ' Reload dashboard statistics
        Await LoadDashboardAsync()
        
        System.Diagnostics.Debug.WriteLine("[v0] AdminDashboard - Dashboard button clicked, showing dashboard")
    End Sub

    ' Properties Button
    Private Sub admin_btn_properties_Click(sender As Object, e As EventArgs)
        ' Load the property management UserControl which shows supplies
        LoadUserControl(New UC_SupplyManagement())
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
        LoadUserControl(New UC_PropertyManagement1())
    End Sub

    Private Sub admin_btn_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_DepartmentManagement.Click
        LoadUserControl(New UC_DepartmentManagement())
    End Sub

    ' Added new button handler for Supplies Management if separate
    Private Sub admin_btn_SuppliesManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_SuppliesManagement.Click
        ' Load supply management which shows all supplies
        LoadUserControl(New UC_SupplyManagement())
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

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub TableLayoutPanel4_Paint_1(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel4.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub admin_panelcontainer_Paint(sender As Object, e As PaintEventArgs) Handles admin_panelcontainer.Paint

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub RoundedPanel11_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel11.Paint

    End Sub

    Private Sub lblSystemAlerts_Click(sender As Object, e As EventArgs) Handles lblSystemAlerts.Click

    End Sub

    Private Sub RoundedPanel13_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel13.Paint

    End Sub

    Private Sub SAChart_RecentPropertyRequests_Click(sender As Object, e As EventArgs) Handles SAChart_RecentPropertyRequests.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub RoundedPanel7_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel7.Paint

    End Sub

    Private Sub SAChart_PendingRequest_Click(sender As Object, e As EventArgs) Handles SAChart_PendingRequest.Click

    End Sub

    Private Sub lblPendingRequest_Click(sender As Object, e As EventArgs) Handles lblPendingRequest.Click

    End Sub

    Private Sub RoundedPanel6_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel6.Paint

    End Sub

    Private Sub SAChart_TotalSupplies_Click(sender As Object, e As EventArgs) Handles SAChart_TotalSupplies.Click

    End Sub

    Private Sub lblTotalSupplies_Click(sender As Object, e As EventArgs) Handles lblTotalSupplies.Click

    End Sub

    Private Sub RoundedPanel12_Paint_1(sender As Object, e As PaintEventArgs) Handles RoundedPanel12.Paint

    End Sub

    Private Sub lblRequestTrends_Click(sender As Object, e As EventArgs) Handles lblRequestTrends.Click

    End Sub

    Private Sub RoundedPanel8_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel8.Paint

    End Sub

    Private Sub SAChart_ScheduleMaintenance_Click(sender As Object, e As EventArgs) Handles SAChart_ScheduleMaintenance.Click

    End Sub

    Private Sub lblScheduleMaintenance_Click(sender As Object, e As EventArgs) Handles lblScheduleMaintenance.Click

    End Sub

    Private Sub RoundedPanel9_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel9.Paint

    End Sub

    Private Sub SAChart_PropertyConditionStatus_Click(sender As Object, e As EventArgs) Handles SAChart_PropertyConditionStatus.Click

    End Sub

    Private Sub lblPropertyConditionStatus_Click(sender As Object, e As EventArgs) Handles lblPropertyConditionStatus.Click

    End Sub

    Private Sub RoundedPanel10_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel10.Paint

    End Sub

    Private Sub SAChart_InventoryStatusOverview_Click(sender As Object, e As EventArgs) Handles SAChart_InventoryStatusOverview.Click

    End Sub

    Private Sub lblInventoryStatusOverview_Click(sender As Object, e As EventArgs) Handles lblInventoryStatusOverview.Click

    End Sub

    Private Sub RoundedPanel5_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel5.Paint

    End Sub

    Private Sub SAChart_TotalProperty_Click(sender As Object, e As EventArgs) Handles SAChart_TotalProperty.Click

    End Sub

    Private Sub lblTotalProperty_Click(sender As Object, e As EventArgs) Handles lblTotalProperty.Click

    End Sub

    Private Sub RoundedPanel2_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel2.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint

    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub RoundedPanel1_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel1.Paint

    End Sub

    Private Sub admin_panel_borrowed_Click(sender As Object, e As EventArgs) Handles admin_panel_borrowed.Click

    End Sub

    Private Sub admin_panel_PendingRequests_Paint(sender As Object, e As PaintEventArgs) Handles admin_panel_PendingRequests.Paint

    End Sub

    Private Sub admin_btn_Logout_Click(sender As Object, e As EventArgs) Handles admin_btn_Logout.Click

    End Sub

    Private Sub admin_panel2_Paint(sender As Object, e As PaintEventArgs) Handles admin_panel2.Paint

    End Sub

    Private Sub btn_MaintenanceRequest_Click(sender As Object, e As EventArgs) Handles admin_btn_MaintenanceRequest.Click
        LoadUserControl(New UC_MaintenanceRequestManagement())
    End Sub

    Private Sub admin_btn_suppliesRequestManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_suppliesRequestManagement.Click
        LoadUserControl(New UC_SupplyRequestManagement())
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        LoadUserControl(New audit())
    End Sub
End Class
