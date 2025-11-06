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
        Me.pnlSearch = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnAddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.lblSuppliesManagement = New System.Windows.Forms.Label()
        Me.dgvSuppliesManagement = New System.Windows.Forms.DataGridView()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.pnlDgvSuppliesManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlSearch.SuspendLayout()
        CType(Me.dgvSuppliesManagement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategories.SuspendLayout()
        Me.pnlDgvSuppliesManagement.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.CornerRadius = 20
        Me.pnlSearch.Location = New System.Drawing.Point(37, 104)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(613, 30)
        Me.pnlSearch.TabIndex = 22
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Location = New System.Drawing.Point(165, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(435, 13)
        Me.txtSearch.TabIndex = 0
        '
        'btnAddSupply
        '
        Me.btnAddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAddSupply.CornerRadius = 15
        Me.btnAddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupply.Font = New System.Drawing.Font("Leelawadee", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSupply.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddSupply.Location = New System.Drawing.Point(946, 629)
        Me.btnAddSupply.Name = "btnAddSupply"
        Me.btnAddSupply.Size = New System.Drawing.Size(94, 31)
        Me.btnAddSupply.TabIndex = 25
        Me.btnAddSupply.Text = "Add Supply"
        Me.btnAddSupply.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Leelawadee", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(821, 629)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(94, 31)
        Me.btnEdit.TabIndex = 24
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'lblSuppliesManagement
        '
        Me.lblSuppliesManagement.AutoSize = True
        Me.lblSuppliesManagement.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuppliesManagement.Location = New System.Drawing.Point(31, 45)
        Me.lblSuppliesManagement.Name = "lblSuppliesManagement"
        Me.lblSuppliesManagement.Size = New System.Drawing.Size(300, 32)
        Me.lblSuppliesManagement.TabIndex = 23
        Me.lblSuppliesManagement.Text = "Supplies Management"
        '
        'dgvSuppliesManagement
        '
        Me.dgvSuppliesManagement.AllowUserToResizeColumns = False
        Me.dgvSuppliesManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuppliesManagement.Location = New System.Drawing.Point(12, 0)
        Me.dgvSuppliesManagement.Name = "dgvSuppliesManagement"
        Me.dgvSuppliesManagement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvSuppliesManagement.Size = New System.Drawing.Size(1019, 455)
        Me.dgvSuppliesManagement.TabIndex = 9
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 20
        Me.pnlCategories.Location = New System.Drawing.Point(725, 104)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(133, 30)
        Me.pnlCategories.TabIndex = 27
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(13, 4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(111, 21)
        Me.comboCategoris.TabIndex = 0
        '
        'pnlDgvSuppliesManagement
        '
        Me.pnlDgvSuppliesManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlDgvSuppliesManagement.Controls.Add(Me.dgvSuppliesManagement)
        Me.pnlDgvSuppliesManagement.CornerRadius = 20
        Me.pnlDgvSuppliesManagement.Location = New System.Drawing.Point(28, 162)
        Me.pnlDgvSuppliesManagement.Name = "pnlDgvSuppliesManagement"
        Me.pnlDgvSuppliesManagement.Size = New System.Drawing.Size(1031, 461)
        Me.pnlDgvSuppliesManagement.TabIndex = 26
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.comboStatus)
        Me.pnlStatus.CornerRadius = 20
        Me.pnlStatus.Location = New System.Drawing.Point(926, 104)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(133, 30)
        Me.pnlStatus.TabIndex = 28
        '
        'comboStatus
        '
        Me.comboStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Location = New System.Drawing.Point(11, 5)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(111, 21)
        Me.comboStatus.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(875, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(656, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Categories"
        '
        'SASuppliesManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1088, 654)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.btnAddSupply)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblSuppliesManagement)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.pnlDgvSuppliesManagement)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SASuppliesManagement"
        Me.Text = "SASuppliesManagement"
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        CType(Me.dgvSuppliesManagement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategories.ResumeLayout(False)
        Me.pnlDgvSuppliesManagement.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSearch As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnAddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents lblSuppliesManagement As Label
    Friend WithEvents dgvSuppliesManagement As DataGridView
    Friend WithEvents pnlCategories As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents pnlDgvSuppliesManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents pnlStatus As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
