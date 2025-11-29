Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_DepartmentManagement
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
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.admin_deptmanagement = New System.Windows.Forms.DataGridView()
        Me.department_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.department_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.head_of_department = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contact_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_of_employees = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.department_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.office_hours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.established_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.parent_department_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.budget_allocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.created_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updated_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttldepartmentmanagement = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.btnView = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.admin_deptmanagement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(49, 54)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(475, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 37
        Me.admin_label_DepartmentManagement.Text = "Department Management"
        '
        'admin_deptmanagement
        '
        Me.admin_deptmanagement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_deptmanagement.BackgroundColor = System.Drawing.Color.White
        Me.admin_deptmanagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.admin_deptmanagement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.department_id, Me.department_name, Me.head_of_department, Me.contact_number, Me.email, Me.location, Me.no_of_employees, Me.department_code, Me.office_hours, Me.established_code, Me.parent_department_id, Me.status, Me.budget_allocation, Me.created_at, Me.updated_at})
        Me.admin_deptmanagement.Location = New System.Drawing.Point(59, 116)
        Me.admin_deptmanagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_deptmanagement.Name = "admin_deptmanagement"
        Me.admin_deptmanagement.RowHeadersWidth = 51
        Me.admin_deptmanagement.Size = New System.Drawing.Size(1270, 573)
        Me.admin_deptmanagement.TabIndex = 147
        '
        'department_id
        '
        Me.department_id.HeaderText = "Department ID"
        Me.department_id.MinimumWidth = 6
        Me.department_id.Name = "department_id"
        Me.department_id.Width = 125
        '
        'department_name
        '
        Me.department_name.HeaderText = "Department Name"
        Me.department_name.MinimumWidth = 6
        Me.department_name.Name = "department_name"
        Me.department_name.Width = 125
        '
        'head_of_department
        '
        Me.head_of_department.HeaderText = "Head of Department"
        Me.head_of_department.MinimumWidth = 6
        Me.head_of_department.Name = "head_of_department"
        Me.head_of_department.Width = 125
        '
        'contact_number
        '
        Me.contact_number.HeaderText = "Contact Number"
        Me.contact_number.MinimumWidth = 6
        Me.contact_number.Name = "contact_number"
        Me.contact_number.Width = 125
        '
        'email
        '
        Me.email.HeaderText = "Email"
        Me.email.MinimumWidth = 6
        Me.email.Name = "email"
        Me.email.Width = 125
        '
        'location
        '
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 6
        Me.location.Name = "location"
        Me.location.Width = 125
        '
        'no_of_employees
        '
        Me.no_of_employees.HeaderText = "Number of Employees"
        Me.no_of_employees.MinimumWidth = 6
        Me.no_of_employees.Name = "no_of_employees"
        Me.no_of_employees.Width = 125
        '
        'department_code
        '
        Me.department_code.HeaderText = "Department Code"
        Me.department_code.MinimumWidth = 6
        Me.department_code.Name = "department_code"
        Me.department_code.Width = 125
        '
        'office_hours
        '
        Me.office_hours.HeaderText = "Office Hours"
        Me.office_hours.MinimumWidth = 6
        Me.office_hours.Name = "office_hours"
        Me.office_hours.Width = 125
        '
        'established_code
        '
        Me.established_code.HeaderText = "Established Code"
        Me.established_code.MinimumWidth = 6
        Me.established_code.Name = "established_code"
        Me.established_code.Width = 125
        '
        'parent_department_id
        '
        Me.parent_department_id.HeaderText = "Parent Department ID"
        Me.parent_department_id.MinimumWidth = 6
        Me.parent_department_id.Name = "parent_department_id"
        Me.parent_department_id.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 125
        '
        'budget_allocation
        '
        Me.budget_allocation.HeaderText = "Budget Allocation"
        Me.budget_allocation.MinimumWidth = 6
        Me.budget_allocation.Name = "budget_allocation"
        Me.budget_allocation.Width = 125
        '
        'created_at
        '
        Me.created_at.HeaderText = "Created At"
        Me.created_at.MinimumWidth = 6
        Me.created_at.Name = "created_at"
        Me.created_at.Width = 125
        '
        'updated_at
        '
        Me.updated_at.HeaderText = "Updated at"
        Me.updated_at.MinimumWidth = 6
        Me.updated_at.Name = "updated_at"
        Me.updated_at.Width = 125
        '
        'ttldepartmentmanagement
        '
        Me.ttldepartmentmanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttldepartmentmanagement.AutoSize = True
        Me.ttldepartmentmanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttldepartmentmanagement.ForeColor = System.Drawing.Color.Black
        Me.ttldepartmentmanagement.Location = New System.Drawing.Point(200, 705)
        Me.ttldepartmentmanagement.Name = "ttldepartmentmanagement"
        Me.ttldepartmentmanagement.Size = New System.Drawing.Size(38, 58)
        Me.ttldepartmentmanagement.TabIndex = 152
        Me.ttldepartmentmanagement.Text = "1"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(49, 705)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "TOTAL:"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1184, 62)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 31)
        Me.pm_cbobx_status.TabIndex = 154
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(1009, 62)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 31)
        Me.pm_cbobx_categ.TabIndex = 155
        Me.pm_cbobx_categ.Text = "Categories"
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnView.CornerRadius = 15
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnView.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnView.Location = New System.Drawing.Point(1123, 706)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(99, 34)
        Me.btnView.TabIndex = 158
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1230, 705)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 34)
        Me.btnAdd.TabIndex = 156
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1016, 706)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 35)
        Me.btnDelete.TabIndex = 157
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'UC_DepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttldepartmentmanagement)
        Me.Controls.Add(Me.admin_deptmanagement)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "UC_DepartmentManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.admin_deptmanagement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents admin_label_DepartmentManagement As Label
    Friend WithEvents BackgroundWorker1 As BackgroundWorker
    Friend WithEvents admin_deptmanagement As DataGridView
    Friend WithEvents department_id As DataGridViewTextBoxColumn
    Friend WithEvents department_name As DataGridViewTextBoxColumn
    Friend WithEvents head_of_department As DataGridViewTextBoxColumn
    Friend WithEvents contact_number As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents location As DataGridViewTextBoxColumn
    Friend WithEvents no_of_employees As DataGridViewTextBoxColumn
    Friend WithEvents department_code As DataGridViewTextBoxColumn
    Friend WithEvents office_hours As DataGridViewTextBoxColumn
    Friend WithEvents established_code As DataGridViewTextBoxColumn
    Friend WithEvents parent_department_id As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents budget_allocation As DataGridViewTextBoxColumn
    Friend WithEvents created_at As DataGridViewTextBoxColumn
    Friend WithEvents updated_at As DataGridViewTextBoxColumn
    Friend WithEvents ttldepartmentmanagement As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents btnView As Resources.Controls.RoundedButton
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
End Class
