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
        Me.btnBorrowReturn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Essuance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        Me.pnlTransactionHistory = New System.Windows.Forms.Panel()
        Me.btnGenerateSlipFromHistory = New System.Windows.Forms.Button()
        Me.lblTransactionTitle = New System.Windows.Forms.Label()
        Me.dgvTransactionHistory = New System.Windows.Forms.DataGridView()
        Me.colHistBorrowId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHistBorrowDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHistReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHistStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHistCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHistReturnReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHistRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnToggleHistory = New System.Windows.Forms.Button()
        Me.dgvBorrowedItems = New System.Windows.Forms.DataGridView()
        Me.colBorrowId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPurpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnViewMaintenanceStatus = New System.Windows.Forms.Button()
        Me.btnRequestMaintenance = New System.Windows.Forms.Button()
        Me.btnReturnItem = New System.Windows.Forms.Button()
        Me.lblNoItems = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.pnlStats.SuspendLayout()
        Me.pnlTransactionHistory.SuspendLayout()
        CType(Me.dgvTransactionHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBorrowedItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.btnBorrowReturn)
        Me.pnlTop.Controls.Add(Me.Essuance)
        Me.pnlTop.Controls.Add(Me.btnRefresh)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Padding = New System.Windows.Forms.Padding(27, 12, 27, 12)
        Me.pnlTop.Size = New System.Drawing.Size(1600, 86)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(27, 12)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(295, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "My Borrowed Items"
        '
        'btnBorrowReturn
        '
        Me.btnBorrowReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBorrowReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBorrowReturn.CornerRadius = 30
        Me.btnBorrowReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrowReturn.Font = New System.Drawing.Font("Poppins Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrowReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBorrowReturn.Location = New System.Drawing.Point(772, 24)
        Me.btnBorrowReturn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBorrowReturn.Name = "btnBorrowReturn"
        Me.btnBorrowReturn.Size = New System.Drawing.Size(223, 45)
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
        Me.Essuance.Location = New System.Drawing.Point(1003, 26)
        Me.Essuance.Margin = New System.Windows.Forms.Padding(4)
        Me.Essuance.Name = "Essuance"
        Me.Essuance.Size = New System.Drawing.Size(375, 44)
        Me.Essuance.TabIndex = 6
        Me.Essuance.Text = "Propety Acknowledgement Receipt"
        Me.Essuance.UseVisualStyleBackColor = False
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
        Me.btnRefresh.Location = New System.Drawing.Point(1413, 12)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(160, 62)
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
        Me.pnlFilters.Location = New System.Drawing.Point(0, 86)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(27, 18, 27, 18)
        Me.pnlFilters.Size = New System.Drawing.Size(1600, 98)
        Me.pnlFilters.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSearch.Location = New System.Drawing.Point(27, 22)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(81, 20)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "🔍 Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(27, 47)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(399, 30)
        Me.txtSearch.TabIndex = 1
        '
        'lblFilterStatus
        '
        Me.lblFilterStatus.AutoSize = True
        Me.lblFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFilterStatus.Location = New System.Drawing.Point(453, 22)
        Me.lblFilterStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilterStatus.Name = "lblFilterStatus"
        Me.lblFilterStatus.Size = New System.Drawing.Size(109, 20)
        Me.lblFilterStatus.TabIndex = 2
        Me.lblFilterStatus.Text = "Filter by Status:"
        '
        'cboFilterStatus
        '
        Me.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboFilterStatus.FormattingEnabled = True
        Me.cboFilterStatus.Location = New System.Drawing.Point(453, 47)
        Me.cboFilterStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFilterStatus.Name = "cboFilterStatus"
        Me.cboFilterStatus.Size = New System.Drawing.Size(265, 31)
        Me.cboFilterStatus.TabIndex = 3
        '
        'lblFilterType
        '
        Me.lblFilterType.AutoSize = True
        Me.lblFilterType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFilterType.Location = New System.Drawing.Point(747, 22)
        Me.lblFilterType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilterType.Name = "lblFilterType"
        Me.lblFilterType.Size = New System.Drawing.Size(100, 20)
        Me.lblFilterType.TabIndex = 4
        Me.lblFilterType.Text = "Filter by Type:"
        '
        'cboFilterType
        '
        Me.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboFilterType.FormattingEnabled = True
        Me.cboFilterType.Location = New System.Drawing.Point(747, 47)
        Me.cboFilterType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFilterType.Name = "cboFilterType"
        Me.cboFilterType.Size = New System.Drawing.Size(265, 31)
        Me.cboFilterType.TabIndex = 5
        '
        'pnlStats
        '
        Me.pnlStats.BackColor = System.Drawing.Color.White
        Me.pnlStats.Controls.Add(Me.lblTotalItems)
        Me.pnlStats.Controls.Add(Me.lblPropertyCount)
        Me.pnlStats.Controls.Add(Me.lblSupplyCount)
        Me.pnlStats.Controls.Add(Me.lblNeedsRepair)
        Me.pnlStats.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStats.Location = New System.Drawing.Point(0, 184)
        Me.pnlStats.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.Padding = New System.Windows.Forms.Padding(27, 12, 27, 12)
        Me.pnlStats.Size = New System.Drawing.Size(1600, 74)
        Me.pnlStats.TabIndex = 2
        '
        'lblTotalItems
        '
        Me.lblTotalItems.AutoSize = True
        Me.lblTotalItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTotalItems.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTotalItems.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalItems.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTotalItems.Location = New System.Drawing.Point(27, 12)
        Me.lblTotalItems.Margin = New System.Windows.Forms.Padding(0, 0, 40, 0)
        Me.lblTotalItems.Name = "lblTotalItems"
        Me.lblTotalItems.Padding = New System.Windows.Forms.Padding(0, 12, 40, 0)
        Me.lblTotalItems.Size = New System.Drawing.Size(158, 35)
        Me.lblTotalItems.TabIndex = 0
        Me.lblTotalItems.Text = "Total Items: 0"
        '
        'lblPropertyCount
        '
        Me.lblPropertyCount.AutoSize = True
        Me.lblPropertyCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPropertyCount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPropertyCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblPropertyCount.Location = New System.Drawing.Point(240, 25)
        Me.lblPropertyCount.Margin = New System.Windows.Forms.Padding(40, 0, 40, 0)
        Me.lblPropertyCount.Name = "lblPropertyCount"
        Me.lblPropertyCount.Padding = New System.Windows.Forms.Padding(0, 0, 40, 0)
        Me.lblPropertyCount.Size = New System.Drawing.Size(145, 23)
        Me.lblPropertyCount.TabIndex = 1
        Me.lblPropertyCount.Text = "Properties: 0"
        '
        'lblSupplyCount
        '
        Me.lblSupplyCount.AutoSize = True
        Me.lblSupplyCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSupplyCount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSupplyCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblSupplyCount.Location = New System.Drawing.Point(453, 25)
        Me.lblSupplyCount.Margin = New System.Windows.Forms.Padding(40, 0, 40, 0)
        Me.lblSupplyCount.Name = "lblSupplyCount"
        Me.lblSupplyCount.Padding = New System.Windows.Forms.Padding(0, 0, 40, 0)
        Me.lblSupplyCount.Size = New System.Drawing.Size(131, 23)
        Me.lblSupplyCount.TabIndex = 2
        Me.lblSupplyCount.Text = "Supplies: 0"
        '
        'lblNeedsRepair
        '
        Me.lblNeedsRepair.AutoSize = True
        Me.lblNeedsRepair.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNeedsRepair.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblNeedsRepair.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblNeedsRepair.Location = New System.Drawing.Point(653, 25)
        Me.lblNeedsRepair.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNeedsRepair.Name = "lblNeedsRepair"
        Me.lblNeedsRepair.Size = New System.Drawing.Size(153, 23)
        Me.lblNeedsRepair.TabIndex = 3
        Me.lblNeedsRepair.Text = "Needs Attention: 0"
        '
        'pnlTransactionHistory
        '
        Me.pnlTransactionHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlTransactionHistory.Controls.Add(Me.btnGenerateSlipFromHistory)
        Me.pnlTransactionHistory.Controls.Add(Me.lblTransactionTitle)
        Me.pnlTransactionHistory.Controls.Add(Me.dgvTransactionHistory)
        Me.pnlTransactionHistory.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTransactionHistory.Location = New System.Drawing.Point(0, 489)
        Me.pnlTransactionHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlTransactionHistory.Name = "pnlTransactionHistory"
        Me.pnlTransactionHistory.Padding = New System.Windows.Forms.Padding(27, 12, 27, 12)
        Me.pnlTransactionHistory.Size = New System.Drawing.Size(1600, 250)
        Me.pnlTransactionHistory.TabIndex = 6
        Me.pnlTransactionHistory.Visible = False
        '
        'btnGenerateSlipFromHistory
        '
        Me.btnGenerateSlipFromHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateSlipFromHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnGenerateSlipFromHistory.Enabled = False
        Me.btnGenerateSlipFromHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateSlipFromHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateSlipFromHistory.ForeColor = System.Drawing.Color.White
        Me.btnGenerateSlipFromHistory.Location = New System.Drawing.Point(1350, 205)
        Me.btnGenerateSlipFromHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerateSlipFromHistory.Name = "btnGenerateSlipFromHistory"
        Me.btnGenerateSlipFromHistory.Size = New System.Drawing.Size(220, 40)
        Me.btnGenerateSlipFromHistory.TabIndex = 2
        Me.btnGenerateSlipFromHistory.Text = "📄 Generate Slip"
        Me.btnGenerateSlipFromHistory.UseVisualStyleBackColor = False
        '
        'lblTransactionTitle
        '
        Me.lblTransactionTitle.AutoSize = True
        Me.lblTransactionTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTransactionTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblTransactionTitle.Location = New System.Drawing.Point(27, 12)
        Me.lblTransactionTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTransactionTitle.Name = "lblTransactionTitle"
        Me.lblTransactionTitle.Size = New System.Drawing.Size(314, 28)
        Me.lblTransactionTitle.TabIndex = 0
        Me.lblTransactionTitle.Text = "📋 Transaction History for Item"
        '
        'dgvTransactionHistory
        '
        Me.dgvTransactionHistory.AllowUserToAddRows = False
        Me.dgvTransactionHistory.AllowUserToDeleteRows = False
        Me.dgvTransactionHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTransactionHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvTransactionHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTransactionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransactionHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHistBorrowId, Me.colHistBorrowDate, Me.colHistReturnDate, Me.colHistStatus, Me.colHistCondition, Me.colHistReturnReason, Me.colHistRemarks})
        Me.dgvTransactionHistory.Location = New System.Drawing.Point(27, 50)
        Me.dgvTransactionHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvTransactionHistory.Name = "dgvTransactionHistory"
        Me.dgvTransactionHistory.ReadOnly = True
        Me.dgvTransactionHistory.RowHeadersWidth = 51
        Me.dgvTransactionHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransactionHistory.Size = New System.Drawing.Size(1546, 138)
        Me.dgvTransactionHistory.TabIndex = 2
        '
        'colHistBorrowId
        '
        Me.colHistBorrowId.HeaderText = "Borrow ID"
        Me.colHistBorrowId.MinimumWidth = 6
        Me.colHistBorrowId.Name = "colHistBorrowId"
        Me.colHistBorrowId.ReadOnly = True
        Me.colHistBorrowId.Visible = False
        Me.colHistBorrowId.Width = 125
        '
        'colHistBorrowDate
        '
        Me.colHistBorrowDate.HeaderText = "Borrow Date"
        Me.colHistBorrowDate.MinimumWidth = 6
        Me.colHistBorrowDate.Name = "colHistBorrowDate"
        Me.colHistBorrowDate.ReadOnly = True
        Me.colHistBorrowDate.Width = 130
        '
        'colHistReturnDate
        '
        Me.colHistReturnDate.HeaderText = "Return Date"
        Me.colHistReturnDate.MinimumWidth = 6
        Me.colHistReturnDate.Name = "colHistReturnDate"
        Me.colHistReturnDate.ReadOnly = True
        Me.colHistReturnDate.Width = 130
        '
        'colHistStatus
        '
        Me.colHistStatus.HeaderText = "Status"
        Me.colHistStatus.MinimumWidth = 6
        Me.colHistStatus.Name = "colHistStatus"
        Me.colHistStatus.ReadOnly = True
        '
        'colHistCondition
        '
        Me.colHistCondition.HeaderText = "Condition"
        Me.colHistCondition.MinimumWidth = 6
        Me.colHistCondition.Name = "colHistCondition"
        Me.colHistCondition.ReadOnly = True
        Me.colHistCondition.Width = 110
        '
        'colHistReturnReason
        '
        Me.colHistReturnReason.HeaderText = "Notes"
        Me.colHistReturnReason.MinimumWidth = 6
        Me.colHistReturnReason.Name = "colHistReturnReason"
        Me.colHistReturnReason.ReadOnly = True
        Me.colHistReturnReason.Width = 180
        '
        'colHistRemarks
        '
        Me.colHistRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colHistRemarks.HeaderText = "Remarks"
        Me.colHistRemarks.MinimumWidth = 6
        Me.colHistRemarks.Name = "colHistRemarks"
        Me.colHistRemarks.ReadOnly = True
        '
        'btnToggleHistory
        '
        Me.btnToggleHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btnToggleHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnToggleHistory.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnToggleHistory.FlatAppearance.BorderSize = 0
        Me.btnToggleHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToggleHistory.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnToggleHistory.ForeColor = System.Drawing.Color.White
        Me.btnToggleHistory.Location = New System.Drawing.Point(27, 25)
        Me.btnToggleHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnToggleHistory.Name = "btnToggleHistory"
        Me.btnToggleHistory.Size = New System.Drawing.Size(267, 48)
        Me.btnToggleHistory.TabIndex = 8
        Me.btnToggleHistory.Text = "📋 Show Transaction History"
        Me.btnToggleHistory.UseVisualStyleBackColor = False
        '
        'dgvBorrowedItems
        '
        Me.dgvBorrowedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBorrowedItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBorrowId, Me.colItemType, Me.colItemName, Me.colCategory, Me.colQuantity, Me.colCondition, Me.colPurpose, Me.colRemarks, Me.colItemId})
        Me.dgvBorrowedItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBorrowedItems.Location = New System.Drawing.Point(0, 258)
        Me.dgvBorrowedItems.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvBorrowedItems.Name = "dgvBorrowedItems"
        Me.dgvBorrowedItems.RowHeadersWidth = 51
        Me.dgvBorrowedItems.Size = New System.Drawing.Size(1600, 231)
        Me.dgvBorrowedItems.TabIndex = 3
        '
        'colBorrowId
        '
        Me.colBorrowId.HeaderText = "Borrow ID"
        Me.colBorrowId.MinimumWidth = 6
        Me.colBorrowId.Name = "colBorrowId"
        Me.colBorrowId.ReadOnly = True
        Me.colBorrowId.Visible = False
        Me.colBorrowId.Width = 125
        '
        'colItemType
        '
        Me.colItemType.HeaderText = "Type"
        Me.colItemType.MinimumWidth = 6
        Me.colItemType.Name = "colItemType"
        Me.colItemType.ReadOnly = True
        Me.colItemType.Width = 125
        '
        'colItemName
        '
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MinimumWidth = 6
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 200
        '
        'colCategory
        '
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.MinimumWidth = 6
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 150
        '
        'colQuantity
        '
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.MinimumWidth = 6
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 125
        '
        'colCondition
        '
        Me.colCondition.HeaderText = "Condition"
        Me.colCondition.MinimumWidth = 6
        Me.colCondition.Name = "colCondition"
        Me.colCondition.ReadOnly = True
        Me.colCondition.Width = 120
        '
        'colPurpose
        '
        Me.colPurpose.HeaderText = "Purpose"
        Me.colPurpose.MinimumWidth = 6
        Me.colPurpose.Name = "colPurpose"
        Me.colPurpose.ReadOnly = True
        Me.colPurpose.Width = 180
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.MinimumWidth = 6
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        Me.colRemarks.Width = 200
        '
        'colItemId
        '
        Me.colItemId.HeaderText = "Item ID"
        Me.colItemId.MinimumWidth = 6
        Me.colItemId.Name = "colItemId"
        Me.colItemId.ReadOnly = True
        Me.colItemId.Visible = False
        Me.colItemId.Width = 125
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Controls.Add(Me.btnToggleHistory)
        Me.pnlBottom.Controls.Add(Me.btnViewMaintenanceStatus)
        Me.pnlBottom.Controls.Add(Me.btnRequestMaintenance)
        Me.pnlBottom.Controls.Add(Me.btnReturnItem)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 739)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.pnlBottom.Size = New System.Drawing.Size(1600, 98)
        Me.pnlBottom.TabIndex = 4
        '
        'btnViewMaintenanceStatus
        '
        Me.btnViewMaintenanceStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnViewMaintenanceStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewMaintenanceStatus.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnViewMaintenanceStatus.Enabled = False
        Me.btnViewMaintenanceStatus.FlatAppearance.BorderSize = 0
        Me.btnViewMaintenanceStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewMaintenanceStatus.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewMaintenanceStatus.ForeColor = System.Drawing.Color.White
        Me.btnViewMaintenanceStatus.Location = New System.Drawing.Point(772, 25)
        Me.btnViewMaintenanceStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewMaintenanceStatus.Name = "btnViewMaintenanceStatus"
        Me.btnViewMaintenanceStatus.Size = New System.Drawing.Size(267, 48)
        Me.btnViewMaintenanceStatus.TabIndex = 7
        Me.btnViewMaintenanceStatus.Text = "🔍 View Maintenance Status"
        Me.btnViewMaintenanceStatus.UseVisualStyleBackColor = False
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
        Me.btnRequestMaintenance.Location = New System.Drawing.Point(1039, 25)
        Me.btnRequestMaintenance.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRequestMaintenance.Name = "btnRequestMaintenance"
        Me.btnRequestMaintenance.Size = New System.Drawing.Size(267, 48)
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
        Me.btnReturnItem.Location = New System.Drawing.Point(1306, 25)
        Me.btnReturnItem.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReturnItem.Name = "btnReturnItem"
        Me.btnReturnItem.Size = New System.Drawing.Size(267, 48)
        Me.btnReturnItem.TabIndex = 1
        Me.btnReturnItem.Text = "↩️ Return Item"
        Me.btnReturnItem.UseVisualStyleBackColor = False
        '
        'lblNoItems
        '
        Me.lblNoItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoItems.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblNoItems.ForeColor = System.Drawing.Color.Gray
        Me.lblNoItems.Location = New System.Drawing.Point(0, 258)
        Me.lblNoItems.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNoItems.Name = "lblNoItems"
        Me.lblNoItems.Size = New System.Drawing.Size(1600, 231)
        Me.lblNoItems.TabIndex = 5
        Me.lblNoItems.Text = "No borrowed items found. Your approved requests will appear here."
        Me.lblNoItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoItems.Visible = False
        '
        'frmBorrowedItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblNoItems)
        Me.Controls.Add(Me.dgvBorrowedItems)
        Me.Controls.Add(Me.pnlTransactionHistory)
        Me.Controls.Add(Me.pnlStats)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlBottom)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBorrowedItem"
        Me.Size = New System.Drawing.Size(1600, 837)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.pnlStats.ResumeLayout(False)
        Me.pnlStats.PerformLayout()
        Me.pnlTransactionHistory.ResumeLayout(False)
        Me.pnlTransactionHistory.PerformLayout()
        CType(Me.dgvTransactionHistory, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnViewMaintenanceStatus As System.Windows.Forms.Button
    Friend WithEvents btnRequestMaintenance As System.Windows.Forms.Button
    Friend WithEvents lblNoItems As System.Windows.Forms.Label
    Friend WithEvents colBorrowId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCondition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPurpose As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBorrowReturn As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Essuance As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents pnlTransactionHistory As System.Windows.Forms.Panel
    Friend WithEvents lblTransactionTitle As System.Windows.Forms.Label
    Friend WithEvents btnToggleHistory As System.Windows.Forms.Button
    Friend WithEvents btnGenerateSlipFromHistory As System.Windows.Forms.Button
    Friend WithEvents dgvTransactionHistory As System.Windows.Forms.DataGridView
    Friend WithEvents colHistBorrowId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHistBorrowDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHistReturnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHistStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHistCondition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHistReturnReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHistRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
