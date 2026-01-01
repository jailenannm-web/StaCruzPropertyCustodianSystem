Imports System
Imports System.Data
Imports System.Linq
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class AddProperty
    Private departmentDirectory As DataTable
    Private usersDirectory As DataTable

    Public Sub New()
        InitializeComponent()
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        ' Initialize Category dropdown
        If cboCategory.Items.Count = 0 Then
            cboCategory.Items.AddRange(New Object() {
                "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                "Laboratory Apparatus", "Books and Publications",
                "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
            })
        End If

        ' Initialize Condition dropdown
        If cboCondition.Items.Count = 0 Then
            cboCondition.Items.AddRange(New Object() {"Good", "Needs Repair", "Damaged"})
        End If
        cboCondition.SelectedIndex = 0 ' Default to "Good"

        ' Initialize Status dropdown
        If cboStatus.Items.Count = 0 Then
            cboStatus.Items.AddRange(New Object() {"Active", "Borrowed", "For Disposal", "Lost"})
        End If
        cboStatus.SelectedIndex = 0 ' Default to "Active"

        ' Initialize Source of Funds dropdown
        If cboSourceOfFunds.Items.Count = 0 Then
            cboSourceOfFunds.Items.AddRange(New Object() {
                "General Fund", "Special Education Fund", "Trust Fund", "Donation", "Others"
            })
        End If
        
        ' Initialize Unit of Measure dropdown
        If txtUnitOfMeasure.Items.Count = 0 Then
            txtUnitOfMeasure.Items.AddRange(New Object() {
                "Piece", "Unit", "Set", "Box", "Pack", "Ream", "Bundle", "Roll", 
                "Gallon", "Liter", "Kilogram", "Meter", "Pair", "Dozen", "Case", "Lot"
            })
        End If
        
        ' Set default quantity
        txtQuantity.Value = 1

        ' Set default date
        dtpAcquisitionDate.Value = DateTime.Now

        ' Configure auto-generated fields as read-only
        txtPropertyNumber.ReadOnly = True
        txtPropertyNumber.BackColor = System.Drawing.Color.LightGray
        txtPropertyNumber.Text = "(Auto-generated)"

        txtInternalCodes.ReadOnly = True
        txtInternalCodes.BackColor = System.Drawing.Color.LightGray
        txtInternalCodes.Text = "(Auto-generated)"

        ' Load departments and users
        LoadDepartments()
        LoadUsers()
    End Sub

    Private Sub LoadDepartments()
        Try
            departmentDirectory = modDB.GetAllDepartments()
            If departmentDirectory IsNot Nothing AndAlso departmentDirectory.Rows.Count > 0 Then
                cboDepartment.DataSource = departmentDirectory.Copy()
                cboDepartment.DisplayMember = "departmentName"
                cboDepartment.ValueMember = "departmentId"
                cboDepartment.SelectedIndex = -1
            End If
        Catch ex As Exception
            ' Load error, populate manually if needed
            cboDepartment.Items.Clear()
        End Try
    End Sub
    
    ''' <summary>
    ''' Auto-fill location when department is selected
    ''' </summary>
    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        Try
            If cboDepartment.SelectedIndex >= 0 AndAlso cboDepartment.SelectedValue IsNot Nothing AndAlso departmentDirectory IsNot Nothing Then
                ' Find the selected department row
                Dim selectedDeptId = cboDepartment.SelectedValue
                Dim rows() As DataRow = departmentDirectory.Select($"departmentId = {selectedDeptId}")
                
                If rows.Length > 0 Then
                    Dim row As DataRow = rows(0)
                    
                    ' Build location string from department data
                    Dim locationParts As New List(Of String)
                    
                    If Not row.IsNull("location") AndAlso Not String.IsNullOrWhiteSpace(row("location").ToString()) Then
                        locationParts.Add(row("location").ToString())
                    End If
                    
                    If Not row.IsNull("building") AndAlso Not String.IsNullOrWhiteSpace(row("building").ToString()) Then
                        locationParts.Add(row("building").ToString())
                    End If
                    
                    If Not row.IsNull("floorNumber") AndAlso Not String.IsNullOrWhiteSpace(row("floorNumber").ToString()) Then
                        locationParts.Add("Floor " & row("floorNumber").ToString())
                    End If
                    
                    ' Set the location text
                    If locationParts.Count > 0 Then
                        txtLocation.Text = String.Join(", ", locationParts)
                    End If
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error auto-filling location: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadUsers()
        Try
            ' Load users for Assigned To dropdown
            Using conn As MySqlConnection = modDB.GetConnection()
                If conn IsNot Nothing Then
                    conn.Open()
                    Using cmd As New MySqlCommand("SELECT userId, CONCAT(IFNULL(firstName,''), ' ', IFNULL(lastName,'')) AS fullName, employeeId FROM users WHERE status = 'Active' ORDER BY firstName, lastName", conn)
                        Using adapter As New MySqlDataAdapter(cmd)
                            usersDirectory = New DataTable()
                            adapter.Fill(usersDirectory)

                            If usersDirectory.Rows.Count > 0 Then
                                ' Add a blank row for "Not Assigned"
                                Dim blankRow As DataRow = usersDirectory.NewRow()
                                blankRow("userId") = DBNull.Value
                                blankRow("fullName") = "-- Not Assigned --"
                                blankRow("employeeId") = DBNull.Value
                                usersDirectory.Rows.InsertAt(blankRow, 0)

                                cboAssignedTo.DataSource = usersDirectory
                                cboAssignedTo.DisplayMember = "fullName"
                                cboAssignedTo.ValueMember = "userId"
                                cboAssignedTo.SelectedIndex = 0
                            End If
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            cboAssignedTo.Items.Clear()
            cboAssignedTo.Items.Add("-- Not Assigned --")
            cboAssignedTo.SelectedIndex = 0
        End Try
    End Sub
    
    ''' <summary>
    ''' Auto-calculate total cost when acquisition cost or quantity changes
    ''' </summary>
    Private Sub CalculateTotalCost()
        Try
            Dim quantity As Decimal = txtQuantity.Value
            Dim acquisitionCost As Decimal = txtAcquisitionCost.Value
            Dim totalCost As Decimal = quantity * acquisitionCost
            
            txtTotalCost.Text = totalCost.ToString("N2")
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error calculating total cost: " & ex.Message)
        End Try
    End Sub
    
    ''' <summary>
    ''' Handle acquisition cost change
    ''' </summary>
    Private Sub txtAcquisitionCost_ValueChanged(sender As Object, e As EventArgs) Handles txtAcquisitionCost.ValueChanged
        CalculateTotalCost()
    End Sub
    
    ''' <summary>
    ''' Handle quantity change
    ''' </summary>
    Private Sub txtQuantity_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged
        CalculateTotalCost()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields
        If Not ValidateInputs() Then
            Return
        End If

        Try
            ' Get values from form
            Dim itemName As String = txtItemName.Text.Trim()
            Dim category As String = If(cboCategory.SelectedIndex >= 0, cboCategory.SelectedItem.ToString(), "")
            Dim serialNumber As String = txtSerialNumber.Text.Trim()
            Dim description As String = txtDescription.Text.Trim()
            
            ' Get unit of measure and quantity
            Dim quantity As Integer = CInt(txtQuantity.Value)
            Dim unitOfMeasure As String = ""
            If txtUnitOfMeasure.SelectedIndex >= 0 Then
                unitOfMeasure = quantity.ToString() & " " & txtUnitOfMeasure.SelectedItem.ToString()
            End If
            
            Dim condition As String = If(cboCondition.SelectedIndex >= 0, cboCondition.SelectedItem.ToString(), "Good")
            Dim acquisitionCost As Decimal = txtAcquisitionCost.Value
            Dim acquisitionDate As Date = dtpAcquisitionDate.Value

            ' Property number and internal codes will be auto-generated (pass empty strings)
            Dim propertyNumber As String = ""
            Dim internalCodes As String = ""

            ' Get department ID
            Dim departmentId As Integer? = Nothing
            If cboDepartment.SelectedValue IsNot Nothing AndAlso Not cboDepartment.SelectedValue.Equals(DBNull.Value) Then
                departmentId = CInt(cboDepartment.SelectedValue)
            End If

            ' Get assigned user ID
            Dim assignedTo As Integer? = Nothing
            If cboAssignedTo.SelectedValue IsNot Nothing AndAlso Not cboAssignedTo.SelectedValue.Equals(DBNull.Value) Then
                assignedTo = CInt(cboAssignedTo.SelectedValue)
            End If

            Dim location As String = txtLocation.Text.Trim()
            Dim status As String = If(cboStatus.SelectedIndex >= 0, cboStatus.SelectedItem.ToString(), "Active")

            ' Parse total cost
            Dim totalCost As Decimal? = Nothing
            Dim totalCostValue As Decimal = 0D
            If Decimal.TryParse(txtTotalCost.Text.Trim(), totalCostValue) AndAlso totalCostValue > 0 Then
                totalCost = totalCostValue
            End If

            Dim sourceOfFunds As String = If(cboSourceOfFunds.SelectedIndex >= 0, cboSourceOfFunds.SelectedItem.ToString(), "")

            ' Insert property into database (propertyNumber and internalCodes will be auto-generated)
            Dim success As Boolean = modDB.AddProperty(
                itemName, category, description, unitOfMeasure,
                propertyNumber, serialNumber, acquisitionDate, acquisitionCost,
                totalCost, sourceOfFunds, assignedTo, departmentId,
                location, condition, status, internalCodes
            )

            If success Then
                MessageBox.Show("Property added successfully with auto-generated Property Number and Internal Code!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearForm()
            Else
                MessageBox.Show("Failed to add property. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        ' Validate Item Name (required)
        If String.IsNullOrWhiteSpace(txtItemName.Text) Then
            MessageBox.Show("Please enter an item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Return False
        End If

        ' Validate Category (required)
        If cboCategory.SelectedIndex < 0 Then
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return False
        End If

        ' Validate Acquisition Cost (must be >= 0)
        If txtAcquisitionCost.Value < 0 Then
            MessageBox.Show("Acquisition cost cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAcquisitionCost.Focus()
            Return False
        End If

        ' Validate Acquisition Date (cannot be future)
        If dtpAcquisitionDate.Value > DateTime.Now Then
            MessageBox.Show("Acquisition date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpAcquisitionDate.Focus()
            Return False
        End If

        ' Validate Location (required)
        If String.IsNullOrWhiteSpace(txtLocation.Text) Then
            MessageBox.Show("Please enter a location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLocation.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ClearForm()
        ' Clear all input fields
        txtItemName.Clear()
        cboCategory.SelectedIndex = -1
        txtSerialNumber.Clear()
        txtDescription.Clear()
        txtUnitOfMeasure.SelectedIndex = -1
        txtQuantity.Value = 1
        cboCondition.SelectedIndex = 0 ' Reset to "Good"
        txtAcquisitionCost.Value = 0
        dtpAcquisitionDate.Value = DateTime.Now
        txtPropertyNumber.Text = "(Auto-generated)"
        txtInternalCodes.Text = "(Auto-generated)"
        If cboDepartment.Items.Count > 0 Then cboDepartment.SelectedIndex = -1
        If cboAssignedTo.Items.Count > 0 Then cboAssignedTo.SelectedIndex = 0 ' Reset to "Not Assigned"
        txtLocation.Clear()
        cboStatus.SelectedIndex = 0 ' Reset to "Active"
        txtTotalCost.Clear()
        cboSourceOfFunds.SelectedIndex = -1

        ' Focus on first field
        txtItemName.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Ask for confirmation
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel? Any unsaved changes will be lost.",
                                                     "Confirm Cancel",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ClearForm()
            ' Return to property management
            If Me.ParentForm IsNot Nothing Then
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    parentDashboard.LoadUserControl(New UC_PropertyManagement1())
                    Return
                End If

                Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
                If saDashboard IsNot Nothing Then
                    saDashboard.LoadUserControl(New UC_PropertyManagement1())
                    Return
                End If
            End If
        End If
    End Sub
End Class
