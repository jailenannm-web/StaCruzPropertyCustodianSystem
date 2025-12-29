<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceRequestForm
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
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.instructions = New System.Windows.Forms.Label()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.itemName = New System.Windows.Forms.ComboBox()
        Me.department = New System.Windows.Forms.ComboBox()
        Me.location = New System.Windows.Forms.ComboBox()
        Me.conditionBefore = New System.Windows.Forms.ComboBox()
        Me.serialNumber = New System.Windows.Forms.TextBox()
        Me.SAAddM_ServiceType = New System.Windows.Forms.Label()
        Me.SAAddM_ServiceDate = New System.Windows.Forms.Label()
        Me.SAAddM_CustodianID = New System.Windows.Forms.Label()
        Me.serialnumberlbs = New System.Windows.Forms.Label()
        Me.propertylbs = New System.Windows.Forms.Label()
        Me.SAAddM_ServiceProvided = New System.Windows.Forms.Label()
        Me.SAAddM_Providercontact = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.user = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.typesOfIssue = New System.Windows.Forms.ComboBox()
        Me.SAAddM_Description = New System.Windows.Forms.Label()
        Me.targetDate = New System.Windows.Forms.DateTimePicker()
        Me.problemDescription = New System.Windows.Forms.TextBox()
        Me.RoundedPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1084, 696)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 177
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(32, 60)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(443, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 174
        Me.admin_label_DepartmentManagement.Text = "Maintenance Request Form"
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
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(932, 696)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 178
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(19, 121)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1261, 43)
        Me.RoundedPanel1.TabIndex = 175
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.itemName)
        Me.Panel1.Controls.Add(Me.department)
        Me.Panel1.Controls.Add(Me.location)
        Me.Panel1.Controls.Add(Me.conditionBefore)
        Me.Panel1.Controls.Add(Me.serialNumber)
        Me.Panel1.Controls.Add(Me.SAAddM_ServiceType)
        Me.Panel1.Controls.Add(Me.SAAddM_ServiceDate)
        Me.Panel1.Controls.Add(Me.SAAddM_CustodianID)
        Me.Panel1.Controls.Add(Me.serialnumberlbs)
        Me.Panel1.Controls.Add(Me.propertylbs)
        Me.Panel1.Location = New System.Drawing.Point(45, 18)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(572, 336)
        Me.Panel1.TabIndex = 64
        '
        'itemName
        '
        Me.itemName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.itemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.itemName.FormattingEnabled = True
        Me.itemName.Location = New System.Drawing.Point(257, 44)
        Me.itemName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.itemName.Name = "itemName"
        Me.itemName.Size = New System.Drawing.Size(273, 26)
        Me.itemName.TabIndex = 73
        '
        'department
        '
        Me.department.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department.FormattingEnabled = True
        Me.department.Location = New System.Drawing.Point(255, 197)
        Me.department.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.department.Name = "department"
        Me.department.Size = New System.Drawing.Size(273, 26)
        Me.department.TabIndex = 72
        '
        'location
        '
        Me.location.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.FormattingEnabled = True
        Me.location.Location = New System.Drawing.Point(255, 144)
        Me.location.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(273, 26)
        Me.location.TabIndex = 71
        '
        'conditionBefore
        '
        Me.conditionBefore.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditionBefore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionBefore.FormattingEnabled = True
        Me.conditionBefore.Location = New System.Drawing.Point(279, 249)
        Me.conditionBefore.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.conditionBefore.Name = "conditionBefore"
        Me.conditionBefore.Size = New System.Drawing.Size(251, 26)
        Me.conditionBefore.TabIndex = 70
        '
        'serialNumber
        '
        Me.serialNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumber.Location = New System.Drawing.Point(255, 95)
        Me.serialNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Size = New System.Drawing.Size(273, 24)
        Me.serialNumber.TabIndex = 66
        '
        'SAAddM_ServiceType
        '
        Me.SAAddM_ServiceType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceType.AutoSize = True
        Me.SAAddM_ServiceType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceType.Location = New System.Drawing.Point(43, 256)
        Me.SAAddM_ServiceType.Name = "SAAddM_ServiceType"
        Me.SAAddM_ServiceType.Size = New System.Drawing.Size(207, 18)
        Me.SAAddM_ServiceType.TabIndex = 62
        Me.SAAddM_ServiceType.Text = "Condition Before Maintenance"
        '
        'SAAddM_ServiceDate
        '
        Me.SAAddM_ServiceDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceDate.AutoSize = True
        Me.SAAddM_ServiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceDate.Location = New System.Drawing.Point(43, 201)
        Me.SAAddM_ServiceDate.Name = "SAAddM_ServiceDate"
        Me.SAAddM_ServiceDate.Size = New System.Drawing.Size(85, 18)
        Me.SAAddM_ServiceDate.TabIndex = 61
        Me.SAAddM_ServiceDate.Text = "Department"
        '
        'SAAddM_CustodianID
        '
        Me.SAAddM_CustodianID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_CustodianID.AutoSize = True
        Me.SAAddM_CustodianID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_CustodianID.Location = New System.Drawing.Point(43, 151)
        Me.SAAddM_CustodianID.Name = "SAAddM_CustodianID"
        Me.SAAddM_CustodianID.Size = New System.Drawing.Size(65, 18)
        Me.SAAddM_CustodianID.TabIndex = 60
        Me.SAAddM_CustodianID.Text = "Location"
        '
        'serialnumberlbs
        '
        Me.serialnumberlbs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialnumberlbs.AutoSize = True
        Me.serialnumberlbs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialnumberlbs.Location = New System.Drawing.Point(43, 98)
        Me.serialnumberlbs.Name = "serialnumberlbs"
        Me.serialnumberlbs.Size = New System.Drawing.Size(102, 18)
        Me.serialnumberlbs.TabIndex = 59
        Me.serialnumberlbs.Text = "Serial Number"
        '
        'propertylbs
        '
        Me.propertylbs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertylbs.AutoSize = True
        Me.propertylbs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertylbs.Location = New System.Drawing.Point(43, 47)
        Me.propertylbs.Name = "propertylbs"
        Me.propertylbs.Size = New System.Drawing.Size(148, 18)
        Me.propertylbs.TabIndex = 58
        Me.propertylbs.Text = "Property / Item Name"
        '
        'SAAddM_ServiceProvided
        '
        Me.SAAddM_ServiceProvided.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceProvided.AutoSize = True
        Me.SAAddM_ServiceProvided.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceProvided.Location = New System.Drawing.Point(44, 95)
        Me.SAAddM_ServiceProvided.Name = "SAAddM_ServiceProvided"
        Me.SAAddM_ServiceProvided.Size = New System.Drawing.Size(143, 18)
        Me.SAAddM_ServiceProvided.TabIndex = 46
        Me.SAAddM_ServiceProvided.Text = "Problem Description"
        '
        'SAAddM_Providercontact
        '
        Me.SAAddM_Providercontact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Providercontact.AutoSize = True
        Me.SAAddM_Providercontact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Providercontact.Location = New System.Drawing.Point(44, 146)
        Me.SAAddM_Providercontact.Name = "SAAddM_Providercontact"
        Me.SAAddM_Providercontact.Size = New System.Drawing.Size(127, 18)
        Me.SAAddM_Providercontact.TabIndex = 47
        Me.SAAddM_Providercontact.Text = "Maintenance Date"
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(19, 214)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1261, 379)
        Me.RoundedPanel2.TabIndex = 176
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.user)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.typesOfIssue)
        Me.Panel2.Controls.Add(Me.SAAddM_Description)
        Me.Panel2.Controls.Add(Me.targetDate)
        Me.Panel2.Controls.Add(Me.problemDescription)
        Me.Panel2.Controls.Add(Me.SAAddM_ServiceProvided)
        Me.Panel2.Controls.Add(Me.SAAddM_Providercontact)
        Me.Panel2.Location = New System.Drawing.Point(685, 18)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(525, 336)
        Me.Panel2.TabIndex = 65
        '
        'user
        '
        Me.user.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.user.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.user.Location = New System.Drawing.Point(265, 194)
        Me.user.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(227, 24)
        Me.user.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 18)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Requested By"
        '
        'typesOfIssue
        '
        Me.typesOfIssue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.typesOfIssue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typesOfIssue.FormattingEnabled = True
        Me.typesOfIssue.Location = New System.Drawing.Point(265, 39)
        Me.typesOfIssue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.typesOfIssue.Name = "typesOfIssue"
        Me.typesOfIssue.Size = New System.Drawing.Size(227, 26)
        Me.typesOfIssue.TabIndex = 75
        '
        'SAAddM_Description
        '
        Me.SAAddM_Description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Description.AutoSize = True
        Me.SAAddM_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Description.Location = New System.Drawing.Point(44, 47)
        Me.SAAddM_Description.Name = "SAAddM_Description"
        Me.SAAddM_Description.Size = New System.Drawing.Size(96, 18)
        Me.SAAddM_Description.TabIndex = 74
        Me.SAAddM_Description.Text = "Type of Issue"
        '
        'targetDate
        '
        Me.targetDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.targetDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetDate.Location = New System.Drawing.Point(265, 146)
        Me.targetDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.targetDate.Name = "targetDate"
        Me.targetDate.Size = New System.Drawing.Size(227, 24)
        Me.targetDate.TabIndex = 75
        '
        'problemDescription
        '
        Me.problemDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.problemDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.problemDescription.Location = New System.Drawing.Point(265, 92)
        Me.problemDescription.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.problemDescription.Name = "problemDescription"
        Me.problemDescription.Size = New System.Drawing.Size(227, 24)
        Me.problemDescription.TabIndex = 68
        '
        'MaintenanceRequestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Name = "MaintenanceRequestForm"
        Me.Size = New System.Drawing.Size(1299, 790)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents btnCancel As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents department As System.Windows.Forms.ComboBox
    Friend Shadows WithEvents location As System.Windows.Forms.ComboBox
    Friend WithEvents conditionBefore As System.Windows.Forms.ComboBox
    Friend WithEvents serialNumber As System.Windows.Forms.TextBox
    Friend WithEvents SAAddM_ServiceType As System.Windows.Forms.Label
    Friend WithEvents SAAddM_ServiceDate As System.Windows.Forms.Label
    Friend WithEvents SAAddM_CustodianID As System.Windows.Forms.Label
    Friend WithEvents serialnumberlbs As System.Windows.Forms.Label
    Friend WithEvents propertylbs As System.Windows.Forms.Label
    Friend WithEvents SAAddM_ServiceProvided As System.Windows.Forms.Label
    Friend WithEvents SAAddM_Providercontact As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents typesOfIssue As System.Windows.Forms.ComboBox
    Friend WithEvents SAAddM_Description As System.Windows.Forms.Label
    Friend WithEvents targetDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents problemDescription As System.Windows.Forms.TextBox
    Friend WithEvents user As System.Windows.Forms.TextBox
    Friend WithEvents itemName As System.Windows.Forms.ComboBox
End Class
