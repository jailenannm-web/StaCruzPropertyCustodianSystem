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
        Me.admin_PanelSidebar = New System.Windows.Forms.Panel()
        Me.admin_btn_Logout = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_SystemConfiguration = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        Me.admin_PanelHeader = New System.Windows.Forms.Panel()
        Me.admin_label_Dashboard = New System.Windows.Forms.Label()
        Me.admin_PanelMain = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.admin_btn_NeedsRepair = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_Borrowed = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_PendingRequests = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_properties = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.admin_txtbox_search = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.admin_PanelSidebar.SuspendLayout()
        CType(Me.admin_picProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.admin_PanelHeader.SuspendLayout()
        Me.admin_PanelMain.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_PanelSidebar
        '
        Me.admin_PanelSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_Logout)
        Me.admin_PanelSidebar.Controls.Add(Me.admin_btn_SystemConfiguration)
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
        Me.admin_PanelSidebar.Name = "admin_PanelSidebar"
        Me.admin_PanelSidebar.Size = New System.Drawing.Size(240, 891)
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
        Me.admin_btn_Logout.Location = New System.Drawing.Point(18, 790)
        Me.admin_btn_Logout.Name = "admin_btn_Logout"
        Me.admin_btn_Logout.Size = New System.Drawing.Size(204, 47)
        Me.admin_btn_Logout.TabIndex = 10
        Me.admin_btn_Logout.Text = "Logout"
        Me.admin_btn_Logout.UseVisualStyleBackColor = False
        '
        'admin_btn_SystemConfiguration
        '
        Me.admin_btn_SystemConfiguration.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_SystemConfiguration.CornerRadius = 15
        Me.admin_btn_SystemConfiguration.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_SystemConfiguration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_SystemConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_SystemConfiguration.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_SystemConfiguration.ForeColor = System.Drawing.Color.White
        Me.admin_btn_SystemConfiguration.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_SystemConfiguration
        Me.admin_btn_SystemConfiguration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_SystemConfiguration.Location = New System.Drawing.Point(18, 713)
        Me.admin_btn_SystemConfiguration.Name = "admin_btn_SystemConfiguration"
        Me.admin_btn_SystemConfiguration.Size = New System.Drawing.Size(204, 47)
        Me.admin_btn_SystemConfiguration.TabIndex = 9
        Me.admin_btn_SystemConfiguration.Text = "System Configuration"
        Me.admin_btn_SystemConfiguration.UseVisualStyleBackColor = False
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
        Me.admin_btn_reports.Location = New System.Drawing.Point(18, 646)
        Me.admin_btn_reports.Name = "admin_btn_reports"
        Me.admin_btn_reports.Size = New System.Drawing.Size(204, 47)
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
        Me.admin_btn_MaintenanceManagement.Location = New System.Drawing.Point(18, 582)
        Me.admin_btn_MaintenanceManagement.Name = "admin_btn_MaintenanceManagement"
        Me.admin_btn_MaintenanceManagement.Size = New System.Drawing.Size(204, 47)
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
        Me.admin_btn_PropertyRequestManagement.Location = New System.Drawing.Point(18, 507)
        Me.admin_btn_PropertyRequestManagement.Name = "admin_btn_PropertyRequestManagement"
        Me.admin_btn_PropertyRequestManagement.Size = New System.Drawing.Size(204, 58)
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
        Me.admin_btn_DepartmentManagement.Location = New System.Drawing.Point(18, 444)
        Me.admin_btn_DepartmentManagement.Name = "admin_btn_DepartmentManagement"
        Me.admin_btn_DepartmentManagement.Size = New System.Drawing.Size(204, 47)
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
        Me.admin_btn_SuppliesManagement.Location = New System.Drawing.Point(18, 380)
        Me.admin_btn_SuppliesManagement.Name = "admin_btn_SuppliesManagement"
        Me.admin_btn_SuppliesManagement.Size = New System.Drawing.Size(204, 47)
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
        Me.admin_btn_PropertyManagement.Location = New System.Drawing.Point(18, 318)
        Me.admin_btn_PropertyManagement.Name = "admin_btn_PropertyManagement"
        Me.admin_btn_PropertyManagement.Size = New System.Drawing.Size(204, 47)
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
        Me.admin_btn_UserManagement.Location = New System.Drawing.Point(18, 257)
        Me.admin_btn_UserManagement.Name = "admin_btn_UserManagement"
        Me.admin_btn_UserManagement.Size = New System.Drawing.Size(204, 47)
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
        Me.admin_btn_dashboard.Location = New System.Drawing.Point(18, 193)
        Me.admin_btn_dashboard.Name = "admin_btn_dashboard"
        Me.admin_btn_dashboard.Size = New System.Drawing.Size(204, 47)
        Me.admin_btn_dashboard.TabIndex = 0
        Me.admin_btn_dashboard.Text = "Dashboard"
        Me.admin_btn_dashboard.UseVisualStyleBackColor = False
        '
        'admin_TitleProfile
        '
        Me.admin_TitleProfile.AutoSize = True
        Me.admin_TitleProfile.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_TitleProfile.ForeColor = System.Drawing.Color.White
        Me.admin_TitleProfile.Location = New System.Drawing.Point(85, 152)
        Me.admin_TitleProfile.Name = "admin_TitleProfile"
        Me.admin_TitleProfile.Size = New System.Drawing.Size(68, 28)
        Me.admin_TitleProfile.TabIndex = 1
        Me.admin_TitleProfile.Text = "Admin"
        Me.admin_TitleProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'admin_picProfile
        '
        Me.admin_picProfile.BackColor = System.Drawing.Color.Transparent
        Me.admin_picProfile.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.profile
        Me.admin_picProfile.Location = New System.Drawing.Point(75, 45)
        Me.admin_picProfile.Name = "admin_picProfile"
        Me.admin_picProfile.Size = New System.Drawing.Size(90, 90)
        Me.admin_picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.admin_picProfile.TabIndex = 0
        Me.admin_picProfile.TabStop = False
        '
        'admin_PanelHeader
        '
        Me.admin_PanelHeader.BackColor = System.Drawing.Color.Transparent
        Me.admin_PanelHeader.Controls.Add(Me.admin_label_Dashboard)
        Me.admin_PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.admin_PanelHeader.Location = New System.Drawing.Point(240, 0)
        Me.admin_PanelHeader.Name = "admin_PanelHeader"
        Me.admin_PanelHeader.Size = New System.Drawing.Size(1374, 60)
        Me.admin_PanelHeader.TabIndex = 2
        '
        'admin_label_Dashboard
        '
        Me.admin_label_Dashboard.AutoSize = True
        Me.admin_label_Dashboard.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_Dashboard.Location = New System.Drawing.Point(20, 17)
        Me.admin_label_Dashboard.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.admin_label_Dashboard.Name = "admin_label_Dashboard"
        Me.admin_label_Dashboard.Size = New System.Drawing.Size(461, 48)
        Me.admin_label_Dashboard.TabIndex = 0
        Me.admin_label_Dashboard.Text = "Property Custodian Dashboard"
        '
        'admin_PanelMain
        '
        Me.admin_PanelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.admin_PanelMain.Controls.Add(Me.TableLayoutPanel1)
        Me.admin_PanelMain.Controls.Add(Me.admin_btn_NeedsRepair)
        Me.admin_PanelMain.Controls.Add(Me.admin_btn_Borrowed)
        Me.admin_PanelMain.Controls.Add(Me.admin_btn_PendingRequests)
        Me.admin_PanelMain.Controls.Add(Me.admin_btn_properties)
        Me.admin_PanelMain.Controls.Add(Me.PictureBox1)
        Me.admin_PanelMain.Controls.Add(Me.admin_txtbox_search)
        Me.admin_PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_PanelMain.Location = New System.Drawing.Point(240, 60)
        Me.admin_PanelMain.Name = "admin_PanelMain"
        Me.admin_PanelMain.Size = New System.Drawing.Size(1374, 831)
        Me.admin_PanelMain.TabIndex = 3
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.48276!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.517241!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(28, 250)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(778, 180)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'admin_btn_NeedsRepair
        '
        Me.admin_btn_NeedsRepair.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_btn_NeedsRepair.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_NeedsRepair.CornerRadius = 15
        Me.admin_btn_NeedsRepair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_NeedsRepair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_NeedsRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_NeedsRepair.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_NeedsRepair.ForeColor = System.Drawing.Color.White
        Me.admin_btn_NeedsRepair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_NeedsRepair.Location = New System.Drawing.Point(1162, 64)
        Me.admin_btn_NeedsRepair.Name = "admin_btn_NeedsRepair"
        Me.admin_btn_NeedsRepair.Size = New System.Drawing.Size(190, 168)
        Me.admin_btn_NeedsRepair.TabIndex = 14
        Me.admin_btn_NeedsRepair.Text = "Needs Repair"
        Me.admin_btn_NeedsRepair.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.admin_btn_NeedsRepair.UseVisualStyleBackColor = False
        '
        'admin_btn_Borrowed
        '
        Me.admin_btn_Borrowed.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.admin_btn_Borrowed.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_Borrowed.CornerRadius = 15
        Me.admin_btn_Borrowed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_Borrowed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_Borrowed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_Borrowed.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_Borrowed.ForeColor = System.Drawing.Color.White
        Me.admin_btn_Borrowed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_Borrowed.Location = New System.Drawing.Point(693, 64)
        Me.admin_btn_Borrowed.Name = "admin_btn_Borrowed"
        Me.admin_btn_Borrowed.Size = New System.Drawing.Size(190, 168)
        Me.admin_btn_Borrowed.TabIndex = 13
        Me.admin_btn_Borrowed.Text = "Borrowed/Returned"
        Me.admin_btn_Borrowed.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.admin_btn_Borrowed.UseVisualStyleBackColor = False
        '
        'admin_btn_PendingRequests
        '
        Me.admin_btn_PendingRequests.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.admin_btn_PendingRequests.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_PendingRequests.CornerRadius = 15
        Me.admin_btn_PendingRequests.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_PendingRequests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_PendingRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_PendingRequests.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_PendingRequests.ForeColor = System.Drawing.Color.White
        Me.admin_btn_PendingRequests.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_PendingRequests.Location = New System.Drawing.Point(497, 64)
        Me.admin_btn_PendingRequests.Name = "admin_btn_PendingRequests"
        Me.admin_btn_PendingRequests.Size = New System.Drawing.Size(190, 168)
        Me.admin_btn_PendingRequests.TabIndex = 12
        Me.admin_btn_PendingRequests.Text = "Pending Requests"
        Me.admin_btn_PendingRequests.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.admin_btn_PendingRequests.UseVisualStyleBackColor = False
        '
        'admin_btn_properties
        '
        Me.admin_btn_properties.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_btn_properties.CornerRadius = 15
        Me.admin_btn_properties.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.admin_btn_properties.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.admin_btn_properties.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn_properties.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn_properties.ForeColor = System.Drawing.Color.White
        Me.admin_btn_properties.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.admin_btn_properties.Location = New System.Drawing.Point(28, 64)
        Me.admin_btn_properties.Name = "admin_btn_properties"
        Me.admin_btn_properties.Size = New System.Drawing.Size(190, 168)
        Me.admin_btn_properties.TabIndex = 11
        Me.admin_btn_properties.Text = "Total Properties"
        Me.admin_btn_properties.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.admin_btn_properties.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(28, 19)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 24)
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
        Me.admin_txtbox_search.Location = New System.Drawing.Point(62, 19)
        Me.admin_txtbox_search.Margin = New System.Windows.Forms.Padding(2)
        Me.admin_txtbox_search.Name = "admin_txtbox_search"
        Me.admin_txtbox_search.Size = New System.Drawing.Size(1291, 28)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1614, 891)
        Me.Controls.Add(Me.admin_PanelMain)
        Me.Controls.Add(Me.admin_PanelHeader)
        Me.Controls.Add(Me.admin_PanelSidebar)
        Me.Name = "AdminDashboard"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.admin_PanelSidebar.ResumeLayout(False)
        Me.admin_PanelSidebar.PerformLayout()
        CType(Me.admin_picProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.admin_PanelHeader.ResumeLayout(False)
        Me.admin_PanelHeader.PerformLayout()
        Me.admin_PanelMain.ResumeLayout(False)
        Me.admin_PanelMain.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents admin_PanelSidebar As System.Windows.Forms.Panel
    Friend WithEvents admin_PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents admin_PanelMain As System.Windows.Forms.Panel
    Friend WithEvents admin_picProfile As System.Windows.Forms.PictureBox
    Friend WithEvents admin_TitleProfile As System.Windows.Forms.Label
    Friend WithEvents admin_btn_dashboard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_UserManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_PropertyManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_SuppliesManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_DepartmentManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_PropertyRequestManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_MaintenanceManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_reports As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_SystemConfiguration As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_Logout As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_label_Dashboard As System.Windows.Forms.Label
    Friend WithEvents admin_txtbox_search As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents admin_btn_properties As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_PendingRequests As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_Borrowed As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_btn_NeedsRepair As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
