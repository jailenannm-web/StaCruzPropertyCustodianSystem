Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAAddDepartmentManagement
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
        Me.components = New System.ComponentModel.Container()
        Me.location_txt = New System.Windows.Forms.TextBox()
        Me.email_txt = New System.Windows.Forms.TextBox()
        Me.contact_number_txt = New System.Windows.Forms.TextBox()
        Me.head_of_department_txt = New System.Windows.Forms.TextBox()
        Me.department_name_txt = New System.Windows.Forms.TextBox()
        Me.established_date = New System.Windows.Forms.Label()
        Me.parent_department_id_txt = New System.Windows.Forms.TextBox()
        Me.department_code = New System.Windows.Forms.Label()
        Me.status_cmbo = New System.Windows.Forms.ComboBox()
        Me.location = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.Label()
        Me.office_hours = New System.Windows.Forms.Label()
        Me.office_hours_cmbo = New System.Windows.Forms.ComboBox()
        Me.parent_department_id = New System.Windows.Forms.Label()
        Me.established_date_date = New System.Windows.Forms.DateTimePicker()
        Me.status = New System.Windows.Forms.Label()
        Me.no_of_employees = New System.Windows.Forms.Label()
        Me.contact_number = New System.Windows.Forms.Label()
        Me.head_of_department = New System.Windows.Forms.Label()
        Me.department_name = New System.Windows.Forms.Label()
        Me.instructions = New System.Windows.Forms.Label()
        Me.department_code_Code = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.no_of_employees_numeric = New System.Windows.Forms.NumericUpDown()
        Me.budget_allocation = New System.Windows.Forms.Label()
        Me.budget_allocation_txt = New System.Windows.Forms.TextBox()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'location_txt
        '
        Me.lblDepartmentManagement.AutoSize = True
        Me.lblDepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentManagement.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDepartmentManagement.Location = New System.Drawing.Point(597, 24)
        Me.lblDepartmentManagement.Name = "lblDepartmentManagement"
        Me.lblDepartmentManagement.Size = New System.Drawing.Size(341, 31)
        Me.lblDepartmentManagement.TabIndex = 49
        Me.lblDepartmentManagement.Text = "Department Management"
        '
        'email_txt
        '
        Me.lblDepartmentName.AutoSize = True
        Me.lblDepartmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDepartmentName.Location = New System.Drawing.Point(166, 161)
        Me.lblDepartmentName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(178, 24)
        Me.lblDepartmentName.TabIndex = 50
        Me.lblDepartmentName.Text = "Department Name"
        '
        'contact_number_txt
        '
        Me.lblHeadofDepartment.AutoSize = True
        Me.lblHeadofDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadofDepartment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblHeadofDepartment.Location = New System.Drawing.Point(166, 221)
        Me.lblHeadofDepartment.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblHeadofDepartment.Name = "lblHeadofDepartment"
        Me.lblHeadofDepartment.Size = New System.Drawing.Size(196, 24)
        Me.lblHeadofDepartment.TabIndex = 51
        Me.lblHeadofDepartment.Text = "Head of Department"
        '
        'head_of_department_txt
        '
        Me.lblContactNumber.AutoSize = True
        Me.lblContactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblContactNumber.Location = New System.Drawing.Point(166, 281)
        Me.lblContactNumber.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Size = New System.Drawing.Size(161, 24)
        Me.lblContactNumber.TabIndex = 52
        Me.lblContactNumber.Text = "Contact Number"
        '
        'department_name_txt
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEmail.Location = New System.Drawing.Point(166, 341)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(62, 24)
        Me.lblEmail.TabIndex = 53
        Me.lblEmail.Text = "Email"
        '
        'established_date
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblLocation.Location = New System.Drawing.Point(166, 401)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(89, 24)
        Me.lblLocation.TabIndex = 54
        Me.lblLocation.Text = "Location"
        '
        'parent_department_id_txt
        '
        Me.lblNoofEmployees.AutoSize = True
        Me.lblNoofEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoofEmployees.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNoofEmployees.Location = New System.Drawing.Point(166, 461)
        Me.lblNoofEmployees.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblNoofEmployees.Name = "lblNoofEmployees"
        Me.lblNoofEmployees.Size = New System.Drawing.Size(170, 24)
        Me.lblNoofEmployees.TabIndex = 55
        Me.lblNoofEmployees.Text = "No of Employees"
        '
        'department_code
        '
        Me.lblDepartmentCode.AutoSize = True
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDepartmentCode.Location = New System.Drawing.Point(166, 521)
        Me.lblDepartmentCode.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(173, 24)
        Me.lblDepartmentCode.TabIndex = 56
        Me.lblDepartmentCode.Text = "Department Code"
        '
        'status_cmbo
        '
        Me.txb_DepartmentName.BackColor = System.Drawing.Color.White
        Me.txb_DepartmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentName.Location = New System.Drawing.Point(389, 163)
        Me.txb_DepartmentName.Name = "txb_DepartmentName"
        Me.txb_DepartmentName.Size = New System.Drawing.Size(264, 26)
        Me.txb_DepartmentName.TabIndex = 57
        '
        'location
        '
        Me.txb_ContactNumber.BackColor = System.Drawing.Color.White
        Me.txb_ContactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ContactNumber.Location = New System.Drawing.Point(389, 223)
        Me.txb_ContactNumber.Name = "txb_ContactNumber"
        Me.txb_ContactNumber.Size = New System.Drawing.Size(264, 26)
        Me.txb_ContactNumber.TabIndex = 58
        '
        'email
        '
        Me.txb_Number.BackColor = System.Drawing.Color.White
        Me.txb_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Number.Location = New System.Drawing.Point(389, 285)
        Me.txb_Number.Name = "txb_Number"
        Me.txb_Number.Size = New System.Drawing.Size(264, 26)
        Me.txb_Number.TabIndex = 59
        '
        'office_hours
        '
        Me.txb_Email.BackColor = System.Drawing.Color.White
        Me.txb_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Email.Location = New System.Drawing.Point(389, 343)
        Me.txb_Email.Name = "txb_Email"
        Me.txb_Email.Size = New System.Drawing.Size(264, 26)
        Me.txb_Email.TabIndex = 60
        '
        'office_hours_cmbo
        '
        Me.txb_Location.BackColor = System.Drawing.Color.White
        Me.txb_Location.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Location.Location = New System.Drawing.Point(389, 403)
        Me.txb_Location.Name = "txb_Location"
        Me.txb_Location.Size = New System.Drawing.Size(264, 26)
        Me.txb_Location.TabIndex = 61
        '
        'parent_department_id
        '
        Me.txb_NoofEmployees.BackColor = System.Drawing.Color.White
        Me.txb_NoofEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_NoofEmployees.Location = New System.Drawing.Point(389, 463)
        Me.txb_NoofEmployees.Name = "txb_NoofEmployees"
        Me.txb_NoofEmployees.Size = New System.Drawing.Size(264, 26)
        Me.txb_NoofEmployees.TabIndex = 62
        '
        'established_date_date
        '
        Me.txb_DepCode.BackColor = System.Drawing.Color.White
        Me.txb_DepCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepCode.Location = New System.Drawing.Point(389, 523)
        Me.txb_DepCode.Name = "txb_DepCode"
        Me.txb_DepCode.Size = New System.Drawing.Size(264, 26)
        Me.txb_DepCode.TabIndex = 63
        '
        'status
        '
        Me.txb_UpdateAt.BackColor = System.Drawing.Color.White
        Me.txb_UpdateAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UpdateAt.Location = New System.Drawing.Point(931, 466)
        Me.txb_UpdateAt.Name = "txb_UpdateAt"
        Me.txb_UpdateAt.Size = New System.Drawing.Size(264, 26)
        Me.txb_UpdateAt.TabIndex = 77
        '
        'no_of_employees
        '
        Me.txb_CreatedAt.BackColor = System.Drawing.Color.White
        Me.txb_CreatedAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_CreatedAt.Location = New System.Drawing.Point(931, 406)
        Me.txb_CreatedAt.Name = "txb_CreatedAt"
        Me.txb_CreatedAt.Size = New System.Drawing.Size(264, 26)
        Me.txb_CreatedAt.TabIndex = 76
        '
        'contact_number
        '
        Me.txb_BudgetAllocation.BackColor = System.Drawing.Color.White
        Me.txb_BudgetAllocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_BudgetAllocation.Location = New System.Drawing.Point(931, 346)
        Me.txb_BudgetAllocation.Name = "txb_BudgetAllocation"
        Me.txb_BudgetAllocation.Size = New System.Drawing.Size(264, 26)
        Me.txb_BudgetAllocation.TabIndex = 75
        '
        'department_name
        '
        Me.txb_Status.BackColor = System.Drawing.Color.White
        Me.txb_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Status.Location = New System.Drawing.Point(931, 286)
        Me.txb_Status.Name = "txb_Status"
        Me.txb_Status.Size = New System.Drawing.Size(264, 26)
        Me.txb_Status.TabIndex = 74
        '
        'instructions
        '
        Me.txb_ParentDep.BackColor = System.Drawing.Color.White
        Me.txb_ParentDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ParentDep.Location = New System.Drawing.Point(931, 228)
        Me.txb_ParentDep.Name = "txb_ParentDep"
        Me.txb_ParentDep.Size = New System.Drawing.Size(264, 26)
        Me.txb_ParentDep.TabIndex = 73
        '
        'department_code_Code
        '
        Me.txb_EstablishedDate.BackColor = System.Drawing.Color.White
        Me.txb_EstablishedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_EstablishedDate.Location = New System.Drawing.Point(931, 166)
        Me.txb_EstablishedDate.Name = "txb_EstablishedDate"
        Me.txb_EstablishedDate.Size = New System.Drawing.Size(264, 26)
        Me.txb_EstablishedDate.TabIndex = 72
        '
        'Panel1
        '
        Me.txb_OfficeHour.BackColor = System.Drawing.Color.White
        Me.txb_OfficeHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_OfficeHour.Location = New System.Drawing.Point(931, 106)
        Me.txb_OfficeHour.Name = "txb_OfficeHour"
        Me.txb_OfficeHour.Size = New System.Drawing.Size(264, 26)
        Me.txb_OfficeHour.TabIndex = 71
        '
        'no_of_employees_numeric
        '
        Me.lblUpdateAt.AutoSize = True
        Me.lblUpdateAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateAt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUpdateAt.Location = New System.Drawing.Point(708, 464)
        Me.lblUpdateAt.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblUpdateAt.Name = "lblUpdateAt"
        Me.lblUpdateAt.Size = New System.Drawing.Size(107, 24)
        Me.lblUpdateAt.TabIndex = 70
        Me.lblUpdateAt.Text = " Update At"
        '
        'budget_allocation
        '
        Me.lblCreatedAt.AutoSize = True
        Me.lblCreatedAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCreatedAt.Location = New System.Drawing.Point(708, 404)
        Me.lblCreatedAt.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblCreatedAt.Name = "lblCreatedAt"
        Me.lblCreatedAt.Size = New System.Drawing.Size(108, 24)
        Me.lblCreatedAt.TabIndex = 69
        Me.lblCreatedAt.Text = "Created At"
        '
        'budget_allocation_txt
        '
        Me.lbBudgetAllocation.AutoSize = True
        Me.lbBudgetAllocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBudgetAllocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbBudgetAllocation.Location = New System.Drawing.Point(708, 344)
        Me.lbBudgetAllocation.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbBudgetAllocation.Name = "lbBudgetAllocation"
        Me.lbBudgetAllocation.Size = New System.Drawing.Size(174, 24)
        Me.lbBudgetAllocation.TabIndex = 68
        Me.lbBudgetAllocation.Text = "Budget Allocation"
        '
        'RoundedPanel1
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStatus.Location = New System.Drawing.Point(708, 284)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(66, 24)
        Me.lblStatus.TabIndex = 67
        Me.lblStatus.Text = "Status"
        '
        'Panel2
        '
        Me.lblParentDepartment.AutoSize = True
        Me.lblParentDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParentDepartment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblParentDepartment.Location = New System.Drawing.Point(708, 224)
        Me.lblParentDepartment.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblParentDepartment.Name = "lblParentDepartment"
        Me.lblParentDepartment.Size = New System.Drawing.Size(183, 24)
        Me.lblParentDepartment.TabIndex = 66
        Me.lblParentDepartment.Text = "Parent Department"
        '
        'btnCancel
        '
        Me.lblEstablishedDate.AutoSize = True
        Me.lblEstablishedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstablishedDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEstablishedDate.Location = New System.Drawing.Point(708, 164)
        Me.lblEstablishedDate.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblEstablishedDate.Name = "lblEstablishedDate"
        Me.lblEstablishedDate.Size = New System.Drawing.Size(166, 24)
        Me.lblEstablishedDate.TabIndex = 65
        Me.lblEstablishedDate.Text = "Established Date"
        '
        'btnSave
        '
        Me.lblOfficeHour.AutoSize = True
        Me.lblOfficeHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOfficeHour.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblOfficeHour.Location = New System.Drawing.Point(708, 104)
        Me.lblOfficeHour.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblOfficeHour.Name = "lblOfficeHour"
        Me.lblOfficeHour.Size = New System.Drawing.Size(116, 24)
        Me.lblOfficeHour.TabIndex = 64
        Me.lblOfficeHour.Text = "Office Hour"
        '
        'RoundedPanel2
        '
        Me.txb_DepartmentID.BackColor = System.Drawing.Color.White
        Me.txb_DepartmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentID.Location = New System.Drawing.Point(389, 109)
        Me.txb_DepartmentID.Name = "txb_DepartmentID"
        Me.txb_DepartmentID.Size = New System.Drawing.Size(264, 26)
        Me.txb_DepartmentID.TabIndex = 81
        '
        'ContextMenuStrip2
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(166, 107)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 24)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Department I.D"
        '
        'ContextMenuStrip1
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(422, 621)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(191, 46)
        Me.btn_Cancel.TabIndex = 82
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'admin_label_DepartmentManagement
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(765, 621)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(190, 46)
        Me.btn_Login.TabIndex = 83
        Me.btn_Login.Text = "Add"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'SAAddDepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1386, 788)
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
        Me.Name = "SAAddDepartmentManagement"
        Me.Text = "SAAddDepartmentManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents location_txt As TextBox
    Friend WithEvents email_txt As TextBox
    Friend WithEvents contact_number_txt As TextBox
    Friend WithEvents head_of_department_txt As TextBox
    Friend WithEvents department_name_txt As TextBox
    Friend WithEvents established_date As Label
    Friend WithEvents parent_department_id_txt As TextBox
    Friend WithEvents department_code As Label
    Friend WithEvents status_cmbo As ComboBox
    Friend WithEvents location As Label
    Friend WithEvents email As Label
    Friend WithEvents office_hours As Label
    Friend WithEvents office_hours_cmbo As ComboBox
    Friend WithEvents parent_department_id As Label
    Friend WithEvents established_date_date As DateTimePicker
    Friend WithEvents status As Label
    Friend WithEvents no_of_employees As Label
    Friend WithEvents contact_number As Label
    Friend WithEvents head_of_department As Label
    Friend WithEvents department_name As Label
    Friend WithEvents instructions As Label
    Friend WithEvents department_code_Code As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents no_of_employees_numeric As NumericUpDown
    Friend WithEvents budget_allocation As Label
    Friend WithEvents budget_allocation_txt As TextBox
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents admin_label_DepartmentManagement As Label
End Class
