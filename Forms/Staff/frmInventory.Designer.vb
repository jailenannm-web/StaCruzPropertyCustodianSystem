Imports System
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventory))
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategory = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.RoundedPanel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventory.Location = New System.Drawing.Point(617, 36)
        Me.lblInventory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(210, 52)
        Me.lblInventory.TabIndex = 8
        Me.lblInventory.Text = "Inventory"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(860, 124)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(84, 20)
        Me.lblCategory.TabIndex = 15
        Me.lblCategory.Text = "Category"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(1087, 124)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(63, 20)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel4.Controls.Add(Me.PictureBox1)
        Me.RoundedPanel4.Controls.Add(Me.txtSearch)
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(151, 143)
        Me.RoundedPanel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(607, 41)
        Me.RoundedPanel4.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(20, 4)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(61, 12)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(527, 22)
        Me.txtSearch.TabIndex = 0
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.comboCategory)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(847, 146)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(207, 41)
        Me.RoundedPanel1.TabIndex = 11
        '
        'comboCategory
        '
        Me.comboCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategory.FormattingEnabled = True
        Me.comboCategory.Location = New System.Drawing.Point(16, 7)
        Me.comboCategory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboCategory.Name = "comboCategory"
        Me.comboCategory.Size = New System.Drawing.Size(173, 24)
        Me.comboCategory.TabIndex = 9
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel3.Controls.Add(Me.dgvInventory)
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(16, 215)
        Me.RoundedPanel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(1417, 598)
        Me.RoundedPanel3.TabIndex = 13
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel2.Controls.Add(Me.comboStatus)
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(1077, 146)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(207, 41)
        Me.RoundedPanel2.TabIndex = 12
        '
        'comboStatus
        '
        Me.comboStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Location = New System.Drawing.Point(13, 7)
        Me.comboStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(173, 24)
        Me.comboStatus.TabIndex = 10
        '
        'dgvInventory
        '
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventory.Location = New System.Drawing.Point(4, 4)
        Me.dgvInventory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.RowHeadersWidth = 51
        Me.dgvInventory.Size = New System.Drawing.Size(1417, 591)
        Me.dgvInventory.TabIndex = 0
        '
        'frmInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1449, 852)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.RoundedPanel4)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.lblInventory)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmInventory"
        Me.Text = "frmInventory"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RoundedPanel4.ResumeLayout(False)
        Me.RoundedPanel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel2.ResumeLayout(False)
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblInventory As Label
    Friend WithEvents comboCategory As ComboBox
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents dgvInventory As DataGridView
End Class
