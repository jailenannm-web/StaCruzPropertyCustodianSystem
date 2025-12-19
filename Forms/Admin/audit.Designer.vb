<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class audit
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
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.cmbLogType = New System.Windows.Forms.ComboBox()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.logId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ipAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userAgent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(389, 221)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(243, 22)
        Me.dtFrom.TabIndex = 199
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(122, 221)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(231, 22)
        Me.dtTo.TabIndex = 200
        '
        'cmbLogType
        '
        Me.cmbLogType.FormattingEnabled = True
        Me.cmbLogType.Location = New System.Drawing.Point(737, 222)
        Me.cmbLogType.Name = "cmbLogType"
        Me.cmbLogType.Size = New System.Drawing.Size(121, 24)
        Me.cmbLogType.TabIndex = 201
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(113, 109)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(163, 38)
        Me.admin_label_DepartmentManagement.TabIndex = 195
        Me.admin_label_DepartmentManagement.Text = "Audit Log"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.logId, Me.userId, Me.action, Me.tableName, Me.recordId, Me.description, Me.ipAddress, Me.userAgent, Me.createdAt})
        Me.DataGridView1.Location = New System.Drawing.Point(120, 266)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1230, 427)
        Me.DataGridView1.TabIndex = 196
        '
        'logId
        '
        Me.logId.HeaderText = "Log ID"
        Me.logId.MinimumWidth = 6
        Me.logId.Name = "logId"
        Me.logId.Width = 150
        '
        'userId
        '
        Me.userId.HeaderText = "User ID"
        Me.userId.MinimumWidth = 6
        Me.userId.Name = "userId"
        Me.userId.Width = 150
        '
        'action
        '
        Me.action.HeaderText = "Action"
        Me.action.MinimumWidth = 6
        Me.action.Name = "action"
        Me.action.Width = 150
        '
        'tableName
        '
        Me.tableName.HeaderText = "Table Name"
        Me.tableName.MinimumWidth = 6
        Me.tableName.Name = "tableName"
        Me.tableName.Width = 150
        '
        'recordId
        '
        Me.recordId.HeaderText = "Record ID"
        Me.recordId.MinimumWidth = 6
        Me.recordId.Name = "recordId"
        Me.recordId.Width = 150
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.MinimumWidth = 6
        Me.description.Name = "description"
        Me.description.Width = 150
        '
        'ipAddress
        '
        Me.ipAddress.HeaderText = "IP Address"
        Me.ipAddress.MinimumWidth = 6
        Me.ipAddress.Name = "ipAddress"
        Me.ipAddress.Width = 150
        '
        'userAgent
        '
        Me.userAgent.HeaderText = "User Agent"
        Me.userAgent.MinimumWidth = 6
        Me.userAgent.Name = "userAgent"
        Me.userAgent.Width = 150
        '
        'createdAt
        '
        Me.createdAt.HeaderText = "Created At"
        Me.createdAt.MinimumWidth = 6
        Me.createdAt.Name = "createdAt"
        Me.createdAt.Width = 150
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(1540, 997)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 198
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1693, 997)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 197
        Me.btnSave.Text = "Export Logs"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'audit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cmbLogType)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "audit"
        Me.Size = New System.Drawing.Size(1942, 1102)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents cmbLogType As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents logId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents action As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recordId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ipAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userAgent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents createdAt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
