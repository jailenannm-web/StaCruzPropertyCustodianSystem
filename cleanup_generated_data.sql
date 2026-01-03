-- ================================================================
-- CLEANUP SCRIPT - Remove All Generated Test Data
-- Use this to start fresh or remove test data
-- Database: teamcruzim
-- ================================================================

USE teamcruzim;

SELECT '=== STARTING CLEANUP PROCESS ===' AS Info;
SELECT 'WARNING: This will delete ALL generated test data!' AS Warning;
SELECT 'Superadmin account and default categories will be preserved.' AS Note;

-- Show current counts before cleanup
SELECT '=== CURRENT RECORD COUNTS ===' AS Info;

SELECT 
    'departments' AS 'Table',
    COUNT(*) AS 'Before Cleanup'
FROM departments
UNION ALL
SELECT 'users', COUNT(*) FROM users
UNION ALL
SELECT 'properties', COUNT(*) FROM properties
UNION ALL
SELECT 'supplies', COUNT(*) FROM supplies
UNION ALL
SELECT 'property_requests', COUNT(*) FROM property_requests
UNION ALL
SELECT 'supplies_requests', COUNT(*) FROM supplies_requests
UNION ALL
SELECT 'maintenance_requests', COUNT(*) FROM maintenance_requests
UNION ALL
SELECT 'maintenance', COUNT(*) FROM maintenance
UNION ALL
SELECT 'borrowed_items', COUNT(*) FROM borrowed_items
UNION ALL
SELECT 'custodian', COUNT(*) FROM custodian
UNION ALL
SELECT 'audit_logs', COUNT(*) FROM audit_logs;

-- Disable foreign key checks for cleanup
SET FOREIGN_KEY_CHECKS = 0;
SET AUTOCOMMIT = 0;

-- ================================================================
-- DELETE GENERATED DATA (in proper order)
-- ================================================================

SELECT 'Cleaning audit logs...' AS Status;
TRUNCATE TABLE audit_logs;

SELECT 'Cleaning borrowed items...' AS Status;
TRUNCATE TABLE borrowed_items;

SELECT 'Cleaning custodian assignments...' AS Status;
TRUNCATE TABLE custodian;

SELECT 'Cleaning maintenance records...' AS Status;
TRUNCATE TABLE maintenance;

SELECT 'Cleaning maintenance requests...' AS Status;
TRUNCATE TABLE maintenance_requests;

SELECT 'Cleaning property requests...' AS Status;
TRUNCATE TABLE property_requests;

SELECT 'Cleaning supply requests...' AS Status;
TRUNCATE TABLE supplies_requests;

SELECT 'Cleaning properties...' AS Status;
TRUNCATE TABLE properties;

SELECT 'Cleaning supplies...' AS Status;
TRUNCATE TABLE supplies;

SELECT 'Cleaning users (keeping superadmin)...' AS Status;
DELETE FROM users WHERE userId > 1;

SELECT 'Cleaning departments (keeping defaults)...' AS Status;
DELETE FROM departments WHERE departmentId > 5;

COMMIT;

-- ================================================================
-- RESET AUTO INCREMENT VALUES
-- ================================================================

SELECT 'Resetting auto increment values...' AS Status;

ALTER TABLE audit_logs AUTO_INCREMENT = 1;
ALTER TABLE borrowed_items AUTO_INCREMENT = 1;
ALTER TABLE custodian AUTO_INCREMENT = 1;
ALTER TABLE maintenance AUTO_INCREMENT = 1;
ALTER TABLE maintenance_requests AUTO_INCREMENT = 1;
ALTER TABLE property_requests AUTO_INCREMENT = 1;
ALTER TABLE supplies_requests AUTO_INCREMENT = 1;
ALTER TABLE properties AUTO_INCREMENT = 1;
ALTER TABLE supplies AUTO_INCREMENT = 1;
ALTER TABLE users AUTO_INCREMENT = 2;
ALTER TABLE departments AUTO_INCREMENT = 6;

-- Re-enable foreign key checks
SET FOREIGN_KEY_CHECKS = 1;
SET AUTOCOMMIT = 1;

-- ================================================================
-- VERIFY CLEANUP
-- ================================================================

SELECT '=== CLEANUP COMPLETED ===' AS Info;

SELECT 
    'departments' AS 'Table',
    COUNT(*) AS 'After Cleanup',
    CASE 
        WHEN COUNT(*) <= 5 THEN '✓ Cleaned'
        ELSE '✗ Check manually'
    END AS 'Status'
FROM departments
UNION ALL
SELECT 
    'users',
    COUNT(*),
    CASE WHEN COUNT(*) = 1 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM users
UNION ALL
SELECT 
    'properties',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM properties
UNION ALL
SELECT 
    'supplies',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM supplies
UNION ALL
SELECT 
    'property_requests',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM property_requests
UNION ALL
SELECT 
    'supplies_requests',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM supplies_requests
UNION ALL
SELECT 
    'maintenance_requests',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM maintenance_requests
UNION ALL
SELECT 
    'maintenance',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM maintenance
UNION ALL
SELECT 
    'borrowed_items',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM borrowed_items
UNION ALL
SELECT 
    'custodian',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM custodian
UNION ALL
SELECT 
    'audit_logs',
    COUNT(*),
    CASE WHEN COUNT(*) = 0 THEN '✓ Cleaned' ELSE '✗ Check manually' END
FROM audit_logs;

-- ================================================================
-- PRESERVED DATA CHECK
-- ================================================================

SELECT '=== PRESERVED DATA ===' AS Info;

SELECT 
    'Superadmin Account' AS 'Item',
    COUNT(*) AS 'Count',
    'Should be 1' AS 'Expected'
FROM users 
WHERE userId = 1;

SELECT 
    'Default Departments' AS 'Item',
    COUNT(*) AS 'Count',
    'Should be 5' AS 'Expected'
FROM departments 
WHERE departmentId <= 5;

SELECT 
    'Default Categories' AS 'Item',
    COUNT(*) AS 'Count',
    'Should be 7' AS 'Expected'
FROM categories;

-- ================================================================
-- SUCCESS MESSAGE
-- ================================================================

SELECT '
╔════════════════════════════════════════════════════════════╗
║                                                            ║
║        ✓ CLEANUP COMPLETED SUCCESSFULLY!                  ║
║                                                            ║
║   All generated test data has been removed.               ║
║   Your database is now clean and ready for:               ║
║                                                            ║
║   • Fresh data generation                                  ║
║   • Production data import                                 ║
║   • New testing cycle                                      ║
║   • Starting from scratch                                  ║
║                                                            ║
║   Preserved:                                               ║
║   ✓ Superadmin account                                     ║
║   ✓ Default departments (5)                                ║
║   ✓ Default categories (7)                                 ║
║   ✓ Database schema                                        ║
║                                                            ║
╚════════════════════════════════════════════════════════════╝
' AS '';

SELECT 'Database cleanup completed!' AS Status;
SELECT 'You can now regenerate test data or start fresh.' AS Message;

-- ================================================================
-- NEXT STEPS
-- ================================================================

SELECT '
NEXT STEPS:

Option 1: Regenerate Test Data
   Execute: MASTER_DATA_GENERATION_SCRIPT.sql

Option 2: Start Fresh
   Begin entering production data manually

Option 3: Import Production Data
   Use your production data import scripts

' AS 'What to do next';
