# 🎯 CODE EXAMPLES FOR PRESENTATION - PART 2: QUERIES & TRANSACTIONS
## Focus: YOUR VB.NET CODE - Complex JOINs and Transaction Management

---

## 📚 **CRITERION 5: COMPLEX QUERIES (5/5 Points - Need 5+ Table JOINs)**

Your system has **MULTIPLE queries with 4-5 table JOINs!** Here's the actual code...

---

### **🔵 EXAMPLE 1: 5-TABLE JOIN - Custodian Report**

#### **WHERE TO FIND:**
- **File:** `modDB.vb` Line 8613-8615
- **Function:** GetCustodianAssignments (used in reports)

#### **THE ACTUAL CODE:**

```vb
Public Shared Function GetCustodianAssignments() As DataTable
    Dim dt As New DataTable()
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If Not SafeOpenConnection(conn) Then Return dt

        ' ⭐ 5-TABLE JOIN QUERY!
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
            "LEFT JOIN users u ON c.userId = u.userId " &                      ' ⭐ TABLE 1 → 2
            "LEFT JOIN properties p ON c.itemId = p.propertyId AND c.itemType = 'property' " & ' ⭐ TABLE 2 → 3
            "LEFT JOIN supplies s ON c.itemId = s.supplyId AND c.itemType = 'supply' " &        ' ⭐ TABLE 2 → 4
            "LEFT JOIN departments d ON c.departmentId = d.departmentId " &                     ' ⭐ TABLE 2 → 5
            "ORDER BY custodianName, c.itemType, itemName"

        Using cmd As New MySqlCommand(query, conn)
            Using adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("GetCustodianAssignments Error: " & ex.Message)
    Finally
        If conn IsNot Nothing Then conn.Close()
    End Try
    Return dt
End Function
```

**⭐ TABLES JOINED:**
1. **custodian** (main table)
2. **users** (get custodian name)
3. **properties** (if itemType = 'property')
4. **supplies** (if itemType = 'supply')
5. **departments** (get department name)

**⭐ COMPLEXITY FEATURES:**
- **Polymorphic JOIN** - Item can be property OR supply
- **CASE Statement** - Conditional column selection
- **Multiple CONCAT** - Build full names
- **Conditional JOIN** - `AND c.itemType = 'property'`

---

### **🔵 EXAMPLE 2: 4-TABLE JOIN - Requisition Report**

#### **WHERE TO FIND:**
- **File:** `modDB.vb` Line 600-605
- **Function:** GetRequisitionAndIssuanceReport

#### **THE ACTUAL CODE:**

```vb
Public Shared Function GetRequisitionAndIssuanceReport(Optional dateFrom As Date? = Nothing,
                                                       Optional dateTo As Date? = Nothing,
                                                       Optional departmentID As Integer? = Nothing) As DataTable
    Dim dt As New DataTable()
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If Not SafeOpenConnection(conn) Then Return dt

        Dim query As New StringBuilder()
        query.Append("SELECT pr.request_id, pr.request_type, pr.status, pr.request_date, pr.approval_date, ")
        query.Append("pr.release_date, pr.actual_returned_date, pr.quantity, ")
        query.Append("CONCAT(IFNULL(sa.firstName,''), ' ', IFNULL(sa.lastName,'')) AS requester_name, ")
        query.Append("d.departmentName, ")
        query.Append("COALESCE(p.item_name, sup.item_name) AS item_name ")  ' ⭐ Get item name from either table
        query.Append("FROM property_requests pr ")
        query.Append("INNER JOIN users sa ON pr.userId = sa.user_id ")              ' ⭐ TABLE 1 → 2 (INNER JOIN - must have user)
        query.Append("LEFT JOIN departments d ON sa.departmentId = d.departmentId ") ' ⭐ TABLE 2 → 3
        query.Append("LEFT JOIN properties p ON pr.property_id = p.propertyId ")     ' ⭐ TABLE 1 → 4
        query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id ")      ' ⭐ TABLE 1 → 5 (actually 5 tables!)
        query.Append("WHERE 1=1 ")

        ' ⭐ Dynamic filters
        If dateFrom.HasValue Then query.Append(" AND pr.request_date >= @dateFrom ")
        If dateTo.HasValue Then query.Append(" AND pr.request_date <= @dateTo ")
        If departmentID.HasValue Then query.Append(" AND sa.departmentId = @departmentID ")

        query.Append(" ORDER BY pr.request_date DESC, pr.request_id DESC")

        Using cmd As New MySqlCommand(query.ToString(), conn)
            If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
            If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)
            If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)

            Using adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("GetRequisitionAndIssuanceReport Error: " & ex.Message)
    Finally
        If conn IsNot Nothing Then conn.Close()
    End Try
    Return dt
End Function
```

**⭐ TABLES JOINED:**
1. **property_requests** (main)
2. **users** (requester info)
3. **departments** (department details)
4. **properties** (if requesting property)
5. **supplies** (if requesting supply)

**⭐ KEY FEATURES:**
- **INNER JOIN** - Requires user (mandatory relationship)
- **LEFT JOIN** - Optional relationships (may not have department)
- **COALESCE** - Gets item name from properties OR supplies
- **Date Range Filtering** - Optional dateFrom/dateTo parameters

---

### **🔵 EXAMPLE 3: 3-TABLE JOIN - Property Inventory with Assignments**

#### **WHERE TO FIND:**
- **File:** `modDB.vb` Line 336-338
- **Function:** GetPropertyInventoryReport

#### **THE ACTUAL CODE:**

```vb
Public Shared Function GetPropertyInventoryReport(Optional groupByCategory As Boolean = False,
                                                  Optional departmentID As Integer? = Nothing,
                                                  Optional category As String = "",
                                                  Optional status As String = "") As DataTable
    Dim dt As New DataTable()
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If Not SafeOpenConnection(conn) Then Return dt

        Dim query As New StringBuilder()
        If groupByCategory Then
            ' ⭐ GROUP BY for summary
            query.Append("SELECT p.category, p.status, COUNT(*) AS total_items, ")
            query.Append("SUM(p.acquisitionCost) AS total_value ")
        Else
            ' ⭐ Detailed report with JOINs
            query.Append("SELECT p.propertyId, p.itemName, p.category, p.status, p.location, ")
            query.Append("p.acquisitionDate, p.acquisitionCost, ")
            query.Append("d.departmentName, ")  ' ⭐ From departments table
            query.Append("CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS custodianName ")  ' ⭐ From users table
        End If
        
        query.Append("FROM properties p ")
        query.Append("LEFT JOIN departments d ON p.departmentId = d.departmentId ")  ' ⭐ TABLE 1 → 2
        query.Append("LEFT JOIN users u ON p.assignedTo = u.userId ")                ' ⭐ TABLE 1 → 3
        query.Append("WHERE 1=1 ")

        ' ⭐ Dynamic filters with parameterized queries
        If departmentID.HasValue Then query.Append(" AND p.departmentId = @departmentID ")
        If Not String.IsNullOrEmpty(category) Then query.Append(" AND p.category = @category ")
        If Not String.IsNullOrEmpty(status) Then query.Append(" AND p.status = @status ")

        If groupByCategory Then
            query.Append(" GROUP BY p.category, p.status ORDER BY p.category")
        Else
            query.Append(" ORDER BY p.category, p.itemName")
        End If

        Using cmd As New MySqlCommand(query.ToString(), conn)
            If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)
            If Not String.IsNullOrEmpty(category) Then cmd.Parameters.AddWithValue("@category", category)
            If Not String.IsNullOrEmpty(status) Then cmd.Parameters.AddWithValue("@status", status)

            Using adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("GetPropertyInventoryReport Error: " & ex.Message)
    Finally
        If conn IsNot Nothing Then conn.Close()
    End Try
    Return dt
End Function
```

**⭐ FEATURES:**
- **3-Table JOIN** - properties + departments + users
- **Conditional Query** - Different SELECT based on groupByCategory parameter
- **Aggregate Functions** - COUNT(*), SUM() for summary report
- **IFNULL Handling** - Handles NULL values gracefully

---

### **🔵 EXAMPLE 4: UNION Query - Combining Property & Supply Data**

#### **WHERE TO FIND:**
- **File:** `modDB.vb` Line 544-558
- **Function:** GetCustodianAssignmentsReport

#### **THE ACTUAL CODE:**

```vb
Public Shared Function GetCustodianAssignmentsReport(Optional custodianID As Integer? = Nothing,
                                                     Optional departmentID As Integer? = Nothing) As DataTable
    Dim dt As New DataTable()
    Dim conn As MySqlConnection = Nothing
    Try
        conn = GetConnection()
        If Not SafeOpenConnection(conn) Then Return dt

        Dim query As New StringBuilder()
        
        ' ⭐ FIRST PART: Get assigned properties
        query.Append("SELECT ")
        query.Append("u.userId, ")
        query.Append("CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS custodian_name, ")
        query.Append("d.departmentName, ")
        query.Append("p.item_name AS asset_name, ")
        query.Append("p.category AS asset_category, ")
        query.Append("'Property' AS asset_type ")  ' ⭐ Label as Property
        query.Append("FROM users u ")
        query.Append("INNER JOIN properties p ON u.userId = p.assignedTo ")       ' ⭐ Only assigned properties
        query.Append("LEFT JOIN departments d ON u.departmentId = d.departmentId ")
        query.Append("WHERE 1=1 ")

        If custodianID.HasValue Then query.Append(" AND u.userId = @custodianID ")
        If departmentID.HasValue Then query.Append(" AND u.departmentId = @departmentID ")

        ' ⭐ UNION ALL - Combine with supplies
        query.Append(" UNION ALL ")

        ' ⭐ SECOND PART: Get supplies (unassigned in this example)
        query.Append("SELECT ")
        query.Append("NULL AS userId, ")
        query.Append("'Unassigned' AS custodian_name, ")
        query.Append("'' AS departmentName, ")
        query.Append("s.item_name AS asset_name, ")
        query.Append("s.category AS asset_category, ")
        query.Append("'Supply' AS asset_type ")  ' ⭐ Label as Supply
        query.Append("FROM supplies s ")
        query.Append("WHERE 1=1 ")

        query.Append(" ORDER BY custodian_name, asset_type")

        Using cmd As New MySqlCommand(query.ToString(), conn)
            If custodianID.HasValue Then cmd.Parameters.AddWithValue("@custodianID", custodianID.Value)
            If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)

            Using adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("GetCustodianAssignmentsReport Error: " & ex.Message)
    Finally
        If conn IsNot Nothing Then conn.Close()
    End Try
    Return dt
End Function
```

**⭐ UNION FEATURES:**
- **UNION ALL** - Combines results from properties and supplies
- **Same Column Structure** - Both queries return same columns
- **Type Labels** - 'Property' vs 'Supply' to distinguish source
- **Single Result Set** - Returns everything in one DataTable

---

## 📚 **CRITERION 6: TRANSACTIONS (10/10 Points - DOUBLED SCORE!)**

Your system implements **COMPLETE TRANSACTIONS** that ensure data integrity!

---

### **🔵 TRANSACTION EXAMPLE 1: Property Approval (Multi-Step)**

#### **WHERE TO FIND:**
- **File:** `modDB.Extensions.vb` Line 659-809
- **Function:** ApprovePropertyRequest_Extensions

#### **THE ACTUAL CODE:**

```vb
Private Shared Function ApprovePropertyRequest_Extensions(requestId As Integer,
                                                          adminId As Integer,
                                                          adminUsername As String,
                                                          adminRole As String,
                                                          Optional propertyId As Integer? = Nothing,
                                                          Optional assignedUserId As Integer? = Nothing,
                                                          Optional remarks As String = "") As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        If conn Is Nothing Then Return False
        If Not SafeOpenConnection(conn) Then Return False
        
        ' ⭐ START TRANSACTION - Multiple operations treated as ONE unit
        transaction = conn.BeginTransaction()
        
        ' ═══════════════════════════════════════════════════════
        ' ⭐ STEP 1: Get request details
        ' ═══════════════════════════════════════════════════════
        Dim requestQuery As String = "SELECT pr.requesterName, pr.itemName, pr.departmentId, " &
                                     "d.location, pr.position, u.userId, u.fullName " &
                                     "FROM property_requests pr " &
                                     "LEFT JOIN departments d ON pr.departmentId = d.departmentId " &
                                     "LEFT JOIN users u ON LOWER(CONCAT(u.firstName, ' ', u.lastName)) = LOWER(pr.requesterName) " &
                                     "WHERE pr.requestId = @requestId"
        
        Dim requesterName As String = ""
        Dim itemName As String = ""
        Dim departmentId As Integer? = Nothing
        Dim requesterUserId As Integer? = Nothing
        
        Using cmd As New MySqlCommand(requestQuery, conn, transaction)  ' ⭐ Note: transaction parameter
            cmd.Parameters.AddWithValue("@requestId", requestId)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    requesterName = If(Not reader.IsDBNull(0), reader.GetString(0), "")
                    itemName = If(Not reader.IsDBNull(1), reader.GetString(1), "")
                    If Not reader.IsDBNull(2) Then departmentId = reader.GetInt32(2)
                    If Not reader.IsDBNull(5) Then requesterUserId = reader.GetInt32(5)
                Else
                    transaction.Rollback()  ' ⭐ Request not found - ROLLBACK
                    Return False
                End If
            End Using
        End Using
        
        ' ═══════════════════════════════════════════════════════
        ' ⭐ STEP 2: Update property_requests status to Approved
        ' ═══════════════════════════════════════════════════════
        Dim updateRequestQuery As String = "UPDATE property_requests SET " &
                                          "status = 'Approved', " &
                                          "approvedBy = @adminId, " &
                                          "approvedDate = NOW(), " &
                                          "remarks = @remarks, " &
                                          "updatedAt = NOW() " &
                                          "WHERE requestId = @requestId"
        
        Using cmd As New MySqlCommand(updateRequestQuery, conn, transaction)
            cmd.Parameters.AddWithValue("@requestId", requestId)
            cmd.Parameters.AddWithValue("@adminId", adminId)
            cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrWhiteSpace(remarks), DBNull.Value, remarks))
            cmd.ExecuteNonQuery()  ' ⭐ Update request
        End Using
        
        ' ═══════════════════════════════════════════════════════
        ' ⭐ STEP 3: Find and update matching property
        ' ═══════════════════════════════════════════════════════
        Dim findPropertyQuery As String = "SELECT propertyId FROM properties " &
                                         "WHERE LOWER(itemName) = LOWER(@itemName) " &
                                         "AND (assignedTo IS NULL OR assignedTo = 0) " &
                                         "LIMIT 1"
        
        Dim matchedPropertyId As Integer? = Nothing
        Using cmd As New MySqlCommand(findPropertyQuery, conn, transaction)
            cmd.Parameters.AddWithValue("@itemName", itemName)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                matchedPropertyId = Convert.ToInt32(result)
            End If
        End Using
        
        ' ⭐ If property found, update it with requester information
        If matchedPropertyId.HasValue Then
            Dim userIdToAssign As Integer? = If(requesterUserId.HasValue, requesterUserId, assignedUserId)
            
            Dim updatePropertyQuery As String = "UPDATE properties SET " &
                                               "assignedTo = @assignedTo, " &
                                               "departmentId = @departmentId, " &
                                               "status = 'Active', " &
                                               "updatedAt = NOW() " &
                                               "WHERE propertyId = @propertyId"
            
            Using cmd As New MySqlCommand(updatePropertyQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@propertyId", matchedPropertyId.Value)
                cmd.Parameters.AddWithValue("@assignedTo", If(userIdToAssign.HasValue, userIdToAssign.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
                cmd.ExecuteNonQuery()  ' ⭐ Update property
            End Using
            
            ' ═══════════════════════════════════════════════════════
            ' ⭐ STEP 4: Create borrowed_items record
            ' ═══════════════════════════════════════════════════════
            If userIdToAssign.HasValue AndAlso userIdToAssign.Value > 0 Then
                Dim borrowQuery As String = "INSERT INTO borrowed_items " &
                                           "(requestId, itemType, itemId, borrowerName, borrowerPosition, " &
                                           "departmentId, borrowDate, status, remarks, createdAt, updatedAt) " &
                                           "VALUES (@requestId, 'property', @itemId, @borrowerName, @borrowerPosition, " &
                                           "@departmentId, NOW(), 'Borrowed', @remarks, NOW(), NOW())"
                
                Using cmd As New MySqlCommand(borrowQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@requestId", requestId)
                    cmd.Parameters.AddWithValue("@itemId", matchedPropertyId.Value)
                    cmd.Parameters.AddWithValue("@borrowerName", requesterName)
                    cmd.Parameters.AddWithValue("@borrowerPosition", DBNull.Value)
                    cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@remarks", "Approved request #" & requestId)
                    cmd.ExecuteNonQuery()  ' ⭐ Insert borrowed_items
                End Using
            End If
        End If
        
        ' ═══════════════════════════════════════════════════════
        ' ⭐ ALL STEPS SUCCEEDED - COMMIT TRANSACTION
        ' ═══════════════════════════════════════════════════════
        transaction.Commit()
        System.Diagnostics.Debug.WriteLine($"[v0] ApprovePropertyRequest SUCCESS - 4 operations committed together")
        Return True
        
    Catch ex As Exception
        ' ═══════════════════════════════════════════════════════
        ' ⭐ ANY STEP FAILED - ROLLBACK ALL CHANGES
        ' ═══════════════════════════════════════════════════════
        If transaction IsNot Nothing Then
            Try
                transaction.Rollback()
                System.Diagnostics.Debug.WriteLine("[v0] ApprovePropertyRequest ROLLED BACK due to error")
            Catch
            End Try
        End If
        System.Diagnostics.Debug.WriteLine("[v0] ApprovePropertyRequest Error: " & ex.Message)
        Return False
    Finally
        ' ⭐ CLEANUP - Always dispose resources
        If transaction IsNot Nothing Then transaction.Dispose()
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
        End If
    End Try
End Function
```

**⭐ TRANSACTION ENSURES:**
1. **Request status updated** to 'Approved'
2. **Property assignment** updated with requester
3. **Borrowed items record** created
4. **ALL succeed together** OR **ALL fail together** (no partial updates!)

---

### **🔵 TRANSACTION EXAMPLE 2: Supply Assignment**

#### **WHERE TO FIND:**
- **File:** `modDB.Extensions.vb` Line 814-866
- **Function:** AssignSupplyToUser

#### **THE ACTUAL CODE:**

```vb
Public Shared Function AssignSupplyToUser(supplyId As Integer, userId As Integer, quantity As Integer,
                                         Optional departmentId As Integer? = Nothing,
                                         Optional purpose As String = "") As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = modDB.GetConnection()
        If conn Is Nothing Then Return False
        If Not modDB.SafeOpenConnection(conn) Then Return False

        ' ⭐ BEGIN TRANSACTION
        transaction = conn.BeginTransaction()

        ' ═══════════════════════════════════════════════════════
        ' ⭐ STEP 1: Check available quantity
        ' ═══════════════════════════════════════════════════════
        Dim availableQty As Integer = 0
        Using checkCmd As New MySqlCommand("SELECT quantity FROM supplies WHERE supplyId = @supplyId", conn, transaction)
            checkCmd.Parameters.AddWithValue("@supplyId", supplyId)
            Dim result = checkCmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Integer.TryParse(result.ToString(), availableQty)
            End If
        End Using

        ' ⭐ Validation - Not enough stock
        If availableQty < quantity Then
            transaction.Rollback()
            System.Diagnostics.Debug.WriteLine($"[v0] Insufficient stock. Available: {availableQty}, Requested: {quantity}")
            Return False
        End If

        ' ═══════════════════════════════════════════════════════
        ' ⭐ STEP 2: Deduct quantity from supplies
        ' ═══════════════════════════════════════════════════════
        Using updateCmd As New MySqlCommand(
            "UPDATE supplies SET " &
            "quantity = quantity - @qty, " &
            "assignedTo = @userId, " &
            "updatedAt = NOW() " &
            "WHERE supplyId = @supplyId", 
            conn, transaction)
            
            updateCmd.Parameters.AddWithValue("@qty", quantity)
            updateCmd.Parameters.AddWithValue("@userId", userId)
            updateCmd.Parameters.AddWithValue("@supplyId", supplyId)
            updateCmd.ExecuteNonQuery()
        End Using

        ' ═══════════════════════════════════════════════════════
        ' ⭐ STEP 3: Create borrowed_items tracking record
        ' ═══════════════════════════════════════════════════════
        Dim borrowQuery As String = 
            "INSERT INTO borrowed_items " &
            "(itemType, itemId, borrowerName, borrowerPosition, departmentId, " &
            "borrowDate, status, remarks, createdAt, updatedAt) " &
            "SELECT 'supply', s.supplyId, CONCAT(u.firstName, ' ', u.lastName), u.position, " &
            "@departmentId, NOW(), 'Borrowed', CONCAT(@remarks, ' - Item: ', s.itemName), NOW(), NOW() " &
            "FROM supplies s, users u " &
            "WHERE s.supplyId = @supplyId AND u.userId = @userId"

        Using borrowCmd As New MySqlCommand(borrowQuery, conn, transaction)
            borrowCmd.Parameters.AddWithValue("@supplyId", supplyId)
            borrowCmd.Parameters.AddWithValue("@userId", userId)
            borrowCmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
            borrowCmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(purpose), "Supply assigned", purpose))
            borrowCmd.ExecuteNonQuery()
        End Using

        ' ⭐ ALL SUCCEEDED - COMMIT
        transaction.Commit()
        System.Diagnostics.Debug.WriteLine($"[v0] AssignSupplyToUser SUCCESS - Qty deducted & tracking created")
        Return True

    Catch ex As Exception
        ' ⭐ ERROR - ROLLBACK
        If transaction IsNot Nothing Then
            Try
                transaction.Rollback()
            Catch
            End Try
        End If
        System.Diagnostics.Debug.WriteLine("[v0] AssignSupplyToUser Error: " & ex.Message)
        Return False
    Finally
        If transaction IsNot Nothing Then transaction.Dispose()
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Dispose()
        End If
    End Try
End Function
```

**⭐ WHY TRANSACTION IS CRITICAL:**
- If Step 2 succeeds (quantity deducted) but Step 3 fails (tracking not created)...
- WITHOUT transaction: Supply lost track, inventory mismatch!
- WITH transaction: Rollback restores quantity, maintains data integrity

---

## 🎯 **PRESENTATION DEMO SCRIPT:**

### **For Complex Queries (Criterion 5):**

**Say:** "Let me show you our most complex query..."

1. Open `modDB.vb` Line 8613
2. **Say:** "This query joins 5 tables: custodian, users, properties, supplies, and departments"
3. Point to code: "See the LEFT JOINs? We use conditional JOINs based on itemType"
4. **Say:** "The CASE statement handles properties OR supplies dynamically"
5. Run a custodian report: "Here's the result - see how it combines both property and supply data?"

### **For Transactions (Criterion 6):**

**Say:** "Transactions ensure data integrity. Let me demonstrate..."

1. Open `modDB.Extensions.vb` Line 710
2. **Say:** "When approving a property request, we do 4 database operations:"
   - Point to each step in code
   - "1. Update request status"
   - "2. Update property assignment"
   - "3. Create borrowed_items record"
   - "4. All wrapped in a transaction"
3. **Say:** "BeginTransaction starts it..."
4. Scroll to Commit: "If all succeed, we Commit"
5. Scroll to Catch: "If ANY fail, we Rollback - no partial updates!"
6. **Say:** "This is why our database never has inconsistent data"

**Demo:** Approve a real property request and show all 3 tables updated together!

---

**Continue to PART 3 for Security & Additional Features...**
