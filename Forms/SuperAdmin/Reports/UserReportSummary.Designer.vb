<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserReportSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserReportSummary))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.issuedDate = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.issuedBy = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.receivedDate = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.receivedBy = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.userID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employeeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lastLogin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateReport = New System.Windows.Forms.DateTimePicker()
        Me.school = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Back = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPDF = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(509, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 17)
        Me.Label1.TabIndex = 374
        Me.Label1.Text = "Republic of the Philippines"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(512, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 17)
        Me.Label2.TabIndex = 375
        Me.Label2.Text = "Department of Education"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(462, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(257, 17)
        Me.Label3.TabIndex = 376
        Me.Label3.Text = "DIVISION OF CAMARINES NORTE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dateReport)
        Me.Panel1.Controls.Add(Me.school)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(148, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1173, 865)
        Me.Panel1.TabIndex = 377
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(79, 636)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 184.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1027, 185)
        Me.TableLayoutPanel1.TabIndex = 387
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.issuedDate)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.issuedBy)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Location = New System.Drawing.Point(517, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(506, 177)
        Me.Panel4.TabIndex = 390
        '
        'issuedDate
        '
        Me.issuedDate.Location = New System.Drawing.Point(123, 119)
        Me.issuedDate.Name = "issuedDate"
        Me.issuedDate.Size = New System.Drawing.Size(271, 22)
        Me.issuedDate.TabIndex = 393
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(240, 144)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 17)
        Me.Label14.TabIndex = 392
        Me.Label14.Text = "Date"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(165, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(179, 17)
        Me.Label11.TabIndex = 389
        Me.Label11.Text = "Signature over Printed Name"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'issuedBy
        '
        Me.issuedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.issuedBy.Location = New System.Drawing.Point(50, 48)
        Me.issuedBy.Name = "issuedBy"
        Me.issuedBy.Size = New System.Drawing.Size(411, 22)
        Me.issuedBy.TabIndex = 388
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 388
        Me.Label12.Text = "Issued by:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.receivedDate)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.receivedBy)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(506, 177)
        Me.Panel3.TabIndex = 0
        '
        'receivedDate
        '
        Me.receivedDate.Location = New System.Drawing.Point(112, 119)
        Me.receivedDate.Name = "receivedDate"
        Me.receivedDate.Size = New System.Drawing.Size(271, 22)
        Me.receivedDate.TabIndex = 391
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(229, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 17)
        Me.Label13.TabIndex = 390
        Me.Label13.Text = "Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(165, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(179, 17)
        Me.Label10.TabIndex = 389
        Me.Label10.Text = "Signature over Printed Name"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'receivedBy
        '
        Me.receivedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.receivedBy.Location = New System.Drawing.Point(50, 48)
        Me.receivedBy.Name = "receivedBy"
        Me.receivedBy.Size = New System.Drawing.Size(411, 22)
        Me.receivedBy.TabIndex = 388
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 388
        Me.Label9.Text = "Received by:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(79, 264)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1027, 374)
        Me.Panel2.TabIndex = 386
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.userID, Me.fullName, Me.position, Me.employeeID, Me.departmentID, Me.email, Me.contactNumber, Me.username, Me.Address, Me.role, Me.status, Me.createdAt, Me.updatedAt, Me.lastLogin})
        Me.DataGridView1.Location = New System.Drawing.Point(-1, -2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1027, 374)
        Me.DataGridView1.TabIndex = 0
        '
        'userID
        '
        Me.userID.HeaderText = "User ID"
        Me.userID.MinimumWidth = 6
        Me.userID.Name = "userID"
        Me.userID.Width = 90
        '
        'fullName
        '
        Me.fullName.HeaderText = "Full Name"
        Me.fullName.MinimumWidth = 6
        Me.fullName.Name = "fullName"
        Me.fullName.Width = 120
        '
        'position
        '
        Me.position.HeaderText = "Position"
        Me.position.MinimumWidth = 6
        Me.position.Name = "position"
        Me.position.Width = 90
        '
        'employeeID
        '
        Me.employeeID.HeaderText = "Employee ID"
        Me.employeeID.MinimumWidth = 6
        Me.employeeID.Name = "employeeID"
        Me.employeeID.Width = 90
        '
        'departmentID
        '
        Me.departmentID.HeaderText = "Department ID"
        Me.departmentID.MinimumWidth = 6
        Me.departmentID.Name = "departmentID"
        Me.departmentID.Width = 90
        '
        'email
        '
        Me.email.HeaderText = "Email"
        Me.email.MinimumWidth = 6
        Me.email.Name = "email"
        Me.email.Width = 120
        '
        'contactNumber
        '
        Me.contactNumber.HeaderText = "Contact Number"
        Me.contactNumber.MinimumWidth = 6
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Width = 125
        '
        'username
        '
        Me.username.HeaderText = "Username"
        Me.username.MinimumWidth = 6
        Me.username.Name = "username"
        Me.username.Width = 125
        '
        'Address
        '
        Me.Address.HeaderText = "Address"
        Me.Address.MinimumWidth = 6
        Me.Address.Name = "Address"
        Me.Address.Width = 120
        '
        'role
        '
        Me.role.HeaderText = "Role"
        Me.role.MinimumWidth = 6
        Me.role.Name = "role"
        Me.role.Width = 90
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 90
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "Created at"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Visible = False
        Me.createdAt.Width = 90
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "Updated at"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Visible = False
        Me.updatedAt.Width = 90
        '
        'lastLogin
        '
        Me.lastLogin.HeaderText = "Last Login"
        Me.lastLogin.MinimumWidth = 6
        Me.lastLogin.Name = "lastLogin"
        Me.lastLogin.Visible = False
        Me.lastLogin.Width = 90
        '
        'dateReport
        '
        Me.dateReport.Location = New System.Drawing.Point(906, 236)
        Me.dateReport.Name = "dateReport"
        Me.dateReport.Size = New System.Drawing.Size(200, 22)
        Me.dateReport.TabIndex = 385
        '
        'school
        '
        Me.school.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.school.Location = New System.Drawing.Point(133, 236)
        Me.school.Name = "school"
        Me.school.Size = New System.Drawing.Size(645, 22)
        Me.school.TabIndex = 384
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(860, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 17)
        Me.Label8.TabIndex = 383
        Me.Label8.Text = "Date:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(77, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 17)
        Me.Label7.TabIndex = 382
        Me.Label7.Text = "School:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(461, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(271, 20)
        Me.Label6.TabIndex = 381
        Me.Label6.Text = "USER MANAGEMENT REPORT"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(976, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(130, 125)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 380
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(79, 59)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(130, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 379
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(469, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 17)
        Me.Label5.TabIndex = 378
        Me.Label5.Text = "Sta. Cruz, Talisay, Camarines Norte"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(533, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 377
        Me.Label4.Text = "Region V - Bicol"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_Back
        '
        Me.btn_Back.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Back.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Back.CornerRadius = 15
        Me.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Back.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btn_Back.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_Back.Location = New System.Drawing.Point(846, 946)
        Me.btn_Back.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(153, 34)
        Me.btn_Back.TabIndex = 382
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = False
        '
        'btnPDF
        '
        Me.btnPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnPDF.CornerRadius = 15
        Me.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPDF.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnPDF.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnPDF.Location = New System.Drawing.Point(1168, 946)
        Me.btnPDF.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(153, 34)
        Me.btnPDF.TabIndex = 381
        Me.btnPDF.Text = "Generate PDF File"
        Me.btnPDF.UseVisualStyleBackColor = False
        '
        'btnCSV
        '
        Me.btnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnCSV.CornerRadius = 15
        Me.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCSV.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCSV.Location = New System.Drawing.Point(1007, 946)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(153, 34)
        Me.btnCSV.TabIndex = 380
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'UserReportSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1480, 1055)
        Me.Controls.Add(Me.btn_Back)
        Me.Controls.Add(Me.btnPDF)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UserReportSummary"
        Me.Text = "UserReportSummary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents school As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dateReport As System.Windows.Forms.DateTimePicker
    Friend WithEvents userID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents position As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents employeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents departmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents contactNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents role As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents createdAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lastLogin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents receivedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents issuedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents issuedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents receivedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_Back As Resources.Controls.RoundedButton
    Friend WithEvents btnPDF As Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As Resources.Controls.RoundedButton
End Class
