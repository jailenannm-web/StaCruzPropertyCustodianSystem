Imports System.Windows.Forms
Imports System.Drawing
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserLevel
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_Staff = New System.Windows.Forms.Button()
        Me.btn_Admin = New System.Windows.Forms.Button()
        Me.btn_SuperAdmin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Poppins", 50.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(106, 520)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(740, 114)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "STA CRUZ PROPERTY"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Poppins", 50.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(100, 616)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(746, 90)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = " CUSTODIAN SYSTEM"
        '
        'Label4
        '
        Me.Label4.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.logo2_removebg_preview
        Me.Label4.Location = New System.Drawing.Point(314, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(318, 262)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btn_Staff)
        Me.Panel1.Controls.Add(Me.btn_Admin)
        Me.Panel1.Controls.Add(Me.btn_SuperAdmin)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(891, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(648, 878)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Poppins", 50.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(226, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(262, 98)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "LEVEL"
        '
        'btn_Staff
        '
        Me.btn_Staff.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Staff.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Staff.Font = New System.Drawing.Font("Poppins", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Staff.ForeColor = System.Drawing.Color.White
        Me.btn_Staff.Location = New System.Drawing.Point(141, 645)
        Me.btn_Staff.Name = "btn_Staff"
        Me.btn_Staff.Size = New System.Drawing.Size(398, 74)
        Me.btn_Staff.TabIndex = 3
        Me.btn_Staff.Text = "STAFF"
        Me.btn_Staff.UseVisualStyleBackColor = False
        '
        'btn_Admin
        '
        Me.btn_Admin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Admin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Admin.Font = New System.Drawing.Font("Poppins", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Admin.ForeColor = System.Drawing.Color.White
        Me.btn_Admin.Location = New System.Drawing.Point(141, 520)
        Me.btn_Admin.Name = "btn_Admin"
        Me.btn_Admin.Size = New System.Drawing.Size(398, 74)
        Me.btn_Admin.TabIndex = 2
        Me.btn_Admin.Text = "ADMIN"
        Me.btn_Admin.UseVisualStyleBackColor = False
        '
        'btn_SuperAdmin
        '
        Me.btn_SuperAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_SuperAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_SuperAdmin.Font = New System.Drawing.Font("Poppins", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SuperAdmin.ForeColor = System.Drawing.Color.White
        Me.btn_SuperAdmin.Location = New System.Drawing.Point(141, 394)
        Me.btn_SuperAdmin.Name = "btn_SuperAdmin"
        Me.btn_SuperAdmin.Size = New System.Drawing.Size(398, 74)
        Me.btn_SuperAdmin.TabIndex = 1
        Me.btn_SuperAdmin.Text = "SUPER ADMIN"
        Me.btn_SuperAdmin.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Poppins", 50.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(73, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(542, 90)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "USER ACCESS"
        '
        'UserLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.BG1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1539, 878)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UserLevel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserAccess"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Staff As Button
    Friend WithEvents btn_Admin As Button
    Friend WithEvents btn_SuperAdmin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class

Friend Class RoundedPanel
    Public Sub New()
    End Sub
End Class
