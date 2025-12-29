Imports System
Imports System.Collections.Generic
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
        
        ' Load suppliers
        LoadSuppliers()
        
        ' Load unit of measures
        LoadUnitOfMeasures()
    End Sub
    
    Private Sub LoadUsers()
        Try
            ' Load users for Assigned To dropdown
            Using conn As MySqlConnection = DatabaseConnection.GetConnection()
                If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                    Using cmd As New MySqlCommand("SELECT userId, CONCAT(IFNULL(firstName,''), ' ', IFNULL(lastName,'')) AS fullName FROM users WHERE status = 'Active' ORDER BY firstName, lastName", conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            cboAssignedTo.Items.Clear()
                            cboAssignedTo.Items.Add("-- Not Assigned --")

                            While reader.Read()
                                Dim userItem As New UserItem() With {
                                    .UserId = CInt(reader("userId")),
                                    .FullName = reader("fullName").ToString()
                                }
                                cboAssignedTo.Items.Add(userItem)
                            End While

                            cboAssignedTo.SelectedIndex = 0
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub LoadSuppliers()
        Try
            Dim suppliers As List(Of String) = DatabaseConnection.GetAllSuppliers()
            cboSupplier.Items.Clear()
            cboSupplier.Items.Add("-- Select or Type Supplier --")

            For Each supplier As String In suppliers
                cboSupplier.Items.Add(supplier)
            Next

            cboSupplier.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUnitOfMeasures()
        Try
            Dim units As List(Of String) = DatabaseConnection.GetAllUnitOfMeasures()
            cboUnitOfMeasure.Items.Clear()
            cboUnitOfMeasure.Items.Add("-- Select or Type Unit --")

            For Each unit As String In units
                cboUnitOfMeasure.Items.Add(unit)
            Next

            cboUnitOfMeasure.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading unit of measures: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    ' Helper class to store user information
    Private Class UserItem
        Public Property UserId As Integer
        Public Property FullName As String

        Public Overrides Function ToString() As String
            Return FullName
        End Function
    End Class

    Public Sub LoadSupplyData(supplyID As Integer, itemName As String, category As String,
                             description As String, unitOfMeasure As String, quantity As Integer,
                             dateReceived As Date, unitCost As Decimal, totalCost As Decimal,
                             supplier As String, sourceOfFunds As String, location As String,
                             stockStatus As String, Optional assignedToUserId As Integer? = Nothing)

        Try
            SupplyIDValue = supplyID

            ' Safely set text fields
            If txtSupplyID IsNot Nothing Then txtSupplyID.Text = supplyID.ToString()
            If txtItemName IsNot Nothing Then txtItemName.Text = If(String.IsNullOrEmpty(itemName), "", itemName)
            If txtDescription IsNot Nothing Then txtDescription.Text = If(String.IsNullOrEmpty(description), "", description)
            ' Set unit of measure combo box
            SetComboValue(cboUnitOfMeasure, unitOfMeasure)
            ' Set supplier combo box
            SetComboValue(cboSupplier, supplier)
            If txtLocation IsNot Nothing Then txtLocation.Text = If(String.IsNullOrEmpty(location), "", location)
            If txtTotalCost IsNot Nothing Then txtTotalCost.Text = totalCost.ToString("0.00")

            ' Safely set combo boxes
            SetComboValue(cboCategory, category)
            SetComboValue(cboSourceOfFunds, sourceOfFunds)
            SetComboValue(cboStockStatus, stockStatus)

            ' Safely set numeric controls with validation
            If numQuantity IsNot Nothing Then
                Dim qtyVal As Decimal = Math.Max(0, Math.Min(quantity, numQuantity.Maximum))
                numQuantity.Value = qtyVal
            End If

            If dtpDateReceived IsNot Nothing Then
                dtpDateReceived.Value = dateReceived
            End If

            If numUnitCost IsNot Nothing Then
                Dim costVal As Decimal = Math.Max(0, Math.Min(unitCost, numUnitCost.Maximum))
                numUnitCost.Value = costVal
            End If

            ' Set assigned user
            If assignedToUserId.HasValue Then
                SetUserValue(assignedToUserId.Value)
            End If

            ' Try to match location with a department
            SetDepartmentByLocation(location)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[EditSupply] LoadSupplyData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error loading supply data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
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

        If String.IsNullOrWhiteSpace(GetComboValue(cboUnitOfMeasure, "")) Then
            MessageBox.Show("Please enter the unit of measure.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboUnitOfMeasure.Focus()
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
                GetComboValue(cboUnitOfMeasure, ""),
                CInt(numQuantity.Value),
                dtpDateReceived.Value,
                numUnitCost.Value,
                totalCost,
                GetComboValue(cboSupplier, ""),
                GetComboValue(cboSourceOfFunds, ""),
                assignedTo,
                txtLocation.Text.Trim(),
                GetComboValue(cboStockStatus, "Available")
            )

            If success Then
                ' Check if assignedTo was changed and handle borrowed_items record
                If assignedTo.HasValue AndAlso assignedTo.Value > 0 Then
                    Try
                        Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                        If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                            ' Check if a borrowed_items record already exists for this supply
                            Dim existingBorrowId As Integer = 0
                            Using checkCmd As New MySqlCommand("SELECT borrowId FROM borrowed_items WHERE itemType = 'supply' AND itemId = @supplyId AND status = 'Borrowed' LIMIT 1", conn)
                                checkCmd.Parameters.AddWithValue("@supplyId", SupplyIDValue)
                                Dim result = checkCmd.ExecuteScalar()
                                If result IsNot Nothing Then
                                    existingBorrowId = Convert.ToInt32(result)
                                End If
                            End Using

                            If existingBorrowId > 0 Then
                                ' Update existing borrowed_items record with new user info
                                Dim updateQuery As String = "UPDATE borrowed_items bi " &
                                                           "JOIN users u ON u.userId = @userId " &
                                                           "SET bi.borrowerName = CONCAT(u.firstName, ' ', u.lastName), " &
                                                           "bi.borrowerPosition = u.position, " &
                                                           "bi.departmentId = u.departmentId, " &
                                                           "bi.updatedAt = NOW() " &
                                                           "WHERE bi.borrowId = @borrowId"

                                Using updateCmd As New MySqlCommand(updateQuery, conn)
                                    updateCmd.Parameters.AddWithValue("@userId", assignedTo.Value)
                                    updateCmd.Parameters.AddWithValue("@borrowId", existingBorrowId)
                                    updateCmd.ExecuteNonQuery()
                                End Using

                                System.Diagnostics.Debug.WriteLine($"[v0] EditSupply - Updated borrowed_items record borrowId: {existingBorrowId}, new userId: {assignedTo.Value}")
                            Else
                                ' Create new borrowed_items record
                                Dim borrowQuery As String = "INSERT INTO borrowed_items (itemType, itemId, itemName, borrowerName, borrowerPosition, " &
                                                            "departmentId, borrowDate, returnReason, status, remarks, createdAt, updatedAt) " &
                                                            "SELECT 'supply', s.supplyId, s.itemName, CONCAT(u.firstName, ' ', u.lastName), u.position, " &
                                                            "u.departmentId, NOW(), NULL, 'Borrowed', @remarks, NOW(), NOW() " &
                                                            "FROM supplies s, users u WHERE s.supplyId = @supplyId AND u.userId = @userId"

                                Using borrowCmd As New MySqlCommand(borrowQuery, conn)
                                    borrowCmd.Parameters.AddWithValue("@supplyId", SupplyIDValue)
                                    borrowCmd.Parameters.AddWithValue("@userId", assignedTo.Value)
                                    borrowCmd.Parameters.AddWithValue("@remarks", "Supply assigned: " & txtItemName.Text.Trim())
                                    borrowCmd.ExecuteNonQuery()
                                End Using

                                System.Diagnostics.Debug.WriteLine($"[v0] EditSupply - Created borrowed_items record for supplyId: {SupplyIDValue}, userId: {assignedTo.Value}")
                            End If

                            If conn.State = ConnectionState.Open Then conn.Close()
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] EditSupply - Error managing borrowed_items: " & ex.Message)
                        ' Don't fail the update operation if borrowed_items management fails
                    End Try
                ElseIf Not assignedTo.HasValue OrElse assignedTo.Value = 0 Then
                    ' If assignedTo was removed, mark borrowed_items as returned
                    Try
                        Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                        If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                            Using returnCmd As New MySqlCommand("UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW(), updatedAt = NOW() WHERE itemType = 'supply' AND itemId = @supplyId AND status = 'Borrowed'", conn)
                                returnCmd.Parameters.AddWithValue("@supplyId", SupplyIDValue)
                                returnCmd.ExecuteNonQuery()
                            End Using
                            If conn.State = ConnectionState.Open Then conn.Close()
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] EditSupply - Error returning borrowed_items: " & ex.Message)
                    End Try
                End If

                MessageBox.Show("Supply updated successfully!" & If(assignedTo.HasValue AndAlso assignedTo.Value > 0, Environment.NewLine & "The supply will appear in the assigned user's 'My Borrowed Items'.", ""), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
