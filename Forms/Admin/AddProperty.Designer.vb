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
        Me.assignedEmployee = New System.Windows.Forms.Label()
        Me.date_purchased = New System.Windows.Forms.Label()
        Me.warrantyExpiration = New System.Windows.Forms.Label()
        Me.assignedDepartment = New System.Windows.Forms.Label()
        Me.location = New System.Windows.Forms.Label()
        Me.remarks = New System.Windows.Forms.Label()
        Me.remarks_txt = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.no_of_employees_numeric = New System.Windows.Forms.NumericUpDown()
        Me.supplierTxt = New System.Windows.Forms.TextBox()
        Me.serialNumberTxt = New System.Windows.Forms.TextBox()
        Me.propertyNameTxt = New System.Windows.Forms.TextBox()
        Me.cost = New System.Windows.Forms.Label()
        Me.conditionStatus = New System.Windows.Forms.Label()
        Me.supplier = New System.Windows.Forms.Label()
        Me.serialNumber = New System.Windows.Forms.Label()
        Me.property_Category = New System.Windows.Forms.Label()
        Me.property_name = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.propertyLocation = New System.Windows.Forms.TextBox()
        Me.assignedDeparmentCmbo = New System.Windows.Forms.ComboBox()
        Me.assignedEmployeeTxt = New System.Windows.Forms.TextBox()
        Me.warrantyExpirationDate = New System.Windows.Forms.DateTimePicker()
        Me.datePurchasedDate = New System.Windows.Forms.DateTimePicker()
        Me.conditionStatusCmbo = New System.Windows.Forms.ComboBox()
        Me.categoryCmbo = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RoundedPanel2.Location = New System.Drawing.Point(42, 211)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1264, 425)
        Me.RoundedPanel2.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.datePurchasedDate)
        Me.Panel2.Controls.Add(Me.warrantyExpirationDate)
        Me.Panel2.Controls.Add(Me.assignedEmployeeTxt)
        Me.Panel2.Controls.Add(Me.assignedDeparmentCmbo)
        Me.Panel2.Controls.Add(Me.propertyLocation)
        Me.Panel2.Controls.Add(Me.assignedEmployee)
        Me.Panel2.Controls.Add(Me.date_purchased)
        Me.Panel2.Controls.Add(Me.warrantyExpiration)
        Me.Panel2.Controls.Add(Me.assignedDepartment)
        Me.Panel2.Controls.Add(Me.location)
        Me.Panel2.Controls.Add(Me.remarks)
        Me.Panel2.Controls.Add(Me.remarks_txt)
        Me.Panel2.Location = New System.Drawing.Point(655, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(537, 382)
        Me.Panel2.TabIndex = 65
        '
        'assignedEmployee
        '
        Me.assignedEmployee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedEmployee.AutoSize = True
        Me.assignedEmployee.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedEmployee.Location = New System.Drawing.Point(44, 151)
        Me.assignedEmployee.Name = "assignedEmployee"
        Me.assignedEmployee.Size = New System.Drawing.Size(158, 26)
        Me.assignedEmployee.TabIndex = 48
        Me.assignedEmployee.Text = "Assigned Employee"
        '
        'date_purchased
        '
        Me.date_purchased.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.date_purchased.AutoSize = True
        Me.date_purchased.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_purchased.Location = New System.Drawing.Point(44, 47)
        Me.date_purchased.Name = "date_purchased"
        Me.date_purchased.Size = New System.Drawing.Size(132, 26)
        Me.date_purchased.TabIndex = 46
        Me.date_purchased.Text = "Date Purchased"
        '
        'warrantyExpiration
        '
        Me.warrantyExpiration.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.warrantyExpiration.AutoSize = True
        Me.warrantyExpiration.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.warrantyExpiration.Location = New System.Drawing.Point(44, 98)
        Me.warrantyExpiration.Name = "warrantyExpiration"
        Me.warrantyExpiration.Size = New System.Drawing.Size(160, 26)
        Me.warrantyExpiration.TabIndex = 47
        Me.warrantyExpiration.Text = "Warranty Expiration"
        '
        'assignedDepartment
        '
        Me.assignedDepartment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedDepartment.AutoSize = True
        Me.assignedDepartment.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedDepartment.Location = New System.Drawing.Point(44, 204)
        Me.assignedDepartment.Name = "assignedDepartment"
        Me.assignedDepartment.Size = New System.Drawing.Size(175, 26)
        Me.assignedDepartment.TabIndex = 49
        Me.assignedDepartment.Text = "Assigned Department"
        '
        'location
        '
        Me.location.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location.AutoSize = True
        Me.location.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.Location = New System.Drawing.Point(44, 256)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(76, 26)
        Me.location.TabIndex = 50
        Me.location.Text = "Location"
        '
        'remarks
        '
        Me.remarks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarks.AutoSize = True
        Me.remarks.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarks.Location = New System.Drawing.Point(44, 313)
        Me.remarks.Name = "remarks"
        Me.remarks.Size = New System.Drawing.Size(77, 26)
        Me.remarks.TabIndex = 51
        Me.remarks.Text = "Remarks"
        '
        'remarks_txt
        '
        Me.remarks_txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarks_txt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarks_txt.Location = New System.Drawing.Point(242, 308)
        Me.remarks_txt.Name = "remarks_txt"
        Me.remarks_txt.Size = New System.Drawing.Size(238, 30)
        Me.remarks_txt.TabIndex = 58
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.categoryCmbo)
        Me.Panel1.Controls.Add(Me.conditionStatusCmbo)
        Me.Panel1.Controls.Add(Me.no_of_employees_numeric)
        Me.Panel1.Controls.Add(Me.supplierTxt)
        Me.Panel1.Controls.Add(Me.serialNumberTxt)
        Me.Panel1.Controls.Add(Me.propertyNameTxt)
        Me.Panel1.Controls.Add(Me.cost)
        Me.Panel1.Controls.Add(Me.conditionStatus)
        Me.Panel1.Controls.Add(Me.supplier)
        Me.Panel1.Controls.Add(Me.serialNumber)
        Me.Panel1.Controls.Add(Me.property_Category)
        Me.Panel1.Controls.Add(Me.property_name)
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
        'supplierTxt
        '
        Me.supplierTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplierTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierTxt.Location = New System.Drawing.Point(256, 198)
        Me.supplierTxt.Name = "supplierTxt"
        Me.supplierTxt.Size = New System.Drawing.Size(254, 30)
        Me.supplierTxt.TabIndex = 67
        '
        'serialNumberTxt
        '
        Me.serialNumberTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialNumberTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumberTxt.Location = New System.Drawing.Point(256, 147)
        Me.serialNumberTxt.Name = "serialNumberTxt"
        Me.serialNumberTxt.Size = New System.Drawing.Size(254, 30)
        Me.serialNumberTxt.TabIndex = 66
        '
        'propertyNameTxt
        '
        Me.propertyNameTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyNameTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyNameTxt.Location = New System.Drawing.Point(256, 44)
        Me.propertyNameTxt.Name = "propertyNameTxt"
        Me.propertyNameTxt.Size = New System.Drawing.Size(254, 30)
        Me.propertyNameTxt.TabIndex = 64
        '
        'cost
        '
        Me.cost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cost.AutoSize = True
        Me.cost.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cost.Location = New System.Drawing.Point(42, 313)
        Me.cost.Name = "cost"
        Me.cost.Size = New System.Drawing.Size(47, 26)
        Me.cost.TabIndex = 63
        Me.cost.Text = "Cost"
        '
        'conditionStatus
        '
        Me.conditionStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditionStatus.AutoSize = True
        Me.conditionStatus.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionStatus.Location = New System.Drawing.Point(42, 256)
        Me.conditionStatus.Name = "conditionStatus"
        Me.conditionStatus.Size = New System.Drawing.Size(138, 26)
        Me.conditionStatus.TabIndex = 62
        Me.conditionStatus.Text = "Condition Status"
        '
        'supplier
        '
        Me.supplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplier.AutoSize = True
        Me.supplier.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplier.Location = New System.Drawing.Point(42, 201)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(74, 26)
        Me.supplier.TabIndex = 61
        Me.supplier.Text = "Supplier"
        '
        'serialNumber
        '
        Me.serialNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialNumber.AutoSize = True
        Me.serialNumber.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumber.Location = New System.Drawing.Point(42, 151)
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Size = New System.Drawing.Size(119, 26)
        Me.serialNumber.TabIndex = 60
        Me.serialNumber.Text = "Serial Number"
        '
        'property_Category
        '
        Me.property_Category.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.property_Category.AutoSize = True
        Me.property_Category.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.property_Category.Location = New System.Drawing.Point(42, 98)
        Me.property_Category.Name = "property_Category"
        Me.property_Category.Size = New System.Drawing.Size(82, 26)
        Me.property_Category.TabIndex = 59
        Me.property_Category.Text = "Category"
        '
        'property_name
        '
        Me.property_name.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.property_name.AutoSize = True
        Me.property_name.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.property_name.Location = New System.Drawing.Point(42, 47)
        Me.property_name.Name = "property_name"
        Me.property_name.Size = New System.Drawing.Size(124, 26)
        Me.property_name.TabIndex = 58
        Me.property_name.Text = "Property Name"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(42, 119)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1264, 72)
        Me.RoundedPanel1.TabIndex = 43
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
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(32, 58)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(251, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 42
        Me.admin_label_DepartmentManagement.Text = "Add Property"
        '
        'propertyLocation
        '
        Me.propertyLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyLocation.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyLocation.Location = New System.Drawing.Point(242, 252)
        Me.propertyLocation.Name = "propertyLocation"
        Me.propertyLocation.Size = New System.Drawing.Size(238, 30)
        Me.propertyLocation.TabIndex = 64
        '
        'assignedDeparmentCmbo
        '
        Me.assignedDeparmentCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedDeparmentCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedDeparmentCmbo.FormattingEnabled = True
        Me.assignedDeparmentCmbo.Location = New System.Drawing.Point(242, 201)
        Me.assignedDeparmentCmbo.Name = "assignedDeparmentCmbo"
        Me.assignedDeparmentCmbo.Size = New System.Drawing.Size(238, 34)
        Me.assignedDeparmentCmbo.TabIndex = 65
        '
        'assignedEmployeeTxt
        '
        Me.assignedEmployeeTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedEmployeeTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedEmployeeTxt.Location = New System.Drawing.Point(242, 147)
        Me.assignedEmployeeTxt.Name = "assignedEmployeeTxt"
        Me.assignedEmployeeTxt.Size = New System.Drawing.Size(238, 30)
        Me.assignedEmployeeTxt.TabIndex = 66
        '
        'warrantyExpirationDate
        '
        Me.warrantyExpirationDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.warrantyExpirationDate.Location = New System.Drawing.Point(242, 102)
        Me.warrantyExpirationDate.Name = "warrantyExpirationDate"
        Me.warrantyExpirationDate.Size = New System.Drawing.Size(238, 30)
        Me.warrantyExpirationDate.TabIndex = 67
        '
        'datePurchasedDate
        '
        Me.datePurchasedDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.datePurchasedDate.Location = New System.Drawing.Point(242, 44)
        Me.datePurchasedDate.Name = "datePurchasedDate"
        Me.datePurchasedDate.Size = New System.Drawing.Size(238, 30)
        Me.datePurchasedDate.TabIndex = 68
        '
        'conditionStatusCmbo
        '
        Me.conditionStatusCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditionStatusCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionStatusCmbo.FormattingEnabled = True
        Me.conditionStatusCmbo.Location = New System.Drawing.Point(256, 248)
        Me.conditionStatusCmbo.Name = "conditionStatusCmbo"
        Me.conditionStatusCmbo.Size = New System.Drawing.Size(254, 34)
        Me.conditionStatusCmbo.TabIndex = 70
        '
        'categoryCmbo
        '
        Me.categoryCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.categoryCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryCmbo.FormattingEnabled = True
        Me.categoryCmbo.Location = New System.Drawing.Point(256, 95)
        Me.categoryCmbo.Name = "categoryCmbo"
        Me.categoryCmbo.Size = New System.Drawing.Size(254, 34)
        Me.categoryCmbo.TabIndex = 71
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1008, 688)
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
        Me.btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1161, 688)
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
        Me.Name = "AddProperty"
        Me.Size = New System.Drawing.Size(1351, 802)
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

    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents assignedEmployee As System.Windows.Forms.Label
    Friend WithEvents date_purchased As System.Windows.Forms.Label
    Friend WithEvents warrantyExpiration As System.Windows.Forms.Label
    Friend WithEvents assignedDepartment As System.Windows.Forms.Label
    Friend WithEvents location As System.Windows.Forms.Label
    Friend WithEvents remarks As System.Windows.Forms.Label
    Friend WithEvents remarks_txt As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents no_of_employees_numeric As System.Windows.Forms.NumericUpDown
    Friend WithEvents supplierTxt As System.Windows.Forms.TextBox
    Friend WithEvents serialNumberTxt As System.Windows.Forms.TextBox
    Friend WithEvents propertyNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents cost As System.Windows.Forms.Label
    Friend WithEvents conditionStatus As System.Windows.Forms.Label
    Friend WithEvents supplier As System.Windows.Forms.Label
    Friend WithEvents serialNumber As System.Windows.Forms.Label
    Friend WithEvents property_Category As System.Windows.Forms.Label
    Friend WithEvents property_name As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents propertyLocation As System.Windows.Forms.TextBox
    Friend WithEvents assignedDeparmentCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents datePurchasedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents warrantyExpirationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents assignedEmployeeTxt As System.Windows.Forms.TextBox
    Friend WithEvents conditionStatusCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents categoryCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
End Class
