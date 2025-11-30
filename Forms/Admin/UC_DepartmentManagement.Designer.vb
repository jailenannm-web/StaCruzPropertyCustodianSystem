Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_DepartmentManagement
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
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.admin_deptmanagement = New System.Windows.Forms.DataGridView()
        Me.DepartmentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepartmentHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepartmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalProperties = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSupplies = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttldepartmentmanagement = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.admin_deptmanagement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(49, 54)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(475, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 37
        Me.admin_label_DepartmentManagement.Text = "Department Management"
        '
        'admin_deptmanagement
        '
        Me.admin_deptmanagement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_deptmanagement.BackgroundColor = System.Drawing.Color.White
        Me.admin_deptmanagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.admin_deptmanagement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DepartmentName, Me.DepartmentHead, Me.DepartmentID, Me.Location, Me.TotalProperties, Me.TotalSupplies, Me.Status})
        Me.admin_deptmanagement.Location = New System.Drawing.Point(59, 116)
        Me.admin_deptmanagement.Margin = New System.Windows.Forms.Padding(4)
        Me.admin_deptmanagement.Name = "admin_deptmanagement"
        Me.admin_deptmanagement.RowHeadersWidth = 51
        Me.admin_deptmanagement.Size = New System.Drawing.Size(1270, 573)
        Me.admin_deptmanagement.TabIndex = 147
        '
        'DepartmentName
        '
        Me.DepartmentName.HeaderText = "Department Name"
        Me.DepartmentName.MinimumWidth = 6
        Me.DepartmentName.Name = "DepartmentName"
        Me.DepartmentName.Width = 125
        '
        'DepartmentHead
        '
        Me.DepartmentHead.HeaderText = "Department Head"
        Me.DepartmentHead.MinimumWidth = 6
        Me.DepartmentHead.Name = "DepartmentHead"
        Me.DepartmentHead.Width = 125
        '
        'DepartmentID
        '
        Me.DepartmentID.HeaderText = "Department I.D"
        Me.DepartmentID.MinimumWidth = 6
        Me.DepartmentID.Name = "DepartmentID"
        Me.DepartmentID.Width = 125
        '
        'Location
        '
        Me.Location.HeaderText = "Location"
        Me.Location.MinimumWidth = 6
        Me.Location.Name = "Location"
        Me.Location.Width = 125
        '
        'TotalProperties
        '
        Me.TotalProperties.HeaderText = "Total Properties"
        Me.TotalProperties.MinimumWidth = 6
        Me.TotalProperties.Name = "TotalProperties"
        Me.TotalProperties.Width = 125
        '
        'TotalSupplies
        '
        Me.TotalSupplies.HeaderText = "Total Supplies"
        Me.TotalSupplies.MinimumWidth = 6
        Me.TotalSupplies.Name = "TotalSupplies"
        Me.TotalSupplies.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'ttldepartmentmanagement
        '
        Me.ttldepartmentmanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttldepartmentmanagement.AutoSize = True
        Me.ttldepartmentmanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttldepartmentmanagement.ForeColor = System.Drawing.Color.Black
        Me.ttldepartmentmanagement.Location = New System.Drawing.Point(200, 705)
        Me.ttldepartmentmanagement.Name = "ttldepartmentmanagement"
        Me.ttldepartmentmanagement.Size = New System.Drawing.Size(47, 58)
        Me.ttldepartmentmanagement.TabIndex = 152
        Me.ttldepartmentmanagement.Text = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(49, 705)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "TOTAL:"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1184, 62)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 31)
        Me.pm_cbobx_status.TabIndex = 154
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(1009, 62)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 31)
        Me.pm_cbobx_categ.TabIndex = 155
        Me.pm_cbobx_categ.Text = "Categories"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1230, 705)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 34)
        Me.btnAdd.TabIndex = 156
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1123, 705)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 35)
        Me.btnDelete.TabIndex = 157
        Me.btnDelete.Text = "Edit"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'UC_DepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttldepartmentmanagement)
        Me.Controls.Add(Me.admin_deptmanagement)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "UC_DepartmentManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
        CType(Me.admin_deptmanagement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents admin_label_DepartmentManagement As Label
    Friend WithEvents BackgroundWorker1 As BackgroundWorker
    Friend WithEvents admin_deptmanagement As DataGridView
    Friend WithEvents ttldepartmentmanagement As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents btnAdd As Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As Resources.Controls.RoundedButton
    Friend WithEvents DepartmentName As DataGridViewTextBoxColumn
    Friend WithEvents DepartmentHead As DataGridViewTextBoxColumn
    Friend WithEvents DepartmentID As DataGridViewTextBoxColumn
    Friend WithEvents Location As DataGridViewTextBoxColumn
    Friend WithEvents TotalProperties As DataGridViewTextBoxColumn
    Friend WithEvents TotalSupplies As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
End Class
