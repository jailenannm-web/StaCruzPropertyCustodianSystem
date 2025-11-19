Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim lblSystemAlerts As System.Windows.Forms.Label
        Dim lblRequestTrends As System.Windows.Forms.Label
        Dim lblScheduleMaintenance As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim lblPendingRequest As System.Windows.Forms.Label
        Dim lblPropertyConditionStatus As System.Windows.Forms.Label
        Dim lblInventoryStatusOverview As System.Windows.Forms.Label
        Dim lblTotalSupplies As System.Windows.Forms.Label
        Dim lblTotalProperty As System.Windows.Forms.Label
        Dim ChartArea10 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend10 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea11 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend11 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea12 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend12 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series12 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea13 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend13 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series13 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea16 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend16 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series16 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea14 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend14 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series14 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea15 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend15 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series15 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea17 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend17 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series17 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea18 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend18 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series18 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.admin_PanelSidebar = New System.Windows.Forms.Panel()
        Me.admin_btn_Logout = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_reports = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_MaintenanceManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_PropertyRequestManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_DepartmentManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_SuppliesManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_PropertyManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_UserManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_dashboard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_TitleProfile = New System.Windows.Forms.Label()
        Me.admin_picProfile = New System.Windows.Forms.PictureBox()
        Me.admin_PanelMain = New System.Windows.Forms.Panel()
        Me.RoundedPanel14 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel11 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_SystemAlerts = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel12 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_RequestTrends = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel8 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_ScheduleMaintenance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel13 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_RecentPropertyRequests = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel7 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_PendingRequest = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel9 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_PropertyConditionStatus = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel10 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_InventoryStatusOverview = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_TotalSupplies = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_TotalProperty = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.admin_panel_borrowed = New System.Windows.Forms.Label()
        Me.admin_panel_PendingRequests = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.admin_label_Dashboard = New System.Windows.Forms.Label()
        Me.admin_panel2 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.admin_panel1 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.admin_label_quickaccess = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.admin_btn_hello = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_viewallprop = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_updateinventory = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_generatereport = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_panelcontainer = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.admin_txtbox_search = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.admin_panel_PendingRequests = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.admin_panel_borrowed = New System.Windows.Forms.Label()
        Me.admin_PanelSidebar.SuspendLayout()
        CType(Me.admin_picProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.admin_PanelMain.SuspendLayout()
        Me.RoundedPanel14.SuspendLayout()
        Me.RoundedPanel11.SuspendLayout()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel12.SuspendLayout()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel8.SuspendLayout()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel13.SuspendLayout()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel7.SuspendLayout()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel9.SuspendLayout()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel10.SuspendLayout()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel6.SuspendLayout()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel5.SuspendLayout()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.admin_panel_PendingRequests.SuspendLayout()
        Me.admin_panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSystemAlerts
        '
        lblSystemAlerts.AutoSize = True
        lblSystemAlerts.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSystemAlerts.ForeColor = System.Drawing.Color.White
        lblSystemAlerts.Location = New System.Drawing.Point(20, 19)
        lblSystemAlerts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblSystemAlerts.Name = "lblSystemAlerts"
        lblSystemAlerts.Size = New System.Drawing.Size(136, 24)
        lblSystemAlerts.TabIndex = 56
        lblSystemAlerts.Text = "System Alerts"
        '
        'lblRequestTrends
        '
        lblRequestTrends.AutoSize = True
        lblRequestTrends.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRequestTrends.ForeColor = System.Drawing.Color.White
        lblRequestTrends.Location = New System.Drawing.Point(20, 19)
        lblRequestTrends.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblRequestTrends.Name = "lblRequestTrends"
        lblRequestTrends.Size = New System.Drawing.Size(159, 24)
        lblRequestTrends.TabIndex = 55
        lblRequestTrends.Text = "Request Trends"
        '
        'lblScheduleMaintenance
        '
        lblScheduleMaintenance.AutoSize = True
        lblScheduleMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblScheduleMaintenance.ForeColor = System.Drawing.Color.White
        lblScheduleMaintenance.Location = New System.Drawing.Point(20, 19)
        lblScheduleMaintenance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblScheduleMaintenance.Name = "lblScheduleMaintenance"
        lblScheduleMaintenance.Size = New System.Drawing.Size(225, 24)
        lblScheduleMaintenance.TabIndex = 48
        lblScheduleMaintenance.Text = "Schedule Maintenance"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.ForeColor = System.Drawing.Color.White
        Label10.Location = New System.Drawing.Point(16, 19)
        Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(250, 24)
        Label10.TabIndex = 48
        Label10.Text = "Inventory Status Overview"
        '
        'lblPendingRequest
        '
        lblPendingRequest.AutoSize = True
        lblPendingRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPendingRequest.ForeColor = System.Drawing.Color.White
        lblPendingRequest.Location = New System.Drawing.Point(9, 19)
        lblPendingRequest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPendingRequest.Name = "lblPendingRequest"
        lblPendingRequest.Size = New System.Drawing.Size(171, 24)
        lblPendingRequest.TabIndex = 51
        lblPendingRequest.Text = "Pending Request"
        '
        'lblPropertyConditionStatus
        '
        lblPropertyConditionStatus.AutoSize = True
        lblPropertyConditionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPropertyConditionStatus.ForeColor = System.Drawing.Color.White
        lblPropertyConditionStatus.Location = New System.Drawing.Point(20, 19)
        lblPropertyConditionStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPropertyConditionStatus.Name = "lblPropertyConditionStatus"
        lblPropertyConditionStatus.Size = New System.Drawing.Size(245, 24)
        lblPropertyConditionStatus.TabIndex = 48
        lblPropertyConditionStatus.Text = "Property Condition Status"
        '
        'lblInventoryStatusOverview
        '
        lblInventoryStatusOverview.AutoSize = True
        lblInventoryStatusOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblInventoryStatusOverview.ForeColor = System.Drawing.Color.White
        lblInventoryStatusOverview.Location = New System.Drawing.Point(16, 19)
        lblInventoryStatusOverview.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblInventoryStatusOverview.Name = "lblInventoryStatusOverview"
        lblInventoryStatusOverview.Size = New System.Drawing.Size(250, 24)
        lblInventoryStatusOverview.TabIndex = 48
        lblInventoryStatusOverview.Text = "Inventory Status Overview"
        '
        'lblTotalSupplies
        '
        lblTotalSupplies.AutoSize = True
        lblTotalSupplies.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalSupplies.ForeColor = System.Drawing.Color.White
        lblTotalSupplies.Location = New System.Drawing.Point(16, 15)
        lblTotalSupplies.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalSupplies.Name = "lblTotalSupplies"
        lblTotalSupplies.Size = New System.Drawing.Size(143, 24)
        lblTotalSupplies.TabIndex = 50
        lblTotalSupplies.Text = "Total Supplies"
        '
        'lblTotalProperty
        '
        lblTotalProperty.AutoSize = True
        lblTotalProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalProperty.ForeColor = System.Drawing.Color.White
        lblTotalProperty.Location = New System.Drawing.Point(23, 15)
        lblTotalProperty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalProperty.Name = "lblTotalProperty"
        lblTotalProperty.Size = New System.Drawing.Size(140, 24)
        lblTotalProperty.TabIndex = 46
        lblTotalProperty.Text = "Total Property"
        '
        'admin_PanelSidebar
        '
        Me.admin_PanelSidebar.AutoScroll = True
        Me.admin_PanelSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_Logout)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_reports)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_MaintenanceManagement)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_PropertyRequestManagement)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_DepartmentManagement)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_SuppliesManagement)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_PropertyManagement)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_UserManagement)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_dashboard)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_TitleProfile)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_picProfile)
        Me.admin_PanelSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.admin_PanelSidebar.Location = New System.Drawing.Point(0, 0)
        Me.admin_PanelSidebar.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_PanelSidebar.Name = "admin_PanelSidebar"
        Me.admin_PanelSidebar.Size = New System.Drawing.Size(340, 1055)
        Me.admin_PanelSidebar.TabIndex = 1
        '
        'admin_btn_Logout
        '
        Me.admin_btn_Logout.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_Logout.CornerRadius = 15
        Me.admin_btn_Logout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_Logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_Logout.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_Logout.ForeColor = System.Drawing.Color.White
        Me.admin_btn_Logout.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_logout
        Me.admin_btn_Logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_Logout.Location = New System.Drawing.Point(24, 931)
        Me.admin_btn_Logout.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_Logout.Name = "admin_btn_Logout"
        Me.admin_btn_Logout.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_Logout.TabIndex = 10
        Me.admin_btn_Logout.Text = "Logout"
        Me.admin_btn_Logout.UseVisualStyleBackColor = False
        '
        'admin_btn_reports
        '
        Me.admin_btn_reports.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_reports.CornerRadius = 15
        Me.admin_btn_reports.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_reports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_reports.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_reports.ForeColor = System.Drawing.Color.White
        Me.admin_btn_reports.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_reports
        Me.admin_btn_reports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_reports.Location = New System.Drawing.Point(24, 795)
        Me.admin_btn_reports.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_reports.Name = "admin_btn_reports"
        Me.admin_btn_reports.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_reports.TabIndex = 8
        Me.admin_btn_reports.Text = "Reports"
        Me.admin_btn_reports.UseVisualStyleBackColor = False
        '
        'admin_btn_MaintenanceManagement
        '
        Me.admin_btn_MaintenanceManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_MaintenanceManagement.CornerRadius = 15
        Me.admin_btn_MaintenanceManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_MaintenanceManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_MaintenanceManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_MaintenanceManagement.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_MaintenanceManagement.ForeColor = System.Drawing.Color.White
        Me.admin_btn_MaintenanceManagement.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_maintenance
        Me.admin_btn_MaintenanceManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_MaintenanceManagement.Location = New System.Drawing.Point(24, 716)
        Me.admin_btn_MaintenanceManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_MaintenanceManagement.Name = "admin_btn_MaintenanceManagement"
        Me.admin_btn_MaintenanceManagement.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_MaintenanceManagement.TabIndex = 7
        Me.admin_btn_MaintenanceManagement.Text = "Maintenance Management"
        Me.admin_btn_MaintenanceManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.admin_btn_MaintenanceManagement.UseVisualStyleBackColor = False
        '
        'admin_btn_PropertyRequestManagement
        '
        Me.admin_btn_PropertyRequestManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_PropertyRequestManagement.CornerRadius = 15
        Me.admin_btn_PropertyRequestManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_PropertyRequestManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_PropertyRequestManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_PropertyRequestManagement.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_PropertyRequestManagement.ForeColor = System.Drawing.Color.White
        Me.admin_btn_PropertyRequestManagement.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_propertyrequest
        Me.admin_btn_PropertyRequestManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_PropertyRequestManagement.Location = New System.Drawing.Point(24, 624)
        Me.admin_btn_PropertyRequestManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_PropertyRequestManagement.Name = "admin_btn_PropertyRequestManagement"
        Me.admin_btn_PropertyRequestManagement.Size = New System.Drawing.Size(272, 72)
        Me.admin_btn_PropertyRequestManagement.TabIndex = 6
        Me.admin_btn_PropertyRequestManagement.Text = "Property Request Management"
        Me.admin_btn_PropertyRequestManagement.UseVisualStyleBackColor = False
        '
        'admin_btn_DepartmentManagement
        '
        Me.admin_btn_DepartmentManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_DepartmentManagement.CornerRadius = 15
        Me.admin_btn_DepartmentManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_DepartmentManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_DepartmentManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_DepartmentManagement.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_DepartmentManagement.ForeColor = System.Drawing.Color.White
        Me.admin_btn_DepartmentManagement.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_propertymanagement
        Me.admin_btn_DepartmentManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_DepartmentManagement.Location = New System.Drawing.Point(24, 546)
        Me.admin_btn_DepartmentManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_DepartmentManagement.Name = "admin_btn_DepartmentManagement"
        Me.admin_btn_DepartmentManagement.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_DepartmentManagement.TabIndex = 5
        Me.admin_btn_DepartmentManagement.Text = "Department Management"
        Me.admin_btn_DepartmentManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.admin_btn_DepartmentManagement.UseVisualStyleBackColor = False
        '
        'admin_btn_SuppliesManagement
        '
        Me.admin_btn_SuppliesManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_SuppliesManagement.CornerRadius = 15
        Me.admin_btn_SuppliesManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_SuppliesManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_SuppliesManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_SuppliesManagement.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_SuppliesManagement.ForeColor = System.Drawing.Color.White
        Me.admin_btn_SuppliesManagement.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_suppliesmanagement
        Me.admin_btn_SuppliesManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_SuppliesManagement.Location = New System.Drawing.Point(24, 468)
        Me.admin_btn_SuppliesManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_SuppliesManagement.Name = "admin_btn_SuppliesManagement"
        Me.admin_btn_SuppliesManagement.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_SuppliesManagement.TabIndex = 4
        Me.admin_btn_SuppliesManagement.Text = "Supplies Management"
        Me.admin_btn_SuppliesManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.admin_btn_SuppliesManagement.UseVisualStyleBackColor = False
        '
        'admin_btn_PropertyManagement
        '
        Me.admin_btn_PropertyManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_PropertyManagement.CornerRadius = 15
        Me.admin_btn_PropertyManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_PropertyManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_PropertyManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_PropertyManagement.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_PropertyManagement.ForeColor = System.Drawing.Color.White
        Me.admin_btn_PropertyManagement.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_propertymanagement
        Me.admin_btn_PropertyManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_PropertyManagement.Location = New System.Drawing.Point(24, 391)
        Me.admin_btn_PropertyManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_PropertyManagement.Name = "admin_btn_PropertyManagement"
        Me.admin_btn_PropertyManagement.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_PropertyManagement.TabIndex = 3
        Me.admin_btn_PropertyManagement.Text = "Property Management"
        Me.admin_btn_PropertyManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.admin_btn_PropertyManagement.UseVisualStyleBackColor = False
        '
        'admin_btn_UserManagement
        '
        Me.admin_btn_UserManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_UserManagement.CornerRadius = 15
        Me.admin_btn_UserManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_UserManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_UserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_UserManagement.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_UserManagement.ForeColor = System.Drawing.Color.White
        Me.admin_btn_UserManagement.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_usermanagement
        Me.admin_btn_UserManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_UserManagement.Location = New System.Drawing.Point(24, 316)
        Me.admin_btn_UserManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_UserManagement.Name = "admin_btn_UserManagement"
        Me.admin_btn_UserManagement.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_UserManagement.TabIndex = 2
        Me.admin_btn_UserManagement.Text = "User Management"
        Me.admin_btn_UserManagement.UseVisualStyleBackColor = False
        '
        'admin_btn_dashboard
        '
        Me.admin_btn_dashboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_dashboard.CornerRadius = 15
        Me.admin_btn_dashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_dashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_dashboard.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_dashboard.ForeColor = System.Drawing.Color.White
        Me.admin_btn_dashboard.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_dashboard
        Me.admin_btn_dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_dashboard.Location = New System.Drawing.Point(24, 238)
        Me.admin_btn_dashboard.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_btn_dashboard.Name = "admin_btn_dashboard"
        Me.admin_btn_dashboard.Size = New System.Drawing.Size(272, 58)
        Me.admin_btn_dashboard.TabIndex = 0
        Me.admin_btn_dashboard.Text = "Dashboard"
        Me.admin_btn_dashboard.UseVisualStyleBackColor = False
        '
        'admin_TitleProfile
        '
        Me.admin_TitleProfile.AutoSize = True
        Me.admin_TitleProfile.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_TitleProfile.ForeColor = System.Drawing.Color.White
        Me.admin_TitleProfile.Location = New System.Drawing.Point(113, 187)
        Me.admin_TitleProfile.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.admin_TitleProfile.Name = "admin_TitleProfile"
        Me.admin_TitleProfile.Size = New System.Drawing.Size(84, 36)
        Me.admin_TitleProfile.TabIndex = 1
        Me.admin_TitleProfile.Text = "Admin"
        Me.admin_TitleProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'admin_picProfile
        '
        Me.admin_picProfile.BackColor = System.Drawing.Color.Transparent
        Me.admin_picProfile.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.profile
        Me.admin_picProfile.Location = New System.Drawing.Point(100, 55)
        Me.admin_picProfile.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_picProfile.Name = "admin_picProfile"
        Me.admin_picProfile.Size = New System.Drawing.Size(120, 111)
        Me.admin_picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.admin_picProfile.TabIndex = 0
        Me.admin_picProfile.TabStop = False
        '
        'admin_PanelMain
        '
        Me.admin_PanelMain.AutoScroll = True
        Me.admin_PanelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.admin_PanelMain.Controls.Add(Me.RoundedPanel14)
        Me.admin_PanelMain.Controls.Add(Me.RoundedPanel4)
        Me.admin_PanelMain.Controls.Add(Me.admin_label_Dashboard)
        Me.admin_PanelMain.Controls.Add(Me.admin_panel1)
        Me.admin_PanelMain.Controls.Add(Me.PictureBox1)
        Me.admin_PanelMain.Controls.Add(Me.admin_txtbox_search)
        Me.admin_PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_PanelMain.Location = New System.Drawing.Point(340, 0)
        Me.admin_PanelMain.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_PanelMain.Name = "admin_PanelMain"
        Me.admin_PanelMain.Size = New System.Drawing.Size(1084, 1055)
        Me.admin_PanelMain.TabIndex = 3
        '
        'RoundedPanel14
        '
        Me.RoundedPanel14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel11)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel12)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel8)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel13)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel7)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel9)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel10)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel6)
        Me.RoundedPanel14.Controls.Add(Me.RoundedPanel5)
        Me.RoundedPanel14.CornerRadius = 20
        Me.RoundedPanel14.ForeColor = System.Drawing.Color.Transparent
        Me.RoundedPanel14.Location = New System.Drawing.Point(26, 429)
        Me.RoundedPanel14.Name = "RoundedPanel14"
        Me.RoundedPanel14.Size = New System.Drawing.Size(1046, 614)
        Me.RoundedPanel14.TabIndex = 57
        '
        'RoundedPanel11
        '
        Me.RoundedPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel11.Controls.Add(lblSystemAlerts)
        Me.RoundedPanel11.Controls.Add(Me.SAChart_SystemAlerts)
        Me.RoundedPanel11.CornerRadius = 20
        Me.RoundedPanel11.Location = New System.Drawing.Point(697, 417)
        Me.RoundedPanel11.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel11.Name = "RoundedPanel11"
        Me.RoundedPanel11.Size = New System.Drawing.Size(332, 186)
        Me.RoundedPanel11.TabIndex = 65
        '
        'SAChart_SystemAlerts
        '
        Me.SAChart_SystemAlerts.BackColor = System.Drawing.Color.Transparent
        ChartArea10.Name = "ChartArea1"
        Me.SAChart_SystemAlerts.ChartAreas.Add(ChartArea10)
        Legend10.Name = "Legend1"
        Me.SAChart_SystemAlerts.Legends.Add(Legend10)
        Me.SAChart_SystemAlerts.Location = New System.Drawing.Point(13, 46)
        Me.SAChart_SystemAlerts.Name = "SAChart_SystemAlerts"
        Series10.ChartArea = "ChartArea1"
        Series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series10.Legend = "Legend1"
        Series10.Name = "Series1"
        Me.SAChart_SystemAlerts.Series.Add(Series10)
        Me.SAChart_SystemAlerts.Size = New System.Drawing.Size(311, 148)
        Me.SAChart_SystemAlerts.TabIndex = 55
        Me.SAChart_SystemAlerts.Text = "Chart9"
        '
        'RoundedPanel12
        '
        Me.RoundedPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel12.Controls.Add(lblRequestTrends)
        Me.RoundedPanel12.Controls.Add(Me.SAChart_RequestTrends)
        Me.RoundedPanel12.CornerRadius = 20
        Me.RoundedPanel12.Location = New System.Drawing.Point(357, 417)
        Me.RoundedPanel12.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel12.Name = "RoundedPanel12"
        Me.RoundedPanel12.Size = New System.Drawing.Size(332, 186)
        Me.RoundedPanel12.TabIndex = 64
        '
        'SAChart_RequestTrends
        '
        Me.SAChart_RequestTrends.BackColor = System.Drawing.Color.Transparent
        ChartArea11.Name = "ChartArea1"
        Me.SAChart_RequestTrends.ChartAreas.Add(ChartArea11)
        Legend11.Name = "Legend1"
        Me.SAChart_RequestTrends.Legends.Add(Legend11)
        Me.SAChart_RequestTrends.Location = New System.Drawing.Point(21, 53)
        Me.SAChart_RequestTrends.Name = "SAChart_RequestTrends"
        Series11.ChartArea = "ChartArea1"
        Series11.Legend = "Legend1"
        Series11.Name = "Series1"
        Me.SAChart_RequestTrends.Series.Add(Series11)
        Me.SAChart_RequestTrends.Size = New System.Drawing.Size(283, 141)
        Me.SAChart_RequestTrends.TabIndex = 54
        Me.SAChart_RequestTrends.Text = "Chart8"
        '
        'RoundedPanel8
        '
        Me.RoundedPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel8.Controls.Add(Me.SAChart_ScheduleMaintenance)
        Me.RoundedPanel8.Controls.Add(lblScheduleMaintenance)
        Me.RoundedPanel8.CornerRadius = 20
        Me.RoundedPanel8.Location = New System.Drawing.Point(697, 208)
        Me.RoundedPanel8.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel8.Name = "RoundedPanel8"
        Me.RoundedPanel8.Size = New System.Drawing.Size(332, 201)
        Me.RoundedPanel8.TabIndex = 62
        '
        'SAChart_ScheduleMaintenance
        '
        Me.SAChart_ScheduleMaintenance.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_ScheduleMaintenance.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea12.Name = "ChartArea1"
        Me.SAChart_ScheduleMaintenance.ChartAreas.Add(ChartArea12)
        Legend12.Name = "Legend1"
        Me.SAChart_ScheduleMaintenance.Legends.Add(Legend12)
        Me.SAChart_ScheduleMaintenance.Location = New System.Drawing.Point(13, 53)
        Me.SAChart_ScheduleMaintenance.Name = "SAChart_ScheduleMaintenance"
        Series12.ChartArea = "ChartArea1"
        Series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series12.Legend = "Legend1"
        Series12.Name = "Series1"
        Me.SAChart_ScheduleMaintenance.Series.Add(Series12)
        Me.SAChart_ScheduleMaintenance.Size = New System.Drawing.Size(311, 134)
        Me.SAChart_ScheduleMaintenance.TabIndex = 52
        Me.SAChart_ScheduleMaintenance.Text = "Chart6"
        '
        'RoundedPanel13
        '
        Me.RoundedPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel13.Controls.Add(Me.SAChart_RecentPropertyRequests)
        Me.RoundedPanel13.Controls.Add(Label10)
        Me.RoundedPanel13.CornerRadius = 20
        Me.RoundedPanel13.Location = New System.Drawing.Point(17, 417)
        Me.RoundedPanel13.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel13.Name = "RoundedPanel13"
        Me.RoundedPanel13.Size = New System.Drawing.Size(332, 186)
        Me.RoundedPanel13.TabIndex = 63
        '
        'SAChart_RecentPropertyRequests
        '
        Me.SAChart_RecentPropertyRequests.BackColor = System.Drawing.Color.Transparent
        ChartArea13.Name = "ChartArea1"
        Me.SAChart_RecentPropertyRequests.ChartAreas.Add(ChartArea13)
        Legend13.Name = "Legend1"
        Me.SAChart_RecentPropertyRequests.Legends.Add(Legend13)
        Me.SAChart_RecentPropertyRequests.Location = New System.Drawing.Point(10, 46)
        Me.SAChart_RecentPropertyRequests.Name = "SAChart_RecentPropertyRequests"
        Series13.ChartArea = "ChartArea1"
        Series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series13.Legend = "Legend1"
        Series13.Name = "Series1"
        Me.SAChart_RecentPropertyRequests.Series.Add(Series13)
        Me.SAChart_RecentPropertyRequests.Size = New System.Drawing.Size(305, 151)
        Me.SAChart_RecentPropertyRequests.TabIndex = 53
        Me.SAChart_RecentPropertyRequests.Text = "Chart7"
        '
        'RoundedPanel7
        '
        Me.RoundedPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel7.Controls.Add(Me.SAChart_PendingRequest)
        Me.RoundedPanel7.Controls.Add(lblPendingRequest)
        Me.RoundedPanel7.CornerRadius = 20
        Me.RoundedPanel7.Location = New System.Drawing.Point(697, 12)
        Me.RoundedPanel7.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel7.Name = "RoundedPanel7"
        Me.RoundedPanel7.Size = New System.Drawing.Size(332, 185)
        Me.RoundedPanel7.TabIndex = 59
        '
        'SAChart_PendingRequest
        '
        ChartArea16.Name = "ChartArea1"
        Me.SAChart_PendingRequest.ChartAreas.Add(ChartArea16)
        Legend16.Name = "Legend1"
        Me.SAChart_PendingRequest.Legends.Add(Legend16)
        Me.SAChart_PendingRequest.Location = New System.Drawing.Point(24, 46)
        Me.SAChart_PendingRequest.Name = "SAChart_PendingRequest"
        Series16.BackImageTransparentColor = System.Drawing.Color.Transparent
        Series16.ChartArea = "ChartArea1"
        Series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series16.LabelForeColor = System.Drawing.Color.BlanchedAlmond
        Series16.Legend = "Legend1"
        Series16.Name = "Series1"
        Me.SAChart_PendingRequest.Series.Add(Series16)
        Me.SAChart_PendingRequest.Size = New System.Drawing.Size(285, 121)
        Me.SAChart_PendingRequest.TabIndex = 52
        Me.SAChart_PendingRequest.Text = "Chart3"
        '
        'RoundedPanel9
        '
        Me.RoundedPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel9.Controls.Add(Me.SAChart_PropertyConditionStatus)
        Me.RoundedPanel9.Controls.Add(lblPropertyConditionStatus)
        Me.RoundedPanel9.CornerRadius = 20
        Me.RoundedPanel9.Location = New System.Drawing.Point(357, 208)
        Me.RoundedPanel9.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel9.Name = "RoundedPanel9"
        Me.RoundedPanel9.Size = New System.Drawing.Size(332, 201)
        Me.RoundedPanel9.TabIndex = 61
        '
        'SAChart_PropertyConditionStatus
        '
        Me.SAChart_PropertyConditionStatus.BackColor = System.Drawing.Color.Transparent
        ChartArea14.Name = "ChartArea1"
        Me.SAChart_PropertyConditionStatus.ChartAreas.Add(ChartArea14)
        Legend14.Name = "Legend1"
        Me.SAChart_PropertyConditionStatus.Legends.Add(Legend14)
        Me.SAChart_PropertyConditionStatus.Location = New System.Drawing.Point(7, 60)
        Me.SAChart_PropertyConditionStatus.Name = "SAChart_PropertyConditionStatus"
        Series14.ChartArea = "ChartArea1"
        Series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar
        Series14.Legend = "Legend1"
        Series14.Name = "Series1"
        Me.SAChart_PropertyConditionStatus.Series.Add(Series14)
        Me.SAChart_PropertyConditionStatus.Size = New System.Drawing.Size(303, 127)
        Me.SAChart_PropertyConditionStatus.TabIndex = 51
        Me.SAChart_PropertyConditionStatus.Text = "Chart5"
        '
        'RoundedPanel10
        '
        Me.RoundedPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel10.Controls.Add(Me.SAChart_InventoryStatusOverview)
        Me.RoundedPanel10.Controls.Add(lblInventoryStatusOverview)
        Me.RoundedPanel10.CornerRadius = 20
        Me.RoundedPanel10.Location = New System.Drawing.Point(17, 208)
        Me.RoundedPanel10.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel10.Name = "RoundedPanel10"
        Me.RoundedPanel10.Size = New System.Drawing.Size(332, 201)
        Me.RoundedPanel10.TabIndex = 60
        '
        'SAChart_InventoryStatusOverview
        '
        Me.SAChart_InventoryStatusOverview.BackColor = System.Drawing.Color.Transparent
        ChartArea15.Name = "ChartArea1"
        Me.SAChart_InventoryStatusOverview.ChartAreas.Add(ChartArea15)
        Legend15.Name = "Legend1"
        Me.SAChart_InventoryStatusOverview.Legends.Add(Legend15)
        Me.SAChart_InventoryStatusOverview.Location = New System.Drawing.Point(20, 46)
        Me.SAChart_InventoryStatusOverview.Name = "SAChart_InventoryStatusOverview"
        Series15.ChartArea = "ChartArea1"
        Series15.Legend = "Legend1"
        Series15.Name = "Series1"
        Me.SAChart_InventoryStatusOverview.Series.Add(Series15)
        Me.SAChart_InventoryStatusOverview.Size = New System.Drawing.Size(291, 141)
        Me.SAChart_InventoryStatusOverview.TabIndex = 50
        Me.SAChart_InventoryStatusOverview.Text = "Chart4"
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel6.Controls.Add(Me.SAChart_TotalSupplies)
        Me.RoundedPanel6.Controls.Add(lblTotalSupplies)
        Me.RoundedPanel6.CornerRadius = 20
        Me.RoundedPanel6.Location = New System.Drawing.Point(357, 12)
        Me.RoundedPanel6.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(332, 185)
        Me.RoundedPanel6.TabIndex = 58
        '
        'SAChart_TotalSupplies
        '
        Me.SAChart_TotalSupplies.BackColor = System.Drawing.Color.Transparent
        ChartArea17.Name = "ChartArea1"
        Me.SAChart_TotalSupplies.ChartAreas.Add(ChartArea17)
        Legend17.Name = "Legend1"
        Me.SAChart_TotalSupplies.Legends.Add(Legend17)
        Me.SAChart_TotalSupplies.Location = New System.Drawing.Point(21, 42)
        Me.SAChart_TotalSupplies.Name = "SAChart_TotalSupplies"
        Series17.ChartArea = "ChartArea1"
        Series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100
        Series17.Legend = "Legend1"
        Series17.Name = "Series1"
        Me.SAChart_TotalSupplies.Series.Add(Series17)
        Me.SAChart_TotalSupplies.Size = New System.Drawing.Size(289, 143)
        Me.SAChart_TotalSupplies.TabIndex = 51
        Me.SAChart_TotalSupplies.Text = "Chart2"
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel5.Controls.Add(Me.SAChart_TotalProperty)
        Me.RoundedPanel5.Controls.Add(lblTotalProperty)
        Me.RoundedPanel5.CornerRadius = 20
        Me.RoundedPanel5.Location = New System.Drawing.Point(17, 12)
        Me.RoundedPanel5.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(332, 185)
        Me.RoundedPanel5.TabIndex = 57
        '
        'SAChart_TotalProperty
        '
        Me.SAChart_TotalProperty.BackColor = System.Drawing.Color.Transparent
        ChartArea18.Name = "ChartArea1"
        Me.SAChart_TotalProperty.ChartAreas.Add(ChartArea18)
        Legend18.Name = "Legend1"
        Me.SAChart_TotalProperty.Legends.Add(Legend18)
        Me.SAChart_TotalProperty.Location = New System.Drawing.Point(10, 42)
        Me.SAChart_TotalProperty.Name = "SAChart_TotalProperty"
        Series18.ChartArea = "ChartArea1"
        Series18.Legend = "Legend1"
        Series18.Name = "Series1"
        Me.SAChart_TotalProperty.Series.Add(Series18)
        Me.SAChart_TotalProperty.Size = New System.Drawing.Size(301, 156)
        Me.SAChart_TotalProperty.TabIndex = 48
        Me.SAChart_TotalProperty.Text = "Chart1"
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel4.Controls.Add(Me.TableLayoutPanel3)
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(37, 142)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(1019, 141)
        Me.RoundedPanel4.TabIndex = 22
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.RoundedPanel2, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RoundedPanel3, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RoundedPanel1, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.admin_panel_PendingRequests, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1014, 132)
        Me.TableLayoutPanel3.TabIndex = 21
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.RoundedPanel2.Controls.Add(Me.Label2)
        Me.RoundedPanel2.Controls.Add(Me.Label7)
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(762, 3)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(249, 126)
        Me.RoundedPanel2.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(101, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 58)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 30)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Needs Repair"
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.RoundedPanel3.Controls.Add(Me.Label4)
        Me.RoundedPanel3.Controls.Add(Me.Label3)
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(3, 3)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(247, 126)
        Me.RoundedPanel3.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(98, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 58)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 30)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Total Properties"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.Label6)
        Me.RoundedPanel1.Controls.Add(Me.admin_panel_borrowed)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(509, 3)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(247, 126)
        Me.RoundedPanel1.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(103, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 58)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "1"
        '
        'admin_panel_borrowed
        '
        Me.admin_panel_borrowed.AutoSize = True
        Me.admin_panel_borrowed.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.admin_panel_borrowed.ForeColor = System.Drawing.Color.White
        Me.admin_panel_borrowed.Location = New System.Drawing.Point(12, 12)
        Me.admin_panel_borrowed.Name = "admin_panel_borrowed"
        Me.admin_panel_borrowed.Size = New System.Drawing.Size(183, 30)
        Me.admin_panel_borrowed.TabIndex = 0
        Me.admin_panel_borrowed.Text = "Borrowed/Returned"
        '
        'admin_panel_PendingRequests
        '
        Me.admin_panel_PendingRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panel_PendingRequests.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_panel_PendingRequests.Controls.Add(Me.Label5)
        Me.admin_panel_PendingRequests.Controls.Add(Me.Label1)
        Me.admin_panel_PendingRequests.CornerRadius = 20
        Me.admin_panel_PendingRequests.Location = New System.Drawing.Point(256, 3)
        Me.admin_panel_PendingRequests.Name = "admin_panel_PendingRequests"
        Me.admin_panel_PendingRequests.Size = New System.Drawing.Size(247, 126)
        Me.admin_panel_PendingRequests.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(105, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 58)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pending Requests"
        '
        'admin_label_Dashboard
        '
        Me.admin_label_Dashboard.AutoSize = True
        Me.admin_label_Dashboard.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_Dashboard.Location = New System.Drawing.Point(37, 28)
        Me.admin_label_Dashboard.Name = "admin_label_Dashboard"
        Me.admin_label_Dashboard.Size = New System.Drawing.Size(558, 58)
        Me.admin_label_Dashboard.TabIndex = 20
        Me.admin_label_Dashboard.Text = "Property Custodian Dashboard"
        '
        'admin_panel1
        '
        Me.admin_panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_panel1.Controls.Add(Me.admin_label_quickaccess)
        Me.admin_panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.admin_panel1.CornerRadius = 10
        Me.admin_panel1.Location = New System.Drawing.Point(40, 299)
        Me.admin_panel1.Name = "admin_panel1"
        Me.admin_panel1.Size = New System.Drawing.Size(1012, 115)
        Me.admin_panel1.TabIndex = 18
        '
        'admin_label_quickaccess
        '
        Me.admin_label_quickaccess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_label_quickaccess.AutoSize = True
        Me.admin_label_quickaccess.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_quickaccess.ForeColor = System.Drawing.Color.White
        Me.admin_label_quickaccess.Location = New System.Drawing.Point(13, 11)
        Me.admin_label_quickaccess.Name = "admin_label_quickaccess"
        Me.admin_label_quickaccess.Size = New System.Drawing.Size(175, 40)
        Me.admin_label_quickaccess.TabIndex = 16
        Me.admin_label_quickaccess.Text = "Quick Access"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.admin_btn_hello, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.admin_btn_viewallprop, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.admin_btn_updateinventory, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.admin_btn_generatereport, 2, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 52)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(976, 53)
        Me.TableLayoutPanel2.TabIndex = 15
        '
        'admin_btn_hello
        '
        Me.admin_btn_hello.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_hello.CornerRadius = 15
        Me.admin_btn_hello.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_hello.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_hello.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_hello.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_hello.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_hello.ForeColor = System.Drawing.Color.White
        Me.admin_btn_hello.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_hello.Location = New System.Drawing.Point(10, 10)
        Me.admin_btn_hello.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_hello.Name = "admin_btn_hello"
        Me.admin_btn_hello.Size = New System.Drawing.Size(224, 33)
        Me.admin_btn_hello.TabIndex = 11
        Me.admin_btn_hello.Text = "None"
        Me.admin_btn_hello.UseVisualStyleBackColor = False
        '
        'admin_btn_viewallprop
        '
        Me.admin_btn_viewallprop.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_viewallprop.CornerRadius = 15
        Me.admin_btn_viewallprop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_viewallprop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_viewallprop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_viewallprop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_viewallprop.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_viewallprop.ForeColor = System.Drawing.Color.White
        Me.admin_btn_viewallprop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_viewallprop.Location = New System.Drawing.Point(742, 10)
        Me.admin_btn_viewallprop.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_viewallprop.Name = "admin_btn_viewallprop"
        Me.admin_btn_viewallprop.Size = New System.Drawing.Size(224, 33)
        Me.admin_btn_viewallprop.TabIndex = 14
        Me.admin_btn_viewallprop.Text = "View All Properties"
        Me.admin_btn_viewallprop.UseVisualStyleBackColor = False
        '
        'admin_btn_updateinventory
        '
        Me.admin_btn_updateinventory.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_updateinventory.CornerRadius = 15
        Me.admin_btn_updateinventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_updateinventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_updateinventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_updateinventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_updateinventory.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_updateinventory.ForeColor = System.Drawing.Color.White
        Me.admin_btn_updateinventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_updateinventory.Location = New System.Drawing.Point(254, 10)
        Me.admin_btn_updateinventory.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_updateinventory.Name = "admin_btn_updateinventory"
        Me.admin_btn_updateinventory.Size = New System.Drawing.Size(224, 33)
        Me.admin_btn_updateinventory.TabIndex = 12
        Me.admin_btn_updateinventory.Text = "Update Inventory"
        Me.admin_btn_updateinventory.UseVisualStyleBackColor = False
        '
        'admin_btn_generatereport
        '
        Me.admin_btn_generatereport.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_generatereport.CornerRadius = 15
        Me.admin_btn_generatereport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_generatereport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_generatereport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_generatereport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_generatereport.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_generatereport.ForeColor = System.Drawing.Color.White
        Me.admin_btn_generatereport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_generatereport.Location = New System.Drawing.Point(498, 10)
        Me.admin_btn_generatereport.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_generatereport.Name = "admin_btn_generatereport"
        Me.admin_btn_generatereport.Size = New System.Drawing.Size(224, 33)
        Me.admin_btn_generatereport.TabIndex = 13
        Me.admin_btn_generatereport.Text = "Generate Report"
        Me.admin_btn_generatereport.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(37, 96)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'admin_txtbox_search
        '
        Me.admin_txtbox_search.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_txtbox_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_txtbox_search.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_txtbox_search.ForeColor = System.Drawing.Color.White
        Me.admin_txtbox_search.Location = New System.Drawing.Point(83, 96)
        Me.admin_txtbox_search.Name = "admin_txtbox_search"
        Me.admin_txtbox_search.Size = New System.Drawing.Size(600, 33)
        Me.admin_txtbox_search.TabIndex = 0
        Me.admin_txtbox_search.Text = "Search"
        Me.admin_txtbox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1424, 1055)
        Me.Controls.Add(Me.admin_PanelMain)
        Me.Controls.Add(Me.admin_PanelSidebar)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AdminDashboard"
        Me.Text = "Admin Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.admin_PanelSidebar.ResumeLayout(False)
        Me.admin_PanelSidebar.PerformLayout()
        CType(Me.admin_picProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.admin_PanelMain.ResumeLayout(False)
        Me.admin_PanelMain.PerformLayout()
        Me.RoundedPanel14.ResumeLayout(False)
        Me.RoundedPanel11.ResumeLayout(False)
        Me.RoundedPanel11.PerformLayout()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel12.ResumeLayout(False)
        Me.RoundedPanel12.PerformLayout()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel8.ResumeLayout(False)
        Me.RoundedPanel8.PerformLayout()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel13.ResumeLayout(False)
        Me.RoundedPanel13.PerformLayout()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel7.ResumeLayout(False)
        Me.RoundedPanel7.PerformLayout()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel9.ResumeLayout(False)
        Me.RoundedPanel9.PerformLayout()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel10.ResumeLayout(False)
        Me.RoundedPanel10.PerformLayout()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel6.ResumeLayout(False)
        Me.RoundedPanel6.PerformLayout()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel5.ResumeLayout(False)
        Me.RoundedPanel5.PerformLayout()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.admin_panel_PendingRequests.ResumeLayout(False)
        Me.admin_panel_PendingRequests.PerformLayout()
        Me.admin_panel1.ResumeLayout(False)
        Me.admin_panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents admin_PanelSidebar As Panel
    Friend WithEvents admin_PanelMain As Panel
    Friend WithEvents admin_picProfile As PictureBox
    Friend WithEvents admin_TitleProfile As Label
    Friend WithEvents admin_btn_dashboard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_UserManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_PropertyManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_SuppliesManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_DepartmentManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_PropertyRequestManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_MaintenanceManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_reports As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_Logout As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_txtbox_search As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents admin_label_Dashboard As Label
    Friend WithEvents admin_panel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents admin_label_quickaccess As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents admin_btn_hello As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_viewallprop As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_updateinventory As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_generatereport As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_label_quickaccess As Label
    Friend WithEvents admin_panel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents admin_panel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents admin_label_Dashboard As Label
    Friend WithEvents admin_panel_PendingRequests As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents admin_panel_borrowed As Label
End Class
