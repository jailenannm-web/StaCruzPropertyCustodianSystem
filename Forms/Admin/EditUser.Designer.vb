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
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.uc_um_edituser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.role = New System.Windows.Forms.ComboBox()
        Me.lblrole = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.username = New System.Windows.Forms.TextBox()
        Me.passwordEncrypted = New System.Windows.Forms.TextBox()
        Me.barangay = New System.Windows.Forms.ComboBox()
        Me.municipal = New System.Windows.Forms.ComboBox()
        Me.province = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxID = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxAddress = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxEmail = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.suffixAdmin = New System.Windows.Forms.ComboBox()
        Me.positionAdmin = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.employeeId = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.contactNumber = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxdepartment = New System.Windows.Forms.Label()
        Me.um_useredit_txtboxposition = New System.Windows.Forms.Label()
        Me.departmentId = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.middleName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.userID = New System.Windows.Forms.TextBox()
        Me.um_edituser_lastname = New System.Windows.Forms.Label()
        Me.lastName = New System.Windows.Forms.TextBox()
        Me.um_edituser_fullname = New System.Windows.Forms.Label()
        Me.firstName = New System.Windows.Forms.TextBox()
        Me.um_edituser_save = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.um_edituser_backbtn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1.SuspendLayout()
        Me.uc_um_edituser.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(51, 69)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(174, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 39
        Me.admin_label_DepartmentManagement.Text = "Edit User"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(49, 130)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1305, 72)
        Me.RoundedPanel1.TabIndex = 40
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(18, 24)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(317, 26)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required department information."
        '
        'uc_um_edituser
        '
        Me.uc_um_edituser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_edituser.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.uc_um_edituser.Controls.Add(Me.role)
        Me.uc_um_edituser.Controls.Add(Me.lblrole)
        Me.uc_um_edituser.Controls.Add(Me.Label1)
        Me.uc_um_edituser.Controls.Add(Me.username)
        Me.uc_um_edituser.Controls.Add(Me.passwordEncrypted)
        Me.uc_um_edituser.Controls.Add(Me.barangay)
        Me.uc_um_edituser.Controls.Add(Me.municipal)
        Me.uc_um_edituser.Controls.Add(Me.province)
        Me.uc_um_edituser.Controls.Add(Me.Label9)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxID)
        Me.uc_um_edituser.Controls.Add(Me.Label6)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxAddress)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxEmail)
        Me.uc_um_edituser.Controls.Add(Me.email)
        Me.uc_um_edituser.Controls.Add(Me.suffixAdmin)
        Me.uc_um_edituser.Controls.Add(Me.positionAdmin)
        Me.uc_um_edituser.Controls.Add(Me.Label8)
        Me.uc_um_edituser.Controls.Add(Me.employeeId)
        Me.uc_um_edituser.Controls.Add(Me.Label7)
        Me.uc_um_edituser.Controls.Add(Me.Label2)
        Me.uc_um_edituser.Controls.Add(Me.contactNumber)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxdepartment)
        Me.uc_um_edituser.Controls.Add(Me.um_useredit_txtboxposition)
        Me.uc_um_edituser.Controls.Add(Me.departmentId)
        Me.uc_um_edituser.Controls.Add(Me.Label5)
        Me.uc_um_edituser.Controls.Add(Me.middleName)
        Me.uc_um_edituser.Controls.Add(Me.Label3)
        Me.uc_um_edituser.Controls.Add(Me.userID)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_lastname)
        Me.uc_um_edituser.Controls.Add(Me.lastName)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_fullname)
        Me.uc_um_edituser.Controls.Add(Me.firstName)
        Me.uc_um_edituser.CornerRadius = 5
        Me.uc_um_edituser.Location = New System.Drawing.Point(49, 211)
        Me.uc_um_edituser.Name = "uc_um_edituser"
        Me.uc_um_edituser.Size = New System.Drawing.Size(1305, 609)
        Me.uc_um_edituser.TabIndex = 0
        '
        'role
        '
        Me.role.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.role.FormattingEnabled = True
        Me.role.Items.AddRange(New Object() {"SuperAdmin", "Admin", "Custodian", "Staff"})
        Me.role.Location = New System.Drawing.Point(846, 228)
        Me.role.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.role.Name = "role"
        Me.role.Size = New System.Drawing.Size(359, 24)
        Me.role.TabIndex = 96
        '
        'lblrole
        '
        Me.lblrole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblrole.AutoSize = True
        Me.lblrole.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblrole.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblrole.Location = New System.Drawing.Point(697, 229)
        Me.lblrole.Name = "lblrole"
        Me.lblrole.Size = New System.Drawing.Size(39, 18)
        Me.lblrole.TabIndex = 95
        Me.lblrole.Text = "Role"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(697, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 18)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Username"
        '
        'username
        '
        Me.username.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.username.BackColor = System.Drawing.SystemColors.Window
        Me.username.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.username.Location = New System.Drawing.Point(843, 101)
        Me.username.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.username.MaxLength = 100
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(362, 22)
        Me.username.TabIndex = 93
        '
        'passwordEncrypted
        '
        Me.passwordEncrypted.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.passwordEncrypted.BackColor = System.Drawing.SystemColors.Window
        Me.passwordEncrypted.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordEncrypted.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.passwordEncrypted.Location = New System.Drawing.Point(843, 405)
        Me.passwordEncrypted.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.passwordEncrypted.MaxLength = 100
        Me.passwordEncrypted.Name = "passwordEncrypted"
        Me.passwordEncrypted.Size = New System.Drawing.Size(362, 22)
        Me.passwordEncrypted.TabIndex = 92
        '
        'barangay
        '
        Me.barangay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barangay.FormattingEnabled = True
        Me.barangay.Location = New System.Drawing.Point(845, 347)
        Me.barangay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barangay.Name = "barangay"
        Me.barangay.Size = New System.Drawing.Size(360, 24)
        Me.barangay.TabIndex = 91
        '
        'municipal
        '
        Me.municipal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.municipal.FormattingEnabled = True
        Me.municipal.Location = New System.Drawing.Point(843, 281)
        Me.municipal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.municipal.Name = "municipal"
        Me.municipal.Size = New System.Drawing.Size(362, 24)
        Me.municipal.TabIndex = 90
        '
        'province
        '
        Me.province.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.province.FormattingEnabled = True
        Me.province.Location = New System.Drawing.Point(841, 162)
        Me.province.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.province.Name = "province"
        Me.province.Size = New System.Drawing.Size(364, 24)
        Me.province.TabIndex = 89
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(697, 287)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 18)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Municipality/City"
        '
        'um_edituser_txtboxID
        '
        Me.um_edituser_txtboxID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxID.AutoSize = True
        Me.um_edituser_txtboxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxID.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxID.Location = New System.Drawing.Point(699, 409)
        Me.um_edituser_txtboxID.Name = "um_edituser_txtboxID"
        Me.um_edituser_txtboxID.Size = New System.Drawing.Size(75, 18)
        Me.um_edituser_txtboxID.TabIndex = 87
        Me.um_edituser_txtboxID.Text = "Password"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(699, 347)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Barangay"
        '
        'um_edituser_txtboxAddress
        '
        Me.um_edituser_txtboxAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxAddress.AutoSize = True
        Me.um_edituser_txtboxAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxAddress.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxAddress.Location = New System.Drawing.Point(697, 162)
        Me.um_edituser_txtboxAddress.Name = "um_edituser_txtboxAddress"
        Me.um_edituser_txtboxAddress.Size = New System.Drawing.Size(66, 18)
        Me.um_edituser_txtboxAddress.TabIndex = 85
        Me.um_edituser_txtboxAddress.Text = "Province"
        '
        'um_edituser_txtboxEmail
        '
        Me.um_edituser_txtboxEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxEmail.AutoSize = True
        Me.um_edituser_txtboxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxEmail.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxEmail.Location = New System.Drawing.Point(697, 52)
        Me.um_edituser_txtboxEmail.Name = "um_edituser_txtboxEmail"
        Me.um_edituser_txtboxEmail.Size = New System.Drawing.Size(45, 18)
        Me.um_edituser_txtboxEmail.TabIndex = 84
        Me.um_edituser_txtboxEmail.Text = "Email"
        '
        'email
        '
        Me.email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email.BackColor = System.Drawing.SystemColors.Window
        Me.email.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.email.Location = New System.Drawing.Point(843, 52)
        Me.email.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.email.MaxLength = 100
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(362, 22)
        Me.email.TabIndex = 83
        '
        'suffixAdmin
        '
        Me.suffixAdmin.FormattingEnabled = True
        Me.suffixAdmin.Items.AddRange(New Object() {"None", "Jr.", "Sr.", "II", "III", "IV"})
        Me.suffixAdmin.Location = New System.Drawing.Point(213, 277)
        Me.suffixAdmin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.suffixAdmin.Name = "suffixAdmin"
        Me.suffixAdmin.Size = New System.Drawing.Size(324, 24)
        Me.suffixAdmin.TabIndex = 81
        '
        'positionAdmin
        '
        Me.positionAdmin.FormattingEnabled = True
        Me.positionAdmin.Items.AddRange(New Object() {"Teacher", "Staff", "Guard", "Principal", "Head admin", "IT", "Administrator", "Clerk", "Manager", "Supervisor", "Technician"})
        Me.positionAdmin.Location = New System.Drawing.Point(210, 331)
        Me.positionAdmin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.positionAdmin.Name = "positionAdmin"
        Me.positionAdmin.Size = New System.Drawing.Size(324, 24)
        Me.positionAdmin.TabIndex = 80
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(81, 439)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 18)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "Employee ID"
        '
        'employeeId
        '
        Me.employeeId.BackColor = System.Drawing.SystemColors.Window
        Me.employeeId.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.employeeId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.employeeId.Location = New System.Drawing.Point(210, 439)
        Me.employeeId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.employeeId.MaxLength = 100
        Me.employeeId.Name = "employeeId"
        Me.employeeId.Size = New System.Drawing.Size(326, 22)
        Me.employeeId.TabIndex = 78
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(82, 276)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 18)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Suffix"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(81, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 18)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Contact Number"
        '
        'contactNumber
        '
        Me.contactNumber.BackColor = System.Drawing.SystemColors.Window
        Me.contactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contactNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.contactNumber.Location = New System.Drawing.Point(207, 500)
        Me.contactNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.contactNumber.MaxLength = 100
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Size = New System.Drawing.Size(327, 22)
        Me.contactNumber.TabIndex = 75
        '
        'um_edituser_txtboxdepartment
        '
        Me.um_edituser_txtboxdepartment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxdepartment.AutoSize = True
        Me.um_edituser_txtboxdepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxdepartment.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxdepartment.Location = New System.Drawing.Point(81, 384)
        Me.um_edituser_txtboxdepartment.Name = "um_edituser_txtboxdepartment"
        Me.um_edituser_txtboxdepartment.Size = New System.Drawing.Size(103, 18)
        Me.um_edituser_txtboxdepartment.TabIndex = 74
        Me.um_edituser_txtboxdepartment.Text = "Department ID"
        '
        'um_useredit_txtboxposition
        '
        Me.um_useredit_txtboxposition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_useredit_txtboxposition.AutoSize = True
        Me.um_useredit_txtboxposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_useredit_txtboxposition.ForeColor = System.Drawing.Color.Black
        Me.um_useredit_txtboxposition.Location = New System.Drawing.Point(81, 331)
        Me.um_useredit_txtboxposition.Name = "um_useredit_txtboxposition"
        Me.um_useredit_txtboxposition.Size = New System.Drawing.Size(62, 18)
        Me.um_useredit_txtboxposition.TabIndex = 73
        Me.um_useredit_txtboxposition.Text = "Position"
        '
        'departmentId
        '
        Me.departmentId.FormattingEnabled = True
        Me.departmentId.Location = New System.Drawing.Point(213, 378)
        Me.departmentId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Size = New System.Drawing.Size(324, 24)
        Me.departmentId.TabIndex = 82
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(80, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 26)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Middle Name"
        '
        'middleName
        '
        Me.middleName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.middleName.BackColor = System.Drawing.SystemColors.Window
        Me.middleName.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.middleName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.middleName.Location = New System.Drawing.Point(210, 162)
        Me.middleName.MaxLength = 100
        Me.middleName.Name = "middleName"
        Me.middleName.Size = New System.Drawing.Size(327, 27)
        Me.middleName.TabIndex = 55
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(80, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 26)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "User ID"
        '
        'userID
        '
        Me.userID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.userID.BackColor = System.Drawing.SystemColors.Window
        Me.userID.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.userID.Location = New System.Drawing.Point(210, 55)
        Me.userID.MaxLength = 100
        Me.userID.Name = "userID"
        Me.userID.Size = New System.Drawing.Size(324, 27)
        Me.userID.TabIndex = 53
        '
        'um_edituser_lastname
        '
        Me.um_edituser_lastname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_lastname.AutoSize = True
        Me.um_edituser_lastname.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.um_edituser_lastname.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_lastname.Location = New System.Drawing.Point(80, 216)
        Me.um_edituser_lastname.Name = "um_edituser_lastname"
        Me.um_edituser_lastname.Size = New System.Drawing.Size(90, 26)
        Me.um_edituser_lastname.TabIndex = 28
        Me.um_edituser_lastname.Text = "Last Name"
        '
        'lastName
        '
        Me.lastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lastName.BackColor = System.Drawing.SystemColors.Window
        Me.lastName.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lastName.Location = New System.Drawing.Point(210, 216)
        Me.lastName.MaxLength = 100
        Me.lastName.Name = "lastName"
        Me.lastName.Size = New System.Drawing.Size(327, 27)
        Me.lastName.TabIndex = 27
        '
        'um_edituser_fullname
        '
        Me.um_edituser_fullname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_fullname.AutoSize = True
        Me.um_edituser_fullname.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.um_edituser_fullname.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_fullname.Location = New System.Drawing.Point(80, 107)
        Me.um_edituser_fullname.Name = "um_edituser_fullname"
        Me.um_edituser_fullname.Size = New System.Drawing.Size(92, 26)
        Me.um_edituser_fullname.TabIndex = 26
        Me.um_edituser_fullname.Text = "First Name"
        '
        'firstName
        '
        Me.firstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.firstName.BackColor = System.Drawing.SystemColors.Window
        Me.firstName.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.firstName.Location = New System.Drawing.Point(210, 107)
        Me.firstName.MaxLength = 100
        Me.firstName.Name = "firstName"
        Me.firstName.Size = New System.Drawing.Size(327, 27)
        Me.firstName.TabIndex = 25
        '
        'um_edituser_save
        '
        Me.um_edituser_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_save.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.um_edituser_save.CornerRadius = 15
        Me.um_edituser_save.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_save.Location = New System.Drawing.Point(1217, 838)
        Me.um_edituser_save.Name = "um_edituser_save"
        Me.um_edituser_save.Size = New System.Drawing.Size(137, 36)
        Me.um_edituser_save.TabIndex = 54
        Me.um_edituser_save.Text = "Save"
        Me.um_edituser_save.UseVisualStyleBackColor = False
        '
        'um_edituser_backbtn
        '
        Me.um_edituser_backbtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_backbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.um_edituser_backbtn.CornerRadius = 15
        Me.um_edituser_backbtn.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_backbtn.Location = New System.Drawing.Point(1076, 838)
        Me.um_edituser_backbtn.Name = "um_edituser_backbtn"
        Me.um_edituser_backbtn.Size = New System.Drawing.Size(119, 36)
        Me.um_edituser_backbtn.TabIndex = 53
        Me.um_edituser_backbtn.Text = "Back"
        Me.um_edituser_backbtn.UseVisualStyleBackColor = False
        '
        'EditUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Controls.Add(Me.um_edituser_save)
        Me.Controls.Add(Me.um_edituser_backbtn)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.uc_um_edituser)
        Me.Name = "EditUser"
        Me.Size = New System.Drawing.Size(1403, 970)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.uc_um_edituser.ResumeLayout(False)
        Me.uc_um_edituser.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents uc_um_edituser As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents um_edituser_fullname As Label
    Friend WithEvents firstName As TextBox
    Friend WithEvents um_edituser_lastname As Label
    Friend WithEvents lastName As TextBox
    Friend WithEvents um_edituser_save As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents um_edituser_backbtn As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_label_DepartmentManagement As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents instructions As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents middleName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents userID As TextBox
    Friend WithEvents suffixAdmin As ComboBox
    Friend WithEvents positionAdmin As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents employeeId As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents contactNumber As TextBox
    Friend WithEvents um_edituser_txtboxdepartment As Label
    Friend WithEvents um_useredit_txtboxposition As Label
    Friend WithEvents departmentId As ComboBox
    Friend WithEvents role As ComboBox
    Friend WithEvents lblrole As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents username As TextBox
    Friend WithEvents passwordEncrypted As TextBox
    Friend WithEvents barangay As ComboBox
    Friend WithEvents municipal As ComboBox
    Friend WithEvents province As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents um_edituser_txtboxID As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents um_edituser_txtboxAddress As Label
    Friend WithEvents um_edituser_txtboxEmail As Label
    Friend WithEvents email As TextBox
End Class
