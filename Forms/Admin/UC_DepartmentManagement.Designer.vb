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
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.headOfDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.building = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.floorNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.shortName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.officeCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalProperties = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalSupplies = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttldepartmentmanagement = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.departmentmanagementsearchbar = New System.Windows.Forms.TextBox()
        Me.btnedit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.DepartmentAllocationSummarybtn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        CType(Me.admin_deptmanagement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.admin_label_DepartmentManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(15, 16)
        Me.admin_label_DepartmentManagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(340, 42)
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
        Me.admin_deptmanagement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.departmentId, Me.departmentName, Me.headOfDepartment, Me.email, Me.contactNumber, Me.location, Me.building, Me.floorNumber, Me.shortName, Me.officeCode, Me.description, Me.totalProperties, Me.totalSupplies, Me.status})
        Me.admin_deptmanagement.Location = New System.Drawing.Point(22, 171)
        Me.admin_deptmanagement.Name = "admin_deptmanagement"
        Me.admin_deptmanagement.RowHeadersWidth = 51
        Me.admin_deptmanagement.Size = New System.Drawing.Size(889, 460)
        Me.admin_deptmanagement.TabIndex = 147
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "Department ID"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Visible = False
        Me.departmentId.Width = 80
        '
        'departmentName
        '
        Me.departmentName.HeaderText = "Department Name"
        Me.departmentName.MinimumWidth = 150
        Me.departmentName.Name = "departmentName"
        Me.departmentName.Width = 180
        '
        'headOfDepartment
        '
        Me.headOfDepartment.HeaderText = "Head of Department"
        Me.headOfDepartment.MinimumWidth = 120
        Me.headOfDepartment.Name = "headOfDepartment"
        Me.headOfDepartment.Width = 150
        '
        'email
        '
        Me.email.HeaderText = "Email"
        Me.email.MinimumWidth = 150
        Me.email.Name = "email"
        Me.email.Width = 180
        '
        'contactNumber
        '
        Me.contactNumber.HeaderText = "Contact Number"
        Me.contactNumber.MinimumWidth = 100
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Width = 120
        '
        'location
        '
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 100
        Me.location.Name = "location"
        Me.location.Width = 120
        '
        'building
        '
        Me.building.HeaderText = "Building"
        Me.building.MinimumWidth = 80
        Me.building.Name = "building"
        Me.building.Width = 125
        '
        'floorNumber
        '
        Me.floorNumber.HeaderText = "Floor Number"
        Me.floorNumber.MinimumWidth = 60
        Me.floorNumber.Name = "floorNumber"
        Me.floorNumber.Width = 80
        '
        'shortName
        '
        Me.shortName.HeaderText = "Short Name"
        Me.shortName.MinimumWidth = 80
        Me.shortName.Name = "shortName"
        Me.shortName.Width = 125
        '
        'officeCode
        '
        Me.officeCode.HeaderText = "Office Code"
        Me.officeCode.MinimumWidth = 80
        Me.officeCode.Name = "officeCode"
        Me.officeCode.Width = 125
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.MinimumWidth = 150
        Me.description.Name = "description"
        Me.description.Width = 200
        '
        'totalProperties
        '
        Me.totalProperties.HeaderText = "Total Properties"
        Me.totalProperties.MinimumWidth = 60
        Me.totalProperties.Name = "totalProperties"
        Me.totalProperties.Width = 80
        '
        'totalSupplies
        '
        Me.totalSupplies.HeaderText = "Total Supplies"
        Me.totalSupplies.MinimumWidth = 60
        Me.totalSupplies.Name = "totalSupplies"
        Me.totalSupplies.Width = 80
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 80
        Me.status.Name = "status"
        Me.status.Width = 125
        '
        'ttldepartmentmanagement
        '
        Me.ttldepartmentmanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttldepartmentmanagement.AutoSize = True
        Me.ttldepartmentmanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttldepartmentmanagement.ForeColor = System.Drawing.Color.Black
        Me.ttldepartmentmanagement.Location = New System.Drawing.Point(130, 637)
        Me.ttldepartmentmanagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ttldepartmentmanagement.Name = "ttldepartmentmanagement"
        Me.ttldepartmentmanagement.Size = New System.Drawing.Size(38, 48)
        Me.ttldepartmentmanagement.TabIndex = 152
        Me.ttldepartmentmanagement.Text = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 637)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 48)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "TOTAL:"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_status.Location = New System.Drawing.Point(446, 36)
        Me.pm_cbobx_status.Margin = New System.Windows.Forms.Padding(2)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(136, 30)
        Me.pm_cbobx_status.TabIndex = 154
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(259, 37)
        Me.pm_cbobx_categ.Margin = New System.Windows.Forms.Padding(2)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(151, 30)
        Me.pm_cbobx_categ.TabIndex = 155
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(837, 637)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 28)
        Me.btnAdd.TabIndex = 156
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(677, 637)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(74, 28)
        Me.btnDelete.TabIndex = 157
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'departmentmanagementsearchbar
        '
        Me.departmentmanagementsearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.departmentmanagementsearchbar.Location = New System.Drawing.Point(14, 41)
        Me.departmentmanagementsearchbar.Name = "departmentmanagementsearchbar"
        Me.departmentmanagementsearchbar.Size = New System.Drawing.Size(226, 25)
        Me.departmentmanagementsearchbar.TabIndex = 158
        '
        'btnedit
        '
        Me.btnedit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnedit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnedit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnedit.Location = New System.Drawing.Point(757, 637)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(74, 28)
        Me.btnedit.TabIndex = 160
        Me.btnedit.Text = "Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'DepartmentAllocationSummarybtn
        '
        Me.DepartmentAllocationSummarybtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DepartmentAllocationSummarybtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.DepartmentAllocationSummarybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DepartmentAllocationSummarybtn.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.DepartmentAllocationSummarybtn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.DepartmentAllocationSummarybtn.Location = New System.Drawing.Point(450, 637)
        Me.DepartmentAllocationSummarybtn.Name = "DepartmentAllocationSummarybtn"
        Me.DepartmentAllocationSummarybtn.Size = New System.Drawing.Size(221, 29)
        Me.DepartmentAllocationSummarybtn.TabIndex = 392
        Me.DepartmentAllocationSummarybtn.Text = "Department Allocation Summary"
        Me.DepartmentAllocationSummarybtn.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.lblStatus)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.departmentmanagementsearchbar)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_categ)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_status)
        Me.pnlFilters.Location = New System.Drawing.Point(22, 73)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(11, 12, 11, 12)
        Me.pnlFilters.Size = New System.Drawing.Size(895, 82)
        Me.pnlFilters.TabIndex = 401
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
        Me.lblCategory.Size = New System.Drawing.Size(59, 19)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
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
        'UC_DepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.DepartmentAllocationSummarybtn)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttldepartmentmanagement)
        Me.Controls.Add(Me.admin_deptmanagement)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "UC_DepartmentManagement"
        Me.Size = New System.Drawing.Size(938, 722)
        CType(Me.admin_deptmanagement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents admin_label_DepartmentManagement As Label
    Friend WithEvents BackgroundWorker1 As BackgroundWorker
    Friend WithEvents admin_deptmanagement As DataGridView
    Friend WithEvents ttldepartmentmanagement As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents btnAdd As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents departmentmanagementsearchbar As TextBox
    Friend WithEvents departmentId As DataGridViewTextBoxColumn
    Friend WithEvents departmentName As DataGridViewTextBoxColumn
    Friend WithEvents headOfDepartment As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents contactNumber As DataGridViewTextBoxColumn
    Friend Shadows WithEvents location As DataGridViewTextBoxColumn
    Friend WithEvents building As DataGridViewTextBoxColumn
    Friend WithEvents floorNumber As DataGridViewTextBoxColumn
    Friend WithEvents shortName As DataGridViewTextBoxColumn
    Friend WithEvents officeCode As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents totalProperties As DataGridViewTextBoxColumn
    Friend WithEvents totalSupplies As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents btnedit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents DepartmentAllocationSummarybtn As Resources.Controls.RoundedButton
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSearch As Label
End Class
