Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_PropertyRequestManagement
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
        Me.admin_label_PropertyRequestManagement = New System.Windows.Forms.Label()
        Me.prm_table1 = New System.Windows.Forms.DataGridView()
        Me.requestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requesterName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateOfRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateOfReques = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.request_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employee_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.department_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.property_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity_requested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requestDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approved_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.release_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.return_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.penalty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updated_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertyrequestmanagement = New System.Windows.Forms.Label()
        Me.maintenancemanagementsearchbar = New System.Windows.Forms.TextBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.issueRequisition = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAssign = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.printPAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.issuePropertyCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_btn_update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.assign = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_PropertyRequestManagement
        '
        Me.admin_label_PropertyRequestManagement.AutoSize = True
        Me.admin_label_PropertyRequestManagement.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.admin_label_PropertyRequestManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.admin_label_PropertyRequestManagement.Location = New System.Drawing.Point(15, 16)
        Me.admin_label_PropertyRequestManagement.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.admin_label_PropertyRequestManagement.Name = "admin_label_PropertyRequestManagement"
        Me.admin_label_PropertyRequestManagement.Size = New System.Drawing.Size(402, 42)
        Me.admin_label_PropertyRequestManagement.TabIndex = 33
        Me.admin_label_PropertyRequestManagement.Text = "Property Request Management"
        '
        'prm_table1
        '
        Me.prm_table1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_table1.BackgroundColor = System.Drawing.Color.White
        Me.prm_table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.prm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requestId, Me.departmentId, Me.requesterName, Me.position, Me.itemName, Me.description, Me.purpose, Me.status, Me.quantityRequested, Me.dateOfRequest, Me.dateOfReques, Me.updatedAt, Me.createdAt, Me.approvedBy})
        Me.prm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.Location = New System.Drawing.Point(22, 171)
        Me.prm_table1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.prm_table1.Name = "prm_table1"
        Me.prm_table1.RowHeadersWidth = 51
        Me.prm_table1.RowTemplate.Height = 24
        Me.prm_table1.Size = New System.Drawing.Size(895, 460)
        Me.prm_table1.TabIndex = 34
        '
        'requestId
        '
        Me.requestId.HeaderText = "Request ID"
        Me.requestId.MinimumWidth = 6
        Me.requestId.Name = "requestId"
        Me.requestId.Width = 125
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "Department ID"
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
        'position
        '
        Me.position.HeaderText = "Position"
        Me.position.MinimumWidth = 6
        Me.position.Name = "position"
        Me.position.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "Item Name"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.MinimumWidth = 6
        Me.description.Name = "description"
        Me.description.Width = 125
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
        'quantityRequested
        '
        Me.quantityRequested.HeaderText = "Quantity Requested"
        Me.quantityRequested.MinimumWidth = 6
        Me.quantityRequested.Name = "quantityRequested"
        Me.quantityRequested.Width = 125
        '
        'dateOfRequest
        '
        Me.dateOfRequest.HeaderText = "Date Of Request"
        Me.dateOfRequest.MinimumWidth = 6
        Me.dateOfRequest.Name = "dateOfRequest"
        Me.dateOfRequest.Width = 125
        '
        'dateOfReques
        '
        Me.dateOfReques.HeaderText = "DateOfRequest"
        Me.dateOfReques.MinimumWidth = 6
        Me.dateOfReques.Name = "dateOfReques"
        Me.dateOfReques.Width = 125
        '
        'updatedAt
        '
        Me.updatedAt.HeaderText = "updatedAt"
        Me.updatedAt.MinimumWidth = 6
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Width = 125
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "createdAt"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Width = 125
        '
        'approvedBy
        '
        Me.approvedBy.HeaderText = "approvedDate"
        Me.approvedBy.MinimumWidth = 6
        Me.approvedBy.Name = "approvedBy"
        Me.approvedBy.Width = 125
        '
        'request_id
        '
        Me.request_id.HeaderText = "Request ID"
        Me.request_id.MinimumWidth = 6
        Me.request_id.Name = "request_id"
        Me.request_id.Width = 125
        '
        'employee_id
        '
        Me.employee_id.HeaderText = "Employee ID"
        Me.employee_id.MinimumWidth = 6
        Me.employee_id.Name = "employee_id"
        Me.employee_id.Width = 125
        '
        'department_id
        '
        Me.department_id.HeaderText = "Department ID"
        Me.department_id.MinimumWidth = 6
        Me.department_id.Name = "department_id"
        Me.department_id.Width = 125
        '
        'property_id
        '
        Me.property_id.HeaderText = "Property ID"
        Me.property_id.MinimumWidth = 6
        Me.property_id.Name = "property_id"
        Me.property_id.Width = 125
        '
        'quantity_requested
        '
        Me.quantity_requested.HeaderText = "Quantity "
        Me.quantity_requested.MinimumWidth = 6
        Me.quantity_requested.Name = "quantity_requested"
        Me.quantity_requested.Width = 125
        '
        'requestDate
        '
        Me.requestDate.HeaderText = "Request Date"
        Me.requestDate.MinimumWidth = 6
        Me.requestDate.Name = "requestDate"
        Me.requestDate.Width = 125
        '
        'approved_by
        '
        Me.approved_by.HeaderText = "Approved by"
        Me.approved_by.MinimumWidth = 6
        Me.approved_by.Name = "approved_by"
        Me.approved_by.Width = 125
        '
        'approvedDate
        '
        Me.approvedDate.HeaderText = "Approved Date"
        Me.approvedDate.MinimumWidth = 6
        Me.approvedDate.Name = "approvedDate"
        Me.approvedDate.Width = 125
        '
        'release_date
        '
        Me.release_date.HeaderText = "Release Date"
        Me.release_date.MinimumWidth = 6
        Me.release_date.Name = "release_date"
        Me.release_date.Width = 125
        '
        'return_date
        '
        Me.return_date.HeaderText = "Return Date"
        Me.return_date.MinimumWidth = 6
        Me.return_date.Name = "return_date"
        Me.return_date.Width = 125
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 125
        '
        'penalty
        '
        Me.penalty.HeaderText = "Penalty"
        Me.penalty.MinimumWidth = 6
        Me.penalty.Name = "penalty"
        Me.penalty.Width = 125
        '
        'updated_at
        '
        Me.updated_at.HeaderText = "Updated At"
        Me.updated_at.MinimumWidth = 6
        Me.updated_at.Name = "updated_at"
        Me.updated_at.Width = 125
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 637)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 48)
        Me.Label1.TabIndex = 159
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
        Me.ttlpropertyrequestmanagement.TabIndex = 158
        Me.ttlpropertyrequestmanagement.Text = "0"
        '
        'maintenancemanagementsearchbar
        '
        Me.maintenancemanagementsearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.maintenancemanagementsearchbar.Location = New System.Drawing.Point(14, 38)
        Me.maintenancemanagementsearchbar.Name = "maintenancemanagementsearchbar"
        Me.maintenancemanagementsearchbar.Size = New System.Drawing.Size(225, 25)
        Me.maintenancemanagementsearchbar.TabIndex = 172
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_status.Location = New System.Drawing.Point(259, 35)
        Me.pm_cbobx_status.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(151, 30)
        Me.pm_cbobx_status.TabIndex = 174
        '
        'issueRequisition
        '
        Me.issueRequisition.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.issueRequisition.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.issueRequisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.issueRequisition.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.issueRequisition.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.issueRequisition.Location = New System.Drawing.Point(764, 35)
        Me.issueRequisition.Name = "issueRequisition"
        Me.issueRequisition.Size = New System.Drawing.Size(115, 28)
        Me.issueRequisition.TabIndex = 175
        Me.issueRequisition.Text = "Issue RIS"
        Me.issueRequisition.UseVisualStyleBackColor = False
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssign.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAssign.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAssign.Location = New System.Drawing.Point(604, 636)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(74, 28)
        Me.btnAssign.TabIndex = 162
        Me.btnAssign.Text = "Assign"
        Me.btnAssign.UseVisualStyleBackColor = False
        Me.btnAssign.Visible = False
        '
        'printPAR
        '
        Me.printPAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.printPAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.printPAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printPAR.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.printPAR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.printPAR.Location = New System.Drawing.Point(660, 35)
        Me.printPAR.Name = "printPAR"
        Me.printPAR.Size = New System.Drawing.Size(97, 28)
        Me.printPAR.TabIndex = 161
        Me.printPAR.Text = "Print PAR/ICS"
        Me.printPAR.UseVisualStyleBackColor = False
        Me.printPAR.Visible = False
        '
        'issuePropertyCard
        '
        Me.issuePropertyCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.issuePropertyCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.issuePropertyCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.issuePropertyCard.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.issuePropertyCard.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.issuePropertyCard.Location = New System.Drawing.Point(538, 35)
        Me.issuePropertyCard.Name = "issuePropertyCard"
        Me.issuePropertyCard.Size = New System.Drawing.Size(116, 28)
        Me.issuePropertyCard.TabIndex = 160
        Me.issuePropertyCard.Text = "Issue Property Acknoledgement "
        Me.issuePropertyCard.UseVisualStyleBackColor = False
        Me.issuePropertyCard.Visible = False
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnApprove.Location = New System.Drawing.Point(843, 636)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(74, 28)
        Me.btnApprove.TabIndex = 154
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnReject.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReject.Location = New System.Drawing.Point(763, 635)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(74, 28)
        Me.btnReject.TabIndex = 155
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'prm_btn_update
        '
        Me.prm_btn_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.prm_btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.prm_btn_update.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.prm_btn_update.ForeColor = System.Drawing.Color.White
        Me.prm_btn_update.Location = New System.Drawing.Point(684, 635)
        Me.prm_btn_update.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.prm_btn_update.Name = "prm_btn_update"
        Me.prm_btn_update.Size = New System.Drawing.Size(74, 28)
        Me.prm_btn_update.TabIndex = 57
        Me.prm_btn_update.Text = "Update"
        Me.prm_btn_update.UseVisualStyleBackColor = False
        '
        'assign
        '
        Me.assign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assign.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.assign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.assign.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.assign.ForeColor = System.Drawing.Color.White
        Me.assign.Location = New System.Drawing.Point(1133, 78)
        Me.assign.Name = "assign"
        Me.assign.Size = New System.Drawing.Size(93, 33)
        Me.assign.TabIndex = 156
        Me.assign.Text = "Assign"
        Me.assign.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.issueRequisition)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.printPAR)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_status)
        Me.pnlFilters.Controls.Add(Me.issuePropertyCard)
        Me.pnlFilters.Controls.Add(Me.maintenancemanagementsearchbar)
        Me.pnlFilters.Location = New System.Drawing.Point(22, 73)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(11, 12, 11, 12)
        Me.pnlFilters.Size = New System.Drawing.Size(895, 82)
        Me.pnlFilters.TabIndex = 404
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(255, 16)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(43, 19)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Status"
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
        'UC_PropertyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertyrequestmanagement)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.prm_btn_update)
        Me.Controls.Add(Me.prm_table1)
        Me.Controls.Add(Me.admin_label_PropertyRequestManagement)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "UC_PropertyRequestManagement"
        Me.Size = New System.Drawing.Size(938, 722)
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_PropertyRequestManagement As Label
    Friend WithEvents prm_table1 As DataGridView
    Friend WithEvents prm_btn_update As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnApprove As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnReject As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents request_id As DataGridViewTextBoxColumn
    Friend WithEvents employee_id As DataGridViewTextBoxColumn
    Friend WithEvents department_id As DataGridViewTextBoxColumn
    Friend WithEvents property_id As DataGridViewTextBoxColumn
    Friend WithEvents quantity_requested As DataGridViewTextBoxColumn
    Friend WithEvents requestDate As DataGridViewTextBoxColumn
    Friend WithEvents approved_by As DataGridViewTextBoxColumn
    Friend WithEvents approvedDate As DataGridViewTextBoxColumn
    Friend WithEvents release_date As DataGridViewTextBoxColumn
    Friend WithEvents return_date As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents penalty As DataGridViewTextBoxColumn
    Friend WithEvents updated_at As DataGridViewTextBoxColumn
    Friend WithEvents assign As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlpropertyrequestmanagement As Label
    Friend WithEvents issuePropertyCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents printPAR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnAssign As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents maintenancemanagementsearchbar As TextBox
    Friend WithEvents requestId As DataGridViewTextBoxColumn
    Friend WithEvents departmentId As DataGridViewTextBoxColumn
    Friend WithEvents requesterName As DataGridViewTextBoxColumn
    Friend WithEvents position As DataGridViewTextBoxColumn
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents purpose As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents quantityRequested As DataGridViewTextBoxColumn
    Friend WithEvents dateOfRequest As DataGridViewTextBoxColumn
    Friend WithEvents dateOfReques As DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As DataGridViewTextBoxColumn
    Friend WithEvents createdAt As DataGridViewTextBoxColumn
    Friend WithEvents approvedBy As DataGridViewTextBoxColumn
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents issueRequisition As Resources.Controls.RoundedButton
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSearch As Label
End Class
