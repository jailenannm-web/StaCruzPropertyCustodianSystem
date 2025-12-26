<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditPropertyManagement
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
        Me.lblPropertyID = New System.Windows.Forms.Label()
        Me.txtPropertyID = New System.Windows.Forms.TextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.lblUnitOfMeasure = New System.Windows.Forms.Label()
        Me.txtUnitOfMeasure = New System.Windows.Forms.TextBox()
        Me.lblAcquisitionCost = New System.Windows.Forms.Label()
        Me.txtAcquisitionCost = New System.Windows.Forms.NumericUpDown()
        Me.lblAcquisitionDate = New System.Windows.Forms.Label()
        Me.dtpAcquisitionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPropertyNumber = New System.Windows.Forms.Label()
        Me.txtPropertyNumber = New System.Windows.Forms.TextBox()
        Me.lblInternalCodes = New System.Windows.Forms.Label()
        Me.txtInternalCodes = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.txtTotalCost = New System.Windows.Forms.TextBox()
        Me.lblSourceOfFunds = New System.Windows.Forms.Label()
        Me.cboSourceOfFunds = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.txtAcquisitionCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Poppins", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(380, 47)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Edit Property Management"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.btnCancel)
        Me.pnlMain.Controls.Add(Me.btnSave)
        Me.pnlMain.Controls.Add(Me.cboSourceOfFunds)
        Me.pnlMain.Controls.Add(Me.lblSourceOfFunds)
        Me.pnlMain.Controls.Add(Me.txtTotalCost)
        Me.pnlMain.Controls.Add(Me.lblTotalCost)
        Me.pnlMain.Controls.Add(Me.cboStatus)
        Me.pnlMain.Controls.Add(Me.lblStatus)
        Me.pnlMain.Controls.Add(Me.txtLocation)
        Me.pnlMain.Controls.Add(Me.lblLocation)
        Me.pnlMain.Controls.Add(Me.cboDepartment)
        Me.pnlMain.Controls.Add(Me.lblDepartment)
        Me.pnlMain.Controls.Add(Me.txtInternalCodes)
        Me.pnlMain.Controls.Add(Me.lblInternalCodes)
        Me.pnlMain.Controls.Add(Me.txtPropertyNumber)
        Me.pnlMain.Controls.Add(Me.lblPropertyNumber)
        Me.pnlMain.Controls.Add(Me.dtpAcquisitionDate)
        Me.pnlMain.Controls.Add(Me.lblAcquisitionDate)
        Me.pnlMain.Controls.Add(Me.txtAcquisitionCost)
        Me.pnlMain.Controls.Add(Me.lblAcquisitionCost)
        Me.pnlMain.Controls.Add(Me.txtUnitOfMeasure)
        Me.pnlMain.Controls.Add(Me.lblUnitOfMeasure)
        Me.pnlMain.Controls.Add(Me.cboCondition)
        Me.pnlMain.Controls.Add(Me.lblCondition)
        Me.pnlMain.Controls.Add(Me.txtDescription)
        Me.pnlMain.Controls.Add(Me.lblDescription)
        Me.pnlMain.Controls.Add(Me.txtSerialNumber)
        Me.pnlMain.Controls.Add(Me.lblSerialNumber)
        Me.pnlMain.Controls.Add(Me.cboCategory)
        Me.pnlMain.Controls.Add(Me.lblCategory)
        Me.pnlMain.Controls.Add(Me.txtItemName)
        Me.pnlMain.Controls.Add(Me.lblItemName)
        Me.pnlMain.Controls.Add(Me.txtPropertyID)
        Me.pnlMain.Controls.Add(Me.lblPropertyID)
        Me.pnlMain.Location = New System.Drawing.Point(20, 80)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1240, 620)
        Me.pnlMain.TabIndex = 1
        '
        'lblPropertyID
        '
        Me.lblPropertyID.AutoSize = True
        Me.lblPropertyID.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblPropertyID.Location = New System.Drawing.Point(30, 30)
        Me.lblPropertyID.Name = "lblPropertyID"
        Me.lblPropertyID.Size = New System.Drawing.Size(94, 26)
        Me.lblPropertyID.TabIndex = 0
        Me.lblPropertyID.Text = "Property ID"
        '
        'txtPropertyID
        '
        Me.txtPropertyID.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtPropertyID.Location = New System.Drawing.Point(180, 27)
        Me.txtPropertyID.Name = "txtPropertyID"
        Me.txtPropertyID.ReadOnly = True
        Me.txtPropertyID.Size = New System.Drawing.Size(450, 30)
        Me.txtPropertyID.TabIndex = 1
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblItemName.Location = New System.Drawing.Point(30, 70)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(95, 26)
        Me.lblItemName.TabIndex = 2
        Me.lblItemName.Text = "Item Name"
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtItemName.Location = New System.Drawing.Point(180, 67)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(450, 30)
        Me.txtItemName.TabIndex = 3
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblCategory.Location = New System.Drawing.Point(30, 110)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(82, 26)
        Me.lblCategory.TabIndex = 4
        Me.lblCategory.Text = "Category"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(180, 107)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(450, 34)
        Me.cboCategory.TabIndex = 5
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblSerialNumber.Location = New System.Drawing.Point(30, 155)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(119, 26)
        Me.lblSerialNumber.TabIndex = 6
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtSerialNumber.Location = New System.Drawing.Point(180, 152)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(450, 30)
        Me.txtSerialNumber.TabIndex = 7
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDescription.Location = New System.Drawing.Point(30, 200)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(95, 26)
        Me.lblDescription.TabIndex = 8
        Me.lblDescription.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtDescription.Location = New System.Drawing.Point(180, 197)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(450, 60)
        Me.txtDescription.TabIndex = 9
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblCondition.Location = New System.Drawing.Point(30, 275)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(138, 26)
        Me.lblCondition.TabIndex = 10
        Me.lblCondition.Text = "Condition Status"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Location = New System.Drawing.Point(180, 272)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(450, 34)
        Me.cboCondition.TabIndex = 11
        '
        'lblUnitOfMeasure
        '
        Me.lblUnitOfMeasure.AutoSize = True
        Me.lblUnitOfMeasure.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblUnitOfMeasure.Location = New System.Drawing.Point(30, 320)
        Me.lblUnitOfMeasure.Name = "lblUnitOfMeasure"
        Me.lblUnitOfMeasure.Size = New System.Drawing.Size(134, 26)
        Me.lblUnitOfMeasure.TabIndex = 12
        Me.lblUnitOfMeasure.Text = "Unit of Measure"
        '
        'txtUnitOfMeasure
        '
        Me.txtUnitOfMeasure.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtUnitOfMeasure.Location = New System.Drawing.Point(180, 317)
        Me.txtUnitOfMeasure.Name = "txtUnitOfMeasure"
        Me.txtUnitOfMeasure.Size = New System.Drawing.Size(450, 30)
        Me.txtUnitOfMeasure.TabIndex = 13
        '
        'lblAcquisitionCost
        '
        Me.lblAcquisitionCost.AutoSize = True
        Me.lblAcquisitionCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblAcquisitionCost.Location = New System.Drawing.Point(30, 365)
        Me.lblAcquisitionCost.Name = "lblAcquisitionCost"
        Me.lblAcquisitionCost.Size = New System.Drawing.Size(133, 26)
        Me.lblAcquisitionCost.TabIndex = 14
        Me.lblAcquisitionCost.Text = "Acquisition Cost"
        '
        'txtAcquisitionCost
        '
        Me.txtAcquisitionCost.DecimalPlaces = 2
        Me.txtAcquisitionCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtAcquisitionCost.Location = New System.Drawing.Point(180, 362)
        Me.txtAcquisitionCost.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.txtAcquisitionCost.Name = "txtAcquisitionCost"
        Me.txtAcquisitionCost.Size = New System.Drawing.Size(450, 30)
        Me.txtAcquisitionCost.TabIndex = 15
        '
        'lblAcquisitionDate
        '
        Me.lblAcquisitionDate.AutoSize = True
        Me.lblAcquisitionDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblAcquisitionDate.Location = New System.Drawing.Point(30, 410)
        Me.lblAcquisitionDate.Name = "lblAcquisitionDate"
        Me.lblAcquisitionDate.Size = New System.Drawing.Size(135, 26)
        Me.lblAcquisitionDate.TabIndex = 16
        Me.lblAcquisitionDate.Text = "Acquisition Date"
        '
        'dtpAcquisitionDate
        '
        Me.dtpAcquisitionDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpAcquisitionDate.Location = New System.Drawing.Point(180, 407)
        Me.dtpAcquisitionDate.Name = "dtpAcquisitionDate"
        Me.dtpAcquisitionDate.Size = New System.Drawing.Size(450, 30)
        Me.dtpAcquisitionDate.TabIndex = 17
        '
        'lblPropertyNumber
        '
        Me.lblPropertyNumber.AutoSize = True
        Me.lblPropertyNumber.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblPropertyNumber.Location = New System.Drawing.Point(680, 30)
        Me.lblPropertyNumber.Name = "lblPropertyNumber"
        Me.lblPropertyNumber.Size = New System.Drawing.Size(175, 26)
        Me.lblPropertyNumber.TabIndex = 18
        Me.lblPropertyNumber.Text = "Property Number 🔒"
        '
        'txtPropertyNumber
        '
        Me.txtPropertyNumber.BackColor = System.Drawing.SystemColors.Control
        Me.txtPropertyNumber.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtPropertyNumber.Location = New System.Drawing.Point(870, 27)
        Me.txtPropertyNumber.Name = "txtPropertyNumber"
        Me.txtPropertyNumber.ReadOnly = True
        Me.txtPropertyNumber.Size = New System.Drawing.Size(340, 30)
        Me.txtPropertyNumber.TabIndex = 19
        '
        'lblInternalCodes
        '
        Me.lblInternalCodes.AutoSize = True
        Me.lblInternalCodes.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblInternalCodes.Location = New System.Drawing.Point(680, 70)
        Me.lblInternalCodes.Name = "lblInternalCodes"
        Me.lblInternalCodes.Size = New System.Drawing.Size(148, 26)
        Me.lblInternalCodes.TabIndex = 20
        Me.lblInternalCodes.Text = "Internal Code 🔒"
        '
        'txtInternalCodes
        '
        Me.txtInternalCodes.BackColor = System.Drawing.SystemColors.Control
        Me.txtInternalCodes.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtInternalCodes.Location = New System.Drawing.Point(870, 67)
        Me.txtInternalCodes.Name = "txtInternalCodes"
        Me.txtInternalCodes.ReadOnly = True
        Me.txtInternalCodes.Size = New System.Drawing.Size(340, 30)
        Me.txtInternalCodes.TabIndex = 21
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(680, 110)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(103, 26)
        Me.lblDepartment.TabIndex = 22
        Me.lblDepartment.Text = "Department"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(870, 107)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(340, 34)
        Me.cboDepartment.TabIndex = 23
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblLocation.Location = New System.Drawing.Point(680, 155)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(76, 26)
        Me.lblLocation.TabIndex = 24
        Me.lblLocation.Text = "Location"
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtLocation.Location = New System.Drawing.Point(870, 152)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(340, 30)
        Me.txtLocation.TabIndex = 25
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblStatus.Location = New System.Drawing.Point(680, 200)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(59, 26)
        Me.lblStatus.TabIndex = 26
        Me.lblStatus.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(870, 197)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(340, 34)
        Me.cboStatus.TabIndex = 27
        '
        'lblTotalCost
        '
        Me.lblTotalCost.AutoSize = True
        Me.lblTotalCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblTotalCost.Location = New System.Drawing.Point(680, 245)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(113, 26)
        Me.lblTotalCost.TabIndex = 28
        Me.lblTotalCost.Text = "Total Cost 🔒"
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtTotalCost.Location = New System.Drawing.Point(870, 242)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.ReadOnly = True
        Me.txtTotalCost.Size = New System.Drawing.Size(340, 30)
        Me.txtTotalCost.TabIndex = 29
        '
        'lblSourceOfFunds
        '
        Me.lblSourceOfFunds.AutoSize = True
        Me.lblSourceOfFunds.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblSourceOfFunds.Location = New System.Drawing.Point(680, 290)
        Me.lblSourceOfFunds.Name = "lblSourceOfFunds"
        Me.lblSourceOfFunds.Size = New System.Drawing.Size(136, 26)
        Me.lblSourceOfFunds.TabIndex = 30
        Me.lblSourceOfFunds.Text = "Source of Funds"
        '
        'cboSourceOfFunds
        '
        Me.cboSourceOfFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSourceOfFunds.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboSourceOfFunds.FormattingEnabled = True
        Me.cboSourceOfFunds.Location = New System.Drawing.Point(870, 287)
        Me.cboSourceOfFunds.Name = "cboSourceOfFunds"
        Me.cboSourceOfFunds.Size = New System.Drawing.Size(340, 34)
        Me.cboSourceOfFunds.TabIndex = 31
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
        Me.btnSave.TabIndex = 33
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
        Me.btnCancel.TabIndex = 32
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'EditPropertyManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "EditPropertyManagement"
        Me.Size = New System.Drawing.Size(1280, 720)
        CType(Me.txtAcquisitionCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lblPropertyID As System.Windows.Forms.Label
    Friend WithEvents txtPropertyID As System.Windows.Forms.TextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblCondition As System.Windows.Forms.Label
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnitOfMeasure As System.Windows.Forms.Label
    Friend WithEvents txtUnitOfMeasure As System.Windows.Forms.TextBox
    Friend WithEvents lblAcquisitionCost As System.Windows.Forms.Label
    Friend WithEvents txtAcquisitionCost As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAcquisitionDate As System.Windows.Forms.Label
    Friend WithEvents dtpAcquisitionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPropertyNumber As System.Windows.Forms.Label
    Friend WithEvents txtPropertyNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblInternalCodes As System.Windows.Forms.Label
    Friend WithEvents txtInternalCodes As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents lblSourceOfFunds As System.Windows.Forms.Label
    Friend WithEvents cboSourceOfFunds As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
