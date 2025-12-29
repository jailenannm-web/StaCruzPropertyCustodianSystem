Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddSupplyRequest
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.lblRequesterInfo = New System.Windows.Forms.Label()
        Me.lblRequesterName = New System.Windows.Forms.Label()
        Me.txtRequesterName = New System.Windows.Forms.TextBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblDateOfRequest = New System.Windows.Forms.Label()
        Me.dtpDateOfRequest = New System.Windows.Forms.DateTimePicker()
        Me.lblRequestDetails = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.pnlForm.SuspendLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.btnCancel)
        Me.pnlMain.Controls.Add(Me.btnSubmit)
        Me.pnlMain.Controls.Add(Me.pnlForm)
        Me.pnlMain.Controls.Add(Me.lblTitle)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlMain.Size = New System.Drawing.Size(1251, 889)
        Me.pnlMain.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(30, 30)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(330, 53)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Add Supply Request"
        '
        'pnlForm
        '
        Me.pnlForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlForm.AutoScroll = True
        Me.pnlForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlForm.Controls.Add(Me.txtPurpose)
        Me.pnlForm.Controls.Add(Me.lblPurpose)
        Me.pnlForm.Controls.Add(Me.cboUnit)
        Me.pnlForm.Controls.Add(Me.lblUnit)
        Me.pnlForm.Controls.Add(Me.numQuantity)
        Me.pnlForm.Controls.Add(Me.lblQuantity)
        Me.pnlForm.Controls.Add(Me.txtDescription)
        Me.pnlForm.Controls.Add(Me.lblDescription)
        Me.pnlForm.Controls.Add(Me.txtItemName)
        Me.pnlForm.Controls.Add(Me.lblItemName)
        Me.pnlForm.Controls.Add(Me.lblRequestDetails)
        Me.pnlForm.Controls.Add(Me.dtpDateOfRequest)
        Me.pnlForm.Controls.Add(Me.lblDateOfRequest)
        Me.pnlForm.Controls.Add(Me.cboDepartment)
        Me.pnlForm.Controls.Add(Me.lblDepartment)
        Me.pnlForm.Controls.Add(Me.txtPosition)
        Me.pnlForm.Controls.Add(Me.lblPosition)
        Me.pnlForm.Controls.Add(Me.txtRequesterName)
        Me.pnlForm.Controls.Add(Me.lblRequesterName)
        Me.pnlForm.Controls.Add(Me.lblRequesterInfo)
        Me.pnlForm.Location = New System.Drawing.Point(40, 100)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlForm.Size = New System.Drawing.Size(1171, 680)
        Me.pnlForm.TabIndex = 1
        '
        'lblRequesterInfo
        '
        Me.lblRequesterInfo.AutoSize = True
        Me.lblRequesterInfo.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequesterInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblRequesterInfo.Location = New System.Drawing.Point(30, 30)
        Me.lblRequesterInfo.Name = "lblRequesterInfo"
        Me.lblRequesterInfo.Size = New System.Drawing.Size(225, 36)
        Me.lblRequesterInfo.TabIndex = 0
        Me.lblRequesterInfo.Text = "Requester Information"
        '
        'lblRequesterName
        '
        Me.lblRequesterName.AutoSize = True
        Me.lblRequesterName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblRequesterName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblRequesterName.Location = New System.Drawing.Point(35, 80)
        Me.lblRequesterName.Name = "lblRequesterName"
        Me.lblRequesterName.Size = New System.Drawing.Size(141, 26)
        Me.lblRequesterName.TabIndex = 1
        Me.lblRequesterName.Text = "Requester Name *"
        '
        'txtRequesterName
        '
        Me.txtRequesterName.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtRequesterName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtRequesterName.Location = New System.Drawing.Point(40, 110)
        Me.txtRequesterName.Name = "txtRequesterName"
        Me.txtRequesterName.ReadOnly = True
        Me.txtRequesterName.Size = New System.Drawing.Size(500, 30)
        Me.txtRequesterName.TabIndex = 2
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblPosition.Location = New System.Drawing.Point(585, 80)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(72, 26)
        Me.lblPosition.TabIndex = 3
        Me.lblPosition.Text = "Position"
        '
        'txtPosition
        '
        Me.txtPosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtPosition.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtPosition.Location = New System.Drawing.Point(590, 110)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.ReadOnly = True
        Me.txtPosition.Size = New System.Drawing.Size(500, 30)
        Me.txtPosition.TabIndex = 4
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDepartment.Location = New System.Drawing.Point(35, 160)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(103, 26)
        Me.lblDepartment.TabIndex = 5
        Me.lblDepartment.Text = "Department"
        '
        'cboDepartment
        '
        Me.cboDepartment.BackColor = System.Drawing.Color.White
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Enabled = False
        Me.cboDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(40, 190)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(500, 34)
        Me.cboDepartment.TabIndex = 6
        '
        'lblDateOfRequest
        '
        Me.lblDateOfRequest.AutoSize = True
        Me.lblDateOfRequest.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDateOfRequest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDateOfRequest.Location = New System.Drawing.Point(585, 160)
        Me.lblDateOfRequest.Name = "lblDateOfRequest"
        Me.lblDateOfRequest.Size = New System.Drawing.Size(132, 26)
        Me.lblDateOfRequest.TabIndex = 7
        Me.lblDateOfRequest.Text = "Date of Request *"
        '
        'dtpDateOfRequest
        '
        Me.dtpDateOfRequest.CalendarFont = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpDateOfRequest.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpDateOfRequest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateOfRequest.Location = New System.Drawing.Point(590, 190)
        Me.dtpDateOfRequest.Name = "dtpDateOfRequest"
        Me.dtpDateOfRequest.Size = New System.Drawing.Size(500, 30)
        Me.dtpDateOfRequest.TabIndex = 8
        '
        'lblRequestDetails
        '
        Me.lblRequestDetails.AutoSize = True
        Me.lblRequestDetails.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblRequestDetails.Location = New System.Drawing.Point(30, 260)
        Me.lblRequestDetails.Name = "lblRequestDetails"
        Me.lblRequestDetails.Size = New System.Drawing.Size(161, 36)
        Me.lblRequestDetails.TabIndex = 9
        Me.lblRequestDetails.Text = "Request Details"
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblItemName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblItemName.Location = New System.Drawing.Point(35, 310)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(102, 26)
        Me.lblItemName.TabIndex = 10
        Me.lblItemName.Text = "Item Name *"
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtItemName.Location = New System.Drawing.Point(40, 340)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(1050, 30)
        Me.txtItemName.TabIndex = 11
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDescription.Location = New System.Drawing.Point(35, 390)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(99, 26)
        Me.lblDescription.TabIndex = 12
        Me.lblDescription.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtDescription.Location = New System.Drawing.Point(40, 420)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(1050, 80)
        Me.txtDescription.TabIndex = 13
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblQuantity.Location = New System.Drawing.Point(35, 520)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(162, 26)
        Me.lblQuantity.TabIndex = 14
        Me.lblQuantity.Text = "Quantity Requested *"
        '
        'numQuantity
        '
        Me.numQuantity.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.numQuantity.Location = New System.Drawing.Point(40, 550)
        Me.numQuantity.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(500, 30)
        Me.numQuantity.TabIndex = 15
        Me.numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblUnit.Location = New System.Drawing.Point(585, 520)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(119, 26)
        Me.lblUnit.TabIndex = 16
        Me.lblUnit.Text = "Unit of Measure"
        '
        'cboUnit
        '
        Me.cboUnit.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Piece", "Box", "Set", "Pack", "Unit", "Ream", "Bundle", "Dozen", "Liter", "Kilogram", "Meter", "Gallon", "Sack", "Bottle", "Others"})
        Me.cboUnit.Location = New System.Drawing.Point(590, 550)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(500, 34)
        Me.cboUnit.TabIndex = 17
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblPurpose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblPurpose.Location = New System.Drawing.Point(35, 600)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(82, 26)
        Me.lblPurpose.TabIndex = 18
        Me.lblPurpose.Text = "Purpose *"
        '
        'txtPurpose
        '
        Me.txtPurpose.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtPurpose.Location = New System.Drawing.Point(40, 630)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPurpose.Size = New System.Drawing.Size(1050, 100)
        Me.txtPurpose.TabIndex = 19
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(1051, 805)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(160, 45)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(871, 805)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(160, 45)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'AddSupplyRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "AddSupplyRequest"
        Me.Size = New System.Drawing.Size(1251, 889)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlForm As Panel
    Friend WithEvents lblRequesterInfo As Label
    Friend WithEvents lblRequesterName As Label
    Friend WithEvents txtRequesterName As TextBox
    Friend WithEvents lblPosition As Label
    Friend WithEvents txtPosition As TextBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents lblDateOfRequest As Label
    Friend WithEvents dtpDateOfRequest As DateTimePicker
    Friend WithEvents lblRequestDetails As Label
    Friend WithEvents lblItemName As Label
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents lblUnit As Label
    Friend WithEvents cboUnit As ComboBox
    Friend WithEvents lblPurpose As Label
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button
End Class
