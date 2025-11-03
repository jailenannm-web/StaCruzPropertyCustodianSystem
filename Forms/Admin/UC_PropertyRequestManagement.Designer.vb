Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_PropertyRequestManagement
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
        Me.admin_label_PropertyRequestManagement = New System.Windows.Forms.Label()
        Me.prm_table1 = New System.Windows.Forms.DataGridView()
        Me.SupplyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prm_btn_update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_PropertyRequestManagement
        '
        Me.admin_label_PropertyRequestManagement.AutoSize = True
        Me.admin_label_PropertyRequestManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_PropertyRequestManagement.Location = New System.Drawing.Point(35, 34)
        Me.admin_label_PropertyRequestManagement.Name = "admin_label_PropertyRequestManagement"
        Me.admin_label_PropertyRequestManagement.Size = New System.Drawing.Size(560, 58)
        Me.admin_label_PropertyRequestManagement.TabIndex = 33
        Me.admin_label_PropertyRequestManagement.Text = "Property Request Management"
        '
        'prm_table1
        '
        Me.prm_table1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_table1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.prm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SupplyID, Me.colName, Me.Category, Me.Stock, Me.UnitCost, Me.TotalValue, Me.Status, Me.Location, Me.Action})
        Me.prm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.Location = New System.Drawing.Point(45, 116)
        Me.prm_table1.Name = "prm_table1"
        Me.prm_table1.RowHeadersWidth = 51
        Me.prm_table1.RowTemplate.Height = 24
        Me.prm_table1.Size = New System.Drawing.Size(1173, 485)
        Me.prm_table1.TabIndex = 34
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
        'prm_btn_update
        '
        Me.prm_btn_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.prm_btn_update.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prm_btn_update.ForeColor = System.Drawing.Color.White
        Me.prm_btn_update.Location = New System.Drawing.Point(1038, 667)
        Me.prm_btn_update.Name = "prm_btn_update"
        Me.prm_btn_update.Size = New System.Drawing.Size(180, 42)
        Me.prm_btn_update.TabIndex = 57
        Me.prm_btn_update.Text = "Update"
        Me.prm_btn_update.UseVisualStyleBackColor = False
        '
        'UC_PropertyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.prm_btn_update)
        Me.Controls.Add(Me.prm_table1)
        Me.Controls.Add(Me.admin_label_PropertyRequestManagement)
        Me.Name = "UC_PropertyRequestManagement"
        Me.Size = New System.Drawing.Size(1262, 770)
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_PropertyRequestManagement As Label
    Friend WithEvents prm_table1 As DataGridView
    Friend WithEvents SupplyID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents UnitCost As DataGridViewTextBoxColumn
    Friend WithEvents TotalValue As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Location As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
    Friend WithEvents prm_btn_update As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
