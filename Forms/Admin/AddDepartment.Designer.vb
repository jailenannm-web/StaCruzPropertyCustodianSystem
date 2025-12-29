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
        Me.departmentId = New System.Windows.Forms.TextBox()
        Me.description = New System.Windows.Forms.TextBox()
        Me.descriptionlbl = New System.Windows.Forms.Label()
        Me.shortName = New System.Windows.Forms.TextBox()
        Me.officeCode = New System.Windows.Forms.TextBox()
        Me.building = New System.Windows.Forms.TextBox()
        Me.established_date = New System.Windows.Forms.Label()
        Me.buildinglbl = New System.Windows.Forms.Label()
        Me.status_cmbo = New System.Windows.Forms.ComboBox()
        Me.shortnamelbl = New System.Windows.Forms.Label()
        Me.parent_department_id = New System.Windows.Forms.Label()
        Me.established_date_date = New System.Windows.Forms.DateTimePicker()
        Me.status = New System.Windows.Forms.Label()
        Me.budget_allocation = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.departmentHead = New System.Windows.Forms.ComboBox()
        Me.floorNumber = New System.Windows.Forms.TextBox()
        Me.location = New System.Windows.Forms.TextBox()
        Me.contactNumber = New System.Windows.Forms.TextBox()
        Me.email = New System.Windows.Forms.TextBox()
        Me.departmentName = New System.Windows.Forms.TextBox()
        Me.floornumberlbl = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.head_of_department = New System.Windows.Forms.Label()
        Me.department_name = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(52, 62)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(287, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 38
        Me.admin_label_DepartmentManagement.Text = "Department Form"
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
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1028, 728)
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
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1181, 728)
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
        Me.RoundedPanel2.Location = New System.Drawing.Point(61, 215)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1264, 488)
        Me.RoundedPanel2.TabIndex = 41
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.departmentId)
        Me.Panel2.Controls.Add(Me.description)
        Me.Panel2.Controls.Add(Me.descriptionlbl)
        Me.Panel2.Controls.Add(Me.shortName)
        Me.Panel2.Controls.Add(Me.officeCode)
        Me.Panel2.Controls.Add(Me.building)
        Me.Panel2.Controls.Add(Me.established_date)
        Me.Panel2.Controls.Add(Me.buildinglbl)
        Me.Panel2.Controls.Add(Me.status_cmbo)
        Me.Panel2.Controls.Add(Me.status)
        Me.Panel2.Controls.Add(Me.shortnamelbl)
        Me.Panel2.Controls.Add(Me.parent_department_id)
        Me.Panel2.Controls.Add(Me.established_date_date)
        Me.Panel2.Controls.Add(Me.budget_allocation)
        Me.Panel2.Location = New System.Drawing.Point(655, 18)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(537, 445)
        Me.Panel2.TabIndex = 65
        '
        'departmentId
        '
        Me.departmentId.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.departmentId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.departmentId.Location = New System.Drawing.Point(248, 404)
        Me.departmentId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Size = New System.Drawing.Size(255, 24)
        Me.departmentId.TabIndex = 96
        Me.departmentId.Visible = False
        '
        'description
        '
        Me.description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(248, 313)
        Me.description.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(257, 95)
        Me.description.TabIndex = 95
        '
        'descriptionlbl
        '
        Me.descriptionlbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.descriptionlbl.AutoSize = True
        Me.descriptionlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionlbl.Location = New System.Drawing.Point(44, 316)
        Me.descriptionlbl.Name = "descriptionlbl"
        Me.descriptionlbl.Size = New System.Drawing.Size(83, 18)
        Me.descriptionlbl.TabIndex = 94
        Me.descriptionlbl.Text = "Description"
        '
        'shortName
        '
        Me.shortName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.shortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shortName.Location = New System.Drawing.Point(243, 92)
        Me.shortName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.shortName.Name = "shortName"
        Me.shortName.Size = New System.Drawing.Size(255, 24)
        Me.shortName.TabIndex = 73
        '
        'officeCode
        '
        Me.officeCode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.officeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.officeCode.Location = New System.Drawing.Point(243, 201)
        Me.officeCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.officeCode.Name = "officeCode"
        Me.officeCode.Size = New System.Drawing.Size(255, 24)
        Me.officeCode.TabIndex = 71
        '
        'building
        '
        Me.building.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.building.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.building.Location = New System.Drawing.Point(243, 41)
        Me.building.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.building.Name = "building"
        Me.building.Size = New System.Drawing.Size(255, 24)
        Me.building.TabIndex = 70
        '
        'established_date
        '
        Me.established_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.established_date.AutoSize = True
        Me.established_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.established_date.Location = New System.Drawing.Point(44, 151)
        Me.established_date.Name = "established_date"
        Me.established_date.Size = New System.Drawing.Size(119, 18)
        Me.established_date.TabIndex = 48
        Me.established_date.Text = "Established Date"
        '
        'buildinglbl
        '
        Me.buildinglbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buildinglbl.AutoSize = True
        Me.buildinglbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buildinglbl.Location = New System.Drawing.Point(44, 47)
        Me.buildinglbl.Name = "buildinglbl"
        Me.buildinglbl.Size = New System.Drawing.Size(63, 18)
        Me.buildinglbl.TabIndex = 46
        Me.buildinglbl.Text = "Building "
        '
        'status_cmbo
        '
        Me.status_cmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status_cmbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status_cmbo.FormattingEnabled = True
        Me.status_cmbo.Location = New System.Drawing.Point(248, 256)
        Me.status_cmbo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.status_cmbo.Name = "status_cmbo"
        Me.status_cmbo.Size = New System.Drawing.Size(239, 26)
        Me.status_cmbo.TabIndex = 62
        '
        'shortnamelbl
        '
        Me.shortnamelbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.shortnamelbl.AutoSize = True
        Me.shortnamelbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shortnamelbl.Location = New System.Drawing.Point(44, 98)
        Me.shortnamelbl.Name = "shortnamelbl"
        Me.shortnamelbl.Size = New System.Drawing.Size(128, 18)
        Me.shortnamelbl.TabIndex = 47
        Me.shortnamelbl.Text = "Short Name/Code"
        '
        'parent_department_id
        '
        Me.parent_department_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.parent_department_id.AutoSize = True
        Me.parent_department_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.parent_department_id.Location = New System.Drawing.Point(44, 201)
        Me.parent_department_id.Name = "parent_department_id"
        Me.parent_department_id.Size = New System.Drawing.Size(87, 18)
        Me.parent_department_id.TabIndex = 49
        Me.parent_department_id.Text = "Office Code"
        '
        'established_date_date
        '
        Me.established_date_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.established_date_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.established_date_date.Location = New System.Drawing.Point(243, 150)
        Me.established_date_date.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.established_date_date.Name = "established_date_date"
        Me.established_date_date.Size = New System.Drawing.Size(239, 24)
        Me.established_date_date.TabIndex = 60
        '
        'status
        '
        Me.status.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status.AutoSize = True
        Me.status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.Location = New System.Drawing.Point(47, 410)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(99, 18)
        Me.status.TabIndex = 50
        Me.status.Text = "DepartmentID"
        Me.status.Visible = False
        '
        'budget_allocation
        '
        Me.budget_allocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.budget_allocation.AutoSize = True
        Me.budget_allocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.budget_allocation.Location = New System.Drawing.Point(47, 262)
        Me.budget_allocation.Name = "budget_allocation"
        Me.budget_allocation.Size = New System.Drawing.Size(50, 18)
        Me.budget_allocation.TabIndex = 51
        Me.budget_allocation.Text = "Status"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.departmentHead)
        Me.Panel1.Controls.Add(Me.floorNumber)
        Me.Panel1.Controls.Add(Me.location)
        Me.Panel1.Controls.Add(Me.contactNumber)
        Me.Panel1.Controls.Add(Me.email)
        Me.Panel1.Controls.Add(Me.departmentName)
        Me.Panel1.Controls.Add(Me.floornumberlbl)
        Me.Panel1.Controls.Add(Me.lblLocation)
        Me.Panel1.Controls.Add(Me.lblContactNumber)
        Me.Panel1.Controls.Add(Me.lblemail)
        Me.Panel1.Controls.Add(Me.head_of_department)
        Me.Panel1.Controls.Add(Me.department_name)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 445)
        Me.Panel1.TabIndex = 64
        '
        'departmentHead
        '
        Me.departmentHead.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.departmentHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.departmentHead.FormattingEnabled = True
        Me.departmentHead.Location = New System.Drawing.Point(256, 98)
        Me.departmentHead.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.departmentHead.Name = "departmentHead"
        Me.departmentHead.Size = New System.Drawing.Size(239, 26)
        Me.departmentHead.TabIndex = 70
        '
        'floorNumber
        '
        Me.floorNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.floorNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.floorNumber.Location = New System.Drawing.Point(256, 310)
        Me.floorNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.floorNumber.Name = "floorNumber"
        Me.floorNumber.Size = New System.Drawing.Size(255, 24)
        Me.floorNumber.TabIndex = 69
        '
        'location
        '
        Me.location.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.Location = New System.Drawing.Point(256, 256)
        Me.location.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(255, 24)
        Me.location.TabIndex = 68
        '
        'contactNumber
        '
        Me.contactNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.contactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contactNumber.Location = New System.Drawing.Point(256, 201)
        Me.contactNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Size = New System.Drawing.Size(255, 24)
        Me.contactNumber.TabIndex = 67
        '
        'email
        '
        Me.email.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.Location = New System.Drawing.Point(256, 145)
        Me.email.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(255, 24)
        Me.email.TabIndex = 66
        '
        'departmentName
        '
        Me.departmentName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.departmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.departmentName.Location = New System.Drawing.Point(256, 44)
        Me.departmentName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.departmentName.Name = "departmentName"
        Me.departmentName.Size = New System.Drawing.Size(255, 24)
        Me.departmentName.TabIndex = 64
        '
        'floornumberlbl
        '
        Me.floornumberlbl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.floornumberlbl.AutoSize = True
        Me.floornumberlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.floornumberlbl.Location = New System.Drawing.Point(43, 313)
        Me.floornumberlbl.Name = "floornumberlbl"
        Me.floornumberlbl.Size = New System.Drawing.Size(100, 18)
        Me.floornumberlbl.TabIndex = 63
        Me.floornumberlbl.Text = "Floor Number"
        '
        'lblLocation
        '
        Me.lblLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(43, 256)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(154, 18)
        Me.lblLocation.TabIndex = 62
        Me.lblLocation.Text = "Location/Office Room"
        '
        'lblContactNumber
        '
        Me.lblContactNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContactNumber.AutoSize = True
        Me.lblContactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.Location = New System.Drawing.Point(43, 201)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Size = New System.Drawing.Size(117, 18)
        Me.lblContactNumber.TabIndex = 61
        Me.lblContactNumber.Text = "Contact Number"
        '
        'lblemail
        '
        Me.lblemail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblemail.AutoSize = True
        Me.lblemail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemail.Location = New System.Drawing.Point(43, 151)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(49, 18)
        Me.lblemail.TabIndex = 60
        Me.lblemail.Text = "Email "
        '
        'head_of_department
        '
        Me.head_of_department.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.head_of_department.AutoSize = True
        Me.head_of_department.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.head_of_department.Location = New System.Drawing.Point(43, 98)
        Me.head_of_department.Name = "head_of_department"
        Me.head_of_department.Size = New System.Drawing.Size(124, 18)
        Me.head_of_department.TabIndex = 59
        Me.head_of_department.Text = "Department Head"
        '
        'department_name
        '
        Me.department_name.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department_name.AutoSize = True
        Me.department_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department_name.Location = New System.Drawing.Point(43, 47)
        Me.department_name.Name = "department_name"
        Me.department_name.Size = New System.Drawing.Size(129, 18)
        Me.department_name.TabIndex = 58
        Me.department_name.Text = "Department Name"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(61, 123)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1264, 71)
        Me.RoundedPanel1.TabIndex = 39
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(19, 25)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(267, 18)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required department information."
        '
        'AddDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AddDepartment"
        Me.Size = New System.Drawing.Size(1425, 791)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents shortnamelbl As System.Windows.Forms.Label
    Friend WithEvents buildinglbl As System.Windows.Forms.Label
    Friend WithEvents parent_department_id As System.Windows.Forms.Label
    Friend WithEvents established_date As System.Windows.Forms.Label
    Friend WithEvents budget_allocation As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents status_cmbo As System.Windows.Forms.ComboBox
    Friend WithEvents established_date_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents departmentName As System.Windows.Forms.TextBox
    Friend WithEvents floornumberlbl As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblContactNumber As System.Windows.Forms.Label
    Friend WithEvents lblemail As System.Windows.Forms.Label
    Friend WithEvents head_of_department As System.Windows.Forms.Label
    Friend WithEvents department_name As System.Windows.Forms.Label
    Friend WithEvents btnCancel As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend Shadows WithEvents location As System.Windows.Forms.TextBox
    Friend WithEvents contactNumber As System.Windows.Forms.TextBox
    Friend WithEvents floorNumber As System.Windows.Forms.TextBox
    Friend WithEvents officeCode As System.Windows.Forms.TextBox
    Friend WithEvents building As System.Windows.Forms.TextBox
    Friend WithEvents departmentHead As System.Windows.Forms.ComboBox
    Friend WithEvents shortName As System.Windows.Forms.TextBox
    Friend WithEvents departmentId As System.Windows.Forms.TextBox
    Friend WithEvents description As System.Windows.Forms.TextBox
    Friend WithEvents descriptionlbl As System.Windows.Forms.Label
End Class
