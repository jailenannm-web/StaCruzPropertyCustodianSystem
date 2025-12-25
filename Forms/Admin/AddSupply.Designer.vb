<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSupply
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
        Me.sourceOfFunds = New System.Windows.Forms.TextBox()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.receivedBy = New System.Windows.Forms.Label()
        Me.date_received = New System.Windows.Forms.Label()
        Me.expirationDate = New System.Windows.Forms.Label()
        Me.remarksSupply = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dateReceived = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.unitOfMeasur = New System.Windows.Forms.ComboBox()
        Me.category = New System.Windows.Forms.ComboBox()
        Me.itemName = New System.Windows.Forms.TextBox()
        Me.quantity = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stock = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.nameSupply = New System.Windows.Forms.Label()
        Me.supply_id = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.unitCost = New System.Windows.Forms.NumericUpDown()
        Me.totalCost = New System.Windows.Forms.NumericUpDown()
        Me.supplier = New System.Windows.Forms.ComboBox()
        Me.location = New System.Windows.Forms.ComboBox()
        Me.description = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.quantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.unitCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.totalCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(56, 203)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1207, 410)
        Me.RoundedPanel2.TabIndex = 47
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.location)
        Me.Panel2.Controls.Add(Me.supplier)
        Me.Panel2.Controls.Add(Me.totalCost)
        Me.Panel2.Controls.Add(Me.unitCost)
        Me.Panel2.Controls.Add(Me.sourceOfFunds)
        Me.Panel2.Controls.Add(Me.lblUnitCost)
        Me.Panel2.Controls.Add(Me.receivedBy)
        Me.Panel2.Controls.Add(Me.date_received)
        Me.Panel2.Controls.Add(Me.expirationDate)
        Me.Panel2.Controls.Add(Me.remarksSupply)
        Me.Panel2.Location = New System.Drawing.Point(653, 18)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(516, 367)
        Me.Panel2.TabIndex = 65
        '
        'sourceOfFunds
        '
        Me.sourceOfFunds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sourceOfFunds.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sourceOfFunds.Location = New System.Drawing.Point(239, 202)
        Me.sourceOfFunds.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sourceOfFunds.Name = "sourceOfFunds"
        Me.sourceOfFunds.Size = New System.Drawing.Size(239, 24)
        Me.sourceOfFunds.TabIndex = 75
        '
        'lblUnitCost
        '
        Me.lblUnitCost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnitCost.AutoSize = True
        Me.lblUnitCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitCost.Location = New System.Drawing.Point(41, 47)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(70, 18)
        Me.lblUnitCost.TabIndex = 69
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'receivedBy
        '
        Me.receivedBy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.receivedBy.AutoSize = True
        Me.receivedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.receivedBy.Location = New System.Drawing.Point(41, 204)
        Me.receivedBy.Name = "receivedBy"
        Me.receivedBy.Size = New System.Drawing.Size(118, 18)
        Me.receivedBy.TabIndex = 48
        Me.receivedBy.Text = "Source of Funds"
        '
        'date_received
        '
        Me.date_received.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.date_received.AutoSize = True
        Me.date_received.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_received.Location = New System.Drawing.Point(41, 98)
        Me.date_received.Name = "date_received"
        Me.date_received.Size = New System.Drawing.Size(77, 18)
        Me.date_received.TabIndex = 46
        Me.date_received.Text = "Total Cost"
        '
        'expirationDate
        '
        Me.expirationDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.expirationDate.AutoSize = True
        Me.expirationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expirationDate.Location = New System.Drawing.Point(41, 151)
        Me.expirationDate.Name = "expirationDate"
        Me.expirationDate.Size = New System.Drawing.Size(61, 18)
        Me.expirationDate.TabIndex = 47
        Me.expirationDate.Text = "Supplier"
        '
        'remarksSupply
        '
        Me.remarksSupply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarksSupply.AutoSize = True
        Me.remarksSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarksSupply.Location = New System.Drawing.Point(41, 257)
        Me.remarksSupply.Name = "remarksSupply"
        Me.remarksSupply.Size = New System.Drawing.Size(65, 18)
        Me.remarksSupply.TabIndex = 49
        Me.remarksSupply.Text = "Location"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.description)
        Me.Panel1.Controls.Add(Me.dateReceived)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.unitOfMeasur)
        Me.Panel1.Controls.Add(Me.category)
        Me.Panel1.Controls.Add(Me.itemName)
        Me.Panel1.Controls.Add(Me.quantity)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.stock)
        Me.Panel1.Controls.Add(Me.lblDescription)
        Me.Panel1.Controls.Add(Me.nameSupply)
        Me.Panel1.Controls.Add(Me.supply_id)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 367)
        Me.Panel1.TabIndex = 64
        '
        'dateReceived
        '
        Me.dateReceived.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dateReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dateReceived.Location = New System.Drawing.Point(212, 302)
        Me.dateReceived.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dateReceived.Name = "dateReceived"
        Me.dateReceived.Size = New System.Drawing.Size(239, 24)
        Me.dateReceived.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 304)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 18)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Date Received"
        '
        'unitOfMeasur
        '
        Me.unitOfMeasur.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.unitOfMeasur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitOfMeasur.FormattingEnabled = True
        Me.unitOfMeasur.Location = New System.Drawing.Point(212, 202)
        Me.unitOfMeasur.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.unitOfMeasur.Name = "unitOfMeasur"
        Me.unitOfMeasur.Size = New System.Drawing.Size(240, 26)
        Me.unitOfMeasur.TabIndex = 82
        '
        'category
        '
        Me.category.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.category.FormattingEnabled = True
        Me.category.Location = New System.Drawing.Point(212, 98)
        Me.category.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.category.Name = "category"
        Me.category.Size = New System.Drawing.Size(240, 26)
        Me.category.TabIndex = 79
        '
        'itemName
        '
        Me.itemName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.itemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.itemName.Location = New System.Drawing.Point(210, 41)
        Me.itemName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.itemName.Name = "itemName"
        Me.itemName.Size = New System.Drawing.Size(241, 24)
        Me.itemName.TabIndex = 78
        '
        'quantity
        '
        Me.quantity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantity.Location = New System.Drawing.Point(212, 255)
        Me.quantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(240, 24)
        Me.quantity.TabIndex = 75
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 18)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Quanity"
        '
        'stock
        '
        Me.stock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stock.AutoSize = True
        Me.stock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stock.Location = New System.Drawing.Point(43, 204)
        Me.stock.Name = "stock"
        Me.stock.Size = New System.Drawing.Size(113, 18)
        Me.stock.TabIndex = 61
        Me.stock.Text = "Unit of Measure"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(43, 151)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(83, 18)
        Me.lblDescription.TabIndex = 60
        Me.lblDescription.Text = "Description"
        '
        'nameSupply
        '
        Me.nameSupply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nameSupply.AutoSize = True
        Me.nameSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameSupply.Location = New System.Drawing.Point(43, 98)
        Me.nameSupply.Name = "nameSupply"
        Me.nameSupply.Size = New System.Drawing.Size(68, 18)
        Me.nameSupply.TabIndex = 59
        Me.nameSupply.Text = "Category"
        '
        'supply_id
        '
        Me.supply_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supply_id.AutoSize = True
        Me.supply_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supply_id.Location = New System.Drawing.Point(43, 47)
        Me.supply_id.Name = "supply_id"
        Me.supply_id.Size = New System.Drawing.Size(80, 18)
        Me.supply_id.TabIndex = 58
        Me.supply_id.Text = "Item Name"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(56, 111)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1207, 71)
        Me.RoundedPanel1.TabIndex = 46
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(19, 25)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(235, 18)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required supply information."
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(45, 50)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(353, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 45
        Me.admin_label_DepartmentManagement.Text = "Supply Register Form"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(927, 674)
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
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1080, 674)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 156
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'unitCost
        '
        Me.unitCost.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.unitCost.DecimalPlaces = 2
        Me.unitCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitCost.Location = New System.Drawing.Point(239, 41)
        Me.unitCost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.unitCost.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.unitCost.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.unitCost.Name = "unitCost"
        Me.unitCost.Size = New System.Drawing.Size(240, 24)
        Me.unitCost.TabIndex = 76
        '
        'totalCost
        '
        Me.totalCost.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.totalCost.DecimalPlaces = 2
        Me.totalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalCost.Location = New System.Drawing.Point(239, 92)
        Me.totalCost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.totalCost.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.totalCost.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.totalCost.Name = "totalCost"
        Me.totalCost.Size = New System.Drawing.Size(240, 24)
        Me.totalCost.TabIndex = 77
        '
        'supplier
        '
        Me.supplier.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplier.FormattingEnabled = True
        Me.supplier.Location = New System.Drawing.Point(239, 151)
        Me.supplier.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(240, 26)
        Me.supplier.TabIndex = 83
        '
        'location
        '
        Me.location.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.FormattingEnabled = True
        Me.location.Location = New System.Drawing.Point(239, 257)
        Me.location.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(240, 26)
        Me.location.TabIndex = 84
        '
        'description
        '
        Me.description.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.FormattingEnabled = True
        Me.description.Location = New System.Drawing.Point(210, 148)
        Me.description.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(240, 26)
        Me.description.TabIndex = 85
        '
        'AddSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AddSupply"
        Me.Size = New System.Drawing.Size(1300, 826)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.quantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.unitCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.totalCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents receivedBy As System.Windows.Forms.Label
    Friend WithEvents date_received As System.Windows.Forms.Label
    Friend WithEvents expirationDate As System.Windows.Forms.Label
    Friend WithEvents remarksSupply As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents stock As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents nameSupply As System.Windows.Forms.Label
    Friend WithEvents supply_id As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents quantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents itemName As System.Windows.Forms.TextBox
    Friend WithEvents category As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents dateReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents unitOfMeasur As System.Windows.Forms.ComboBox
    Friend WithEvents sourceOfFunds As System.Windows.Forms.TextBox
    Friend WithEvents supplier As System.Windows.Forms.ComboBox
    Friend WithEvents totalCost As System.Windows.Forms.NumericUpDown
    Friend WithEvents unitCost As System.Windows.Forms.NumericUpDown
    Friend Shadows WithEvents location As System.Windows.Forms.ComboBox
    Friend WithEvents description As System.Windows.Forms.ComboBox
End Class
