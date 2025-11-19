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
        Me.admin_PanelSidebar = New System.Windows.Forms.Panel()
        Me.admin_btn_Logout = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_reports = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_MaintenanceManagement = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_PropertyRequestManagement = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_DepartmentManagement = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_SuppliesManagement = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_PropertyManagement = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_UserManagement = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_btn_dashboard = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_TitleProfile = New System.Windows.Forms.Label()
        Me.admin_picProfile = New System.Windows.Forms.PictureBox()
        Me.admin_PanelMain = New System.Windows.Forms.Panel()
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
        Me.admin_panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.admin_panelcontainer.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.admin_panel_PendingRequests.SuspendLayout
        Me.RoundedPanel1.SuspendLayout
        Me.RoundedPanel2.SuspendLayout
        Me.RoundedPanel3.SuspendLayout
        Me.SuspendLayout()
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
        Me.admin_PanelMain.Controls.Add(Me.admin_label_Dashboard)
        Me.admin_PanelMain.Controls.Add(Me.admin_panel2)
        Me.admin_PanelMain.Controls.Add(Me.admin_panel1)
        Me.admin_PanelMain.Controls.Add(Me.admin_panelcontainer)
        Me.admin_PanelMain.Controls.Add(Me.PictureBox1)
        Me.admin_PanelMain.Controls.Add(Me.admin_txtbox_search)
        Me.admin_PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.admin_PanelMain.Location = New System.Drawing.Point(340, 0)
        Me.admin_PanelMain.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_PanelMain.Name = "admin_PanelMain"
        Me.admin_PanelMain.Size = New System.Drawing.Size(1084, 1055)
        Me.admin_PanelMain.TabIndex = 3
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
        'admin_panel2
        '
        Me.admin_panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_panel2.CornerRadius = 10
        Me.admin_panel2.Location = New System.Drawing.Point(47, 624)
        Me.admin_panel2.Name = "admin_panel2"
        Me.admin_panel2.Size = New System.Drawing.Size(998, 406)
        Me.admin_panel2.TabIndex = 19
        '
        'admin_panel1
        '
        Me.admin_panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_panel1.Controls.Add(Me.admin_label_quickaccess)
        Me.admin_panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.admin_panel1.CornerRadius = 10
        Me.admin_panel1.Location = New System.Drawing.Point(47, 433)
        Me.admin_panel1.Name = "admin_panel1"
        Me.admin_panel1.Size = New System.Drawing.Size(998, 171)
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
        Me.admin_label_quickaccess.Location = New System.Drawing.Point(13, 13)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 53)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(978, 104)
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
        Me.admin_btn_hello.Size = New System.Drawing.Size(224, 84)
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
        Me.admin_btn_viewallprop.Size = New System.Drawing.Size(226, 84)
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
        Me.admin_btn_updateinventory.Size = New System.Drawing.Size(224, 84)
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
        Me.admin_btn_generatereport.Size = New System.Drawing.Size(224, 84)
        Me.admin_btn_generatereport.TabIndex = 13
        Me.admin_btn_generatereport.Text = "Generate Report"
        Me.admin_btn_generatereport.UseVisualStyleBackColor = False
        '
        'admin_panelcontainer
        '
        Me.admin_panelcontainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panelcontainer.Controls.Add(Me.TableLayoutPanel1)
        Me.admin_panelcontainer.Location = New System.Drawing.Point(47, 152)
        Me.admin_panelcontainer.Name = "admin_panelcontainer"
        Me.admin_panelcontainer.Size = New System.Drawing.Size(998, 269)
        Me.admin_panelcontainer.TabIndex = 16
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel2, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RoundedPanel1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.admin_panel_PendingRequests, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 4)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(998, 265)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(37, 106)
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
        Me.admin_txtbox_search.Location = New System.Drawing.Point(83, 106)
        Me.admin_txtbox_search.Name = "admin_txtbox_search"
        Me.admin_txtbox_search.Size = New System.Drawing.Size(972, 33)
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
        'admin_panel_PendingRequests
        '
        Me.admin_panel_PendingRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panel_PendingRequests.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.admin_panel_PendingRequests.Controls.Add(Me.Label1)
        Me.admin_panel_PendingRequests.CornerRadius = 20
        Me.admin_panel_PendingRequests.Location = New System.Drawing.Point(252, 3)
        Me.admin_panel_PendingRequests.Name = "admin_panel_PendingRequests"
        Me.admin_panel_PendingRequests.Size = New System.Drawing.Size(243, 259)
        Me.admin_panel_PendingRequests.TabIndex = 22
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
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.admin_panel_borrowed)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(501, 3)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(243, 259)
        Me.RoundedPanel1.TabIndex = 23
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.RoundedPanel2.Controls.Add(Me.Label2)
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(750, 3)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(245, 259)
        Me.RoundedPanel2.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 30)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Needs Repair"
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.RoundedPanel3.Controls.Add(Me.Label3)
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(3, 3)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(243, 259)
        Me.RoundedPanel3.TabIndex = 23
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
        Me.admin_panel1.ResumeLayout(False)
        Me.admin_panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.admin_panelcontainer.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.admin_panel_PendingRequests.ResumeLayout(False)
        Me.admin_panel_PendingRequests.PerformLayout
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout
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
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents admin_panelcontainer As Panel
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
