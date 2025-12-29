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
        Me.pnlFormLoader = New System.Windows.Forms.Panel()
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.txtPersonalHistory = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.admin_panel_borrowed = New System.Windows.Forms.Label()
        Me.comboMonth = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.btnPropertyInventory = New System.Windows.Forms.Button()
        Me.btnMaintenanceReq = New System.Windows.Forms.Button()
        Me.icStaff = New System.Windows.Forms.PictureBox()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnBorrowedItem = New System.Windows.Forms.Button()
        Me.btnMyRequest = New System.Windows.Forms.Button()
        Me.btnSupplyInventory = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.pnlFormLoader.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.pnlMain.Controls.Add(Me.pnlFormLoader)
        Me.pnlMain.CornerRadius = 15
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(267, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1176, 862)
        Me.pnlMain.TabIndex = 1
        '
        'pnlFormLoader
        '
        Me.pnlFormLoader.Controls.Add(Me.DataGridView1)
        Me.pnlFormLoader.Controls.Add(Me.ComboBox1)
        Me.pnlFormLoader.Controls.Add(Me.ComboBox3)
        Me.pnlFormLoader.Controls.Add(Me.txtPersonalHistory)
        Me.pnlFormLoader.Controls.Add(Me.Panel4)
        Me.pnlFormLoader.Controls.Add(Me.Panel3)
        Me.pnlFormLoader.Controls.Add(Me.comboMonth)
        Me.pnlFormLoader.Controls.Add(Me.Panel2)
        Me.pnlFormLoader.Controls.Add(Me.Label1)
        Me.pnlFormLoader.Controls.Add(Me.Panel1)
        Me.pnlFormLoader.Controls.Add(Me.Label2)
        Me.pnlFormLoader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFormLoader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlFormLoader.Location = New System.Drawing.Point(0, 0)
        Me.pnlFormLoader.Name = "pnlFormLoader"
        Me.pnlFormLoader.Size = New System.Drawing.Size(1176, 862)
        Me.pnlFormLoader.TabIndex = 12
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RequestID, Me.UserID, Me.PropertyID, Me.RequestDate, Me.Purpose, Me.Quantity, Me.Status, Me.ApprovedBy, Me.ReleaseDate, Me.ReturnDate})
        Me.DataGridView1.Location = New System.Drawing.Point(46, 301)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1088, 512)
        Me.DataGridView1.TabIndex = 159
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
        Me.UserID.HeaderText = "Date of Request"
        Me.UserID.MinimumWidth = 6
        Me.UserID.Name = "UserID"
        Me.UserID.Width = 135
        '
        'PropertyID
        '
        Me.PropertyID.HeaderText = "Item Name"
        Me.PropertyID.MinimumWidth = 6
        Me.PropertyID.Name = "PropertyID"
        Me.PropertyID.Width = 170
        '
        'RequestDate
        '
        Me.RequestDate.HeaderText = "Description"
        Me.RequestDate.MinimumWidth = 6
        Me.RequestDate.Name = "RequestDate"
        Me.RequestDate.Width = 170
        '
        'Purpose
        '
        Me.Purpose.HeaderText = "Quantity Requested"
        Me.Purpose.MinimumWidth = 6
        Me.Purpose.Name = "Purpose"
        Me.Purpose.Width = 150
        '
        'Quantity
        '
        Me.Quantity.HeaderText = "Unit"
        Me.Quantity.MinimumWidth = 6
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Width = 125
        '
        'Status
        '
        Me.Status.HeaderText = "Purpose"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 200
        '
        'ApprovedBy
        '
        Me.ApprovedBy.HeaderText = "Status "
        Me.ApprovedBy.MinimumWidth = 6
        Me.ApprovedBy.Name = "ApprovedBy"
        Me.ApprovedBy.Width = 125
        '
        'ReleaseDate
        '
        Me.ReleaseDate.HeaderText = "Approved By"
        Me.ReleaseDate.MinimumWidth = 6
        Me.ReleaseDate.Name = "ReleaseDate"
        Me.ReleaseDate.Width = 150
        '
        'ReturnDate
        '
        Me.ReturnDate.HeaderText = "Approved Date"
        Me.ReturnDate.MinimumWidth = 6
        Me.ReturnDate.Name = "ReturnDate"
        Me.ReturnDate.Width = 150
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.ComboBox1.Font = New System.Drawing.Font("Poppins Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"2015", "2016,", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025"})
        Me.ComboBox1.Location = New System.Drawing.Point(811, 262)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(122, 30)
        Me.ComboBox1.TabIndex = 158
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.ComboBox3.Font = New System.Drawing.Font("Poppins Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.ForeColor = System.Drawing.Color.White
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"January", "February", "March", "April", "June", "July", "August", "September", "October", "November", "December"})
        Me.ComboBox3.Location = New System.Drawing.Point(510, 262)
        Me.ComboBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(179, 30)
        Me.ComboBox3.TabIndex = 157
        '
        'txtPersonalHistory
        '
        Me.txtPersonalHistory.AutoSize = True
        Me.txtPersonalHistory.Font = New System.Drawing.Font("Poppins", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonalHistory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.txtPersonalHistory.Location = New System.Drawing.Point(39, 257)
        Me.txtPersonalHistory.Name = "txtPersonalHistory"
        Me.txtPersonalHistory.Size = New System.Drawing.Size(299, 39)
        Me.txtPersonalHistory.TabIndex = 7
        Me.txtPersonalHistory.Text = "Personal Request History"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(906, 120)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(249, 93)
        Me.Panel4.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(119, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 48)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(75, 9)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 25)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Borrowed Items"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.admin_panel_borrowed)
        Me.Panel3.Location = New System.Drawing.Point(618, 120)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(249, 93)
        Me.Panel3.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(112, 37)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 48)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "0"
        '
        'admin_panel_borrowed
        '
        Me.admin_panel_borrowed.AutoSize = True
        Me.admin_panel_borrowed.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.admin_panel_borrowed.ForeColor = System.Drawing.Color.Transparent
        Me.admin_panel_borrowed.Location = New System.Drawing.Point(62, 9)
        Me.admin_panel_borrowed.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.admin_panel_borrowed.Name = "admin_panel_borrowed"
        Me.admin_panel_borrowed.Size = New System.Drawing.Size(143, 25)
        Me.admin_panel_borrowed.TabIndex = 0
        Me.admin_panel_borrowed.Text = "Rejected Requests"
        '
        'comboMonth
        '
        Me.comboMonth.AutoSize = True
        Me.comboMonth.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboMonth.Location = New System.Drawing.Point(384, 271)
        Me.comboMonth.Name = "comboMonth"
        Me.comboMonth.Size = New System.Drawing.Size(126, 25)
        Me.comboMonth.TabIndex = 10
        Me.comboMonth.Text = "Filter by month:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(332, 120)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(249, 93)
        Me.Panel2.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(106, 37)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 48)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(52, 9)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 25)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Approved Requests"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(38, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 48)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "DashBoard"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(46, 120)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(249, 93)
        Me.Panel1.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(54, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 25)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Pending Request"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(96, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 48)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(693, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Filter by year:"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnPropertyInventory)
        Me.pnlSidebar.Controls.Add(Me.btnMaintenanceReq)
        Me.pnlSidebar.Controls.Add(Me.icStaff)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.btnBorrowedItem)
        Me.pnlSidebar.Controls.Add(Me.btnMyRequest)
        Me.pnlSidebar.Controls.Add(Me.btnSupplyInventory)
        Me.pnlSidebar.Controls.Add(Me.btnProfile)
        Me.pnlSidebar.Controls.Add(Me.btnDashboard)
        Me.pnlSidebar.CornerRadius = 6
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.MaximumSize = New System.Drawing.Size(300, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(267, 862)
        Me.pnlSidebar.TabIndex = 0
        '
        'btnPropertyInventory
        '
        Me.btnPropertyInventory.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnPropertyInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnPropertyInventory.FlatAppearance.BorderSize = 0
        Me.btnPropertyInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPropertyInventory.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPropertyInventory.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnPropertyInventory.Image = CType(resources.GetObject("btnPropertyInventory.Image"), System.Drawing.Image)
        Me.btnPropertyInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPropertyInventory.Location = New System.Drawing.Point(14, 261)
        Me.btnPropertyInventory.Name = "btnPropertyInventory"
        Me.btnPropertyInventory.Size = New System.Drawing.Size(238, 51)
        Me.btnPropertyInventory.TabIndex = 12
        Me.btnPropertyInventory.Text = "Property Inventory"
        Me.btnPropertyInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPropertyInventory.UseVisualStyleBackColor = False
        '
        'btnMaintenanceReq
        '
        Me.btnMaintenanceReq.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnMaintenanceReq.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnMaintenanceReq.FlatAppearance.BorderSize = 0
        Me.btnMaintenanceReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaintenanceReq.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenanceReq.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnMaintenanceReq.Image = CType(resources.GetObject("btnMaintenanceReq.Image"), System.Drawing.Image)
        Me.btnMaintenanceReq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMaintenanceReq.Location = New System.Drawing.Point(12, 485)
        Me.btnMaintenanceReq.Name = "btnMaintenanceReq"
        Me.btnMaintenanceReq.Size = New System.Drawing.Size(238, 51)
        Me.btnMaintenanceReq.TabIndex = 11
        Me.btnMaintenanceReq.Text = "Maintenance Request"
        Me.btnMaintenanceReq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMaintenanceReq.UseVisualStyleBackColor = False
        '
        'icStaff
        '
        Me.icStaff.Image = CType(resources.GetObject("icStaff.Image"), System.Drawing.Image)
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
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(12, 542)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(238, 51)
        Me.btnLogout.TabIndex = 9
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnBorrowedItem
        '
        Me.btnBorrowedItem.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnBorrowedItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnBorrowedItem.FlatAppearance.BorderSize = 0
        Me.btnBorrowedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrowedItem.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrowedItem.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnBorrowedItem.Image = CType(resources.GetObject("btnBorrowedItem.Image"), System.Drawing.Image)
        Me.btnBorrowedItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrowedItem.Location = New System.Drawing.Point(12, 427)
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
        Me.btnMyRequest.FlatAppearance.BorderSize = 0
        Me.btnMyRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyRequest.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMyRequest.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnMyRequest.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_propertyrequest
        Me.btnMyRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMyRequest.Location = New System.Drawing.Point(14, 370)
        Me.btnMyRequest.Name = "btnMyRequest"
        Me.btnMyRequest.Size = New System.Drawing.Size(238, 51)
        Me.btnMyRequest.TabIndex = 6
        Me.btnMyRequest.Text = "My Request"
        Me.btnMyRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMyRequest.UseVisualStyleBackColor = False
        '
        'btnSupplyInventory
        '
        Me.btnSupplyInventory.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnSupplyInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSupplyInventory.FlatAppearance.BorderSize = 0
        Me.btnSupplyInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupplyInventory.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplyInventory.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnSupplyInventory.Image = CType(resources.GetObject("btnSupplyInventory.Image"), System.Drawing.Image)
        Me.btnSupplyInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSupplyInventory.Location = New System.Drawing.Point(14, 316)
        Me.btnSupplyInventory.Name = "btnSupplyInventory"
        Me.btnSupplyInventory.Size = New System.Drawing.Size(238, 51)
        Me.btnSupplyInventory.TabIndex = 5
        Me.btnSupplyInventory.Text = "Supply Inventory"
        Me.btnSupplyInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSupplyInventory.UseVisualStyleBackColor = False
        '
        'btnProfile
        '
        Me.btnProfile.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnProfile.FlatAppearance.BorderSize = 0
        Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProfile.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfile.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnProfile.Image = CType(resources.GetObject("btnProfile.Image"), System.Drawing.Image)
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
        Me.btnDashboard.FlatAppearance.BorderSize = 0
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Poppins Medium", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboard.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnDashboard.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_dashboard
        Me.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.Location = New System.Drawing.Point(12, 152)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(238, 51)
        Me.btnDashboard.TabIndex = 2
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'StaffDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1443, 862)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSidebar)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "StaffDashboard"
        Me.Text = "StaffDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlFormLoader.ResumeLayout(False)
        Me.pnlFormLoader.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlSidebar.ResumeLayout(False)
        CType(Me.icStaff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnBorrowedItem As Button
    Friend WithEvents btnMyRequest As Button
    Friend WithEvents btnSupplyInventory As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents icStaff As PictureBox
    Friend WithEvents tmrSidebar As Timer
    Friend WithEvents btnMaintenanceReq As Button
    Friend WithEvents btnPropertyInventory As Button
    Friend WithEvents pnlFormLoader As Panel
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
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents txtPersonalHistory As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents admin_panel_borrowed As Label
    Friend WithEvents comboMonth As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlMain As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
End Class
