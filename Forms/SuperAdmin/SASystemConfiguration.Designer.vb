Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SASystemConfiguration
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
        Me.lblSystemConfig = New System.Windows.Forms.Label()
        Me.dgvSystemConfiguration = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.combostatus = New System.Windows.Forms.ComboBox()
        CType(Me.dgvSystemConfiguration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatus.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSystemConfig
        '
        Me.lblSystemConfig.AutoSize = True
        Me.lblSystemConfig.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold)
        Me.lblSystemConfig.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblSystemConfig.Location = New System.Drawing.Point(158, 114)
        Me.lblSystemConfig.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemConfig.Name = "lblSystemConfig"
        Me.lblSystemConfig.Size = New System.Drawing.Size(395, 58)
        Me.lblSystemConfig.TabIndex = 50
        Me.lblSystemConfig.Text = "System Configuration"
        '
        'dgvSystemConfiguration
        '
        Me.dgvSystemConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSystemConfiguration.Location = New System.Drawing.Point(155, 280)
        Me.dgvSystemConfiguration.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSystemConfiguration.Name = "dgvSystemConfiguration"
        Me.dgvSystemConfiguration.RowHeadersWidth = 51
        Me.dgvSystemConfiguration.Size = New System.Drawing.Size(1356, 667)
        Me.dgvSystemConfiguration.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(151, 200)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 158
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(211, 200)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(729, 41)
        Me.TextBox1.TabIndex = 157
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label2.Location = New System.Drawing.Point(1261, 210)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 30)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label1.Location = New System.Drawing.Point(953, 212)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 30)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Categories"
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.combostatus)
        Me.pnlStatus.CornerRadius = 5
        Me.pnlStatus.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlStatus.Location = New System.Drawing.Point(1329, 203)
        Me.pnlStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(177, 37)
        Me.pnlStatus.TabIndex = 154
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 5
        Me.pnlCategories.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlCategories.Location = New System.Drawing.Point(1061, 205)
        Me.pnlCategories.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(177, 37)
        Me.pnlCategories.TabIndex = 153
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(19, 7)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(144, 23)
        Me.comboCategoris.TabIndex = 0
        '
        'combostatus
        '
        Me.combostatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.combostatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.combostatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FormattingEnabled = True
        Me.combostatus.Location = New System.Drawing.Point(16, 7)
        Me.combostatus.Margin = New System.Windows.Forms.Padding(4)
        Me.combostatus.Name = "combostatus"
        Me.combostatus.Size = New System.Drawing.Size(144, 23)
        Me.combostatus.TabIndex = 1
        '
        'SASystemConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1773, 1080)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.dgvSystemConfiguration)
        Me.Controls.Add(Me.lblSystemConfig)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SASystemConfiguration"
        Me.Text = "SASystemConfiguration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvSystemConfiguration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlCategories.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSystemConfig As Label
    Friend WithEvents dgvSystemConfiguration As DataGridView
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlStatus As Resources.Controls.RoundedPanel
    Friend WithEvents pnlCategories As Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents combostatus As ComboBox
End Class
