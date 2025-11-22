Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_PropertyRequestManagement
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
        Me.admin_label_PropertyRequestManagement = New System.Windows.Forms.Label()
        Me.prm_table1 = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_btn_update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDeny = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.request_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employee_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.department_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.property_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity_requested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requestDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approved_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.release_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.return_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.penalty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updated_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_PropertyRequestManagement
        '
        Me.admin_label_PropertyRequestManagement.AutoSize = True
        Me.admin_label_PropertyRequestManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_PropertyRequestManagement.Location = New System.Drawing.Point(35, 53)
        Me.admin_label_PropertyRequestManagement.Name = "admin_label_PropertyRequestManagement"
        Me.admin_label_PropertyRequestManagement.Size = New System.Drawing.Size(560, 58)
        Me.admin_label_PropertyRequestManagement.TabIndex = 33
        Me.admin_label_PropertyRequestManagement.Text = "Property Request Management"
        '
        'prm_table1
        '
        Me.prm_table1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_table1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.prm_table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.prm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.request_id, Me.employee_id, Me.department_id, Me.property_id, Me.quantity_requested, Me.purpose, Me.requestDate, Me.status, Me.approved_by, Me.approvedDate, Me.release_date, Me.return_date, Me.remarks, Me.penalty, Me.updated_at})
        Me.prm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.Location = New System.Drawing.Point(45, 114)
        Me.prm_table1.Name = "prm_table1"
        Me.prm_table1.RowHeadersWidth = 51
        Me.prm_table1.RowTemplate.Height = 24
        Me.prm_table1.Size = New System.Drawing.Size(1162, 485)
        Me.prm_table1.TabIndex = 34
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(826, 648)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(121, 34)
        Me.btnAdd.TabIndex = 152
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(700, 647)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 35)
        Me.btnDelete.TabIndex = 153
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'prm_btn_update
        '
        Me.prm_btn_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_btn_update.CornerRadius = 15
        Me.prm_btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.prm_btn_update.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prm_btn_update.ForeColor = System.Drawing.Color.White
        Me.prm_btn_update.Location = New System.Drawing.Point(564, 649)
        Me.prm_btn_update.Name = "prm_btn_update"
        Me.prm_btn_update.Size = New System.Drawing.Size(129, 33)
        Me.prm_btn_update.TabIndex = 57
        Me.prm_btn_update.Text = "Update"
        Me.prm_btn_update.UseVisualStyleBackColor = False
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnApprove.CornerRadius = 15
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnApprove.Location = New System.Drawing.Point(1083, 647)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(121, 34)
        Me.btnApprove.TabIndex = 154
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnDeny
        '
        Me.btnDeny.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeny.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnDeny.CornerRadius = 15
        Me.btnDeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeny.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeny.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDeny.Location = New System.Drawing.Point(955, 646)
        Me.btnDeny.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeny.Name = "btnDeny"
        Me.btnDeny.Size = New System.Drawing.Size(120, 35)
        Me.btnDeny.TabIndex = 155
        Me.btnDeny.Text = "Deny"
        Me.btnDeny.UseVisualStyleBackColor = False
        '
        'request_id
        '
        Me.request_id.HeaderText = "Request ID"
        Me.request_id.MinimumWidth = 6
        Me.request_id.Name = "request_id"
        '
        'employee_id
        '
        Me.employee_id.HeaderText = "Employee ID"
        Me.employee_id.MinimumWidth = 6
        Me.employee_id.Name = "employee_id"
        '
        'department_id
        '
        Me.department_id.HeaderText = "Department ID"
        Me.department_id.MinimumWidth = 6
        Me.department_id.Name = "department_id"
        '
        'property_id
        '
        Me.property_id.HeaderText = "Property ID"
        Me.property_id.MinimumWidth = 6
        Me.property_id.Name = "property_id"
        '
        'quantity_requested
        '
        Me.quantity_requested.HeaderText = "Quantity "
        Me.quantity_requested.MinimumWidth = 6
        Me.quantity_requested.Name = "quantity_requested"
        '
        'purpose
        '
        Me.purpose.HeaderText = "Purpose"
        Me.purpose.MinimumWidth = 6
        Me.purpose.Name = "purpose"
        '
        'requestDate
        '
        Me.requestDate.HeaderText = "Request Date"
        Me.requestDate.MinimumWidth = 6
        Me.requestDate.Name = "requestDate"
        Me.requestDate.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        '
        'approved_by
        '
        Me.approved_by.HeaderText = "Approved by"
        Me.approved_by.MinimumWidth = 6
        Me.approved_by.Name = "approved_by"
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
        '
        'return_date
        '
        Me.return_date.HeaderText = "Return Date"
        Me.return_date.MinimumWidth = 6
        Me.return_date.Name = "return_date"
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
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
        '
        'UC_PropertyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnDeny)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.prm_btn_update)
        Me.Controls.Add(Me.prm_table1)
        Me.Controls.Add(Me.admin_label_PropertyRequestManagement)
        Me.Name = "UC_PropertyRequestManagement"
        Me.Size = New System.Drawing.Size(1262, 770)
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_PropertyRequestManagement As Label
    Friend WithEvents prm_table1 As DataGridView
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
    Friend WithEvents prm_btn_update As Resources.Controls.RoundedButton
    Friend WithEvents btnApprove As Resources.Controls.RoundedButton
    Friend WithEvents btnDeny As Resources.Controls.RoundedButton
    Friend WithEvents request_id As DataGridViewTextBoxColumn
    Friend WithEvents employee_id As DataGridViewTextBoxColumn
    Friend WithEvents department_id As DataGridViewTextBoxColumn
    Friend WithEvents property_id As DataGridViewTextBoxColumn
    Friend WithEvents quantity_requested As DataGridViewTextBoxColumn
    Friend WithEvents purpose As DataGridViewTextBoxColumn
    Friend WithEvents requestDate As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents approved_by As DataGridViewTextBoxColumn
    Friend WithEvents approvedDate As DataGridViewTextBoxColumn
    Friend WithEvents release_date As DataGridViewTextBoxColumn
    Friend WithEvents return_date As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents penalty As DataGridViewTextBoxColumn
    Friend WithEvents updated_at As DataGridViewTextBoxColumn
End Class
