Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

''' <summary>
''' Professional dialog for assigning a technician to maintenance requests with dropdown selection
''' </summary>
Public Class AssignTechnicianDialog
    Inherits Form

    Private lblTitle As Label
    Private lblInstruction As Label
    Private lblTechnician As Label
    Private cboTechnician As ComboBox
    Private lblDepartment As Label
    Private txtDepartment As TextBox
    Private lblTargetDate As Label
    Private dtpTargetDate As DateTimePicker
    Private btnAssign As Button
    Private btnCancel As Button
    Private pnlHeader As Panel
    Private pnlContent As Panel
    Private technicianData As DataTable

    ''' <summary>
    ''' Get the selected technician's full name
    ''' </summary>
    Public Property TechnicianName As String
        Get
            If cboTechnician.SelectedIndex >= 0 AndAlso technicianData IsNot Nothing AndAlso technicianData.Rows.Count > 0 Then
                Dim selectedRow As DataRow = technicianData.Rows(cboTechnician.SelectedIndex)
                Return selectedRow("fullName").ToString()
            End If
            Return ""
        End Get
        Set(value As String)
            ' Find and select the technician by name
            If technicianData IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(value) Then
                For i As Integer = 0 To technicianData.Rows.Count - 1
                    If technicianData.Rows(i)("fullName").ToString().Equals(value, StringComparison.OrdinalIgnoreCase) Then
                        cboTechnician.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
        End Set
    End Property

    ''' <summary>
    ''' Get the selected technician's user ID
    ''' </summary>
    Public ReadOnly Property SelectedTechnicianId As Integer?
        Get
            If cboTechnician.SelectedIndex >= 0 AndAlso technicianData IsNot Nothing AndAlso technicianData.Rows.Count > 0 Then
                Dim selectedRow As DataRow = technicianData.Rows(cboTechnician.SelectedIndex)
                Return Convert.ToInt32(selectedRow("userId"))
            End If
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Get or set the target date for maintenance
    ''' </summary>
    Public Property TargetDate As Date
        Get
            Return dtpTargetDate.Value
        End Get
        Set(value As Date)
            dtpTargetDate.Value = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        LoadTechnicians()
    End Sub

    Private Sub InitializeComponent()
        ' Form settings
        Me.Text = "Assign Technician"
        Me.Size = New Size(500, 380)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(44, 62, 80)  ' Match dialog background

        ' Title
        lblTitle = New Label()
        lblTitle.Text = "Assign Technician"
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 20)
        lblTitle.AutoSize = True
        Me.Controls.Add(lblTitle)

        ' Instruction
        lblInstruction = New Label()
        lblInstruction.Text = "Select a technician from the list below to assign to this maintenance request"
        lblInstruction.Font = New Font("Segoe UI", 9)
        lblInstruction.ForeColor = Color.FromArgb(189, 195, 199)
        lblInstruction.Location = New Point(20, 55)
        lblInstruction.Size = New Size(450, 30)
        Me.Controls.Add(lblInstruction)

        ' Technician Label
        lblTechnician = New Label()
        lblTechnician.Text = "Select Technician:"
        lblTechnician.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTechnician.ForeColor = Color.White
        lblTechnician.Location = New Point(20, 100)
        lblTechnician.AutoSize = True
        Me.Controls.Add(lblTechnician)

        ' Technician ComboBox - THE DROPDOWN!
        cboTechnician = New ComboBox()
        cboTechnician.Font = New Font("Segoe UI", 11)
        cboTechnician.Location = New Point(20, 125)
        cboTechnician.Size = New Size(450, 30)
        cboTechnician.DropDownStyle = ComboBoxStyle.DropDownList
        cboTechnician.BackColor = Color.White
        AddHandler cboTechnician.SelectedIndexChanged, AddressOf CboTechnician_SelectedIndexChanged
        Me.Controls.Add(cboTechnician)

        ' Department Label
        lblDepartment = New Label()
        lblDepartment.Text = "Department & Position:"
        lblDepartment.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblDepartment.ForeColor = Color.FromArgb(189, 195, 199)
        lblDepartment.Location = New Point(20, 165)
        lblDepartment.AutoSize = True
        Me.Controls.Add(lblDepartment)

        ' Department TextBox (Read-only info display)
        txtDepartment = New TextBox()
        txtDepartment.Font = New Font("Segoe UI", 9)
        txtDepartment.Location = New Point(20, 185)
        txtDepartment.Size = New Size(450, 25)
        txtDepartment.ReadOnly = True
        txtDepartment.BackColor = Color.FromArgb(52, 73, 94)
        txtDepartment.ForeColor = Color.White
        txtDepartment.BorderStyle = BorderStyle.FixedSingle
        txtDepartment.Text = "Select a technician to view details"
        Me.Controls.Add(txtDepartment)

        ' Target Date Label
        lblTargetDate = New Label()
        lblTargetDate.Text = "Target Completion Date:"
        lblTargetDate.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTargetDate.ForeColor = Color.White
        lblTargetDate.Location = New Point(20, 220)
        lblTargetDate.AutoSize = True
        Me.Controls.Add(lblTargetDate)

        ' Target Date Picker
        dtpTargetDate = New DateTimePicker()
        dtpTargetDate.Font = New Font("Segoe UI", 11)
        dtpTargetDate.Location = New Point(20, 245)
        dtpTargetDate.Size = New Size(450, 30)
        dtpTargetDate.Format = DateTimePickerFormat.Short
        dtpTargetDate.MinDate = DateTime.Now
        dtpTargetDate.Value = DateTime.Now.AddDays(7) ' Default to 1 week from now
        Me.Controls.Add(dtpTargetDate)

        ' Assign Button
        btnAssign = New Button()
        btnAssign.Text = "Assign"
        btnAssign.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnAssign.Size = New Size(200, 40)
        btnAssign.Location = New Point(270, 295)
        btnAssign.BackColor = Color.FromArgb(46, 204, 113)  ' Green
        btnAssign.ForeColor = Color.White
        btnAssign.FlatStyle = FlatStyle.Flat
        btnAssign.FlatAppearance.BorderSize = 0
        btnAssign.Cursor = Cursors.Hand
        AddHandler btnAssign.Click, AddressOf BtnAssign_Click
        AddHandler btnAssign.MouseEnter, Sub() btnAssign.BackColor = Color.FromArgb(39, 174, 96)
        AddHandler btnAssign.MouseLeave, Sub() btnAssign.BackColor = Color.FromArgb(46, 204, 113)
        Me.Controls.Add(btnAssign)

        ' Cancel Button
        btnCancel = New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Segoe UI", 10)
        btnCancel.Size = New Size(200, 40)
        btnCancel.Location = New Point(20, 295)
        btnCancel.BackColor = Color.FromArgb(149, 165, 166)  ' Gray
        btnCancel.ForeColor = Color.White
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.Cursor = Cursors.Hand
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click
        AddHandler btnCancel.MouseEnter, Sub() btnCancel.BackColor = Color.FromArgb(127, 140, 141)
        AddHandler btnCancel.MouseLeave, Sub() btnCancel.BackColor = Color.FromArgb(149, 165, 166)
        Me.Controls.Add(btnCancel)

        ' Set tab order
        cboTechnician.TabIndex = 0
        dtpTargetDate.TabIndex = 1
        btnAssign.TabIndex = 2
        btnCancel.TabIndex = 3

        ' Accept button
        Me.AcceptButton = btnAssign
        Me.CancelButton = btnCancel

        ' Focus on combobox when shown
        AddHandler Me.Shown, Sub() cboTechnician.Focus()
    End Sub

    ''' <summary>
    ''' Load hardcoded technicians into dropdown
    ''' </summary>
    Private Sub LoadTechnicians()
        Try
            ' Create a DataTable to store hardcoded technician data
            technicianData = New DataTable()
            technicianData.Columns.Add("technicianNumber", GetType(String))
            technicianData.Columns.Add("fullName", GetType(String))
            technicianData.Columns.Add("displayText", GetType(String))
            technicianData.Columns.Add("position", GetType(String))
            technicianData.Columns.Add("departmentName", GetType(String))
            
            ' ============================================================
            ' HARDCODED TECHNICIANS - Add or modify technicians here
            ' ============================================================
            technicianData.Rows.Add("Technician 1", "Maricel Jheck", "Maricel Jheck (Technician 1)", "Maintenance Technician", "Maintenance Department")
            technicianData.Rows.Add("Technician 2", "John Santos", "John Santos (Technician 2)", "Maintenance Technician", "Maintenance Department")
            technicianData.Rows.Add("Technician 3", "Maria Cruz", "Maria Cruz (Technician 3)", "Senior Technician", "Maintenance Department")
            technicianData.Rows.Add("Technician 4", "Robert Garcia", "Robert Garcia (Technician 4)", "Maintenance Technician", "Maintenance Department")
            technicianData.Rows.Add("Technician 5", "Anna Reyes", "Anna Reyes (Technician 5)", "Lead Technician", "Maintenance Department")
            ' Add more technicians as needed following the same format:
            ' technicianData.Rows.Add("Technician #", "Full Name", "Display Name (Technician #)", "Position", "Department")
            
            ' Clear and populate the dropdown
            cboTechnician.Items.Clear()
            
            For Each row As DataRow In technicianData.Rows
                cboTechnician.Items.Add(row("displayText").ToString())
            Next
            
            ' Select first technician by default
            If cboTechnician.Items.Count > 0 Then
                cboTechnician.SelectedIndex = 0
            End If
            
        Catch ex As Exception
            MessageBox.Show("Error loading technicians: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboTechnician.Items.Add("Error loading technicians")
            cboTechnician.Enabled = False
            btnAssign.Enabled = False
        End Try
    End Sub

    ''' <summary>
    ''' Update department info when technician selection changes
    ''' </summary>
    Private Sub CboTechnician_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cboTechnician.SelectedIndex >= 0 AndAlso technicianData IsNot Nothing AndAlso cboTechnician.SelectedIndex < technicianData.Rows.Count Then
            Dim selectedRow As DataRow = technicianData.Rows(cboTechnician.SelectedIndex)
            
            Dim position As String = If(IsDBNull(selectedRow("position")), "No Position", selectedRow("position").ToString())
            Dim department As String = If(IsDBNull(selectedRow("departmentName")), "No Department", selectedRow("departmentName").ToString())
            
            txtDepartment.Text = department & " - " & position
        Else
            txtDepartment.Text = "Select a technician to view details"
        End If
    End Sub

    Private Sub BtnAssign_Click(sender As Object, e As EventArgs)
        If cboTechnician.SelectedIndex < 0 Then
            MessageBox.Show("Please select a technician from the list.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTechnician.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TechnicianName) Then
            MessageBox.Show("Please select a valid technician.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTechnician.Focus()
            Return
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
