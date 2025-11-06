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
        Me.lblSuperAdmin = New System.Windows.Forms.Label()
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlFormLoader = New System.Windows.Forms.Panel()
        Me.RoundedPanel11 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel14 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel13 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel12 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel9 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel8 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel10 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel7 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.btnGenerateReports = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddSupply = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddUser = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddProperty = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.comboFilter = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
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
        Me.btnSystemConfig = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
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
        Me.SuspendLayout()
        '
        'lblTotalProperty
        '
        lblTotalProperty.AutoSize = True
        lblTotalProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalProperty.ForeColor = System.Drawing.Color.White
        lblTotalProperty.Location = New System.Drawing.Point(17, 12)
        lblTotalProperty.Name = "lblTotalProperty"
        lblTotalProperty.Size = New System.Drawing.Size(115, 18)
        lblTotalProperty.TabIndex = 46
        lblTotalProperty.Text = "Total Property"
        '
        'lblTotalSupplies
        '
        lblTotalSupplies.AutoSize = True
        lblTotalSupplies.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalSupplies.ForeColor = System.Drawing.Color.White
        lblTotalSupplies.Location = New System.Drawing.Point(14, 12)
        lblTotalSupplies.Name = "lblTotalSupplies"
        lblTotalSupplies.Size = New System.Drawing.Size(115, 18)
        lblTotalSupplies.TabIndex = 47
        lblTotalSupplies.Text = "Total Supplies"
        '
        'lblPendingRequest
        '
        lblPendingRequest.AutoSize = True
        lblPendingRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPendingRequest.ForeColor = System.Drawing.Color.White
        lblPendingRequest.Location = New System.Drawing.Point(17, 12)
        lblPendingRequest.Name = "lblPendingRequest"
        lblPendingRequest.Size = New System.Drawing.Size(135, 18)
        lblPendingRequest.TabIndex = 48
        lblPendingRequest.Text = "Pending Request"
        '
        'lblScheduleMaintenance
        '
        lblScheduleMaintenance.AutoSize = True
        lblScheduleMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblScheduleMaintenance.ForeColor = System.Drawing.Color.White
        lblScheduleMaintenance.Location = New System.Drawing.Point(13, 12)
        lblScheduleMaintenance.Name = "lblScheduleMaintenance"
        lblScheduleMaintenance.Size = New System.Drawing.Size(177, 18)
        lblScheduleMaintenance.TabIndex = 47
        lblScheduleMaintenance.Text = "Schedule Maintenance"
        '
        'lblInventoryStatusOverview
        '
        lblInventoryStatusOverview.AutoSize = True
        lblInventoryStatusOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblInventoryStatusOverview.ForeColor = System.Drawing.Color.White
        lblInventoryStatusOverview.Location = New System.Drawing.Point(17, 17)
        lblInventoryStatusOverview.Name = "lblInventoryStatusOverview"
        lblInventoryStatusOverview.Size = New System.Drawing.Size(203, 18)
        lblInventoryStatusOverview.TabIndex = 47
        lblInventoryStatusOverview.Text = "Inventory Status Overview"
        '
        'lblPropertyConditionStatus
        '
        lblPropertyConditionStatus.AutoSize = True
        lblPropertyConditionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPropertyConditionStatus.ForeColor = System.Drawing.Color.White
        lblPropertyConditionStatus.Location = New System.Drawing.Point(17, 17)
        lblPropertyConditionStatus.Name = "lblPropertyConditionStatus"
        lblPropertyConditionStatus.Size = New System.Drawing.Size(202, 18)
        lblPropertyConditionStatus.TabIndex = 47
        lblPropertyConditionStatus.Text = "Property Condition Status"
        '
        'lblRequestTrends
        '
        lblRequestTrends.AutoSize = True
        lblRequestTrends.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRequestTrends.ForeColor = System.Drawing.Color.White
        lblRequestTrends.Location = New System.Drawing.Point(17, 7)
        lblRequestTrends.Name = "lblRequestTrends"
        lblRequestTrends.Size = New System.Drawing.Size(127, 18)
        lblRequestTrends.TabIndex = 48
        lblRequestTrends.Text = "Request Trends"
        '
        'lblRecentPRopertyRequests
        '
        lblRecentPRopertyRequests.AutoSize = True
        lblRecentPRopertyRequests.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRecentPRopertyRequests.ForeColor = System.Drawing.Color.White
        lblRecentPRopertyRequests.Location = New System.Drawing.Point(18, 19)
        lblRecentPRopertyRequests.Name = "lblRecentPRopertyRequests"
        lblRecentPRopertyRequests.Size = New System.Drawing.Size(206, 18)
        lblRecentPRopertyRequests.TabIndex = 49
        lblRecentPRopertyRequests.Text = "Recent Property Requests"
        '
        'lblSystemAlerts
        '
        lblSystemAlerts.AutoSize = True
        lblSystemAlerts.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSystemAlerts.ForeColor = System.Drawing.Color.White
        lblSystemAlerts.Location = New System.Drawing.Point(17, 19)
        lblSystemAlerts.Name = "lblSystemAlerts"
        lblSystemAlerts.Size = New System.Drawing.Size(112, 18)
        lblSystemAlerts.TabIndex = 49
        lblSystemAlerts.Text = "System Alerts"
        '
        'lblSuperAdmin
        '
        Me.lblSuperAdmin.AutoSize = True
        Me.lblSuperAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblSuperAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuperAdmin.ForeColor = System.Drawing.Color.White
        Me.lblSuperAdmin.Location = New System.Drawing.Point(80, 118)
        Me.lblSuperAdmin.Name = "lblSuperAdmin"
        Me.lblSuperAdmin.Size = New System.Drawing.Size(90, 16)
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
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(267, 749)
        Me.pnlSidebar.TabIndex = 21
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(269, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1103, 749)
        Me.Panel1.TabIndex = 23
        '
        'pnlFormLoader
        '
        Me.pnlFormLoader.AutoScroll = True
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel11)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel9)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel8)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel10)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel7)
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
        Me.pnlFormLoader.Location = New System.Drawing.Point(302, 12)
        Me.pnlFormLoader.Name = "pnlFormLoader"
        Me.pnlFormLoader.Size = New System.Drawing.Size(1100, 746)
        Me.pnlFormLoader.TabIndex = 22
        '
        'RoundedPanel11
        '
        Me.RoundedPanel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel11.Controls.Add(Me.RoundedPanel14)
        Me.RoundedPanel11.Controls.Add(Me.RoundedPanel13)
        Me.RoundedPanel11.Controls.Add(Me.RoundedPanel12)
        Me.RoundedPanel11.Controls.Add(lblSystemAlerts)
        Me.RoundedPanel11.CornerRadius = 20
        Me.RoundedPanel11.Location = New System.Drawing.Point(562, 700)
        Me.RoundedPanel11.Name = "RoundedPanel11"
        Me.RoundedPanel11.Size = New System.Drawing.Size(520, 253)
        Me.RoundedPanel11.TabIndex = 18
        '
        'RoundedPanel14
        '
        Me.RoundedPanel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel14.CornerRadius = 20
        Me.RoundedPanel14.Location = New System.Drawing.Point(41, 174)
        Me.RoundedPanel14.Name = "RoundedPanel14"
        Me.RoundedPanel14.Size = New System.Drawing.Size(445, 50)
        Me.RoundedPanel14.TabIndex = 51
        '
        'RoundedPanel13
        '
        Me.RoundedPanel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel13.CornerRadius = 20
        Me.RoundedPanel13.Location = New System.Drawing.Point(41, 117)
        Me.RoundedPanel13.Name = "RoundedPanel13"
        Me.RoundedPanel13.Size = New System.Drawing.Size(445, 50)
        Me.RoundedPanel13.TabIndex = 51
        '
        'RoundedPanel12
        '
        Me.RoundedPanel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel12.CornerRadius = 20
        Me.RoundedPanel12.Location = New System.Drawing.Point(41, 59)
        Me.RoundedPanel12.Name = "RoundedPanel12"
        Me.RoundedPanel12.Size = New System.Drawing.Size(445, 50)
        Me.RoundedPanel12.TabIndex = 50
        '
        'RoundedPanel9
        '
        Me.RoundedPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel9.Controls.Add(lblRecentPRopertyRequests)
        Me.RoundedPanel9.CornerRadius = 20
        Me.RoundedPanel9.Location = New System.Drawing.Point(20, 700)
        Me.RoundedPanel9.Name = "RoundedPanel9"
        Me.RoundedPanel9.Size = New System.Drawing.Size(520, 253)
        Me.RoundedPanel9.TabIndex = 17
        '
        'RoundedPanel8
        '
        Me.RoundedPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel8.Controls.Add(lblRequestTrends)
        Me.RoundedPanel8.CornerRadius = 20
        Me.RoundedPanel8.Location = New System.Drawing.Point(21, 575)
        Me.RoundedPanel8.Name = "RoundedPanel8"
        Me.RoundedPanel8.Size = New System.Drawing.Size(1061, 109)
        Me.RoundedPanel8.TabIndex = 17
        '
        'RoundedPanel10
        '
        Me.RoundedPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel10.Controls.Add(lblPropertyConditionStatus)
        Me.RoundedPanel10.CornerRadius = 20
        Me.RoundedPanel10.Location = New System.Drawing.Point(562, 304)
        Me.RoundedPanel10.Name = "RoundedPanel10"
        Me.RoundedPanel10.Size = New System.Drawing.Size(520, 253)
        Me.RoundedPanel10.TabIndex = 17
        '
        'RoundedPanel7
        '
        Me.RoundedPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel7.CornerRadius = 20
        Me.RoundedPanel7.Location = New System.Drawing.Point(562, 304)
        Me.RoundedPanel7.Name = "RoundedPanel7"
        Me.RoundedPanel7.Size = New System.Drawing.Size(520, 253)
        Me.RoundedPanel7.TabIndex = 17
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel6.Controls.Add(lblInventoryStatusOverview)
        Me.RoundedPanel6.CornerRadius = 20
        Me.RoundedPanel6.Location = New System.Drawing.Point(21, 304)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(520, 253)
        Me.RoundedPanel6.TabIndex = 16
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel5.Controls.Add(lblScheduleMaintenance)
        Me.RoundedPanel5.CornerRadius = 20
        Me.RoundedPanel5.Location = New System.Drawing.Point(829, 138)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(251, 150)
        Me.RoundedPanel5.TabIndex = 16
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel4.Controls.Add(lblPendingRequest)
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(562, 138)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(251, 150)
        Me.RoundedPanel4.TabIndex = 15
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel3.Controls.Add(lblTotalSupplies)
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(290, 138)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(251, 150)
        Me.RoundedPanel3.TabIndex = 15
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel2.Controls.Add(lblTotalProperty)
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(21, 138)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(251, 150)
        Me.RoundedPanel2.TabIndex = 14
        '
        'btnGenerateReports
        '
        Me.btnGenerateReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateReports.CornerRadius = 15
        Me.btnGenerateReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReports.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateReports.Location = New System.Drawing.Point(943, 63)
        Me.btnGenerateReports.Name = "btnGenerateReports"
        Me.btnGenerateReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnGenerateReports.Size = New System.Drawing.Size(137, 29)
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
        Me.btnAddSupply.Location = New System.Drawing.Point(651, 63)
        Me.btnAddSupply.Name = "btnAddSupply"
        Me.btnAddSupply.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddSupply.Size = New System.Drawing.Size(116, 29)
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
        Me.btnAddUser.Location = New System.Drawing.Point(797, 63)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddUser.Size = New System.Drawing.Size(116, 29)
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
        Me.btnAddProperty.Location = New System.Drawing.Point(505, 63)
        Me.btnAddProperty.Name = "btnAddProperty"
        Me.btnAddProperty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddProperty.Size = New System.Drawing.Size(116, 29)
        Me.btnAddProperty.TabIndex = 10
        Me.btnAddProperty.Text = "Add Property"
        Me.btnAddProperty.UseVisualStyleBackColor = False
        '
        'comboFilter
        '
        Me.comboFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboFilter.FormattingEnabled = True
        Me.comboFilter.Location = New System.Drawing.Point(335, 67)
        Me.comboFilter.Name = "comboFilter"
        Me.comboFilter.Size = New System.Drawing.Size(131, 21)
        Me.comboFilter.TabIndex = 9
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.txtboxSearch)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Location = New System.Drawing.Point(21, 60)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(287, 36)
        Me.RoundedPanel1.TabIndex = 8
        '
        'txtboxSearch
        '
        Me.txtboxSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.txtboxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxSearch.Location = New System.Drawing.Point(29, 12)
        Me.txtboxSearch.Name = "txtboxSearch"
        Me.txtboxSearch.Size = New System.Drawing.Size(241, 13)
        Me.txtboxSearch.TabIndex = 14
        '
        'lblPropertyCustodian
        '
        Me.lblPropertyCustodian.AutoSize = True
        Me.lblPropertyCustodian.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCustodian.Location = New System.Drawing.Point(16, 16)
        Me.lblPropertyCustodian.Name = "lblPropertyCustodian"
        Me.lblPropertyCustodian.Size = New System.Drawing.Size(214, 25)
        Me.lblPropertyCustodian.TabIndex = 7
        Me.lblPropertyCustodian.Text = "Property Custodian"
        '
        'icStaff
        '
        Me.icStaff.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.icStaff.Image = CType(resources.GetObject("icStaff.Image"), System.Drawing.Image)
        Me.icStaff.Location = New System.Drawing.Point(74, 32)
        Me.icStaff.Name = "icStaff"
        Me.icStaff.Size = New System.Drawing.Size(97, 83)
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
        Me.btnReports.Location = New System.Drawing.Point(12, 552)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(238, 51)
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
        Me.btnMaintenanceManagement.Location = New System.Drawing.Point(12, 495)
        Me.btnMaintenanceManagement.Name = "btnMaintenanceManagement"
        Me.btnMaintenanceManagement.Size = New System.Drawing.Size(238, 51)
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
        Me.btnPropertyRequestManagement.Location = New System.Drawing.Point(12, 438)
        Me.btnPropertyRequestManagement.Name = "btnPropertyRequestManagement"
        Me.btnPropertyRequestManagement.Size = New System.Drawing.Size(238, 51)
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
        Me.btnDepartmentManagement.Location = New System.Drawing.Point(12, 381)
        Me.btnDepartmentManagement.Name = "btnDepartmentManagement"
        Me.btnDepartmentManagement.Size = New System.Drawing.Size(238, 51)
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
        Me.btnSuppliesManagement.Location = New System.Drawing.Point(12, 324)
        Me.btnSuppliesManagement.Name = "btnSuppliesManagement"
        Me.btnSuppliesManagement.Size = New System.Drawing.Size(238, 51)
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
        Me.btnPropertyManagement.Location = New System.Drawing.Point(12, 267)
        Me.btnPropertyManagement.Name = "btnPropertyManagement"
        Me.btnPropertyManagement.Size = New System.Drawing.Size(238, 51)
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
        Me.btnUserManagement.Location = New System.Drawing.Point(12, 210)
        Me.btnUserManagement.Name = "btnUserManagement"
        Me.btnUserManagement.Size = New System.Drawing.Size(238, 51)
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
        Me.btnDashboard.Location = New System.Drawing.Point(12, 153)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(238, 51)
        Me.btnDashboard.TabIndex = 12
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDashboard.UseVisualStyleBackColor = False
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
        Me.btnSystemConfig.Location = New System.Drawing.Point(12, 609)
        Me.btnSystemConfig.Name = "btnSystemConfig"
        Me.btnSystemConfig.Size = New System.Drawing.Size(238, 51)
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
        Me.btnLogout.Location = New System.Drawing.Point(12, 666)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(238, 51)
        Me.btnLogout.TabIndex = 22
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'SADashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1370, 749)
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
    Friend WithEvents RoundedPanel7 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel6 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel5 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel14 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel13 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel12 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
End Class
