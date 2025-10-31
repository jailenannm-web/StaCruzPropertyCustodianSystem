Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPropertyRequest
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

    'Declare controls at class level
    Friend WithEvents txtPropertyRequest As Label
    Friend WithEvents lblItem As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblPurpose As Label
    Friend WithEvents comboItem As ComboBox
    Friend WithEvents numericQuantity As NumericUpDown
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents btnSubmitRequest As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtPropertyRequest = New System.Windows.Forms.Label()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.comboItem = New System.Windows.Forms.ComboBox()
        Me.numericQuantity = New System.Windows.Forms.NumericUpDown()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.btnSubmitRequest = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.numericQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPropertyRequest
        '
        Me.txtPropertyRequest.AutoSize = True
        Me.txtPropertyRequest.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Bold)
        Me.txtPropertyRequest.Location = New System.Drawing.Point(414, 59)
        Me.txtPropertyRequest.Name = "txtPropertyRequest"
        Me.txtPropertyRequest.Size = New System.Drawing.Size(239, 32)
        Me.txtPropertyRequest.TabIndex = 0
        Me.txtPropertyRequest.Text = "Property Request"
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Font = New System.Drawing.Font("Leelawadee", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblItem.Location = New System.Drawing.Point(495, 148)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(44, 19)
        Me.lblItem.TabIndex = 1
        Me.lblItem.Text = "Item"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Leelawadee", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblQuantity.Location = New System.Drawing.Point(480, 225)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(76, 19)
        Me.lblQuantity.TabIndex = 2
        Me.lblQuantity.Text = "Quantity"
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Font = New System.Drawing.Font("Leelawadee", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPurpose.Location = New System.Drawing.Point(485, 308)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(71, 19)
        Me.lblPurpose.TabIndex = 3
        Me.lblPurpose.Text = "Purpose"
        '
        'comboItem
        '
        Me.comboItem.BackColor = System.Drawing.Color.FromArgb(27, 60, 83)
        Me.comboItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboItem.Font = New System.Drawing.Font("Leelawadee", 11.25!)
        Me.comboItem.ForeColor = System.Drawing.Color.White
        Me.comboItem.FormattingEnabled = True
        Me.comboItem.Location = New System.Drawing.Point(374, 170)
        Me.comboItem.Name = "comboItem"
        Me.comboItem.Size = New System.Drawing.Size(318, 26)
        Me.comboItem.TabIndex = 4
        '
        'numericQuantity
        '
        Me.numericQuantity.BackColor = System.Drawing.Color.FromArgb(27, 60, 83)
        Me.numericQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.numericQuantity.Font = New System.Drawing.Font("Leelawadee", 11.25!)
        Me.numericQuantity.ForeColor = System.Drawing.Color.White
        Me.numericQuantity.Hexadecimal = True
        Me.numericQuantity.Location = New System.Drawing.Point(457, 247)
        Me.numericQuantity.Name = "numericQuantity"
        Me.numericQuantity.Size = New System.Drawing.Size(120, 21)
        Me.numericQuantity.TabIndex = 5
        '
        'txtPurpose
        '
        Me.txtPurpose.BackColor = System.Drawing.Color.FromArgb(27, 60, 83)
        Me.txtPurpose.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPurpose.Font = New System.Drawing.Font("Leelawadee", 11.25!)
        Me.txtPurpose.ForeColor = System.Drawing.Color.White
        Me.txtPurpose.Location = New System.Drawing.Point(310, 330)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(430, 164)
        Me.txtPurpose.TabIndex = 6
        '
        'btnSubmitRequest
        '
        Me.btnSubmitRequest.BackColor = System.Drawing.Color.FromArgb(27, 60, 83)
        Me.btnSubmitRequest.CornerRadius = 15
        Me.btnSubmitRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmitRequest.Font = New System.Drawing.Font("Leelawadee", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSubmitRequest.ForeColor = System.Drawing.Color.White
        Me.btnSubmitRequest.Location = New System.Drawing.Point(446, 562)
        Me.btnSubmitRequest.Name = "btnSubmitRequest"
        Me.btnSubmitRequest.Size = New System.Drawing.Size(157, 43)
        Me.btnSubmitRequest.TabIndex = 7
        Me.btnSubmitRequest.Text = "Submit Request"
        Me.btnSubmitRequest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubmitRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmitRequest.UseCompatibleTextRendering = True
        Me.btnSubmitRequest.UseVisualStyleBackColor = False
        '
        'frmPropertyRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1056, 679)
        Me.Controls.Add(Me.btnSubmitRequest)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.numericQuantity)
        Me.Controls.Add(Me.comboItem)
        Me.Controls.Add(Me.lblPurpose)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.txtPropertyRequest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPropertyRequest"
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.numericQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
