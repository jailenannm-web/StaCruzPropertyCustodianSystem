Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports StaCruzPropertyCustodianSystem.Resources.Controls
Partial Class UC_SupplyManagement
    Inherits System.Windows.Forms.UserControl

    ' ... [Dispose method and other boilerplate remains unchanged] ...

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.admin_label_PropertyManagement = New System.Windows.Forms.Label()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_table = New System.Windows.Forms.DataGridView()
        Me.supplyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitOfMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sourceOfFunds = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_PM = New System.Windows.Forms.Label()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlSupplymanagement = New System.Windows.Forms.Label()
        Me.cmsActions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAssign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDispose = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLostDamaged = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintPARICS = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.supplymanagementsearchbar = New System.Windows.Forms.TextBox()
        Me.btnSummary = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActions.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_PropertyManagement
        '
        Me.admin_label_PropertyManagement.Location = New System.Drawing.Point(0, 0)
        Me.admin_label_PropertyManagement.Name = "admin_label_PropertyManagement"
        Me.admin_label_PropertyManagement.Size = New System.Drawing.Size(100, 23)
        Me.admin_label_PropertyManagement.TabIndex = 31
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(442, 35)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(151, 30)
        Me.pm_cbobx_categ.TabIndex = 28
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_status.Location = New System.Drawing.Point(259, 35)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(151, 30)
        Me.pm_cbobx_status.TabIndex = 27
        '
        'pm_table
        '
        Me.pm_table.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.pm_table.BackgroundColor = System.Drawing.Color.White
        Me.pm_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.supplyId, Me.itemName, Me.category, Me.description, Me.quantity, Me.supplier, Me.assignedTo, Me.location, Me.stockStatus, Me.unitOfMeasure, Me.dateReceived, Me.unitCost, Me.totalCost, Me.sourceOfFunds, Me.createdAt, Me.updatedAt})
        Me.pm_table.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.Location = New System.Drawing.Point(39, 160)
        Me.pm_table.Name = "pm_table"
        Me.pm_table.RowHeadersWidth = 51
        Me.pm_table.RowTemplate.Height = 24
        Me.pm_table.Size = New System.Drawing.Size(869, 448)
        Me.pm_table.TabIndex = 26
        '
        'supplyId
        '
        Me.supplyId.HeaderText = "Supply ID"
        Me.supplyId.MinimumWidth = 6
        Me.supplyId.Name = "supplyId"
        Me.supplyId.Visible = False
        Me.supplyId.Width = 80
        '
        'itemName
        '
        Me.itemName.HeaderText = "Item Name"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 77
        '
        'category
        '
        Me.category.HeaderText = "Category"
        Me.category.MinimumWidth = 6
        Me.category.Name = "category"
        Me.category.Width = 74
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.MinimumWidth = 6
        Me.description.Name = "description"
        Me.description.Width = 85
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.MinimumWidth = 6
        Me.quantity.Name = "quantity"
        Me.quantity.Width = 71
        '
        'supplier
        '
        Me.supplier.HeaderText = "Supplier"
        Me.supplier.MinimumWidth = 6
        Me.supplier.Name = "supplier"
        Me.supplier.Width = 70
        '
        'assignedTo
        '
        Me.assignedTo.HeaderText = "Assigned To"
        Me.assignedTo.MinimumWidth = 6
        Me.assignedTo.Name = "assignedTo"
        Me.assignedTo.Width = 84
        '
        'location
        '
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 6
        Me.location.Name = "location"
        Me.location.Width = 73
        '
        'stockStatus
        '
        Me.stockStatus.HeaderText = "Stock Status"
        Me.stockStatus.MinimumWidth = 6
        Me.stockStatus.Name = "stockStatus"
        Me.stockStatus.Width = 86
        '
        'unitOfMeasure
        '
        Me.unitOfMeasure.HeaderText = "Unit"
        Me.unitOfMeasure.MinimumWidth = 6
        Me.unitOfMeasure.Name = "unitOfMeasure"
        Me.unitOfMeasure.Width = 51
        '
        'dateReceived
        '
        Me.dateReceived.HeaderText = "Date Received"
        Me.dateReceived.MinimumWidth = 6
        Me.dateReceived.Name = "dateReceived"
        Me.dateReceived.Visible = False
        Me.dateReceived.Width = 110
        '
        'unitCost
        '
        Me.unitCost.HeaderText = "Unit Cost"
        Me.unitCost.MinimumWidth = 6
        Me.unitCost.Name = "unitCost"
        Me.unitCost.Width = 70
        '
        'totalCost
        '
        Me.totalCost.HeaderText = "Total Cost"
        Me.totalCost.MinimumWidth = 6
        Me.totalCost.Name = "totalCost"
        Me.totalCost.Width = 74
        '
        'sourceOfFunds
        '
        Me.sourceOfFunds.HeaderText = "Source Of Funds"
        Me.sourceOfFunds.MinimumWidth = 6
        Me.sourceOfFunds.Name = "sourceOfFunds"
        Me.sourceOfFunds.Width = 77
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "Created At"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Visible = False
        Me.createdAt.Width = 125
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "Updated At"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Visible = False
        Me.updatedAt.Width = 125
        '
        'admin_label_PM
        '
        Me.admin_label_PM.AutoSize = True
        Me.admin_label_PM.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.admin_label_PM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.admin_label_PM.Location = New System.Drawing.Point(32, 14)
        Me.admin_label_PM.Name = "admin_label_PM"
        Me.admin_label_PM.Size = New System.Drawing.Size(275, 42)
        Me.admin_label_PM.TabIndex = 32
        Me.admin_label_PM.Text = "Supply Management"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(702, 617)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(99, 28)
        Me.btnEdit.TabIndex = 154
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
        Me.btnAdd.Location = New System.Drawing.Point(809, 616)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 28)
        Me.btnAdd.TabIndex = 152
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
        Me.btnDelete.Location = New System.Drawing.Point(595, 617)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 29)
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
        Me.Label1.Location = New System.Drawing.Point(31, 616)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 48)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "TOTAL:"
        '
        'ttlSupplymanagement
        '
        Me.ttlSupplymanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlSupplymanagement.AutoSize = True
        Me.ttlSupplymanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlSupplymanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlSupplymanagement.Location = New System.Drawing.Point(144, 616)
        Me.ttlSupplymanagement.Name = "ttlSupplymanagement"
        Me.ttlSupplymanagement.Size = New System.Drawing.Size(38, 48)
        Me.ttlSupplymanagement.TabIndex = 158
        Me.ttlSupplymanagement.Text = "0"
        '
        'cmsActions
        '
        Me.cmsActions.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAssign, Me.mnuDispose, Me.mnuLostDamaged, Me.mnuViewDetails, Me.mnuPrintPARICS})
        Me.cmsActions.Name = "ContextMenuStrip1"
        Me.cmsActions.Size = New System.Drawing.Size(165, 114)
        '
        'mnuAssign
        '
        Me.mnuAssign.Name = "mnuAssign"
        Me.mnuAssign.Size = New System.Drawing.Size(164, 22)
        Me.mnuAssign.Text = "Transfer Property"
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
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(872, -27)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'supplymanagementsearchbar
        '
        Me.supplymanagementsearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.supplymanagementsearchbar.ForeColor = System.Drawing.Color.Gray
        Me.supplymanagementsearchbar.Location = New System.Drawing.Point(19, 38)
        Me.supplymanagementsearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.supplymanagementsearchbar.Name = "supplymanagementsearchbar"
        Me.supplymanagementsearchbar.Size = New System.Drawing.Size(225, 25)
        Me.supplymanagementsearchbar.TabIndex = 178
        Me.supplymanagementsearchbar.Text = "Search supplies..."
        '
        'btnSummary
        '
        Me.btnSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSummary.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnSummary.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSummary.Location = New System.Drawing.Point(727, 38)
        Me.btnSummary.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSummary.Name = "btnSummary"
        Me.btnSummary.Size = New System.Drawing.Size(125, 28)
        Me.btnSummary.TabIndex = 180
        Me.btnSummary.Text = "Summary"
        Me.btnSummary.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.Label2)
        Me.pnlFilters.Controls.Add(Me.btnSummary)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.supplymanagementsearchbar)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_status)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_categ)
        Me.pnlFilters.Location = New System.Drawing.Point(39, 73)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(11, 12, 11, 12)
        Me.pnlFilters.Size = New System.Drawing.Size(869, 82)
        Me.pnlFilters.TabIndex = 405
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(438, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 19)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Status"
        '
        'UC_SupplyManagement
        '
        Me.AutoScroll = True
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlSupplymanagement)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.admin_label_PM)
        Me.Controls.Add(Me.pm_table)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.admin_label_PropertyManagement)
        Me.Name = "UC_SupplyManagement"
        Me.Size = New System.Drawing.Size(938, 705)
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsActions.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' ---------- Friend Controls ----------
    Friend WithEvents admin_label_PropertyManagement As Label
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_table As DataGridView
    Friend WithEvents admin_label_PM As Label
    Friend WithEvents btnEdit As RoundedButton
    Friend WithEvents btnAdd As RoundedButton
    Friend WithEvents btnDelete As RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlSupplymanagement As Label
    Friend WithEvents cmsActions As ContextMenuStrip
    Private components As IContainer
    Friend WithEvents mnuAssign As ToolStripMenuItem
    Friend WithEvents mnuDispose As ToolStripMenuItem
    Friend WithEvents mnuLostDamaged As ToolStripMenuItem
    Friend WithEvents mnuViewDetails As ToolStripMenuItem
    Friend WithEvents mnuPrintPARICS As ToolStripMenuItem
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents supplymanagementsearchbar As TextBox
    Friend WithEvents supplyId As DataGridViewTextBoxColumn
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents supplier As DataGridViewTextBoxColumn
    Friend WithEvents assignedTo As DataGridViewTextBoxColumn
    Friend Shadows WithEvents location As DataGridViewTextBoxColumn
    Friend WithEvents stockStatus As DataGridViewTextBoxColumn
    Friend WithEvents unitOfMeasure As DataGridViewTextBoxColumn
    Friend WithEvents dateReceived As DataGridViewTextBoxColumn
    Friend WithEvents unitCost As DataGridViewTextBoxColumn
    Friend WithEvents totalCost As DataGridViewTextBoxColumn
    Friend WithEvents sourceOfFunds As DataGridViewTextBoxColumn
    Friend WithEvents createdAt As DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As DataGridViewTextBoxColumn
    Friend WithEvents btnSummary As RoundedButton
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents Label2 As Label
    ' Removed duplicate search field: supplymanagementssearchbar
End Class
