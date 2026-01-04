<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MaintenanceRequestForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.grpItemDetails = New System.Windows.Forms.GroupBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.cboItemName = New System.Windows.Forms.ComboBox()
        Me.lblPropertyNumber = New System.Windows.Forms.Label()
        Me.txtPropertyNumber = New System.Windows.Forms.TextBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.grpRequestDetails = New System.Windows.Forms.GroupBox()
        Me.lblDateRequested = New System.Windows.Forms.Label()
        Me.dtpDateRequested = New System.Windows.Forms.DateTimePicker()
        Me.lblConditionBefore = New System.Windows.Forms.Label()
        Me.cboConditionBefore = New System.Windows.Forms.ComboBox()
        Me.lblTypeOfIssue = New System.Windows.Forms.Label()
        Me.cboTypeOfIssue = New System.Windows.Forms.ComboBox()
        Me.lblTargetDate = New System.Windows.Forms.Label()
        Me.dtpTargetDate = New System.Windows.Forms.DateTimePicker()
        Me.lblProblemDescription = New System.Windows.Forms.Label()
        Me.txtProblemDescription = New System.Windows.Forms.TextBox()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.lblRequestedBy = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.grpItemDetails.SuspendLayout()
        Me.grpRequestDetails.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlHeader.Size = New System.Drawing.Size(1200, 120)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(30, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(338, 37)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "🔧 Maintenance Request"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(30, 65)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(524, 19)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Submit a maintenance request for repair, replacement, or servicing of property it" &
    "ems"
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.grpItemDetails)
        Me.pnlMain.Controls.Add(Me.grpRequestDetails)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 120)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlMain.Size = New System.Drawing.Size(1200, 580)
        Me.pnlMain.TabIndex = 1
        '
        'grpItemDetails
        '
        Me.grpItemDetails.Controls.Add(Me.lblItemName)
        Me.grpItemDetails.Controls.Add(Me.cboItemName)
        Me.grpItemDetails.Controls.Add(Me.lblPropertyNumber)
        Me.grpItemDetails.Controls.Add(Me.txtPropertyNumber)
        Me.grpItemDetails.Controls.Add(Me.lblSerialNumber)
        Me.grpItemDetails.Controls.Add(Me.txtSerialNumber)
        Me.grpItemDetails.Controls.Add(Me.lblDepartment)
        Me.grpItemDetails.Controls.Add(Me.cboDepartment)
        Me.grpItemDetails.Controls.Add(Me.lblLocation)
        Me.grpItemDetails.Controls.Add(Me.txtLocation)
        Me.grpItemDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpItemDetails.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpItemDetails.Location = New System.Drawing.Point(30, 400)
        Me.grpItemDetails.Name = "grpItemDetails"
        Me.grpItemDetails.Padding = New System.Windows.Forms.Padding(20, 20, 20, 20)
        Me.grpItemDetails.Size = New System.Drawing.Size(1123, 280)
        Me.grpItemDetails.TabIndex = 0
        Me.grpItemDetails.TabStop = False
        Me.grpItemDetails.Text = "Item/Property Details"
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblItemName.Location = New System.Drawing.Point(23, 40)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(146, 19)
        Me.lblItemName.TabIndex = 0
        Me.lblItemName.Text = "Item Name / Property:"
        '
        'cboItemName
        '
        Me.cboItemName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboItemName.FormattingEnabled = True
        Me.cboItemName.Location = New System.Drawing.Point(27, 65)
        Me.cboItemName.Name = "cboItemName"
        Me.cboItemName.Size = New System.Drawing.Size(520, 25)
        Me.cboItemName.TabIndex = 1
        '
        'lblPropertyNumber
        '
        Me.lblPropertyNumber.AutoSize = True
        Me.lblPropertyNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPropertyNumber.Location = New System.Drawing.Point(570, 40)
        Me.lblPropertyNumber.Name = "lblPropertyNumber"
        Me.lblPropertyNumber.Size = New System.Drawing.Size(119, 19)
        Me.lblPropertyNumber.TabIndex = 2
        Me.lblPropertyNumber.Text = "Property Number:"
        '
        'txtPropertyNumber
        '
        Me.txtPropertyNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPropertyNumber.Location = New System.Drawing.Point(574, 65)
        Me.txtPropertyNumber.Name = "txtPropertyNumber"
        Me.txtPropertyNumber.Size = New System.Drawing.Size(250, 25)
        Me.txtPropertyNumber.TabIndex = 3
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSerialNumber.Location = New System.Drawing.Point(840, 40)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(98, 19)
        Me.lblSerialNumber.TabIndex = 4
        Me.lblSerialNumber.Text = "Serial Number:"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSerialNumber.Location = New System.Drawing.Point(844, 65)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(250, 25)
        Me.txtSerialNumber.TabIndex = 5
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(23, 110)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(86, 19)
        Me.lblDepartment.TabIndex = 6
        Me.lblDepartment.Text = "Department:"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(27, 135)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(520, 25)
        Me.cboDepartment.TabIndex = 7
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblLocation.Location = New System.Drawing.Point(23, 180)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(64, 19)
        Me.lblLocation.TabIndex = 8
        Me.lblLocation.Text = "Location:"
        '
        'txtLocation
        '
        Me.txtLocation.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtLocation.Location = New System.Drawing.Point(27, 205)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(520, 25)
        Me.txtLocation.TabIndex = 9
        '
        'grpRequestDetails
        '
        Me.grpRequestDetails.Controls.Add(Me.lblDateRequested)
        Me.grpRequestDetails.Controls.Add(Me.dtpDateRequested)
        Me.grpRequestDetails.Controls.Add(Me.lblConditionBefore)
        Me.grpRequestDetails.Controls.Add(Me.cboConditionBefore)
        Me.grpRequestDetails.Controls.Add(Me.lblTypeOfIssue)
        Me.grpRequestDetails.Controls.Add(Me.cboTypeOfIssue)
        Me.grpRequestDetails.Controls.Add(Me.lblTargetDate)
        Me.grpRequestDetails.Controls.Add(Me.dtpTargetDate)
        Me.grpRequestDetails.Controls.Add(Me.lblProblemDescription)
        Me.grpRequestDetails.Controls.Add(Me.txtProblemDescription)
        Me.grpRequestDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRequestDetails.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.grpRequestDetails.Location = New System.Drawing.Point(30, 20)
        Me.grpRequestDetails.Name = "grpRequestDetails"
        Me.grpRequestDetails.Padding = New System.Windows.Forms.Padding(20, 20, 20, 20)
        Me.grpRequestDetails.Size = New System.Drawing.Size(1123, 380)
        Me.grpRequestDetails.TabIndex = 1
        Me.grpRequestDetails.TabStop = False
        Me.grpRequestDetails.Text = "Maintenance Request Details"
        '
        'lblDateRequested
        '
        Me.lblDateRequested.AutoSize = True
        Me.lblDateRequested.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDateRequested.Location = New System.Drawing.Point(23, 40)
        Me.lblDateRequested.Name = "lblDateRequested"
        Me.lblDateRequested.Size = New System.Drawing.Size(109, 19)
        Me.lblDateRequested.TabIndex = 0
        Me.lblDateRequested.Text = "Date Requested:"
        '
        'dtpDateRequested
        '
        Me.dtpDateRequested.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpDateRequested.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateRequested.Location = New System.Drawing.Point(27, 65)
        Me.dtpDateRequested.Name = "dtpDateRequested"
        Me.dtpDateRequested.Size = New System.Drawing.Size(250, 25)
        Me.dtpDateRequested.TabIndex = 1
        '
        'lblConditionBefore
        '
        Me.lblConditionBefore.AutoSize = True
        Me.lblConditionBefore.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblConditionBefore.Location = New System.Drawing.Point(297, 40)
        Me.lblConditionBefore.Name = "lblConditionBefore"
        Me.lblConditionBefore.Size = New System.Drawing.Size(115, 19)
        Me.lblConditionBefore.TabIndex = 2
        Me.lblConditionBefore.Text = "Condition Before:"
        '
        'cboConditionBefore
        '
        Me.cboConditionBefore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConditionBefore.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboConditionBefore.FormattingEnabled = True
        Me.cboConditionBefore.Location = New System.Drawing.Point(301, 65)
        Me.cboConditionBefore.Name = "cboConditionBefore"
        Me.cboConditionBefore.Size = New System.Drawing.Size(250, 25)
        Me.cboConditionBefore.TabIndex = 3
        '
        'lblTypeOfIssue
        '
        Me.lblTypeOfIssue.AutoSize = True
        Me.lblTypeOfIssue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTypeOfIssue.Location = New System.Drawing.Point(571, 40)
        Me.lblTypeOfIssue.Name = "lblTypeOfIssue"
        Me.lblTypeOfIssue.Size = New System.Drawing.Size(91, 19)
        Me.lblTypeOfIssue.TabIndex = 4
        Me.lblTypeOfIssue.Text = "Type of Issue:"
        '
        'cboTypeOfIssue
        '
        Me.cboTypeOfIssue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeOfIssue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboTypeOfIssue.FormattingEnabled = True
        Me.cboTypeOfIssue.Location = New System.Drawing.Point(575, 65)
        Me.cboTypeOfIssue.Name = "cboTypeOfIssue"
        Me.cboTypeOfIssue.Size = New System.Drawing.Size(250, 25)
        Me.cboTypeOfIssue.TabIndex = 5
        '
        'lblTargetDate
        '
        Me.lblTargetDate.AutoSize = True
        Me.lblTargetDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTargetDate.Location = New System.Drawing.Point(844, 40)
        Me.lblTargetDate.Name = "lblTargetDate"
        Me.lblTargetDate.Size = New System.Drawing.Size(82, 19)
        Me.lblTargetDate.TabIndex = 6
        Me.lblTargetDate.Text = "Target Date:"
        '
        'dtpTargetDate
        '
        Me.dtpTargetDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTargetDate.Location = New System.Drawing.Point(848, 65)
        Me.dtpTargetDate.Name = "dtpTargetDate"
        Me.dtpTargetDate.Size = New System.Drawing.Size(250, 25)
        Me.dtpTargetDate.TabIndex = 7
        '
        'lblProblemDescription
        '
        Me.lblProblemDescription.AutoSize = True
        Me.lblProblemDescription.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblProblemDescription.Location = New System.Drawing.Point(23, 110)
        Me.lblProblemDescription.Name = "lblProblemDescription"
        Me.lblProblemDescription.Size = New System.Drawing.Size(212, 19)
        Me.lblProblemDescription.TabIndex = 8
        Me.lblProblemDescription.Text = "Problem Description (Required): *"
        '
        'txtProblemDescription
        '
        Me.txtProblemDescription.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtProblemDescription.Location = New System.Drawing.Point(27, 135)
        Me.txtProblemDescription.Multiline = True
        Me.txtProblemDescription.Name = "txtProblemDescription"
        Me.txtProblemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProblemDescription.Size = New System.Drawing.Size(1080, 200)
        Me.txtProblemDescription.TabIndex = 9
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlFooter.Controls.Add(Me.lblRequestedBy)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Controls.Add(Me.btnSubmit)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 700)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlFooter.Size = New System.Drawing.Size(1200, 100)
        Me.pnlFooter.TabIndex = 2
        '
        'lblRequestedBy
        '
        Me.lblRequestedBy.AutoSize = True
        Me.lblRequestedBy.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblRequestedBy.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblRequestedBy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRequestedBy.Location = New System.Drawing.Point(30, 20)
        Me.lblRequestedBy.Name = "lblRequestedBy"
        Me.lblRequestedBy.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.lblRequestedBy.Size = New System.Drawing.Size(95, 34)
        Me.lblRequestedBy.TabIndex = 0
        Me.lblRequestedBy.Text = "Requested By:"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(880, 20)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(140, 60)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(1020, 20)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(150, 60)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "✓ Submit Request"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'MaintenanceRequestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "MaintenanceRequestForm"
        Me.Size = New System.Drawing.Size(1200, 800)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.grpItemDetails.ResumeLayout(False)
        Me.grpItemDetails.PerformLayout()
        Me.grpRequestDetails.ResumeLayout(False)
        Me.grpRequestDetails.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents grpItemDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents cboItemName As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropertyNumber As System.Windows.Forms.Label
    Friend WithEvents txtPropertyNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents grpRequestDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblDateRequested As System.Windows.Forms.Label
    Friend WithEvents dtpDateRequested As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblConditionBefore As System.Windows.Forms.Label
    Friend WithEvents cboConditionBefore As System.Windows.Forms.ComboBox
    Friend WithEvents lblTypeOfIssue As System.Windows.Forms.Label
    Friend WithEvents cboTypeOfIssue As System.Windows.Forms.ComboBox
    Friend WithEvents lblTargetDate As System.Windows.Forms.Label
    Friend WithEvents dtpTargetDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProblemDescription As System.Windows.Forms.Label
    Friend WithEvents txtProblemDescription As System.Windows.Forms.TextBox
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents lblRequestedBy As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
End Class
