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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SADashboard))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblRecentPRopertyRequests As System.Windows.Forms.Label
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblScheduleMaintenance As System.Windows.Forms.Label
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblPropertyConditionStatus As System.Windows.Forms.Label
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblInventoryStatusOverview As System.Windows.Forms.Label
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblPendingRequest As System.Windows.Forms.Label
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblTotalSupplies As System.Windows.Forms.Label
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblTotalProperty As System.Windows.Forms.Label
        Dim ChartArea8 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend8 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblRequestTrends As System.Windows.Forms.Label
        Dim ChartArea9 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend9 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim lblSystemAlerts As System.Windows.Forms.Label
        Me.pnlFormLoader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RoundedPanel9 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_RecentPropertyRequests = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_ScheduleMaintenance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel10 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_PropertyConditionStatus = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_InventoryStatusOverview = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_PendingRequest = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_TotalSupplies = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_TotalProperty = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel8 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_RequestTrends = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel11 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAChart_SystemAlerts = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtboxSearch = New System.Windows.Forms.TextBox()
        Me.comboFilter = New System.Windows.Forms.ComboBox()
        Me.btnAddProperty = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddUser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnGenerateReports = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.btnSystemConfig = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSuperAdmin = New System.Windows.Forms.Label()
        lblRecentPRopertyRequests = New System.Windows.Forms.Label()
        lblScheduleMaintenance = New System.Windows.Forms.Label()
        lblPropertyConditionStatus = New System.Windows.Forms.Label()
        lblInventoryStatusOverview = New System.Windows.Forms.Label()
        lblPendingRequest = New System.Windows.Forms.Label()
        lblTotalSupplies = New System.Windows.Forms.Label()
        lblTotalProperty = New System.Windows.Forms.Label()
        lblRequestTrends = New System.Windows.Forms.Label()
        lblSystemAlerts = New System.Windows.Forms.Label()
        Me.pnlFormLoader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.RoundedPanel9.SuspendLayout()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel5.SuspendLayout()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel10.SuspendLayout()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel6.SuspendLayout()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel4.SuspendLayout()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel3.SuspendLayout()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel2.SuspendLayout()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel8.SuspendLayout()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel11.SuspendLayout()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFormLoader
        '
        Me.pnlFormLoader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFormLoader.AutoScroll = True
        Me.pnlFormLoader.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.pnlFormLoader.Controls.Add(Me.Panel2)
        Me.pnlFormLoader.Controls.Add(Me.lblPropertyCustodian)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel1)
        Me.pnlFormLoader.Location = New System.Drawing.Point(356, 0)
        Me.pnlFormLoader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlFormLoader.Name = "pnlFormLoader"
        Me.pnlFormLoader.Size = New System.Drawing.Size(1920, 1080)
        Me.pnlFormLoader.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Location = New System.Drawing.Point(28, 145)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1397, 746)
        Me.Panel2.TabIndex = 19
        '
        'lblPropertyCustodian
        '
        Me.lblPropertyCustodian.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCustodian.AutoSize = True
        Me.lblPropertyCustodian.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCustodian.Location = New System.Drawing.Point(25, 28)
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
        Me.icStaff.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnReports.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnMaintenanceManagement.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnPropertyRequestManagement.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnDepartmentManagement.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnSuppliesManagement.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnPropertyManagement.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnUserManagement.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnDashboard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(317, 63)
        Me.btnDashboard.TabIndex = 12
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.67841!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.32159!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 459.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel9, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel10, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel8, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel11, 2, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.4725!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.5275!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1385, 734)
        Me.TableLayoutPanel1.TabIndex = 28
        '
        'RoundedPanel9
        '
        Me.RoundedPanel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel9.BackColor = System.Drawing.Color.White
        Me.RoundedPanel9.Controls.Add(Me.SAChart_RecentPropertyRequests)
        Me.RoundedPanel9.Controls.Add(lblRecentPRopertyRequests)
        Me.RoundedPanel9.CornerRadius = 5
        Me.RoundedPanel9.Location = New System.Drawing.Point(4, 495)
        Me.RoundedPanel9.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel9.Name = "RoundedPanel9"
        Me.RoundedPanel9.Size = New System.Drawing.Size(442, 235)
        Me.RoundedPanel9.TabIndex = 35
        '
        'SAChart_RecentPropertyRequests
        '
        Me.SAChart_RecentPropertyRequests.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.SAChart_RecentPropertyRequests.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.SAChart_RecentPropertyRequests.Legends.Add(Legend1)
        Me.SAChart_RecentPropertyRequests.Location = New System.Drawing.Point(30, 59)
        Me.SAChart_RecentPropertyRequests.Name = "SAChart_RecentPropertyRequests"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.SAChart_RecentPropertyRequests.Series.Add(Series1)
        Me.SAChart_RecentPropertyRequests.Size = New System.Drawing.Size(353, 173)
        Me.SAChart_RecentPropertyRequests.TabIndex = 52
        Me.SAChart_RecentPropertyRequests.Text = "Chart7"
        '
        'lblRecentPRopertyRequests
        '
        lblRecentPRopertyRequests.AutoSize = True
        lblRecentPRopertyRequests.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRecentPRopertyRequests.ForeColor = System.Drawing.Color.Black
        lblRecentPRopertyRequests.Location = New System.Drawing.Point(24, 23)
        lblRecentPRopertyRequests.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblRecentPRopertyRequests.Name = "lblRecentPRopertyRequests"
        lblRecentPRopertyRequests.Size = New System.Drawing.Size(253, 24)
        lblRecentPRopertyRequests.TabIndex = 49
        lblRecentPRopertyRequests.Text = "Recent Property Requests"
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel5.BackColor = System.Drawing.Color.White
        Me.RoundedPanel5.Controls.Add(Me.SAChart_ScheduleMaintenance)
        Me.RoundedPanel5.Controls.Add(lblScheduleMaintenance)
        Me.RoundedPanel5.CornerRadius = 5
        Me.RoundedPanel5.Location = New System.Drawing.Point(929, 242)
        Me.RoundedPanel5.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(452, 245)
        Me.RoundedPanel5.TabIndex = 28
        '
        'SAChart_ScheduleMaintenance
        '
        Me.SAChart_ScheduleMaintenance.BackColor = System.Drawing.Color.Transparent
        Me.SAChart_ScheduleMaintenance.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.SAChart_ScheduleMaintenance.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.SAChart_ScheduleMaintenance.Legends.Add(Legend2)
        Me.SAChart_ScheduleMaintenance.Location = New System.Drawing.Point(64, 62)
        Me.SAChart_ScheduleMaintenance.Name = "SAChart_ScheduleMaintenance"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.SAChart_ScheduleMaintenance.Series.Add(Series2)
        Me.SAChart_ScheduleMaintenance.Size = New System.Drawing.Size(335, 148)
        Me.SAChart_ScheduleMaintenance.TabIndex = 51
        Me.SAChart_ScheduleMaintenance.Text = "Chart6"
        '
        'lblScheduleMaintenance
        '
        lblScheduleMaintenance.AutoSize = True
        lblScheduleMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblScheduleMaintenance.ForeColor = System.Drawing.Color.Black
        lblScheduleMaintenance.Location = New System.Drawing.Point(23, 28)
        lblScheduleMaintenance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblScheduleMaintenance.Name = "lblScheduleMaintenance"
        lblScheduleMaintenance.Size = New System.Drawing.Size(225, 24)
        lblScheduleMaintenance.TabIndex = 47
        lblScheduleMaintenance.Text = "Schedule Maintenance"
        '
        'RoundedPanel10
        '
        Me.RoundedPanel10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel10.BackColor = System.Drawing.Color.White
        Me.RoundedPanel10.Controls.Add(Me.SAChart_PropertyConditionStatus)
        Me.RoundedPanel10.Controls.Add(lblPropertyConditionStatus)
        Me.RoundedPanel10.CornerRadius = 5
        Me.RoundedPanel10.Location = New System.Drawing.Point(454, 242)
        Me.RoundedPanel10.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel10.Name = "RoundedPanel10"
        Me.RoundedPanel10.Size = New System.Drawing.Size(467, 245)
        Me.RoundedPanel10.TabIndex = 27
        '
        'SAChart_PropertyConditionStatus
        '
        Me.SAChart_PropertyConditionStatus.BackColor = System.Drawing.Color.Transparent
        ChartArea3.Name = "ChartArea1"
        Me.SAChart_PropertyConditionStatus.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.SAChart_PropertyConditionStatus.Legends.Add(Legend3)
        Me.SAChart_PropertyConditionStatus.Location = New System.Drawing.Point(23, 48)
        Me.SAChart_PropertyConditionStatus.Name = "SAChart_PropertyConditionStatus"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.SAChart_PropertyConditionStatus.Series.Add(Series3)
        Me.SAChart_PropertyConditionStatus.Size = New System.Drawing.Size(388, 176)
        Me.SAChart_PropertyConditionStatus.TabIndex = 50
        Me.SAChart_PropertyConditionStatus.Text = "Chart5"
        '
        'lblPropertyConditionStatus
        '
        lblPropertyConditionStatus.AutoSize = True
        lblPropertyConditionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPropertyConditionStatus.ForeColor = System.Drawing.Color.Black
        lblPropertyConditionStatus.Location = New System.Drawing.Point(23, 21)
        lblPropertyConditionStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPropertyConditionStatus.Name = "lblPropertyConditionStatus"
        lblPropertyConditionStatus.Size = New System.Drawing.Size(245, 24)
        lblPropertyConditionStatus.TabIndex = 47
        lblPropertyConditionStatus.Text = "Property Condition Status"
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel6.BackColor = System.Drawing.Color.White
        Me.RoundedPanel6.Controls.Add(Me.SAChart_InventoryStatusOverview)
        Me.RoundedPanel6.Controls.Add(lblInventoryStatusOverview)
        Me.RoundedPanel6.CornerRadius = 5
        Me.RoundedPanel6.Location = New System.Drawing.Point(4, 242)
        Me.RoundedPanel6.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(442, 245)
        Me.RoundedPanel6.TabIndex = 24
        '
        'SAChart_InventoryStatusOverview
        '
        Me.SAChart_InventoryStatusOverview.BackColor = System.Drawing.Color.Transparent
        ChartArea4.Name = "ChartArea1"
        Me.SAChart_InventoryStatusOverview.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.SAChart_InventoryStatusOverview.Legends.Add(Legend4)
        Me.SAChart_InventoryStatusOverview.Location = New System.Drawing.Point(21, 55)
        Me.SAChart_InventoryStatusOverview.Name = "SAChart_InventoryStatusOverview"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.SAChart_InventoryStatusOverview.Series.Add(Series4)
        Me.SAChart_InventoryStatusOverview.Size = New System.Drawing.Size(362, 169)
        Me.SAChart_InventoryStatusOverview.TabIndex = 49
        Me.SAChart_InventoryStatusOverview.Text = "Chart4"
        '
        'lblInventoryStatusOverview
        '
        lblInventoryStatusOverview.AutoSize = True
        lblInventoryStatusOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblInventoryStatusOverview.ForeColor = System.Drawing.Color.Black
        lblInventoryStatusOverview.Location = New System.Drawing.Point(23, 21)
        lblInventoryStatusOverview.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblInventoryStatusOverview.Name = "lblInventoryStatusOverview"
        lblInventoryStatusOverview.Size = New System.Drawing.Size(250, 24)
        lblInventoryStatusOverview.TabIndex = 47
        lblInventoryStatusOverview.Text = "Inventory Status Overview"
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel4.BackColor = System.Drawing.Color.White
        Me.RoundedPanel4.Controls.Add(Me.SAChart_PendingRequest)
        Me.RoundedPanel4.Controls.Add(lblPendingRequest)
        Me.RoundedPanel4.CornerRadius = 5
        Me.RoundedPanel4.Location = New System.Drawing.Point(929, 4)
        Me.RoundedPanel4.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(452, 230)
        Me.RoundedPanel4.TabIndex = 23
        '
        'SAChart_PendingRequest
        '
        ChartArea5.Name = "ChartArea1"
        Me.SAChart_PendingRequest.ChartAreas.Add(ChartArea5)
        Legend5.Name = "Legend1"
        Me.SAChart_PendingRequest.Legends.Add(Legend5)
        Me.SAChart_PendingRequest.Location = New System.Drawing.Point(64, 46)
        Me.SAChart_PendingRequest.Name = "SAChart_PendingRequest"
        Series5.BackImageTransparentColor = System.Drawing.Color.Transparent
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series5.LabelForeColor = System.Drawing.Color.BlanchedAlmond
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        Me.SAChart_PendingRequest.Series.Add(Series5)
        Me.SAChart_PendingRequest.Size = New System.Drawing.Size(335, 148)
        Me.SAChart_PendingRequest.TabIndex = 50
        Me.SAChart_PendingRequest.Text = "Chart3"
        '
        'lblPendingRequest
        '
        lblPendingRequest.AutoSize = True
        lblPendingRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPendingRequest.ForeColor = System.Drawing.Color.Black
        lblPendingRequest.Location = New System.Drawing.Point(23, 15)
        lblPendingRequest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblPendingRequest.Name = "lblPendingRequest"
        lblPendingRequest.Size = New System.Drawing.Size(171, 24)
        lblPendingRequest.TabIndex = 48
        lblPendingRequest.Text = "Pending Request"
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel3.BackColor = System.Drawing.Color.White
        Me.RoundedPanel3.Controls.Add(Me.SAChart_TotalSupplies)
        Me.RoundedPanel3.Controls.Add(lblTotalSupplies)
        Me.RoundedPanel3.CornerRadius = 5
        Me.RoundedPanel3.Location = New System.Drawing.Point(454, 4)
        Me.RoundedPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(467, 230)
        Me.RoundedPanel3.TabIndex = 22
        '
        'SAChart_TotalSupplies
        '
        Me.SAChart_TotalSupplies.BackColor = System.Drawing.Color.Transparent
        ChartArea6.Name = "ChartArea1"
        Me.SAChart_TotalSupplies.ChartAreas.Add(ChartArea6)
        Legend6.Name = "Legend1"
        Me.SAChart_TotalSupplies.Legends.Add(Legend6)
        Me.SAChart_TotalSupplies.Location = New System.Drawing.Point(50, 42)
        Me.SAChart_TotalSupplies.Name = "SAChart_TotalSupplies"
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100
        Series6.Legend = "Legend1"
        Series6.Name = "Series1"
        Me.SAChart_TotalSupplies.Series.Add(Series6)
        Me.SAChart_TotalSupplies.Size = New System.Drawing.Size(335, 172)
        Me.SAChart_TotalSupplies.TabIndex = 49
        Me.SAChart_TotalSupplies.Text = "Chart2"
        '
        'lblTotalSupplies
        '
        lblTotalSupplies.AutoSize = True
        lblTotalSupplies.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalSupplies.ForeColor = System.Drawing.Color.Black
        lblTotalSupplies.Location = New System.Drawing.Point(19, 15)
        lblTotalSupplies.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalSupplies.Name = "lblTotalSupplies"
        lblTotalSupplies.Size = New System.Drawing.Size(143, 24)
        lblTotalSupplies.TabIndex = 47
        lblTotalSupplies.Text = "Total Supplies"
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.BackColor = System.Drawing.Color.White
        Me.RoundedPanel2.Controls.Add(Me.SAChart_TotalProperty)
        Me.RoundedPanel2.Controls.Add(lblTotalProperty)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(4, 4)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(442, 230)
        Me.RoundedPanel2.TabIndex = 20
        '
        'SAChart_TotalProperty
        '
        Me.SAChart_TotalProperty.BackColor = System.Drawing.Color.Transparent
        ChartArea7.Name = "ChartArea1"
        Me.SAChart_TotalProperty.ChartAreas.Add(ChartArea7)
        Legend7.Name = "Legend1"
        Me.SAChart_TotalProperty.Legends.Add(Legend7)
        Me.SAChart_TotalProperty.Location = New System.Drawing.Point(21, 49)
        Me.SAChart_TotalProperty.Name = "SAChart_TotalProperty"
        Series7.ChartArea = "ChartArea1"
        Series7.Legend = "Legend1"
        Series7.Name = "Series1"
        Me.SAChart_TotalProperty.Series.Add(Series7)
        Me.SAChart_TotalProperty.Size = New System.Drawing.Size(362, 165)
        Me.SAChart_TotalProperty.TabIndex = 48
        Me.SAChart_TotalProperty.Text = "Chart1"
        '
        'lblTotalProperty
        '
        lblTotalProperty.AutoSize = True
        lblTotalProperty.BackColor = System.Drawing.Color.Transparent
        lblTotalProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTotalProperty.ForeColor = System.Drawing.Color.Black
        lblTotalProperty.Location = New System.Drawing.Point(23, 15)
        lblTotalProperty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblTotalProperty.Name = "lblTotalProperty"
        lblTotalProperty.Size = New System.Drawing.Size(140, 24)
        lblTotalProperty.TabIndex = 46
        lblTotalProperty.Text = "Total Property"
        '
        'RoundedPanel8
        '
        Me.RoundedPanel8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel8.BackColor = System.Drawing.Color.White
        Me.RoundedPanel8.Controls.Add(Me.SAChart_RequestTrends)
        Me.RoundedPanel8.Controls.Add(lblRequestTrends)
        Me.RoundedPanel8.CornerRadius = 5
        Me.RoundedPanel8.Location = New System.Drawing.Point(454, 495)
        Me.RoundedPanel8.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel8.Name = "RoundedPanel8"
        Me.RoundedPanel8.Size = New System.Drawing.Size(467, 235)
        Me.RoundedPanel8.TabIndex = 30
        '
        'SAChart_RequestTrends
        '
        Me.SAChart_RequestTrends.BackColor = System.Drawing.Color.Transparent
        ChartArea8.Name = "ChartArea1"
        Me.SAChart_RequestTrends.ChartAreas.Add(ChartArea8)
        Legend8.Name = "Legend1"
        Me.SAChart_RequestTrends.Legends.Add(Legend8)
        Me.SAChart_RequestTrends.Location = New System.Drawing.Point(27, 47)
        Me.SAChart_RequestTrends.Name = "SAChart_RequestTrends"
        Series8.ChartArea = "ChartArea1"
        Series8.Legend = "Legend1"
        Series8.Name = "Series1"
        Me.SAChart_RequestTrends.Series.Add(Series8)
        Me.SAChart_RequestTrends.Size = New System.Drawing.Size(362, 185)
        Me.SAChart_RequestTrends.TabIndex = 53
        Me.SAChart_RequestTrends.Text = "Chart8"
        '
        'lblRequestTrends
        '
        lblRequestTrends.AutoSize = True
        lblRequestTrends.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRequestTrends.ForeColor = System.Drawing.Color.Black
        lblRequestTrends.Location = New System.Drawing.Point(23, 23)
        lblRequestTrends.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblRequestTrends.Name = "lblRequestTrends"
        lblRequestTrends.Size = New System.Drawing.Size(159, 24)
        lblRequestTrends.TabIndex = 48
        lblRequestTrends.Text = "Request Trends"
        '
        'RoundedPanel11
        '
        Me.RoundedPanel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel11.BackColor = System.Drawing.Color.White
        Me.RoundedPanel11.Controls.Add(Me.SAChart_SystemAlerts)
        Me.RoundedPanel11.Controls.Add(lblSystemAlerts)
        Me.RoundedPanel11.CornerRadius = 5
        Me.RoundedPanel11.Location = New System.Drawing.Point(930, 495)
        Me.RoundedPanel11.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel11.Name = "RoundedPanel11"
        Me.RoundedPanel11.Size = New System.Drawing.Size(451, 235)
        Me.RoundedPanel11.TabIndex = 34
        '
        'SAChart_SystemAlerts
        '
        Me.SAChart_SystemAlerts.BackColor = System.Drawing.Color.Transparent
        ChartArea9.Name = "ChartArea1"
        Me.SAChart_SystemAlerts.ChartAreas.Add(ChartArea9)
        Legend9.Name = "Legend1"
        Me.SAChart_SystemAlerts.Legends.Add(Legend9)
        Me.SAChart_SystemAlerts.Location = New System.Drawing.Point(45, 50)
        Me.SAChart_SystemAlerts.Name = "SAChart_SystemAlerts"
        Series9.ChartArea = "ChartArea1"
        Series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series9.Legend = "Legend1"
        Series9.Name = "Series1"
        Me.SAChart_SystemAlerts.Series.Add(Series9)
        Me.SAChart_SystemAlerts.Size = New System.Drawing.Size(354, 182)
        Me.SAChart_SystemAlerts.TabIndex = 54
        Me.SAChart_SystemAlerts.Text = "Chart9"
        '
        'lblSystemAlerts
        '
        lblSystemAlerts.AutoSize = True
        lblSystemAlerts.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSystemAlerts.ForeColor = System.Drawing.Color.Black
        lblSystemAlerts.Location = New System.Drawing.Point(23, 23)
        lblSystemAlerts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblSystemAlerts.Name = "lblSystemAlerts"
        lblSystemAlerts.Size = New System.Drawing.Size(136, 24)
        lblSystemAlerts.TabIndex = 49
        lblSystemAlerts.Text = "System Alerts"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.PictureBox1)
        Me.RoundedPanel1.Controls.Add(Me.txtboxSearch)
        Me.RoundedPanel1.Controls.Add(Me.comboFilter)
        Me.RoundedPanel1.Controls.Add(Me.btnAddProperty)
        Me.RoundedPanel1.Controls.Add(Me.btnAddSupply)
        Me.RoundedPanel1.Controls.Add(Me.btnAddUser)
        Me.RoundedPanel1.Controls.Add(Me.btnGenerateReports)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Location = New System.Drawing.Point(28, 78)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1397, 51)
        Me.RoundedPanel1.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search
        Me.PictureBox1.Location = New System.Drawing.Point(13, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'txtboxSearch
        '
        Me.txtboxSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.txtboxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxSearch.Location = New System.Drawing.Point(61, 21)
        Me.txtboxSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtboxSearch.Name = "txtboxSearch"
        Me.txtboxSearch.Size = New System.Drawing.Size(321, 15)
        Me.txtboxSearch.TabIndex = 14
        '
        'comboFilter
        '
        Me.comboFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboFilter.FormattingEnabled = True
        Me.comboFilter.Location = New System.Drawing.Point(406, 16)
        Me.comboFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.comboFilter.Name = "comboFilter"
        Me.comboFilter.Size = New System.Drawing.Size(173, 24)
        Me.comboFilter.TabIndex = 9
        '
        'btnAddProperty
        '
        Me.btnAddProperty.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAddProperty.CornerRadius = 5
        Me.btnAddProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProperty.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddProperty.Location = New System.Drawing.Point(618, 8)
        Me.btnAddProperty.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddProperty.Name = "btnAddProperty"
        Me.btnAddProperty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddProperty.Size = New System.Drawing.Size(155, 36)
        Me.btnAddProperty.TabIndex = 10
        Me.btnAddProperty.Text = "Add Property"
        Me.btnAddProperty.UseVisualStyleBackColor = False
        '
        'btnAddSupply
        '
        Me.btnAddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAddSupply.CornerRadius = 5
        Me.btnAddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSupply.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddSupply.Location = New System.Drawing.Point(815, 8)
        Me.btnAddSupply.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnAddUser.CornerRadius = 5
        Me.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddUser.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddUser.Location = New System.Drawing.Point(1008, 8)
        Me.btnAddUser.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAddUser.Size = New System.Drawing.Size(155, 36)
        Me.btnAddUser.TabIndex = 11
        Me.btnAddUser.Text = "Add User"
        Me.btnAddUser.UseVisualStyleBackColor = False
        '
        'btnGenerateReports
        '
        Me.btnGenerateReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateReports.CornerRadius = 5
        Me.btnGenerateReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReports.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateReports.Location = New System.Drawing.Point(1199, 8)
        Me.btnGenerateReports.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerateReports.Name = "btnGenerateReports"
        Me.btnGenerateReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnGenerateReports.Size = New System.Drawing.Size(183, 36)
        Me.btnGenerateReports.TabIndex = 13
        Me.btnGenerateReports.Text = "Generate Reports"
        Me.btnGenerateReports.UseVisualStyleBackColor = False
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnSystemConfig)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.Panel1)
        Me.pnlSidebar.Controls.Add(Me.lblSuperAdmin)
        Me.pnlSidebar.CornerRadius = 2
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnSystemConfig.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(4)
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1471, 922)
        Me.Panel1.TabIndex = 23
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
        'SADashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SADashboard"
        Me.Text = "SADashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlFormLoader.ResumeLayout(False)
        Me.pnlFormLoader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.RoundedPanel9.ResumeLayout(False)
        Me.RoundedPanel9.PerformLayout()
        CType(Me.SAChart_RecentPropertyRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel5.ResumeLayout(False)
        Me.RoundedPanel5.PerformLayout()
        CType(Me.SAChart_ScheduleMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel10.ResumeLayout(False)
        Me.RoundedPanel10.PerformLayout()
        CType(Me.SAChart_PropertyConditionStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel6.ResumeLayout(False)
        Me.RoundedPanel6.PerformLayout()
        CType(Me.SAChart_InventoryStatusOverview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel4.ResumeLayout(False)
        Me.RoundedPanel4.PerformLayout()
        CType(Me.SAChart_PendingRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        CType(Me.SAChart_TotalSupplies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        CType(Me.SAChart_TotalProperty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel8.ResumeLayout(False)
        Me.RoundedPanel8.PerformLayout()
        CType(Me.SAChart_RequestTrends, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel11.ResumeLayout(False)
        Me.RoundedPanel11.PerformLayout()
        CType(Me.SAChart_SystemAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
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
    Friend WithEvents btnGenerateReports As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnAddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents txtboxSearch As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RoundedPanel3 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_TotalSupplies As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_TotalProperty As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel8 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_RequestTrends As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel5 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_ScheduleMaintenance As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel10 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_PropertyConditionStatus As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel6 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_InventoryStatusOverview As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel4 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_PendingRequest As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel11 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_SystemAlerts As DataVisualization.Charting.Chart
    Friend WithEvents RoundedPanel9 As Resources.Controls.RoundedPanel
    Friend WithEvents SAChart_RecentPropertyRequests As DataVisualization.Charting.Chart
End Class
