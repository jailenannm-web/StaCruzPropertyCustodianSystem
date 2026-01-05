-- ============================================================================
-- SIMPLE TEST DATA FOR DASHBOARD TESTING
-- ============================================================================
-- This assumes you already have the 'prince' user created in your system
-- This script only creates the request/borrowed/maintenance data
-- ============================================================================

-- First, let's check what user exists and get their exact full name
SELECT userId, username, firstName, middleName, lastName, 
       CONCAT(firstName, IFNULL(CONCAT(' ', middleName), ''), ' ', lastName) as fullName
FROM users 
WHERE username LIKE '%prince%' OR firstName LIKE '%prince%';

-- If you see a user above, note their EXACT fullName format
-- Then use that exact format below

-- For now, let's assume the format is "Prince Juan" (no middle name)
-- ============================================================================

-- Get the superadmin userId (should be 1)
SET @adminUserId = (SELECT userId FROM users WHERE role = 'SuperAdmin' LIMIT 1);

-- Get any existing department ID (or use NULL if none exists)
SET @deptId = (SELECT departmentId FROM departments LIMIT 1);

-- Step 1: Generate Property Requests
-- Replace 'Prince Juan' with the exact fullName from the query above
-- Using @deptId which will be NULL if no departments exist (foreign key allows NULL)
INSERT INTO property_requests (requesterName, position, departmentId, dateOfRequest, itemName, description, quantityRequested, unit, purpose, status, approvedBy, approvedDate)
VALUES 
('Prince Juan', 'Staff', @deptId, '2024-12-01', 'Desktop Computer', 'For office work', 1, 'unit', 'Daily office tasks', 'Approved', @adminUserId, NOW()),
('Prince Juan', 'Staff', @deptId, '2024-12-05', 'Office Chair', 'Ergonomic chair', 1, 'unit', 'Workspace improvement', 'Approved', @adminUserId, NOW()),
('Prince Juan', 'Staff', @deptId, '2024-12-08', 'Laptop', 'Portable computer', 1, 'unit', 'Field work', 'Pending', NULL, NULL),
('Prince Juan', 'Staff', @deptId, '2024-12-10', 'Monitor', 'LED display', 1, 'unit', 'Additional screen', 'Pending', NULL, NULL),
('Prince Juan', 'Staff', @deptId, '2024-11-20', 'Printer', 'Office printer', 1, 'unit', 'Document printing', 'Rejected', @adminUserId, NOW());

-- Step 2: Generate Supply Requests
INSERT INTO supplies_requests (requesterName, position, departmentId, dateOfRequest, itemName, description, quantityRequested, unit, purpose, status, approvedBy, approvedDate)
VALUES 
('Prince Juan', 'Staff', @deptId, '2024-12-01', 'Ballpen', 'Blue ink', 20, 'pcs', 'Office use', 'Approved', @adminUserId, NOW()),
('Prince Juan', 'Staff', @deptId, '2024-12-05', 'Bond Paper', 'A4 size', 10, 'reams', 'Printing', 'Approved', @adminUserId, NOW()),
('Prince Juan', 'Staff', @deptId, '2024-12-08', 'Folder', 'Document folders', 15, 'pcs', 'File organization', 'Pending', NULL, NULL),
('Prince Juan', 'Staff', @deptId, '2024-12-10', 'Stapler', 'Heavy duty', 2, 'pcs', 'Document binding', 'Pending', NULL, NULL),
('Prince Juan', 'Staff', @deptId, '2024-11-25', 'Notebook', 'Spiral notebook', 5, 'pcs', 'Meeting notes', 'Rejected', @adminUserId, NOW());

-- Step 3: Create some dummy properties to borrow
INSERT INTO properties (itemName, category, description, unitOfMeasure, propertyNumber, acquisitionDate, acquisitionCost, departmentId, location, `condition`, status)
VALUES 
('Test Laptop', 'IT Equipment', 'Test laptop for borrowing', 'unit', 'TEST-001', '2024-01-01', 25000.00, @deptId, 'Office', 'Good', 'Active'),
('Test Projector', 'Office Equipment', 'Test projector', 'unit', 'TEST-002', '2024-01-01', 15000.00, @deptId, 'Office', 'Good', 'Active')
ON DUPLICATE KEY UPDATE itemName=itemName; -- Skip if already exists

-- Get the property IDs we just created
SET @laptopId = (SELECT propertyId FROM properties WHERE propertyNumber = 'TEST-001' LIMIT 1);
SET @projectorId = (SELECT propertyId FROM properties WHERE propertyNumber = 'TEST-002' LIMIT 1);

-- Step 4: Generate Borrowed Items
INSERT INTO borrowed_items (itemType, itemId, borrowerName, borrowerPosition, departmentId, borrowDate, expectedReturnDate, status)
VALUES 
('property', @laptopId, 'Prince Juan', 'Staff', @deptId, '2024-12-01', '2024-12-15', 'Borrowed'),
('property', @projectorId, 'Prince Juan', 'Staff', @deptId, '2024-11-20', '2024-12-05', 'Borrowed');

-- Step 5: Generate Maintenance Requests
-- First get the userId for prince
SET @princeUserId = (SELECT userId FROM users WHERE username = 'prince' LIMIT 1);

INSERT INTO maintenance_requests (dateRequested, itemName, propertyNumber, departmentId, typeOfIssue, problemDescription, status, requestedBy)
VALUES 
('2024-12-05', 'Air Conditioner', 'AC-001', @deptId, 'Repair', 'Not cooling properly', 'Pending', @princeUserId),
('2024-11-28', 'Printer', 'PRINT-001', @deptId, 'Repair', 'Paper jam issue', 'In Progress', @princeUserId),
('2024-11-15', 'Office Chair', 'CHAIR-001', @deptId, 'Repair', 'Broken wheels', 'Completed', @princeUserId);

-- ============================================================================
-- VERIFICATION QUERIES - Run these to confirm data was inserted
-- ============================================================================

SELECT '=== PROPERTY REQUESTS ===' as section;
SELECT requestId, requesterName, itemName, status, dateOfRequest 
FROM property_requests 
WHERE requesterName = 'Prince Juan'
ORDER BY dateOfRequest DESC;

SELECT '=== SUPPLY REQUESTS ===' as section;
SELECT requestId, requesterName, itemName, status, dateOfRequest 
FROM supplies_requests 
WHERE requesterName = 'Prince Juan'
ORDER BY dateOfRequest DESC;

SELECT '=== BORROWED ITEMS ===' as section;
SELECT borrowId, borrowerName, itemType, status, borrowDate 
FROM borrowed_items 
WHERE borrowerName = 'Prince Juan'
ORDER BY borrowDate DESC;

SELECT '=== MAINTENANCE REQUESTS ===' as section;
SELECT requestId, itemName, status, dateRequested 
FROM maintenance_requests 
WHERE requestedBy = @princeUserId
ORDER BY dateRequested DESC;

SELECT '=== SUMMARY ===' as section;
SELECT 
    (SELECT COUNT(*) FROM property_requests WHERE requesterName = 'Prince Juan') as property_requests,
    (SELECT COUNT(*) FROM supplies_requests WHERE requesterName = 'Prince Juan') as supply_requests,
    (SELECT COUNT(*) FROM borrowed_items WHERE borrowerName = 'Prince Juan') as borrowed_items,
    (SELECT COUNT(*) FROM maintenance_requests WHERE requestedBy = @princeUserId) as maintenance_requests;
