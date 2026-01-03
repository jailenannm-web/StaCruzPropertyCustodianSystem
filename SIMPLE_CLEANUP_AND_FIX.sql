-- ================================================================
-- SIMPLE CLEANUP AND DEPARTMENT FIX
-- Run this script to fix the department duplicate issue
-- ================================================================

USE teamcruzim;

-- ================================================================
-- STEP 1: Clear old departments
-- ================================================================

DELETE FROM departments WHERE departmentId > 5;

-- ================================================================
-- STEP 2: Reset auto increment
-- ================================================================

ALTER TABLE departments AUTO_INCREMENT = 6;

-- ================================================================
-- STEP 3: Verify cleanup
-- ================================================================

SELECT 'Cleanup completed!' AS Status;
SELECT COUNT(*) AS 'Remaining Departments (should be 5)' FROM departments;

-- ================================================================
-- NEXT STEP: Now run the individual department generation script
-- Import: tmp_rovodev_generate_departments.sql
-- ================================================================

SELECT '
╔════════════════════════════════════════════════════════╗
║                                                        ║
║  ✓ Cleanup Complete!                                  ║
║                                                        ║
║  Next Step:                                            ║
║  1. Go to Import tab in phpMyAdmin                     ║
║  2. Select: tmp_rovodev_generate_departments.sql       ║
║  3. Click Go                                           ║
║                                                        ║
╚════════════════════════════════════════════════════════╝
' AS 'Instructions';
