Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_UserManagement
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.admin_label_Dashboard = New System.Windows.Forms.Label()
        Me.pm_table = New System.Windows.Forms.DataGridView()
        Me.cboRoleFilter = New System.Windows.Forms.ComboBox()
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlusermanagement = New System.Windows.Forms.Label()
        Me.btnRefresh = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_assigned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.firstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.middleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suffixAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.positionAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepartmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usernameAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.passwordAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.provinceAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.municipality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barangay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_Dashboard
        '
        Me.admin_label_Dashboard.AutoSize = True
        Me.admin_label_Dashboard.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_Dashboard.Location = New System.Drawing.Point(43, 53)
        Me.admin_label_Dashboard.Name = "admin_label_Dashboard"
        Me.admin_label_Dashboard.Size = New System.Drawing.Size(342, 58)
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
        Me.pm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserID, Me.date_assigned, Me.fullName, Me.firstName, Me.middleName, Me.lastName, Me.suffixAdmin, Me.positionAdmin, Me.DepartmentID, Me.EmployeeID, Me.contactNumber, Me.email, Me.usernameAdmin, Me.passwordAdmin, Me.provinceAdmin, Me.municipality, Me.barangay, Me.Role, Me.Status})
        Me.pm_table.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.Location = New System.Drawing.Point(53, 114)
        Me.pm_table.Name = "pm_table"
        Me.pm_table.RowHeadersWidth = 51
        Me.pm_table.RowTemplate.Height = 24
        Me.pm_table.Size = New System.Drawing.Size(1270, 573)
        Me.pm_table.TabIndex = 27
        '
        'cboRoleFilter
        '
        Me.cboRoleFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRoleFilter.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cboRoleFilter.FormattingEnabled = True
        Me.cboRoleFilter.Location = New System.Drawing.Point(883, 64)
        Me.cboRoleFilter.Name = "cboRoleFilter"
        Me.cboRoleFilter.Size = New System.Drawing.Size(164, 31)
        Me.cboRoleFilter.TabIndex = 163
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusFilter.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.cboStatusFilter.FormattingEnabled = True
        Me.cboStatusFilter.Location = New System.Drawing.Point(1053, 64)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(164, 31)
        Me.cboStatusFilter.TabIndex = 164
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(43, 709)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "TOTAL:"
        '
        'ttlusermanagement
        '
        Me.ttlusermanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlusermanagement.AutoSize = True
        Me.ttlusermanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlusermanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlusermanagement.Location = New System.Drawing.Point(194, 709)
        Me.ttlusermanagement.Name = "ttlusermanagement"
        Me.ttlusermanagement.Size = New System.Drawing.Size(47, 58)
        Me.ttlusermanagement.TabIndex = 166
        Me.ttlusermanagement.Text = "0"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRefresh.CornerRadius = 15
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefresh.Location = New System.Drawing.Point(1224, 64)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(99, 34)
        Me.btnRefresh.TabIndex = 165
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1011, 709)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 34)
        Me.btnDelete.TabIndex = 161
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(1118, 709)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(99, 34)
        Me.btnEdit.TabIndex = 160
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1224, 709)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 34)
        Me.btnAdd.TabIndex = 158
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'UserID
        '
        Me.UserID.HeaderText = "User I.D"
        Me.UserID.MinimumWidth = 6
        Me.UserID.Name = "UserID"
        Me.UserID.Width = 125
        '
        'date_assigned
        '
        Me.date_assigned.HeaderText = "Date Assigned"
        Me.date_assigned.MinimumWidth = 6
        Me.date_assigned.Name = "date_assigned"
        Me.date_assigned.Width = 125
        '
        'fullName
        '
        Me.fullName.HeaderText = "Full Name"
        Me.fullName.MinimumWidth = 6
        Me.fullName.Name = "fullName"
        Me.fullName.Width = 125
        '
        'firstName
        '
        Me.firstName.HeaderText = "First Name"
        Me.firstName.MinimumWidth = 6
        Me.firstName.Name = "firstName"
        Me.firstName.Visible = False
        Me.firstName.Width = 125
        '
        'middleName
        '
        Me.middleName.HeaderText = "Middle Name"
        Me.middleName.MinimumWidth = 6
        Me.middleName.Name = "middleName"
        Me.middleName.Visible = False
        Me.middleName.Width = 125
        '
        'lastName
        '
        Me.lastName.HeaderText = "Last Name"
        Me.lastName.MinimumWidth = 6
        Me.lastName.Name = "lastName"
        Me.lastName.Visible = False
        Me.lastName.Width = 125
        '
        'suffixAdmin
        '
        Me.suffixAdmin.HeaderText = "Suffix"
        Me.suffixAdmin.MinimumWidth = 6
        Me.suffixAdmin.Name = "suffixAdmin"
        Me.suffixAdmin.Visible = False
        Me.suffixAdmin.Width = 125
        '
        'positionAdmin
        '
        Me.positionAdmin.HeaderText = "Position"
        Me.positionAdmin.MinimumWidth = 6
        Me.positionAdmin.Name = "positionAdmin"
        Me.positionAdmin.Width = 125
        '
        'DepartmentID
        '
        Me.DepartmentID.HeaderText = "Department ID"
        Me.DepartmentID.MinimumWidth = 6
        Me.DepartmentID.Name = "DepartmentID"
        Me.DepartmentID.Width = 125
        '
        'EmployeeID
        '
        Me.EmployeeID.HeaderText = "Employee I.D"
        Me.EmployeeID.MinimumWidth = 6
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Width = 125
        '
        'contactNumber
        '
        Me.contactNumber.HeaderText = "Contact Number"
        Me.contactNumber.MinimumWidth = 6
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Visible = False
        Me.contactNumber.Width = 125
        '
        'email
        '
        Me.email.HeaderText = "Email"
        Me.email.MinimumWidth = 6
        Me.email.Name = "email"
        Me.email.Visible = False
        Me.email.Width = 125
        '
        'usernameAdmin
        '
        Me.usernameAdmin.HeaderText = "Username"
        Me.usernameAdmin.MinimumWidth = 6
        Me.usernameAdmin.Name = "usernameAdmin"
        Me.usernameAdmin.Width = 125
        '
        'passwordAdmin
        '
        Me.passwordAdmin.HeaderText = "Password"
        Me.passwordAdmin.MinimumWidth = 6
        Me.passwordAdmin.Name = "passwordAdmin"
        Me.passwordAdmin.Visible = False
        Me.passwordAdmin.Width = 125
        '
        'provinceAdmin
        '
        Me.provinceAdmin.HeaderText = "Province"
        Me.provinceAdmin.MinimumWidth = 6
        Me.provinceAdmin.Name = "provinceAdmin"
        Me.provinceAdmin.Width = 125
        '
        'municipality
        '
        Me.municipality.HeaderText = "Municipality"
        Me.municipality.MinimumWidth = 6
        Me.municipality.Name = "municipality"
        Me.municipality.Visible = False
        Me.municipality.Width = 125
        '
        'barangay
        '
        Me.barangay.HeaderText = "Barangay"
        Me.barangay.MinimumWidth = 6
        Me.barangay.Name = "barangay"
        Me.barangay.Visible = False
        Me.barangay.Width = 125
        '
        'Role
        '
        Me.Role.HeaderText = "Role"
        Me.Role.MinimumWidth = 6
        Me.Role.Name = "Role"
        Me.Role.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'UC_UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlusermanagement)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.cboStatusFilter)
        Me.Controls.Add(Me.cboRoleFilter)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.pm_table)
        Me.Controls.Add(Me.admin_label_Dashboard)
        Me.Name = "UC_UserManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents admin_label_Dashboard As Label
    Friend WithEvents pm_table As DataGridView
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnEdit As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
    Friend WithEvents cboRoleFilter As ComboBox
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents btnRefresh As Resources.Controls.RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlusermanagement As Label
    Friend WithEvents UserID As DataGridViewTextBoxColumn
    Friend WithEvents date_assigned As DataGridViewTextBoxColumn
    Friend WithEvents fullName As DataGridViewTextBoxColumn
    Friend WithEvents firstName As DataGridViewTextBoxColumn
    Friend WithEvents middleName As DataGridViewTextBoxColumn
    Friend WithEvents lastName As DataGridViewTextBoxColumn
    Friend WithEvents suffixAdmin As DataGridViewTextBoxColumn
    Friend WithEvents positionAdmin As DataGridViewTextBoxColumn
    Friend WithEvents DepartmentID As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeID As DataGridViewTextBoxColumn
    Friend WithEvents contactNumber As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents usernameAdmin As DataGridViewTextBoxColumn
    Friend WithEvents passwordAdmin As DataGridViewTextBoxColumn
    Friend WithEvents provinceAdmin As DataGridViewTextBoxColumn
    Friend WithEvents municipality As DataGridViewTextBoxColumn
    Friend WithEvents barangay As DataGridViewTextBoxColumn
    Friend WithEvents Role As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
End Class
