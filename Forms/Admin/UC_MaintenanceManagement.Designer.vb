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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.maintenanceId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propertyItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionBeforeMaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typeOfMaintenance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedTechnician = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.maintenanceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costMaterialsLabor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionAfterMaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlMaintenancemanagement = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.maintenancemanagementsearchbar = New System.Windows.Forms.TextBox()
        Me.btnGenerateMaintenance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnRefresh = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAddMaintenance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.cmbStatusFilter = New System.Windows.Forms.ComboBox()
        Me.cmbTypeFilter = New System.Windows.Forms.ComboBox()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.lblTypeFilter = New System.Windows.Forms.Label()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_MaintenanceManagement
        '
        Me.admin_label_MaintenanceManagement.AutoSize = True
        Me.admin_label_MaintenanceManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_MaintenanceManagement.Location = New System.Drawing.Point(44, 37)
        Me.admin_label_MaintenanceManagement.Name = "admin_label_MaintenanceManagement"
        Me.admin_label_MaintenanceManagement.Size = New System.Drawing.Size(493, 58)
        Me.admin_label_MaintenanceManagement.TabIndex = 34
        Me.admin_label_MaintenanceManagement.Text = "Maintenance Management"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeight = 40
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.maintenanceId, Me.requestId, Me.propertyItemName, Me.serialNumber, Me.location, Me.departmentId, Me.conditionBeforeMaint, Me.typeOfMaintenance, Me.assignedTechnician, Me.maintenanceDate, Me.costMaterialsLabor, Me.conditionAfterMaint, Me.status})
        Me.DataGridView1.GridColor = System.Drawing.Color.LightGray
        Me.DataGridView1.Location = New System.Drawing.Point(72, 130)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.RowTemplate.Height = 35
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1270, 552)
        Me.DataGridView1.TabIndex = 155
        '
        'maintenanceId
        '
        Me.maintenanceId.DataPropertyName = "maintenanceId"
        Me.maintenanceId.HeaderText = "ID"
        Me.maintenanceId.MinimumWidth = 60
        Me.maintenanceId.Name = "maintenanceId"
        Me.maintenanceId.ReadOnly = True
        '
        'requestId
        '
        Me.requestId.DataPropertyName = "requestId"
        Me.requestId.HeaderText = "Req ID"
        Me.requestId.MinimumWidth = 70
        Me.requestId.Name = "requestId"
        Me.requestId.ReadOnly = True
        '
        'propertyItemName
        '
        Me.propertyItemName.DataPropertyName = "propertyItemName"
        Me.propertyItemName.FillWeight = 150.0!
        Me.propertyItemName.HeaderText = "Property Item"
        Me.propertyItemName.MinimumWidth = 120
        Me.propertyItemName.Name = "propertyItemName"
        Me.propertyItemName.ReadOnly = True
        '
        'serialNumber
        '
        Me.serialNumber.DataPropertyName = "serialNumber"
        Me.serialNumber.HeaderText = "Serial Number"
        Me.serialNumber.MinimumWidth = 110
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.ReadOnly = True
        '
        'location
        '
        Me.location.DataPropertyName = "location"
        Me.location.FillWeight = 120.0!
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 100
        Me.location.Name = "location"
        Me.location.ReadOnly = True
        '
        'departmentId
        '
        Me.departmentId.DataPropertyName = "departmentName"
        Me.departmentId.HeaderText = "Department"
        Me.departmentId.MinimumWidth = 80
        Me.departmentId.Name = "departmentId"
        Me.departmentId.ReadOnly = True
        '
        'conditionBeforeMaint
        '
        Me.conditionBeforeMaint.DataPropertyName = "conditionBeforeMaint"
        Me.conditionBeforeMaint.FillWeight = 90.0!
        Me.conditionBeforeMaint.HeaderText = "Condition Before"
        Me.conditionBeforeMaint.MinimumWidth = 80
        Me.conditionBeforeMaint.Name = "conditionBeforeMaint"
        Me.conditionBeforeMaint.ReadOnly = True
        '
        'typeOfMaintenance
        '
        Me.typeOfMaintenance.DataPropertyName = "typeOfMaintenance"
        Me.typeOfMaintenance.FillWeight = 80.0!
        Me.typeOfMaintenance.HeaderText = "Type"
        Me.typeOfMaintenance.MinimumWidth = 70
        Me.typeOfMaintenance.Name = "typeOfMaintenance"
        Me.typeOfMaintenance.ReadOnly = True
        '
        'assignedTechnician
        '
        Me.assignedTechnician.DataPropertyName = "assignedTechnician"
        Me.assignedTechnician.FillWeight = 120.0!
        Me.assignedTechnician.HeaderText = "Technician"
        Me.assignedTechnician.MinimumWidth = 100
        Me.assignedTechnician.Name = "assignedTechnician"
        Me.assignedTechnician.ReadOnly = True
        '
        'maintenanceDate
        '
        Me.maintenanceDate.DataPropertyName = "maintenanceDate"
        Me.maintenanceDate.FillWeight = 80.0!
        Me.maintenanceDate.HeaderText = "Date"
        Me.maintenanceDate.MinimumWidth = 80
        Me.maintenanceDate.Name = "maintenanceDate"
        Me.maintenanceDate.ReadOnly = True
        '
        'costMaterialsLabor
        '
        Me.costMaterialsLabor.DataPropertyName = "costMaterialsLabor"
        Me.costMaterialsLabor.FillWeight = 70.0!
        Me.costMaterialsLabor.HeaderText = "Cost"
        Me.costMaterialsLabor.MinimumWidth = 60
        Me.costMaterialsLabor.Name = "costMaterialsLabor"
        Me.costMaterialsLabor.ReadOnly = True
        '
        'conditionAfterMaint
        '
        Me.conditionAfterMaint.DataPropertyName = "conditionAfterMaint"
        Me.conditionAfterMaint.FillWeight = 90.0!
        Me.conditionAfterMaint.HeaderText = "Condition After"
        Me.conditionAfterMaint.MinimumWidth = 80
        Me.conditionAfterMaint.Name = "conditionAfterMaint"
        Me.conditionAfterMaint.ReadOnly = True
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        Me.status.FillWeight = 70.0!
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 70
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(48, 704)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "TOTAL:"
        '
        'ttlMaintenancemanagement
        '
        Me.ttlMaintenancemanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlMaintenancemanagement.AutoSize = True
        Me.ttlMaintenancemanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlMaintenancemanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlMaintenancemanagement.Location = New System.Drawing.Point(199, 704)
        Me.ttlMaintenancemanagement.Name = "ttlMaintenancemanagement"
        Me.ttlMaintenancemanagement.Size = New System.Drawing.Size(47, 58)
        Me.ttlMaintenancemanagement.TabIndex = 156
        Me.ttlMaintenancemanagement.Text = "0"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(543, 55)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 171
        Me.PictureBox2.TabStop = False
        '
        'maintenancemanagementsearchbar
        '
        Me.maintenancemanagementsearchbar.Font = New System.Drawing.Font("Poppins", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maintenancemanagementsearchbar.Location = New System.Drawing.Point(590, 58)
        Me.maintenancemanagementsearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.maintenancemanagementsearchbar.Name = "maintenancemanagementsearchbar"
        Me.maintenancemanagementsearchbar.Size = New System.Drawing.Size(222, 34)
        Me.maintenancemanagementsearchbar.TabIndex = 170
        '
        'btnGenerateMaintenance
        '
        Me.btnGenerateMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateMaintenance.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateMaintenance.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnGenerateMaintenance.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateMaintenance.Location = New System.Drawing.Point(1139, 70)
        Me.btnGenerateMaintenance.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerateMaintenance.Name = "btnGenerateMaintenance"
        Me.btnGenerateMaintenance.Size = New System.Drawing.Size(193, 35)
        Me.btnGenerateMaintenance.TabIndex = 167
        Me.btnGenerateMaintenance.Text = "Generate Maintenance Report"
        Me.btnGenerateMaintenance.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefresh.Location = New System.Drawing.Point(871, 704)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(99, 35)
        Me.btnRefresh.TabIndex = 166
        Me.btnRefresh.Text = "Update"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnAddMaintenance
        '
        Me.btnAddMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddMaintenance.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAddMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMaintenance.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAddMaintenance.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddMaintenance.Location = New System.Drawing.Point(1192, 704)
        Me.btnAddMaintenance.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddMaintenance.Name = "btnAddMaintenance"
        Me.btnAddMaintenance.Size = New System.Drawing.Size(140, 35)
        Me.btnAddMaintenance.TabIndex = 168
        Me.btnAddMaintenance.Text = "Add Maintenance"
        Me.btnAddMaintenance.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(978, 704)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 35)
        Me.btnDelete.TabIndex = 153
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'cmbStatusFilter
        '
        Me.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusFilter.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbStatusFilter.FormattingEnabled = True
        Me.cmbStatusFilter.Items.AddRange(New Object() {"All Status", "Completed", "Ongoing", "For Review"})
        Me.cmbStatusFilter.Location = New System.Drawing.Point(826, 70)
        Me.cmbStatusFilter.Name = "cmbStatusFilter"
        Me.cmbStatusFilter.Size = New System.Drawing.Size(150, 34)
        Me.cmbStatusFilter.TabIndex = 172
        '
        'cmbTypeFilter
        '
        Me.cmbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeFilter.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cmbTypeFilter.FormattingEnabled = True
        Me.cmbTypeFilter.Items.AddRange(New Object() {"All Types", "Repair", "Replace", "Servicing"})
        Me.cmbTypeFilter.Location = New System.Drawing.Point(982, 70)
        Me.cmbTypeFilter.Name = "cmbTypeFilter"
        Me.cmbTypeFilter.Size = New System.Drawing.Size(150, 34)
        Me.cmbTypeFilter.TabIndex = 173
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblStatusFilter.Location = New System.Drawing.Point(819, 42)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(58, 25)
        Me.lblStatusFilter.TabIndex = 174
        Me.lblStatusFilter.Text = "Status:"
        '
        'lblTypeFilter
        '
        Me.lblTypeFilter.AutoSize = True
        Me.lblTypeFilter.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblTypeFilter.Location = New System.Drawing.Point(982, 47)
        Me.lblTypeFilter.Name = "lblTypeFilter"
        Me.lblTypeFilter.Size = New System.Drawing.Size(49, 25)
        Me.lblTypeFilter.TabIndex = 175
        Me.lblTypeFilter.Text = "Type:"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(1085, 704)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(99, 35)
        Me.btnEdit.TabIndex = 176
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'UC_MaintenanceManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblTypeFilter)
        Me.Controls.Add(Me.lblStatusFilter)
        Me.Controls.Add(Me.cmbTypeFilter)
        Me.Controls.Add(Me.cmbStatusFilter)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.maintenancemanagementsearchbar)
        Me.Controls.Add(Me.btnGenerateMaintenance)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnAddMaintenance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlMaintenancemanagement)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.admin_label_MaintenanceManagement)
        Me.Name = "UC_MaintenanceManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_MaintenanceManagement As Label
    Friend WithEvents btnDelete As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlMaintenancemanagement As Label
    Friend WithEvents btnAddMaintenance As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnRefresh As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnGenerateMaintenance As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents maintenancemanagementsearchbar As TextBox
    Friend WithEvents cmbStatusFilter As ComboBox
    Friend WithEvents cmbTypeFilter As ComboBox
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents lblTypeFilter As Label
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents maintenanceId As DataGridViewTextBoxColumn
    Friend WithEvents requestId As DataGridViewTextBoxColumn
    Friend WithEvents propertyItemName As DataGridViewTextBoxColumn
    Friend WithEvents serialNumber As DataGridViewTextBoxColumn
    Friend Shadows WithEvents location As DataGridViewTextBoxColumn
    Friend WithEvents departmentId As DataGridViewTextBoxColumn
    Friend WithEvents conditionBeforeMaint As DataGridViewTextBoxColumn
    Friend WithEvents typeOfMaintenance As DataGridViewTextBoxColumn
    Friend WithEvents assignedTechnician As DataGridViewTextBoxColumn
    Friend WithEvents maintenanceDate As DataGridViewTextBoxColumn
    Friend WithEvents costMaterialsLabor As DataGridViewTextBoxColumn
    Friend WithEvents conditionAfterMaint As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
