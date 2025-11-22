<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddUser
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
        Me.um_edituser_save = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.um_edituser_backbtn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.uc_um_edituser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.um_edituser_txtboxPassword = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxUsername = New System.Windows.Forms.Label()
        Me.um_edituser_Username = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxEmail = New System.Windows.Forms.Label()
        Me.um_edituser_email = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxcontact = New System.Windows.Forms.TextBox()
        Me.um_edituser_txtboxdepartment = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.um_useredit_txtboxposition = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxPosition = New System.Windows.Forms.TextBox()
        Me.um_edituser_lastname = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxfull = New System.Windows.Forms.TextBox()
        Me.um_edituser_fullname = New System.Windows.Forms.Label()
        Me.um_edituser_txtboxfirst = New System.Windows.Forms.TextBox()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.uc_um_edituser.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'um_edituser_save
        '
        Me.cb_Barangay.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Barangay.FormattingEnabled = True
        Me.cb_Barangay.Items.AddRange(New Object() {"Binanuaan", "Caawigan", "Cahabaan", "Calintaan", "Del Carmen", "Gabon", "Itomang", "Poblacion", "San Francisco", "San Isidro", "San Jose", "San Nicolas", "Santa Cruz", "Santa Elena", "Santo Niño"})
        Me.cb_Barangay.Location = New System.Drawing.Point(1184, 496)
        Me.cb_Barangay.Name = "cb_Barangay"
        Me.cb_Barangay.Size = New System.Drawing.Size(337, 36)
        Me.cb_Barangay.TabIndex = 46
        '
        'um_edituser_backbtn
        '
        Me.cb_Municipality.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Municipality.FormattingEnabled = True
        Me.cb_Municipality.Items.AddRange(New Object() {"Daet", "Basud", "Capalonga", "Jose Panganiban", "Labo", "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente", "Santa Elena", "Talisay", "Vinzons"})
        Me.cb_Municipality.Location = New System.Drawing.Point(1184, 406)
        Me.cb_Municipality.Name = "cb_Municipality"
        Me.cb_Municipality.Size = New System.Drawing.Size(337, 36)
        Me.cb_Municipality.TabIndex = 45
        '
        'Label1
        '
        Me.cb_Province.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Province.FormattingEnabled = True
        Me.cb_Province.Items.AddRange(New Object() {"Albay", "Camarines Norte", "Camarines Sur", "Catanduanes", "Masbate", "Sorsogon"})
        Me.cb_Province.Location = New System.Drawing.Point(1184, 319)
        Me.cb_Province.Name = "cb_Province"
        Me.cb_Province.Size = New System.Drawing.Size(337, 36)
        Me.cb_Province.TabIndex = 44
        '
        'um_edituser_txtboxCreated
        '
        Me.cb_Position.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Position.FormattingEnabled = True
        Me.cb_Position.Items.AddRange(New Object() {"Super Admin", "Admin", "Staff"})
        Me.cb_Position.Location = New System.Drawing.Point(367, 481)
        Me.cb_Position.Name = "cb_Position"
        Me.cb_Position.Size = New System.Drawing.Size(346, 36)
        Me.cb_Position.TabIndex = 43
        '
        'um_edituser_txtStatus
        '
        Me.txb_ContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ContactNumber.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ContactNumber.Location = New System.Drawing.Point(367, 736)
        Me.txb_ContactNumber.Multiline = True
        Me.txb_ContactNumber.Name = "txb_ContactNumber"
        Me.txb_ContactNumber.Size = New System.Drawing.Size(346, 34)
        Me.txb_ContactNumber.TabIndex = 42
        '
        'um_edituser_txtboxLogin
        '
        Me.Label16.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(149, 736)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(218, 34)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Contact Number"
        '
        'Label4
        '
        Me.txb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Password.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Password.Location = New System.Drawing.Point(1184, 663)
        Me.txb_Password.Multiline = True
        Me.txb_Password.Name = "txb_Password"
        Me.txb_Password.Size = New System.Drawing.Size(337, 34)
        Me.txb_Password.TabIndex = 40
        '
        'um_edituser_txtboxStatus
        '
        Me.Label11.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(971, 663)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 34)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Password"
        '
        'um_edituser_txtboxID
        '
        Me.txb_EmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_EmployeeID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_EmployeeID.Location = New System.Drawing.Point(367, 653)
        Me.txb_EmployeeID.Multiline = True
        Me.txb_EmployeeID.Name = "txb_EmployeeID"
        Me.txb_EmployeeID.Size = New System.Drawing.Size(346, 34)
        Me.txb_EmployeeID.TabIndex = 38
        '
        'um_edituser_EmployeeID
        '
        Me.txb_HouseNoStreet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_HouseNoStreet.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_HouseNoStreet.Location = New System.Drawing.Point(1184, 573)
        Me.txb_HouseNoStreet.Multiline = True
        Me.txb_HouseNoStreet.Name = "txb_HouseNoStreet"
        Me.txb_HouseNoStreet.Size = New System.Drawing.Size(337, 34)
        Me.txb_HouseNoStreet.TabIndex = 37
        '
        'Label6
        '
        Me.txb_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_UserName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UserName.Location = New System.Drawing.Point(1184, 235)
        Me.txb_UserName.Multiline = True
        Me.txb_UserName.Name = "txb_UserName"
        Me.txb_UserName.Size = New System.Drawing.Size(337, 34)
        Me.txb_UserName.TabIndex = 33
        '
        'um_edituser_txtboxAssignment
        '
        Me.txb_Email.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Email.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Email.Location = New System.Drawing.Point(1184, 162)
        Me.txb_Email.Multiline = True
        Me.txb_Email.Name = "txb_Email"
        Me.txb_Email.Size = New System.Drawing.Size(337, 34)
        Me.txb_Email.TabIndex = 32
        '
        'um_edituser_txtboxAddress
        '
        Me.Label9.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(971, 409)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(171, 34)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Municipality"
        '
        'um_edituser_txtboxUserAddress
        '
        Me.Label10.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(979, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 34)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "User Name"
        '
        'um_edituser_Password
        '
        Me.Label12.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(971, 579)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(219, 34)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "House No. Street"
        '
        'admin_label_DepartmentManagement
        '
        Me.Label13.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(971, 321)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(207, 34)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Province"
        '
        'uc_um_edituser
        '
        Me.Label14.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(971, 498)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 34)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Barangay"
        '
        'um_edituser_txtboxUsername
        '
        Me.Label15.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(979, 162)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(150, 34)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Email"
        '
        'um_edituser_Username
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(891, 874)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(190, 46)
        Me.btn_Login.TabIndex = 16
        Me.btn_Login.Text = "Add"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'um_edituser_txtboxEmail
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(548, 874)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(191, 46)
        Me.btn_Cancel.TabIndex = 15
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'um_edituser_email
        '
        Me.txb_DepartmentID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_DepartmentID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentID.Location = New System.Drawing.Point(367, 569)
        Me.txb_DepartmentID.Multiline = True
        Me.txb_DepartmentID.Name = "txb_DepartmentID"
        Me.txb_DepartmentID.Size = New System.Drawing.Size(346, 34)
        Me.txb_DepartmentID.TabIndex = 13
        '
        'Label2
        '
        Me.Label8.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(149, 401)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 34)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Suffix"
        '
        'um_edituser_txtboxcontact
        '
        Me.Label7.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(149, 229)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 34)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Middle Name"
        '
        'um_edituser_txtboxdepartment
        '
        Me.txb_Suffix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Suffix.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Suffix.Location = New System.Drawing.Point(367, 401)
        Me.txb_Suffix.Multiline = True
        Me.txb_Suffix.Name = "txb_Suffix"
        Me.txb_Suffix.Size = New System.Drawing.Size(346, 34)
        Me.txb_Suffix.TabIndex = 9
        '
        'TextBox4
        '
        Me.txb_LastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_LastName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_LastName.Location = New System.Drawing.Point(367, 315)
        Me.txb_LastName.Multiline = True
        Me.txb_LastName.Name = "txb_LastName"
        Me.txb_LastName.Size = New System.Drawing.Size(346, 34)
        Me.txb_LastName.TabIndex = 8
        '
        'um_useredit_txtboxposition
        '
        Me.txb_MiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_MiddleName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_MiddleName.Location = New System.Drawing.Point(367, 229)
        Me.txb_MiddleName.Multiline = True
        Me.txb_MiddleName.Name = "txb_MiddleName"
        Me.txb_MiddleName.Size = New System.Drawing.Size(346, 34)
        Me.txb_MiddleName.TabIndex = 7
        '
        'um_edituser_txtboxPosition
        '
        Me.txb_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_FirstName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_FirstName.Location = New System.Drawing.Point(367, 156)
        Me.txb_FirstName.Multiline = True
        Me.txb_FirstName.Name = "txb_FirstName"
        Me.txb_FirstName.Size = New System.Drawing.Size(346, 34)
        Me.txb_FirstName.TabIndex = 6
        '
        'um_edituser_lastname
        '
        Me.Label6.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(149, 653)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(212, 34)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Employee I.D"
        '
        'um_edituser_txtboxfull
        '
        Me.Label5.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(149, 569)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 34)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Department I.D"
        '
        'um_edituser_fullname
        '
        Me.Label4.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(149, 315)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 34)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Last Name"
        '
        'um_edituser_txtboxfirst
        '
        Me.Label3.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(149, 483)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 34)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Position"
        '
        'RoundedPanel1
        '
        Me.Label2.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(149, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 34)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'instructions
        '
        Me.Label1.Font = New System.Drawing.Font("Poppins", 41.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(670, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 64)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REGISTER"
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1694, 1008)
        Me.Controls.Add(Me.cb_Barangay)
        Me.Controls.Add(Me.cb_Municipality)
        Me.Controls.Add(Me.txb_Password)
        Me.Controls.Add(Me.cb_Province)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb_Position)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txb_ContactNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txb_EmployeeID)
        Me.Controls.Add(Me.txb_FirstName)
        Me.Controls.Add(Me.txb_HouseNoStreet)
        Me.Controls.Add(Me.txb_MiddleName)
        Me.Controls.Add(Me.txb_UserName)
        Me.Controls.Add(Me.txb_LastName)
        Me.Controls.Add(Me.txb_Email)
        Me.Controls.Add(Me.txb_Suffix)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txb_DepartmentID)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.Label15)
        Me.Name = "AddUser"
        Me.Text = "AddUser"
        Me.uc_um_edituser.ResumeLayout(False)
        Me.uc_um_edituser.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents um_edituser_save As Resources.Controls.RoundedButton
    Friend WithEvents um_edituser_backbtn As Resources.Controls.RoundedButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxCreated As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtStatus As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxStatus As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxID As System.Windows.Forms.Label
    Friend WithEvents um_edituser_EmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxAssignment As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxAddress As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxUserAddress As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_Password As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents uc_um_edituser As Resources.Controls.RoundedPanel
    Friend WithEvents um_edituser_txtboxPassword As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxUsername As System.Windows.Forms.Label
    Friend WithEvents um_edituser_Username As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxEmail As System.Windows.Forms.Label
    Friend WithEvents um_edituser_email As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxcontact As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_txtboxdepartment As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents um_useredit_txtboxposition As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxPosition As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_lastname As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxfull As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_fullname As System.Windows.Forms.Label
    Friend WithEvents um_edituser_txtboxfirst As System.Windows.Forms.TextBox
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
End Class
