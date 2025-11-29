<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_PropertyManagement1
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
        Me.components = New System.ComponentModel.Container()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.propertyManagementGrid = New System.Windows.Forms.DataGridView()
        Me.propertyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propertyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.condition_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datePurchased = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.warrantyExpiration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedEmployee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateUpdated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMenu = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertymanagement = New System.Windows.Forms.Label()
        Me.cmsActions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.msuAssign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDispose = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLostDamaged = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintPARICS = New System.Windows.Forms.ToolStripMenuItem()
        Me.generatePropertyCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(46, 65)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(414, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 42
        Me.admin_label_DepartmentManagement.Text = "Property Management"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1181, 84)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 31)
        Me.pm_cbobx_status.TabIndex = 40
        Me.pm_cbobx_status.Text = "Status"
        '
        'propertyManagementGrid
        '
        Me.propertyManagementGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyManagementGrid.BackgroundColor = System.Drawing.Color.White
        Me.propertyManagementGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.propertyManagementGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.propertyID, Me.propertyName, Me.category, Me.serialNumber, Me.supplier, Me.condition_status, Me.cost, Me.datePurchased, Me.warrantyExpiration, Me.assignedEmployee, Me.assignedDepartment, Me.location, Me.remarks, Me.dateCreated, Me.dateUpdated, Me.updatedBy, Me.colMenu})
        Me.propertyManagementGrid.Location = New System.Drawing.Point(56, 126)
        Me.propertyManagementGrid.Name = "propertyManagementGrid"
        Me.propertyManagementGrid.RowHeadersWidth = 51
        Me.propertyManagementGrid.RowTemplate.Height = 24
        Me.propertyManagementGrid.Size = New System.Drawing.Size(1270, 564)
        Me.propertyManagementGrid.TabIndex = 45
        '
        'propertyID
        '
        Me.propertyID.HeaderText = "Property ID"
        Me.propertyID.MinimumWidth = 6
        Me.propertyID.Name = "propertyID"
        Me.propertyID.Width = 125
        '
        'propertyName
        '
        Me.propertyName.HeaderText = "Property Name"
        Me.propertyName.MinimumWidth = 6
        Me.propertyName.Name = "propertyName"
        Me.propertyName.Width = 125
        '
        'category
        '
        Me.category.HeaderText = "Category"
        Me.category.MinimumWidth = 6
        Me.category.Name = "category"
        Me.category.Width = 125
        '
        'serialNumber
        '
        Me.serialNumber.HeaderText = "Serial Number"
        Me.serialNumber.MinimumWidth = 6
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Width = 125
        '
        'supplier
        '
        Me.supplier.HeaderText = "Supplier"
        Me.supplier.MinimumWidth = 6
        Me.supplier.Name = "supplier"
        Me.supplier.Width = 125
        '
        'condition_status
        '
        Me.condition_status.HeaderText = "Condition Status"
        Me.condition_status.MinimumWidth = 6
        Me.condition_status.Name = "condition_status"
        Me.condition_status.Width = 125
        '
        'cost
        '
        Me.cost.HeaderText = "Cost"
        Me.cost.MinimumWidth = 6
        Me.cost.Name = "cost"
        Me.cost.Width = 125
        '
        'datePurchased
        '
        Me.datePurchased.HeaderText = "Date Purchased"
        Me.datePurchased.MinimumWidth = 6
        Me.datePurchased.Name = "datePurchased"
        Me.datePurchased.Width = 125
        '
        'warrantyExpiration
        '
        Me.warrantyExpiration.HeaderText = "Warranty Expiration"
        Me.warrantyExpiration.MinimumWidth = 6
        Me.warrantyExpiration.Name = "warrantyExpiration"
        Me.warrantyExpiration.Width = 125
        '
        'assignedEmployee
        '
        Me.assignedEmployee.HeaderText = "Assigned Employee"
        Me.assignedEmployee.MinimumWidth = 6
        Me.assignedEmployee.Name = "assignedEmployee"
        Me.assignedEmployee.Width = 125
        '
        'assignedDepartment
        '
        Me.assignedDepartment.HeaderText = "Assigned Department"
        Me.assignedDepartment.MinimumWidth = 6
        Me.assignedDepartment.Name = "assignedDepartment"
        Me.assignedDepartment.Width = 125
        '
        'location
        '
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 6
        Me.location.Name = "location"
        Me.location.Width = 125
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 125
        '
        'dateCreated
        '
        Me.dateCreated.HeaderText = "Date Created"
        Me.dateCreated.MinimumWidth = 6
        Me.dateCreated.Name = "dateCreated"
        Me.dateCreated.Width = 125
        '
        'dateUpdated
        '
        Me.dateUpdated.HeaderText = "Date Updated"
        Me.dateUpdated.MinimumWidth = 6
        Me.dateUpdated.Name = "dateUpdated"
        Me.dateUpdated.Width = 125
        '
        'updatedBy
        '
        Me.updatedBy.HeaderText = "Updated By"
        Me.updatedBy.MinimumWidth = 6
        Me.updatedBy.Name = "updatedBy"
        Me.updatedBy.Width = 125
        '
        'colMenu
        '
        Me.colMenu.HeaderText = "Actions"
        Me.colMenu.MinimumWidth = 6
        Me.colMenu.Name = "colMenu"
        Me.colMenu.Text = "..."
        Me.colMenu.UseColumnTextForButtonValue = True
        Me.colMenu.Width = 125
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(1120, 717)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(99, 34)
        Me.btnEdit.TabIndex = 154
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
        Me.btnAdd.Location = New System.Drawing.Point(1227, 717)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 34)
        Me.btnAdd.TabIndex = 152
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
        Me.btnDelete.Location = New System.Drawing.Point(1012, 717)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 35)
        Me.btnDelete.TabIndex = 153
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(46, 701)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "TOTAL:"
        '
        'ttlpropertymanagement
        '
        Me.ttlpropertymanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlpropertymanagement.AutoSize = True
        Me.ttlpropertymanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlpropertymanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlpropertymanagement.Location = New System.Drawing.Point(197, 701)
        Me.ttlpropertymanagement.Name = "ttlpropertymanagement"
        Me.ttlpropertymanagement.Size = New System.Drawing.Size(38, 58)
        Me.ttlpropertymanagement.TabIndex = 158
        Me.ttlpropertymanagement.Text = "1"
        '
        'cmsActions
        '
        Me.cmsActions.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msuAssign, Me.mnuDispose, Me.mnuLostDamaged, Me.mnuViewDetails, Me.mnuPrintPARICS})
        Me.cmsActions.Name = "cmsActions"
        Me.cmsActions.Size = New System.Drawing.Size(211, 152)
        '
        'msuAssign
        '
        Me.msuAssign.Name = "msuAssign"
        Me.msuAssign.Size = New System.Drawing.Size(210, 24)
        Me.msuAssign.Text = "Transfer Property"
        '
        'mnuDispose
        '
        Me.mnuDispose.Name = "mnuDispose"
        Me.mnuDispose.Size = New System.Drawing.Size(210, 24)
        Me.mnuDispose.Text = "Dispose"
        '
        'mnuLostDamaged
        '
        Me.mnuLostDamaged.Name = "mnuLostDamaged"
        Me.mnuLostDamaged.Size = New System.Drawing.Size(210, 24)
        Me.mnuLostDamaged.Text = "Lost/Damaged"
        '
        'mnuViewDetails
        '
        Me.mnuViewDetails.Name = "mnuViewDetails"
        Me.mnuViewDetails.Size = New System.Drawing.Size(210, 24)
        Me.mnuViewDetails.Text = "View Details"
        '
        'mnuPrintPARICS
        '
        Me.mnuPrintPARICS.Name = "mnuPrintPARICS"
        Me.mnuPrintPARICS.Size = New System.Drawing.Size(210, 24)
        Me.mnuPrintPARICS.Text = "Print PAR/ICS"
        '
        'generatePropertyCard
        '
        Me.generatePropertyCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generatePropertyCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.generatePropertyCard.CornerRadius = 15
        Me.generatePropertyCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.generatePropertyCard.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.generatePropertyCard.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.generatePropertyCard.Location = New System.Drawing.Point(827, 717)
        Me.generatePropertyCard.Margin = New System.Windows.Forms.Padding(4)
        Me.generatePropertyCard.Name = "generatePropertyCard"
        Me.generatePropertyCard.Size = New System.Drawing.Size(177, 35)
        Me.generatePropertyCard.TabIndex = 160
        Me.generatePropertyCard.Text = "Generate Property Card"
        Me.generatePropertyCard.UseVisualStyleBackColor = False
        '
        'UC_PropertyManagement1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.generatePropertyCard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertymanagement)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.propertyManagementGrid)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Name = "UC_PropertyManagement1"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsActions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents pm_cbobx_status As System.Windows.Forms.ComboBox
    Friend WithEvents propertyManagementGrid As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As Resources.Controls.RoundedButton
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
    Friend WithEvents propertyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents propertyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents supplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents condition_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datePurchased As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents warrantyExpiration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents assignedEmployee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents assignedDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateCreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateUpdated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ttlpropertymanagement As System.Windows.Forms.Label
    Friend WithEvents cmsActions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents msuAssign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDispose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLostDamaged As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintPARICS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colMenu As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents generatePropertyCard As Resources.Controls.RoundedButton
End Class
