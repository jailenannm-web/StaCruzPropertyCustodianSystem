Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_UserManagement
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.admin_um_panel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.uc_um_edit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.uc_um_update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.uc_um_UserEmail = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.uc_um_contact = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.uc_um_userposition = New System.Windows.Forms.TextBox()
        Me.uc_um_position = New System.Windows.Forms.Label()
        Me.uc_um_fullname = New System.Windows.Forms.Label()
        Me.uc_um_userFullName = New System.Windows.Forms.TextBox()
        Me.uc_um_adminprofile = New System.Windows.Forms.Label()
        Me.admin_label_Dashboard = New System.Windows.Forms.Label()
        Me.admin_um_panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_um_panel1
        '
        Me.admin_um_panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_um_panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.admin_um_panel1.Controls.Add(Me.uc_um_edit)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_update)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_UserEmail)
        Me.admin_um_panel1.Controls.Add(Me.Label2)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_contact)
        Me.admin_um_panel1.Controls.Add(Me.Label1)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_userposition)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_position)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_fullname)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_userFullName)
        Me.admin_um_panel1.Controls.Add(Me.uc_um_adminprofile)
        Me.admin_um_panel1.CornerRadius = 20
        Me.admin_um_panel1.Location = New System.Drawing.Point(53, 105)
        Me.admin_um_panel1.Name = "admin_um_panel1"
        Me.admin_um_panel1.Size = New System.Drawing.Size(984, 910)
        Me.admin_um_panel1.TabIndex = 0
        '
        'uc_um_edit
        '
        Me.uc_um_edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_edit.CornerRadius = 15
        Me.uc_um_edit.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_edit.Location = New System.Drawing.Point(583, 555)
        Me.uc_um_edit.Name = "uc_um_edit"
        Me.uc_um_edit.Size = New System.Drawing.Size(151, 40)
        Me.uc_um_edit.TabIndex = 32
        Me.uc_um_edit.Text = "Edit"
        Me.uc_um_edit.UseVisualStyleBackColor = True
        '
        'uc_um_update
        '
        Me.uc_um_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_update.CornerRadius = 15
        Me.uc_um_update.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_update.Location = New System.Drawing.Point(763, 555)
        Me.uc_um_update.Name = "uc_um_update"
        Me.uc_um_update.Size = New System.Drawing.Size(151, 40)
        Me.uc_um_update.TabIndex = 31
        Me.uc_um_update.Text = "Update"
        Me.uc_um_update.UseVisualStyleBackColor = True
        '
        'uc_um_UserEmail
        '
        Me.uc_um_UserEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_UserEmail.BackColor = System.Drawing.SystemColors.Window
        Me.uc_um_UserEmail.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_UserEmail.ForeColor = System.Drawing.Color.Black
        Me.uc_um_UserEmail.Location = New System.Drawing.Point(410, 367)
        Me.uc_um_UserEmail.MaxLength = 30
        Me.uc_um_UserEmail.Name = "uc_um_UserEmail"
        Me.uc_um_UserEmail.Size = New System.Drawing.Size(258, 27)
        Me.uc_um_UserEmail.TabIndex = 30
        Me.uc_um_UserEmail.Text = "Enter Email Address"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(317, 367)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 30)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Email"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'uc_um_contact
        '
        Me.uc_um_contact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_contact.BackColor = System.Drawing.SystemColors.Window
        Me.uc_um_contact.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_contact.ForeColor = System.Drawing.Color.Black
        Me.uc_um_contact.Location = New System.Drawing.Point(410, 303)
        Me.uc_um_contact.MaxLength = 11
        Me.uc_um_contact.Name = "uc_um_contact"
        Me.uc_um_contact.Size = New System.Drawing.Size(258, 27)
        Me.uc_um_contact.TabIndex = 28
        Me.uc_um_contact.Text = "Enter Contact Number"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(221, 303)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 30)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Contact Number"
        '
        'uc_um_userposition
        '
        Me.uc_um_userposition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_userposition.BackColor = System.Drawing.SystemColors.Window
        Me.uc_um_userposition.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_userposition.ForeColor = System.Drawing.Color.Black
        Me.uc_um_userposition.Location = New System.Drawing.Point(410, 234)
        Me.uc_um_userposition.MaxLength = 50
        Me.uc_um_userposition.Name = "uc_um_userposition"
        Me.uc_um_userposition.Size = New System.Drawing.Size(258, 27)
        Me.uc_um_userposition.TabIndex = 26
        Me.uc_um_userposition.Text = "Enter Position"
        '
        'uc_um_position
        '
        Me.uc_um_position.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_position.AutoSize = True
        Me.uc_um_position.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_position.ForeColor = System.Drawing.Color.Black
        Me.uc_um_position.Location = New System.Drawing.Point(298, 231)
        Me.uc_um_position.Name = "uc_um_position"
        Me.uc_um_position.Size = New System.Drawing.Size(82, 30)
        Me.uc_um_position.TabIndex = 25
        Me.uc_um_position.Text = "Position"
        '
        'uc_um_fullname
        '
        Me.uc_um_fullname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_fullname.AutoSize = True
        Me.uc_um_fullname.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_fullname.ForeColor = System.Drawing.Color.Black
        Me.uc_um_fullname.Location = New System.Drawing.Point(280, 168)
        Me.uc_um_fullname.Name = "uc_um_fullname"
        Me.uc_um_fullname.Size = New System.Drawing.Size(99, 30)
        Me.uc_um_fullname.TabIndex = 24
        Me.uc_um_fullname.Text = "Full Name"
        '
        'uc_um_userFullName
        '
        Me.uc_um_userFullName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_userFullName.BackColor = System.Drawing.SystemColors.Window
        Me.uc_um_userFullName.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_userFullName.ForeColor = System.Drawing.Color.Black
        Me.uc_um_userFullName.Location = New System.Drawing.Point(410, 171)
        Me.uc_um_userFullName.MaxLength = 100
        Me.uc_um_userFullName.Name = "uc_um_userFullName"
        Me.uc_um_userFullName.Size = New System.Drawing.Size(258, 27)
        Me.uc_um_userFullName.TabIndex = 23
        Me.uc_um_userFullName.Text = "Enter Full Name"
        '
        'uc_um_adminprofile
        '
        Me.uc_um_adminprofile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_adminprofile.AutoSize = True
        Me.uc_um_adminprofile.Font = New System.Drawing.Font("Poppins", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_adminprofile.ForeColor = System.Drawing.Color.Black
        Me.uc_um_adminprofile.Location = New System.Drawing.Point(401, 62)
        Me.uc_um_adminprofile.Name = "uc_um_adminprofile"
        Me.uc_um_adminprofile.Size = New System.Drawing.Size(215, 50)
        Me.uc_um_adminprofile.TabIndex = 22
        Me.uc_um_adminprofile.Text = "Admin Profile"
        '
        'admin_label_Dashboard
        '
        Me.admin_label_Dashboard.AutoSize = True
        Me.admin_label_Dashboard.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_Dashboard.Location = New System.Drawing.Point(43, 31)
        Me.admin_label_Dashboard.Name = "admin_label_Dashboard"
        Me.admin_label_Dashboard.Size = New System.Drawing.Size(342, 58)
        Me.admin_label_Dashboard.TabIndex = 21
        Me.admin_label_Dashboard.Text = "User Management"
        '
        'UC_UserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.admin_label_Dashboard)
        Me.Controls.Add(Me.admin_um_panel1)
        Me.Name = "UC_UserManagement"
        Me.Size = New System.Drawing.Size(1084, 1055)
        Me.admin_um_panel1.ResumeLayout(False)
        Me.admin_um_panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_um_panel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents admin_label_Dashboard As Label
    Friend WithEvents uc_um_fullname As Label
    Friend WithEvents uc_um_userFullName As TextBox
    Friend WithEvents uc_um_adminprofile As Label
    Friend WithEvents uc_um_userposition As TextBox
    Friend WithEvents uc_um_position As Label
    Friend WithEvents uc_um_contact As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents uc_um_UserEmail As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents uc_um_update As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents uc_um_edit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
