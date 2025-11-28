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
        Me.userID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.firstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.middleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suffix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.positionUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userRole = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.province = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.municipalityCity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barangay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.houseNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateRegistered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.accountStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btndelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cboRoleFilter = New System.Windows.Forms.ComboBox()
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        Me.pm_table.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.pm_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.userID, Me.firstName, Me.middleName, Me.lastName, Me.suffix, Me.positionUser, Me.departmentID, Me.contactNumber, Me.email, Me.userRole, Me.province, Me.municipalityCity, Me.barangay, Me.houseNumber, Me.password, Me.dateRegistered, Me.accountStatus})
        Me.pm_table.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.Location = New System.Drawing.Point(53, 105)
        Me.pm_table.Name = "pm_table"
        Me.pm_table.RowHeadersWidth = 51
        Me.pm_table.RowTemplate.Height = 24
        Me.pm_table.Size = New System.Drawing.Size(1270, 573)
        Me.pm_table.TabIndex = 27
        '
        'userID
        '
        Me.userID.HeaderText = "User ID"
        Me.userID.MinimumWidth = 6
        Me.userID.Name = "userID"
        Me.userID.Width = 90
        '
        'firstName
        '
        Me.firstName.HeaderText = "First Name"
        Me.firstName.MinimumWidth = 6
        Me.firstName.Name = "firstName"
        Me.firstName.Width = 90
        '
        'middleName
        '
        Me.middleName.HeaderText = "Middle Name"
        Me.middleName.MinimumWidth = 6
        Me.middleName.Name = "middleName"
        Me.middleName.Width = 90
        '
        'lastName
        '
        Me.lastName.HeaderText = "Last Name"
        Me.lastName.MinimumWidth = 6
        Me.lastName.Name = "lastName"
        Me.lastName.Width = 90
        '
        'suffix
        '
        Me.suffix.HeaderText = "Suffix"
        Me.suffix.MinimumWidth = 6
        Me.suffix.Name = "suffix"
        Me.suffix.Width = 90
        '
        'positionUser
        '
        Me.positionUser.HeaderText = "Position"
        Me.positionUser.MinimumWidth = 6
        Me.positionUser.Name = "positionUser"
        Me.positionUser.Width = 90
        '
        'departmentID
        '
        Me.departmentID.HeaderText = "Department ID"
        Me.departmentID.MinimumWidth = 6
        Me.departmentID.Name = "departmentID"
        Me.departmentID.Width = 90
        '
        'contactNumber
        '
        Me.contactNumber.HeaderText = "Contact Number"
        Me.contactNumber.MinimumWidth = 6
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Width = 90
        '
        'email
        '
        Me.email.HeaderText = "Email"
        Me.email.MinimumWidth = 6
        Me.email.Name = "email"
        Me.email.Width = 90
        '
        'userRole
        '
        Me.userRole.HeaderText = "User Role"
        Me.userRole.MinimumWidth = 6
        Me.userRole.Name = "userRole"
        Me.userRole.Width = 90
        '
        'province
        '
        Me.province.HeaderText = "Province"
        Me.province.MinimumWidth = 6
        Me.province.Name = "province"
        Me.province.Width = 90
        '
        'municipalityCity
        '
        Me.municipalityCity.HeaderText = "Municipality/City"
        Me.municipalityCity.MinimumWidth = 6
        Me.municipalityCity.Name = "municipalityCity"
        Me.municipalityCity.Width = 90
        '
        'barangay
        '
        Me.barangay.HeaderText = "Barangay"
        Me.barangay.MinimumWidth = 6
        Me.barangay.Name = "barangay"
        Me.barangay.Width = 90
        '
        'houseNumber
        '
        Me.houseNumber.HeaderText = "House Number"
        Me.houseNumber.MinimumWidth = 6
        Me.houseNumber.Name = "houseNumber"
        Me.houseNumber.Width = 90
        '
        'password
        '
        Me.password.HeaderText = "Password"
        Me.password.MinimumWidth = 6
        Me.password.Name = "password"
        Me.password.Width = 90
        '
        'dateRegistered
        '
        Me.dateRegistered.HeaderText = "Date Registered"
        Me.dateRegistered.MinimumWidth = 6
        Me.dateRegistered.Name = "dateRegistered"
        Me.dateRegistered.Width = 90
        '
        'accountStatus
        '
        Me.accountStatus.HeaderText = "Account Status"
        Me.accountStatus.MinimumWidth = 6
        Me.accountStatus.Name = "accountStatus"
        Me.accountStatus.Width = 90
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(719, 709)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 159
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1178, 709)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(145, 34)
        Me.btnAdd.TabIndex = 158
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(872, 709)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(145, 34)
        Me.btnEdit.TabIndex = 160
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btndelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btndelete.CornerRadius = 15
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btndelete.Location = New System.Drawing.Point(1025, 709)
        Me.btndelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(145, 34)
        Me.btndelete.TabIndex = 161
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(561, 73)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(230, 30)
        Me.txtSearch.TabIndex = 162
        '
        'cboRoleFilter
        '
        Me.cboRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRoleFilter.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRoleFilter.FormattingEnabled = True
        Me.cboRoleFilter.Location = New System.Drawing.Point(809, 72)
        Me.cboRoleFilter.Name = "cboRoleFilter"
        Me.cboRoleFilter.Size = New System.Drawing.Size(180, 34)
        Me.cboRoleFilter.TabIndex = 163
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusFilter.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatusFilter.FormattingEnabled = True
        Me.cboStatusFilter.Location = New System.Drawing.Point(1006, 72)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(180, 34)
        Me.cboStatusFilter.TabIndex = 164
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnRefresh.CornerRadius = 15
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Poppins SemiBold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefresh.Location = New System.Drawing.Point(1204, 70)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(119, 34)
        Me.btnRefresh.TabIndex = 165
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'UC_UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.cboStatusFilter)
        Me.Controls.Add(Me.cboRoleFilter)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnCancel)
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
    Friend WithEvents userID As DataGridViewTextBoxColumn
    Friend WithEvents firstName As DataGridViewTextBoxColumn
    Friend WithEvents middleName As DataGridViewTextBoxColumn
    Friend WithEvents lastName As DataGridViewTextBoxColumn
    Friend WithEvents suffix As DataGridViewTextBoxColumn
    Friend WithEvents positionUser As DataGridViewTextBoxColumn
    Friend WithEvents departmentID As DataGridViewTextBoxColumn
    Friend WithEvents contactNumber As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents userRole As DataGridViewTextBoxColumn
    Friend WithEvents province As DataGridViewTextBoxColumn
    Friend WithEvents municipalityCity As DataGridViewTextBoxColumn
    Friend WithEvents barangay As DataGridViewTextBoxColumn
    Friend WithEvents houseNumber As DataGridViewTextBoxColumn
    Friend WithEvents password As DataGridViewTextBoxColumn
    Friend WithEvents dateRegistered As DataGridViewTextBoxColumn
    Friend WithEvents accountStatus As DataGridViewTextBoxColumn
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnEdit As Resources.Controls.RoundedButton
    Friend WithEvents btndelete As Resources.Controls.RoundedButton
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cboRoleFilter As ComboBox
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents btnRefresh As Resources.Controls.RoundedButton
End Class
