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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRequest))
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
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.icStaff = New System.Windows.Forms.PictureBox()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnBorrowedItem = New System.Windows.Forms.Button()
        Me.btnMyRequest = New System.Windows.Forms.Button()
        Me.btnViewInventory = New System.Windows.Forms.Button()
        Me.btnPropertyRequest = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.txtStaff = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRequest
        '
        Me.lblRequest.AutoSize = True
        Me.lblRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequest.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblRequest.Location = New System.Drawing.Point(335, 45)
        Me.lblRequest.Name = "lblRequest"
        Me.lblRequest.Size = New System.Drawing.Size(231, 39)
        Me.lblRequest.TabIndex = 1
        Me.lblRequest.Text = "My Requests"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RequestID, Me.UserID, Me.PropertyID, Me.RequestDate, Me.Purpose, Me.Quantity, Me.Status, Me.ApprovedBy, Me.ReleaseDate, Me.ReturnDate, Me.ActualReturnedDate, Me.Remarks, Me.Penalty, Me.ConditionUponReturn, Me.CreatedAt, Me.UpdatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(342, 131)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1057, 459)
        Me.DataGridView1.TabIndex = 155
        '
        'RequestID
        '
        Me.RequestID.HeaderText = "Request I.D"
        Me.RequestID.Name = "RequestID"
        '
        'UserID
        '
        Me.UserID.HeaderText = "User I.D"
        Me.UserID.Name = "UserID"
        '
        'PropertyID
        '
        Me.PropertyID.HeaderText = "Property I.D"
        Me.PropertyID.Name = "PropertyID"
        '
        'RequestDate
        '
        Me.RequestDate.HeaderText = "RequestDate"
        Me.RequestDate.Name = "RequestDate"
        '
        'Purpose
        '
        Me.Purpose.HeaderText = "Purpose"
        Me.Purpose.Name = "Purpose"
        '
        'Quantity
        '
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'ApprovedBy
        '
        Me.ApprovedBy.HeaderText = "Approved By"
        Me.ApprovedBy.Name = "ApprovedBy"
        '
        'ReleaseDate
        '
        Me.ReleaseDate.HeaderText = "Release Date"
        Me.ReleaseDate.Name = "ReleaseDate"
        '
        'ReturnDate
        '
        Me.ReturnDate.HeaderText = "Return Date"
        Me.ReturnDate.Name = "ReturnDate"
        '
        'ActualReturnedDate
        '
        Me.ActualReturnedDate.HeaderText = "Actual Returned Date"
        Me.ActualReturnedDate.Name = "ActualReturnedDate"
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'Penalty
        '
        Me.Penalty.HeaderText = "Penalty"
        Me.Penalty.Name = "Penalty"
        '
        'ConditionUponReturn
        '
        Me.ConditionUponReturn.HeaderText = "Condition Upon Return"
        Me.ConditionUponReturn.Name = "ConditionUponReturn"
        '
        'CreatedAt
        '
        Me.CreatedAt.HeaderText = "Created At"
        Me.CreatedAt.Name = "CreatedAt"
        '
        'UpdatedAt
        '
        Me.UpdatedAt.HeaderText = "Updated At"
        Me.UpdatedAt.Name = "UpdatedAt"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.icStaff)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.btnReports)
        Me.pnlSidebar.Controls.Add(Me.btnBorrowedItem)
        Me.pnlSidebar.Controls.Add(Me.btnMyRequest)
        Me.pnlSidebar.Controls.Add(Me.btnViewInventory)
        Me.pnlSidebar.Controls.Add(Me.btnPropertyRequest)
        Me.pnlSidebar.Controls.Add(Me.btnProfile)
        Me.pnlSidebar.Controls.Add(Me.btnDashboard)
        Me.pnlSidebar.Controls.Add(Me.txtStaff)
        Me.pnlSidebar.CornerRadius = 6
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.MaximumSize = New System.Drawing.Size(300, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(267, 685)
        Me.pnlSidebar.TabIndex = 156
        '
        'icStaff
        '
        Me.icStaff.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icStaff
        Me.icStaff.Location = New System.Drawing.Point(74, 31)
        Me.icStaff.Name = "icStaff"
        Me.icStaff.Size = New System.Drawing.Size(97, 83)
        Me.icStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.icStaff.TabIndex = 10
        Me.icStaff.TabStop = False
        '
        'btnLogout
        '
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnLogout.FlatAppearance.BorderSize = 2
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnLogout.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icLogout
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(12, 551)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(238, 51)
        Me.btnLogout.TabIndex = 9
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnReports.FlatAppearance.BorderSize = 2
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.Location = New System.Drawing.Point(12, 494)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(238, 51)
        Me.btnReports.TabIndex = 8
        Me.btnReports.Text = "Reports"
        Me.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'btnBorrowedItem
        '
        Me.btnBorrowedItem.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnBorrowedItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnBorrowedItem.FlatAppearance.BorderSize = 2
        Me.btnBorrowedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrowedItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrowedItem.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnBorrowedItem.Image = CType(resources.GetObject("btnBorrowedItem.Image"), System.Drawing.Image)
        Me.btnBorrowedItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrowedItem.Location = New System.Drawing.Point(12, 437)
        Me.btnBorrowedItem.Name = "btnBorrowedItem"
        Me.btnBorrowedItem.Size = New System.Drawing.Size(238, 51)
        Me.btnBorrowedItem.TabIndex = 7
        Me.btnBorrowedItem.Text = "My Borrowed Item"
        Me.btnBorrowedItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBorrowedItem.UseVisualStyleBackColor = False
        '
        'btnMyRequest
        '
        Me.btnMyRequest.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnMyRequest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnMyRequest.FlatAppearance.BorderSize = 2
        Me.btnMyRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMyRequest.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnMyRequest.Image = CType(resources.GetObject("btnMyRequest.Image"), System.Drawing.Image)
        Me.btnMyRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMyRequest.Location = New System.Drawing.Point(12, 380)
        Me.btnMyRequest.Name = "btnMyRequest"
        Me.btnMyRequest.Size = New System.Drawing.Size(238, 51)
        Me.btnMyRequest.TabIndex = 6
        Me.btnMyRequest.Text = "My Request"
        Me.btnMyRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMyRequest.UseVisualStyleBackColor = False
        '
        'btnViewInventory
        '
        Me.btnViewInventory.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnViewInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnViewInventory.FlatAppearance.BorderSize = 2
        Me.btnViewInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewInventory.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnViewInventory.Image = CType(resources.GetObject("btnViewInventory.Image"), System.Drawing.Image)
        Me.btnViewInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewInventory.Location = New System.Drawing.Point(12, 323)
        Me.btnViewInventory.Name = "btnViewInventory"
        Me.btnViewInventory.Size = New System.Drawing.Size(238, 51)
        Me.btnViewInventory.TabIndex = 5
        Me.btnViewInventory.Text = "View Inventory"
        Me.btnViewInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnViewInventory.UseVisualStyleBackColor = False
        '
        'btnPropertyRequest
        '
        Me.btnPropertyRequest.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnPropertyRequest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnPropertyRequest.FlatAppearance.BorderSize = 2
        Me.btnPropertyRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPropertyRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPropertyRequest.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnPropertyRequest.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icRequest
        Me.btnPropertyRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPropertyRequest.Location = New System.Drawing.Point(12, 266)
        Me.btnPropertyRequest.Name = "btnPropertyRequest"
        Me.btnPropertyRequest.Size = New System.Drawing.Size(238, 51)
        Me.btnPropertyRequest.TabIndex = 4
        Me.btnPropertyRequest.Text = "Property Request"
        Me.btnPropertyRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPropertyRequest.UseVisualStyleBackColor = False
        '
        'btnProfile
        '
        Me.btnProfile.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnProfile.FlatAppearance.BorderSize = 2
        Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfile.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnProfile.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icPerson
        Me.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProfile.Location = New System.Drawing.Point(12, 209)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(238, 51)
        Me.btnProfile.TabIndex = 3
        Me.btnProfile.Text = "Profile"
        Me.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProfile.UseVisualStyleBackColor = False
        '
        'btnDashboard
        '
        Me.btnDashboard.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnDashboard.FlatAppearance.BorderSize = 2
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboard.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnDashboard.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icDefault
        Me.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.Location = New System.Drawing.Point(12, 152)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(238, 51)
        Me.btnDashboard.TabIndex = 2
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'txtStaff
        '
        Me.txtStaff.AutoSize = True
        Me.txtStaff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStaff.ForeColor = System.Drawing.Color.White
        Me.txtStaff.Location = New System.Drawing.Point(100, 120)
        Me.txtStaff.Name = "txtStaff"
        Me.txtStaff.Size = New System.Drawing.Size(50, 16)
        Me.txtStaff.TabIndex = 1
        Me.txtStaff.Text = "Staff 1"
        '
        'frmRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1463, 685)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblRequest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRequest"
        Me.Text = "frmRequest"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnlSidebar As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents icStaff As PictureBox
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnBorrowedItem As Button
    Friend WithEvents btnMyRequest As Button
    Friend WithEvents btnViewInventory As Button
    Friend WithEvents btnPropertyRequest As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents txtStaff As Label
End Class
