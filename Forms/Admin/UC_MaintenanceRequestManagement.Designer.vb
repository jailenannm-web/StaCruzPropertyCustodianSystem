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
        Me.requestID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propertyNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.department = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionBefore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typeOfIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.problemDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignedTechnician = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.targetDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.printPAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.issuePropertySlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_btn_update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.propertyManagementGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requestID, Me.dateRequested, Me.itemName, Me.serialNumber, Me.propertyNumber, Me.department, Me.location, Me.conditionBefore, Me.typeOfIssue, Me.problemDescription, Me.status, Me.assignedTechnician, Me.targetDate})
        Me.propertyManagementGrid.Location = New System.Drawing.Point(67, 115)
        Me.propertyManagementGrid.Name = "propertyManagementGrid"
        Me.propertyManagementGrid.RowHeadersWidth = 51
        Me.propertyManagementGrid.RowTemplate.Height = 24
        Me.propertyManagementGrid.Size = New System.Drawing.Size(1270, 564)
        Me.propertyManagementGrid.TabIndex = 163
        '
        'requestID
        '
        Me.requestID.HeaderText = "Request ID"
        Me.requestID.MinimumWidth = 6
        Me.requestID.Name = "requestID"
        Me.requestID.Width = 85
        '
        'dateRequested
        '
        Me.dateRequested.HeaderText = "Date Requested"
        Me.dateRequested.MinimumWidth = 6
        Me.dateRequested.Name = "dateRequested"
        Me.dateRequested.Width = 85
        '
        'itemName
        '
        Me.itemName.HeaderText = "Item Name"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'serialNumber
        '
        Me.serialNumber.HeaderText = "Serial Number"
        Me.serialNumber.MinimumWidth = 6
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Width = 85
        '
        'propertyNumber
        '
        Me.propertyNumber.HeaderText = "Property Number"
        Me.propertyNumber.MinimumWidth = 6
        Me.propertyNumber.Name = "propertyNumber"
        Me.propertyNumber.Width = 85
        '
        'department
        '
        Me.department.HeaderText = "Department"
        Me.department.MinimumWidth = 6
        Me.department.Name = "department"
        Me.department.Width = 85
        '
        'location
        '
        Me.location.HeaderText = "Location"
        Me.location.MinimumWidth = 6
        Me.location.Name = "location"
        Me.location.Width = 85
        '
        'conditionBefore
        '
        Me.conditionBefore.HeaderText = "Condition Before"
        Me.conditionBefore.MinimumWidth = 6
        Me.conditionBefore.Name = "conditionBefore"
        Me.conditionBefore.Width = 85
        '
        'typeOfIssue
        '
        Me.typeOfIssue.HeaderText = "Type of Issue"
        Me.typeOfIssue.MinimumWidth = 6
        Me.typeOfIssue.Name = "typeOfIssue"
        Me.typeOfIssue.Width = 85
        '
        'problemDescription
        '
        Me.problemDescription.HeaderText = "Problem Description"
        Me.problemDescription.MinimumWidth = 6
        Me.problemDescription.Name = "problemDescription"
        Me.problemDescription.Width = 150
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 85
        '
        'assignedTechnician
        '
        Me.assignedTechnician.HeaderText = "Assigned Technician"
        Me.assignedTechnician.MinimumWidth = 6
        Me.assignedTechnician.Name = "assignedTechnician"
        Me.assignedTechnician.Width = 85
        '
        'targetDate
        '
        Me.targetDate.HeaderText = "Target Date/Completion Date"
        Me.targetDate.MinimumWidth = 6
        Me.targetDate.Name = "targetDate"
        Me.targetDate.Width = 85
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(57, 54)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(639, 58)
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
        'issuePropertySlip
        '
        Me.issuePropertySlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.issuePropertySlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.issuePropertySlip.CornerRadius = 15
        Me.issuePropertySlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.issuePropertySlip.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.issuePropertySlip.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.issuePropertySlip.Location = New System.Drawing.Point(1023, 690)
        Me.issuePropertySlip.Margin = New System.Windows.Forms.Padding(4)
        Me.issuePropertySlip.Name = "issuePropertySlip"
        Me.issuePropertySlip.Size = New System.Drawing.Size(153, 33)
        Me.issuePropertySlip.TabIndex = 169
        Me.issuePropertySlip.Text = "Issue Property Slip"
        Me.issuePropertySlip.UseVisualStyleBackColor = False
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
        'prm_btn_update
        '
        Me.prm_btn_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.prm_btn_update.CornerRadius = 15
        Me.prm_btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.prm_btn_update.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.prm_btn_update.ForeColor = System.Drawing.Color.White
        Me.prm_btn_update.Location = New System.Drawing.Point(1032, 71)
        Me.prm_btn_update.Name = "prm_btn_update"
        Me.prm_btn_update.Size = New System.Drawing.Size(93, 33)
        Me.prm_btn_update.TabIndex = 171
        Me.prm_btn_update.Text = "Update"
        Me.prm_btn_update.UseVisualStyleBackColor = False
        '
        'UC_MaintenanceRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.prm_btn_update)
        Me.Controls.Add(Me.printPAR)
        Me.Controls.Add(Me.issuePropertySlip)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertymanagement)
        Me.Controls.Add(Me.propertyManagementGrid)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "UC_MaintenanceRequestManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.propertyManagementGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ttlpropertymanagement As System.Windows.Forms.Label
    Friend WithEvents propertyManagementGrid As System.Windows.Forms.DataGridView
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents requestID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateRequested As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents propertyNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents department As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents conditionBefore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents typeOfIssue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents problemDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents assignedTechnician As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents targetDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents printPAR As Resources.Controls.RoundedButton
    Friend WithEvents issuePropertySlip As Resources.Controls.RoundedButton
    Friend WithEvents btnApprove As Resources.Controls.RoundedButton
    Friend WithEvents btnReject As Resources.Controls.RoundedButton
    Friend WithEvents prm_btn_update As Resources.Controls.RoundedButton
End Class
