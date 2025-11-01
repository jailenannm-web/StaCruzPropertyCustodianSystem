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
        Me.txtPropertyRequest = New System.Windows.Forms.Label()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.comboItem = New System.Windows.Forms.ComboBox()
        Me.numericQuantity = New System.Windows.Forms.NumericUpDown()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.btnSubmitRequest = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        CType(Me.numericQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPropertyRequest
        '
        Me.txtPropertyRequest.AutoSize = True
        Me.txtPropertyRequest.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropertyRequest.Location = New System.Drawing.Point(435, 59)
        Me.txtPropertyRequest.Name = "txtPropertyRequest"
        Me.txtPropertyRequest.Size = New System.Drawing.Size(239, 32)
        Me.txtPropertyRequest.TabIndex = 0
        Me.txtPropertyRequest.Text = "Property Request"
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem.Location = New System.Drawing.Point(520, 137)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(50, 23)
        Me.lblItem.TabIndex = 1
        Me.lblItem.Text = "Item"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.Location = New System.Drawing.Point(502, 234)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(88, 23)
        Me.lblQuantity.TabIndex = 2
        Me.lblQuantity.Text = "Quantity"
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPurpose.Location = New System.Drawing.Point(506, 319)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(84, 23)
        Me.lblPurpose.TabIndex = 3
        Me.lblPurpose.Text = "Purpose"
        '
        'comboItem
        '
        Me.comboItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboItem.Font = New System.Drawing.Font("Leelawadee", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboItem.ForeColor = System.Drawing.Color.White
        Me.comboItem.FormattingEnabled = True
        Me.comboItem.ItemHeight = 18
        Me.comboItem.Location = New System.Drawing.Point(17, 10)
        Me.comboItem.Name = "comboItem"
        Me.comboItem.Size = New System.Drawing.Size(341, 26)
        Me.comboItem.TabIndex = 4
        '
        'numericQuantity
        '
        Me.numericQuantity.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.numericQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.numericQuantity.Font = New System.Drawing.Font("Leelawadee", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numericQuantity.ForeColor = System.Drawing.Color.White
        Me.numericQuantity.Hexadecimal = True
        Me.numericQuantity.Location = New System.Drawing.Point(14, 6)
        Me.numericQuantity.Name = "numericQuantity"
        Me.numericQuantity.Size = New System.Drawing.Size(120, 21)
        Me.numericQuantity.TabIndex = 5
        '
        'txtPurpose
        '
        Me.txtPurpose.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.txtPurpose.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPurpose.Font = New System.Drawing.Font("Leelawadee", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurpose.ForeColor = System.Drawing.Color.White
        Me.txtPurpose.Location = New System.Drawing.Point(302, 345)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(527, 256)
        Me.txtPurpose.TabIndex = 6
        '
        'btnSubmitRequest
        '
        Me.btnSubmitRequest.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnSubmitRequest.CornerRadius = 15
        Me.btnSubmitRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmitRequest.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitRequest.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSubmitRequest.Image = My.Resources.Resources.icSubmit1
        Me.btnSubmitRequest.Location = New System.Drawing.Point(467, 624)
        Me.btnSubmitRequest.Name = "btnSubmitRequest"
        Me.btnSubmitRequest.Size = New System.Drawing.Size(157, 43)
        Me.btnSubmitRequest.TabIndex = 7
        Me.btnSubmitRequest.Text = "Submit Request"
        Me.btnSubmitRequest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmitRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmitRequest.UseCompatibleTextRendering = True
        Me.btnSubmitRequest.UseVisualStyleBackColor = False
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.Controls.Add(Me.comboItem)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(360, 163)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(374, 45)
        Me.RoundedPanel1.TabIndex = 8
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel3.Controls.Add(Me.numericQuantity)
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(481, 260)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(143, 31)
        Me.RoundedPanel3.TabIndex = 10
        '
        'frmPropertyRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1056, 679)
        Me.Controls.Add(Me.btnSubmitRequest)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.lblPurpose)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.txtPropertyRequest)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPropertyRequest"
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.numericQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPropertyRequest As Label
    Friend WithEvents lblItem As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblPurpose As Label
    Friend WithEvents comboItem As ComboBox
    Friend WithEvents numericQuantity As NumericUpDown
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents btnSubmitRequest As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
End Class
