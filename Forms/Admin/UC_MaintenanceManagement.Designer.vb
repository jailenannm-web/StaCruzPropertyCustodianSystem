Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_MaintenanceManagement
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
        Me.admin_label_MaintenanceManagement = New System.Windows.Forms.Label()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_MaintenanceManagement
        '
        Me.admin_label_MaintenanceManagement.AutoSize = True
        Me.admin_label_MaintenanceManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_MaintenanceManagement.Location = New System.Drawing.Point(38, 47)
        Me.admin_label_MaintenanceManagement.Name = "admin_label_MaintenanceManagement"
        Me.admin_label_MaintenanceManagement.Size = New System.Drawing.Size(493, 58)
        Me.admin_label_MaintenanceManagement.TabIndex = 34
        Me.admin_label_MaintenanceManagement.Text = "Maintenance Management"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(1148, 645)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(121, 34)
        Me.btnEdit.TabIndex = 154
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1277, 644)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(121, 34)
        Me.btnAdd.TabIndex = 152
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1020, 644)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 35)
        Me.btnDelete.TabIndex = 153
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaintenanceID, Me.PropertyID, Me.CustodianID, Me.ServiceDate, Me.ServiceType, Me.Description, Me.ServiceProvider, Me.ProviderContact, Me.Cost, Me.NextSchedule, Me.WarrantyStatus, Me.TechnicianAssigned, Me.Status, Me.Remarks, Me.CreatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(48, 119)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1350, 518)
        Me.DataGridView1.TabIndex = 155
        '
        'MaintenanceID
        '
        Me.MaintenanceID.HeaderText = "MaintenanceID"
        Me.MaintenanceID.MinimumWidth = 6
        Me.MaintenanceID.Name = "MaintenanceID"
        '
        'PropertyID
        '
        Me.PropertyID.HeaderText = "PropertyID"
        Me.PropertyID.MinimumWidth = 6
        Me.PropertyID.Name = "PropertyID"
        '
        'CustodianID
        '
        Me.CustodianID.HeaderText = "CustodianID"
        Me.CustodianID.MinimumWidth = 6
        Me.CustodianID.Name = "CustodianID"
        '
        'ServiceDate
        '
        Me.ServiceDate.HeaderText = "Service Date"
        Me.ServiceDate.MinimumWidth = 6
        Me.ServiceDate.Name = "ServiceDate"
        '
        'ServiceType
        '
        Me.ServiceType.HeaderText = "Service Type"
        Me.ServiceType.MinimumWidth = 6
        Me.ServiceType.Name = "ServiceType"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        '
        'ServiceProvider
        '
        Me.ServiceProvider.HeaderText = "Service Provider"
        Me.ServiceProvider.MinimumWidth = 6
        Me.ServiceProvider.Name = "ServiceProvider"
        '
        'ProviderContact
        '
        Me.ProviderContact.HeaderText = "Provider Contact"
        Me.ProviderContact.MinimumWidth = 6
        Me.ProviderContact.Name = "ProviderContact"
        '
        'Cost
        '
        Me.Cost.HeaderText = "Cost"
        Me.Cost.MinimumWidth = 6
        Me.Cost.Name = "Cost"
        '
        'NextSchedule
        '
        Me.NextSchedule.HeaderText = "Next Schedule"
        Me.NextSchedule.MinimumWidth = 6
        Me.NextSchedule.Name = "NextSchedule"
        '
        'WarrantyStatus
        '
        Me.WarrantyStatus.HeaderText = "Warranty Status"
        Me.WarrantyStatus.MinimumWidth = 6
        Me.WarrantyStatus.Name = "WarrantyStatus"
        '
        'TechnicianAssigned
        '
        Me.TechnicianAssigned.HeaderText = "Technician Assigned"
        Me.TechnicianAssigned.MinimumWidth = 6
        Me.TechnicianAssigned.Name = "TechnicianAssigned"
        '
        'Status
        '
        Me.Status.HeaderText = "Status "
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MinimumWidth = 6
        Me.Remarks.Name = "Remarks"
        '
        'CreatedAt
        '
        Me.CreatedAt.HeaderText = "Created At"
        Me.CreatedAt.MinimumWidth = 6
        Me.CreatedAt.Name = "CreatedAt"
        '
        'UC_MaintenanceManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.admin_label_MaintenanceManagement)
        Me.Name = "UC_MaintenanceManagement"
        Me.Size = New System.Drawing.Size(1455, 741)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_MaintenanceManagement As Label
    Friend WithEvents btnEdit As Resources.Controls.RoundedButton
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MaintenanceID As DataGridViewTextBoxColumn
    Friend WithEvents PropertyID As DataGridViewTextBoxColumn
    Friend WithEvents CustodianID As DataGridViewTextBoxColumn
    Friend WithEvents ServiceDate As DataGridViewTextBoxColumn
    Friend WithEvents ServiceType As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents ServiceProvider As DataGridViewTextBoxColumn
    Friend WithEvents ProviderContact As DataGridViewTextBoxColumn
    Friend WithEvents Cost As DataGridViewTextBoxColumn
    Friend WithEvents NextSchedule As DataGridViewTextBoxColumn
    Friend WithEvents WarrantyStatus As DataGridViewTextBoxColumn
    Friend WithEvents TechnicianAssigned As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Remarks As DataGridViewTextBoxColumn
    Friend WithEvents CreatedAt As DataGridViewTextBoxColumn
End Class
