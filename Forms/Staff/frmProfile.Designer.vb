Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProfile
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.txtBarangay = New System.Windows.Forms.TextBox()
        Me.lblBarangay = New System.Windows.Forms.Label()
        Me.txtMunicipality = New System.Windows.Forms.TextBox()
        Me.lblMunicipality = New System.Windows.Forms.Label()
        Me.txtProvince = New System.Windows.Forms.TextBox()
        Me.lblProvince = New System.Windows.Forms.Label()
        Me.lblAddressInfo = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblAccountInfo = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtContactNumber = New System.Windows.Forms.TextBox()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.lblContactInfo = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtEmployeeId = New System.Windows.Forms.TextBox()
        Me.lblEmployeeId = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblWorkInfo = New System.Windows.Forms.Label()
        Me.txtSuffix = New System.Windows.Forms.TextBox()
        Me.lblSuffix = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.lblPersonalInfo = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.txtBarangay)
        Me.pnlMain.Controls.Add(Me.lblBarangay)
        Me.pnlMain.Controls.Add(Me.txtMunicipality)
        Me.pnlMain.Controls.Add(Me.lblMunicipality)
        Me.pnlMain.Controls.Add(Me.txtProvince)
        Me.pnlMain.Controls.Add(Me.lblProvince)
        Me.pnlMain.Controls.Add(Me.lblAddressInfo)
        Me.pnlMain.Controls.Add(Me.txtPassword)
        Me.pnlMain.Controls.Add(Me.lblPassword)
        Me.pnlMain.Controls.Add(Me.txtUsername)
        Me.pnlMain.Controls.Add(Me.lblUsername)
        Me.pnlMain.Controls.Add(Me.lblAccountInfo)
        Me.pnlMain.Controls.Add(Me.txtEmail)
        Me.pnlMain.Controls.Add(Me.lblEmail)
        Me.pnlMain.Controls.Add(Me.txtContactNumber)
        Me.pnlMain.Controls.Add(Me.lblContactNumber)
        Me.pnlMain.Controls.Add(Me.lblContactInfo)
        Me.pnlMain.Controls.Add(Me.txtDepartment)
        Me.pnlMain.Controls.Add(Me.lblDepartment)
        Me.pnlMain.Controls.Add(Me.txtEmployeeId)
        Me.pnlMain.Controls.Add(Me.lblEmployeeId)
        Me.pnlMain.Controls.Add(Me.txtPosition)
        Me.pnlMain.Controls.Add(Me.lblPosition)
        Me.pnlMain.Controls.Add(Me.lblWorkInfo)
        Me.pnlMain.Controls.Add(Me.txtSuffix)
        Me.pnlMain.Controls.Add(Me.lblSuffix)
        Me.pnlMain.Controls.Add(Me.txtLastName)
        Me.pnlMain.Controls.Add(Me.lblLastName)
        Me.pnlMain.Controls.Add(Me.txtMiddleName)
        Me.pnlMain.Controls.Add(Me.lblMiddleName)
        Me.pnlMain.Controls.Add(Me.txtFirstName)
        Me.pnlMain.Controls.Add(Me.lblFirstName)
        Me.pnlMain.Controls.Add(Me.txtUserId)
        Me.pnlMain.Controls.Add(Me.lblUserId)
        Me.pnlMain.Controls.Add(Me.lblPersonalInfo)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Controls.Add(Me.btnEdit)
        Me.pnlMain.Controls.Add(Me.lblTitle)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1942, 1125)
        Me.pnlMain.TabIndex = 0
        '
        'txtBarangay
        '
        Me.txtBarangay.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtBarangay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarangay.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtBarangay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtBarangay.Location = New System.Drawing.Point(1121, 667)
        Me.txtBarangay.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBarangay.Name = "txtBarangay"
        Me.txtBarangay.ReadOnly = True
        Me.txtBarangay.Size = New System.Drawing.Size(418, 32)
        Me.txtBarangay.TabIndex = 37
        '
        'lblBarangay
        '
        Me.lblBarangay.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBarangay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblBarangay.Location = New System.Drawing.Point(908, 669)
        Me.lblBarangay.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBarangay.Name = "lblBarangay"
        Me.lblBarangay.Size = New System.Drawing.Size(188, 31)
        Me.lblBarangay.TabIndex = 36
        Me.lblBarangay.Text = "Barangay:"
        Me.lblBarangay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMunicipality
        '
        Me.txtMunicipality.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMunicipality.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtMunicipality.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtMunicipality.Location = New System.Drawing.Point(1121, 617)
        Me.txtMunicipality.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMunicipality.Name = "txtMunicipality"
        Me.txtMunicipality.ReadOnly = True
        Me.txtMunicipality.Size = New System.Drawing.Size(418, 32)
        Me.txtMunicipality.TabIndex = 35
        '
        'lblMunicipality
        '
        Me.lblMunicipality.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMunicipality.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblMunicipality.Location = New System.Drawing.Point(908, 619)
        Me.lblMunicipality.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMunicipality.Name = "lblMunicipality"
        Me.lblMunicipality.Size = New System.Drawing.Size(188, 31)
        Me.lblMunicipality.TabIndex = 34
        Me.lblMunicipality.Text = "Municipality:"
        Me.lblMunicipality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProvince
        '
        Me.txtProvince.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProvince.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtProvince.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtProvince.Location = New System.Drawing.Point(1121, 567)
        Me.txtProvince.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.ReadOnly = True
        Me.txtProvince.Size = New System.Drawing.Size(418, 32)
        Me.txtProvince.TabIndex = 33
        '
        'lblProvince
        '
        Me.lblProvince.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblProvince.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblProvince.Location = New System.Drawing.Point(908, 569)
        Me.lblProvince.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProvince.Name = "lblProvince"
        Me.lblProvince.Size = New System.Drawing.Size(188, 31)
        Me.lblProvince.TabIndex = 32
        Me.lblProvince.Text = "Province:"
        Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddressInfo
        '
        Me.lblAddressInfo.AutoSize = True
        Me.lblAddressInfo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblAddressInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblAddressInfo.Location = New System.Drawing.Point(902, 513)
        Me.lblAddressInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAddressInfo.Name = "lblAddressInfo"
        Me.lblAddressInfo.Size = New System.Drawing.Size(251, 32)
        Me.lblAddressInfo.TabIndex = 31
        Me.lblAddressInfo.Text = "Address Information"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(1121, 442)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.ReadOnly = True
        Me.txtPassword.Size = New System.Drawing.Size(418, 32)
        Me.txtPassword.TabIndex = 30
        '
        'lblPassword
        '
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblPassword.Location = New System.Drawing.Point(908, 444)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(188, 31)
        Me.lblPassword.TabIndex = 29
        Me.lblPassword.Text = "Password:"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtUsername.Location = New System.Drawing.Point(1121, 392)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(418, 32)
        Me.txtUsername.TabIndex = 28
        '
        'lblUsername
        '
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblUsername.Location = New System.Drawing.Point(908, 394)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(188, 31)
        Me.lblUsername.TabIndex = 27
        Me.lblUsername.Text = "Username:"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAccountInfo
        '
        Me.lblAccountInfo.AutoSize = True
        Me.lblAccountInfo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblAccountInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblAccountInfo.Location = New System.Drawing.Point(902, 338)
        Me.lblAccountInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAccountInfo.Name = "lblAccountInfo"
        Me.lblAccountInfo.Size = New System.Drawing.Size(254, 32)
        Me.lblAccountInfo.TabIndex = 26
        Me.lblAccountInfo.Text = "Account Information"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtEmail.Location = New System.Drawing.Point(1121, 267)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(418, 32)
        Me.txtEmail.TabIndex = 25
        '
        'lblEmail
        '
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblEmail.Location = New System.Drawing.Point(908, 269)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(188, 31)
        Me.lblEmail.TabIndex = 24
        Me.lblEmail.Text = "Email:"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactNumber
        '
        Me.txtContactNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactNumber.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtContactNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtContactNumber.Location = New System.Drawing.Point(1121, 217)
        Me.txtContactNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.ReadOnly = True
        Me.txtContactNumber.Size = New System.Drawing.Size(418, 32)
        Me.txtContactNumber.TabIndex = 23
        '
        'lblContactNumber
        '
        Me.lblContactNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblContactNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblContactNumber.Location = New System.Drawing.Point(908, 219)
        Me.lblContactNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Size = New System.Drawing.Size(188, 31)
        Me.lblContactNumber.TabIndex = 22
        Me.lblContactNumber.Text = "Contact Number:"
        Me.lblContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContactInfo
        '
        Me.lblContactInfo.AutoSize = True
        Me.lblContactInfo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblContactInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblContactInfo.Location = New System.Drawing.Point(902, 163)
        Me.lblContactInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblContactInfo.Name = "lblContactInfo"
        Me.lblContactInfo.Size = New System.Drawing.Size(247, 32)
        Me.lblContactInfo.TabIndex = 21
        Me.lblContactInfo.Text = "Contact Information"
        '
        'txtDepartment
        '
        Me.txtDepartment.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartment.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtDepartment.Location = New System.Drawing.Point(264, 642)
        Me.txtDepartment.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.Size = New System.Drawing.Size(562, 32)
        Me.txtDepartment.TabIndex = 20
        '
        'lblDepartment
        '
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblDepartment.Location = New System.Drawing.Point(27, 644)
        Me.lblDepartment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(225, 31)
        Me.lblDepartment.TabIndex = 19
        Me.lblDepartment.Text = "Department:"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtEmployeeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeId.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtEmployeeId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtEmployeeId.Location = New System.Drawing.Point(264, 592)
        Me.txtEmployeeId.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.ReadOnly = True
        Me.txtEmployeeId.Size = New System.Drawing.Size(562, 32)
        Me.txtEmployeeId.TabIndex = 18
        '
        'lblEmployeeId
        '
        Me.lblEmployeeId.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblEmployeeId.Location = New System.Drawing.Point(27, 594)
        Me.lblEmployeeId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeId.Name = "lblEmployeeId"
        Me.lblEmployeeId.Size = New System.Drawing.Size(225, 31)
        Me.lblEmployeeId.TabIndex = 17
        Me.lblEmployeeId.Text = "Employee ID:"
        Me.lblEmployeeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPosition
        '
        Me.txtPosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosition.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtPosition.Location = New System.Drawing.Point(264, 542)
        Me.txtPosition.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.ReadOnly = True
        Me.txtPosition.Size = New System.Drawing.Size(562, 32)
        Me.txtPosition.TabIndex = 16
        '
        'lblPosition
        '
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblPosition.Location = New System.Drawing.Point(27, 544)
        Me.lblPosition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(225, 31)
        Me.lblPosition.TabIndex = 15
        Me.lblPosition.Text = "Position:"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkInfo
        '
        Me.lblWorkInfo.AutoSize = True
        Me.lblWorkInfo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblWorkInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblWorkInfo.Location = New System.Drawing.Point(21, 488)
        Me.lblWorkInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWorkInfo.Name = "lblWorkInfo"
        Me.lblWorkInfo.Size = New System.Drawing.Size(220, 32)
        Me.lblWorkInfo.TabIndex = 14
        Me.lblWorkInfo.Text = "Work Information"
        '
        'txtSuffix
        '
        Me.txtSuffix.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuffix.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtSuffix.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtSuffix.Location = New System.Drawing.Point(264, 417)
        Me.txtSuffix.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.ReadOnly = True
        Me.txtSuffix.Size = New System.Drawing.Size(562, 32)
        Me.txtSuffix.TabIndex = 13
        '
        'lblSuffix
        '
        Me.lblSuffix.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSuffix.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblSuffix.Location = New System.Drawing.Point(27, 419)
        Me.lblSuffix.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSuffix.Name = "lblSuffix"
        Me.lblSuffix.Size = New System.Drawing.Size(225, 31)
        Me.lblSuffix.TabIndex = 12
        Me.lblSuffix.Text = "Suffix:"
        Me.lblSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtLastName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtLastName.Location = New System.Drawing.Point(264, 367)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(562, 32)
        Me.txtLastName.TabIndex = 11
        '
        'lblLastName
        '
        Me.lblLastName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblLastName.Location = New System.Drawing.Point(27, 369)
        Me.lblLastName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(225, 31)
        Me.lblLastName.TabIndex = 10
        Me.lblLastName.Text = "Last Name:"
        Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMiddleName
        '
        Me.txtMiddleName.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMiddleName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtMiddleName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtMiddleName.Location = New System.Drawing.Point(264, 317)
        Me.txtMiddleName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.ReadOnly = True
        Me.txtMiddleName.Size = New System.Drawing.Size(562, 32)
        Me.txtMiddleName.TabIndex = 9
        '
        'lblMiddleName
        '
        Me.lblMiddleName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMiddleName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblMiddleName.Location = New System.Drawing.Point(27, 319)
        Me.lblMiddleName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(225, 31)
        Me.lblMiddleName.TabIndex = 8
        Me.lblMiddleName.Text = "Middle Name:"
        Me.lblMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFirstName
        '
        Me.txtFirstName.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtFirstName.Location = New System.Drawing.Point(264, 267)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(562, 32)
        Me.txtFirstName.TabIndex = 7
        '
        'lblFirstName
        '
        Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblFirstName.Location = New System.Drawing.Point(27, 269)
        Me.lblFirstName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(225, 31)
        Me.lblFirstName.TabIndex = 6
        Me.lblFirstName.Text = "First Name:"
        Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUserId
        '
        Me.txtUserId.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserId.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtUserId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtUserId.Location = New System.Drawing.Point(264, 217)
        Me.txtUserId.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.ReadOnly = True
        Me.txtUserId.Size = New System.Drawing.Size(562, 32)
        Me.txtUserId.TabIndex = 5
        '
        'lblUserId
        '
        Me.lblUserId.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.lblUserId.Location = New System.Drawing.Point(27, 219)
        Me.lblUserId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(225, 31)
        Me.lblUserId.TabIndex = 4
        Me.lblUserId.Text = "User ID:"
        Me.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPersonalInfo
        '
        Me.lblPersonalInfo.AutoSize = True
        Me.lblPersonalInfo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPersonalInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblPersonalInfo.Location = New System.Drawing.Point(21, 163)
        Me.lblPersonalInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPersonalInfo.Name = "lblPersonalInfo"
        Me.lblPersonalInfo.Size = New System.Drawing.Size(257, 32)
        Me.lblPersonalInfo.TabIndex = 3
        Me.lblPersonalInfo.Text = "Personal Information"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(1114, 63)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(200, 56)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(1340, 63)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(200, 56)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit Profile"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(14, 51)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(172, 62)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Profile"
        '
        'frmProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1942, 1125)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Profile"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblPersonalInfo As Label
    Friend WithEvents lblUserId As Label
    Friend WithEvents txtUserId As TextBox
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblMiddleName As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblSuffix As Label
    Friend WithEvents txtSuffix As TextBox
    Friend WithEvents lblWorkInfo As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents txtPosition As TextBox
    Friend WithEvents lblEmployeeId As Label
    Friend WithEvents txtEmployeeId As TextBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents lblContactInfo As Label
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblAccountInfo As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblAddressInfo As Label
    Friend WithEvents lblProvince As Label
    Friend WithEvents txtProvince As TextBox
    Friend WithEvents lblMunicipality As Label
    Friend WithEvents txtMunicipality As TextBox
    Friend WithEvents lblBarangay As Label
    Friend WithEvents txtBarangay As TextBox
End Class
