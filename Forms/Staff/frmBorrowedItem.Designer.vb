<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBorrowedItem
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
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblFilterStatus = New System.Windows.Forms.Label()
        Me.cboFilterStatus = New System.Windows.Forms.ComboBox()
        Me.lblFilterType = New System.Windows.Forms.Label()
        Me.cboFilterType = New System.Windows.Forms.ComboBox()
        Me.pnlStats = New System.Windows.Forms.Panel()
        Me.lblTotalItems = New System.Windows.Forms.Label()
        Me.lblPropertyCount = New System.Windows.Forms.Label()
        Me.lblSupplyCount = New System.Windows.Forms.Label()
        Me.lblNeedsRepair = New System.Windows.Forms.Label()
        Me.dgvBorrowedItems = New System.Windows.Forms.DataGridView()
        Me.colRequestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPropertyNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApprovedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPurpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCanMaintenance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPropertyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnRequestMaintenance = New System.Windows.Forms.Button()
        Me.btnReturnItem = New System.Windows.Forms.Button()
        Me.lblNoItems = New System.Windows.Forms.Label()
        Me.btnBorrowReturn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Essuance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlTop.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.pnlStats.SuspendLayout()
        CType(Me.dgvBorrowedItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.btnRefresh)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlTop.Size = New System.Drawing.Size(1200, 70)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(239, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "My Borrowed Items"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(1060, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 50)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.txtSearch)
        Me.pnlFilters.Controls.Add(Me.lblFilterStatus)
        Me.pnlFilters.Controls.Add(Me.cboFilterStatus)
        Me.pnlFilters.Controls.Add(Me.lblFilterType)
        Me.pnlFilters.Controls.Add(Me.cboFilterType)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 70)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.pnlFilters.Size = New System.Drawing.Size(1200, 80)
        Me.pnlFilters.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearch.Location = New System.Drawing.Point(20, 18)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(60, 15)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "🔍 Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(20, 38)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(300, 25)
        Me.txtSearch.TabIndex = 1
        '
        'lblFilterStatus
        '
        Me.lblFilterStatus.AutoSize = True
        Me.lblFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFilterStatus.Location = New System.Drawing.Point(340, 18)
        Me.lblFilterStatus.Name = "lblFilterStatus"
        Me.lblFilterStatus.Size = New System.Drawing.Size(87, 15)
        Me.lblFilterStatus.TabIndex = 2
        Me.lblFilterStatus.Text = "Filter by Status:"
        '
        'cboFilterStatus
        '
        Me.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboFilterStatus.FormattingEnabled = True
        Me.cboFilterStatus.Location = New System.Drawing.Point(340, 38)
        Me.cboFilterStatus.Name = "cboFilterStatus"
        Me.cboFilterStatus.Size = New System.Drawing.Size(200, 25)
        Me.cboFilterStatus.TabIndex = 3
        '
        'lblFilterType
        '
        Me.lblFilterType.AutoSize = True
        Me.lblFilterType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFilterType.Location = New System.Drawing.Point(560, 18)
        Me.lblFilterType.Name = "lblFilterType"
        Me.lblFilterType.Size = New System.Drawing.Size(80, 15)
        Me.lblFilterType.TabIndex = 4
        Me.lblFilterType.Text = "Filter by Type:"
        '
        'cboFilterType
        '
        Me.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboFilterType.FormattingEnabled = True
        Me.cboFilterType.Location = New System.Drawing.Point(560, 38)
        Me.cboFilterType.Name = "cboFilterType"
        Me.cboFilterType.Size = New System.Drawing.Size(200, 25)
        Me.cboFilterType.TabIndex = 5
        '
        'pnlStats
        '
        Me.pnlStats.BackColor = System.Drawing.Color.White
        Me.pnlStats.Controls.Add(Me.lblTotalItems)
        Me.pnlStats.Controls.Add(Me.lblPropertyCount)
        Me.pnlStats.Controls.Add(Me.lblSupplyCount)
        Me.pnlStats.Controls.Add(Me.lblNeedsRepair)
        Me.pnlStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStats.Location = New System.Drawing.Point(0, 150)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlStats.Size = New System.Drawing.Size(1200, 60)
        Me.pnlStats.TabIndex = 2
        '
        'lblTotalItems
        '
        Me.lblTotalItems.AutoSize = True
        Me.lblTotalItems.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTotalItems.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalItems.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTotalItems.Location = New System.Drawing.Point(20, 10)
        Me.lblTotalItems.Margin = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.lblTotalItems.Name = "lblTotalItems"
        Me.lblTotalItems.Padding = New System.Windows.Forms.Padding(0, 10, 30, 0)
        Me.lblTotalItems.Size = New System.Drawing.Size(128, 29)
        Me.lblTotalItems.TabIndex = 0
        Me.lblTotalItems.Text = "Total Items: 0"
        '
        'lblPropertyCount
        '
        Me.lblPropertyCount.AutoSize = True
        Me.lblPropertyCount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPropertyCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblPropertyCount.Location = New System.Drawing.Point(180, 20)
        Me.lblPropertyCount.Margin = New System.Windows.Forms.Padding(30, 0, 30, 0)
        Me.lblPropertyCount.Name = "lblPropertyCount"
        Me.lblPropertyCount.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.lblPropertyCount.Size = New System.Drawing.Size(116, 19)
        Me.lblPropertyCount.TabIndex = 1
        Me.lblPropertyCount.Text = "Properties: 0"
        '
        'lblSupplyCount
        '
        Me.lblSupplyCount.AutoSize = True
        Me.lblSupplyCount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSupplyCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblSupplyCount.Location = New System.Drawing.Point(340, 20)
        Me.lblSupplyCount.Margin = New System.Windows.Forms.Padding(30, 0, 30, 0)
        Me.lblSupplyCount.Name = "lblSupplyCount"
        Me.lblSupplyCount.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.lblSupplyCount.Size = New System.Drawing.Size(104, 19)
        Me.lblSupplyCount.TabIndex = 2
        Me.lblSupplyCount.Text = "Supplies: 0"
        '
        'lblNeedsRepair
        '
        Me.lblNeedsRepair.AutoSize = True
        Me.lblNeedsRepair.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblNeedsRepair.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblNeedsRepair.Location = New System.Drawing.Point(490, 20)
        Me.lblNeedsRepair.Name = "lblNeedsRepair"
        Me.lblNeedsRepair.Size = New System.Drawing.Size(124, 19)
        Me.lblNeedsRepair.TabIndex = 3
        Me.lblNeedsRepair.Text = "Needs Attention: 0"
        '
        'dgvBorrowedItems
        '
        Me.dgvBorrowedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBorrowedItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRequestId, Me.colItemType, Me.colItemName, Me.colPropertyNumber, Me.colSerialNumber, Me.colQuantity, Me.colCondition, Me.colApprovedDate, Me.colPurpose, Me.colRemarks, Me.colCanMaintenance, Me.colPropertyId})
        Me.dgvBorrowedItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBorrowedItems.Location = New System.Drawing.Point(0, 210)
        Me.dgvBorrowedItems.Name = "dgvBorrowedItems"
        Me.dgvBorrowedItems.RowHeadersWidth = 51
        Me.dgvBorrowedItems.Size = New System.Drawing.Size(1200, 390)
        Me.dgvBorrowedItems.TabIndex = 3
        '
        'colRequestId
        '
        Me.colRequestId.HeaderText = "Request ID"
        Me.colRequestId.MinimumWidth = 6
        Me.colRequestId.Name = "colRequestId"
        Me.colRequestId.ReadOnly = True
        Me.colRequestId.Visible = False
        Me.colRequestId.Width = 125
        '
        'colItemType
        '
        Me.colItemType.HeaderText = "Type"
        Me.colItemType.MinimumWidth = 6
        Me.colItemType.Name = "colItemType"
        Me.colItemType.ReadOnly = True
        Me.colItemType.Width = 90
        '
        'colItemName
        '
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MinimumWidth = 6
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 200
        '
        'colPropertyNumber
        '
        Me.colPropertyNumber.HeaderText = "Property No."
        Me.colPropertyNumber.MinimumWidth = 6
        Me.colPropertyNumber.Name = "colPropertyNumber"
        Me.colPropertyNumber.ReadOnly = True
        Me.colPropertyNumber.Width = 120
        '
        'colSerialNumber
        '
        Me.colSerialNumber.HeaderText = "Serial No."
        Me.colSerialNumber.MinimumWidth = 6
        Me.colSerialNumber.Name = "colSerialNumber"
        Me.colSerialNumber.ReadOnly = True
        Me.colSerialNumber.Width = 120
        '
        'colQuantity
        '
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.MinimumWidth = 6
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 90
        '
        'colCondition
        '
        Me.colCondition.HeaderText = "Condition"
        Me.colCondition.MinimumWidth = 6
        Me.colCondition.Name = "colCondition"
        Me.colCondition.ReadOnly = True
        Me.colCondition.Width = 110
        '
        'colApprovedDate
        '
        Me.colApprovedDate.HeaderText = "Approved Date"
        Me.colApprovedDate.MinimumWidth = 6
        Me.colApprovedDate.Name = "colApprovedDate"
        Me.colApprovedDate.ReadOnly = True
        Me.colApprovedDate.Width = 130
        '
        'colPurpose
        '
        Me.colPurpose.HeaderText = "Purpose"
        Me.colPurpose.MinimumWidth = 6
        Me.colPurpose.Name = "colPurpose"
        Me.colPurpose.ReadOnly = True
        Me.colPurpose.Width = 150
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.MinimumWidth = 6
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        Me.colRemarks.Width = 150
        '
        'colCanMaintenance
        '
        Me.colCanMaintenance.HeaderText = "CanMaintenance"
        Me.colCanMaintenance.MinimumWidth = 6
        Me.colCanMaintenance.Name = "colCanMaintenance"
        Me.colCanMaintenance.ReadOnly = True
        Me.colCanMaintenance.Visible = False
        Me.colCanMaintenance.Width = 125
        '
        'colPropertyId
        '
        Me.colPropertyId.HeaderText = "PropertyId"
        Me.colPropertyId.MinimumWidth = 6
        Me.colPropertyId.Name = "colPropertyId"
        Me.colPropertyId.ReadOnly = True
        Me.colPropertyId.Visible = False
        Me.colPropertyId.Width = 125
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Controls.Add(Me.Essuance)
        Me.pnlBottom.Controls.Add(Me.btnBorrowReturn)
        Me.pnlBottom.Controls.Add(Me.btnRequestMaintenance)
        Me.pnlBottom.Controls.Add(Me.btnReturnItem)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 600)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(20, 20, 20, 20)
        Me.pnlBottom.Size = New System.Drawing.Size(1200, 80)
        Me.pnlBottom.TabIndex = 4
        '
        'btnRequestMaintenance
        '
        Me.btnRequestMaintenance.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnRequestMaintenance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRequestMaintenance.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnRequestMaintenance.FlatAppearance.BorderSize = 0
        Me.btnRequestMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequestMaintenance.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRequestMaintenance.ForeColor = System.Drawing.Color.White
        Me.btnRequestMaintenance.Location = New System.Drawing.Point(780, 20)
        Me.btnRequestMaintenance.Name = "btnRequestMaintenance"
        Me.btnRequestMaintenance.Size = New System.Drawing.Size(200, 40)
        Me.btnRequestMaintenance.TabIndex = 0
        Me.btnRequestMaintenance.Text = "🔧 Request Maintenance"
        Me.btnRequestMaintenance.UseVisualStyleBackColor = False
        '
        'btnReturnItem
        '
        Me.btnReturnItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnReturnItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReturnItem.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnReturnItem.FlatAppearance.BorderSize = 0
        Me.btnReturnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturnItem.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnReturnItem.ForeColor = System.Drawing.Color.White
        Me.btnReturnItem.Location = New System.Drawing.Point(980, 20)
        Me.btnReturnItem.Name = "btnReturnItem"
        Me.btnReturnItem.Size = New System.Drawing.Size(200, 40)
        Me.btnReturnItem.TabIndex = 1
        Me.btnReturnItem.Text = "↩️ Return Item"
        Me.btnReturnItem.UseVisualStyleBackColor = False
        '
        'lblNoItems
        '
        Me.lblNoItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoItems.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblNoItems.ForeColor = System.Drawing.Color.Gray
        Me.lblNoItems.Location = New System.Drawing.Point(0, 210)
        Me.lblNoItems.Name = "lblNoItems"
        Me.lblNoItems.Size = New System.Drawing.Size(1200, 390)
        Me.lblNoItems.TabIndex = 5
        Me.lblNoItems.Text = "No borrowed items found. Your approved requests will appear here."
        Me.lblNoItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoItems.Visible = False
        '
        'btnBorrowReturn
        '
        Me.btnBorrowReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBorrowReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBorrowReturn.CornerRadius = 30
        Me.btnBorrowReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrowReturn.Font = New System.Drawing.Font("Poppins Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrowReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBorrowReturn.Location = New System.Drawing.Point(560, 22)
        Me.btnBorrowReturn.Name = "btnBorrowReturn"
        Me.btnBorrowReturn.Size = New System.Drawing.Size(214, 38)
        Me.btnBorrowReturn.TabIndex = 5
        Me.btnBorrowReturn.Text = "Borrow and Return Slip"
        Me.btnBorrowReturn.UseVisualStyleBackColor = False
        '
        'Essuance
        '
        Me.Essuance.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Essuance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Essuance.CornerRadius = 30
        Me.Essuance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Essuance.Font = New System.Drawing.Font("Poppins Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Essuance.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Essuance.Location = New System.Drawing.Point(304, 23)
        Me.Essuance.Name = "Essuance"
        Me.Essuance.Size = New System.Drawing.Size(250, 37)
        Me.Essuance.TabIndex = 6
        Me.Essuance.Text = "Propety Acknowledgement Receipt"
        Me.Essuance.UseVisualStyleBackColor = False
        '
        'frmBorrowedItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblNoItems)
        Me.Controls.Add(Me.dgvBorrowedItems)
        Me.Controls.Add(Me.pnlStats)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlBottom)
        Me.Name = "frmBorrowedItem"
        Me.Size = New System.Drawing.Size(1200, 680)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.pnlStats.ResumeLayout(False)
        Me.pnlStats.PerformLayout()
        CType(Me.dgvBorrowedItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlFilters As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblFilterStatus As System.Windows.Forms.Label
    Friend WithEvents cboFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblFilterType As System.Windows.Forms.Label
    Friend WithEvents cboFilterType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlStats As System.Windows.Forms.Panel
    Friend WithEvents lblTotalItems As System.Windows.Forms.Label
    Friend WithEvents lblPropertyCount As System.Windows.Forms.Label
    Friend WithEvents lblSupplyCount As System.Windows.Forms.Label
    Friend WithEvents lblNeedsRepair As System.Windows.Forms.Label
    Friend WithEvents dgvBorrowedItems As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnReturnItem As System.Windows.Forms.Button
    Friend WithEvents btnRequestMaintenance As System.Windows.Forms.Button
    Friend WithEvents lblNoItems As System.Windows.Forms.Label
    Friend WithEvents colRequestId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPropertyNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCondition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApprovedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPurpose As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCanMaintenance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPropertyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBorrowReturn As Resources.Controls.RoundedButton
    Friend WithEvents Essuance As Resources.Controls.RoundedButton
End Class
