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
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.maintenanceId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costMaterialsLabor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionAfterMaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actionTaken = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partsReplaced = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propertyItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionBeforeMaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typeOfMaintenance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedTechnician = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.maintenanceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.maintenanceDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlMaintenancemanagement = New System.Windows.Forms.Label()
        Me.btnRefresh = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnGenerateMaintenance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAssign = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.maintenancemanagementsearchbar = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_MaintenanceManagement
        '
        Me.admin_label_MaintenanceManagement.AutoSize = True
        Me.admin_label_MaintenanceManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_MaintenanceManagement.Location = New System.Drawing.Point(48, 47)
        Me.admin_label_MaintenanceManagement.Name = "admin_label_MaintenanceManagement"
        Me.admin_label_MaintenanceManagement.Size = New System.Drawing.Size(493, 58)
        Me.admin_label_MaintenanceManagement.TabIndex = 34
        Me.admin_label_MaintenanceManagement.Text = "Maintenance Management"
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnApprove.CornerRadius = 15
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnApprove.Location = New System.Drawing.Point(1229, 705)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(99, 34)
        Me.btnApprove.TabIndex = 152
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1015, 705)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 35)
        Me.btnDelete.TabIndex = 153
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.maintenanceId, Me.costMaterialsLabor, Me.conditionAfterMaint, Me.actionTaken, Me.partsReplaced, Me.createdAt, Me.updatedAt, Me.requestId, Me.propertyItemName, Me.serialNumber, Me.departmentId, Me.conditionBeforeMaint, Me.typeOfMaintenance, Me.assignedTechnician, Me.maintenanceDate, Me.maintenanceDetails})
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(58, 109)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1270, 573)
        Me.DataGridView1.TabIndex = 155
        '
        'maintenanceId
        '
        Me.maintenanceId.HeaderText = "maintenanceId"
        Me.maintenanceId.MinimumWidth = 6
        Me.maintenanceId.Name = "maintenanceId"
        Me.maintenanceId.Width = 125
        '
        'costMaterialsLabor
        '
        Me.costMaterialsLabor.HeaderText = "costMaterialsLabor"
        Me.costMaterialsLabor.MinimumWidth = 6
        Me.costMaterialsLabor.Name = "costMaterialsLabor"
        Me.costMaterialsLabor.Width = 125
        '
        'conditionAfterMaint
        '
        Me.conditionAfterMaint.HeaderText = "conditionAfterMaint"
        Me.conditionAfterMaint.MinimumWidth = 6
        Me.conditionAfterMaint.Name = "conditionAfterMaint"
        Me.conditionAfterMaint.Width = 125
        '
        'actionTaken
        '
        Me.actionTaken.HeaderText = "actionTaken"
        Me.actionTaken.MinimumWidth = 6
        Me.actionTaken.Name = "actionTaken"
        Me.actionTaken.Width = 125
        '
        'partsReplaced
        '
        Me.partsReplaced.HeaderText = "partsReplaced"
        Me.partsReplaced.MinimumWidth = 6
        Me.partsReplaced.Name = "partsReplaced"
        Me.partsReplaced.Width = 125
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "createdAt"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Width = 125
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "updatedAt"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Width = 125
        '
        'requestId
        '
        Me.requestId.HeaderText = "requestId"
        Me.requestId.MinimumWidth = 6
        Me.requestId.Name = "requestId"
        Me.requestId.Width = 125
        '
        'propertyItemName
        '
        Me.propertyItemName.HeaderText = "propertyItemName"
        Me.propertyItemName.MinimumWidth = 6
        Me.propertyItemName.Name = "propertyItemName"
        Me.propertyItemName.Width = 125
        '
        'serialNumber
        '
        Me.serialNumber.HeaderText = "serialNumber"
        Me.serialNumber.MinimumWidth = 6
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Width = 125
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "departmentId"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Width = 125
        '
        'conditionBeforeMaint
        '
        Me.conditionBeforeMaint.HeaderText = "conditionBeforeMaint"
        Me.conditionBeforeMaint.MinimumWidth = 6
        Me.conditionBeforeMaint.Name = "conditionBeforeMaint"
        Me.conditionBeforeMaint.Width = 125
        '
        'typeOfMaintenance
        '
        Me.typeOfMaintenance.HeaderText = "typeOfMaintenance"
        Me.typeOfMaintenance.MinimumWidth = 6
        Me.typeOfMaintenance.Name = "typeOfMaintenance"
        Me.typeOfMaintenance.Width = 125
        '
        'assignedTechnician
        '
        Me.assignedTechnician.HeaderText = "assignedTechnician"
        Me.assignedTechnician.MinimumWidth = 6
        Me.assignedTechnician.Name = "assignedTechnician"
        Me.assignedTechnician.Width = 125
        '
        'maintenanceDate
        '
        Me.maintenanceDate.HeaderText = "maintenanceDate"
        Me.maintenanceDate.MinimumWidth = 6
        Me.maintenanceDate.Name = "maintenanceDate"
        Me.maintenanceDate.Width = 125
        '
        'maintenanceDetails
        '
        Me.maintenanceDetails.HeaderText = "maintenanceDetails"
        Me.maintenanceDetails.MinimumWidth = 6
        Me.maintenanceDetails.Name = "maintenanceDetails"
        Me.maintenanceDetails.Width = 125
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
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRefresh.CornerRadius = 15
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefresh.Location = New System.Drawing.Point(993, 63)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(99, 34)
        Me.btnRefresh.TabIndex = 166
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnGenerateMaintenance
        '
        Me.btnGenerateMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateMaintenance.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateMaintenance.CornerRadius = 15
        Me.btnGenerateMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateMaintenance.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnGenerateMaintenance.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateMaintenance.Location = New System.Drawing.Point(1100, 63)
        Me.btnGenerateMaintenance.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerateMaintenance.Name = "btnGenerateMaintenance"
        Me.btnGenerateMaintenance.Size = New System.Drawing.Size(228, 35)
        Me.btnGenerateMaintenance.TabIndex = 167
        Me.btnGenerateMaintenance.Text = "Generate Maintenance Report"
        Me.btnGenerateMaintenance.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnReject.CornerRadius = 15
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnReject.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReject.Location = New System.Drawing.Point(1122, 704)
        Me.btnReject.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(99, 34)
        Me.btnReject.TabIndex = 168
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAssign.CornerRadius = 15
        Me.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssign.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAssign.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAssign.Location = New System.Drawing.Point(898, 706)
        Me.btnAssign.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(99, 34)
        Me.btnAssign.TabIndex = 169
        Me.btnAssign.Text = "Assign"
        Me.btnAssign.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(543, 55)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 42)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 171
        Me.PictureBox2.TabStop = False
        '
        'maintenancemanagementsearchbar
        '
        Me.maintenancemanagementsearchbar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.maintenancemanagementsearchbar.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maintenancemanagementsearchbar.Location = New System.Drawing.Point(608, 55)
        Me.maintenancemanagementsearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.maintenancemanagementsearchbar.Name = "maintenancemanagementsearchbar"
        Me.maintenancemanagementsearchbar.Size = New System.Drawing.Size(367, 42)
        Me.maintenancemanagementsearchbar.TabIndex = 170
        '
        'UC_MaintenanceManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.maintenancemanagementsearchbar)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnGenerateMaintenance)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlMaintenancemanagement)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnApprove)
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
    Friend WithEvents btnApprove As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlMaintenancemanagement As Label
    Friend WithEvents btnRefresh As Resources.Controls.RoundedButton
    Friend WithEvents btnGenerateMaintenance As Resources.Controls.RoundedButton
    Friend WithEvents btnReject As Resources.Controls.RoundedButton
    Friend WithEvents btnAssign As Resources.Controls.RoundedButton
    Friend WithEvents maintenanceId As DataGridViewTextBoxColumn
    Friend WithEvents costMaterialsLabor As DataGridViewTextBoxColumn
    Friend WithEvents conditionAfterMaint As DataGridViewTextBoxColumn
    Friend WithEvents actionTaken As DataGridViewTextBoxColumn
    Friend WithEvents partsReplaced As DataGridViewTextBoxColumn
    Friend WithEvents createdAt As DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As DataGridViewTextBoxColumn
    Friend WithEvents requestId As DataGridViewTextBoxColumn
    Friend WithEvents propertyItemName As DataGridViewTextBoxColumn
    Friend WithEvents serialNumber As DataGridViewTextBoxColumn
    Friend WithEvents departmentId As DataGridViewTextBoxColumn
    Friend WithEvents conditionBeforeMaint As DataGridViewTextBoxColumn
    Friend WithEvents typeOfMaintenance As DataGridViewTextBoxColumn
    Friend WithEvents assignedTechnician As DataGridViewTextBoxColumn
    Friend WithEvents maintenanceDate As DataGridViewTextBoxColumn
    Friend WithEvents maintenanceDetails As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents maintenancemanagementsearchbar As TextBox
End Class
