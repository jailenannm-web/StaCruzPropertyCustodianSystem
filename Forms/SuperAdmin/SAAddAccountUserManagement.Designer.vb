Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAAddAccountUserManagement
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
        Me.lblAddAccount = New System.Windows.Forms.Label()
        Me.txtNoofEmployees = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtHeadofDep = New System.Windows.Forms.TextBox()
        Me.txtDepName = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel7 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnBack = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAddAccount
        '
        Me.lblAddAccount.AutoSize = True
        Me.lblAddAccount.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddAccount.Location = New System.Drawing.Point(591, 99)
        Me.lblAddAccount.Name = "lblAddAccount"
        Me.lblAddAccount.Size = New System.Drawing.Size(179, 32)
        Me.lblAddAccount.TabIndex = 8
        Me.lblAddAccount.Text = "Add Account"
        '
        'txtNoofEmployees
        '
        Me.txtNoofEmployees.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtNoofEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNoofEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoofEmployees.Location = New System.Drawing.Point(669, 497)
        Me.txtNoofEmployees.Name = "txtNoofEmployees"
        Me.txtNoofEmployees.Size = New System.Drawing.Size(264, 19)
        Me.txtNoofEmployees.TabIndex = 75
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(669, 437)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(264, 19)
        Me.txtLocation.TabIndex = 74
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(669, 377)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(264, 19)
        Me.txtEmail.TabIndex = 73
        '
        'txtContact
        '
        Me.txtContact.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(669, 316)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(264, 19)
        Me.txtContact.TabIndex = 72
        '
        'txtHeadofDep
        '
        Me.txtHeadofDep.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtHeadofDep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHeadofDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeadofDep.Location = New System.Drawing.Point(669, 257)
        Me.txtHeadofDep.Name = "txtHeadofDep"
        Me.txtHeadofDep.Size = New System.Drawing.Size(264, 19)
        Me.txtHeadofDep.TabIndex = 71
        '
        'txtDepName
        '
        Me.txtDepName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtDepName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDepName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepName.Location = New System.Drawing.Point(669, 197)
        Me.txtDepName.Name = "txtDepName"
        Me.txtDepName.Size = New System.Drawing.Size(264, 19)
        Me.txtDepName.TabIndex = 70
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStatus.Location = New System.Drawing.Point(446, 495)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(65, 23)
        Me.lblStatus.TabIndex = 68
        Me.lblStatus.Text = "Status"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAddress.Location = New System.Drawing.Point(446, 435)
        Me.lblAddress.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(81, 23)
        Me.lblAddress.TabIndex = 67
        Me.lblAddress.Text = "Address"
        '
        'lblContactNumber
        '
        Me.lblContactNumber.AutoSize = True
        Me.lblContactNumber.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblContactNumber.Location = New System.Drawing.Point(446, 315)
        Me.lblContactNumber.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Size = New System.Drawing.Size(158, 23)
        Me.lblContactNumber.TabIndex = 66
        Me.lblContactNumber.Text = "Contact Number"
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPosition.Location = New System.Drawing.Point(446, 255)
        Me.lblPosition.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(85, 23)
        Me.lblPosition.TabIndex = 65
        Me.lblPosition.Text = "Position"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblFullName.Location = New System.Drawing.Point(446, 195)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(101, 23)
        Me.lblFullName.TabIndex = 64
        Me.lblFullName.Text = "Full Name"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEmail.Location = New System.Drawing.Point(446, 375)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(59, 23)
        Me.lblEmail.TabIndex = 77
        Me.lblEmail.Text = "Email"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.RoundedPanel2)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(658, 189)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel1.TabIndex = 78
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(8, 8)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel2.TabIndex = 79
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(658, 248)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel3.TabIndex = 79
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(658, 308)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel4.TabIndex = 80
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel5.CornerRadius = 20
        Me.RoundedPanel5.Location = New System.Drawing.Point(658, 368)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel5.TabIndex = 81
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel6.CornerRadius = 20
        Me.RoundedPanel6.Location = New System.Drawing.Point(658, 435)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel6.TabIndex = 79
        '
        'RoundedPanel7
        '
        Me.RoundedPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel7.CornerRadius = 20
        Me.RoundedPanel7.Location = New System.Drawing.Point(658, 497)
        Me.RoundedPanel7.Name = "RoundedPanel7"
        Me.RoundedPanel7.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel7.TabIndex = 82
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(992, 635)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSave.Size = New System.Drawing.Size(93, 29)
        Me.btnSave.TabIndex = 83
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBack.CornerRadius = 15
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(291, 635)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBack.Size = New System.Drawing.Size(93, 29)
        Me.btnBack.TabIndex = 84
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'SAAddAccountUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1386, 788)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtNoofEmployees)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.txtHeadofDep)
        Me.Controls.Add(Me.txtDepName)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblContactNumber)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblAddAccount)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.RoundedPanel4)
        Me.Controls.Add(Me.RoundedPanel5)
        Me.Controls.Add(Me.RoundedPanel6)
        Me.Controls.Add(Me.RoundedPanel7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SAAddAccountUserManagement"
        Me.Text = "SAAddAccountUserManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RoundedPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblAddAccount As Label
    Friend WithEvents txtNoofEmployees As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtHeadofDep As TextBox
    Friend WithEvents txtDepName As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel5 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel6 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel7 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnBack As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
