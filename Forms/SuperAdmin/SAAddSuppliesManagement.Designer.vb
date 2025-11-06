Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAAddSuppliesManagement
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
        Me.lblStock = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.txtSupplyName = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSupplyName = New System.Windows.Forms.Label()
        Me.lblAddAccount = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtTotalValue = New System.Windows.Forms.TextBox()
        Me.txtUnitCost = New System.Windows.Forms.TextBox()
        Me.lblTotalValue = New System.Windows.Forms.Label()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel7 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundedPanel8 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.btnBack = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStock.Location = New System.Drawing.Point(213, 364)
        Me.lblStock.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(60, 23)
        Me.lblStock.TabIndex = 95
        Me.lblStock.Text = "Stock"
        '
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.Location = New System.Drawing.Point(380, 373)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(264, 19)
        Me.txtStock.TabIndex = 92
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(380, 312)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(264, 19)
        Me.txtLocation.TabIndex = 91
        '
        'txtCategory
        '
        Me.txtCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(380, 253)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(264, 19)
        Me.txtCategory.TabIndex = 90
        '
        'txtSupplyName
        '
        Me.txtSupplyName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtSupplyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSupplyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplyName.Location = New System.Drawing.Point(380, 193)
        Me.txtSupplyName.Name = "txtSupplyName"
        Me.txtSupplyName.Size = New System.Drawing.Size(264, 19)
        Me.txtSupplyName.TabIndex = 89
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblLocation.Location = New System.Drawing.Point(213, 304)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(88, 23)
        Me.lblLocation.TabIndex = 86
        Me.lblLocation.Text = "Location"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCategory.Location = New System.Drawing.Point(213, 244)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(91, 23)
        Me.lblCategory.TabIndex = 85
        Me.lblCategory.Text = "Category"
        '
        'lblSupplyName
        '
        Me.lblSupplyName.AutoSize = True
        Me.lblSupplyName.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplyName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSupplyName.Location = New System.Drawing.Point(213, 184)
        Me.lblSupplyName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblSupplyName.Name = "lblSupplyName"
        Me.lblSupplyName.Size = New System.Drawing.Size(130, 23)
        Me.lblSupplyName.TabIndex = 84
        Me.lblSupplyName.Text = "Supply Name"
        '
        'lblAddAccount
        '
        Me.lblAddAccount.AutoSize = True
        Me.lblAddAccount.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddAccount.Location = New System.Drawing.Point(590, 75)
        Me.lblAddAccount.Name = "lblAddAccount"
        Me.lblAddAccount.Size = New System.Drawing.Size(179, 32)
        Me.lblAddAccount.TabIndex = 83
        Me.lblAddAccount.Text = "Add Account"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.RoundedPanel2)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(369, 185)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel1.TabIndex = 96
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(8, 8)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel2.TabIndex = 79
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(369, 244)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel3.TabIndex = 97
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(369, 304)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel4.TabIndex = 99
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel5.CornerRadius = 20
        Me.RoundedPanel5.Location = New System.Drawing.Point(369, 364)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel5.TabIndex = 100
        '
        'txtTotalValue
        '
        Me.txtTotalValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalValue.Location = New System.Drawing.Point(870, 244)
        Me.txtTotalValue.Name = "txtTotalValue"
        Me.txtTotalValue.Size = New System.Drawing.Size(264, 19)
        Me.txtTotalValue.TabIndex = 105
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUnitCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitCost.Location = New System.Drawing.Point(870, 184)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(264, 19)
        Me.txtUnitCost.TabIndex = 104
        '
        'lblTotalValue
        '
        Me.lblTotalValue.AutoSize = True
        Me.lblTotalValue.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalValue.Location = New System.Drawing.Point(723, 246)
        Me.lblTotalValue.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTotalValue.Name = "lblTotalValue"
        Me.lblTotalValue.Size = New System.Drawing.Size(112, 23)
        Me.lblTotalValue.TabIndex = 103
        Me.lblTotalValue.Text = "Total Value"
        '
        'lblUnitCost
        '
        Me.lblUnitCost.AutoSize = True
        Me.lblUnitCost.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitCost.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUnitCost.Location = New System.Drawing.Point(723, 186)
        Me.lblUnitCost.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(93, 23)
        Me.lblUnitCost.TabIndex = 102
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel6.CornerRadius = 20
        Me.RoundedPanel6.Location = New System.Drawing.Point(859, 182)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel6.TabIndex = 106
        '
        'RoundedPanel7
        '
        Me.RoundedPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel7.CornerRadius = 20
        Me.RoundedPanel7.Location = New System.Drawing.Point(859, 244)
        Me.RoundedPanel7.Name = "RoundedPanel7"
        Me.RoundedPanel7.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel7.TabIndex = 107
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(870, 307)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(264, 19)
        Me.TextBox1.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(723, 309)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 23)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Status"
        '
        'RoundedPanel8
        '
        Me.RoundedPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel8.CornerRadius = 20
        Me.RoundedPanel8.Location = New System.Drawing.Point(859, 307)
        Me.RoundedPanel8.Name = "RoundedPanel8"
        Me.RoundedPanel8.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel8.TabIndex = 110
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBack.CornerRadius = 15
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(234, 587)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBack.Size = New System.Drawing.Size(93, 29)
        Me.btnBack.TabIndex = 111
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1041, 587)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSave.Size = New System.Drawing.Size(93, 29)
        Me.btnSave.TabIndex = 112
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'SAAddSuppliesManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1386, 788)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RoundedPanel8)
        Me.Controls.Add(Me.txtTotalValue)
        Me.Controls.Add(Me.txtUnitCost)
        Me.Controls.Add(Me.lblTotalValue)
        Me.Controls.Add(Me.lblUnitCost)
        Me.Controls.Add(Me.RoundedPanel6)
        Me.Controls.Add(Me.RoundedPanel7)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtSupplyName)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblSupplyName)
        Me.Controls.Add(Me.lblAddAccount)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.RoundedPanel4)
        Me.Controls.Add(Me.RoundedPanel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SAAddSuppliesManagement"
        Me.Text = "SAAddSuppliesManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RoundedPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStock As Label
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents txtSupplyName As TextBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSupplyName As Label
    Friend WithEvents lblAddAccount As Label
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel5 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtTotalValue As TextBox
    Friend WithEvents txtUnitCost As TextBox
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents lblUnitCost As Label
    Friend WithEvents RoundedPanel6 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel7 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundedPanel8 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents btnBack As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
