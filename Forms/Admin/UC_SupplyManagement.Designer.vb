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
        Me.unitOfMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sourceOfFunds = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.supplyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitOfMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sourceOfFunds = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActions.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pm_cbobx_categ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(1012, 82)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 31)
        Me.pm_cbobx_categ.TabIndex = 28
        Me.pm_cbobx_categ.Text = "Categories"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1187, 82)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 31)
        Me.pm_cbobx_status.TabIndex = 27
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_table
        '
        Me.pm_table.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_table.BackgroundColor = System.Drawing.Color.White
        Me.pm_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.supplyId, Me.itemName, Me.unitOfMeasure, Me.dateReceived, Me.unitCost, Me.totalCost, Me.sourceOfFunds, Me.stockStatus, Me.createdAt, Me.updatedAt})
        Me.pm_table.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.Location = New System.Drawing.Point(62, 124)
        Me.pm_table.Name = "pm_table"
        Me.pm_table.RowHeadersWidth = 51
        Me.pm_table.RowTemplate.Height = 24
        Me.pm_table.Size = New System.Drawing.Size(1270, 573)
        Me.pm_table.TabIndex = 26
        '
        'supplyId
        '
        Me.supplyId.HeaderText = "supplyId"
        Me.supplyId.MinimumWidth = 6
        Me.supplyId.Name = "supplyId"
        Me.supplyId.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "item Name"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'unitOfMeasure
        '
        Me.unitOfMeasure.HeaderText = "unit Of Measure"
        Me.unitOfMeasure.MinimumWidth = 6
        Me.unitOfMeasure.Name = "unitOfMeasure"
        Me.unitOfMeasure.Width = 125
        '
        'dateReceived
        '
        Me.dateReceived.HeaderText = "date Received"
        Me.dateReceived.MinimumWidth = 6
        Me.dateReceived.Name = "dateReceived"
        Me.dateReceived.Width = 125
        '
        'unitCost
        '
        Me.unitCost.HeaderText = "unitCost"
        Me.unitCost.MinimumWidth = 6
        Me.unitCost.Name = "unitCost"
        Me.unitCost.Width = 125
        '
        'totalCost
        '
        Me.totalCost.HeaderText = "totalCost"
        Me.totalCost.MinimumWidth = 6
        Me.totalCost.Name = "totalCost"
        Me.totalCost.Width = 125
        '
        'sourceOfFunds
        '
        Me.sourceOfFunds.HeaderText = "source Of Funds"
        Me.sourceOfFunds.MinimumWidth = 6
        Me.sourceOfFunds.Name = "sourceOfFunds"
        Me.sourceOfFunds.Width = 125
        '
        'stockStatus
        '
        Me.stockStatus.HeaderText = "stockStatus"
        Me.stockStatus.MinimumWidth = 6
        Me.stockStatus.Name = "stockStatus"
        Me.stockStatus.Width = 125
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "createdAt"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Width = 125
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "updatedAt"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Width = 125
        '
        'admin_label_PM
        '
        Me.admin_label_PM.AutoSize = True
        Me.admin_label_PM.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_PM.Location = New System.Drawing.Point(52, 63)
        Me.admin_label_PM.Name = "admin_label_PM"
        Me.admin_label_PM.Size = New System.Drawing.Size(385, 58)
        Me.admin_label_PM.TabIndex = 32
        Me.admin_label_PM.Text = "Supply Management"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(1126, 710)
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
        Me.btnAdd.Location = New System.Drawing.Point(1233, 709)
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
        Me.btnDelete.Location = New System.Drawing.Point(1019, 710)
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
        Me.Label1.Location = New System.Drawing.Point(52, 709)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "TOTAL:"
        '
        'ttlSupplymanagement
        '
        Me.ttlSupplymanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlSupplymanagement.AutoSize = True
        Me.ttlSupplymanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlSupplymanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlSupplymanagement.Location = New System.Drawing.Point(203, 709)
        Me.ttlSupplymanagement.Name = "ttlSupplymanagement"
        Me.ttlSupplymanagement.Size = New System.Drawing.Size(47, 58)
        Me.ttlSupplymanagement.TabIndex = 158
        Me.ttlSupplymanagement.Text = "0"
        '
        'cmsActions
        '
        Me.cmsActions.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAssign, Me.mnuDispose, Me.mnuLostDamaged, Me.mnuViewDetails, Me.mnuPrintPARICS})
        Me.cmsActions.Name = "ContextMenuStrip1"
        Me.cmsActions.Size = New System.Drawing.Size(191, 124)
        '
        'mnuAssign
        '
        Me.mnuAssign.Name = "mnuAssign"
        Me.mnuAssign.Size = New System.Drawing.Size(190, 24)
        Me.mnuAssign.Text = "Transfer Property"
        '
        'mnuDispose
        '
        Me.mnuDispose.Name = "mnuDispose"
        Me.mnuDispose.Size = New System.Drawing.Size(190, 24)
        Me.mnuDispose.Text = "Dispose"
        '
        'mnuLostDamaged
        '
        Me.mnuLostDamaged.Name = "mnuLostDamaged"
        Me.mnuLostDamaged.Size = New System.Drawing.Size(190, 24)
        Me.mnuLostDamaged.Text = "Lost/Damaged"
        '
        'mnuViewDetails
        '
        Me.mnuViewDetails.Name = "mnuViewDetails"
        Me.mnuViewDetails.Size = New System.Drawing.Size(190, 24)
        Me.mnuViewDetails.Text = "View Details"
        '
        'mnuPrintPARICS
        '
        Me.mnuPrintPARICS.Name = "mnuPrintPARICS"
        Me.mnuPrintPARICS.Size = New System.Drawing.Size(190, 24)
        Me.mnuPrintPARICS.Text = "Print PAR/ICS"
        '
        'supplyId
        '
        Me.supplyId.HeaderText = "supplyId"
        Me.supplyId.MinimumWidth = 6
        Me.supplyId.Name = "supplyId"
        Me.supplyId.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "item Name"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'unitOfMeasure
        '
        Me.unitOfMeasure.HeaderText = "unit Of Measure"
        Me.unitOfMeasure.MinimumWidth = 6
        Me.unitOfMeasure.Name = "unitOfMeasure"
        Me.unitOfMeasure.Width = 125
        '
        'dateReceived
        '
        Me.dateReceived.HeaderText = "date Received"
        Me.dateReceived.MinimumWidth = 6
        Me.dateReceived.Name = "dateReceived"
        Me.dateReceived.Width = 125
        '
        'unitCost
        '
        Me.unitCost.HeaderText = "unitCost"
        Me.unitCost.MinimumWidth = 6
        Me.unitCost.Name = "unitCost"
        Me.unitCost.Width = 125
        '
        'totalCost
        '
        Me.totalCost.HeaderText = "totalCost"
        Me.totalCost.MinimumWidth = 6
        Me.totalCost.Name = "totalCost"
        Me.totalCost.Width = 125
        '
        'sourceOfFunds
        '
        Me.sourceOfFunds.HeaderText = "source Of Funds"
        Me.sourceOfFunds.MinimumWidth = 6
        Me.sourceOfFunds.Name = "sourceOfFunds"
        Me.sourceOfFunds.Width = 125
        '
        'stockStatus
        '
        Me.stockStatus.HeaderText = "stockStatus"
        Me.stockStatus.MinimumWidth = 6
        Me.stockStatus.Name = "stockStatus"
        Me.stockStatus.Width = 125
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "createdAt"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Width = 125
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "updatedAt"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Width = 125
        '
        'UC_SupplyManagement
        '
        Me.AutoScroll = True
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.supplymanagementsearchbar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlSupplymanagement)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.admin_label_PM)
        Me.Controls.Add(Me.pm_table)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Controls.Add(Me.admin_label_PropertyManagement)
        Me.Name = "UC_SupplyManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsActions.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents supplyId As DataGridViewTextBoxColumn
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents unitOfMeasure As DataGridViewTextBoxColumn
    Friend WithEvents dateReceived As DataGridViewTextBoxColumn
    Friend WithEvents unitCost As DataGridViewTextBoxColumn
    Friend WithEvents totalCost As DataGridViewTextBoxColumn
    Friend WithEvents sourceOfFunds As DataGridViewTextBoxColumn
    Friend WithEvents stockStatus As DataGridViewTextBoxColumn
    Friend WithEvents createdAt As DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents supplymanagementsearchbar As TextBox
End Class
