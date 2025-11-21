Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_MaintenanceManagement
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
        Me.admin_label_MaintenanceManagement = New System.Windows.Forms.Label()
        Me.mm_table1 = New System.Windows.Forms.DataGridView()
        Me.LogID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mmProperty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateReported = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warranty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.mm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_MaintenanceManagement
        '
        Me.admin_label_MaintenanceManagement.AutoSize = True
        Me.admin_label_MaintenanceManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_MaintenanceManagement.Location = New System.Drawing.Point(38, 47)
        Me.admin_label_MaintenanceManagement.Name = "admin_label_MaintenanceManagement"
        Me.admin_label_MaintenanceManagement.Size = New System.Drawing.Size(493, 58)
        Me.admin_label_MaintenanceManagement.TabIndex = 34
        Me.admin_label_MaintenanceManagement.Text = "Maintenance Management"
        '
        'mm_table1
        '
        Me.mm_table1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mm_table1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.mm_table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LogID, Me.mmProperty, Me.RepairDescription, Me.DateReported, Me.Warranty, Me.Status, Me.Action})
        Me.mm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.mm_table1.Location = New System.Drawing.Point(48, 125)
        Me.mm_table1.Name = "mm_table1"
        Me.mm_table1.RowHeadersWidth = 51
        Me.mm_table1.RowTemplate.Height = 24
        Me.mm_table1.Size = New System.Drawing.Size(913, 485)
        Me.mm_table1.TabIndex = 35
        '
        'LogID
        '
        Me.LogID.HeaderText = "Log ID"
        Me.LogID.MinimumWidth = 6
        Me.LogID.Name = "LogID"
        Me.LogID.Width = 125
        '
        'mmProperty
        '
        Me.mmProperty.HeaderText = "Property"
        Me.mmProperty.MinimumWidth = 6
        Me.mmProperty.Name = "mmProperty"
        Me.mmProperty.Width = 125
        '
        'RepairDescription
        '
        Me.RepairDescription.HeaderText = "Repair Description"
        Me.RepairDescription.MinimumWidth = 6
        Me.RepairDescription.Name = "RepairDescription"
        Me.RepairDescription.Width = 125
        '
        'DateReported
        '
        Me.DateReported.HeaderText = "Date Reported"
        Me.DateReported.MinimumWidth = 6
        Me.DateReported.Name = "DateReported"
        Me.DateReported.Width = 125
        '
        'Warranty
        '
        Me.Warranty.HeaderText = "Warranty"
        Me.Warranty.MinimumWidth = 6
        Me.Warranty.Name = "Warranty"
        Me.Warranty.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.MinimumWidth = 6
        Me.Action.Name = "Action"
        Me.Action.Width = 125
        '
        'UC_MaintenanceManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.mm_table1)
        Me.Controls.Add(Me.admin_label_MaintenanceManagement)
        Me.Name = "UC_MaintenanceManagement"
        Me.Size = New System.Drawing.Size(1014, 741)
        CType(Me.mm_table1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_MaintenanceManagement As Label
    Friend WithEvents mm_table1 As DataGridView
    Friend WithEvents LogID As DataGridViewTextBoxColumn
    Friend WithEvents mmProperty As DataGridViewTextBoxColumn
    Friend WithEvents RepairDescription As DataGridViewTextBoxColumn
    Friend WithEvents DateReported As DataGridViewTextBoxColumn
    Friend WithEvents Warranty As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
End Class
