Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class EditPropertyManagement
    Private PropertyIDValue As Integer
    Private departmentDirectory As DataTable
    Private usersDirectory As DataTable

    Public Sub New()
        InitializeComponent()
        InitializeForm()
        
        ' Add event handler for department change
        AddHandler cboDepartment.SelectedIndexChanged, AddressOf cboDepartment_SelectedIndexChanged
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

        ' Initialize Status dropdown
        If cboStatus.Items.Count = 0 Then
            cboStatus.Items.AddRange(New Object() {"Active", "Borrowed", "For Disposal", "Lost"})
        End If

        ' Initialize Source of Funds dropdown
        If cboSourceOfFunds.Items.Count = 0 Then
            cboSourceOfFunds.Items.AddRange(New Object() {
                "General Fund", "Special Education Fund", "Trust Fund", "Donation", "Others"
            })
        End If

        ' Load departments
        LoadDepartments()
    End Sub

    Private Sub LoadDepartments()
        Try
            departmentDirectory = DatabaseConnection.GetAllDepartments()
            If departmentDirectory IsNot Nothing AndAlso departmentDirectory.Rows.Count > 0 Then
                cboDepartment.DataSource = departmentDirectory.Copy()
                cboDepartment.DisplayMember = "departmentName"
                cboDepartment.ValueMember = "departmentId"
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub LoadUsers()
        Try
            ' Load users for Assigned To dropdown
            Using conn As MySqlConnection = DatabaseConnection.GetConnection()
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

                                ' Bind to the combo box
                                If cboAssignedTo IsNot Nothing Then
                                    cboAssignedTo.DataSource = usersDirectory
                                    cboAssignedTo.DisplayMember = "fullName"
                                    cboAssignedTo.ValueMember = "userId"
                                    cboAssignedTo.SelectedIndex = 0
                                End If
                            End If
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadUsers Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub SetUserValue(userId As Integer)
        ' Set the assigned user in the combo box
        If cboAssignedTo IsNot Nothing AndAlso cboAssignedTo.DataSource IsNot Nothing Then
            For i As Integer = 0 To cboAssignedTo.Items.Count - 1
                cboAssignedTo.SelectedIndex = i
                If cboAssignedTo.SelectedValue IsNot Nothing AndAlso Not DBNull.Value.Equals(cboAssignedTo.SelectedValue) Then
                    Dim selectedUserId As Integer
                    If Integer.TryParse(cboAssignedTo.SelectedValue.ToString(), selectedUserId) Then
                        If selectedUserId = userId Then
                            Return ' Found and selected the user
                        End If
                    End If
                End If
            Next
            ' If not found, reset to "Not Assigned"
            cboAssignedTo.SelectedIndex = 0
        End If
    End Sub

    Public Sub LoadPropertyData(propertyID As Integer, itemName As String, category As String,
                                serialNumber As String, description As String, unitOfMeasure As String,
                                conditionStatus As String, acquisitionCost As Decimal, acquisitionDate As Date,
                                departmentID As Integer?, location As String, status As String,
                                propertyNumber As String, internalCodes As String, totalCost As Decimal,
                                sourceOfFunds As String, Optional assignedToUserId As Integer? = Nothing)

        PropertyIDValue = propertyID
        txtPropertyID.Text = propertyID.ToString()
        txtItemName.Text = itemName
        SetComboValue(cboCategory, category)
        txtSerialNumber.Text = serialNumber
        txtDescription.Text = description
        txtUnitOfMeasure.Text = unitOfMeasure
        SetComboValue(cboCondition, conditionStatus)
        txtAcquisitionCost.Value = acquisitionCost
        dtpAcquisitionDate.Value = acquisitionDate
        txtLocation.Text = location
        SetComboValue(cboStatus, status)

        ' Set read-only fields
        txtPropertyNumber.Text = propertyNumber
        txtInternalCodes.Text = internalCodes
        txtTotalCost.Text = totalCost.ToString("0.00")
        SetComboValue(cboSourceOfFunds, sourceOfFunds)

        ' Set department
        If departmentID.HasValue Then
            SetDepartmentValue(departmentID.Value)
        End If

        ' Load users for assignment if not already loaded
        If usersDirectory Is Nothing OrElse usersDirectory.Rows.Count = 0 Then
            LoadUsers()
        End If

        ' Set assigned user
        If assignedToUserId.HasValue AndAlso assignedToUserId.Value > 0 Then
            SetUserValue(assignedToUserId.Value)
        End If
    End Sub

    Private Sub SetComboValue(combo As ComboBox, value As String)
        If combo Is Nothing OrElse String.IsNullOrWhiteSpace(value) Then Return

        Dim index As Integer = combo.FindStringExact(value)
        If index >= 0 Then
            combo.SelectedIndex = index
        Else
            combo.Text = value
        End If
    End Sub

    Private Sub SetDepartmentValue(departmentID As Integer)
        If cboDepartment Is Nothing OrElse cboDepartment.DataSource Is Nothing Then Return

        For i As Integer = 0 To cboDepartment.Items.Count - 1
            cboDepartment.SelectedIndex = i
            If cboDepartment.SelectedValue IsNot Nothing Then
                Dim selectedID As Integer
                If Integer.TryParse(cboDepartment.SelectedValue.ToString(), selectedID) Then
                    If selectedID = departmentID Then
                        Return
                    End If
                End If
            End If
        Next
    End Sub

    Private Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        If combo.SelectedIndex >= 0 AndAlso combo.SelectedItem IsNot Nothing Then
            Return combo.SelectedItem.ToString()
        End If
        If Not String.IsNullOrWhiteSpace(combo.Text) Then
            Return combo.Text.Trim()
        End If
        Return fallback
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(txtItemName.Text) Then
            MessageBox.Show("Please enter the item name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Return
        End If

        If cboCategory.SelectedIndex < 0 Then
            MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return
        End If

        ' Get department ID
        Dim departmentID As Integer? = Nothing
        If cboDepartment.SelectedValue IsNot Nothing Then
            Dim deptID As Integer
            If Integer.TryParse(cboDepartment.SelectedValue.ToString(), deptID) Then
                departmentID = deptID
            End If
        End If

        ' Get assigned user ID from cboAssignedTo
        Dim assignedToUserId As Integer? = Nothing
        Try
            If cboAssignedTo IsNot Nothing AndAlso cboAssignedTo.SelectedValue IsNot Nothing AndAlso Not cboAssignedTo.SelectedValue.Equals(DBNull.Value) Then
                assignedToUserId = CInt(cboAssignedTo.SelectedValue)
            End If
        Catch ex As Exception
            ' Error accessing control, continue without assignment
            System.Diagnostics.Debug.WriteLine("[v0] Error getting assigned user: " & ex.Message)
        End Try

        Try
            Dim success = DatabaseConnection.UpdateProperty(
                PropertyIDValue,
                txtItemName.Text.Trim(),
                GetComboValue(cboCategory, "Others"),
                txtDescription.Text.Trim(),
                txtUnitOfMeasure.Text.Trim(),
                txtSerialNumber.Text.Trim(),
                GetComboValue(cboCondition, "Good"),
                txtLocation.Text.Trim(),
                assignedToUserId, ' custodianID - now passed from form
                departmentID,
                dtpAcquisitionDate.Value,
                txtAcquisitionCost.Value,
                GetComboValue(cboSourceOfFunds, ""),
                GetComboValue(cboStatus, "Active")
            )

            If success Then
                MessageBox.Show("Property updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NavigateBackToList()
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBackToList()
    End Sub

    Private Sub NavigateBackToList()
        Dim parentForm = Me.FindForm()
        If TypeOf parentForm Is SADashboard Then
            Dim dashboard = CType(parentForm, SADashboard)
            dashboard.LoadUserControl(New UC_PropertyManagement1())
        ElseIf TypeOf parentForm Is AdminDashboard Then
            Dim dashboard = CType(parentForm, AdminDashboard)
            dashboard.LoadUserControl(New UC_PropertyManagement1())
        End If
    End Sub
    
    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Auto-fill location based on selected department
        UpdateLocationFromDepartment()
    End Sub
    
    Private Sub UpdateLocationFromDepartment()
        Try
            If departmentDirectory Is Nothing OrElse departmentDirectory.Rows.Count = 0 Then Return
            If cboDepartment.SelectedValue Is Nothing Then Return
            
            Dim deptID As Integer
            If Not Integer.TryParse(cboDepartment.SelectedValue.ToString(), deptID) Then Return
            
            ' Find the selected department row
            Dim selectedDept = departmentDirectory.AsEnumerable().
                FirstOrDefault(Function(r) Convert.ToInt32(r("departmentId")) = deptID)
            
            If selectedDept IsNot Nothing Then
                ' Get location from department
                Dim deptLocation As String = ""
                
                If selectedDept.Table.Columns.Contains("location") AndAlso Not selectedDept.IsNull("location") Then
                    deptLocation = selectedDept("location").ToString()
                ElseIf selectedDept.Table.Columns.Contains("building") AndAlso Not selectedDept.IsNull("building") Then
                    deptLocation = selectedDept("building").ToString()
                End If
                
                ' Update the location textbox if we found a location
                If Not String.IsNullOrWhiteSpace(deptLocation) AndAlso txtLocation IsNot Nothing Then
                    txtLocation.Text = deptLocation
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateLocationFromDepartment Exception: " & ex.Message)
        End Try
    End Sub
End Class
