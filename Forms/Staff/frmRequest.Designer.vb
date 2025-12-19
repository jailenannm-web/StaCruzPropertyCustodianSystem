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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.myrequestssearchbar = New System.Windows.Forms.TextBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.btnRequisitionSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRequest
        '
        Me.lblRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRequest.AutoSize = True
        Me.lblRequest.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequest.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblRequest.Location = New System.Drawing.Point(72, 88)
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
        Me.DataGridView1.Location = New System.Drawing.Point(82, 150)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1275, 884)
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
        Me.status.Visible = False
        Me.status.Width = 125
        '
        'approvedBy
        '
        Me.approvedBy.HeaderText = "Approved By"
        Me.approvedBy.MinimumWidth = 6
        Me.approvedBy.Name = "approvedBy"
        Me.approvedBy.Visible = False
        Me.approvedBy.Width = 125
        '
        'approvedDate
        '
        Me.approvedDate.HeaderText = "Approved Date"
        Me.approvedDate.MinimumWidth = 6
        Me.approvedDate.Name = "approvedDate"
        Me.approvedDate.Visible = False
        Me.approvedDate.Width = 125
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        Me.remarks.Visible = False
        Me.remarks.Width = 125
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(343, 88)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 42)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 186
        Me.PictureBox2.TabStop = False
        '
        'myrequestssearchbar
        '
        Me.myrequestssearchbar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.myrequestssearchbar.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.myrequestssearchbar.Location = New System.Drawing.Point(408, 88)
        Me.myrequestssearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.myrequestssearchbar.Name = "myrequestssearchbar"
        Me.myrequestssearchbar.Size = New System.Drawing.Size(367, 42)
        Me.myrequestssearchbar.TabIndex = 185
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(990, 99)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 31)
        Me.pm_cbobx_status.TabIndex = 183
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(815, 99)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 31)
        Me.pm_cbobx_categ.TabIndex = 184
        Me.pm_cbobx_categ.Text = "Categories"
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
        Me.btnRequisitionSlip.Location = New System.Drawing.Point(1175, 1070)
        Me.btnRequisitionSlip.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRequisitionSlip.Name = "btnRequisitionSlip"
        Me.btnRequisitionSlip.Size = New System.Drawing.Size(182, 34)
        Me.btnRequisitionSlip.TabIndex = 187
        Me.btnRequisitionSlip.Text = "Requisition Slip"
        Me.btnRequisitionSlip.UseVisualStyleBackColor = False
        '
        'frmRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1467, 1175)
        Me.Controls.Add(Me.btnRequisitionSlip)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.myrequestssearchbar)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblRequest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRequest"
        Me.Text = "frmRequest"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRequest As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PictureBox2 As PictureBox
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
End Class
