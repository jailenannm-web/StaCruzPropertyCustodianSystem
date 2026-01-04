Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_UserManagement
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.admin_label_Dashboard = New System.Windows.Forms.Label()
        Me.pm_table = New System.Windows.Forms.DataGridView()
        Me.userId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.firstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.middleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employeeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.passwordEncrypted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lastLogin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboRoleFilter = New System.Windows.Forms.ComboBox()
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlusermanagement = New System.Windows.Forms.Label()
        Me.btnRefresh = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnUserReport = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.usermanagementsearchbar = New System.Windows.Forms.TextBox()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_Dashboard
        '
        Me.admin_label_Dashboard.AutoSize = True
        Me.admin_label_Dashboard.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.admin_label_Dashboard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.admin_label_Dashboard.Location = New System.Drawing.Point(15, 16)
        Me.admin_label_Dashboard.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.admin_label_Dashboard.Name = "admin_label_Dashboard"
        Me.admin_label_Dashboard.Size = New System.Drawing.Size(245, 42)
        Me.admin_label_Dashboard.TabIndex = 21
        Me.admin_label_Dashboard.Text = "User Management"
        '
        'pm_table
        '
        Me.pm_table.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_table.BackgroundColor = System.Drawing.Color.White
        Me.pm_table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.pm_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.userId, Me.createdAt, Me.updatedAt, Me.username, Me.firstName, Me.middleName, Me.lastName, Me.fullName, Me.departmentId, Me.employeeId, Me.contactNumber, Me.email, Me.fullAddress, Me.role, Me.passwordEncrypted, Me.lastLogin})
        Me.pm_table.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.Location = New System.Drawing.Point(22, 171)
        Me.pm_table.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pm_table.Name = "pm_table"
        Me.pm_table.RowHeadersWidth = 51
        Me.pm_table.RowTemplate.Height = 24
        Me.pm_table.Size = New System.Drawing.Size(889, 460)
        Me.pm_table.TabIndex = 27
        '
        'userId
        '
        Me.userId.HeaderText = "user Id"
        Me.userId.MinimumWidth = 6
        Me.userId.Name = "userId"
        Me.userId.Width = 125
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "createdAt"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Visible = False
        Me.createdAt.Width = 125
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "updatedAt"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Visible = False
        Me.updatedAt.Width = 125
        '
        'username
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.username.DefaultCellStyle = DataGridViewCellStyle22
        Me.username.HeaderText = "Username"
        Me.username.MinimumWidth = 6
        Me.username.Name = "username"
        Me.username.Width = 125
        '
        'firstName
        '
        Me.firstName.HeaderText = "first Name"
        Me.firstName.MinimumWidth = 6
        Me.firstName.Name = "firstName"
        Me.firstName.Width = 125
        '
        'middleName
        '
        Me.middleName.HeaderText = "middle Name"
        Me.middleName.MinimumWidth = 6
        Me.middleName.Name = "middleName"
        Me.middleName.Width = 125
        '
        'lastName
        '
        Me.lastName.HeaderText = "last Name"
        Me.lastName.MinimumWidth = 6
        Me.lastName.Name = "lastName"
        Me.lastName.Width = 125
        '
        'fullName
        '
        Me.fullName.HeaderText = "full Name"
        Me.fullName.MinimumWidth = 6
        Me.fullName.Name = "fullName"
        Me.fullName.Width = 125
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "department Id"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Width = 125
        '
        'employeeId
        '
        Me.employeeId.HeaderText = "employeeId"
        Me.employeeId.MinimumWidth = 6
        Me.employeeId.Name = "employeeId"
        Me.employeeId.Width = 125
        '
        'contactNumber
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.contactNumber.DefaultCellStyle = DataGridViewCellStyle23
        Me.contactNumber.HeaderText = "Contact Number"
        Me.contactNumber.MinimumWidth = 6
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Width = 125
        '
        'email
        '
        Me.email.HeaderText = "Email"
        Me.email.MinimumWidth = 6
        Me.email.Name = "email"
        Me.email.Width = 125
        '
        'fullAddress
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.fullAddress.DefaultCellStyle = DataGridViewCellStyle24
        Me.fullAddress.HeaderText = "Full Address"
        Me.fullAddress.MinimumWidth = 6
        Me.fullAddress.Name = "fullAddress"
        Me.fullAddress.Width = 200
        '
        'role
        '
        Me.role.HeaderText = "Role"
        Me.role.MinimumWidth = 6
        Me.role.Name = "role"
        '
        'passwordEncrypted
        '
        Me.passwordEncrypted.HeaderText = "passwordEncrypted"
        Me.passwordEncrypted.MinimumWidth = 6
        Me.passwordEncrypted.Name = "passwordEncrypted"
        Me.passwordEncrypted.Visible = False
        Me.passwordEncrypted.Width = 125
        '
        'lastLogin
        '
        Me.lastLogin.HeaderText = "lastLogin"
        Me.lastLogin.MinimumWidth = 6
        Me.lastLogin.Name = "lastLogin"
        Me.lastLogin.Visible = False
        Me.lastLogin.Width = 125
        '
        'cboRoleFilter
        '
        Me.cboRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRoleFilter.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboRoleFilter.FormattingEnabled = True
        Me.cboRoleFilter.Location = New System.Drawing.Point(259, 38)
        Me.cboRoleFilter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboRoleFilter.Name = "cboRoleFilter"
        Me.cboRoleFilter.Size = New System.Drawing.Size(151, 30)
        Me.cboRoleFilter.TabIndex = 163
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusFilter.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboStatusFilter.FormattingEnabled = True
        Me.cboStatusFilter.Location = New System.Drawing.Point(446, 38)
        Me.cboStatusFilter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(136, 30)
        Me.cboStatusFilter.TabIndex = 164
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 633)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 48)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "TOTAL:"
        '
        'ttlusermanagement
        '
        Me.ttlusermanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlusermanagement.AutoSize = True
        Me.ttlusermanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlusermanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlusermanagement.Location = New System.Drawing.Point(133, 633)
        Me.ttlusermanagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ttlusermanagement.Name = "ttlusermanagement"
        Me.ttlusermanagement.Size = New System.Drawing.Size(38, 48)
        Me.ttlusermanagement.TabIndex = 166
        Me.ttlusermanagement.Text = "0"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefresh.Location = New System.Drawing.Point(805, 37)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(74, 28)
        Me.btnRefresh.TabIndex = 165
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(677, 646)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(74, 28)
        Me.btnDelete.TabIndex = 161
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(757, 646)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(74, 28)
        Me.btnEdit.TabIndex = 160
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(837, 646)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 28)
        Me.btnAdd.TabIndex = 158
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnUserReport
        '
        Me.btnUserReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUserReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnUserReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUserReport.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnUserReport.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUserReport.Location = New System.Drawing.Point(578, 646)
        Me.btnUserReport.Name = "btnUserReport"
        Me.btnUserReport.Size = New System.Drawing.Size(93, 28)
        Me.btnUserReport.TabIndex = 391
        Me.btnUserReport.Text = "User Report"
        Me.btnUserReport.UseVisualStyleBackColor = False
        '
        'usermanagementsearchbar
        '
        Me.usermanagementsearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.usermanagementsearchbar.Location = New System.Drawing.Point(14, 40)
        Me.usermanagementsearchbar.Name = "usermanagementsearchbar"
        Me.usermanagementsearchbar.Size = New System.Drawing.Size(226, 25)
        Me.usermanagementsearchbar.TabIndex = 178
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.lblStatus)
        Me.pnlFilters.Controls.Add(Me.usermanagementsearchbar)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.btnRefresh)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.cboStatusFilter)
        Me.pnlFilters.Controls.Add(Me.cboRoleFilter)
        Me.pnlFilters.Location = New System.Drawing.Point(22, 73)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(11, 12, 11, 12)
        Me.pnlFilters.Size = New System.Drawing.Size(895, 82)
        Me.pnlFilters.TabIndex = 402
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(442, 17)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 19)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "Status"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(255, 16)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(33, 19)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Role"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(15, 16)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(50, 19)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search "
        '
        'UC_UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlusermanagement)
        Me.Controls.Add(Me.btnUserReport)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.pm_table)
        Me.Controls.Add(Me.admin_label_Dashboard)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UC_UserManagement"
        Me.Size = New System.Drawing.Size(938, 722)
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents admin_label_Dashboard As Label
    Friend WithEvents pm_table As DataGridView
    Friend WithEvents btnAdd As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents cboRoleFilter As ComboBox
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents btnRefresh As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnUserReport As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlusermanagement As Label
    Friend WithEvents userId As DataGridViewTextBoxColumn
    Friend WithEvents createdAt As DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As DataGridViewTextBoxColumn
    Friend WithEvents username As DataGridViewTextBoxColumn
    Friend WithEvents firstName As DataGridViewTextBoxColumn
    Friend WithEvents middleName As DataGridViewTextBoxColumn
    Friend WithEvents lastName As DataGridViewTextBoxColumn
    Friend WithEvents fullName As DataGridViewTextBoxColumn
    Friend WithEvents departmentId As DataGridViewTextBoxColumn
    Friend WithEvents employeeId As DataGridViewTextBoxColumn
    Friend WithEvents contactNumber As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents fullAddress As DataGridViewTextBoxColumn
    Friend WithEvents role As DataGridViewTextBoxColumn
    Friend WithEvents passwordEncrypted As DataGridViewTextBoxColumn
    Friend WithEvents lastLogin As DataGridViewTextBoxColumn
    Friend WithEvents usermanagementsearchbar As TextBox
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSearch As Label
End Class
