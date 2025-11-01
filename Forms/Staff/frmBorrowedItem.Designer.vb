Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBorrowedItem
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
        Me.lblBorrowed = New System.Windows.Forms.Label()
        Me.pnlBorrowedItem = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.dgvBorrowedItem = New System.Windows.Forms.DataGridView()
        Me.pnlBorrowedItem.SuspendLayout()
        CType(Me.dgvBorrowedItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBorrowed
        '
        Me.lblBorrowed.AutoSize = True
        Me.lblBorrowed.Font = New System.Drawing.Font("Leelawadee", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowed.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblBorrowed.Location = New System.Drawing.Point(382, 35)
        Me.lblBorrowed.Name = "lblBorrowed"
        Me.lblBorrowed.Size = New System.Drawing.Size(325, 41)
        Me.lblBorrowed.TabIndex = 1
        Me.lblBorrowed.Text = "My Borrowed Item"
        '
        'pnlBorrowedItem
        '
        Me.pnlBorrowedItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlBorrowedItem.Controls.Add(Me.dgvBorrowedItem)
        Me.pnlBorrowedItem.CornerRadius = 20
        Me.pnlBorrowedItem.Location = New System.Drawing.Point(12, 91)
        Me.pnlBorrowedItem.Name = "pnlBorrowedItem"
        Me.pnlBorrowedItem.Size = New System.Drawing.Size(1075, 569)
        Me.pnlBorrowedItem.TabIndex = 2
        '
        'dgvBorrowedItem
        '
        Me.dgvBorrowedItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBorrowedItem.Location = New System.Drawing.Point(0, 0)
        Me.dgvBorrowedItem.Name = "dgvBorrowedItem"
        Me.dgvBorrowedItem.Size = New System.Drawing.Size(1072, 566)
        Me.dgvBorrowedItem.TabIndex = 0
        '
        'frmBorrowedItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1099, 672)
        Me.Controls.Add(Me.pnlBorrowedItem)
        Me.Controls.Add(Me.lblBorrowed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBorrowedItem"
        Me.Text = "frmBorrowedItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlBorrowedItem.ResumeLayout(False)
        CType(Me.dgvBorrowedItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBorrowed As Label
    Friend WithEvents pnlBorrowedItem As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents dgvBorrowedItem As DataGridView
End Class
