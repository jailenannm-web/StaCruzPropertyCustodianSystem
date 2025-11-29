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
        Me.admin_label_PropertyManagement = New System.Windows.Forms.Label()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_table = New System.Windows.Forms.DataGridView()
        Me.SupplyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_received = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.expiration_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.received_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.created_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updated_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_PM = New System.Windows.Forms.Label()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlSupplymanagement = New System.Windows.Forms.Label()
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SupplyID, Me.colName, Me.Category, Me.Stock, Me.UnitCost, Me.TotalValue, Me.Status, Me.LocationColumn, Me.supplier, Me.date_received, Me.expiration_date, Me.received_by, Me.remarks, Me.created_at, Me.updated_at})
        Me.pm_table.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.Location = New System.Drawing.Point(62, 124)
        Me.pm_table.Name = "pm_table"
        Me.pm_table.RowHeadersWidth = 51
        Me.pm_table.RowTemplate.Height = 24
        Me.pm_table.Size = New System.Drawing.Size(1270, 573)
        Me.pm_table.TabIndex = 26
        '
        'SupplyID
        '
        Me.SupplyID.HeaderText = "Supply ID"
        Me.SupplyID.MinimumWidth = 6
        Me.SupplyID.Name = "SupplyID"
        Me.SupplyID.Width = 125
        '
        'colName
        '
        Me.colName.HeaderText = "Name"
        Me.colName.MinimumWidth = 6
        Me.colName.Name = "colName"
        Me.colName.Width = 125
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.MinimumWidth = 6
        Me.Category.Name = "Category"
        Me.Category.Width = 125
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.MinimumWidth = 6
        Me.Stock.Name = "Stock"
        Me.Stock.Width = 125
        '
        'UnitCost
        '
        Me.UnitCost.HeaderText = "Unit Cost"
        Me.UnitCost.MinimumWidth = 6
        Me.UnitCost.Name = "UnitCost"
        Me.UnitCost.Width = 125
        '
        'TotalValue
        '
        Me.TotalValue.HeaderText = "Total Value"
        Me.TotalValue.MinimumWidth = 6
        Me.TotalValue.Name = "TotalValue"
        Me.TotalValue.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'LocationColumn
        '
        Me.LocationColumn.HeaderText = "Location"
        Me.LocationColumn.MinimumWidth = 6
        Me.LocationColumn.Name = "LocationColumn"
        Me.LocationColumn.Width = 125
        '
        'supplier
        '
        Me.supplier.HeaderText = "Supplier"
        Me.supplier.MinimumWidth = 6
        Me.supplier.Name = "supplier"
        Me.supplier.Width = 125
        '
        'date_received
        '
        Me.date_received.HeaderText = "Date Received"
        Me.date_received.MinimumWidth = 6
        Me.date_received.Name = "date_received"
        Me.date_received.Width = 125
        '
        'expiration_date
        '
        Me.expiration_date.HeaderText = "Expiration Date"
        Me.expiration_date.MinimumWidth = 6
        Me.expiration_date.Name = "expiration_date"
        Me.expiration_date.Width = 125
        '
        'received_by
        '
        Me.received_by.HeaderText = "Received by"
        Me.received_by.MinimumWidth = 6
        Me.received_by.Name = "received_by"
        Me.received_by.Width = 125
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 125
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
        Me.updated_at.HeaderText = "Updated At"
        Me.updated_at.MinimumWidth = 6
        Me.updated_at.Name = "updated_at"
        Me.updated_at.Width = 125
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
        Me.ttlSupplymanagement.Size = New System.Drawing.Size(38, 58)
        Me.ttlSupplymanagement.TabIndex = 158
        Me.ttlSupplymanagement.Text = "1"
        '
        'UC_SupplyManagement
        '
        Me.AutoScroll = True
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
    Friend WithEvents SupplyID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents UnitCost As DataGridViewTextBoxColumn
    Friend WithEvents TotalValue As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents LocationColumn As DataGridViewTextBoxColumn
    Friend WithEvents supplier As DataGridViewTextBoxColumn
    Friend WithEvents date_received As DataGridViewTextBoxColumn
    Friend WithEvents expiration_date As DataGridViewTextBoxColumn
    Friend WithEvents received_by As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents created_at As DataGridViewTextBoxColumn
    Friend WithEvents updated_at As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlSupplymanagement As Label
End Class
