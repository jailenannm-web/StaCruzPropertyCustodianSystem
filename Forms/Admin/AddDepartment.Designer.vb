<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddDepartment
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.established_date = New System.Windows.Forms.Label()
        Me.parent_department_id_txt = New System.Windows.Forms.TextBox()
        Me.department_code = New System.Windows.Forms.Label()
        Me.status_cmbo = New System.Windows.Forms.ComboBox()
        Me.office_hours = New System.Windows.Forms.Label()
        Me.office_hours_cmbo = New System.Windows.Forms.ComboBox()
        Me.parent_department_id = New System.Windows.Forms.Label()
        Me.established_date_date = New System.Windows.Forms.DateTimePicker()
        Me.status = New System.Windows.Forms.Label()
        Me.department_code_Code = New System.Windows.Forms.TextBox()
        Me.budget_allocation = New System.Windows.Forms.Label()
        Me.budget_allocation_txt = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.no_of_employees_numeric = New System.Windows.Forms.NumericUpDown()
        Me.location_txt = New System.Windows.Forms.TextBox()
        Me.email_txt = New System.Windows.Forms.TextBox()
        Me.contact_number_txt = New System.Windows.Forms.TextBox()
        Me.head_of_department_txt = New System.Windows.Forms.TextBox()
        Me.department_name_txt = New System.Windows.Forms.TextBox()
        Me.no_of_employees = New System.Windows.Forms.Label()
        Me.location = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.Label()
        Me.contact_number = New System.Windows.Forms.Label()
        Me.head_of_department = New System.Windows.Forms.Label()
        Me.department_name = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(52, 62)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(312, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 38
        Me.admin_label_DepartmentManagement.Text = "Add Department"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1028, 732)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 153
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1181, 732)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 152
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(62, 215)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1264, 425)
        Me.RoundedPanel2.TabIndex = 41
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.established_date)
        Me.Panel2.Controls.Add(Me.parent_department_id_txt)
        Me.Panel2.Controls.Add(Me.department_code)
        Me.Panel2.Controls.Add(Me.status_cmbo)
        Me.Panel2.Controls.Add(Me.office_hours)
        Me.Panel2.Controls.Add(Me.office_hours_cmbo)
        Me.Panel2.Controls.Add(Me.parent_department_id)
        Me.Panel2.Controls.Add(Me.established_date_date)
        Me.Panel2.Controls.Add(Me.status)
        Me.Panel2.Controls.Add(Me.department_code_Code)
        Me.Panel2.Controls.Add(Me.budget_allocation)
        Me.Panel2.Controls.Add(Me.budget_allocation_txt)
        Me.Panel2.Location = New System.Drawing.Point(655, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(537, 382)
        Me.Panel2.TabIndex = 65
        '
        'established_date
        '
        Me.established_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.established_date.AutoSize = True
        Me.established_date.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.established_date.Location = New System.Drawing.Point(44, 151)
        Me.established_date.Name = "established_date"
        Me.established_date.Size = New System.Drawing.Size(137, 26)
        Me.established_date.TabIndex = 48
        Me.established_date.Text = "Established Date"
        '
        'parent_department_id_txt
        '
        Me.parent_department_id_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.parent_department_id_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.parent_department_id_txt.Location = New System.Drawing.Point(242, 197)
        Me.parent_department_id_txt.Name = "parent_department_id_txt"
        Me.parent_department_id_txt.Size = New System.Drawing.Size(238, 30)
        Me.parent_department_id_txt.TabIndex = 63
        '
        'department_code
        '
        Me.department_code.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department_code.AutoSize = True
        Me.department_code.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department_code.Location = New System.Drawing.Point(44, 47)
        Me.department_code.Name = "department_code"
        Me.department_code.Size = New System.Drawing.Size(147, 26)
        Me.department_code.TabIndex = 46
        Me.department_code.Text = "Department Code"
        '
        'status_cmbo
        '
        Me.status_cmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status_cmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status_cmbo.FormattingEnabled = True
        Me.status_cmbo.Location = New System.Drawing.Point(242, 252)
        Me.status_cmbo.Name = "status_cmbo"
        Me.status_cmbo.Size = New System.Drawing.Size(238, 34)
        Me.status_cmbo.TabIndex = 62
        '
        'office_hours
        '
        Me.office_hours.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.office_hours.AutoSize = True
        Me.office_hours.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.office_hours.Location = New System.Drawing.Point(44, 98)
        Me.office_hours.Name = "office_hours"
        Me.office_hours.Size = New System.Drawing.Size(104, 26)
        Me.office_hours.TabIndex = 47
        Me.office_hours.Text = "Office Hours"
        '
        'office_hours_cmbo
        '
        Me.office_hours_cmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.office_hours_cmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.office_hours_cmbo.FormattingEnabled = True
        Me.office_hours_cmbo.Location = New System.Drawing.Point(242, 91)
        Me.office_hours_cmbo.Name = "office_hours_cmbo"
        Me.office_hours_cmbo.Size = New System.Drawing.Size(238, 34)
        Me.office_hours_cmbo.TabIndex = 61
        '
        'parent_department_id
        '
        Me.parent_department_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.parent_department_id.AutoSize = True
        Me.parent_department_id.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.parent_department_id.Location = New System.Drawing.Point(44, 201)
        Me.parent_department_id.Name = "parent_department_id"
        Me.parent_department_id.Size = New System.Drawing.Size(174, 26)
        Me.parent_department_id.TabIndex = 49
        Me.parent_department_id.Text = "Parent Department ID"
        '
        'established_date_date
        '
        Me.established_date_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.established_date_date.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.established_date_date.Location = New System.Drawing.Point(242, 150)
        Me.established_date_date.Name = "established_date_date"
        Me.established_date_date.Size = New System.Drawing.Size(238, 30)
        Me.established_date_date.TabIndex = 60
        '
        'status
        '
        Me.status.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status.AutoSize = True
        Me.status.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.Location = New System.Drawing.Point(44, 256)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(59, 26)
        Me.status.TabIndex = 50
        Me.status.Text = "Status"
        '
        'department_code_Code
        '
        Me.department_code_Code.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department_code_Code.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department_code_Code.Location = New System.Drawing.Point(242, 43)
        Me.department_code_Code.Name = "department_code_Code"
        Me.department_code_Code.Size = New System.Drawing.Size(238, 30)
        Me.department_code_Code.TabIndex = 59
        '
        'budget_allocation
        '
        Me.budget_allocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.budget_allocation.AutoSize = True
        Me.budget_allocation.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.budget_allocation.Location = New System.Drawing.Point(44, 313)
        Me.budget_allocation.Name = "budget_allocation"
        Me.budget_allocation.Size = New System.Drawing.Size(145, 26)
        Me.budget_allocation.TabIndex = 51
        Me.budget_allocation.Text = "Budget Allocation"
        '
        'budget_allocation_txt
        '
        Me.budget_allocation_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.budget_allocation_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.budget_allocation_txt.Location = New System.Drawing.Point(242, 308)
        Me.budget_allocation_txt.Name = "budget_allocation_txt"
        Me.budget_allocation_txt.Size = New System.Drawing.Size(238, 30)
        Me.budget_allocation_txt.TabIndex = 58
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.no_of_employees_numeric)
        Me.Panel1.Controls.Add(Me.location_txt)
        Me.Panel1.Controls.Add(Me.email_txt)
        Me.Panel1.Controls.Add(Me.contact_number_txt)
        Me.Panel1.Controls.Add(Me.head_of_department_txt)
        Me.Panel1.Controls.Add(Me.department_name_txt)
        Me.Panel1.Controls.Add(Me.no_of_employees)
        Me.Panel1.Controls.Add(Me.location)
        Me.Panel1.Controls.Add(Me.email)
        Me.Panel1.Controls.Add(Me.contact_number)
        Me.Panel1.Controls.Add(Me.head_of_department)
        Me.Panel1.Controls.Add(Me.department_name)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 382)
        Me.Panel1.TabIndex = 64
        '
        'no_of_employees_numeric
        '
        Me.no_of_employees_numeric.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.no_of_employees_numeric.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.no_of_employees_numeric.Location = New System.Drawing.Point(256, 309)
        Me.no_of_employees_numeric.Name = "no_of_employees_numeric"
        Me.no_of_employees_numeric.Size = New System.Drawing.Size(254, 30)
        Me.no_of_employees_numeric.TabIndex = 69
        '
        'location_txt
        '
        Me.location_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location_txt.Location = New System.Drawing.Point(256, 252)
        Me.location_txt.Name = "location_txt"
        Me.location_txt.Size = New System.Drawing.Size(254, 30)
        Me.location_txt.TabIndex = 68
        '
        'email_txt
        '
        Me.email_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email_txt.Location = New System.Drawing.Point(256, 198)
        Me.email_txt.Name = "email_txt"
        Me.email_txt.Size = New System.Drawing.Size(254, 30)
        Me.email_txt.TabIndex = 67
        '
        'contact_number_txt
        '
        Me.contact_number_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.contact_number_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contact_number_txt.Location = New System.Drawing.Point(256, 147)
        Me.contact_number_txt.Name = "contact_number_txt"
        Me.contact_number_txt.Size = New System.Drawing.Size(254, 30)
        Me.contact_number_txt.TabIndex = 66
        '
        'head_of_department_txt
        '
        Me.head_of_department_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.head_of_department_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.head_of_department_txt.Location = New System.Drawing.Point(256, 95)
        Me.head_of_department_txt.Name = "head_of_department_txt"
        Me.head_of_department_txt.Size = New System.Drawing.Size(254, 30)
        Me.head_of_department_txt.TabIndex = 65
        '
        'department_name_txt
        '
        Me.department_name_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department_name_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department_name_txt.Location = New System.Drawing.Point(256, 44)
        Me.department_name_txt.Name = "department_name_txt"
        Me.department_name_txt.Size = New System.Drawing.Size(254, 30)
        Me.department_name_txt.TabIndex = 64
        '
        'no_of_employees
        '
        Me.no_of_employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.no_of_employees.AutoSize = True
        Me.no_of_employees.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.no_of_employees.Location = New System.Drawing.Point(42, 313)
        Me.no_of_employees.Name = "no_of_employees"
        Me.no_of_employees.Size = New System.Drawing.Size(177, 26)
        Me.no_of_employees.TabIndex = 63
        Me.no_of_employees.Text = "Number of Employees"
        '
        'location
        '
        Me.location.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location.AutoSize = True
        Me.location.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.Location = New System.Drawing.Point(42, 256)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(76, 26)
        Me.location.TabIndex = 62
        Me.location.Text = "Location"
        '
        'email
        '
        Me.email.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email.AutoSize = True
        Me.email.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.Location = New System.Drawing.Point(42, 201)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(53, 26)
        Me.email.TabIndex = 61
        Me.email.Text = "Email"
        '
        'contact_number
        '
        Me.contact_number.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.contact_number.AutoSize = True
        Me.contact_number.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contact_number.Location = New System.Drawing.Point(42, 151)
        Me.contact_number.Name = "contact_number"
        Me.contact_number.Size = New System.Drawing.Size(138, 26)
        Me.contact_number.TabIndex = 60
        Me.contact_number.Text = "Contact Number"
        '
        'head_of_department
        '
        Me.head_of_department.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.head_of_department.AutoSize = True
        Me.head_of_department.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.head_of_department.Location = New System.Drawing.Point(42, 98)
        Me.head_of_department.Name = "head_of_department"
        Me.head_of_department.Size = New System.Drawing.Size(164, 26)
        Me.head_of_department.TabIndex = 59
        Me.head_of_department.Text = "Head of Department"
        '
        'department_name
        '
        Me.department_name.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department_name.AutoSize = True
        Me.department_name.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department_name.Location = New System.Drawing.Point(42, 47)
        Me.department_name.Name = "department_name"
        Me.department_name.Size = New System.Drawing.Size(151, 26)
        Me.department_name.TabIndex = 58
        Me.department_name.Text = "Department Name"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(62, 123)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1264, 72)
        Me.RoundedPanel1.TabIndex = 39
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(18, 24)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(317, 26)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required department information."
        '
        'AddDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "AddDepartment"
        Me.Size = New System.Drawing.Size(1425, 791)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents office_hours As System.Windows.Forms.Label
    Friend WithEvents department_code As System.Windows.Forms.Label
    Friend WithEvents parent_department_id As System.Windows.Forms.Label
    Friend WithEvents established_date As System.Windows.Forms.Label
    Friend WithEvents budget_allocation As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents parent_department_id_txt As System.Windows.Forms.TextBox
    Friend WithEvents status_cmbo As System.Windows.Forms.ComboBox
    Friend WithEvents office_hours_cmbo As System.Windows.Forms.ComboBox
    Friend WithEvents established_date_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents department_code_Code As System.Windows.Forms.TextBox
    Friend WithEvents budget_allocation_txt As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents no_of_employees_numeric As System.Windows.Forms.NumericUpDown
    Friend WithEvents location_txt As System.Windows.Forms.TextBox
    Friend WithEvents email_txt As System.Windows.Forms.TextBox
    Friend WithEvents contact_number_txt As System.Windows.Forms.TextBox
    Friend WithEvents head_of_department_txt As System.Windows.Forms.TextBox
    Friend WithEvents department_name_txt As System.Windows.Forms.TextBox
    Friend WithEvents no_of_employees As System.Windows.Forms.Label
    Friend WithEvents location As System.Windows.Forms.Label
    Friend WithEvents email As System.Windows.Forms.Label
    Friend WithEvents contact_number As System.Windows.Forms.Label
    Friend WithEvents head_of_department As System.Windows.Forms.Label
    Friend WithEvents department_name As System.Windows.Forms.Label
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
End Class
