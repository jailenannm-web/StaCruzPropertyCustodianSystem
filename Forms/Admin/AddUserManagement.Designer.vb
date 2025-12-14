<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUserManagement
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
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.uc_um_edituser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.role = New System.Windows.Forms.ComboBox()
        Me.lblrole = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.username = New System.Windows.Forms.TextBox()
        Me.suffix = New System.Windows.Forms.ComboBox()
        Me.passwordEncrypted = New System.Windows.Forms.TextBox()
        Me.barangay = New System.Windows.Forms.ComboBox()
        Me.municipal = New System.Windows.Forms.ComboBox()
        Me.province = New System.Windows.Forms.ComboBox()
        Me.position = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.employeeId = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.middleName = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxID = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxAddress = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxEmail = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.contactNumber = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxdepartment = New System.Windows.Forms.Label()
        Me.um_useredit_txtboxposition = New System.Windows.Forms.Label()
        Me.edituser_lastname = New System.Windows.Forms.Label()
        Me.lastName = New System.Windows.Forms.TextBox()
        Me.um_edituser_fullname = New System.Windows.Forms.Label()
        Me.firstName = New System.Windows.Forms.TextBox()
        Me.departmentId = New System.Windows.Forms.ComboBox()
        Me.um_edituser_save = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.um_edituser_backbtn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1.SuspendLayout()
        Me.uc_um_edituser.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(59, 41)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(162, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 61
        Me.admin_label_DepartmentManagement.Text = "Add User"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(56, 102)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1219, 71)
        Me.RoundedPanel1.TabIndex = 62
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(19, 25)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(267, 18)
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
        Me.uc_um_edituser.Controls.Add(Me.suffix)
        Me.uc_um_edituser.Controls.Add(Me.passwordEncrypted)
        Me.uc_um_edituser.Controls.Add(Me.barangay)
        Me.uc_um_edituser.Controls.Add(Me.municipal)
        Me.uc_um_edituser.Controls.Add(Me.province)
        Me.uc_um_edituser.Controls.Add(Me.position)
        Me.uc_um_edituser.Controls.Add(Me.Label9)
        Me.uc_um_edituser.Controls.Add(Me.Label8)
        Me.uc_um_edituser.Controls.Add(Me.employeeId)
        Me.uc_um_edituser.Controls.Add(Me.Label7)
        Me.uc_um_edituser.Controls.Add(Me.Label5)
        Me.uc_um_edituser.Controls.Add(Me.middleName)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxID)
        Me.uc_um_edituser.Controls.Add(Me.Label6)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxAddress)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxEmail)
        Me.uc_um_edituser.Controls.Add(Me.email)
        Me.uc_um_edituser.Controls.Add(Me.Label2)
        Me.uc_um_edituser.Controls.Add(Me.contactNumber)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxdepartment)
        Me.uc_um_edituser.Controls.Add(Me.um_useredit_txtboxposition)
        Me.uc_um_edituser.Controls.Add(Me.edituser_lastname)
        Me.uc_um_edituser.Controls.Add(Me.lastName)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_fullname)
        Me.uc_um_edituser.Controls.Add(Me.firstName)
        Me.uc_um_edituser.Controls.Add(Me.departmentId)
        Me.uc_um_edituser.CornerRadius = 5
        Me.uc_um_edituser.Location = New System.Drawing.Point(56, 183)
        Me.uc_um_edituser.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.uc_um_edituser.Name = "uc_um_edituser"
        Me.uc_um_edituser.Size = New System.Drawing.Size(1219, 560)
        Me.uc_um_edituser.TabIndex = 60
        '
        'role
        '
        Me.role.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.role.FormattingEnabled = True
        Me.role.Items.AddRange(New Object() {"SuperAdmin", "Admin", "Custodian", "Staff"})
        Me.role.Location = New System.Drawing.Point(858, 230)
        Me.role.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.role.Name = "role"
        Me.role.Size = New System.Drawing.Size(244, 24)
        Me.role.TabIndex = 78
        '
        'lblrole
        '
        Me.lblrole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblrole.AutoSize = True
        Me.lblrole.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblrole.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblrole.Location = New System.Drawing.Point(709, 231)
        Me.lblrole.Name = "lblrole"
        Me.lblrole.Size = New System.Drawing.Size(39, 18)
        Me.lblrole.TabIndex = 77
        Me.lblrole.Text = "Role"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(709, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 18)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Username"
        '
        'username
        '
        Me.username.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.username.BackColor = System.Drawing.SystemColors.Window
        Me.username.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.username.Location = New System.Drawing.Point(855, 103)
        Me.username.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.username.MaxLength = 100
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(245, 22)
        Me.username.TabIndex = 75
        '
        'suffix
        '
        Me.suffix.FormattingEnabled = True
        Me.suffix.Location = New System.Drawing.Point(262, 219)
        Me.suffix.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.suffix.Name = "suffix"
        Me.suffix.Size = New System.Drawing.Size(287, 24)
        Me.suffix.TabIndex = 71
        '
        'passwordEncrypted
        '
        Me.passwordEncrypted.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.passwordEncrypted.BackColor = System.Drawing.SystemColors.Window
        Me.passwordEncrypted.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordEncrypted.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.passwordEncrypted.Location = New System.Drawing.Point(855, 407)
        Me.passwordEncrypted.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.passwordEncrypted.MaxLength = 100
        Me.passwordEncrypted.Name = "passwordEncrypted"
        Me.passwordEncrypted.Size = New System.Drawing.Size(247, 22)
        Me.passwordEncrypted.TabIndex = 68
        '
        'barangay
        '
        Me.barangay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barangay.FormattingEnabled = True
        Me.barangay.Location = New System.Drawing.Point(857, 349)
        Me.barangay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barangay.Name = "barangay"
        Me.barangay.Size = New System.Drawing.Size(245, 24)
        Me.barangay.TabIndex = 67
        '
        'municipal
        '
        Me.municipal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.municipal.FormattingEnabled = True
        Me.municipal.Location = New System.Drawing.Point(855, 283)
        Me.municipal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.municipal.Name = "municipal"
        Me.municipal.Size = New System.Drawing.Size(243, 24)
        Me.municipal.TabIndex = 66
        '
        'province
        '
        Me.province.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.province.FormattingEnabled = True
        Me.province.Location = New System.Drawing.Point(853, 164)
        Me.province.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.province.Name = "province"
        Me.province.Size = New System.Drawing.Size(244, 24)
        Me.province.TabIndex = 65
        '
        'position
        '
        Me.position.FormattingEnabled = True
        Me.position.Items.AddRange(New Object() {"Teacher", "Staff", "Guard", "Principal", "Head admin", "IT"})
        Me.position.Location = New System.Drawing.Point(259, 273)
        Me.position.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.position.Name = "position"
        Me.position.Size = New System.Drawing.Size(287, 24)
        Me.position.TabIndex = 63
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(709, 289)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 18)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Municipality/City"
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(130, 381)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 18)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Employee ID"
        '
        'employeeId
        '
        Me.employeeId.BackColor = System.Drawing.SystemColors.Window
        Me.employeeId.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.employeeId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.employeeId.Location = New System.Drawing.Point(259, 381)
        Me.employeeId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.employeeId.MaxLength = 100
        Me.employeeId.Name = "employeeId"
        Me.employeeId.Size = New System.Drawing.Size(289, 22)
        Me.employeeId.TabIndex = 59
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(131, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 18)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Suffix"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(130, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 18)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Middle Name"
        '
        'middleName
        '
        Me.middleName.BackColor = System.Drawing.SystemColors.Window
        Me.middleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.middleName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.middleName.Location = New System.Drawing.Point(259, 113)
        Me.middleName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.middleName.MaxLength = 100
        Me.middleName.Name = "middleName"
        Me.middleName.Size = New System.Drawing.Size(289, 22)
        Me.middleName.TabIndex = 55
        '
        'um_edituser_txtboxID
        '
        Me.um_edituser_txtboxID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxID.AutoSize = True
        Me.um_edituser_txtboxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxID.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxID.Location = New System.Drawing.Point(711, 411)
        Me.um_edituser_txtboxID.Name = "um_edituser_txtboxID"
        Me.um_edituser_txtboxID.Size = New System.Drawing.Size(75, 18)
        Me.um_edituser_txtboxID.TabIndex = 46
        Me.um_edituser_txtboxID.Text = "Password"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(711, 349)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Barangay"
        '
        'um_edituser_txtboxAddress
        '
        Me.um_edituser_txtboxAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxAddress.AutoSize = True
        Me.um_edituser_txtboxAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxAddress.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxAddress.Location = New System.Drawing.Point(709, 164)
        Me.um_edituser_txtboxAddress.Name = "um_edituser_txtboxAddress"
        Me.um_edituser_txtboxAddress.Size = New System.Drawing.Size(66, 18)
        Me.um_edituser_txtboxAddress.TabIndex = 42
        Me.um_edituser_txtboxAddress.Text = "Province"
        '
        'um_edituser_txtboxEmail
        '
        Me.um_edituser_txtboxEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxEmail.AutoSize = True
        Me.um_edituser_txtboxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxEmail.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxEmail.Location = New System.Drawing.Point(709, 54)
        Me.um_edituser_txtboxEmail.Name = "um_edituser_txtboxEmail"
        Me.um_edituser_txtboxEmail.Size = New System.Drawing.Size(45, 18)
        Me.um_edituser_txtboxEmail.TabIndex = 36
        Me.um_edituser_txtboxEmail.Text = "Email"
        '
        'email
        '
        Me.email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email.BackColor = System.Drawing.SystemColors.Window
        Me.email.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.email.Location = New System.Drawing.Point(855, 54)
        Me.email.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.email.MaxLength = 100
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(245, 22)
        Me.email.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(130, 432)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 18)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Contact Number"
        '
        'contactNumber
        '
        Me.contactNumber.BackColor = System.Drawing.SystemColors.Window
        Me.contactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contactNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.contactNumber.Location = New System.Drawing.Point(259, 432)
        Me.contactNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.contactNumber.MaxLength = 100
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Size = New System.Drawing.Size(290, 22)
        Me.contactNumber.TabIndex = 33
        '
        'um_edituser_txtboxdepartment
        '
        Me.um_edituser_txtboxdepartment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxdepartment.AutoSize = True
        Me.um_edituser_txtboxdepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxdepartment.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxdepartment.Location = New System.Drawing.Point(130, 326)
        Me.um_edituser_txtboxdepartment.Name = "um_edituser_txtboxdepartment"
        Me.um_edituser_txtboxdepartment.Size = New System.Drawing.Size(103, 18)
        Me.um_edituser_txtboxdepartment.TabIndex = 32
        Me.um_edituser_txtboxdepartment.Text = "Department ID"
        '
        'um_useredit_txtboxposition
        '
        Me.um_useredit_txtboxposition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_useredit_txtboxposition.AutoSize = True
        Me.um_useredit_txtboxposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_useredit_txtboxposition.ForeColor = System.Drawing.Color.Black
        Me.um_useredit_txtboxposition.Location = New System.Drawing.Point(130, 273)
        Me.um_useredit_txtboxposition.Name = "um_useredit_txtboxposition"
        Me.um_useredit_txtboxposition.Size = New System.Drawing.Size(62, 18)
        Me.um_useredit_txtboxposition.TabIndex = 30
        Me.um_useredit_txtboxposition.Text = "Position"
        '
        'edituser_lastname
        '
        Me.edituser_lastname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edituser_lastname.AutoSize = True
        Me.edituser_lastname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.edituser_lastname.ForeColor = System.Drawing.Color.Black
        Me.edituser_lastname.Location = New System.Drawing.Point(130, 168)
        Me.edituser_lastname.Name = "edituser_lastname"
        Me.edituser_lastname.Size = New System.Drawing.Size(80, 18)
        Me.edituser_lastname.TabIndex = 28
        Me.edituser_lastname.Text = "Last Name"
        '
        'lastName
        '
        Me.lastName.BackColor = System.Drawing.SystemColors.Window
        Me.lastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lastName.Location = New System.Drawing.Point(259, 168)
        Me.lastName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lastName.MaxLength = 100
        Me.lastName.Name = "lastName"
        Me.lastName.Size = New System.Drawing.Size(289, 22)
        Me.lastName.TabIndex = 27
        '
        'um_edituser_fullname
        '
        Me.um_edituser_fullname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_fullname.AutoSize = True
        Me.um_edituser_fullname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_fullname.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_fullname.Location = New System.Drawing.Point(130, 58)
        Me.um_edituser_fullname.Name = "um_edituser_fullname"
        Me.um_edituser_fullname.Size = New System.Drawing.Size(81, 18)
        Me.um_edituser_fullname.TabIndex = 26
        Me.um_edituser_fullname.Text = "First Name"
        '
        'firstName
        '
        Me.firstName.BackColor = System.Drawing.SystemColors.Window
        Me.firstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.firstName.Location = New System.Drawing.Point(259, 58)
        Me.firstName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.firstName.MaxLength = 100
        Me.firstName.Name = "firstName"
        Me.firstName.Size = New System.Drawing.Size(289, 22)
        Me.firstName.TabIndex = 25
        '
        'departmentId
        '
        Me.departmentId.FormattingEnabled = True
        Me.departmentId.Location = New System.Drawing.Point(262, 320)
        Me.departmentId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Size = New System.Drawing.Size(287, 24)
        Me.departmentId.TabIndex = 72
        '
        'um_edituser_save
        '
        Me.um_edituser_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_save.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.um_edituser_save.CornerRadius = 15
        Me.um_edituser_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_save.Location = New System.Drawing.Point(1017, 769)
        Me.um_edituser_save.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.um_edituser_save.Name = "um_edituser_save"
        Me.um_edituser_save.Size = New System.Drawing.Size(137, 36)
        Me.um_edituser_save.TabIndex = 59
        Me.um_edituser_save.Text = "Save"
        Me.um_edituser_save.UseVisualStyleBackColor = False
        '
        'um_edituser_backbtn
        '
        Me.um_edituser_backbtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_backbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.um_edituser_backbtn.CornerRadius = 15
        Me.um_edituser_backbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_backbtn.Location = New System.Drawing.Point(876, 769)
        Me.um_edituser_backbtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.um_edituser_backbtn.Name = "um_edituser_backbtn"
        Me.um_edituser_backbtn.Size = New System.Drawing.Size(119, 36)
        Me.um_edituser_backbtn.TabIndex = 58
        Me.um_edituser_backbtn.Text = "Back"
        Me.um_edituser_backbtn.UseVisualStyleBackColor = False
        '
        'AddUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.uc_um_edituser)
        Me.Controls.Add(Me.um_edituser_save)
        Me.Controls.Add(Me.um_edituser_backbtn)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AddUserManagement"
        Me.Size = New System.Drawing.Size(1345, 852)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.uc_um_edituser.ResumeLayout(False)
        Me.uc_um_edituser.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents um_edituser_save As Resources.Controls.RoundedButton
    Friend WithEvents um_edituser_backbtn As Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents uc_um_edituser As Resources.Controls.RoundedPanel
    Friend WithEvents suffix As System.Windows.Forms.ComboBox
    Friend WithEvents passwordEncrypted As System.Windows.Forms.TextBox
    Friend WithEvents barangay As System.Windows.Forms.ComboBox
    Friend WithEvents municipal As System.Windows.Forms.ComboBox
    Friend WithEvents province As System.Windows.Forms.ComboBox
    Friend WithEvents position As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents employeeId As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents middleName As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxID As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxAddress As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxEmail As System.Windows.Forms.Label
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents contactNumber As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxdepartment As System.Windows.Forms.Label
    Friend WithEvents um_useredit_txtboxposition As System.Windows.Forms.Label
    Friend WithEvents edituser_lastname As System.Windows.Forms.Label
    Friend WithEvents lastName As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_fullname As System.Windows.Forms.Label
    Friend WithEvents firstName As System.Windows.Forms.TextBox
    Friend WithEvents departmentId As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents username As System.Windows.Forms.TextBox
    Friend WithEvents role As System.Windows.Forms.ComboBox
    Friend WithEvents lblrole As System.Windows.Forms.Label
End Class
