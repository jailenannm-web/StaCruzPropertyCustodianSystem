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
        Me.issuePropertyCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertyrequestmanagement = New System.Windows.Forms.Label()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnReject = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_table1 = New System.Windows.Forms.DataGridView()
        Me.NameOfRequester = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Department = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateOfRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.admin_label_SupplyRequestManagement = New System.Windows.Forms.Label()
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'issuePropertyCard
        '
        Me.issuePropertyCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.issuePropertyCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.issuePropertyCard.CornerRadius = 15
        Me.issuePropertyCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.issuePropertyCard.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.issuePropertyCard.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.issuePropertyCard.Location = New System.Drawing.Point(1023, 707)
        Me.issuePropertyCard.Margin = New System.Windows.Forms.Padding(4)
        Me.issuePropertyCard.Name = "issuePropertyCard"
        Me.issuePropertyCard.Size = New System.Drawing.Size(153, 33)
        Me.issuePropertyCard.TabIndex = 169
        Me.issuePropertyCard.Text = "Issue Property Card"
        Me.issuePropertyCard.UseVisualStyleBackColor = False
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
        Me.prm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameOfRequester, Me.Department, Me.DateOfRequest, Me.ItemName, Me.QuantityRequested, Me.Purpose, Me.Status})
        Me.prm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.Location = New System.Drawing.Point(67, 111)
        Me.prm_table1.Name = "prm_table1"
        Me.prm_table1.RowHeadersWidth = 51
        Me.prm_table1.RowTemplate.Height = 24
        Me.prm_table1.Size = New System.Drawing.Size(1270, 573)
        Me.prm_table1.TabIndex = 163
        '
        'NameOfRequester
        '
        Me.NameOfRequester.HeaderText = "Name Of Requester"
        Me.NameOfRequester.MinimumWidth = 6
        Me.NameOfRequester.Name = "NameOfRequester"
        Me.NameOfRequester.Width = 125
        '
        'Department
        '
        Me.Department.HeaderText = "Department"
        Me.Department.MinimumWidth = 6
        Me.Department.Name = "Department"
        Me.Department.Width = 125
        '
        'DateOfRequest
        '
        Me.DateOfRequest.HeaderText = "Date Of Request"
        Me.DateOfRequest.MinimumWidth = 6
        Me.DateOfRequest.Name = "DateOfRequest"
        Me.DateOfRequest.Width = 125
        '
        'ItemName
        '
        Me.ItemName.HeaderText = "Item Name"
        Me.ItemName.MinimumWidth = 6
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Width = 125
        '
        'QuantityRequested
        '
        Me.QuantityRequested.HeaderText = "Quantity Requested"
        Me.QuantityRequested.MinimumWidth = 6
        Me.QuantityRequested.Name = "QuantityRequested"
        Me.QuantityRequested.Width = 125
        '
        'Purpose
        '
        Me.Purpose.HeaderText = "Purpose"
        Me.Purpose.MinimumWidth = 6
        Me.Purpose.Name = "Purpose"
        Me.Purpose.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
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
        'UC_SupplyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.printPAR)
        Me.Controls.Add(Me.issuePropertyCard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertyrequestmanagement)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.prm_table1)
        Me.Controls.Add(Me.admin_label_SupplyRequestManagement)
        Me.Name = "UC_SupplyRequestManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents printPAR As Resources.Controls.RoundedButton
    Friend WithEvents issuePropertyCard As Resources.Controls.RoundedButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ttlpropertyrequestmanagement As System.Windows.Forms.Label
    Friend WithEvents btnApprove As Resources.Controls.RoundedButton
    Friend WithEvents btnReject As Resources.Controls.RoundedButton
    Friend WithEvents prm_table1 As System.Windows.Forms.DataGridView
    Friend WithEvents NameOfRequester As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Department As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfRequest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityRequested As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Purpose As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents admin_label_SupplyRequestManagement As System.Windows.Forms.Label
End Class
