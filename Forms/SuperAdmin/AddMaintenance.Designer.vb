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
        Me.txb_CreateAt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txb_ProviderContact = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txb_ServiceProvider = New System.Windows.Forms.TextBox()
        Me.txb_MaintenanceID = New System.Windows.Forms.TextBox()
        Me.txb_Remark = New System.Windows.Forms.TextBox()
        Me.txb_PropertyID = New System.Windows.Forms.TextBox()
        Me.txb_NextSchedule = New System.Windows.Forms.TextBox()
        Me.txb_CustodianID = New System.Windows.Forms.TextBox()
        Me.txb_Cost = New System.Windows.Forms.TextBox()
        Me.txb_ServiceDate = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txb_Description = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txb_WarrantyStatus = New System.Windows.Forms.TextBox()
        Me.txb_TechnicianAssigned = New System.Windows.Forms.TextBox()
        Me.txb_Status = New System.Windows.Forms.TextBox()
        Me.txb_ServiceType = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txb_CreateAt
        '
        Me.txb_CreateAt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_CreateAt.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_CreateAt.Location = New System.Drawing.Point(1353, 778)
        Me.txb_CreateAt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_CreateAt.Multiline = True
        Me.txb_CreateAt.Name = "txb_CreateAt"
        Me.txb_CreateAt.Size = New System.Drawing.Size(449, 42)
        Me.txb_CreateAt.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(208, 166)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(283, 42)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "MaintenanceID"
        '
        'txb_ProviderContact
        '
        Me.txb_ProviderContact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ProviderContact.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ProviderContact.Location = New System.Drawing.Point(499, 880)
        Me.txb_ProviderContact.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ProviderContact.Multiline = True
        Me.txb_ProviderContact.Name = "txb_ProviderContact"
        Me.txb_ProviderContact.Size = New System.Drawing.Size(461, 42)
        Me.txb_ProviderContact.TabIndex = 75
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(208, 569)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(245, 42)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Service Type"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(208, 880)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(291, 42)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Provider Contact"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(208, 362)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(245, 42)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "CustodianID"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(208, 674)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(283, 42)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Description"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(1069, 778)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 42)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "CreatedAt"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(208, 778)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(283, 42)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Service Provider"
        '
        'txb_ServiceProvider
        '
        Me.txb_ServiceProvider.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ServiceProvider.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ServiceProvider.Location = New System.Drawing.Point(499, 778)
        Me.txb_ServiceProvider.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ServiceProvider.Multiline = True
        Me.txb_ServiceProvider.Name = "txb_ServiceProvider"
        Me.txb_ServiceProvider.Size = New System.Drawing.Size(461, 42)
        Me.txb_ServiceProvider.TabIndex = 71
        '
        'txb_MaintenanceID
        '
        Me.txb_MaintenanceID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_MaintenanceID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_MaintenanceID.Location = New System.Drawing.Point(499, 166)
        Me.txb_MaintenanceID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_MaintenanceID.Multiline = True
        Me.txb_MaintenanceID.Name = "txb_MaintenanceID"
        Me.txb_MaintenanceID.Size = New System.Drawing.Size(461, 42)
        Me.txb_MaintenanceID.TabIndex = 53
        '
        'txb_Remark
        '
        Me.txb_Remark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Remark.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Remark.Location = New System.Drawing.Point(1353, 667)
        Me.txb_Remark.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Remark.Multiline = True
        Me.txb_Remark.Name = "txb_Remark"
        Me.txb_Remark.Size = New System.Drawing.Size(449, 42)
        Me.txb_Remark.TabIndex = 70
        '
        'txb_PropertyID
        '
        Me.txb_PropertyID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_PropertyID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_PropertyID.Location = New System.Drawing.Point(499, 256)
        Me.txb_PropertyID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_PropertyID.Multiline = True
        Me.txb_PropertyID.Name = "txb_PropertyID"
        Me.txb_PropertyID.Size = New System.Drawing.Size(461, 42)
        Me.txb_PropertyID.TabIndex = 54
        '
        'txb_NextSchedule
        '
        Me.txb_NextSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_NextSchedule.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_NextSchedule.Location = New System.Drawing.Point(1353, 251)
        Me.txb_NextSchedule.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_NextSchedule.Multiline = True
        Me.txb_NextSchedule.Name = "txb_NextSchedule"
        Me.txb_NextSchedule.Size = New System.Drawing.Size(449, 42)
        Me.txb_NextSchedule.TabIndex = 69
        '
        'txb_CustodianID
        '
        Me.txb_CustodianID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_CustodianID.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_CustodianID.Location = New System.Drawing.Point(499, 362)
        Me.txb_CustodianID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_CustodianID.Multiline = True
        Me.txb_CustodianID.Name = "txb_CustodianID"
        Me.txb_CustodianID.Size = New System.Drawing.Size(461, 42)
        Me.txb_CustodianID.TabIndex = 55
        '
        'txb_Cost
        '
        Me.txb_Cost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Cost.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Cost.Location = New System.Drawing.Point(1353, 161)
        Me.txb_Cost.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Cost.Multiline = True
        Me.txb_Cost.Name = "txb_Cost"
        Me.txb_Cost.Size = New System.Drawing.Size(449, 42)
        Me.txb_Cost.TabIndex = 68
        '
        'txb_ServiceDate
        '
        Me.txb_ServiceDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ServiceDate.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ServiceDate.Location = New System.Drawing.Point(499, 468)
        Me.txb_ServiceDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ServiceDate.Multiline = True
        Me.txb_ServiceDate.Name = "txb_ServiceDate"
        Me.txb_ServiceDate.Size = New System.Drawing.Size(461, 42)
        Me.txb_ServiceDate.TabIndex = 56
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(1069, 465)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(228, 42)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Technician"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(208, 256)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(260, 42)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "PropertyID"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1080, 251)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(265, 42)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Next Schedule"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(208, 468)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(245, 42)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Service Date"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1069, 674)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(292, 42)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Remarks"
        '
        'txb_Description
        '
        Me.txb_Description.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Description.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Description.Location = New System.Drawing.Point(499, 674)
        Me.txb_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Description.Multiline = True
        Me.txb_Description.Name = "txb_Description"
        Me.txb_Description.Size = New System.Drawing.Size(461, 42)
        Me.txb_Description.TabIndex = 59
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(1069, 357)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(276, 42)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Warranty Status"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(740, 1050)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(255, 57)
        Me.btn_Cancel.TabIndex = 60
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(1069, 575)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(181, 42)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Status "
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(1197, 1050)
        Me.btn_Login.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(253, 57)
        Me.btn_Login.TabIndex = 61
        Me.btn_Login.Text = "Add"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Poppins", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(1080, 161)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(200, 42)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Cost"
        '
        'txb_WarrantyStatus
        '
        Me.txb_WarrantyStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_WarrantyStatus.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_WarrantyStatus.Location = New System.Drawing.Point(1353, 357)
        Me.txb_WarrantyStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_WarrantyStatus.Multiline = True
        Me.txb_WarrantyStatus.Name = "txb_WarrantyStatus"
        Me.txb_WarrantyStatus.Size = New System.Drawing.Size(449, 42)
        Me.txb_WarrantyStatus.TabIndex = 77
        '
        'txb_TechnicianAssigned
        '
        Me.txb_TechnicianAssigned.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_TechnicianAssigned.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_TechnicianAssigned.Location = New System.Drawing.Point(1353, 465)
        Me.txb_TechnicianAssigned.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_TechnicianAssigned.Multiline = True
        Me.txb_TechnicianAssigned.Name = "txb_TechnicianAssigned"
        Me.txb_TechnicianAssigned.Size = New System.Drawing.Size(449, 42)
        Me.txb_TechnicianAssigned.TabIndex = 78
        '
        'txb_Status
        '
        Me.txb_Status.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Status.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Status.Location = New System.Drawing.Point(1353, 569)
        Me.txb_Status.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_Status.Multiline = True
        Me.txb_Status.Name = "txb_Status"
        Me.txb_Status.Size = New System.Drawing.Size(449, 42)
        Me.txb_Status.TabIndex = 79
        '
        'txb_ServiceType
        '
        Me.txb_ServiceType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_ServiceType.Font = New System.Drawing.Font("Poppins Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_ServiceType.Location = New System.Drawing.Point(499, 569)
        Me.txb_ServiceType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txb_ServiceType.Multiline = True
        Me.txb_ServiceType.Name = "txb_ServiceType"
        Me.txb_ServiceType.Size = New System.Drawing.Size(461, 42)
        Me.txb_ServiceType.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(790, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(392, 61)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Add Maintenance"
        '
        'AddMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1175)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txb_ServiceType)
        Me.Controls.Add(Me.txb_Status)
        Me.Controls.Add(Me.txb_TechnicianAssigned)
        Me.Controls.Add(Me.txb_WarrantyStatus)
        Me.Controls.Add(Me.txb_CreateAt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txb_ProviderContact)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txb_ServiceProvider)
        Me.Controls.Add(Me.txb_MaintenanceID)
        Me.Controls.Add(Me.txb_Remark)
        Me.Controls.Add(Me.txb_PropertyID)
        Me.Controls.Add(Me.txb_NextSchedule)
        Me.Controls.Add(Me.txb_CustodianID)
        Me.Controls.Add(Me.txb_Cost)
        Me.Controls.Add(Me.txb_ServiceDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txb_Description)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.Label15)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AddMaintenance"
        Me.Text = "AddMaintenance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txb_CreateAt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txb_ProviderContact As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txb_ServiceProvider As System.Windows.Forms.TextBox
    Friend WithEvents txb_MaintenanceID As System.Windows.Forms.TextBox
    Friend WithEvents txb_Remark As System.Windows.Forms.TextBox
    Friend WithEvents txb_PropertyID As System.Windows.Forms.TextBox
    Friend WithEvents txb_NextSchedule As System.Windows.Forms.TextBox
    Friend WithEvents txb_CustodianID As System.Windows.Forms.TextBox
    Friend WithEvents txb_Cost As System.Windows.Forms.TextBox
    Friend WithEvents txb_ServiceDate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txb_Description As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btn_Login As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txb_WarrantyStatus As System.Windows.Forms.TextBox
    Friend WithEvents txb_TechnicianAssigned As System.Windows.Forms.TextBox
    Friend WithEvents txb_Status As System.Windows.Forms.TextBox
    Friend WithEvents txb_ServiceType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
