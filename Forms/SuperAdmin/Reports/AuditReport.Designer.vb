Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AuditReport
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
        Me.btn_Back = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.status = New System.Windows.Forms.TextBox()
        Me.action = New System.Windows.Forms.TextBox()
        Me.userAgent = New System.Windows.Forms.TextBox()
        Me.ipAddress = New System.Windows.Forms.TextBox()
        Me.recordId = New System.Windows.Forms.TextBox()
        Me.tableName = New System.Windows.Forms.TextBox()
        Me.logId = New System.Windows.Forms.TextBox()
        Me.userId = New System.Windows.Forms.TextBox()
        Me.user = New System.Windows.Forms.TextBox()
        Me.description = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DateTimePicker5 = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DateTimePicker6 = New System.Windows.Forms.DateTimePicker()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel11.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Back
        '
        Me.btn_Back.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Back.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Back.ForeColor = System.Drawing.Color.White
        Me.btn_Back.Location = New System.Drawing.Point(823, 1163)
        Me.btn_Back.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(235, 52)
        Me.btn_Back.TabIndex = 78
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1155, 1163)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(235, 52)
        Me.Button1.TabIndex = 79
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(385, 926)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(1371, 106)
        Me.TextBox3.TabIndex = 359
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblPropertyCard)
        Me.Panel11.Location = New System.Drawing.Point(351, 70)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(913, 64)
        Me.Panel11.TabIndex = 360
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(361, 10)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(197, 44)
        Me.lblPropertyCard.TabIndex = 38
        Me.lblPropertyCard.Text = "AUDIT REPORT"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.TextBox11)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.DateTimePicker3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(351, 128)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(913, 724)
        Me.Panel1.TabIndex = 361
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.TextBox5)
        Me.Panel2.Controls.Add(Me.TextBox6)
        Me.Panel2.Controls.Add(Me.TextBox7)
        Me.Panel2.Controls.Add(Me.TextBox8)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.DateTimePicker2)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.DateTimePicker4)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Location = New System.Drawing.Point(-1, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(913, 724)
        Me.Panel2.TabIndex = 399
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.status)
        Me.Panel3.Controls.Add(Me.action)
        Me.Panel3.Controls.Add(Me.userAgent)
        Me.Panel3.Controls.Add(Me.ipAddress)
        Me.Panel3.Controls.Add(Me.recordId)
        Me.Panel3.Controls.Add(Me.tableName)
        Me.Panel3.Controls.Add(Me.logId)
        Me.Panel3.Controls.Add(Me.userId)
        Me.Panel3.Controls.Add(Me.user)
        Me.Panel3.Controls.Add(Me.description)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.DateTimePicker5)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.DateTimePicker6)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.Label33)
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Controls.Add(Me.Label35)
        Me.Panel3.Location = New System.Drawing.Point(-1, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(913, 724)
        Me.Panel3.TabIndex = 399
        '
        'status
        '
        Me.status.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.Location = New System.Drawing.Point(598, 454)
        Me.status.Margin = New System.Windows.Forms.Padding(4)
        Me.status.Multiline = True
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(252, 27)
        Me.status.TabIndex = 404
        '
        'action
        '
        Me.action.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.action.Location = New System.Drawing.Point(150, 454)
        Me.action.Margin = New System.Windows.Forms.Padding(4)
        Me.action.Multiline = True
        Me.action.Name = "action"
        Me.action.Size = New System.Drawing.Size(306, 27)
        Me.action.TabIndex = 403
        '
        'userAgent
        '
        Me.userAgent.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userAgent.Location = New System.Drawing.Point(598, 412)
        Me.userAgent.Margin = New System.Windows.Forms.Padding(4)
        Me.userAgent.Multiline = True
        Me.userAgent.Name = "userAgent"
        Me.userAgent.Size = New System.Drawing.Size(252, 27)
        Me.userAgent.TabIndex = 402
        '
        'ipAddress
        '
        Me.ipAddress.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ipAddress.Location = New System.Drawing.Point(598, 371)
        Me.ipAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.ipAddress.Multiline = True
        Me.ipAddress.Name = "ipAddress"
        Me.ipAddress.Size = New System.Drawing.Size(252, 27)
        Me.ipAddress.TabIndex = 401
        '
        'recordId
        '
        Me.recordId.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.recordId.Location = New System.Drawing.Point(154, 412)
        Me.recordId.Margin = New System.Windows.Forms.Padding(4)
        Me.recordId.Multiline = True
        Me.recordId.Name = "recordId"
        Me.recordId.Size = New System.Drawing.Size(302, 27)
        Me.recordId.TabIndex = 400
        '
        'tableName
        '
        Me.tableName.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tableName.Location = New System.Drawing.Point(154, 371)
        Me.tableName.Margin = New System.Windows.Forms.Padding(4)
        Me.tableName.Multiline = True
        Me.tableName.Name = "tableName"
        Me.tableName.Size = New System.Drawing.Size(302, 27)
        Me.tableName.TabIndex = 399
        '
        'logId
        '
        Me.logId.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logId.Location = New System.Drawing.Point(157, 159)
        Me.logId.Margin = New System.Windows.Forms.Padding(4)
        Me.logId.Multiline = True
        Me.logId.Name = "logId"
        Me.logId.Size = New System.Drawing.Size(299, 27)
        Me.logId.TabIndex = 398
        '
        'userId
        '
        Me.userId.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userId.Location = New System.Drawing.Point(157, 124)
        Me.userId.Margin = New System.Windows.Forms.Padding(4)
        Me.userId.Multiline = True
        Me.userId.Name = "userId"
        Me.userId.Size = New System.Drawing.Size(299, 27)
        Me.userId.TabIndex = 397
        '
        'user
        '
        Me.user.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.user.Location = New System.Drawing.Point(157, 89)
        Me.user.Margin = New System.Windows.Forms.Padding(4)
        Me.user.Multiline = True
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(299, 27)
        Me.user.TabIndex = 396
        '
        'description
        '
        Me.description.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(68, 242)
        Me.description.Margin = New System.Windows.Forms.Padding(4)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(782, 95)
        Me.description.TabIndex = 395
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(506, 417)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 22)
        Me.Label24.TabIndex = 394
        Me.Label24.Text = "User Agent :"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(68, 216)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(86, 22)
        Me.Label25.TabIndex = 384
        Me.Label25.Text = "Description :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(508, 376)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 22)
        Me.Label26.TabIndex = 392
        Me.Label26.Text = "IP Address :"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(64, 164)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(53, 22)
        Me.Label27.TabIndex = 380
        Me.Label27.Text = "Log ID :"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker5
        '
        Me.DateTimePicker5.Location = New System.Drawing.Point(478, 20)
        Me.DateTimePicker5.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker5.Name = "DateTimePicker5"
        Me.DateTimePicker5.Size = New System.Drawing.Size(247, 22)
        Me.DateTimePicker5.TabIndex = 373
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(440, 20)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 22)
        Me.Label28.TabIndex = 372
        Me.Label28.Text = "To :"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(508, 459)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 22)
        Me.Label29.TabIndex = 377
        Me.Label29.Text = "Status :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(74, 459)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(56, 22)
        Me.Label30.TabIndex = 356
        Me.Label30.Text = "Action :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(70, 417)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 22)
        Me.Label31.TabIndex = 390
        Me.Label31.Text = "Record ID :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker6
        '
        Me.DateTimePicker6.Location = New System.Drawing.Point(189, 18)
        Me.DateTimePicker6.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker6.Name = "DateTimePicker6"
        Me.DateTimePicker6.Size = New System.Drawing.Size(246, 22)
        Me.DateTimePicker6.TabIndex = 355
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(70, 374)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(87, 22)
        Me.Label32.TabIndex = 385
        Me.Label32.Text = "table Name :"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(64, 94)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(43, 22)
        Me.Label33.TabIndex = 56
        Me.Label33.Text = "User :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(139, 21)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(48, 22)
        Me.Label34.TabIndex = 38
        Me.Label34.Text = "From :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(64, 129)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(58, 22)
        Me.Label35.TabIndex = 381
        Me.Label35.Text = "User ID :"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(150, 129)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(299, 27)
        Me.TextBox5.TabIndex = 398
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(150, 94)
        Me.TextBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(299, 27)
        Me.TextBox6.TabIndex = 397
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(150, 59)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(299, 27)
        Me.TextBox7.TabIndex = 396
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(70, 197)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(753, 95)
        Me.TextBox8.TabIndex = 395
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(474, 376)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 22)
        Me.Label6.TabIndex = 394
        Me.Label6.Text = "User Agent :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(65, 171)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 22)
        Me.Label11.TabIndex = 384
        Me.Label11.Text = "Description :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(474, 335)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 22)
        Me.Label14.TabIndex = 392
        Me.Label14.Text = "IP Adress :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(65, 134)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 22)
        Me.Label15.TabIndex = 380
        Me.Label15.Text = "Log ID :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(404, 20)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(247, 22)
        Me.DateTimePicker2.TabIndex = 373
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(366, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 22)
        Me.Label16.TabIndex = 372
        Me.Label16.Text = "To :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(83, 504)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 22)
        Me.Label17.TabIndex = 377
        Me.Label17.Text = "Status :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(83, 459)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 22)
        Me.Label18.TabIndex = 356
        Me.Label18.Text = "Action :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(65, 376)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 22)
        Me.Label19.TabIndex = 390
        Me.Label19.Text = "Record ID :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Location = New System.Drawing.Point(115, 18)
        Me.DateTimePicker4.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(246, 22)
        Me.DateTimePicker4.TabIndex = 355
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(66, 322)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 22)
        Me.Label20.TabIndex = 385
        Me.Label20.Text = "table Name :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(65, 64)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 22)
        Me.Label21.TabIndex = 56
        Me.Label21.Text = "User :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(65, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 22)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "From :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(65, 99)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 22)
        Me.Label23.TabIndex = 381
        Me.Label23.Text = "User ID :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(150, 129)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(299, 27)
        Me.TextBox4.TabIndex = 398
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(150, 94)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(299, 27)
        Me.TextBox2.TabIndex = 397
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(150, 59)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(299, 27)
        Me.TextBox1.TabIndex = 396
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(70, 197)
        Me.TextBox11.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox11.Multiline = True
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(753, 95)
        Me.TextBox11.TabIndex = 395
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(474, 376)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 22)
        Me.Label13.TabIndex = 394
        Me.Label13.Text = "User Agent :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(65, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 22)
        Me.Label5.TabIndex = 384
        Me.Label5.Text = "Description :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(474, 335)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 22)
        Me.Label12.TabIndex = 392
        Me.Label12.Text = "IP Adress :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(65, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 22)
        Me.Label3.TabIndex = 380
        Me.Label3.Text = "Log ID :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(404, 20)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(247, 22)
        Me.DateTimePicker1.TabIndex = 373
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(366, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 22)
        Me.Label7.TabIndex = 372
        Me.Label7.Text = "To :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(83, 504)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 22)
        Me.Label10.TabIndex = 377
        Me.Label10.Text = "Status :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 459)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 22)
        Me.Label1.TabIndex = 356
        Me.Label1.Text = "Action :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(65, 376)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 22)
        Me.Label9.TabIndex = 390
        Me.Label9.Text = "Record ID :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(115, 18)
        Me.DateTimePicker3.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(246, 22)
        Me.DateTimePicker3.TabIndex = 355
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(66, 322)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 22)
        Me.Label4.TabIndex = 385
        Me.Label4.Text = "table Name :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(65, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 22)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "User :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(65, 21)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(48, 22)
        Me.lblName.TabIndex = 38
        Me.lblName.Text = "From :"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(65, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 22)
        Me.Label2.TabIndex = 381
        Me.Label2.Text = "User ID :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(1111, 869)
        Me.RoundedButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(153, 34)
        Me.RoundedButton1.TabIndex = 368
        Me.RoundedButton1.Text = "Generate PDF File"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'btnCSV
        '
        Me.btnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnCSV.CornerRadius = 15
        Me.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCSV.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCSV.Location = New System.Drawing.Point(950, 869)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(153, 34)
        Me.btnCSV.TabIndex = 367
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(830, 869)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 34)
        Me.Button2.TabIndex = 366
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'AuditReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1569, 942)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.btn_Back)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AuditReport"
        Me.Text = "AuditReport"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Back As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblPropertyCard As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents RoundedButton1 As Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As Resources.Controls.RoundedButton
    Friend WithEvents Button2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents logId As TextBox
    Friend WithEvents userId As TextBox
    Friend WithEvents user As TextBox
    Friend WithEvents description As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents DateTimePicker5 As DateTimePicker
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents DateTimePicker6 As DateTimePicker
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents DateTimePicker4 As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents status As TextBox
    Friend WithEvents action As TextBox
    Friend WithEvents userAgent As TextBox
    Friend WithEvents ipAddress As TextBox
    Friend WithEvents recordId As TextBox
    Friend WithEvents tableName As TextBox
End Class
