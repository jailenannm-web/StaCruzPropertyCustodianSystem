# 🎯 CODE EXAMPLES FOR PRESENTATION - PART 1: CRUD OPERATIONS
## Focus: YOUR VB.NET CODE (Not Just SQL!)

---

## 📚 **CRITERION 4: CRUD OPERATIONS (5/5 Points)**

Your system has COMPLETE CRUD operations with error handling in VB.NET code!

---

### **🔵 CREATE EXAMPLE 1: Add Property**

#### **WHERE TO FIND:**
- **Form:** `Forms/Admin/AddProperty.vb` 
- **Button Click:** Line 191-261
- **Database Function:** `modDB.Extensions.vb` Line 362-473

#### **THE ACTUAL CODE FROM YOUR SYSTEM:**

**Step 1: User clicks Save Button (AddProperty.vb)**
```vb
Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    ' Validate required fields
    If Not ValidateInputs() Then
        Return
    End If

    Try
        ' Get values from form controls
        Dim itemName As String = txtItemName.Text.Trim()
        Dim category As String = If(cboCategory.SelectedIndex >= 0, cboCategory.SelectedItem.ToString(), "")
        Dim serialNumber As String = txtSerialNumber.Text.Trim()
        Dim quantity As Integer = CInt(txtQuantity.Value)
        Dim acquisitionCost As Decimal = txtAcquisitionCost.Value
        Dim acquisitionDate As Date = dtpAcquisitionDate.Value
        
        ' Get department ID from dropdown
        Dim departmentId As Integer? = Nothing
        If cboDepartment.SelectedValue IsNot Nothing AndAlso Not cboDepartment.SelectedValue.Equals(DBNull.Value) Then
            departmentId = CInt(cboDepartment.SelectedValue)
        End If

        ' Get assigned user ID
        Dim assignedTo As Integer? = Nothing
        If cboAssignedTo.SelectedValue IsNot Nothing AndAlso Not cboAssignedTo.SelectedValue.Equals(DBNull.Value) Then
            assignedTo = CInt(cboAssignedTo.SelectedValue)
        End If

        ' ⭐ Call database function to INSERT property
        Dim success As Boolean = modDB.AddProperty(
            itemName, category, description, unitOfMeasure,
            propertyNumber, serialNumber, acquisitionDate, acquisitionCost,
            totalCost, sourceOfFunds, assignedTo, departmentId,
            location, condition, status, internalCodes
        )

        If success Then
            MessageBox.Show("Property added successfully with auto-generated Property Number!", 
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearForm()
        Else
            MessageBox.Show("Failed to add property.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    Catch ex As Exception
        ' ⭐ ERROR HANDLING - Never crashes!
        MessageBox.Show("Error saving property: " & ex.Message, 
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

**Step 2: Database INSERT (modDB.Extensions.vb Line 362-473)**
```vb
Public Shared Function AddProperty(itemName As String, category As String, ...) As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        If conn Is Nothing Then Return False
        If Not SafeOpenConnection(conn) Then Return False
        
        ' ⭐ START TRANSACTION (ensures data integrity)
        transaction = conn.BeginTransaction()
        
        ' ⭐ Auto-generate propertyNumber if empty
        If String.IsNullOrWhiteSpace(propertyNumber) Then
            propertyNumber = GeneratePropertyNumber(conn, transaction)
        End If
        
        ' Auto-generate internalCodes if empty
        If String.IsNullOrWhiteSpace(internalCodes) Then
            internalCodes = GenerateInternalCode(conn, transaction)
        End If
        
        ' ⭐ Build INSERT query with parameterized values (prevents SQL injection)
        Dim query As String = "INSERT INTO properties (itemName, category, description, " &
                             "propertyNumber, serialNumber, acquisitionDate, acquisitionCost, " &
                             "assignedTo, departmentId, location, `condition`, status, internalCodes, " &
                             "createdAt, updatedAt) " &
                             "VALUES (@itemName, @category, @description, " &
                             "@propertyNumber, @serialNumber, @acquisitionDate, @acquisitionCost, " &
                             "@assignedTo, @departmentId, @location, @condition, @status, @internalCodes, " &
                             "NOW(), NOW())"
        
        Dim newPropertyId As Integer = 0
        Using cmd As New MySqlCommand(query, conn, transaction)
            ' ⭐ Add parameters (prevents SQL injection)
            cmd.Parameters.AddWithValue("@itemName", itemName)
            cmd.Parameters.AddWithValue("@category", category)
            cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(description), DBNull.Value, description))
            cmd.Parameters.AddWithValue("@propertyNumber", propertyNumber)
            cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrWhiteSpace(serialNumber), DBNull.Value, serialNumber))
            cmd.Parameters.AddWithValue("@acquisitionDate", acquisitionDate)
            cmd.Parameters.AddWithValue("@acquisitionCost", acquisitionCost)
            cmd.Parameters.AddWithValue("@assignedTo", If(assignedTo.HasValue, assignedTo.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@location", location)
            cmd.Parameters.AddWithValue("@condition", condition)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@internalCodes", internalCodes)
            
            ' ⭐ Execute INSERT
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected <= 0 Then
                transaction.Rollback()
                Return False
            End If
            
            ' Get the newly inserted property ID
            Using idCmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction)
                newPropertyId = Convert.ToInt32(idCmd.ExecuteScalar())
            End Using
        End Using
        
        ' ⭐ If property is assigned to user, create borrowed_items record
        If assignedTo.HasValue AndAlso assignedTo.Value > 0 Then
            CreateBorrowedItemRecord(conn, transaction, newPropertyId, assignedTo.Value, departmentId, itemName, propertyNumber, serialNumber)
        End If
        
        ' ⭐ COMMIT TRANSACTION - All operations succeeded!
        transaction.Commit()
        Return True
        
    Catch ex As Exception
        ' ⭐ ERROR HANDLING - Rollback if anything fails
        If transaction IsNot Nothing Then
            Try
                transaction.Rollback()  ' ← Undo all changes
            Catch
            End Try
        End If
        System.Diagnostics.Debug.WriteLine("[v0] AddProperty Exception: " & ex.Message)
        Return False
    Finally
        ' ⭐ CLEANUP - Always close connections
        If transaction IsNot Nothing Then transaction.Dispose()
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
        End If
    End Try
End Function
```

**⭐ KEY POINTS TO SHOW IN PRESENTATION:**
1. **Validation** - Form validates before database insert
2. **Parameterized Queries** - Prevents SQL injection
3. **Transaction** - BeginTransaction() ensures all-or-nothing
4. **Auto-Generation** - PropertyNumber auto-created
5. **Error Handling** - Try-Catch-Finally with Rollback
6. **Cleanup** - Always closes connections in Finally

---

### **🔵 READ EXAMPLE 1: Get All Properties (with JOIN!)**

#### **WHERE TO FIND:**
- **Database Function:** `modDB.vb` Line 8017-8100
- **Used In:** `Forms/Admin/UC_PropertyManagement1.vb` Line 352

#### **THE ACTUAL CODE:**

```vb
Public Shared Function GetAllProperties(Optional custodianID As Integer? = Nothing, 
                                       Optional conditionStatus As String = "",
                                       Optional category As String = "", 
                                       Optional location As String = "",
                                       Optional status As String = "") As DataTable
    Dim dt As New DataTable()
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If conn Is Nothing Then Return dt
        If Not SafeOpenConnection(conn) Then Return dt

        ' ⭐ BUILD COMPLEX JOIN QUERY
        Dim query As New StringBuilder()
        query.Append("SELECT p.*, ")
        query.Append("CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS assignedEmployee, ")
        query.Append("d.departmentName, d.location AS deptLocation ")
        query.Append("FROM properties p ")
        query.Append("LEFT JOIN users u ON p.assignedTo = u.userId ")  ' ⭐ JOIN to get employee name
        query.Append("LEFT JOIN departments d ON p.departmentId = d.departmentId ")  ' ⭐ JOIN to get department
        query.Append("WHERE 1=1 ")

        ' ⭐ Dynamic filters
        If custodianID.HasValue Then query.Append(" AND p.assignedTo = @custodianID ")
        If Not String.IsNullOrEmpty(conditionStatus) Then query.Append(" AND p.condition = @condition ")
        If Not String.IsNullOrEmpty(category) Then query.Append(" AND p.category = @category ")
        If Not String.IsNullOrEmpty(status) Then query.Append(" AND p.status = @status ")
        
        query.Append(" ORDER BY p.itemName ASC")

        Using cmd As New MySqlCommand(query.ToString(), conn)
            ' ⭐ Add parameters for filters
            If custodianID.HasValue Then cmd.Parameters.AddWithValue("@custodianID", custodianID.Value)
            If Not String.IsNullOrEmpty(conditionStatus) Then cmd.Parameters.AddWithValue("@condition", conditionStatus)
            If Not String.IsNullOrEmpty(category) Then cmd.Parameters.AddWithValue("@category", category)
            If Not String.IsNullOrEmpty(status) Then cmd.Parameters.AddWithValue("@status", status)

            ' ⭐ Fill DataTable with results
            Using adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        
        System.Diagnostics.Debug.WriteLine($"[v0] GetAllProperties - Retrieved {dt.Rows.Count} properties")
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties Exception: " & ex.Message)
    Finally
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
        End If
    End Try
    Return dt
End Function
```

**HOW IT'S USED IN THE FORM:**
```vb
' From UC_PropertyManagement1.vb Line 352
Public Sub LoadPropertiesData()
    Try
        propertyManagementGrid.Rows.Clear()
        
        ' Get filter values
        Dim categoryFilter As String = ""
        Dim statusFilter As String = ""
        
        ' ⭐ Call the database function
        Dim dt As DataTable = modDB.GetAllProperties(Nothing, conditionFilter, categoryFilter, Nothing, statusFilter)
        
        ' ⭐ Populate grid with data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim propID As Integer = CInt(row("propertyId"))
                Dim itemName As String = row("itemName").ToString()
                Dim assignedTo As String = row("assignedEmployee").ToString()  ' ← From JOIN!
                Dim department As String = row("departmentName").ToString()     ' ← From JOIN!
                
                propertyManagementGrid.Rows.Add(propID, itemName, category, description, assignedTo, location, condition, status)
            Next
        End If
    Catch ex As Exception
        MessageBox.Show("Error loading properties: " & ex.Message)
    End Try
End Sub
```

**⭐ KEY POINTS:**
1. **LEFT JOIN** - Combines 3 tables (properties, users, departments)
2. **CONCAT** - Builds full name from firstName + lastName
3. **Dynamic Filters** - Adds WHERE clauses based on parameters
4. **Parameterized** - All user inputs use @parameters
5. **DataTable** - Returns structured data for grid

---

### **🔵 UPDATE EXAMPLE 1: Edit Supply**

#### **WHERE TO FIND:**
- **Form:** `Forms/Admin/EditSupply.vb` Line 360-424
- **Button Click:** btnSave_Click event

#### **THE ACTUAL CODE:**

```vb
Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    Try
        ' ⭐ Get values from form
        Dim itemName As String = txtItemName.Text.Trim()
        Dim category As String = cboCategory.SelectedItem.ToString()
        Dim quantity As Integer = CInt(numQuantity.Value)
        Dim unitCost As Decimal = numUnitCost.Value
        
        Dim assignedTo As Integer? = Nothing
        If cboAssignedTo.SelectedValue IsNot Nothing Then
            assignedTo = CInt(cboAssignedTo.SelectedValue)
        End If

        ' ⭐ BUILD UPDATE QUERY
        Dim updateQuery As String = "UPDATE supplies SET " &
                                    "itemName = @itemName, " &
                                    "category = @category, " &
                                    "description = @description, " &
                                    "quantity = @quantity, " &
                                    "unitCost = @unitCost, " &
                                    "totalCost = @totalCost, " &
                                    "assignedTo = @assignedTo, " &
                                    "location = @location, " &
                                    "stockStatus = @stockStatus, " &
                                    "updatedAt = NOW() " &
                                    "WHERE supplyId = @supplyId"

        ' ⭐ Execute UPDATE
        Dim success As Boolean = modDB.UpdateSupply(SupplyIDValue, itemName, category, description, 
                                                     unitOfMeasure, quantity, dateReceived, unitCost, 
                                                     totalCost, supplier, sourceOfFunds, location, 
                                                     stockStatus, assignedTo)

        If success Then
            ' ⭐ If assignment changed, update borrowed_items table
            If assignedTo.HasValue AndAlso assignedTo.Value > 0 Then
                ' Check if borrowed_items record exists
                Using conn As MySqlConnection = modDB.GetConnection()
                    If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                        ' Update or create borrowed_items record
                        Dim updateBorrowQuery As String = 
                            "UPDATE borrowed_items bi " &
                            "JOIN users u ON u.userId = @userId " &
                            "SET bi.borrowerName = CONCAT(u.firstName, ' ', u.lastName), " &
                            "bi.borrowerPosition = u.position, " &
                            "bi.departmentId = u.departmentId, " &
                            "bi.updatedAt = NOW() " &
                            "WHERE bi.itemType = 'supply' AND bi.itemId = @supplyId"
                        
                        Using updateCmd As New MySqlCommand(updateBorrowQuery, conn)
                            updateCmd.Parameters.AddWithValue("@userId", assignedTo.Value)
                            updateCmd.Parameters.AddWithValue("@supplyId", SupplyIDValue)
                            updateCmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End If

            MessageBox.Show("Supply updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBackToList()
        End If
    Catch ex As Exception
        MessageBox.Show("Error updating supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

**⭐ KEY POINTS:**
1. **UPDATE Statement** - Modifies existing record
2. **WHERE Clause** - Only updates specific supplyId
3. **Related Table Update** - Also updates borrowed_items if assignment changed
4. **updatedAt** - Automatically tracks last modification time
5. **Error Handling** - Try-Catch with user feedback

---

### **🔵 DELETE EXAMPLE 1: Delete Supply**

#### **WHERE TO FIND:**
- **Form:** `Forms/Admin/UC_SupplyManagement.vb` Line 641-699
- **Button Click:** btnDelete_Click event

#### **THE ACTUAL CODE:**

```vb
Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    ' ⭐ STEP 1: Validate selection
    If pm_table.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a supply to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
    
    ' ⭐ STEP 2: Get supplyID from grid
    Dim supplyID As Integer
    If Not Integer.TryParse(selectedRow.Cells(0).Value.ToString(), supplyID) Then
        MessageBox.Show("Invalid supply ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return
    End If

    ' Get supply name for confirmation message
    Dim supplyName As String = If(selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells(1).Value.ToString(), "Unknown")

    ' ⭐ STEP 3: Confirmation dialog (important for DELETE!)
    Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to delete supply '" & supplyName & "' (ID: " & supplyID.ToString() & ")?",
        "Confirm Delete",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    )

    If result = DialogResult.Yes Then
        Try
            ' ⭐ STEP 4: Call database DELETE function
            Dim success As Boolean = modDB.DeleteSupply(supplyID)
            
            If success Then
                ' ⭐ STEP 5: Refresh grid to show updated data
                LoadSuppliesData()
                MessageBox.Show("Supply deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to delete supply. It may be in use.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End If
End Sub
```

**DATABASE DELETE FUNCTION (modDB.vb):**
```vb
Public Shared Function DeleteSupply(supplyId As Integer) As Boolean
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If Not SafeOpenConnection(conn) Then Return False

        ' ⭐ Simple DELETE query
        Dim query As String = "DELETE FROM supplies WHERE supplyId = @supplyId"
        
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@supplyId", supplyId)
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            Return rowsAffected > 0  ' ← Returns True if deleted
        End Using
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("DeleteSupply Error: " & ex.Message)
        Return False
    Finally
        If conn IsNot Nothing Then conn.Close()
    End Try
End Function
```

**⭐ KEY POINTS:**
1. **Confirmation Dialog** - Prevents accidental deletion
2. **Parameterized Query** - Uses @supplyId to prevent SQL injection
3. **Rows Affected Check** - Verifies deletion succeeded
4. **Grid Refresh** - Calls LoadSuppliesData() to update display
5. **Error Handling** - Shows specific error messages

---

## 🎯 **PRESENTATION DEMO SCRIPT FOR CRUD:**

**Say:** "Let me demonstrate our CRUD operations with actual code..."

1. **CREATE:** "Open AddProperty form, fill data, click Save"
   - Show `AddProperty.vb` Line 191: "Here's the button click event"
   - Show `modDB.Extensions.vb` Line 362: "This inserts to database with transaction"
   - Point out: "BeginTransaction... Commit... Rollback on error"

2. **READ:** "This grid shows all properties"
   - Show `modDB.vb` Line 8046: "Look at this query - LEFT JOIN to 3 tables!"
   - Show result: "See employee names and departments? That's from the JOIN"

3. **UPDATE:** "Edit a supply and change the assigned person"
   - Show `EditSupply.vb` Line 360: "UPDATE query with parameters"
   - Show: "Also updates borrowed_items table automatically"

4. **DELETE:** "Try to delete a supply"
   - Show confirmation dialog: "Prevents accidents"
   - Show `modDB.vb`: "Simple DELETE with WHERE clause"

**Final Statement:** "All CRUD operations have Try-Catch error handling and never crash the app!"

---

**Continue to PART 2 for Complex Queries and Transactions...**
