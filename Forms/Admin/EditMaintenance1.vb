Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' Edit Maintenance Form
''' Allows users to edit existing maintenance records based on the database schema
''' </summary>
Public Class EditMaintenance1
    Inherits UserControl

    Private canModifyMaintenance As Boolean = False
    Private _maintenanceID As Integer = 0

    Public Property MaintenanceID As Integer
        Get
            Return _maintenanceID
        End Get
        Set(value As Integer)
            _maintenanceID = value
            If _maintenanceID > 0 Then
                LoadMaintenanceData()
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub EditMaintenance1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
        If _maintenanceID > 0 Then
            LoadMaintenanceData()
        End If
    End Sub

    Private Sub LoadMaintenanceData()
        Try
            If _maintenanceID <= 0 Then Return
            
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Unable to connect to database.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Not DatabaseConnection.SafeOpenConnection(conn) Then
                MessageBox.Show("Failed to open database connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Setup combo boxes
            SetupComboBoxes()

            Dim query As String = "SELECT m.* " &
                                 "FROM maintenance m " &
                                 "WHERE m.maintenanceId = @maintenanceID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@maintenanceID", _maintenanceID)
                
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Populate form fields (read-only property info)
                        propertyNameTxt.Text = If(IsDBNull(reader("propertyItemName")), "", reader("propertyItemName").ToString())
                        serialNumberTxt.Text = If(IsDBNull(reader("serialNumber")), "", reader("serialNumber").ToString())
                        propertyLocation.Text = If(IsDBNull(reader("location")), "", reader("location").ToString())
                        
                        ' Condition Before
                        If Not IsDBNull(reader("conditionBeforeMaint")) Then
                            conditionStatusCmbo.SelectedItem = reader("conditionBeforeMaint").ToString()
                        End If
                        
                        ' Type of Maintenance
                        If Not IsDBNull(reader("typeOfMaintenance")) Then
                            categoryCmbo.SelectedItem = reader("typeOfMaintenance").ToString()
                        End If
                        
                        ' Assigned Technician
                        assignedEmployeeTxt.Text = If(IsDBNull(reader("assignedTechnician")), "", reader("assignedTechnician").ToString())
                        
                        ' Maintenance Date
                        If Not IsDBNull(reader("maintenanceDate")) Then
                            datePurchasedDate.Value = Convert.ToDateTime(reader("maintenanceDate"))
                        End If
                        
                        ' Maintenance Details
                        supplierTxt.Text = If(IsDBNull(reader("maintenanceDetails")), "", reader("maintenanceDetails").ToString())
                        
                        ' Diagnosis
                        TextBox1.Text = If(IsDBNull(reader("diagnosis")), "", reader("diagnosis").ToString())
                        
                        ' Action Taken
                        TextBox2.Text = If(IsDBNull(reader("actionTaken")), "", reader("actionTaken").ToString())
                        
                        ' Parts Replaced
                        TextBox3.Text = If(IsDBNull(reader("partsReplaced")), "", reader("partsReplaced").ToString())
                        
                        ' Cost
                        If Not IsDBNull(reader("costMaterialsLabor")) Then
                            no_of_employees_numeric.Value = Convert.ToDecimal(reader("costMaterialsLabor"))
                        End If
                        
                        ' Condition After
                        If Not IsDBNull(reader("conditionAfterMaint")) Then
                            ComboBox1.SelectedItem = reader("conditionAfterMaint").ToString()
                        End If
                        
                        ' Status
                        If Not IsDBNull(reader("status")) Then
                            ComboBox2.SelectedItem = reader("status").ToString()
                        End If
                        
                    Else
                        MessageBox.Show("Maintenance record not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        NavigateBack()
                    End If
                End Using
            End Using
            
            If conn.State = ConnectionState.Open Then conn.Close()
            
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("LoadMaintenanceData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub SetupComboBoxes()
        ' Condition Before Maintenance
        If conditionStatusCmbo.Items.Count = 0 Then
            conditionStatusCmbo.Items.AddRange(New Object() {"Good", "Needs Repair", "Damaged"})
        End If
        
        ' Type of Maintenance
        If categoryCmbo.Items.Count = 0 Then
            categoryCmbo.Items.AddRange(New Object() {"Repair", "Replace", "Servicing"})
        End If
        
        ' Condition After Maintenance
        If ComboBox1.Items.Count = 0 Then
            ComboBox1.Items.AddRange(New Object() {"Good", "Needs Further Repair"})
        End If
        
        ' Status
        If ComboBox2.Items.Count = 0 Then
            ComboBox2.Items.AddRange(New Object() {"Completed", "Ongoing", "For Review"})
        End If
    End Sub


    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Check permissions
            If Not EnsureModifyPermission() Then Return
            
            If _maintenanceID <= 0 Then
                MessageBox.Show("No maintenance record selected for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            ' Validate required fields
            If String.IsNullOrWhiteSpace(propertyNameTxt.Text) Then
                MessageBox.Show("Property Item Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                propertyNameTxt.Focus()
                Return
            End If
            
            If categoryCmbo.SelectedIndex < 0 Then
                MessageBox.Show("Type of Maintenance is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                categoryCmbo.Focus()
                Return
            End If

            ' Prepare data for update
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Unable to connect to database.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Not DatabaseConnection.SafeOpenConnection(conn) Then
                MessageBox.Show("Failed to open database connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim query As String = "UPDATE maintenance SET " &
                "conditionBeforeMaint = @conditionBeforeMaint, " &
                "typeOfMaintenance = @typeOfMaintenance, " &
                "assignedTechnician = @assignedTechnician, " &
                "maintenanceDate = @maintenanceDate, " &
                "maintenanceDetails = @maintenanceDetails, " &
                "costMaterialsLabor = @costMaterialsLabor, " &
                "conditionAfterMaint = @conditionAfterMaint, " &
                "status = @status, " &
                "diagnosis = @diagnosis, " &
                "actionTaken = @actionTaken, " &
                "partsReplaced = @partsReplaced, " &
                "updatedAt = NOW() " &
                "WHERE maintenanceId = @maintenanceID"

            Using cmd As New MySqlCommand(query, conn)
                ' Add parameters
                cmd.Parameters.AddWithValue("@maintenanceID", _maintenanceID)
                cmd.Parameters.AddWithValue("@conditionBeforeMaint", If(conditionStatusCmbo.SelectedItem IsNot Nothing, conditionStatusCmbo.SelectedItem.ToString(), "Good"))
                cmd.Parameters.AddWithValue("@typeOfMaintenance", categoryCmbo.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@assignedTechnician", If(String.IsNullOrWhiteSpace(assignedEmployeeTxt.Text), DBNull.Value, CType(assignedEmployeeTxt.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@maintenanceDate", datePurchasedDate.Value.Date)
                cmd.Parameters.AddWithValue("@maintenanceDetails", If(String.IsNullOrWhiteSpace(supplierTxt.Text), DBNull.Value, CType(supplierTxt.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@costMaterialsLabor", no_of_employees_numeric.Value)
                cmd.Parameters.AddWithValue("@conditionAfterMaint", If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedItem.ToString(), DBNull.Value))
                cmd.Parameters.AddWithValue("@status", If(ComboBox2.SelectedItem IsNot Nothing, ComboBox2.SelectedItem.ToString(), "Ongoing"))
                cmd.Parameters.AddWithValue("@diagnosis", If(String.IsNullOrWhiteSpace(TextBox1.Text), DBNull.Value, CType(TextBox1.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@actionTaken", If(String.IsNullOrWhiteSpace(TextBox2.Text), DBNull.Value, CType(TextBox2.Text.Trim(), Object)))
                cmd.Parameters.AddWithValue("@partsReplaced", If(String.IsNullOrWhiteSpace(TextBox3.Text), DBNull.Value, CType(TextBox3.Text.Trim(), Object)))

                ' Execute update
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                
                If rowsAffected > 0 Then
                    MessageBox.Show("Maintenance record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    
                    ' Audit logging can be added later if needed
                    
                    ' Navigate back
                    NavigateBack()
                Else
                    MessageBox.Show("Failed to update maintenance record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            
            If conn.State = ConnectionState.Open Then conn.Close()
            
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("EditMaintenance1 SQL Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        Catch ex As Exception
            MessageBox.Show("Error saving maintenance: " & ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("EditMaintenance1 btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_MaintenanceManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        ' No restrictions for Super Admin, Admin, and Custodian
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If hasFullAccess Then
            Return True
        End If
        ' For other roles, check permission
        canModifyMaintenance = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyMaintenance)
        If Not canModifyMaintenance Then
            MessageBox.Show("You have view-only access to Maintenance Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class

