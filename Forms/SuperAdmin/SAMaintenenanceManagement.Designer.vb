Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAMaintenenanceManagement
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
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.lblMaintenanceManagement = New System.Windows.Forms.Label()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.pnDgvPropertyRequest = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.dgvMaintenanceManagement = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlSearch.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.pnDgvPropertyRequest.SuspendLayout()
        CType(Me.dgvMaintenanceManagement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.CornerRadius = 20
        Me.pnlSearch.Location = New System.Drawing.Point(18, 101)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(613, 30)
        Me.pnlSearch.TabIndex = 45
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
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 20
        Me.pnlCategories.Location = New System.Drawing.Point(706, 101)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(133, 30)
        Me.pnlCategories.TabIndex = 47
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
        'lblMaintenanceManagement
        '
        Me.lblMaintenanceManagement.AutoSize = True
        Me.lblMaintenanceManagement.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaintenanceManagement.Location = New System.Drawing.Point(12, 42)
        Me.lblMaintenanceManagement.Name = "lblMaintenanceManagement"
        Me.lblMaintenanceManagement.Size = New System.Drawing.Size(355, 32)
        Me.lblMaintenanceManagement.TabIndex = 46
        Me.lblMaintenanceManagement.Text = "Maintenance Management"
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.comboStatus)
        Me.pnlStatus.CornerRadius = 20
        Me.pnlStatus.Location = New System.Drawing.Point(907, 101)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(133, 30)
        Me.pnlStatus.TabIndex = 48
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
        'pnDgvPropertyRequest
        '
        Me.pnDgvPropertyRequest.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnDgvPropertyRequest.Controls.Add(Me.dgvMaintenanceManagement)
        Me.pnDgvPropertyRequest.CornerRadius = 20
        Me.pnDgvPropertyRequest.Location = New System.Drawing.Point(18, 151)
        Me.pnDgvPropertyRequest.Name = "pnDgvPropertyRequest"
        Me.pnDgvPropertyRequest.Size = New System.Drawing.Size(1377, 532)
        Me.pnDgvPropertyRequest.TabIndex = 51
        '
        'dgvMaintenanceManagement
        '
        Me.dgvMaintenanceManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaintenanceManagement.Location = New System.Drawing.Point(13, 3)
        Me.dgvMaintenanceManagement.Name = "dgvMaintenanceManagement"
        Me.dgvMaintenanceManagement.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvMaintenanceManagement.Size = New System.Drawing.Size(1367, 526)
        Me.dgvMaintenanceManagement.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(856, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(637, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Categories"
        '
        'SAMaintenenanceManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1104, 693)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.lblMaintenanceManagement)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnDgvPropertyRequest)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SAMaintenenanceManagement"
        Me.Text = "SAMaintenenanceManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlCategories.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.pnDgvPropertyRequest.ResumeLayout(False)
        CType(Me.dgvMaintenanceManagement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSearch As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents pnlCategories As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents lblMaintenanceManagement As Label
    Friend WithEvents pnlStatus As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents pnDgvPropertyRequest As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents dgvMaintenanceManagement As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
