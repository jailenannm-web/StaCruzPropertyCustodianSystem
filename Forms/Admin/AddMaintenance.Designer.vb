Imports System
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddMaintenance
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
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.pnlBasicInfo = New System.Windows.Forms.Panel()
        Me.lblBasicInfo = New System.Windows.Forms.Label()
        Me.lblPropertyItemName = New System.Windows.Forms.Label()
        Me.cmbPropertyItem = New System.Windows.Forms.ComboBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.pnlMaintenanceInfo = New System.Windows.Forms.Panel()
        Me.lblMaintenanceInfo = New System.Windows.Forms.Label()
        Me.lblConditionBefore = New System.Windows.Forms.Label()
        Me.cmbConditionBefore = New System.Windows.Forms.ComboBox()
        Me.lblTypeOfMaintenance = New System.Windows.Forms.Label()
        Me.cmbTypeOfMaintenance = New System.Windows.Forms.ComboBox()
        Me.lblAssignedTechnician = New System.Windows.Forms.Label()
        Me.cmbAssignedTechnician = New System.Windows.Forms.ComboBox()
        Me.lblMaintenanceDate = New System.Windows.Forms.Label()
        Me.dtpMaintenanceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblDetailsInfo = New System.Windows.Forms.Label()
        Me.lblMaintenanceDetails = New System.Windows.Forms.Label()
        Me.txtMaintenanceDetails = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.txtDiagnosis = New System.Windows.Forms.TextBox()
        Me.lblActionTaken = New System.Windows.Forms.Label()
        Me.txtActionTaken = New System.Windows.Forms.TextBox()
        Me.lblPartsReplaced = New System.Windows.Forms.Label()
        Me.txtPartsReplaced = New System.Windows.Forms.TextBox()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.lblConditionAfter = New System.Windows.Forms.Label()
        Me.cmbConditionAfter = New System.Windows.Forms.ComboBox()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlMain.SuspendLayout()
        Me.pnlForm.SuspendLayout()
        Me.pnlBasicInfo.SuspendLayout()
        Me.pnlMaintenanceInfo.SuspendLayout()
        Me.pnlDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Poppins", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(30, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(285, 60)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Add Maintenance"
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.btnCancel)
        Me.pnlMain.Controls.Add(Me.btnSave)
        Me.pnlMain.Controls.Add(Me.pnlForm)
        Me.pnlMain.Controls.Add(Me.lblTitle)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlMain.Size = New System.Drawing.Size(1200, 800)
        Me.pnlMain.TabIndex = 0
        '
        'pnlForm
        '
        Me.pnlForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlForm.AutoScroll = True
        Me.pnlForm.BackColor = System.Drawing.Color.White
        Me.pnlForm.Controls.Add(Me.pnlDetails)
        Me.pnlForm.Controls.Add(Me.pnlMaintenanceInfo)
        Me.pnlForm.Controls.Add(Me.pnlBasicInfo)
        Me.pnlForm.Location = New System.Drawing.Point(30, 90)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlForm.Size = New System.Drawing.Size(1140, 635)
        Me.pnlForm.TabIndex = 1
        '
        'pnlBasicInfo
        '
        Me.pnlBasicInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlBasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBasicInfo.Controls.Add(Me.lblBasicInfo)
        Me.pnlBasicInfo.Controls.Add(Me.lblPropertyItemName)
        Me.pnlBasicInfo.Controls.Add(Me.cmbPropertyItem)
        Me.pnlBasicInfo.Controls.Add(Me.lblSerialNumber)
        Me.pnlBasicInfo.Controls.Add(Me.txtSerialNumber)
        Me.pnlBasicInfo.Controls.Add(Me.lblLocation)
        Me.pnlBasicInfo.Controls.Add(Me.txtLocation)
        Me.pnlBasicInfo.Controls.Add(Me.lblDepartment)
        Me.pnlBasicInfo.Controls.Add(Me.cmbDepartment)
        Me.pnlBasicInfo.Location = New System.Drawing.Point(20, 20)
        Me.pnlBasicInfo.Name = "pnlBasicInfo"
        Me.pnlBasicInfo.Size = New System.Drawing.Size(1080, 150)
        Me.pnlBasicInfo.TabIndex = 0
        '
        'lblBasicInfo
        '
        Me.lblBasicInfo.AutoSize = True
        Me.lblBasicInfo.Font = New System.Drawing.Font("Poppins SemiBold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBasicInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblBasicInfo.Location = New System.Drawing.Point(15, 10)
        Me.lblBasicInfo.Name = "lblBasicInfo"
        Me.lblBasicInfo.Size = New System.Drawing.Size(180, 34)
        Me.lblBasicInfo.TabIndex = 0
        Me.lblBasicInfo.Text = "Property Information"
        '
        'lblPropertyItemName
        '
        Me.lblPropertyItemName.AutoSize = True
        Me.lblPropertyItemName.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPropertyItemName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblPropertyItemName.Location = New System.Drawing.Point(20, 55)
        Me.lblPropertyItemName.Name = "lblPropertyItemName"
        Me.lblPropertyItemName.Size = New System.Drawing.Size(176, 26)
        Me.lblPropertyItemName.TabIndex = 1
        Me.lblPropertyItemName.Text = "Property Item Name *"
        '
        'cmbPropertyItem
        '
        Me.cmbPropertyItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPropertyItem.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbPropertyItem.FormattingEnabled = True
        Me.cmbPropertyItem.Location = New System.Drawing.Point(25, 85)
        Me.cmbPropertyItem.Name = "cmbPropertyItem"
        Me.cmbPropertyItem.Size = New System.Drawing.Size(340, 34)
        Me.cmbPropertyItem.TabIndex = 2
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblSerialNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblSerialNumber.Location = New System.Drawing.Point(385, 55)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(114, 26)
        Me.lblSerialNumber.TabIndex = 3
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtSerialNumber.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtSerialNumber.Location = New System.Drawing.Point(390, 85)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.ReadOnly = True
        Me.txtSerialNumber.Size = New System.Drawing.Size(325, 34)
        Me.txtSerialNumber.TabIndex = 4
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblLocation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblLocation.Location = New System.Drawing.Point(735, 55)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(75, 26)
        Me.lblLocation.TabIndex = 5
        Me.lblLocation.Text = "Location"
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtLocation.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtLocation.Location = New System.Drawing.Point(740, 85)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(310, 34)
        Me.txtLocation.TabIndex = 6
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblDepartment.Location = New System.Drawing.Point(20, 55)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(102, 26)
        Me.lblDepartment.TabIndex = 7
        Me.lblDepartment.Text = "Department"
        Me.lblDepartment.Visible = False
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.Enabled = False
        Me.cmbDepartment.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(25, 85)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(340, 34)
        Me.cmbDepartment.TabIndex = 8
        Me.cmbDepartment.Visible = False
        '
        'pnlMaintenanceInfo
        '
        Me.pnlMaintenanceInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlMaintenanceInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMaintenanceInfo.Controls.Add(Me.lblMaintenanceInfo)
        Me.pnlMaintenanceInfo.Controls.Add(Me.lblConditionBefore)
        Me.pnlMaintenanceInfo.Controls.Add(Me.cmbConditionBefore)
        Me.pnlMaintenanceInfo.Controls.Add(Me.lblTypeOfMaintenance)
        Me.pnlMaintenanceInfo.Controls.Add(Me.cmbTypeOfMaintenance)
        Me.pnlMaintenanceInfo.Controls.Add(Me.lblAssignedTechnician)
        Me.pnlMaintenanceInfo.Controls.Add(Me.cmbAssignedTechnician)
        Me.pnlMaintenanceInfo.Controls.Add(Me.lblMaintenanceDate)
        Me.pnlMaintenanceInfo.Controls.Add(Me.dtpMaintenanceDate)
        Me.pnlMaintenanceInfo.Controls.Add(Me.lblStatus)
        Me.pnlMaintenanceInfo.Controls.Add(Me.cmbStatus)
        Me.pnlMaintenanceInfo.Location = New System.Drawing.Point(20, 180)
        Me.pnlMaintenanceInfo.Name = "pnlMaintenanceInfo"
        Me.pnlMaintenanceInfo.Size = New System.Drawing.Size(1080, 150)
        Me.pnlMaintenanceInfo.TabIndex = 1
        '
        'lblMaintenanceInfo
        '
        Me.lblMaintenanceInfo.AutoSize = True
        Me.lblMaintenanceInfo.Font = New System.Drawing.Font("Poppins SemiBold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblMaintenanceInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblMaintenanceInfo.Location = New System.Drawing.Point(15, 10)
        Me.lblMaintenanceInfo.Name = "lblMaintenanceInfo"
        Me.lblMaintenanceInfo.Size = New System.Drawing.Size(220, 34)
        Me.lblMaintenanceInfo.TabIndex = 0
        Me.lblMaintenanceInfo.Text = "Maintenance Information"
        '
        'lblConditionBefore
        '
        Me.lblConditionBefore.AutoSize = True
        Me.lblConditionBefore.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblConditionBefore.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblConditionBefore.Location = New System.Drawing.Point(20, 55)
        Me.lblConditionBefore.Name = "lblConditionBefore"
        Me.lblConditionBefore.Size = New System.Drawing.Size(137, 26)
        Me.lblConditionBefore.TabIndex = 1
        Me.lblConditionBefore.Text = "Condition Before"
        '
        'cmbConditionBefore
        '
        Me.cmbConditionBefore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConditionBefore.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbConditionBefore.FormattingEnabled = True
        Me.cmbConditionBefore.Items.AddRange(New Object() {"Good", "Needs Repair", "Damaged"})
        Me.cmbConditionBefore.Location = New System.Drawing.Point(25, 85)
        Me.cmbConditionBefore.Name = "cmbConditionBefore"
        Me.cmbConditionBefore.Size = New System.Drawing.Size(200, 34)
        Me.cmbConditionBefore.TabIndex = 2
        '
        'lblTypeOfMaintenance
        '
        Me.lblTypeOfMaintenance.AutoSize = True
        Me.lblTypeOfMaintenance.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTypeOfMaintenance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblTypeOfMaintenance.Location = New System.Drawing.Point(245, 55)
        Me.lblTypeOfMaintenance.Name = "lblTypeOfMaintenance"
        Me.lblTypeOfMaintenance.Size = New System.Drawing.Size(186, 26)
        Me.lblTypeOfMaintenance.TabIndex = 3
        Me.lblTypeOfMaintenance.Text = "Type of Maintenance *"
        '
        'cmbTypeOfMaintenance
        '
        Me.cmbTypeOfMaintenance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeOfMaintenance.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbTypeOfMaintenance.FormattingEnabled = True
        Me.cmbTypeOfMaintenance.Items.AddRange(New Object() {"Repair", "Replace", "Servicing"})
        Me.cmbTypeOfMaintenance.Location = New System.Drawing.Point(250, 85)
        Me.cmbTypeOfMaintenance.Name = "cmbTypeOfMaintenance"
        Me.cmbTypeOfMaintenance.Size = New System.Drawing.Size(200, 34)
        Me.cmbTypeOfMaintenance.TabIndex = 4
        '
        'lblAssignedTechnician
        '
        Me.lblAssignedTechnician.AutoSize = True
        Me.lblAssignedTechnician.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblAssignedTechnician.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblAssignedTechnician.Location = New System.Drawing.Point(470, 55)
        Me.lblAssignedTechnician.Name = "lblAssignedTechnician"
        Me.lblAssignedTechnician.Size = New System.Drawing.Size(162, 26)
        Me.lblAssignedTechnician.TabIndex = 5
        Me.lblAssignedTechnician.Text = "Assigned Technician"
        '
        'cmbAssignedTechnician
        '
        Me.cmbAssignedTechnician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAssignedTechnician.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbAssignedTechnician.FormattingEnabled = True
        Me.cmbAssignedTechnician.Location = New System.Drawing.Point(475, 85)
        Me.cmbAssignedTechnician.Name = "cmbAssignedTechnician"
        Me.cmbAssignedTechnician.Size = New System.Drawing.Size(240, 34)
        Me.cmbAssignedTechnician.TabIndex = 6
        '
        'lblMaintenanceDate
        '
        Me.lblMaintenanceDate.AutoSize = True
        Me.lblMaintenanceDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblMaintenanceDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblMaintenanceDate.Location = New System.Drawing.Point(735, 55)
        Me.lblMaintenanceDate.Name = "lblMaintenanceDate"
        Me.lblMaintenanceDate.Size = New System.Drawing.Size(147, 26)
        Me.lblMaintenanceDate.TabIndex = 7
        Me.lblMaintenanceDate.Text = "Maintenance Date"
        '
        'dtpMaintenanceDate
        '
        Me.dtpMaintenanceDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.dtpMaintenanceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMaintenanceDate.Location = New System.Drawing.Point(740, 85)
        Me.dtpMaintenanceDate.Name = "dtpMaintenanceDate"
        Me.dtpMaintenanceDate.Size = New System.Drawing.Size(310, 34)
        Me.dtpMaintenanceDate.TabIndex = 8
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(940, 55)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(58, 26)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Visible = False
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Completed", "Ongoing", "For Review"})
        Me.cmbStatus.Location = New System.Drawing.Point(945, 85)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(105, 34)
        Me.cmbStatus.TabIndex = 10
        Me.cmbStatus.Visible = False
        '
        'pnlDetails
        '
        Me.pnlDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetails.Controls.Add(Me.lblDetailsInfo)
        Me.pnlDetails.Controls.Add(Me.lblMaintenanceDetails)
        Me.pnlDetails.Controls.Add(Me.txtMaintenanceDetails)
        Me.pnlDetails.Controls.Add(Me.lblDiagnosis)
        Me.pnlDetails.Controls.Add(Me.txtDiagnosis)
        Me.pnlDetails.Controls.Add(Me.lblActionTaken)
        Me.pnlDetails.Controls.Add(Me.txtActionTaken)
        Me.pnlDetails.Controls.Add(Me.lblPartsReplaced)
        Me.pnlDetails.Controls.Add(Me.txtPartsReplaced)
        Me.pnlDetails.Controls.Add(Me.lblCost)
        Me.pnlDetails.Controls.Add(Me.txtCost)
        Me.pnlDetails.Controls.Add(Me.lblConditionAfter)
        Me.pnlDetails.Controls.Add(Me.cmbConditionAfter)
        Me.pnlDetails.Location = New System.Drawing.Point(20, 340)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(1080, 255)
        Me.pnlDetails.TabIndex = 2
        '
        'lblDetailsInfo
        '
        Me.lblDetailsInfo.AutoSize = True
        Me.lblDetailsInfo.Font = New System.Drawing.Font("Poppins SemiBold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetailsInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblDetailsInfo.Location = New System.Drawing.Point(15, 10)
        Me.lblDetailsInfo.Name = "lblDetailsInfo"
        Me.lblDetailsInfo.Size = New System.Drawing.Size(186, 34)
        Me.lblDetailsInfo.TabIndex = 0
        Me.lblDetailsInfo.Text = "Additional Details"
        '
        'lblMaintenanceDetails
        '
        Me.lblMaintenanceDetails.AutoSize = True
        Me.lblMaintenanceDetails.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblMaintenanceDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblMaintenanceDetails.Location = New System.Drawing.Point(20, 55)
        Me.lblMaintenanceDetails.Name = "lblMaintenanceDetails"
        Me.lblMaintenanceDetails.Size = New System.Drawing.Size(154, 26)
        Me.lblMaintenanceDetails.TabIndex = 1
        Me.lblMaintenanceDetails.Text = "Maintenance Details"
        '
        'txtMaintenanceDetails
        '
        Me.txtMaintenanceDetails.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtMaintenanceDetails.Location = New System.Drawing.Point(25, 85)
        Me.txtMaintenanceDetails.Multiline = True
        Me.txtMaintenanceDetails.Name = "txtMaintenanceDetails"
        Me.txtMaintenanceDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMaintenanceDetails.Size = New System.Drawing.Size(340, 60)
        Me.txtMaintenanceDetails.TabIndex = 2
        '
        'lblCost
        '
        Me.lblCost.AutoSize = True
        Me.lblCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblCost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblCost.Location = New System.Drawing.Point(20, 160)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(155, 26)
        Me.lblCost.TabIndex = 9
        Me.lblCost.Text = "Cost (Materials/Labor)"
        '
        'txtCost
        '
        Me.txtCost.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtCost.Location = New System.Drawing.Point(25, 190)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(200, 34)
        Me.txtCost.TabIndex = 10
        Me.txtCost.Text = "0.00"
        '
        'lblConditionAfter
        '
        Me.lblConditionAfter.AutoSize = True
        Me.lblConditionAfter.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblConditionAfter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblConditionAfter.Location = New System.Drawing.Point(245, 160)
        Me.lblConditionAfter.Name = "lblConditionAfter"
        Me.lblConditionAfter.Size = New System.Drawing.Size(122, 26)
        Me.lblConditionAfter.TabIndex = 11
        Me.lblConditionAfter.Text = "Condition After"
        '
        'cmbConditionAfter
        '
        Me.cmbConditionAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConditionAfter.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbConditionAfter.FormattingEnabled = True
        Me.cmbConditionAfter.Items.AddRange(New Object() {"Good", "Needs Further Repair"})
        Me.cmbConditionAfter.Location = New System.Drawing.Point(250, 190)
        Me.cmbConditionAfter.Name = "cmbConditionAfter"
        Me.cmbConditionAfter.Size = New System.Drawing.Size(240, 34)
        Me.cmbConditionAfter.TabIndex = 12
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.AutoSize = True
        Me.lblDiagnosis.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblDiagnosis.Location = New System.Drawing.Point(385, 55)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(85, 26)
        Me.lblDiagnosis.TabIndex = 3
        Me.lblDiagnosis.Text = "Diagnosis"
        '
        'txtDiagnosis
        '
        Me.txtDiagnosis.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtDiagnosis.Location = New System.Drawing.Point(390, 85)
        Me.txtDiagnosis.Multiline = True
        Me.txtDiagnosis.Name = "txtDiagnosis"
        Me.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDiagnosis.Size = New System.Drawing.Size(325, 60)
        Me.txtDiagnosis.TabIndex = 4
        '
        'lblActionTaken
        '
        Me.lblActionTaken.AutoSize = True
        Me.lblActionTaken.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblActionTaken.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblActionTaken.Location = New System.Drawing.Point(735, 55)
        Me.lblActionTaken.Name = "lblActionTaken"
        Me.lblActionTaken.Size = New System.Drawing.Size(110, 26)
        Me.lblActionTaken.TabIndex = 5
        Me.lblActionTaken.Text = "Action Taken"
        '
        'txtActionTaken
        '
        Me.txtActionTaken.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtActionTaken.Location = New System.Drawing.Point(740, 85)
        Me.txtActionTaken.Multiline = True
        Me.txtActionTaken.Name = "txtActionTaken"
        Me.txtActionTaken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtActionTaken.Size = New System.Drawing.Size(310, 60)
        Me.txtActionTaken.TabIndex = 6
        '
        'lblPartsReplaced
        '
        Me.lblPartsReplaced.AutoSize = True
        Me.lblPartsReplaced.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.lblPartsReplaced.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblPartsReplaced.Location = New System.Drawing.Point(510, 160)
        Me.lblPartsReplaced.Name = "lblPartsReplaced"
        Me.lblPartsReplaced.Size = New System.Drawing.Size(127, 26)
        Me.lblPartsReplaced.TabIndex = 7
        Me.lblPartsReplaced.Text = "Parts Replaced"
        '
        'txtPartsReplaced
        '
        Me.txtPartsReplaced.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtPartsReplaced.Location = New System.Drawing.Point(515, 190)
        Me.txtPartsReplaced.Multiline = True
        Me.txtPartsReplaced.Name = "txtPartsReplaced"
        Me.txtPartsReplaced.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPartsReplaced.Size = New System.Drawing.Size(535, 34)
        Me.txtPartsReplaced.TabIndex = 8
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(930, 735)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 45)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(1056, 735)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 45)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'AddMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "AddMaintenance"
        Me.Size = New System.Drawing.Size(1200, 800)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlForm As Panel
    Friend WithEvents pnlBasicInfo As Panel
    Friend WithEvents lblBasicInfo As Label
    Friend WithEvents lblPropertyItemName As Label
    Friend WithEvents cmbPropertyItem As ComboBox
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents pnlMaintenanceInfo As Panel
    Friend WithEvents lblMaintenanceInfo As Label
    Friend WithEvents lblConditionBefore As Label
    Friend WithEvents cmbConditionBefore As ComboBox
    Friend WithEvents lblTypeOfMaintenance As Label
    Friend WithEvents cmbTypeOfMaintenance As ComboBox
    Friend WithEvents lblAssignedTechnician As Label
    Friend WithEvents cmbAssignedTechnician As ComboBox
    Friend WithEvents lblMaintenanceDate As Label
    Friend WithEvents dtpMaintenanceDate As DateTimePicker
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents pnlDetails As Panel
    Friend WithEvents lblDetailsInfo As Label
    Friend WithEvents lblMaintenanceDetails As Label
    Friend WithEvents txtMaintenanceDetails As TextBox
    Friend WithEvents lblDiagnosis As Label
    Friend WithEvents txtDiagnosis As TextBox
    Friend WithEvents lblActionTaken As Label
    Friend WithEvents txtActionTaken As TextBox
    Friend WithEvents lblPartsReplaced As Label
    Friend WithEvents txtPartsReplaced As TextBox
    Friend WithEvents lblCost As Label
    Friend WithEvents txtCost As TextBox
    Friend WithEvents lblConditionAfter As Label
    Friend WithEvents cmbConditionAfter As ComboBox
    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnCancel As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
