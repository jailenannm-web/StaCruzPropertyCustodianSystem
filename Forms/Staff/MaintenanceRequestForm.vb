Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient

''' <summary>
''' Professional Maintenance Request Form
''' Allows staff to submit maintenance requests for properties they have borrowed
''' Matches the maintenance_requests table schema
''' </summary>
Public Class MaintenanceRequestForm
    Inherits System.Windows.Forms.UserControl
    
    Private prefilledPropertyId As Integer? = Nothing
    
    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub
    
    Private Sub MaintenanceRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
    End Sub
    
    ''' <summary>
    ''' Initialize form controls and load data
    ''' </summary>
    Private Sub InitializeForm()
        Try
            ' Set date requested to today (read-only)
            dtpDateRequested.Value = Date.Today
            dtpDateRequested.Enabled = False
            
            ' Set target date to 7 days from now
            dtpTargetDate.Value = Date.Today.AddDays(7)
            dtpTargetDate.MinDate = Date.Today
            
            ' Load departments
            LoadDepartments()
            
            ' Load condition before options
            cboConditionBefore.Items.Clear()
            cboConditionBefore.Items.AddRange(New String() {"Good", "Needs Repair", "Damaged"})
            cboConditionBefore.SelectedIndex = 1 ' Default to "Needs Repair"
            
            ' Load type of issue options
            cboTypeOfIssue.Items.Clear()
            cboTypeOfIssue.Items.AddRange(New String() {"Repair", "Replace", "Servicing"})
            cboTypeOfIssue.SelectedIndex = 0 ' Default to "Repair"
            
            ' Load properties (only items the user has borrowed)
            LoadBorrowedProperties()
            
            ' Set requesting user info
            If SessionContext.CurrentUserID.HasValue Then
                lblRequestedBy.Text = $"Requested By: {SessionContext.CurrentFullName}"
            End If
            
        Catch ex As Exception
            MessageBox.Show("Error initializing form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ''' <summary>
    ''' Load departments into combo box
    ''' </summary>
    Private Sub LoadDepartments()
        Try
            cboDepartment.Items.Clear()
            cboDepartment.Items.Add(New KeyValuePair(Of Integer, String)(-1, "-- Select Department --"))
            
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                Dim query As String = "SELECT departmentId, departmentName FROM departments WHERE status = 'Active' ORDER BY departmentName"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboDepartment.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("departmentId"),
                                reader.GetString("departmentName")
                            ))
                        End While
                    End Using
                End Using
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            
            cboDepartment.DisplayMember = "Value"
            cboDepartment.ValueMember = "Key"
            cboDepartment.SelectedIndex = 0
            
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ''' <summary>
    ''' Load properties that the user has borrowed
    ''' </summary>
    Private Sub LoadBorrowedProperties()
        Try
            cboItemName.Items.Clear()
            cboItemName.Items.Add(New With {.PropertyId = -1, .DisplayText = "-- Select Property or Enter Manually --"})
            
            If Not SessionContext.CurrentUserID.HasValue Then Return
            
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                ' Get properties from borrowed_items for current user
                Dim query As String = "SELECT DISTINCT p.propertyId, p.itemName, p.propertyNumber, p.serialNumber, p.departmentId, p.location, p.condition " &
                                     "FROM borrowed_items bi " &
                                     "INNER JOIN properties p ON bi.itemId = p.propertyId AND bi.itemType = 'property' " &
                                     "WHERE bi.status = 'Borrowed' " &
                                     "AND (bi.borrowerName LIKE CONCAT((SELECT firstName FROM users WHERE userId = @userId), '%') " &
                                     "   OR bi.borrowerName = (SELECT CONCAT(firstName, ' ', lastName) FROM users WHERE userId = @userId) " &
                                     "   OR bi.borrowerName = (SELECT fullName FROM users WHERE userId = @userId)) " &
                                     "ORDER BY p.itemName"
                
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", SessionContext.CurrentUserID.Value)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim displayText As String = reader.GetString("itemName")
                            If Not reader.IsDBNull(reader.GetOrdinal("propertyNumber")) Then
                                displayText &= " (" & reader.GetString("propertyNumber") & ")"
                            End If
                            
                            cboItemName.Items.Add(New With {
                                .PropertyId = reader.GetInt32("propertyId"),
                                .DisplayText = displayText,
                                .ItemName = reader.GetString("itemName"),
                                .PropertyNumber = If(reader.IsDBNull(reader.GetOrdinal("propertyNumber")), "", reader.GetString("propertyNumber")),
                                .SerialNumber = If(reader.IsDBNull(reader.GetOrdinal("serialNumber")), "", reader.GetString("serialNumber")),
                                .DepartmentId = If(reader.IsDBNull(reader.GetOrdinal("departmentId")), CType(Nothing, Integer?), reader.GetInt32("departmentId")),
                                .Location = If(reader.IsDBNull(reader.GetOrdinal("location")), "", reader.GetString("location")),
                                .Condition = If(reader.IsDBNull(reader.GetOrdinal("condition")), "Good", reader.GetString("condition"))
                            })
                        End While
                    End Using
                End Using
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            
            cboItemName.DisplayMember = "DisplayText"
            cboItemName.SelectedIndex = 0
            
        Catch ex As Exception
            MessageBox.Show("Error loading properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ''' <summary>
    ''' When a property is selected, auto-fill related fields
    ''' </summary>
    Private Sub cboItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemName.SelectedIndexChanged
        Try
            If cboItemName.SelectedIndex > 0 AndAlso cboItemName.SelectedItem IsNot Nothing Then
                Dim selectedItem = cboItemName.SelectedItem
                
                ' Get property using reflection
                Dim propIdProp = selectedItem.GetType().GetProperty("PropertyId")
                Dim propertyId As Integer = CInt(propIdProp.GetValue(selectedItem))
                
                If propertyId > 0 Then
                    ' Auto-fill fields
                    Dim propNumProp = selectedItem.GetType().GetProperty("PropertyNumber")
                    Dim serialProp = selectedItem.GetType().GetProperty("SerialNumber")
                    Dim deptIdProp = selectedItem.GetType().GetProperty("DepartmentId")
                    Dim locationProp = selectedItem.GetType().GetProperty("Location")
                    Dim conditionProp = selectedItem.GetType().GetProperty("Condition")
                    
                    txtPropertyNumber.Text = CStr(propNumProp.GetValue(selectedItem))
                    txtSerialNumber.Text = CStr(serialProp.GetValue(selectedItem))
                    txtLocation.Text = CStr(locationProp.GetValue(selectedItem))
                    
                    ' Set department
                    Dim deptId As Integer? = CType(deptIdProp.GetValue(selectedItem), Integer?)
                    If deptId.HasValue Then
                        For i As Integer = 0 To cboDepartment.Items.Count - 1
                            Dim item = CType(cboDepartment.Items(i), KeyValuePair(Of Integer, String))
                            If item.Key = deptId.Value Then
                                cboDepartment.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    
                    ' Set condition
                    Dim condition As String = CStr(conditionProp.GetValue(selectedItem))
                    Dim condIndex As Integer = cboConditionBefore.FindStringExact(condition)
                    If condIndex >= 0 Then
                        cboConditionBefore.SelectedIndex = condIndex
                    End If
                End If
            Else
                ' Clear auto-filled fields if manual entry is selected
                txtPropertyNumber.Clear()
                txtSerialNumber.Clear()
                txtLocation.Clear()
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error auto-filling fields: " & ex.Message)
        End Try
    End Sub
    
    ''' <summary>
    ''' Public method to pre-fill item details when called from frmBorrowedItem (DEPRECATED - use SetPropertyDetails)
    ''' </summary>
    Public Sub SetItemDetails(itemName As String, propertyNumber As String, serialNumber As String, propertyId As String)
        Try
            System.Diagnostics.Debug.WriteLine($"[v0] SetItemDetails called - itemName: {itemName}, propertyId: {propertyId}")
            
            ' Try to find and select the property in the combo box
            Dim foundMatch As Boolean = False
            For i As Integer = 1 To cboItemName.Items.Count - 1
                Try
                    Dim item = cboItemName.Items(i)
                    Dim propIdProp = item.GetType().GetProperty("PropertyId")
                    If propIdProp IsNot Nothing Then
                        Dim itemPropId As Integer = CInt(propIdProp.GetValue(item))
                        
                        If itemPropId.ToString() = propertyId Then
                            cboItemName.SelectedIndex = i
                            foundMatch = True
                            System.Diagnostics.Debug.WriteLine($"[v0] Found property match at index {i}")
                            Return
                        End If
                    End If
                Catch itemEx As Exception
                    System.Diagnostics.Debug.WriteLine($"[v0] Error checking item at index {i}: " & itemEx.Message)
                    Continue For
                End Try
            Next
            
            ' If not found in borrowed items, set as manual entry
            If Not foundMatch Then
                System.Diagnostics.Debug.WriteLine("[v0] Property not found in dropdown, setting manual entry")
                ' Don't set SelectedIndex to 0, just set the text directly
                cboItemName.Text = itemName
                txtPropertyNumber.Text = propertyNumber
                txtSerialNumber.Text = serialNumber
            End If
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SetItemDetails Exception: " & ex.Message)
            ' Fallback: just set the text fields
            Try
                cboItemName.Text = itemName
                txtPropertyNumber.Text = propertyNumber
                txtSerialNumber.Text = serialNumber
            Catch
            End Try
        End Try
    End Sub
    
    ''' <summary>
    ''' Public method to pre-fill ALL property details when called from frmBorrowedItem
    ''' This will auto-populate Item Name, Property Number, Serial Number, Location, Department, and Condition
    ''' </summary>
    Public Sub SetPropertyDetails(itemName As String, propertyNumber As String, serialNumber As String, location As String, departmentId As Integer?, condition As String)
        Try
            System.Diagnostics.Debug.WriteLine($"[v0] SetPropertyDetails called - itemName: {itemName}, location: {location}, deptId: {departmentId}, condition: {condition}")
            
            ' Set item name (as text, not dropdown selection)
            cboItemName.Text = itemName
            
            ' Set property number and serial number
            txtPropertyNumber.Text = If(String.IsNullOrEmpty(propertyNumber) OrElse propertyNumber = "N/A", "", propertyNumber)
            txtSerialNumber.Text = If(String.IsNullOrEmpty(serialNumber) OrElse serialNumber = "N/A", "", serialNumber)
            
            ' Set location
            txtLocation.Text = If(String.IsNullOrEmpty(location), "", location)
            
            ' Set department
            If departmentId.HasValue Then
                For i As Integer = 0 To cboDepartment.Items.Count - 1
                    Try
                        Dim item = CType(cboDepartment.Items(i), KeyValuePair(Of Integer, String))
                        If item.Key = departmentId.Value Then
                            cboDepartment.SelectedIndex = i
                            System.Diagnostics.Debug.WriteLine($"[v0] Department set to index {i}: {item.Value}")
                            Exit For
                        End If
                    Catch
                        Continue For
                    End Try
                Next
            End If
            
            ' Set condition before maintenance
            If Not String.IsNullOrEmpty(condition) Then
                Dim condIndex As Integer = cboConditionBefore.FindStringExact(condition)
                If condIndex >= 0 Then
                    cboConditionBefore.SelectedIndex = condIndex
                    System.Diagnostics.Debug.WriteLine($"[v0] Condition set to: {condition}")
                End If
            End If
            
            System.Diagnostics.Debug.WriteLine("[v0] All property details pre-filled successfully!")
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SetPropertyDetails Exception: " & ex.Message)
            ' Fallback: just set the basic text fields
            Try
                cboItemName.Text = itemName
                txtPropertyNumber.Text = propertyNumber
                txtSerialNumber.Text = serialNumber
            Catch
            End Try
        End Try
    End Sub
    
    ''' <summary>
    ''' Submit maintenance request
    ''' </summary>
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            ' Validate required fields
            If cboItemName.SelectedIndex = 0 AndAlso String.IsNullOrWhiteSpace(cboItemName.Text) Then
                MessageBox.Show("Please select or enter an item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboItemName.Focus()
                Return
            End If
            
            If cboTypeOfIssue.SelectedIndex < 0 Then
                MessageBox.Show("Please select the type of issue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboTypeOfIssue.Focus()
                Return
            End If
            
            If String.IsNullOrWhiteSpace(txtProblemDescription.Text) Then
                MessageBox.Show("Please describe the problem.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProblemDescription.Focus()
                Return
            End If
            
            If Not SessionContext.CurrentUserID.HasValue Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Get item name
            Dim itemName As String = ""
            If cboItemName.SelectedIndex > 0 Then
                Dim selectedItem = cboItemName.SelectedItem
                Dim itemNameProp = selectedItem.GetType().GetProperty("ItemName")
                itemName = CStr(itemNameProp.GetValue(selectedItem))
            Else
                itemName = cboItemName.Text.Trim()
            End If
            
            ' Get department ID
            Dim departmentId As Integer? = Nothing
            If cboDepartment.SelectedIndex > 0 Then
                Dim selectedDept = CType(cboDepartment.SelectedItem, KeyValuePair(Of Integer, String))
                departmentId = selectedDept.Key
            End If
            
            ' Insert maintenance request
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            If Not DatabaseConnection.SafeOpenConnection(conn) Then
                MessageBox.Show("Could not open database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            Dim query As String = "INSERT INTO maintenance_requests " &
                                 "(dateRequested, itemName, propertyNumber, serialNumber, departmentId, location, " &
                                 "conditionBefore, typeOfIssue, problemDescription, status, targetDate, requestedBy, createdAt, updatedAt) " &
                                 "VALUES (@dateRequested, @itemName, @propertyNumber, @serialNumber, @departmentId, @location, " &
                                 "@conditionBefore, @typeOfIssue, @problemDescription, 'Pending', @targetDate, @requestedBy, NOW(), NOW())"
            
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@dateRequested", dtpDateRequested.Value.Date)
                cmd.Parameters.AddWithValue("@itemName", itemName)
                cmd.Parameters.AddWithValue("@propertyNumber", If(String.IsNullOrWhiteSpace(txtPropertyNumber.Text), DBNull.Value, txtPropertyNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrWhiteSpace(txtSerialNumber.Text), DBNull.Value, txtSerialNumber.Text.Trim()))
                cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, CObj(departmentId.Value), DBNull.Value))
                cmd.Parameters.AddWithValue("@location", If(String.IsNullOrWhiteSpace(txtLocation.Text), DBNull.Value, txtLocation.Text.Trim()))
                cmd.Parameters.AddWithValue("@conditionBefore", cboConditionBefore.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@typeOfIssue", cboTypeOfIssue.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@problemDescription", txtProblemDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@targetDate", If(dtpTargetDate.Value > Date.Today, CObj(dtpTargetDate.Value.Date), DBNull.Value))
                cmd.Parameters.AddWithValue("@requestedBy", SessionContext.CurrentUserID.Value)
                
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                
                If rowsAffected > 0 Then
                    ' Update the property condition based on the maintenance request
                    If Not String.IsNullOrWhiteSpace(txtPropertyNumber.Text) Then
                        Try
                            Dim updateQuery As String = "UPDATE properties SET `condition` = @condition, updatedAt = NOW() WHERE propertyNumber = @propertyNumber"
                            Using updateCmd As New MySqlCommand(updateQuery, conn)
                                updateCmd.Parameters.AddWithValue("@condition", cboConditionBefore.SelectedItem.ToString())
                                updateCmd.Parameters.AddWithValue("@propertyNumber", txtPropertyNumber.Text.Trim())
                                updateCmd.ExecuteNonQuery()
                                System.Diagnostics.Debug.WriteLine($"[v0] Property condition updated to: {cboConditionBefore.SelectedItem.ToString()}")
                            End Using
                        Catch updateEx As Exception
                            System.Diagnostics.Debug.WriteLine($"[v0] Error updating property condition: {updateEx.Message}")
                        End Try
                    End If
                    
                    MessageBox.Show("Maintenance request submitted successfully!" & Environment.NewLine & Environment.NewLine &
                                   "Your request has been sent to the maintenance department for review.", 
                                   "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    
                    ' Navigate back to borrowed items or maintenance requests
                    NavigateBack()
                Else
                    MessageBox.Show("Failed to submit maintenance request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            
            If conn.State = ConnectionState.Open Then conn.Close()
            
        Catch ex As Exception
            MessageBox.Show("Error submitting maintenance request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ''' <summary>
    ''' Cancel and go back
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub
    
    ''' <summary>
    ''' Navigate back to the previous form
    ''' </summary>
    Private Sub NavigateBack()
        Try
            ' Find the parent StaffDashboard
            Dim parentControl As Control = Me.Parent
            While parentControl IsNot Nothing AndAlso Not (TypeOf parentControl Is StaffDashboard)
                parentControl = parentControl.Parent
            End While
            
            If TypeOf parentControl Is StaffDashboard Then
                Dim dashboard As StaffDashboard = CType(parentControl, StaffDashboard)
                ' Load the borrowed items form
                Dim borrowedItemsForm As New frmBorrowedItem()
                
                ' Use reflection to call loadFormIntoPanel
                Dim dashboardType As Type = dashboard.GetType()
                Dim loadMethod = dashboardType.GetMethod("loadFormIntoPanel")
                
                If loadMethod IsNot Nothing Then
                    loadMethod.Invoke(dashboard, New Object() {borrowedItemsForm})
                Else
                    ' Fallback
                    Dim panel = dashboard.Controls("pnlContent")
                    If panel IsNot Nothing Then
                        panel.Controls.Clear()
                        panel.Controls.Add(borrowedItemsForm)
                    End If
                End If
            Else
                ' If not in dashboard, just remove this control
                If Me.Parent IsNot Nothing Then
                    Me.Parent.Controls.Remove(Me)
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("NavigateBack error: " & ex.Message)
        End Try
    End Sub
End Class
