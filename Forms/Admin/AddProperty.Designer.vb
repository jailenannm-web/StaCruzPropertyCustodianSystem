<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProperty
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
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.status = New System.Windows.Forms.ComboBox()
        Me.warranty = New System.Windows.Forms.Label()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.condition = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.no_of_employees_numeric = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.warrantyExpirationDate = New System.Windows.Forms.DateTimePicker()
        Me.assignedTo = New System.Windows.Forms.TextBox()
        Me.department = New System.Windows.Forms.ComboBox()
        Me.propertyLocation = New System.Windows.Forms.TextBox()
        Me.assignedEmployee = New System.Windows.Forms.Label()
        Me.warrantyExpiration = New System.Windows.Forms.Label()
        Me.location = New System.Windows.Forms.Label()
        Me.remarks = New System.Windows.Forms.Label()
        Me.acquisitionCost = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.acquisitionDate = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.description = New System.Windows.Forms.TextBox()
        Me.propertyNumber = New System.Windows.Forms.TextBox()
        Me.category = New System.Windows.Forms.ComboBox()
        Me.supplierTxt = New System.Windows.Forms.TextBox()
        Me.serialNumberTxt = New System.Windows.Forms.TextBox()
        Me.itemName = New System.Windows.Forms.TextBox()
        Me.cost = New System.Windows.Forms.Label()
        Me.conditionStatus = New System.Windows.Forms.Label()
        Me.supplier = New System.Windows.Forms.Label()
        Me.serialNumber = New System.Windows.Forms.Label()
        Me.property_Category = New System.Windows.Forms.Label()
        Me.item_name = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(39, 203)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1264, 471)
        Me.RoundedPanel2.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.status)
        Me.Panel2.Controls.Add(Me.warranty)
        Me.Panel2.Controls.Add(Me.lblstatus)
        Me.Panel2.Controls.Add(Me.condition)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.no_of_employees_numeric)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.warrantyExpirationDate)
        Me.Panel2.Controls.Add(Me.assignedTo)
        Me.Panel2.Controls.Add(Me.department)
        Me.Panel2.Controls.Add(Me.propertyLocation)
        Me.Panel2.Controls.Add(Me.assignedEmployee)
        Me.Panel2.Controls.Add(Me.warrantyExpiration)
        Me.Panel2.Controls.Add(Me.location)
        Me.Panel2.Controls.Add(Me.remarks)
        Me.Panel2.Controls.Add(Me.acquisitionCost)
        Me.Panel2.Location = New System.Drawing.Point(655, 18)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(537, 428)
        Me.Panel2.TabIndex = 65
        '
        'status
        '
        Me.status.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.FormattingEnabled = True
        Me.status.Items.AddRange(New Object() {"GOOD", "DAMAGE", "READY TO USE"})
        Me.status.Location = New System.Drawing.Point(246, 148)
        Me.status.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(255, 26)
        Me.status.TabIndex = 80
        '
        'warranty
        '
        Me.warranty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.warranty.AutoSize = True
        Me.warranty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.warranty.Location = New System.Drawing.Point(45, 16)
        Me.warranty.Name = "warranty"
        Me.warranty.Size = New System.Drawing.Size(64, 18)
        Me.warranty.TabIndex = 79
        Me.warranty.Text = "warranty"
        '
        'lblstatus
        '
        Me.lblstatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatus.Location = New System.Drawing.Point(45, 154)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(48, 18)
        Me.lblstatus.TabIndex = 78
        Me.lblstatus.Text = "status"
        '
        'condition
        '
        Me.condition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.condition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.condition.FormattingEnabled = True
        Me.condition.Items.AddRange(New Object() {"GOOD", "DAMAGE", "READY TO USE"})
        Me.condition.Location = New System.Drawing.Point(244, 348)
        Me.condition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.condition.Name = "condition"
        Me.condition.Size = New System.Drawing.Size(255, 26)
        Me.condition.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 352)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 18)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Condition"
        '
        'no_of_employees_numeric
        '
        Me.no_of_employees_numeric.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.no_of_employees_numeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.no_of_employees_numeric.Location = New System.Drawing.Point(244, 56)
        Me.no_of_employees_numeric.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.no_of_employees_numeric.Name = "no_of_employees_numeric"
        Me.no_of_employees_numeric.Size = New System.Drawing.Size(253, 24)
        Me.no_of_employees_numeric.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 304)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 18)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Location"
        '
        'warrantyExpirationDate
        '
        Me.warrantyExpirationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.warrantyExpirationDate.Location = New System.Drawing.Point(244, 11)
        Me.warrantyExpirationDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.warrantyExpirationDate.Name = "warrantyExpirationDate"
        Me.warrantyExpirationDate.Size = New System.Drawing.Size(239, 24)
        Me.warrantyExpirationDate.TabIndex = 67
        '
        'assignedTo
        '
        Me.assignedTo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedTo.Location = New System.Drawing.Point(244, 198)
        Me.assignedTo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.assignedTo.Name = "assignedTo"
        Me.assignedTo.Size = New System.Drawing.Size(239, 24)
        Me.assignedTo.TabIndex = 66
        '
        'department
        '
        Me.department.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department.FormattingEnabled = True
        Me.department.Items.AddRange(New Object() {"MATH DEPARTMENT", "SCIENCE DEPARTMENT", "ENGLISH DEPARTMENT", "MAPEH DEPARMENT", "TLE DEPARTMENT"})
        Me.department.Location = New System.Drawing.Point(244, 253)
        Me.department.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.department.Name = "department"
        Me.department.Size = New System.Drawing.Size(239, 26)
        Me.department.TabIndex = 65
        '
        'propertyLocation
        '
        Me.propertyLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyLocation.Location = New System.Drawing.Point(244, 302)
        Me.propertyLocation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.propertyLocation.Name = "propertyLocation"
        Me.propertyLocation.Size = New System.Drawing.Size(239, 24)
        Me.propertyLocation.TabIndex = 64
        '
        'assignedEmployee
        '
        Me.assignedEmployee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedEmployee.AutoSize = True
        Me.assignedEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedEmployee.Location = New System.Drawing.Point(45, 106)
        Me.assignedEmployee.Name = "assignedEmployee"
        Me.assignedEmployee.Size = New System.Drawing.Size(77, 18)
        Me.assignedEmployee.TabIndex = 48
        Me.assignedEmployee.Text = "Total Cost"
        '
        'warrantyExpiration
        '
        Me.warrantyExpiration.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.warrantyExpiration.AutoSize = True
        Me.warrantyExpiration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.warrantyExpiration.Location = New System.Drawing.Point(34, 58)
        Me.warrantyExpiration.Name = "warrantyExpiration"
        Me.warrantyExpiration.Size = New System.Drawing.Size(123, 18)
        Me.warrantyExpiration.TabIndex = 47
        Me.warrantyExpiration.Text = "Acquisistion Cost"
        '
        'location
        '
        Me.location.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location.AutoSize = True
        Me.location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.Location = New System.Drawing.Point(45, 201)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(85, 18)
        Me.location.TabIndex = 50
        Me.location.Text = "Assigned to"
        '
        'remarks
        '
        Me.remarks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarks.AutoSize = True
        Me.remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarks.Location = New System.Drawing.Point(45, 256)
        Me.remarks.Name = "remarks"
        Me.remarks.Size = New System.Drawing.Size(85, 18)
        Me.remarks.TabIndex = 51
        Me.remarks.Text = "Department"
        '
        'acquisitionCost
        '
        Me.acquisitionCost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.acquisitionCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.acquisitionCost.Location = New System.Drawing.Point(244, 95)
        Me.acquisitionCost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.acquisitionCost.Name = "acquisitionCost"
        Me.acquisitionCost.Size = New System.Drawing.Size(239, 24)
        Me.acquisitionCost.TabIndex = 58
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.acquisitionDate)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.description)
        Me.Panel1.Controls.Add(Me.propertyNumber)
        Me.Panel1.Controls.Add(Me.category)
        Me.Panel1.Controls.Add(Me.supplierTxt)
        Me.Panel1.Controls.Add(Me.serialNumberTxt)
        Me.Panel1.Controls.Add(Me.itemName)
        Me.Panel1.Controls.Add(Me.cost)
        Me.Panel1.Controls.Add(Me.conditionStatus)
        Me.Panel1.Controls.Add(Me.supplier)
        Me.Panel1.Controls.Add(Me.serialNumber)
        Me.Panel1.Controls.Add(Me.property_Category)
        Me.Panel1.Controls.Add(Me.item_name)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 428)
        Me.Panel1.TabIndex = 64
        '
        'acquisitionDate
        '
        Me.acquisitionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.acquisitionDate.Location = New System.Drawing.Point(256, 350)
        Me.acquisitionDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.acquisitionDate.Name = "acquisitionDate"
        Me.acquisitionDate.Size = New System.Drawing.Size(255, 24)
        Me.acquisitionDate.TabIndex = 78
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(256, 350)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(255, 24)
        Me.DateTimePicker1.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 358)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 18)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Acquisition Date"
        '
        'description
        '
        Me.description.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(256, 151)
        Me.description.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(255, 24)
        Me.description.TabIndex = 72
        '
        'propertyNumber
        '
        Me.propertyNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.propertyNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyNumber.Location = New System.Drawing.Point(256, 256)
        Me.propertyNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.propertyNumber.Name = "propertyNumber"
        Me.propertyNumber.Size = New System.Drawing.Size(239, 24)
        Me.propertyNumber.TabIndex = 74
        '
        'category
        '
        Me.category.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.category.FormattingEnabled = True
        Me.category.Items.AddRange(New Object() {"Electronics", "Computer", "Furnitures"})
        Me.category.Location = New System.Drawing.Point(256, 98)
        Me.category.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.category.Name = "category"
        Me.category.Size = New System.Drawing.Size(255, 26)
        Me.category.TabIndex = 71
        '
        'supplierTxt
        '
        Me.supplierTxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.supplierTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierTxt.Location = New System.Drawing.Point(254, 201)
        Me.supplierTxt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.supplierTxt.Name = "supplierTxt"
        Me.supplierTxt.Size = New System.Drawing.Size(255, 24)
        Me.supplierTxt.TabIndex = 67
        '
        'serialNumberTxt
        '
        Me.serialNumberTxt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.serialNumberTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumberTxt.Location = New System.Drawing.Point(254, 308)
        Me.serialNumberTxt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.serialNumberTxt.Name = "serialNumberTxt"
        Me.serialNumberTxt.Size = New System.Drawing.Size(255, 24)
        Me.serialNumberTxt.TabIndex = 66
        '
        'itemName
        '
        Me.itemName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.itemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.itemName.Location = New System.Drawing.Point(256, 44)
        Me.itemName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.itemName.Name = "itemName"
        Me.itemName.Size = New System.Drawing.Size(255, 24)
        Me.itemName.TabIndex = 64
        '
        'cost
        '
        Me.cost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cost.AutoSize = True
        Me.cost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cost.Location = New System.Drawing.Point(43, 308)
        Me.cost.Name = "cost"
        Me.cost.Size = New System.Drawing.Size(102, 18)
        Me.cost.TabIndex = 63
        Me.cost.Text = "Serial Number"
        '
        'conditionStatus
        '
        Me.conditionStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditionStatus.AutoSize = True
        Me.conditionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionStatus.Location = New System.Drawing.Point(43, 256)
        Me.conditionStatus.Name = "conditionStatus"
        Me.conditionStatus.Size = New System.Drawing.Size(121, 18)
        Me.conditionStatus.TabIndex = 62
        Me.conditionStatus.Text = "Property Number"
        '
        'supplier
        '
        Me.supplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplier.AutoSize = True
        Me.supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplier.Location = New System.Drawing.Point(43, 201)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(61, 18)
        Me.supplier.TabIndex = 61
        Me.supplier.Text = "Supplier"
        '
        'serialNumber
        '
        Me.serialNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialNumber.AutoSize = True
        Me.serialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumber.Location = New System.Drawing.Point(43, 151)
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Size = New System.Drawing.Size(83, 18)
        Me.serialNumber.TabIndex = 60
        Me.serialNumber.Text = "Description"
        '
        'property_Category
        '
        Me.property_Category.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.property_Category.AutoSize = True
        Me.property_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.property_Category.Location = New System.Drawing.Point(43, 98)
        Me.property_Category.Name = "property_Category"
        Me.property_Category.Size = New System.Drawing.Size(68, 18)
        Me.property_Category.TabIndex = 59
        Me.property_Category.Text = "Category"
        '
        'item_name
        '
        Me.item_name.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.item_name.AutoSize = True
        Me.item_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.item_name.Location = New System.Drawing.Point(43, 47)
        Me.item_name.Name = "item_name"
        Me.item_name.Size = New System.Drawing.Size(80, 18)
        Me.item_name.TabIndex = 58
        Me.item_name.Text = "Item Name"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(39, 112)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1264, 71)
        Me.RoundedPanel1.TabIndex = 43
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
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(32, 58)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(379, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 42
        Me.admin_label_DepartmentManagement.Text = "Property Register Form"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1004, 703)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 155
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
        Me.btnSave.Location = New System.Drawing.Point(1157, 703)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 154
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AddProperty"
        Me.Size = New System.Drawing.Size(1351, 802)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents assignedEmployee As System.Windows.Forms.Label
    Friend WithEvents warrantyExpiration As System.Windows.Forms.Label
    Friend WithEvents location As System.Windows.Forms.Label
    Friend WithEvents remarks As System.Windows.Forms.Label
    Friend WithEvents acquisitionCost As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents no_of_employees_numeric As System.Windows.Forms.NumericUpDown
    Friend WithEvents supplierTxt As System.Windows.Forms.TextBox
    Friend WithEvents serialNumberTxt As System.Windows.Forms.TextBox
    Friend WithEvents itemName As System.Windows.Forms.TextBox
    Friend WithEvents cost As System.Windows.Forms.Label
    Friend WithEvents conditionStatus As System.Windows.Forms.Label
    Friend WithEvents supplier As System.Windows.Forms.Label
    Friend WithEvents serialNumber As System.Windows.Forms.Label
    Friend WithEvents property_Category As System.Windows.Forms.Label
    Friend WithEvents item_name As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents propertyLocation As System.Windows.Forms.TextBox
    Friend WithEvents department As System.Windows.Forms.ComboBox
    Friend WithEvents warrantyExpirationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents assignedTo As System.Windows.Forms.TextBox
    Friend WithEvents category As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents propertyNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents description As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents condition As System.Windows.Forms.ComboBox
    Friend WithEvents acquisitionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents warranty As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.ComboBox
End Class
