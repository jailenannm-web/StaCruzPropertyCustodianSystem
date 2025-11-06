Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SADepartmentManagement
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
        Dim lblEmployee As System.Windows.Forms.Label
        Me.pnlSearch = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        Me.lblSuppliesManagement = New System.Windows.Forms.Label()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddDepartent = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.countDepartment = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.countEmployee = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.countBudget = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.countActiveDep = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblTotalDep = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblBudget = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblActiveDep = New System.Windows.Forms.Label()
        lblEmployee = New System.Windows.Forms.Label()
        Me.pnlSearch.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEmployee
        '
        lblEmployee.AutoSize = True
        lblEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblEmployee.ForeColor = System.Drawing.Color.White
        lblEmployee.Location = New System.Drawing.Point(3, 5)
        lblEmployee.Name = "lblEmployee"
        lblEmployee.Size = New System.Drawing.Size(130, 18)
        lblEmployee.TabIndex = 45
        lblEmployee.Text = " Total Employee"
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.CornerRadius = 20
        Me.pnlSearch.Location = New System.Drawing.Point(39, 105)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(613, 30)
        Me.pnlSearch.TabIndex = 31
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Location = New System.Drawing.Point(165, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(435, 13)
        Me.txtSearch.TabIndex = 0
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 20
        Me.pnlCategories.Location = New System.Drawing.Point(727, 105)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(133, 30)
        Me.pnlCategories.TabIndex = 33
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(13, 4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(111, 21)
        Me.comboCategoris.TabIndex = 0
        '
        'lblSuppliesManagement
        '
        Me.lblSuppliesManagement.AutoSize = True
        Me.lblSuppliesManagement.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuppliesManagement.Location = New System.Drawing.Point(33, 46)
        Me.lblSuppliesManagement.Name = "lblSuppliesManagement"
        Me.lblSuppliesManagement.Size = New System.Drawing.Size(346, 32)
        Me.lblSuppliesManagement.TabIndex = 32
        Me.lblSuppliesManagement.Text = "Department Management"
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.comboStatus)
        Me.pnlStatus.CornerRadius = 20
        Me.pnlStatus.Location = New System.Drawing.Point(928, 105)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(133, 30)
        Me.pnlStatus.TabIndex = 34
        '
        'comboStatus
        '
        Me.comboStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboStatus.FormattingEnabled = True
        Me.comboStatus.Location = New System.Drawing.Point(11, 5)
        Me.comboStatus.Name = "comboStatus"
        Me.comboStatus.Size = New System.Drawing.Size(111, 21)
        Me.comboStatus.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(877, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(658, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Categories"
        '
        'btnAddDepartent
        '
        Me.btnAddDepartent.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAddDepartent.CornerRadius = 15
        Me.btnAddDepartent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddDepartent.Font = New System.Drawing.Font("Leelawadee", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDepartent.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddDepartent.Location = New System.Drawing.Point(928, 55)
        Me.btnAddDepartent.Name = "btnAddDepartent"
        Me.btnAddDepartent.Size = New System.Drawing.Size(127, 27)
        Me.btnAddDepartent.TabIndex = 37
        Me.btnAddDepartent.Text = "Add Department"
        Me.btnAddDepartent.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(39, 147)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1011, 138)
        Me.Panel2.TabIndex = 39
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(39, 291)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1011, 138)
        Me.Panel3.TabIndex = 40
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(39, 435)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1011, 138)
        Me.Panel4.TabIndex = 40
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel1.Controls.Add(Me.countDepartment)
        Me.Panel1.Location = New System.Drawing.Point(39, 580)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(223, 119)
        Me.Panel1.TabIndex = 41
        '
        'countDepartment
        '
        Me.countDepartment.AutoSize = True
        Me.countDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.countDepartment.ForeColor = System.Drawing.Color.White
        Me.countDepartment.Location = New System.Drawing.Point(86, 54)
        Me.countDepartment.Name = "countDepartment"
        Me.countDepartment.Size = New System.Drawing.Size(37, 39)
        Me.countDepartment.TabIndex = 45
        Me.countDepartment.Text = "3"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel5.Controls.Add(Me.countEmployee)
        Me.Panel5.Controls.Add(Me.Panel9)
        Me.Panel5.Location = New System.Drawing.Point(294, 580)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(223, 119)
        Me.Panel5.TabIndex = 42
        '
        'countEmployee
        '
        Me.countEmployee.AutoSize = True
        Me.countEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.countEmployee.ForeColor = System.Drawing.Color.White
        Me.countEmployee.Location = New System.Drawing.Point(96, 54)
        Me.countEmployee.Name = "countEmployee"
        Me.countEmployee.Size = New System.Drawing.Size(37, 39)
        Me.countEmployee.TabIndex = 46
        Me.countEmployee.Text = "3"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel9.Controls.Add(lblEmployee)
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(223, 32)
        Me.Panel9.TabIndex = 43
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel6.Controls.Add(Me.countBudget)
        Me.Panel6.Location = New System.Drawing.Point(558, 580)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(223, 119)
        Me.Panel6.TabIndex = 42
        '
        'countBudget
        '
        Me.countBudget.AutoSize = True
        Me.countBudget.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.countBudget.ForeColor = System.Drawing.Color.White
        Me.countBudget.Location = New System.Drawing.Point(84, 54)
        Me.countBudget.Name = "countBudget"
        Me.countBudget.Size = New System.Drawing.Size(37, 39)
        Me.countBudget.TabIndex = 47
        Me.countBudget.Text = "3"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Panel7.Controls.Add(Me.countActiveDep)
        Me.Panel7.Location = New System.Drawing.Point(827, 580)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(223, 119)
        Me.Panel7.TabIndex = 42
        '
        'countActiveDep
        '
        Me.countActiveDep.AutoSize = True
        Me.countActiveDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.countActiveDep.ForeColor = System.Drawing.Color.White
        Me.countActiveDep.Location = New System.Drawing.Point(94, 54)
        Me.countActiveDep.Name = "countActiveDep"
        Me.countActiveDep.Size = New System.Drawing.Size(37, 39)
        Me.countActiveDep.TabIndex = 46
        Me.countActiveDep.Text = "3"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel8.Controls.Add(Me.lblTotalDep)
        Me.Panel8.Location = New System.Drawing.Point(39, 579)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(223, 32)
        Me.Panel8.TabIndex = 42
        '
        'lblTotalDep
        '
        Me.lblTotalDep.AutoSize = True
        Me.lblTotalDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDep.ForeColor = System.Drawing.Color.White
        Me.lblTotalDep.Location = New System.Drawing.Point(3, 6)
        Me.lblTotalDep.Name = "lblTotalDep"
        Me.lblTotalDep.Size = New System.Drawing.Size(143, 18)
        Me.lblTotalDep.TabIndex = 44
        Me.lblTotalDep.Text = " Total Department"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel10.Controls.Add(Me.lblBudget)
        Me.Panel10.Location = New System.Drawing.Point(558, 579)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(223, 32)
        Me.Panel10.TabIndex = 43
        '
        'lblBudget
        '
        Me.lblBudget.AutoSize = True
        Me.lblBudget.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBudget.ForeColor = System.Drawing.Color.White
        Me.lblBudget.Location = New System.Drawing.Point(3, 6)
        Me.lblBudget.Name = "lblBudget"
        Me.lblBudget.Size = New System.Drawing.Size(108, 18)
        Me.lblBudget.TabIndex = 46
        Me.lblBudget.Text = " Total Budget"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel11.Controls.Add(Me.lblActiveDep)
        Me.Panel11.Location = New System.Drawing.Point(827, 579)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(223, 32)
        Me.Panel11.TabIndex = 43
        '
        'lblActiveDep
        '
        Me.lblActiveDep.AutoSize = True
        Me.lblActiveDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveDep.ForeColor = System.Drawing.Color.White
        Me.lblActiveDep.Location = New System.Drawing.Point(11, 6)
        Me.lblActiveDep.Name = "lblActiveDep"
        Me.lblActiveDep.Size = New System.Drawing.Size(145, 18)
        Me.lblActiveDep.TabIndex = 47
        Me.lblActiveDep.Text = "Active Department"
        '
        'SADepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1104, 710)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnAddDepartent)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.lblSuppliesManagement)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SADepartmentManagement"
        Me.Text = "SADepartmentManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlCategories.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSearch As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents pnlCategories As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
    Friend WithEvents lblSuppliesManagement As Label
    Friend WithEvents pnlStatus As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents comboStatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddDepartent As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblBudget As Label
    Friend WithEvents lblTotalDep As Label
    Friend WithEvents lblActiveDep As Label
    Friend WithEvents countDepartment As Label
    Friend WithEvents countEmployee As Label
    Friend WithEvents countBudget As Label
    Friend WithEvents countActiveDep As Label
End Class
