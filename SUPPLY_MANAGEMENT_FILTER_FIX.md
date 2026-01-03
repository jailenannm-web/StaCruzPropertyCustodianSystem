# Supply Management Filter Fix - Complete Guide

## 🔧 Issue Fixed

### The Problem:
The Supply Management filters were not working properly. Specifically:
1. **"Out of Stock" filter showed no results** - Even though there were supplies with "Out of Stock" status
2. The system was filtering out ALL "Out of Stock" items with quantity = 0, regardless of user filter selection

### Root Cause:
In `modDB.vb`, the `GetAllSupplies()` function had a hardcoded filter that excluded supplies with:
```vb
stockStatus = 'Out of Stock' AND quantity = 0
```

This filter was applied BEFORE checking user-selected filters, preventing "Out of Stock" items from ever appearing.

### The Solution:
Modified the filter logic to only exclude soft-deleted supplies when NO status filter is selected:

**Before (Line 8824-8833):**
```vb
query.Append("WHERE 1=1 ")
' Filter out soft-deleted supplies (those with stockStatus = 'Out of Stock' and quantity = 0)
query.Append("AND NOT (s.stockStatus = 'Out of Stock' AND s.quantity = 0)")

If Not String.IsNullOrEmpty(category) Then
    query.Append(" AND s.category = @category")
End If
If Not String.IsNullOrEmpty(status) Then
    query.Append(" AND s.stockStatus = @status")
End If
```

**After (Fixed):**
```vb
query.Append("WHERE 1=1 ")

' Apply filters
If Not String.IsNullOrEmpty(category) Then
    query.Append(" AND s.category = @category")
End If
If Not String.IsNullOrEmpty(status) Then
    query.Append(" AND s.stockStatus = @status")
Else
    ' Only filter out soft-deleted supplies if no status filter is applied
    ' This allows "Out of Stock" items to show when specifically filtered
    query.Append(" AND NOT (s.stockStatus = 'Out of Stock' AND s.quantity = 0)")
End If
```

---

## 📊 Database Schema for Supplies Table

```sql
CREATE TABLE supplies (
  supplyId INT(11) PRIMARY KEY AUTO_INCREMENT,
  itemName VARCHAR(200) NOT NULL,
  category VARCHAR(100) NOT NULL,
  description TEXT,
  unitOfMeasure VARCHAR(50) NOT NULL,
  quantity INT(11) NOT NULL DEFAULT 0,
  dateReceived DATE NOT NULL,
  unitCost DECIMAL(15,2) NOT NULL,
  totalCost DECIMAL(15,2),
  supplier VARCHAR(200),
  sourceOfFunds VARCHAR(200),
  assignedTo INT(11),  -- Foreign key to users.userId
  location VARCHAR(200) NOT NULL,
  stockStatus ENUM('Available','Low Stock','Out of Stock') DEFAULT 'Available',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
)
```

### Valid Values for Filters:

**Category Filter (`pm_cbobx_categ`):**
- "All" (Shows all categories)
- "Office Supplies"
- "Cleaning Supplies"
- "Classroom Supplies"
- "Medical Supplies"
- "IT Supplies"
- "Stationery"
- "Electronics"
- "Furniture"
- "Equipment"
- *(Categories are loaded dynamically from the database)*

**Status Filter (`pm_cbobx_status`):**
- "All Status" (Shows all statuses)
- "Available" (Items in stock and ready)
- "Low Stock" (Items running low)
- "Out of Stock" (Items depleted)

---

## 🔍 How the Filter System Works

### 1. **Filter Dropdowns Initialization**
Located in `UC_SupplyManagement.vb` - `InitializeFilters()` method (Lines 35-106):

```vb
Private Sub InitializeFilters()
    ' Load categories from database
    If pm_cbobx_categ IsNot Nothing Then
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All")
        
        ' Get unique categories from supplies table
        Dim categories As DataTable = modDB.GetCategories("supply")
        ' ... add categories to dropdown
        
        pm_cbobx_categ.SelectedIndex = 0
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
    End If
    
    ' Initialize status dropdown
    If pm_cbobx_status IsNot Nothing Then
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
        pm_cbobx_status.SelectedIndex = 0
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End If
End Sub
```

### 2. **Filter Change Handler**
Located in `UC_SupplyManagement.vb` - `Filter_Changed()` method (Lines 432-448):

```vb
Private Sub Filter_Changed(sender As Object, e As EventArgs)
    ' Reload data with filters
    LoadSuppliesData()
    
    ' Reapply search if there's search text
    ' ... (search reapplication logic)
End Sub
```

### 3. **Data Loading with Filters**
Located in `UC_SupplyManagement.vb` - `LoadSuppliesData()` method (Lines 199-295):

```vb
Public Sub LoadSuppliesData()
    Dim categoryFilter As String = ""
    Dim statusFilter As String = ""
    
    ' Get filter values - exclude "All" and similar default options
    If pm_cbobx_categ IsNot Nothing AndAlso pm_cbobx_categ.SelectedIndex > 0 Then
        Dim selectedCat As String = pm_cbobx_categ.SelectedItem.ToString()
        If Not selectedCat.Equals("All", StringComparison.OrdinalIgnoreCase) Then
            categoryFilter = selectedCat
        End If
    End If
    
    If pm_cbobx_status IsNot Nothing AndAlso pm_cbobx_status.SelectedIndex > 0 Then
        Dim selectedStatus As String = pm_cbobx_status.SelectedItem.ToString()
        If Not selectedStatus.Equals("All Status", StringComparison.OrdinalIgnoreCase) Then
            statusFilter = selectedStatus
        End If
    End If
    
    ' Load supplies from database with filters
    Dim dt As DataTable = modDB.GetAllSupplies(categoryFilter, statusFilter)
    ' ... populate DataGridView
End Sub
```

### 4. **Database Query Execution**
Located in `modDB.vb` - `GetAllSupplies()` method (Lines 8794-8867):

```vb
Public Shared Function GetAllSupplies(Optional category As String = "", 
                                      Optional status As String = "") As DataTable
    ' Build query with JOINs to get assigned user info
    Dim query As StringBuilder
    query.Append("SELECT s.*, assignedEmployee, assignedDepartment ")
    query.Append("FROM supplies s ")
    query.Append("LEFT JOIN users u ON s.assignedTo = u.userId ")
    query.Append("LEFT JOIN departments d ON u.departmentId = d.departmentId ")
    query.Append("WHERE 1=1 ")
    
    ' Apply filters
    If Not String.IsNullOrEmpty(category) Then
        query.Append(" AND s.category = @category")
    End If
    If Not String.IsNullOrEmpty(status) Then
        query.Append(" AND s.stockStatus = @status")
    Else
        ' Only exclude soft-deleted when no status filter is active
        query.Append(" AND NOT (s.stockStatus = 'Out of Stock' AND s.quantity = 0)")
    End If
    
    ' Execute query and return DataTable
End Function
```

---

## 🧪 Testing Guide

### Test Case 1: Category Filter
**Steps:**
1. Login as SuperAdmin or Admin
2. Navigate to **Supply Management**
3. Select a category from the dropdown (e.g., "Office Supplies")
4. **Expected:** Only supplies in that category are shown
5. Verify the count label shows correct number

### Test Case 2: Status Filter - Available
**Steps:**
1. Select **"Available"** from status dropdown
2. **Expected:** Only supplies with stockStatus = 'Available' are shown
3. Verify items in the list show "Available" in the status column

### Test Case 3: Status Filter - Low Stock
**Steps:**
1. Select **"Low Stock"** from status dropdown
2. **Expected:** Only supplies with stockStatus = 'Low Stock' are shown
3. These are items that need reordering

### Test Case 4: Status Filter - Out of Stock (THE FIX)
**Steps:**
1. Select **"Out of Stock"** from status dropdown
2. **Expected:** Supplies with stockStatus = 'Out of Stock' ARE NOW SHOWN
3. **Before Fix:** This showed no results
4. **After Fix:** All out-of-stock items appear (including those with quantity = 0)

### Test Case 5: Combined Filters
**Steps:**
1. Select a category (e.g., "Office Supplies")
2. Select a status (e.g., "Low Stock")
3. **Expected:** Only Office Supplies that are Low Stock are shown
4. Verify both filters work together

### Test Case 6: Search with Filters
**Steps:**
1. Select a category filter
2. Type in the search box
3. **Expected:** Search results are filtered by the selected category
4. Clear search and verify category filter remains active

### Test Case 7: Reset Filters
**Steps:**
1. Select "All" for category
2. Select "All Status" for status
3. **Expected:** All supplies shown (except soft-deleted with quantity=0)
4. This is the default view

### Test Case 8: Soft-Deleted Items
**Steps:**
1. Ensure status filter is "All Status"
2. **Expected:** Items with stockStatus='Out of Stock' AND quantity=0 are hidden
3. Select "Out of Stock" filter
4. **Expected:** Even items with quantity=0 now appear

---

## 🎯 Filter Combinations Matrix

| Category Filter | Status Filter | Result |
|----------------|---------------|---------|
| All | All Status | Shows all supplies except soft-deleted (Out of Stock + qty=0) |
| All | Available | Shows only Available supplies |
| All | Low Stock | Shows only Low Stock supplies |
| All | Out of Stock | **Shows ALL Out of Stock supplies (including qty=0)** ✅ |
| Office Supplies | All Status | Shows only Office Supplies (except soft-deleted) |
| Office Supplies | Available | Shows only Available Office Supplies |
| Office Supplies | Low Stock | Shows only Low Stock Office Supplies |
| Office Supplies | Out of Stock | Shows Out of Stock Office Supplies ✅ |
| *Any Category* | *Any Status* | Applies both filters correctly |

---

## 🔨 SQL Query to Verify Data

Run this in your MySQL/phpMyAdmin to see what data exists:

```sql
-- Check all supplies by status
SELECT stockStatus, COUNT(*) as count, SUM(quantity) as total_qty
FROM supplies
GROUP BY stockStatus;

-- Check Out of Stock items specifically
SELECT supplyId, itemName, category, quantity, stockStatus
FROM supplies
WHERE stockStatus = 'Out of Stock'
ORDER BY quantity DESC;

-- Check soft-deleted items (should be hidden by default)
SELECT supplyId, itemName, category, quantity, stockStatus
FROM supplies
WHERE stockStatus = 'Out of Stock' AND quantity = 0;
```

---

## 📝 Generate Test Data

If you need test data for all statuses:

```sql
-- Insert Available supply
INSERT INTO supplies (itemName, category, description, unitOfMeasure, quantity, 
    dateReceived, unitCost, totalCost, supplier, location, stockStatus)
VALUES ('Test Item - Available', 'Office Supplies', 'Test supply', 'Piece', 100, 
    NOW(), 10.00, 1000.00, 'Test Supplier', 'Main Office', 'Available');

-- Insert Low Stock supply
INSERT INTO supplies (itemName, category, description, unitOfMeasure, quantity, 
    dateReceived, unitCost, totalCost, supplier, location, stockStatus)
VALUES ('Test Item - Low Stock', 'Office Supplies', 'Test supply', 'Piece', 5, 
    NOW(), 10.00, 50.00, 'Test Supplier', 'Main Office', 'Low Stock');

-- Insert Out of Stock supply (quantity > 0)
INSERT INTO supplies (itemName, category, description, unitOfMeasure, quantity, 
    dateReceived, unitCost, totalCost, supplier, location, stockStatus)
VALUES ('Test Item - Out of Stock', 'Office Supplies', 'Test supply', 'Piece', 0, 
    NOW(), 10.00, 0.00, 'Test Supplier', 'Main Office', 'Out of Stock');

-- Insert soft-deleted supply (should be hidden by default)
INSERT INTO supplies (itemName, category, description, unitOfMeasure, quantity, 
    dateReceived, unitCost, totalCost, supplier, location, stockStatus)
VALUES ('Test Item - Soft Deleted', 'Office Supplies', 'Deleted supply', 'Piece', 0, 
    NOW(), 10.00, 0.00, 'Test Supplier', 'Main Office', 'Out of Stock');
```

---

## 🎓 Understanding the Logic

### Why the Original Code Failed:
```vb
' This was ALWAYS applied, even when user selected "Out of Stock"
query.Append("AND NOT (s.stockStatus = 'Out of Stock' AND s.quantity = 0)")
```

This line excluded ALL Out of Stock items with 0 quantity, regardless of what the user selected in the filter dropdown.

### How the Fix Works:
```vb
If Not String.IsNullOrEmpty(status) Then
    ' User selected a specific status - honor it exactly
    query.Append(" AND s.stockStatus = @status")
Else
    ' No status filter - apply default behavior (hide soft-deleted)
    query.Append(" AND NOT (s.stockStatus = 'Out of Stock' AND s.quantity = 0)")
End If
```

Now:
- ✅ When user selects "Out of Stock" → Show ALL Out of Stock items
- ✅ When user selects "Available" or "Low Stock" → Show only those
- ✅ When user selects "All Status" → Show all except soft-deleted (Out of Stock + qty=0)

---

## 🚀 Benefits of This Fix

1. **Filter Accuracy** - Status filters now work as expected
2. **Data Visibility** - Users can see Out of Stock items when needed
3. **Inventory Management** - Better visibility into depleted supplies
4. **Soft-Delete Preservation** - Still hides truly deleted items in default view
5. **User Experience** - Filters behave intuitively

---

## 📌 Additional Notes

### Search Functionality
The search bar works **in combination** with filters:
- Search text filters the already-filtered results
- Category and status filters are applied first
- Then search narrows down those results

### Performance
The query uses proper JOINs and indexes:
- `LEFT JOIN users` - Gets assigned employee info
- `LEFT JOIN departments` - Gets department details
- Indexed on `supplyId`, `category`, `stockStatus`

### Future Enhancements
Consider adding filters for:
- Quantity range (e.g., < 10 items)
- Date range (dateReceived)
- Supplier filter
- Assigned/Unassigned filter

---

**Last Updated:** January 3, 2026  
**Version:** 1.0  
**Fixed By:** Supply Management Filter Fix
