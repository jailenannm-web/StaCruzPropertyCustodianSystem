Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAAddDepartmentManagement
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
        Me.lblDepartmentManagement = New System.Windows.Forms.Label()
        Me.lblDepartmentName = New System.Windows.Forms.Label()
        Me.lblHeadofDepartment = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblNoofEmployees = New System.Windows.Forms.Label()
        Me.lblDepartmentCode = New System.Windows.Forms.Label()
        Me.txtDepName = New System.Windows.Forms.TextBox()
        Me.txtHeadofDep = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtNoofEmployees = New System.Windows.Forms.TextBox()
        Me.txtDepCode = New System.Windows.Forms.TextBox()
        Me.txtUpdateAt = New System.Windows.Forms.TextBox()
        Me.txtCreatedAt = New System.Windows.Forms.TextBox()
        Me.txtBudgetAllocation = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtParentDep = New System.Windows.Forms.TextBox()
        Me.txtEstablishedDate = New System.Windows.Forms.TextBox()
        Me.txtOfficeHour = New System.Windows.Forms.TextBox()
        Me.lblUpdateAt = New System.Windows.Forms.Label()
        Me.lblCreatedAt = New System.Windows.Forms.Label()
        Me.lbBudgetAllocation = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblParentDepartment = New System.Windows.Forms.Label()
        Me.lblEstablishedDate = New System.Windows.Forms.Label()
        Me.lblOfficeHour = New System.Windows.Forms.Label()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnBack = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.SuspendLayout()
        '
        'lblDepartmentManagement
        '
        Me.lblDepartmentManagement.AutoSize = True
        Me.lblDepartmentManagement.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentManagement.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDepartmentManagement.Location = New System.Drawing.Point(500, 68)
        Me.lblDepartmentManagement.Name = "lblDepartmentManagement"
        Me.lblDepartmentManagement.Size = New System.Drawing.Size(346, 32)
        Me.lblDepartmentManagement.TabIndex = 49
        Me.lblDepartmentManagement.Text = "Department Management"
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.AutoSize = True
        Me.lblDepartmentName.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDepartmentName.Location = New System.Drawing.Point(166, 161)
        Me.lblDepartmentName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(174, 23)
        Me.lblDepartmentName.TabIndex = 50
        Me.lblDepartmentName.Text = "Department Name"
        '
        'lblHeadofDepartment
        '
        Me.lblHeadofDepartment.AutoSize = True
        Me.lblHeadofDepartment.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadofDepartment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblHeadofDepartment.Location = New System.Drawing.Point(166, 221)
        Me.lblHeadofDepartment.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblHeadofDepartment.Name = "lblHeadofDepartment"
        Me.lblHeadofDepartment.Size = New System.Drawing.Size(193, 23)
        Me.lblHeadofDepartment.TabIndex = 51
        Me.lblHeadofDepartment.Text = "Head of Department"
        '
        'lblContactNumber
        '
        Me.lblContactNumber.AutoSize = True
        Me.lblContactNumber.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblContactNumber.Location = New System.Drawing.Point(166, 281)
        Me.lblContactNumber.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Size = New System.Drawing.Size(158, 23)
        Me.lblContactNumber.TabIndex = 52
        Me.lblContactNumber.Text = "Contact Number"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEmail.Location = New System.Drawing.Point(166, 341)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(59, 23)
        Me.lblEmail.TabIndex = 53
        Me.lblEmail.Text = "Email"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblLocation.Location = New System.Drawing.Point(166, 401)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(88, 23)
        Me.lblLocation.TabIndex = 54
        Me.lblLocation.Text = "Location"
        '
        'lblNoofEmployees
        '
        Me.lblNoofEmployees.AutoSize = True
        Me.lblNoofEmployees.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoofEmployees.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNoofEmployees.Location = New System.Drawing.Point(166, 461)
        Me.lblNoofEmployees.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblNoofEmployees.Name = "lblNoofEmployees"
        Me.lblNoofEmployees.Size = New System.Drawing.Size(161, 23)
        Me.lblNoofEmployees.TabIndex = 55
        Me.lblNoofEmployees.Text = "No of Employees"
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.AutoSize = True
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDepartmentCode.Location = New System.Drawing.Point(166, 521)
        Me.lblDepartmentCode.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(168, 23)
        Me.lblDepartmentCode.TabIndex = 56
        Me.lblDepartmentCode.Text = "Department Code"
        '
        'txtDepName
        '
        Me.txtDepName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtDepName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDepName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepName.Location = New System.Drawing.Point(389, 163)
        Me.txtDepName.Name = "txtDepName"
        Me.txtDepName.Size = New System.Drawing.Size(264, 19)
        Me.txtDepName.TabIndex = 57
        '
        'txtHeadofDep
        '
        Me.txtHeadofDep.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtHeadofDep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHeadofDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeadofDep.Location = New System.Drawing.Point(389, 223)
        Me.txtHeadofDep.Name = "txtHeadofDep"
        Me.txtHeadofDep.Size = New System.Drawing.Size(264, 19)
        Me.txtHeadofDep.TabIndex = 58
        '
        'txtContact
        '
        Me.txtContact.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(389, 285)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(264, 19)
        Me.txtContact.TabIndex = 59
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(389, 343)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(264, 19)
        Me.txtEmail.TabIndex = 60
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(389, 403)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(264, 19)
        Me.txtLocation.TabIndex = 61
        '
        'txtNoofEmployees
        '
        Me.txtNoofEmployees.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtNoofEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNoofEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoofEmployees.Location = New System.Drawing.Point(389, 463)
        Me.txtNoofEmployees.Name = "txtNoofEmployees"
        Me.txtNoofEmployees.Size = New System.Drawing.Size(264, 19)
        Me.txtNoofEmployees.TabIndex = 62
        '
        'txtDepCode
        '
        Me.txtDepCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtDepCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDepCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepCode.Location = New System.Drawing.Point(389, 523)
        Me.txtDepCode.Name = "txtDepCode"
        Me.txtDepCode.Size = New System.Drawing.Size(264, 19)
        Me.txtDepCode.TabIndex = 63
        '
        'txtUpdateAt
        '
        Me.txtUpdateAt.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtUpdateAt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUpdateAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateAt.Location = New System.Drawing.Point(938, 523)
        Me.txtUpdateAt.Name = "txtUpdateAt"
        Me.txtUpdateAt.Size = New System.Drawing.Size(264, 19)
        Me.txtUpdateAt.TabIndex = 77
        '
        'txtCreatedAt
        '
        Me.txtCreatedAt.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtCreatedAt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreatedAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreatedAt.Location = New System.Drawing.Point(938, 463)
        Me.txtCreatedAt.Name = "txtCreatedAt"
        Me.txtCreatedAt.Size = New System.Drawing.Size(264, 19)
        Me.txtCreatedAt.TabIndex = 76
        '
        'txtBudgetAllocation
        '
        Me.txtBudgetAllocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtBudgetAllocation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBudgetAllocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBudgetAllocation.Location = New System.Drawing.Point(938, 403)
        Me.txtBudgetAllocation.Name = "txtBudgetAllocation"
        Me.txtBudgetAllocation.Size = New System.Drawing.Size(264, 19)
        Me.txtBudgetAllocation.TabIndex = 75
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(938, 343)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(264, 19)
        Me.txtStatus.TabIndex = 74
        '
        'txtParentDep
        '
        Me.txtParentDep.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtParentDep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtParentDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParentDep.Location = New System.Drawing.Point(938, 285)
        Me.txtParentDep.Name = "txtParentDep"
        Me.txtParentDep.Size = New System.Drawing.Size(264, 19)
        Me.txtParentDep.TabIndex = 73
        '
        'txtEstablishedDate
        '
        Me.txtEstablishedDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtEstablishedDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEstablishedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstablishedDate.Location = New System.Drawing.Point(938, 223)
        Me.txtEstablishedDate.Name = "txtEstablishedDate"
        Me.txtEstablishedDate.Size = New System.Drawing.Size(264, 19)
        Me.txtEstablishedDate.TabIndex = 72
        '
        'txtOfficeHour
        '
        Me.txtOfficeHour.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtOfficeHour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOfficeHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOfficeHour.Location = New System.Drawing.Point(938, 163)
        Me.txtOfficeHour.Name = "txtOfficeHour"
        Me.txtOfficeHour.Size = New System.Drawing.Size(264, 19)
        Me.txtOfficeHour.TabIndex = 71
        '
        'lblUpdateAt
        '
        Me.lblUpdateAt.AutoSize = True
        Me.lblUpdateAt.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateAt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUpdateAt.Location = New System.Drawing.Point(715, 521)
        Me.lblUpdateAt.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblUpdateAt.Name = "lblUpdateAt"
        Me.lblUpdateAt.Size = New System.Drawing.Size(105, 23)
        Me.lblUpdateAt.TabIndex = 70
        Me.lblUpdateAt.Text = " Update At"
        '
        'lblCreatedAt
        '
        Me.lblCreatedAt.AutoSize = True
        Me.lblCreatedAt.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCreatedAt.Location = New System.Drawing.Point(715, 461)
        Me.lblCreatedAt.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblCreatedAt.Name = "lblCreatedAt"
        Me.lblCreatedAt.Size = New System.Drawing.Size(104, 23)
        Me.lblCreatedAt.TabIndex = 69
        Me.lblCreatedAt.Text = "Created At"
        '
        'lbBudgetAllocation
        '
        Me.lbBudgetAllocation.AutoSize = True
        Me.lbBudgetAllocation.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBudgetAllocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbBudgetAllocation.Location = New System.Drawing.Point(715, 401)
        Me.lbBudgetAllocation.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbBudgetAllocation.Name = "lbBudgetAllocation"
        Me.lbBudgetAllocation.Size = New System.Drawing.Size(173, 23)
        Me.lbBudgetAllocation.TabIndex = 68
        Me.lbBudgetAllocation.Text = "Budget Allocation"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStatus.Location = New System.Drawing.Point(715, 341)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(65, 23)
        Me.lblStatus.TabIndex = 67
        Me.lblStatus.Text = "Status"
        '
        'lblParentDepartment
        '
        Me.lblParentDepartment.AutoSize = True
        Me.lblParentDepartment.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParentDepartment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblParentDepartment.Location = New System.Drawing.Point(715, 281)
        Me.lblParentDepartment.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblParentDepartment.Name = "lblParentDepartment"
        Me.lblParentDepartment.Size = New System.Drawing.Size(181, 23)
        Me.lblParentDepartment.TabIndex = 66
        Me.lblParentDepartment.Text = "Parent Department"
        '
        'lblEstablishedDate
        '
        Me.lblEstablishedDate.AutoSize = True
        Me.lblEstablishedDate.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstablishedDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEstablishedDate.Location = New System.Drawing.Point(715, 221)
        Me.lblEstablishedDate.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblEstablishedDate.Name = "lblEstablishedDate"
        Me.lblEstablishedDate.Size = New System.Drawing.Size(156, 23)
        Me.lblEstablishedDate.TabIndex = 65
        Me.lblEstablishedDate.Text = "Established Date"
        '
        'lblOfficeHour
        '
        Me.lblOfficeHour.AutoSize = True
        Me.lblOfficeHour.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOfficeHour.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblOfficeHour.Location = New System.Drawing.Point(715, 161)
        Me.lblOfficeHour.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblOfficeHour.Name = "lblOfficeHour"
        Me.lblOfficeHour.Size = New System.Drawing.Size(115, 23)
        Me.lblOfficeHour.TabIndex = 64
        Me.lblOfficeHour.Text = "Office Hour"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1025, 606)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSave.Size = New System.Drawing.Size(93, 29)
        Me.btnSave.TabIndex = 78
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBack.CornerRadius = 15
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(231, 606)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBack.Size = New System.Drawing.Size(93, 29)
        Me.btnBack.TabIndex = 79
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'SAAddDepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1386, 788)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtUpdateAt)
        Me.Controls.Add(Me.txtCreatedAt)
        Me.Controls.Add(Me.txtBudgetAllocation)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtParentDep)
        Me.Controls.Add(Me.txtEstablishedDate)
        Me.Controls.Add(Me.txtOfficeHour)
        Me.Controls.Add(Me.lblUpdateAt)
        Me.Controls.Add(Me.lblCreatedAt)
        Me.Controls.Add(Me.lbBudgetAllocation)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblParentDepartment)
        Me.Controls.Add(Me.lblEstablishedDate)
        Me.Controls.Add(Me.lblOfficeHour)
        Me.Controls.Add(Me.txtDepCode)
        Me.Controls.Add(Me.txtNoofEmployees)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.txtHeadofDep)
        Me.Controls.Add(Me.txtDepName)
        Me.Controls.Add(Me.lblDepartmentCode)
        Me.Controls.Add(Me.lblNoofEmployees)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblContactNumber)
        Me.Controls.Add(Me.lblHeadofDepartment)
        Me.Controls.Add(Me.lblDepartmentName)
        Me.Controls.Add(Me.lblDepartmentManagement)
        Me.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SAAddDepartmentManagement"
        Me.Text = "SAAddDepartmentManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDepartmentManagement As Label
    Friend WithEvents lblDepartmentName As Label
    Friend WithEvents lblHeadofDepartment As Label
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblNoofEmployees As Label
    Friend WithEvents lblDepartmentCode As Label
    Friend WithEvents txtDepName As TextBox
    Friend WithEvents txtHeadofDep As TextBox
    Friend WithEvents txtContact As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents txtNoofEmployees As TextBox
    Friend WithEvents txtDepCode As TextBox
    Friend WithEvents txtUpdateAt As TextBox
    Friend WithEvents txtCreatedAt As TextBox
    Friend WithEvents txtBudgetAllocation As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtParentDep As TextBox
    Friend WithEvents txtEstablishedDate As TextBox
    Friend WithEvents txtOfficeHour As TextBox
    Friend WithEvents lblUpdateAt As Label
    Friend WithEvents lblCreatedAt As Label
    Friend WithEvents lbBudgetAllocation As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblParentDepartment As Label
    Friend WithEvents lblEstablishedDate As Label
    Friend WithEvents lblOfficeHour As Label
    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnBack As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
