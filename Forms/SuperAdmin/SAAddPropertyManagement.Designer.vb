Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAAddPropertyManagement
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
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnBack = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundedPanel8 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtTotalValue = New System.Windows.Forms.TextBox()
        Me.txtUnitCost = New System.Windows.Forms.TextBox()
        Me.lblTotalValue = New System.Windows.Forms.Label()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.RoundedPanel6 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel7 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.txtSupplyID = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSupply = New System.Windows.Forms.Label()
        Me.lblPropertyManagement = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.RoundedPanel9 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1052, 579)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSave.Size = New System.Drawing.Size(93, 29)
        Me.btnSave.TabIndex = 136
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBack.CornerRadius = 15
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(245, 579)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnBack.Size = New System.Drawing.Size(93, 29)
        Me.btnBack.TabIndex = 135
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(881, 299)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(264, 19)
        Me.TextBox1.TabIndex = 133
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(734, 301)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 23)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Status"
        '
        'RoundedPanel8
        '
        Me.RoundedPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel8.CornerRadius = 20
        Me.RoundedPanel8.Location = New System.Drawing.Point(870, 299)
        Me.RoundedPanel8.Name = "RoundedPanel8"
        Me.RoundedPanel8.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel8.TabIndex = 134
        '
        'txtTotalValue
        '
        Me.txtTotalValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalValue.Location = New System.Drawing.Point(881, 236)
        Me.txtTotalValue.Name = "txtTotalValue"
        Me.txtTotalValue.Size = New System.Drawing.Size(264, 19)
        Me.txtTotalValue.TabIndex = 129
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUnitCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitCost.Location = New System.Drawing.Point(881, 176)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(264, 19)
        Me.txtUnitCost.TabIndex = 128
        '
        'lblTotalValue
        '
        Me.lblTotalValue.AutoSize = True
        Me.lblTotalValue.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTotalValue.Location = New System.Drawing.Point(734, 238)
        Me.lblTotalValue.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTotalValue.Name = "lblTotalValue"
        Me.lblTotalValue.Size = New System.Drawing.Size(112, 23)
        Me.lblTotalValue.TabIndex = 127
        Me.lblTotalValue.Text = "Total Value"
        '
        'lblUnitCost
        '
        Me.lblUnitCost.AutoSize = True
        Me.lblUnitCost.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitCost.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUnitCost.Location = New System.Drawing.Point(734, 178)
        Me.lblUnitCost.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(93, 23)
        Me.lblUnitCost.TabIndex = 126
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'RoundedPanel6
        '
        Me.RoundedPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel6.CornerRadius = 20
        Me.RoundedPanel6.Location = New System.Drawing.Point(870, 174)
        Me.RoundedPanel6.Name = "RoundedPanel6"
        Me.RoundedPanel6.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel6.TabIndex = 130
        '
        'RoundedPanel7
        '
        Me.RoundedPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel7.CornerRadius = 20
        Me.RoundedPanel7.Location = New System.Drawing.Point(870, 236)
        Me.RoundedPanel7.Name = "RoundedPanel7"
        Me.RoundedPanel7.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel7.TabIndex = 131
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStock.Location = New System.Drawing.Point(224, 356)
        Me.lblStock.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(60, 23)
        Me.lblStock.TabIndex = 121
        Me.lblStock.Text = "Stock"
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
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.Location = New System.Drawing.Point(365, 365)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(264, 19)
        Me.txtStock.TabIndex = 120
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(365, 244)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(264, 19)
        Me.txtName.TabIndex = 119
        '
        'txtCategory
        '
        Me.txtCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(365, 308)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(264, 19)
        Me.txtCategory.TabIndex = 118
        '
        'txtSupplyID
        '
        Me.txtSupplyID.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtSupplyID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSupplyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplyID.Location = New System.Drawing.Point(365, 185)
        Me.txtSupplyID.Name = "txtSupplyID"
        Me.txtSupplyID.Size = New System.Drawing.Size(264, 19)
        Me.txtSupplyID.TabIndex = 117
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblName.Location = New System.Drawing.Point(224, 236)
        Me.lblName.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(62, 23)
        Me.lblName.TabIndex = 116
        Me.lblName.Text = "Name"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCategory.Location = New System.Drawing.Point(224, 299)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(91, 23)
        Me.lblCategory.TabIndex = 115
        Me.lblCategory.Text = "Category"
        '
        'lblSupply
        '
        Me.lblSupply.AutoSize = True
        Me.lblSupply.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupply.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSupply.Location = New System.Drawing.Point(224, 176)
        Me.lblSupply.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblSupply.Name = "lblSupply"
        Me.lblSupply.Size = New System.Drawing.Size(98, 23)
        Me.lblSupply.TabIndex = 114
        Me.lblSupply.Text = "Supply ID"
        '
        'lblPropertyManagement
        '
        Me.lblPropertyManagement.AutoSize = True
        Me.lblPropertyManagement.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyManagement.Location = New System.Drawing.Point(601, 67)
        Me.lblPropertyManagement.Name = "lblPropertyManagement"
        Me.lblPropertyManagement.Size = New System.Drawing.Size(297, 32)
        Me.lblPropertyManagement.TabIndex = 113
        Me.lblPropertyManagement.Text = "PropertyManagement"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.RoundedPanel2)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(354, 177)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel1.TabIndex = 122
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(354, 299)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel3.TabIndex = 123
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(354, 236)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel4.TabIndex = 124
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel5.CornerRadius = 20
        Me.RoundedPanel5.Location = New System.Drawing.Point(354, 356)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel5.TabIndex = 125
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblLocation.Location = New System.Drawing.Point(734, 356)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(88, 23)
        Me.lblLocation.TabIndex = 138
        Me.lblLocation.Text = "Location"
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.Location = New System.Drawing.Point(11, 8)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(264, 19)
        Me.txtLocation.TabIndex = 137
        '
        'RoundedPanel9
        '
        Me.RoundedPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.RoundedPanel9.Controls.Add(Me.txtLocation)
        Me.RoundedPanel9.CornerRadius = 20
        Me.RoundedPanel9.Location = New System.Drawing.Point(870, 356)
        Me.RoundedPanel9.Name = "RoundedPanel9"
        Me.RoundedPanel9.Size = New System.Drawing.Size(286, 30)
        Me.RoundedPanel9.TabIndex = 139
        '
        'SAAddPropertyManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1386, 788)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.RoundedPanel9)
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
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtSupplyID)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblSupply)
        Me.Controls.Add(Me.lblPropertyManagement)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.RoundedPanel4)
        Me.Controls.Add(Me.RoundedPanel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SAAddPropertyManagement"
        Me.Text = "SAAddPropertyManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel9.ResumeLayout(False)
        Me.RoundedPanel9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnBack As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundedPanel8 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtTotalValue As TextBox
    Friend WithEvents txtUnitCost As TextBox
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents lblUnitCost As Label
    Friend WithEvents RoundedPanel6 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel7 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents lblStock As Label
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents txtSupplyID As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSupply As Label
    Friend WithEvents lblPropertyManagement As Label
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel5 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents lblLocation As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents RoundedPanel9 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
End Class
