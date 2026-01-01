Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

Public Class AssignTechnician
    Inherits Form

    Private _maintenanceID As Integer = 0
    Private _maintenanceData As DataRow = Nothing

    Public Property MaintenanceID As Integer
        Get
            Return _maintenanceID
        End Get
        Set(value As Integer)
            _maintenanceID = value
            LoadMaintenanceData()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        LoadTechnicianDropdown()
    End Sub

    Private Sub LoadTechnicianDropdown()
        Try
            If technicianComboBox IsNot Nothing Then
                technicianComboBox.Items.Clear()
                ' Hardcoded technician list (minimum 5)
                technicianComboBox.Items.Add("Technician 1")
                technicianComboBox.Items.Add("Technician 2")
                technicianComboBox.Items.Add("Technician 3")
                technicianComboBox.Items.Add("Technician 4")
                technicianComboBox.Items.Add("Technician 5")
                technicianComboBox.SelectedIndex = -1
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("AssignTechnician LoadTechnicianDropdown Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMaintenanceData()
        Try
            If _maintenanceID <= 0 Then Return

            Dim dt As DataTable = modDB.GetAllMaintenance()
            For Each row As DataRow In dt.Rows
                Dim rowID As Integer = 0
                If dt.Columns.Contains("maintenanceId") AndAlso Not IsDBNull(row("maintenanceId")) Then
                    rowID = Convert.ToInt32(row("maintenanceId"))
                End If

                If rowID = _maintenanceID Then
                    _maintenanceData = row
                    ' Display maintenance record details (read-only)
                    If maintenanceIDLabel IsNot Nothing Then
                        maintenanceIDLabel.Text = "Maintenance ID: " & _maintenanceID.ToString()
                    End If
                    If propertyItemNameLabel IsNot Nothing Then
                        propertyItemNameLabel.Text = "Property Item Name: " & If(dt.Columns.Contains("propertyItemName") AndAlso Not IsDBNull(row("propertyItemName")), row("propertyItemName").ToString(), "N/A")
                    End If
                    If locationLabel IsNot Nothing Then
                        locationLabel.Text = "Location: " & If(dt.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "N/A")
                    End If
                    If typeOfMaintenanceLabel IsNot Nothing Then
                        typeOfMaintenanceLabel.Text = "Type of Maintenance: " & If(dt.Columns.Contains("typeOfMaintenance") AndAlso Not IsDBNull(row("typeOfMaintenance")), row("typeOfMaintenance").ToString(), "N/A")
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        Try
            If technicianComboBox Is Nothing OrElse technicianComboBox.SelectedIndex < 0 Then
                MessageBox.Show("Please select a technician.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedTechnician As String = technicianComboBox.SelectedItem.ToString()

            If _maintenanceID <= 0 Then
                MessageBox.Show("Invalid maintenance record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Get current maintenance data
            Dim serviceDate As Date = Date.Today
            Dim serviceType As String = "Repair"
            Dim description As String = ""
            Dim cost As Decimal = 0
            Dim currentStatus As String = "Ongoing"

            If _maintenanceData IsNot Nothing Then
                If _maintenanceData.Table.Columns.Contains("maintenanceDate") AndAlso Not IsDBNull(_maintenanceData("maintenanceDate")) Then
                    serviceDate = Convert.ToDateTime(_maintenanceData("maintenanceDate"))
                End If
                If _maintenanceData.Table.Columns.Contains("typeOfMaintenance") AndAlso Not IsDBNull(_maintenanceData("typeOfMaintenance")) Then
                    serviceType = _maintenanceData("typeOfMaintenance").ToString()
                End If
                If _maintenanceData.Table.Columns.Contains("maintenanceDetails") AndAlso Not IsDBNull(_maintenanceData("maintenanceDetails")) Then
                    description = _maintenanceData("maintenanceDetails").ToString()
                End If
                If _maintenanceData.Table.Columns.Contains("costMaterialsLabor") AndAlso Not IsDBNull(_maintenanceData("costMaterialsLabor")) Then
                    Decimal.TryParse(_maintenanceData("costMaterialsLabor").ToString(), cost)
                End If
                If _maintenanceData.Table.Columns.Contains("status") AndAlso Not IsDBNull(_maintenanceData("status")) Then
                    currentStatus = _maintenanceData("status").ToString()
                End If
            End If

            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            ' Update maintenance record with assigned technician
            If modDB.UpdateMaintenanceEntry(_maintenanceID, serviceDate, serviceType, description, "", "", cost, Nothing, selectedTechnician, "Assigned", "", 0, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole) Then
                MessageBox.Show("Technician assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to assign technician. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error assigning technician: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AssignTechnician btnAssign_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    ' Designer-generated controls
    Private maintenanceIDLabel As Label
    Private propertyItemNameLabel As Label
    Private locationLabel As Label
    Private typeOfMaintenanceLabel As Label
    Private technicianComboBox As ComboBox
    Private technicianLabel As Label
    Private WithEvents btnAssign As Button
    Private WithEvents btnCancel As Button

    Private Sub InitializeComponent()
        Me.maintenanceIDLabel = New Label()
        Me.propertyItemNameLabel = New Label()
        Me.locationLabel = New Label()
        Me.typeOfMaintenanceLabel = New Label()
        Me.technicianLabel = New Label()
        Me.technicianComboBox = New ComboBox()
        Me.btnAssign = New Button()
        Me.btnCancel = New Button()
        Me.SuspendLayout()

        ' maintenanceIDLabel
        Me.maintenanceIDLabel.AutoSize = True
        Me.maintenanceIDLabel.Location = New System.Drawing.Point(20, 20)
        Me.maintenanceIDLabel.Name = "maintenanceIDLabel"
        Me.maintenanceIDLabel.Size = New System.Drawing.Size(200, 20)
        Me.maintenanceIDLabel.Text = "Maintenance ID:"

        ' propertyItemNameLabel
        Me.propertyItemNameLabel.AutoSize = True
        Me.propertyItemNameLabel.Location = New System.Drawing.Point(20, 50)
        Me.propertyItemNameLabel.Name = "propertyItemNameLabel"
        Me.propertyItemNameLabel.Size = New System.Drawing.Size(200, 20)
        Me.propertyItemNameLabel.Text = "Property Item Name:"

        ' locationLabel
        Me.locationLabel.AutoSize = True
        Me.locationLabel.Location = New System.Drawing.Point(20, 80)
        Me.locationLabel.Name = "locationLabel"
        Me.locationLabel.Size = New System.Drawing.Size(200, 20)
        Me.locationLabel.Text = "Location:"

        ' typeOfMaintenanceLabel
        Me.typeOfMaintenanceLabel.AutoSize = True
        Me.typeOfMaintenanceLabel.Location = New System.Drawing.Point(20, 110)
        Me.typeOfMaintenanceLabel.Name = "typeOfMaintenanceLabel"
        Me.typeOfMaintenanceLabel.Size = New System.Drawing.Size(200, 20)
        Me.typeOfMaintenanceLabel.Text = "Type of Maintenance:"

        ' technicianLabel
        Me.technicianLabel.AutoSize = True
        Me.technicianLabel.Location = New System.Drawing.Point(20, 150)
        Me.technicianLabel.Name = "technicianLabel"
        Me.technicianLabel.Size = New System.Drawing.Size(150, 20)
        Me.technicianLabel.Text = "Select Technician:"

        ' technicianComboBox
        Me.technicianComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        Me.technicianComboBox.FormattingEnabled = True
        Me.technicianComboBox.Location = New System.Drawing.Point(180, 147)
        Me.technicianComboBox.Name = "technicianComboBox"
        Me.technicianComboBox.Size = New System.Drawing.Size(250, 28)
        Me.technicianComboBox.TabIndex = 1

        ' btnAssign
        Me.btnAssign.Location = New System.Drawing.Point(300, 200)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(100, 35)
        Me.btnAssign.TabIndex = 2
        Me.btnAssign.Text = "Assign"
        Me.btnAssign.UseVisualStyleBackColor = True

        ' btnCancel
        Me.btnCancel.Location = New System.Drawing.Point(190, 200)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 35)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True

        ' AssignTechnician
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 260)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.technicianComboBox)
        Me.Controls.Add(Me.technicianLabel)
        Me.Controls.Add(Me.typeOfMaintenanceLabel)
        Me.Controls.Add(Me.locationLabel)
        Me.Controls.Add(Me.propertyItemNameLabel)
        Me.Controls.Add(Me.maintenanceIDLabel)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AssignTechnician"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Assign Technician"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class

