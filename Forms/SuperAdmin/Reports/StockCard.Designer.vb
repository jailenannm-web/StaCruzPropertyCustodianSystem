Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockCard1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.NumberOfDaysConsume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.Office = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Quantity1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateAndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.description = New System.Windows.Forms.TextBox()
        Me.unitofmeasurement = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_Back = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.item = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumberOfDaysConsume
        '
        Me.NumberOfDaysConsume.HeaderText = "Number of Days Consume"
        Me.NumberOfDaysConsume.MinimumWidth = 6
        Me.NumberOfDaysConsume.Name = "NumberOfDaysConsume"
        Me.NumberOfDaysConsume.Width = 300
        '
        'Quantity3
        '
        Me.Quantity3.HeaderText = "Quantity"
        Me.Quantity3.MinimumWidth = 6
        Me.Quantity3.Name = "Quantity3"
        Me.Quantity3.Width = 200
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Quantity3, Me.NumberOfDaysConsume})
        Me.DataGridView3.Location = New System.Drawing.Point(1006, 393)
        Me.DataGridView3.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersWidth = 51
        Me.DataGridView3.Size = New System.Drawing.Size(724, 410)
        Me.DataGridView3.TabIndex = 82
        '
        'Office
        '
        Me.Office.HeaderText = "Office"
        Me.Office.MinimumWidth = 6
        Me.Office.Name = "Office"
        Me.Office.ReadOnly = True
        Me.Office.Width = 125
        '
        'Quantity2
        '
        Me.Quantity2.HeaderText = "Quantity"
        Me.Quantity2.MinimumWidth = 6
        Me.Quantity2.Name = "Quantity2"
        Me.Quantity2.ReadOnly = True
        Me.Quantity2.Width = 125
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Quantity2, Me.Office})
        Me.DataGridView2.Location = New System.Drawing.Point(664, 393)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.Size = New System.Drawing.Size(333, 410)
        Me.DataGridView2.TabIndex = 81
        '
        'Quantity1
        '
        Me.Quantity1.HeaderText = "Quantity"
        Me.Quantity1.MinimumWidth = 6
        Me.Quantity1.Name = "Quantity1"
        Me.Quantity1.Width = 125
        '
        'Referencre
        '
        Me.Referencre.HeaderText = "Referencre"
        Me.Referencre.MinimumWidth = 6
        Me.Referencre.Name = "Referencre"
        Me.Referencre.Width = 125
        '
        'DateAndTime
        '
        Me.DateAndTime.HeaderText = "Date"
        Me.DateAndTime.MinimumWidth = 6
        Me.DateAndTime.Name = "DateAndTime"
        Me.DateAndTime.Width = 125
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateAndTime, Me.Referencre, Me.Quantity1})
        Me.DataGridView1.Location = New System.Drawing.Point(236, 296)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(459, 410)
        Me.DataGridView1.TabIndex = 80
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(0, 0)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(100, 22)
        Me.TextBox7.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 1
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(0, 0)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 22)
        Me.TextBox6.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(229, 231)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 32)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Unit of Mesurement :"
        '
        'description
        '
        Me.description.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(351, 198)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(593, 35)
        Me.description.TabIndex = 53
        '
        'unitofmeasurement
        '
        Me.unitofmeasurement.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitofmeasurement.Location = New System.Drawing.Point(351, 228)
        Me.unitofmeasurement.Multiline = True
        Me.unitofmeasurement.Name = "unitofmeasurement"
        Me.unitofmeasurement.Size = New System.Drawing.Size(593, 35)
        Me.unitofmeasurement.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(814, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 30)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Re-order Point :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(814, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Stock No :"
        '
        'TextBox4
        '
        Me.TextBox4.CausesValidation = False
        Me.TextBox4.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(920, 165)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(619, 35)
        Me.TextBox4.TabIndex = 57
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(920, 195)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(619, 36)
        Me.TextBox5.TabIndex = 58
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(436, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 31)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Receipt :"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.CausesValidation = False
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(685, 270)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 17)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Issue"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(916, 262)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(109, 31)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "Balance"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Back
        '
        Me.btn_Back.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Back.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Back.ForeColor = System.Drawing.Color.White
        Me.btn_Back.Location = New System.Drawing.Point(809, 1153)
        Me.btn_Back.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(235, 52)
        Me.btn_Back.TabIndex = 78
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1141, 1153)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(235, 52)
        Me.Button1.TabIndex = 79
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(229, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 32)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Item :"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(229, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 33)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Description :"
        '
        'item
        '
        Me.item.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.item.Location = New System.Drawing.Point(351, 169)
        Me.item.Multiline = True
        Me.item.Name = "item"
        Me.item.Size = New System.Drawing.Size(593, 35)
        Me.item.TabIndex = 12
        Me.item.Text = " "
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(967, 110)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(243, 46)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Stock Card"
        '
        'StockCard1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_Back)
        Me.Controls.Add(Me.item)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.description)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.unitofmeasurement)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "StockCard1"
        Me.Text = "StockCard1"
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NumberOfDaysConsume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents Office As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents description As System.Windows.Forms.TextBox
    Friend WithEvents unitofmeasurement As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btn_Back As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents item As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Quantity1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateAndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
