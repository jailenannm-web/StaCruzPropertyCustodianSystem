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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.fundClusterTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.entityNameTxt = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
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
        Me.RoundedButton2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reorder, Me.ItemNumber, Me.Manufacturer, Me.Description, Me.CostPerItem, Me.StockQuantity, Me.InventoryValue, Me.ReorderCycle, Me.ItemReorderQuantity, Me.ItemDiscontinue})
        Me.DataGridView1.Location = New System.Drawing.Point(334, 186)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(913, 652)
        Me.DataGridView1.TabIndex = 85
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblPropertyCard)
        Me.Panel11.Location = New System.Drawing.Point(334, 60)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(913, 64)
        Me.Panel11.TabIndex = 369
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(326, 12)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(266, 44)
        Me.lblPropertyCard.TabIndex = 38
        Me.lblPropertyCard.Text = "INVENTORY REPORT"
        Me.lblPropertyCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.fundClusterTxt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.entityNameTxt)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Location = New System.Drawing.Point(334, 123)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(913, 64)
        Me.Panel1.TabIndex = 370
        '
        'fundClusterTxt
        '
        Me.fundClusterTxt.Location = New System.Drawing.Point(135, 35)
        Me.fundClusterTxt.Name = "fundClusterTxt"
        Me.fundClusterTxt.Size = New System.Drawing.Size(302, 22)
        Me.fundClusterTxt.TabIndex = 57
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 22)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Reporter:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'entityNameTxt
        '
        Me.entityNameTxt.Location = New System.Drawing.Point(135, 7)
        Me.entityNameTxt.Name = "entityNameTxt"
        Me.entityNameTxt.Size = New System.Drawing.Size(302, 22)
        Me.entityNameTxt.TabIndex = 55
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(10, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(112, 22)
        Me.lblName.TabIndex = 38
        Me.lblName.Text = "Inventory Period:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Reorder
        '
        Me.Reorder.HeaderText = "Reorder?"
        Me.Reorder.MinimumWidth = 6
        Me.Reorder.Name = "Reorder"
        '
        'ItemNumber
        '
        Me.ItemNumber.HeaderText = "Item Number"
        Me.ItemNumber.MinimumWidth = 6
        Me.ItemNumber.Name = "ItemNumber"
        '
        'Manufacturer
        '
        Me.Manufacturer.HeaderText = "Manufacturer"
        Me.Manufacturer.MinimumWidth = 6
        Me.Manufacturer.Name = "Manufacturer"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        '
        'CostPerItem
        '
        Me.CostPerItem.HeaderText = "Cost Per Item"
        Me.CostPerItem.MinimumWidth = 6
        Me.CostPerItem.Name = "CostPerItem"
        '
        'StockQuantity
        '
        Me.StockQuantity.HeaderText = "Stock Quantity"
        Me.StockQuantity.MinimumWidth = 6
        Me.StockQuantity.Name = "StockQuantity"
        '
        'InventoryValue
        '
        Me.InventoryValue.HeaderText = "Inventory Value"
        Me.InventoryValue.MinimumWidth = 6
        Me.InventoryValue.Name = "InventoryValue"
        '
        'ReorderCycle
        '
        Me.ReorderCycle.HeaderText = "Reorder Cycle"
        Me.ReorderCycle.MinimumWidth = 6
        Me.ReorderCycle.Name = "ReorderCycle"
        '
        'ItemReorderQuantity
        '
        Me.ItemReorderQuantity.HeaderText = "Item Reorder Quantity"
        Me.ItemReorderQuantity.MinimumWidth = 6
        Me.ItemReorderQuantity.Name = "ItemReorderQuantity"
        '
        'ItemDiscontinue
        '
        Me.ItemDiscontinue.HeaderText = "Item Discontinue?"
        Me.ItemDiscontinue.MinimumWidth = 6
        Me.ItemDiscontinue.Name = "ItemDiscontinue"
        '
        'RoundedButton2
        '
        Me.RoundedButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton2.CornerRadius = 15
        Me.RoundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton2.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton2.Location = New System.Drawing.Point(772, 858)
        Me.RoundedButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton2.Name = "RoundedButton2"
        Me.RoundedButton2.Size = New System.Drawing.Size(153, 34)
        Me.RoundedButton2.TabIndex = 371
        Me.RoundedButton2.Text = "Back"
        Me.RoundedButton2.UseVisualStyleBackColor = False
        '
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(1094, 858)
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
        Me.btnCSV.Location = New System.Drawing.Point(933, 858)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(153, 34)
        Me.btnCSV.TabIndex = 367
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'InventoryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1569, 942)
        Me.Controls.Add(Me.RoundedButton2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_Back)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "InventoryReport"
        Me.Text = "InventoryReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_Back As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RoundedButton1 As Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As Resources.Controls.RoundedButton
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblPropertyCard As Label
    Friend WithEvents Reorder As DataGridViewTextBoxColumn
    Friend WithEvents ItemNumber As DataGridViewTextBoxColumn
    Friend WithEvents Manufacturer As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents CostPerItem As DataGridViewTextBoxColumn
    Friend WithEvents StockQuantity As DataGridViewTextBoxColumn
    Friend WithEvents InventoryValue As DataGridViewTextBoxColumn
    Friend WithEvents ReorderCycle As DataGridViewTextBoxColumn
    Friend WithEvents ItemReorderQuantity As DataGridViewTextBoxColumn
    Friend WithEvents ItemDiscontinue As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents fundClusterTxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents entityNameTxt As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents RoundedButton2 As Resources.Controls.RoundedButton
End Class
