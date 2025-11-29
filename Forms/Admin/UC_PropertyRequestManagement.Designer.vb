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
        Me.assign = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnApprove = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDeny = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.prm_btn_update = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ttlpropertyrequestmanagement = New System.Windows.Forms.Label()
        Me.NameOfRequester = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Department = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateOfRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityRequested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.prm_table1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'admin_label_PropertyRequestManagement
        '
        Me.admin_label_PropertyRequestManagement.AutoSize = True
        Me.admin_label_PropertyRequestManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_PropertyRequestManagement.Location = New System.Drawing.Point(52, 61)
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
        Me.prm_table1.BackgroundColor = System.Drawing.Color.White
        Me.prm_table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.prm_table1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameOfRequester, Me.Department, Me.DateOfRequest, Me.ItemName, Me.QuantityRequested, Me.Purpose, Me.Status})
        Me.prm_table1.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.prm_table1.Location = New System.Drawing.Point(62, 126)
        Me.prm_table1.Name = "prm_table1"
        Me.prm_table1.RowHeadersWidth = 51
        Me.prm_table1.RowTemplate.Height = 24
        Me.prm_table1.Size = New System.Drawing.Size(1270, 573)
        Me.prm_table1.TabIndex = 34
        '
        'assign
        '
        Me.assign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assign.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.assign.CornerRadius = 15
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
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnApprove.CornerRadius = 15
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnApprove.Location = New System.Drawing.Point(1233, 717)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(99, 34)
        Me.btnApprove.TabIndex = 154
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnDeny
        '
        Me.btnDeny.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeny.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDeny.CornerRadius = 15
        Me.btnDeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeny.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDeny.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDeny.Location = New System.Drawing.Point(1127, 718)
        Me.btnDeny.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeny.Name = "btnDeny"
        Me.btnDeny.Size = New System.Drawing.Size(99, 35)
        Me.btnDeny.TabIndex = 155
        Me.btnDeny.Text = "Deny"
        Me.btnDeny.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1233, 78)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(99, 33)
        Me.btnAdd.TabIndex = 152
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(934, 78)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(93, 33)
        Me.btnDelete.TabIndex = 153
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'prm_btn_update
        '
        Me.prm_btn_update.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prm_btn_update.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.prm_btn_update.CornerRadius = 15
        Me.prm_btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.prm_btn_update.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.prm_btn_update.ForeColor = System.Drawing.Color.White
        Me.prm_btn_update.Location = New System.Drawing.Point(1034, 78)
        Me.prm_btn_update.Name = "prm_btn_update"
        Me.prm_btn_update.Size = New System.Drawing.Size(93, 33)
        Me.prm_btn_update.TabIndex = 57
        Me.prm_btn_update.Text = "Update"
        Me.prm_btn_update.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(52, 713)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 58)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "TOTAL:"
        '
        'ttlpropertyrequestmanagement
        '
        Me.ttlpropertyrequestmanagement.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ttlpropertyrequestmanagement.AutoSize = True
        Me.ttlpropertyrequestmanagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ttlpropertyrequestmanagement.ForeColor = System.Drawing.Color.Black
        Me.ttlpropertyrequestmanagement.Location = New System.Drawing.Point(203, 713)
        Me.ttlpropertyrequestmanagement.Name = "ttlpropertyrequestmanagement"
        Me.ttlpropertyrequestmanagement.Size = New System.Drawing.Size(47, 58)
        Me.ttlpropertyrequestmanagement.TabIndex = 158
        Me.ttlpropertyrequestmanagement.Text = "0"
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
        'UC_PropertyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ttlpropertyrequestmanagement)
        Me.Controls.Add(Me.assign)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnDeny)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.prm_btn_update)
        Me.Controls.Add(Me.prm_table1)
        Me.Controls.Add(Me.admin_label_PropertyRequestManagement)
        Me.Name = "UC_PropertyRequestManagement"
        Me.Size = New System.Drawing.Size(1394, 803)
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
    Friend WithEvents assign As Resources.Controls.RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ttlpropertyrequestmanagement As Label
    Friend WithEvents NameOfRequester As DataGridViewTextBoxColumn
    Friend WithEvents Department As DataGridViewTextBoxColumn
    Friend WithEvents DateOfRequest As DataGridViewTextBoxColumn
    Friend WithEvents ItemName As DataGridViewTextBoxColumn
    Friend WithEvents QuantityRequested As DataGridViewTextBoxColumn
    Friend WithEvents Purpose As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
End Class
