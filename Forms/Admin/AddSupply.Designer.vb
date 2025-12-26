<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddSupply
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblUnitOfMeasure = New System.Windows.Forms.Label()
        Me.txtUnitOfMeasure = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblDateReceived = New System.Windows.Forms.Label()
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.numUnitCost = New System.Windows.Forms.NumericUpDown()
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.txtTotalCost = New System.Windows.Forms.TextBox()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.lblSourceOfFunds = New System.Windows.Forms.Label()
        Me.cboSourceOfFunds = New System.Windows.Forms.ComboBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblStockStatus = New System.Windows.Forms.Label()
        Me.cboStockStatus = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUnitCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Poppins", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(180, 47)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Add Supply"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.btnCancel)
        Me.pnlMain.Controls.Add(Me.btnSave)
        Me.pnlMain.Controls.Add(Me.cboStockStatus)
        Me.pnlMain.Controls.Add(Me.lblStockStatus)
        Me.pnlMain.Controls.Add(Me.txtLocation)
        Me.pnlMain.Controls.Add(Me.lblLocation)
        Me.pnlMain.Controls.Add(Me.cboDepartment)
        Me.pnlMain.Controls.Add(Me.lblDepartment)
        Me.pnlMain.Controls.Add(Me.cboSourceOfFunds)
        Me.pnlMain.Controls.Add(Me.lblSourceOfFunds)
        Me.pnlMain.Controls.Add(Me.txtSupplier)
        Me.pnlMain.Controls.Add(Me.lblSupplier)
        Me.pnlMain.Controls.Add(Me.txtTotalCost)
        Me.pnlMain.Controls.Add(Me.lblTotalCost)
        Me.pnlMain.Controls.Add(Me.numUnitCost)
        Me.pnlMain.Controls.Add(Me.lblUnitCost)
        Me.pnlMain.Controls.Add(Me.dtpDateReceived)
        Me.pnlMain.Controls.Add(Me.lblDateReceived)
        Me.pnlMain.Controls.Add(Me.numQuantity)
        Me.pnlMain.Controls.Add(Me.lblQuantity)
        Me.pnlMain.Controls.Add(Me.txtUnitOfMeasure)
        Me.pnlMain.Controls.Add(Me.lblUnitOfMeasure)
        Me.pnlMain.Controls.Add(Me.txtDescription)
        Me.pnlMain.Controls.Add(Me.lblDescription)
        Me.pnlMain.Controls.Add(Me.cboCategory)
        Me.pnlMain.Controls.Add(Me.lblCategory)
        Me.pnlMain.Controls.Add(Me.txtItemName)
        Me.pnlMain.Controls.Add(Me.lblItemName)
        Me.pnlMain.Location = New System.Drawing.Point(20, 80)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1240, 620)
        Me.pnlMain.TabIndex = 1
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblItemName.Location = New System.Drawing.Point(30, 30)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(95, 26)
        Me.lblItemName.TabIndex = 0
        Me.lblItemName.Text = "Item Name"
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtItemName.Location = New System.Drawing.Point(180, 27)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(450, 30)
        Me.txtItemName.TabIndex = 1
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblCategory.Location = New System.Drawing.Point(30, 70)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(82, 26)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(180, 67)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(450, 34)
        Me.cboCategory.TabIndex = 3
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDescription.Location = New System.Drawing.Point(30, 115)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(95, 26)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtDescription.Location = New System.Drawing.Point(180, 112)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(450, 60)
        Me.txtDescription.TabIndex = 5
        '
        'lblUnitOfMeasure
        '
        Me.lblUnitOfMeasure.AutoSize = True
        Me.lblUnitOfMeasure.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblUnitOfMeasure.Location = New System.Drawing.Point(30, 190)
        Me.lblUnitOfMeasure.Name = "lblUnitOfMeasure"
        Me.lblUnitOfMeasure.Size = New System.Drawing.Size(134, 26)
        Me.lblUnitOfMeasure.TabIndex = 6
        Me.lblUnitOfMeasure.Text = "Unit of Measure"
        '
        'txtUnitOfMeasure
        '
        Me.txtUnitOfMeasure.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtUnitOfMeasure.Location = New System.Drawing.Point(180, 187)
        Me.txtUnitOfMeasure.Name = "txtUnitOfMeasure"
        Me.txtUnitOfMeasure.Size = New System.Drawing.Size(450, 30)
        Me.txtUnitOfMeasure.TabIndex = 7
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblQuantity.Location = New System.Drawing.Point(30, 235)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(79, 26)
        Me.lblQuantity.TabIndex = 8
        Me.lblQuantity.Text = "Quantity"
        '
        'numQuantity
        '
        Me.numQuantity.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.numQuantity.Location = New System.Drawing.Point(180, 232)
        Me.numQuantity.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(450, 30)
        Me.numQuantity.TabIndex = 9
        '
        'lblDateReceived
        '
        Me.lblDateReceived.AutoSize = True
        Me.lblDateReceived.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDateReceived.Location = New System.Drawing.Point(30, 280)
        Me.lblDateReceived.Name = "lblDateReceived"
        Me.lblDateReceived.Size = New System.Drawing.Size(121, 26)
        Me.lblDateReceived.TabIndex = 10
        Me.lblDateReceived.Text = "Date Received"
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpDateReceived.Location = New System.Drawing.Point(180, 277)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(450, 30)
        Me.dtpDateReceived.TabIndex = 11
        '
        'lblUnitCost
        '
        Me.lblUnitCost.AutoSize = True
        Me.lblUnitCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblUnitCost.Location = New System.Drawing.Point(30, 325)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(82, 26)
        Me.lblUnitCost.TabIndex = 12
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'numUnitCost
        '
        Me.numUnitCost.DecimalPlaces = 2
        Me.numUnitCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.numUnitCost.Location = New System.Drawing.Point(180, 322)
        Me.numUnitCost.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numUnitCost.Name = "numUnitCost"
        Me.numUnitCost.Size = New System.Drawing.Size(450, 30)
        Me.numUnitCost.TabIndex = 13
        '
        'lblTotalCost
        '
        Me.lblTotalCost.AutoSize = True
        Me.lblTotalCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblTotalCost.Location = New System.Drawing.Point(30, 370)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(133, 26)
        Me.lblTotalCost.TabIndex = 14
        Me.lblTotalCost.Text = "Total Cost (Auto)"
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtTotalCost.Location = New System.Drawing.Point(180, 367)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.ReadOnly = True
        Me.txtTotalCost.Size = New System.Drawing.Size(450, 30)
        Me.txtTotalCost.TabIndex = 15
        Me.txtTotalCost.Text = "0.00"
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblSupplier.Location = New System.Drawing.Point(680, 30)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(71, 26)
        Me.lblSupplier.TabIndex = 16
        Me.lblSupplier.Text = "Supplier"
        '
        'txtSupplier
        '
        Me.txtSupplier.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtSupplier.Location = New System.Drawing.Point(830, 27)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(380, 30)
        Me.txtSupplier.TabIndex = 17
        '
        'lblSourceOfFunds
        '
        Me.lblSourceOfFunds.AutoSize = True
        Me.lblSourceOfFunds.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblSourceOfFunds.Location = New System.Drawing.Point(680, 70)
        Me.lblSourceOfFunds.Name = "lblSourceOfFunds"
        Me.lblSourceOfFunds.Size = New System.Drawing.Size(136, 26)
        Me.lblSourceOfFunds.TabIndex = 18
        Me.lblSourceOfFunds.Text = "Source of Funds"
        '
        'cboSourceOfFunds
        '
        Me.cboSourceOfFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSourceOfFunds.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboSourceOfFunds.FormattingEnabled = True
        Me.cboSourceOfFunds.Location = New System.Drawing.Point(830, 67)
        Me.cboSourceOfFunds.Name = "cboSourceOfFunds"
        Me.cboSourceOfFunds.Size = New System.Drawing.Size(380, 34)
        Me.cboSourceOfFunds.TabIndex = 19
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(680, 115)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(103, 26)
        Me.lblDepartment.TabIndex = 20
        Me.lblDepartment.Text = "Department"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(830, 112)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(380, 34)
        Me.cboDepartment.TabIndex = 21
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblLocation.Location = New System.Drawing.Point(680, 160)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(118, 26)
        Me.lblLocation.TabIndex = 22
        Me.lblLocation.Text = "Location (Auto)"
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.SystemColors.Control
        Me.txtLocation.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtLocation.Location = New System.Drawing.Point(830, 157)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(380, 30)
        Me.txtLocation.TabIndex = 23
        '
        'lblStockStatus
        '
        Me.lblStockStatus.AutoSize = True
        Me.lblStockStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblStockStatus.Location = New System.Drawing.Point(680, 205)
        Me.lblStockStatus.Name = "lblStockStatus"
        Me.lblStockStatus.Size = New System.Drawing.Size(107, 26)
        Me.lblStockStatus.TabIndex = 24
        Me.lblStockStatus.Text = "Stock Status"
        '
        'cboStockStatus
        '
        Me.cboStockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStockStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboStockStatus.FormattingEnabled = True
        Me.cboStockStatus.Location = New System.Drawing.Point(830, 202)
        Me.cboStockStatus.Name = "cboStockStatus"
        Me.cboStockStatus.Size = New System.Drawing.Size(380, 34)
        Me.cboStockStatus.TabIndex = 25
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(1050, 550)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(160, 45)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(870, 550)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(160, 45)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'AddSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "AddSupply"
        Me.Size = New System.Drawing.Size(1280, 720)
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUnitCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitOfMeasure As System.Windows.Forms.Label
    Friend WithEvents txtUnitOfMeasure As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents numQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDateReceived As System.Windows.Forms.Label
    Friend WithEvents dtpDateReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents numUnitCost As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents lblSourceOfFunds As System.Windows.Forms.Label
    Friend WithEvents cboSourceOfFunds As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblStockStatus As System.Windows.Forms.Label
    Friend WithEvents cboStockStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
