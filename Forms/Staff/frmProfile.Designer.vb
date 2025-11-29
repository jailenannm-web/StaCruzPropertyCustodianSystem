Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProfile
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
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Edit = New System.Windows.Forms.Button()
        Me.lb_UserID = New System.Windows.Forms.Label()
        Me.lb_Suffix = New System.Windows.Forms.Label()
        Me.lb_MiddleName = New System.Windows.Forms.Label()
        Me.lb_Employee = New System.Windows.Forms.Label()
        Me.lb_Position = New System.Windows.Forms.Label()
        Me.lb_Department = New System.Windows.Forms.Label()
        Me.lb_FirstName = New System.Windows.Forms.Label()
        Me.lb_LastName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lb_Password = New System.Windows.Forms.Label()
        Me.lb_Email = New System.Windows.Forms.Label()
        Me.lb_Municipality = New System.Windows.Forms.Label()
        Me.lb_UserName = New System.Windows.Forms.Label()
        Me.lb_Province = New System.Windows.Forms.Label()
        Me.lb_ContactNumber = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(582, 959)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(147, 49)
        Me.btn_Cancel.TabIndex = 60
        Me.btn_Cancel.Text = "Update"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Edit.FlatAppearance.BorderSize = 0
        Me.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Edit.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Edit.ForeColor = System.Drawing.Color.Transparent
        Me.btn_Edit.Location = New System.Drawing.Point(913, 958)
        Me.btn_Edit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(147, 49)
        Me.btn_Edit.TabIndex = 61
        Me.btn_Edit.Text = "Edit"
        Me.btn_Edit.UseVisualStyleBackColor = False
        '
        'lb_UserID
        '
        Me.lb_UserID.BackColor = System.Drawing.Color.Transparent
        Me.lb_UserID.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_UserID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_UserID.Location = New System.Drawing.Point(378, 145)
        Me.lb_UserID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_UserID.Name = "lb_UserID"
        Me.lb_UserID.Size = New System.Drawing.Size(219, 22)
        Me.lb_UserID.TabIndex = 91
        Me.lb_UserID.Text = "User I.D"
        '
        'lb_Suffix
        '
        Me.lb_Suffix.BackColor = System.Drawing.Color.Transparent
        Me.lb_Suffix.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Suffix.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Suffix.Location = New System.Drawing.Point(378, 573)
        Me.lb_Suffix.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Suffix.Name = "lb_Suffix"
        Me.lb_Suffix.Size = New System.Drawing.Size(157, 22)
        Me.lb_Suffix.TabIndex = 92
        Me.lb_Suffix.Text = "Suffix"
        '
        'lb_MiddleName
        '
        Me.lb_MiddleName.BackColor = System.Drawing.Color.Transparent
        Me.lb_MiddleName.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_MiddleName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_MiddleName.Location = New System.Drawing.Point(378, 359)
        Me.lb_MiddleName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_MiddleName.Name = "lb_MiddleName"
        Me.lb_MiddleName.Size = New System.Drawing.Size(233, 21)
        Me.lb_MiddleName.TabIndex = 93
        Me.lb_MiddleName.Text = "Middle Name"
        '
        'lb_Employee
        '
        Me.lb_Employee.BackColor = System.Drawing.Color.Transparent
        Me.lb_Employee.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Employee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Employee.Location = New System.Drawing.Point(378, 888)
        Me.lb_Employee.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Employee.Name = "lb_Employee"
        Me.lb_Employee.Size = New System.Drawing.Size(261, 22)
        Me.lb_Employee.TabIndex = 98
        Me.lb_Employee.Text = "Employee I.D"
        '
        'lb_Position
        '
        Me.lb_Position.BackColor = System.Drawing.Color.Transparent
        Me.lb_Position.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Position.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Position.Location = New System.Drawing.Point(378, 684)
        Me.lb_Position.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Position.Name = "lb_Position"
        Me.lb_Position.Size = New System.Drawing.Size(254, 20)
        Me.lb_Position.TabIndex = 94
        Me.lb_Position.Text = "Position"
        '
        'lb_Department
        '
        Me.lb_Department.BackColor = System.Drawing.Color.Transparent
        Me.lb_Department.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Department.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Department.Location = New System.Drawing.Point(378, 781)
        Me.lb_Department.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Department.Name = "lb_Department"
        Me.lb_Department.Size = New System.Drawing.Size(254, 22)
        Me.lb_Department.TabIndex = 95
        Me.lb_Department.Text = "Department I.D"
        '
        'lb_FirstName
        '
        Me.lb_FirstName.BackColor = System.Drawing.Color.Transparent
        Me.lb_FirstName.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_FirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_FirstName.Location = New System.Drawing.Point(378, 251)
        Me.lb_FirstName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_FirstName.Name = "lb_FirstName"
        Me.lb_FirstName.Size = New System.Drawing.Size(233, 22)
        Me.lb_FirstName.TabIndex = 96
        Me.lb_FirstName.Text = "First Name"
        '
        'lb_LastName
        '
        Me.lb_LastName.BackColor = System.Drawing.Color.Transparent
        Me.lb_LastName.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_LastName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_LastName.Location = New System.Drawing.Point(378, 466)
        Me.lb_LastName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_LastName.Name = "lb_LastName"
        Me.lb_LastName.Size = New System.Drawing.Size(181, 22)
        Me.lb_LastName.TabIndex = 97
        Me.lb_LastName.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(365, 121)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(364, 61)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "User I.D"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(365, 545)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(364, 61)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Suffix"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(365, 335)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(364, 61)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Middle Name"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(365, 861)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(364, 61)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Employee I.D"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(365, 652)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(364, 61)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "Position"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(365, 757)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(364, 61)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Department I.D"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(365, 227)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(364, 61)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "First Name"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(365, 442)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(364, 61)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Last Name"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(936, 786)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(177, 32)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "Barangay"
        '
        'lb_Password
        '
        Me.lb_Password.BackColor = System.Drawing.Color.Transparent
        Me.lb_Password.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Password.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Password.Location = New System.Drawing.Point(936, 466)
        Me.lb_Password.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Password.Name = "lb_Password"
        Me.lb_Password.Size = New System.Drawing.Size(203, 22)
        Me.lb_Password.TabIndex = 112
        Me.lb_Password.Text = "Password"
        '
        'lb_Email
        '
        Me.lb_Email.BackColor = System.Drawing.Color.Transparent
        Me.lb_Email.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Email.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Email.Location = New System.Drawing.Point(936, 251)
        Me.lb_Email.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Email.Name = "lb_Email"
        Me.lb_Email.Size = New System.Drawing.Size(177, 22)
        Me.lb_Email.TabIndex = 111
        Me.lb_Email.Text = "Email"
        '
        'lb_Municipality
        '
        Me.lb_Municipality.BackColor = System.Drawing.Color.Transparent
        Me.lb_Municipality.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Municipality.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Municipality.Location = New System.Drawing.Point(936, 684)
        Me.lb_Municipality.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Municipality.Name = "lb_Municipality"
        Me.lb_Municipality.Size = New System.Drawing.Size(248, 22)
        Me.lb_Municipality.TabIndex = 110
        Me.lb_Municipality.Text = "Municipality"
        '
        'lb_UserName
        '
        Me.lb_UserName.BackColor = System.Drawing.Color.Transparent
        Me.lb_UserName.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_UserName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_UserName.Location = New System.Drawing.Point(936, 359)
        Me.lb_UserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_UserName.Name = "lb_UserName"
        Me.lb_UserName.Size = New System.Drawing.Size(248, 22)
        Me.lb_UserName.TabIndex = 109
        Me.lb_UserName.Text = "User name"
        '
        'lb_Province
        '
        Me.lb_Province.BackColor = System.Drawing.Color.Transparent
        Me.lb_Province.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Province.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_Province.Location = New System.Drawing.Point(936, 573)
        Me.lb_Province.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Province.Name = "lb_Province"
        Me.lb_Province.Size = New System.Drawing.Size(159, 22)
        Me.lb_Province.TabIndex = 108
        Me.lb_Province.Text = "Province"
        '
        'lb_ContactNumber
        '
        Me.lb_ContactNumber.BackColor = System.Drawing.Color.Transparent
        Me.lb_ContactNumber.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_ContactNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lb_ContactNumber.Location = New System.Drawing.Point(936, 145)
        Me.lb_ContactNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_ContactNumber.Name = "lb_ContactNumber"
        Me.lb_ContactNumber.Size = New System.Drawing.Size(288, 22)
        Me.lb_ContactNumber.TabIndex = 107
        Me.lb_ContactNumber.Text = "Contact Number"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(928, 757)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(363, 71)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Barangay"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(928, 442)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(363, 61)
        Me.Label17.TabIndex = 119
        Me.Label17.Text = "Password"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(928, 227)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(363, 61)
        Me.Label18.TabIndex = 118
        Me.Label18.Text = "Email"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(928, 652)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(363, 61)
        Me.Label19.TabIndex = 117
        Me.Label19.Text = "Municipality"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(928, 334)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(363, 61)
        Me.Label20.TabIndex = 116
        Me.Label20.Text = "User name"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(928, 545)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(363, 61)
        Me.Label21.TabIndex = 115
        Me.Label21.Text = "Province"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(928, 121)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(363, 61)
        Me.Label22.TabIndex = 114
        Me.Label22.Text = "Contact Number"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(760, 24)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(147, 45)
        Me.Label23.TabIndex = 121
        Me.Label23.Text = "Profile"
        '
        'frmProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1795, 1058)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lb_Password)
        Me.Controls.Add(Me.lb_Email)
        Me.Controls.Add(Me.lb_Municipality)
        Me.Controls.Add(Me.lb_UserName)
        Me.Controls.Add(Me.lb_Province)
        Me.Controls.Add(Me.lb_ContactNumber)
        Me.Controls.Add(Me.lb_UserID)
        Me.Controls.Add(Me.lb_Suffix)
        Me.Controls.Add(Me.lb_MiddleName)
        Me.Controls.Add(Me.lb_Employee)
        Me.Controls.Add(Me.lb_Position)
        Me.Controls.Add(Me.lb_Department)
        Me.Controls.Add(Me.lb_FirstName)
        Me.Controls.Add(Me.lb_LastName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Edit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmProfile"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_Edit As Button
    Friend WithEvents lb_UserID As Label
    Friend WithEvents lb_Suffix As Label
    Friend WithEvents lb_MiddleName As Label
    Friend WithEvents lb_Employee As Label
    Friend WithEvents lb_Position As Label
    Friend WithEvents lb_Department As Label
    Friend WithEvents lb_FirstName As Label
    Friend WithEvents lb_LastName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lb_Password As Label
    Friend WithEvents lb_Email As Label
    Friend WithEvents lb_Municipality As Label
    Friend WithEvents lb_UserName As Label
    Friend WithEvents lb_Province As Label
    Friend WithEvents lb_ContactNumber As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
End Class
