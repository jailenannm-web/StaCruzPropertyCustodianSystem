Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports StaCruzPropertyCustodianSystem.Resources.Controls
Partial Class UC_PropertyManagement
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
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_PM = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pm_txtbox_search = New System.Windows.Forms.TextBox()
        Me.pm_btn_AddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pm_btn_Update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(882, 115)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 33)
        Me.pm_cbobx_categ.TabIndex = 28
        Me.pm_cbobx_categ.Text = "Categories"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1057, 115)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 33)
        Me.pm_cbobx_status.TabIndex = 27
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_table
        '
        Me.pm_table.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_table.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SupplyID, Me.colName, Me.Category, Me.Stock, Me.UnitCost, Me.TotalValue, Me.Status, Me.Location, Me.Action})
        Me.pm_table.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_table.Location = New System.Drawing.Point(37, 196)
        Me.pm_table.Name = "pm_table"
        Me.pm_table.RowHeadersWidth = 51
        Me.pm_table.RowTemplate.Height = 24
        Me.pm_table.Size = New System.Drawing.Size(1163, 485)
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
        'Location
        '
        Me.Location.HeaderText = "Location"
        Me.Location.MinimumWidth = 6
        Me.Location.Name = "Location"
        Me.Location.Width = 125
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.MinimumWidth = 6
        Me.Action.Name = "Action"
        Me.Action.Width = 125
        '
        'admin_label_PM
        '
        Me.admin_label_PM.AutoSize = True
        Me.admin_label_PM.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_PM.Location = New System.Drawing.Point(29, 44)
        Me.admin_label_PM.Name = "admin_label_PM"
        Me.admin_label_PM.Size = New System.Drawing.Size(344, 48)
        Me.admin_label_PM.TabIndex = 32
        Me.admin_label_PM.Text = "Property Management"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(39, 115)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'pm_txtbox_search
        '
        Me.pm_txtbox_search.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_txtbox_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_txtbox_search.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_txtbox_search.ForeColor = System.Drawing.Color.White
        Me.pm_txtbox_search.Location = New System.Drawing.Point(87, 115)
        Me.pm_txtbox_search.Name = "pm_txtbox_search"
        Me.pm_txtbox_search.Size = New System.Drawing.Size(741, 28)
        Me.pm_txtbox_search.TabIndex = 33
        Me.pm_txtbox_search.Text = "Search"
        Me.pm_txtbox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pm_btn_AddSupply
        '
        Me.pm_btn_AddSupply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pm_btn_AddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_btn_AddSupply.CornerRadius = 15
        Me.pm_btn_AddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_btn_AddSupply.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_btn_AddSupply.ForeColor = System.Drawing.Color.White
        Me.pm_btn_AddSupply.Location = New System.Drawing.Point(1022, 687)
        Me.pm_btn_AddSupply.Name = "pm_btn_AddSupply"
        Me.pm_btn_AddSupply.Size = New System.Drawing.Size(180, 42)
        Me.pm_btn_AddSupply.TabIndex = 55
        Me.pm_btn_AddSupply.Text = "Add Supply"
        Me.pm_btn_AddSupply.UseVisualStyleBackColor = False
        '
        'pm_btn_Update
        '
        Me.pm_btn_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pm_btn_Update.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_btn_Update.CornerRadius = 15
        Me.pm_btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_btn_Update.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_btn_Update.ForeColor = System.Drawing.Color.White
        Me.pm_btn_Update.Location = New System.Drawing.Point(808, 687)
        Me.pm_btn_Update.Name = "pm_btn_Update"
        Me.pm_btn_Update.Size = New System.Drawing.Size(180, 42)
        Me.pm_btn_Update.TabIndex = 56
        Me.pm_btn_Update.Text = "Update"
        Me.pm_btn_Update.UseVisualStyleBackColor = False
        '
        'UC_PropertyManagement
        '
        Me.Controls.Add(Me.pm_btn_Update)
        Me.Controls.Add(Me.pm_btn_AddSupply)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pm_txtbox_search)
        Me.Controls.Add(Me.admin_label_PM)
        Me.Controls.Add(Me.pm_table)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Controls.Add(Me.admin_label_PropertyManagement)
        Me.Name = "UC_PropertyManagement"
        Me.Size = New System.Drawing.Size(1249, 768)
        CType(Me.pm_table, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' ---------- Friend Controls ----------
    Friend WithEvents admin_label_PropertyManagement As Label
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_table As DataGridView
    Friend WithEvents SupplyID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn  ' Renamed
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents UnitCost As DataGridViewTextBoxColumn
    Friend WithEvents TotalValue As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Location As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
    Friend WithEvents admin_label_PM As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pm_txtbox_search As TextBox
    Friend WithEvents pm_btn_AddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents pm_btn_Update As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
