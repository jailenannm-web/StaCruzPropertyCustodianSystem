Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports StaCruzPropertyCustodianSystem.Resources.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRequest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.lblRequest = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.requestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requesterName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateOfRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.myrequestssearchbar = New System.Windows.Forms.TextBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.btnRequisitionSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRequest
        '
        Me.lblRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRequest.AutoSize = True
        Me.lblRequest.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequest.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblRequest.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblRequest.Location = New System.Drawing.Point(13, 9)
        Me.lblRequest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRequest.Name = "lblRequest"
        Me.lblRequest.Size = New System.Drawing.Size(238, 58)
        Me.lblRequest.TabIndex = 1
        Me.lblRequest.Text = "My Requests"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requestId, Me.requesterName, Me.position, Me.departmentId, Me.dateOfRequest, Me.itemName, Me.description, Me.quantityRequested, Me.unit, Me.purpose, Me.status, Me.approvedBy, Me.approvedDate, Me.remarks})
        Me.DataGridView1.Location = New System.Drawing.Point(29, 210)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1185, 566)
        Me.DataGridView1.TabIndex = 155
        '
        'requestId
        '
        Me.requestId.HeaderText = "Request ID"
        Me.requestId.MinimumWidth = 6
        Me.requestId.Name = "requestId"
        Me.requestId.Width = 125
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
        'departmentId
        '
        Me.departmentId.HeaderText = "Department ID"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Width = 125
        '
        'dateOfRequest
        '
        Me.dateOfRequest.HeaderText = "Date of Request"
        Me.dateOfRequest.MinimumWidth = 6
        Me.dateOfRequest.Name = "dateOfRequest"
        Me.dateOfRequest.Width = 125
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
        'quantityRequested
        '
        Me.quantityRequested.HeaderText = "Quantity Requested"
        Me.quantityRequested.MinimumWidth = 6
        Me.quantityRequested.Name = "quantityRequested"
        Me.quantityRequested.Width = 125
        '
        'unit
        '
        Me.unit.HeaderText = "Unit"
        Me.unit.MinimumWidth = 6
        Me.unit.Name = "unit"
        Me.unit.Visible = False
        Me.unit.Width = 125
        '
        'purpose
        '
        Me.purpose.HeaderText = "Purpose"
        Me.purpose.MinimumWidth = 6
        Me.purpose.Name = "purpose"
        Me.purpose.Visible = False
        Me.purpose.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 125
        '
        'approvedBy
        '
        Me.approvedBy.HeaderText = "Approved By"
        Me.approvedBy.MinimumWidth = 6
        Me.approvedBy.Name = "approvedBy"
        Me.approvedBy.Width = 150
        '
        'approvedDate
        '
        Me.approvedDate.HeaderText = "Approved Date"
        Me.approvedDate.MinimumWidth = 6
        Me.approvedDate.Name = "approvedDate"
        Me.approvedDate.Width = 130
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 200
        '
        'myrequestssearchbar
        '
        Me.myrequestssearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.myrequestssearchbar.Location = New System.Drawing.Point(19, 51)
        Me.myrequestssearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.myrequestssearchbar.Name = "myrequestssearchbar"
        Me.myrequestssearchbar.Size = New System.Drawing.Size(300, 30)
        Me.myrequestssearchbar.TabIndex = 185
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_status.Location = New System.Drawing.Point(595, 49)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(180, 34)
        Me.pm_cbobx_status.TabIndex = 183
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(345, 51)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(200, 34)
        Me.pm_cbobx_categ.TabIndex = 184
        '
        'btnRequisitionSlip
        '
        Me.btnRequisitionSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRequisitionSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRequisitionSlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRequisitionSlip.CornerRadius = 30
        Me.btnRequisitionSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequisitionSlip.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.btnRequisitionSlip.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRequisitionSlip.Location = New System.Drawing.Point(1029, 799)
        Me.btnRequisitionSlip.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRequisitionSlip.Name = "btnRequisitionSlip"
        Me.btnRequisitionSlip.Size = New System.Drawing.Size(182, 34)
        Me.btnRequisitionSlip.TabIndex = 187
        Me.btnRequisitionSlip.Text = "Requisition Slip"
        Me.btnRequisitionSlip.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.lblStatus)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_status)
        Me.pnlFilters.Controls.Add(Me.myrequestssearchbar)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_categ)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Location = New System.Drawing.Point(29, 90)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlFilters.Size = New System.Drawing.Size(1193, 100)
        Me.pnlFilters.TabIndex = 188
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(590, 21)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(55, 25)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "Status"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(340, 20)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(77, 25)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(20, 20)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(122, 25)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search Request"
        '
        'frmRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1251, 889)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.btnRequisitionSlip)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblRequest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRequest"
        Me.Text = "frmRequest"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRequest As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents myrequestssearchbar As TextBox
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents requestId As DataGridViewTextBoxColumn
    Friend WithEvents requesterName As DataGridViewTextBoxColumn
    Friend WithEvents position As DataGridViewTextBoxColumn
    Friend WithEvents departmentId As DataGridViewTextBoxColumn
    Friend WithEvents dateOfRequest As DataGridViewTextBoxColumn
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents quantityRequested As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents purpose As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents approvedBy As DataGridViewTextBoxColumn
    Friend WithEvents approvedDate As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents btnRequisitionSlip As RoundedButton
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSearch As Label
End Class
