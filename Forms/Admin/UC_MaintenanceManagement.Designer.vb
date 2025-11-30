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
        Me.maintenanceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diagnosis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actionTaken = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partsReplaced = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.maintenanceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.technician = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlMaintenancemanagement = New System.Windows.Forms.Label()
        Me.btnRefresh = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAssign = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.maintenanceID, Me.itemName, Me.diagnosis, Me.actionTaken, Me.partsReplaced, Me.maintenanceDate, Me.technician, Me.cost, Me.status})
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(58, 109)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1270, 573)
        Me.DataGridView1.TabIndex = 155
        '
        'maintenanceID
        '
        Me.maintenanceID.HeaderText = "Maintenance ID"
        Me.maintenanceID.MinimumWidth = 6
        Me.maintenanceID.Name = "maintenanceID"
        Me.maintenanceID.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "Item Name"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 140
        '
        'diagnosis
        '
        Me.diagnosis.HeaderText = "Diagnosis"
        Me.diagnosis.MinimumWidth = 6
        Me.diagnosis.Name = "diagnosis"
        Me.diagnosis.Width = 175
        '
        'actionTaken
        '
        Me.actionTaken.HeaderText = "ActionTaken"
        Me.actionTaken.MinimumWidth = 6
        Me.actionTaken.Name = "actionTaken"
        Me.actionTaken.Width = 125
        '
        'partsReplaced
        '
        Me.partsReplaced.HeaderText = "Parts Replaced"
        Me.partsReplaced.MinimumWidth = 6
        Me.partsReplaced.Name = "partsReplaced"
        Me.partsReplaced.Width = 150
        '
        'maintenanceDate
        '
        Me.maintenanceDate.HeaderText = "Maintenance Date"
        Me.maintenanceDate.MinimumWidth = 6
        Me.maintenanceDate.Name = "maintenanceDate"
        Me.maintenanceDate.Width = 125
        '
        'technician
        '
        Me.technician.HeaderText = "Technician"
        Me.technician.MinimumWidth = 6
        Me.technician.Name = "technician"
        Me.technician.Width = 125
        '
        'cost
        '
        Me.cost.HeaderText = "Cost"
        Me.cost.MinimumWidth = 6
        Me.cost.Name = "cost"
        Me.cost.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 125
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
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(1100, 63)
        Me.RoundedButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(228, 35)
        Me.RoundedButton1.TabIndex = 167
        Me.RoundedButton1.Text = "Generate Maintenance Report"
        Me.RoundedButton1.UseVisualStyleBackColor = False
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
        'UC_MaintenanceManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.RoundedButton1)
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
    Friend WithEvents RoundedButton1 As Resources.Controls.RoundedButton
    Friend WithEvents btnReject As Resources.Controls.RoundedButton
    Friend WithEvents btnAssign As Resources.Controls.RoundedButton
    Friend WithEvents maintenanceID As DataGridViewTextBoxColumn
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents diagnosis As DataGridViewTextBoxColumn
    Friend WithEvents actionTaken As DataGridViewTextBoxColumn
    Friend WithEvents partsReplaced As DataGridViewTextBoxColumn
    Friend WithEvents maintenanceDate As DataGridViewTextBoxColumn
    Friend WithEvents technician As DataGridViewTextBoxColumn
    Friend WithEvents cost As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
