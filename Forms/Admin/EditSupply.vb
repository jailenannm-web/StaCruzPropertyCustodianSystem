Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class EditSupply
    Private SupplyIDValue As Integer

    Public Sub New()
        InitializeComponent()
        InitializeForm()
    End Sub

    Private usersDirectory As DataTable
    
    Private Sub InitializeForm()
        ' Initialize Category dropdown
        If cboCategory.Items.Count = 0 Then
            cboCategory.Items.AddRange(New Object() {
                "Office Supplies", "Cleaning Supplies", "Medical Supplies",
                "IT Supplies", "Laboratory Supplies", "Others"
            })
        End If

        ' Initialize Stock Status dropdown
        If cboStockStatus.Items.Count = 0 Then
            cboStockStatus.Items.AddRange(New Object() {"Available", "Low Stock", "Out of Stock"})
        End If

        ' Initialize Source of Funds dropdown
        If cboSourceOfFunds.Items.Count = 0 Then
            cboSourceOfFunds.Items.AddRange(New Object() {
                "General Fund", "Special Education Fund", "Trust Fund", "Donation", "Others"
            })
        End If

        ' Load departments
        LoadDepartments()
        
        ' Load users for assignment
        LoadUsers()
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

                                ' Check if cboAssignedTo control exists
                                Dim assignedToControls() As Control = Me.Controls.Find("cboAssignedTo", True)
                                If assignedToControls.Length > 0 AndAlso TypeOf assignedToControls(0) Is ComboBox Then
                                    Dim cboAssignedTo As ComboBox = CType(assignedToControls(0), ComboBox)
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
            System.Diagnostics.Debug.WriteLine("LoadUsers Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cboDepartment.Items.Clear()
                cboDepartment.Items.Add("-- Select Department --")
                
                For Each row As DataRow In dt.Rows
                    Dim deptItem As New DepartmentItem() With {
                        .DepartmentId = CInt(row("departmentId")),
                        .DepartmentName = row("departmentName").ToString(),
                        .Location = If(row.IsNull("location"), "", row("location").ToString())
                    }
                    cboDepartment.Items.Add(deptItem)
                Next
                
                cboDepartment.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        If cboDepartment.SelectedIndex > 0 AndAlso TypeOf cboDepartment.SelectedItem Is DepartmentItem Then
            Dim selectedDept As DepartmentItem = CType(cboDepartment.SelectedItem, DepartmentItem)
            txtLocation.Text = selectedDept.Location
        Else
            txtLocation.Text = ""
        End If
    End Sub

    ' Helper class to store department information
    Private Class DepartmentItem
        Public Property DepartmentId As Integer
        Public Property DepartmentName As String
        Public Property Location As String

        Public Overrides Function ToString() As String
            Return DepartmentName
        End Function
    End Class

    Public Sub LoadSupplyData(supplyID As Integer, itemName As String, category As String,
                             description As String, unitOfMeasure As String, quantity As Integer,
                             dateReceived As Date, unitCost As Decimal, totalCost As Decimal,
                             supplier As String, sourceOfFunds As String, location As String,
                             stockStatus As String, Optional assignedToUserId As Integer? = Nothing)
        
        SupplyIDValue = supplyID
        txtSupplyID.Text = supplyID.ToString()
        txtItemName.Text = itemName
        SetComboValue(cboCategory, category)
        txtDescription.Text = description
        txtUnitOfMeasure.Text = unitOfMeasure
        numQuantity.Value = quantity
        dtpDateReceived.Value = dateReceived
        numUnitCost.Value = unitCost
        txtTotalCost.Text = totalCost.ToString("0.00")
        txtSupplier.Text = supplier
        SetComboValue(cboSourceOfFunds, sourceOfFunds)
        txtLocation.Text = location
        SetComboValue(cboStockStatus, stockStatus)
        
        ' Set assigned user
        If assignedToUserId.HasValue Then
            SetUserValue(assignedToUserId.Value)
        End If
        
        ' Try to match location with a department
        SetDepartmentByLocation(location)
    End Sub
    
    Private Sub SetUserValue(userId As Integer)
        ' Set the assigned user in the combo box
        Dim assignedToControls() As Control = Me.Controls.Find("cboAssignedTo", True)
        If assignedToControls.Length > 0 AndAlso TypeOf assignedToControls(0) Is ComboBox Then
            Dim cboAssignedTo As ComboBox = CType(assignedToControls(0), ComboBox)
            If cboAssignedTo.DataSource IsNot Nothing Then
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
        End If
    End Sub

    Private Sub SetDepartmentByLocation(location As String)
        If String.IsNullOrWhiteSpace(location) Then
            cboDepartment.SelectedIndex = 0
            Return
        End If

        ' Try to find matching department by location
        For i As Integer = 1 To cboDepartment.Items.Count - 1
            If TypeOf cboDepartment.Items(i) Is DepartmentItem Then
                Dim deptItem As DepartmentItem = CType(cboDepartment.Items(i), DepartmentItem)
                If deptItem.Location.Trim().Equals(location.Trim(), StringComparison.OrdinalIgnoreCase) Then
                    cboDepartment.SelectedIndex = i
                    Return
                End If
            End If
        Next

        ' If no match found, set to first item and keep existing location
        cboDepartment.SelectedIndex = 0
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

        If String.IsNullOrWhiteSpace(txtUnitOfMeasure.Text) Then
            MessageBox.Show("Please enter the unit of measure.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitOfMeasure.Focus()
            Return
        End If

        If numQuantity.Value <= 0 Then
            MessageBox.Show("Please enter a quantity greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numQuantity.Focus()
            Return
        End If

        If numUnitCost.Value <= 0 Then
            MessageBox.Show("Please enter a unit cost greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numUnitCost.Focus()
            Return
        End If

        Try
            ' Calculate total cost
            Dim totalCost As Decimal = numQuantity.Value * numUnitCost.Value

            ' Get assigned user ID
            Dim assignedTo As Integer? = Nothing
            Dim assignedToControls() As Control = Me.Controls.Find("cboAssignedTo", True)
            If assignedToControls.Length > 0 AndAlso TypeOf assignedToControls(0) Is ComboBox Then
                Dim cboAssignedTo As ComboBox = CType(assignedToControls(0), ComboBox)
                If cboAssignedTo.SelectedValue IsNot Nothing AndAlso Not cboAssignedTo.SelectedValue.Equals(DBNull.Value) Then
                    assignedTo = CInt(cboAssignedTo.SelectedValue)
                End If
            End If

            Dim success = DatabaseConnection.UpdateSupply(
                SupplyIDValue,
                txtItemName.Text.Trim(),
                GetComboValue(cboCategory, "Others"),
                txtDescription.Text.Trim(),
                txtUnitOfMeasure.Text.Trim(),
                CInt(numQuantity.Value),
                dtpDateReceived.Value,
                numUnitCost.Value,
                totalCost,
                txtSupplier.Text.Trim(),
                GetComboValue(cboSourceOfFunds, ""),
                assignedTo,
                txtLocation.Text.Trim(),
                GetComboValue(cboStockStatus, "Available")
            )

            If success Then
                MessageBox.Show("Supply updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NavigateBackToList()
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBackToList()
    End Sub

    Private Sub NavigateBackToList()
        Dim parentForm = Me.FindForm()
        If TypeOf parentForm Is SADashboard Then
            Dim dashboard = CType(parentForm, SADashboard)
            dashboard.LoadUserControl(New UC_SupplyManagement())
        ElseIf TypeOf parentForm Is AdminDashboard Then
            Dim dashboard = CType(parentForm, AdminDashboard)
            dashboard.LoadUserControl(New UC_SupplyManagement())
        End If
    End Sub

    Private Sub numQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numQuantity.ValueChanged
        UpdateTotalCost()
    End Sub

    Private Sub numUnitCost_ValueChanged(sender As Object, e As EventArgs) Handles numUnitCost.ValueChanged
        UpdateTotalCost()
    End Sub

    Private Sub UpdateTotalCost()
        Try
            txtTotalCost.Text = (numQuantity.Value * numUnitCost.Value).ToString("N2")
        Catch
            txtTotalCost.Text = "0.00"
        End Try
    End Sub

    Private Sub pnlMain_Paint(sender As Object, e As PaintEventArgs) Handles pnlMain.Paint

    End Sub
End Class
