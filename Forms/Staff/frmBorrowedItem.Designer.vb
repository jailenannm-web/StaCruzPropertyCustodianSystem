Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBorrowedItem
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
        Me.lblBorrowed = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PropertyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitofMeasurement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BorrowQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BorrowDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpecteReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Condition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBorrowed
        '
        Me.lblBorrowed.AutoSize = True
        Me.lblBorrowed.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowed.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblBorrowed.Location = New System.Drawing.Point(79, 31)
        Me.lblBorrowed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBorrowed.Name = "lblBorrowed"
        Me.lblBorrowed.Size = New System.Drawing.Size(331, 58)
        Me.lblBorrowed.TabIndex = 1
        Me.lblBorrowed.Text = "My Borrowed Item"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertyName, Me.Category, Me.Description, Me.UnitofMeasurement, Me.BorrowQuantity, Me.BorrowDate, Me.ExpecteReturnDate, Me.Status, Me.Condition})
        Me.DataGridView1.Location = New System.Drawing.Point(79, 172)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1491, 868)
        Me.DataGridView1.TabIndex = 2
        '
        'PropertyName
        '
        Me.PropertyName.HeaderText = "Property Name"
        Me.PropertyName.MinimumWidth = 6
        Me.PropertyName.Name = "PropertyName"
        Me.PropertyName.Width = 125
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.MinimumWidth = 6
        Me.Category.Name = "Category"
        Me.Category.Width = 125
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 125
        '
        'UnitofMeasurement
        '
        Me.UnitofMeasurement.HeaderText = "Unit of Measurement"
        Me.UnitofMeasurement.MinimumWidth = 6
        Me.UnitofMeasurement.Name = "UnitofMeasurement"
        Me.UnitofMeasurement.Width = 125
        '
        'BorrowQuantity
        '
        Me.BorrowQuantity.HeaderText = "Borrow Quantity"
        Me.BorrowQuantity.MinimumWidth = 6
        Me.BorrowQuantity.Name = "BorrowQuantity"
        Me.BorrowQuantity.Width = 125
        '
        'BorrowDate
        '
        Me.BorrowDate.HeaderText = "Borrow Date"
        Me.BorrowDate.MinimumWidth = 6
        Me.BorrowDate.Name = "BorrowDate"
        Me.BorrowDate.Width = 125
        '
        'ExpecteReturnDate
        '
        Me.ExpecteReturnDate.HeaderText = "Expected Return Date"
        Me.ExpecteReturnDate.MinimumWidth = 6
        Me.ExpecteReturnDate.Name = "ExpecteReturnDate"
        Me.ExpecteReturnDate.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'Condition
        '
        Me.Condition.HeaderText = "Condition"
        Me.Condition.MinimumWidth = 6
        Me.Condition.Name = "Condition"
        Me.Condition.Width = 125
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(69, 95)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 161
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(134, 95)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(775, 41)
        Me.TextBox1.TabIndex = 160
        '
        'frmBorrowedItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1652, 1222)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblBorrowed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBorrowedItem"
        Me.Text = "frmBorrowedItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBorrowed As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PropertyName As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents UnitofMeasurement As DataGridViewTextBoxColumn
    Friend WithEvents BorrowQuantity As DataGridViewTextBoxColumn
    Friend WithEvents BorrowDate As DataGridViewTextBoxColumn
    Friend WithEvents ExpecteReturnDate As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Condition As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox1 As TextBox
End Class
