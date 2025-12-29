-- ================================================================
-- TEST SCRIPT FOR PROPERTY REQUEST APPROVAL FUNCTIONALITY
-- This script tests the approval process that updates properties
-- ================================================================

USE teamcruzim;

-- ================================================================
-- STEP 1: Create a test property (unassigned)
-- ================================================================
INSERT INTO properties (itemName, category, description, propertyNumber, serialNumber, 
                       acquisitionDate, acquisitionCost, location, `condition`, status, createdAt, updatedAt)
VALUES ('Test Laptop', 'IT Equipment', 'Test laptop for approval', 'PROP-2025-TEST01', 'SN-TEST-001',
        NOW(), 25000.00, 'Storage Room', 'Good', 'Active', NOW(), NOW());

SELECT 'Test property created' AS Result;
SELECT * FROM properties WHERE propertyNumber = 'PROP-2025-TEST01';

-- ================================================================
-- STEP 2: Create a test user (requester)
-- ================================================================
INSERT INTO users (firstName, lastName, username, passwordEncrypted, email, role, departmentId, status, createdAt, updatedAt)
VALUES ('Test', 'User', 'testuser', '$2a$11$test', 'testuser@example.com', 'Staff', 2, 'Active', NOW(), NOW())
ON DUPLICATE KEY UPDATE status = 'Active';

SELECT 'Test user created/updated' AS Result;
SELECT userId, fullName, departmentId FROM users WHERE username = 'testuser';

-- ================================================================
-- STEP 3: Create a property request from the test user
-- ================================================================
INSERT INTO property_requests (requesterName, position, departmentId, dateOfRequest, 
                               itemName, description, quantityRequested, purpose, status, createdAt, updatedAt)
VALUES ('Test User', 'Staff', 2, NOW(), 'Test Laptop', 'Request for laptop', 1, 
        'Testing approval functionality', 'Pending', NOW(), NOW());

SELECT 'Test property request created' AS Result;
SELECT requestId, requesterName, itemName, departmentId, status FROM property_requests WHERE requesterName = 'Test User';

-- ================================================================
-- STEP 4: Show current state BEFORE approval
-- ================================================================
SELECT '=== BEFORE APPROVAL ===' AS Status;

SELECT 'Property Request:' AS Info;
SELECT requestId, requesterName, itemName, departmentId, status FROM property_requests 
WHERE requesterName = 'Test User' ORDER BY requestId DESC LIMIT 1;

SELECT 'Property (should be unassigned):' AS Info;
SELECT propertyId, itemName, assignedTo, departmentId, location, status FROM properties 
WHERE propertyNumber = 'PROP-2025-TEST01';

-- ================================================================
-- NOTE: The actual approval will be done through the application
-- When admin/superadmin clicks "Approve" button, the following happens:
-- 1. property_requests.status = 'Approved'
-- 2. properties.assignedTo = requester's userId
-- 3. properties.departmentId = requester's departmentId
-- 4. properties.location = requester's department location
-- 5. borrowed_items record created
-- ================================================================

-- ================================================================
-- STEP 5: Simulate what the approval function will do (for reference)
-- ================================================================
SELECT '=== SIMULATING APPROVAL (for reference only) ===' AS Status;

-- Get the request ID we just created
SET @testRequestId = (SELECT requestId FROM property_requests WHERE requesterName = 'Test User' ORDER BY requestId DESC LIMIT 1);
SET @testUserId = (SELECT userId FROM users WHERE username = 'testuser');
SET @testDeptId = (SELECT departmentId FROM users WHERE username = 'testuser');
SET @testDeptLocation = (SELECT location FROM departments WHERE departmentId = @testDeptId);

SELECT CONCAT('Request ID: ', @testRequestId) AS Info;
SELECT CONCAT('User ID: ', @testUserId) AS Info;
SELECT CONCAT('Department ID: ', @testDeptId) AS Info;
SELECT CONCAT('Department Location: ', @testDeptLocation) AS Info;

-- ================================================================
-- STEP 6: Instructions for manual testing
-- ================================================================
SELECT '=== TESTING INSTRUCTIONS ===' AS Info;
SELECT '1. Run this script to create test data' AS Step;
SELECT '2. Login to the application as Admin or SuperAdmin' AS Step;
SELECT '3. Go to Property Request Management' AS Step;
SELECT '4. Find the request for "Test Laptop" from "Test User"' AS Step;
SELECT '5. Click the Approve button' AS Step;
SELECT '6. Run the verification query below to check results' AS Step;

-- ================================================================
-- VERIFICATION QUERY (Run AFTER approving through the application)
-- ================================================================
SELECT '=== RUN THIS AFTER APPROVAL ===' AS Info;

/*
-- VERIFICATION QUERIES - RUN THESE AFTER APPROVING IN THE APPLICATION

SELECT '=== AFTER APPROVAL - VERIFICATION ===' AS Status;

SELECT 'Property Request (should be Approved):' AS Info;
SELECT requestId, requesterName, itemName, departmentId, status, approvedDate, remarks 
FROM property_requests 
WHERE requesterName = 'Test User' 
ORDER BY requestId DESC LIMIT 1;

SELECT 'Property (should be assigned to Test User):' AS Info;
SELECT p.propertyId, p.itemName, p.assignedTo, u.fullName AS assignedToName, 
       p.departmentId, d.departmentName, p.location, p.status 
FROM properties p
LEFT JOIN users u ON p.assignedTo = u.userId
LEFT JOIN departments d ON p.departmentId = d.departmentId
WHERE p.propertyNumber = 'PROP-2025-TEST01';

SELECT 'Borrowed Items (should have new record):' AS Info;
SELECT bi.borrowId, bi.itemType, bi.itemId, bi.borrowerName, bi.departmentId, 
       bi.borrowDate, bi.status, bi.remarks
FROM borrowed_items bi
WHERE bi.itemType = 'property' AND bi.itemId = (SELECT propertyId FROM properties WHERE propertyNumber = 'PROP-2025-TEST01')
ORDER BY bi.borrowId DESC LIMIT 1;

*/

-- ================================================================
-- CLEANUP (Run this to remove test data after testing)
-- ================================================================
/*
DELETE FROM borrowed_items WHERE itemType = 'property' AND itemId = (SELECT propertyId FROM properties WHERE propertyNumber = 'PROP-2025-TEST01');
DELETE FROM property_requests WHERE requesterName = 'Test User';
DELETE FROM properties WHERE propertyNumber = 'PROP-2025-TEST01';
DELETE FROM users WHERE username = 'testuser';

SELECT 'Test data cleaned up' AS Result;
*/
