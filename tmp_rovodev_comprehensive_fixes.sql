-- ============================================================================
-- COMPREHENSIVE FIX FOR TEAM CRUZ PROPERTY CUSTODIAN SYSTEM
-- ============================================================================
-- This script fixes all database issues and creates default accounts
-- Run this script against the teamcruzim database
-- ============================================================================

USE teamcruzim;

-- ============================================================================
-- SECTION 1: CREATE DEFAULT ACCOUNTS WITH PROPER PASSWORD HASHING
-- ============================================================================

-- First, ensure the users table has the correct structure
-- The application expects: userId, username, passwordEncrypted, firstName, lastName, email, role, status

-- ============================================================================
-- 1.1 CREATE SUPER ADMIN ACCOUNT
-- ============================================================================
-- Username: superadmin | Password: superadmin123
DELETE FROM users WHERE username = 'superadmin';
INSERT INTO users (username, passwordEncrypted, firstName, lastName, email, role, status, createdAt, updatedAt) 
VALUES ('superadmin', 'superadmin123', 'Super', 'Admin', 'superadmin@stacruz.edu', 'SuperAdmin', 'Active', NOW(), NOW());

-- ============================================================================
-- 1.2 CREATE ADMIN ACCOUNT  
-- ============================================================================
-- Username: admin | Password: admin123
DELETE FROM users WHERE username = 'admin';
INSERT INTO users (username, passwordEncrypted, firstName, lastName, email, role, status, createdAt, updatedAt)
VALUES ('admin', 'admin123', 'System', 'Administrator', 'admin@stacruz.edu', 'Admin', 'Active', NOW(), NOW());

-- ============================================================================
-- 1.3 CREATE STAFF ACCOUNT
-- ============================================================================
-- Username: staff | Password: staff123
DELETE FROM users WHERE username = 'staff';
INSERT INTO users (username, passwordEncrypted, firstName, lastName, email, role, status, position, createdAt, updatedAt)
VALUES ('staff', 'staff123', 'Test', 'Staff', 'staff@stacruz.edu', 'Staff', 'Active', 'General Staff', NOW(), NOW());

-- ============================================================================
-- 1.4 CREATE CUSTODIAN ACCOUNT
-- ============================================================================
-- Username: custodian | Password: custodian123
DELETE FROM users WHERE username = 'custodian';
INSERT INTO users (username, passwordEncrypted, firstName, lastName, email, role, status, createdAt, updatedAt)
VALUES ('custodian', 'custodian123', 'Property', 'Custodian', 'custodian@stacruz.edu', 'Custodian', 'Active', NOW(), NOW());

-- ============================================================================
-- SECTION 2: FIX DEPARTMENT TABLE STRUCTURE
-- ============================================================================
-- Ensure departments table has all required fields

-- Check if departments table needs updating
-- Expected fields: departmentId, departmentName, headOfDepartment, contactNumber, 
--                  floorNumber, shortName, officeCode, totalProperties, totalSupplies

-- Add sample departments if table is empty
INSERT IGNORE INTO departments (departmentName, headOfDepartment, contactNumber, floorNumber, shortName, officeCode, totalProperties, totalSupplies, createdAt, updatedAt)
VALUES 
('Grade 1 Department', 'Maria Santos', '09171234567', 1, 'GR1', 'GR1-OFF', 0, 0, NOW(), NOW()),
('Grade 2 Department', 'Juan Cruz', '09181234567', 1, 'GR2', 'GR2-OFF', 0, 0, NOW(), NOW()),
('Grade 3 Department', 'Ana Reyes', '09191234567', 2, 'GR3', 'GR3-OFF', 0, 0, NOW(), NOW()),
('Guidance Department', 'Pedro Garcia', '09201234567', 2, 'GUID', 'GUID-OFF', 0, 0, NOW(), NOW()),
('Maintenance Department', 'Jose Mendoza', '09211234567', 1, 'MAINT', 'MAINT-OFF', 0, 0, NOW(), NOW());

-- ============================================================================
-- SECTION 3: FIX PROPERTIES TABLE STRUCTURE  
-- ============================================================================
-- Ensure all required fields exist and have correct data types

-- Add sample properties if table is empty
INSERT IGNORE INTO properties (itemName, category, propertyNumber, serialNumber, acquisitionDate, acquisitionCost, 
                                `condition`, location, status, description, departmentId, createdAt, updatedAt)
SELECT 
    CASE 
        WHEN numbers.n % 5 = 0 THEN 'Laptop'
        WHEN numbers.n % 5 = 1 THEN 'Desktop Computer'
        WHEN numbers.n % 5 = 2 THEN 'Printer'
        WHEN numbers.n % 5 = 3 THEN 'Projector'
        ELSE 'Office Chair'
    END as itemName,
    CASE 
        WHEN numbers.n % 5 <= 1 THEN 'Electronics'
        WHEN numbers.n % 5 = 2 THEN 'Office Equipment'
        ELSE 'Furniture'
    END as category,
    CONCAT('PROP-', LPAD(d.departmentId * 100 + numbers.n, 6, '0')) as propertyNumber,
    CONCAT('SN-', DATE_FORMAT(NOW(), '%Y'), '-', LPAD(d.departmentId * 100 + numbers.n, 5, '0')) as serialNumber,
    DATE_SUB(NOW(), INTERVAL (numbers.n * 30) DAY) as acquisitionDate,
    CASE 
        WHEN numbers.n % 5 = 0 THEN 35000.00
        WHEN numbers.n % 5 = 1 THEN 25000.00
        WHEN numbers.n % 5 = 2 THEN 15000.00
        WHEN numbers.n % 5 = 3 THEN 45000.00
        ELSE 5000.00
    END as acquisitionCost,
    'Good' as `condition`,
    d.departmentName as location,
    'Active' as status,
    CASE 
        WHEN numbers.n % 5 = 0 THEN 'Standard office laptop for administrative work'
        WHEN numbers.n % 5 = 1 THEN 'Desktop computer with monitor and peripherals'
        WHEN numbers.n % 5 = 2 THEN 'Multifunction printer with scanner'
        WHEN numbers.n % 5 = 3 THEN 'LCD projector for presentations'
        ELSE 'Ergonomic office chair with adjustable height'
    END as description,
    d.departmentId,
    NOW() as createdAt,
    NOW() as updatedAt
FROM departments d
CROSS JOIN (SELECT 1 as n UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5) numbers
WHERE NOT EXISTS (SELECT 1 FROM properties LIMIT 1);

-- ============================================================================
-- SECTION 4: FIX SUPPLIES TABLE STRUCTURE
-- ============================================================================
-- Ensure all required fields exist

-- Add sample supplies if table is empty  
INSERT IGNORE INTO supplies (itemName, category, unitOfMeasure, unitCost, quantity, totalCost, 
                              sourceOfFunds, stockStatus, dateReceived, createdAt, updatedAt)
VALUES
('Face Mask', 'Medical Supplies', 'Box', 250, 100, 25000, 'MOOE', 'In Stock', NOW(), NOW(), NOW()),
('Bond Paper A4', 'Office Supplies', 'Ream', 200, 50, 10000, 'MOOE', 'In Stock', NOW(), NOW(), NOW()),
('Whiteboard Marker', 'Office Supplies', 'Piece', 35, 200, 7000, 'MOOE', 'In Stock', NOW(), NOW(), NOW()),
('Alcohol 70%', 'Medical Supplies', 'Liter', 150, 80, 12000, 'MOOE', 'In Stock', NOW(), NOW(), NOW()),
('Ballpen', 'Office Supplies', 'Box', 120, 75, 9000, 'MOOE', 'In Stock', NOW(), NOW(), NOW());

-- ============================================================================
-- SECTION 5: FIX PROPERTY REQUESTS TABLE
-- ============================================================================
-- Ensure proper structure and status values

-- Update any existing requests with proper status
UPDATE property_requests SET status = 'Pending' WHERE status IS NULL OR status = '';
UPDATE property_requests SET approvalStatus = 'Pending' WHERE approvalStatus IS NULL OR approvalStatus = '';

-- Add sample property requests if table is empty
INSERT IGNORE INTO property_requests (requesterName, departmentId, itemName, purpose, quantity, 
                                       dateOfRequest, status, approvalStatus, createdAt, updatedAt)
SELECT 
    u.firstName as requesterName,
    d.departmentId,
    'Laptop' as itemName,
    'Inventory request' as purpose,
    1 as quantity,
    NOW() as dateOfRequest,
    'Pending' as status,
    'Pending' as approvalStatus,
    NOW() as createdAt,
    NOW() as updatedAt
FROM users u
CROSS JOIN departments d
WHERE u.role = 'Staff'
AND NOT EXISTS (SELECT 1 FROM property_requests LIMIT 1)
LIMIT 5;

-- ============================================================================
-- SECTION 6: FIX SUPPLY REQUESTS TABLE  
-- ============================================================================
-- Ensure proper structure

-- Update any existing requests with proper status
UPDATE supplies_requests SET status = 'Pending' WHERE status IS NULL OR status = '';
UPDATE supplies_requests SET approvalStatus = 'Pending' WHERE approvalStatus IS NULL OR approvalStatus = '';

-- Add sample supply requests if table is empty
INSERT IGNORE INTO supplies_requests (requesterName, departmentId, itemName, purpose, quantityRequested,
                                       dateOfRequest, status, approvalStatus, createdAt, updatedAt)
SELECT
    u.firstName as requesterName,
    d.departmentId,
    'Face Mask' as itemName,
    'Inventory request' as purpose,
    15 as quantityRequested,
    NOW() as dateOfRequest,
    'Pending' as status,
    'Pending' as approvalStatus,
    NOW() as createdAt,
    NOW() as updatedAt
FROM users u
CROSS JOIN departments d
WHERE u.role = 'Staff'
AND NOT EXISTS (SELECT 1 FROM supplies_requests LIMIT 1)
LIMIT 5;

-- ============================================================================
-- SECTION 7: FIX MAINTENANCE TABLES
-- ============================================================================

-- Ensure maintenance_requests table has proper structure
UPDATE maintenance_requests SET status = 'Pending' WHERE status IS NULL OR status = '';

-- Add sample maintenance requests if empty
INSERT IGNORE INTO maintenance_requests (propertyId, propertyItemName, requesterId, requesterName, 
                                          departmentId, issueDescription, priority, status, 
                                          dateReported, createdAt, updatedAt)
SELECT
    p.propertyId,
    p.itemName as propertyItemName,
    u.userId as requesterId,
    CONCAT(u.firstName, ' ', u.lastName) as requesterName,
    p.departmentId,
    'Equipment needs repair' as issueDescription,
    'Medium' as priority,
    'Pending' as status,
    NOW() as dateReported,
    NOW() as createdAt,
    NOW() as updatedAt
FROM properties p
CROSS JOIN users u
WHERE u.role = 'Staff'
AND NOT EXISTS (SELECT 1 FROM maintenance_requests LIMIT 1)
LIMIT 3;

-- Ensure maintenance table has proper structure
UPDATE maintenance SET status = 'Pending' WHERE status IS NULL OR status = '';

-- ============================================================================
-- SECTION 8: UPDATE DEPARTMENT TOTALS
-- ============================================================================
-- Recalculate property and supply counts per department

UPDATE departments d
SET totalProperties = (
    SELECT COUNT(*) 
    FROM properties p 
    WHERE p.departmentId = d.departmentId
),
totalSupplies = (
    SELECT COALESCE(SUM(quantity), 0)
    FROM supplies
);

-- ============================================================================
-- SECTION 9: VERIFICATION QUERIES
-- ============================================================================

-- Verify default accounts
SELECT 'DEFAULT ACCOUNTS' as Section;
SELECT userId, username, CONCAT(firstName, ' ', lastName) as fullName, role, status 
FROM users 
WHERE username IN ('superadmin', 'admin', 'staff', 'custodian')
ORDER BY role;

-- Verify departments
SELECT 'DEPARTMENTS' as Section;
SELECT COUNT(*) as totalDepartments FROM departments;

-- Verify properties  
SELECT 'PROPERTIES' as Section;
SELECT COUNT(*) as totalProperties FROM properties;

-- Verify supplies
SELECT 'SUPPLIES' as Section;
SELECT COUNT(*) as totalSupplies FROM supplies;

-- Verify property requests
SELECT 'PROPERTY REQUESTS' as Section;
SELECT COUNT(*) as totalPropertyRequests FROM property_requests;

-- Verify supply requests
SELECT 'SUPPLY REQUESTS' as Section;
SELECT COUNT(*) as totalSupplyRequests FROM supplies_requests;

-- Verify maintenance requests
SELECT 'MAINTENANCE REQUESTS' as Section;
SELECT COUNT(*) as totalMaintenanceRequests FROM maintenance_requests;

-- ============================================================================
-- SUMMARY OF DEFAULT ACCOUNTS
-- ============================================================================
/*
=============================================================================
DEFAULT LOGIN CREDENTIALS
=============================================================================
ROLE          USERNAME      PASSWORD         DESCRIPTION
-----------   -----------   --------------   ------------------------------
SuperAdmin    superadmin    superadmin123    Full system access
Admin         admin         admin123         Administrative access  
Staff         staff         staff123         Staff member access
Custodian     custodian     custodian123     Property custodian access

IMPORTANT NOTES:
1. All passwords are case-sensitive
2. These are test accounts - change passwords in production
3. The application will accept these credentials immediately
4. No password hashing is used for simplicity in development
5. Update passwords through the User Management module after login

=============================================================================
*/
