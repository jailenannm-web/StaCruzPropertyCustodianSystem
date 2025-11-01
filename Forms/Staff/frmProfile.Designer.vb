Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProfile
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
        Dim txtFullName As System.Windows.Forms.TextBox
        Dim txtContact As System.Windows.Forms.TextBox
        Dim txtEmail As System.Windows.Forms.TextBox
        Me.lblProfile = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblAssignedDep = New System.Windows.Forms.Label()
        Me.comboPosition = New System.Windows.Forms.ComboBox()
        Me.comboAssigned = New System.Windows.Forms.ComboBox()
        Me.btnUpdate = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedPanel5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        txtFullName = New System.Windows.Forms.TextBox()
        txtContact = New System.Windows.Forms.TextBox()
        txtEmail = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtFullName
        '
        txtFullName.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtFullName.Font = New System.Drawing.Font("Leelawadee", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFullName.ForeColor = System.Drawing.SystemColors.Window
        txtFullName.Location = New System.Drawing.Point(346, 178)
        txtFullName.Multiline = True
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New System.Drawing.Size(426, 29)
        txtFullName.TabIndex = 9
        AddHandler txtFullName.TextChanged, AddressOf Me.txtbxName_TextChanged
        '
        'txtContact
        '
        txtContact.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        txtContact.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtContact.Font = New System.Drawing.Font("Leelawadee", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtContact.ForeColor = System.Drawing.SystemColors.Window
        txtContact.Location = New System.Drawing.Point(104, 384)
        txtContact.Name = "txtContact"
        txtContact.Size = New System.Drawing.Size(252, 29)
        txtContact.TabIndex = 12
        '
        'txtEmail
        '
        txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        txtEmail.Font = New System.Drawing.Font("Leelawadee", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtEmail.ForeColor = System.Drawing.SystemColors.Window
        txtEmail.Location = New System.Drawing.Point(733, 384)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New System.Drawing.Size(237, 29)
        txtEmail.TabIndex = 13
        '
        'lblProfile
        '
        Me.lblProfile.AutoSize = True
        Me.lblProfile.Font = New System.Drawing.Font("Leelawadee", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfile.Location = New System.Drawing.Point(491, 48)
        Me.lblProfile.Name = "lblProfile"
        Me.lblProfile.Size = New System.Drawing.Size(129, 41)
        Me.lblProfile.TabIndex = 0
        Me.lblProfile.Text = "Profile"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullName.Location = New System.Drawing.Point(499, 142)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(101, 23)
        Me.lblFullName.TabIndex = 1
        Me.lblFullName.Text = "Full Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(493, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 25)
        Me.Label1.TabIndex = 2
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.Location = New System.Drawing.Point(499, 237)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(85, 23)
        Me.lblPosition.TabIndex = 3
        Me.lblPosition.Text = "Position"
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContact.Location = New System.Drawing.Point(187, 347)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(79, 23)
        Me.lblContact.TabIndex = 4
        Me.lblContact.Text = "Contact"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(833, 347)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(59, 23)
        Me.lblEmail.TabIndex = 5
        Me.lblEmail.Text = "Email"
        '
        'lblAssignedDep
        '
        Me.lblAssignedDep.AutoSize = True
        Me.lblAssignedDep.Font = New System.Drawing.Font("Leelawadee", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignedDep.Location = New System.Drawing.Point(425, 480)
        Me.lblAssignedDep.Name = "lblAssignedDep"
        Me.lblAssignedDep.Size = New System.Drawing.Size(264, 23)
        Me.lblAssignedDep.TabIndex = 6
        Me.lblAssignedDep.Text = "Assigned Department/Office"
        '
        'comboPosition
        '
        Me.comboPosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboPosition.Font = New System.Drawing.Font("Leelawadee", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboPosition.ForeColor = System.Drawing.SystemColors.Window
        Me.comboPosition.FormattingEnabled = True
        Me.comboPosition.Location = New System.Drawing.Point(346, 280)
        Me.comboPosition.Name = "comboPosition"
        Me.comboPosition.Size = New System.Drawing.Size(426, 27)
        Me.comboPosition.TabIndex = 10
        '
        'comboAssigned
        '
        Me.comboAssigned.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboAssigned.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboAssigned.Font = New System.Drawing.Font("Leelawadee", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAssigned.ForeColor = System.Drawing.SystemColors.Window
        Me.comboAssigned.FormattingEnabled = True
        Me.comboAssigned.Location = New System.Drawing.Point(408, 522)
        Me.comboAssigned.Name = "comboAssigned"
        Me.comboAssigned.Size = New System.Drawing.Size(308, 27)
        Me.comboAssigned.TabIndex = 11
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnUpdate.CornerRadius = 20
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Leelawadee", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(918, 630)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(85, 34)
        Me.btnUpdate.TabIndex = 8
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnEdit.CornerRadius = 20
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Leelawadee", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(785, 630)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(87, 34)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(333, 168)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(452, 47)
        Me.RoundedPanel1.TabIndex = 14
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(333, 271)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(452, 47)
        Me.RoundedPanel2.TabIndex = 15
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel3.CornerRadius = 20
        Me.RoundedPanel3.Location = New System.Drawing.Point(716, 373)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.Size = New System.Drawing.Size(269, 47)
        Me.RoundedPanel3.TabIndex = 16
        '
        'RoundedPanel4
        '
        Me.RoundedPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel4.CornerRadius = 20
        Me.RoundedPanel4.Location = New System.Drawing.Point(98, 373)
        Me.RoundedPanel4.Name = "RoundedPanel4"
        Me.RoundedPanel4.Size = New System.Drawing.Size(265, 47)
        Me.RoundedPanel4.TabIndex = 17
        '
        'RoundedPanel5
        '
        Me.RoundedPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedPanel5.CornerRadius = 20
        Me.RoundedPanel5.Location = New System.Drawing.Point(395, 510)
        Me.RoundedPanel5.Name = "RoundedPanel5"
        Me.RoundedPanel5.Size = New System.Drawing.Size(328, 47)
        Me.RoundedPanel5.TabIndex = 18
        '
        'frmProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1072, 718)
        Me.Controls.Add(txtContact)
        Me.Controls.Add(Me.comboAssigned)
        Me.Controls.Add(Me.comboPosition)
        Me.Controls.Add(txtFullName)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblAssignedDep)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblProfile)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(txtEmail)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.RoundedPanel4)
        Me.Controls.Add(Me.RoundedPanel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProfile"
        Me.Text = "frmProfile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblProfile As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblAssignedDep As Label
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnUpdate As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Public WithEvents comboPosition As ComboBox
    Public WithEvents comboAssigned As ComboBox
    Friend WithEvents RoundedPanel1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel5 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
End Class
