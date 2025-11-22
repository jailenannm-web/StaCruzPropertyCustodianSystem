Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StaffDashboard
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StaffDashboard))
        Me.tmrSidebar = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMain = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtPersonalHistory = New System.Windows.Forms.Label()
        Me.pnlHistoryContainer = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.dgvHistory = New System.Windows.Forms.DataGridView()
        Me.RoundedButton2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlFormLoader = New System.Windows.Forms.Panel()
        Me.comboMonth = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnRequestProperty = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        Me.pnlMain.SuspendLayout()
        Me.pnlHistoryContainer.SuspendLayout()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFormLoader.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.pnlSidebar.SuspendLayout()
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrSidebar
        '
        Me.tmrSidebar.Interval = 1
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.txtPersonalHistory)
        Me.pnlMain.Controls.Add(Me.pnlHistoryContainer)
        Me.pnlMain.Controls.Add(Me.RoundedButton2)
        Me.pnlMain.Controls.Add(Me.RoundedButton1)
        Me.pnlMain.Controls.Add(Me.pnlFormLoader)
        Me.pnlMain.CornerRadius = 15
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(356, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1471, 922)
        Me.pnlMain.TabIndex = 1
        '
        'txtPersonalHistory
        '
        Me.txtPersonalHistory.AutoSize = True
        Me.txtPersonalHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonalHistory.Location = New System.Drawing.Point(120, 316)
        Me.txtPersonalHistory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtPersonalHistory.Name = "txtPersonalHistory"
        Me.txtPersonalHistory.Size = New System.Drawing.Size(347, 31)
        Me.txtPersonalHistory.TabIndex = 7
        Me.txtPersonalHistory.Text = "Personal Request History"
        '
        'pnlHistoryContainer
        '
        Me.pnlHistoryContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlHistoryContainer.Controls.Add(Me.dgvHistory)
        Me.pnlHistoryContainer.CornerRadius = 20
        Me.pnlHistoryContainer.Location = New System.Drawing.Point(105, 364)
        Me.pnlHistoryContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlHistoryContainer.Name = "pnlHistoryContainer"
        Me.pnlHistoryContainer.Size = New System.Drawing.Size(1227, 471)
        Me.pnlHistoryContainer.TabIndex = 5
        '
        'dgvHistory
        '
        Me.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistory.Location = New System.Drawing.Point(4, 4)
        Me.dgvHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvHistory.Name = "dgvHistory"
        Me.dgvHistory.RowHeadersWidth = 51
        Me.dgvHistory.Size = New System.Drawing.Size(1223, 468)
        Me.dgvHistory.TabIndex = 0
        '
        'RoundedButton2
        '
        Me.RoundedButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton2.CornerRadius = 15
        Me.RoundedButton2.FlatAppearance.BorderSize = 0
        Me.RoundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton2.ForeColor = System.Drawing.Color.White
        Me.RoundedButton2.Location = New System.Drawing.Point(984, 165)
        Me.RoundedButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton2.Name = "RoundedButton2"
        Me.RoundedButton2.Size = New System.Drawing.Size(348, 98)
        Me.RoundedButton2.TabIndex = 4
        Me.RoundedButton2.Text = "Property Request"
        Me.RoundedButton2.UseVisualStyleBackColor = False
        '
        'RoundedButton1
        '
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatAppearance.BorderSize = 0
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton1.ForeColor = System.Drawing.Color.White
        Me.RoundedButton1.Location = New System.Drawing.Point(556, 165)
        Me.RoundedButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(348, 98)
        Me.RoundedButton1.TabIndex = 3
        Me.RoundedButton1.Text = "Property Request"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'pnlFormLoader
        '
        Me.pnlFormLoader.Controls.Add(Me.comboMonth)
        Me.pnlFormLoader.Controls.Add(Me.Label1)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel2)
        Me.pnlFormLoader.Controls.Add(Me.Label2)
        Me.pnlFormLoader.Controls.Add(Me.RoundedPanel1)
        Me.pnlFormLoader.Controls.Add(Me.btnRequestProperty)
        Me.pnlFormLoader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFormLoader.Location = New System.Drawing.Point(0, 0)
        Me.pnlFormLoader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlFormLoader.Name = "pnlFormLoader"
        Me.pnlFormLoader.Size = New System.Drawing.Size(1471, 922)
        Me.pnlFormLoader.TabIndex = 12
        '
        'comboMonth
        '
        Me.comboMonth.AutoSize = True
        Me.comboMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboMonth.Location = New System.Drawing.Point(647, 329)
        Me.comboMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.comboMonth.Name = "comboMonth"
        Me.comboMonth.Size = New System.Drawing.Size(141, 20)
        Me.comboMonth.TabIndex = 10
        Me.comboMonth.Text = "Filter by month:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 58)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "DashBoard"
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel2.Controls.Add(Me.ComboBox2)
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(1101, 321)
        Me.RoundedPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(183, 33)
        Me.RoundedPanel2.TabIndex = 10
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(11, 4)
        Me.ComboBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox2.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(979, 329)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Filter by year:"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.ComboBox1)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(789, 321)
        Me.RoundedPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(183, 33)
        Me.RoundedPanel1.TabIndex = 9
        '
        'ComboBox1
        '
        Me.ComboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(11, 4)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox1.TabIndex = 8
        '
        'btnRequestProperty
        '
        Me.btnRequestProperty.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRequestProperty.CornerRadius = 15
        Me.btnRequestProperty.FlatAppearance.BorderSize = 0
        Me.btnRequestProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequestProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequestProperty.ForeColor = System.Drawing.Color.White
        Me.btnRequestProperty.Location = New System.Drawing.Point(105, 135)
        Me.btnRequestProperty.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRequestProperty.Name = "btnRequestProperty"
        Me.btnRequestProperty.Size = New System.Drawing.Size(348, 98)
        Me.btnRequestProperty.TabIndex = 2
        Me.btnRequestProperty.Text = "Property Request"
        Me.btnRequestProperty.UseVisualStyleBackColor = False
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
        Me.pnlSidebar.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSidebar.MaximumSize = New System.Drawing.Size(400, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(356, 922)
        Me.pnlSidebar.TabIndex = 0
        '
        'icStaff
        '
        Me.icStaff.Image = CType(resources.GetObject("icStaff.Image"), System.Drawing.Image)
        Me.icStaff.Location = New System.Drawing.Point(99, 38)
        Me.icStaff.Margin = New System.Windows.Forms.Padding(4)
        Me.icStaff.Name = "icStaff"
        Me.icStaff.Size = New System.Drawing.Size(129, 102)
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
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(16, 678)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(317, 63)
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
        Me.btnReports.Location = New System.Drawing.Point(16, 608)
        Me.btnReports.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(317, 63)
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
        Me.btnBorrowedItem.Location = New System.Drawing.Point(16, 538)
        Me.btnBorrowedItem.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBorrowedItem.Name = "btnBorrowedItem"
        Me.btnBorrowedItem.Size = New System.Drawing.Size(317, 63)
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
        Me.btnMyRequest.Location = New System.Drawing.Point(16, 468)
        Me.btnMyRequest.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMyRequest.Name = "btnMyRequest"
        Me.btnMyRequest.Size = New System.Drawing.Size(317, 63)
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
        Me.btnViewInventory.Location = New System.Drawing.Point(16, 398)
        Me.btnViewInventory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewInventory.Name = "btnViewInventory"
        Me.btnViewInventory.Size = New System.Drawing.Size(317, 63)
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
        Me.btnPropertyRequest.Image = CType(resources.GetObject("btnPropertyRequest.Image"), System.Drawing.Image)
        Me.btnPropertyRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPropertyRequest.Location = New System.Drawing.Point(16, 327)
        Me.btnPropertyRequest.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPropertyRequest.Name = "btnPropertyRequest"
        Me.btnPropertyRequest.Size = New System.Drawing.Size(317, 63)
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
        Me.btnProfile.Image = CType(resources.GetObject("btnProfile.Image"), System.Drawing.Image)
        Me.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProfile.Location = New System.Drawing.Point(16, 257)
        Me.btnProfile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(317, 63)
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
        Me.btnDashboard.Image = CType(resources.GetObject("btnDashboard.Image"), System.Drawing.Image)
        Me.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.Location = New System.Drawing.Point(16, 187)
        Me.btnDashboard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(317, 63)
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
        Me.txtStaff.Location = New System.Drawing.Point(133, 148)
        Me.txtStaff.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtStaff.Name = "txtStaff"
        Me.txtStaff.Size = New System.Drawing.Size(65, 20)
        Me.txtStaff.TabIndex = 1
        Me.txtStaff.Text = "Staff 1"
        '
        'StaffDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 922)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSidebar)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "StaffDashboard"
        Me.Text = "StaffDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlHistoryContainer.ResumeLayout(False)
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFormLoader.ResumeLayout(False)
        Me.pnlFormLoader.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents txtStaff As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnBorrowedItem As Button
    Friend WithEvents btnMyRequest As Button
    Friend WithEvents btnViewInventory As Button
    Friend WithEvents btnPropertyRequest As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents icStaff As PictureBox
    Friend WithEvents tmrSidebar As Timer
    Friend WithEvents pnlMain As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents btnRequestProperty As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedButton2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedButton1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlHistoryContainer As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents txtPersonalHistory As Label
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents comboMonth As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlFormLoader As Panel
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
End Class
