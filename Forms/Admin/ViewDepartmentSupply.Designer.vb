<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewDepartmentSupply
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
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SupplyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityAssigned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateAssigned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssignedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConditionStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepartmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsageStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Custodian = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarrantyStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NextMaintenanceSchedule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(47, 49)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(602, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 38
        Me.admin_label_DepartmentManagement.Text = "Department Management Supply"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SupplyID, Me.SupplyName, Me.Category, Me.QuantityAssigned, Me.UnitCost, Me.TotalValue, Me.DateAssigned, Me.AssignedBy, Me.ConditionStatus, Me.DepartmentID, Me.UsageStatus, Me.Custodian, Me.WarrantyStatus, Me.NextMaintenanceSchedule})
        Me.DataGridView1.Location = New System.Drawing.Point(57, 127)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1113, 581)
        Me.DataGridView1.TabIndex = 39
        '
        'SupplyID
        '
        Me.SupplyID.HeaderText = "Supply ID"
        Me.SupplyID.MinimumWidth = 6
        Me.SupplyID.Name = "SupplyID"
        Me.SupplyID.Width = 125
        '
        'SupplyName
        '
        Me.SupplyName.HeaderText = "Supply Name"
        Me.SupplyName.MinimumWidth = 6
        Me.SupplyName.Name = "SupplyName"
        Me.SupplyName.Width = 125
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.MinimumWidth = 6
        Me.Category.Name = "Category"
        Me.Category.Width = 125
        '
        'QuantityAssigned
        '
        Me.QuantityAssigned.HeaderText = "Quantity Assigned"
        Me.QuantityAssigned.MinimumWidth = 6
        Me.QuantityAssigned.Name = "QuantityAssigned"
        Me.QuantityAssigned.Width = 125
        '
        'UnitCost
        '
        Me.UnitCost.HeaderText = "Unit Cost"
        Me.UnitCost.MinimumWidth = 6
        Me.UnitCost.Name = "UnitCost"
        Me.UnitCost.Width = 125
        '
        'TotalValue
        '
        Me.TotalValue.HeaderText = "Total Value"
        Me.TotalValue.MinimumWidth = 6
        Me.TotalValue.Name = "TotalValue"
        Me.TotalValue.Width = 125
        '
        'DateAssigned
        '
        Me.DateAssigned.HeaderText = "Date Assigned"
        Me.DateAssigned.MinimumWidth = 6
        Me.DateAssigned.Name = "DateAssigned"
        Me.DateAssigned.Width = 125
        '
        'AssignedBy
        '
        Me.AssignedBy.HeaderText = "Assigned By"
        Me.AssignedBy.MinimumWidth = 6
        Me.AssignedBy.Name = "AssignedBy"
        Me.AssignedBy.Width = 125
        '
        'ConditionStatus
        '
        Me.ConditionStatus.HeaderText = "Condition Status"
        Me.ConditionStatus.MinimumWidth = 6
        Me.ConditionStatus.Name = "ConditionStatus"
        Me.ConditionStatus.Width = 125
        '
        'DepartmentID
        '
        Me.DepartmentID.HeaderText = "Department ID"
        Me.DepartmentID.MinimumWidth = 6
        Me.DepartmentID.Name = "DepartmentID"
        Me.DepartmentID.Width = 125
        '
        'UsageStatus
        '
        Me.UsageStatus.HeaderText = "Usage Status"
        Me.UsageStatus.MinimumWidth = 6
        Me.UsageStatus.Name = "UsageStatus"
        Me.UsageStatus.Width = 125
        '
        'Custodian
        '
        Me.Custodian.HeaderText = "Custodian"
        Me.Custodian.MinimumWidth = 6
        Me.Custodian.Name = "Custodian"
        Me.Custodian.Width = 125
        '
        'WarrantyStatus
        '
        Me.WarrantyStatus.HeaderText = "Warranty Status"
        Me.WarrantyStatus.MinimumWidth = 6
        Me.WarrantyStatus.Name = "WarrantyStatus"
        Me.WarrantyStatus.Width = 125
        '
        'NextMaintenanceSchedule
        '
        Me.NextMaintenanceSchedule.HeaderText = "Next Maintenance Schedule"
        Me.NextMaintenanceSchedule.MinimumWidth = 6
        Me.NextMaintenanceSchedule.Name = "NextMaintenanceSchedule"
        Me.NextMaintenanceSchedule.Width = 125
        '
        'ViewDepartmentSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "ViewDepartmentSupply"
        Me.Size = New System.Drawing.Size(1239, 774)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SupplyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityAssigned As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateAssigned As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssignedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConditionStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsageStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Custodian As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarrantyStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NextMaintenanceSchedule As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
