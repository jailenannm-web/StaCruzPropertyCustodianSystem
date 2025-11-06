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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAPropertyRequestManagement))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSuperAdmin = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblUserManagement = New System.Windows.Forms.Label()
        Me.btnUpdate = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.btnSystemConfig = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.pnlSidebar = New StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Button8 = New System.Windows.Forms.Button()
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel2.SuspendLayout
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(74, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(97, 83)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button3.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(12, 552)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(238, 51)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Reports"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(12, 495)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(238, 51)
        Me.Button4.TabIndex = 30
        Me.Button4.Text = "Maintenance Management"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button6.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button6.FlatAppearance.BorderSize = 2
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(12, 381)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(238, 51)
        Me.Button6.TabIndex = 28
        Me.Button6.Text = "Department Management"
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button5.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button5.FlatAppearance.BorderSize = 2
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(12, 438)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(238, 51)
        Me.Button5.TabIndex = 29
        Me.Button5.Text = "Property Request Management"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button7.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button7.FlatAppearance.BorderSize = 2
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(12, 324)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(238, 51)
        Me.Button7.TabIndex = 27
        Me.Button7.Text = "Supplies Management"
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(985, 99)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(102, 35)
        Me.btnAdd.TabIndex = 155
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel2.Controls.Add(Me.Button11)
        Me.RoundedPanel2.Controls.Add(Me.Button12)
        Me.RoundedPanel2.Controls.Add(Me.Panel3)
        Me.RoundedPanel2.Controls.Add(Me.Label2)
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RoundedPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(267, 710)
        Me.RoundedPanel2.TabIndex = 33
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button11.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button11.FlatAppearance.BorderSize = 2
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(12, 609)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(238, 51)
        Me.Button11.TabIndex = 22
        Me.Button11.Text = "System Configuration"
        Me.Button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button12.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button12.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button12.FlatAppearance.BorderSize = 2
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button12.Location = New System.Drawing.Point(12, 666)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(238, 51)
        Me.Button12.TabIndex = 22
        Me.Button12.Text = "Logout"
        Me.Button12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(269, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1103, 749)
        Me.Panel3.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(80, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Superadmin"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(269, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1103, 749)
        Me.Panel1.TabIndex = 23
        '
        'lblSuperAdmin
        '
        Me.lblSuperAdmin.AutoSize = True
        Me.lblSuperAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblSuperAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuperAdmin.ForeColor = System.Drawing.Color.White
        Me.lblSuperAdmin.Location = New System.Drawing.Point(80, 118)
        Me.lblSuperAdmin.Name = "lblSuperAdmin"
        Me.lblSuperAdmin.Size = New System.Drawing.Size(90, 16)
        Me.lblSuperAdmin.TabIndex = 11
        Me.lblSuperAdmin.Text = "Superadmin"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(283, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 26)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Search"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(363, 96)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(493, 35)
        Me.TextBox1.TabIndex = 159
        '
        'lblUserManagement
        '
        Me.lblUserManagement.AutoSize = True
        Me.lblUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserManagement.Location = New System.Drawing.Point(289, 29)
        Me.lblUserManagement.Name = "lblUserManagement"
        Me.lblUserManagement.Size = New System.Drawing.Size(417, 31)
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
        Me.btnUpdate.Location = New System.Drawing.Point(1247, 96)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(101, 38)
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
        Me.btnDelete.Location = New System.Drawing.Point(1122, 98)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(101, 36)
        Me.btnDelete.TabIndex = 156
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RequestID, Me.UserID, Me.PropertyID, Me.RequestDate, Me.Purpose, Me.Quantity, Me.Status, Me.ApprovedBy, Me.ReleaseDate, Me.ReturnDate, Me.ActualReturnedDate, Me.Remarks, Me.Penalty, Me.ConditionUponReturn, Me.CreatedAt, Me.UpdatedAt})
        Me.DataGridView1.Location = New System.Drawing.Point(291, 153)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1057, 459)
        Me.DataGridView1.TabIndex = 154
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button9.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button9.FlatAppearance.BorderSize = 2
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(12, 210)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(238, 51)
        Me.Button9.TabIndex = 25
        Me.Button9.Text = "User Management"
        Me.Button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button10.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button10.FlatAppearance.BorderSize = 2
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(12, 153)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(238, 51)
        Me.Button10.TabIndex = 24
        Me.Button10.Text = "Dashboard"
        Me.Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button10.UseVisualStyleBackColor = False
        '
        'btnSystemConfig
        '
        Me.btnSystemConfig.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSystemConfig.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnSystemConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSystemConfig.FlatAppearance.BorderSize = 2
        Me.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSystemConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemConfig.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnSystemConfig.Image = CType(resources.GetObject("btnSystemConfig.Image"), System.Drawing.Image)
        Me.btnSystemConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSystemConfig.Location = New System.Drawing.Point(12, 614)
        Me.btnSystemConfig.Name = "btnSystemConfig"
        Me.btnSystemConfig.Size = New System.Drawing.Size(238, 51)
        Me.btnSystemConfig.TabIndex = 22
        Me.btnSystemConfig.Text = "System Configuration"
        Me.btnSystemConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemConfig.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnLogout.FlatAppearance.BorderSize = 2
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.FloralWhite
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.Location = New System.Drawing.Point(12, 666)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(238, 51)
        Me.btnLogout.TabIndex = 22
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.PictureBox1)
        Me.pnlSidebar.Controls.Add(Me.Button3)
        Me.pnlSidebar.Controls.Add(Me.Button4)
        Me.pnlSidebar.Controls.Add(Me.Button5)
        Me.pnlSidebar.Controls.Add(Me.Button6)
        Me.pnlSidebar.Controls.Add(Me.Button7)
        Me.pnlSidebar.Controls.Add(Me.Button8)
        Me.pnlSidebar.Controls.Add(Me.Button9)
        Me.pnlSidebar.Controls.Add(Me.Button10)
        Me.pnlSidebar.Controls.Add(Me.RoundedPanel2)
        Me.pnlSidebar.Controls.Add(Me.btnSystemConfig)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.Panel1)
        Me.pnlSidebar.Controls.Add(Me.lblSuperAdmin)
        Me.pnlSidebar.CornerRadius = 20
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(267, 710)
        Me.pnlSidebar.TabIndex = 153
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Button8.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button8.FlatAppearance.BorderSize = 2
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.FloralWhite
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(12, 267)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(238, 51)
        Me.Button8.TabIndex = 26
        Me.Button8.Text = "Property Management"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
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
        'SAPropertyRequestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1373, 710)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblUserManagement)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.pnlSidebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SAPropertyRequestManagement"
        Me.Text = "SAPropertyRequestManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents btnAdd As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblSuperAdmin As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblUserManagement As Label
    Friend WithEvents btnUpdate As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents btnSystemConfig As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlSidebar As StaCruzPropertyCustodianSystem.StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents Button8 As Button
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
