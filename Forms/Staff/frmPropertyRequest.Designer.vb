Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPropertyRequest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPropertyRequest))
        Me.txtPropertyRequest = New System.Windows.Forms.Label()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.txt_UserID = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.lblDepartmentName = New System.Windows.Forms.Label()
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
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
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.pnlSidebar.SuspendLayout
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPropertyRequest
        '
        Me.txtPropertyRequest.AutoSize = True
        Me.txtPropertyRequest.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropertyRequest.Location = New System.Drawing.Point(668, 19)
        Me.txtPropertyRequest.Name = "txtPropertyRequest"
        Me.txtPropertyRequest.Size = New System.Drawing.Size(242, 31)
        Me.txtPropertyRequest.TabIndex = 0
        Me.txtPropertyRequest.Text = "Property Request"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Cancel.Location = New System.Drawing.Point(557, 609)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(191, 46)
        Me.btn_Cancel.TabIndex = 115
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Login
        '
        Me.btn_Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Login.Font = New System.Drawing.Font("Poppins", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.Location = New System.Drawing.Point(900, 609)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(190, 46)
        Me.btn_Login.TabIndex = 116
        Me.btn_Login.Text = "Request"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'txt_UserID
        '
        Me.txt_UserID.BackColor = System.Drawing.Color.White
        Me.txt_UserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UserID.Location = New System.Drawing.Point(788, 158)
        Me.txt_UserID.Name = "txt_UserID"
        Me.txt_UserID.Size = New System.Drawing.Size(264, 26)
        Me.txt_UserID.TabIndex = 92
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblEmail.Location = New System.Drawing.Point(752, 266)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(88, 24)
        Me.lblEmail.TabIndex = 88
        Me.lblEmail.Text = "Purpose"
        '
        'lblContactNumber
        '
        Me.lblContactNumber.AutoSize = True
        Me.lblContactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblContactNumber.Location = New System.Drawing.Point(573, 192)
        Me.lblContactNumber.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Size = New System.Drawing.Size(135, 24)
        Me.lblContactNumber.TabIndex = 87
        Me.lblContactNumber.Text = "Request Date"
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.AutoSize = True
        Me.lblDepartmentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDepartmentName.Location = New System.Drawing.Point(573, 158)
        Me.lblDepartmentName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(84, 24)
        Me.lblDepartmentName.TabIndex = 85
        Me.lblDepartmentName.Text = "User I.D"
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
        Me.pnlSidebar.Size = New System.Drawing.Size(267, 679)
        Me.pnlSidebar.TabIndex = 117
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
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(577, 293)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(493, 94)
        Me.TextBox5.TabIndex = 356
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.ComboBox2.Location = New System.Drawing.Point(743, 404)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(144, 27)
        Me.ComboBox2.TabIndex = 357
        Me.ComboBox2.Text = "Quantity"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(788, 223)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(264, 26)
        Me.TextBox1.TabIndex = 359
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(573, 223)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 24)
        Me.Label1.TabIndex = 358
        Me.Label1.Text = "Property/Supply Name"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(788, 194)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(264, 20)
        Me.DateTimePicker1.TabIndex = 360
        '
        'frmPropertyRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1361, 679)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.txt_UserID)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblContactNumber)
        Me.Controls.Add(Me.lblDepartmentName)
        Me.Controls.Add(Me.txtPropertyRequest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPropertyRequest"
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPropertyRequest As Label
    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_Login As Button
    Friend WithEvents txt_UserID As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents lblDepartmentName As Label
    Friend WithEvents pnlSidebar As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
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
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
