<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMaintenance1
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
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.maintenanceDate = New System.Windows.Forms.DateTimePicker()
        Me.conditionAfterMaint = New System.Windows.Forms.ComboBox()
        Me.costMaterialsLabor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.maintenanceDetails = New System.Windows.Forms.ComboBox()
        Me.SAAddM_Providercontact = New System.Windows.Forms.Label()
        Me.SAAddM_NextSched = New System.Windows.Forms.Label()
        Me.SAAddM_Warranty = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.assignedTechnician = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.typeOfMaintenance = New System.Windows.Forms.ComboBox()
        Me.departmentId = New System.Windows.Forms.ComboBox()
        Me.location = New System.Windows.Forms.ComboBox()
        Me.conditionBeforeMaint = New System.Windows.Forms.ComboBox()
        Me.serialNumber = New System.Windows.Forms.TextBox()
        Me.propertyItemName = New System.Windows.Forms.TextBox()
        Me.SAAddM_Description = New System.Windows.Forms.Label()
        Me.SAAddM_ServiceType = New System.Windows.Forms.Label()
        Me.SAAddM_ServiceDate = New System.Windows.Forms.Label()
        Me.SAAddM_CustodianID = New System.Windows.Forms.Label()
        Me.SAAddM_PropertyID = New System.Windows.Forms.Label()
        Me.SAAddM_MainID = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(32, 193)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1261, 489)
        Me.RoundedPanel2.TabIndex = 171
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.maintenanceDate)
        Me.Panel2.Controls.Add(Me.conditionAfterMaint)
        Me.Panel2.Controls.Add(Me.costMaterialsLabor)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.maintenanceDetails)
        Me.Panel2.Controls.Add(Me.SAAddM_Providercontact)
        Me.Panel2.Controls.Add(Me.SAAddM_NextSched)
        Me.Panel2.Controls.Add(Me.SAAddM_Warranty)
        Me.Panel2.Location = New System.Drawing.Point(685, 18)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(525, 446)
        Me.Panel2.TabIndex = 65
        '
        'maintenanceDate
        '
        Me.maintenanceDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maintenanceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maintenanceDate.Location = New System.Drawing.Point(265, 98)
        Me.maintenanceDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.maintenanceDate.Name = "maintenanceDate"
        Me.maintenanceDate.Size = New System.Drawing.Size(227, 24)
        Me.maintenanceDate.TabIndex = 75
        '
        'conditionAfterMaint
        '
        Me.conditionAfterMaint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditionAfterMaint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionAfterMaint.FormattingEnabled = True
        Me.conditionAfterMaint.Location = New System.Drawing.Point(265, 248)
        Me.conditionAfterMaint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.conditionAfterMaint.Name = "conditionAfterMaint"
        Me.conditionAfterMaint.Size = New System.Drawing.Size(227, 26)
        Me.conditionAfterMaint.TabIndex = 73
        '
        'costMaterialsLabor
        '
        Me.costMaterialsLabor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.costMaterialsLabor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.costMaterialsLabor.Location = New System.Drawing.Point(264, 200)
        Me.costMaterialsLabor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.costMaterialsLabor.Name = "costMaterialsLabor"
        Me.costMaterialsLabor.Size = New System.Drawing.Size(228, 24)
        Me.costMaterialsLabor.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 18)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Cost of Materials / Labor"
        '
        'maintenanceDetails
        '
        Me.maintenanceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maintenanceDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maintenanceDetails.FormattingEnabled = True
        Me.maintenanceDetails.Location = New System.Drawing.Point(265, 154)
        Me.maintenanceDetails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.maintenanceDetails.Name = "maintenanceDetails"
        Me.maintenanceDetails.Size = New System.Drawing.Size(227, 26)
        Me.maintenanceDetails.TabIndex = 65
        '
        'SAAddM_Providercontact
        '
        Me.SAAddM_Providercontact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Providercontact.AutoSize = True
        Me.SAAddM_Providercontact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Providercontact.Location = New System.Drawing.Point(44, 98)
        Me.SAAddM_Providercontact.Name = "SAAddM_Providercontact"
        Me.SAAddM_Providercontact.Size = New System.Drawing.Size(127, 18)
        Me.SAAddM_Providercontact.TabIndex = 47
        Me.SAAddM_Providercontact.Text = "Maintenance Date"
        '
        'SAAddM_NextSched
        '
        Me.SAAddM_NextSched.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_NextSched.AutoSize = True
        Me.SAAddM_NextSched.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_NextSched.Location = New System.Drawing.Point(44, 155)
        Me.SAAddM_NextSched.Name = "SAAddM_NextSched"
        Me.SAAddM_NextSched.Size = New System.Drawing.Size(185, 18)
        Me.SAAddM_NextSched.TabIndex = 49
        Me.SAAddM_NextSched.Text = "Maintenance Details/Notes"
        '
        'SAAddM_Warranty
        '
        Me.SAAddM_Warranty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Warranty.AutoSize = True
        Me.SAAddM_Warranty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Warranty.Location = New System.Drawing.Point(44, 248)
        Me.SAAddM_Warranty.Name = "SAAddM_Warranty"
        Me.SAAddM_Warranty.Size = New System.Drawing.Size(193, 18)
        Me.SAAddM_Warranty.TabIndex = 50
        Me.SAAddM_Warranty.Text = "Condition After Maintenance"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.assignedTechnician)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.typeOfMaintenance)
        Me.Panel1.Controls.Add(Me.departmentId)
        Me.Panel1.Controls.Add(Me.location)
        Me.Panel1.Controls.Add(Me.conditionBeforeMaint)
        Me.Panel1.Controls.Add(Me.serialNumber)
        Me.Panel1.Controls.Add(Me.propertyItemName)
        Me.Panel1.Controls.Add(Me.SAAddM_Description)
        Me.Panel1.Controls.Add(Me.SAAddM_ServiceType)
        Me.Panel1.Controls.Add(Me.SAAddM_ServiceDate)
        Me.Panel1.Controls.Add(Me.SAAddM_CustodianID)
        Me.Panel1.Controls.Add(Me.SAAddM_PropertyID)
        Me.Panel1.Controls.Add(Me.SAAddM_MainID)
        Me.Panel1.Location = New System.Drawing.Point(45, 18)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(572, 446)
        Me.Panel1.TabIndex = 64
        '
        'assignedTechnician
        '
        Me.assignedTechnician.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedTechnician.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedTechnician.Location = New System.Drawing.Point(279, 350)
        Me.assignedTechnician.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.assignedTechnician.Name = "assignedTechnician"
        Me.assignedTechnician.Size = New System.Drawing.Size(249, 24)
        Me.assignedTechnician.TabIndex = 75
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 353)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 18)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Assigned Technician"
        '
        'typeOfMaintenance
        '
        Me.typeOfMaintenance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.typeOfMaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typeOfMaintenance.FormattingEnabled = True
        Me.typeOfMaintenance.Location = New System.Drawing.Point(279, 303)
        Me.typeOfMaintenance.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.typeOfMaintenance.Name = "typeOfMaintenance"
        Me.typeOfMaintenance.Size = New System.Drawing.Size(251, 26)
        Me.typeOfMaintenance.TabIndex = 73
        '
        'departmentId
        '
        Me.departmentId.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.departmentId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.departmentId.FormattingEnabled = True
        Me.departmentId.Location = New System.Drawing.Point(255, 197)
        Me.departmentId.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Size = New System.Drawing.Size(273, 26)
        Me.departmentId.TabIndex = 72
        '
        'location
        '
        Me.location.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.location.FormattingEnabled = True
        Me.location.Location = New System.Drawing.Point(255, 144)
        Me.location.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.location.Name = "location"
        Me.location.Size = New System.Drawing.Size(273, 26)
        Me.location.TabIndex = 71
        '
        'conditionBeforeMaint
        '
        Me.conditionBeforeMaint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditionBeforeMaint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionBeforeMaint.FormattingEnabled = True
        Me.conditionBeforeMaint.Location = New System.Drawing.Point(279, 249)
        Me.conditionBeforeMaint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.conditionBeforeMaint.Name = "conditionBeforeMaint"
        Me.conditionBeforeMaint.Size = New System.Drawing.Size(251, 26)
        Me.conditionBeforeMaint.TabIndex = 70
        '
        'serialNumber
        '
        Me.serialNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumber.Location = New System.Drawing.Point(255, 95)
        Me.serialNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Size = New System.Drawing.Size(273, 24)
        Me.serialNumber.TabIndex = 66
        '
        'propertyItemName
        '
        Me.propertyItemName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyItemName.Location = New System.Drawing.Point(256, 44)
        Me.propertyItemName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.propertyItemName.Name = "propertyItemName"
        Me.propertyItemName.Size = New System.Drawing.Size(273, 24)
        Me.propertyItemName.TabIndex = 64
        '
        'SAAddM_Description
        '
        Me.SAAddM_Description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Description.AutoSize = True
        Me.SAAddM_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Description.Location = New System.Drawing.Point(43, 308)
        Me.SAAddM_Description.Name = "SAAddM_Description"
        Me.SAAddM_Description.Size = New System.Drawing.Size(145, 18)
        Me.SAAddM_Description.TabIndex = 63
        Me.SAAddM_Description.Text = "Type of Maintenance"
        '
        'SAAddM_ServiceType
        '
        Me.SAAddM_ServiceType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceType.AutoSize = True
        Me.SAAddM_ServiceType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceType.Location = New System.Drawing.Point(43, 256)
        Me.SAAddM_ServiceType.Name = "SAAddM_ServiceType"
        Me.SAAddM_ServiceType.Size = New System.Drawing.Size(207, 18)
        Me.SAAddM_ServiceType.TabIndex = 62
        Me.SAAddM_ServiceType.Text = "Condition Before Maintenance"
        '
        'SAAddM_ServiceDate
        '
        Me.SAAddM_ServiceDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceDate.AutoSize = True
        Me.SAAddM_ServiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceDate.Location = New System.Drawing.Point(43, 201)
        Me.SAAddM_ServiceDate.Name = "SAAddM_ServiceDate"
        Me.SAAddM_ServiceDate.Size = New System.Drawing.Size(85, 18)
        Me.SAAddM_ServiceDate.TabIndex = 61
        Me.SAAddM_ServiceDate.Text = "Department"
        '
        'SAAddM_CustodianID
        '
        Me.SAAddM_CustodianID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_CustodianID.AutoSize = True
        Me.SAAddM_CustodianID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_CustodianID.Location = New System.Drawing.Point(43, 151)
        Me.SAAddM_CustodianID.Name = "SAAddM_CustodianID"
        Me.SAAddM_CustodianID.Size = New System.Drawing.Size(65, 18)
        Me.SAAddM_CustodianID.TabIndex = 60
        Me.SAAddM_CustodianID.Text = "Location"
        '
        'SAAddM_PropertyID
        '
        Me.SAAddM_PropertyID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_PropertyID.AutoSize = True
        Me.SAAddM_PropertyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_PropertyID.Location = New System.Drawing.Point(43, 98)
        Me.SAAddM_PropertyID.Name = "SAAddM_PropertyID"
        Me.SAAddM_PropertyID.Size = New System.Drawing.Size(102, 18)
        Me.SAAddM_PropertyID.TabIndex = 59
        Me.SAAddM_PropertyID.Text = "Serial Number"
        '
        'SAAddM_MainID
        '
        Me.SAAddM_MainID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_MainID.AutoSize = True
        Me.SAAddM_MainID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_MainID.Location = New System.Drawing.Point(43, 47)
        Me.SAAddM_MainID.Name = "SAAddM_MainID"
        Me.SAAddM_MainID.Size = New System.Drawing.Size(148, 18)
        Me.SAAddM_MainID.TabIndex = 58
        Me.SAAddM_MainID.Text = "Property / Item Name"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(32, 100)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1261, 71)
        Me.RoundedPanel1.TabIndex = 170
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(19, 25)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(267, 18)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required department information."
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(45, 39)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(395, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 66
        Me.admin_label_DepartmentManagement.Text = "Maintenance Work Form"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(945, 703)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 173
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
        Me.btnSave.Location = New System.Drawing.Point(1097, 703)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 172
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddMaintenance1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AddMaintenance1"
        Me.Size = New System.Drawing.Size(1317, 786)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SAAddM_Providercontact As System.Windows.Forms.Label
    Friend WithEvents SAAddM_NextSched As System.Windows.Forms.Label
    Friend WithEvents SAAddM_Warranty As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend Shadows WithEvents location As System.Windows.Forms.ComboBox
    Friend WithEvents conditionBeforeMaint As System.Windows.Forms.ComboBox
    Friend WithEvents serialNumber As System.Windows.Forms.TextBox
    Friend WithEvents propertyItemName As System.Windows.Forms.TextBox
    Friend WithEvents SAAddM_Description As System.Windows.Forms.Label
    Friend WithEvents SAAddM_ServiceType As System.Windows.Forms.Label
    Friend WithEvents SAAddM_ServiceDate As System.Windows.Forms.Label
    Friend WithEvents SAAddM_CustodianID As System.Windows.Forms.Label
    Friend WithEvents SAAddM_PropertyID As System.Windows.Forms.Label
    Friend WithEvents SAAddM_MainID As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents typeOfMaintenance As System.Windows.Forms.ComboBox
    Friend WithEvents departmentId As System.Windows.Forms.ComboBox
    Friend WithEvents conditionAfterMaint As System.Windows.Forms.ComboBox
    Friend WithEvents costMaterialsLabor As System.Windows.Forms.TextBox
    Friend WithEvents maintenanceDetails As System.Windows.Forms.ComboBox
    Friend WithEvents assignedTechnician As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents maintenanceDate As System.Windows.Forms.DateTimePicker
End Class
