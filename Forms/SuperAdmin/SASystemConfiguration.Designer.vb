Imports System
Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SASystemConfiguration
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.grpDatabaseSettings = New System.Windows.Forms.GroupBox()
        Me.lblDbHost = New System.Windows.Forms.Label()
        Me.txtDbHost = New System.Windows.Forms.TextBox()
        Me.lblDbPort = New System.Windows.Forms.Label()
        Me.txtDbPort = New System.Windows.Forms.TextBox()
        Me.lblDbName = New System.Windows.Forms.Label()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.lblDbUser = New System.Windows.Forms.Label()
        Me.txtDbUser = New System.Windows.Forms.TextBox()
        Me.lblDbPassword = New System.Windows.Forms.Label()
        Me.txtDbPassword = New System.Windows.Forms.TextBox()
        Me.btnTestConnection = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.grpSystemSettings = New System.Windows.Forms.GroupBox()
        Me.lblSystemName = New System.Windows.Forms.Label()
        Me.txtSystemName = New System.Windows.Forms.TextBox()
        Me.lblOrgName = New System.Windows.Forms.Label()
        Me.txtOrgName = New System.Windows.Forms.TextBox()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnRefresh = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.lblConnectionStatus = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.grpDatabaseSettings.SuspendLayout()
        Me.grpSystemSettings.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlHeader.Size = New System.Drawing.Size(1394, 100)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Poppins SemiBold", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(30, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(284, 42)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "System Configuration"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(33, 60)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(388, 22)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Manage system settings, database connection, and configuration"
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.grpDatabaseSettings)
        Me.pnlMain.Controls.Add(Me.grpSystemSettings)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 100)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(30, 20, 30, 80)
        Me.pnlMain.Size = New System.Drawing.Size(1394, 703)
        Me.pnlMain.TabIndex = 1
        '
        'grpDatabaseSettings
        '
        Me.grpDatabaseSettings.BackColor = System.Drawing.Color.White
        Me.grpDatabaseSettings.Controls.Add(Me.lblDbHost)
        Me.grpDatabaseSettings.Controls.Add(Me.txtDbHost)
        Me.grpDatabaseSettings.Controls.Add(Me.lblDbPort)
        Me.grpDatabaseSettings.Controls.Add(Me.txtDbPort)
        Me.grpDatabaseSettings.Controls.Add(Me.lblDbName)
        Me.grpDatabaseSettings.Controls.Add(Me.txtDbName)
        Me.grpDatabaseSettings.Controls.Add(Me.lblDbUser)
        Me.grpDatabaseSettings.Controls.Add(Me.txtDbUser)
        Me.grpDatabaseSettings.Controls.Add(Me.lblDbPassword)
        Me.grpDatabaseSettings.Controls.Add(Me.txtDbPassword)
        Me.grpDatabaseSettings.Controls.Add(Me.btnTestConnection)
        Me.grpDatabaseSettings.Controls.Add(Me.lblConnectionStatus)
        Me.grpDatabaseSettings.Font = New System.Drawing.Font("Poppins SemiBold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpDatabaseSettings.Location = New System.Drawing.Point(30, 20)
        Me.grpDatabaseSettings.Name = "grpDatabaseSettings"
        Me.grpDatabaseSettings.Padding = New System.Windows.Forms.Padding(20)
        Me.grpDatabaseSettings.Size = New System.Drawing.Size(650, 450)
        Me.grpDatabaseSettings.TabIndex = 0
        Me.grpDatabaseSettings.TabStop = False
        Me.grpDatabaseSettings.Text = "Database Connection Settings"
        '
        'lblDbHost
        '
        Me.lblDbHost.AutoSize = True
        Me.lblDbHost.Font = New System.Drawing.Font("Poppins", 9.5!)
        Me.lblDbHost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDbHost.Location = New System.Drawing.Point(25, 50)
        Me.lblDbHost.Name = "lblDbHost"
        Me.lblDbHost.Size = New System.Drawing.Size(107, 23)
        Me.lblDbHost.TabIndex = 0
        Me.lblDbHost.Text = "Database Host"
        '
        'txtDbHost
        '
        Me.txtDbHost.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.txtDbHost.Location = New System.Drawing.Point(25, 75)
        Me.txtDbHost.Name = "txtDbHost"
        Me.txtDbHost.Size = New System.Drawing.Size(400, 27)
        Me.txtDbHost.TabIndex = 1
        '
        'lblDbPort
        '
        Me.lblDbPort.AutoSize = True
        Me.lblDbPort.Font = New System.Drawing.Font("Poppins", 9.5!)
        Me.lblDbPort.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDbPort.Location = New System.Drawing.Point(450, 50)
        Me.lblDbPort.Name = "lblDbPort"
        Me.lblDbPort.Size = New System.Drawing.Size(38, 23)
        Me.lblDbPort.TabIndex = 2
        Me.lblDbPort.Text = "Port"
        '
        'txtDbPort
        '
        Me.txtDbPort.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.txtDbPort.Location = New System.Drawing.Point(450, 75)
        Me.txtDbPort.Name = "txtDbPort"
        Me.txtDbPort.Size = New System.Drawing.Size(165, 27)
        Me.txtDbPort.TabIndex = 3
        '
        'lblDbName
        '
        Me.lblDbName.AutoSize = True
        Me.lblDbName.Font = New System.Drawing.Font("Poppins", 9.5!)
        Me.lblDbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDbName.Location = New System.Drawing.Point(25, 120)
        Me.lblDbName.Name = "lblDbName"
        Me.lblDbName.Size = New System.Drawing.Size(113, 23)
        Me.lblDbName.TabIndex = 4
        Me.lblDbName.Text = "Database Name"
        '
        'txtDbName
        '
        Me.txtDbName.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.txtDbName.Location = New System.Drawing.Point(25, 145)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.Size = New System.Drawing.Size(590, 27)
        Me.txtDbName.TabIndex = 5
        '
        'lblDbUser
        '
        Me.lblDbUser.AutoSize = True
        Me.lblDbUser.Font = New System.Drawing.Font("Poppins", 9.5!)
        Me.lblDbUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDbUser.Location = New System.Drawing.Point(25, 190)
        Me.lblDbUser.Name = "lblDbUser"
        Me.lblDbUser.Size = New System.Drawing.Size(73, 23)
        Me.lblDbUser.TabIndex = 6
        Me.lblDbUser.Text = "Username"
        '
        'txtDbUser
        '
        Me.txtDbUser.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.txtDbUser.Location = New System.Drawing.Point(25, 215)
        Me.txtDbUser.Name = "txtDbUser"
        Me.txtDbUser.Size = New System.Drawing.Size(590, 27)
        Me.txtDbUser.TabIndex = 7
        '
        'lblDbPassword
        '
        Me.lblDbPassword.AutoSize = True
        Me.lblDbPassword.Font = New System.Drawing.Font("Poppins", 9.5!)
        Me.lblDbPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDbPassword.Location = New System.Drawing.Point(25, 260)
        Me.lblDbPassword.Name = "lblDbPassword"
        Me.lblDbPassword.Size = New System.Drawing.Size(74, 23)
        Me.lblDbPassword.TabIndex = 8
        Me.lblDbPassword.Text = "Password"
        '
        'txtDbPassword
        '
        Me.txtDbPassword.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.txtDbPassword.Location = New System.Drawing.Point(25, 285)
        Me.txtDbPassword.Name = "txtDbPassword"
        Me.txtDbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtDbPassword.Size = New System.Drawing.Size(590, 27)
        Me.txtDbPassword.TabIndex = 9
        Me.txtDbPassword.UseSystemPasswordChar = True
        '
        'btnTestConnection
        '
        Me.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConnection.Font = New System.Drawing.Font("Poppins SemiBold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTestConnection.ForeColor = System.Drawing.Color.White
        Me.btnTestConnection.Location = New System.Drawing.Point(25, 340)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(180, 40)
        Me.btnTestConnection.TabIndex = 10
        Me.btnTestConnection.Text = "Test Connection"
        Me.btnTestConnection.UseVisualStyleBackColor = False
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblConnectionStatus.Location = New System.Drawing.Point(25, 395)
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Size = New System.Drawing.Size(590, 30)
        Me.lblConnectionStatus.TabIndex = 11
        Me.lblConnectionStatus.Text = "Status: Not tested"
        Me.lblConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpSystemSettings
        '
        Me.grpSystemSettings.BackColor = System.Drawing.Color.White
        Me.grpSystemSettings.Controls.Add(Me.lblSystemName)
        Me.grpSystemSettings.Controls.Add(Me.txtSystemName)
        Me.grpSystemSettings.Controls.Add(Me.lblOrgName)
        Me.grpSystemSettings.Controls.Add(Me.txtOrgName)
        Me.grpSystemSettings.Font = New System.Drawing.Font("Poppins SemiBold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpSystemSettings.Location = New System.Drawing.Point(714, 20)
        Me.grpSystemSettings.Name = "grpSystemSettings"
        Me.grpSystemSettings.Padding = New System.Windows.Forms.Padding(20)
        Me.grpSystemSettings.Size = New System.Drawing.Size(650, 250)
        Me.grpSystemSettings.TabIndex = 1
        Me.grpSystemSettings.TabStop = False
        Me.grpSystemSettings.Text = "System Settings"
        '
        'lblSystemName
        '
        Me.lblSystemName.AutoSize = True
        Me.lblSystemName.Font = New System.Drawing.Font("Poppins", 9.5!)
        Me.lblSystemName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSystemName.Location = New System.Drawing.Point(25, 50)
        Me.lblSystemName.Name = "lblSystemName"
        Me.lblSystemName.Size = New System.Drawing.Size(101, 23)
        Me.lblSystemName.TabIndex = 0
        Me.lblSystemName.Text = "System Name"
        '
        'txtSystemName
        '
        Me.txtSystemName.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.txtSystemName.Location = New System.Drawing.Point(25, 75)
        Me.txtSystemName.Multiline = True
        Me.txtSystemName.Name = "txtSystemName"
        Me.txtSystemName.Size = New System.Drawing.Size(590, 50)
        Me.txtSystemName.TabIndex = 1
        '
        'lblOrgName
        '
        Me.lblOrgName.AutoSize = True
        Me.lblOrgName.Font = New System.Drawing.Font("Poppins", 9.5!)
        Me.lblOrgName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOrgName.Location = New System.Drawing.Point(25, 140)
        Me.lblOrgName.Name = "lblOrgName"
        Me.lblOrgName.Size = New System.Drawing.Size(139, 23)
        Me.lblOrgName.TabIndex = 2
        Me.lblOrgName.Text = "Organization Name"
        '
        'txtOrgName
        '
        Me.txtOrgName.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.txtOrgName.Location = New System.Drawing.Point(25, 165)
        Me.txtOrgName.Name = "txtOrgName"
        Me.txtOrgName.Size = New System.Drawing.Size(590, 27)
        Me.txtOrgName.TabIndex = 3
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.White
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.btnSave)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 743)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Padding = New System.Windows.Forms.Padding(30, 10, 30, 10)
        Me.pnlButtons.Size = New System.Drawing.Size(1394, 60)
        Me.pnlButtons.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(1030, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 38)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save Settings"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(1180, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 38)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Poppins SemiBold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(1270, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(92, 38)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'SASystemConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "SASystemConfiguration"
        Me.Size = New System.Drawing.Size(1394, 803)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.grpDatabaseSettings.ResumeLayout(False)
        Me.grpDatabaseSettings.PerformLayout()
        Me.grpSystemSettings.ResumeLayout(False)
        Me.grpSystemSettings.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents grpDatabaseSettings As GroupBox
    Friend WithEvents lblDbHost As Label
    Friend WithEvents txtDbHost As TextBox
    Friend WithEvents lblDbPort As Label
    Friend WithEvents txtDbPort As TextBox
    Friend WithEvents lblDbName As Label
    Friend WithEvents txtDbName As TextBox
    Friend WithEvents lblDbUser As Label
    Friend WithEvents txtDbUser As TextBox
    Friend WithEvents lblDbPassword As Label
    Friend WithEvents txtDbPassword As TextBox
    Friend WithEvents btnTestConnection As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents lblConnectionStatus As Label
    Friend WithEvents grpSystemSettings As GroupBox
    Friend WithEvents lblSystemName As Label
    Friend WithEvents txtSystemName As TextBox
    Friend WithEvents lblOrgName As Label
    Friend WithEvents txtOrgName As TextBox
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnCancel As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnRefresh As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
