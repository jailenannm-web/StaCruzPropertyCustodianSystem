# Requisition and Issue Slip (RIS) - Complete Guide

## Overview
The **Requisition and Issue Slip (RIS)** is a standard government form used to request and track the issuance of property and supplies. This document explains how the system generates and stores RIS data.

---

## 📋 Database Tables Used

### 1. **property_requests** Table
Stores all property requisition requests from staff members.

**Key Fields:**
- `requestId` - Unique identifier for each request
- `requesterName` - Full name of the person requesting
- `position` - Job title/position of requester
- `departmentId` - Foreign key to departments table
- `dateOfRequest` - When the request was submitted
- `itemName` - Name of the property being requested
- `description` - Detailed description of the item
- `quantityRequested` - Number of units requested
- `unit` - Unit of measure (e.g., "piece", "set", "unit")
- `purpose` - Reason for the request
- `status` - Current status: Pending, Approved, Rejected
- `approvedBy` - User ID of the approver
- `approvedDate` - Date when approved
- `remarks` - Additional notes or comments

### 2. **supplies_requests** Table
Stores all supply requisition requests from staff members.

**Key Fields:** (Same structure as property_requests)
- Same fields as property_requests table
- Used for consumable items and supplies

### 3. **departments** Table
Stores department information for the requisition.

**Key Fields:**
- `departmentId` - Unique identifier
- `departmentName` - Full name of the department
- `location` - Physical location of the department

### 4. **users** Table
Stores information about who approved the request.

**Key Fields:**
- `userId` - Unique identifier
- `firstName` - First name of approver
- `lastName` - Last name of approver
- `role` - User role (SuperAdmin, Admin, etc.)

---

## 🔄 How RIS Data is Generated

### Step 1: Staff Member Submits Request
```vb
' Staff creates a new request through frmPropertyRequest or frmRequest
' Data saved to property_requests or supplies_requests table
INSERT INTO property_requests (
    requesterName,
    position,
    departmentId,
    dateOfRequest,
    itemName,
    description,
    quantityRequested,
    unit,
    purpose,
    status
) VALUES (
    'John Doe',
    'Teacher',
    5,
    '2026-01-01',
    'Office Chair',
    'Ergonomic office chair with lumbar support',
    2,
    'piece',
    'For new staff members',
    'Pending'
)
```

### Step 2: Admin/SuperAdmin Reviews and Approves
```vb
' Admin reviews in UC_PropertyRequestManagement
' Updates the request with approval information
UPDATE property_requests 
SET 
    status = 'Approved',
    approvedBy = 32792,  -- SuperAdmin user ID
    approvedDate = NOW(),
    remarks = 'Approved for procurement'
WHERE requestId = 42786
```

### Step 3: Generate RIS Report
The system uses `modDB.GetRequestById()` to retrieve complete request data:

```vb
Public Shared Function GetRequestById(requestId As Integer, requestType As String) As DataRow
    ' Query joins multiple tables to get complete information:
    
    SELECT 
        pr.requestId AS request_id,
        pr.requesterName,
        pr.position,
        pr.departmentId,
        d.departmentName,              -- From departments table
        pr.dateOfRequest AS request_date,
        pr.itemName AS item_name,
        pr.description,
        pr.quantityRequested AS quantity,
        pr.unit,
        pr.purpose,
        pr.status,
        pr.approvedBy,
        pr.approvedDate AS approval_date,
        pr.remarks,
        CONCAT(u.firstName, ' ', u.lastName) AS approved_by_name  -- From users table
    FROM property_requests pr
    LEFT JOIN departments d ON pr.departmentId = d.departmentId
    LEFT JOIN users u ON pr.approvedBy = u.userId
    WHERE pr.requestId = @requestId
End Function
```

---

## 📊 RIS Form Fields and Data Sources

| **RIS Form Field** | **Database Source** | **Example Value** |
|-------------------|---------------------|-------------------|
| RIS Number | `requestId` | 42786 |
| Entity Name | System Configuration | "Camarines Norte State College" |
| Fund Cluster | System Default | "101 - General Fund" |
| Division | `departmentName` | "Etienza Campus" |
| Office/Section | `departmentName` | "Etienza Campus" |
| Responsibility Center Code | Department code | "ETC-001" |
| Date of Request | `dateOfRequest` | "Thursday, 01 January 2026" |
| Stock/Property Number | Generated or manual | "PROP-2026-001" |
| Unit | `unit` | "piece" |
| Item Description | `itemName` + `description` | "Office Chair - Ergonomic" |
| Quantity Requested | `quantityRequested` | 2 |
| Purpose | `purpose` | "For new staff members" |
| Requested By | `requesterName` | "John Doe" |
| Position | `position` | "Teacher" |
| Approved By | `approved_by_name` | "Super Administrator" |
| Date Approved | `approvedDate` | "01/01/2026" |
| Status | `status` | "Approved" |
| Remarks | `remarks` | "Approved for procurement" |

---

## 💾 How to Generate Test Data

### SQL Script to Create Sample RIS Data:

```sql
-- Step 1: Insert a sample property request
INSERT INTO property_requests (
    requesterName,
    position,
    departmentId,
    dateOfRequest,
    itemName,
    description,
    quantityRequested,
    unit,
    purpose,
    status,
    remarks,
    createdAt,
    updatedAt
) VALUES (
    'Prince Jheck Juan Jr.',
    'Teacher',
    1,  -- Department ID (must exist in departments table)
    '2026-01-03',
    'Laptop Computer',
    'Dell Latitude 5520, 16GB RAM, 512GB SSD',
    1,
    'unit',
    'For online classes and research work',
    'Pending',
    NULL,
    NOW(),
    NOW()
);

-- Get the inserted requestId
SET @lastRequestId = LAST_INSERT_ID();

-- Step 2: Approve the request (as SuperAdmin)
UPDATE property_requests 
SET 
    status = 'Approved',
    approvedBy = 32792,  -- SuperAdmin userId
    approvedDate = NOW(),
    remarks = 'Approved for immediate procurement',
    updatedAt = NOW()
WHERE requestId = @lastRequestId;

-- Step 3: Verify the data
SELECT 
    pr.requestId,
    pr.requesterName,
    pr.itemName,
    pr.quantityRequested,
    pr.unit,
    pr.status,
    pr.approvedDate,
    d.departmentName,
    CONCAT(u.firstName, ' ', u.lastName) AS approved_by_name
FROM property_requests pr
LEFT JOIN departments d ON pr.departmentId = d.departmentId
LEFT JOIN users u ON pr.approvedBy = u.userId
WHERE pr.requestId = @lastRequestId;
```

### Multiple Requests at Once:

```sql
-- Insert multiple property requests
INSERT INTO property_requests 
    (requesterName, position, departmentId, dateOfRequest, itemName, description, 
     quantityRequested, unit, purpose, status, approvedBy, approvedDate) 
VALUES
    ('John Doe', 'Administrative Officer', 1, '2026-01-03', 'Office Desk', 'Standard office desk 120x60cm', 3, 'piece', 'For new office setup', 'Approved', 32792, NOW()),
    ('Jane Smith', 'IT Specialist', 2, '2026-01-03', 'Network Switch', '24-port Gigabit switch', 2, 'unit', 'Network infrastructure upgrade', 'Approved', 32792, NOW()),
    ('Bob Johnson', 'Maintenance Staff', 5, '2026-01-03', 'Tool Set', 'Complete mechanic tool set', 1, 'set', 'Facility maintenance', 'Pending', NULL, NULL);

-- Insert multiple supply requests
INSERT INTO supplies_requests 
    (requesterName, position, departmentId, dateOfRequest, itemName, description, 
     quantityRequested, unit, purpose, status, approvedBy, approvedDate) 
VALUES
    ('Alice Brown', 'Teacher', 3, '2026-01-03', 'Bond Paper', 'A4 size, 80gsm', 10, 'ream', 'Printing class materials', 'Approved', 32792, NOW()),
    ('Charlie Davis', 'Librarian', 4, '2026-01-03', 'Ballpen', 'Blue ink, medium point', 50, 'piece', 'Library use', 'Approved', 32792, NOW());
```

---

## 🖥️ How to Access RIS in the System

### For Staff Members:
1. Login as Staff
2. Go to **My Requests** section
3. View your request history
4. Click **View RIS** button on any approved request
5. The system displays the completed RIS form with all details
6. Export to PDF or print for submission

### For Admin/SuperAdmin:
1. Login as Admin or SuperAdmin
2. Navigate to **Property Request Management**
3. Select a request from the grid
4. Click **Requisition Issue Slip** button
5. The RIS form opens with complete request details
6. Can export to CSV or PDF for official records

---

## 🔧 Troubleshooting

### Issue: "Request not found" error
**Cause:** The `GetRequestById` function couldn't find the request
**Solutions:**
1. Verify the requestId exists in the database
2. Check if the requestType parameter is correct ("properties" or "supply")
3. Ensure the database connection is working

### Issue: Missing department name or approver name
**Cause:** Foreign key relationships not properly set
**Solutions:**
1. Verify `departmentId` exists in `departments` table
2. Verify `approvedBy` userId exists in `users` table
3. Check JOIN clauses in the SQL query

### Issue: RIS shows empty fields
**Cause:** NULL values in database
**Solutions:**
1. Use default values in INSERT statements
2. Update existing records with proper values
3. Check the `SafeGetValue()` helper functions

---

## 📝 Best Practices

1. **Always fill all required fields** when creating a request
2. **Use proper units of measure** (piece, unit, ream, box, etc.)
3. **Provide clear descriptions** for better inventory tracking
4. **Approve requests promptly** to maintain workflow
5. **Keep remarks field updated** with important notes
6. **Generate RIS immediately after approval** for proper documentation

---

## 📞 Support

If you encounter issues with RIS generation:
1. Check the debug output window for error messages
2. Verify database table structures match this guide
3. Ensure all foreign key relationships are intact
4. Test with sample data using the SQL scripts above

---

**Last Updated:** January 3, 2026  
**Version:** 1.0
