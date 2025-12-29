<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuppliesStock
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
        Me.btnBack = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPDF = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.status = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.location = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.sourceOfFunds = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.totalCost = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.unitCost = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dateReceived = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.quantity = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.unitOfMeasure = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.description = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.category = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.itemName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.supplyId = New System.Windows.Forms.TextBox()
        Me.lblSupplyId = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.stockStatus = New System.Windows.Forms.ComboBox()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.totalCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.unitCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBack.CornerRadius = 15
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(700, 662)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(153, 34)
        Me.btnBack.TabIndex = 391
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnPDF
        '
        Me.btnPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnPDF.CornerRadius = 15
        Me.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPDF.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnPDF.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnPDF.Location = New System.Drawing.Point(1020, 662)
        Me.btnPDF.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(153, 34)
        Me.btnPDF.TabIndex = 390
        Me.btnPDF.Text = "Generate PDF File"
        Me.btnPDF.UseVisualStyleBackColor = False
        '
        'btnCSV
        '
        Me.btnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnCSV.CornerRadius = 15
        Me.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCSV.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCSV.Location = New System.Drawing.Point(861, 662)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(153, 34)
        Me.btnCSV.TabIndex = 389
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.DateTimePicker2)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.DateTimePicker1)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Location = New System.Drawing.Point(281, 584)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(892, 59)
        Me.Panel4.TabIndex = 388
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker2.Location = New System.Drawing.Point(638, 19)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(236, 25)
        Me.DateTimePicker2.TabIndex = 398
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(522, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 22)
        Me.Label18.TabIndex = 398
        Me.Label18.Text = "Updated at:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker1.Location = New System.Drawing.Point(136, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(350, 25)
        Me.DateTimePicker1.TabIndex = 398
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(20, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 22)
        Me.Label19.TabIndex = 398
        Me.Label19.Text = "Created at:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.status)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.stockStatus)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.location)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Location = New System.Drawing.Point(281, 491)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(892, 104)
        Me.Panel3.TabIndex = 387
        '
        'status
        '
        Me.status.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.status.FormattingEnabled = True
        Me.status.Location = New System.Drawing.Point(116, 56)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(309, 30)
        Me.status.TabIndex = 397
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(29, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 22)
        Me.Label16.TabIndex = 396
        Me.Label16.Text = "Status:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(468, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 22)
        Me.Label15.TabIndex = 395
        Me.Label15.Text = "Stock Status : "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'location
        '
        Me.location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.location.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.location.Location = New System.Drawing.Point(116, 21)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(309, 25)
        Me.location.TabIndex = 386
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(29, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 22)
        Me.Label14.TabIndex = 394
        Me.Label14.Text = "Location :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.sourceOfFunds)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.totalCost)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.unitCost)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(281, 366)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(892, 128)
        Me.Panel2.TabIndex = 386
        '
        'sourceOfFunds
        '
        Me.sourceOfFunds.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.sourceOfFunds.FormattingEnabled = True
        Me.sourceOfFunds.Location = New System.Drawing.Point(153, 71)
        Me.sourceOfFunds.Name = "sourceOfFunds"
        Me.sourceOfFunds.Size = New System.Drawing.Size(272, 30)
        Me.sourceOfFunds.TabIndex = 386
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(29, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 22)
        Me.Label11.TabIndex = 391
        Me.Label11.Text = "Source of Funds:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'totalCost
        '
        Me.totalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totalCost.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.totalCost.Location = New System.Drawing.Point(554, 21)
        Me.totalCost.Name = "totalCost"
        Me.totalCost.Size = New System.Drawing.Size(307, 25)
        Me.totalCost.TabIndex = 390
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(465, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 22)
        Me.Label10.TabIndex = 389
        Me.Label10.Text = "Total Cost:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'unitCost
        '
        Me.unitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.unitCost.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.unitCost.Location = New System.Drawing.Point(153, 22)
        Me.unitCost.Name = "unitCost"
        Me.unitCost.Size = New System.Drawing.Size(272, 25)
        Me.unitCost.TabIndex = 388
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(29, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 22)
        Me.Label9.TabIndex = 386
        Me.Label9.Text = "Unit Cost:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dateReceived)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.quantity)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.unitOfMeasure)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.description)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.category)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.itemName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.supplyId)
        Me.Panel1.Controls.Add(Me.lblSupplyId)
        Me.Panel1.Location = New System.Drawing.Point(281, 136)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 231)
        Me.Panel1.TabIndex = 385
        '
        'dateReceived
        '
        Me.dateReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dateReceived.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.dateReceived.Location = New System.Drawing.Point(589, 182)
        Me.dateReceived.Name = "dateReceived"
        Me.dateReceived.Size = New System.Drawing.Size(272, 25)
        Me.dateReceived.TabIndex = 385
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(478, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 22)
        Me.Label7.TabIndex = 384
        Me.Label7.Text = "Date Received : "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'quantity
        '
        Me.quantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.quantity.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.quantity.Location = New System.Drawing.Point(153, 182)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(272, 25)
        Me.quantity.TabIndex = 383
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 22)
        Me.Label6.TabIndex = 382
        Me.Label6.Text = "Quantity : "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'unitOfMeasure
        '
        Me.unitOfMeasure.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.unitOfMeasure.FormattingEnabled = True
        Me.unitOfMeasure.Location = New System.Drawing.Point(554, 96)
        Me.unitOfMeasure.Name = "unitOfMeasure"
        Me.unitOfMeasure.Size = New System.Drawing.Size(307, 30)
        Me.unitOfMeasure.TabIndex = 381
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(478, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 22)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "Unit:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'description
        '
        Me.description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.description.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.description.Location = New System.Drawing.Point(116, 96)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(309, 67)
        Me.description.TabIndex = 379
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 22)
        Me.Label4.TabIndex = 378
        Me.Label4.Text = "Description:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'category
        '
        Me.category.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.category.FormattingEnabled = True
        Me.category.Location = New System.Drawing.Point(554, 53)
        Me.category.Name = "category"
        Me.category.Size = New System.Drawing.Size(307, 30)
        Me.category.TabIndex = 377
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(478, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 22)
        Me.Label3.TabIndex = 376
        Me.Label3.Text = "Category:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'itemName
        '
        Me.itemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.itemName.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.itemName.Location = New System.Drawing.Point(116, 54)
        Me.itemName.Name = "itemName"
        Me.itemName.Size = New System.Drawing.Size(309, 25)
        Me.itemName.TabIndex = 375
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 22)
        Me.Label1.TabIndex = 374
        Me.Label1.Text = "Item Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'supplyId
        '
        Me.supplyId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.supplyId.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.supplyId.Location = New System.Drawing.Point(648, 15)
        Me.supplyId.Name = "supplyId"
        Me.supplyId.Size = New System.Drawing.Size(213, 25)
        Me.supplyId.TabIndex = 373
        '
        'lblSupplyId
        '
        Me.lblSupplyId.AutoSize = True
        Me.lblSupplyId.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplyId.Location = New System.Drawing.Point(561, 17)
        Me.lblSupplyId.Name = "lblSupplyId"
        Me.lblSupplyId.Size = New System.Drawing.Size(75, 22)
        Me.lblSupplyId.TabIndex = 371
        Me.lblSupplyId.Text = "Supply ID : "
        Me.lblSupplyId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblPropertyCard)
        Me.Panel11.Location = New System.Drawing.Point(281, 80)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(892, 57)
        Me.Panel11.TabIndex = 384
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(337, 12)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(223, 44)
        Me.lblPropertyCard.TabIndex = 38
        Me.lblPropertyCard.Text = "SUPPLIES STOCK"
        '
        'stockStatus
        '
        Me.stockStatus.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold)
        Me.stockStatus.FormattingEnabled = True
        Me.stockStatus.Location = New System.Drawing.Point(589, 17)
        Me.stockStatus.Name = "stockStatus"
        Me.stockStatus.Size = New System.Drawing.Size(272, 30)
        Me.stockStatus.TabIndex = 386
        '
        'SuppliesStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1455, 876)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnPDF)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Name = "SuppliesStock"
        Me.Text = "Supplies Stock"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.totalCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.unitCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBack As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPDF As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents status As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend Shadows WithEvents location As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents sourceOfFunds As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents totalCost As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents unitCost As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dateReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents quantity As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents unitOfMeasure As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents description As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents category As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents itemName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents supplyId As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplyId As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents lblPropertyCard As System.Windows.Forms.Label
    Friend WithEvents stockStatus As System.Windows.Forms.ComboBox
End Class
