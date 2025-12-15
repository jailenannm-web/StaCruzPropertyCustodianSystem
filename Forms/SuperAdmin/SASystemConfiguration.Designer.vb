Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SASystemConfiguration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblSystemConfig = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnRoles = New System.Windows.Forms.Button()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.txtCategoryName = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.btnAddCategory = New System.Windows.Forms.Button()
        Me.btnEditCategory = New System.Windows.Forms.Button()
        Me.dgvCategory = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.combostatus = New System.Windows.Forms.ComboBox()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.pm_as_propertyman = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DBHost = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.port = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnTestConn = New System.Windows.Forms.Button()
        Me.btnSaveConn = New System.Windows.Forms.Button()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.cmbLogType = New System.Windows.Forms.ComboBox()
        Me.btnExportLogs = New System.Windows.Forms.Button()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Actionn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtRoleName = New System.Windows.Forms.TextBox()
        Me.chkInventory = New System.Windows.Forms.CheckBox()
        Me.chkMaintenance = New System.Windows.Forms.CheckBox()
        Me.chkBorrow = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.btnSaveRole = New System.Windows.Forms.Button()
        Me.Permissions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Statuss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvRoles = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PanelMenu.SuspendLayout()
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pm_as_propertyman.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSystemConfig
        '
        Me.lblSystemConfig.AutoSize = True
        Me.lblSystemConfig.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblSystemConfig.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold)
        Me.lblSystemConfig.ForeColor = System.Drawing.Color.Transparent
        Me.lblSystemConfig.Location = New System.Drawing.Point(41, 28)
        Me.lblSystemConfig.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemConfig.Name = "lblSystemConfig"
        Me.lblSystemConfig.Size = New System.Drawing.Size(407, 58)
        Me.lblSystemConfig.TabIndex = 50
        Me.lblSystemConfig.Text = "System Configuration"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1340, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 23)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1586, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 23)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Categories"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(47, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(429, 23)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "Manage system- wide settings, connection, backups, and logs"
        '
        'PanelMenu
        '
        Me.PanelMenu.AutoScroll = True
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.PanelMenu.Controls.Add(Me.btnLogs)
        Me.PanelMenu.Controls.Add(Me.btnRoles)
        Me.PanelMenu.Controls.Add(Me.btnCategory)
        Me.PanelMenu.Controls.Add(Me.btnConnection)
        Me.PanelMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelMenu.Location = New System.Drawing.Point(0, -8)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(380, 1055)
        Me.PanelMenu.TabIndex = 161
        '
        'btnLogs
        '
        Me.btnLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogs.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnLogs.ForeColor = System.Drawing.Color.White
        Me.btnLogs.Location = New System.Drawing.Point(38, 396)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(305, 48)
        Me.btnLogs.TabIndex = 12
        Me.btnLogs.Text = "Logs"
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnRoles
        '
        Me.btnRoles.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRoles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoles.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnRoles.ForeColor = System.Drawing.Color.White
        Me.btnRoles.Location = New System.Drawing.Point(38, 331)
        Me.btnRoles.Name = "btnRoles"
        Me.btnRoles.Size = New System.Drawing.Size(305, 48)
        Me.btnRoles.TabIndex = 11
        Me.btnRoles.Text = "User Roles"
        Me.btnRoles.UseVisualStyleBackColor = False
        '
        'btnCategory
        '
        Me.btnCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategory.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCategory.ForeColor = System.Drawing.Color.White
        Me.btnCategory.Location = New System.Drawing.Point(38, 266)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(305, 48)
        Me.btnCategory.TabIndex = 10
        Me.btnCategory.Text = "Category and Status"
        Me.btnCategory.UseVisualStyleBackColor = False
        '
        'btnConnection
        '
        Me.btnConnection.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnConnection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnection.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnConnection.ForeColor = System.Drawing.Color.White
        Me.btnConnection.Location = New System.Drawing.Point(38, 202)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(305, 48)
        Me.btnConnection.TabIndex = 9
        Me.btnConnection.Text = "Connection Settings"
        Me.btnConnection.UseVisualStyleBackColor = False
        '
        'txtCategoryName
        '
        Me.txtCategoryName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoryName.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtCategoryName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtCategoryName.Location = New System.Drawing.Point(1284, 217)
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.Size = New System.Drawing.Size(500, 27)
        Me.txtCategoryName.TabIndex = 174
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDescription.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtDescription.Location = New System.Drawing.Point(1284, 260)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(500, 27)
        Me.txtDescription.TabIndex = 175
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmbType.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Category", "Status"})
        Me.cmbType.Location = New System.Drawing.Point(1284, 174)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(500, 31)
        Me.cmbType.TabIndex = 176
        '
        'btnAddCategory
        '
        Me.btnAddCategory.BackColor = System.Drawing.Color.Transparent
        Me.btnAddCategory.Location = New System.Drawing.Point(1514, 302)
        Me.btnAddCategory.Name = "btnAddCategory"
        Me.btnAddCategory.Size = New System.Drawing.Size(131, 36)
        Me.btnAddCategory.TabIndex = 177
        Me.btnAddCategory.Text = "Add Category"
        Me.btnAddCategory.UseVisualStyleBackColor = False
        '
        'btnEditCategory
        '
        Me.btnEditCategory.BackColor = System.Drawing.Color.Transparent
        Me.btnEditCategory.Location = New System.Drawing.Point(1653, 302)
        Me.btnEditCategory.Name = "btnEditCategory"
        Me.btnEditCategory.Size = New System.Drawing.Size(131, 36)
        Me.btnEditCategory.TabIndex = 178
        Me.btnEditCategory.Text = "Edit Category"
        Me.btnEditCategory.UseVisualStyleBackColor = False
        '
        'dgvCategory
        '
        Me.dgvCategory.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.CategoryName, Me.Type, Me.Description, Me.Status, Me.Action})
        Me.dgvCategory.Location = New System.Drawing.Point(1141, 357)
        Me.dgvCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCategory.Name = "dgvCategory"
        Me.dgvCategory.RowHeadersWidth = 51
        Me.dgvCategory.Size = New System.Drawing.Size(644, 250)
        Me.dgvCategory.TabIndex = 179
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.MinimumWidth = 6
        Me.ID.Name = "ID"
        Me.ID.Width = 125
        '
        'CategoryName
        '
        Me.CategoryName.HeaderText = "Category Name"
        Me.CategoryName.MinimumWidth = 6
        Me.CategoryName.Name = "CategoryName"
        Me.CategoryName.Width = 125
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.MinimumWidth = 6
        Me.Type.Name = "Type"
        Me.Type.Width = 125
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.MinimumWidth = 6
        Me.Action.Name = "Action"
        Me.Action.Width = 125
        '
        'combostatus
        '
        Me.combostatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.combostatus.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.combostatus.ForeColor = System.Drawing.Color.Transparent
        Me.combostatus.FormattingEnabled = True
        Me.combostatus.Location = New System.Drawing.Point(1404, 50)
        Me.combostatus.Margin = New System.Windows.Forms.Padding(4)
        Me.combostatus.Name = "combostatus"
        Me.combostatus.Size = New System.Drawing.Size(144, 31)
        Me.combostatus.TabIndex = 1
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboCategoris.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(1677, 50)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(144, 31)
        Me.comboCategoris.TabIndex = 0
        '
        'pm_as_propertyman
        '
        Me.pm_as_propertyman.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_propertyman.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_as_propertyman.Controls.Add(Me.Label3)
        Me.pm_as_propertyman.Controls.Add(Me.comboCategoris)
        Me.pm_as_propertyman.Controls.Add(Me.combostatus)
        Me.pm_as_propertyman.Controls.Add(Me.Label1)
        Me.pm_as_propertyman.Controls.Add(Me.lblSystemConfig)
        Me.pm_as_propertyman.Controls.Add(Me.Label2)
        Me.pm_as_propertyman.CornerRadius = 20
        Me.pm_as_propertyman.Location = New System.Drawing.Point(-13, -8)
        Me.pm_as_propertyman.Name = "pm_as_propertyman"
        Me.pm_as_propertyman.Size = New System.Drawing.Size(1973, 124)
        Me.pm_as_propertyman.TabIndex = 160
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(1149, 263)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 23)
        Me.Label4.TabIndex = 194
        Me.Label4.Text = "Types"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(1149, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 23)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "Description"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(1149, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 23)
        Me.Label9.TabIndex = 192
        Me.Label9.Text = "Categories"
        '
        'DBHost
        '
        Me.DBHost.AutoSize = True
        Me.DBHost.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.DBHost.Location = New System.Drawing.Point(458, 175)
        Me.DBHost.Name = "DBHost"
        Me.DBHost.Size = New System.Drawing.Size(59, 23)
        Me.DBHost.TabIndex = 162
        Me.DBHost.Text = "DB Host"
        '
        'txtHost
        '
        Me.txtHost.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHost.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtHost.Location = New System.Drawing.Point(572, 173)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(449, 27)
        Me.txtHost.TabIndex = 163
        '
        'port
        '
        Me.port.AutoSize = True
        Me.port.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.port.Location = New System.Drawing.Point(457, 218)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(56, 23)
        Me.port.TabIndex = 164
        Me.port.Text = "DB Port"
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPort.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtPort.Location = New System.Drawing.Point(572, 215)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(449, 27)
        Me.txtPort.TabIndex = 165
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(458, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 23)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "DB Name"
        '
        'txtDBName
        '
        Me.txtDBName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtDBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDBName.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtDBName.Location = New System.Drawing.Point(572, 258)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(449, 27)
        Me.txtDBName.TabIndex = 167
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(458, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 23)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "DB User"
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtUser.Location = New System.Drawing.Point(572, 300)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(449, 27)
        Me.txtUser.TabIndex = 169
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(457, 346)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 23)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "DB Password"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.txtPassword.Location = New System.Drawing.Point(572, 344)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(449, 27)
        Me.txtPassword.TabIndex = 171
        '
        'btnTestConn
        '
        Me.btnTestConn.BackColor = System.Drawing.Color.Black
        Me.btnTestConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTestConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConn.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnTestConn.ForeColor = System.Drawing.Color.White
        Me.btnTestConn.Location = New System.Drawing.Point(742, 395)
        Me.btnTestConn.Name = "btnTestConn"
        Me.btnTestConn.Size = New System.Drawing.Size(131, 36)
        Me.btnTestConn.TabIndex = 172
        Me.btnTestConn.Text = "Test Connection"
        Me.btnTestConn.UseVisualStyleBackColor = False
        '
        'btnSaveConn
        '
        Me.btnSaveConn.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.btnSaveConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveConn.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnSaveConn.ForeColor = System.Drawing.Color.White
        Me.btnSaveConn.Location = New System.Drawing.Point(890, 394)
        Me.btnSaveConn.Name = "btnSaveConn"
        Me.btnSaveConn.Size = New System.Drawing.Size(131, 36)
        Me.btnSaveConn.TabIndex = 173
        Me.btnSaveConn.Text = "Save Settings"
        Me.btnSaveConn.UseVisualStyleBackColor = False
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(1541, 734)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(243, 22)
        Me.dtFrom.TabIndex = 187
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(1304, 734)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(231, 22)
        Me.dtTo.TabIndex = 188
        '
        'cmbLogType
        '
        Me.cmbLogType.FormattingEnabled = True
        Me.cmbLogType.Location = New System.Drawing.Point(1237, 696)
        Me.cmbLogType.Name = "cmbLogType"
        Me.cmbLogType.Size = New System.Drawing.Size(547, 24)
        Me.cmbLogType.TabIndex = 189
        '
        'btnExportLogs
        '
        Me.btnExportLogs.Location = New System.Drawing.Point(1670, 1018)
        Me.btnExportLogs.Name = "btnExportLogs"
        Me.btnExportLogs.Size = New System.Drawing.Size(115, 29)
        Me.btnExportLogs.TabIndex = 190
        Me.btnExportLogs.Text = "Exports Logs"
        Me.btnExportLogs.UseVisualStyleBackColor = True
        '
        'Message
        '
        Me.Message.HeaderText = "Message"
        Me.Message.MinimumWidth = 6
        Me.Message.Name = "Message"
        Me.Message.Width = 125
        '
        'Actionn
        '
        Me.Actionn.HeaderText = "Action"
        Me.Actionn.MinimumWidth = 6
        Me.Actionn.Name = "Actionn"
        Me.Actionn.Width = 125
        '
        'User
        '
        Me.User.HeaderText = "User"
        Me.User.MinimumWidth = 6
        Me.User.Name = "User"
        Me.User.Width = 125
        '
        'DateTime
        '
        Me.DateTime.HeaderText = "DateTime"
        Me.DateTime.MinimumWidth = 6
        Me.DateTime.Name = "DateTime"
        Me.DateTime.Width = 125
        '
        'LogID
        '
        Me.LogID.HeaderText = "LogID"
        Me.LogID.MinimumWidth = 6
        Me.LogID.Name = "LogID"
        Me.LogID.Width = 125
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LogID, Me.DateTime, Me.User, Me.Actionn, Me.Message})
        Me.DataGridView1.Location = New System.Drawing.Point(1142, 778)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(643, 232)
        Me.DataGridView1.TabIndex = 191
        '
        'txtRoleName
        '
        Me.txtRoleName.Location = New System.Drawing.Point(572, 698)
        Me.txtRoleName.Name = "txtRoleName"
        Me.txtRoleName.Size = New System.Drawing.Size(449, 22)
        Me.txtRoleName.TabIndex = 180
        '
        'chkInventory
        '
        Me.chkInventory.AutoSize = True
        Me.chkInventory.Location = New System.Drawing.Point(938, 737)
        Me.chkInventory.Name = "chkInventory"
        Me.chkInventory.Size = New System.Drawing.Size(83, 20)
        Me.chkInventory.TabIndex = 181
        Me.chkInventory.Text = "Inventory"
        Me.chkInventory.UseVisualStyleBackColor = True
        '
        'chkMaintenance
        '
        Me.chkMaintenance.AutoSize = True
        Me.chkMaintenance.Location = New System.Drawing.Point(826, 738)
        Me.chkMaintenance.Name = "chkMaintenance"
        Me.chkMaintenance.Size = New System.Drawing.Size(106, 20)
        Me.chkMaintenance.TabIndex = 182
        Me.chkMaintenance.Text = "Maintenance"
        Me.chkMaintenance.UseVisualStyleBackColor = True
        '
        'chkBorrow
        '
        Me.chkBorrow.AutoSize = True
        Me.chkBorrow.Location = New System.Drawing.Point(624, 737)
        Me.chkBorrow.Name = "chkBorrow"
        Me.chkBorrow.Size = New System.Drawing.Size(71, 20)
        Me.chkBorrow.TabIndex = 183
        Me.chkBorrow.Text = "Borrow"
        Me.chkBorrow.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(711, 738)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(97, 20)
        Me.CheckBox4.TabIndex = 184
        Me.CheckBox4.Text = "CheckBox4"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'btnSaveRole
        '
        Me.btnSaveRole.Location = New System.Drawing.Point(906, 1018)
        Me.btnSaveRole.Name = "btnSaveRole"
        Me.btnSaveRole.Size = New System.Drawing.Size(115, 29)
        Me.btnSaveRole.TabIndex = 185
        Me.btnSaveRole.Text = "SaveRole"
        Me.btnSaveRole.UseVisualStyleBackColor = True
        '
        'Permissions
        '
        Me.Permissions.HeaderText = "Permissions"
        Me.Permissions.MinimumWidth = 6
        Me.Permissions.Name = "Permissions"
        Me.Permissions.Width = 125
        '
        'Role
        '
        Me.Role.HeaderText = "Role"
        Me.Role.MinimumWidth = 6
        Me.Role.Name = "Role"
        Me.Role.Width = 125
        '
        'Statuss
        '
        Me.Statuss.HeaderText = "Status"
        Me.Statuss.MinimumWidth = 6
        Me.Statuss.Name = "Statuss"
        Me.Statuss.Width = 125
        '
        'RoleID
        '
        Me.RoleID.HeaderText = "Role ID"
        Me.RoleID.MinimumWidth = 6
        Me.RoleID.Name = "RoleID"
        Me.RoleID.Width = 125
        '
        'dgvRoles
        '
        Me.dgvRoles.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRoles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoleID, Me.Statuss, Me.Role, Me.Permissions})
        Me.dgvRoles.Location = New System.Drawing.Point(462, 778)
        Me.dgvRoles.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvRoles.Name = "dgvRoles"
        Me.dgvRoles.RowHeadersWidth = 51
        Me.dgvRoles.Size = New System.Drawing.Size(559, 232)
        Me.dgvRoles.TabIndex = 186
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(458, 699)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 23)
        Me.Label10.TabIndex = 195
        Me.Label10.Text = "Role Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(1137, 699)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 23)
        Me.Label11.TabIndex = 196
        Me.Label11.Text = "Role Name"
        '
        'SASystemConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1942, 1102)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnExportLogs)
        Me.Controls.Add(Me.cmbLogType)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.dgvRoles)
        Me.Controls.Add(Me.btnSaveRole)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.chkBorrow)
        Me.Controls.Add(Me.chkMaintenance)
        Me.Controls.Add(Me.chkInventory)
        Me.Controls.Add(Me.txtRoleName)
        Me.Controls.Add(Me.dgvCategory)
        Me.Controls.Add(Me.btnEditCategory)
        Me.Controls.Add(Me.btnAddCategory)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtCategoryName)
        Me.Controls.Add(Me.btnSaveConn)
        Me.Controls.Add(Me.btnTestConn)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.port)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.DBHost)
        Me.Controls.Add(Me.pm_as_propertyman)
        Me.Controls.Add(Me.PanelMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SASystemConfiguration"
        Me.Text = "SASystemConfiguration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelMenu.ResumeLayout(False)
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pm_as_propertyman.ResumeLayout(False)
        Me.pm_as_propertyman.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSystemConfig As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents combostatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pm_as_propertyman As Resources.Controls.RoundedPanel
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents btnConnection As Button
    Friend WithEvents btnCategory As Button
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnRoles As Button
    Friend WithEvents txtCategoryName As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents btnAddCategory As Button
    Friend WithEvents btnEditCategory As Button
    Friend WithEvents dgvCategory As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents CategoryName As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents DBHost As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents port As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnTestConn As Button
    Friend WithEvents btnSaveConn As Button
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents cmbLogType As ComboBox
    Friend WithEvents btnExportLogs As Button
    Friend WithEvents Message As DataGridViewTextBoxColumn
    Friend WithEvents Actionn As DataGridViewTextBoxColumn
    Friend WithEvents User As DataGridViewTextBoxColumn
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents LogID As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtRoleName As TextBox
    Friend WithEvents chkInventory As CheckBox
    Friend WithEvents chkMaintenance As CheckBox
    Friend WithEvents chkBorrow As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents btnSaveRole As Button
    Friend WithEvents Permissions As DataGridViewTextBoxColumn
    Friend WithEvents Role As DataGridViewTextBoxColumn
    Friend WithEvents Statuss As DataGridViewTextBoxColumn
    Friend WithEvents RoleID As DataGridViewTextBoxColumn
    Friend WithEvents dgvRoles As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
End Class
