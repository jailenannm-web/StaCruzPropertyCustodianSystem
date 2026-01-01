Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' Add Maintenance Form
''' Allows users to create new maintenance records based on the database schema
''' </summary>
Public Class AddMaintenance
    Inherits UserControl

    ' ================================================================
    ' CONSTRUCTOR
    ' ================================================================
    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' ================================================================
    ' LOAD EVENT
    ' ================================================================
    Private Sub AddMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load property items from database
            LoadPropertyItems()
            
            ' Load technicians
            LoadTechnicians()
            
            ' Set default values
            dtpMaintenanceDate.Value = DateTime.Now
            cmbConditionBefore.SelectedIndex = 0 ' Good
            cmbTypeOfMaintenance.SelectedIndex = 0 ' Repair
            cmbStatus.SelectedIndex = 1 ' Ongoing (hidden by default)
            txtCost.Text = "0.00"
            
        Catch ex As Exception
            MessageBox.Show("Error initializing form: " & ex.Message, "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' LOAD PROPERTY ITEMS
    ' ================================================================
    Private Sub LoadPropertyItems()
        Try
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                Dim query As String = "SELECT propertyId, itemName, serialNumber, location, departmentId FROM properties WHERE status = 'Active' ORDER BY itemName"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)
                        
                        cmbPropertyItem.DataSource = dt
                        cmbPropertyItem.DisplayMember = "itemName"
                        cmbPropertyItem.ValueMember = "propertyId"
                        cmbPropertyItem.SelectedIndex = -1
                    End Using
                End Using
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading property items: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' LOAD TECHNICIANS
    ' ================================================================
    Private Sub LoadTechnicians()
        Try
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                Dim query As String = "SELECT userId, CONCAT(firstName, ' ', lastName) AS fullName FROM users WHERE status = 'Active' AND role IN ('Admin', 'SuperAdmin') ORDER BY firstName"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)
                        
                        cmbAssignedTechnician.DataSource = dt
                        cmbAssignedTechnician.DisplayMember = "fullName"
                        cmbAssignedTechnician.ValueMember = "fullName"
                        cmbAssignedTechnician.SelectedIndex = -1
                    End Using
                End Using
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading technicians: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' PROPERTY ITEM SELECTION CHANGED - Auto-fill related fields
    ' ================================================================
    Private Sub cmbPropertyItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPropertyItem.SelectedIndexChanged
        Try
            If cmbPropertyItem.SelectedIndex >= 0 Then
                Dim dt As DataTable = CType(cmbPropertyItem.DataSource, DataTable)
                Dim row As DataRow = dt.Rows(cmbPropertyItem.SelectedIndex)
                
                ' Auto-fill serial number
                If Not IsDBNull(row("serialNumber")) Then
                    txtSerialNumber.Text = row("serialNumber").ToString()
                Else
                    txtSerialNumber.Text = ""
                End If
                
                ' Auto-fill location
                If Not IsDBNull(row("location")) Then
                    txtLocation.Text = row("location").ToString()
                Else
                    txtLocation.Text = ""
                End If
                
                ' Auto-select department (hidden)
                If Not IsDBNull(row("departmentId")) Then
                    cmbDepartment.SelectedValue = row("departmentId")
                End If
            Else
                txtSerialNumber.Text = ""
                txtLocation.Text = ""
            End If
        Catch ex As Exception
            ' Ignore errors during selection change
        End Try
    End Sub

    ' ================================================================
    ' SAVE BUTTON CLICK
    ' ================================================================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validate required fields
            If cmbPropertyItem.SelectedIndex < 0 Then
                MessageBox.Show("Property Item Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPropertyItem.Focus()
                Return
            End If
            
            If cmbTypeOfMaintenance.SelectedIndex < 0 Then
                MessageBox.Show("Type of Maintenance is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbTypeOfMaintenance.Focus()
                Return
            End If
            
            ' Get the property item name from the selected property
            Dim propertyItemName As String = cmbPropertyItem.Text

            ' Prepare data for insertion
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Unable to connect to database.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Not modDB.SafeOpenConnection(conn) Then
                MessageBox.Show("Failed to open database connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim query As String = "INSERT INTO maintenance (" &
                "requestId, propertyItemName, serialNumber, location, departmentId, " &
                "conditionBeforeMaint, typeOfMaintenance, assignedTechnician, maintenanceDate, " &
                "maintenanceDetails, costMaterialsLabor, conditionAfterMaint, status, " &
                "diagnosis, actionTaken, partsReplaced, createdAt, updatedAt" &
                ") VALUES (" &
                "@requestId, @propertyItemName, @serialNumber, @location, @departmentId, " &
                "@conditionBeforeMaint, @typeOfMaintenance, @assignedTechnician, @maintenanceDate, " &
                "@maintenanceDetails, @costMaterialsLabor, @conditionAfterMaint, @status, " &
                "@diagnosis, @actionTaken, @partsReplaced, NOW(), NOW()" &
                ")"

            Using cmd As New MySqlCommand(query, conn)
                ' Add parameters
                cmd.Parameters.AddWithValue("@requestId", DBNull.Value) ' Request ID removed from form
                cmd.Parameters.AddWithValue("@propertyItemName", propertyItemName)
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrWhiteSpace(txtSerialNumber.Text), DBNull.Value, CType(txtSerialNumber.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@location", If(String.IsNullOrWhiteSpace(txtLocation.Text), DBNull.Value, CType(txtLocation.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@departmentId", If(cmbDepartment.SelectedValue Is Nothing, DBNull.Value, cmbDepartment.SelectedValue))
                cmd.Parameters.AddWithValue("@conditionBeforeMaint", If(cmbConditionBefore.SelectedItem IsNot Nothing, cmbConditionBefore.SelectedItem.ToString(), "Good"))
                cmd.Parameters.AddWithValue("@typeOfMaintenance", cmbTypeOfMaintenance.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@assignedTechnician", If(cmbAssignedTechnician.SelectedIndex >= 0, cmbAssignedTechnician.Text, DBNull.Value))
                cmd.Parameters.AddWithValue("@maintenanceDate", dtpMaintenanceDate.Value.Date)
                cmd.Parameters.AddWithValue("@maintenanceDetails", If(String.IsNullOrWhiteSpace(txtMaintenanceDetails.Text), DBNull.Value, CType(txtMaintenanceDetails.Text.Trim(), Object)))
                
                ' Parse cost
                Dim cost As Decimal = 0D
                Decimal.TryParse(txtCost.Text, cost)
                cmd.Parameters.AddWithValue("@costMaterialsLabor", cost)
                
                cmd.Parameters.AddWithValue("@conditionAfterMaint", If(cmbConditionAfter.SelectedIndex >= 0, cmbConditionAfter.SelectedItem.ToString(), DBNull.Value))
                cmd.Parameters.AddWithValue("@status", If(cmbStatus.SelectedIndex >= 0, cmbStatus.SelectedItem.ToString(), "Ongoing"))
                cmd.Parameters.AddWithValue("@diagnosis", If(String.IsNullOrWhiteSpace(txtDiagnosis.Text), DBNull.Value, CType(txtDiagnosis.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@actionTaken", If(String.IsNullOrWhiteSpace(txtActionTaken.Text), DBNull.Value, CType(txtActionTaken.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@partsReplaced", If(String.IsNullOrWhiteSpace(txtPartsReplaced.Text), DBNull.Value, CType(txtPartsReplaced.Text.Trim(), Object)))

                ' Execute insert
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                
                If rowsAffected > 0 Then
                    MessageBox.Show("Maintenance record created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    
                    ' Audit logging can be added later if needed
                    
                    ' Navigate back
                    NavigateBack()
                Else
                    MessageBox.Show("Failed to create maintenance record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            
            If conn.State = ConnectionState.Open Then conn.Close()

        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AddMaintenance SQL Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        Catch ex As Exception
            MessageBox.Show("Error saving maintenance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AddMaintenance Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    ' ================================================================
    ' CANCEL BUTTON CLICK
    ' ================================================================
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    ' ================================================================
    ' NAVIGATION
    ' ================================================================
    Private Sub NavigateBack()
        Try
            Dim adminDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If adminDashboard IsNot Nothing Then
                adminDashboard.LoadUserControl(New UC_MaintenanceManagement())
                Return
            End If
            
            Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
            If saDashboard IsNot Nothing Then
                saDashboard.LoadUserControl(New UC_MaintenanceManagement())
                Return
            End If
            
            ' Fallback
            Me.Parent?.Controls.Remove(Me)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Navigation error: " & ex.Message)
        End Try
    End Sub

End Class
