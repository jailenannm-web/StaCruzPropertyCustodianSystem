Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports StaCruzPropertyCustodianSystem.Resources.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Reports
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
        Me.admin_label_Reports = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.adminreports_txtbox_search = New System.Windows.Forms.TextBox()
        Me.admin_panelcontainer = New System.Windows.Forms.Panel()
        Me.rpt_genbtn_StockCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_StockCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.rpt_genbtn_PropertyCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_PropertyCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.rpt_genbtn_MaintenanceRepair = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_MaintenanceRepair = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.rpt_genbtn_RequisitionSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_RequisitionSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.reports_requisitionSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_StockCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_MaintenanceRepair = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_PropertyCard = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rpt_genbtn_LostDamage = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_LostDamage = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.rpt_genbtn_BorrowingReturnSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_BorrowingReturnSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.rpt_genbtn_InventorySummary = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_InventorySummary = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.rpt_genbtn_InventoryCustodianSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_InventoryCustodianSip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.reports_InventoryCustodianSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_LostDamage = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_InventorySummary = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_BorrowingReturnSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rpt_genbtn_AnnualProperty = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_AnnualProperty = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.rpt_genbtn_DeptAllocation = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_prevbtn_DeptAllocation = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.reports_DepartmentAllocation = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.reports_AnnualProperty = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.admin_panelcontainer.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_Reports
        '
        Me.admin_label_Reports.AutoSize = True
        Me.admin_label_Reports.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_Reports.Location = New System.Drawing.Point(53, 59)
        Me.admin_label_Reports.Name = "admin_label_Reports"
        Me.admin_label_Reports.Size = New System.Drawing.Size(158, 58)
        Me.admin_label_Reports.TabIndex = 35
        Me.admin_label_Reports.Text = "Reports"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(59, 120)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'adminreports_txtbox_search
        '
        Me.adminreports_txtbox_search.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminreports_txtbox_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.adminreports_txtbox_search.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adminreports_txtbox_search.ForeColor = System.Drawing.Color.White
        Me.adminreports_txtbox_search.Location = New System.Drawing.Point(105, 120)
        Me.adminreports_txtbox_search.Name = "adminreports_txtbox_search"
        Me.adminreports_txtbox_search.Size = New System.Drawing.Size(1097, 33)
        Me.adminreports_txtbox_search.TabIndex = 36
        Me.adminreports_txtbox_search.Text = "Search"
        Me.adminreports_txtbox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'admin_panelcontainer
        '
        Me.admin_panelcontainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.admin_panelcontainer.Controls.Add(Me.rpt_genbtn_StockCard)
        Me.admin_panelcontainer.Controls.Add(Me.reports_prevbtn_StockCard)
        Me.admin_panelcontainer.Controls.Add(Me.rpt_genbtn_PropertyCard)
        Me.admin_panelcontainer.Controls.Add(Me.reports_prevbtn_PropertyCard)
        Me.admin_panelcontainer.Controls.Add(Me.rpt_genbtn_MaintenanceRepair)
        Me.admin_panelcontainer.Controls.Add(Me.reports_prevbtn_MaintenanceRepair)
        Me.admin_panelcontainer.Controls.Add(Me.rpt_genbtn_RequisitionSlip)
        Me.admin_panelcontainer.Controls.Add(Me.reports_prevbtn_RequisitionSlip)
        Me.admin_panelcontainer.Controls.Add(Me.TableLayoutPanel1)
        Me.admin_panelcontainer.Location = New System.Drawing.Point(63, 185)
        Me.admin_panelcontainer.Name = "admin_panelcontainer"
        Me.admin_panelcontainer.Size = New System.Drawing.Size(1139, 290)
        Me.admin_panelcontainer.TabIndex = 38
        '
        'rpt_genbtn_StockCard
        '
        Me.rpt_genbtn_StockCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_StockCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_StockCard.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_StockCard.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_StockCard.Location = New System.Drawing.Point(1030, 250)
        Me.rpt_genbtn_StockCard.Name = "rpt_genbtn_StockCard"
        Me.rpt_genbtn_StockCard.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_StockCard.TabIndex = 46
        Me.rpt_genbtn_StockCard.Text = "Generate"
        Me.rpt_genbtn_StockCard.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_StockCard
        '
        Me.reports_prevbtn_StockCard.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_StockCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_StockCard.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_StockCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_StockCard.Location = New System.Drawing.Point(925, 250)
        Me.reports_prevbtn_StockCard.Name = "reports_prevbtn_StockCard"
        Me.reports_prevbtn_StockCard.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_StockCard.TabIndex = 45
        Me.reports_prevbtn_StockCard.Text = "Preview"
        Me.reports_prevbtn_StockCard.UseVisualStyleBackColor = False
        '
        'rpt_genbtn_PropertyCard
        '
        Me.rpt_genbtn_PropertyCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_PropertyCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_PropertyCard.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_PropertyCard.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_PropertyCard.Location = New System.Drawing.Point(743, 250)
        Me.rpt_genbtn_PropertyCard.Name = "rpt_genbtn_PropertyCard"
        Me.rpt_genbtn_PropertyCard.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_PropertyCard.TabIndex = 44
        Me.rpt_genbtn_PropertyCard.Text = "Generate"
        Me.rpt_genbtn_PropertyCard.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_PropertyCard
        '
        Me.reports_prevbtn_PropertyCard.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_PropertyCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_PropertyCard.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_PropertyCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_PropertyCard.Location = New System.Drawing.Point(638, 250)
        Me.reports_prevbtn_PropertyCard.Name = "reports_prevbtn_PropertyCard"
        Me.reports_prevbtn_PropertyCard.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_PropertyCard.TabIndex = 43
        Me.reports_prevbtn_PropertyCard.Text = "Preview"
        Me.reports_prevbtn_PropertyCard.UseVisualStyleBackColor = False
        '
        'rpt_genbtn_MaintenanceRepair
        '
        Me.rpt_genbtn_MaintenanceRepair.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_MaintenanceRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_MaintenanceRepair.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_MaintenanceRepair.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_MaintenanceRepair.Location = New System.Drawing.Point(459, 250)
        Me.rpt_genbtn_MaintenanceRepair.Name = "rpt_genbtn_MaintenanceRepair"
        Me.rpt_genbtn_MaintenanceRepair.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_MaintenanceRepair.TabIndex = 42
        Me.rpt_genbtn_MaintenanceRepair.Text = "Generate"
        Me.rpt_genbtn_MaintenanceRepair.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_MaintenanceRepair
        '
        Me.reports_prevbtn_MaintenanceRepair.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_MaintenanceRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_MaintenanceRepair.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_MaintenanceRepair.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_MaintenanceRepair.Location = New System.Drawing.Point(354, 250)
        Me.reports_prevbtn_MaintenanceRepair.Name = "reports_prevbtn_MaintenanceRepair"
        Me.reports_prevbtn_MaintenanceRepair.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_MaintenanceRepair.TabIndex = 41
        Me.reports_prevbtn_MaintenanceRepair.Text = "Preview"
        Me.reports_prevbtn_MaintenanceRepair.UseVisualStyleBackColor = False
        '
        'rpt_genbtn_RequisitionSlip
        '
        Me.rpt_genbtn_RequisitionSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_RequisitionSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_RequisitionSlip.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_RequisitionSlip.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_RequisitionSlip.Location = New System.Drawing.Point(175, 250)
        Me.rpt_genbtn_RequisitionSlip.Name = "rpt_genbtn_RequisitionSlip"
        Me.rpt_genbtn_RequisitionSlip.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_RequisitionSlip.TabIndex = 40
        Me.rpt_genbtn_RequisitionSlip.Text = "Generate"
        Me.rpt_genbtn_RequisitionSlip.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_RequisitionSlip
        '
        Me.reports_prevbtn_RequisitionSlip.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_RequisitionSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_RequisitionSlip.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_RequisitionSlip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_RequisitionSlip.Location = New System.Drawing.Point(70, 250)
        Me.reports_prevbtn_RequisitionSlip.Name = "reports_prevbtn_RequisitionSlip"
        Me.reports_prevbtn_RequisitionSlip.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_RequisitionSlip.TabIndex = 39
        Me.reports_prevbtn_RequisitionSlip.Text = "Preview"
        Me.reports_prevbtn_RequisitionSlip.UseVisualStyleBackColor = False
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
        Me.TableLayoutPanel1.Controls.Add(Me.reports_requisitionSlip, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.reports_StockCard, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.reports_MaintenanceRepair, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.reports_PropertyCard, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 10)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1139, 237)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'reports_requisitionSlip
        '
        Me.reports_requisitionSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_requisitionSlip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_requisitionSlip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_requisitionSlip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_requisitionSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_requisitionSlip.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_requisitionSlip.ForeColor = System.Drawing.Color.White
        Me.reports_requisitionSlip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_requisitionSlip.Location = New System.Drawing.Point(10, 10)
        Me.reports_requisitionSlip.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_requisitionSlip.Name = "reports_requisitionSlip"
        Me.reports_requisitionSlip.Size = New System.Drawing.Size(264, 217)
        Me.reports_requisitionSlip.TabIndex = 11
        Me.reports_requisitionSlip.Text = "Requisition and Issue Slip"
        Me.reports_requisitionSlip.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_requisitionSlip.UseVisualStyleBackColor = False
        '
        'reports_StockCard
        '
        Me.reports_StockCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_StockCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_StockCard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_StockCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_StockCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_StockCard.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_StockCard.ForeColor = System.Drawing.Color.White
        Me.reports_StockCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_StockCard.Location = New System.Drawing.Point(862, 10)
        Me.reports_StockCard.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_StockCard.Name = "reports_StockCard"
        Me.reports_StockCard.Size = New System.Drawing.Size(267, 217)
        Me.reports_StockCard.TabIndex = 14
        Me.reports_StockCard.Text = "Stock Card"
        Me.reports_StockCard.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_StockCard.UseVisualStyleBackColor = False
        '
        'reports_MaintenanceRepair
        '
        Me.reports_MaintenanceRepair.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_MaintenanceRepair.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_MaintenanceRepair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_MaintenanceRepair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_MaintenanceRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_MaintenanceRepair.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_MaintenanceRepair.ForeColor = System.Drawing.Color.White
        Me.reports_MaintenanceRepair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_MaintenanceRepair.Location = New System.Drawing.Point(294, 10)
        Me.reports_MaintenanceRepair.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_MaintenanceRepair.Name = "reports_MaintenanceRepair"
        Me.reports_MaintenanceRepair.Size = New System.Drawing.Size(264, 217)
        Me.reports_MaintenanceRepair.TabIndex = 12
        Me.reports_MaintenanceRepair.Text = "Maintenance and Repair Report"
        Me.reports_MaintenanceRepair.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_MaintenanceRepair.UseVisualStyleBackColor = False
        '
        'reports_PropertyCard
        '
        Me.reports_PropertyCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_PropertyCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_PropertyCard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_PropertyCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_PropertyCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_PropertyCard.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_PropertyCard.ForeColor = System.Drawing.Color.White
        Me.reports_PropertyCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_PropertyCard.Location = New System.Drawing.Point(578, 10)
        Me.reports_PropertyCard.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_PropertyCard.Name = "reports_PropertyCard"
        Me.reports_PropertyCard.Size = New System.Drawing.Size(264, 217)
        Me.reports_PropertyCard.TabIndex = 13
        Me.reports_PropertyCard.Text = "Property Card"
        Me.reports_PropertyCard.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_PropertyCard.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.rpt_genbtn_LostDamage)
        Me.Panel1.Controls.Add(Me.reports_prevbtn_LostDamage)
        Me.Panel1.Controls.Add(Me.rpt_genbtn_BorrowingReturnSlip)
        Me.Panel1.Controls.Add(Me.reports_prevbtn_BorrowingReturnSlip)
        Me.Panel1.Controls.Add(Me.rpt_genbtn_InventorySummary)
        Me.Panel1.Controls.Add(Me.reports_prevbtn_InventorySummary)
        Me.Panel1.Controls.Add(Me.rpt_genbtn_InventoryCustodianSlip)
        Me.Panel1.Controls.Add(Me.reports_prevbtn_InventoryCustodianSip)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Location = New System.Drawing.Point(63, 478)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1139, 290)
        Me.Panel1.TabIndex = 47
        '
        'rpt_genbtn_LostDamage
        '
        Me.rpt_genbtn_LostDamage.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_LostDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_LostDamage.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_LostDamage.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_LostDamage.Location = New System.Drawing.Point(1030, 250)
        Me.rpt_genbtn_LostDamage.Name = "rpt_genbtn_LostDamage"
        Me.rpt_genbtn_LostDamage.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_LostDamage.TabIndex = 46
        Me.rpt_genbtn_LostDamage.Text = "Generate"
        Me.rpt_genbtn_LostDamage.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_LostDamage
        '
        Me.reports_prevbtn_LostDamage.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_LostDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_LostDamage.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_LostDamage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_LostDamage.Location = New System.Drawing.Point(925, 250)
        Me.reports_prevbtn_LostDamage.Name = "reports_prevbtn_LostDamage"
        Me.reports_prevbtn_LostDamage.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_LostDamage.TabIndex = 45
        Me.reports_prevbtn_LostDamage.Text = "Preview"
        Me.reports_prevbtn_LostDamage.UseVisualStyleBackColor = False
        '
        'rpt_genbtn_BorrowingReturnSlip
        '
        Me.rpt_genbtn_BorrowingReturnSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_BorrowingReturnSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_BorrowingReturnSlip.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_BorrowingReturnSlip.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_BorrowingReturnSlip.Location = New System.Drawing.Point(743, 250)
        Me.rpt_genbtn_BorrowingReturnSlip.Name = "rpt_genbtn_BorrowingReturnSlip"
        Me.rpt_genbtn_BorrowingReturnSlip.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_BorrowingReturnSlip.TabIndex = 44
        Me.rpt_genbtn_BorrowingReturnSlip.Text = "Generate"
        Me.rpt_genbtn_BorrowingReturnSlip.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_BorrowingReturnSlip
        '
        Me.reports_prevbtn_BorrowingReturnSlip.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_BorrowingReturnSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_BorrowingReturnSlip.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_BorrowingReturnSlip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_BorrowingReturnSlip.Location = New System.Drawing.Point(638, 250)
        Me.reports_prevbtn_BorrowingReturnSlip.Name = "reports_prevbtn_BorrowingReturnSlip"
        Me.reports_prevbtn_BorrowingReturnSlip.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_BorrowingReturnSlip.TabIndex = 43
        Me.reports_prevbtn_BorrowingReturnSlip.Text = "Preview"
        Me.reports_prevbtn_BorrowingReturnSlip.UseVisualStyleBackColor = False
        '
        'rpt_genbtn_InventorySummary
        '
        Me.rpt_genbtn_InventorySummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_InventorySummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_InventorySummary.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_InventorySummary.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_InventorySummary.Location = New System.Drawing.Point(459, 250)
        Me.rpt_genbtn_InventorySummary.Name = "rpt_genbtn_InventorySummary"
        Me.rpt_genbtn_InventorySummary.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_InventorySummary.TabIndex = 42
        Me.rpt_genbtn_InventorySummary.Text = "Generate"
        Me.rpt_genbtn_InventorySummary.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_InventorySummary
        '
        Me.reports_prevbtn_InventorySummary.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_InventorySummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_InventorySummary.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_InventorySummary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_InventorySummary.Location = New System.Drawing.Point(354, 250)
        Me.reports_prevbtn_InventorySummary.Name = "reports_prevbtn_InventorySummary"
        Me.reports_prevbtn_InventorySummary.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_InventorySummary.TabIndex = 41
        Me.reports_prevbtn_InventorySummary.Text = "Preview"
        Me.reports_prevbtn_InventorySummary.UseVisualStyleBackColor = False
        '
        'rpt_genbtn_InventoryCustodianSlip
        '
        Me.rpt_genbtn_InventoryCustodianSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_InventoryCustodianSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_InventoryCustodianSlip.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_InventoryCustodianSlip.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_InventoryCustodianSlip.Location = New System.Drawing.Point(175, 250)
        Me.rpt_genbtn_InventoryCustodianSlip.Name = "rpt_genbtn_InventoryCustodianSlip"
        Me.rpt_genbtn_InventoryCustodianSlip.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_InventoryCustodianSlip.TabIndex = 40
        Me.rpt_genbtn_InventoryCustodianSlip.Text = "Generate"
        Me.rpt_genbtn_InventoryCustodianSlip.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_InventoryCustodianSip
        '
        Me.reports_prevbtn_InventoryCustodianSip.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_InventoryCustodianSip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_InventoryCustodianSip.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_InventoryCustodianSip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_InventoryCustodianSip.Location = New System.Drawing.Point(70, 250)
        Me.reports_prevbtn_InventoryCustodianSip.Name = "reports_prevbtn_InventoryCustodianSip"
        Me.reports_prevbtn_InventoryCustodianSip.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_InventoryCustodianSip.TabIndex = 39
        Me.reports_prevbtn_InventoryCustodianSip.Text = "Preview"
        Me.reports_prevbtn_InventoryCustodianSip.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.reports_InventoryCustodianSlip, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.reports_LostDamage, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.reports_InventorySummary, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.reports_BorrowingReturnSlip, 2, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 10)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1139, 237)
        Me.TableLayoutPanel2.TabIndex = 15
        '
        'reports_InventoryCustodianSlip
        '
        Me.reports_InventoryCustodianSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_InventoryCustodianSlip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_InventoryCustodianSlip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_InventoryCustodianSlip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_InventoryCustodianSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_InventoryCustodianSlip.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_InventoryCustodianSlip.ForeColor = System.Drawing.Color.White
        Me.reports_InventoryCustodianSlip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_InventoryCustodianSlip.Location = New System.Drawing.Point(10, 10)
        Me.reports_InventoryCustodianSlip.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_InventoryCustodianSlip.Name = "reports_InventoryCustodianSlip"
        Me.reports_InventoryCustodianSlip.Size = New System.Drawing.Size(264, 217)
        Me.reports_InventoryCustodianSlip.TabIndex = 11
        Me.reports_InventoryCustodianSlip.Text = "Inventory Custodian Slip"
        Me.reports_InventoryCustodianSlip.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_InventoryCustodianSlip.UseVisualStyleBackColor = False
        '
        'reports_LostDamage
        '
        Me.reports_LostDamage.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_LostDamage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_LostDamage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_LostDamage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_LostDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_LostDamage.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_LostDamage.ForeColor = System.Drawing.Color.White
        Me.reports_LostDamage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_LostDamage.Location = New System.Drawing.Point(862, 10)
        Me.reports_LostDamage.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_LostDamage.Name = "reports_LostDamage"
        Me.reports_LostDamage.Size = New System.Drawing.Size(267, 217)
        Me.reports_LostDamage.TabIndex = 14
        Me.reports_LostDamage.Text = "Lost/Damaged Property Certificate"
        Me.reports_LostDamage.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_LostDamage.UseVisualStyleBackColor = False
        '
        'reports_InventorySummary
        '
        Me.reports_InventorySummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_InventorySummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_InventorySummary.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_InventorySummary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_InventorySummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_InventorySummary.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_InventorySummary.ForeColor = System.Drawing.Color.White
        Me.reports_InventorySummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_InventorySummary.Location = New System.Drawing.Point(294, 10)
        Me.reports_InventorySummary.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_InventorySummary.Name = "reports_InventorySummary"
        Me.reports_InventorySummary.Size = New System.Drawing.Size(264, 217)
        Me.reports_InventorySummary.TabIndex = 12
        Me.reports_InventorySummary.Text = "Official Inventory Summary Report"
        Me.reports_InventorySummary.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_InventorySummary.UseVisualStyleBackColor = False
        '
        'reports_BorrowingReturnSlip
        '
        Me.reports_BorrowingReturnSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_BorrowingReturnSlip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_BorrowingReturnSlip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_BorrowingReturnSlip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_BorrowingReturnSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_BorrowingReturnSlip.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_BorrowingReturnSlip.ForeColor = System.Drawing.Color.White
        Me.reports_BorrowingReturnSlip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_BorrowingReturnSlip.Location = New System.Drawing.Point(578, 10)
        Me.reports_BorrowingReturnSlip.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_BorrowingReturnSlip.Name = "reports_BorrowingReturnSlip"
        Me.reports_BorrowingReturnSlip.Size = New System.Drawing.Size(264, 217)
        Me.reports_BorrowingReturnSlip.TabIndex = 13
        Me.reports_BorrowingReturnSlip.Text = "Borrowing and Return Slip Report"
        Me.reports_BorrowingReturnSlip.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_BorrowingReturnSlip.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.rpt_genbtn_AnnualProperty)
        Me.Panel2.Controls.Add(Me.reports_prevbtn_AnnualProperty)
        Me.Panel2.Controls.Add(Me.rpt_genbtn_DeptAllocation)
        Me.Panel2.Controls.Add(Me.reports_prevbtn_DeptAllocation)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Location = New System.Drawing.Point(63, 771)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1139, 290)
        Me.Panel2.TabIndex = 48
        '
        'rpt_genbtn_AnnualProperty
        '
        Me.rpt_genbtn_AnnualProperty.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_AnnualProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_AnnualProperty.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_AnnualProperty.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_AnnualProperty.Location = New System.Drawing.Point(459, 250)
        Me.rpt_genbtn_AnnualProperty.Name = "rpt_genbtn_AnnualProperty"
        Me.rpt_genbtn_AnnualProperty.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_AnnualProperty.TabIndex = 42
        Me.rpt_genbtn_AnnualProperty.Text = "Generate"
        Me.rpt_genbtn_AnnualProperty.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_AnnualProperty
        '
        Me.reports_prevbtn_AnnualProperty.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_AnnualProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_AnnualProperty.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_AnnualProperty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_AnnualProperty.Location = New System.Drawing.Point(354, 250)
        Me.reports_prevbtn_AnnualProperty.Name = "reports_prevbtn_AnnualProperty"
        Me.reports_prevbtn_AnnualProperty.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_AnnualProperty.TabIndex = 41
        Me.reports_prevbtn_AnnualProperty.Text = "Preview"
        Me.reports_prevbtn_AnnualProperty.UseVisualStyleBackColor = False
        '
        'rpt_genbtn_DeptAllocation
        '
        Me.rpt_genbtn_DeptAllocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.rpt_genbtn_DeptAllocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rpt_genbtn_DeptAllocation.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_genbtn_DeptAllocation.ForeColor = System.Drawing.Color.White
        Me.rpt_genbtn_DeptAllocation.Location = New System.Drawing.Point(175, 250)
        Me.rpt_genbtn_DeptAllocation.Name = "rpt_genbtn_DeptAllocation"
        Me.rpt_genbtn_DeptAllocation.Size = New System.Drawing.Size(99, 37)
        Me.rpt_genbtn_DeptAllocation.TabIndex = 40
        Me.rpt_genbtn_DeptAllocation.Text = "Generate"
        Me.rpt_genbtn_DeptAllocation.UseVisualStyleBackColor = False
        '
        'reports_prevbtn_DeptAllocation
        '
        Me.reports_prevbtn_DeptAllocation.BackColor = System.Drawing.Color.White
        Me.reports_prevbtn_DeptAllocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_prevbtn_DeptAllocation.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_prevbtn_DeptAllocation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_prevbtn_DeptAllocation.Location = New System.Drawing.Point(70, 250)
        Me.reports_prevbtn_DeptAllocation.Name = "reports_prevbtn_DeptAllocation"
        Me.reports_prevbtn_DeptAllocation.Size = New System.Drawing.Size(99, 37)
        Me.reports_prevbtn_DeptAllocation.TabIndex = 39
        Me.reports_prevbtn_DeptAllocation.Text = "Preview"
        Me.reports_prevbtn_DeptAllocation.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.reports_DepartmentAllocation, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.reports_AnnualProperty, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 10)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(10)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1139, 237)
        Me.TableLayoutPanel3.TabIndex = 15
        '
        'reports_DepartmentAllocation
        '
        Me.reports_DepartmentAllocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_DepartmentAllocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_DepartmentAllocation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_DepartmentAllocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_DepartmentAllocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_DepartmentAllocation.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_DepartmentAllocation.ForeColor = System.Drawing.Color.White
        Me.reports_DepartmentAllocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_DepartmentAllocation.Location = New System.Drawing.Point(10, 10)
        Me.reports_DepartmentAllocation.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_DepartmentAllocation.Name = "reports_DepartmentAllocation"
        Me.reports_DepartmentAllocation.Size = New System.Drawing.Size(264, 217)
        Me.reports_DepartmentAllocation.TabIndex = 11
        Me.reports_DepartmentAllocation.Text = "Department Allocation Report"
        Me.reports_DepartmentAllocation.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_DepartmentAllocation.UseVisualStyleBackColor = False
        '
        'reports_AnnualProperty
        '
        Me.reports_AnnualProperty.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.reports_AnnualProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reports_AnnualProperty.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.reports_AnnualProperty.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.reports_AnnualProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reports_AnnualProperty.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reports_AnnualProperty.ForeColor = System.Drawing.Color.White
        Me.reports_AnnualProperty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reports_AnnualProperty.Location = New System.Drawing.Point(294, 10)
        Me.reports_AnnualProperty.Margin = New System.Windows.Forms.Padding(10)
        Me.reports_AnnualProperty.Name = "reports_AnnualProperty"
        Me.reports_AnnualProperty.Size = New System.Drawing.Size(264, 217)
        Me.reports_AnnualProperty.TabIndex = 12
        Me.reports_AnnualProperty.Text = "Annual Property Custodian Report"
        Me.reports_AnnualProperty.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.reports_AnnualProperty.UseVisualStyleBackColor = False
        '
        'UC_Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.admin_panelcontainer)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.adminreports_txtbox_search)
        Me.Controls.Add(Me.admin_label_Reports)
        Me.Name = "UC_Reports"
        Me.Size = New System.Drawing.Size(1287, 1184)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.admin_panelcontainer.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_Reports As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents adminreports_txtbox_search As TextBox
    Friend WithEvents admin_panelcontainer As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents reports_requisitionSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_StockCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_MaintenanceRepair As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_PropertyCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_RequisitionSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_RequisitionSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_MaintenanceRepair As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_MaintenanceRepair As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_PropertyCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_PropertyCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_StockCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_StockCard As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rpt_genbtn_LostDamage As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_LostDamage As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_BorrowingReturnSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_BorrowingReturnSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_InventorySummary As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_InventorySummary As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_InventoryCustodianSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_InventoryCustodianSip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents reports_InventoryCustodianSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_LostDamage As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_InventorySummary As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_BorrowingReturnSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rpt_genbtn_AnnualProperty As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_AnnualProperty As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents rpt_genbtn_DeptAllocation As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_prevbtn_DeptAllocation As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents reports_DepartmentAllocation As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents reports_AnnualProperty As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
