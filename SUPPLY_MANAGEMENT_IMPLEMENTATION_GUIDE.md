# Supply Management Implementation Guide

## ✅ Completed Steps

1. **Database Schema** - Created `add_assignedTo_to_supplies.sql`
   - Adds `assignedTo` field to supplies table
   - Adds foreign key to users table
   - **Action Required:** Run this SQL script in phpMyAdmin

2. **AddSupply.vb** - Updated with assignment support
   - Added `LoadUsers()` method
   - Added `cboAssignedTo` dropdown population
   - Updated `btnSave_Click` to pass assignedTo parameter

3. **EditSupply.vb** - Updated with assignment support
   - Added `LoadUsers()` method
   - Added `SetUserValue()` method
   - Updated `LoadSupplyData()` to accept assignedToUserId parameter
   - Updated `btnSave_Click` to pass assignedTo parameter

---

## 🚧 Remaining Implementation Steps

### Step 1: Update DatabaseConnection for Supply Operations

You need to update the following methods in **DatabaseConnection.vb** or create them in **DatabaseConnection.Extensions.vb**:

#### A. Update `AddSupply` Method

**Current signature:**
```vb
Public Shared Function AddSupply(itemName As String, category As String, description As String, 
                                 unitOfMeasure As String, quantity As Integer, dateReceived As Date,
                                 unitCost As Decimal, totalCost As Decimal, supplier As String,
                                 sourceOfFunds As String, location As String, stockStatus As String) As Boolean
```

**New signature (add assignedTo parameter):**
```vb
Public Shared Function AddSupply(itemName As String, category As String, description As String, 
                                 unitOfMeasure As String, quantity As Integer, dateReceived As Date,
                                 unitCost As Decimal, totalCost As Decimal, supplier As String,
                                 sourceOfFunds As String, assignedTo As Integer?, location As String,
                                 stockStatus As String) As Boolean
```

**Implementation (similar to AddProperty):**
```vb
Public Shared Function AddSupply(itemName As String, category As String, description As String,
                                 unitOfMeasure As String, quantity As Integer, dateReceived As Date,
                                 unitCost As Decimal, totalCost As Decimal, supplier As String,
                                 sourceOfFunds As String, assignedTo As Integer?, location As String,
                                 stockStatus As String) As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        If conn Is Nothing Then Return False
        If Not SafeOpenConnection(conn) Then Return False
        
        ' Start transaction to ensure both supply and borrowed_items are created together
        transaction = conn.BeginTransaction()
        
        ' Insert supply into database
        Dim query As String = "INSERT INTO supplies (itemName, category, description, unitOfMeasure, " &
                             "quantity, dateReceived, unitCost, totalCost, supplier, sourceOfFunds, " &
                             "assignedTo, location, stockStatus, createdAt, updatedAt) " &
                             "VALUES (@itemName, @category, @description, @unitOfMeasure, @quantity, " &
                             "@dateReceived, @unitCost, @totalCost, @supplier, @sourceOfFunds, " &
                             "@assignedTo, @location, @stockStatus, NOW(), NOW())"
        
        Dim newSupplyId As Integer = 0
        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@itemName", itemName)
            cmd.Parameters.AddWithValue("@category", category)
            cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(description), DBNull.Value, description))
            cmd.Parameters.AddWithValue("@unitOfMeasure", unitOfMeasure)
            cmd.Parameters.AddWithValue("@quantity", quantity)
            cmd.Parameters.AddWithValue("@dateReceived", dateReceived)
            cmd.Parameters.AddWithValue("@unitCost", unitCost)
            cmd.Parameters.AddWithValue("@totalCost", totalCost)
            cmd.Parameters.AddWithValue("@supplier", If(String.IsNullOrWhiteSpace(supplier), DBNull.Value, supplier))
            cmd.Parameters.AddWithValue("@sourceOfFunds", If(String.IsNullOrWhiteSpace(sourceOfFunds), DBNull.Value, sourceOfFunds))
            cmd.Parameters.AddWithValue("@assignedTo", If(assignedTo.HasValue, assignedTo.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@location", location)
            cmd.Parameters.AddWithValue("@stockStatus", stockStatus)
            
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected <= 0 Then
                transaction.Rollback()
                Return False
            End If
            
            ' Get the newly inserted supply ID
            Using idCmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction)
                newSupplyId = Convert.ToInt32(idCmd.ExecuteScalar())
            End Using
        End Using
        
        ' If supply is assigned to a user, automatically create borrowed_items record
        If assignedTo.HasValue AndAlso assignedTo.Value > 0 Then
            CreateBorrowedItemRecordForSupply(conn, transaction, newSupplyId, assignedTo.Value, Nothing, itemName, quantity, unitOfMeasure)
        End If
        
        ' Commit transaction
        transaction.Commit()
        System.Diagnostics.Debug.WriteLine($"[v0] AddSupply Success - ID: {newSupplyId}, AssignedTo: {If(assignedTo.HasValue, assignedTo.Value.ToString(), "None")}")
        Return True
        
    Catch ex As Exception
        If transaction IsNot Nothing Then
            Try
                transaction.Rollback()
            Catch
            End Try
        End If
        System.Diagnostics.Debug.WriteLine("[v0] AddSupply Exception: " & ex.Message)
        MessageBox.Show("Error adding supply: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
    Finally
        If transaction IsNot Nothing Then
            Try
                transaction.Dispose()
            Catch
            End Try
        End If
        If conn IsNot Nothing Then
            Try
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Dispose()
            Catch
            End Try
        End If
    End Try
End Function
```

#### B. Create `CreateBorrowedItemRecordForSupply` Method

Add this to **DatabaseConnection.Extensions.vb**:

```vb
''' <summary>
''' Create a borrowed_items record when a supply is assigned to a user
''' </summary>
Private Shared Sub CreateBorrowedItemRecordForSupply(conn As MySqlConnection, transaction As MySqlTransaction,
                                             supplyId As Integer, userId As Integer,
                                             departmentId As Integer?, itemName As String,
                                             quantity As Integer, unitOfMeasure As String)
    Try
        ' Get user information
        Dim borrowerName As String = ""
        Dim borrowerPosition As String = ""
        Dim userDeptId As Integer? = departmentId
        
        Using userCmd As New MySqlCommand("SELECT CONCAT(IFNULL(firstName,''), ' ', IFNULL(lastName,'')) AS fullName, position, departmentId FROM users WHERE userId = @userId", conn, transaction)
            userCmd.Parameters.AddWithValue("@userId", userId)
            Using reader As MySqlDataReader = userCmd.ExecuteReader()
                If reader.Read() Then
                    borrowerName = If(reader.IsDBNull(0), "Unknown User", reader.GetString(0))
                    borrowerPosition = If(reader.IsDBNull(1), Nothing, reader.GetString(1))
                    If Not reader.IsDBNull(2) Then userDeptId = reader.GetInt32(2)
                End If
            End Using
        End Using
        
        ' Create borrowed_items record
        Dim borrowQuery As String = "INSERT INTO borrowed_items (itemType, itemId, borrowerName, borrowerPosition, " &
                                   "departmentId, borrowDate, expectedReturnDate, status, remarks, createdAt, updatedAt) " &
                                   "VALUES ('supply', @itemId, @borrowerName, @borrowerPosition, @departmentId, " &
                                   "NOW(), DATE_ADD(NOW(), INTERVAL 30 DAY), 'Borrowed', @remarks, NOW(), NOW())"
        
        Using borrowCmd As New MySqlCommand(borrowQuery, conn, transaction)
            borrowCmd.Parameters.AddWithValue("@itemId", supplyId)
            borrowCmd.Parameters.AddWithValue("@borrowerName", borrowerName)
            borrowCmd.Parameters.AddWithValue("@borrowerPosition", If(String.IsNullOrEmpty(borrowerPosition), DBNull.Value, borrowerPosition))
            borrowCmd.Parameters.AddWithValue("@departmentId", If(userDeptId.HasValue, userDeptId.Value, DBNull.Value))
            
            Dim remarks As String = $"Supply assigned: {itemName} ({quantity} {unitOfMeasure})"
            borrowCmd.Parameters.AddWithValue("@remarks", remarks)
            
            borrowCmd.ExecuteNonQuery()
            System.Diagnostics.Debug.WriteLine($"[v0] Created borrowed_items record for supplyId: {supplyId}, userId: {userId}")
        End Using
        
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("[v0] CreateBorrowedItemRecordForSupply Exception: " & ex.Message)
        Throw ' Re-throw to rollback transaction
    End Try
End Sub
```

#### C. Update `UpdateSupply` Method

**Current signature:**
```vb
Public Shared Function UpdateSupply(supplyId As Integer, itemName As String, category As String,
                                   description As String, unitOfMeasure As String, quantity As Integer,
                                   dateReceived As Date, unitCost As Decimal, totalCost As Decimal,
                                   supplier As String, sourceOfFunds As String, location As String,
                                   stockStatus As String) As Boolean
```

**New signature (add assignedTo parameter):**
```vb
Public Shared Function UpdateSupply(supplyId As Integer, itemName As String, category As String,
                                   description As String, unitOfMeasure As String, quantity As Integer,
                                   dateReceived As Date, unitCost As Decimal, totalCost As Decimal,
                                   supplier As String, sourceOfFunds As String, assignedTo As Integer?,
                                   location As String, stockStatus As String) As Boolean
```

**Implementation (similar to UpdateProperty):**
```vb
Public Shared Function UpdateSupply(supplyId As Integer, itemName As String, category As String,
                                   description As String, unitOfMeasure As String, quantity As Integer,
                                   dateReceived As Date, unitCost As Decimal, totalCost As Decimal,
                                   supplier As String, sourceOfFunds As String, assignedTo As Integer?,
                                   location As String, stockStatus As String) As Boolean
    Dim conn As MySqlConnection = Nothing
    Dim transaction As MySqlTransaction = Nothing
    Try
        conn = GetConnection()
        If conn Is Nothing Then Return False
        If Not SafeOpenConnection(conn) Then Return False
        
        ' Start transaction
        transaction = conn.BeginTransaction()
        
        ' Get current assignedTo value before update
        Dim oldAssignedTo As Integer? = Nothing
        Using checkCmd As New MySqlCommand("SELECT assignedTo FROM supplies WHERE supplyId = @supplyId", conn, transaction)
            checkCmd.Parameters.AddWithValue("@supplyId", supplyId)
            Using reader As MySqlDataReader = checkCmd.ExecuteReader()
                If reader.Read() AndAlso Not reader.IsDBNull(0) Then
                    oldAssignedTo = reader.GetInt32(0)
                End If
            End Using
        End Using
        
        ' Update supply
        Dim query As String = "UPDATE supplies SET itemName = @itemName, category = @category, " &
                             "description = @description, unitOfMeasure = @unitOfMeasure, quantity = @quantity, " &
                             "dateReceived = @dateReceived, unitCost = @unitCost, totalCost = @totalCost, " &
                             "supplier = @supplier, sourceOfFunds = @sourceOfFunds, assignedTo = @assignedTo, " &
                             "location = @location, stockStatus = @stockStatus, updatedAt = NOW() " &
                             "WHERE supplyId = @supplyId"
        
        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@supplyId", supplyId)
            cmd.Parameters.AddWithValue("@itemName", itemName)
            cmd.Parameters.AddWithValue("@category", category)
            cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(description), DBNull.Value, description))
            cmd.Parameters.AddWithValue("@unitOfMeasure", unitOfMeasure)
            cmd.Parameters.AddWithValue("@quantity", quantity)
            cmd.Parameters.AddWithValue("@dateReceived", dateReceived)
            cmd.Parameters.AddWithValue("@unitCost", unitCost)
            cmd.Parameters.AddWithValue("@totalCost", totalCost)
            cmd.Parameters.AddWithValue("@supplier", If(String.IsNullOrWhiteSpace(supplier), DBNull.Value, supplier))
            cmd.Parameters.AddWithValue("@sourceOfFunds", If(String.IsNullOrWhiteSpace(sourceOfFunds), DBNull.Value, sourceOfFunds))
            cmd.Parameters.AddWithValue("@assignedTo", If(assignedTo.HasValue, assignedTo.Value, DBNull.Value))
            cmd.Parameters.AddWithValue("@location", location)
            cmd.Parameters.AddWithValue("@stockStatus", stockStatus)
            
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected <= 0 Then
                transaction.Rollback()
                Return False
            End If
        End Using
        
        ' Handle borrowed_items based on assignment changes
        ' Case 1: Supply was not assigned, now it is assigned
        If (Not oldAssignedTo.HasValue OrElse oldAssignedTo.Value = 0) AndAlso assignedTo.HasValue AndAlso assignedTo.Value > 0 Then
            CreateBorrowedItemRecordForSupply(conn, transaction, supplyId, assignedTo.Value, Nothing, itemName, quantity, unitOfMeasure)
        
        ' Case 2: Supply was assigned to someone, now assigned to different user
        ElseIf oldAssignedTo.HasValue AndAlso oldAssignedTo.Value > 0 AndAlso assignedTo.HasValue AndAlso assignedTo.Value > 0 AndAlso oldAssignedTo.Value <> assignedTo.Value Then
            ' Mark old borrowed_items as returned
            Using returnCmd As New MySqlCommand("UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW(), " &
                                               "updatedAt = NOW() WHERE itemType = 'supply' AND itemId = @supplyId AND status = 'Borrowed'", conn, transaction)
                returnCmd.Parameters.AddWithValue("@supplyId", supplyId)
                returnCmd.ExecuteNonQuery()
            End Using
            
            ' Create new borrowed_items record for new user
            CreateBorrowedItemRecordForSupply(conn, transaction, supplyId, assignedTo.Value, Nothing, itemName, quantity, unitOfMeasure)
        
        ' Case 3: Supply was assigned, now unassigned (mark as returned)
        ElseIf oldAssignedTo.HasValue AndAlso oldAssignedTo.Value > 0 AndAlso (Not assignedTo.HasValue OrElse assignedTo.Value = 0) Then
            Using returnCmd As New MySqlCommand("UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW(), " &
                                               "updatedAt = NOW() WHERE itemType = 'supply' AND itemId = @supplyId AND status = 'Borrowed'", conn, transaction)
                returnCmd.Parameters.AddWithValue("@supplyId", supplyId)
                returnCmd.ExecuteNonQuery()
            End Using
        End If
        
        ' Commit transaction
        transaction.Commit()
        System.Diagnostics.Debug.WriteLine($"[v0] UpdateSupply Success - ID: {supplyId}, OldAssignedTo: {If(oldAssignedTo.HasValue, oldAssignedTo.Value.ToString(), "None")}, NewAssignedTo: {If(assignedTo.HasValue, assignedTo.Value.ToString(), "None")}")
        Return True
        
    Catch ex As Exception
        If transaction IsNot Nothing Then
            Try
                transaction.Rollback()
            Catch
            End Try
        End If
        System.Diagnostics.Debug.WriteLine("[v0] UpdateSupply Exception: " & ex.Message)
        MessageBox.Show("Error updating supply: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
    Finally
        If transaction IsNot Nothing Then
            Try
                transaction.Dispose()
            Catch
            End Try
        End If
        If conn IsNot Nothing Then
            Try
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Dispose()
            Catch
            End Try
        End If
    End Try
End Function
```

#### D. Update `GetAllSupplies` Method

Update the SELECT query to include JOIN with users table:

```vb
' Change FROM:
SELECT supplyId, itemName, category, description, unitOfMeasure, quantity, dateReceived, 
       unitCost, totalCost, supplier, sourceOfFunds, location, stockStatus

' TO:
SELECT s.supplyId, s.itemName, s.category, s.description, s.unitOfMeasure, s.quantity, 
       s.dateReceived, s.unitCost, s.totalCost, s.supplier, s.sourceOfFunds, s.assignedTo, 
       s.location, s.stockStatus,
       CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS assignedEmployee
FROM supplies s
LEFT JOIN users u ON s.assignedTo = u.userId
```

---

### Step 2: Update frmBorrowedItem.vb Return Logic for Supplies

Update the `UpdateBorrowedItemReturn` method to also handle supplies:

```vb
' In the section that updates properties, add similar logic for supplies:

' If it's a supply, update the supplies table
If itemType.ToLower() = "supply" AndAlso itemId > 0 Then
    ' Update supply and clear assignedTo
    Dim updateSupplyQuery As String = "UPDATE supplies SET " &
                                 "assignedTo = NULL, " &
                                 "updatedAt = NOW() " &
                                 "WHERE supplyId = @supplyId"

    Using supCmd As New MySqlCommand(updateSupplyQuery, conn, transaction)
        supCmd.Parameters.AddWithValue("@supplyId", itemId)
        supCmd.ExecuteNonQuery()
    End Using
    
    System.Diagnostics.Debug.WriteLine($"[v0] Supply {itemId} returned - assignedTo cleared")
End If
```

---

### Step 3: Update UI Forms to Display assignedTo

#### UC_SupplyManagement.vb

The implementation is already there, but verify it displays the `assignedEmployee` column similar to UC_PropertyManagement1.vb.

#### SupplyInventory.vb (Staff Interface)

Similar to PropertyInventory.vb, ensure it displays the `assignedEmployee` column.

---

## 📝 Testing Checklist

After implementing all changes:

1. ☐ Run `add_assignedTo_to_supplies.sql` in phpMyAdmin
2. ☐ Build the project (should compile without errors)
3. ☐ Test adding a new supply with assignment
4. ☐ Test editing a supply to assign/reassign/unassign
5. ☐ Test viewing assigned supplies in UC_SupplyManagement
6. ☐ Test viewing assigned supplies in SupplyInventory
7. ☐ Test returning a supply in frmBorrowedItem
8. ☐ Verify assignedTo is cleared after return
9. ☐ Verify borrowed_items records are created correctly

---

## 🎯 Summary

**Completed:**
- ✅ Database schema SQL script
- ✅ AddSupply.vb UI updates
- ✅ EditSupply.vb UI updates

**To Do:**
- ⏳ DatabaseConnection.AddSupply with assignedTo and borrowed_items
- ⏳ DatabaseConnection.UpdateSupply with assignedTo and borrowed_items
- ⏳ DatabaseConnection.GetAllSupplies to include assignedEmployee
- ⏳ CreateBorrowedItemRecordForSupply helper method
- ⏳ Update frmBorrowedItem return logic for supplies
- ⏳ Verify UI grids display assignedTo properly

This implementation mirrors the Property Management flow exactly!
