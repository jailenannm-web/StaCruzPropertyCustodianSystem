<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMaintenance
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
        Me.categoryCmbo = New System.Windows.Forms.ComboBox()
        Me.conditionStatusCmbo = New System.Windows.Forms.ComboBox()
        Me.no_of_employees_numeric = New System.Windows.Forms.NumericUpDown()
        Me.supplierTxt = New System.Windows.Forms.TextBox()
        Me.datePurchasedDate = New System.Windows.Forms.DateTimePicker()
        Me.assignedEmployeeTxt = New System.Windows.Forms.TextBox()
        Me.propertyNameTxt = New System.Windows.Forms.TextBox()
        Me.SAAddM_Description = New System.Windows.Forms.Label()
        Me.SAAddM_ServiceType = New System.Windows.Forms.Label()
        Me.assignedDeparmentCmbo = New System.Windows.Forms.ComboBox()
        Me.propertyLocation = New System.Windows.Forms.TextBox()
        Me.SAAddM_Cost = New System.Windows.Forms.Label()
        Me.SAAddM_ServiceProvided = New System.Windows.Forms.Label()
        Me.SAAddM_Providercontact = New System.Windows.Forms.Label()
        Me.serialNumberTxt = New System.Windows.Forms.TextBox()
        Me.SAAddM_ServiceDate = New System.Windows.Forms.Label()
        Me.SAAddM_CustodianID = New System.Windows.Forms.Label()
        Me.SAAddM_MainID = New System.Windows.Forms.Label()
        Me.SAAddM_NextSched = New System.Windows.Forms.Label()
        Me.SAAddM_Warranty = New System.Windows.Forms.Label()
        Me.SAAddM_PropertyID = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.SAAddM_lblMaintenance = New System.Windows.Forms.Label()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'categoryCmbo
        '
        Me.categoryCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.categoryCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryCmbo.FormattingEnabled = True
        Me.categoryCmbo.Location = New System.Drawing.Point(256, 95)
        Me.categoryCmbo.Name = "categoryCmbo"
        Me.categoryCmbo.Size = New System.Drawing.Size(664, 34)
        Me.categoryCmbo.TabIndex = 71
        '
        'conditionStatusCmbo
        '
        Me.conditionStatusCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.conditionStatusCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conditionStatusCmbo.FormattingEnabled = True
        Me.conditionStatusCmbo.Location = New System.Drawing.Point(256, 248)
        Me.conditionStatusCmbo.Name = "conditionStatusCmbo"
        Me.conditionStatusCmbo.Size = New System.Drawing.Size(664, 34)
        Me.conditionStatusCmbo.TabIndex = 70
        '
        'no_of_employees_numeric
        '
        Me.no_of_employees_numeric.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.no_of_employees_numeric.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.no_of_employees_numeric.Location = New System.Drawing.Point(256, 309)
        Me.no_of_employees_numeric.Name = "no_of_employees_numeric"
        Me.no_of_employees_numeric.Size = New System.Drawing.Size(664, 30)
        Me.no_of_employees_numeric.TabIndex = 69
        '
        'supplierTxt
        '
        Me.supplierTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplierTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierTxt.Location = New System.Drawing.Point(242, 94)
        Me.supplierTxt.Name = "supplierTxt"
        Me.supplierTxt.Size = New System.Drawing.Size(542, 30)
        Me.supplierTxt.TabIndex = 67
        '
        'datePurchasedDate
        '
        Me.datePurchasedDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.datePurchasedDate.Location = New System.Drawing.Point(256, 197)
        Me.datePurchasedDate.Name = "datePurchasedDate"
        Me.datePurchasedDate.Size = New System.Drawing.Size(441, 30)
        Me.datePurchasedDate.TabIndex = 68
        '
        'assignedEmployeeTxt
        '
        Me.assignedEmployeeTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedEmployeeTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedEmployeeTxt.Location = New System.Drawing.Point(242, 147)
        Me.assignedEmployeeTxt.Name = "assignedEmployeeTxt"
        Me.assignedEmployeeTxt.Size = New System.Drawing.Size(542, 30)
        Me.assignedEmployeeTxt.TabIndex = 66
        '
        'propertyNameTxt
        '
        Me.propertyNameTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyNameTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyNameTxt.Location = New System.Drawing.Point(256, 44)
        Me.propertyNameTxt.Name = "propertyNameTxt"
        Me.propertyNameTxt.Size = New System.Drawing.Size(664, 30)
        Me.propertyNameTxt.TabIndex = 64
        '
        'SAAddM_Description
        '
        Me.SAAddM_Description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Description.AutoSize = True
        Me.SAAddM_Description.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Description.Location = New System.Drawing.Point(42, 313)
        Me.SAAddM_Description.Name = "SAAddM_Description"
        Me.SAAddM_Description.Size = New System.Drawing.Size(98, 26)
        Me.SAAddM_Description.TabIndex = 63
        Me.SAAddM_Description.Text = "Description"
        '
        'SAAddM_ServiceType
        '
        Me.SAAddM_ServiceType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceType.AutoSize = True
        Me.SAAddM_ServiceType.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceType.Location = New System.Drawing.Point(42, 256)
        Me.SAAddM_ServiceType.Name = "SAAddM_ServiceType"
        Me.SAAddM_ServiceType.Size = New System.Drawing.Size(105, 26)
        Me.SAAddM_ServiceType.TabIndex = 62
        Me.SAAddM_ServiceType.Text = "Service Type"
        '
        'assignedDeparmentCmbo
        '
        Me.assignedDeparmentCmbo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedDeparmentCmbo.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignedDeparmentCmbo.FormattingEnabled = True
        Me.assignedDeparmentCmbo.Location = New System.Drawing.Point(242, 201)
        Me.assignedDeparmentCmbo.Name = "assignedDeparmentCmbo"
        Me.assignedDeparmentCmbo.Size = New System.Drawing.Size(542, 34)
        Me.assignedDeparmentCmbo.TabIndex = 65
        '
        'propertyLocation
        '
        Me.propertyLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyLocation.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyLocation.Location = New System.Drawing.Point(242, 252)
        Me.propertyLocation.Name = "propertyLocation"
        Me.propertyLocation.Size = New System.Drawing.Size(542, 30)
        Me.propertyLocation.TabIndex = 64
        '
        'SAAddM_Cost
        '
        Me.SAAddM_Cost.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Cost.AutoSize = True
        Me.SAAddM_Cost.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Cost.Location = New System.Drawing.Point(44, 151)
        Me.SAAddM_Cost.Name = "SAAddM_Cost"
        Me.SAAddM_Cost.Size = New System.Drawing.Size(47, 26)
        Me.SAAddM_Cost.TabIndex = 48
        Me.SAAddM_Cost.Text = "Cost"
        '
        'SAAddM_ServiceProvided
        '
        Me.SAAddM_ServiceProvided.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceProvided.AutoSize = True
        Me.SAAddM_ServiceProvided.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceProvided.Location = New System.Drawing.Point(44, 47)
        Me.SAAddM_ServiceProvided.Name = "SAAddM_ServiceProvided"
        Me.SAAddM_ServiceProvided.Size = New System.Drawing.Size(136, 26)
        Me.SAAddM_ServiceProvided.TabIndex = 46
        Me.SAAddM_ServiceProvided.Text = "Service Provided"
        '
        'SAAddM_Providercontact
        '
        Me.SAAddM_Providercontact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Providercontact.AutoSize = True
        Me.SAAddM_Providercontact.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Providercontact.Location = New System.Drawing.Point(44, 98)
        Me.SAAddM_Providercontact.Name = "SAAddM_Providercontact"
        Me.SAAddM_Providercontact.Size = New System.Drawing.Size(139, 26)
        Me.SAAddM_Providercontact.TabIndex = 47
        Me.SAAddM_Providercontact.Text = "Provider Contact"
        '
        'serialNumberTxt
        '
        Me.serialNumberTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serialNumberTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialNumberTxt.Location = New System.Drawing.Point(256, 147)
        Me.serialNumberTxt.Name = "serialNumberTxt"
        Me.serialNumberTxt.Size = New System.Drawing.Size(664, 30)
        Me.serialNumberTxt.TabIndex = 66
        '
        'SAAddM_ServiceDate
        '
        Me.SAAddM_ServiceDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_ServiceDate.AutoSize = True
        Me.SAAddM_ServiceDate.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_ServiceDate.Location = New System.Drawing.Point(42, 201)
        Me.SAAddM_ServiceDate.Name = "SAAddM_ServiceDate"
        Me.SAAddM_ServiceDate.Size = New System.Drawing.Size(105, 26)
        Me.SAAddM_ServiceDate.TabIndex = 61
        Me.SAAddM_ServiceDate.Text = "Service Date"
        '
        'SAAddM_CustodianID
        '
        Me.SAAddM_CustodianID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_CustodianID.AutoSize = True
        Me.SAAddM_CustodianID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_CustodianID.Location = New System.Drawing.Point(42, 151)
        Me.SAAddM_CustodianID.Name = "SAAddM_CustodianID"
        Me.SAAddM_CustodianID.Size = New System.Drawing.Size(110, 26)
        Me.SAAddM_CustodianID.TabIndex = 60
        Me.SAAddM_CustodianID.Text = "Custodian ID"
        '
        'SAAddM_MainID
        '
        Me.SAAddM_MainID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_MainID.AutoSize = True
        Me.SAAddM_MainID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_MainID.Location = New System.Drawing.Point(42, 47)
        Me.SAAddM_MainID.Name = "SAAddM_MainID"
        Me.SAAddM_MainID.Size = New System.Drawing.Size(130, 26)
        Me.SAAddM_MainID.TabIndex = 58
        Me.SAAddM_MainID.Text = "Maintenance ID"
        '
        'SAAddM_NextSched
        '
        Me.SAAddM_NextSched.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_NextSched.AutoSize = True
        Me.SAAddM_NextSched.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_NextSched.Location = New System.Drawing.Point(44, 204)
        Me.SAAddM_NextSched.Name = "SAAddM_NextSched"
        Me.SAAddM_NextSched.Size = New System.Drawing.Size(118, 26)
        Me.SAAddM_NextSched.TabIndex = 49
        Me.SAAddM_NextSched.Text = "Next Schedule"
        '
        'SAAddM_Warranty
        '
        Me.SAAddM_Warranty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_Warranty.AutoSize = True
        Me.SAAddM_Warranty.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_Warranty.Location = New System.Drawing.Point(44, 256)
        Me.SAAddM_Warranty.Name = "SAAddM_Warranty"
        Me.SAAddM_Warranty.Size = New System.Drawing.Size(82, 26)
        Me.SAAddM_Warranty.TabIndex = 50
        Me.SAAddM_Warranty.Text = "Warranty"
        '
        'SAAddM_PropertyID
        '
        Me.SAAddM_PropertyID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SAAddM_PropertyID.AutoSize = True
        Me.SAAddM_PropertyID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_PropertyID.Location = New System.Drawing.Point(42, 98)
        Me.SAAddM_PropertyID.Name = "SAAddM_PropertyID"
        Me.SAAddM_PropertyID.Size = New System.Drawing.Size(94, 26)
        Me.SAAddM_PropertyID.TabIndex = 59
        Me.SAAddM_PropertyID.Text = "Property ID"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.assignedEmployeeTxt)
        Me.Panel2.Controls.Add(Me.supplierTxt)
        Me.Panel2.Controls.Add(Me.assignedDeparmentCmbo)
        Me.Panel2.Controls.Add(Me.propertyLocation)
        Me.Panel2.Controls.Add(Me.SAAddM_Cost)
        Me.Panel2.Controls.Add(Me.SAAddM_ServiceProvided)
        Me.Panel2.Controls.Add(Me.SAAddM_Providercontact)
        Me.Panel2.Controls.Add(Me.SAAddM_NextSched)
        Me.Panel2.Controls.Add(Me.SAAddM_Warranty)
        Me.Panel2.Location = New System.Drawing.Point(740, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(841, 382)
        Me.Panel2.TabIndex = 65
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(242, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(542, 30)
        Me.TextBox1.TabIndex = 68
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(141, 317)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1653, 425)
        Me.RoundedPanel2.TabIndex = 168
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.datePurchasedDate)
        Me.Panel1.Controls.Add(Me.categoryCmbo)
        Me.Panel1.Controls.Add(Me.conditionStatusCmbo)
        Me.Panel1.Controls.Add(Me.no_of_employees_numeric)
        Me.Panel1.Controls.Add(Me.serialNumberTxt)
        Me.Panel1.Controls.Add(Me.propertyNameTxt)
        Me.Panel1.Controls.Add(Me.SAAddM_Description)
        Me.Panel1.Controls.Add(Me.SAAddM_ServiceType)
        Me.Panel1.Controls.Add(Me.SAAddM_ServiceDate)
        Me.Panel1.Controls.Add(Me.SAAddM_CustodianID)
        Me.Panel1.Controls.Add(Me.SAAddM_PropertyID)
        Me.Panel1.Controls.Add(Me.SAAddM_MainID)
        Me.Panel1.Location = New System.Drawing.Point(46, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(963, 382)
        Me.Panel1.TabIndex = 64
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(18, 24)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(317, 26)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required department information."
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1496, 977)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 170
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1649, 977)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 169
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(141, 225)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1653, 72)
        Me.RoundedPanel1.TabIndex = 167
        '
        'SAAddM_lblMaintenance
        '
        Me.SAAddM_lblMaintenance.AutoSize = True
        Me.SAAddM_lblMaintenance.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SAAddM_lblMaintenance.Location = New System.Drawing.Point(131, 164)
        Me.SAAddM_lblMaintenance.Name = "SAAddM_lblMaintenance"
        Me.SAAddM_lblMaintenance.Size = New System.Drawing.Size(254, 58)
        Me.SAAddM_lblMaintenance.TabIndex = 166
        Me.SAAddM_lblMaintenance.Text = "Maintenance"
        '
        'AddMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1175)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.SAAddM_lblMaintenance)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AddMaintenance"
        Me.Text = "AddMaintenance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents categoryCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents conditionStatusCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents no_of_employees_numeric As System.Windows.Forms.NumericUpDown
    Friend WithEvents supplierTxt As System.Windows.Forms.TextBox
    Friend WithEvents datePurchasedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents assignedEmployeeTxt As System.Windows.Forms.TextBox
    Friend WithEvents propertyNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents SAAddM_Description As System.Windows.Forms.Label
    Friend WithEvents SAAddM_ServiceType As System.Windows.Forms.Label
    Friend WithEvents assignedDeparmentCmbo As System.Windows.Forms.ComboBox
    Friend WithEvents propertyLocation As System.Windows.Forms.TextBox
    Friend WithEvents SAAddM_Cost As System.Windows.Forms.Label
    Friend WithEvents SAAddM_ServiceProvided As System.Windows.Forms.Label
    Friend WithEvents SAAddM_Providercontact As System.Windows.Forms.Label
    Friend WithEvents serialNumberTxt As System.Windows.Forms.TextBox
    Friend WithEvents SAAddM_ServiceDate As System.Windows.Forms.Label
    Friend WithEvents SAAddM_CustodianID As System.Windows.Forms.Label
    Friend WithEvents SAAddM_MainID As System.Windows.Forms.Label
    Friend WithEvents SAAddM_NextSched As System.Windows.Forms.Label
    Friend WithEvents SAAddM_Warranty As System.Windows.Forms.Label
    Friend WithEvents SAAddM_PropertyID As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents SAAddM_lblMaintenance As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
