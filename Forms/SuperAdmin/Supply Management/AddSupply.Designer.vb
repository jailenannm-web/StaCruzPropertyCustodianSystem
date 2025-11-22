<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSupply
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim acquisitionDate As System.Windows.Forms.Label
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.acquisitionDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.expirationDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.totalValueTxt = New System.Windows.Forms.TextBox()
        Me.statusCombo = New System.Windows.Forms.ComboBox()
        Me.locationTxt = New System.Windows.Forms.TextBox()
        Me.reorderLevel = New System.Windows.Forms.Label()
        Me.warrantyExpiration = New System.Windows.Forms.Label()
        Me.expirationDate = New System.Windows.Forms.Label()
        Me.location = New System.Windows.Forms.Label()
        Me.custodianID = New System.Windows.Forms.Label()
        Me.custodianIDtxt = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.categoryCmbo = New System.Windows.Forms.ComboBox()
        Me.unitOfMeasureCombo = New System.Windows.Forms.ComboBox()
        Me.no_of_employees_numeric = New System.Windows.Forms.NumericUpDown()
        Me.descriptionTxt = New System.Windows.Forms.TextBox()
        Me.supplyNameTxt = New System.Windows.Forms.TextBox()
        Me.supplyIDTxt = New System.Windows.Forms.TextBox()
        Me.quantityInStock = New System.Windows.Forms.Label()
        Me.unitOfMeasure = New System.Windows.Forms.Label()
        Me.description = New System.Windows.Forms.Label()
        Me.category = New System.Windows.Forms.Label()
        Me.supply_Name = New System.Windows.Forms.Label()
        Me.supplyID = New System.Windows.Forms.Label()
        Me.unitCost = New System.Windows.Forms.Label()
        Me.totalValue = New System.Windows.Forms.Label()
        Me.supplierIDTxt = New System.Windows.Forms.TextBox()
        Me.reorderLevelTxt = New System.Windows.Forms.TextBox()
        Me.status = New System.Windows.Forms.Label()
        Me.unitCostTxt = New System.Windows.Forms.TextBox()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        acquisitionDate = New System.Windows.Forms.Label()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(628, 1047)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(255, 57)
        Me.btn_Cancel.TabIndex = 93
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(1085, 1047)
        Me.btn_Login.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(253, 57)
        Me.btn_Login.TabIndex = 94
        Me.btn_Login.Text = "Add"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(215, 231)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1264, 526)
        Me.RoundedPanel2.TabIndex = 118
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.unitCostTxt)
        Me.Panel2.Controls.Add(Me.status)
        Me.Panel2.Controls.Add(Me.totalValue)
        Me.Panel2.Controls.Add(Me.acquisitionDatePicker)
        Me.Panel2.Controls.Add(Me.unitCost)
        Me.Panel2.Controls.Add(Me.expirationDatePicker)
        Me.Panel2.Controls.Add(Me.totalValueTxt)
        Me.Panel2.Controls.Add(Me.statusCombo)
        Me.Panel2.Controls.Add(Me.locationTxt)
        Me.Panel2.Controls.Add(acquisitionDate)
        Me.Panel2.Controls.Add(Me.expirationDate)
        Me.Panel2.Controls.Add(Me.location)
        Me.Panel2.Controls.Add(Me.custodianID)
        Me.Panel2.Controls.Add(Me.custodianIDtxt)
        Me.Panel2.Location = New System.Drawing.Point(655, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(537, 483)
        Me.Panel2.TabIndex = 65
        '
        'acquisitionDatePicker
        '
        Me.acquisitionDatePicker.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.acquisitionDatePicker.Location = New System.Drawing.Point(242, 147)
        Me.acquisitionDatePicker.Name = "acquisitionDatePicker"
        Me.acquisitionDatePicker.Size = New System.Drawing.Size(238, 30)
        Me.acquisitionDatePicker.TabIndex = 68
        '
        'expirationDatePicker
        '
        Me.expirationDatePicker.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.expirationDatePicker.Location = New System.Drawing.Point(242, 197)
        Me.expirationDatePicker.Name = "expirationDatePicker"
        Me.expirationDatePicker.Size = New System.Drawing.Size(238, 30)
        Me.expirationDatePicker.TabIndex = 67
        '
        'totalValueTxt
        '
        Me.totalValueTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalValueTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalValueTxt.Location = New System.Drawing.Point(242, 94)
        Me.totalValueTxt.Name = "totalValueTxt"
        Me.totalValueTxt.Size = New System.Drawing.Size(238, 30)
        Me.totalValueTxt.TabIndex = 66
        '
        'statusCombo
        '
        Me.statusCombo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.statusCombo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusCombo.FormattingEnabled = True
        Me.statusCombo.Location = New System.Drawing.Point(242, 355)
        Me.statusCombo.Name = "statusCombo"
        Me.statusCombo.Size = New System.Drawing.Size(238, 34)
        Me.statusCombo.TabIndex = 65
        '
        'locationTxt
        '
        Me.locationTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.locationTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.locationTxt.Location = New System.Drawing.Point(242, 253)
        Me.locationTxt.Name = "locationTxt"
        Me.locationTxt.Size = New System.Drawing.Size(238, 30)
        Me.locationTxt.TabIndex = 64
        '
        'acquisitionDate
        '
        acquisitionDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        acquisitionDate.AutoSize = True
        acquisitionDate.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        acquisitionDate.Location = New System.Drawing.Point(44, 151)
        acquisitionDate.Name = "acquisitionDate"
        acquisitionDate.Size = New System.Drawing.Size(135, 26)
        acquisitionDate.TabIndex = 48
        acquisitionDate.Text = "Acquisition Date"
        '
        'reorderLevel
        '
        Me.reorderLevel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reorderLevel.AutoSize = True
        Me.reorderLevel.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reorderLevel.Location = New System.Drawing.Point(42, 374)
        Me.reorderLevel.Name = "reorderLevel"
        Me.reorderLevel.Size = New System.Drawing.Size(111, 26)
        Me.reorderLevel.TabIndex = 46
        Me.reorderLevel.Text = "Reorder Level"
        '
        'warrantyExpiration
        '
        Me.warrantyExpiration.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.warrantyExpiration.AutoSize = True
        Me.warrantyExpiration.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.warrantyExpiration.Location = New System.Drawing.Point(42, 425)
        Me.warrantyExpiration.Name = "warrantyExpiration"
        Me.warrantyExpiration.Size = New System.Drawing.Size(93, 26)
        Me.warrantyExpiration.TabIndex = 47
        Me.warrantyExpiration.Text = "Supplier ID"
        '
        'expirationDate
        '
        Me.expirationDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.expirationDate.AutoSize = True
        Me.expirationDate.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expirationDate.Location = New System.Drawing.Point(44, 204)
        Me.expirationDate.Name = "expirationDate"
        Me.expirationDate.Size = New System.Drawing.Size(125, 26)
        Me.expirationDate.TabIndex = 49
        Me.expirationDate.Text = "Expiration Date"
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
        'custodianID
        '
        Me.custodianID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.custodianID.AutoSize = True
        Me.custodianID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.custodianID.Location = New System.Drawing.Point(44, 312)
        Me.custodianID.Name = "custodianID"
        Me.custodianID.Size = New System.Drawing.Size(110, 26)
        Me.custodianID.TabIndex = 51
        Me.custodianID.Text = "Custodian ID"
        '
        'custodianIDtxt
        '
        Me.custodianIDtxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.custodianIDtxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.custodianIDtxt.Location = New System.Drawing.Point(242, 307)
        Me.custodianIDtxt.Name = "custodianIDtxt"
        Me.custodianIDtxt.Size = New System.Drawing.Size(238, 30)
        Me.custodianIDtxt.TabIndex = 58
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.reorderLevelTxt)
        Me.Panel1.Controls.Add(Me.supplierIDTxt)
        Me.Panel1.Controls.Add(Me.categoryCmbo)
        Me.Panel1.Controls.Add(Me.unitOfMeasureCombo)
        Me.Panel1.Controls.Add(Me.no_of_employees_numeric)
        Me.Panel1.Controls.Add(Me.descriptionTxt)
        Me.Panel1.Controls.Add(Me.supplyNameTxt)
        Me.Panel1.Controls.Add(Me.supplyIDTxt)
        Me.Panel1.Controls.Add(Me.quantityInStock)
        Me.Panel1.Controls.Add(Me.unitOfMeasure)
        Me.Panel1.Controls.Add(Me.reorderLevel)
        Me.Panel1.Controls.Add(Me.warrantyExpiration)
        Me.Panel1.Controls.Add(Me.description)
        Me.Panel1.Controls.Add(Me.category)
        Me.Panel1.Controls.Add(Me.supply_Name)
        Me.Panel1.Controls.Add(Me.supplyID)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 483)
        Me.Panel1.TabIndex = 64
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
        Me.categoryCmbo.Size = New System.Drawing.Size(254, 34)
        Me.categoryCmbo.TabIndex = 71
        '
        'unitOfMeasureCombo
        '
        Me.unitOfMeasureCombo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.unitOfMeasureCombo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitOfMeasureCombo.FormattingEnabled = True
        Me.unitOfMeasureCombo.Location = New System.Drawing.Point(256, 248)
        Me.unitOfMeasureCombo.Name = "unitOfMeasureCombo"
        Me.unitOfMeasureCombo.Size = New System.Drawing.Size(254, 34)
        Me.unitOfMeasureCombo.TabIndex = 70
        '
        'no_of_employees_numeric
        '
        Me.no_of_employees_numeric.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.no_of_employees_numeric.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.no_of_employees_numeric.Location = New System.Drawing.Point(256, 308)
        Me.no_of_employees_numeric.Name = "no_of_employees_numeric"
        Me.no_of_employees_numeric.Size = New System.Drawing.Size(254, 30)
        Me.no_of_employees_numeric.TabIndex = 69
        '
        'descriptionTxt
        '
        Me.descriptionTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.descriptionTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionTxt.Location = New System.Drawing.Point(256, 197)
        Me.descriptionTxt.Name = "descriptionTxt"
        Me.descriptionTxt.Size = New System.Drawing.Size(254, 30)
        Me.descriptionTxt.TabIndex = 67
        '
        'supplyNameTxt
        '
        Me.supplyNameTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyNameTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyNameTxt.Location = New System.Drawing.Point(256, 94)
        Me.supplyNameTxt.Name = "supplyNameTxt"
        Me.supplyNameTxt.Size = New System.Drawing.Size(254, 30)
        Me.supplyNameTxt.TabIndex = 66
        '
        'supplyIDTxt
        '
        Me.supplyIDTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyIDTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyIDTxt.Location = New System.Drawing.Point(256, 44)
        Me.supplyIDTxt.Name = "supplyIDTxt"
        Me.supplyIDTxt.Size = New System.Drawing.Size(254, 30)
        Me.supplyIDTxt.TabIndex = 64
        '
        'quantityInStock
        '
        Me.quantityInStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.quantityInStock.AutoSize = True
        Me.quantityInStock.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantityInStock.Location = New System.Drawing.Point(42, 313)
        Me.quantityInStock.Name = "quantityInStock"
        Me.quantityInStock.Size = New System.Drawing.Size(139, 26)
        Me.quantityInStock.TabIndex = 63
        Me.quantityInStock.Text = "Quantity in Stock"
        '
        'unitOfMeasure
        '
        Me.unitOfMeasure.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.unitOfMeasure.AutoSize = True
        Me.unitOfMeasure.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitOfMeasure.Location = New System.Drawing.Point(42, 256)
        Me.unitOfMeasure.Name = "unitOfMeasure"
        Me.unitOfMeasure.Size = New System.Drawing.Size(129, 26)
        Me.unitOfMeasure.TabIndex = 62
        Me.unitOfMeasure.Text = "Unit of Measure"
        '
        'description
        '
        Me.description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.description.AutoSize = True
        Me.description.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(42, 201)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(98, 26)
        Me.description.TabIndex = 61
        Me.description.Text = "Description"
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
        'supply_Name
        '
        Me.supply_Name.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supply_Name.AutoSize = True
        Me.supply_Name.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supply_Name.Location = New System.Drawing.Point(42, 98)
        Me.supply_Name.Name = "supply_Name"
        Me.supply_Name.Size = New System.Drawing.Size(112, 26)
        Me.supply_Name.TabIndex = 59
        Me.supply_Name.Text = "Supply Name"
        '
        'supplyID
        '
        Me.supplyID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyID.AutoSize = True
        Me.supplyID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyID.Location = New System.Drawing.Point(42, 47)
        Me.supplyID.Name = "supplyID"
        Me.supplyID.Size = New System.Drawing.Size(82, 26)
        Me.supplyID.TabIndex = 58
        Me.supplyID.Text = "Supply ID"
        '
        'unitCost
        '
        Me.unitCost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.unitCost.AutoSize = True
        Me.unitCost.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitCost.Location = New System.Drawing.Point(44, 47)
        Me.unitCost.Name = "unitCost"
        Me.unitCost.Size = New System.Drawing.Size(80, 26)
        Me.unitCost.TabIndex = 72
        Me.unitCost.Text = "Unit Cost"
        '
        'totalValue
        '
        Me.totalValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalValue.AutoSize = True
        Me.totalValue.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalValue.Location = New System.Drawing.Point(44, 98)
        Me.totalValue.Name = "totalValue"
        Me.totalValue.Size = New System.Drawing.Size(96, 26)
        Me.totalValue.TabIndex = 73
        Me.totalValue.Text = "Total Value"
        '
        'supplierIDTxt
        '
        Me.supplierIDTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplierIDTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierIDTxt.Location = New System.Drawing.Point(256, 422)
        Me.supplierIDTxt.Name = "supplierIDTxt"
        Me.supplierIDTxt.Size = New System.Drawing.Size(254, 30)
        Me.supplierIDTxt.TabIndex = 72
        '
        'reorderLevelTxt
        '
        Me.reorderLevelTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reorderLevelTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reorderLevelTxt.Location = New System.Drawing.Point(256, 368)
        Me.reorderLevelTxt.Name = "reorderLevelTxt"
        Me.reorderLevelTxt.Size = New System.Drawing.Size(254, 30)
        Me.reorderLevelTxt.TabIndex = 73
        '
        'status
        '
        Me.status.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status.AutoSize = True
        Me.status.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.Location = New System.Drawing.Point(44, 363)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(59, 26)
        Me.status.TabIndex = 74
        Me.status.Text = "Status"
        '
        'unitCostTxt
        '
        Me.unitCostTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.unitCostTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitCostTxt.Location = New System.Drawing.Point(242, 47)
        Me.unitCostTxt.Name = "unitCostTxt"
        Me.unitCostTxt.Size = New System.Drawing.Size(238, 30)
        Me.unitCostTxt.TabIndex = 75
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(212, 85)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(222, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 158
        Me.admin_label_DepartmentManagement.Text = "Add Supply"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(212, 146)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1264, 72)
        Me.RoundedPanel1.TabIndex = 159
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
        'AddSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Login)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AddSupply"
        Me.Text = "AddSupply"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Login As System.Windows.Forms.Button
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents acquisitionDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents expirationDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents totalValueTxt As System.Windows.Forms.TextBox
    Friend WithEvents statusCombo As System.Windows.Forms.ComboBox
    Friend WithEvents locationTxt As System.Windows.Forms.TextBox
    Friend WithEvents reorderLevel As System.Windows.Forms.Label
    Friend WithEvents warrantyExpiration As System.Windows.Forms.Label
    Friend WithEvents expirationDate As System.Windows.Forms.Label
    Friend WithEvents location As System.Windows.Forms.Label
    Friend WithEvents custodianID As System.Windows.Forms.Label
    Friend WithEvents custodianIDtxt As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents categoryCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents unitOfMeasureCombo As System.Windows.Forms.ComboBox
    Friend WithEvents no_of_employees_numeric As System.Windows.Forms.NumericUpDown
    Friend WithEvents descriptionTxt As System.Windows.Forms.TextBox
    Friend WithEvents supplyNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents supplyIDTxt As System.Windows.Forms.TextBox
    Friend WithEvents quantityInStock As System.Windows.Forms.Label
    Friend WithEvents unitOfMeasure As System.Windows.Forms.Label
    Friend WithEvents description As System.Windows.Forms.Label
    Friend WithEvents category As System.Windows.Forms.Label
    Friend WithEvents supply_Name As System.Windows.Forms.Label
    Friend WithEvents supplyID As System.Windows.Forms.Label
    Friend WithEvents totalValue As System.Windows.Forms.Label
    Friend WithEvents unitCost As System.Windows.Forms.Label
    Friend WithEvents reorderLevelTxt As System.Windows.Forms.TextBox
    Friend WithEvents supplierIDTxt As System.Windows.Forms.TextBox
    Friend WithEvents unitCostTxt As System.Windows.Forms.TextBox
    Friend WithEvents status As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
End Class
