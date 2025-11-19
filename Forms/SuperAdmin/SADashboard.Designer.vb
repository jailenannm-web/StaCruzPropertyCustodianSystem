Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SADashboard
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
        Dim lblTotalProperty As System.Windows.Forms.Label
        Dim lblTotalSupplies As System.Windows.Forms.Label
        Dim lblPendingRequest As System.Windows.Forms.Label
        Dim lblScheduleMaintenance As System.Windows.Forms.Label
        Dim lblInventoryStatusOverview As System.Windows.Forms.Label
        Dim lblPropertyConditionStatus As System.Windows.Forms.Label
        Dim lblRequestTrends As System.Windows.Forms.Label
        Dim lblRecentPRopertyRequests As System.Windows.Forms.Label
        Dim lblSystemAlerts As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SADashboard))
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
        Dim ChartArea10 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend10 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea17 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend17 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series17 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea18 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend18 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series18 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.lblSuperAdmin = New System.Windows.Forms.Label()
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.btnSystemConfig = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlFormLoader = New System.Windows.Forms.Panel()
        Me.RoundedPanel11 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel9 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel8 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel10 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.btnGenerateReports = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddUser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddProperty = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.comboFilter = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtboxSearch = New System.Windows.Forms.TextBox()
        Me.lblPropertyCustodian = New System.Windows.Forms.Label()
        Me.icStaff = New System.Windows.Forms.PictureBox()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnMaintenanceManagement = New System.Windows.Forms.Button()
        Me.btnPropertyRequestManagement = New System.Windows.Forms.Button()
        Me.btnDepartmentManagement = New System.Windows.Forms.Button()
        Me.btnSuppliesManagement = New System.Windows.Forms.Button()
        Me.btnPropertyManagement = New System.Windows.Forms.Button()
        Me.btnUserManagement = New System.Windows.Forms.Button()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.SAChart_TotalProperty = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_TotalSupplies = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_PendingRequest = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_InventoryStatusOverview = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_PropertyConditionStatus = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_ScheduleMaintenance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_RecentPropertyRequests = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_RequestTrends = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SAChart_SystemAlerts = New System.Windows.Forms.DataVisualization.Charting.Chart()
        lblTotalProperty = New System.Windows.Forms.Label()
        lblTotalSupplies = New System.Windows.Forms.Label()
        lblPendingRequest = New System.Windows.Forms.Label()
        lblScheduleMaintenance = New System.Windows.Forms.Label()
        lblInventoryStatusOverview = New System.Windows.Forms.Label()
        lblPropertyConditionStatus = New System.Windows.Forms.Label()
        lblRequestTrends = New System.Windows.Forms.Label()
        lblRecentPRopertyRequests = New System.Windows.Forms.Label()
        lblSystemAlerts = New System.Windows.Forms.Label()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlFormLoader.SuspendLayout()
        Me.RoundedPanel11.SuspendLayout()
        Me.RoundedPanel9.SuspendLayout()
        Me.RoundedPanel8.SuspendLayout()
        Me.RoundedPanel10.SuspendLayout()
        Me.RoundedPanel6.SuspendLayout()
        Me.RoundedPanel5.SuspendLayout()
        Me.RoundedPanel4.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'lblTotalSupplies
        '
        lblTotalSupplies.AutoSize = True
        lblTotalSupplies.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalSupplies.ForeColor = System.Drawing.Color.White
        lblTotalSupplies.Location = New System.Drawing.Point(19, 15)
        lblTotalSupplies.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalSupplies.Name = "lblTotalSupplies"
        lblTotalSupplies.Size = New System.Drawing.Size(143, 24)
        lblTotalSupplies.TabIndex = 47
        lblTotalSupplies.Text = "Total Supplies"
        '
        'lblPendingRequest
        '
        lblPendingRequest.AutoSize = True
        lblPendingRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPendingRequest.ForeColor = System.Drawing.Color.White
        lblPendingRequest.Location = New System.Drawing.Point(23, 15)
        lblPendingRequest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPendingRequest.Name = "lblPendingRequest"
        lblPendingRequest.Size = New System.Drawing.Size(171, 24)
        lblPendingRequest.TabIndex = 48
        lblPendingRequest.Text = "Pending Request"
        '
        'lblScheduleMaintenance
        '
        lblScheduleMaintenance.AutoSize = True
        lblScheduleMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblScheduleMaintenance.ForeColor = System.Drawing.Color.White
        lblScheduleMaintenance.Location = New System.Drawing.Point(17, 15)
        lblScheduleMaintenance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblScheduleMaintenance.Name = "lblScheduleMaintenance"
        lblScheduleMaintenance.Size = New System.Drawing.Size(225, 24)
        lblScheduleMaintenance.TabIndex = 47
        lblScheduleMaintenance.Text = "Schedule Maintenance"
        '
        'lblInventoryStatusOverview
        '
        lblInventoryStatusOverview.AutoSize = True
        lblInventoryStatusOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblInventoryStatusOverview.ForeColor = System.Drawing.Color.White
        lblInventoryStatusOverview.Location = New System.Drawing.Point(23, 21)
        lblInventoryStatusOverview.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblInventoryStatusOverview.Name = "lblInventoryStatusOverview"
        lblInventoryStatusOverview.Size = New System.Drawing.Size(250, 24)
        lblInventoryStatusOverview.TabIndex = 47
        lblInventoryStatusOverview.Text = "Inventory Status Overview"
        '
        'lblPropertyConditionStatus
        '
        lblPropertyConditionStatus.AutoSize = True
        lblPropertyConditionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPropertyConditionStatus.ForeColor = System.Drawing.Color.White
        lblPropertyConditionStatus.Location = New System.Drawing.Point(23, 21)
        lblPropertyConditionStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPropertyConditionStatus.Name = "lblPropertyConditionStatus"
        lblPropertyConditionStatus.Size = New System.Drawing.Size(245, 24)
        lblPropertyConditionStatus.TabIndex = 47
        lblPropertyConditionStatus.Text = "Property Condition Status"
        '
        'lblRequestTrends
        '
        lblRequestTrends.AutoSize = True
        lblRequestTrends.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRequestTrends.ForeColor = System.Drawing.Color.White
        lblRequestTrends.Location = New System.Drawing.Point(23, 9)
        lblRequestTrends.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblRequestTrends.Name = "lblRequestTrends"
        lblRequestTrends.Size = New System.Drawing.Size(159, 24)
        lblRequestTrends.TabIndex = 48
        lblRequestTrends.Text = "Request Trends"
        '
        'lblRecentPRopertyRequests
        '
        lblRecentPRopertyRequests.AutoSize = True
        lblRecentPRopertyRequests.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRecentPRopertyRequests.ForeColor = System.Drawing.Color.White
        lblRecentPRopertyRequests.Location = New System.Drawing.Point(24, 23)
        lblRecentPRopertyRequests.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblRecentPRopertyRequests.Name = "lblRecentPRopertyRequests"
        lblRecentPRopertyRequests.Size = New System.Drawing.Size(253, 24)
        lblRecentPRopertyRequests.TabIndex = 49
        lblRecentPRopertyRequests.Text = "Recent Property Requests"
        '
        'lblSystemAlerts
        '
        lblSystemAlerts.AutoSize = True
        lblSystemAlerts.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSystemAlerts.ForeColor = System.Drawing.Color.White
        lblSystemAlerts.Location = New System.Drawing.Point(23, 23)
        lblSystemAlerts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblSystemAlerts.Name = "lblSystemAlerts"
        lblSystemAlerts.Size = New System.Drawing.Size(136, 24)
        lblSystemAlerts.TabIndex = 49
        lblSystemAlerts.Text = "System Alerts"
        '
        'lblSuperAdmin
        '
        Me.lblSuperAdmin.AutoSize = True
        Me.lblSuperAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblSuperAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuperAdmin.ForeColor = System.Drawing.Color.White
        Me.lblSuperAdmin.Location = New System.Drawing.Point(107, 145)
        Me.lblSuperAdmin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSuperAdmin.Name = "lblSuperAdmin"
        Me.lblSuperAdmin.Size = New System.Drawing.Size(108, 20)
        Me.lblSuperAdmin.TabIndex = 11
        Me.lblSuperAdmin.Text = "Superadmin"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnSystemConfig)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.Panel1)
        Me.pnlSidebar.Controls.Add(Me.lblSuperAdmin)
        Me.pnlSidebar.CornerRadius = 20
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(356, 922)
        Me.pnlSidebar.TabIndex = 21
        '
        'btnSystemConfig
        '
        Me.btnSystemConfig.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSystemConfig.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnSystemConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSystemConfig.FlatAppearance.BorderSize = 2
        Me.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSystemConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemConfig.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnSystemConfig.Image = CType(resources.GetObject("btnSystemConfig.Image"), System.Drawing.Image)
        Me.btnSystemConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSystemConfig.Location = New System.Drawing.Point(16, 750)
        Me.btnSystemConfig.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSystemConfig.Name = "btnSystemConfig"
        Me.btnSystemConfig.Size = New System.Drawing.Size(317, 63)
        Me.btnSystemConfig.TabIndex = 22
        Me.btnSystemConfig.Text = "System Configuration"
        Me.btnSystemConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemConfig.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnLogout.FlatAppearance.BorderSize = 2
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(16, 820)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(317, 63)
        Me.btnLogout.TabIndex = 22
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(359, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1471, 922)
        Me.Panel1.TabIndex = 23
        '
        'pnlFormLoader
        '
        Me.pnlFormLoader.AutoScroll = True
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel11)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel9)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel8)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel10)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel6)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel5)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel4)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel3)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel2)
        Me.pnlFormLoader.Controls.Add(Me.btnGenerateReports)
        Me.pnlFormLoader.Controls.Add(Me.btnAddSupply)
        Me.pnlFormLoader.Controls.Add(Me.btnAddUser)
        Me.pnlFormLoader.Controls.Add(Me.btnAddProperty)
        Me.pnlFormLoader.Controls.Add(Me.comboFilter)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel1)
        Me.pnlFormLoader.Controls.Add(Me.lblPropertyCustodian)
        Me.pnlFormLoader.Location = New System.Drawing.Point(403, 15)
        Me.pnlFormLoader.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlFormLoader.Name = "pnlFormLoader"
        Me.pnlFormLoader.Size = New System.Drawing.Size(1467, 918)
        Me.pnlFormLoader.TabIndex = 22
        '
        'RoundedPanel11
        '
        Me.RoundedPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel11.Controls.Add(Me.SAChart_SystemAlerts)
        Me.RoundedPanel11.Controls.Add(lblSystemAlerts)
        Me.RoundedPanel11.CornerRadius = 20
        Me.RoundedPanel11.Location = New System.Drawing.Point(931, 630)
        Me.RoundedPanel11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel11.Name = "RoundedPanel11"
        Me.RoundedPanel11.Size = New System.Drawing.Size(443, 250)
        Me.RoundedPanel11.TabIndex = 18
        '
        'RoundedPanel9
        '
        Me.RoundedPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel9.Controls.Add(Me.SAChart_RecentPropertyRequests)
        Me.RoundedPanel9.Controls.Add(lblRecentPRopertyRequests)
        Me.RoundedPanel9.CornerRadius = 20
        Me.RoundedPanel9.Location = New System.Drawing.Point(28, 630)
        Me.RoundedPanel9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel9.Name = "RoundedPanel9"
        Me.RoundedPanel9.Size = New System.Drawing.Size(415, 250)
        Me.RoundedPanel9.TabIndex = 17
        '
        'RoundedPanel8
        '
        Me.RoundedPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel8.Controls.Add(Me.SAChart_RequestTrends)
        Me.RoundedPanel8.Controls.Add(lblRequestTrends)
        Me.RoundedPanel8.CornerRadius = 20
        Me.RoundedPanel8.Location = New System.Drawing.Point(470, 630)
        Me.RoundedPanel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel8.Name = "RoundedPanel8"
        Me.RoundedPanel8.Size = New System.Drawing.Size(427, 250)
        Me.RoundedPanel8.TabIndex = 17
        '
        'RoundedPanel10
        '
        Me.RoundedPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel10.Controls.Add(Me.SAChart_PropertyConditionStatus)
        Me.RoundedPanel10.Controls.Add(lblPropertyConditionStatus)
        Me.RoundedPanel10.CornerRadius = 20
        Me.RoundedPanel10.Location = New System.Drawing.Point(470, 384)
        Me.RoundedPanel10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel10.Name = "RoundedPanel10"
        Me.RoundedPanel10.Size = New System.Drawing.Size(427, 231)
        Me.RoundedPanel10.TabIndex = 17
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel6.Controls.Add(Me.SAChart_InventoryStatusOverview)
        Me.RoundedPanel6.Controls.Add(lblInventoryStatusOverview)
        Me.RoundedPanel6.CornerRadius = 20
        Me.RoundedPanel6.Location = New System.Drawing.Point(28, 384)
        Me.RoundedPanel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(414, 231)
        Me.RoundedPanel6.TabIndex = 16
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel5.Controls.Add(Me.SAChart_ScheduleMaintenance)
        Me.RoundedPanel5.Controls.Add(lblScheduleMaintenance)
        Me.RoundedPanel5.CornerRadius = 20
        Me.RoundedPanel5.Location = New System.Drawing.Point(931, 377)
        Me.RoundedPanel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(443, 238)
        Me.RoundedPanel5.TabIndex = 16
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel4.Controls.Add(Me.SAChart_PendingRequest)
        Me.RoundedPanel4.Controls.Add(lblPendingRequest)
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(931, 147)
        Me.RoundedPanel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(443, 217)
        Me.RoundedPanel4.TabIndex = 15
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel3.Controls.Add(Me.SAChart_TotalSupplies)
        Me.RoundedPanel3.Controls.Add(lblTotalSupplies)
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(470, 148)
        Me.RoundedPanel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(427, 217)
        Me.RoundedPanel3.TabIndex = 15
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel2.Controls.Add(Me.SAChart_TotalProperty)
        Me.RoundedPanel2.Controls.Add(lblTotalProperty)
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(28, 147)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(414, 217)
        Me.RoundedPanel2.TabIndex = 14
        '
        'btnGenerateReports
        '
        Me.btnGenerateReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateReports.CornerRadius = 15
        Me.btnGenerateReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReports.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateReports.Location = New System.Drawing.Point(1257, 78)
        Me.btnGenerateReports.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateReports.Name = "btnGenerateReports"
        Me.btnGenerateReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnGenerateReports.Size = New System.Drawing.Size(183, 36)
        Me.btnGenerateReports.TabIndex = 13
        Me.btnGenerateReports.Text = "Generate Reports"
        Me.btnGenerateReports.UseVisualStyleBackColor = False
        '
        'btnAddSupply
        '
        Me.btnAddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAddSupply.CornerRadius = 15
        Me.btnAddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSupply.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddSupply.Location = New System.Drawing.Point(868, 78)
        Me.btnAddSupply.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddSupply.Name = "btnAddSupply"
        Me.btnAddSupply.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddSupply.Size = New System.Drawing.Size(155, 36)
        Me.btnAddSupply.TabIndex = 12
        Me.btnAddSupply.Text = "Add Supply"
        Me.btnAddSupply.UseVisualStyleBackColor = False
        '
        'btnAddUser
        '
        Me.btnAddUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAddUser.CornerRadius = 15
        Me.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddUser.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddUser.Location = New System.Drawing.Point(1063, 78)
        Me.btnAddUser.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddUser.Size = New System.Drawing.Size(155, 36)
        Me.btnAddUser.TabIndex = 11
        Me.btnAddUser.Text = "Add User"
        Me.btnAddUser.UseVisualStyleBackColor = False
        '
        'btnAddProperty
        '
        Me.btnAddProperty.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAddProperty.CornerRadius = 15
        Me.btnAddProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProperty.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddProperty.Location = New System.Drawing.Point(673, 78)
        Me.btnAddProperty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddProperty.Name = "btnAddProperty"
        Me.btnAddProperty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddProperty.Size = New System.Drawing.Size(155, 36)
        Me.btnAddProperty.TabIndex = 10
        Me.btnAddProperty.Text = "Add Property"
        Me.btnAddProperty.UseVisualStyleBackColor = False
        '
        'comboFilter
        '
        Me.comboFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboFilter.FormattingEnabled = True
        Me.comboFilter.Location = New System.Drawing.Point(447, 82)
        Me.comboFilter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboFilter.Name = "comboFilter"
        Me.comboFilter.Size = New System.Drawing.Size(173, 24)
        Me.comboFilter.TabIndex = 9
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.txtboxSearch)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Location = New System.Drawing.Point(28, 74)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(383, 44)
        Me.RoundedPanel1.TabIndex = 8
        '
        'txtboxSearch
        '
        Me.txtboxSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.txtboxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxSearch.Location = New System.Drawing.Point(39, 15)
        Me.txtboxSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtboxSearch.Name = "txtboxSearch"
        Me.txtboxSearch.Size = New System.Drawing.Size(321, 15)
        Me.txtboxSearch.TabIndex = 14
        '
        'lblPropertyCustodian
        '
        Me.lblPropertyCustodian.AutoSize = True
        Me.lblPropertyCustodian.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCustodian.Location = New System.Drawing.Point(21, 20)
        Me.lblPropertyCustodian.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPropertyCustodian.Name = "lblPropertyCustodian"
        Me.lblPropertyCustodian.Size = New System.Drawing.Size(265, 31)
        Me.lblPropertyCustodian.TabIndex = 7
        Me.lblPropertyCustodian.Text = "Property Custodian"
        '
        'icStaff
        '
        Me.icStaff.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.icStaff.Image = CType(resources.GetObject("icStaff.Image"), System.Drawing.Image)
        Me.icStaff.Location = New System.Drawing.Point(99, 39)
        Me.icStaff.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.icStaff.Name = "icStaff"
        Me.icStaff.Size = New System.Drawing.Size(129, 102)
        Me.icStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.icStaff.TabIndex = 20
        Me.icStaff.TabStop = False
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnReports.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnReports.FlatAppearance.BorderSize = 2
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.Location = New System.Drawing.Point(16, 679)
        Me.btnReports.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(317, 63)
        Me.btnReports.TabIndex = 19
        Me.btnReports.Text = "Reports"
        Me.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'btnMaintenanceManagement
        '
        Me.btnMaintenanceManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnMaintenanceManagement.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnMaintenanceManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnMaintenanceManagement.FlatAppearance.BorderSize = 2
        Me.btnMaintenanceManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaintenanceManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenanceManagement.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnMaintenanceManagement.Image = CType(resources.GetObject("btnMaintenanceManagement.Image"), System.Drawing.Image)
        Me.btnMaintenanceManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMaintenanceManagement.Location = New System.Drawing.Point(16, 609)
        Me.btnMaintenanceManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMaintenanceManagement.Name = "btnMaintenanceManagement"
        Me.btnMaintenanceManagement.Size = New System.Drawing.Size(317, 63)
        Me.btnMaintenanceManagement.TabIndex = 18
        Me.btnMaintenanceManagement.Text = "Maintenance Management"
        Me.btnMaintenanceManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMaintenanceManagement.UseVisualStyleBackColor = False
        '
        'btnPropertyRequestManagement
        '
        Me.btnPropertyRequestManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnPropertyRequestManagement.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnPropertyRequestManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnPropertyRequestManagement.FlatAppearance.BorderSize = 2
        Me.btnPropertyRequestManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPropertyRequestManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPropertyRequestManagement.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnPropertyRequestManagement.Image = CType(resources.GetObject("btnPropertyRequestManagement.Image"), System.Drawing.Image)
        Me.btnPropertyRequestManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPropertyRequestManagement.Location = New System.Drawing.Point(16, 539)
        Me.btnPropertyRequestManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPropertyRequestManagement.Name = "btnPropertyRequestManagement"
        Me.btnPropertyRequestManagement.Size = New System.Drawing.Size(317, 63)
        Me.btnPropertyRequestManagement.TabIndex = 17
        Me.btnPropertyRequestManagement.Text = "Property Request Management"
        Me.btnPropertyRequestManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPropertyRequestManagement.UseVisualStyleBackColor = False
        '
        'btnDepartmentManagement
        '
        Me.btnDepartmentManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDepartmentManagement.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnDepartmentManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnDepartmentManagement.FlatAppearance.BorderSize = 2
        Me.btnDepartmentManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDepartmentManagement.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnDepartmentManagement.Image = CType(resources.GetObject("btnDepartmentManagement.Image"), System.Drawing.Image)
        Me.btnDepartmentManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDepartmentManagement.Location = New System.Drawing.Point(16, 469)
        Me.btnDepartmentManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDepartmentManagement.Name = "btnDepartmentManagement"
        Me.btnDepartmentManagement.Size = New System.Drawing.Size(317, 63)
        Me.btnDepartmentManagement.TabIndex = 16
        Me.btnDepartmentManagement.Text = "Department Management"
        Me.btnDepartmentManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDepartmentManagement.UseVisualStyleBackColor = False
        '
        'btnSuppliesManagement
        '
        Me.btnSuppliesManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSuppliesManagement.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnSuppliesManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSuppliesManagement.FlatAppearance.BorderSize = 2
        Me.btnSuppliesManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuppliesManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSuppliesManagement.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnSuppliesManagement.Image = CType(resources.GetObject("btnSuppliesManagement.Image"), System.Drawing.Image)
        Me.btnSuppliesManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSuppliesManagement.Location = New System.Drawing.Point(16, 399)
        Me.btnSuppliesManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSuppliesManagement.Name = "btnSuppliesManagement"
        Me.btnSuppliesManagement.Size = New System.Drawing.Size(317, 63)
        Me.btnSuppliesManagement.TabIndex = 15
        Me.btnSuppliesManagement.Text = "Supplies Management"
        Me.btnSuppliesManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSuppliesManagement.UseVisualStyleBackColor = False
        '
        'btnPropertyManagement
        '
        Me.btnPropertyManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnPropertyManagement.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnPropertyManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnPropertyManagement.FlatAppearance.BorderSize = 2
        Me.btnPropertyManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPropertyManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPropertyManagement.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnPropertyManagement.Image = CType(resources.GetObject("btnPropertyManagement.Image"), System.Drawing.Image)
        Me.btnPropertyManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPropertyManagement.Location = New System.Drawing.Point(16, 329)
        Me.btnPropertyManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPropertyManagement.Name = "btnPropertyManagement"
        Me.btnPropertyManagement.Size = New System.Drawing.Size(317, 63)
        Me.btnPropertyManagement.TabIndex = 14
        Me.btnPropertyManagement.Text = "Property Management"
        Me.btnPropertyManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPropertyManagement.UseVisualStyleBackColor = False
        '
        'btnUserManagement
        '
        Me.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnUserManagement.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnUserManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnUserManagement.FlatAppearance.BorderSize = 2
        Me.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUserManagement.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnUserManagement.Image = CType(resources.GetObject("btnUserManagement.Image"), System.Drawing.Image)
        Me.btnUserManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUserManagement.Location = New System.Drawing.Point(16, 258)
        Me.btnUserManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUserManagement.Name = "btnUserManagement"
        Me.btnUserManagement.Size = New System.Drawing.Size(317, 63)
        Me.btnUserManagement.TabIndex = 13
        Me.btnUserManagement.Text = "User Management"
        Me.btnUserManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUserManagement.UseVisualStyleBackColor = False
        '
        'btnDashboard
        '
        Me.btnDashboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDashboard.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnDashboard.FlatAppearance.BorderSize = 2
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboard.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnDashboard.Image = CType(resources.GetObject("btnDashboard.Image"), System.Drawing.Image)
        Me.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.Location = New System.Drawing.Point(16, 188)
        Me.btnDashboard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(317, 63)
        Me.btnDashboard.TabIndex = 12
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'SAChart_TotalProperty
        '
        Me.SAChart_TotalProperty.BackColor = System.Drawing.Color.Transparent
        ChartArea11.Name = "ChartArea1"
        Me.SAChart_TotalProperty.ChartAreas.Add(ChartArea11)
        Legend11.Name = "Legend1"
        Me.SAChart_TotalProperty.Legends.Add(Legend11)
        Me.SAChart_TotalProperty.Location = New System.Drawing.Point(21, 49)
        Me.SAChart_TotalProperty.Name = "SAChart_TotalProperty"
        Series11.ChartArea = "ChartArea1"
        Series11.Legend = "Legend1"
        Series11.Name = "Series1"
        Me.SAChart_TotalProperty.Series.Add(Series11)
        Me.SAChart_TotalProperty.Size = New System.Drawing.Size(362, 165)
        Me.SAChart_TotalProperty.TabIndex = 48
        Me.SAChart_TotalProperty.Text = "Chart1"
        '
        'SAChart_TotalSupplies
        '
        Me.SAChart_TotalSupplies.BackColor = System.Drawing.Color.Transparent
        ChartArea12.Name = "ChartArea1"
        Me.SAChart_TotalSupplies.ChartAreas.Add(ChartArea12)
        Legend12.Name = "Legend1"
        Me.SAChart_TotalSupplies.Legends.Add(Legend12)
        Me.SAChart_TotalSupplies.Location = New System.Drawing.Point(50, 42)
        Me.SAChart_TotalSupplies.Name = "SAChart_TotalSupplies"
        Series12.ChartArea = "ChartArea1"
        Series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100
        Series12.Legend = "Legend1"
        Series12.Name = "Series1"
        Me.SAChart_TotalSupplies.Series.Add(Series12)
        Me.SAChart_TotalSupplies.Size = New System.Drawing.Size(335, 172)
        Me.SAChart_TotalSupplies.TabIndex = 49
        Me.SAChart_TotalSupplies.Text = "Chart2"
        '
        'SAChart_PendingRequest
        '
        ChartArea13.Name = "ChartArea1"
        Me.SAChart_PendingRequest.ChartAreas.Add(ChartArea13)
        Legend13.Name = "Legend1"
        Me.SAChart_PendingRequest.Legends.Add(Legend13)
        Me.SAChart_PendingRequest.Location = New System.Drawing.Point(64, 46)
        Me.SAChart_PendingRequest.Name = "SAChart_PendingRequest"
        Series13.BackImageTransparentColor = System.Drawing.Color.Transparent
        Series13.ChartArea = "ChartArea1"
        Series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series13.LabelForeColor = System.Drawing.Color.BlanchedAlmond
        Series13.Legend = "Legend1"
        Series13.Name = "Series1"
        Me.SAChart_PendingRequest.Series.Add(Series13)
        Me.SAChart_PendingRequest.Size = New System.Drawing.Size(335, 148)
        Me.SAChart_PendingRequest.TabIndex = 50
        Me.SAChart_PendingRequest.Text = "Chart3"
        '
        'SAChart_InventoryStatusOverview
        '
        Me.SAChart_InventoryStatusOverview.BackColor = System.Drawing.Color.Transparent
        ChartArea14.Name = "ChartArea1"
        Me.SAChart_InventoryStatusOverview.ChartAreas.Add(ChartArea14)
        Legend14.Name = "Legend1"
        Me.SAChart_InventoryStatusOverview.Legends.Add(Legend14)
        Me.SAChart_InventoryStatusOverview.Location = New System.Drawing.Point(21, 55)
        Me.SAChart_InventoryStatusOverview.Name = "SAChart_InventoryStatusOverview"
        Series14.ChartArea = "ChartArea1"
        Series14.Legend = "Legend1"
        Series14.Name = "Series1"
        Me.SAChart_InventoryStatusOverview.Series.Add(Series14)
        Me.SAChart_InventoryStatusOverview.Size = New System.Drawing.Size(362, 169)
        Me.SAChart_InventoryStatusOverview.TabIndex = 49
        Me.SAChart_InventoryStatusOverview.Text = "Chart4"
        '
        'SAChart_PropertyConditionStatus
        '
        Me.SAChart_PropertyConditionStatus.BackColor = System.Drawing.Color.Transparent
        ChartArea15.Name = "ChartArea1"
        Me.SAChart_PropertyConditionStatus.ChartAreas.Add(ChartArea15)
        Legend15.Name = "Legend1"
        Me.SAChart_PropertyConditionStatus.Legends.Add(Legend15)
        Me.SAChart_PropertyConditionStatus.Location = New System.Drawing.Point(23, 48)
        Me.SAChart_PropertyConditionStatus.Name = "SAChart_PropertyConditionStatus"
        Series15.ChartArea = "ChartArea1"
        Series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar
        Series15.Legend = "Legend1"
        Series15.Name = "Series1"
        Me.SAChart_PropertyConditionStatus.Series.Add(Series15)
        Me.SAChart_PropertyConditionStatus.Size = New System.Drawing.Size(388, 176)
        Me.SAChart_PropertyConditionStatus.TabIndex = 50
        Me.SAChart_PropertyConditionStatus.Text = "Chart5"
        '
        'SAChart_ScheduleMaintenance
        '
        Me.SAChart_ScheduleMaintenance.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_ScheduleMaintenance.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea16.Name = "ChartArea1"
        Me.SAChart_ScheduleMaintenance.ChartAreas.Add(ChartArea16)
        Legend16.Name = "Legend1"
        Me.SAChart_ScheduleMaintenance.Legends.Add(Legend16)
        Me.SAChart_ScheduleMaintenance.Location = New System.Drawing.Point(64, 62)
        Me.SAChart_ScheduleMaintenance.Name = "SAChart_ScheduleMaintenance"
        Series16.ChartArea = "ChartArea1"
        Series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series16.Legend = "Legend1"
        Series16.Name = "Series1"
        Me.SAChart_ScheduleMaintenance.Series.Add(Series16)
        Me.SAChart_ScheduleMaintenance.Size = New System.Drawing.Size(335, 148)
        Me.SAChart_ScheduleMaintenance.TabIndex = 51
        Me.SAChart_ScheduleMaintenance.Text = "Chart6"
        '
        'SAChart_RecentPropertyRequests
        '
        Me.SAChart_RecentPropertyRequests.BackColor = System.Drawing.Color.Transparent
        ChartArea10.Name = "ChartArea1"
        Me.SAChart_RecentPropertyRequests.ChartAreas.Add(ChartArea10)
        Legend10.Name = "Legend1"
        Me.SAChart_RecentPropertyRequests.Legends.Add(Legend10)
        Me.SAChart_RecentPropertyRequests.Location = New System.Drawing.Point(21, 65)
        Me.SAChart_RecentPropertyRequests.Name = "SAChart_RecentPropertyRequests"
        Series10.ChartArea = "ChartArea1"
        Series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series10.Legend = "Legend1"
        Series10.Name = "Series1"
        Me.SAChart_RecentPropertyRequests.Series.Add(Series10)
        Me.SAChart_RecentPropertyRequests.Size = New System.Drawing.Size(353, 173)
        Me.SAChart_RecentPropertyRequests.TabIndex = 52
        Me.SAChart_RecentPropertyRequests.Text = "Chart7"
        '
        'SAChart_RequestTrends
        '
        Me.SAChart_RequestTrends.BackColor = System.Drawing.Color.Transparent
        ChartArea17.Name = "ChartArea1"
        Me.SAChart_RequestTrends.ChartAreas.Add(ChartArea17)
        Legend17.Name = "Legend1"
        Me.SAChart_RequestTrends.Legends.Add(Legend17)
        Me.SAChart_RequestTrends.Location = New System.Drawing.Point(27, 47)
        Me.SAChart_RequestTrends.Name = "SAChart_RequestTrends"
        Series17.ChartArea = "ChartArea1"
        Series17.Legend = "Legend1"
        Series17.Name = "Series1"
        Me.SAChart_RequestTrends.Series.Add(Series17)
        Me.SAChart_RequestTrends.Size = New System.Drawing.Size(362, 200)
        Me.SAChart_RequestTrends.TabIndex = 53
        Me.SAChart_RequestTrends.Text = "Chart8"
        '
        'SAChart_SystemAlerts
        '
        Me.SAChart_SystemAlerts.BackColor = System.Drawing.Color.Transparent
        ChartArea18.Name = "ChartArea1"
        Me.SAChart_SystemAlerts.ChartAreas.Add(ChartArea18)
        Legend18.Name = "Legend1"
        Me.SAChart_SystemAlerts.Legends.Add(Legend18)
        Me.SAChart_SystemAlerts.Location = New System.Drawing.Point(45, 65)
        Me.SAChart_SystemAlerts.Name = "SAChart_SystemAlerts"
        Series18.ChartArea = "ChartArea1"
        Series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series18.Legend = "Legend1"
        Series18.Name = "Series1"
        Me.SAChart_SystemAlerts.Series.Add(Series18)
        Me.SAChart_SystemAlerts.Size = New System.Drawing.Size(354, 182)
        Me.SAChart_SystemAlerts.TabIndex = 54
        Me.SAChart_SystemAlerts.Text = "Chart9"
        '
        'SADashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1827, 922)
        Me.Controls.Add(Me.pnlFormLoader)
        Me.Controls.Add(Me.icStaff)
        Me.Controls.Add(Me.btnReports)
        Me.Controls.Add(Me.btnMaintenanceManagement)
        Me.Controls.Add(Me.btnPropertyRequestManagement)
        Me.Controls.Add(Me.btnDepartmentManagement)
        Me.Controls.Add(Me.btnSuppliesManagement)
        Me.Controls.Add(Me.btnPropertyManagement)
        Me.Controls.Add(Me.btnUserManagement)
        Me.Controls.Add(Me.btnDashboard)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SADashboard"
        Me.Text = "SADashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        Me.pnlFormLoader.ResumeLayout(False)
        Me.pnlFormLoader.PerformLayout()
        Me.RoundedPanel11.ResumeLayout(False)
        Me.RoundedPanel11.PerformLayout()
        Me.RoundedPanel9.ResumeLayout(False)
        Me.RoundedPanel9.PerformLayout()
        Me.RoundedPanel8.ResumeLayout(False)
        Me.RoundedPanel8.PerformLayout()
        Me.RoundedPanel10.ResumeLayout(False)
        Me.RoundedPanel10.PerformLayout()
        Me.RoundedPanel6.ResumeLayout(False)
        Me.RoundedPanel6.PerformLayout()
        Me.RoundedPanel5.ResumeLayout(False)
        Me.RoundedPanel5.PerformLayout()
        Me.RoundedPanel4.ResumeLayout(False)
        Me.RoundedPanel4.PerformLayout()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents icStaff As PictureBox
    Friend WithEvents btnReports As Button
    Friend WithEvents btnMaintenanceManagement As Button
    Friend WithEvents btnPropertyRequestManagement As Button
    Friend WithEvents btnDepartmentManagement As Button
    Friend WithEvents btnSuppliesManagement As Button
    Friend WithEvents btnPropertyManagement As Button
    Friend WithEvents btnUserManagement As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents lblSuperAdmin As Label
    Friend WithEvents pnlSidebar As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSystemConfig As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlFormLoader As Panel
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents lblPropertyCustodian As Label
    Friend WithEvents btnAddProperty As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents comboFilter As ComboBox
    Friend WithEvents btnAddUser As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents btnGenerateReports As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnAddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents txtboxSearch As TextBox
    Friend WithEvents RoundedPanel11 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel9 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel8 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel10 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel6 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel5 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_SystemAlerts As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_RecentPropertyRequests As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_RequestTrends As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_PropertyConditionStatus As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_InventoryStatusOverview As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_ScheduleMaintenance As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_PendingRequest As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_TotalSupplies As DataVisualization.Charting.Chart
    Friend WithEvents SAChart_TotalProperty As DataVisualization.Charting.Chart
End Class
