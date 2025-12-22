<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceManagementReport1
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.conditionAfterMaintenance = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.maintenanceDetail = New System.Windows.Forms.TextBox()
        Me.costMaterialsLabor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.maintenanceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.assignedTechnician = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.typeOfMaintenance = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.conditionBeforeMaintenance = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.departmentId = New System.Windows.Forms.TextBox()
        Me.location = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.serialId = New System.Windows.Forms.TextBox()
        Me.propertyItemName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fundCluster = New System.Windows.Forms.Label()
        Me.requestId = New System.Windows.Forms.TextBox()
        Me.maintenanceId = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.actionTaken = New System.Windows.Forms.ComboBox()
        Me.status = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.partsReplaced = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.diagnosis = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.conditionAfterMaintenance)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.maintenanceDetail)
        Me.Panel4.Controls.Add(Me.costMaterialsLabor)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.maintenanceDate)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.assignedTechnician)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.typeOfMaintenance)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.conditionBeforeMaintenance)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Location = New System.Drawing.Point(183, 340)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(913, 477)
        Me.Panel4.TabIndex = 61
        '
        'conditionAfterMaintenance
        '
        Me.conditionAfterMaintenance.Location = New System.Drawing.Point(75, 392)
        Me.conditionAfterMaintenance.Multiline = True
        Me.conditionAfterMaintenance.Name = "conditionAfterMaintenance"
        Me.conditionAfterMaintenance.Size = New System.Drawing.Size(793, 61)
        Me.conditionAfterMaintenance.TabIndex = 67
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 358)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(189, 22)
        Me.Label17.TabIndex = 66
        Me.Label17.Text = "Condition After Maintenance:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'maintenanceDetail
        '
        Me.maintenanceDetail.Location = New System.Drawing.Point(75, 225)
        Me.maintenanceDetail.Multiline = True
        Me.maintenanceDetail.Name = "maintenanceDetail"
        Me.maintenanceDetail.Size = New System.Drawing.Size(793, 61)
        Me.maintenanceDetail.TabIndex = 65
        '
        'costMaterialsLabor
        '
        Me.costMaterialsLabor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.costMaterialsLabor.Location = New System.Drawing.Point(631, 308)
        Me.costMaterialsLabor.Name = "costMaterialsLabor"
        Me.costMaterialsLabor.Size = New System.Drawing.Size(269, 22)
        Me.costMaterialsLabor.TabIndex = 64
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(473, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 22)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Cost Materials Labor:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'maintenanceDate
        '
        Me.maintenanceDate.Location = New System.Drawing.Point(161, 308)
        Me.maintenanceDate.Name = "maintenanceDate"
        Me.maintenanceDate.Size = New System.Drawing.Size(277, 22)
        Me.maintenanceDate.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 309)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 22)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Maintenance Date:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 22)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Maintenance Detail:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'assignedTechnician
        '
        Me.assignedTechnician.FormattingEnabled = True
        Me.assignedTechnician.Location = New System.Drawing.Point(618, 18)
        Me.assignedTechnician.Name = "assignedTechnician"
        Me.assignedTechnician.Size = New System.Drawing.Size(282, 24)
        Me.assignedTechnician.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(473, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 22)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Assigned Technician:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'typeOfMaintenance
        '
        Me.typeOfMaintenance.FormattingEnabled = True
        Me.typeOfMaintenance.Location = New System.Drawing.Point(176, 18)
        Me.typeOfMaintenance.Name = "typeOfMaintenance"
        Me.typeOfMaintenance.Size = New System.Drawing.Size(262, 24)
        Me.typeOfMaintenance.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 22)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Type of Maintenance:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'conditionBeforeMaintenance
        '
        Me.conditionBeforeMaintenance.Location = New System.Drawing.Point(75, 102)
        Me.conditionBeforeMaintenance.Multiline = True
        Me.conditionBeforeMaintenance.Name = "conditionBeforeMaintenance"
        Me.conditionBeforeMaintenance.Size = New System.Drawing.Size(793, 61)
        Me.conditionBeforeMaintenance.TabIndex = 55
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(198, 22)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Condition Before Maintenance:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.departmentId)
        Me.Panel1.Controls.Add(Me.location)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.serialId)
        Me.Panel1.Controls.Add(Me.propertyItemName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.fundCluster)
        Me.Panel1.Controls.Add(Me.requestId)
        Me.Panel1.Controls.Add(Me.maintenanceId)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Location = New System.Drawing.Point(183, 190)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(913, 151)
        Me.Panel1.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(473, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 22)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Department ID:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'departmentId
        '
        Me.departmentId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.departmentId.Location = New System.Drawing.Point(598, 97)
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Size = New System.Drawing.Size(302, 22)
        Me.departmentId.TabIndex = 62
        '
        'location
        '
        Me.location.Location = New System.Drawing.Point(136, 97)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(302, 22)
        Me.location.TabIndex = 63
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 22)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Location:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(473, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 22)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Serial Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'serialId
        '
        Me.serialId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialId.Location = New System.Drawing.Point(598, 57)
        Me.serialId.Name = "serialId"
        Me.serialId.Size = New System.Drawing.Size(302, 22)
        Me.serialId.TabIndex = 58
        '
        'propertyItemName
        '
        Me.propertyItemName.Location = New System.Drawing.Point(136, 57)
        Me.propertyItemName.Name = "propertyItemName"
        Me.propertyItemName.Size = New System.Drawing.Size(302, 22)
        Me.propertyItemName.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 22)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Property Item Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fundCluster
        '
        Me.fundCluster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fundCluster.AutoSize = True
        Me.fundCluster.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fundCluster.Location = New System.Drawing.Point(473, 22)
        Me.fundCluster.Name = "fundCluster"
        Me.fundCluster.Size = New System.Drawing.Size(78, 22)
        Me.fundCluster.TabIndex = 39
        Me.fundCluster.Text = "Request ID:"
        Me.fundCluster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'requestId
        '
        Me.requestId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestId.Location = New System.Drawing.Point(598, 20)
        Me.requestId.Name = "requestId"
        Me.requestId.Size = New System.Drawing.Size(302, 22)
        Me.requestId.TabIndex = 45
        '
        'maintenanceId
        '
        Me.maintenanceId.Location = New System.Drawing.Point(136, 20)
        Me.maintenanceId.Name = "maintenanceId"
        Me.maintenanceId.Size = New System.Drawing.Size(302, 22)
        Me.maintenanceId.TabIndex = 55
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(11, 22)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(108, 22)
        Me.lblName.TabIndex = 38
        Me.lblName.Text = "Maintenance ID:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblPropertyCard)
        Me.Panel11.Location = New System.Drawing.Point(183, 128)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(913, 64)
        Me.Panel11.TabIndex = 59
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(204, 14)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(493, 44)
        Me.lblPropertyCard.TabIndex = 38
        Me.lblPropertyCard.Text = "MAINTENANCE MANAGEMENT REPORT"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.actionTaken)
        Me.Panel2.Controls.Add(Me.status)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.partsReplaced)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.diagnosis)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Location = New System.Drawing.Point(183, 815)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(913, 109)
        Me.Panel2.TabIndex = 64
        '
        'actionTaken
        '
        Me.actionTaken.FormattingEnabled = True
        Me.actionTaken.Location = New System.Drawing.Point(136, 57)
        Me.actionTaken.Name = "actionTaken"
        Me.actionTaken.Size = New System.Drawing.Size(302, 24)
        Me.actionTaken.TabIndex = 69
        '
        'status
        '
        Me.status.FormattingEnabled = True
        Me.status.Location = New System.Drawing.Point(136, 20)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(302, 24)
        Me.status.TabIndex = 68
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(473, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 22)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Parts Replaced:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'partsReplaced
        '
        Me.partsReplaced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.partsReplaced.Location = New System.Drawing.Point(598, 57)
        Me.partsReplaced.Name = "partsReplaced"
        Me.partsReplaced.Size = New System.Drawing.Size(302, 22)
        Me.partsReplaced.TabIndex = 58
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 22)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "Action Taken:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(473, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 22)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Diagnosis:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'diagnosis
        '
        Me.diagnosis.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.diagnosis.Location = New System.Drawing.Point(598, 20)
        Me.diagnosis.Name = "diagnosis"
        Me.diagnosis.Size = New System.Drawing.Size(302, 22)
        Me.diagnosis.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 22)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Status:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MaintenanceManagementReport1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Name = "MaintenanceManagementReport1"
        Me.Size = New System.Drawing.Size(1339, 1110)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents conditionBeforeMaintenance As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents fundCluster As System.Windows.Forms.Label
    Friend WithEvents requestId As System.Windows.Forms.TextBox
    Friend WithEvents maintenanceId As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents lblPropertyCard As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents departmentId As System.Windows.Forms.TextBox
    Friend Shadows WithEvents location As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents serialId As System.Windows.Forms.TextBox
    Friend WithEvents propertyItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents assignedTechnician As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents typeOfMaintenance As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents maintenanceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents costMaterialsLabor As System.Windows.Forms.TextBox
    Friend WithEvents conditionAfterMaintenance As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents maintenanceDetail As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents partsReplaced As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents diagnosis As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents actionTaken As System.Windows.Forms.ComboBox
    Friend WithEvents status As System.Windows.Forms.ComboBox
End Class
