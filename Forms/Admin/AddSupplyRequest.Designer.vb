<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSupplyRequest
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
        Me.instructions = New System.Windows.Forms.Label()
        Me.sqr_property_id = New System.Windows.Forms.Label()
        Me.sqr_department_id = New System.Windows.Forms.Label()
        Me.sqr_employeeID = New System.Windows.Forms.Label()
        Me.sqr_request_id = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.approved_by = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.position = New System.Windows.Forms.TextBox()
        Me.requesterName = New System.Windows.Forms.TextBox()
        Me.quantityRequest = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.itemName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.department = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.unit = New System.Windows.Forms.ComboBox()
        Me.quantityRequested = New System.Windows.Forms.NumericUpDown()
        Me.purpose = New System.Windows.Forms.TextBox()
        Me.description = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        CType(Me.quantityRequested, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(19, 25)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(189, 18)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required information."
        '
        'sqr_property_id
        '
        Me.sqr_property_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sqr_property_id.AutoSize = True
        Me.sqr_property_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sqr_property_id.Location = New System.Drawing.Point(43, 201)
        Me.sqr_property_id.Name = "sqr_property_id"
        Me.sqr_property_id.Size = New System.Drawing.Size(115, 18)
        Me.sqr_property_id.TabIndex = 61
        Me.sqr_property_id.Text = "Date of Request"
        '
        'sqr_department_id
        '
        Me.sqr_department_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sqr_department_id.AutoSize = True
        Me.sqr_department_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sqr_department_id.Location = New System.Drawing.Point(43, 151)
        Me.sqr_department_id.Name = "sqr_department_id"
        Me.sqr_department_id.Size = New System.Drawing.Size(85, 18)
        Me.sqr_department_id.TabIndex = 60
        Me.sqr_department_id.Text = "Department"
        '
        'sqr_employeeID
        '
        Me.sqr_employeeID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sqr_employeeID.AutoSize = True
        Me.sqr_employeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sqr_employeeID.Location = New System.Drawing.Point(43, 98)
        Me.sqr_employeeID.Name = "sqr_employeeID"
        Me.sqr_employeeID.Size = New System.Drawing.Size(62, 18)
        Me.sqr_employeeID.TabIndex = 59
        Me.sqr_employeeID.Text = "Position"
        '
        'sqr_request_id
        '
        Me.sqr_request_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sqr_request_id.AutoSize = True
        Me.sqr_request_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sqr_request_id.Location = New System.Drawing.Point(43, 47)
        Me.sqr_request_id.Name = "sqr_request_id"
        Me.sqr_request_id.Size = New System.Drawing.Size(137, 18)
        Me.sqr_request_id.TabIndex = 58
        Me.sqr_request_id.Text = "Name of Requester"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 18)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Description"
        '
        'approved_by
        '
        Me.approved_by.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.approved_by.AutoSize = True
        Me.approved_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.approved_by.Location = New System.Drawing.Point(29, 194)
        Me.approved_by.Name = "approved_by"
        Me.approved_by.Size = New System.Drawing.Size(120, 18)
        Me.approved_by.TabIndex = 46
        Me.approved_by.Text = "Purpose/Reason"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 18)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Quantity Requested"
        '
        'position
        '
        Me.position.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.position.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.position.Location = New System.Drawing.Point(223, 95)
        Me.position.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.position.Name = "position"
        Me.position.Size = New System.Drawing.Size(288, 24)
        Me.position.TabIndex = 76
        '
        'requesterName
        '
        Me.requesterName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requesterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requesterName.Location = New System.Drawing.Point(223, 44)
        Me.requesterName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.requesterName.Name = "requesterName"
        Me.requesterName.Size = New System.Drawing.Size(288, 24)
        Me.requesterName.TabIndex = 64
        '
        'quantityRequest
        '
        Me.quantityRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.quantityRequest.AutoSize = True
        Me.quantityRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantityRequest.Location = New System.Drawing.Point(44, 252)
        Me.quantityRequest.Name = "quantityRequest"
        Me.quantityRequest.Size = New System.Drawing.Size(80, 18)
        Me.quantityRequest.TabIndex = 62
        Me.quantityRequest.Text = "Item Name"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 18)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Unit"
        '
        'itemName
        '
        Me.itemName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.itemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.itemName.Location = New System.Drawing.Point(223, 250)
        Me.itemName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.itemName.Name = "itemName"
        Me.itemName.Size = New System.Drawing.Size(288, 24)
        Me.itemName.TabIndex = 88
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.department)
        Me.Panel1.Controls.Add(Me.itemName)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.position)
        Me.Panel1.Controls.Add(Me.requesterName)
        Me.Panel1.Controls.Add(Me.quantityRequest)
        Me.Panel1.Controls.Add(Me.sqr_property_id)
        Me.Panel1.Controls.Add(Me.sqr_department_id)
        Me.Panel1.Controls.Add(Me.sqr_employeeID)
        Me.Panel1.Controls.Add(Me.sqr_request_id)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 415)
        Me.Panel1.TabIndex = 64
        '
        'department
        '
        Me.department.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.department.FormattingEnabled = True
        Me.department.Location = New System.Drawing.Point(223, 151)
        Me.department.Name = "department"
        Me.department.Size = New System.Drawing.Size(288, 26)
        Me.department.TabIndex = 128
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(223, 201)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(288, 24)
        Me.DateTimePicker1.TabIndex = 79
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(109, 68)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1264, 71)
        Me.RoundedPanel1.TabIndex = 157
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.unit)
        Me.Panel2.Controls.Add(Me.quantityRequested)
        Me.Panel2.Controls.Add(Me.purpose)
        Me.Panel2.Controls.Add(Me.description)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.approved_by)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(656, 18)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(537, 415)
        Me.Panel2.TabIndex = 65
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1001, 738)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 160
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
        Me.btnSave.Location = New System.Drawing.Point(1155, 738)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 159
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
        Me.RoundedPanel2.Location = New System.Drawing.Point(109, 158)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1264, 458)
        Me.RoundedPanel2.TabIndex = 158
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(99, 8)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(352, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 156
        Me.admin_label_DepartmentManagement.Text = "Supply Request Form"
        '
        'unit
        '
        Me.unit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unit.FormattingEnabled = True
        Me.unit.Location = New System.Drawing.Point(177, 145)
        Me.unit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.unit.Name = "unit"
        Me.unit.Size = New System.Drawing.Size(291, 26)
        Me.unit.TabIndex = 99
        '
        'quantityRequested
        '
        Me.quantityRequested.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.quantityRequested.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantityRequested.Location = New System.Drawing.Point(177, 97)
        Me.quantityRequested.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.quantityRequested.Name = "quantityRequested"
        Me.quantityRequested.Size = New System.Drawing.Size(291, 24)
        Me.quantityRequested.TabIndex = 98
        '
        'purpose
        '
        Me.purpose.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.purpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.purpose.Location = New System.Drawing.Point(177, 198)
        Me.purpose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.purpose.Multiline = True
        Me.purpose.Name = "purpose"
        Me.purpose.Size = New System.Drawing.Size(288, 158)
        Me.purpose.TabIndex = 97
        '
        'description
        '
        Me.description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(177, 53)
        Me.description.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(291, 24)
        Me.description.TabIndex = 96
        '
        'AddSupplyRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "AddSupplyRequest"
        Me.Size = New System.Drawing.Size(1473, 810)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        CType(Me.quantityRequested, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents sqr_property_id As System.Windows.Forms.Label
    Friend WithEvents sqr_department_id As System.Windows.Forms.Label
    Friend WithEvents sqr_employeeID As System.Windows.Forms.Label
    Friend WithEvents sqr_request_id As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents approved_by As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents position As System.Windows.Forms.TextBox
    Friend WithEvents requesterName As System.Windows.Forms.TextBox
    Friend WithEvents quantityRequest As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents itemName As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents department As System.Windows.Forms.ComboBox
    Friend WithEvents unit As System.Windows.Forms.ComboBox
    Friend WithEvents quantityRequested As System.Windows.Forms.NumericUpDown
    Friend WithEvents purpose As System.Windows.Forms.TextBox
    Friend WithEvents description As System.Windows.Forms.TextBox
End Class
