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
        Me.CreatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TechnicianAssigned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarrantyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NextSchedule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProviderContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceProvider = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustodianID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PropertyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaintenanceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUserManagement
        '
        Me.lblUserManagement.AutoSize = True
        Me.lblUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserManagement.Location = New System.Drawing.Point(30, 54)
        Me.lblUserManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserManagement.Name = "lblUserManagement"
        Me.lblUserManagement.Size = New System.Drawing.Size(203, 39)
        Me.lblUserManagement.TabIndex = 41
        Me.lblUserManagement.Text = "Maintenace"
        '
        'DataGridView1
        '
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaintenanceID, Me.PropertyID, Me.CustodianID, Me.ServiceDate, Me.ServiceType, Me.Description, Me.ServiceProvider, Me.ProviderContact, Me.Cost, Me.NextSchedule, Me.WarrantyStatus, Me.TechnicianAssigned, Me.Status, Me.Remarks, Me.CreatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1511, 824)
        Me.DataGridView1.TabIndex = 42
        '
        'CreatedAt
        '
        Me.CreatedAt.HeaderText = "Created At"
        Me.CreatedAt.MinimumWidth = 6
        Me.CreatedAt.Name = "CreatedAt"
        Me.CreatedAt.Width = 125
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MinimumWidth = 6
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status "
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'TechnicianAssigned
        '
        Me.TechnicianAssigned.HeaderText = "Technician Assigned"
        Me.TechnicianAssigned.MinimumWidth = 6
        Me.TechnicianAssigned.Name = "TechnicianAssigned"
        Me.TechnicianAssigned.Width = 125
        '
        'WarrantyStatus
        '
        Me.WarrantyStatus.HeaderText = "Warranty Status"
        Me.WarrantyStatus.MinimumWidth = 6
        Me.WarrantyStatus.Name = "WarrantyStatus"
        Me.WarrantyStatus.Width = 125
        '
        'NextSchedule
        '
        Me.NextSchedule.HeaderText = "Next Schedule"
        Me.NextSchedule.MinimumWidth = 6
        Me.NextSchedule.Name = "NextSchedule"
        Me.NextSchedule.Width = 125
        '
        'Cost
        '
        Me.Cost.HeaderText = "Cost"
        Me.Cost.MinimumWidth = 6
        Me.Cost.Name = "Cost"
        Me.Cost.Width = 125
        '
        'ProviderContact
        '
        Me.ProviderContact.HeaderText = "Provider Contact"
        Me.ProviderContact.MinimumWidth = 6
        Me.ProviderContact.Name = "ProviderContact"
        Me.ProviderContact.Width = 125
        '
        'ServiceProvider
        '
        Me.ServiceProvider.HeaderText = "Service Provider"
        Me.ServiceProvider.MinimumWidth = 6
        Me.ServiceProvider.Name = "ServiceProvider"
        Me.ServiceProvider.Width = 125
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 125
        '
        'ServiceType
        '
        Me.ServiceType.HeaderText = "Service Type"
        Me.ServiceType.MinimumWidth = 6
        Me.ServiceType.Name = "ServiceType"
        Me.ServiceType.Width = 125
        '
        'ServiceDate
        '
        Me.ServiceDate.HeaderText = "Service Date"
        Me.ServiceDate.MinimumWidth = 6
        Me.ServiceDate.Name = "ServiceDate"
        Me.ServiceDate.Width = 125
        '
        'CustodianID
        '
        Me.CustodianID.HeaderText = "CustodianID"
        Me.CustodianID.MinimumWidth = 6
        Me.CustodianID.Name = "CustodianID"
        Me.CustodianID.Width = 125
        '
        'PropertyID
        '
        Me.PropertyID.HeaderText = "PropertyID"
        Me.PropertyID.MinimumWidth = 6
        Me.PropertyID.Name = "PropertyID"
        Me.PropertyID.Width = 125
        '
        'MaintenanceID
        '
        Me.MaintenanceID.HeaderText = "MaintenanceID"
        Me.MaintenanceID.MinimumWidth = 6
        Me.MaintenanceID.Name = "MaintenanceID"
        Me.MaintenanceID.Width = 125
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(45, 455)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 100)
        Me.Panel1.TabIndex = 43
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(37, 120)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1515, 813)
        Me.Panel2.TabIndex = 44
        '
        'SAMaintenace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1564, 988)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblUserManagement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "SAMaintenace"
        Me.Text = "SAMaintenace"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
