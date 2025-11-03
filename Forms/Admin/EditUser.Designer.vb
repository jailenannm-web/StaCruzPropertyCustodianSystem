Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports StaCruzPropertyCustodianSystem.Resources.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditUser
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
        Me.uc_um_edituser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.uc_um_adminprofile = New System.Windows.Forms.Label()
        Me.um_edituser_fullname = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxfirst = New System.Windows.Forms.TextBox()
        Me.um_edituser_lastname = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxfull = New System.Windows.Forms.TextBox()
        Me.um_useredit_txtboxposition = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxPosition = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxEmail = New System.Windows.Forms.Label()
        Me.um_edituser_email = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxcontact = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxdepartment = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxUsername = New System.Windows.Forms.Label()
        Me.um_edituser_Username = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxCreated = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtStatus = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxLogin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxStatus = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxID = New System.Windows.Forms.Label()
        Me.um_edituser_EmployeeID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxAssignment = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxAddress = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxUserAddress = New System.Windows.Forms.TextBox()
        Me.um_edituser_Password = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxPassword = New System.Windows.Forms.TextBox()
        Me.um_edituser_backbtn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.um_edituser_save = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.uc_um_edituser.SuspendLayout()
        Me.SuspendLayout()
        '
        'uc_um_edituser
        '
        Me.uc_um_edituser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_edituser.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.uc_um_edituser.CornerRadius = 20
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_save)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_backbtn)
        Me.uc_um_edituser.Controls.Add(Me.Label1)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxCreated)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtStatus)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxLogin)
        Me.uc_um_edituser.Controls.Add(Me.Label4)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxStatus)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxID)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_EmployeeID)
        Me.uc_um_edituser.Controls.Add(Me.Label6)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxAssignment)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxAddress)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxUserAddress)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_Password)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxPassword)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxUsername)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_Username)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxEmail)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_email)
        Me.uc_um_edituser.Controls.Add(Me.Label2)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxcontact)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxdepartment)
        Me.uc_um_edituser.Controls.Add(Me.TextBox4)
        Me.uc_um_edituser.Controls.Add(Me.um_useredit_txtboxposition)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxPosition)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_lastname)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxfull)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_fullname)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxfirst)
        Me.uc_um_edituser.Controls.Add(Me.uc_um_adminprofile)
        Me.uc_um_edituser.Location = New System.Drawing.Point(38, 41)
        Me.uc_um_edituser.Name = "uc_um_edituser"
        Me.uc_um_edituser.Size = New System.Drawing.Size(1216, 737)
        Me.uc_um_edituser.TabIndex = 0
        '
        'uc_um_adminprofile
        '
        Me.uc_um_adminprofile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_adminprofile.AutoSize = True
        Me.uc_um_adminprofile.Font = New System.Drawing.Font("Poppins", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_adminprofile.ForeColor = System.Drawing.Color.White
        Me.uc_um_adminprofile.Location = New System.Drawing.Point(501, 39)
        Me.uc_um_adminprofile.Name = "uc_um_adminprofile"
        Me.uc_um_adminprofile.Size = New System.Drawing.Size(215, 50)
        Me.uc_um_adminprofile.TabIndex = 23
        Me.uc_um_adminprofile.Text = "Admin Profile"
        '
        'um_edituser_fullname
        '
        Me.um_edituser_fullname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_fullname.AutoSize = True
        Me.um_edituser_fullname.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_fullname.ForeColor = System.Drawing.Color.White
        Me.um_edituser_fullname.Location = New System.Drawing.Point(172, 130)
        Me.um_edituser_fullname.Name = "um_edituser_fullname"
        Me.um_edituser_fullname.Size = New System.Drawing.Size(106, 30)
        Me.um_edituser_fullname.TabIndex = 26
        Me.um_edituser_fullname.Text = "First Name"
        '
        'um_edituser_txtboxfirst
        '
        Me.um_edituser_txtboxfirst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxfirst.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxfirst.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxfirst.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxfirst.Location = New System.Drawing.Point(302, 130)
        Me.um_edituser_txtboxfirst.MaxLength = 100
        Me.um_edituser_txtboxfirst.Name = "um_edituser_txtboxfirst"
        Me.um_edituser_txtboxfirst.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxfirst.TabIndex = 25
        Me.um_edituser_txtboxfirst.Text = "Enter Full Name"
        '
        'um_edituser_lastname
        '
        Me.um_edituser_lastname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_lastname.AutoSize = True
        Me.um_edituser_lastname.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_lastname.ForeColor = System.Drawing.Color.White
        Me.um_edituser_lastname.Location = New System.Drawing.Point(172, 186)
        Me.um_edituser_lastname.Name = "um_edituser_lastname"
        Me.um_edituser_lastname.Size = New System.Drawing.Size(105, 30)
        Me.um_edituser_lastname.TabIndex = 28
        Me.um_edituser_lastname.Text = "Last Name"
        '
        'um_edituser_txtboxfull
        '
        Me.um_edituser_txtboxfull.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxfull.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxfull.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxfull.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxfull.Location = New System.Drawing.Point(302, 186)
        Me.um_edituser_txtboxfull.MaxLength = 100
        Me.um_edituser_txtboxfull.Name = "um_edituser_txtboxfull"
        Me.um_edituser_txtboxfull.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxfull.TabIndex = 27
        Me.um_edituser_txtboxfull.Text = "Enter Last Name"
        '
        'um_useredit_txtboxposition
        '
        Me.um_useredit_txtboxposition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_useredit_txtboxposition.AutoSize = True
        Me.um_useredit_txtboxposition.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_useredit_txtboxposition.ForeColor = System.Drawing.Color.White
        Me.um_useredit_txtboxposition.Location = New System.Drawing.Point(172, 240)
        Me.um_useredit_txtboxposition.Name = "um_useredit_txtboxposition"
        Me.um_useredit_txtboxposition.Size = New System.Drawing.Size(82, 30)
        Me.um_useredit_txtboxposition.TabIndex = 30
        Me.um_useredit_txtboxposition.Text = "Position"
        '
        'um_edituser_txtboxPosition
        '
        Me.um_edituser_txtboxPosition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxPosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxPosition.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxPosition.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxPosition.Location = New System.Drawing.Point(302, 240)
        Me.um_edituser_txtboxPosition.MaxLength = 100
        Me.um_edituser_txtboxPosition.Name = "um_edituser_txtboxPosition"
        Me.um_edituser_txtboxPosition.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxPosition.TabIndex = 29
        Me.um_edituser_txtboxPosition.Text = "Enter Position"
        '
        'um_edituser_txtboxEmail
        '
        Me.um_edituser_txtboxEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxEmail.AutoSize = True
        Me.um_edituser_txtboxEmail.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxEmail.ForeColor = System.Drawing.Color.White
        Me.um_edituser_txtboxEmail.Location = New System.Drawing.Point(172, 401)
        Me.um_edituser_txtboxEmail.Name = "um_edituser_txtboxEmail"
        Me.um_edituser_txtboxEmail.Size = New System.Drawing.Size(62, 30)
        Me.um_edituser_txtboxEmail.TabIndex = 36
        Me.um_edituser_txtboxEmail.Text = "Email"
        '
        'um_edituser_email
        '
        Me.um_edituser_email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_email.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_email.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_email.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_email.Location = New System.Drawing.Point(302, 401)
        Me.um_edituser_email.MaxLength = 100
        Me.um_edituser_email.Name = "um_edituser_email"
        Me.um_edituser_email.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_email.TabIndex = 35
        Me.um_edituser_email.Text = "Enter Email "
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(172, 347)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 30)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Contact Number"
        '
        'um_edituser_txtboxcontact
        '
        Me.um_edituser_txtboxcontact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxcontact.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxcontact.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxcontact.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxcontact.Location = New System.Drawing.Point(336, 347)
        Me.um_edituser_txtboxcontact.MaxLength = 100
        Me.um_edituser_txtboxcontact.Name = "um_edituser_txtboxcontact"
        Me.um_edituser_txtboxcontact.Size = New System.Drawing.Size(224, 27)
        Me.um_edituser_txtboxcontact.TabIndex = 33
        Me.um_edituser_txtboxcontact.Text = "Enter Contact Number"
        '
        'um_edituser_txtboxdepartment
        '
        Me.um_edituser_txtboxdepartment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxdepartment.AutoSize = True
        Me.um_edituser_txtboxdepartment.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxdepartment.ForeColor = System.Drawing.Color.White
        Me.um_edituser_txtboxdepartment.Location = New System.Drawing.Point(172, 293)
        Me.um_edituser_txtboxdepartment.Name = "um_edituser_txtboxdepartment"
        Me.um_edituser_txtboxdepartment.Size = New System.Drawing.Size(119, 30)
        Me.um_edituser_txtboxdepartment.TabIndex = 32
        Me.um_edituser_txtboxdepartment.Text = "Department"
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.TextBox4.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox4.Location = New System.Drawing.Point(302, 293)
        Me.TextBox4.MaxLength = 100
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(258, 27)
        Me.TextBox4.TabIndex = 31
        Me.TextBox4.Text = "Enter Department"
        '
        'um_edituser_txtboxUsername
        '
        Me.um_edituser_txtboxUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxUsername.AutoSize = True
        Me.um_edituser_txtboxUsername.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxUsername.ForeColor = System.Drawing.Color.White
        Me.um_edituser_txtboxUsername.Location = New System.Drawing.Point(172, 453)
        Me.um_edituser_txtboxUsername.Name = "um_edituser_txtboxUsername"
        Me.um_edituser_txtboxUsername.Size = New System.Drawing.Size(102, 30)
        Me.um_edituser_txtboxUsername.TabIndex = 38
        Me.um_edituser_txtboxUsername.Text = "Username"
        '
        'um_edituser_Username
        '
        Me.um_edituser_Username.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_Username.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_Username.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_Username.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_Username.Location = New System.Drawing.Point(302, 453)
        Me.um_edituser_Username.MaxLength = 100
        Me.um_edituser_Username.Name = "um_edituser_Username"
        Me.um_edituser_Username.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_Username.TabIndex = 37
        Me.um_edituser_Username.Text = "Enter Username"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(671, 450)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 30)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Created at"
        '
        'um_edituser_txtboxCreated
        '
        Me.um_edituser_txtboxCreated.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxCreated.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxCreated.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxCreated.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxCreated.Location = New System.Drawing.Point(801, 450)
        Me.um_edituser_txtboxCreated.MaxLength = 100
        Me.um_edituser_txtboxCreated.Name = "um_edituser_txtboxCreated"
        Me.um_edituser_txtboxCreated.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxCreated.TabIndex = 51
        Me.um_edituser_txtboxCreated.Text = "Created at "
        '
        'um_edituser_txtStatus
        '
        Me.um_edituser_txtStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtStatus.AutoSize = True
        Me.um_edituser_txtStatus.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtStatus.ForeColor = System.Drawing.Color.White
        Me.um_edituser_txtStatus.Location = New System.Drawing.Point(671, 398)
        Me.um_edituser_txtStatus.Name = "um_edituser_txtStatus"
        Me.um_edituser_txtStatus.Size = New System.Drawing.Size(100, 30)
        Me.um_edituser_txtStatus.TabIndex = 50
        Me.um_edituser_txtStatus.Text = "Last Login"
        '
        'um_edituser_txtboxLogin
        '
        Me.um_edituser_txtboxLogin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxLogin.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxLogin.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxLogin.Location = New System.Drawing.Point(801, 398)
        Me.um_edituser_txtboxLogin.MaxLength = 100
        Me.um_edituser_txtboxLogin.Name = "um_edituser_txtboxLogin"
        Me.um_edituser_txtboxLogin.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxLogin.TabIndex = 49
        Me.um_edituser_txtboxLogin.Text = "Last Login"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(671, 344)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 30)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Status"
        '
        'um_edituser_txtboxStatus
        '
        Me.um_edituser_txtboxStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxStatus.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxStatus.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxStatus.Location = New System.Drawing.Point(801, 344)
        Me.um_edituser_txtboxStatus.MaxLength = 100
        Me.um_edituser_txtboxStatus.Name = "um_edituser_txtboxStatus"
        Me.um_edituser_txtboxStatus.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxStatus.TabIndex = 47
        Me.um_edituser_txtboxStatus.Text = "Enter Status"
        '
        'um_edituser_txtboxID
        '
        Me.um_edituser_txtboxID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxID.AutoSize = True
        Me.um_edituser_txtboxID.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxID.ForeColor = System.Drawing.Color.White
        Me.um_edituser_txtboxID.Location = New System.Drawing.Point(671, 290)
        Me.um_edituser_txtboxID.Name = "um_edituser_txtboxID"
        Me.um_edituser_txtboxID.Size = New System.Drawing.Size(167, 30)
        Me.um_edituser_txtboxID.TabIndex = 46
        Me.um_edituser_txtboxID.Text = "Enter Employee ID"
        '
        'um_edituser_EmployeeID
        '
        Me.um_edituser_EmployeeID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_EmployeeID.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_EmployeeID.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_EmployeeID.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_EmployeeID.Location = New System.Drawing.Point(863, 290)
        Me.um_edituser_EmployeeID.MaxLength = 10
        Me.um_edituser_EmployeeID.Name = "um_edituser_EmployeeID"
        Me.um_edituser_EmployeeID.Size = New System.Drawing.Size(196, 27)
        Me.um_edituser_EmployeeID.TabIndex = 45
        Me.um_edituser_EmployeeID.Text = "Enter Employee ID"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(671, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(186, 30)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Enter Date Assigned"
        '
        'um_edituser_txtboxAssignment
        '
        Me.um_edituser_txtboxAssignment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxAssignment.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxAssignment.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxAssignment.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxAssignment.Location = New System.Drawing.Point(863, 237)
        Me.um_edituser_txtboxAssignment.MaxLength = 100
        Me.um_edituser_txtboxAssignment.Name = "um_edituser_txtboxAssignment"
        Me.um_edituser_txtboxAssignment.Size = New System.Drawing.Size(196, 27)
        Me.um_edituser_txtboxAssignment.TabIndex = 43
        Me.um_edituser_txtboxAssignment.Text = "Choose Date"
        '
        'um_edituser_txtboxAddress
        '
        Me.um_edituser_txtboxAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxAddress.AutoSize = True
        Me.um_edituser_txtboxAddress.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxAddress.ForeColor = System.Drawing.Color.White
        Me.um_edituser_txtboxAddress.Location = New System.Drawing.Point(671, 183)
        Me.um_edituser_txtboxAddress.Name = "um_edituser_txtboxAddress"
        Me.um_edituser_txtboxAddress.Size = New System.Drawing.Size(84, 30)
        Me.um_edituser_txtboxAddress.TabIndex = 42
        Me.um_edituser_txtboxAddress.Text = "Address"
        '
        'um_edituser_txtboxUserAddress
        '
        Me.um_edituser_txtboxUserAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxUserAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxUserAddress.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxUserAddress.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxUserAddress.Location = New System.Drawing.Point(801, 183)
        Me.um_edituser_txtboxUserAddress.MaxLength = 100
        Me.um_edituser_txtboxUserAddress.Name = "um_edituser_txtboxUserAddress"
        Me.um_edituser_txtboxUserAddress.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxUserAddress.TabIndex = 41
        Me.um_edituser_txtboxUserAddress.Text = "Enter Address"
        '
        'um_edituser_Password
        '
        Me.um_edituser_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_Password.AutoSize = True
        Me.um_edituser_Password.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_Password.ForeColor = System.Drawing.Color.White
        Me.um_edituser_Password.Location = New System.Drawing.Point(671, 127)
        Me.um_edituser_Password.Name = "um_edituser_Password"
        Me.um_edituser_Password.Size = New System.Drawing.Size(97, 30)
        Me.um_edituser_Password.TabIndex = 40
        Me.um_edituser_Password.Text = "Password"
        '
        'um_edituser_txtboxPassword
        '
        Me.um_edituser_txtboxPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_edituser_txtboxPassword.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_txtboxPassword.ForeColor = System.Drawing.Color.LightGray
        Me.um_edituser_txtboxPassword.Location = New System.Drawing.Point(801, 127)
        Me.um_edituser_txtboxPassword.MaxLength = 100
        Me.um_edituser_txtboxPassword.Name = "um_edituser_txtboxPassword"
        Me.um_edituser_txtboxPassword.Size = New System.Drawing.Size(258, 27)
        Me.um_edituser_txtboxPassword.TabIndex = 39
        Me.um_edituser_txtboxPassword.Text = "Enter Password"
        '
        'um_edituser_backbtn
        '
        Me.um_edituser_backbtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_backbtn.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_backbtn.Location = New System.Drawing.Point(71, 660)
        Me.um_edituser_backbtn.Name = "um_edituser_backbtn"
        Me.um_edituser_backbtn.Size = New System.Drawing.Size(119, 32)
        Me.um_edituser_backbtn.TabIndex = 53
        Me.um_edituser_backbtn.Text = "Back"
        Me.um_edituser_backbtn.UseVisualStyleBackColor = True
        '
        'um_edituser_save
        '
        Me.um_edituser_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_save.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_save.Location = New System.Drawing.Point(1036, 660)
        Me.um_edituser_save.Name = "um_edituser_save"
        Me.um_edituser_save.Size = New System.Drawing.Size(119, 32)
        Me.um_edituser_save.TabIndex = 54
        Me.um_edituser_save.Text = "Save"
        Me.um_edituser_save.UseVisualStyleBackColor = True
        '
        'EditUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.Controls.Add(Me.uc_um_edituser)
        Me.Name = "EditUser"
        Me.Size = New System.Drawing.Size(1303, 827)
        Me.uc_um_edituser.ResumeLayout(False)
        Me.uc_um_edituser.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents uc_um_edituser As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents uc_um_adminprofile As Label
    Friend WithEvents um_edituser_fullname As Label
    Friend WithEvents um_edituser_txtboxfirst As TextBox
    Friend WithEvents um_edituser_lastname As Label
    Friend WithEvents um_edituser_txtboxfull As TextBox
    Friend WithEvents um_useredit_txtboxposition As Label
    Friend WithEvents um_edituser_txtboxPosition As TextBox
    Friend WithEvents um_edituser_txtboxEmail As Label
    Friend WithEvents um_edituser_email As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents um_edituser_txtboxcontact As TextBox
    Friend WithEvents um_edituser_txtboxdepartment As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents um_edituser_txtboxCreated As TextBox
    Friend WithEvents um_edituser_txtStatus As Label
    Friend WithEvents um_edituser_txtboxLogin As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents um_edituser_txtboxStatus As TextBox
    Friend WithEvents um_edituser_txtboxID As Label
    Friend WithEvents um_edituser_EmployeeID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents um_edituser_txtboxAssignment As TextBox
    Friend WithEvents um_edituser_txtboxAddress As Label
    Friend WithEvents um_edituser_txtboxUserAddress As TextBox
    Friend WithEvents um_edituser_Password As Label
    Friend WithEvents um_edituser_txtboxPassword As TextBox
    Friend WithEvents um_edituser_txtboxUsername As Label
    Friend WithEvents um_edituser_Username As TextBox
    Friend WithEvents um_edituser_save As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents um_edituser_backbtn As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
