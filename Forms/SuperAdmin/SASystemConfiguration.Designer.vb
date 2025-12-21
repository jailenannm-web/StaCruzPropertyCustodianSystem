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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SASystemConfiguration))
        Me.lblSystemConfig = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DBHost = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.port = New System.Windows.Forms.Label()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnTestConn = New System.Windows.Forms.Button()
        Me.btnSaveConn = New System.Windows.Forms.Button()
        Me.combostatus = New System.Windows.Forms.ComboBox()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.pm_as_propertyman = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pm_as_propertyman.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSystemConfig
        '
        Me.lblSystemConfig.AutoSize = False
        Me.lblSystemConfig.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblSystemConfig.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold)
        Me.lblSystemConfig.ForeColor = System.Drawing.Color.White
        Me.lblSystemConfig.Dock = DockStyle.Top
        Me.lblSystemConfig.Height = 90
        Me.lblSystemConfig.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemConfig.Name = "lblSystemConfig"
        Me.lblSystemConfig.Padding = New Padding(20, 20, 0, 0)
        Me.lblSystemConfig.TabIndex = 50
        Me.lblSystemConfig.Text = "System Configuration"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.Location = New System.Drawing.Point(738, 53)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(563, 27)
        Me.TextBox1.TabIndex = 157
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1411, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 23)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1649, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 23)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Categories"
        '
        'Label3
        '
        Me.Label3.AutoSize = False
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9!, System.Drawing.FontStyle.Regular)
        Me.Label3.ForeColor = System.Drawing.Color.LightGray
        Me.Label3.Location = New System.Drawing.Point(20, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(500, 25)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "Manage system-wide settings, connection, backups, and logs"
        '
        'DBHost
        '
        Me.DBHost.AutoSize = True
        Me.DBHost.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.DBHost.Location = New System.Drawing.Point(577, 311)
        Me.DBHost.Name = "DBHost"
        Me.DBHost.Size = New System.Drawing.Size(59, 23)
        Me.DBHost.TabIndex = 162
        Me.DBHost.Text = "DB Host"
        '
        'txtHost
        '
        Me.txtHost.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtHost.Location = New System.Drawing.Point(688, 307)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(419, 28)
        Me.txtHost.TabIndex = 163
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtPort.Location = New System.Drawing.Point(688, 354)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(419, 28)
        Me.txtPort.TabIndex = 165
        '
        'port
        '
        Me.port.AutoSize = True
        Me.port.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.port.Location = New System.Drawing.Point(577, 359)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(56, 23)
        Me.port.TabIndex = 164
        Me.port.Text = "DB Port"
        '
        'txtDBName
        '
        Me.txtDBName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtDBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDBName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtDBName.Location = New System.Drawing.Point(688, 404)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(419, 28)
        Me.txtDBName.TabIndex = 167
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(577, 409)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 23)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "DB Name"
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtUser.Location = New System.Drawing.Point(688, 459)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(419, 28)
        Me.txtUser.TabIndex = 169
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(577, 464)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 23)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "DB User"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.txtPassword.Location = New System.Drawing.Point(688, 512)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(419, 28)
        Me.txtPassword.TabIndex = 171
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(577, 517)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 23)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "DB Password"
        '
        'btnTestConn
        '
        Me.btnTestConn.BackColor = System.Drawing.Color.Black
        Me.btnTestConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTestConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConn.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnTestConn.ForeColor = System.Drawing.Color.White
        Me.btnTestConn.Location = New System.Drawing.Point(851, 582)
        Me.btnTestConn.Name = "btnTestConn"
        Me.btnTestConn.Size = New System.Drawing.Size(131, 46)
        Me.btnTestConn.TabIndex = 172
        Me.btnTestConn.Text = "Test Connection"
        Me.btnTestConn.UseVisualStyleBackColor = False
        '
        'btnSaveConn
        '
        Me.btnSaveConn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSaveConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveConn.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnSaveConn.ForeColor = System.Drawing.Color.White
        Me.btnSaveConn.Location = New System.Drawing.Point(988, 582)
        Me.btnSaveConn.Name = "btnSaveConn"
        Me.btnSaveConn.Size = New System.Drawing.Size(119, 46)
        Me.btnSaveConn.TabIndex = 173
        Me.btnSaveConn.Text = "Save Settings"
        Me.btnSaveConn.UseVisualStyleBackColor = False
        '
        'combostatus
        '
        Me.combostatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.combostatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.combostatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.combostatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FormattingEnabled = True
        Me.combostatus.Location = New System.Drawing.Point(1472, 55)
        Me.combostatus.Margin = New System.Windows.Forms.Padding(4)
        Me.combostatus.Name = "combostatus"
        Me.combostatus.Size = New System.Drawing.Size(144, 23)
        Me.combostatus.TabIndex = 1
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(1740, 55)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(144, 23)
        Me.comboCategoris.TabIndex = 0
        '
        'pm_as_propertyman
        '
        Me.pm_as_propertyman.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_propertyman.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_as_propertyman.Controls.Add(Me.comboCategoris)
        Me.pm_as_propertyman.Controls.Add(Me.combostatus)
        Me.pm_as_propertyman.Controls.Add(Me.lblSystemConfig)
        Me.pm_as_propertyman.Controls.Add(Me.Label1)
        Me.pm_as_propertyman.Controls.Add(Me.Label2)
        Me.pm_as_propertyman.Controls.Add(Me.TextBox1)
        Me.pm_as_propertyman.CornerRadius = 20
        Me.pm_as_propertyman.Location = New System.Drawing.Point(-13, -8)
        Me.pm_as_propertyman.Name = "pm_as_propertyman"
        Me.pm_as_propertyman.Size = New System.Drawing.Size(1973, 124)
        Me.pm_as_propertyman.TabIndex = 160
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(672, 36)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(49, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 158
        Me.PictureBox2.TabStop = False
        '
        'SASystemConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1942, 1102)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSaveConn)
        Me.Controls.Add(Me.btnTestConn)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.port)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.DBHost)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.pm_as_propertyman)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SASystemConfiguration"
        Me.Text = "SASystemConfiguration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pm_as_propertyman.ResumeLayout(False)
        Me.pm_as_propertyman.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSystemConfig As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents combostatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pm_as_propertyman As Resources.Controls.RoundedPanel
    Friend WithEvents DBHost As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents port As Label
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnTestConn As Button
    Friend WithEvents btnSaveConn As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
