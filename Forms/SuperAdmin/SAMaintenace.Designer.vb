<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAMaintenace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAMaintenace))
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSuperAdmin = New System.Windows.Forms.Label()
        Me.btnSystemConfig = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.lblUserManagement = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MaintenanceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PropertyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustodianID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceProvider = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProviderContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NextSchedule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarrantyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TechnicianAssigned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSidebar.SuspendLayout
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnSystemConfig)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.Panel1)
        Me.pnlSidebar.Controls.Add(Me.lblSuperAdmin)
        Me.pnlSidebar.Controls.Add(Me.Button4)
        Me.pnlSidebar.CornerRadius = 20
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(267, 803)
        Me.pnlSidebar.TabIndex = 31
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(269, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1103, 749)
        Me.Panel1.TabIndex = 23
        '
        'lblSuperAdmin
        '
        Me.lblSuperAdmin.AutoSize = True
        Me.lblSuperAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblSuperAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuperAdmin.ForeColor = System.Drawing.Color.White
        Me.lblSuperAdmin.Location = New System.Drawing.Point(80, 118)
        Me.lblSuperAdmin.Name = "lblSuperAdmin"
        Me.lblSuperAdmin.Size = New System.Drawing.Size(90, 16)
        Me.lblSuperAdmin.TabIndex = 11
        Me.lblSuperAdmin.Text = "Superadmin"
        '
        'btnSystemConfig
        '
        Me.btnSystemConfig.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSystemConfig.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnSystemConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSystemConfig.FlatAppearance.BorderSize = 2
        Me.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSystemConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemConfig.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnSystemConfig.Image = CType(resources.GetObject("btnSystemConfig.Image"), System.Drawing.Image)
        Me.btnSystemConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSystemConfig.Location = New System.Drawing.Point(12, 609)
        Me.btnSystemConfig.Name = "btnSystemConfig"
        Me.btnSystemConfig.Size = New System.Drawing.Size(238, 51)
        Me.btnSystemConfig.TabIndex = 22
        Me.btnSystemConfig.Text = "System Configuration"
        Me.btnSystemConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemConfig.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnLogout.FlatAppearance.BorderSize = 2
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(12, 666)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(238, 51)
        Me.btnLogout.TabIndex = 22
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(74, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(97, 83)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(12, 552)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(238, 51)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Reports"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(12, 495)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(238, 51)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Maintenance Management"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button3.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(12, 438)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(238, 51)
        Me.Button3.TabIndex = 37
        Me.Button3.Text = "Property Request Management"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(12, 381)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(238, 51)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "Department Management"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button5.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button5.FlatAppearance.BorderSize = 2
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(12, 324)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(238, 51)
        Me.Button5.TabIndex = 35
        Me.Button5.Text = "Supplies Management"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button6.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button6.FlatAppearance.BorderSize = 2
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(12, 267)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(238, 51)
        Me.Button6.TabIndex = 34
        Me.Button6.Text = "Property Management"
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button7.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button7.FlatAppearance.BorderSize = 2
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(12, 210)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(238, 51)
        Me.Button7.TabIndex = 33
        Me.Button7.Text = "User Management"
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button8.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button8.FlatAppearance.BorderSize = 2
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(12, 153)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(238, 51)
        Me.Button8.TabIndex = 32
        Me.Button8.Text = "Dashboard"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'lblUserManagement
        '
        Me.lblUserManagement.AutoSize = True
        Me.lblUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserManagement.Location = New System.Drawing.Point(297, 41)
        Me.lblUserManagement.Name = "lblUserManagement"
        Me.lblUserManagement.Size = New System.Drawing.Size(164, 31)
        Me.lblUserManagement.TabIndex = 41
        Me.lblUserManagement.Text = "Maintenace"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaintenanceID, Me.PropertyID, Me.CustodianID, Me.ServiceDate, Me.ServiceType, Me.Description, Me.ServiceProvider, Me.ProviderContact, Me.Cost, Me.NextSchedule, Me.WarrantyStatus, Me.TechnicianAssigned, Me.Status, Me.Remarks, Me.CreatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(303, 179)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(848, 414)
        Me.DataGridView1.TabIndex = 42
        '
        'MaintenanceID
        '
        Me.MaintenanceID.HeaderText = "MaintenanceID"
        Me.MaintenanceID.Name = "MaintenanceID"
        '
        'PropertyID
        '
        Me.PropertyID.HeaderText = "PropertyID"
        Me.PropertyID.Name = "PropertyID"
        '
        'CustodianID
        '
        Me.CustodianID.HeaderText = "CustodianID"
        Me.CustodianID.Name = "CustodianID"
        '
        'ServiceDate
        '
        Me.ServiceDate.HeaderText = "Service Date"
        Me.ServiceDate.Name = "ServiceDate"
        '
        'ServiceType
        '
        Me.ServiceType.HeaderText = "Service Type"
        Me.ServiceType.Name = "ServiceType"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        '
        'ServiceProvider
        '
        Me.ServiceProvider.HeaderText = "Service Provider"
        Me.ServiceProvider.Name = "ServiceProvider"
        '
        'ProviderContact
        '
        Me.ProviderContact.HeaderText = "Provider Contact"
        Me.ProviderContact.Name = "ProviderContact"
        '
        'Cost
        '
        Me.Cost.HeaderText = "Cost"
        Me.Cost.Name = "Cost"
        '
        'NextSchedule
        '
        Me.NextSchedule.HeaderText = "Next Schedule"
        Me.NextSchedule.Name = "NextSchedule"
        '
        'WarrantyStatus
        '
        Me.WarrantyStatus.HeaderText = "Warranty Status"
        Me.WarrantyStatus.Name = "WarrantyStatus"
        '
        'TechnicianAssigned
        '
        Me.TechnicianAssigned.HeaderText = "Technician Assigned"
        Me.TechnicianAssigned.Name = "TechnicianAssigned"
        '
        'Status
        '
        Me.Status.HeaderText = "Status "
        Me.Status.Name = "Status"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'CreatedAt
        '
        Me.CreatedAt.HeaderText = "Created At"
        Me.CreatedAt.Name = "CreatedAt"
        '
        'SAMaintenace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 803)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblUserManagement)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.pnlSidebar)
        Me.MinimizeBox = False
        Me.Name = "SAMaintenace"
        Me.Text = "SAMaintenace"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSidebar As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents btnSystemConfig As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSuperAdmin As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents lblUserManagement As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MaintenanceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustodianID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceProvider As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProviderContact As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NextSchedule As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarrantyStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TechnicianAssigned As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
