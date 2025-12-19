<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_MaintenanceRequestManagement
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertymanagement = New System.Windows.Forms.Label()
        Me.propertyManagementGrid = New System.Windows.Forms.DataGridView()
        Me.requestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propertyNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionBefore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typeOfIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.problemDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedTechnician = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.targetDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.completionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requestedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.printPAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Delete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_btn_update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.maintenancerequestmanagementsearchbar = New System.Windows.Forms.TextBox()
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(57, 690)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "TOTAL:"
        '
        'ttlpropertymanagement
        '
        Me.ttlpropertymanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlpropertymanagement.AutoSize = True
        Me.ttlpropertymanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlpropertymanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlpropertymanagement.Location = New System.Drawing.Point(208, 690)
        Me.ttlpropertymanagement.Name = "ttlpropertymanagement"
        Me.ttlpropertymanagement.Size = New System.Drawing.Size(38, 58)
        Me.ttlpropertymanagement.TabIndex = 167
        Me.ttlpropertymanagement.Text = "1"
        '
        'propertyManagementGrid
        '
        Me.propertyManagementGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyManagementGrid.BackgroundColor = System.Drawing.Color.White
        Me.propertyManagementGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.propertyManagementGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requestId, Me.dateRequested, Me.itemName, Me.location, Me.propertyNumber, Me.serialNumber, Me.departmentId, Me.conditionBefore, Me.typeOfIssue, Me.problemDescription, Me.status, Me.assignedTechnician, Me.targetDate, Me.completionDate, Me.requestedBy, Me.createdAt, Me.updatedAt})
        Me.propertyManagementGrid.Location = New System.Drawing.Point(67, 115)
        Me.propertyManagementGrid.Name = "propertyManagementGrid"
        Me.propertyManagementGrid.RowHeadersWidth = 51
        Me.propertyManagementGrid.RowTemplate.Height = 24
        Me.propertyManagementGrid.Size = New System.Drawing.Size(1270, 564)
        Me.propertyManagementGrid.TabIndex = 163
        '
        'requestId
        '
        Me.requestId.HeaderText = "requestId"
        Me.requestId.MinimumWidth = 6
        Me.requestId.Name = "requestId"
        Me.requestId.Width = 125
        '
        'dateRequested
        '
        Me.dateRequested.HeaderText = "dateRequested"
        Me.dateRequested.MinimumWidth = 6
        Me.dateRequested.Name = "dateRequested"
        Me.dateRequested.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "itemName"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'location
        '
        Me.location.HeaderText = "location"
        Me.location.MinimumWidth = 6
        Me.location.Name = "location"
        Me.location.Width = 125
        '
        'propertyNumber
        '
        Me.propertyNumber.HeaderText = "propertyNumber"
        Me.propertyNumber.MinimumWidth = 6
        Me.propertyNumber.Name = "propertyNumber"
        Me.propertyNumber.Width = 125
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
        'conditionBefore
        '
        Me.conditionBefore.HeaderText = "conditionBefore"
        Me.conditionBefore.MinimumWidth = 6
        Me.conditionBefore.Name = "conditionBefore"
        Me.conditionBefore.Width = 125
        '
        'typeOfIssue
        '
        Me.typeOfIssue.HeaderText = "typeOfIssue"
        Me.typeOfIssue.MinimumWidth = 6
        Me.typeOfIssue.Name = "typeOfIssue"
        Me.typeOfIssue.Width = 125
        '
        'problemDescription
        '
        Me.problemDescription.HeaderText = "problemDescription"
        Me.problemDescription.MinimumWidth = 6
        Me.problemDescription.Name = "problemDescription"
        Me.problemDescription.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 125
        '
        'assignedTechnician
        '
        Me.assignedTechnician.HeaderText = "assignedTechnician"
        Me.assignedTechnician.MinimumWidth = 6
        Me.assignedTechnician.Name = "assignedTechnician"
        Me.assignedTechnician.Visible = False
        Me.assignedTechnician.Width = 125
        '
        'targetDate
        '
        Me.targetDate.HeaderText = "targetDate"
        Me.targetDate.MinimumWidth = 6
        Me.targetDate.Name = "targetDate"
        Me.targetDate.Visible = False
        Me.targetDate.Width = 125
        '
        'completionDate
        '
        Me.completionDate.HeaderText = "completionDate"
        Me.completionDate.MinimumWidth = 6
        Me.completionDate.Name = "completionDate"
        Me.completionDate.Visible = False
        Me.completionDate.Width = 125
        '
        'requestedBy
        '
        Me.requestedBy.HeaderText = "requestedBy"
        Me.requestedBy.MinimumWidth = 6
        Me.requestedBy.Name = "requestedBy"
        Me.requestedBy.Visible = False
        Me.requestedBy.Width = 125
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "createdAt"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Visible = False
        Me.createdAt.Width = 125
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "updatedAt"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Visible = False
        Me.updatedAt.Width = 125
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 14.8!, System.Drawing.FontStyle.Bold)
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(59, 62)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(483, 44)
        Me.admin_label_DepartmentManagement.TabIndex = 162
        Me.admin_label_DepartmentManagement.Text = "Maintenance Request Management"
        '
        'printPAR
        '
        Me.printPAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.printPAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.printPAR.CornerRadius = 15
        Me.printPAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printPAR.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.printPAR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.printPAR.Location = New System.Drawing.Point(1184, 690)
        Me.printPAR.Margin = New System.Windows.Forms.Padding(4)
        Me.printPAR.Name = "printPAR"
        Me.printPAR.Size = New System.Drawing.Size(153, 33)
        Me.printPAR.TabIndex = 170
        Me.printPAR.Text = "Print PAR/ICS"
        Me.printPAR.UseVisualStyleBackColor = False
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnApprove.CornerRadius = 15
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnApprove.Location = New System.Drawing.Point(1238, 70)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(99, 34)
        Me.btnApprove.TabIndex = 172
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnReject.CornerRadius = 15
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnReject.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReject.Location = New System.Drawing.Point(1132, 69)
        Me.btnReject.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(99, 35)
        Me.btnReject.TabIndex = 173
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'Delete
        '
        Me.Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Delete.CornerRadius = 15
        Me.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Delete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Delete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Delete.Location = New System.Drawing.Point(916, 69)
        Me.Delete.Margin = New System.Windows.Forms.Padding(4)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(99, 35)
        Me.Delete.TabIndex = 174
        Me.Delete.Text = "Delete"
        Me.Delete.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1023, 69)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 35)
        Me.btnAdd.TabIndex = 175
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'prm_btn_update
        '
        Me.prm_btn_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.prm_btn_update.CornerRadius = 15
        Me.prm_btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.prm_btn_update.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.prm_btn_update.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.prm_btn_update.Location = New System.Drawing.Point(1085, 690)
        Me.prm_btn_update.Margin = New System.Windows.Forms.Padding(4)
        Me.prm_btn_update.Name = "prm_btn_update"
        Me.prm_btn_update.Size = New System.Drawing.Size(78, 35)
        Me.prm_btn_update.TabIndex = 178
        Me.prm_btn_update.Text = "Refresh"
        Me.prm_btn_update.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(567, 69)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 177
        Me.PictureBox2.TabStop = False
        '
        'maintenancerequestmanagementsearchbar
        '
        Me.maintenancerequestmanagementsearchbar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.maintenancerequestmanagementsearchbar.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.maintenancerequestmanagementsearchbar.Location = New System.Drawing.Point(601, 73)
        Me.maintenancerequestmanagementsearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.maintenancerequestmanagementsearchbar.Name = "maintenancerequestmanagementsearchbar"
        Me.maintenancerequestmanagementsearchbar.Size = New System.Drawing.Size(299, 27)
        Me.maintenancerequestmanagementsearchbar.TabIndex = 176
        '
        'UC_MaintenanceRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.prm_btn_update)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.maintenancerequestmanagementsearchbar)
        Me.Controls.Add(Me.Delete)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.printPAR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertymanagement)
        Me.Controls.Add(Me.propertyManagementGrid)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "UC_MaintenanceRequestManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ttlpropertymanagement As System.Windows.Forms.Label
    Friend WithEvents propertyManagementGrid As System.Windows.Forms.DataGridView
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents printPAR As Resources.Controls.RoundedButton
    Friend WithEvents btnApprove As Resources.Controls.RoundedButton
    Friend WithEvents btnReject As Resources.Controls.RoundedButton
    Friend WithEvents Delete As Resources.Controls.RoundedButton
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents prm_btn_update As Resources.Controls.RoundedButton
    Friend WithEvents requestId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateRequested As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents propertyNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents departmentId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents conditionBefore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents typeOfIssue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents problemDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents assignedTechnician As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents targetDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents completionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requestedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents createdAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents maintenancerequestmanagementsearchbar As System.Windows.Forms.TextBox
End Class
