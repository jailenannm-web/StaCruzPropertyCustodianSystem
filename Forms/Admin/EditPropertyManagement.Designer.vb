<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditPropertyManagement
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
        Me.btnBack = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtRemarks = New System.Windows.Forms.ComboBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtAssignedDepartment = New System.Windows.Forms.ComboBox()
        Me.txtAssignedEmployee = New System.Windows.Forms.ComboBox()
        Me.dtpWarrantyExpiration = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateUpdated = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDateCreated = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateCreatedProperty = New System.Windows.Forms.DateTimePicker()
        Me.supplier = New System.Windows.Forms.Label()
        Me.receivedBy = New System.Windows.Forms.Label()
        Me.date_received = New System.Windows.Forms.Label()
        Me.expirationDate = New System.Windows.Forms.Label()
        Me.remarksSupply = New System.Windows.Forms.Label()
        Me.createdAt = New System.Windows.Forms.Label()
        Me.updatedAt = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpDatePurchased = New System.Windows.Forms.DateTimePicker()
        Me.txtCost = New System.Windows.Forms.NumericUpDown()
        Me.conditionStatusCmbo = New System.Windows.Forms.ComboBox()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.txtSupplier = New System.Windows.Forms.ComboBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.txtPropertyName = New System.Windows.Forms.TextBox()
        Me.location_supply = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpropertyID = New System.Windows.Forms.TextBox()
        Me.status = New System.Windows.Forms.Label()
        Me.totalValue = New System.Windows.Forms.Label()
        Me.stock = New System.Windows.Forms.Label()
        Me.category = New System.Windows.Forms.Label()
        Me.nameSupply = New System.Windows.Forms.Label()
        Me.supply_id = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnBack.CornerRadius = 15
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(1018, 737)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(145, 34)
        Me.btnBack.TabIndex = 162
        Me.btnBack.Text = "Cancel"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1171, 737)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 161
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
        Me.RoundedPanel2.Location = New System.Drawing.Point(146, 180)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1207, 525)
        Me.RoundedPanel2.TabIndex = 160
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtRemarks)
        Me.Panel2.Controls.Add(Me.txtLocation)
        Me.Panel2.Controls.Add(Me.txtAssignedDepartment)
        Me.Panel2.Controls.Add(Me.txtAssignedEmployee)
        Me.Panel2.Controls.Add(Me.dtpWarrantyExpiration)
        Me.Panel2.Controls.Add(Me.dtpDateUpdated)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.dtpDateCreated)
        Me.Panel2.Controls.Add(Me.dtpDateCreatedProperty)
        Me.Panel2.Controls.Add(Me.supplier)
        Me.Panel2.Controls.Add(Me.receivedBy)
        Me.Panel2.Controls.Add(Me.date_received)
        Me.Panel2.Controls.Add(Me.expirationDate)
        Me.Panel2.Controls.Add(Me.remarksSupply)
        Me.Panel2.Controls.Add(Me.createdAt)
        Me.Panel2.Controls.Add(Me.updatedAt)
        Me.Panel2.Location = New System.Drawing.Point(654, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(516, 482)
        Me.Panel2.TabIndex = 65
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.FormattingEnabled = True
        Me.txtRemarks.Location = New System.Drawing.Point(239, 254)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(238, 34)
        Me.txtRemarks.TabIndex = 83
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(239, 204)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(238, 30)
        Me.txtLocation.TabIndex = 82
        '
        'txtAssignedDepartment
        '
        Me.txtAssignedDepartment.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtAssignedDepartment.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssignedDepartment.FormattingEnabled = True
        Me.txtAssignedDepartment.Location = New System.Drawing.Point(239, 148)
        Me.txtAssignedDepartment.Name = "txtAssignedDepartment"
        Me.txtAssignedDepartment.Size = New System.Drawing.Size(238, 34)
        Me.txtAssignedDepartment.TabIndex = 81
        '
        'txtAssignedEmployee
        '
        Me.txtAssignedEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtAssignedEmployee.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssignedEmployee.FormattingEnabled = True
        Me.txtAssignedEmployee.Location = New System.Drawing.Point(239, 94)
        Me.txtAssignedEmployee.Name = "txtAssignedEmployee"
        Me.txtAssignedEmployee.Size = New System.Drawing.Size(238, 34)
        Me.txtAssignedEmployee.TabIndex = 80
        '
        'dtpWarrantyExpiration
        '
        Me.dtpWarrantyExpiration.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpWarrantyExpiration.Location = New System.Drawing.Point(239, 43)
        Me.dtpWarrantyExpiration.Name = "dtpWarrantyExpiration"
        Me.dtpWarrantyExpiration.Size = New System.Drawing.Size(238, 30)
        Me.dtpWarrantyExpiration.TabIndex = 77
        '
        'dtpDateUpdated
        '
        Me.dtpDateUpdated.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpDateUpdated.Location = New System.Drawing.Point(239, 414)
        Me.dtpDateUpdated.Name = "dtpDateUpdated"
        Me.dtpDateUpdated.Size = New System.Drawing.Size(238, 30)
        Me.dtpDateUpdated.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 417)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 26)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Updated By"
        '
        'dtpDateCreated
        '
        Me.dtpDateCreated.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpDateCreated.Location = New System.Drawing.Point(239, 363)
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.Size = New System.Drawing.Size(238, 30)
        Me.dtpDateCreated.TabIndex = 74
        '
        'dtpDateCreatedProperty
        '
        Me.dtpDateCreatedProperty.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpDateCreatedProperty.Location = New System.Drawing.Point(239, 309)
        Me.dtpDateCreatedProperty.Name = "dtpDateCreatedProperty"
        Me.dtpDateCreatedProperty.Size = New System.Drawing.Size(238, 30)
        Me.dtpDateCreatedProperty.TabIndex = 73
        '
        'supplier
        '
        Me.supplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplier.AutoSize = True
        Me.supplier.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplier.Location = New System.Drawing.Point(41, 47)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(160, 26)
        Me.supplier.TabIndex = 69
        Me.supplier.Text = "Warranty Expiration"
        '
        'receivedBy
        '
        Me.receivedBy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.receivedBy.AutoSize = True
        Me.receivedBy.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.receivedBy.Location = New System.Drawing.Point(41, 204)
        Me.receivedBy.Name = "receivedBy"
        Me.receivedBy.Size = New System.Drawing.Size(76, 26)
        Me.receivedBy.TabIndex = 48
        Me.receivedBy.Text = "Location"
        '
        'date_received
        '
        Me.date_received.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.date_received.AutoSize = True
        Me.date_received.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_received.Location = New System.Drawing.Point(41, 98)
        Me.date_received.Name = "date_received"
        Me.date_received.Size = New System.Drawing.Size(158, 26)
        Me.date_received.TabIndex = 46
        Me.date_received.Text = "Assigned Employee"
        '
        'expirationDate
        '
        Me.expirationDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.expirationDate.AutoSize = True
        Me.expirationDate.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expirationDate.Location = New System.Drawing.Point(41, 151)
        Me.expirationDate.Name = "expirationDate"
        Me.expirationDate.Size = New System.Drawing.Size(175, 26)
        Me.expirationDate.TabIndex = 47
        Me.expirationDate.Text = "Assigned Department"
        '
        'remarksSupply
        '
        Me.remarksSupply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarksSupply.AutoSize = True
        Me.remarksSupply.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarksSupply.Location = New System.Drawing.Point(41, 257)
        Me.remarksSupply.Name = "remarksSupply"
        Me.remarksSupply.Size = New System.Drawing.Size(77, 26)
        Me.remarksSupply.TabIndex = 49
        Me.remarksSupply.Text = "Remarks"
        '
        'createdAt
        '
        Me.createdAt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createdAt.AutoSize = True
        Me.createdAt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createdAt.Location = New System.Drawing.Point(41, 309)
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Size = New System.Drawing.Size(112, 26)
        Me.createdAt.TabIndex = 50
        Me.createdAt.Text = "Date Created"
        '
        'updatedAt
        '
        Me.updatedAt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.updatedAt.AutoSize = True
        Me.updatedAt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updatedAt.Location = New System.Drawing.Point(41, 366)
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Size = New System.Drawing.Size(115, 26)
        Me.updatedAt.TabIndex = 51
        Me.updatedAt.Text = "Date Updated"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dtpDatePurchased)
        Me.Panel1.Controls.Add(Me.txtCost)
        Me.Panel1.Controls.Add(Me.conditionStatusCmbo)
        Me.Panel1.Controls.Add(Me.txtSerialNumber)
        Me.Panel1.Controls.Add(Me.txtSupplier)
        Me.Panel1.Controls.Add(Me.cboCategory)
        Me.Panel1.Controls.Add(Me.txtPropertyName)
        Me.Panel1.Controls.Add(Me.location_supply)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtpropertyID)
        Me.Panel1.Controls.Add(Me.status)
        Me.Panel1.Controls.Add(Me.totalValue)
        Me.Panel1.Controls.Add(Me.stock)
        Me.Panel1.Controls.Add(Me.category)
        Me.Panel1.Controls.Add(Me.nameSupply)
        Me.Panel1.Controls.Add(Me.supply_id)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 482)
        Me.Panel1.TabIndex = 64
        '
        'dtpDatePurchased
        '
        Me.dtpDatePurchased.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpDatePurchased.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpDatePurchased.Location = New System.Drawing.Point(255, 429)
        Me.dtpDatePurchased.Name = "dtpDatePurchased"
        Me.dtpDatePurchased.Size = New System.Drawing.Size(198, 30)
        Me.dtpDatePurchased.TabIndex = 77
        '
        'txtCost
        '
        Me.txtCost.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCost.Location = New System.Drawing.Point(256, 378)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(197, 22)
        Me.txtCost.TabIndex = 84
        '
        'conditionStatusCmbo
        '
        Me.conditionStatusCmbo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.conditionStatusCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionStatusCmbo.FormattingEnabled = True
        Me.conditionStatusCmbo.Location = New System.Drawing.Point(256, 313)
        Me.conditionStatusCmbo.Name = "conditionStatusCmbo"
        Me.conditionStatusCmbo.Size = New System.Drawing.Size(197, 34)
        Me.conditionStatusCmbo.TabIndex = 83
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSerialNumber.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(256, 202)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(197, 30)
        Me.txtSerialNumber.TabIndex = 82
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSupplier.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.FormattingEnabled = True
        Me.txtSupplier.Location = New System.Drawing.Point(256, 254)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(197, 34)
        Me.txtSupplier.TabIndex = 80
        '
        'cboCategory
        '
        Me.cboCategory.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCategory.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(256, 148)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(197, 34)
        Me.cboCategory.TabIndex = 79
        '
        'txtPropertyName
        '
        Me.txtPropertyName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPropertyName.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropertyName.Location = New System.Drawing.Point(256, 94)
        Me.txtPropertyName.Name = "txtPropertyName"
        Me.txtPropertyName.Size = New System.Drawing.Size(197, 30)
        Me.txtPropertyName.TabIndex = 78
        '
        'location_supply
        '
        Me.location_supply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location_supply.AutoSize = True
        Me.location_supply.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location_supply.Location = New System.Drawing.Point(42, 433)
        Me.location_supply.Name = "location_supply"
        Me.location_supply.Size = New System.Drawing.Size(132, 26)
        Me.location_supply.TabIndex = 76
        Me.location_supply.Text = "Date Purchased"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 26)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Supplier"
        '
        'txtpropertyID
        '
        Me.txtpropertyID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtpropertyID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpropertyID.Location = New System.Drawing.Point(256, 43)
        Me.txtpropertyID.Name = "txtpropertyID"
        Me.txtpropertyID.Size = New System.Drawing.Size(197, 30)
        Me.txtpropertyID.TabIndex = 64
        '
        'status
        '
        Me.status.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status.AutoSize = True
        Me.status.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.Location = New System.Drawing.Point(42, 378)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(47, 26)
        Me.status.TabIndex = 63
        Me.status.Text = "Cost"
        '
        'totalValue
        '
        Me.totalValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalValue.AutoSize = True
        Me.totalValue.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalValue.Location = New System.Drawing.Point(42, 321)
        Me.totalValue.Name = "totalValue"
        Me.totalValue.Size = New System.Drawing.Size(138, 26)
        Me.totalValue.TabIndex = 62
        Me.totalValue.Text = "Condition Status"
        '
        'stock
        '
        Me.stock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stock.AutoSize = True
        Me.stock.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stock.Location = New System.Drawing.Point(42, 204)
        Me.stock.Name = "stock"
        Me.stock.Size = New System.Drawing.Size(119, 26)
        Me.stock.TabIndex = 61
        Me.stock.Text = "Serial Number"
        '
        'category
        '
        Me.category.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.category.AutoSize = True
        Me.category.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.category.Location = New System.Drawing.Point(42, 151)
        Me.category.Name = "category"
        Me.category.Size = New System.Drawing.Size(82, 26)
        Me.category.TabIndex = 60
        Me.category.Text = "Category"
        '
        'nameSupply
        '
        Me.nameSupply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nameSupply.AutoSize = True
        Me.nameSupply.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameSupply.Location = New System.Drawing.Point(42, 98)
        Me.nameSupply.Name = "nameSupply"
        Me.nameSupply.Size = New System.Drawing.Size(124, 26)
        Me.nameSupply.TabIndex = 59
        Me.nameSupply.Text = "Property Name"
        '
        'supply_id
        '
        Me.supply_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supply_id.AutoSize = True
        Me.supply_id.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supply_id.Location = New System.Drawing.Point(42, 47)
        Me.supply_id.Name = "supply_id"
        Me.supply_id.Size = New System.Drawing.Size(94, 26)
        Me.supply_id.TabIndex = 58
        Me.supply_id.Text = "Property ID"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(146, 88)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1207, 72)
        Me.RoundedPanel1.TabIndex = 159
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(18, 24)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(402, 26)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required proepety management information."
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(136, 27)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(485, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 158
        Me.admin_label_DepartmentManagement.Text = "Edit Property Management"
        '
        'EditPropertyManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "EditPropertyManagement"
        Me.Size = New System.Drawing.Size(1489, 799)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBack As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpDateCreated As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateCreatedProperty As System.Windows.Forms.DateTimePicker
    Friend WithEvents supplier As System.Windows.Forms.Label
    Friend WithEvents receivedBy As System.Windows.Forms.Label
    Friend WithEvents date_received As System.Windows.Forms.Label
    Friend WithEvents expirationDate As System.Windows.Forms.Label
    Friend WithEvents remarksSupply As System.Windows.Forms.Label
    Friend WithEvents createdAt As System.Windows.Forms.Label
    Friend WithEvents updatedAt As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtPropertyName As System.Windows.Forms.TextBox
    Friend WithEvents location_supply As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpropertyID As System.Windows.Forms.TextBox
    Friend WithEvents status As System.Windows.Forms.Label
    Friend WithEvents totalValue As System.Windows.Forms.Label
    Friend WithEvents stock As System.Windows.Forms.Label
    Friend WithEvents category As System.Windows.Forms.Label
    Friend WithEvents nameSupply As System.Windows.Forms.Label
    Friend WithEvents supply_id As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents dtpDateUpdated As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDatePurchased As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCost As System.Windows.Forms.NumericUpDown
    Friend WithEvents conditionStatusCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.ComboBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtAssignedDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents txtAssignedEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents dtpWarrantyExpiration As System.Windows.Forms.DateTimePicker
End Class
