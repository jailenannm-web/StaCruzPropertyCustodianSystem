Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_DepartmentManagement
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pm_txtbox_search = New System.Windows.Forms.TextBox()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.dm_label_ExistingDept = New System.Windows.Forms.Label()
        Me.dm_panelContainer = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dm_panelContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(43, 114)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'pm_txtbox_search
        '
        Me.pm_txtbox_search.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_txtbox_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_txtbox_search.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_txtbox_search.ForeColor = System.Drawing.Color.White
        Me.pm_txtbox_search.Location = New System.Drawing.Point(91, 114)
        Me.pm_txtbox_search.Name = "pm_txtbox_search"
        Me.pm_txtbox_search.Size = New System.Drawing.Size(741, 33)
        Me.pm_txtbox_search.TabIndex = 38
        Me.pm_txtbox_search.Text = "Search"
        Me.pm_txtbox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(33, 43)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(475, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 37
        Me.admin_label_DepartmentManagement.Text = "Department Management"
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1061, 114)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 38)
        Me.pm_cbobx_status.TabIndex = 35
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(886, 114)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 38)
        Me.pm_cbobx_categ.TabIndex = 36
        Me.pm_cbobx_categ.Text = "Categories"
        '
        'dm_label_ExistingDept
        '
        Me.dm_label_ExistingDept.AutoSize = True
        Me.dm_label_ExistingDept.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.dm_label_ExistingDept.Location = New System.Drawing.Point(38, 168)
        Me.dm_label_ExistingDept.Name = "dm_label_ExistingDept"
        Me.dm_label_ExistingDept.Size = New System.Drawing.Size(190, 30)
        Me.dm_label_ExistingDept.TabIndex = 41
        Me.dm_label_ExistingDept.Text = "Existing Department"
        '
        'dm_panelContainer
        '
        Me.dm_panelContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dm_panelContainer.Controls.Add(Me.TableLayoutPanel1)
        Me.dm_panelContainer.Location = New System.Drawing.Point(43, 604)
        Me.dm_panelContainer.Name = "dm_panelContainer"
        Me.dm_panelContainer.Size = New System.Drawing.Size(1163, 197)
        Me.dm_panelContainer.TabIndex = 17
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 10)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1163, 178)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'UC_DepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dm_panelContainer)
        Me.Controls.Add(Me.dm_label_ExistingDept)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pm_txtbox_search)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Name = "UC_DepartmentManagement"
        Me.Size = New System.Drawing.Size(1253, 804)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dm_panelContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pm_txtbox_search As TextBox
    Friend WithEvents admin_label_DepartmentManagement As Label
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents dm_label_ExistingDept As Label
    Friend WithEvents dm_panelContainer As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
