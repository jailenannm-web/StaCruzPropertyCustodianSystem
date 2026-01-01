# Database Schema Fix Instructions

## Overview
Your `borrowed_items` table has been migrated to replace the `expectedReturnDate` DATE column with a `returnReason` VARCHAR(200) column. This document explains the changes and provides instructions.

## What Changed

### 1. borrowed_items Table
- ❌ **REMOVED**: `expectedReturnDate` DATE column
- ✅ **ADDED**: `returnReason` VARCHAR(200) column
- ✅ **ADDED**: `itemName` VARCHAR(200) column (for faster queries without joins)

### 2. supplies Table
- ✅ **ADDED**: `assignedTo` INT(11) column (tracks which user has the supply)
- ✅ **ADDED**: `departmentId` INT(11) column (tracks which department has the supply)
- ✅ **ADDED**: Foreign key constraints to `users` and `departments` tables

## How to Apply the Fix

### Step 1: Run the Complete Fix Script
Execute the file `fix_borrowed_items_schema_complete.sql` in phpMyAdmin:

1. Open phpMyAdmin
2. Select the `teamcruzim` database
3. Click on the **SQL** tab
4. Copy and paste the contents of `fix_borrowed_items_schema_complete.sql`
5. Click **Go** to execute

This script will:
- Add the missing `itemName` column to `borrowed_items`
- Remove `expectedReturnDate` if it still exists
- Add `returnReason` column if not present
- Populate `itemName` from existing `properties` and `supplies` data
- Add `assignedTo` and `departmentId` to `supplies` table
- Set up all necessary indexes and foreign keys

### Step 2: Verify the Changes
After running the script, verify the structure:

```sql
-- Check borrowed_items structure
DESCRIBE borrowed_items;

-- Check supplies structure  
DESCRIBE supplies;

-- Verify data was populated
SELECT borrowId, itemType, itemId, itemName, returnReason 
FROM borrowed_items 
LIMIT 10;
```

## Understanding the Migration

### Why Remove expectedReturnDate?
The old design used a DATE field to store when items should be returned. The new design uses a VARCHAR field to store the **reason** for return instead. This provides more flexibility:

**Old Design:**
- `expectedReturnDate`: 2025-01-15

**New Design:**
- `returnReason`: "Project completed" or "No longer needed" or "End of semester"

### Impact on Your Application

#### Forms That Reference expectedReturnDate:
1. **BorrowingAndReturnSlip.vb** - ✅ Already handled (uses calculated date for display)
   - The form control `expectedReturnDate` still exists in the UI for display purposes
   - It now calculates a date (borrowDate + 30 days) instead of reading from DB
   - This maintains backward compatibility with the form design

#### Database Queries:
Your VB.NET code should now use `returnReason` instead of `expectedReturnDate`:

```vb
' OLD (Don't use):
Dim query As String = "SELECT borrowId, expectedReturnDate FROM borrowed_items"

' NEW (Use this):
Dim query As String = "SELECT borrowId, returnReason FROM borrowed_items"
```

## New Features Enabled

### 1. Supply Assignment Tracking
With the new `assignedTo` column in supplies, you can now:
- Track which user has which supply
- Automatically create `borrowed_items` records when supplies are assigned
- Generate reports on supply assignments

Example usage:
```vb
' Assign a supply to a user
DatabaseConnection.AssignSupplyToUser(supplyId:=5, userId:=10, quantity:=3, departmentId:=2)
```

### 2. Item Name in Borrowed Items
The new `itemName` column improves query performance:

```sql
-- OLD (requires JOIN):
SELECT bi.*, p.itemName 
FROM borrowed_items bi 
INNER JOIN properties p ON bi.itemId = p.propertyId

-- NEW (direct access):
SELECT bi.borrowId, bi.itemName, bi.status 
FROM borrowed_items bi
```

## Sample Data After Migration

### borrowed_items Table:
| borrowId | itemType | itemId | itemName | returnReason | status | borrowDate |
|----------|----------|--------|----------|--------------|--------|------------|
| 1 | property | 5 | Laptop Dell XPS | Project completed | Returned | 2025-01-01 |
| 2 | supply | 10 | Whiteboard Markers | Department transfer | Borrowed | 2025-01-02 |

### supplies Table:
| supplyId | itemName | quantity | assignedTo | departmentId |
|----------|----------|----------|------------|--------------|
| 1 | Paper A4 | 100 | NULL | NULL |
| 2 | USB Cable | 5 | 15 | 3 |

## Troubleshooting

### Issue 1: "Column 'expectedReturnDate' not found"
**Cause**: Your code is still trying to read from the old column.

**Solution**: Update your queries to use `returnReason` instead.

### Issue 2: "Column 'itemName' is NULL in borrowed_items"
**Cause**: The populate script didn't run or data doesn't match.

**Solution**: Run the update queries from Step 3 in the fix script:
```sql
UPDATE borrowed_items bi
INNER JOIN properties p ON bi.itemId = p.propertyId AND bi.itemType = 'property'
SET bi.itemName = p.itemName
WHERE bi.itemName IS NULL;

UPDATE borrowed_items bi
INNER JOIN supplies s ON bi.itemId = s.supplyId AND bi.itemType = 'supply'
SET bi.itemName = s.itemName
WHERE bi.itemName IS NULL;
```

### Issue 3: "Duplicate key error on supplies"
**Cause**: You're running the script multiple times.

**Solution**: The script uses `IF NOT EXISTS` clauses, so it's safe to re-run. If you still get errors, the indexes/constraints already exist (which is fine).

## Next Steps

1. ✅ Run `fix_borrowed_items_schema_complete.sql`
2. ✅ Verify the changes worked
3. ⚠️ Update any custom queries in your code that reference `expectedReturnDate`
4. ✅ Test the borrowing and return workflows
5. ✅ Test supply assignment features

## Questions?

If you encounter issues:
1. Check the database error messages
2. Verify you're using the `teamcruzim` database
3. Ensure you have proper permissions (CREATE, ALTER, INSERT, UPDATE)
4. Check the MySQL version (should support `IF NOT EXISTS` syntax for MariaDB 10.4+)

---
**Last Updated**: 2026-01-01
**Database Version**: MariaDB 10.4.32
**Application**: Sta Cruz Property Custodian System
