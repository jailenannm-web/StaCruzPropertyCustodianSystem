Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SASuppliesManagement
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
        Me.btnAddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.lblSuppliesManagement = New System.Windows.Forms.Label()
        Me.dgvSuppliesManagement = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        CType(Me.dgvSuppliesManagement, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatus.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddSupply
        '
        Me.btnAddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAddSupply.CornerRadius = 15
        Me.btnAddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSupply.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddSupply.Location = New System.Drawing.Point(1372, 1029)
        Me.btnAddSupply.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddSupply.Name = "btnAddSupply"
        Me.btnAddSupply.Size = New System.Drawing.Size(125, 38)
        Me.btnAddSupply.TabIndex = 25
        Me.btnAddSupply.Text = "Add Supply"
        Me.btnAddSupply.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(1206, 1029)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(125, 38)
        Me.btnEdit.TabIndex = 24
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'lblSuppliesManagement
        '
        Me.lblSuppliesManagement.AutoSize = True
        Me.lblSuppliesManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuppliesManagement.Location = New System.Drawing.Point(131, 69)
        Me.lblSuppliesManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSuppliesManagement.Name = "lblSuppliesManagement"
        Me.lblSuppliesManagement.Size = New System.Drawing.Size(375, 39)
        Me.lblSuppliesManagement.TabIndex = 23
        Me.lblSuppliesManagement.Text = "Supplies Management"
        '
        'dgvSuppliesManagement
        '
        Me.dgvSuppliesManagement.AllowUserToResizeColumns = False
        Me.dgvSuppliesManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuppliesManagement.Location = New System.Drawing.Point(146, 214)
        Me.dgvSuppliesManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSuppliesManagement.Name = "dgvSuppliesManagement"
        Me.dgvSuppliesManagement.RowHeadersWidth = 51
        Me.dgvSuppliesManagement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvSuppliesManagement.Size = New System.Drawing.Size(1351, 796)
        Me.dgvSuppliesManagement.TabIndex = 9
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(139, 136)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 152
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(199, 136)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(729, 41)
        Me.TextBox1.TabIndex = 151
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1249, 146)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(941, 148)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "Categories"
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.comboStatus)
        Me.pnlStatus.CornerRadius = 5
        Me.pnlStatus.Location = New System.Drawing.Point(1317, 139)
        Me.pnlStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(177, 37)
        Me.pnlStatus.TabIndex = 148
        '
        'comboStatus
        '
        Me.comboStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Location = New System.Drawing.Point(14, 9)
        Me.comboStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(147, 24)
        Me.comboStatus.TabIndex = 0
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 5
        Me.pnlCategories.Location = New System.Drawing.Point(1049, 141)
        Me.pnlCategories.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(177, 37)
        Me.pnlCategories.TabIndex = 147
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(13, 8)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(147, 24)
        Me.comboCategoris.TabIndex = 0
        '
        'SASuppliesManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1773, 1080)
        Me.Controls.Add(Me.dgvSuppliesManagement)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.btnAddSupply)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblSuppliesManagement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SASuppliesManagement"
        Me.Text = "SASuppliesManagement"
        CType(Me.dgvSuppliesManagement, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlCategories.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents lblSuppliesManagement As Label
    Friend WithEvents dgvSuppliesManagement As DataGridView
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlStatus As Resources.Controls.RoundedPanel
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents pnlCategories As Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
End Class
