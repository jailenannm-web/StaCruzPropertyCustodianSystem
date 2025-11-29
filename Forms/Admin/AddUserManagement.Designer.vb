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
        Me.um_edituser_save = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.um_edituser_backbtn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.uc_um_edituser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.suffixAdmin = New System.Windows.Forms.ComboBox()
        Me.dateRegistered = New System.Windows.Forms.DateTimePicker()
        Me.houseNumber = New System.Windows.Forms.TextBox()
        Me.barangay = New System.Windows.Forms.ComboBox()
        Me.municipality = New System.Windows.Forms.ComboBox()
        Me.province = New System.Windows.Forms.ComboBox()
        Me.positionAdmin = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.employeeID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.middleName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.userID = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtStatus = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxID = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxAddress = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxEmail = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.contactNumber = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxdepartment = New System.Windows.Forms.Label()
        Me.departmentID = New System.Windows.Forms.TextBox()
        Me.um_useredit_txtboxposition = New System.Windows.Forms.Label()
        Me.um_edituser_lastname = New System.Windows.Forms.Label()
        Me.lastName = New System.Windows.Forms.TextBox()
        Me.um_edituser_fullname = New System.Windows.Forms.Label()
        Me.firstName = New System.Windows.Forms.TextBox()
        Me.RoundedPanel1.SuspendLayout()
        Me.uc_um_edituser.SuspendLayout()
        Me.SuspendLayout()
        '
        'um_edituser_save
        '
        Me.um_edituser_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_save.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.um_edituser_save.CornerRadius = 15
        Me.um_edituser_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_edituser_save.Location = New System.Drawing.Point(763, 625)
        Me.um_edituser_save.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.um_edituser_save.Name = "um_edituser_save"
        Me.um_edituser_save.Size = New System.Drawing.Size(103, 29)
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
        Me.um_edituser_backbtn.Location = New System.Drawing.Point(657, 625)
        Me.um_edituser_backbtn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.um_edituser_backbtn.Name = "um_edituser_backbtn"
        Me.um_edituser_backbtn.Size = New System.Drawing.Size(89, 29)
        Me.um_edituser_backbtn.TabIndex = 58
        Me.um_edituser_backbtn.Text = "Back"
        Me.um_edituser_backbtn.UseVisualStyleBackColor = False
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(42, 83)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(914, 58)
        Me.RoundedPanel1.TabIndex = 62
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(14, 20)
        Me.instructions.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(226, 15)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required department information."
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(44, 33)
        Me.admin_label_DepartmentManagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(135, 31)
        Me.admin_label_DepartmentManagement.TabIndex = 61
        Me.admin_label_DepartmentManagement.Text = "Add User"
        '
        'uc_um_edituser
        '
        Me.uc_um_edituser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_edituser.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.uc_um_edituser.Controls.Add(Me.suffixAdmin)
        Me.uc_um_edituser.Controls.Add(Me.dateRegistered)
        Me.uc_um_edituser.Controls.Add(Me.houseNumber)
        Me.uc_um_edituser.Controls.Add(Me.barangay)
        Me.uc_um_edituser.Controls.Add(Me.municipality)
        Me.uc_um_edituser.Controls.Add(Me.province)
        Me.uc_um_edituser.Controls.Add(Me.positionAdmin)
        Me.uc_um_edituser.Controls.Add(Me.Label9)
        Me.uc_um_edituser.Controls.Add(Me.Label8)
        Me.uc_um_edituser.Controls.Add(Me.employeeID)
        Me.uc_um_edituser.Controls.Add(Me.Label7)
        Me.uc_um_edituser.Controls.Add(Me.Label5)
        Me.uc_um_edituser.Controls.Add(Me.middleName)
        Me.uc_um_edituser.Controls.Add(Me.Label3)
        Me.uc_um_edituser.Controls.Add(Me.userID)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtStatus)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxID)
        Me.uc_um_edituser.Controls.Add(Me.Label6)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxAddress)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxEmail)
        Me.uc_um_edituser.Controls.Add(Me.email)
        Me.uc_um_edituser.Controls.Add(Me.Label2)
        Me.uc_um_edituser.Controls.Add(Me.contactNumber)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_txtboxdepartment)
        Me.uc_um_edituser.Controls.Add(Me.departmentID)
        Me.uc_um_edituser.Controls.Add(Me.um_useredit_txtboxposition)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_lastname)
        Me.uc_um_edituser.Controls.Add(Me.lastName)
        Me.uc_um_edituser.Controls.Add(Me.um_edituser_fullname)
        Me.uc_um_edituser.Controls.Add(Me.firstName)
        Me.uc_um_edituser.CornerRadius = 5
        Me.uc_um_edituser.Location = New System.Drawing.Point(42, 149)
        Me.uc_um_edituser.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.uc_um_edituser.Name = "uc_um_edituser"
        Me.uc_um_edituser.Size = New System.Drawing.Size(914, 455)
        Me.uc_um_edituser.TabIndex = 60
        '
        'suffixAdmin
        '
        Me.suffixAdmin.FormattingEnabled = True
        Me.suffixAdmin.Location = New System.Drawing.Point(198, 218)
        Me.suffixAdmin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.suffixAdmin.Name = "suffixAdmin"
        Me.suffixAdmin.Size = New System.Drawing.Size(216, 21)
        Me.suffixAdmin.TabIndex = 71
        '
        'dateRegistered
        '
        Me.dateRegistered.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dateRegistered.Location = New System.Drawing.Point(711, 260)
        Me.dateRegistered.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dateRegistered.Name = "dateRegistered"
        Me.dateRegistered.Size = New System.Drawing.Size(114, 20)
        Me.dateRegistered.TabIndex = 69
        '
        'houseNumber
        '
        Me.houseNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.houseNumber.BackColor = System.Drawing.SystemColors.Window
        Me.houseNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.houseNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.houseNumber.Location = New System.Drawing.Point(711, 221)
        Me.houseNumber.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.houseNumber.MaxLength = 100
        Me.houseNumber.Name = "houseNumber"
        Me.houseNumber.Size = New System.Drawing.Size(115, 19)
        Me.houseNumber.TabIndex = 68
        '
        'barangay
        '
        Me.barangay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barangay.FormattingEnabled = True
        Me.barangay.Location = New System.Drawing.Point(640, 180)
        Me.barangay.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.barangay.Name = "barangay"
        Me.barangay.Size = New System.Drawing.Size(185, 21)
        Me.barangay.TabIndex = 67
        '
        'municipality
        '
        Me.municipality.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.municipality.FormattingEnabled = True
        Me.municipality.Location = New System.Drawing.Point(641, 130)
        Me.municipality.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.municipality.Name = "municipality"
        Me.municipality.Size = New System.Drawing.Size(183, 21)
        Me.municipality.TabIndex = 66
        '
        'province
        '
        Me.province.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.province.FormattingEnabled = True
        Me.province.Location = New System.Drawing.Point(640, 87)
        Me.province.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.province.Name = "province"
        Me.province.Size = New System.Drawing.Size(184, 21)
        Me.province.TabIndex = 65
        '
        'positionAdmin
        '
        Me.positionAdmin.FormattingEnabled = True
        Me.positionAdmin.Location = New System.Drawing.Point(198, 262)
        Me.positionAdmin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.positionAdmin.Name = "positionAdmin"
        Me.positionAdmin.Size = New System.Drawing.Size(216, 21)
        Me.positionAdmin.TabIndex = 63
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(532, 130)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 15)
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
        Me.Label8.Location = New System.Drawing.Point(99, 349)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Employee ID"
        '
        'employeeID
        '
        Me.employeeID.BackColor = System.Drawing.SystemColors.Window
        Me.employeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.employeeID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.employeeID.Location = New System.Drawing.Point(196, 349)
        Me.employeeID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.employeeID.MaxLength = 100
        Me.employeeID.Name = "employeeID"
        Me.employeeID.Size = New System.Drawing.Size(218, 19)
        Me.employeeID.TabIndex = 59
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(100, 217)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
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
        Me.Label5.Location = New System.Drawing.Point(99, 132)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Middle Name"
        '
        'middleName
        '
        Me.middleName.BackColor = System.Drawing.SystemColors.Window
        Me.middleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.middleName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.middleName.Location = New System.Drawing.Point(196, 132)
        Me.middleName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.middleName.MaxLength = 100
        Me.middleName.Name = "middleName"
        Me.middleName.Size = New System.Drawing.Size(218, 19)
        Me.middleName.TabIndex = 55
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(99, 45)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "User ID"
        '
        'userID
        '
        Me.userID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.userID.BackColor = System.Drawing.SystemColors.Window
        Me.userID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.userID.Location = New System.Drawing.Point(196, 45)
        Me.userID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.userID.MaxLength = 100
        Me.userID.Name = "userID"
        Me.userID.Size = New System.Drawing.Size(41, 19)
        Me.userID.TabIndex = 53
        '
        'um_edituser_txtStatus
        '
        Me.um_edituser_txtStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtStatus.AutoSize = True
        Me.um_edituser_txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtStatus.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtStatus.Location = New System.Drawing.Point(532, 261)
        Me.um_edituser_txtStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_edituser_txtStatus.Name = "um_edituser_txtStatus"
        Me.um_edituser_txtStatus.Size = New System.Drawing.Size(96, 15)
        Me.um_edituser_txtStatus.TabIndex = 50
        Me.um_edituser_txtStatus.Text = "Date Registered"
        '
        'um_edituser_txtboxID
        '
        Me.um_edituser_txtboxID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxID.AutoSize = True
        Me.um_edituser_txtboxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxID.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxID.Location = New System.Drawing.Point(532, 222)
        Me.um_edituser_txtboxID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_edituser_txtboxID.Name = "um_edituser_txtboxID"
        Me.um_edituser_txtboxID.Size = New System.Drawing.Size(161, 15)
        Me.um_edituser_txtboxID.TabIndex = 46
        Me.um_edituser_txtboxID.Text = "House Number/Full Address"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(532, 179)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
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
        Me.um_edituser_txtboxAddress.Location = New System.Drawing.Point(532, 87)
        Me.um_edituser_txtboxAddress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_edituser_txtboxAddress.Name = "um_edituser_txtboxAddress"
        Me.um_edituser_txtboxAddress.Size = New System.Drawing.Size(54, 15)
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
        Me.um_edituser_txtboxEmail.Location = New System.Drawing.Point(532, 44)
        Me.um_edituser_txtboxEmail.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_edituser_txtboxEmail.Name = "um_edituser_txtboxEmail"
        Me.um_edituser_txtboxEmail.Size = New System.Drawing.Size(39, 15)
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
        Me.email.Location = New System.Drawing.Point(641, 44)
        Me.email.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.email.MaxLength = 100
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(185, 19)
        Me.email.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(99, 391)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Contact Number"
        '
        'contactNumber
        '
        Me.contactNumber.BackColor = System.Drawing.SystemColors.Window
        Me.contactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contactNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.contactNumber.Location = New System.Drawing.Point(222, 391)
        Me.contactNumber.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.contactNumber.MaxLength = 100
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Size = New System.Drawing.Size(192, 19)
        Me.contactNumber.TabIndex = 33
        '
        'um_edituser_txtboxdepartment
        '
        Me.um_edituser_txtboxdepartment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_txtboxdepartment.AutoSize = True
        Me.um_edituser_txtboxdepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_txtboxdepartment.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_txtboxdepartment.Location = New System.Drawing.Point(99, 305)
        Me.um_edituser_txtboxdepartment.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_edituser_txtboxdepartment.Name = "um_edituser_txtboxdepartment"
        Me.um_edituser_txtboxdepartment.Size = New System.Drawing.Size(87, 15)
        Me.um_edituser_txtboxdepartment.TabIndex = 32
        Me.um_edituser_txtboxdepartment.Text = "Department ID"
        '
        'departmentID
        '
        Me.departmentID.BackColor = System.Drawing.SystemColors.Window
        Me.departmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.departmentID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.departmentID.Location = New System.Drawing.Point(196, 305)
        Me.departmentID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.departmentID.MaxLength = 100
        Me.departmentID.Name = "departmentID"
        Me.departmentID.Size = New System.Drawing.Size(218, 19)
        Me.departmentID.TabIndex = 31
        '
        'um_useredit_txtboxposition
        '
        Me.um_useredit_txtboxposition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_useredit_txtboxposition.AutoSize = True
        Me.um_useredit_txtboxposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_useredit_txtboxposition.ForeColor = System.Drawing.Color.Black
        Me.um_useredit_txtboxposition.Location = New System.Drawing.Point(99, 262)
        Me.um_useredit_txtboxposition.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_useredit_txtboxposition.Name = "um_useredit_txtboxposition"
        Me.um_useredit_txtboxposition.Size = New System.Drawing.Size(51, 15)
        Me.um_useredit_txtboxposition.TabIndex = 30
        Me.um_useredit_txtboxposition.Text = "Position"
        '
        'um_edituser_lastname
        '
        Me.um_edituser_lastname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_lastname.AutoSize = True
        Me.um_edituser_lastname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_lastname.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_lastname.Location = New System.Drawing.Point(99, 176)
        Me.um_edituser_lastname.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_edituser_lastname.Name = "um_edituser_lastname"
        Me.um_edituser_lastname.Size = New System.Drawing.Size(67, 15)
        Me.um_edituser_lastname.TabIndex = 28
        Me.um_edituser_lastname.Text = "Last Name"
        '
        'lastName
        '
        Me.lastName.BackColor = System.Drawing.SystemColors.Window
        Me.lastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lastName.Location = New System.Drawing.Point(196, 176)
        Me.lastName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lastName.MaxLength = 100
        Me.lastName.Name = "lastName"
        Me.lastName.Size = New System.Drawing.Size(218, 19)
        Me.lastName.TabIndex = 27
        '
        'um_edituser_fullname
        '
        Me.um_edituser_fullname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_fullname.AutoSize = True
        Me.um_edituser_fullname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.um_edituser_fullname.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_fullname.Location = New System.Drawing.Point(99, 87)
        Me.um_edituser_fullname.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.um_edituser_fullname.Name = "um_edituser_fullname"
        Me.um_edituser_fullname.Size = New System.Drawing.Size(67, 15)
        Me.um_edituser_fullname.TabIndex = 26
        Me.um_edituser_fullname.Text = "First Name"
        '
        'firstName
        '
        Me.firstName.BackColor = System.Drawing.SystemColors.Window
        Me.firstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.firstName.Location = New System.Drawing.Point(196, 87)
        Me.firstName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.firstName.MaxLength = 100
        Me.firstName.Name = "firstName"
        Me.firstName.Size = New System.Drawing.Size(218, 19)
        Me.firstName.TabIndex = 25
        '
        'AddUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.uc_um_edituser)
        Me.Controls.Add(Me.um_edituser_save)
        Me.Controls.Add(Me.um_edituser_backbtn)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "AddUserManagement"
        Me.Size = New System.Drawing.Size(1009, 692)
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
    Friend WithEvents suffixAdmin As System.Windows.Forms.ComboBox
    Friend WithEvents dateRegistered As System.Windows.Forms.DateTimePicker
    Friend WithEvents houseNumber As System.Windows.Forms.TextBox
    Friend WithEvents barangay As System.Windows.Forms.ComboBox
    Friend WithEvents municipality As System.Windows.Forms.ComboBox
    Friend WithEvents province As System.Windows.Forms.ComboBox
    Friend WithEvents positionAdmin As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents employeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents middleName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents userID As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtStatus As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxID As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxAddress As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxEmail As System.Windows.Forms.Label
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents contactNumber As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxdepartment As System.Windows.Forms.Label
    Friend WithEvents departmentID As System.Windows.Forms.TextBox
    Friend WithEvents um_useredit_txtboxposition As System.Windows.Forms.Label
    Friend WithEvents um_edituser_lastname As System.Windows.Forms.Label
    Friend WithEvents lastName As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_fullname As System.Windows.Forms.Label
    Friend WithEvents firstName As System.Windows.Forms.TextBox
End Class
