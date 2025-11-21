Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAPropertyRequestManagement
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
        Me.btnAdd = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblUserManagement = New System.Windows.Forms.Label()
        Me.btnUpdate = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RequestID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PropertyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Purpose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprovedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReleaseDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualReturnedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Penalty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConditionUponReturn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1313, 122)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(136, 43)
        Me.btnAdd.TabIndex = 155
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(377, 129)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 32)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Search"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(484, 118)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(656, 41)
        Me.TextBox1.TabIndex = 159
        '
        'lblUserManagement
        '
        Me.lblUserManagement.AutoSize = True
        Me.lblUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserManagement.Location = New System.Drawing.Point(385, 36)
        Me.lblUserManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserManagement.Name = "lblUserManagement"
        Me.lblUserManagement.Size = New System.Drawing.Size(515, 39)
        Me.lblUserManagement.TabIndex = 158
        Me.lblUserManagement.Text = "Property Request Management"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnUpdate.CornerRadius = 15
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdate.Location = New System.Drawing.Point(1663, 118)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(135, 47)
        Me.btnUpdate.TabIndex = 157
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1496, 121)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(135, 44)
        Me.btnDelete.TabIndex = 156
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RequestID, Me.UserID, Me.PropertyID, Me.RequestDate, Me.Purpose, Me.Quantity, Me.Status, Me.ApprovedBy, Me.ReleaseDate, Me.ReturnDate, Me.ActualReturnedDate, Me.Remarks, Me.Penalty, Me.ConditionUponReturn, Me.CreatedAt, Me.UpdatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(388, 188)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1409, 565)
        Me.DataGridView1.TabIndex = 154
        '
        'RequestID
        '
        Me.RequestID.HeaderText = "Request I.D"
        Me.RequestID.MinimumWidth = 6
        Me.RequestID.Name = "RequestID"
        Me.RequestID.Width = 125
        '
        'UserID
        '
        Me.UserID.HeaderText = "User I.D"
        Me.UserID.MinimumWidth = 6
        Me.UserID.Name = "UserID"
        Me.UserID.Width = 125
        '
        'PropertyID
        '
        Me.PropertyID.HeaderText = "Property I.D"
        Me.PropertyID.MinimumWidth = 6
        Me.PropertyID.Name = "PropertyID"
        Me.PropertyID.Width = 125
        '
        'RequestDate
        '
        Me.RequestDate.HeaderText = "RequestDate"
        Me.RequestDate.MinimumWidth = 6
        Me.RequestDate.Name = "RequestDate"
        Me.RequestDate.Width = 125
        '
        'Purpose
        '
        Me.Purpose.HeaderText = "Purpose"
        Me.Purpose.MinimumWidth = 6
        Me.Purpose.Name = "Purpose"
        Me.Purpose.Width = 125
        '
        'Quantity
        '
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.MinimumWidth = 6
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 125
        '
        'ApprovedBy
        '
        Me.ApprovedBy.HeaderText = "Approved By"
        Me.ApprovedBy.MinimumWidth = 6
        Me.ApprovedBy.Name = "ApprovedBy"
        Me.ApprovedBy.Width = 125
        '
        'ReleaseDate
        '
        Me.ReleaseDate.HeaderText = "Release Date"
        Me.ReleaseDate.MinimumWidth = 6
        Me.ReleaseDate.Name = "ReleaseDate"
        Me.ReleaseDate.Width = 125
        '
        'ReturnDate
        '
        Me.ReturnDate.HeaderText = "Return Date"
        Me.ReturnDate.MinimumWidth = 6
        Me.ReturnDate.Name = "ReturnDate"
        Me.ReturnDate.Width = 125
        '
        'ActualReturnedDate
        '
        Me.ActualReturnedDate.HeaderText = "Actual Returned Date"
        Me.ActualReturnedDate.MinimumWidth = 6
        Me.ActualReturnedDate.Name = "ActualReturnedDate"
        Me.ActualReturnedDate.Width = 125
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.MinimumWidth = 6
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 125
        '
        'Penalty
        '
        Me.Penalty.HeaderText = "Penalty"
        Me.Penalty.MinimumWidth = 6
        Me.Penalty.Name = "Penalty"
        Me.Penalty.Width = 125
        '
        'ConditionUponReturn
        '
        Me.ConditionUponReturn.HeaderText = "Condition Upon Return"
        Me.ConditionUponReturn.MinimumWidth = 6
        Me.ConditionUponReturn.Name = "ConditionUponReturn"
        Me.ConditionUponReturn.Width = 125
        '
        'CreatedAt
        '
        Me.CreatedAt.HeaderText = "Created At"
        Me.CreatedAt.MinimumWidth = 6
        Me.CreatedAt.Name = "CreatedAt"
        Me.CreatedAt.Width = 125
        '
        'UpdatedAt
        '
        Me.UpdatedAt.HeaderText = "Updated At"
        Me.UpdatedAt.MinimumWidth = 6
        Me.UpdatedAt.Name = "UpdatedAt"
        Me.UpdatedAt.Width = 125
        '
        'SAPropertyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1831, 874)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblUserManagement)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SAPropertyRequestManagement"
        Me.Text = "SAPropertyRequestManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblUserManagement As Label
    Friend WithEvents btnUpdate As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RequestID As DataGridViewTextBoxColumn
    Friend WithEvents UserID As DataGridViewTextBoxColumn
    Friend WithEvents PropertyID As DataGridViewTextBoxColumn
    Friend WithEvents RequestDate As DataGridViewTextBoxColumn
    Friend WithEvents Purpose As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents ApprovedBy As DataGridViewTextBoxColumn
    Friend WithEvents ReleaseDate As DataGridViewTextBoxColumn
    Friend WithEvents ReturnDate As DataGridViewTextBoxColumn
    Friend WithEvents ActualReturnedDate As DataGridViewTextBoxColumn
    Friend WithEvents Remarks As DataGridViewTextBoxColumn
    Friend WithEvents Penalty As DataGridViewTextBoxColumn
    Friend WithEvents ConditionUponReturn As DataGridViewTextBoxColumn
    Friend WithEvents CreatedAt As DataGridViewTextBoxColumn
    Friend WithEvents UpdatedAt As DataGridViewTextBoxColumn
End Class
