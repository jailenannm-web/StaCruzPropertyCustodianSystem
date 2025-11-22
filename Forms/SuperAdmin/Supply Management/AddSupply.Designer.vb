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
        Me.txb_Status = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txb_UnitCost = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txb_SupplierID = New System.Windows.Forms.TextBox()
        Me.txb_SupplyID = New System.Windows.Forms.TextBox()
        Me.txb_CustodianID = New System.Windows.Forms.TextBox()
        Me.txb_SupplyName = New System.Windows.Forms.TextBox()
        Me.txb_AcquisitionDate = New System.Windows.Forms.TextBox()
        Me.txb_Category = New System.Windows.Forms.TextBox()
        Me.txb_TotalValue = New System.Windows.Forms.TextBox()
        Me.txb_Description = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txb_ReorderLevel = New System.Windows.Forms.TextBox()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txb_UnitOfMeasure = New System.Windows.Forms.TextBox()
        Me.txb_Location = New System.Windows.Forms.TextBox()
        Me.txb_ExpirationDate = New System.Windows.Forms.TextBox()
        Me.txb_QuantityInStock = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txb_Status
        '
        Me.txb_Status.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Status.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Status.Location = New System.Drawing.Point(1364, 759)
        Me.txb_Status.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Status.Multiline = True
        Me.txb_Status.Name = "txb_Status"
        Me.txb_Status.Size = New System.Drawing.Size(449, 42)
        Me.txb_Status.TabIndex = 106
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 34.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(724, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(629, 101)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Add Supply"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(96, 164)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(283, 42)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Supply I.D"
        '
        'txb_UnitCost
        '
        Me.txb_UnitCost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_UnitCost.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UnitCost.Location = New System.Drawing.Point(1364, 162)
        Me.txb_UnitCost.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_UnitCost.Multiline = True
        Me.txb_UnitCost.Name = "txb_UnitCost"
        Me.txb_UnitCost.Size = New System.Drawing.Size(449, 42)
        Me.txb_UnitCost.TabIndex = 108
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(96, 566)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(283, 42)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Unit Of Measure"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(1061, 162)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(291, 42)
        Me.Label16.TabIndex = 107
        Me.Label16.Text = "Unit Cost"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(96, 359)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(245, 42)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Category"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(96, 759)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(260, 42)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Reorder Level "
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1061, 759)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(181, 42)
        Me.Label11.TabIndex = 105
        Me.Label11.Text = "Status"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(96, 848)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(283, 42)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Supplier I.D"
        '
        'txb_SupplierID
        '
        Me.txb_SupplierID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_SupplierID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_SupplierID.Location = New System.Drawing.Point(387, 848)
        Me.txb_SupplierID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_SupplierID.Multiline = True
        Me.txb_SupplierID.Name = "txb_SupplierID"
        Me.txb_SupplierID.Size = New System.Drawing.Size(461, 42)
        Me.txb_SupplierID.TabIndex = 104
        '
        'txb_SupplyID
        '
        Me.txb_SupplyID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_SupplyID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_SupplyID.Location = New System.Drawing.Point(387, 164)
        Me.txb_SupplyID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_SupplyID.Multiline = True
        Me.txb_SupplyID.Name = "txb_SupplyID"
        Me.txb_SupplyID.Size = New System.Drawing.Size(461, 42)
        Me.txb_SupplyID.TabIndex = 86
        '
        'txb_CustodianID
        '
        Me.txb_CustodianID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_CustodianID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_CustodianID.Location = New System.Drawing.Point(1364, 656)
        Me.txb_CustodianID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_CustodianID.Multiline = True
        Me.txb_CustodianID.Name = "txb_CustodianID"
        Me.txb_CustodianID.Size = New System.Drawing.Size(449, 42)
        Me.txb_CustodianID.TabIndex = 103
        '
        'txb_SupplyName
        '
        Me.txb_SupplyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_SupplyName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_SupplyName.Location = New System.Drawing.Point(387, 254)
        Me.txb_SupplyName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_SupplyName.Multiline = True
        Me.txb_SupplyName.Name = "txb_SupplyName"
        Me.txb_SupplyName.Size = New System.Drawing.Size(461, 42)
        Me.txb_SupplyName.TabIndex = 87
        '
        'txb_AcquisitionDate
        '
        Me.txb_AcquisitionDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_AcquisitionDate.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_AcquisitionDate.Location = New System.Drawing.Point(1364, 346)
        Me.txb_AcquisitionDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_AcquisitionDate.Multiline = True
        Me.txb_AcquisitionDate.Name = "txb_AcquisitionDate"
        Me.txb_AcquisitionDate.Size = New System.Drawing.Size(449, 42)
        Me.txb_AcquisitionDate.TabIndex = 102
        '
        'txb_Category
        '
        Me.txb_Category.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Category.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Category.Location = New System.Drawing.Point(387, 359)
        Me.txb_Category.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Category.Multiline = True
        Me.txb_Category.Name = "txb_Category"
        Me.txb_Category.Size = New System.Drawing.Size(461, 42)
        Me.txb_Category.TabIndex = 88
        '
        'txb_TotalValue
        '
        Me.txb_TotalValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_TotalValue.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_TotalValue.Location = New System.Drawing.Point(1364, 246)
        Me.txb_TotalValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_TotalValue.Multiline = True
        Me.txb_TotalValue.Name = "txb_TotalValue"
        Me.txb_TotalValue.Size = New System.Drawing.Size(449, 42)
        Me.txb_TotalValue.TabIndex = 101
        '
        'txb_Description
        '
        Me.txb_Description.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Description.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Description.Location = New System.Drawing.Point(387, 465)
        Me.txb_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Description.Multiline = True
        Me.txb_Description.Name = "txb_Description"
        Me.txb_Description.Size = New System.Drawing.Size(461, 42)
        Me.txb_Description.TabIndex = 89
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(1061, 447)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(276, 42)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Expiration Date"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(96, 254)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(260, 42)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Supply Name"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1061, 346)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(292, 42)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Acquisition Date"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(96, 465)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(224, 42)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Description"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1061, 656)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(292, 42)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "Custodian I.D"
        '
        'txb_ReorderLevel
        '
        Me.txb_ReorderLevel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ReorderLevel.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ReorderLevel.Location = New System.Drawing.Point(387, 759)
        Me.txb_ReorderLevel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ReorderLevel.Multiline = True
        Me.txb_ReorderLevel.Name = "txb_ReorderLevel"
        Me.txb_ReorderLevel.Size = New System.Drawing.Size(461, 42)
        Me.txb_ReorderLevel.TabIndex = 92
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
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(1061, 556)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(181, 42)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Location"
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
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(1061, 249)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(252, 42)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "Total Value"
        '
        'txb_UnitOfMeasure
        '
        Me.txb_UnitOfMeasure.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_UnitOfMeasure.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UnitOfMeasure.Location = New System.Drawing.Point(387, 566)
        Me.txb_UnitOfMeasure.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_UnitOfMeasure.Multiline = True
        Me.txb_UnitOfMeasure.Name = "txb_UnitOfMeasure"
        Me.txb_UnitOfMeasure.Size = New System.Drawing.Size(461, 42)
        Me.txb_UnitOfMeasure.TabIndex = 113
        '
        'txb_Location
        '
        Me.txb_Location.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Location.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Location.Location = New System.Drawing.Point(1364, 556)
        Me.txb_Location.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Location.Multiline = True
        Me.txb_Location.Name = "txb_Location"
        Me.txb_Location.Size = New System.Drawing.Size(449, 42)
        Me.txb_Location.TabIndex = 114
        '
        'txb_ExpirationDate
        '
        Me.txb_ExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ExpirationDate.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ExpirationDate.Location = New System.Drawing.Point(1364, 447)
        Me.txb_ExpirationDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ExpirationDate.Multiline = True
        Me.txb_ExpirationDate.Name = "txb_ExpirationDate"
        Me.txb_ExpirationDate.Size = New System.Drawing.Size(449, 42)
        Me.txb_ExpirationDate.TabIndex = 115
        '
        'txb_QuantityInStock
        '
        Me.txb_QuantityInStock.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_QuantityInStock.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_QuantityInStock.Location = New System.Drawing.Point(387, 661)
        Me.txb_QuantityInStock.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_QuantityInStock.Multiline = True
        Me.txb_QuantityInStock.Name = "txb_QuantityInStock"
        Me.txb_QuantityInStock.Size = New System.Drawing.Size(461, 42)
        Me.txb_QuantityInStock.TabIndex = 117
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(96, 661)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(296, 42)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "Quantity In Stock"
        '
        'AddSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources._Presentation1
        Me.ClientSize = New System.Drawing.Size(1924, 1115)
        Me.Controls.Add(Me.txb_QuantityInStock)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txb_ExpirationDate)
        Me.Controls.Add(Me.txb_Location)
        Me.Controls.Add(Me.txb_UnitOfMeasure)
        Me.Controls.Add(Me.txb_Status)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txb_UnitCost)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txb_SupplierID)
        Me.Controls.Add(Me.txb_SupplyID)
        Me.Controls.Add(Me.txb_CustodianID)
        Me.Controls.Add(Me.txb_SupplyName)
        Me.Controls.Add(Me.txb_AcquisitionDate)
        Me.Controls.Add(Me.txb_Category)
        Me.Controls.Add(Me.txb_TotalValue)
        Me.Controls.Add(Me.txb_Description)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txb_ReorderLevel)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.Label15)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AddSupply"
        Me.Text = "AddSupply"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txb_Status As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txb_UnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txb_SupplierID As System.Windows.Forms.TextBox
    Friend WithEvents txb_SupplyID As System.Windows.Forms.TextBox
    Friend WithEvents txb_CustodianID As System.Windows.Forms.TextBox
    Friend WithEvents txb_SupplyName As System.Windows.Forms.TextBox
    Friend WithEvents txb_AcquisitionDate As System.Windows.Forms.TextBox
    Friend WithEvents txb_Category As System.Windows.Forms.TextBox
    Friend WithEvents txb_TotalValue As System.Windows.Forms.TextBox
    Friend WithEvents txb_Description As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txb_ReorderLevel As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btn_Login As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txb_UnitOfMeasure As System.Windows.Forms.TextBox
    Friend WithEvents txb_Location As System.Windows.Forms.TextBox
    Friend WithEvents txb_ExpirationDate As System.Windows.Forms.TextBox
    Friend WithEvents txb_QuantityInStock As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
