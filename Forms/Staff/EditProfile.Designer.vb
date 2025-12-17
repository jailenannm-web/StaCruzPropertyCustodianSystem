<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditProfile
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
        Me.Txb_Password = New System.Windows.Forms.TextBox()
        Me.txb_Position = New System.Windows.Forms.TextBox()
        Me.txb_UserID = New System.Windows.Forms.TextBox()
        Me.cb_Barangay = New System.Windows.Forms.ComboBox()
        Me.cb_Municipality = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_Province = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txb_ContactNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txb_FirstName = New System.Windows.Forms.TextBox()
        Me.txb_MiddleName = New System.Windows.Forms.TextBox()
        Me.txb_LastName = New System.Windows.Forms.TextBox()
        Me.txb_UserName = New System.Windows.Forms.TextBox()
        Me.txb_Suffix = New System.Windows.Forms.TextBox()
        Me.txb_Email = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txb_DepartmentID = New System.Windows.Forms.ComboBox()
        Me.txb_EmployeeID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Txb_Password
        '
        Me.Txb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txb_Password.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txb_Password.Location = New System.Drawing.Point(1276, 469)
        Me.Txb_Password.Margin = New System.Windows.Forms.Padding(4)
        Me.Txb_Password.Multiline = True
        Me.Txb_Password.Name = "Txb_Password"
        Me.Txb_Password.Size = New System.Drawing.Size(421, 42)
        Me.Txb_Password.TabIndex = 82
        '
        'txb_Position
        '
        Me.txb_Position.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Position.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Position.Location = New System.Drawing.Point(469, 652)
        Me.txb_Position.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Position.Multiline = True
        Me.txb_Position.Name = "txb_Position"
        Me.txb_Position.Size = New System.Drawing.Size(421, 42)
        Me.txb_Position.TabIndex = 81
        '
        'txb_UserID
        '
        Me.txb_UserID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_UserID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UserID.Location = New System.Drawing.Point(469, 163)
        Me.txb_UserID.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_UserID.Multiline = True
        Me.txb_UserID.Name = "txb_UserID"
        Me.txb_UserID.Size = New System.Drawing.Size(421, 42)
        Me.txb_UserID.TabIndex = 80
        '
        'cb_Barangay
        '
        Me.cb_Barangay.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Barangay.FormattingEnabled = True
        Me.cb_Barangay.Items.AddRange(New Object() {"Binanuaan", "Caawigan", "Cahabaan", "Calintaan", "Del Carmen", "Gabon", "Itomang", "Poblacion", "San Francisco", "San Isidro", "San Jose", "San Nicolas", "Santa Cruz", "Santa Elena", "Santo Niño"})
        Me.cb_Barangay.Location = New System.Drawing.Point(1276, 804)
        Me.cb_Barangay.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Barangay.Name = "cb_Barangay"
        Me.cb_Barangay.Size = New System.Drawing.Size(421, 44)
        Me.cb_Barangay.TabIndex = 79
        '
        'cb_Municipality
        '
        Me.cb_Municipality.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Municipality.FormattingEnabled = True
        Me.cb_Municipality.Items.AddRange(New Object() {"Daet", "Basud", "Capalonga", "Jose Panganiban", "Labo", "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente", "Santa Elena", "Talisay", "Vinzons"})
        Me.cb_Municipality.Location = New System.Drawing.Point(1276, 691)
        Me.cb_Municipality.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Municipality.Name = "cb_Municipality"
        Me.cb_Municipality.Size = New System.Drawing.Size(421, 44)
        Me.cb_Municipality.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(915, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 56)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Edit Profile"
        '
        'cb_Province
        '
        Me.cb_Province.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Province.FormattingEnabled = True
        Me.cb_Province.Items.AddRange(New Object() {"Albay", "Camarines Norte", "Camarines Sur", "Catanduanes", "Masbate", "Sorsogon"})
        Me.cb_Province.Location = New System.Drawing.Point(1276, 583)
        Me.cb_Province.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Province.Name = "cb_Province"
        Me.cb_Province.Size = New System.Drawing.Size(421, 44)
        Me.cb_Province.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(279, 180)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 25)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "User I.D"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(279, 559)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 26)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Suffix"
        '
        'txb_ContactNumber
        '
        Me.txb_ContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ContactNumber.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ContactNumber.Location = New System.Drawing.Point(1276, 163)
        Me.txb_ContactNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_ContactNumber.Multiline = True
        Me.txb_ContactNumber.Name = "txb_ContactNumber"
        Me.txb_ContactNumber.Size = New System.Drawing.Size(421, 42)
        Me.txb_ContactNumber.TabIndex = 76
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(276, 366)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 26)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Middle Name"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(276, 879)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(161, 42)
        Me.Label16.TabIndex = 75
        Me.Label16.Text = "Employee I.D"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(279, 668)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(182, 26)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Position"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(279, 776)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(182, 26)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Department I.D"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1060, 818)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(177, 30)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Barangay"
        '
        'txb_FirstName
        '
        Me.txb_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_FirstName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_FirstName.Location = New System.Drawing.Point(469, 254)
        Me.txb_FirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_FirstName.Multiline = True
        Me.txb_FirstName.Name = "txb_FirstName"
        Me.txb_FirstName.Size = New System.Drawing.Size(421, 42)
        Me.txb_FirstName.TabIndex = 56
        '
        'txb_MiddleName
        '
        Me.txb_MiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_MiddleName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_MiddleName.Location = New System.Drawing.Point(469, 348)
        Me.txb_MiddleName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_MiddleName.Multiline = True
        Me.txb_MiddleName.Name = "txb_MiddleName"
        Me.txb_MiddleName.Size = New System.Drawing.Size(421, 42)
        Me.txb_MiddleName.TabIndex = 57
        '
        'txb_LastName
        '
        Me.txb_LastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_LastName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_LastName.Location = New System.Drawing.Point(469, 447)
        Me.txb_LastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_LastName.Multiline = True
        Me.txb_LastName.Name = "txb_LastName"
        Me.txb_LastName.Size = New System.Drawing.Size(421, 42)
        Me.txb_LastName.TabIndex = 58
        '
        'txb_UserName
        '
        Me.txb_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_UserName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UserName.Location = New System.Drawing.Point(1276, 362)
        Me.txb_UserName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_UserName.Multiline = True
        Me.txb_UserName.Name = "txb_UserName"
        Me.txb_UserName.Size = New System.Drawing.Size(421, 42)
        Me.txb_UserName.TabIndex = 72
        '
        'txb_Suffix
        '
        Me.txb_Suffix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Suffix.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Suffix.Location = New System.Drawing.Point(469, 543)
        Me.txb_Suffix.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Suffix.Multiline = True
        Me.txb_Suffix.Name = "txb_Suffix"
        Me.txb_Suffix.Size = New System.Drawing.Size(421, 42)
        Me.txb_Suffix.TabIndex = 59
        '
        'txb_Email
        '
        Me.txb_Email.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Email.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Email.Location = New System.Drawing.Point(1276, 260)
        Me.txb_Email.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Email.Multiline = True
        Me.txb_Email.Name = "txb_Email"
        Me.txb_Email.Size = New System.Drawing.Size(421, 42)
        Me.txb_Email.TabIndex = 71
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(279, 270)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 26)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "First Name"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(1060, 481)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(203, 30)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Password"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(276, 469)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 26)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Last Name"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1060, 272)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(177, 30)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Email"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1060, 705)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(203, 30)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Municipality"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(713, 1002)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(228, 58)
        Me.btn_Cancel.TabIndex = 63
        Me.btn_Cancel.Text = "Back"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(1060, 374)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(248, 30)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "User name"
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.FlatAppearance.BorderSize = 0
        Me.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.Transparent
        Me.btn_Login.Location = New System.Drawing.Point(1142, 1002)
        Me.btn_Login.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(227, 58)
        Me.btn_Login.TabIndex = 64
        Me.btn_Login.Text = "Save"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(1060, 597)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(159, 30)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "Province"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(1060, 180)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(288, 30)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Contact Number"
        '
        'txb_DepartmentID
        '
        Me.txb_DepartmentID.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentID.FormattingEnabled = True
        Me.txb_DepartmentID.Items.AddRange(New Object() {"Daet", "Basud", "Capalonga", "Jose Panganiban", "Labo", "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente", "Santa Elena", "Talisay", "Vinzons"})
        Me.txb_DepartmentID.Location = New System.Drawing.Point(455, 818)
        Me.txb_DepartmentID.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_DepartmentID.Name = "txb_DepartmentID"
        Me.txb_DepartmentID.Size = New System.Drawing.Size(421, 44)
        Me.txb_DepartmentID.TabIndex = 83
        '
        'txb_EmployeeID
        '
        Me.txb_EmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_EmployeeID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_EmployeeID.Location = New System.Drawing.Point(469, 871)
        Me.txb_EmployeeID.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_EmployeeID.Multiline = True
        Me.txb_EmployeeID.Name = "txb_EmployeeID"
        Me.txb_EmployeeID.Size = New System.Drawing.Size(421, 42)
        Me.txb_EmployeeID.TabIndex = 84
        '
        'EditProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1175)
        Me.Controls.Add(Me.txb_EmployeeID)
        Me.Controls.Add(Me.txb_DepartmentID)
        Me.Controls.Add(Me.Txb_Password)
        Me.Controls.Add(Me.txb_Position)
        Me.Controls.Add(Me.txb_UserID)
        Me.Controls.Add(Me.cb_Barangay)
        Me.Controls.Add(Me.cb_Municipality)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb_Province)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txb_ContactNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txb_FirstName)
        Me.Controls.Add(Me.txb_MiddleName)
        Me.Controls.Add(Me.txb_LastName)
        Me.Controls.Add(Me.txb_UserName)
        Me.Controls.Add(Me.txb_Suffix)
        Me.Controls.Add(Me.txb_Email)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Name = "EditProfile"
        Me.Text = "EditProfile"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txb_Password As System.Windows.Forms.TextBox
    Friend WithEvents txb_Position As System.Windows.Forms.TextBox
    Friend WithEvents txb_UserID As System.Windows.Forms.TextBox
    Friend WithEvents cb_Barangay As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Municipality As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_Province As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txb_ContactNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txb_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents txb_MiddleName As System.Windows.Forms.TextBox
    Friend WithEvents txb_LastName As System.Windows.Forms.TextBox
    Friend WithEvents txb_UserName As System.Windows.Forms.TextBox
    Friend WithEvents txb_Suffix As System.Windows.Forms.TextBox
    Friend WithEvents txb_Email As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_Login As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txb_DepartmentID As System.Windows.Forms.ComboBox
    Friend WithEvents txb_EmployeeID As System.Windows.Forms.TextBox
End Class
