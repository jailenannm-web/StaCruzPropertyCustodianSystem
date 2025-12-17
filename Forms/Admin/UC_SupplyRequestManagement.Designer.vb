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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertyrequestmanagement = New System.Windows.Forms.Label()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_table1 = New System.Windows.Forms.DataGridView()
        Me.requestId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requesterName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateOfRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_SupplyRequestManagement = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.supplyrequestmanagementsearchbar = New System.Windows.Forms.TextBox()
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'printPAR
        '
        Me.printPAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.printPAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.printPAR.CornerRadius = 15
        Me.printPAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printPAR.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.printPAR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.printPAR.Location = New System.Drawing.Point(1184, 707)
        Me.printPAR.Margin = New System.Windows.Forms.Padding(4)
        Me.printPAR.Name = "printPAR"
        Me.printPAR.Size = New System.Drawing.Size(153, 33)
        Me.printPAR.TabIndex = 170
        Me.printPAR.Text = "Print PAR/ICS"
        Me.printPAR.UseVisualStyleBackColor = False
        '
        'issueRequisition
        '
        Me.issueRequisition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.issueRequisition.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.issueRequisition.CornerRadius = 15
        Me.issueRequisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.issueRequisition.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.issueRequisition.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.issueRequisition.Location = New System.Drawing.Point(1023, 707)
        Me.issueRequisition.Margin = New System.Windows.Forms.Padding(4)
        Me.issueRequisition.Name = "issueRequisition"
        Me.issueRequisition.Size = New System.Drawing.Size(153, 33)
        Me.issueRequisition.TabIndex = 169
        Me.issueRequisition.Text = "Issue RIS"
        Me.issueRequisition.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(57, 698)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "TOTAL:"
        '
        'ttlpropertyrequestmanagement
        '
        Me.ttlpropertyrequestmanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlpropertyrequestmanagement.AutoSize = True
        Me.ttlpropertyrequestmanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlpropertyrequestmanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlpropertyrequestmanagement.Location = New System.Drawing.Point(208, 698)
        Me.ttlpropertyrequestmanagement.Name = "ttlpropertyrequestmanagement"
        Me.ttlpropertyrequestmanagement.Size = New System.Drawing.Size(47, 58)
        Me.ttlpropertyrequestmanagement.TabIndex = 167
        Me.ttlpropertyrequestmanagement.Text = "0"
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnApprove.CornerRadius = 15
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnApprove.Location = New System.Drawing.Point(1238, 62)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(99, 34)
        Me.btnApprove.TabIndex = 165
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
        Me.btnReject.Location = New System.Drawing.Point(1132, 61)
        Me.btnReject.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(99, 35)
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
        Me.prm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requestId, Me.requesterName, Me.departmentId, Me.dateOfRequest, Me.itemName, Me.quantityRequested, Me.approvedBy, Me.approvedDate, Me.createdAt, Me.updatedAt})
        Me.prm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.Location = New System.Drawing.Point(67, 111)
        Me.prm_table1.Name = "prm_table1"
        Me.prm_table1.RowHeadersWidth = 51
        Me.prm_table1.RowTemplate.Height = 24
        Me.prm_table1.Size = New System.Drawing.Size(1270, 573)
        Me.prm_table1.TabIndex = 163
        '
        'requestId
        '
        Me.requestId.HeaderText = "requestId"
        Me.requestId.MinimumWidth = 6
        Me.requestId.Name = "requestId"
        Me.requestId.Width = 125
        '
        'requesterName
        '
        Me.requesterName.HeaderText = "requesterName"
        Me.requesterName.MinimumWidth = 6
        Me.requesterName.Name = "requesterName"
        Me.requesterName.Width = 125
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "departmentId"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Width = 125
        '
        'dateOfRequest
        '
        Me.dateOfRequest.HeaderText = "dateOfRequest"
        Me.dateOfRequest.MinimumWidth = 6
        Me.dateOfRequest.Name = "dateOfRequest"
        Me.dateOfRequest.Width = 125
        '
        'itemName
        '
        Me.itemName.HeaderText = "itemName"
        Me.itemName.MinimumWidth = 6
        Me.itemName.Name = "itemName"
        Me.itemName.Width = 125
        '
        'quantityRequested
        '
        Me.quantityRequested.HeaderText = "quantityRequested"
        Me.quantityRequested.MinimumWidth = 6
        Me.quantityRequested.Name = "quantityRequested"
        Me.quantityRequested.Width = 125
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
        Me.admin_label_SupplyRequestManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_SupplyRequestManagement.Location = New System.Drawing.Point(57, 46)
        Me.admin_label_SupplyRequestManagement.Name = "admin_label_SupplyRequestManagement"
        Me.admin_label_SupplyRequestManagement.Size = New System.Drawing.Size(531, 58)
        Me.admin_label_SupplyRequestManagement.TabIndex = 162
        Me.admin_label_SupplyRequestManagement.Text = "Supply Request Management"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(634, 52)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 44)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 179
        Me.PictureBox2.TabStop = False
        '
        'supplyrequestmanagementsearchbar
        '
        Me.supplyrequestmanagementsearchbar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.supplyrequestmanagementsearchbar.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyrequestmanagementsearchbar.Location = New System.Drawing.Point(677, 54)
        Me.supplyrequestmanagementsearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.supplyrequestmanagementsearchbar.Name = "supplyrequestmanagementsearchbar"
        Me.supplyrequestmanagementsearchbar.Size = New System.Drawing.Size(345, 42)
        Me.supplyrequestmanagementsearchbar.TabIndex = 178
        '
        'UC_SupplyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.supplyrequestmanagementsearchbar)
        Me.Controls.Add(Me.printPAR)
        Me.Controls.Add(Me.issueRequisition)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertyrequestmanagement)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.prm_table1)
        Me.Controls.Add(Me.admin_label_SupplyRequestManagement)
        Me.Name = "UC_SupplyRequestManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents printPAR As Resources.Controls.RoundedButton
    Friend WithEvents issueRequisition As Resources.Controls.RoundedButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ttlpropertyrequestmanagement As System.Windows.Forms.Label
    Friend WithEvents btnApprove As Resources.Controls.RoundedButton
    Friend WithEvents btnReject As Resources.Controls.RoundedButton
    Friend WithEvents prm_table1 As System.Windows.Forms.DataGridView
    Friend WithEvents admin_label_SupplyRequestManagement As System.Windows.Forms.Label
    Friend WithEvents requestId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requesterName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents departmentId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateOfRequest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantityRequested As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents approvedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents approvedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents createdAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updatedAt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents supplyrequestmanagementsearchbar As System.Windows.Forms.TextBox
End Class
