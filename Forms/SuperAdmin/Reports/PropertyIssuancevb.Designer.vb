<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class txb_Name
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
        Me.Name = New System.Windows.Forms.Label()
        Me.txb_Department = New System.Windows.Forms.TextBox()
        Me.fundCluster = New System.Windows.Forms.Label()
        Me.EmployeeNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PropertyNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sign = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateInssuance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtname = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Name
        '
        Me.Name.AutoSize = True
        Me.Name.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name.Location = New System.Drawing.Point(381, 221)
        Me.Name.Name = "Name"
        Me.Name.Size = New System.Drawing.Size(47, 22)
        Me.Name.TabIndex = 38
        Me.Name.Text = "Name"
        Me.Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txb_Department
        '
        Me.txb_Department.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txb_Department.Location = New System.Drawing.Point(862, 219)
        Me.txb_Department.Name = "txb_Department"
        Me.txb_Department.Size = New System.Drawing.Size(198, 22)
        Me.txb_Department.TabIndex = 45
        '
        'fundCluster
        '
        Me.fundCluster.AutoSize = True
        Me.fundCluster.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fundCluster.Location = New System.Drawing.Point(771, 221)
        Me.fundCluster.Name = "fundCluster"
        Me.fundCluster.Size = New System.Drawing.Size(85, 22)
        Me.fundCluster.TabIndex = 39
        Me.fundCluster.Text = "Department"
        Me.fundCluster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EmployeeNo
        '
        Me.EmployeeNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmployeeNo.Location = New System.Drawing.Point(1112, 218)
        Me.EmployeeNo.Name = "EmployeeNo"
        Me.EmployeeNo.Size = New System.Drawing.Size(119, 22)
        Me.EmployeeNo.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1066, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 22)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Emplyee No."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertyNo, Me.Sign, Me.DateInssuance})
        Me.DataGridView1.Location = New System.Drawing.Point(449, 267)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(744, 601)
        Me.DataGridView1.TabIndex = 53
        '
        'PropertyNo
        '
        Me.PropertyNo.HeaderText = "Property"
        Me.PropertyNo.MinimumWidth = 6
        Me.PropertyNo.Name = "PropertyNo"
        Me.PropertyNo.Width = 125
        '
        'Sign
        '
        Me.Sign.HeaderText = "Sign"
        Me.Sign.MinimumWidth = 6
        Me.Sign.Name = "Sign"
        Me.Sign.Width = 125
        '
        'DateInssuance
        '
        Me.DateInssuance.HeaderText = "Date Essuance"
        Me.DateInssuance.MinimumWidth = 6
        Me.DateInssuance.Name = "DateInssuance"
        Me.DateInssuance.Width = 125
        '
        'txtname
        '
        Me.txtname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtname.Location = New System.Drawing.Point(434, 221)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(331, 22)
        Me.txtname.TabIndex = 55
        '
        'txb_Name
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1569, 942)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EmployeeNo)
        Me.Controls.Add(Me.txb_Department)
        Me.Controls.Add(Me.fundCluster)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "txtname"
        Me.Text = "PropertyIssuance.vb"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Name As System.Windows.Forms.Label
    Friend WithEvents txb_Department As System.Windows.Forms.TextBox
    Friend WithEvents fundCluster As System.Windows.Forms.Label
    Friend WithEvents EmployeeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PropertyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sign As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateInssuance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtname As System.Windows.Forms.TextBox
End Class
