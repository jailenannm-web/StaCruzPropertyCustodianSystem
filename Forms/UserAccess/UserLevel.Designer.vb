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
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Poppins ExtraBold", 80.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 572)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1187, 132)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "STA CRUZ PROPERTY"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Poppins ExtraBold", 69.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(58, 704)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1047, 120)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = " CUSTODIAN SYSTEM"
        '
        'Label4
        '
        Me.Label4.Image = My.Resources.Resources.logo2_removebg_preview
        Me.Label4.Location = New System.Drawing.Point(446, 255)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(280, 289)
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
        Me.Panel1.Location = New System.Drawing.Point(1199, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(700, 959)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Poppins ExtraBold", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(229, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(293, 133)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "LEVEL"
        '
        'btn_Staff
        '
        Me.btn_Staff.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Staff.Font = New System.Drawing.Font("Poppins", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Staff.ForeColor = System.Drawing.Color.White
        Me.btn_Staff.Location = New System.Drawing.Point(172, 641)
        Me.btn_Staff.Name = "btn_Staff"
        Me.btn_Staff.Size = New System.Drawing.Size(373, 75)
        Me.btn_Staff.TabIndex = 3
        Me.btn_Staff.Text = "STAFF"
        Me.btn_Staff.UseVisualStyleBackColor = False
        '
        'btn_Admin
        '
        Me.btn_Admin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Admin.Font = New System.Drawing.Font("Poppins", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Admin.ForeColor = System.Drawing.Color.White
        Me.btn_Admin.Location = New System.Drawing.Point(172, 520)
        Me.btn_Admin.Name = "btn_Admin"
        Me.btn_Admin.Size = New System.Drawing.Size(373, 75)
        Me.btn_Admin.TabIndex = 2
        Me.btn_Admin.Text = "ADMIN"
        Me.btn_Admin.UseVisualStyleBackColor = False
        '
        'btn_SuperAdmin
        '
        Me.btn_SuperAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_SuperAdmin.Font = New System.Drawing.Font("Poppins", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SuperAdmin.ForeColor = System.Drawing.Color.White
        Me.btn_SuperAdmin.Location = New System.Drawing.Point(172, 402)
        Me.btn_SuperAdmin.Name = "btn_SuperAdmin"
        Me.btn_SuperAdmin.Size = New System.Drawing.Size(373, 75)
        Me.btn_SuperAdmin.TabIndex = 1
        Me.btn_SuperAdmin.Text = "SUPER ADMIN"
        Me.btn_SuperAdmin.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Poppins ExtraBold", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(55, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(621, 124)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "USER ACCESS"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = My.Resources.Resources.BG1
        Me.ClientSize = New System.Drawing.Size(1924, 1013)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
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
