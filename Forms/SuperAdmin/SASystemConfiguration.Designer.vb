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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SASystemConfiguration))
        Me.lblSystemConfig = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnRoles = New System.Windows.Forms.Button()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.DBHost = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.port = New System.Windows.Forms.Label()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnTestConn = New System.Windows.Forms.Button()
        Me.btnSaveConn = New System.Windows.Forms.Button()
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
        Me.txtRoleName = New System.Windows.Forms.TextBox()
        Me.chkInventory = New System.Windows.Forms.CheckBox()
        Me.chkMaintenance = New System.Windows.Forms.CheckBox()
        Me.chkBorrow = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.btnSaveRole = New System.Windows.Forms.Button()
        Me.dgvRoles = New System.Windows.Forms.DataGridView()
        Me.RoleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Statuss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Permissions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.cmbLogType = New System.Windows.Forms.ComboBox()
        Me.btnExportLogs = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.LogID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Actionn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.combostatus = New System.Windows.Forms.ComboBox()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.pm_as_propertyman = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMenu.SuspendLayout()
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatus.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSystemConfig
        '
        Me.lblSystemConfig.AutoSize = True
        Me.lblSystemConfig.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.lblSystemConfig.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold)
        Me.lblSystemConfig.ForeColor = System.Drawing.Color.White
        Me.lblSystemConfig.Location = New System.Drawing.Point(28, 9)
        Me.lblSystemConfig.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemConfig.Name = "lblSystemConfig"
        Me.lblSystemConfig.Size = New System.Drawing.Size(395, 58)
        Me.lblSystemConfig.TabIndex = 50
        Me.lblSystemConfig.Text = "System Configuration"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(564, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(63, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 158
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(624, 26)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(563, 41)
        Me.TextBox1.TabIndex = 157
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1195, 35)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 30)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1440, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 30)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Categories"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(33, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(485, 26)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "Manage system- wide settings, connection, backups, and logs"
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.DarkGray
        Me.PanelMenu.Controls.Add(Me.btnLogs)
        Me.PanelMenu.Controls.Add(Me.btnRoles)
        Me.PanelMenu.Controls.Add(Me.btnCategory)
        Me.PanelMenu.Controls.Add(Me.btnConnection)
        Me.PanelMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelMenu.Location = New System.Drawing.Point(0, -8)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(397, 1234)
        Me.PanelMenu.TabIndex = 161
        '
        'btnLogs
        '
        Me.btnLogs.BackColor = System.Drawing.Color.DarkGray
        Me.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogs.Font = New System.Drawing.Font("Poppins", 15.8!, System.Drawing.FontStyle.Bold)
        Me.btnLogs.ForeColor = System.Drawing.Color.White
        Me.btnLogs.Location = New System.Drawing.Point(33, 619)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(305, 48)
        Me.btnLogs.TabIndex = 12
        Me.btnLogs.Text = "Logs"
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnRoles
        '
        Me.btnRoles.BackColor = System.Drawing.Color.DarkGray
        Me.btnRoles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoles.Font = New System.Drawing.Font("Poppins", 15.8!, System.Drawing.FontStyle.Bold)
        Me.btnRoles.ForeColor = System.Drawing.Color.White
        Me.btnRoles.Location = New System.Drawing.Point(33, 516)
        Me.btnRoles.Name = "btnRoles"
        Me.btnRoles.Size = New System.Drawing.Size(305, 48)
        Me.btnRoles.TabIndex = 11
        Me.btnRoles.Text = "User Roles"
        Me.btnRoles.UseVisualStyleBackColor = False
        '
        'btnCategory
        '
        Me.btnCategory.BackColor = System.Drawing.Color.DarkGray
        Me.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategory.Font = New System.Drawing.Font("Poppins", 15.8!, System.Drawing.FontStyle.Bold)
        Me.btnCategory.ForeColor = System.Drawing.Color.White
        Me.btnCategory.Location = New System.Drawing.Point(33, 412)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(305, 48)
        Me.btnCategory.TabIndex = 10
        Me.btnCategory.Text = "Category & Status"
        Me.btnCategory.UseVisualStyleBackColor = False
        '
        'btnConnection
        '
        Me.btnConnection.BackColor = System.Drawing.Color.DarkGray
        Me.btnConnection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnection.Font = New System.Drawing.Font("Poppins", 12.8!, System.Drawing.FontStyle.Bold)
        Me.btnConnection.ForeColor = System.Drawing.Color.White
        Me.btnConnection.Location = New System.Drawing.Point(33, 312)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(305, 48)
        Me.btnConnection.TabIndex = 9
        Me.btnConnection.Text = "Connection Settings"
        Me.btnConnection.UseVisualStyleBackColor = False
        '
        'DBHost
        '
        Me.DBHost.AutoSize = True
        Me.DBHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.DBHost.Location = New System.Drawing.Point(458, 173)
        Me.DBHost.Name = "DBHost"
        Me.DBHost.Size = New System.Drawing.Size(77, 22)
        Me.DBHost.TabIndex = 162
        Me.DBHost.Text = "DB Host"
        '
        'txtHost
        '
        Me.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtHost.Location = New System.Drawing.Point(572, 173)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(419, 28)
        Me.txtHost.TabIndex = 163
        '
        'txtPort
        '
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtPort.Location = New System.Drawing.Point(572, 247)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(419, 28)
        Me.txtPort.TabIndex = 165
        '
        'port
        '
        Me.port.AutoSize = True
        Me.port.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.port.Location = New System.Drawing.Point(457, 250)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(73, 22)
        Me.port.TabIndex = 164
        Me.port.Text = "DB Port"
        '
        'txtDBName
        '
        Me.txtDBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDBName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtDBName.Location = New System.Drawing.Point(572, 312)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(419, 28)
        Me.txtDBName.TabIndex = 167
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Label5.Location = New System.Drawing.Point(457, 318)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 22)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "DB Name"
        '
        'txtUser
        '
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtUser.Location = New System.Drawing.Point(572, 376)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(419, 28)
        Me.txtUser.TabIndex = 169
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Label6.Location = New System.Drawing.Point(457, 382)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 22)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "DB User"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtPassword.Location = New System.Drawing.Point(572, 453)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(419, 28)
        Me.txtPassword.TabIndex = 171
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Label7.Location = New System.Drawing.Point(457, 456)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 22)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "DB Password"
        '
        'btnTestConn
        '
        Me.btnTestConn.BackColor = System.Drawing.Color.Black
        Me.btnTestConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTestConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConn.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnTestConn.ForeColor = System.Drawing.Color.White
        Me.btnTestConn.Location = New System.Drawing.Point(543, 512)
        Me.btnTestConn.Name = "btnTestConn"
        Me.btnTestConn.Size = New System.Drawing.Size(131, 46)
        Me.btnTestConn.TabIndex = 172
        Me.btnTestConn.Text = "Test Connection"
        Me.btnTestConn.UseVisualStyleBackColor = False
        '
        'btnSaveConn
        '
        Me.btnSaveConn.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.btnSaveConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveConn.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnSaveConn.ForeColor = System.Drawing.Color.White
        Me.btnSaveConn.Location = New System.Drawing.Point(744, 512)
        Me.btnSaveConn.Name = "btnSaveConn"
        Me.btnSaveConn.Size = New System.Drawing.Size(131, 46)
        Me.btnSaveConn.TabIndex = 173
        Me.btnSaveConn.Text = "Save Settings"
        Me.btnSaveConn.UseVisualStyleBackColor = False
        '
        'txtCategoryName
        '
        Me.txtCategoryName.Location = New System.Drawing.Point(1092, 234)
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.Size = New System.Drawing.Size(264, 22)
        Me.txtCategoryName.TabIndex = 174
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(1092, 272)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(264, 22)
        Me.txtDescription.TabIndex = 175
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Category", "Status"})
        Me.cmbType.Location = New System.Drawing.Point(1092, 195)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(264, 24)
        Me.cmbType.TabIndex = 176
        '
        'btnAddCategory
        '
        Me.btnAddCategory.Location = New System.Drawing.Point(1391, 246)
        Me.btnAddCategory.Name = "btnAddCategory"
        Me.btnAddCategory.Size = New System.Drawing.Size(141, 48)
        Me.btnAddCategory.TabIndex = 177
        Me.btnAddCategory.Text = "Add Category"
        Me.btnAddCategory.UseVisualStyleBackColor = True
        '
        'btnEditCategory
        '
        Me.btnEditCategory.Location = New System.Drawing.Point(1548, 246)
        Me.btnEditCategory.Name = "btnEditCategory"
        Me.btnEditCategory.Size = New System.Drawing.Size(142, 50)
        Me.btnEditCategory.TabIndex = 178
        Me.btnEditCategory.Text = "Edit Category"
        Me.btnEditCategory.UseVisualStyleBackColor = True
        '
        'dgvCategory
        '
        Me.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.CategoryName, Me.Type, Me.Description, Me.Status, Me.Action})
        Me.dgvCategory.Location = New System.Drawing.Point(1082, 302)
        Me.dgvCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCategory.Name = "dgvCategory"
        Me.dgvCategory.RowHeadersWidth = 51
        Me.dgvCategory.Size = New System.Drawing.Size(629, 254)
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
        'txtRoleName
        '
        Me.txtRoleName.Location = New System.Drawing.Point(444, 599)
        Me.txtRoleName.Name = "txtRoleName"
        Me.txtRoleName.Size = New System.Drawing.Size(533, 22)
        Me.txtRoleName.TabIndex = 180
        '
        'chkInventory
        '
        Me.chkInventory.AutoSize = True
        Me.chkInventory.Location = New System.Drawing.Point(758, 671)
        Me.chkInventory.Name = "chkInventory"
        Me.chkInventory.Size = New System.Drawing.Size(83, 20)
        Me.chkInventory.TabIndex = 181
        Me.chkInventory.Text = "Inventory"
        Me.chkInventory.UseVisualStyleBackColor = True
        '
        'chkMaintenance
        '
        Me.chkMaintenance.AutoSize = True
        Me.chkMaintenance.Location = New System.Drawing.Point(646, 672)
        Me.chkMaintenance.Name = "chkMaintenance"
        Me.chkMaintenance.Size = New System.Drawing.Size(106, 20)
        Me.chkMaintenance.TabIndex = 182
        Me.chkMaintenance.Text = "Maintenance"
        Me.chkMaintenance.UseVisualStyleBackColor = True
        '
        'chkBorrow
        '
        Me.chkBorrow.AutoSize = True
        Me.chkBorrow.Location = New System.Drawing.Point(444, 671)
        Me.chkBorrow.Name = "chkBorrow"
        Me.chkBorrow.Size = New System.Drawing.Size(71, 20)
        Me.chkBorrow.TabIndex = 183
        Me.chkBorrow.Text = "Borrow"
        Me.chkBorrow.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(531, 672)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(97, 20)
        Me.CheckBox4.TabIndex = 184
        Me.CheckBox4.Text = "CheckBox4"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'btnSaveRole
        '
        Me.btnSaveRole.Location = New System.Drawing.Point(876, 663)
        Me.btnSaveRole.Name = "btnSaveRole"
        Me.btnSaveRole.Size = New System.Drawing.Size(115, 29)
        Me.btnSaveRole.TabIndex = 185
        Me.btnSaveRole.Text = "SaveRole"
        Me.btnSaveRole.UseVisualStyleBackColor = True
        '
        'dgvRoles
        '
        Me.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRoles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoleID, Me.Statuss, Me.Role, Me.Permissions})
        Me.dgvRoles.Location = New System.Drawing.Point(444, 720)
        Me.dgvRoles.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvRoles.Name = "dgvRoles"
        Me.dgvRoles.RowHeadersWidth = 51
        Me.dgvRoles.Size = New System.Drawing.Size(547, 237)
        Me.dgvRoles.TabIndex = 186
        '
        'RoleID
        '
        Me.RoleID.HeaderText = "Role ID"
        Me.RoleID.MinimumWidth = 6
        Me.RoleID.Name = "RoleID"
        Me.RoleID.Width = 125
        '
        'Statuss
        '
        Me.Statuss.HeaderText = "Status"
        Me.Statuss.MinimumWidth = 6
        Me.Statuss.Name = "Statuss"
        Me.Statuss.Width = 125
        '
        'Role
        '
        Me.Role.HeaderText = "Role"
        Me.Role.MinimumWidth = 6
        Me.Role.Name = "Role"
        Me.Role.Width = 125
        '
        'Permissions
        '
        Me.Permissions.HeaderText = "Permissions"
        Me.Permissions.MinimumWidth = 6
        Me.Permissions.Name = "Permissions"
        Me.Permissions.Width = 125
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(1331, 664)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(243, 22)
        Me.dtFrom.TabIndex = 187
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(1082, 663)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(231, 22)
        Me.dtTo.TabIndex = 188
        '
        'cmbLogType
        '
        Me.cmbLogType.FormattingEnabled = True
        Me.cmbLogType.Location = New System.Drawing.Point(1590, 601)
        Me.cmbLogType.Name = "cmbLogType"
        Me.cmbLogType.Size = New System.Drawing.Size(121, 24)
        Me.cmbLogType.TabIndex = 189
        '
        'btnExportLogs
        '
        Me.btnExportLogs.Location = New System.Drawing.Point(1590, 643)
        Me.btnExportLogs.Name = "btnExportLogs"
        Me.btnExportLogs.Size = New System.Drawing.Size(121, 48)
        Me.btnExportLogs.TabIndex = 190
        Me.btnExportLogs.Text = "Exports Logs"
        Me.btnExportLogs.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LogID, Me.DateTime, Me.User, Me.Actionn, Me.Message})
        Me.DataGridView1.Location = New System.Drawing.Point(1082, 720)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(643, 237)
        Me.DataGridView1.TabIndex = 191
        '
        'LogID
        '
        Me.LogID.HeaderText = "LogID"
        Me.LogID.MinimumWidth = 6
        Me.LogID.Name = "LogID"
        Me.LogID.Width = 125
        '
        'DateTime
        '
        Me.DateTime.HeaderText = "DateTime"
        Me.DateTime.MinimumWidth = 6
        Me.DateTime.Name = "DateTime"
        Me.DateTime.Width = 125
        '
        'User
        '
        Me.User.HeaderText = "User"
        Me.User.MinimumWidth = 6
        Me.User.Name = "User"
        Me.User.Width = 125
        '
        'Actionn
        '
        Me.Actionn.HeaderText = "Action"
        Me.Actionn.MinimumWidth = 6
        Me.Actionn.Name = "Actionn"
        Me.Actionn.Width = 125
        '
        'Message
        '
        Me.Message.HeaderText = "Message"
        Me.Message.MinimumWidth = 6
        Me.Message.Name = "Message"
        Me.Message.Width = 125
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.combostatus)
        Me.pnlStatus.CornerRadius = 5
        Me.pnlStatus.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlStatus.Location = New System.Drawing.Point(1263, 28)
        Me.pnlStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(177, 37)
        Me.pnlStatus.TabIndex = 154
        '
        'combostatus
        '
        Me.combostatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.combostatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.combostatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FormattingEnabled = True
        Me.combostatus.Location = New System.Drawing.Point(16, 7)
        Me.combostatus.Margin = New System.Windows.Forms.Padding(4)
        Me.combostatus.Name = "combostatus"
        Me.combostatus.Size = New System.Drawing.Size(144, 23)
        Me.combostatus.TabIndex = 1
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 5
        Me.pnlCategories.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlCategories.Location = New System.Drawing.Point(1548, 30)
        Me.pnlCategories.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(177, 37)
        Me.pnlCategories.TabIndex = 153
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(19, 7)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(144, 23)
        Me.comboCategoris.TabIndex = 0
        '
        'pm_as_propertyman
        '
        Me.pm_as_propertyman.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_propertyman.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_propertyman.CornerRadius = 20
        Me.pm_as_propertyman.Location = New System.Drawing.Point(-13, -8)
        Me.pm_as_propertyman.Name = "pm_as_propertyman"
        Me.pm_as_propertyman.Size = New System.Drawing.Size(1973, 124)
        Me.pm_as_propertyman.TabIndex = 160
        '
        'SASystemConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1942, 1102)
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
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.lblSystemConfig)
        Me.Controls.Add(Me.pm_as_propertyman)
        Me.Controls.Add(Me.PanelMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SASystemConfiguration"
        Me.Text = "SASystemConfiguration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMenu.ResumeLayout(False)
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlCategories.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSystemConfig As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlStatus As Resources.Controls.RoundedPanel
    Friend WithEvents pnlCategories As Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents combostatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pm_as_propertyman As Resources.Controls.RoundedPanel
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents btnConnection As Button
    Friend WithEvents btnCategory As Button
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnRoles As Button
    Friend WithEvents DBHost As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents port As Label
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnTestConn As Button
    Friend WithEvents btnSaveConn As Button
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
    Friend WithEvents txtRoleName As TextBox
    Friend WithEvents chkInventory As CheckBox
    Friend WithEvents chkMaintenance As CheckBox
    Friend WithEvents chkBorrow As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents btnSaveRole As Button
    Friend WithEvents dgvRoles As DataGridView
    Friend WithEvents RoleID As DataGridViewTextBoxColumn
    Friend WithEvents Statuss As DataGridViewTextBoxColumn
    Friend WithEvents Role As DataGridViewTextBoxColumn
    Friend WithEvents Permissions As DataGridViewTextBoxColumn
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents cmbLogType As ComboBox
    Friend WithEvents btnExportLogs As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents LogID As DataGridViewTextBoxColumn
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents User As DataGridViewTextBoxColumn
    Friend WithEvents Actionn As DataGridViewTextBoxColumn
    Friend WithEvents Message As DataGridViewTextBoxColumn
End Class
