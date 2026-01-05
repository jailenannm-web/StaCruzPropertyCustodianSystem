<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_SupplyRequestManagement
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.printPAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.issueRequisition = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAssignSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnUpdate = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertyrequestmanagement = New System.Windows.Forms.Label()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_table1 = New System.Windows.Forms.DataGridView()
        Me.requestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requesterName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateOfRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_SupplyRequestManagement = New System.Windows.Forms.Label()
        Me.supplyrequestmanagementsearchbar = New System.Windows.Forms.TextBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'printPAR
        '
        Me.printPAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.printPAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.printPAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printPAR.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.printPAR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.printPAR.Location = New System.Drawing.Point(675, 637)
        Me.printPAR.Name = "printPAR"
        Me.printPAR.Size = New System.Drawing.Size(115, 27)
        Me.printPAR.TabIndex = 170
        Me.printPAR.Text = "Print PAR/ICS"
        Me.printPAR.UseVisualStyleBackColor = False
        Me.printPAR.Visible = False
        '
        'issueRequisition
        '
        Me.issueRequisition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.issueRequisition.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.issueRequisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.issueRequisition.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.issueRequisition.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.issueRequisition.Location = New System.Drawing.Point(796, 637)
        Me.issueRequisition.Name = "issueRequisition"
        Me.issueRequisition.Size = New System.Drawing.Size(115, 27)
        Me.issueRequisition.TabIndex = 169
        Me.issueRequisition.Text = "Issue RIS"
        Me.issueRequisition.UseVisualStyleBackColor = False
        '
        'btnAssignSupply
        '
        Me.btnAssignSupply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssignSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAssignSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssignSupply.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAssignSupply.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAssignSupply.Location = New System.Drawing.Point(645, 36)
        Me.btnAssignSupply.Name = "btnAssignSupply"
        Me.btnAssignSupply.Size = New System.Drawing.Size(74, 28)
        Me.btnAssignSupply.TabIndex = 180
        Me.btnAssignSupply.Text = "Assign"
        Me.btnAssignSupply.UseVisualStyleBackColor = False
        Me.btnAssignSupply.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdate.Location = New System.Drawing.Point(565, 36)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(74, 28)
        Me.btnUpdate.TabIndex = 181
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 637)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 48)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "TOTAL:"
        '
        'ttlpropertyrequestmanagement
        '
        Me.ttlpropertyrequestmanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlpropertyrequestmanagement.AutoSize = True
        Me.ttlpropertyrequestmanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlpropertyrequestmanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlpropertyrequestmanagement.Location = New System.Drawing.Point(130, 637)
        Me.ttlpropertyrequestmanagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ttlpropertyrequestmanagement.Name = "ttlpropertyrequestmanagement"
        Me.ttlpropertyrequestmanagement.Size = New System.Drawing.Size(38, 48)
        Me.ttlpropertyrequestmanagement.TabIndex = 167
        Me.ttlpropertyrequestmanagement.Text = "0"
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnApprove.Location = New System.Drawing.Point(805, 36)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(74, 28)
        Me.btnApprove.TabIndex = 165
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnReject.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReject.Location = New System.Drawing.Point(725, 36)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(74, 28)
        Me.btnReject.TabIndex = 166
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'prm_table1
        '
        Me.prm_table1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_table1.BackgroundColor = System.Drawing.Color.White
        Me.prm_table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.prm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requestId, Me.departmentId, Me.requesterName, Me.itemName, Me.position, Me.description, Me.quantityRequested, Me.unit, Me.purpose, Me.status, Me.remarks, Me.dateOfRequest, Me.approvedBy, Me.approvedDate, Me.createdAt, Me.updatedAt})
        Me.prm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.Location = New System.Drawing.Point(22, 171)
        Me.prm_table1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.prm_table1.Name = "prm_table1"
        Me.prm_table1.RowHeadersWidth = 51
        Me.prm_table1.RowTemplate.Height = 24
        Me.prm_table1.Size = New System.Drawing.Size(889, 460)
        Me.prm_table1.TabIndex = 163
        '
        'requestId
        '
        Me.requestId.HeaderText = "RequestId"
        Me.requestId.MinimumWidth = 6
        Me.requestId.Name = "requestId"
        Me.requestId.Width = 125
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "departmentId"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Width = 125
        '
        'requesterName
        '
        Me.requesterName.HeaderText = "Requester Name"
        Me.requesterName.MinimumWidth = 6
        Me.requesterName.Name = "requesterName"
        Me.requesterName.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "itemName"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'position
        '
        Me.position.HeaderText = "Position"
        Me.position.MinimumWidth = 6
        Me.position.Name = "position"
        Me.position.Width = 125
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.MinimumWidth = 6
        Me.description.Name = "description"
        Me.description.Width = 125
        '
        'quantityRequested
        '
        Me.quantityRequested.HeaderText = "quantityRequested"
        Me.quantityRequested.MinimumWidth = 6
        Me.quantityRequested.Name = "quantityRequested"
        Me.quantityRequested.Width = 125
        '
        'unit
        '
        Me.unit.HeaderText = "Unit"
        Me.unit.MinimumWidth = 6
        Me.unit.Name = "unit"
        Me.unit.Width = 125
        '
        'purpose
        '
        Me.purpose.HeaderText = "Purpose"
        Me.purpose.MinimumWidth = 6
        Me.purpose.Name = "purpose"
        Me.purpose.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 125
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 125
        '
        'dateOfRequest
        '
        Me.dateOfRequest.HeaderText = "Date Of Request"
        Me.dateOfRequest.MinimumWidth = 6
        Me.dateOfRequest.Name = "dateOfRequest"
        Me.dateOfRequest.Width = 125
        '
        'approvedBy
        '
        Me.approvedBy.HeaderText = "approvedBy"
        Me.approvedBy.MinimumWidth = 6
        Me.approvedBy.Name = "approvedBy"
        Me.approvedBy.Width = 125
        '
        'approvedDate
        '
        Me.approvedDate.HeaderText = "approvedDate"
        Me.approvedDate.MinimumWidth = 6
        Me.approvedDate.Name = "approvedDate"
        Me.approvedDate.Width = 125
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
        'admin_label_SupplyRequestManagement
        '
        Me.admin_label_SupplyRequestManagement.AutoSize = True
        Me.admin_label_SupplyRequestManagement.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.admin_label_SupplyRequestManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.admin_label_SupplyRequestManagement.Location = New System.Drawing.Point(15, 16)
        Me.admin_label_SupplyRequestManagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.admin_label_SupplyRequestManagement.Name = "admin_label_SupplyRequestManagement"
        Me.admin_label_SupplyRequestManagement.Size = New System.Drawing.Size(381, 42)
        Me.admin_label_SupplyRequestManagement.TabIndex = 162
        Me.admin_label_SupplyRequestManagement.Text = "Supply Request Management"
        '
        'supplyrequestmanagementsearchbar
        '
        Me.supplyrequestmanagementsearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.supplyrequestmanagementsearchbar.Location = New System.Drawing.Point(19, 40)
        Me.supplyrequestmanagementsearchbar.Name = "supplyrequestmanagementsearchbar"
        Me.supplyrequestmanagementsearchbar.Size = New System.Drawing.Size(226, 25)
        Me.supplyrequestmanagementsearchbar.TabIndex = 178
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_status.Location = New System.Drawing.Point(279, 36)
        Me.pm_cbobx_status.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(136, 30)
        Me.pm_cbobx_status.TabIndex = 182
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.lblStatus)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_status)
        Me.pnlFilters.Controls.Add(Me.supplyrequestmanagementsearchbar)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.btnApprove)
        Me.pnlFilters.Controls.Add(Me.btnUpdate)
        Me.pnlFilters.Controls.Add(Me.btnReject)
        Me.pnlFilters.Controls.Add(Me.btnAssignSupply)
        Me.pnlFilters.Location = New System.Drawing.Point(22, 73)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(11, 12, 11, 12)
        Me.pnlFilters.Size = New System.Drawing.Size(895, 82)
        Me.pnlFilters.TabIndex = 403
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(275, 14)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 19)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "Status"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(15, 16)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(50, 19)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search "
        '
        'UC_SupplyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.printPAR)
        Me.Controls.Add(Me.issueRequisition)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertyrequestmanagement)
        Me.Controls.Add(Me.prm_table1)
        Me.Controls.Add(Me.admin_label_SupplyRequestManagement)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UC_SupplyRequestManagement"
        Me.Size = New System.Drawing.Size(938, 722)
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents printPAR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents issueRequisition As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ttlpropertyrequestmanagement As System.Windows.Forms.Label
    Friend WithEvents btnApprove As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnReject As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnAssignSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnUpdate As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents prm_table1 As System.Windows.Forms.DataGridView
    Friend WithEvents admin_label_SupplyRequestManagement As System.Windows.Forms.Label
    Friend WithEvents supplyrequestmanagementsearchbar As System.Windows.Forms.TextBox
    Friend WithEvents requestId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents departmentId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requesterName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents position As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantityRequested As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents purpose As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateOfRequest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents approvedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents approvedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents createdAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pm_cbobx_status As System.Windows.Forms.ComboBox
    Friend WithEvents pnlFilters As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
End Class
