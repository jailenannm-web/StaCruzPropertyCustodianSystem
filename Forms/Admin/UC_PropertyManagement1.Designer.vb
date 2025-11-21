<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_PropertyManagement1
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
        Me.pm_txtbox_search = New System.Windows.Forms.TextBox()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.propertyManagementGrid = New System.Windows.Forms.DataGridView()
        Me.propertyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propertyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datePurchased = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.warrantyExpiration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedEmployee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateUpdated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pm_txtbox_search
        '
        Me.pm_txtbox_search.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_txtbox_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_txtbox_search.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_txtbox_search.ForeColor = System.Drawing.Color.White
        Me.pm_txtbox_search.Location = New System.Drawing.Point(115, 126)
        Me.pm_txtbox_search.Name = "pm_txtbox_search"
        Me.pm_txtbox_search.Size = New System.Drawing.Size(701, 33)
        Me.pm_txtbox_search.TabIndex = 43
        Me.pm_txtbox_search.Text = "Search"
        Me.pm_txtbox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(57, 55)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(414, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 42
        Me.admin_label_DepartmentManagement.Text = "Property Management"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1085, 126)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 38)
        Me.pm_cbobx_status.TabIndex = 40
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(910, 126)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 38)
        Me.pm_cbobx_categ.TabIndex = 41
        Me.pm_cbobx_categ.Text = "Categories"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(67, 126)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'propertyManagementGrid
        '
        Me.propertyManagementGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyManagementGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.propertyManagementGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.propertyManagementGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.propertyID, Me.propertyName, Me.category, Me.serialNumber, Me.supplier, Me.conditionStatus, Me.cost, Me.datePurchased, Me.warrantyExpiration, Me.assignedEmployee, Me.assignedDepartment, Me.location, Me.remarks, Me.dateCreated, Me.dateUpdated})
        Me.propertyManagementGrid.Location = New System.Drawing.Point(67, 189)
        Me.propertyManagementGrid.Name = "propertyManagementGrid"
        Me.propertyManagementGrid.RowHeadersWidth = 51
        Me.propertyManagementGrid.RowTemplate.Height = 24
        Me.propertyManagementGrid.Size = New System.Drawing.Size(1163, 479)
        Me.propertyManagementGrid.TabIndex = 45
        '
        'propertyID
        '
        Me.propertyID.HeaderText = "Property ID"
        Me.propertyID.MinimumWidth = 6
        Me.propertyID.Name = "propertyID"
        '
        'propertyName
        '
        Me.propertyName.HeaderText = "Property Name"
        Me.propertyName.MinimumWidth = 6
        Me.propertyName.Name = "propertyName"
        '
        'category
        '
        Me.category.HeaderText = "Category"
        Me.category.MinimumWidth = 6
        Me.category.Name = "category"
        '
        'serialNumber
        '
        Me.serialNumber.HeaderText = "Serial Number"
        Me.serialNumber.MinimumWidth = 6
        Me.serialNumber.Name = "serialNumber"
        '
        'supplier
        '
        Me.supplier.HeaderText = "Supplier"
        Me.supplier.MinimumWidth = 6
        Me.supplier.Name = "supplier"
        '
        'conditionStatus
        '
        Me.conditionStatus.HeaderText = "Condition Status"
        Me.conditionStatus.MinimumWidth = 6
        Me.conditionStatus.Name = "conditionStatus"
        '
        'cost
        '
        Me.cost.HeaderText = "Cost"
        Me.cost.MinimumWidth = 6
        Me.cost.Name = "cost"
        '
        'datePurchased
        '
        Me.datePurchased.HeaderText = "Date Purchased"
        Me.datePurchased.MinimumWidth = 6
        Me.datePurchased.Name = "datePurchased"
        '
        'warrantyExpiration
        '
        Me.warrantyExpiration.HeaderText = "Warranty Expiration"
        Me.warrantyExpiration.MinimumWidth = 6
        Me.warrantyExpiration.Name = "warrantyExpiration"
        '
        'assignedEmployee
        '
        Me.assignedEmployee.HeaderText = "Assigned Employee"
        Me.assignedEmployee.MinimumWidth = 6
        Me.assignedEmployee.Name = "assignedEmployee"
        '
        'assignedDepartment
        '
        Me.assignedDepartment.HeaderText = "Assigned Department"
        Me.assignedDepartment.MinimumWidth = 6
        Me.assignedDepartment.Name = "assignedDepartment"
        '
        'location
        '
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 6
        Me.location.Name = "location"
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        '
        'dateCreated
        '
        Me.dateCreated.HeaderText = "Date Created"
        Me.dateCreated.MinimumWidth = 6
        Me.dateCreated.Name = "dateCreated"
        '
        'dateUpdated
        '
        Me.dateUpdated.HeaderText = "Date Updated"
        Me.dateUpdated.MinimumWidth = 6
        Me.dateUpdated.Name = "dateUpdated"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(981, 690)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(121, 34)
        Me.btnEdit.TabIndex = 154
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1110, 689)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(121, 34)
        Me.btnAdd.TabIndex = 152
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(853, 689)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 35)
        Me.btnDelete.TabIndex = 153
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'PropertyManagement1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.propertyManagementGrid)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pm_txtbox_search)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Name = "PropertyManagement1"
        Me.Size = New System.Drawing.Size(1288, 775)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pm_txtbox_search As System.Windows.Forms.TextBox
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents pm_cbobx_status As System.Windows.Forms.ComboBox
    Friend WithEvents pm_cbobx_categ As System.Windows.Forms.ComboBox
    Friend WithEvents propertyManagementGrid As System.Windows.Forms.DataGridView
    Friend WithEvents propertyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents propertyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents supplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents conditionStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datePurchased As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents warrantyExpiration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents assignedEmployee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents assignedDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateCreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateUpdated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEdit As Resources.Controls.RoundedButton
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
End Class
