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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(615, 1053)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 42)
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
        Me.btn_Back.Location = New System.Drawing.Point(366, 1053)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(176, 42)
        Me.btn_Back.TabIndex = 78
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(475, 292)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(293, 19)
        Me.TextBox5.TabIndex = 58
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(470, 322)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(298, 20)
        Me.TextBox4.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(348, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Inventory Period :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(348, 325)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Reporter :"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(484, 205)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(316, 37)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Inventory Report"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reorder, Me.ItemNumber, Me.Manufacturer, Me.Description, Me.CostPerItem, Me.StockQuantity, Me.InventoryValue, Me.ReorderCycle, Me.ItemReorderQuantity, Me.ItemDiscontinue})
        Me.DataGridView1.Location = New System.Drawing.Point(174, 382)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1263, 418)
        Me.DataGridView1.TabIndex = 85
        '
        'Reorder
        '
        Me.Reorder.HeaderText = "Reorder?"
        Me.Reorder.Name = "Reorder"
        '
        'ItemNumber
        '
        Me.ItemNumber.HeaderText = "Item Number"
        Me.ItemNumber.Name = "ItemNumber"
        Me.ItemNumber.Width = 140
        '
        'Manufacturer
        '
        Me.Manufacturer.HeaderText = "Manufacturer"
        Me.Manufacturer.Name = "Manufacturer"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.Width = 150
        '
        'CostPerItem
        '
        Me.CostPerItem.HeaderText = "Cost Per Item"
        Me.CostPerItem.Name = "CostPerItem"
        Me.CostPerItem.Width = 150
        '
        'StockQuantity
        '
        Me.StockQuantity.HeaderText = "Stock Quantity"
        Me.StockQuantity.Name = "StockQuantity"
        '
        'InventoryValue
        '
        Me.InventoryValue.HeaderText = "Inventory Value"
        Me.InventoryValue.Name = "InventoryValue"
        Me.InventoryValue.Width = 130
        '
        'ReorderCycle
        '
        Me.ReorderCycle.HeaderText = "Reorder Cycle"
        Me.ReorderCycle.Name = "ReorderCycle"
        '
        'ItemReorderQuantity
        '
        Me.ItemReorderQuantity.HeaderText = "Item Reorder Quantity"
        Me.ItemReorderQuantity.Name = "ItemReorderQuantity"
        Me.ItemReorderQuantity.Width = 150
        '
        'ItemDiscontinue
        '
        Me.ItemDiscontinue.HeaderText = "Item Discontinue?"
        Me.ItemDiscontinue.Name = "ItemDiscontinue"
        '
        'InventoryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1614, 891)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.btn_Back)
        Me.Controls.Add(Me.TextBox5)
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
End Class
