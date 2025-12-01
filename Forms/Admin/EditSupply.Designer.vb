<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSupply
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
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.remarksTxt = New System.Windows.Forms.TextBox()
        Me.supplierTxt = New System.Windows.Forms.TextBox()
        Me.supplier = New System.Windows.Forms.Label()
        Me.receivedBy = New System.Windows.Forms.Label()
        Me.date_received = New System.Windows.Forms.Label()
        Me.expirationDate = New System.Windows.Forms.Label()
        Me.remarksSupply = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.categoryCmbo = New System.Windows.Forms.ComboBox()
        Me.supplyName = New System.Windows.Forms.TextBox()
        Me.stockSupply = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.supplyID = New System.Windows.Forms.TextBox()
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
        CType(Me.stockSupply, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(985, 736)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 162
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
        Me.btnSave.Location = New System.Drawing.Point(1138, 736)
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
        Me.RoundedPanel2.Location = New System.Drawing.Point(114, 265)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1207, 410)
        Me.RoundedPanel2.TabIndex = 160
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.remarksTxt)
        Me.Panel2.Controls.Add(Me.supplierTxt)
        Me.Panel2.Controls.Add(Me.supplier)
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
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(239, 202)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(239, 24)
        Me.TextBox3.TabIndex = 75
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(239, 148)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(239, 24)
        Me.TextBox2.TabIndex = 74
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(239, 95)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(239, 24)
        Me.TextBox1.TabIndex = 73
        '
        'remarksTxt
        '
        Me.remarksTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarksTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarksTxt.Location = New System.Drawing.Point(239, 256)
        Me.remarksTxt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.remarksTxt.Name = "remarksTxt"
        Me.remarksTxt.Size = New System.Drawing.Size(239, 24)
        Me.remarksTxt.TabIndex = 72
        '
        'supplierTxt
        '
        Me.supplierTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplierTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierTxt.Location = New System.Drawing.Point(239, 43)
        Me.supplierTxt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.supplierTxt.Name = "supplierTxt"
        Me.supplierTxt.Size = New System.Drawing.Size(239, 24)
        Me.supplierTxt.TabIndex = 70
        '
        'supplier
        '
        Me.supplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplier.AutoSize = True
        Me.supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplier.Location = New System.Drawing.Point(41, 47)
        Me.supplier.Name = "supplier"
        Me.supplier.Size = New System.Drawing.Size(70, 18)
        Me.supplier.TabIndex = 69
        Me.supplier.Text = "Unit Cost"
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
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.categoryCmbo)
        Me.Panel1.Controls.Add(Me.supplyName)
        Me.Panel1.Controls.Add(Me.stockSupply)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.supplyID)
        Me.Panel1.Controls.Add(Me.stock)
        Me.Panel1.Controls.Add(Me.category)
        Me.Panel1.Controls.Add(Me.nameSupply)
        Me.Panel1.Controls.Add(Me.supply_id)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 367)
        Me.Panel1.TabIndex = 64
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(212, 302)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(239, 24)
        Me.DateTimePicker1.TabIndex = 84
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
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(212, 202)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(240, 26)
        Me.ComboBox1.TabIndex = 82
        '
        'categoryCmbo
        '
        Me.categoryCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.categoryCmbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryCmbo.FormattingEnabled = True
        Me.categoryCmbo.Location = New System.Drawing.Point(212, 98)
        Me.categoryCmbo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.categoryCmbo.Name = "categoryCmbo"
        Me.categoryCmbo.Size = New System.Drawing.Size(240, 26)
        Me.categoryCmbo.TabIndex = 79
        '
        'supplyName
        '
        Me.supplyName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyName.Location = New System.Drawing.Point(212, 151)
        Me.supplyName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.supplyName.Name = "supplyName"
        Me.supplyName.Size = New System.Drawing.Size(241, 24)
        Me.supplyName.TabIndex = 78
        '
        'stockSupply
        '
        Me.stockSupply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stockSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stockSupply.Location = New System.Drawing.Point(212, 255)
        Me.stockSupply.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.stockSupply.Name = "stockSupply"
        Me.stockSupply.Size = New System.Drawing.Size(240, 24)
        Me.stockSupply.TabIndex = 75
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
        'supplyID
        '
        Me.supplyID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyID.Location = New System.Drawing.Point(212, 43)
        Me.supplyID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.supplyID.Name = "supplyID"
        Me.supplyID.Size = New System.Drawing.Size(241, 24)
        Me.supplyID.TabIndex = 64
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
        'category
        '
        Me.category.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.category.AutoSize = True
        Me.category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.category.Location = New System.Drawing.Point(43, 151)
        Me.category.Name = "category"
        Me.category.Size = New System.Drawing.Size(83, 18)
        Me.category.TabIndex = 60
        Me.category.Text = "Description"
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
        Me.RoundedPanel1.Location = New System.Drawing.Point(114, 173)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1207, 71)
        Me.RoundedPanel1.TabIndex = 159
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
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(103, 112)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(353, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 158
        Me.admin_label_DepartmentManagement.Text = "Supply Register Form"
        '
        'EditSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "EditSupply"
        Me.Size = New System.Drawing.Size(1424, 883)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.stockSupply, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents remarksTxt As System.Windows.Forms.TextBox
    Friend WithEvents supplierTxt As System.Windows.Forms.TextBox
    Friend WithEvents supplier As System.Windows.Forms.Label
    Friend WithEvents receivedBy As System.Windows.Forms.Label
    Friend WithEvents date_received As System.Windows.Forms.Label
    Friend WithEvents expirationDate As System.Windows.Forms.Label
    Friend WithEvents remarksSupply As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents categoryCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents supplyName As System.Windows.Forms.TextBox
    Friend WithEvents stockSupply As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents supplyID As System.Windows.Forms.TextBox
    Friend WithEvents stock As System.Windows.Forms.Label
    Friend WithEvents category As System.Windows.Forms.Label
    Friend WithEvents nameSupply As System.Windows.Forms.Label
    Friend WithEvents supply_id As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
End Class
