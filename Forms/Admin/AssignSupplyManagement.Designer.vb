<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssignSupplyManagement
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
        Me.admin_label_AssignSupply = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.supplyId = New System.Windows.Forms.ComboBox()
        Me.supplyName = New System.Windows.Forms.ComboBox()
        Me.category = New System.Windows.Forms.ComboBox()
        Me.description = New System.Windows.Forms.TextBox()
        Me.supplier = New System.Windows.Forms.TextBox()
        Me.unitOfMeasure = New System.Windows.Forms.ComboBox()
        Me.stockStatus = New System.Windows.Forms.ComboBox()
        Me.quantityAvailable = New System.Windows.Forms.NumericUpDown()
        Me.unitCost = New System.Windows.Forms.NumericUpDown()
        Me.location = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.department = New System.Windows.Forms.ComboBox()
        Me.employee = New System.Windows.Forms.ComboBox()
        Me.quantityToAssign = New System.Windows.Forms.NumericUpDown()
        Me.assignmentPurpose = New System.Windows.Forms.TextBox()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        CType(Me.quantityAvailable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.unitCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel3.SuspendLayout()
        Me.RoundedPanel4.SuspendLayout()
        CType(Me.quantityToAssign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_AssignSupply
        '
        Me.admin_label_AssignSupply.AutoSize = True
        Me.admin_label_AssignSupply.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_AssignSupply.Location = New System.Drawing.Point(632, 32)
        Me.admin_label_AssignSupply.Name = "admin_label_AssignSupply"
        Me.admin_label_AssignSupply.Size = New System.Drawing.Size(265, 58)
        Me.admin_label_AssignSupply.TabIndex = 108
        Me.admin_label_AssignSupply.Text = "Assign Supply"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RoundedPanel1.Controls.Add(Me.location)
        Me.RoundedPanel1.Controls.Add(Me.unitCost)
        Me.RoundedPanel1.Controls.Add(Me.quantityAvailable)
        Me.RoundedPanel1.Controls.Add(Me.stockStatus)
        Me.RoundedPanel1.Controls.Add(Me.unitOfMeasure)
        Me.RoundedPanel1.Controls.Add(Me.supplier)
        Me.RoundedPanel1.Controls.Add(Me.description)
        Me.RoundedPanel1.Controls.Add(Me.category)
        Me.RoundedPanel1.Controls.Add(Me.supplyName)
        Me.RoundedPanel1.Controls.Add(Me.supplyId)
        Me.RoundedPanel1.Controls.Add(Me.Label11)
        Me.RoundedPanel1.Controls.Add(Me.Label10)
        Me.RoundedPanel1.Controls.Add(Me.Label9)
        Me.RoundedPanel1.Controls.Add(Me.Label8)
        Me.RoundedPanel1.Controls.Add(Me.Label7)
        Me.RoundedPanel1.Controls.Add(Me.Label6)
        Me.RoundedPanel1.Controls.Add(Me.Label5)
        Me.RoundedPanel1.Controls.Add(Me.Label4)
        Me.RoundedPanel1.Controls.Add(Me.Label3)
        Me.RoundedPanel1.Controls.Add(Me.RoundedPanel2)
        Me.RoundedPanel1.CornerRadius = 10
        Me.RoundedPanel1.Location = New System.Drawing.Point(106, 109)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1317, 424)
        Me.RoundedPanel1.TabIndex = 115
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
        Me.Label1.Size = New System.Drawing.Size(149, 26)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Supply Information"
        '
        'Label3
        '
        Me.Label3.AllowDrop = True
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(79, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 26)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Supply I.D"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(79, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 26)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Supply Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(79, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 26)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Category"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(79, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 26)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(79, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 26)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Supplier"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(79, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 26)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Unit of Measure"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(79, 284)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 26)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Stock Status"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(79, 318)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 26)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Quantity Available"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(79, 352)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 26)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Unit Cost"
        '
        'supplyId
        '
        Me.supplyId.FormattingEnabled = True
        Me.supplyId.Location = New System.Drawing.Point(245, 80)
        Me.supplyId.Name = "supplyId"
        Me.supplyId.Size = New System.Drawing.Size(325, 24)
        Me.supplyId.TabIndex = 117
        '
        'supplyName
        '
        Me.supplyName.FormattingEnabled = True
        Me.supplyName.Location = New System.Drawing.Point(245, 114)
        Me.supplyName.Name = "supplyName"
        Me.supplyName.Size = New System.Drawing.Size(325, 24)
        Me.supplyName.TabIndex = 118
        '
        'category
        '
        Me.category.FormattingEnabled = True
        Me.category.Location = New System.Drawing.Point(245, 148)
        Me.category.Name = "category"
        Me.category.Size = New System.Drawing.Size(325, 24)
        Me.category.TabIndex = 119
        '
        'description
        '
        Me.description.Location = New System.Drawing.Point(245, 182)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(325, 22)
        Me.description.TabIndex = 120
        '
        'supplier
        '
        Me.supplier.Location = New System.Drawing.Point(245, 216)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(325, 22)
        Me.supplier.TabIndex = 121
        '
        'unitOfMeasure
        '
        Me.unitOfMeasure.FormattingEnabled = True
        Me.unitOfMeasure.Location = New System.Drawing.Point(245, 250)
        Me.unitOfMeasure.Name = "unitOfMeasure"
        Me.unitOfMeasure.Size = New System.Drawing.Size(325, 24)
        Me.unitOfMeasure.TabIndex = 122
        '
        'stockStatus
        '
        Me.stockStatus.FormattingEnabled = True
        Me.stockStatus.Location = New System.Drawing.Point(245, 284)
        Me.stockStatus.Name = "stockStatus"
        Me.stockStatus.Size = New System.Drawing.Size(325, 24)
        Me.stockStatus.TabIndex = 123
        '
        'quantityAvailable
        '
        Me.quantityAvailable.Location = New System.Drawing.Point(245, 318)
        Me.quantityAvailable.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.quantityAvailable.Name = "quantityAvailable"
        Me.quantityAvailable.ReadOnly = True
        Me.quantityAvailable.Size = New System.Drawing.Size(325, 22)
        Me.quantityAvailable.TabIndex = 124
        '
        'unitCost
        '
        Me.unitCost.DecimalPlaces = 2
        Me.unitCost.Location = New System.Drawing.Point(245, 352)
        Me.unitCost.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.unitCost.Name = "unitCost"
        Me.unitCost.ReadOnly = True
        Me.unitCost.Size = New System.Drawing.Size(325, 22)
        Me.unitCost.TabIndex = 125
        '
        'location
        '
        Me.location.FormattingEnabled = True
        Me.location.Location = New System.Drawing.Point(245, 386)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(325, 24)
        Me.location.TabIndex = 126
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel3.BackColor = System.Drawing.Color.White
        Me.RoundedPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RoundedPanel3.Controls.Add(Me.assignmentPurpose)
        Me.RoundedPanel3.Controls.Add(Me.quantityToAssign)
        Me.RoundedPanel3.Controls.Add(Me.employee)
        Me.RoundedPanel3.Controls.Add(Me.department)
        Me.RoundedPanel3.Controls.Add(Me.Label15)
        Me.RoundedPanel3.Controls.Add(Me.Label14)
        Me.RoundedPanel3.Controls.Add(Me.Label13)
        Me.RoundedPanel3.Controls.Add(Me.Label12)
        Me.RoundedPanel3.Controls.Add(Me.RoundedPanel4)
        Me.RoundedPanel3.CornerRadius = 10
        Me.RoundedPanel3.Location = New System.Drawing.Point(106, 564)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(1317, 250)
        Me.RoundedPanel3.TabIndex = 126
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RoundedPanel4.Controls.Add(Me.Label2)
        Me.RoundedPanel4.CornerRadius = 1
        Me.RoundedPanel4.Location = New System.Drawing.Point(17, 8)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(1278, 52)
        Me.RoundedPanel4.TabIndex = 116
        '
        'Label2
        '
        Me.Label2.AllowDrop = True
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 26)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Assignment Details"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(79, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 26)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "Department"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(79, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 26)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "Employee"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(79, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(137, 26)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Quantity to Assign"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(79, 182)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 26)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "Assignment Purpose"
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
        Me.employee.Location = New System.Drawing.Point(245, 114)
        Me.employee.Name = "employee"
        Me.employee.Size = New System.Drawing.Size(325, 24)
        Me.employee.TabIndex = 127
        '
        'quantityToAssign
        '
        Me.quantityToAssign.Location = New System.Drawing.Point(245, 148)
        Me.quantityToAssign.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.quantityToAssign.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.quantityToAssign.Name = "quantityToAssign"
        Me.quantityToAssign.Size = New System.Drawing.Size(325, 22)
        Me.quantityToAssign.TabIndex = 128
        Me.quantityToAssign.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'assignmentPurpose
        '
        Me.assignmentPurpose.Location = New System.Drawing.Point(245, 182)
        Me.assignmentPurpose.Multiline = True
        Me.assignmentPurpose.Name = "assignmentPurpose"
        Me.assignmentPurpose.Size = New System.Drawing.Size(325, 50)
        Me.assignmentPurpose.TabIndex = 129
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1125, 850)
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
        Me.btnSave.Location = New System.Drawing.Point(1278, 850)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 156
        Me.btnSave.Text = "Assign"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AssignSupplyManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.admin_label_AssignSupply)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Name = "AssignSupplyManagement"
        Me.Size = New System.Drawing.Size(1529, 920)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        CType(Me.quantityAvailable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.unitCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        Me.RoundedPanel4.ResumeLayout(False)
        Me.RoundedPanel4.PerformLayout()
        CType(Me.quantityToAssign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_AssignSupply As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents supplyId As System.Windows.Forms.ComboBox
    Friend WithEvents supplyName As System.Windows.Forms.ComboBox
    Friend WithEvents category As System.Windows.Forms.ComboBox
    Friend WithEvents description As System.Windows.Forms.TextBox
    Friend WithEvents supplier As System.Windows.Forms.TextBox
    Friend WithEvents unitOfMeasure As System.Windows.Forms.ComboBox
    Friend WithEvents stockStatus As System.Windows.Forms.ComboBox
    Friend WithEvents quantityAvailable As System.Windows.Forms.NumericUpDown
    Friend WithEvents unitCost As System.Windows.Forms.NumericUpDown
    Friend WithEvents location As System.Windows.Forms.ComboBox
    Friend WithEvents RoundedPanel3 As Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As Resources.Controls.RoundedPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents department As System.Windows.Forms.ComboBox
    Friend WithEvents employee As System.Windows.Forms.ComboBox
    Friend WithEvents quantityToAssign As System.Windows.Forms.NumericUpDown
    Friend WithEvents assignmentPurpose As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
End Class

