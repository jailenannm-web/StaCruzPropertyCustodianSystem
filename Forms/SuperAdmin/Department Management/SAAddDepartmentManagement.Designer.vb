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
        Me.txb_DepartmentName = New System.Windows.Forms.TextBox()
        Me.txb_ContactNumber = New System.Windows.Forms.TextBox()
        Me.txb_Number = New System.Windows.Forms.TextBox()
        Me.txb_Email = New System.Windows.Forms.TextBox()
        Me.txb_Location = New System.Windows.Forms.TextBox()
        Me.txb_NoofEmployees = New System.Windows.Forms.TextBox()
        Me.txb_DepCode = New System.Windows.Forms.TextBox()
        Me.txb_UpdateAt = New System.Windows.Forms.TextBox()
        Me.txb_CreatedAt = New System.Windows.Forms.TextBox()
        Me.txb_BudgetAllocation = New System.Windows.Forms.TextBox()
        Me.txb_Status = New System.Windows.Forms.TextBox()
        Me.txb_ParentDep = New System.Windows.Forms.TextBox()
        Me.txb_EstablishedDate = New System.Windows.Forms.TextBox()
        Me.txb_OfficeHour = New System.Windows.Forms.TextBox()
        Me.lblUpdateAt = New System.Windows.Forms.Label()
        Me.lblCreatedAt = New System.Windows.Forms.Label()
        Me.lbBudgetAllocation = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblParentDepartment = New System.Windows.Forms.Label()
        Me.lblEstablishedDate = New System.Windows.Forms.Label()
        Me.lblOfficeHour = New System.Windows.Forms.Label()
        Me.txb_DepartmentID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblDepartmentManagement
        '
        Me.lblDepartmentManagement.AutoSize = True
        Me.lblDepartmentManagement.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentManagement.Font = New System.Drawing.Font("Poppins", 34.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblDepartmentManagement.Location = New System.Drawing.Point(572, 23)
        Me.lblDepartmentManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepartmentManagement.Name = "lblDepartmentManagement"
        Me.lblDepartmentManagement.Size = New System.Drawing.Size(825, 102)
        Me.lblDepartmentManagement.TabIndex = 49
        Me.lblDepartmentManagement.Text = "Department Management"
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentName.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblDepartmentName.Location = New System.Drawing.Point(226, 231)
        Me.lblDepartmentName.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(224, 29)
        Me.lblDepartmentName.TabIndex = 50
        Me.lblDepartmentName.Text = "Department Name"
        '
        'lblHeadofDepartment
        '
        Me.lblHeadofDepartment.BackColor = System.Drawing.Color.Transparent
        Me.lblHeadofDepartment.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadofDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblHeadofDepartment.Location = New System.Drawing.Point(226, 305)
        Me.lblHeadofDepartment.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblHeadofDepartment.Name = "lblHeadofDepartment"
        Me.lblHeadofDepartment.Size = New System.Drawing.Size(246, 29)
        Me.lblHeadofDepartment.TabIndex = 51
        Me.lblHeadofDepartment.Text = "Head of Department"
        '
        'lblContactNumber
        '
        Me.lblContactNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblContactNumber.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblContactNumber.Location = New System.Drawing.Point(226, 379)
        Me.lblContactNumber.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Size = New System.Drawing.Size(201, 29)
        Me.lblContactNumber.TabIndex = 52
        Me.lblContactNumber.Text = "Contact Number"
        '
        'lblEmail
        '
        Me.lblEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblEmail.Location = New System.Drawing.Point(226, 453)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(79, 29)
        Me.lblEmail.TabIndex = 53
        Me.lblEmail.Text = "Email"
        '
        'lblLocation
        '
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblLocation.Location = New System.Drawing.Point(226, 527)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(112, 29)
        Me.lblLocation.TabIndex = 54
        Me.lblLocation.Text = "Location"
        '
        'lblNoofEmployees
        '
        Me.lblNoofEmployees.BackColor = System.Drawing.Color.Transparent
        Me.lblNoofEmployees.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoofEmployees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblNoofEmployees.Location = New System.Drawing.Point(226, 600)
        Me.lblNoofEmployees.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblNoofEmployees.Name = "lblNoofEmployees"
        Me.lblNoofEmployees.Size = New System.Drawing.Size(213, 29)
        Me.lblNoofEmployees.TabIndex = 55
        Me.lblNoofEmployees.Text = "No of Employees"
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblDepartmentCode.Location = New System.Drawing.Point(226, 674)
        Me.lblDepartmentCode.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(218, 29)
        Me.lblDepartmentCode.TabIndex = 56
        Me.lblDepartmentCode.Text = "Department Code"
        '
        'txb_DepartmentName
        '
        Me.txb_DepartmentName.BackColor = System.Drawing.Color.White
        Me.txb_DepartmentName.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentName.Location = New System.Drawing.Point(524, 234)
        Me.txb_DepartmentName.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_DepartmentName.Name = "txb_DepartmentName"
        Me.txb_DepartmentName.Size = New System.Drawing.Size(361, 42)
        Me.txb_DepartmentName.TabIndex = 57
        '
        'txb_ContactNumber
        '
        Me.txb_ContactNumber.BackColor = System.Drawing.Color.White
        Me.txb_ContactNumber.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ContactNumber.Location = New System.Drawing.Point(524, 307)
        Me.txb_ContactNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_ContactNumber.Name = "txb_ContactNumber"
        Me.txb_ContactNumber.Size = New System.Drawing.Size(361, 42)
        Me.txb_ContactNumber.TabIndex = 58
        '
        'txb_Number
        '
        Me.txb_Number.BackColor = System.Drawing.Color.White
        Me.txb_Number.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Number.Location = New System.Drawing.Point(524, 384)
        Me.txb_Number.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Number.Name = "txb_Number"
        Me.txb_Number.Size = New System.Drawing.Size(361, 42)
        Me.txb_Number.TabIndex = 59
        '
        'txb_Email
        '
        Me.txb_Email.BackColor = System.Drawing.Color.White
        Me.txb_Email.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Email.Location = New System.Drawing.Point(524, 455)
        Me.txb_Email.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Email.Name = "txb_Email"
        Me.txb_Email.Size = New System.Drawing.Size(361, 42)
        Me.txb_Email.TabIndex = 60
        '
        'txb_Location
        '
        Me.txb_Location.BackColor = System.Drawing.Color.White
        Me.txb_Location.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Location.Location = New System.Drawing.Point(524, 529)
        Me.txb_Location.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Location.Name = "txb_Location"
        Me.txb_Location.Size = New System.Drawing.Size(361, 42)
        Me.txb_Location.TabIndex = 61
        '
        'txb_NoofEmployees
        '
        Me.txb_NoofEmployees.BackColor = System.Drawing.Color.White
        Me.txb_NoofEmployees.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_NoofEmployees.Location = New System.Drawing.Point(524, 603)
        Me.txb_NoofEmployees.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_NoofEmployees.Name = "txb_NoofEmployees"
        Me.txb_NoofEmployees.Size = New System.Drawing.Size(361, 42)
        Me.txb_NoofEmployees.TabIndex = 62
        '
        'txb_DepCode
        '
        Me.txb_DepCode.BackColor = System.Drawing.Color.White
        Me.txb_DepCode.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepCode.Location = New System.Drawing.Point(524, 677)
        Me.txb_DepCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_DepCode.Name = "txb_DepCode"
        Me.txb_DepCode.Size = New System.Drawing.Size(361, 42)
        Me.txb_DepCode.TabIndex = 63
        '
        'txb_UpdateAt
        '
        Me.txb_UpdateAt.BackColor = System.Drawing.Color.White
        Me.txb_UpdateAt.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UpdateAt.Location = New System.Drawing.Point(1246, 607)
        Me.txb_UpdateAt.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_UpdateAt.Name = "txb_UpdateAt"
        Me.txb_UpdateAt.Size = New System.Drawing.Size(361, 42)
        Me.txb_UpdateAt.TabIndex = 77
        '
        'txb_CreatedAt
        '
        Me.txb_CreatedAt.BackColor = System.Drawing.Color.White
        Me.txb_CreatedAt.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_CreatedAt.Location = New System.Drawing.Point(1246, 533)
        Me.txb_CreatedAt.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_CreatedAt.Name = "txb_CreatedAt"
        Me.txb_CreatedAt.Size = New System.Drawing.Size(361, 42)
        Me.txb_CreatedAt.TabIndex = 76
        '
        'txb_BudgetAllocation
        '
        Me.txb_BudgetAllocation.BackColor = System.Drawing.Color.White
        Me.txb_BudgetAllocation.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_BudgetAllocation.Location = New System.Drawing.Point(1246, 459)
        Me.txb_BudgetAllocation.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_BudgetAllocation.Name = "txb_BudgetAllocation"
        Me.txb_BudgetAllocation.Size = New System.Drawing.Size(361, 42)
        Me.txb_BudgetAllocation.TabIndex = 75
        '
        'txb_Status
        '
        Me.txb_Status.BackColor = System.Drawing.Color.White
        Me.txb_Status.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Status.Location = New System.Drawing.Point(1246, 385)
        Me.txb_Status.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_Status.Name = "txb_Status"
        Me.txb_Status.Size = New System.Drawing.Size(361, 42)
        Me.txb_Status.TabIndex = 74
        '
        'txb_ParentDep
        '
        Me.txb_ParentDep.BackColor = System.Drawing.Color.White
        Me.txb_ParentDep.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ParentDep.Location = New System.Drawing.Point(1246, 314)
        Me.txb_ParentDep.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_ParentDep.Name = "txb_ParentDep"
        Me.txb_ParentDep.Size = New System.Drawing.Size(361, 42)
        Me.txb_ParentDep.TabIndex = 73
        '
        'txb_EstablishedDate
        '
        Me.txb_EstablishedDate.BackColor = System.Drawing.Color.White
        Me.txb_EstablishedDate.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_EstablishedDate.Location = New System.Drawing.Point(1246, 237)
        Me.txb_EstablishedDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_EstablishedDate.Name = "txb_EstablishedDate"
        Me.txb_EstablishedDate.Size = New System.Drawing.Size(361, 42)
        Me.txb_EstablishedDate.TabIndex = 72
        '
        'txb_OfficeHour
        '
        Me.txb_OfficeHour.BackColor = System.Drawing.Color.White
        Me.txb_OfficeHour.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_OfficeHour.Location = New System.Drawing.Point(1246, 163)
        Me.txb_OfficeHour.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_OfficeHour.Name = "txb_OfficeHour"
        Me.txb_OfficeHour.Size = New System.Drawing.Size(361, 42)
        Me.txb_OfficeHour.TabIndex = 71
        '
        'lblUpdateAt
        '
        Me.lblUpdateAt.BackColor = System.Drawing.Color.Transparent
        Me.lblUpdateAt.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateAt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblUpdateAt.Location = New System.Drawing.Point(999, 616)
        Me.lblUpdateAt.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblUpdateAt.Name = "lblUpdateAt"
        Me.lblUpdateAt.Size = New System.Drawing.Size(134, 29)
        Me.lblUpdateAt.TabIndex = 70
        Me.lblUpdateAt.Text = " Update At"
        '
        'lblCreatedAt
        '
        Me.lblCreatedAt.BackColor = System.Drawing.Color.Transparent
        Me.lblCreatedAt.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblCreatedAt.Location = New System.Drawing.Point(999, 542)
        Me.lblCreatedAt.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblCreatedAt.Name = "lblCreatedAt"
        Me.lblCreatedAt.Size = New System.Drawing.Size(136, 29)
        Me.lblCreatedAt.TabIndex = 69
        Me.lblCreatedAt.Text = "Created At"
        '
        'lbBudgetAllocation
        '
        Me.lbBudgetAllocation.BackColor = System.Drawing.Color.Transparent
        Me.lbBudgetAllocation.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBudgetAllocation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lbBudgetAllocation.Location = New System.Drawing.Point(999, 468)
        Me.lbBudgetAllocation.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lbBudgetAllocation.Name = "lbBudgetAllocation"
        Me.lbBudgetAllocation.Size = New System.Drawing.Size(218, 29)
        Me.lbBudgetAllocation.TabIndex = 68
        Me.lbBudgetAllocation.Text = "Budget Allocation"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(999, 395)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(85, 29)
        Me.lblStatus.TabIndex = 67
        Me.lblStatus.Text = "Status"
        '
        'lblParentDepartment
        '
        Me.lblParentDepartment.BackColor = System.Drawing.Color.Transparent
        Me.lblParentDepartment.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParentDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblParentDepartment.Location = New System.Drawing.Point(999, 321)
        Me.lblParentDepartment.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblParentDepartment.Name = "lblParentDepartment"
        Me.lblParentDepartment.Size = New System.Drawing.Size(231, 29)
        Me.lblParentDepartment.TabIndex = 66
        Me.lblParentDepartment.Text = "Parent Department"
        '
        'lblEstablishedDate
        '
        Me.lblEstablishedDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEstablishedDate.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstablishedDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblEstablishedDate.Location = New System.Drawing.Point(999, 247)
        Me.lblEstablishedDate.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblEstablishedDate.Name = "lblEstablishedDate"
        Me.lblEstablishedDate.Size = New System.Drawing.Size(211, 29)
        Me.lblEstablishedDate.TabIndex = 65
        Me.lblEstablishedDate.Text = "Established Date"
        '
        'lblOfficeHour
        '
        Me.lblOfficeHour.BackColor = System.Drawing.Color.Transparent
        Me.lblOfficeHour.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOfficeHour.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblOfficeHour.Location = New System.Drawing.Point(999, 173)
        Me.lblOfficeHour.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblOfficeHour.Name = "lblOfficeHour"
        Me.lblOfficeHour.Size = New System.Drawing.Size(145, 29)
        Me.lblOfficeHour.TabIndex = 64
        Me.lblOfficeHour.Text = "Office Hour"
        '
        'txb_DepartmentID
        '
        Me.txb_DepartmentID.BackColor = System.Drawing.Color.White
        Me.txb_DepartmentID.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentID.Location = New System.Drawing.Point(524, 167)
        Me.txb_DepartmentID.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_DepartmentID.Name = "txb_DepartmentID"
        Me.txb_DepartmentID.Size = New System.Drawing.Size(361, 42)
        Me.txb_DepartmentID.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(226, 165)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 29)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Department I.D"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(592, 811)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(255, 57)
        Me.btn_Cancel.TabIndex = 82
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.FlatAppearance.BorderSize = 0
        Me.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(1049, 811)
        Me.btn_Login.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(253, 57)
        Me.btn_Login.TabIndex = 83
        Me.btn_Login.Text = "Add"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'SAAddDepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources._Presentation2
        Me.ClientSize = New System.Drawing.Size(1848, 970)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.txb_DepartmentID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txb_UpdateAt)
        Me.Controls.Add(Me.txb_CreatedAt)
        Me.Controls.Add(Me.txb_BudgetAllocation)
        Me.Controls.Add(Me.txb_Status)
        Me.Controls.Add(Me.txb_ParentDep)
        Me.Controls.Add(Me.txb_EstablishedDate)
        Me.Controls.Add(Me.txb_OfficeHour)
        Me.Controls.Add(Me.lblUpdateAt)
        Me.Controls.Add(Me.lblCreatedAt)
        Me.Controls.Add(Me.lbBudgetAllocation)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblParentDepartment)
        Me.Controls.Add(Me.lblEstablishedDate)
        Me.Controls.Add(Me.lblOfficeHour)
        Me.Controls.Add(Me.txb_DepCode)
        Me.Controls.Add(Me.txb_NoofEmployees)
        Me.Controls.Add(Me.txb_Location)
        Me.Controls.Add(Me.txb_Email)
        Me.Controls.Add(Me.txb_Number)
        Me.Controls.Add(Me.txb_ContactNumber)
        Me.Controls.Add(Me.txb_DepartmentName)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents txb_DepartmentName As TextBox
    Friend WithEvents txb_ContactNumber As TextBox
    Friend WithEvents txb_Number As TextBox
    Friend WithEvents txb_Email As TextBox
    Friend WithEvents txb_Location As TextBox
    Friend WithEvents txb_NoofEmployees As TextBox
    Friend WithEvents txb_DepCode As TextBox
    Friend WithEvents txb_UpdateAt As TextBox
    Friend WithEvents txb_CreatedAt As TextBox
    Friend WithEvents txb_BudgetAllocation As TextBox
    Friend WithEvents txb_Status As TextBox
    Friend WithEvents txb_ParentDep As TextBox
    Friend WithEvents txb_EstablishedDate As TextBox
    Friend WithEvents txb_OfficeHour As TextBox
    Friend WithEvents lblUpdateAt As Label
    Friend WithEvents lblCreatedAt As Label
    Friend WithEvents lbBudgetAllocation As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblParentDepartment As Label
    Friend WithEvents lblEstablishedDate As Label
    Friend WithEvents lblOfficeHour As Label
    Friend WithEvents txb_DepartmentID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_Login As Button
End Class
