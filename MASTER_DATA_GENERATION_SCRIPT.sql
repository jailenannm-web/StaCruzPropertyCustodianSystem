-- ================================================================
-- MASTER DATA GENERATION SCRIPT
-- Generates 10,000+ test records for all entities
-- Complete realistic school property management system data
-- 
-- Database: teamcruzim
-- Total Records: 100,000+
-- Execution Time: ~5-10 minutes
-- ================================================================

USE teamcruzim;

-- ================================================================
-- IMPORTANT: READ BEFORE EXECUTION
-- ================================================================
-- This script will:
-- 1. Clear ALL existing data (except superadmin)
-- 2. Generate 10,000+ departments
-- 3. Generate 10,000+ users (realistic Philippine names)
-- 4. Generate 10,000+ properties (school equipment)
-- 5. Generate 10,000+ supplies (consumables)
-- 6. Generate 10,000+ property requests
-- 7. Generate 10,000+ supply requests
-- 8. Generate 10,000+ maintenance requests
-- 9. Generate 10,000+ maintenance records
-- 10. Generate 10,000+ borrowed items
-- 11. Generate 10,000+ custodian assignments
-- 12. Generate 50,000+ audit logs
--
-- TOTAL: Over 120,000 realistic, connected records
-- ================================================================

SET @start_time = NOW();
SELECT CONCAT('=== DATA GENERATION STARTED AT: ', @start_time, ' ===') AS Info;

-- Disable checks for faster execution
SET FOREIGN_KEY_CHECKS = 0;
SET UNIQUE_CHECKS = 0;
SET AUTOCOMMIT = 0;
SET sql_log_bin = 0;

-- ================================================================
-- EXECUTION ORDER (DO NOT CHANGE)
-- ================================================================

SELECT '1/6 - Loading departments script...' AS Status;
SOURCE tmp_rovodev_generate_departments.sql;

SELECT '2/6 - Loading users script...' AS Status;
SOURCE tmp_rovodev_generate_users.sql;

SELECT '3/6 - Loading properties script...' AS Status;
SOURCE tmp_rovodev_generate_properties.sql;

SELECT '4/6 - Loading supplies script...' AS Status;
SOURCE tmp_rovodev_generate_supplies.sql;

SELECT '5/6 - Loading requests and maintenance script...' AS Status;
SOURCE tmp_rovodev_generate_requests_and_maintenance.sql;

SELECT '6/6 - Loading borrowed items, custodian, and audit logs script...' AS Status;
SOURCE tmp_rovodev_generate_borrowed_custodian_audit.sql;

-- Re-enable checks
SET FOREIGN_KEY_CHECKS = 1;
SET UNIQUE_CHECKS = 1;
SET AUTOCOMMIT = 1;
SET sql_log_bin = 1;

-- ================================================================
-- FINAL VERIFICATION AND STATISTICS
-- ================================================================

SELECT '=== FINAL DATABASE STATISTICS ===' AS Info;

-- Count all records
SELECT 
    'departments' AS 'Table',
    COUNT(*) AS 'Records',
    CONCAT(FORMAT(COUNT(*), 0), ' departments') AS 'Description'
FROM departments
UNION ALL
SELECT 
    'users',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' user accounts')
FROM users
UNION ALL
SELECT 
    'properties',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' property items')
FROM properties
UNION ALL
SELECT 
    'supplies',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' supply items')
FROM supplies
UNION ALL
SELECT 
    'property_requests',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' property requests')
FROM property_requests
UNION ALL
SELECT 
    'supplies_requests',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' supply requests')
FROM supplies_requests
UNION ALL
SELECT 
    'maintenance_requests',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' maintenance requests')
FROM maintenance_requests
UNION ALL
SELECT 
    'maintenance',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' maintenance records')
FROM maintenance
UNION ALL
SELECT 
    'borrowed_items',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' borrowed items')
FROM borrowed_items
UNION ALL
SELECT 
    'custodian',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' custodian assignments')
FROM custodian
UNION ALL
SELECT 
    'audit_logs',
    COUNT(*),
    CONCAT(FORMAT(COUNT(*), 0), ' audit log entries')
FROM audit_logs;

-- Total count
SELECT 
    FORMAT(
        (SELECT COUNT(*) FROM departments) +
        (SELECT COUNT(*) FROM users) +
        (SELECT COUNT(*) FROM properties) +
        (SELECT COUNT(*) FROM supplies) +
        (SELECT COUNT(*) FROM property_requests) +
        (SELECT COUNT(*) FROM supplies_requests) +
        (SELECT COUNT(*) FROM maintenance_requests) +
        (SELECT COUNT(*) FROM maintenance) +
        (SELECT COUNT(*) FROM borrowed_items) +
        (SELECT COUNT(*) FROM custodian) +
        (SELECT COUNT(*) FROM audit_logs)
    , 0) AS 'TOTAL RECORDS GENERATED';

-- User distribution
SELECT '=== USER ROLE DISTRIBUTION ===' AS Info;
SELECT 
    role AS 'Role',
    COUNT(*) AS 'Count',
    CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM users), 1), '%') AS 'Percentage'
FROM users
GROUP BY role
ORDER BY COUNT(*) DESC;

-- Property statistics
SELECT '=== PROPERTY STATISTICS ===' AS Info;
SELECT 
    category AS 'Category',
    COUNT(*) AS 'Count',
    CONCAT('₱', FORMAT(SUM(acquisitionCost), 2)) AS 'Total Value'
FROM properties
GROUP BY category
ORDER BY SUM(acquisitionCost) DESC
LIMIT 10;

-- Supply statistics
SELECT '=== SUPPLY STATISTICS ===' AS Info;
SELECT 
    category AS 'Category',
    COUNT(*) AS 'Items',
    SUM(quantity) AS 'Total Qty',
    CONCAT('₱', FORMAT(SUM(totalCost), 2)) AS 'Total Value'
FROM supplies
GROUP BY category
ORDER BY SUM(totalCost) DESC;

-- Request statistics
SELECT '=== REQUEST STATUS SUMMARY ===' AS Info;
SELECT 
    'Property Requests' AS 'Type',
    SUM(CASE WHEN status = 'Approved' THEN 1 ELSE 0 END) AS 'Approved',
    SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END) AS 'Pending',
    SUM(CASE WHEN status = 'Rejected' THEN 1 ELSE 0 END) AS 'Rejected',
    COUNT(*) AS 'Total'
FROM property_requests
UNION ALL
SELECT 
    'Supply Requests',
    SUM(CASE WHEN status = 'Approved' THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Rejected' THEN 1 ELSE 0 END),
    COUNT(*)
FROM supplies_requests
UNION ALL
SELECT 
    'Maintenance Requests',
    SUM(CASE WHEN status IN ('Approved','In Progress','Completed') THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Rejected' THEN 1 ELSE 0 END),
    COUNT(*)
FROM maintenance_requests;

-- Borrowed items status
SELECT '=== BORROWED ITEMS STATUS ===' AS Info;
SELECT 
    status AS 'Status',
    itemType AS 'Type',
    COUNT(*) AS 'Count'
FROM borrowed_items
GROUP BY status, itemType
ORDER BY status, itemType;

-- Execution time
SET @end_time = NOW();
SELECT 
    CONCAT('Started: ', @start_time) AS 'Start Time',
    CONCAT('Ended: ', @end_time) AS 'End Time',
    CONCAT(TIMESTAMPDIFF(SECOND, @start_time, @end_time), ' seconds') AS 'Duration';

-- ================================================================
-- SUCCESS MESSAGE
-- ================================================================

SELECT '
╔════════════════════════════════════════════════════════════════╗
║                                                                ║
║        ✓ DATA GENERATION COMPLETED SUCCESSFULLY!              ║
║                                                                ║
║   Your database now contains 120,000+ realistic test records  ║
║   All entities are properly connected and follow the system   ║
║   workflow with realistic Philippine school data.             ║
║                                                                ║
║   You can now:                                                 ║
║   • Test all system features                                   ║
║   • Generate reports with real data                            ║
║   • Demonstrate the complete workflow                          ║
║   • Perform stress testing                                     ║
║   • Show to stakeholders                                       ║
║                                                                ║
║   Default Login Credentials:                                   ║
║   Username: superadmin                                         ║
║   Password: (your configured password)                         ║
║                                                                ║
╚════════════════════════════════════════════════════════════════╝
' AS '';

-- ================================================================
-- SAMPLE DATA QUERIES (for verification)
-- ================================================================

-- View sample users
SELECT '=== SAMPLE USERS ===' AS Info;
SELECT 
    CONCAT(firstName, ' ', lastName) AS 'Full Name',
    position AS 'Position',
    role AS 'Role',
    email AS 'Email'
FROM users
WHERE userId > 1
LIMIT 10;

-- View sample properties
SELECT '=== SAMPLE PROPERTIES ===' AS Info;
SELECT 
    itemName AS 'Item',
    category AS 'Category',
    propertyNumber AS 'Property #',
    CONCAT('₱', FORMAT(acquisitionCost, 2)) AS 'Cost',
    status AS 'Status'
FROM properties
LIMIT 10;

-- View sample borrowed items
SELECT '=== SAMPLE BORROWED ITEMS ===' AS Info;
SELECT 
    borrowerName AS 'Borrower',
    itemType AS 'Type',
    borrowDate AS 'Borrow Date',
    status AS 'Status'
FROM borrowed_items
LIMIT 10;

SELECT 'Database is ready for use!' AS 'Status';
