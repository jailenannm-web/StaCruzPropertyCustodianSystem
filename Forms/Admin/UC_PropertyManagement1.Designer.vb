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
        Me.filter = New System.Windows.Forms.ComboBox()
        Me.propertyManagementGrid = New System.Windows.Forms.DataGridView()
        Me.propertyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitOfMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propertyNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acquisitionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acqusitionCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sourceOfFunds = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.condition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertymanagement = New System.Windows.Forms.Label()
        Me.cmsActions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.msuAssign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDispose = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLostDamaged = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintPARICS = New System.Windows.Forms.ToolStripMenuItem()
        Me.propertymanagementsearchbar = New System.Windows.Forms.TextBox()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.generatePropertyCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.issuePropertySlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSummary = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActions.SuspendLayout()
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
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(296, 42)
        Me.admin_label_DepartmentManagement.TabIndex = 42
        Me.admin_label_DepartmentManagement.Text = "Property Management"
        '
        'filter
        '
        Me.filter.BackColor = System.Drawing.Color.White
        Me.filter.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.filter.ForeColor = System.Drawing.Color.Black
        Me.filter.Location = New System.Drawing.Point(259, 35)
        Me.filter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.filter.Name = "filter"
        Me.filter.Size = New System.Drawing.Size(151, 30)
        Me.filter.TabIndex = 40
        '
        'propertyManagementGrid
        '
        Me.propertyManagementGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyManagementGrid.BackgroundColor = System.Drawing.Color.White
        Me.propertyManagementGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.propertyManagementGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.propertyId, Me.itemName, Me.category, Me.description, Me.unitOfMeasure, Me.propertyNumber, Me.serialNumber, Me.acquisitionDate, Me.acqusitionCost, Me.totalCost, Me.sourceOfFunds, Me.assignedTo, Me.departmentId, Me.location, Me.condition, Me.status})
        Me.propertyManagementGrid.Location = New System.Drawing.Point(22, 171)
        Me.propertyManagementGrid.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.propertyManagementGrid.Name = "propertyManagementGrid"
        Me.propertyManagementGrid.RowHeadersWidth = 51
        Me.propertyManagementGrid.RowTemplate.Height = 24
        Me.propertyManagementGrid.Size = New System.Drawing.Size(895, 460)
        Me.propertyManagementGrid.TabIndex = 45
        '
        'propertyId
        '
        Me.propertyId.HeaderText = "Property ID"
        Me.propertyId.MinimumWidth = 6
        Me.propertyId.Name = "propertyId"
        Me.propertyId.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "Item Name"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'category
        '
        Me.category.HeaderText = "Category"
        Me.category.MinimumWidth = 6
        Me.category.Name = "category"
        Me.category.Width = 125
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.MinimumWidth = 6
        Me.description.Name = "description"
        Me.description.Width = 125
        '
        'unitOfMeasure
        '
        Me.unitOfMeasure.HeaderText = "Unit of Measure"
        Me.unitOfMeasure.MinimumWidth = 6
        Me.unitOfMeasure.Name = "unitOfMeasure"
        Me.unitOfMeasure.Width = 125
        '
        'propertyNumber
        '
        Me.propertyNumber.HeaderText = "Property Number"
        Me.propertyNumber.MinimumWidth = 6
        Me.propertyNumber.Name = "propertyNumber"
        Me.propertyNumber.Width = 125
        '
        'serialNumber
        '
        Me.serialNumber.HeaderText = "Serial Number"
        Me.serialNumber.MinimumWidth = 6
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Width = 125
        '
        'acquisitionDate
        '
        Me.acquisitionDate.HeaderText = "Acquisition Date"
        Me.acquisitionDate.MinimumWidth = 6
        Me.acquisitionDate.Name = "acquisitionDate"
        Me.acquisitionDate.Width = 125
        '
        'acqusitionCost
        '
        Me.acqusitionCost.HeaderText = "Acquisition Cost"
        Me.acqusitionCost.MinimumWidth = 6
        Me.acqusitionCost.Name = "acqusitionCost"
        Me.acqusitionCost.Width = 125
        '
        'totalCost
        '
        Me.totalCost.HeaderText = "Total Cost"
        Me.totalCost.MinimumWidth = 6
        Me.totalCost.Name = "totalCost"
        Me.totalCost.Width = 125
        '
        'sourceOfFunds
        '
        Me.sourceOfFunds.HeaderText = "Source of Funds"
        Me.sourceOfFunds.MinimumWidth = 6
        Me.sourceOfFunds.Name = "sourceOfFunds"
        Me.sourceOfFunds.Width = 125
        '
        'assignedTo
        '
        Me.assignedTo.HeaderText = "Assigned to"
        Me.assignedTo.MinimumWidth = 6
        Me.assignedTo.Name = "assignedTo"
        Me.assignedTo.Width = 125
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "Department ID"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Width = 125
        '
        'location
        '
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 6
        Me.location.Name = "location"
        Me.location.Width = 125
        '
        'condition
        '
        Me.condition.HeaderText = "Condition"
        Me.condition.MinimumWidth = 6
        Me.condition.Name = "condition"
        Me.condition.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 125
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
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "TOTAL:"
        '
        'ttlpropertymanagement
        '
        Me.ttlpropertymanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlpropertymanagement.AutoSize = True
        Me.ttlpropertymanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlpropertymanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlpropertymanagement.Location = New System.Drawing.Point(130, 637)
        Me.ttlpropertymanagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ttlpropertymanagement.Name = "ttlpropertymanagement"
        Me.ttlpropertymanagement.Size = New System.Drawing.Size(31, 48)
        Me.ttlpropertymanagement.TabIndex = 158
        Me.ttlpropertymanagement.Text = "1"
        '
        'cmsActions
        '
        Me.cmsActions.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msuAssign, Me.mnuDispose, Me.mnuLostDamaged, Me.mnuViewDetails, Me.mnuPrintPARICS})
        Me.cmsActions.Name = "cmsActions"
        Me.cmsActions.Size = New System.Drawing.Size(165, 114)
        '
        'msuAssign
        '
        Me.msuAssign.Name = "msuAssign"
        Me.msuAssign.Size = New System.Drawing.Size(164, 22)
        Me.msuAssign.Text = "Transfer Property"
        '
        'mnuDispose
        '
        Me.mnuDispose.Name = "mnuDispose"
        Me.mnuDispose.Size = New System.Drawing.Size(164, 22)
        Me.mnuDispose.Text = "Dispose"
        '
        'mnuLostDamaged
        '
        Me.mnuLostDamaged.Name = "mnuLostDamaged"
        Me.mnuLostDamaged.Size = New System.Drawing.Size(164, 22)
        Me.mnuLostDamaged.Text = "Lost/Damaged"
        '
        'mnuViewDetails
        '
        Me.mnuViewDetails.Name = "mnuViewDetails"
        Me.mnuViewDetails.Size = New System.Drawing.Size(164, 22)
        Me.mnuViewDetails.Text = "View Details"
        '
        'mnuPrintPARICS
        '
        Me.mnuPrintPARICS.Name = "mnuPrintPARICS"
        Me.mnuPrintPARICS.Size = New System.Drawing.Size(164, 22)
        Me.mnuPrintPARICS.Text = "Print PAR/ICS"
        '
        'propertymanagementsearchbar
        '
        Me.propertymanagementsearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.propertymanagementsearchbar.Location = New System.Drawing.Point(19, 38)
        Me.propertymanagementsearchbar.Name = "propertymanagementsearchbar"
        Me.propertymanagementsearchbar.Size = New System.Drawing.Size(225, 25)
        Me.propertymanagementsearchbar.TabIndex = 172
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(764, 660)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(74, 28)
        Me.btnEdit.TabIndex = 174
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
        Me.btnAdd.Location = New System.Drawing.Point(845, 660)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 28)
        Me.btnAdd.TabIndex = 173
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
        Me.btnDelete.Location = New System.Drawing.Point(684, 660)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(74, 28)
        Me.btnDelete.TabIndex = 175
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'generatePropertyCard
        '
        Me.generatePropertyCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generatePropertyCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.generatePropertyCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.generatePropertyCard.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.generatePropertyCard.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.generatePropertyCard.Location = New System.Drawing.Point(509, 660)
        Me.generatePropertyCard.Name = "generatePropertyCard"
        Me.generatePropertyCard.Size = New System.Drawing.Size(170, 28)
        Me.generatePropertyCard.TabIndex = 176
        Me.generatePropertyCard.Text = "Generate Property Codes"
        Me.generatePropertyCard.UseVisualStyleBackColor = False
        Me.generatePropertyCard.Visible = False
        '
        'issuePropertySlip
        '
        Me.issuePropertySlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.issuePropertySlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.issuePropertySlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.issuePropertySlip.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.issuePropertySlip.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.issuePropertySlip.Location = New System.Drawing.Point(660, 37)
        Me.issuePropertySlip.Name = "issuePropertySlip"
        Me.issuePropertySlip.Size = New System.Drawing.Size(112, 28)
        Me.issuePropertySlip.TabIndex = 177
        Me.issuePropertySlip.Text = "Issue Property Slip"
        Me.issuePropertySlip.UseVisualStyleBackColor = False
        '
        'btnSummary
        '
        Me.btnSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSummary.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnSummary.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSummary.Location = New System.Drawing.Point(780, 37)
        Me.btnSummary.Name = "btnSummary"
        Me.btnSummary.Size = New System.Drawing.Size(99, 28)
        Me.btnSummary.TabIndex = 178
        Me.btnSummary.Text = "Summary"
        Me.btnSummary.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.btnSummary)
        Me.pnlFilters.Controls.Add(Me.issuePropertySlip)
        Me.pnlFilters.Controls.Add(Me.propertymanagementsearchbar)
        Me.pnlFilters.Controls.Add(Me.filter)
        Me.pnlFilters.Location = New System.Drawing.Point(22, 73)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(11, 12, 11, 12)
        Me.pnlFilters.Size = New System.Drawing.Size(895, 82)
        Me.pnlFilters.TabIndex = 404
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(255, 16)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(43, 19)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Status"
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
        'UC_PropertyManagement1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.generatePropertyCard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertymanagement)
        Me.Controls.Add(Me.propertyManagementGrid)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UC_PropertyManagement1"
        Me.Size = New System.Drawing.Size(938, 722)
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsActions.ResumeLayout(False)
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents filter As System.Windows.Forms.ComboBox
    Friend WithEvents propertyManagementGrid As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnAdd As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ttlpropertymanagement As System.Windows.Forms.Label
    Friend WithEvents cmsActions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents msuAssign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDispose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLostDamaged As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintPARICS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents generatePropertyCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents propertymanagementsearchbar As System.Windows.Forms.TextBox
    Friend WithEvents propertyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unitOfMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents propertyNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acquisitionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acqusitionCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sourceOfFunds As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents assignedTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents departmentId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend Shadows WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents condition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents issuePropertySlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnSummary As Resources.Controls.RoundedButton
    Friend WithEvents pnlFilters As System.Windows.Forms.Panel
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
End Class
