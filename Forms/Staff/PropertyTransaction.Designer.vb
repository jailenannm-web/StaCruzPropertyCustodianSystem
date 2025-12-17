<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PropertyTransaction
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
        Me.admin_label_Dashboard = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlTransaction = New System.Windows.Forms.Panel()
        Me.RoundedButton3 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedButton2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.propertyID = New System.Windows.Forms.TextBox()
        Me.propertyName = New System.Windows.Forms.TextBox()
        Me.propertyDescription = New System.Windows.Forms.TextBox()
        Me.propertyQuantity = New System.Windows.Forms.TextBox()
        Me.serialNumber = New System.Windows.Forms.TextBox()
        Me.propertyCategory = New System.Windows.Forms.ComboBox()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.RoundedButton4 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedButton5 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlTransaction.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_Dashboard
        '
        Me.admin_label_Dashboard.AutoSize = True
        Me.admin_label_Dashboard.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_Dashboard.Location = New System.Drawing.Point(821, 74)
        Me.admin_label_Dashboard.Name = "admin_label_Dashboard"
        Me.admin_label_Dashboard.Size = New System.Drawing.Size(391, 58)
        Me.admin_label_Dashboard.TabIndex = 21
        Me.admin_label_Dashboard.Text = "Property Transaction"
        Me.admin_label_Dashboard.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Poppins", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(245, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 50)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Property Information"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Poppins Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(288, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 36)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Property ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Poppins Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(288, 300)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 36)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Property Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Poppins Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 350)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 36)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Description"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Poppins Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(288, 395)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 36)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Available Qty"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Poppins Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1029, 250)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 36)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Category"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Poppins Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1029, 300)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 36)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Serial No"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Font = New System.Drawing.Font("Poppins", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(265, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(290, 50)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Select Transaction"
        '
        'pnlTransaction
        '
        Me.pnlTransaction.Controls.Add(Me.RoundedButton3)
        Me.pnlTransaction.Controls.Add(Me.RoundedButton2)
        Me.pnlTransaction.Controls.Add(Me.RoundedButton1)
        Me.pnlTransaction.Controls.Add(Me.Label14)
        Me.pnlTransaction.Controls.Add(Me.RoundedPanel2)
        Me.pnlTransaction.Location = New System.Drawing.Point(-20, 564)
        Me.pnlTransaction.Name = "pnlTransaction"
        Me.pnlTransaction.Size = New System.Drawing.Size(1927, 473)
        Me.pnlTransaction.TabIndex = 30
        '
        'RoundedButton3
        '
        Me.RoundedButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton3.CornerRadius = 15
        Me.RoundedButton3.Font = New System.Drawing.Font("Poppins Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton3.ForeColor = System.Drawing.Color.Transparent
        Me.RoundedButton3.Location = New System.Drawing.Point(1357, 222)
        Me.RoundedButton3.Name = "RoundedButton3"
        Me.RoundedButton3.Size = New System.Drawing.Size(303, 40)
        Me.RoundedButton3.TabIndex = 2
        Me.RoundedButton3.Text = "Repair Item"
        Me.RoundedButton3.UseVisualStyleBackColor = False
        '
        'RoundedButton2
        '
        Me.RoundedButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton2.CornerRadius = 15
        Me.RoundedButton2.Font = New System.Drawing.Font("Poppins Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton2.ForeColor = System.Drawing.Color.Transparent
        Me.RoundedButton2.Location = New System.Drawing.Point(839, 222)
        Me.RoundedButton2.Name = "RoundedButton2"
        Me.RoundedButton2.Size = New System.Drawing.Size(315, 40)
        Me.RoundedButton2.TabIndex = 1
        Me.RoundedButton2.Text = "Return Item"
        Me.RoundedButton2.UseVisualStyleBackColor = False
        '
        'RoundedButton1
        '
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton1.ForeColor = System.Drawing.Color.Transparent
        Me.RoundedButton1.Location = New System.Drawing.Point(342, 222)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(307, 40)
        Me.RoundedButton1.TabIndex = 0
        Me.RoundedButton1.Text = "Borrow Item"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.White
        Me.RoundedPanel2.CornerRadius = 20
        Me.RoundedPanel2.Location = New System.Drawing.Point(212, 73)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1612, 272)
        Me.RoundedPanel2.TabIndex = 39
        '
        'propertyID
        '
        Me.propertyID.Location = New System.Drawing.Point(487, 257)
        Me.propertyID.Name = "propertyID"
        Me.propertyID.Size = New System.Drawing.Size(488, 22)
        Me.propertyID.TabIndex = 31
        '
        'propertyName
        '
        Me.propertyName.Location = New System.Drawing.Point(487, 300)
        Me.propertyName.Name = "propertyName"
        Me.propertyName.Size = New System.Drawing.Size(488, 22)
        Me.propertyName.TabIndex = 32
        '
        'propertyDescription
        '
        Me.propertyDescription.Location = New System.Drawing.Point(487, 350)
        Me.propertyDescription.Name = "propertyDescription"
        Me.propertyDescription.Size = New System.Drawing.Size(1192, 22)
        Me.propertyDescription.TabIndex = 33
        '
        'propertyQuantity
        '
        Me.propertyQuantity.Location = New System.Drawing.Point(487, 395)
        Me.propertyQuantity.Name = "propertyQuantity"
        Me.propertyQuantity.Size = New System.Drawing.Size(488, 22)
        Me.propertyQuantity.TabIndex = 34
        '
        'serialNumber
        '
        Me.serialNumber.Location = New System.Drawing.Point(1191, 300)
        Me.serialNumber.Name = "serialNumber"
        Me.serialNumber.Size = New System.Drawing.Size(488, 22)
        Me.serialNumber.TabIndex = 36
        '
        'propertyCategory
        '
        Me.propertyCategory.FormattingEnabled = True
        Me.propertyCategory.Location = New System.Drawing.Point(1191, 255)
        Me.propertyCategory.Name = "propertyCategory"
        Me.propertyCategory.Size = New System.Drawing.Size(488, 24)
        Me.propertyCategory.TabIndex = 37
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.Controls.Add(Me.RoundedButton4)
        Me.RoundedPanel1.Controls.Add(Me.RoundedButton5)
        Me.RoundedPanel1.CornerRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(192, 135)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1612, 386)
        Me.RoundedPanel1.TabIndex = 38
        '
        'RoundedButton4
        '
        Me.RoundedButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton4.CornerRadius = 15
        Me.RoundedButton4.Font = New System.Drawing.Font("Poppins Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton4.ForeColor = System.Drawing.Color.Transparent
        Me.RoundedButton4.Location = New System.Drawing.Point(1445, 317)
        Me.RoundedButton4.Name = "RoundedButton4"
        Me.RoundedButton4.Size = New System.Drawing.Size(134, 37)
        Me.RoundedButton4.TabIndex = 58
        Me.RoundedButton4.Text = "Cancel"
        Me.RoundedButton4.UseVisualStyleBackColor = False
        '
        'RoundedButton5
        '
        Me.RoundedButton5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton5.CornerRadius = 15
        Me.RoundedButton5.Font = New System.Drawing.Font("Poppins Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton5.ForeColor = System.Drawing.Color.Transparent
        Me.RoundedButton5.Location = New System.Drawing.Point(1255, 317)
        Me.RoundedButton5.Name = "RoundedButton5"
        Me.RoundedButton5.Size = New System.Drawing.Size(134, 37)
        Me.RoundedButton5.TabIndex = 57
        Me.RoundedButton5.Text = "Confirm"
        Me.RoundedButton5.UseVisualStyleBackColor = False
        '
        'PropertyTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1902, 1033)
        Me.Controls.Add(Me.propertyCategory)
        Me.Controls.Add(Me.serialNumber)
        Me.Controls.Add(Me.propertyQuantity)
        Me.Controls.Add(Me.propertyDescription)
        Me.Controls.Add(Me.propertyName)
        Me.Controls.Add(Me.propertyID)
        Me.Controls.Add(Me.pnlTransaction)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.admin_label_Dashboard)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PropertyTransaction"
        Me.Text = "PropertyTransaction"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTransaction.ResumeLayout(False)
        Me.pnlTransaction.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_Dashboard As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlTransaction As System.Windows.Forms.Panel
    Friend WithEvents RoundedButton1 As Resources.Controls.RoundedButton
    Friend WithEvents RoundedButton3 As Resources.Controls.RoundedButton
    Friend WithEvents RoundedButton2 As Resources.Controls.RoundedButton
    Friend WithEvents propertyID As System.Windows.Forms.TextBox
    Friend WithEvents propertyName As System.Windows.Forms.TextBox
    Friend WithEvents propertyDescription As System.Windows.Forms.TextBox
    Friend WithEvents propertyQuantity As System.Windows.Forms.TextBox
    Friend WithEvents serialNumber As System.Windows.Forms.TextBox
    Friend WithEvents propertyCategory As System.Windows.Forms.ComboBox
    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents RoundedButton4 As Resources.Controls.RoundedButton
    Friend WithEvents RoundedButton5 As Resources.Controls.RoundedButton
End Class
