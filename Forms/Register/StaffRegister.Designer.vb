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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txb_FirstName = New System.Windows.Forms.TextBox()
        Me.txb_MiddleName = New System.Windows.Forms.TextBox()
        Me.txb_LastName = New System.Windows.Forms.TextBox()
        Me.txb_Suffix = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txb_DepartmentID = New System.Windows.Forms.TextBox()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txb_Email = New System.Windows.Forms.TextBox()
        Me.txb_UserName = New System.Windows.Forms.TextBox()
        Me.txb_HouseNoStreet = New System.Windows.Forms.TextBox()
        Me.txb_EmployeeID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pa = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txb_ContactNumber = New System.Windows.Forms.TextBox()
        Me.cb_Position = New System.Windows.Forms.ComboBox()
        Me.cb_Province = New System.Windows.Forms.ComboBox()
        Me.cb_Municipality = New System.Windows.Forms.ComboBox()
        Me.cb_Barangay = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 41.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(768, 92)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(377, 80)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REGISTER"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(117, 247)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 42)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(117, 656)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(157, 42)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Position"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(117, 446)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(219, 42)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Last Name"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(117, 763)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(254, 42)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Department I.D"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(117, 868)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(254, 42)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Employee I.D"
        '
        'txb_FirstName
        '
        Me.txb_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_FirstName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_FirstName.Location = New System.Drawing.Point(389, 247)
        Me.txb_FirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_FirstName.Multiline = True
        Me.txb_FirstName.Name = "txb_FirstName"
        Me.txb_FirstName.Size = New System.Drawing.Size(421, 42)
        Me.txb_FirstName.TabIndex = 6
        '
        'txb_MiddleName
        '
        Me.txb_MiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_MiddleName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_MiddleName.Location = New System.Drawing.Point(389, 338)
        Me.txb_MiddleName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_MiddleName.Multiline = True
        Me.txb_MiddleName.Name = "txb_MiddleName"
        Me.txb_MiddleName.Size = New System.Drawing.Size(421, 42)
        Me.txb_MiddleName.TabIndex = 7
        '
        'txb_LastName
        '
        Me.txb_LastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_LastName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_LastName.Location = New System.Drawing.Point(389, 446)
        Me.txb_LastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_LastName.Multiline = True
        Me.txb_LastName.Name = "txb_LastName"
        Me.txb_LastName.Size = New System.Drawing.Size(421, 42)
        Me.txb_LastName.TabIndex = 8
        '
        'txb_Suffix
        '
        Me.txb_Suffix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Suffix.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Suffix.Location = New System.Drawing.Point(389, 553)
        Me.txb_Suffix.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Suffix.Multiline = True
        Me.txb_Suffix.Name = "txb_Suffix"
        Me.txb_Suffix.Size = New System.Drawing.Size(421, 42)
        Me.txb_Suffix.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(117, 338)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(233, 42)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Middle Name"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(117, 553)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 42)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Suffix"
        '
        'txb_DepartmentID
        '
        Me.txb_DepartmentID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_DepartmentID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentID.Location = New System.Drawing.Point(389, 763)
        Me.txb_DepartmentID.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_DepartmentID.Multiline = True
        Me.txb_DepartmentID.Name = "txb_DepartmentID"
        Me.txb_DepartmentID.Size = New System.Drawing.Size(421, 42)
        Me.txb_DepartmentID.TabIndex = 13
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(633, 1086)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(228, 58)
        Me.btn_Cancel.TabIndex = 15
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.FlatAppearance.BorderSize = 0
        Me.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.Transparent
        Me.btn_Login.Location = New System.Drawing.Point(1062, 1086)
        Me.btn_Login.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(227, 58)
        Me.btn_Login.TabIndex = 16
        Me.btn_Login.Text = "Login"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(1154, 255)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(177, 42)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Email"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(1154, 674)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(159, 42)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Barangay"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(1154, 453)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(248, 42)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Province"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1154, 768)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(248, 42)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "House No. Street"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1154, 346)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(177, 42)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "User Name"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(1154, 561)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(203, 42)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Municipality"
        '
        'txb_Email
        '
        Me.txb_Email.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Email.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Email.Location = New System.Drawing.Point(1410, 255)
        Me.txb_Email.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Email.Multiline = True
        Me.txb_Email.Name = "txb_Email"
        Me.txb_Email.Size = New System.Drawing.Size(410, 42)
        Me.txb_Email.TabIndex = 32
        '
        'txb_UserName
        '
        Me.txb_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_UserName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UserName.Location = New System.Drawing.Point(1410, 346)
        Me.txb_UserName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_UserName.Multiline = True
        Me.txb_UserName.Name = "txb_UserName"
        Me.txb_UserName.Size = New System.Drawing.Size(410, 42)
        Me.txb_UserName.TabIndex = 33
        '
        'txb_HouseNoStreet
        '
        Me.txb_HouseNoStreet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_HouseNoStreet.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_HouseNoStreet.Location = New System.Drawing.Point(1410, 768)
        Me.txb_HouseNoStreet.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_HouseNoStreet.Multiline = True
        Me.txb_HouseNoStreet.Name = "txb_HouseNoStreet"
        Me.txb_HouseNoStreet.Size = New System.Drawing.Size(410, 42)
        Me.txb_HouseNoStreet.TabIndex = 37
        '
        'txb_EmployeeID
        '
        Me.txb_EmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_EmployeeID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_EmployeeID.Location = New System.Drawing.Point(389, 868)
        Me.txb_EmployeeID.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_EmployeeID.Multiline = True
        Me.txb_EmployeeID.Name = "txb_EmployeeID"
        Me.txb_EmployeeID.Size = New System.Drawing.Size(421, 42)
        Me.txb_EmployeeID.TabIndex = 38
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1154, 881)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(159, 42)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Password"
        '
        'pa
        '
        Me.pa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pa.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pa.Location = New System.Drawing.Point(1410, 881)
        Me.pa.Margin = New System.Windows.Forms.Padding(4)
        Me.pa.Multiline = True
        Me.pa.Name = "pa"
        Me.pa.Size = New System.Drawing.Size(410, 42)
        Me.pa.TabIndex = 40
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(117, 972)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(261, 42)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Contact Number"
        '
        'txb_ContactNumber
        '
        Me.txb_ContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ContactNumber.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ContactNumber.Location = New System.Drawing.Point(389, 972)
        Me.txb_ContactNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_ContactNumber.Multiline = True
        Me.txb_ContactNumber.Name = "txb_ContactNumber"
        Me.txb_ContactNumber.Size = New System.Drawing.Size(421, 42)
        Me.txb_ContactNumber.TabIndex = 42
        '
        'cb_Position
        '
        Me.cb_Position.AutoCompleteCustomSource.AddRange(New String() {"", "Principal l", "Principal ll", "Assistant Principal", "Administrative Officer", "School Registrar", "Finance", "Master Teacher I", "Master Teacher Il", "Master Teacher Ill", "Classroom Teacher I", "Classroom Teacher Il", "Classroom Teacher Ill", "Special Education Teacher", "English Teachers", "Math Teachers", " Science Teachers", "MAPEH Teachers", "Guidance Counselor", "ICT", "School Secretary", "Security Personnel"})
        Me.cb_Position.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Position.FormattingEnabled = True
        Me.cb_Position.Items.AddRange(New Object() {"Super Admin", "Admin", "Staff"})
        Me.cb_Position.Location = New System.Drawing.Point(389, 653)
        Me.cb_Position.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Position.Name = "cb_Position"
        Me.cb_Position.Size = New System.Drawing.Size(421, 44)
        Me.cb_Position.TabIndex = 43
        '
        'cb_Province
        '
        Me.cb_Province.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Province.FormattingEnabled = True
        Me.cb_Province.Items.AddRange(New Object() {"Albay", "Camarines Norte", "Camarines Sur", "Catanduanes", "Masbate", "Sorsogon"})
        Me.cb_Province.Location = New System.Drawing.Point(1410, 451)
        Me.cb_Province.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Province.Name = "cb_Province"
        Me.cb_Province.Size = New System.Drawing.Size(409, 44)
        Me.cb_Province.TabIndex = 44
        '
        'cb_Municipality
        '
        Me.cb_Municipality.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Municipality.FormattingEnabled = True
        Me.cb_Municipality.Items.AddRange(New Object() {"Daet", "Basud", "Capalonga", "Jose Panganiban", "Labo", "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente", "Santa Elena", "Talisay", "Vinzons"})
        Me.cb_Municipality.Location = New System.Drawing.Point(1410, 559)
        Me.cb_Municipality.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Municipality.Name = "cb_Municipality"
        Me.cb_Municipality.Size = New System.Drawing.Size(409, 44)
        Me.cb_Municipality.TabIndex = 45
        '
        'cb_Barangay
        '
        Me.cb_Barangay.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Barangay.FormattingEnabled = True
        Me.cb_Barangay.Items.AddRange(New Object() {"Binanuaan", "Caawigan", "Cahabaan", "Calintaan", "Del Carmen", "Gabon", "Itomang", "Poblacion", "San Francisco", "San Isidro", "San Jose", "San Nicolas", "Santa Cruz", "Santa Elena", "Santo Niño"})
        Me.cb_Barangay.Location = New System.Drawing.Point(1410, 672)
        Me.cb_Barangay.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Barangay.Name = "cb_Barangay"
        Me.cb_Barangay.Size = New System.Drawing.Size(409, 44)
        Me.cb_Barangay.TabIndex = 46
        '
        'StaffRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources._Presentation1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1942, 1222)
        Me.Controls.Add(Me.cb_Barangay)
        Me.Controls.Add(Me.cb_Municipality)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb_Province)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb_Position)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txb_ContactNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pa)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txb_FirstName)
        Me.Controls.Add(Me.txb_EmployeeID)
        Me.Controls.Add(Me.txb_MiddleName)
        Me.Controls.Add(Me.txb_HouseNoStreet)
        Me.Controls.Add(Me.txb_LastName)
        Me.Controls.Add(Me.txb_UserName)
        Me.Controls.Add(Me.txb_Suffix)
        Me.Controls.Add(Me.txb_Email)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txb_DepartmentID)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "StaffRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Register As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txb_FirstName As TextBox
    Friend WithEvents txb_MiddleName As TextBox
    Friend WithEvents txb_LastName As TextBox
    Friend WithEvents txb_Suffix As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txb_DepartmentID As TextBox
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_Login As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txb_Email As TextBox
    Friend WithEvents txb_UserName As TextBox
    Friend WithEvents txb_HouseNoStreet As TextBox
    Friend WithEvents txb_EmployeeID As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents pa As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txb_ContactNumber As TextBox
    Friend WithEvents cb_Position As ComboBox
    Friend WithEvents cb_Province As ComboBox
    Friend WithEvents cb_Municipality As ComboBox
    Friend WithEvents cb_Barangay As ComboBox
End Class
