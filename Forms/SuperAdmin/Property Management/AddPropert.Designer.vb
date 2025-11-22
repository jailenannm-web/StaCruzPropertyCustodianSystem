<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddPropert
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.cb_Barangay = New System.Windows.Forms.ComboBox()
        Me.cb_Municipality = New System.Windows.Forms.ComboBox()
        Me.txb_Disposal = New System.Windows.Forms.TextBox()
        Me.cb_Province = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_Position = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txb_ContactNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txb_EmployeeID = New System.Windows.Forms.TextBox()
        Me.txb_FirstName = New System.Windows.Forms.TextBox()
        Me.txb_HouseNoStreet = New System.Windows.Forms.TextBox()
        Me.txb_MiddleName = New System.Windows.Forms.TextBox()
        Me.txb_UserName = New System.Windows.Forms.TextBox()
        Me.txb_LastName = New System.Windows.Forms.TextBox()
        Me.txb_Email = New System.Windows.Forms.TextBox()
        Me.txb_Suffix = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txb_DepartmentID = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txb_UpdateAt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.cb_Barangay.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Barangay.FormattingEnabled = True
        Me.cb_Barangay.Items.AddRange(New Object() {"Binanuaan", "Caawigan", "Cahabaan", "Calintaan", "Del Carmen", "Gabon", "Itomang", "Poblacion", "San Francisco", "San Isidro", "San Jose", "San Nicolas", "Santa Cruz", "Santa Elena", "Santo Niño"})
        Me.cb_Barangay.Location = New System.Drawing.Point(1107, 447)
        Me.cb_Barangay.Name = "cb_Barangay"
        Me.cb_Barangay.Size = New System.Drawing.Size(337, 36)
        Me.cb_Barangay.TabIndex = 79
        '
        'admin_label_DepartmentManagement
        '
        Me.cb_Municipality.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Municipality.FormattingEnabled = True
        Me.cb_Municipality.Items.AddRange(New Object() {"Daet", "Basud", "Capalonga", "Jose Panganiban", "Labo", "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente", "Santa Elena", "Talisay", "Vinzons"})
        Me.cb_Municipality.Location = New System.Drawing.Point(1107, 357)
        Me.cb_Municipality.Name = "cb_Municipality"
        Me.cb_Municipality.Size = New System.Drawing.Size(337, 36)
        Me.cb_Municipality.TabIndex = 78
        '
        'txb_Disposal
        '
        Me.txb_Disposal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Disposal.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Disposal.Location = New System.Drawing.Point(1107, 614)
        Me.txb_Disposal.Multiline = True
        Me.txb_Disposal.Name = "txb_Disposal"
        Me.txb_Disposal.Size = New System.Drawing.Size(337, 34)
        Me.txb_Disposal.TabIndex = 73
        '
        'cb_Province
        '
        Me.cb_Province.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Province.FormattingEnabled = True
        Me.cb_Province.Items.AddRange(New Object() {"Albay", "Camarines Norte", "Camarines Sur", "Catanduanes", "Masbate", "Sorsogon"})
        Me.cb_Province.Location = New System.Drawing.Point(1107, 270)
        Me.cb_Province.Name = "cb_Province"
        Me.cb_Province.Size = New System.Drawing.Size(337, 36)
        Me.cb_Province.TabIndex = 77
        '
        'RoundedPanel1
        '
        Me.Label1.Font = New System.Drawing.Font("Poppins", 41.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(593, -17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(472, 82)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Add Property"
        '
        'Panel1
        '
        Me.cb_Position.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Position.FormattingEnabled = True
        Me.cb_Position.Items.AddRange(New Object() {"Super Admin", "Admin", "Staff"})
        Me.cb_Position.Location = New System.Drawing.Point(290, 432)
        Me.cb_Position.Name = "cb_Position"
        Me.cb_Position.Size = New System.Drawing.Size(346, 36)
        Me.cb_Position.TabIndex = 76
        '
        'categoryCmbo
        '
        Me.Label2.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(72, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 34)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Property I.D"
        '
        'conditionStatusCmbo
        '
        Me.txb_ContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ContactNumber.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ContactNumber.Location = New System.Drawing.Point(290, 687)
        Me.txb_ContactNumber.Multiline = True
        Me.txb_ContactNumber.Name = "txb_ContactNumber"
        Me.txb_ContactNumber.Size = New System.Drawing.Size(346, 34)
        Me.txb_ContactNumber.TabIndex = 75
        '
        'no_of_employees_numeric
        '
        Me.Label3.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(72, 434)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 34)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Serial Number"
        '
        'supplierTxt
        '
        Me.Label16.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(72, 687)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(218, 34)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Supplier"
        '
        'serialNumberTxt
        '
        Me.Label4.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(72, 266)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 34)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Category"
        '
        'propertyNameTxt
        '
        Me.Label5.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(72, 520)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(227, 34)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Acquisition Date"
        '
        'cost
        '
        Me.Label11.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(894, 614)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 34)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "Disposal Date"
        '
        'conditionStatus
        '
        Me.Label6.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(72, 604)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(212, 34)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Acquisition Cost"
        '
        'supplier
        '
        Me.txb_EmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_EmployeeID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_EmployeeID.Location = New System.Drawing.Point(290, 604)
        Me.txb_EmployeeID.Multiline = True
        Me.txb_EmployeeID.Name = "txb_EmployeeID"
        Me.txb_EmployeeID.Size = New System.Drawing.Size(346, 34)
        Me.txb_EmployeeID.TabIndex = 71
        '
        'serialNumber
        '
        Me.txb_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_FirstName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_FirstName.Location = New System.Drawing.Point(290, 107)
        Me.txb_FirstName.Multiline = True
        Me.txb_FirstName.Name = "txb_FirstName"
        Me.txb_FirstName.Size = New System.Drawing.Size(346, 34)
        Me.txb_FirstName.TabIndex = 53
        '
        'property_Category
        '
        Me.txb_HouseNoStreet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_HouseNoStreet.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_HouseNoStreet.Location = New System.Drawing.Point(1107, 524)
        Me.txb_HouseNoStreet.Multiline = True
        Me.txb_HouseNoStreet.Name = "txb_HouseNoStreet"
        Me.txb_HouseNoStreet.Size = New System.Drawing.Size(337, 34)
        Me.txb_HouseNoStreet.TabIndex = 70
        '
        'property_name
        '
        Me.txb_MiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_MiddleName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_MiddleName.Location = New System.Drawing.Point(290, 180)
        Me.txb_MiddleName.Multiline = True
        Me.txb_MiddleName.Name = "txb_MiddleName"
        Me.txb_MiddleName.Size = New System.Drawing.Size(346, 34)
        Me.txb_MiddleName.TabIndex = 54
        '
        'txb_UserName
        '
        Me.txb_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_UserName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UserName.Location = New System.Drawing.Point(1107, 186)
        Me.txb_UserName.Multiline = True
        Me.txb_UserName.Name = "txb_UserName"
        Me.txb_UserName.Size = New System.Drawing.Size(337, 34)
        Me.txb_UserName.TabIndex = 69
        '
        'assignedDepartment
        '
        Me.txb_LastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_LastName.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_LastName.Location = New System.Drawing.Point(290, 266)
        Me.txb_LastName.Multiline = True
        Me.txb_LastName.Name = "txb_LastName"
        Me.txb_LastName.Size = New System.Drawing.Size(346, 34)
        Me.txb_LastName.TabIndex = 55
        '
        'location
        '
        Me.txb_Email.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Email.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Email.Location = New System.Drawing.Point(1107, 113)
        Me.txb_Email.Multiline = True
        Me.txb_Email.Name = "txb_Email"
        Me.txb_Email.Size = New System.Drawing.Size(337, 34)
        Me.txb_Email.TabIndex = 68
        '
        'remarks
        '
        Me.txb_Suffix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Suffix.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Suffix.Location = New System.Drawing.Point(290, 352)
        Me.txb_Suffix.Multiline = True
        Me.txb_Suffix.Name = "txb_Suffix"
        Me.txb_Suffix.Size = New System.Drawing.Size(346, 34)
        Me.txb_Suffix.TabIndex = 56
        '
        'remarks_txt
        '
        Me.Label9.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(894, 360)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(171, 34)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Warranty Details"
        '
        'RoundedPanel2
        '
        Me.Label7.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(72, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 34)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Property Name"
        '
        'Panel2
        '
        Me.Label10.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(894, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 34)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Location"
        '
        'datePurchasedDate
        '
        Me.Label8.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(72, 352)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 34)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Description"
        '
        'warrantyExpirationDate
        '
        Me.Label12.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(894, 530)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(219, 34)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Depreciation Value"
        '
        'assignedEmployeeTxt
        '
        Me.txb_DepartmentID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_DepartmentID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_DepartmentID.Location = New System.Drawing.Point(290, 520)
        Me.txb_DepartmentID.Multiline = True
        Me.txb_DepartmentID.Name = "txb_DepartmentID"
        Me.txb_DepartmentID.Size = New System.Drawing.Size(346, 34)
        Me.txb_DepartmentID.TabIndex = 59
        '
        'assignedDeparmentCmbo
        '
        Me.Label13.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(894, 272)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(207, 34)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Custodian I.D "
        '
        'propertyLocation
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(471, 825)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(191, 46)
        Me.btn_Cancel.TabIndex = 60
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'assignedEmployee
        '
        Me.Label14.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(894, 449)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 34)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Life Span"
        '
        'date_purchased
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(814, 825)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(190, 46)
        Me.btn_Login.TabIndex = 61
        Me.btn_Login.Text = "Add"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'warrantyExpiration
        '
        Me.Label15.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(894, 113)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(136, 34)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Condition Status"
        '
        'txb_UpdateAt
        '
        Me.txb_UpdateAt.BackColor = System.Drawing.Color.White
        Me.txb_UpdateAt.Font = New System.Drawing.Font("Poppins Light", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_UpdateAt.Location = New System.Drawing.Point(1342, 632)
        Me.txb_UpdateAt.Margin = New System.Windows.Forms.Padding(4)
        Me.txb_UpdateAt.Name = "txb_UpdateAt"
        Me.txb_UpdateAt.Size = New System.Drawing.Size(361, 42)
        Me.txb_UpdateAt.TabIndex = 86
        '
        'AddPropert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1516, 906)
        Me.Controls.Add(Me.cb_Barangay)
        Me.Controls.Add(Me.cb_Municipality)
        Me.Controls.Add(Me.txb_Disposal)
        Me.Controls.Add(Me.cb_Province)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb_Position)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txb_ContactNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txb_EmployeeID)
        Me.Controls.Add(Me.txb_FirstName)
        Me.Controls.Add(Me.txb_HouseNoStreet)
        Me.Controls.Add(Me.txb_MiddleName)
        Me.Controls.Add(Me.txb_UserName)
        Me.Controls.Add(Me.txb_LastName)
        Me.Controls.Add(Me.txb_Email)
        Me.Controls.Add(Me.txb_Suffix)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txb_DepartmentID)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txb_UpdateAt)
        Me.Name = "AddPropert"
        Me.Text = "AddPropert"
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.no_of_employees_numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cb_Barangay As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Municipality As System.Windows.Forms.ComboBox
    Friend WithEvents txb_Disposal As System.Windows.Forms.TextBox
    Friend WithEvents cb_Province As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_Position As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txb_ContactNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txb_EmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txb_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents txb_HouseNoStreet As System.Windows.Forms.TextBox
    Friend WithEvents txb_MiddleName As System.Windows.Forms.TextBox
    Friend WithEvents txb_UserName As System.Windows.Forms.TextBox
    Friend WithEvents txb_LastName As System.Windows.Forms.TextBox
    Friend WithEvents txb_Email As System.Windows.Forms.TextBox
    Friend WithEvents txb_Suffix As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txb_DepartmentID As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btn_Login As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txb_UpdateAt As System.Windows.Forms.TextBox
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents no_of_employees_numeric As System.Windows.Forms.NumericUpDown
End Class
