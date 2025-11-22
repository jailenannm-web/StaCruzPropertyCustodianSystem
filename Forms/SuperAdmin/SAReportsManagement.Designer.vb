Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAReportsManagement
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
        Me.lblReportsManagement = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewRIS = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblRequisitionIssueSlip = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblMaintenacneReport = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnGenerateMRR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewMRR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnGeneratePC = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewPC = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblStockCard = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnGenerateSC = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewSC = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnGenerateICS = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewICS = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.btnGenerateOISR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewOISR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnGenerateBRSR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewBRSR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.btnGenerateLDPC = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewLDPC = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.btnGenerateDAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewDAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.btnGenerateAPCR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewAPCR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.btnGenerateAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnPreviewAR = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel22.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblReportsManagement
        '
        Me.lblReportsManagement.AutoSize = True
        Me.lblReportsManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReportsManagement.Location = New System.Drawing.Point(217, 48)
        Me.lblReportsManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReportsManagement.Name = "lblReportsManagement"
        Me.lblReportsManagement.Size = New System.Drawing.Size(361, 39)
        Me.lblReportsManagement.TabIndex = 48
        Me.lblReportsManagement.Text = "Reports Management"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel1.Controls.Add(Me.RoundedButton1)
        Me.Panel1.Controls.Add(Me.btnPreviewRIS)
        Me.Panel1.Location = New System.Drawing.Point(209, 182)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 228)
        Me.Panel1.TabIndex = 49
        '
        'RoundedButton1
        '
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(80, 184)
        Me.RoundedButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(103, 28)
        Me.RoundedButton1.TabIndex = 0
        Me.RoundedButton1.Text = "Generate"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'btnPreviewRIS
        '
        Me.btnPreviewRIS.BackColor = System.Drawing.Color.White
        Me.btnPreviewRIS.CornerRadius = 15
        Me.btnPreviewRIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewRIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewRIS.Location = New System.Drawing.Point(206, 184)
        Me.btnPreviewRIS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewRIS.Name = "btnPreviewRIS"
        Me.btnPreviewRIS.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewRIS.TabIndex = 1
        Me.btnPreviewRIS.Text = "Preview"
        Me.btnPreviewRIS.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblRequisitionIssueSlip)
        Me.Panel2.Location = New System.Drawing.Point(209, 182)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(327, 36)
        Me.Panel2.TabIndex = 50
        '
        'lblRequisitionIssueSlip
        '
        Me.lblRequisitionIssueSlip.AutoSize = True
        Me.lblRequisitionIssueSlip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequisitionIssueSlip.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblRequisitionIssueSlip.Location = New System.Drawing.Point(12, 7)
        Me.lblRequisitionIssueSlip.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRequisitionIssueSlip.Name = "lblRequisitionIssueSlip"
        Me.lblRequisitionIssueSlip.Size = New System.Drawing.Size(228, 20)
        Me.lblRequisitionIssueSlip.TabIndex = 51
        Me.lblRequisitionIssueSlip.Text = "Requisition and Issue Slip"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblMaintenacneReport)
        Me.Panel3.Location = New System.Drawing.Point(566, 182)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(309, 36)
        Me.Panel3.TabIndex = 53
        '
        'lblMaintenacneReport
        '
        Me.lblMaintenacneReport.AutoSize = True
        Me.lblMaintenacneReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaintenacneReport.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMaintenacneReport.Location = New System.Drawing.Point(12, 7)
        Me.lblMaintenacneReport.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMaintenacneReport.Name = "lblMaintenacneReport"
        Me.lblMaintenacneReport.Size = New System.Drawing.Size(274, 20)
        Me.lblMaintenacneReport.TabIndex = 51
        Me.lblMaintenacneReport.Text = "Maintenance and Repair Report"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel4.Controls.Add(Me.btnGenerateMRR)
        Me.Panel4.Controls.Add(Me.btnPreviewMRR)
        Me.Panel4.Location = New System.Drawing.Point(566, 182)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(309, 228)
        Me.Panel4.TabIndex = 52
        '
        'btnGenerateMRR
        '
        Me.btnGenerateMRR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateMRR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateMRR.CornerRadius = 15
        Me.btnGenerateMRR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateMRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateMRR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateMRR.Location = New System.Drawing.Point(80, 184)
        Me.btnGenerateMRR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateMRR.Name = "btnGenerateMRR"
        Me.btnGenerateMRR.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateMRR.TabIndex = 0
        Me.btnGenerateMRR.Text = "Generate"
        Me.btnGenerateMRR.UseVisualStyleBackColor = False
        '
        'btnPreviewMRR
        '
        Me.btnPreviewMRR.BackColor = System.Drawing.Color.White
        Me.btnPreviewMRR.CornerRadius = 15
        Me.btnPreviewMRR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewMRR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewMRR.Location = New System.Drawing.Point(191, 184)
        Me.btnPreviewMRR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewMRR.Name = "btnPreviewMRR"
        Me.btnPreviewMRR.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewMRR.TabIndex = 1
        Me.btnPreviewMRR.Text = "Preview"
        Me.btnPreviewMRR.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel5.Controls.Add(Me.lblPropertyCard)
        Me.Panel5.Location = New System.Drawing.Point(922, 182)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(309, 36)
        Me.Panel5.TabIndex = 53
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPropertyCard.Location = New System.Drawing.Point(12, 7)
        Me.lblPropertyCard.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(126, 20)
        Me.lblPropertyCard.TabIndex = 51
        Me.lblPropertyCard.Text = "Property Card"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel6.Controls.Add(Me.btnGeneratePC)
        Me.Panel6.Controls.Add(Me.btnPreviewPC)
        Me.Panel6.Location = New System.Drawing.Point(922, 182)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(309, 228)
        Me.Panel6.TabIndex = 52
        '
        'btnGeneratePC
        '
        Me.btnGeneratePC.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGeneratePC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGeneratePC.CornerRadius = 15
        Me.btnGeneratePC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGeneratePC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneratePC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGeneratePC.Location = New System.Drawing.Point(80, 184)
        Me.btnGeneratePC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGeneratePC.Name = "btnGeneratePC"
        Me.btnGeneratePC.Size = New System.Drawing.Size(103, 28)
        Me.btnGeneratePC.TabIndex = 0
        Me.btnGeneratePC.Text = "Generate"
        Me.btnGeneratePC.UseVisualStyleBackColor = False
        '
        'btnPreviewPC
        '
        Me.btnPreviewPC.BackColor = System.Drawing.Color.White
        Me.btnPreviewPC.CornerRadius = 15
        Me.btnPreviewPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewPC.Location = New System.Drawing.Point(191, 184)
        Me.btnPreviewPC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewPC.Name = "btnPreviewPC"
        Me.btnPreviewPC.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewPC.TabIndex = 1
        Me.btnPreviewPC.Text = "Preview"
        Me.btnPreviewPC.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel7.Controls.Add(Me.lblStockCard)
        Me.Panel7.Location = New System.Drawing.Point(1265, 182)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(309, 36)
        Me.Panel7.TabIndex = 53
        '
        'lblStockCard
        '
        Me.lblStockCard.AutoSize = True
        Me.lblStockCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCard.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblStockCard.Location = New System.Drawing.Point(12, 7)
        Me.lblStockCard.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockCard.Name = "lblStockCard"
        Me.lblStockCard.Size = New System.Drawing.Size(102, 20)
        Me.lblStockCard.TabIndex = 51
        Me.lblStockCard.Text = "Stock Card"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel8.Controls.Add(Me.btnGenerateSC)
        Me.Panel8.Controls.Add(Me.btnPreviewSC)
        Me.Panel8.Location = New System.Drawing.Point(1265, 182)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(309, 228)
        Me.Panel8.TabIndex = 52
        '
        'btnGenerateSC
        '
        Me.btnGenerateSC.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateSC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateSC.CornerRadius = 15
        Me.btnGenerateSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateSC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateSC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateSC.Location = New System.Drawing.Point(80, 184)
        Me.btnGenerateSC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateSC.Name = "btnGenerateSC"
        Me.btnGenerateSC.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateSC.TabIndex = 0
        Me.btnGenerateSC.Text = "Generate"
        Me.btnGenerateSC.UseVisualStyleBackColor = False
        '
        'btnPreviewSC
        '
        Me.btnPreviewSC.BackColor = System.Drawing.Color.White
        Me.btnPreviewSC.CornerRadius = 15
        Me.btnPreviewSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewSC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewSC.Location = New System.Drawing.Point(191, 184)
        Me.btnPreviewSC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewSC.Name = "btnPreviewSC"
        Me.btnPreviewSC.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewSC.TabIndex = 1
        Me.btnPreviewSC.Text = "Preview"
        Me.btnPreviewSC.UseVisualStyleBackColor = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel9.Controls.Add(Me.Label5)
        Me.Panel9.Location = New System.Drawing.Point(209, 436)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(327, 36)
        Me.Panel9.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(12, 7)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 20)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Inventory Custodian Slip"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel10.Controls.Add(Me.btnGenerateICS)
        Me.Panel10.Controls.Add(Me.btnPreviewICS)
        Me.Panel10.Location = New System.Drawing.Point(209, 436)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(327, 230)
        Me.Panel10.TabIndex = 54
        '
        'btnGenerateICS
        '
        Me.btnGenerateICS.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateICS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateICS.CornerRadius = 15
        Me.btnGenerateICS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateICS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateICS.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateICS.Location = New System.Drawing.Point(80, 184)
        Me.btnGenerateICS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateICS.Name = "btnGenerateICS"
        Me.btnGenerateICS.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateICS.TabIndex = 0
        Me.btnGenerateICS.Text = "Generate"
        Me.btnGenerateICS.UseVisualStyleBackColor = False
        '
        'btnPreviewICS
        '
        Me.btnPreviewICS.BackColor = System.Drawing.Color.White
        Me.btnPreviewICS.CornerRadius = 15
        Me.btnPreviewICS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewICS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewICS.Location = New System.Drawing.Point(206, 184)
        Me.btnPreviewICS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewICS.Name = "btnPreviewICS"
        Me.btnPreviewICS.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewICS.TabIndex = 1
        Me.btnPreviewICS.Text = "Preview"
        Me.btnPreviewICS.UseVisualStyleBackColor = False
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel11.Controls.Add(Me.Label6)
        Me.Panel11.Location = New System.Drawing.Point(566, 436)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(309, 36)
        Me.Panel11.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(4, 7)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(298, 20)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Official Inventory Summary Report"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel12.Controls.Add(Me.btnGenerateOISR)
        Me.Panel12.Controls.Add(Me.btnPreviewOISR)
        Me.Panel12.Location = New System.Drawing.Point(566, 436)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(309, 230)
        Me.Panel12.TabIndex = 52
        '
        'btnGenerateOISR
        '
        Me.btnGenerateOISR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateOISR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateOISR.CornerRadius = 15
        Me.btnGenerateOISR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateOISR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateOISR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateOISR.Location = New System.Drawing.Point(80, 184)
        Me.btnGenerateOISR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateOISR.Name = "btnGenerateOISR"
        Me.btnGenerateOISR.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateOISR.TabIndex = 0
        Me.btnGenerateOISR.Text = "Generate"
        Me.btnGenerateOISR.UseVisualStyleBackColor = False
        '
        'btnPreviewOISR
        '
        Me.btnPreviewOISR.BackColor = System.Drawing.Color.White
        Me.btnPreviewOISR.CornerRadius = 15
        Me.btnPreviewOISR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewOISR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewOISR.Location = New System.Drawing.Point(191, 184)
        Me.btnPreviewOISR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewOISR.Name = "btnPreviewOISR"
        Me.btnPreviewOISR.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewOISR.TabIndex = 1
        Me.btnPreviewOISR.Text = "Preview"
        Me.btnPreviewOISR.UseVisualStyleBackColor = False
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel13.Controls.Add(Me.Label7)
        Me.Panel13.Location = New System.Drawing.Point(922, 436)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(309, 36)
        Me.Panel13.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(12, 7)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(292, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Borrowing and Return Slip Report"
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel14.Controls.Add(Me.btnGenerateBRSR)
        Me.Panel14.Controls.Add(Me.btnPreviewBRSR)
        Me.Panel14.Location = New System.Drawing.Point(922, 436)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(309, 230)
        Me.Panel14.TabIndex = 52
        '
        'btnGenerateBRSR
        '
        Me.btnGenerateBRSR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateBRSR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateBRSR.CornerRadius = 15
        Me.btnGenerateBRSR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateBRSR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateBRSR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateBRSR.Location = New System.Drawing.Point(80, 184)
        Me.btnGenerateBRSR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateBRSR.Name = "btnGenerateBRSR"
        Me.btnGenerateBRSR.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateBRSR.TabIndex = 0
        Me.btnGenerateBRSR.Text = "Generate"
        Me.btnGenerateBRSR.UseVisualStyleBackColor = False
        '
        'btnPreviewBRSR
        '
        Me.btnPreviewBRSR.BackColor = System.Drawing.Color.White
        Me.btnPreviewBRSR.CornerRadius = 15
        Me.btnPreviewBRSR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewBRSR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewBRSR.Location = New System.Drawing.Point(191, 184)
        Me.btnPreviewBRSR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewBRSR.Name = "btnPreviewBRSR"
        Me.btnPreviewBRSR.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewBRSR.TabIndex = 1
        Me.btnPreviewBRSR.Text = "Preview"
        Me.btnPreviewBRSR.UseVisualStyleBackColor = False
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel15.Controls.Add(Me.Label8)
        Me.Panel15.Location = New System.Drawing.Point(1265, 436)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(309, 36)
        Me.Panel15.TabIndex = 53
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(12, 7)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(302, 20)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Lost/Damaged Property Certificate"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel16.Controls.Add(Me.btnGenerateLDPC)
        Me.Panel16.Controls.Add(Me.btnPreviewLDPC)
        Me.Panel16.Location = New System.Drawing.Point(1265, 436)
        Me.Panel16.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(309, 230)
        Me.Panel16.TabIndex = 52
        '
        'btnGenerateLDPC
        '
        Me.btnGenerateLDPC.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateLDPC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateLDPC.CornerRadius = 15
        Me.btnGenerateLDPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateLDPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateLDPC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateLDPC.Location = New System.Drawing.Point(80, 184)
        Me.btnGenerateLDPC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateLDPC.Name = "btnGenerateLDPC"
        Me.btnGenerateLDPC.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateLDPC.TabIndex = 0
        Me.btnGenerateLDPC.Text = "Generate"
        Me.btnGenerateLDPC.UseVisualStyleBackColor = False
        '
        'btnPreviewLDPC
        '
        Me.btnPreviewLDPC.BackColor = System.Drawing.Color.White
        Me.btnPreviewLDPC.CornerRadius = 15
        Me.btnPreviewLDPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewLDPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewLDPC.Location = New System.Drawing.Point(191, 184)
        Me.btnPreviewLDPC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewLDPC.Name = "btnPreviewLDPC"
        Me.btnPreviewLDPC.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewLDPC.TabIndex = 1
        Me.btnPreviewLDPC.Text = "Preview"
        Me.btnPreviewLDPC.UseVisualStyleBackColor = False
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel17.Controls.Add(Me.Label9)
        Me.Panel17.Location = New System.Drawing.Point(209, 705)
        Me.Panel17.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(327, 36)
        Me.Panel17.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Location = New System.Drawing.Point(12, 7)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(264, 20)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Department Allocation Report "
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel18.Controls.Add(Me.btnGenerateDAR)
        Me.Panel18.Controls.Add(Me.btnPreviewDAR)
        Me.Panel18.Location = New System.Drawing.Point(209, 705)
        Me.Panel18.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(327, 231)
        Me.Panel18.TabIndex = 56
        '
        'btnGenerateDAR
        '
        Me.btnGenerateDAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateDAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateDAR.CornerRadius = 15
        Me.btnGenerateDAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateDAR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateDAR.Location = New System.Drawing.Point(80, 189)
        Me.btnGenerateDAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateDAR.Name = "btnGenerateDAR"
        Me.btnGenerateDAR.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateDAR.TabIndex = 0
        Me.btnGenerateDAR.Text = "Generate"
        Me.btnGenerateDAR.UseVisualStyleBackColor = False
        '
        'btnPreviewDAR
        '
        Me.btnPreviewDAR.BackColor = System.Drawing.Color.White
        Me.btnPreviewDAR.CornerRadius = 15
        Me.btnPreviewDAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewDAR.Location = New System.Drawing.Point(206, 189)
        Me.btnPreviewDAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewDAR.Name = "btnPreviewDAR"
        Me.btnPreviewDAR.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewDAR.TabIndex = 1
        Me.btnPreviewDAR.Text = "Preview"
        Me.btnPreviewDAR.UseVisualStyleBackColor = False
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel19.Controls.Add(Me.Label10)
        Me.Panel19.Location = New System.Drawing.Point(566, 705)
        Me.Panel19.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(309, 36)
        Me.Panel19.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label10.Location = New System.Drawing.Point(12, 7)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(295, 20)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Annual Property Custodian Report"
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel20.Controls.Add(Me.btnGenerateAPCR)
        Me.Panel20.Controls.Add(Me.btnPreviewAPCR)
        Me.Panel20.Location = New System.Drawing.Point(566, 705)
        Me.Panel20.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(309, 231)
        Me.Panel20.TabIndex = 52
        '
        'btnGenerateAPCR
        '
        Me.btnGenerateAPCR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateAPCR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateAPCR.CornerRadius = 15
        Me.btnGenerateAPCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateAPCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateAPCR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateAPCR.Location = New System.Drawing.Point(80, 189)
        Me.btnGenerateAPCR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateAPCR.Name = "btnGenerateAPCR"
        Me.btnGenerateAPCR.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateAPCR.TabIndex = 0
        Me.btnGenerateAPCR.Text = "Generate"
        Me.btnGenerateAPCR.UseVisualStyleBackColor = False
        '
        'btnPreviewAPCR
        '
        Me.btnPreviewAPCR.BackColor = System.Drawing.Color.White
        Me.btnPreviewAPCR.CornerRadius = 15
        Me.btnPreviewAPCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewAPCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewAPCR.Location = New System.Drawing.Point(191, 189)
        Me.btnPreviewAPCR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewAPCR.Name = "btnPreviewAPCR"
        Me.btnPreviewAPCR.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewAPCR.TabIndex = 1
        Me.btnPreviewAPCR.Text = "Preview"
        Me.btnPreviewAPCR.UseVisualStyleBackColor = False
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel21.Controls.Add(Me.Label11)
        Me.Panel21.Location = New System.Drawing.Point(922, 705)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(309, 36)
        Me.Panel21.TabIndex = 53
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label11.Location = New System.Drawing.Point(12, 7)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 20)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Audit Report"
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel22.Controls.Add(Me.btnGenerateAR)
        Me.Panel22.Controls.Add(Me.btnPreviewAR)
        Me.Panel22.Location = New System.Drawing.Point(922, 705)
        Me.Panel22.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(309, 231)
        Me.Panel22.TabIndex = 52
        '
        'btnGenerateAR
        '
        Me.btnGenerateAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGenerateAR.CornerRadius = 15
        Me.btnGenerateAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateAR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateAR.Location = New System.Drawing.Point(80, 189)
        Me.btnGenerateAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerateAR.Name = "btnGenerateAR"
        Me.btnGenerateAR.Size = New System.Drawing.Size(103, 28)
        Me.btnGenerateAR.TabIndex = 0
        Me.btnGenerateAR.Text = "Generate"
        Me.btnGenerateAR.UseVisualStyleBackColor = False
        '
        'btnPreviewAR
        '
        Me.btnPreviewAR.BackColor = System.Drawing.Color.White
        Me.btnPreviewAR.CornerRadius = 15
        Me.btnPreviewAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviewAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviewAR.Location = New System.Drawing.Point(191, 189)
        Me.btnPreviewAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPreviewAR.Name = "btnPreviewAR"
        Me.btnPreviewAR.Size = New System.Drawing.Size(103, 28)
        Me.btnPreviewAR.TabIndex = 1
        Me.btnPreviewAR.Text = "Preview"
        Me.btnPreviewAR.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox1.Location = New System.Drawing.Point(226, 113)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 41)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 162
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(306, 113)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(656, 41)
        Me.TextBox1.TabIndex = 161
        '
        'SAReportsManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1773, 1080)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel21)
        Me.Controls.Add(Me.Panel22)
        Me.Controls.Add(Me.Panel19)
        Me.Controls.Add(Me.Panel20)
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.Panel18)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel14)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblReportsManagement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SAReportsManagement"
        Me.Text = "SAReportsManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.Panel18.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.Panel22.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblReportsManagement As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RoundedButton1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewRIS As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents lblRequisitionIssueSlip As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblMaintenacneReport As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnGenerateMRR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewMRR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblPropertyCard As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnGeneratePC As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewPC As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblStockCard As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btnGenerateSC As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewSC As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents btnGenerateICS As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewICS As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents btnGenerateOISR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewOISR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents btnGenerateBRSR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewBRSR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents btnGenerateLDPC As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewLDPC As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel18 As Panel
    Friend WithEvents btnGenerateDAR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewDAR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel20 As Panel
    Friend WithEvents btnGenerateAPCR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewAPCR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel21 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel22 As Panel
    Friend WithEvents btnGenerateAR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnPreviewAR As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
End Class
