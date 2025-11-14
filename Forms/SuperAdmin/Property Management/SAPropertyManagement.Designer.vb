Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAPropertyManagement
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
        Me.pnlSearch = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnAddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.lblPropertyManagement = New System.Windows.Forms.Label()
        Me.dgvPropertyManagement = New System.Windows.Forms.DataGridView()
        Me.pnlDgvPropertyManagement = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlSearch.SuspendLayout()
        CType(Me.dgvPropertyManagement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDgvPropertyManagement.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.CornerRadius = 20
        Me.pnlSearch.Location = New System.Drawing.Point(61, 132)
        Me.pnlSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(817, 37)
        Me.pnlSearch.TabIndex = 13
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Location = New System.Drawing.Point(220, 12)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(580, 15)
        Me.txtSearch.TabIndex = 0
        '
        'btnAddSupply
        '
        Me.btnAddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAddSupply.CornerRadius = 15
        Me.btnAddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSupply.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddSupply.Location = New System.Drawing.Point(1273, 778)
        Me.btnAddSupply.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddSupply.Name = "btnAddSupply"
        Me.btnAddSupply.Size = New System.Drawing.Size(125, 38)
        Me.btnAddSupply.TabIndex = 16
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
        Me.btnEdit.Location = New System.Drawing.Point(1107, 778)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(125, 38)
        Me.btnEdit.TabIndex = 15
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'lblPropertyManagement
        '
        Me.lblPropertyManagement.AutoSize = True
        Me.lblPropertyManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyManagement.Location = New System.Drawing.Point(53, 59)
        Me.lblPropertyManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPropertyManagement.Name = "lblPropertyManagement"
        Me.lblPropertyManagement.Size = New System.Drawing.Size(371, 39)
        Me.lblPropertyManagement.TabIndex = 14
        Me.lblPropertyManagement.Text = "Property Management"
        '
        'dgvPropertyManagement
        '
        Me.dgvPropertyManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPropertyManagement.Location = New System.Drawing.Point(16, 4)
        Me.dgvPropertyManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvPropertyManagement.Name = "dgvPropertyManagement"
        Me.dgvPropertyManagement.RowHeadersWidth = 51
        Me.dgvPropertyManagement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvPropertyManagement.Size = New System.Drawing.Size(1359, 560)
        Me.dgvPropertyManagement.TabIndex = 9
        '
        'pnlDgvPropertyManagement
        '
        Me.pnlDgvPropertyManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlDgvPropertyManagement.Controls.Add(Me.dgvPropertyManagement)
        Me.pnlDgvPropertyManagement.CornerRadius = 20
        Me.pnlDgvPropertyManagement.Location = New System.Drawing.Point(49, 203)
        Me.pnlDgvPropertyManagement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlDgvPropertyManagement.Name = "pnlDgvPropertyManagement"
        Me.pnlDgvPropertyManagement.Size = New System.Drawing.Size(1375, 567)
        Me.pnlDgvPropertyManagement.TabIndex = 17
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 20
        Me.pnlCategories.Location = New System.Drawing.Point(979, 132)
        Me.pnlCategories.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(177, 37)
        Me.pnlCategories.TabIndex = 18
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(17, 5)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(147, 24)
        Me.comboCategoris.TabIndex = 0
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.comboStatus)
        Me.pnlStatus.CornerRadius = 20
        Me.pnlStatus.Location = New System.Drawing.Point(1247, 132)
        Me.pnlStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(177, 37)
        Me.pnlStatus.TabIndex = 19
        '
        'comboStatus
        '
        Me.comboStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Location = New System.Drawing.Point(15, 6)
        Me.comboStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(147, 24)
        Me.comboStatus.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(887, 143)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Categories"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1179, 144)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Status"
        '
        'SAPropertyManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1472, 874)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.btnAddSupply)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblPropertyManagement)
        Me.Controls.Add(Me.pnlDgvPropertyManagement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SAPropertyManagement"
        Me.Text = "SAPropertyManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        CType(Me.dgvPropertyManagement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDgvPropertyManagement.ResumeLayout(False)
        Me.pnlCategories.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSearch As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnAddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents lblPropertyManagement As Label
    Friend WithEvents dgvPropertyManagement As DataGridView
    Friend WithEvents pnlDgvPropertyManagement As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents pnlCategories As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents pnlStatus As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
