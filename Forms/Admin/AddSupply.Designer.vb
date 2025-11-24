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
        Me.updatedAtPicker = New System.Windows.Forms.DateTimePicker()
        Me.createdAtPicker = New System.Windows.Forms.DateTimePicker()
        Me.remarksTxt = New System.Windows.Forms.TextBox()
        Me.receivedByPicker = New System.Windows.Forms.DateTimePicker()
        Me.supplierTxt = New System.Windows.Forms.TextBox()
        Me.supplier = New System.Windows.Forms.Label()
        Me.dateReceivedPicker = New System.Windows.Forms.DateTimePicker()
        Me.expirationDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.receivedBy = New System.Windows.Forms.Label()
        Me.date_received = New System.Windows.Forms.Label()
        Me.expirationDate = New System.Windows.Forms.Label()
        Me.remarksSupply = New System.Windows.Forms.Label()
        Me.createdAt = New System.Windows.Forms.Label()
        Me.updatedAt = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.statusCombo = New System.Windows.Forms.ComboBox()
        Me.statusCmbo = New System.Windows.Forms.ComboBox()
        Me.categoryCmbo = New System.Windows.Forms.ComboBox()
        Me.supplyName = New System.Windows.Forms.TextBox()
        Me.locationtxt = New System.Windows.Forms.TextBox()
        Me.location_supply = New System.Windows.Forms.Label()
        Me.stockSupply = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.totalValueNumber = New System.Windows.Forms.NumericUpDown()
        Me.supplyID = New System.Windows.Forms.TextBox()
        Me.status = New System.Windows.Forms.Label()
        Me.totalValue = New System.Windows.Forms.Label()
        Me.stock = New System.Windows.Forms.Label()
        Me.category = New System.Windows.Forms.Label()
        Me.nameSupply = New System.Windows.Forms.Label()
        Me.supply_id = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.stockSupply, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.totalValueNumber, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RoundedPanel2.Location = New System.Drawing.Point(56, 203)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1207, 525)
        Me.RoundedPanel2.TabIndex = 47
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.updatedAtPicker)
        Me.Panel2.Controls.Add(Me.createdAtPicker)
        Me.Panel2.Controls.Add(Me.remarksTxt)
        Me.Panel2.Controls.Add(Me.receivedByPicker)
        Me.Panel2.Controls.Add(Me.supplierTxt)
        Me.Panel2.Controls.Add(Me.supplier)
        Me.Panel2.Controls.Add(Me.dateReceivedPicker)
        Me.Panel2.Controls.Add(Me.expirationDatePicker)
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
        'updatedAtPicker
        '
        Me.updatedAtPicker.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.updatedAtPicker.Location = New System.Drawing.Point(239, 363)
        Me.updatedAtPicker.Name = "updatedAtPicker"
        Me.updatedAtPicker.Size = New System.Drawing.Size(238, 30)
        Me.updatedAtPicker.TabIndex = 74
        '
        'createdAtPicker
        '
        Me.createdAtPicker.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.createdAtPicker.Location = New System.Drawing.Point(239, 309)
        Me.createdAtPicker.Name = "createdAtPicker"
        Me.createdAtPicker.Size = New System.Drawing.Size(238, 30)
        Me.createdAtPicker.TabIndex = 73
        '
        'remarksTxt
        '
        Me.remarksTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarksTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarksTxt.Location = New System.Drawing.Point(239, 256)
        Me.remarksTxt.Name = "remarksTxt"
        Me.remarksTxt.Size = New System.Drawing.Size(238, 30)
        Me.remarksTxt.TabIndex = 72
        '
        'receivedByPicker
        '
        Me.receivedByPicker.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.receivedByPicker.Location = New System.Drawing.Point(239, 201)
        Me.receivedByPicker.Name = "receivedByPicker"
        Me.receivedByPicker.Size = New System.Drawing.Size(238, 30)
        Me.receivedByPicker.TabIndex = 71
        '
        'supplierTxt
        '
        Me.supplierTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplierTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierTxt.Location = New System.Drawing.Point(239, 43)
        Me.supplierTxt.Name = "supplierTxt"
        Me.supplierTxt.Size = New System.Drawing.Size(238, 30)
        Me.supplierTxt.TabIndex = 70
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
        Me.supplier.Size = New System.Drawing.Size(74, 26)
        Me.supplier.TabIndex = 69
        Me.supplier.Text = "Supplier"
        '
        'dateReceivedPicker
        '
        Me.dateReceivedPicker.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dateReceivedPicker.Location = New System.Drawing.Point(239, 95)
        Me.dateReceivedPicker.Name = "dateReceivedPicker"
        Me.dateReceivedPicker.Size = New System.Drawing.Size(238, 30)
        Me.dateReceivedPicker.TabIndex = 68
        '
        'expirationDatePicker
        '
        Me.expirationDatePicker.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.expirationDatePicker.Location = New System.Drawing.Point(239, 147)
        Me.expirationDatePicker.Name = "expirationDatePicker"
        Me.expirationDatePicker.Size = New System.Drawing.Size(238, 30)
        Me.expirationDatePicker.TabIndex = 67
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
        Me.receivedBy.Size = New System.Drawing.Size(101, 26)
        Me.receivedBy.TabIndex = 48
        Me.receivedBy.Text = "Received by"
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
        Me.date_received.Size = New System.Drawing.Size(118, 26)
        Me.date_received.TabIndex = 46
        Me.date_received.Text = "Date Received"
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
        Me.expirationDate.Size = New System.Drawing.Size(125, 26)
        Me.expirationDate.TabIndex = 47
        Me.expirationDate.Text = "Expiration Date"
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
        Me.createdAt.Size = New System.Drawing.Size(92, 26)
        Me.createdAt.TabIndex = 50
        Me.createdAt.Text = "Created At"
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
        Me.updatedAt.Size = New System.Drawing.Size(95, 26)
        Me.updatedAt.TabIndex = 51
        Me.updatedAt.Text = "Updated At"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.statusCombo)
        Me.Panel1.Controls.Add(Me.statusCmbo)
        Me.Panel1.Controls.Add(Me.categoryCmbo)
        Me.Panel1.Controls.Add(Me.supplyName)
        Me.Panel1.Controls.Add(Me.locationtxt)
        Me.Panel1.Controls.Add(Me.location_supply)
        Me.Panel1.Controls.Add(Me.stockSupply)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.totalValueNumber)
        Me.Panel1.Controls.Add(Me.supplyID)
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
        'statusCombo
        '
        Me.statusCombo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.statusCombo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusCombo.FormattingEnabled = True
        Me.statusCombo.Location = New System.Drawing.Point(256, 370)
        Me.statusCombo.Name = "statusCombo"
        Me.statusCombo.Size = New System.Drawing.Size(197, 34)
        Me.statusCombo.TabIndex = 81
        '
        'statusCmbo
        '
        Me.statusCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.statusCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusCmbo.FormattingEnabled = True
        Me.statusCmbo.Location = New System.Drawing.Point(256, 254)
        Me.statusCmbo.Name = "statusCmbo"
        Me.statusCmbo.Size = New System.Drawing.Size(197, 34)
        Me.statusCmbo.TabIndex = 80
        '
        'categoryCmbo
        '
        Me.categoryCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.categoryCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryCmbo.FormattingEnabled = True
        Me.categoryCmbo.Location = New System.Drawing.Point(256, 148)
        Me.categoryCmbo.Name = "categoryCmbo"
        Me.categoryCmbo.Size = New System.Drawing.Size(197, 34)
        Me.categoryCmbo.TabIndex = 79
        '
        'supplyName
        '
        Me.supplyName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyName.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyName.Location = New System.Drawing.Point(256, 94)
        Me.supplyName.Name = "supplyName"
        Me.supplyName.Size = New System.Drawing.Size(197, 30)
        Me.supplyName.TabIndex = 78
        '
        'locationtxt
        '
        Me.locationtxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.locationtxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.locationtxt.Location = New System.Drawing.Point(256, 429)
        Me.locationtxt.Name = "locationtxt"
        Me.locationtxt.Size = New System.Drawing.Size(197, 30)
        Me.locationtxt.TabIndex = 77
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
        Me.location_supply.Size = New System.Drawing.Size(76, 26)
        Me.location_supply.TabIndex = 76
        Me.location_supply.Text = "Location"
        '
        'stockSupply
        '
        Me.stockSupply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stockSupply.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stockSupply.Location = New System.Drawing.Point(256, 201)
        Me.stockSupply.Name = "stockSupply"
        Me.stockSupply.Size = New System.Drawing.Size(197, 30)
        Me.stockSupply.TabIndex = 75
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
        Me.Label2.Size = New System.Drawing.Size(59, 26)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Status"
        '
        'totalValueNumber
        '
        Me.totalValueNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalValueNumber.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalValueNumber.Location = New System.Drawing.Point(256, 319)
        Me.totalValueNumber.Name = "totalValueNumber"
        Me.totalValueNumber.Size = New System.Drawing.Size(197, 30)
        Me.totalValueNumber.TabIndex = 69
        '
        'supplyID
        '
        Me.supplyID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyID.Location = New System.Drawing.Point(256, 43)
        Me.supplyID.Name = "supplyID"
        Me.supplyID.Size = New System.Drawing.Size(197, 30)
        Me.supplyID.TabIndex = 64
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
        Me.status.Size = New System.Drawing.Size(59, 26)
        Me.status.TabIndex = 63
        Me.status.Text = "Status"
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
        Me.totalValue.Size = New System.Drawing.Size(96, 26)
        Me.totalValue.TabIndex = 62
        Me.totalValue.Text = "Total Value"
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
        Me.stock.Size = New System.Drawing.Size(53, 26)
        Me.stock.TabIndex = 61
        Me.stock.Text = "Stock"
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
        Me.nameSupply.Size = New System.Drawing.Size(57, 26)
        Me.nameSupply.TabIndex = 59
        Me.nameSupply.Text = "Name"
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
        Me.supply_id.Size = New System.Drawing.Size(82, 26)
        Me.supply_id.TabIndex = 58
        Me.supply_id.Text = "Supply ID"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(56, 111)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1207, 72)
        Me.RoundedPanel1.TabIndex = 46
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(18, 24)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(278, 26)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required supply information."
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(46, 50)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(222, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 45
        Me.admin_label_DepartmentManagement.Text = "Add Supply"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(928, 760)
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
        Me.btnSave.Location = New System.Drawing.Point(1081, 760)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 156
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
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
        Me.Name = "AddSupply"
        Me.Size = New System.Drawing.Size(1300, 826)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.stockSupply, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.totalValueNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dateReceivedPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents expirationDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents receivedBy As System.Windows.Forms.Label
    Friend WithEvents date_received As System.Windows.Forms.Label
    Friend WithEvents expirationDate As System.Windows.Forms.Label
    Friend WithEvents remarksSupply As System.Windows.Forms.Label
    Friend WithEvents createdAt As System.Windows.Forms.Label
    Friend WithEvents updatedAt As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents totalValueNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents supplyID As System.Windows.Forms.TextBox
    Friend WithEvents status As System.Windows.Forms.Label
    Friend WithEvents totalValue As System.Windows.Forms.Label
    Friend WithEvents stock As System.Windows.Forms.Label
    Friend WithEvents category As System.Windows.Forms.Label
    Friend WithEvents nameSupply As System.Windows.Forms.Label
    Friend WithEvents supply_id As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents supplierTxt As System.Windows.Forms.TextBox
    Friend WithEvents supplier As System.Windows.Forms.Label
    Friend WithEvents locationtxt As System.Windows.Forms.TextBox
    Friend WithEvents location_supply As System.Windows.Forms.Label
    Friend WithEvents stockSupply As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents supplyName As System.Windows.Forms.TextBox
    Friend WithEvents categoryCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents statusCombo As System.Windows.Forms.ComboBox
    Friend WithEvents statusCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents updatedAtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents createdAtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents remarksTxt As System.Windows.Forms.TextBox
    Friend WithEvents receivedByPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
End Class
