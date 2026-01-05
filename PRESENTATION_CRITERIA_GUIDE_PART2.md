# PRESENTATION CRITERIA GUIDE - PART 2
## Property Custodian System - Functionality Criteria

---

## ⚙️ FUNCTIONALITY CRITERIA

### **CRITERION 4: CRUD Operations**
**Score: 5/5** (All CRUD operations without errors!)

#### **What is CRUD?**
- **C**reate - Add new records
- **R**ead - Retrieve/view records
- **U**pdate - Modify existing records
- **D**elete - Remove records

---

#### **Example 1: CREATE - Add Property**

**File:** `Forms/Admin/AddProperty.vb` (Lines 191-261)

**The Code:**
```vb
Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    ' Validate required fields
    If Not ValidateInputs() Then
        Return
    End If

    Try
        ' Get values from form
        Dim itemName As String = txtItemName.Text.Trim()
        Dim category As String = cboCategory.SelectedItem.ToString()
        Dim serialNumber As String = txtSerialNumber.Text.Trim()
        Dim description As String = txtDescription.Text.Trim()
        Dim quantity As Integer = CInt(txtQuantity.Value)
        Dim condition As String = cboCondition.SelectedItem.ToString()
        Dim acquisitionCost As Decimal = txtAcquisitionCost.Value
        Dim acquisitionDate As Date = dtpAcquisitionDate.Value
        
        ' Get department and assigned user IDs
        Dim departmentId As Integer? = Nothing
        If cboDepartment.SelectedValue IsNot Nothing Then
            departmentId = CInt(cboDepartment.SelectedValue)
        End If
        
        Dim assignedTo As Integer? = Nothing
        If cboAssignedTo.SelectedValue IsNot Nothing Then
            assignedTo = CInt(cboAssignedTo.SelectedValue)
        End If
        
        ' Insert property into database
        Dim success As Boolean = modDB.AddProperty(
            itemName, category, description, unitOfMeasure,
            propertyNumber, serialNumber, acquisitionDate, 
            acquisitionCost, totalCost, sourceOfFunds, 
            assignedTo, departmentId, location, condition, status
        )

        If success Then
            MessageBox.Show("Property added successfully!", 
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearForm()
        End If
    Catch ex As Exception
        MessageBox.Show("Error saving property: " & ex.Message, 
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

**Database Function:** `modDB.Extensions.vb` (Lines 362-473)
```vb
Public Shared Function AddProperty(itemName As String, category As String, ...) As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        transaction = conn.BeginTransaction()
        
        ' Auto-generate propertyNumber if empty
        If String.IsNullOrWhiteSpace(propertyNumber) Then
            propertyNumber = GeneratePropertyNumber(conn, transaction)
        End If
        
        ' Insert property into database
        Dim query As String = "INSERT INTO properties (itemName, category, description, " & _
                             "acquisitionCost, assignedTo, departmentId, location, status) " & _
                             "VALUES (@itemName, @category, @description, @cost, @assignedTo, " & _
                             "@departmentId, @location, @status)"
        
        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@itemName", itemName)
            cmd.Parameters.AddWithValue("@category", category)
            cmd.Parameters.AddWithValue("@description", description)
            cmd.Parameters.AddWithValue("@cost", acquisitionCost)
            cmd.Parameters.AddWithValue("@assignedTo", If(assignedTo.HasValue, assignedTo.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@location", location)
            cmd.Parameters.AddWithValue("@status", status)
            
            cmd.ExecuteNonQuery()
        End Using
        
        transaction.Commit()
        Return True
    Catch ex As Exception
        If transaction IsNot Nothing Then transaction.Rollback()
        Return False
    End Try
End Function
```

**Error Handling:** Try-Catch blocks prevent crashes, rollback on failure

---

#### **Example 2: READ - Get All Properties (with JOINs!)**

**File:** `modDB.vb` (Lines 2964-3020)

**The Code:**
```vb
Public Shared Function GetAllProperties(Optional departmentID As Integer? = Nothing,
                                       Optional condition As String = "",
                                       Optional category As String = "",
                                       Optional location As String = "",
                                       Optional status As String = "") As DataTable
    Dim dt As New DataTable()
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If Not SafeOpenConnection(conn) Then Return dt

        ' Complex JOIN query to get related data
        Dim query As String = "SELECT p.*, " &
                             "CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) as assignedEmployee, " &
                             "d.departmentName, d.location as deptLocation " &
                             "FROM properties p " &
                             "LEFT JOIN users u ON p.assignedTo = u.userId " &
                             "LEFT JOIN departments d ON p.departmentId = d.departmentId " &
                             "WHERE 1=1 "

        ' Apply filters dynamically
        If departmentID.HasValue Then
            query &= " AND p.departmentId = @departmentID"
        End If
        If Not String.IsNullOrEmpty(condition) Then
            query &= " AND p.condition = @condition"
        End If
        If Not String.IsNullOrEmpty(category) Then
            query &= " AND p.category = @category"
        End If
        If Not String.IsNullOrEmpty(status) Then
            query &= " AND p.status = @status"
        End If
        
        query &= " ORDER BY p.itemName ASC"

        Using cmd As New MySqlCommand(query, conn)
            If departmentID.HasValue Then 
                cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)
            End If
            If Not String.IsNullOrEmpty(condition) Then 
                cmd.Parameters.AddWithValue("@condition", condition)
            End If
            If Not String.IsNullOrEmpty(category) Then 
                cmd.Parameters.AddWithValue("@category", category)
            End If
            If Not String.IsNullOrEmpty(status) Then 
                cmd.Parameters.AddWithValue("@status", status)
            End If

            Using adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
    Catch ex As Exception
        Debug.WriteLine("GetAllProperties Error: " & ex.Message)
    Finally
        If conn IsNot Nothing Then conn.Close()
    End Try
    Return dt
End Function
```

**Used in:** `Forms/Admin/UC_PropertyManagement1.vb` (Line 352)

---

#### **Example 3: UPDATE - Edit Property**

**File:** `modDB.Extensions.vb` (Lines 530-654)

**The Code:**
```vb
Public Shared Function UpdateProperty(propertyId As Integer,
                                     itemName As String,
                                     category As String,
                                     description As String,
                                     condition As String,
                                     location As String,
                                     custodianId As Integer?,
                                     departmentId As Integer?,
                                     status As String) As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        transaction = conn.BeginTransaction()
        
        ' Get current assignedTo value before update
        Dim oldAssignedTo As Integer? = Nothing
        Using checkCmd As New MySqlCommand("SELECT assignedTo FROM properties WHERE propertyId = @propertyId", conn, transaction)
            checkCmd.Parameters.AddWithValue("@propertyId", propertyId)
            Using reader As MySqlDataReader = checkCmd.ExecuteReader()
                If reader.Read() AndAlso Not reader.IsDBNull(0) Then
                    oldAssignedTo = reader.GetInt32(0)
                End If
            End Using
        End Using
        
        ' Update property
        Dim query As String = "UPDATE properties SET " &
                             "itemName = @itemName, " &
                             "category = @category, " &
                             "description = @description, " &
                             "condition = @condition, " &
                             "location = @location, " &
                             "assignedTo = @assignedTo, " &
                             "departmentId = @departmentId, " &
                             "status = @status, " &
                             "updatedAt = NOW() " &
                             "WHERE propertyId = @propertyId"
        
        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@propertyId", propertyId)
            cmd.Parameters.AddWithValue("@itemName", itemName)
            cmd.Parameters.AddWithValue("@category", category)
            cmd.Parameters.AddWithValue("@description", description)
            cmd.Parameters.AddWithValue("@condition", condition)
            cmd.Parameters.AddWithValue("@location", location)
            cmd.Parameters.AddWithValue("@assignedTo", If(custodianId.HasValue, custodianId.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@status", status)
            
            cmd.ExecuteNonQuery()
        End Using
        
        ' Handle borrowed_items changes if assignment changed
        If oldAssignedTo <> custodianId Then
            ' Update borrowed_items table accordingly
            ' (See full code for borrowed items management)
        End If
        
        transaction.Commit()
        Return True
    Catch ex As Exception
        If transaction IsNot Nothing Then transaction.Rollback()
        Debug.WriteLine("UpdateProperty Error: " & ex.Message)
        Return False
    End Try
End Function
```

**Called from:** `Forms/Admin/EditPropertyManagement.vb` (btnSave_Click)

---

#### **Example 4: DELETE - Remove Property**

**File:** `Forms/Admin/UC_PropertyManagement1.vb` (Lines 754-810)

**The Code:**
```vb
Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    ' Validate selection
    If propertyManagementGrid.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a property to delete.", 
                       "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    Dim row As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
    Dim propertyID As Integer
    
    ' Get property ID from row Tag
    If row.Tag Is Nothing OrElse Not Integer.TryParse(row.Tag.ToString(), propertyID) Then
        MessageBox.Show("Invalid Property ID.", "Error", 
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return
    End If

    ' Confirm deletion
    Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to delete this property?" & vbCrLf &
        "This action cannot be undone.", 
        "Confirm Delete",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    )

    If result = DialogResult.Yes Then
        Try
            ' Call database delete function
            Dim success As Boolean = modDB.DeleteProperty(propertyID)
            
            If success Then
                MessageBox.Show("Property deleted successfully!", 
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                ' Reload data grid
                LoadPropertiesData()
            Else
                MessageBox.Show("Failed to delete property.", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting property: " & ex.Message, 
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End If
End Sub
```

**Database Function:** `modDB.vb`
```vb
Public Shared Function DeleteProperty(propertyId As Integer) As Boolean
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If Not SafeOpenConnection(conn) Then Return False

        Dim query As String = "DELETE FROM properties WHERE propertyId = @propertyId"
        
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@propertyId", propertyId)
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            Return rowsAffected > 0
        End Using
    Catch ex As Exception
        Debug.WriteLine("DeleteProperty Error: " & ex.Message)
        Return False
    Finally
        If conn IsNot Nothing Then conn.Close()
    End Try
End Function
```

---

#### **Example 5: CRUD for Supplies**

**CREATE:** `Forms/Admin/AddSupply.vb` → `modDB.AddSupply()`
**READ:** `Forms/Admin/UC_SupplyManagement.vb` → `modDB.GetAllSupplies()`
**UPDATE:** `Forms/Admin/EditSupply.vb` (Line 364+) → `modDB.UpdateSupply()`
**DELETE:** `Forms/Admin/UC_SupplyManagement.vb` → `modDB.DeleteSupply()`

All follow same pattern with error handling!

---

### **CRITERION 5: Queries (Complex JOINs)**
**Score: 5/5** (Multiple 5-table JOIN queries!)

#### **Example 1: 5-TABLE JOIN - Custodian Assignment Report**

**File:** `modDB.vb` (Lines 8613-8615)

**The Query:**
```vb
Public Shared Function GetCustodianAssignments() As DataTable
    Dim query As String = 
        "SELECT " &
        "c.custodianId, " &
        "c.itemType, " &
        "c.itemId, " &
        "CONCAT(u.firstName, ' ', u.lastName) AS custodianName, " &
        "u.employeeId, " &
        "d.departmentName, " &
        "CASE " &
        "  WHEN c.itemType = 'property' THEN p.itemName " &
        "  WHEN c.itemType = 'supply' THEN s.itemName " &
        "  ELSE NULL " &
        "END AS itemName, " &
        "CASE " &
        "  WHEN c.itemType = 'property' THEN p.propertyNumber " &
        "  ELSE NULL " &
        "END AS propertyNumber " &
        "FROM custodian c " &
        "LEFT JOIN users u ON c.userId = u.userId " &
        "LEFT JOIN properties p ON c.itemId = p.propertyId AND c.itemType = 'property' " &
        "LEFT JOIN supplies s ON c.itemId = s.supplyId AND c.itemType = 'supply' " &
        "LEFT JOIN departments d ON c.departmentId = d.departmentId " &
        "ORDER BY custodianName, c.itemType, itemName"
End Function
```

**Tables Joined:**
1. `custodian` (main table)
2. `users` (get custodian name)
3. `properties` (if item is property)
4. `supplies` (if item is supply)
5. `departments` (get department name)

**Why Complex:** Polymorphic relationship - item can be property OR supply

---

#### **Example 2: 4-TABLE JOIN - Requisition Report**

**File:** `modDB.vb` (Lines 602-605)

**The Query:**
```vb
Dim query As String = 
    "SELECT " &
    "pr.requestId, " &
    "pr.requestType, " &
    "pr.requestDate, " &
    "pr.status, " &
    "CONCAT(sa.firstName, ' ', sa.lastName) AS requesterName, " &
    "d.departmentName, " &
    "COALESCE(p.itemName, sup.itemName) AS itemName, " &
    "pr.quantity " &
    "FROM property_requests pr " &
    "INNER JOIN users sa ON pr.userId = sa.userId " &
    "LEFT JOIN departments d ON sa.departmentId = d.departmentId " &
    "LEFT JOIN properties p ON pr.property_id = p.propertyId " &
    "LEFT JOIN supplies sup ON pr.supply_id = sup.supplyId " &
    "WHERE pr.status IN ('Approved', 'Released') " &
    "ORDER BY pr.requestDate DESC"
```

**Tables Joined:**
1. `property_requests` (main)
2. `users` (requester info)
3. `departments` (department details)
4. `properties` OR `supplies` (item details)

---

#### **Example 3: 3-TABLE JOIN - Maintenance Reports**

**File:** `modDB.vb` (Lines 5125-5126)

**The Query:**
```vb
Dim query As String = 
    "SELECT " &
    "mr.requestId, " &
    "mr.issueDescription, " &
    "mr.requestDate, " &
    "mr.status, " &
    "CONCAT(u.firstName, ' ', u.lastName) AS requestedBy, " &
    "d.departmentName " &
    "FROM maintenance_requests mr " &
    "LEFT JOIN users u ON mr.requestedBy = u.userId " &
    "LEFT JOIN departments d ON mr.departmentId = d.departmentId " &
    "WHERE mr.status != 'Cancelled' " &
    "ORDER BY mr.requestDate DESC"
```

**Tables Joined:**
1. `maintenance_requests`
2. `users`
3. `departments`

---

#### **Example 4: UNION with Multiple JOINs**

**File:** `modDB.vb` (Lines 544-558)

**The Query:**
```vb
Dim query As String = 
    "SELECT " &
    "u.userId, " &
    "CONCAT(u.firstName, ' ', u.lastName) AS custodianName, " &
    "d.departmentName, " &
    "p.itemName AS assetName, " &
    "p.category AS assetCategory, " &
    "'Property' AS assetType, " &
    "p.acquisitionCost AS value " &
    "FROM users u " &
    "INNER JOIN properties p ON u.userId = p.assignedTo " &
    "LEFT JOIN departments d ON u.departmentId = d.departmentId " &
    "WHERE p.assignedTo IS NOT NULL " &
    "UNION ALL " &
    "SELECT " &
    "u.userId, " &
    "CONCAT(u.firstName, ' ', u.lastName) AS custodianName, " &
    "d.departmentName, " &
    "s.itemName AS assetName, " &
    "s.category AS assetCategory, " &
    "'Supply' AS assetType, " &
    "s.unitCost AS value " &
    "FROM users u " &
    "INNER JOIN supplies s ON u.userId = s.assignedTo " &
    "LEFT JOIN departments d ON u.departmentId = d.departmentId " &
    "WHERE s.assignedTo IS NOT NULL " &
    "ORDER BY custodianName, assetType"
```

**Why Complex:** Combines property and supply data using UNION

---

#### **Example 5: Dashboard Analytics Query**

**File:** `Forms/Admin/AdminDashboard.vb`

**The Query:**
```vb
' Get property count by status with department info
Dim query As String = 
    "SELECT " &
    "p.status, " &
    "COUNT(*) AS count, " &
    "d.departmentName, " &
    "SUM(p.acquisitionCost) AS totalValue " &
    "FROM properties p " &
    "LEFT JOIN departments d ON p.departmentId = d.departmentId " &
    "GROUP BY p.status, d.departmentName " &
    "ORDER BY count DESC"
```

**Uses:** JOIN + GROUP BY + aggregate functions

---

### **CRITERION 6: Transactions**
**Score: 10/10** (5 × 2 = doubled score!)

#### **What is a Transaction?**
- Multiple database operations treated as ONE unit
- Either ALL succeed or ALL fail (rollback)
- Ensures data integrity

---

#### **Example 1: Property Approval Transaction**

**File:** `modDB.Extensions.vb` (Lines 710-750)

**The Code:**
```vb
Private Shared Function ApprovePropertyRequest_Extensions(requestId As Integer, ...) As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        transaction = conn.BeginTransaction()  ' ← START TRANSACTION
        
        ' STEP 1: Update property_requests status to Approved
        Dim updateRequestQuery As String = 
            "UPDATE property_requests SET " &
            "status = 'Approved', " &
            "approvedBy = @adminId, " &
            "approvedDate = NOW() " &
            "WHERE requestId = @requestId"
        
        Using cmd As New MySqlCommand(updateRequestQuery, conn, transaction)
            cmd.Parameters.AddWithValue("@requestId", requestId)
            cmd.Parameters.AddWithValue("@adminId", adminId)
            cmd.ExecuteNonQuery()
        End Using
        
        ' STEP 2: Update property assignment
        Dim updatePropertyQuery As String = 
            "UPDATE properties SET " &
            "assignedTo = @userId, " &
            "departmentId = @departmentId, " &
            "status = 'Active' " &
            "WHERE propertyId = @propertyId"
        
        Using cmd As New MySqlCommand(updatePropertyQuery, conn, transaction)
            cmd.Parameters.AddWithValue("@propertyId", propertyId)
            cmd.Parameters.AddWithValue("@userId", userId)
            cmd.Parameters.AddWithValue("@departmentId", departmentId)
            cmd.ExecuteNonQuery()
        End Using
        
        ' STEP 3: Create borrowed_items record
        Dim borrowQuery As String = 
            "INSERT INTO borrowed_items (...) VALUES (...)"
        Using cmd As New MySqlCommand(borrowQuery, conn, transaction)
            ' ... parameters ...
            cmd.ExecuteNonQuery()
        End Using
        
        ' STEP 4: Create audit log
        ' AuditLogger.LogAction(...)
        
        transaction.Commit()  ' ← ALL SUCCEED: COMMIT
        Return True
        
    Catch ex As Exception
        If transaction IsNot Nothing Then
            transaction.Rollback()  ' ← ANY FAIL: ROLLBACK ALL
        End If
        Return False
    End Try
End Function
```

**Why Transaction?** If step 2 fails, step 1 automatically rolls back - no partial data!

---

#### **Example 2: Supply Assignment Transaction**

**File:** `modDB.Extensions.vb` (Lines 814-866)

**The Code:**
```vb
Public Shared Function AssignSupplyToUser(supplyId As Integer, userId As Integer, quantity As Integer) As Boolean
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        transaction = conn.BeginTransaction()
        
        ' STEP 1: Check available quantity
        Using checkCmd As New MySqlCommand("SELECT quantity FROM supplies WHERE supplyId = @supplyId", conn, transaction)
            checkCmd.Parameters.AddWithValue("@supplyId", supplyId)
            Dim availableQty As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            
            If availableQty < quantity Then
                transaction.Rollback()
                Return False
            End If
        End Using
        
        ' STEP 2: Deduct quantity from supplies
        Using updateCmd As New MySqlCommand(
            "UPDATE supplies SET quantity = quantity - @qty, assignedTo = @userId WHERE supplyId = @supplyId", 
            conn, transaction)
            updateCmd.Parameters.AddWithValue("@qty", quantity)
            updateCmd.Parameters.AddWithValue("@userId", userId)
            updateCmd.Parameters.AddWithValue("@supplyId", supplyId)
            updateCmd.ExecuteNonQuery()
        End Using
        
        ' STEP 3: Create borrowed_items record
        Dim borrowQuery As String = "INSERT INTO borrowed_items (...) VALUES (...)"
        Using borrowCmd As New MySqlCommand(borrowQuery, conn, transaction)
            ' ... insert tracking record ...
            borrowCmd.ExecuteNonQuery()
        End Using
        
        transaction.Commit()
        Return True
        
    Catch ex As Exception
        If transaction IsNot Nothing Then transaction.Rollback()
        Return False
    End Try
End Function
```

**Why Transaction?** Ensures quantity is deducted AND borrowed_items created together

---

#### **Example 3: User Creation with Audit**

**File:** `Forms/SuperAdmin/UserManagement/AddUser.vb`

```vb
Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = modDB.GetConnection()
        transaction = conn.BeginTransaction()
        
        ' STEP 1: Insert new user
        Dim insertQuery As String = "INSERT INTO users (...) VALUES (...)"
        Dim newUserId As Integer = 0
        Using cmd As New MySqlCommand(insertQuery, conn, transaction)
            ' ... parameters ...
            cmd.ExecuteNonQuery()
            newUserId = cmd.LastInsertedId
        End Using
        
        ' STEP 2: Log creation in audit_logs
        AuditLogger.LogCreate(SessionContext.CurrentUserId, "users", newUserId, 
                             "Created new user: " & username, SessionContext.CurrentRole)
        
        transaction.Commit()
        MessageBox.Show("User created successfully!")
        
    Catch ex As Exception
        If transaction IsNot Nothing Then transaction.Rollback()
        MessageBox.Show("Error creating user: " & ex.Message)
    End Try
End Sub
```

**Why Transaction?** User creation and audit log must both succeed

---

#### **Example 4: Return Item Transaction**

**File:** `modDB.Extensions.vb` (Lines 607-618)

```vb
Public Shared Function ReturnBorrowedItem(borrowedId As Integer) As Boolean
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        transaction = conn.BeginTransaction()
        
        ' STEP 1: Update borrowed_items status
        Using returnCmd As New MySqlCommand(
            "UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW() WHERE borrowedId = @id",
            conn, transaction)
            returnCmd.Parameters.AddWithValue("@id", borrowedId)
            returnCmd.ExecuteNonQuery()
        End Using
        
        ' STEP 2: Update property/supply status to Available
        Using statusCmd As New MySqlCommand(
            "UPDATE properties SET status = 'Available', assignedTo = NULL WHERE propertyId = (SELECT itemId FROM borrowed_items WHERE borrowedId = @id)",
            conn, transaction)
            statusCmd.Parameters.AddWithValue("@id", borrowedId)
            statusCmd.ExecuteNonQuery()
        End Using
        
        transaction.Commit()
        Return True
    Catch ex As Exception
        If transaction IsNot Nothing Then transaction.Rollback()
        Return False
    End Try
End Function
```

---

#### **Example 5: Maintenance Completion Transaction**

**File:** `modDB.vb` (Line 290)

```vb
Public Shared Function CompleteMaintenance(maintenanceId As Integer, completionNotes As String) As Boolean
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        transaction = conn.BeginTransaction()
        
        ' STEP 1: Update maintenance record
        Using cmd As New MySqlCommand(
            "UPDATE maintenance SET status = 'Completed', completionDate = NOW(), notes = @notes WHERE maintenanceId = @id",
            conn, transaction)
            cmd.Parameters.AddWithValue("@id", maintenanceId)
            cmd.Parameters.AddWithValue("@notes", completionNotes)
            cmd.ExecuteNonQuery()
        End Using
        
        ' STEP 2: Update property condition
        Using propCmd As New MySqlCommand(
            "UPDATE properties p " &
            "INNER JOIN maintenance m ON p.propertyId = m.propertyId " &
            "SET p.condition = 'Good' " &
            "WHERE m.maintenanceId = @id",
            conn, transaction)
            propCmd.Parameters.AddWithValue("@id", maintenanceId)
            propCmd.ExecuteNonQuery()
        End Using
        
        transaction.Commit()
        Return True
    Catch ex As Exception
        If transaction IsNot Nothing Then transaction.Rollback()
        Return False
    End Try
End Function
```

---

## 📝 PRESENTATION TIPS FOR FUNCTIONALITY

### **How to Present CRUD (Criterion 4):**
1. **Live Demo:** Open AddProperty form, fill it out, click Save
2. **Show Code:** Open `AddProperty.vb` line 191, show btnSave_Click
3. **Show Database Function:** Open `modDB.Extensions.vb` line 362, show AddProperty function
4. **Show Error Handling:** Point to Try-Catch block: "If anything fails, we rollback"
5. **Test Other CRUD:** Edit a property, Delete a property (show confirmation dialog)

### **How to Present Queries (Criterion 5):**
1. **Open modDB.vb** and search for "LEFT JOIN"
2. **Count the tables:** "This query joins 5 tables: custodian, users, properties, supplies, departments"
3. **Show result:** Run the report that uses this query
4. **Explain complexity:** "We use CASE to handle properties OR supplies dynamically"

### **How to Present Transactions (Criterion 6):**
1. **Open code:** `modDB.Extensions.vb` line 710
2. **Highlight structure:**
   - "transaction = conn.BeginTransaction()" - Start
   - "3 database operations in sequence"
   - "transaction.Commit()" - All succeed
   - "Catch block: transaction.Rollback()" - Any fail
3. **Explain benefit:** "If property assignment fails, the approval is automatically undone"
4. **Show live:** Approve a property request and show all tables updated together

---

**Continue to PART 3 for Performance, Security, UI & Additional Features...**
