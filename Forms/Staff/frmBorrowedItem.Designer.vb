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
        Me.UnitOfMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpirationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBorrowed
        '
        Me.lblBorrowed.AutoSize = True
        Me.lblBorrowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowed.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblBorrowed.Location = New System.Drawing.Point(397, 38)
        Me.lblBorrowed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBorrowed.Name = "lblBorrowed"
        Me.lblBorrowed.Size = New System.Drawing.Size(393, 52)
        Me.lblBorrowed.TabIndex = 1
        Me.lblBorrowed.Text = "My Borrowed Item"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertyName, Me.Category, Me.Description, Me.UnitOfMeasure, Me.ExpirationDate})
        Me.DataGridView1.Location = New System.Drawing.Point(407, 144)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(678, 653)
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
        'UnitOfMeasure
        '
        Me.UnitOfMeasure.HeaderText = "Unit Of Measure"
        Me.UnitOfMeasure.MinimumWidth = 6
        Me.UnitOfMeasure.Name = "UnitOfMeasure"
        Me.UnitOfMeasure.Width = 125
        '
        'ExpirationDate
        '
        Me.ExpirationDate.HeaderText = "Expiration Date"
        Me.ExpirationDate.MinimumWidth = 6
        Me.ExpirationDate.Name = "ExpirationDate"
        Me.ExpirationDate.Width = 125
        '
        'frmBorrowedItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1465, 827)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblBorrowed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBorrowedItem"
        Me.Text = "frmBorrowedItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBorrowed As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PropertyName As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents UnitOfMeasure As DataGridViewTextBoxColumn
    Friend WithEvents ExpirationDate As DataGridViewTextBoxColumn
End Class
