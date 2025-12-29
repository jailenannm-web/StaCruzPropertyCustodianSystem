## ✅ FIXED: AUTO-ASSIGNMENT ON APPROVAL - DUAL TABLE SUPPORT

### Problem Identified

Your database has TWO user tables:
1. **users** table - Main user accounts (admins, custodians, etc.)
2. **staff_accounts** table - Staff user accounts (linked to users via userId)

The original code only searched the **users** table, so it couldn't find staff members who submitted requests!

### Solution Implemented

Updated \ApprovePropertyRequest()\ to search **BOTH** tables:

#### Step 1: Find Requester by Name
```vb
-- Search users table first
SELECT userId FROM users 
WHERE CONCAT(firstName, ' ', lastName) LIKE '%requesterName%'

-- If not found, search staff_accounts table
SELECT userId FROM staff_accounts 
WHERE CONCAT(firstName, ' ', lastName) LIKE '%requesterName%'
```

#### Step 2: Get Requester's Department
```vb
-- Try users table first
SELECT departmentId FROM users WHERE userId = ?

-- If not found or NULL, try staff_accounts
SELECT departmentId FROM staff_accounts WHERE userId = ?
```

#### Step 3: Get Department Location
```sql
SELECT location FROM departments WHERE departmentId = ?
```

#### Step 4: Update Property
```sql
UPDATE properties SET 
    assignedTo = requesterUserId,
    departmentId = requesterDepartmentId,
    location = departmentLocation,
    status = 'Borrowed',
    updatedAt = NOW()
WHERE propertyId = ?
```

### Debug Output You'll See

**SUCCESSFUL APPROVAL:**
```
[ApprovePropertyRequest] Looking for requester: John Doe
[ApprovePropertyRequest] Found requester in staff_accounts table, userId: 5
[ApprovePropertyRequest] Found requester's departmentId in staff_accounts: 2
[ApprovePropertyRequest] Found department location: Main Building
[ApprovePropertyRequest] Updating propertyId=123: assignedTo=5, departmentId=2, location=Main Building
[ApprovePropertyRequest] Property update complete: 1 rows affected
```

**POSSIBLE ISSUES:**

1. **User Not Found:**
   ```
   [ApprovePropertyRequest] Requester NOT FOUND in either users or staff_accounts: John Doe
   ```
   **Solution:** Create the user/staff account before submitting requests

2. **No Department:**
   ```
   [ApprovePropertyRequest] Requester has no departmentId
   ```
   **Solution:** Update users/staff_accounts table to set departmentId

3. **Department Has No Location:**
   ```
   [ApprovePropertyRequest] Department 2 has no location
   ```
   **Solution:** Update departments table to set location

### How to Test

#### 1. Prepare Test Data

**A. Create a staff user with department:**
```sql
-- Insert into users table first (if needed)
INSERT INTO users (firstName, lastName, departmentId, username, passwordEncrypted, role, status)
VALUES ('John', 'Doe', 2, 'jdoe', '\\\', 'Staff', 'Active');

-- Get the userId
SET @userId = LAST_INSERT_ID();

-- Insert into staff_accounts (linked to users)
INSERT INTO staff_accounts (userId, firstName, lastName, departmentId, username, passwordEncrypted, status)
VALUES (@userId, 'John', 'Doe', 2, 'jdoe', '\\\', 'Active');
```

**B. Make sure department has a location:**
```sql
UPDATE departments SET location = 'Main Building' WHERE departmentId = 2;
```

**C. Create a property:**
```sql
INSERT INTO properties (itemName, category, propertyNumber, acquisitionDate, acquisitionCost, location, status)
VALUES ('Laptop', 'IT Equipment', 'PROP-001', NOW(), 50000.00, 'Storage Room', 'Active');
```

**D. Create a property request:**
```sql
INSERT INTO property_requests (requesterName, departmentId, dateOfRequest, itemName, purpose, status)
VALUES ('John Doe', 2, NOW(), 'Laptop', 'For office work', 'Pending');
```

#### 2. Test Approval

1. **Run the application in Debug mode** (F5)
2. **Login as admin** (username: \dmin\, password: \dmin\)
3. **Go to Property Request Management**
4. **Find the pending request for "John Doe"**
5. **Click Approve**
6. **Check the Output window** (View → Output, set to Debug)

#### 3. Verify Results

**A. Check Debug Output** - Should show successful update

**B. Check Database:**
```sql
SELECT 
    p.propertyId,
    p.itemName,
    p.assignedTo,
    CONCAT(u.firstName, ' ', u.lastName) AS assignedUserName,
    p.departmentId,
    d.departmentName,
    p.location AS propertyLocation,
    d.location AS departmentLocation,
    p.status
FROM properties p
LEFT JOIN users u ON p.assignedTo = u.userId
LEFT JOIN departments d ON p.departmentId = d.departmentId
WHERE p.itemName = 'Laptop';
```

**Expected Result:**
| Field | Value |
|-------|-------|
| assignedTo | 5 (John's userId) |
| assignedUserName | John Doe |
| departmentId | 2 (IT Department) |
| departmentName | IT Department |
| propertyLocation | Main Building |
| departmentLocation | Main Building |
| status | Borrowed |

**C. Check Property Grids:**
- **UC_PropertyManagement1** (Admin view)
- **PropertyInventory** (Staff view)

Both should show:
- **Assigned To:** John Doe
- **Department:** IT Department
- **Location:** Main Building

### Build Status

✅ **Build: Successful**
✅ **Dual table support: Implemented**
✅ **Enhanced debug logging: Active**

### Files Modified

- **DatabaseConnection.vb** - Lines 3878-3970
  - Added staff_accounts table search
  - Enhanced department lookup logic
  - Added comprehensive debug logging

---

**Implementation Date:** 2025-12-28 14:39
**Status:** ✅ Ready for Testing with Dual Table Support

