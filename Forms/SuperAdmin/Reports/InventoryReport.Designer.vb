Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_Back = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Reorder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Manufacturer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostPerItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InventoryValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReorderCycle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemReorderQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemDiscontinue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(820, 1296)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(235, 52)
        Me.Button1.TabIndex = 79
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_Back
        '
        Me.btn_Back.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Back.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Back.ForeColor = System.Drawing.Color.White
        Me.btn_Back.Location = New System.Drawing.Point(488, 1296)
        Me.btn_Back.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(235, 52)
        Me.btn_Back.TabIndex = 78
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(633, 359)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(389, 22)
        Me.TextBox5.TabIndex = 58
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(627, 396)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(396, 24)
        Me.TextBox4.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(464, 359)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 23)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Inventory Period :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(464, 400)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 25)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Reporter :"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(645, 252)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(421, 46)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Inventory Report"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reorder, Me.ItemNumber, Me.Manufacturer, Me.Description, Me.CostPerItem, Me.StockQuantity, Me.InventoryValue, Me.ReorderCycle, Me.ItemReorderQuantity, Me.ItemDiscontinue})
        Me.DataGridView1.Location = New System.Drawing.Point(232, 470)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1684, 514)
        Me.DataGridView1.TabIndex = 85
        '
        'Reorder
        '
        Me.Reorder.HeaderText = "Reorder?"
        Me.Reorder.MinimumWidth = 6
        Me.Reorder.Name = "Reorder"
        Me.Reorder.Width = 125
        '
        'ItemNumber
        '
        Me.ItemNumber.HeaderText = "Item Number"
        Me.ItemNumber.MinimumWidth = 6
        Me.ItemNumber.Name = "ItemNumber"
        Me.ItemNumber.Width = 140
        '
        'Manufacturer
        '
        Me.Manufacturer.HeaderText = "Manufacturer"
        Me.Manufacturer.MinimumWidth = 6
        Me.Manufacturer.Name = "Manufacturer"
        Me.Manufacturer.Width = 125
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 150
        '
        'CostPerItem
        '
        Me.CostPerItem.HeaderText = "Cost Per Item"
        Me.CostPerItem.MinimumWidth = 6
        Me.CostPerItem.Name = "CostPerItem"
        Me.CostPerItem.Width = 150
        '
        'StockQuantity
        '
        Me.StockQuantity.HeaderText = "Stock Quantity"
        Me.StockQuantity.MinimumWidth = 6
        Me.StockQuantity.Name = "StockQuantity"
        Me.StockQuantity.Width = 125
        '
        'InventoryValue
        '
        Me.InventoryValue.HeaderText = "Inventory Value"
        Me.InventoryValue.MinimumWidth = 6
        Me.InventoryValue.Name = "InventoryValue"
        Me.InventoryValue.Width = 130
        '
        'ReorderCycle
        '
        Me.ReorderCycle.HeaderText = "Reorder Cycle"
        Me.ReorderCycle.MinimumWidth = 6
        Me.ReorderCycle.Name = "ReorderCycle"
        Me.ReorderCycle.Width = 125
        '
        'ItemReorderQuantity
        '
        Me.ItemReorderQuantity.HeaderText = "Item Reorder Quantity"
        Me.ItemReorderQuantity.MinimumWidth = 6
        Me.ItemReorderQuantity.Name = "ItemReorderQuantity"
        Me.ItemReorderQuantity.Width = 150
        '
        'ItemDiscontinue
        '
        Me.ItemDiscontinue.HeaderText = "Item Discontinue?"
        Me.ItemDiscontinue.MinimumWidth = 6
        Me.ItemDiscontinue.Name = "ItemDiscontinue"
        Me.ItemDiscontinue.Width = 125
        '
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(1763, 1008)
        Me.RoundedButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(153, 34)
        Me.RoundedButton1.TabIndex = 368
        Me.RoundedButton1.Text = "Generate PDF File"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'btnCSV
        '
        Me.btnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnCSV.CornerRadius = 15
        Me.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCSV.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCSV.Location = New System.Drawing.Point(1602, 1008)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(153, 34)
        Me.btnCSV.TabIndex = 367
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(1482, 1008)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 34)
        Me.Button2.TabIndex = 366
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'InventoryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.btn_Back)
        Me.Controls.Add(Me.TextBox5)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "InventoryReport"
        Me.Text = "InventoryReport"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_Back As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Reorder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Manufacturer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostPerItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReorderCycle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemReorderQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemDiscontinue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoundedButton1 As Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As Resources.Controls.RoundedButton
    Friend WithEvents Button2 As Button
End Class
