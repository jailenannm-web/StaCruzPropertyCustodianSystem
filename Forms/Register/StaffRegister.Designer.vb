Imports System.Windows.Forms
Imports System.Drawing
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StaffRegister
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.txb_ConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txb_Password = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txb_Address = New System.Windows.Forms.TextBox()
        Me.txb_Email = New System.Windows.Forms.TextBox()
        Me.txb_ContactNumber = New System.Windows.Forms.TextBox()
        Me.txb_Position = New System.Windows.Forms.TextBox()
        Me.txb_FullName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_Login)
        Me.Panel1.Controls.Add(Me.btn_Cancel)
        Me.Panel1.Controls.Add(Me.txb_ConfirmPassword)
        Me.Panel1.Controls.Add(Me.txb_Password)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txb_Address)
        Me.Panel1.Controls.Add(Me.txb_Email)
        Me.Panel1.Controls.Add(Me.txb_ContactNumber)
        Me.Panel1.Controls.Add(Me.txb_Position)
        Me.Panel1.Controls.Add(Me.txb_FullName)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(384, 60)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1393, 1007)
        Me.Panel1.TabIndex = 0
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(968, 884)
        Me.btn_Login.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(203, 60)
        Me.btn_Login.TabIndex = 16
        Me.btn_Login.Text = "Login"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(667, 884)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(205, 60)
        Me.btn_Cancel.TabIndex = 15
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'txb_ConfirmPassword
        '
        Me.txb_ConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.txb_ConfirmPassword.Location = New System.Drawing.Point(667, 785)
        Me.txb_ConfirmPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ConfirmPassword.Multiline = True
        Me.txb_ConfirmPassword.Name = "txb_ConfirmPassword"
        Me.txb_ConfirmPassword.Size = New System.Drawing.Size(504, 46)
        Me.txb_ConfirmPassword.TabIndex = 14
        '
        'txb_Password
        '
        Me.txb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.txb_Password.Location = New System.Drawing.Point(667, 674)
        Me.txb_Password.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Password.Multiline = True
        Me.txb_Password.Name = "txb_Password"
        Me.txb_Password.Size = New System.Drawing.Size(504, 46)
        Me.txb_Password.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(329, 464)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(260, 46)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Email"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(309, 245)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(260, 46)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Position"
        '
        'txb_Address
        '
        Me.txb_Address.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.txb_Address.Location = New System.Drawing.Point(667, 575)
        Me.txb_Address.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Address.Multiline = True
        Me.txb_Address.Name = "txb_Address"
        Me.txb_Address.Size = New System.Drawing.Size(504, 46)
        Me.txb_Address.TabIndex = 10
        '
        'txb_Email
        '
        Me.txb_Email.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.txb_Email.Location = New System.Drawing.Point(667, 464)
        Me.txb_Email.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Email.Multiline = True
        Me.txb_Email.Name = "txb_Email"
        Me.txb_Email.Size = New System.Drawing.Size(504, 46)
        Me.txb_Email.TabIndex = 9
        '
        'txb_ContactNumber
        '
        Me.txb_ContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ContactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.txb_ContactNumber.Location = New System.Drawing.Point(667, 352)
        Me.txb_ContactNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ContactNumber.Multiline = True
        Me.txb_ContactNumber.Name = "txb_ContactNumber"
        Me.txb_ContactNumber.Size = New System.Drawing.Size(504, 46)
        Me.txb_ContactNumber.TabIndex = 8
        '
        'txb_Position
        '
        Me.txb_Position.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.txb_Position.Location = New System.Drawing.Point(667, 245)
        Me.txb_Position.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Position.Multiline = True
        Me.txb_Position.Name = "txb_Position"
        Me.txb_Position.Size = New System.Drawing.Size(504, 46)
        Me.txb_Position.TabIndex = 7
        '
        'txb_FullName
        '
        Me.txb_FullName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_FullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.txb_FullName.Location = New System.Drawing.Point(667, 153)
        Me.txb_FullName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_FullName.Multiline = True
        Me.txb_FullName.Name = "txb_FullName"
        Me.txb_FullName.Size = New System.Drawing.Size(504, 46)
        Me.txb_FullName.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(195, 785)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(464, 46)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Confirm Password"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(297, 674)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(260, 46)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Password"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(221, 352)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(408, 46)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Contact number"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(309, 575)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 46)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Address"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(281, 153)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 46)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Full name"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(443, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(584, 126)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REGISTER"
        '
        'StaffRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.BG1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 1175)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "StaffRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txb_FullName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txb_Position As TextBox
    Friend WithEvents txb_Address As TextBox
    Friend WithEvents txb_Email As TextBox
    Friend WithEvents txb_ContactNumber As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txb_ConfirmPassword As TextBox
    Friend WithEvents txb_Password As TextBox
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_Login As Button
    Friend WithEvents btn_Register As Button
End Class
