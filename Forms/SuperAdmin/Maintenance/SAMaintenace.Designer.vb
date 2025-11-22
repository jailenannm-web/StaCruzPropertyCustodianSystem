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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.combostatus = New System.Windows.Forms.ComboBox()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatus.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUserManagement
        '
        Me.lblUserManagement.AutoSize = True
        Me.lblUserManagement.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold)
        Me.lblUserManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblUserManagement.Location = New System.Drawing.Point(147, 74)
        Me.lblUserManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserManagement.Name = "lblUserManagement"
        Me.lblUserManagement.Size = New System.Drawing.Size(226, 58)
        Me.lblUserManagement.TabIndex = 41
        Me.lblUserManagement.Text = "Maintenace"
        '
        'DataGridView1
        '
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaintenanceID, Me.PropertyID, Me.CustodianID, Me.ServiceDate, Me.ServiceType, Me.Description, Me.ServiceProvider, Me.ProviderContact, Me.Cost, Me.NextSchedule, Me.WarrantyStatus, Me.TechnicianAssigned, Me.Status, Me.Remarks, Me.CreatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(148, 215)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1372, 856)
        Me.DataGridView1.TabIndex = 42
        '
        'MaintenanceID
        '
        Me.MaintenanceID.HeaderText = "MaintenanceID"
        Me.MaintenanceID.MinimumWidth = 6
        Me.MaintenanceID.Name = "MaintenanceID"
        Me.MaintenanceID.Width = 125
        '
        'PropertyID
        '
        Me.PropertyID.HeaderText = "PropertyID"
        Me.PropertyID.MinimumWidth = 6
        Me.PropertyID.Name = "PropertyID"
        Me.PropertyID.Width = 125
        '
        'CustodianID
        '
        Me.CustodianID.HeaderText = "CustodianID"
        Me.CustodianID.MinimumWidth = 6
        Me.CustodianID.Name = "CustodianID"
        Me.CustodianID.Width = 125
        '
        'ServiceDate
        '
        Me.ServiceDate.HeaderText = "Service Date"
        Me.ServiceDate.MinimumWidth = 6
        Me.ServiceDate.Name = "ServiceDate"
        Me.ServiceDate.Width = 125
        '
        'ServiceType
        '
        Me.ServiceType.HeaderText = "Service Type"
        Me.ServiceType.MinimumWidth = 6
        Me.ServiceType.Name = "ServiceType"
        Me.ServiceType.Width = 125
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 125
        '
        'ServiceProvider
        '
        Me.ServiceProvider.HeaderText = "Service Provider"
        Me.ServiceProvider.MinimumWidth = 6
        Me.ServiceProvider.Name = "ServiceProvider"
        Me.ServiceProvider.Width = 125
        '
        'ProviderContact
        '
        Me.ProviderContact.HeaderText = "Provider Contact"
        Me.ProviderContact.MinimumWidth = 6
        Me.ProviderContact.Name = "ProviderContact"
        Me.ProviderContact.Width = 125
        '
        'Cost
        '
        Me.Cost.HeaderText = "Cost"
        Me.Cost.MinimumWidth = 6
        Me.Cost.Name = "Cost"
        Me.Cost.Width = 125
        '
        'NextSchedule
        '
        Me.NextSchedule.HeaderText = "Next Schedule"
        Me.NextSchedule.MinimumWidth = 6
        Me.NextSchedule.Name = "NextSchedule"
        Me.NextSchedule.Width = 125
        '
        'WarrantyStatus
        '
        Me.WarrantyStatus.HeaderText = "Warranty Status"
        Me.WarrantyStatus.MinimumWidth = 6
        Me.WarrantyStatus.Name = "WarrantyStatus"
        Me.WarrantyStatus.Width = 125
        '
        'TechnicianAssigned
        '
        Me.TechnicianAssigned.HeaderText = "Technician Assigned"
        Me.TechnicianAssigned.MinimumWidth = 6
        Me.TechnicianAssigned.Name = "TechnicianAssigned"
        Me.TechnicianAssigned.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status "
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MinimumWidth = 6
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 125
        '
        'CreatedAt
        '
        Me.CreatedAt.HeaderText = "Created At"
        Me.CreatedAt.MinimumWidth = 6
        Me.CreatedAt.Name = "CreatedAt"
        Me.CreatedAt.Width = 125
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(143, 141)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 164
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(203, 141)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(729, 41)
        Me.TextBox1.TabIndex = 163
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label2.Location = New System.Drawing.Point(1253, 151)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 30)
        Me.Label2.TabIndex = 162
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label1.Location = New System.Drawing.Point(945, 153)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 30)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Categories"
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.combostatus)
        Me.pnlStatus.CornerRadius = 5
        Me.pnlStatus.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlStatus.Location = New System.Drawing.Point(1321, 144)
        Me.pnlStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(177, 37)
        Me.pnlStatus.TabIndex = 160
        '
        'combostatus
        '
        Me.combostatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.combostatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.combostatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FormattingEnabled = True
        Me.combostatus.Location = New System.Drawing.Point(16, 7)
        Me.combostatus.Margin = New System.Windows.Forms.Padding(4)
        Me.combostatus.Name = "combostatus"
        Me.combostatus.Size = New System.Drawing.Size(144, 23)
        Me.combostatus.TabIndex = 1
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 5
        Me.pnlCategories.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlCategories.Location = New System.Drawing.Point(1053, 146)
        Me.pnlCategories.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(177, 37)
        Me.pnlCategories.TabIndex = 159
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(19, 7)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(144, 23)
        Me.comboCategoris.TabIndex = 0
        '
        'SAMaintenace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1637, 1222)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblUserManagement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "SAMaintenace"
        Me.Text = "SAMaintenace"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlCategories.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlStatus As Resources.Controls.RoundedPanel
    Friend WithEvents combostatus As System.Windows.Forms.ComboBox
    Friend WithEvents pnlCategories As Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As System.Windows.Forms.ComboBox
End Class
