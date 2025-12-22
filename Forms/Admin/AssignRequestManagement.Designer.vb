<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssignRequestManagement
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.ConditionStatus = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.serialNumber = New System.Windows.Forms.TextBox()
        Me.um_edituser_fullname = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.suppier = New System.Windows.Forms.TextBox()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.warrantyExpiration = New System.Windows.Forms.DateTimePicker()
        Me.datePurchased = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.assignmentPurpose = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateCreatedlbl = New System.Windows.Forms.Label()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateUpdatedlbl = New System.Windows.Forms.Label()
        Me.UpdatedBylbl = New System.Windows.Forms.Label()
        Me.condition = New System.Windows.Forms.ComboBox()
        Me.dateCreated = New System.Windows.Forms.DateTimePicker()
        Me.dateUpdated = New System.Windows.Forms.DateTimePicker()
        Me.updatedBy = New System.Windows.Forms.ComboBox()
        Me.department = New System.Windows.Forms.ComboBox()
        Me.employee = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.propertyId = New System.Windows.Forms.ComboBox()
        Me.propertyName = New System.Windows.Forms.ComboBox()
        Me.cost = New System.Windows.Forms.NumericUpDown()
        Me.location = New System.Windows.Forms.ComboBox()
        Me.remarks = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.RoundedPanel4.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        CType(Me.cost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(79, 326)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 26)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Date Purchased"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(79, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 26)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Supplier"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(79, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 26)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Category"
        '
        'Label3
        '
        Me.Label3.AllowDrop = True
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(79, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 26)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Property I.D"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(79, 361)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 26)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Warranty Expiration"
        '
        'lblCost
        '
        Me.lblCost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCost.AutoSize = True
        Me.lblCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblCost.ForeColor = System.Drawing.Color.Black
        Me.lblCost.Location = New System.Drawing.Point(79, 291)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(47, 26)
        Me.lblCost.TabIndex = 78
        Me.lblCost.Text = "Cost"
        '
        'ConditionStatus
        '
        Me.ConditionStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConditionStatus.AutoSize = True
        Me.ConditionStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.ConditionStatus.ForeColor = System.Drawing.Color.Black
        Me.ConditionStatus.Location = New System.Drawing.Point(79, 250)
        Me.ConditionStatus.Name = "ConditionStatus"
        Me.ConditionStatus.Size = New System.Drawing.Size(138, 26)
        Me.ConditionStatus.TabIndex = 76
        Me.ConditionStatus.Text = "Condition Status"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblSerialNumber.ForeColor = System.Drawing.Color.Black
        Me.lblSerialNumber.Location = New System.Drawing.Point(79, 180)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(119, 26)
        Me.lblSerialNumber.TabIndex = 75
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'serialNumber
        '
        Me.serialNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialNumber.BackColor = System.Drawing.SystemColors.Window
        Me.serialNumber.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.serialNumber.Location = New System.Drawing.Point(245, 180)
        Me.serialNumber.MaxLength = 100
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Size = New System.Drawing.Size(323, 27)
        Me.serialNumber.TabIndex = 74
        '
        'um_edituser_fullname
        '
        Me.um_edituser_fullname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.um_edituser_fullname.AutoSize = True
        Me.um_edituser_fullname.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.um_edituser_fullname.ForeColor = System.Drawing.Color.Black
        Me.um_edituser_fullname.Location = New System.Drawing.Point(79, 114)
        Me.um_edituser_fullname.Name = "um_edituser_fullname"
        Me.um_edituser_fullname.Size = New System.Drawing.Size(124, 26)
        Me.um_edituser_fullname.TabIndex = 73
        Me.um_edituser_fullname.Text = "Property Name"
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(632, 32)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(301, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 108
        Me.admin_label_DepartmentManagement.Text = "Assign Property"
        '
        'suppier
        '
        Me.suppier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.suppier.BackColor = System.Drawing.SystemColors.Window
        Me.suppier.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suppier.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.suppier.Location = New System.Drawing.Point(245, 217)
        Me.suppier.MaxLength = 100
        Me.suppier.Name = "suppier"
        Me.suppier.Size = New System.Drawing.Size(323, 27)
        Me.suppier.TabIndex = 109
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RoundedPanel1.Controls.Add(Me.cost)
        Me.RoundedPanel1.Controls.Add(Me.propertyName)
        Me.RoundedPanel1.Controls.Add(Me.propertyId)
        Me.RoundedPanel1.Controls.Add(Me.warrantyExpiration)
        Me.RoundedPanel1.Controls.Add(Me.datePurchased)
        Me.RoundedPanel1.Controls.Add(Me.ComboBox3)
        Me.RoundedPanel1.Controls.Add(Me.ComboBox1)
        Me.RoundedPanel1.Controls.Add(Me.RoundedPanel2)
        Me.RoundedPanel1.Controls.Add(Me.Label3)
        Me.RoundedPanel1.Controls.Add(Me.um_edituser_fullname)
        Me.RoundedPanel1.Controls.Add(Me.suppier)
        Me.RoundedPanel1.Controls.Add(Me.Label8)
        Me.RoundedPanel1.Controls.Add(Me.Label5)
        Me.RoundedPanel1.Controls.Add(Me.lblSerialNumber)
        Me.RoundedPanel1.Controls.Add(Me.serialNumber)
        Me.RoundedPanel1.Controls.Add(Me.Label7)
        Me.RoundedPanel1.Controls.Add(Me.ConditionStatus)
        Me.RoundedPanel1.Controls.Add(Me.lblCost)
        Me.RoundedPanel1.Controls.Add(Me.Label2)
        Me.RoundedPanel1.CornerRadius = 10
        Me.RoundedPanel1.Location = New System.Drawing.Point(106, 109)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1317, 424)
        Me.RoundedPanel1.TabIndex = 115
        '
        'warrantyExpiration
        '
        Me.warrantyExpiration.Location = New System.Drawing.Point(245, 361)
        Me.warrantyExpiration.Name = "warrantyExpiration"
        Me.warrantyExpiration.Size = New System.Drawing.Size(325, 22)
        Me.warrantyExpiration.TabIndex = 116
        '
        'datePurchased
        '
        Me.datePurchased.Location = New System.Drawing.Point(245, 326)
        Me.datePurchased.Name = "datePurchased"
        Me.datePurchased.Size = New System.Drawing.Size(325, 22)
        Me.datePurchased.TabIndex = 119
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(245, 252)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(325, 24)
        Me.ComboBox3.TabIndex = 118
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(245, 148)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(325, 24)
        Me.ComboBox1.TabIndex = 117
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RoundedPanel2.Controls.Add(Me.Label1)
        Me.RoundedPanel2.CornerRadius = 1
        Me.RoundedPanel2.Location = New System.Drawing.Point(17, 8)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1278, 47)
        Me.RoundedPanel2.TabIndex = 116
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 26)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Property Information"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1125, 1038)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 157
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
        Me.btnSave.Location = New System.Drawing.Point(1278, 1038)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 156
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(79, 250)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(138, 26)
        Me.Label21.TabIndex = 76
        Me.Label21.Text = "Condition Status"
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(79, 217)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(167, 26)
        Me.Label20.TabIndex = 95
        Me.Label20.Text = "Assignment Purpose"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(79, 180)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 26)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "Remarks"
        '
        'Label16
        '
        Me.Label16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(79, 147)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 26)
        Me.Label16.TabIndex = 94
        Me.Label16.Text = "Location"
        '
        'assignmentPurpose
        '
        Me.assignmentPurpose.BackColor = System.Drawing.SystemColors.Window
        Me.assignmentPurpose.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignmentPurpose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.assignmentPurpose.Location = New System.Drawing.Point(245, 217)
        Me.assignmentPurpose.MaxLength = 100
        Me.assignmentPurpose.Name = "assignmentPurpose"
        Me.assignmentPurpose.Size = New System.Drawing.Size(323, 27)
        Me.assignmentPurpose.TabIndex = 109
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(79, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 26)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "Employee"
        '
        'Label6
        '
        Me.Label6.AllowDrop = True
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(79, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 26)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Department"
        '
        'DateCreatedlbl
        '
        Me.DateCreatedlbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateCreatedlbl.AutoSize = True
        Me.DateCreatedlbl.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.DateCreatedlbl.ForeColor = System.Drawing.Color.Black
        Me.DateCreatedlbl.Location = New System.Drawing.Point(79, 287)
        Me.DateCreatedlbl.Name = "DateCreatedlbl"
        Me.DateCreatedlbl.Size = New System.Drawing.Size(112, 26)
        Me.DateCreatedlbl.TabIndex = 87
        Me.DateCreatedlbl.Text = "Date Created"
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RoundedPanel4.Controls.Add(Me.Label4)
        Me.RoundedPanel4.CornerRadius = 1
        Me.RoundedPanel4.Location = New System.Drawing.Point(17, 8)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(1278, 52)
        Me.RoundedPanel4.TabIndex = 116
        '
        'Label4
        '
        Me.Label4.AllowDrop = True
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 26)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Assignment Details"
        '
        'DateUpdatedlbl
        '
        Me.DateUpdatedlbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateUpdatedlbl.AutoSize = True
        Me.DateUpdatedlbl.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.DateUpdatedlbl.ForeColor = System.Drawing.Color.Black
        Me.DateUpdatedlbl.Location = New System.Drawing.Point(79, 324)
        Me.DateUpdatedlbl.Name = "DateUpdatedlbl"
        Me.DateUpdatedlbl.Size = New System.Drawing.Size(115, 26)
        Me.DateUpdatedlbl.TabIndex = 88
        Me.DateUpdatedlbl.Text = "Date Updated"
        '
        'UpdatedBylbl
        '
        Me.UpdatedBylbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UpdatedBylbl.AutoSize = True
        Me.UpdatedBylbl.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.UpdatedBylbl.ForeColor = System.Drawing.Color.Black
        Me.UpdatedBylbl.Location = New System.Drawing.Point(78, 358)
        Me.UpdatedBylbl.Name = "UpdatedBylbl"
        Me.UpdatedBylbl.Size = New System.Drawing.Size(98, 26)
        Me.UpdatedBylbl.TabIndex = 85
        Me.UpdatedBylbl.Text = "Updated by"
        '
        'condition
        '
        Me.condition.FormattingEnabled = True
        Me.condition.Location = New System.Drawing.Point(245, 252)
        Me.condition.Name = "condition"
        Me.condition.Size = New System.Drawing.Size(325, 24)
        Me.condition.TabIndex = 118
        '
        'dateCreated
        '
        Me.dateCreated.Location = New System.Drawing.Point(245, 291)
        Me.dateCreated.Name = "dateCreated"
        Me.dateCreated.Size = New System.Drawing.Size(325, 22)
        Me.dateCreated.TabIndex = 123
        '
        'dateUpdated
        '
        Me.dateUpdated.Location = New System.Drawing.Point(245, 328)
        Me.dateUpdated.Name = "dateUpdated"
        Me.dateUpdated.Size = New System.Drawing.Size(325, 22)
        Me.dateUpdated.TabIndex = 124
        '
        'updatedBy
        '
        Me.updatedBy.FormattingEnabled = True
        Me.updatedBy.Location = New System.Drawing.Point(245, 358)
        Me.updatedBy.Name = "updatedBy"
        Me.updatedBy.Size = New System.Drawing.Size(325, 24)
        Me.updatedBy.TabIndex = 125
        '
        'department
        '
        Me.department.FormattingEnabled = True
        Me.department.Location = New System.Drawing.Point(245, 80)
        Me.department.Name = "department"
        Me.department.Size = New System.Drawing.Size(325, 24)
        Me.department.TabIndex = 126
        '
        'employee
        '
        Me.employee.FormattingEnabled = True
        Me.employee.Location = New System.Drawing.Point(245, 115)
        Me.employee.Name = "employee"
        Me.employee.Size = New System.Drawing.Size(325, 24)
        Me.employee.TabIndex = 127
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel3.BackColor = System.Drawing.Color.White
        Me.RoundedPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RoundedPanel3.Controls.Add(Me.remarks)
        Me.RoundedPanel3.Controls.Add(Me.location)
        Me.RoundedPanel3.Controls.Add(Me.employee)
        Me.RoundedPanel3.Controls.Add(Me.department)
        Me.RoundedPanel3.Controls.Add(Me.updatedBy)
        Me.RoundedPanel3.Controls.Add(Me.dateUpdated)
        Me.RoundedPanel3.Controls.Add(Me.dateCreated)
        Me.RoundedPanel3.Controls.Add(Me.condition)
        Me.RoundedPanel3.Controls.Add(Me.UpdatedBylbl)
        Me.RoundedPanel3.Controls.Add(Me.DateUpdatedlbl)
        Me.RoundedPanel3.Controls.Add(Me.RoundedPanel4)
        Me.RoundedPanel3.Controls.Add(Me.DateCreatedlbl)
        Me.RoundedPanel3.Controls.Add(Me.Label6)
        Me.RoundedPanel3.Controls.Add(Me.Label13)
        Me.RoundedPanel3.Controls.Add(Me.assignmentPurpose)
        Me.RoundedPanel3.Controls.Add(Me.Label16)
        Me.RoundedPanel3.Controls.Add(Me.Label18)
        Me.RoundedPanel3.Controls.Add(Me.Label20)
        Me.RoundedPanel3.Controls.Add(Me.Label21)
        Me.RoundedPanel3.CornerRadius = 10
        Me.RoundedPanel3.Location = New System.Drawing.Point(106, 564)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(1317, 415)
        Me.RoundedPanel3.TabIndex = 126
        '
        'propertyId
        '
        Me.propertyId.FormattingEnabled = True
        Me.propertyId.Location = New System.Drawing.Point(245, 80)
        Me.propertyId.Name = "propertyId"
        Me.propertyId.Size = New System.Drawing.Size(325, 24)
        Me.propertyId.TabIndex = 120
        '
        'propertyName
        '
        Me.propertyName.FormattingEnabled = True
        Me.propertyName.Location = New System.Drawing.Point(245, 114)
        Me.propertyName.Name = "propertyName"
        Me.propertyName.Size = New System.Drawing.Size(325, 24)
        Me.propertyName.TabIndex = 121
        '
        'cost
        '
        Me.cost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cost.Location = New System.Drawing.Point(245, 291)
        Me.cost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cost.Name = "cost"
        Me.cost.Size = New System.Drawing.Size(330, 24)
        Me.cost.TabIndex = 122
        '
        'location
        '
        Me.location.FormattingEnabled = True
        Me.location.Location = New System.Drawing.Point(245, 149)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(325, 24)
        Me.location.TabIndex = 129
        '
        'remarks
        '
        Me.remarks.FormattingEnabled = True
        Me.remarks.Location = New System.Drawing.Point(245, 181)
        Me.remarks.Name = "remarks"
        Me.remarks.Size = New System.Drawing.Size(325, 24)
        Me.remarks.TabIndex = 130
        '
        'AssignRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Name = "AssignRequestManagement"
        Me.Size = New System.Drawing.Size(1529, 1099)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        Me.RoundedPanel4.ResumeLayout(False)
        Me.RoundedPanel4.PerformLayout()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        CType(Me.cost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents ConditionStatus As System.Windows.Forms.Label
    Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
    Friend WithEvents serialNumber As System.Windows.Forms.TextBox
    Friend WithEvents um_edituser_fullname As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents suppier As System.Windows.Forms.TextBox
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents warrantyExpiration As System.Windows.Forms.DateTimePicker
    Friend WithEvents datePurchased As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents assignmentPurpose As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateCreatedlbl As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel4 As Resources.Controls.RoundedPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateUpdatedlbl As System.Windows.Forms.Label
    Friend WithEvents UpdatedBylbl As System.Windows.Forms.Label
    Friend WithEvents condition As System.Windows.Forms.ComboBox
    Friend WithEvents dateCreated As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateUpdated As System.Windows.Forms.DateTimePicker
    Friend WithEvents updatedBy As System.Windows.Forms.ComboBox
    Friend WithEvents department As System.Windows.Forms.ComboBox
    Friend WithEvents employee As System.Windows.Forms.ComboBox
    Friend WithEvents RoundedPanel3 As Resources.Controls.RoundedPanel
    Friend WithEvents propertyId As System.Windows.Forms.ComboBox
    Friend WithEvents propertyName As System.Windows.Forms.ComboBox
    Friend WithEvents cost As System.Windows.Forms.NumericUpDown
    Friend WithEvents remarks As System.Windows.Forms.ComboBox
    Friend Shadows WithEvents location As System.Windows.Forms.ComboBox
End Class
