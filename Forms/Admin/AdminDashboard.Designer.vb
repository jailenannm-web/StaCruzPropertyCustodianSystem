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
        Dim Label10 As System.Windows.Forms.Label
        Dim lblPendingRequest As System.Windows.Forms.Label
        Dim lblTotalSupplies As System.Windows.Forms.Label
        Dim lblRequestTrends As System.Windows.Forms.Label
        Dim lblScheduleMaintenance As System.Windows.Forms.Label
        Dim lblPropertyConditionStatus As System.Windows.Forms.Label
        Dim lblInventoryStatusOverview As System.Windows.Forms.Label
        Dim lblTotalProperty As System.Windows.Forms.Label
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea9 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend9 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
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
        Dim ChartArea14 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend14 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series14 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea15 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend15 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series15 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea16 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend16 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series16 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea17 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend17 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series17 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea18 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend18 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series18 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.admin_PanelSidebar = New System.Windows.Forms.Panel()
        Me.admin_TitleProfile = New System.Windows.Forms.Label()
        Me.admin_picProfile = New System.Windows.Forms.PictureBox()
        Me.admin_PanelMain = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.admin_label_Dashboard = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.admin_txtbox_search = New System.Windows.Forms.TextBox()
        Me.admin_panelcontainer = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RoundedPanel11 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_SystemAlerts = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel13 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_RecentPropertyRequests = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel7 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_PendingRequest = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_TotalSupplies = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel12 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_RequestTrends = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel8 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_ScheduleMaintenance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel9 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_PropertyConditionStatus = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel10 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_InventoryStatusOverview = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_TotalProperty = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.admin_panel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.admin_label_quickaccess = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.admin_btn_hello = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_viewallprop = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_updateinventory = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_generatereport = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        Me.admin_btn_Logout = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_reports = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_MaintenanceManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_PropertyRequestManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_DepartmentManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_SuppliesManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_PropertyManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_UserManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_dashboard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_panel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        lblSystemAlerts = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        lblPendingRequest = New System.Windows.Forms.Label()
        lblTotalSupplies = New System.Windows.Forms.Label()
        lblRequestTrends = New System.Windows.Forms.Label()
        lblScheduleMaintenance = New System.Windows.Forms.Label()
        lblPropertyConditionStatus = New System.Windows.Forms.Label()
        lblInventoryStatusOverview = New System.Windows.Forms.Label()
        lblTotalProperty = New System.Windows.Forms.Label()
        Me.admin_PanelSidebar.SuspendLayout()
        CType(Me.admin_picProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.admin_PanelMain.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel11.SuspendLayout()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel13.SuspendLayout()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel7.SuspendLayout()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel6.SuspendLayout()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel12.SuspendLayout()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel8.SuspendLayout()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel9.SuspendLayout()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel10.SuspendLayout()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel5.SuspendLayout()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.admin_panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.admin_panel_PendingRequests.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSystemAlerts
        '
        lblSystemAlerts.AutoSize = True
        lblSystemAlerts.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSystemAlerts.ForeColor = System.Drawing.Color.Black
        lblSystemAlerts.Location = New System.Drawing.Point(20, 19)
        lblSystemAlerts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblSystemAlerts.Name = "lblSystemAlerts"
        lblSystemAlerts.Size = New System.Drawing.Size(133, 30)
        lblSystemAlerts.TabIndex = 56
        lblSystemAlerts.Text = "System Alerts"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.ForeColor = System.Drawing.Color.Black
        Label10.Location = New System.Drawing.Point(16, 19)
        Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(243, 30)
        Label10.TabIndex = 48
        Label10.Text = "Inventory Status Overview"
        '
        'lblPendingRequest
        '
        lblPendingRequest.AutoSize = True
        lblPendingRequest.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPendingRequest.ForeColor = System.Drawing.Color.Black
        lblPendingRequest.Location = New System.Drawing.Point(9, 19)
        lblPendingRequest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPendingRequest.Name = "lblPendingRequest"
        lblPendingRequest.Size = New System.Drawing.Size(159, 30)
        lblPendingRequest.TabIndex = 51
        lblPendingRequest.Text = "Pending Request"
        '
        'lblTotalSupplies
        '
        lblTotalSupplies.AutoSize = True
        lblTotalSupplies.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalSupplies.ForeColor = System.Drawing.Color.Black
        lblTotalSupplies.Location = New System.Drawing.Point(16, 15)
        lblTotalSupplies.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalSupplies.Name = "lblTotalSupplies"
        lblTotalSupplies.Size = New System.Drawing.Size(136, 30)
        lblTotalSupplies.TabIndex = 50
        lblTotalSupplies.Text = "Total Supplies"
        '
        'lblRequestTrends
        '
        lblRequestTrends.AutoSize = True
        lblRequestTrends.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRequestTrends.ForeColor = System.Drawing.Color.Black
        lblRequestTrends.Location = New System.Drawing.Point(20, 19)
        lblRequestTrends.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblRequestTrends.Name = "lblRequestTrends"
        lblRequestTrends.Size = New System.Drawing.Size(146, 30)
        lblRequestTrends.TabIndex = 55
        lblRequestTrends.Text = "Request Trends"
        '
        'lblScheduleMaintenance
        '
        lblScheduleMaintenance.AutoSize = True
        lblScheduleMaintenance.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblScheduleMaintenance.ForeColor = System.Drawing.Color.Black
        lblScheduleMaintenance.Location = New System.Drawing.Point(20, 19)
        lblScheduleMaintenance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblScheduleMaintenance.Name = "lblScheduleMaintenance"
        lblScheduleMaintenance.Size = New System.Drawing.Size(211, 30)
        lblScheduleMaintenance.TabIndex = 48
        lblScheduleMaintenance.Text = "Schedule Maintenance"
        '
        'lblPropertyConditionStatus
        '
        lblPropertyConditionStatus.AutoSize = True
        lblPropertyConditionStatus.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPropertyConditionStatus.ForeColor = System.Drawing.Color.Black
        lblPropertyConditionStatus.Location = New System.Drawing.Point(20, 19)
        lblPropertyConditionStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPropertyConditionStatus.Name = "lblPropertyConditionStatus"
        lblPropertyConditionStatus.Size = New System.Drawing.Size(239, 30)
        lblPropertyConditionStatus.TabIndex = 48
        lblPropertyConditionStatus.Text = "Property Condition Status"
        '
        'lblInventoryStatusOverview
        '
        lblInventoryStatusOverview.AutoSize = True
        lblInventoryStatusOverview.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblInventoryStatusOverview.ForeColor = System.Drawing.Color.Black
        lblInventoryStatusOverview.Location = New System.Drawing.Point(14, 16)
        lblInventoryStatusOverview.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblInventoryStatusOverview.Name = "lblInventoryStatusOverview"
        lblInventoryStatusOverview.Size = New System.Drawing.Size(243, 30)
        lblInventoryStatusOverview.TabIndex = 48
        lblInventoryStatusOverview.Text = "Inventory Status Overview"
        '
        'lblTotalProperty
        '
        lblTotalProperty.AutoSize = True
        lblTotalProperty.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalProperty.ForeColor = System.Drawing.Color.Black
        lblTotalProperty.Location = New System.Drawing.Point(23, 15)
        lblTotalProperty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalProperty.Name = "lblTotalProperty"
        lblTotalProperty.Size = New System.Drawing.Size(138, 30)
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
        Me.admin_PanelMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_PanelMain.AutoScroll = True
        Me.admin_PanelMain.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_PanelMain.Controls.Add(Me.Panel3)
        Me.admin_PanelMain.Controls.Add(Me.Panel2)
        Me.admin_PanelMain.Controls.Add(Me.Panel1)
        Me.admin_PanelMain.Controls.Add(Me.admin_label_Dashboard)
        Me.admin_PanelMain.Controls.Add(Me.PictureBox1)
        Me.admin_PanelMain.Controls.Add(Me.admin_txtbox_search)
        Me.admin_PanelMain.Location = New System.Drawing.Point(340, 0)
        Me.admin_PanelMain.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_PanelMain.Name = "admin_PanelMain"
        Me.admin_PanelMain.Size = New System.Drawing.Size(1084, 1055)
        Me.admin_PanelMain.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel3.Location = New System.Drawing.Point(26, 401)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1046, 642)
        Me.Panel3.TabIndex = 60
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel11, 2, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel13, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel7, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel6, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel12, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel8, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel9, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel10, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.RoundedPanel5, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(11, 10)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1015, 622)
        Me.TableLayoutPanel4.TabIndex = 60
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.admin_panel1)
        Me.Panel2.Location = New System.Drawing.Point(26, 288)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1046, 107)
        Me.Panel2.TabIndex = 59
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Location = New System.Drawing.Point(26, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1046, 140)
        Me.Panel1.TabIndex = 58
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
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(14, 10)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1012, 120)
        Me.TableLayoutPanel3.TabIndex = 21
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
        'admin_panelcontainer
        '
        Me.admin_panelcontainer.Location = New System.Drawing.Point(0, 0)
        Me.admin_panelcontainer.Name = "admin_panelcontainer"
        Me.admin_panelcontainer.Size = New System.Drawing.Size(200, 100)
        Me.admin_panelcontainer.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'RoundedPanel11
        '
        Me.RoundedPanel11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel11.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel11.Controls.Add(Me.SAChart_SystemAlerts)
        Me.RoundedPanel11.Controls.Add(lblSystemAlerts)
        Me.RoundedPanel11.CornerRadius = 5
        Me.RoundedPanel11.Location = New System.Drawing.Point(686, 424)
        Me.RoundedPanel11.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel11.Name = "RoundedPanel11"
        Me.RoundedPanel11.Size = New System.Drawing.Size(319, 188)
        Me.RoundedPanel11.TabIndex = 70
        '
        'SAChart_SystemAlerts
        '
        Me.SAChart_SystemAlerts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_SystemAlerts.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_SystemAlerts.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_SystemAlerts.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea10.Name = "ChartArea1"
        Me.SAChart_SystemAlerts.ChartAreas.Add(ChartArea10)
        Legend10.Name = "Legend1"
        Me.SAChart_SystemAlerts.Legends.Add(Legend10)
        Me.SAChart_SystemAlerts.Location = New System.Drawing.Point(43, 56)
        Me.SAChart_SystemAlerts.Name = "SAChart_SystemAlerts"
        Series10.ChartArea = "ChartArea1"
        Series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series10.Legend = "Legend1"
        Series10.Name = "Series1"
        Me.SAChart_SystemAlerts.Series.Add(Series10)
        Me.SAChart_SystemAlerts.Size = New System.Drawing.Size(249, 116)
        Me.SAChart_SystemAlerts.TabIndex = 57
        Me.SAChart_SystemAlerts.Text = "Chart9"
        '
        'lblSystemAlerts
        '
        lblSystemAlerts.AutoSize = True
        lblSystemAlerts.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSystemAlerts.ForeColor = System.Drawing.Color.Black
        lblSystemAlerts.Location = New System.Drawing.Point(20, 19)
        lblSystemAlerts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblSystemAlerts.Name = "lblSystemAlerts"
        lblSystemAlerts.Size = New System.Drawing.Size(133, 30)
        lblSystemAlerts.TabIndex = 56
        lblSystemAlerts.Text = "System Alerts"
        '
        'RoundedPanel13
        '
        Me.RoundedPanel13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel13.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel13.Controls.Add(Me.SAChart_RecentPropertyRequests)
        Me.RoundedPanel13.Controls.Add(Label10)
        Me.RoundedPanel13.CornerRadius = 5
        Me.RoundedPanel13.Location = New System.Drawing.Point(10, 424)
        Me.RoundedPanel13.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel13.Name = "RoundedPanel13"
        Me.RoundedPanel13.Size = New System.Drawing.Size(318, 188)
        Me.RoundedPanel13.TabIndex = 69
        '
        'SAChart_RecentPropertyRequests
        '
        Me.SAChart_RecentPropertyRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_RecentPropertyRequests.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_RecentPropertyRequests.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_RecentPropertyRequests.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea11.Name = "ChartArea1"
        Me.SAChart_RecentPropertyRequests.ChartAreas.Add(ChartArea11)
        Legend11.Name = "Legend1"
        Me.SAChart_RecentPropertyRequests.Legends.Add(Legend11)
        Me.SAChart_RecentPropertyRequests.Location = New System.Drawing.Point(28, 52)
        Me.SAChart_RecentPropertyRequests.Name = "SAChart_RecentPropertyRequests"
        Series11.ChartArea = "ChartArea1"
        Series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series11.Legend = "Legend1"
        Series11.Name = "Series1"
        Me.SAChart_RecentPropertyRequests.Series.Add(Series11)
        Me.SAChart_RecentPropertyRequests.Size = New System.Drawing.Size(271, 120)
        Me.SAChart_RecentPropertyRequests.TabIndex = 54
        Me.SAChart_RecentPropertyRequests.Text = "Chart7"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.ForeColor = System.Drawing.Color.Black
        Label10.Location = New System.Drawing.Point(16, 19)
        Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(243, 30)
        Label10.TabIndex = 48
        Label10.Text = "Inventory Status Overview"
        '
        'RoundedPanel7
        '
        Me.RoundedPanel7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel7.Controls.Add(Me.SAChart_PendingRequest)
        Me.RoundedPanel7.Controls.Add(lblPendingRequest)
        Me.RoundedPanel7.CornerRadius = 5
        Me.RoundedPanel7.Location = New System.Drawing.Point(686, 10)
        Me.RoundedPanel7.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel7.Name = "RoundedPanel7"
        Me.RoundedPanel7.Size = New System.Drawing.Size(319, 187)
        Me.RoundedPanel7.TabIndex = 68
        '
        'SAChart_PendingRequest
        '
        Me.SAChart_PendingRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_PendingRequest.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_PendingRequest.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea13.Name = "ChartArea1"
        Me.SAChart_PendingRequest.ChartAreas.Add(ChartArea13)
        Legend13.Name = "Legend1"
        Me.SAChart_PendingRequest.Legends.Add(Legend13)
        Me.SAChart_PendingRequest.Location = New System.Drawing.Point(43, 46)
        Me.SAChart_PendingRequest.Name = "SAChart_PendingRequest"
        Series13.BackImageTransparentColor = System.Drawing.Color.Transparent
        Series13.ChartArea = "ChartArea1"
        Series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series13.LabelForeColor = System.Drawing.Color.BlanchedAlmond
        Series13.Legend = "Legend1"
        Series13.Name = "Series1"
        Me.SAChart_PendingRequest.Series.Add(Series13)
        Me.SAChart_PendingRequest.Size = New System.Drawing.Size(238, 127)
        Me.SAChart_PendingRequest.TabIndex = 52
        Me.SAChart_PendingRequest.Text = "Chart3"
        '
        'lblPendingRequest
        '
        lblPendingRequest.AutoSize = True
        lblPendingRequest.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPendingRequest.ForeColor = System.Drawing.Color.Black
        lblPendingRequest.Location = New System.Drawing.Point(9, 19)
        lblPendingRequest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPendingRequest.Name = "lblPendingRequest"
        lblPendingRequest.Size = New System.Drawing.Size(159, 30)
        lblPendingRequest.TabIndex = 51
        lblPendingRequest.Text = "Pending Request"
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel6.Controls.Add(Me.SAChart_TotalSupplies)
        Me.RoundedPanel6.Controls.Add(lblTotalSupplies)
        Me.RoundedPanel6.CornerRadius = 5
        Me.RoundedPanel6.Location = New System.Drawing.Point(348, 10)
        Me.RoundedPanel6.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(318, 187)
        Me.RoundedPanel6.TabIndex = 67
        '
        'SAChart_TotalSupplies
        '
        Me.SAChart_TotalSupplies.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_TotalSupplies.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_TotalSupplies.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_TotalSupplies.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea14.Name = "ChartArea1"
        Me.SAChart_TotalSupplies.ChartAreas.Add(ChartArea14)
        Legend14.Name = "Legend1"
        Me.SAChart_TotalSupplies.Legends.Add(Legend14)
        Me.SAChart_TotalSupplies.Location = New System.Drawing.Point(21, 46)
        Me.SAChart_TotalSupplies.Name = "SAChart_TotalSupplies"
        Series14.ChartArea = "ChartArea1"
        Series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100
        Series14.Legend = "Legend1"
        Series14.Name = "Series1"
        Me.SAChart_TotalSupplies.Series.Add(Series14)
        Me.SAChart_TotalSupplies.Size = New System.Drawing.Size(284, 127)
        Me.SAChart_TotalSupplies.TabIndex = 51
        Me.SAChart_TotalSupplies.Text = "Chart2"
        '
        'lblTotalSupplies
        '
        lblTotalSupplies.AutoSize = True
        lblTotalSupplies.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalSupplies.ForeColor = System.Drawing.Color.Black
        lblTotalSupplies.Location = New System.Drawing.Point(16, 15)
        lblTotalSupplies.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalSupplies.Name = "lblTotalSupplies"
        lblTotalSupplies.Size = New System.Drawing.Size(136, 30)
        lblTotalSupplies.TabIndex = 50
        lblTotalSupplies.Text = "Total Supplies"
        '
        'RoundedPanel12
        '
        Me.RoundedPanel12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel12.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel12.Controls.Add(Me.SAChart_RequestTrends)
        Me.RoundedPanel12.Controls.Add(lblRequestTrends)
        Me.RoundedPanel12.CornerRadius = 5
        Me.RoundedPanel12.Location = New System.Drawing.Point(348, 424)
        Me.RoundedPanel12.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel12.Name = "RoundedPanel12"
        Me.RoundedPanel12.Size = New System.Drawing.Size(318, 188)
        Me.RoundedPanel12.TabIndex = 65
        '
        'SAChart_RequestTrends
        '
        Me.SAChart_RequestTrends.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_RequestTrends.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_RequestTrends.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_RequestTrends.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea12.Name = "ChartArea1"
        Me.SAChart_RequestTrends.ChartAreas.Add(ChartArea12)
        Legend12.Name = "Legend1"
        Me.SAChart_RequestTrends.Legends.Add(Legend12)
        Me.SAChart_RequestTrends.Location = New System.Drawing.Point(25, 52)
        Me.SAChart_RequestTrends.Name = "SAChart_RequestTrends"
        Series12.ChartArea = "ChartArea1"
        Series12.Legend = "Legend1"
        Series12.Name = "Series1"
        Me.SAChart_RequestTrends.Series.Add(Series12)
        Me.SAChart_RequestTrends.Size = New System.Drawing.Size(273, 120)
        Me.SAChart_RequestTrends.TabIndex = 56
        Me.SAChart_RequestTrends.Text = "Chart8"
        '
        'lblRequestTrends
        '
        lblRequestTrends.AutoSize = True
        lblRequestTrends.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRequestTrends.ForeColor = System.Drawing.Color.Black
        lblRequestTrends.Location = New System.Drawing.Point(20, 19)
        lblRequestTrends.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblRequestTrends.Name = "lblRequestTrends"
        lblRequestTrends.Size = New System.Drawing.Size(146, 30)
        lblRequestTrends.TabIndex = 55
        lblRequestTrends.Text = "Request Trends"
        '
        'RoundedPanel8
        '
        Me.RoundedPanel8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel8.Controls.Add(Me.SAChart_ScheduleMaintenance)
        Me.RoundedPanel8.Controls.Add(lblScheduleMaintenance)
        Me.RoundedPanel8.CornerRadius = 5
        Me.RoundedPanel8.Location = New System.Drawing.Point(686, 217)
        Me.RoundedPanel8.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel8.Name = "RoundedPanel8"
        Me.RoundedPanel8.Size = New System.Drawing.Size(319, 187)
        Me.RoundedPanel8.TabIndex = 63
        '
        'SAChart_ScheduleMaintenance
        '
        Me.SAChart_ScheduleMaintenance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_ScheduleMaintenance.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_ScheduleMaintenance.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_ScheduleMaintenance.BorderlineColor = System.Drawing.Color.Transparent
        Me.SAChart_ScheduleMaintenance.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea15.Name = "ChartArea1"
        Me.SAChart_ScheduleMaintenance.ChartAreas.Add(ChartArea15)
        Legend15.Name = "Legend1"
        Me.SAChart_ScheduleMaintenance.Legends.Add(Legend15)
        Me.SAChart_ScheduleMaintenance.Location = New System.Drawing.Point(43, 43)
        Me.SAChart_ScheduleMaintenance.Name = "SAChart_ScheduleMaintenance"
        Series15.ChartArea = "ChartArea1"
        Series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series15.Legend = "Legend1"
        Series15.Name = "Series1"
        Me.SAChart_ScheduleMaintenance.Series.Add(Series15)
        Me.SAChart_ScheduleMaintenance.Size = New System.Drawing.Size(238, 132)
        Me.SAChart_ScheduleMaintenance.TabIndex = 55
        Me.SAChart_ScheduleMaintenance.Text = "Chart6"
        '
        'lblScheduleMaintenance
        '
        lblScheduleMaintenance.AutoSize = True
        lblScheduleMaintenance.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblScheduleMaintenance.ForeColor = System.Drawing.Color.Black
        lblScheduleMaintenance.Location = New System.Drawing.Point(20, 19)
        lblScheduleMaintenance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblScheduleMaintenance.Name = "lblScheduleMaintenance"
        lblScheduleMaintenance.Size = New System.Drawing.Size(211, 30)
        lblScheduleMaintenance.TabIndex = 48
        lblScheduleMaintenance.Text = "Schedule Maintenance"
        '
        'RoundedPanel9
        '
        Me.RoundedPanel9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel9.Controls.Add(Me.SAChart_PropertyConditionStatus)
        Me.RoundedPanel9.Controls.Add(lblPropertyConditionStatus)
        Me.RoundedPanel9.CornerRadius = 5
        Me.RoundedPanel9.Location = New System.Drawing.Point(348, 217)
        Me.RoundedPanel9.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel9.Name = "RoundedPanel9"
        Me.RoundedPanel9.Size = New System.Drawing.Size(318, 187)
        Me.RoundedPanel9.TabIndex = 62
        '
        'SAChart_PropertyConditionStatus
        '
        Me.SAChart_PropertyConditionStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_PropertyConditionStatus.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_PropertyConditionStatus.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_PropertyConditionStatus.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea16.Name = "ChartArea1"
        Me.SAChart_PropertyConditionStatus.ChartAreas.Add(ChartArea16)
        Legend16.Name = "Legend1"
        Me.SAChart_PropertyConditionStatus.Legends.Add(Legend16)
        Me.SAChart_PropertyConditionStatus.Location = New System.Drawing.Point(21, 49)
        Me.SAChart_PropertyConditionStatus.Name = "SAChart_PropertyConditionStatus"
        Series16.ChartArea = "ChartArea1"
        Series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar
        Series16.Legend = "Legend1"
        Series16.Name = "Series1"
        Me.SAChart_PropertyConditionStatus.Series.Add(Series16)
        Me.SAChart_PropertyConditionStatus.Size = New System.Drawing.Size(284, 126)
        Me.SAChart_PropertyConditionStatus.TabIndex = 51
        Me.SAChart_PropertyConditionStatus.Text = "Chart5"
        '
        'lblPropertyConditionStatus
        '
        lblPropertyConditionStatus.AutoSize = True
        lblPropertyConditionStatus.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPropertyConditionStatus.ForeColor = System.Drawing.Color.Black
        lblPropertyConditionStatus.Location = New System.Drawing.Point(20, 19)
        lblPropertyConditionStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPropertyConditionStatus.Name = "lblPropertyConditionStatus"
        lblPropertyConditionStatus.Size = New System.Drawing.Size(239, 30)
        lblPropertyConditionStatus.TabIndex = 48
        lblPropertyConditionStatus.Text = "Property Condition Status"
        '
        'RoundedPanel10
        '
        Me.RoundedPanel10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel10.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel10.Controls.Add(Me.SAChart_InventoryStatusOverview)
        Me.RoundedPanel10.Controls.Add(lblInventoryStatusOverview)
        Me.RoundedPanel10.CornerRadius = 5
        Me.RoundedPanel10.Location = New System.Drawing.Point(10, 217)
        Me.RoundedPanel10.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel10.Name = "RoundedPanel10"
        Me.RoundedPanel10.Size = New System.Drawing.Size(318, 187)
        Me.RoundedPanel10.TabIndex = 61
        '
        'SAChart_InventoryStatusOverview
        '
        Me.SAChart_InventoryStatusOverview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_InventoryStatusOverview.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_InventoryStatusOverview.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_InventoryStatusOverview.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea17.Name = "ChartArea1"
        Me.SAChart_InventoryStatusOverview.ChartAreas.Add(ChartArea17)
        Legend17.Name = "Legend1"
        Me.SAChart_InventoryStatusOverview.Legends.Add(Legend17)
        Me.SAChart_InventoryStatusOverview.Location = New System.Drawing.Point(28, 49)
        Me.SAChart_InventoryStatusOverview.Name = "SAChart_InventoryStatusOverview"
        Series17.ChartArea = "ChartArea1"
        Series17.Legend = "Legend1"
        Series17.Name = "Series1"
        Me.SAChart_InventoryStatusOverview.Series.Add(Series17)
        Me.SAChart_InventoryStatusOverview.Size = New System.Drawing.Size(271, 129)
        Me.SAChart_InventoryStatusOverview.TabIndex = 52
        Me.SAChart_InventoryStatusOverview.Text = "Chart4"
        '
        'lblInventoryStatusOverview
        '
        lblInventoryStatusOverview.AutoSize = True
        lblInventoryStatusOverview.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblInventoryStatusOverview.ForeColor = System.Drawing.Color.Black
        lblInventoryStatusOverview.Location = New System.Drawing.Point(14, 16)
        lblInventoryStatusOverview.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblInventoryStatusOverview.Name = "lblInventoryStatusOverview"
        lblInventoryStatusOverview.Size = New System.Drawing.Size(243, 30)
        lblInventoryStatusOverview.TabIndex = 48
        lblInventoryStatusOverview.Text = "Inventory Status Overview"
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel5.Controls.Add(Me.SAChart_TotalProperty)
        Me.RoundedPanel5.Controls.Add(lblTotalProperty)
        Me.RoundedPanel5.CornerRadius = 5
        Me.RoundedPanel5.Location = New System.Drawing.Point(10, 10)
        Me.RoundedPanel5.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(318, 187)
        Me.RoundedPanel5.TabIndex = 58
        '
        'SAChart_TotalProperty
        '
        Me.SAChart_TotalProperty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAChart_TotalProperty.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None
        Me.SAChart_TotalProperty.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_TotalProperty.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea18.Name = "ChartArea1"
        Me.SAChart_TotalProperty.ChartAreas.Add(ChartArea18)
        Legend18.Name = "Legend1"
        Me.SAChart_TotalProperty.Legends.Add(Legend18)
        Me.SAChart_TotalProperty.Location = New System.Drawing.Point(28, 46)
        Me.SAChart_TotalProperty.Name = "SAChart_TotalProperty"
        Series18.ChartArea = "ChartArea1"
        Series18.Legend = "Legend1"
        Series18.Name = "Series1"
        Me.SAChart_TotalProperty.Series.Add(Series18)
        Me.SAChart_TotalProperty.Size = New System.Drawing.Size(271, 127)
        Me.SAChart_TotalProperty.TabIndex = 49
        Me.SAChart_TotalProperty.Text = "Chart1"
        '
        'lblTotalProperty
        '
        lblTotalProperty.AutoSize = True
        lblTotalProperty.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalProperty.ForeColor = System.Drawing.Color.Black
        lblTotalProperty.Location = New System.Drawing.Point(23, 15)
        lblTotalProperty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalProperty.Name = "lblTotalProperty"
        lblTotalProperty.Size = New System.Drawing.Size(138, 30)
        lblTotalProperty.TabIndex = 46
        lblTotalProperty.Text = "Total Property"
        '
        'admin_panel1
        '
        Me.admin_panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_panel1.Controls.Add(Me.admin_label_quickaccess)
        Me.admin_panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.admin_panel1.CornerRadius = 5
        Me.admin_panel1.Location = New System.Drawing.Point(24, 8)
        Me.admin_panel1.Name = "admin_panel1"
        Me.admin_panel1.Size = New System.Drawing.Size(992, 96)
        Me.admin_panel1.TabIndex = 19
        '
        'admin_label_quickaccess
        '
        Me.admin_label_quickaccess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_label_quickaccess.AutoSize = True
        Me.admin_label_quickaccess.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_quickaccess.ForeColor = System.Drawing.Color.Black
        Me.admin_label_quickaccess.Location = New System.Drawing.Point(13, 11)
        Me.admin_label_quickaccess.Name = "admin_label_quickaccess"
        Me.admin_label_quickaccess.Size = New System.Drawing.Size(128, 30)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 39)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(972, 53)
        Me.TableLayoutPanel2.TabIndex = 15
        '
        'admin_btn_hello
        '
        Me.admin_btn_hello.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_btn_hello.CornerRadius = 5
        Me.admin_btn_hello.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_hello.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_hello.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_hello.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_hello.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_hello.ForeColor = System.Drawing.Color.Black
        Me.admin_btn_hello.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_hello.Location = New System.Drawing.Point(10, 10)
        Me.admin_btn_hello.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_hello.Name = "admin_btn_hello"
        Me.admin_btn_hello.Size = New System.Drawing.Size(223, 33)
        Me.admin_btn_hello.TabIndex = 11
        Me.admin_btn_hello.Text = "None"
        Me.admin_btn_hello.UseVisualStyleBackColor = False
        '
        'admin_btn_viewallprop
        '
        Me.admin_btn_viewallprop.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_btn_viewallprop.CornerRadius = 5
        Me.admin_btn_viewallprop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_viewallprop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_viewallprop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_viewallprop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_viewallprop.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_viewallprop.ForeColor = System.Drawing.Color.Black
        Me.admin_btn_viewallprop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_viewallprop.Location = New System.Drawing.Point(739, 10)
        Me.admin_btn_viewallprop.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_viewallprop.Name = "admin_btn_viewallprop"
        Me.admin_btn_viewallprop.Size = New System.Drawing.Size(223, 33)
        Me.admin_btn_viewallprop.TabIndex = 14
        Me.admin_btn_viewallprop.Text = "View All Properties"
        Me.admin_btn_viewallprop.UseVisualStyleBackColor = False
        '
        'admin_btn_updateinventory
        '
        Me.admin_btn_updateinventory.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_btn_updateinventory.CornerRadius = 5
        Me.admin_btn_updateinventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_updateinventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_updateinventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_updateinventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_updateinventory.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_updateinventory.ForeColor = System.Drawing.Color.Black
        Me.admin_btn_updateinventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_updateinventory.Location = New System.Drawing.Point(253, 10)
        Me.admin_btn_updateinventory.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_updateinventory.Name = "admin_btn_updateinventory"
        Me.admin_btn_updateinventory.Size = New System.Drawing.Size(223, 33)
        Me.admin_btn_updateinventory.TabIndex = 12
        Me.admin_btn_updateinventory.Text = "Update Inventory"
        Me.admin_btn_updateinventory.UseVisualStyleBackColor = False
        '
        'admin_btn_generatereport
        '
        Me.admin_btn_generatereport.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_btn_generatereport.CornerRadius = 5
        Me.admin_btn_generatereport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_btn_generatereport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_generatereport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_generatereport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_generatereport.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_generatereport.ForeColor = System.Drawing.Color.Black
        Me.admin_btn_generatereport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_generatereport.Location = New System.Drawing.Point(496, 10)
        Me.admin_btn_generatereport.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_btn_generatereport.Name = "admin_btn_generatereport"
        Me.admin_btn_generatereport.Size = New System.Drawing.Size(223, 33)
        Me.admin_btn_generatereport.TabIndex = 13
        Me.admin_btn_generatereport.Text = "Generate Report"
        Me.admin_btn_generatereport.UseVisualStyleBackColor = False
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel2.Controls.Add(Me.Label2)
        Me.RoundedPanel2.Controls.Add(Me.Label7)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(769, 10)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(233, 100)
        Me.RoundedPanel2.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(101, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 58)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 9)
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
        Me.RoundedPanel3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel3.Controls.Add(Me.Label4)
        Me.RoundedPanel3.Controls.Add(Me.Label3)
        Me.RoundedPanel3.CornerRadius = 5
        Me.RoundedPanel3.Location = New System.Drawing.Point(10, 10)
        Me.RoundedPanel3.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(233, 100)
        Me.RoundedPanel3.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(97, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 58)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 8)
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
        Me.RoundedPanel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RoundedPanel1.Controls.Add(Me.Label6)
        Me.RoundedPanel1.Controls.Add(Me.admin_panel_borrowed)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(516, 10)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(10)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(233, 100)
        Me.RoundedPanel1.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(96, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 58)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "1"
        '
        'admin_panel_borrowed
        '
        Me.admin_panel_borrowed.AutoSize = True
        Me.admin_panel_borrowed.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.admin_panel_borrowed.ForeColor = System.Drawing.Color.Black
        Me.admin_panel_borrowed.Location = New System.Drawing.Point(12, 9)
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
        Me.admin_panel_PendingRequests.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_panel_PendingRequests.Controls.Add(Me.Label5)
        Me.admin_panel_PendingRequests.Controls.Add(Me.Label1)
        Me.admin_panel_PendingRequests.CornerRadius = 5
        Me.admin_panel_PendingRequests.Location = New System.Drawing.Point(263, 10)
        Me.admin_panel_PendingRequests.Margin = New System.Windows.Forms.Padding(10)
        Me.admin_panel_PendingRequests.Name = "admin_panel_PendingRequests"
        Me.admin_panel_PendingRequests.Size = New System.Drawing.Size(233, 100)
        Me.admin_panel_PendingRequests.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(97, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 58)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pending Requests"
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
        Me.admin_btn_UserManagement.Location = New System.Drawing.Point(24, 314)
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
        'admin_panel2
        '
        Me.admin_panel2.CornerRadius = 20
        Me.admin_panel2.Location = New System.Drawing.Point(0, 0)
        Me.admin_panel2.Name = "admin_panel2"
        Me.admin_panel2.Size = New System.Drawing.Size(200, 100)
        Me.admin_panel2.TabIndex = 0
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
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel11.ResumeLayout(False)
        Me.RoundedPanel11.PerformLayout()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel13.ResumeLayout(False)
        Me.RoundedPanel13.PerformLayout()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel7.ResumeLayout(False)
        Me.RoundedPanel7.PerformLayout()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel6.ResumeLayout(False)
        Me.RoundedPanel6.PerformLayout()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel12.ResumeLayout(False)
        Me.RoundedPanel12.PerformLayout()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel8.ResumeLayout(False)
        Me.RoundedPanel8.PerformLayout()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel9.ResumeLayout(False)
        Me.RoundedPanel9.PerformLayout()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel10.ResumeLayout(False)
        Me.RoundedPanel10.PerformLayout()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel5.ResumeLayout(False)
        Me.RoundedPanel5.PerformLayout()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.admin_panel1.ResumeLayout(False)
        Me.admin_panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.admin_panel_PendingRequests.ResumeLayout(False)
        Me.admin_panel_PendingRequests.PerformLayout()
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
    Friend WithEvents admin_panel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents admin_panelcontainer As Panel
    Friend WithEvents admin_panel_PendingRequests As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents admin_panel_borrowed As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents admin_panel1 As Resources.Controls.RoundedPanel
    Friend WithEvents admin_label_quickaccess As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents admin_btn_hello As Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_viewallprop As Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_updateinventory As Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_generatereport As Resources.Controls.RoundedButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents RoundedPanel7 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_PendingRequest As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel6 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_TotalSupplies As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel8 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_ScheduleMaintenance As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel9 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_PropertyConditionStatus As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel10 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_InventoryStatusOverview As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel5 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_TotalProperty As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel11 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_SystemAlerts As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel13 As Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel12 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_RecentPropertyRequests As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_RequestTrends As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
End Class
