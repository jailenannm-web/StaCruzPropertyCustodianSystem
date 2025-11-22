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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRequest
        '
        Me.lblRequest.AutoSize = True
        Me.lblRequest.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequest.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblRequest.Location = New System.Drawing.Point(65, 29)
        Me.lblRequest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRequest.Name = "lblRequest"
        Me.lblRequest.Size = New System.Drawing.Size(238, 58)
        Me.lblRequest.TabIndex = 1
        Me.lblRequest.Text = "My Requests"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RequestID, Me.UserID, Me.PropertyID, Me.RequestDate, Me.Purpose, Me.Quantity, Me.Status, Me.ApprovedBy, Me.ReleaseDate, Me.ReturnDate, Me.ActualReturnedDate, Me.Remarks, Me.Penalty, Me.ConditionUponReturn, Me.CreatedAt, Me.UpdatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(75, 162)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1524, 871)
        Me.DataGridView1.TabIndex = 155
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
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(72, 91)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 157
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(137, 93)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(775, 41)
        Me.TextBox1.TabIndex = 156
        '
        'frmRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1942, 1222)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
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
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox1 As TextBox
End Class
