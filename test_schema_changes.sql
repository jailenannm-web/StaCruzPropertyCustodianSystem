-- ================================================================
-- TEST SCRIPT FOR SCHEMA CHANGES
-- Run this after applying fix_borrowed_items_schema_complete.sql
-- Database: teamcruzim
-- ================================================================

USE teamcruzim;

-- ================================================================
-- TEST 1: Verify borrowed_items table structure
-- ================================================================

SELECT '========================================' AS '';
SELECT 'TEST 1: Verify borrowed_items Structure' AS TestName;
SELECT '========================================' AS '';

SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'teamcruzim'
  AND TABLE_NAME = 'borrowed_items'
  AND COLUMN_NAME IN ('itemName', 'returnReason', 'expectedReturnDate')
ORDER BY ORDINAL_POSITION;

-- Check: Should show itemName and returnReason, NOT expectedReturnDate
SELECT 
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'borrowed_items' 
            AND COLUMN_NAME = 'itemName'
        ) THEN '✓ PASS'
        ELSE '✗ FAIL'
    END AS 'itemName Column Exists',
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'borrowed_items' 
            AND COLUMN_NAME = 'returnReason'
        ) THEN '✓ PASS'
        ELSE '✗ FAIL'
    END AS 'returnReason Column Exists',
    CASE 
        WHEN NOT EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'borrowed_items' 
            AND COLUMN_NAME = 'expectedReturnDate'
        ) THEN '✓ PASS'
        ELSE '✗ FAIL'
    END AS 'expectedReturnDate Removed';

-- ================================================================
-- TEST 2: Verify supplies table structure
-- ================================================================

SELECT '========================================' AS '';
SELECT 'TEST 2: Verify supplies Structure' AS TestName;
SELECT '========================================' AS '';

SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    COLUMN_KEY
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'teamcruzim'
  AND TABLE_NAME = 'supplies'
  AND COLUMN_NAME IN ('assignedTo', 'departmentId')
ORDER BY ORDINAL_POSITION;

-- Check: Should show assignedTo and departmentId
SELECT 
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'supplies' 
            AND COLUMN_NAME = 'assignedTo'
        ) THEN '✓ PASS'
        ELSE '✗ FAIL'
    END AS 'assignedTo Column Exists',
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'supplies' 
            AND COLUMN_NAME = 'departmentId'
        ) THEN '✓ PASS'
        ELSE '✗ FAIL'
    END AS 'departmentId Column Exists';

-- ================================================================
-- TEST 3: Verify foreign key constraints
-- ================================================================

SELECT '========================================' AS '';
SELECT 'TEST 3: Verify Foreign Key Constraints' AS TestName;
SELECT '========================================' AS '';

SELECT 
    CONSTRAINT_NAME,
    TABLE_NAME,
    COLUMN_NAME,
    REFERENCED_TABLE_NAME,
    REFERENCED_COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE TABLE_SCHEMA = 'teamcruzim'
  AND TABLE_NAME = 'supplies'
  AND CONSTRAINT_NAME IN ('fk_supplies_assignedTo', 'fk_supplies_departmentId')
ORDER BY CONSTRAINT_NAME;

-- Check foreign keys exist
SELECT 
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'supplies' 
            AND CONSTRAINT_NAME = 'fk_supplies_assignedTo'
        ) THEN '✓ PASS'
        ELSE '✗ FAIL'
    END AS 'FK to users Exists',
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'supplies' 
            AND CONSTRAINT_NAME = 'fk_supplies_departmentId'
        ) THEN '✓ PASS'
        ELSE '✗ FAIL'
    END AS 'FK to departments Exists';

-- ================================================================
-- TEST 4: Verify indexes
-- ================================================================

SELECT '========================================' AS '';
SELECT 'TEST 4: Verify Indexes' AS TestName;
SELECT '========================================' AS '';

SELECT 
    TABLE_NAME,
    INDEX_NAME,
    COLUMN_NAME
FROM INFORMATION_SCHEMA.STATISTICS
WHERE TABLE_SCHEMA = 'teamcruzim'
  AND (
    (TABLE_NAME = 'borrowed_items' AND INDEX_NAME = 'idx_borrow_itemName')
    OR (TABLE_NAME = 'supplies' AND INDEX_NAME IN ('idx_supply_assigned', 'idx_supply_department'))
  )
ORDER BY TABLE_NAME, INDEX_NAME;

-- ================================================================
-- TEST 5: Check data population in borrowed_items
-- ================================================================

SELECT '========================================' AS '';
SELECT 'TEST 5: Check Data Population' AS TestName;
SELECT '========================================' AS '';

-- Count records with and without itemName
SELECT 
    COUNT(*) AS TotalBorrowedItems,
    SUM(CASE WHEN itemName IS NOT NULL AND itemName != '' THEN 1 ELSE 0 END) AS WithItemName,
    SUM(CASE WHEN itemName IS NULL OR itemName = '' THEN 1 ELSE 0 END) AS WithoutItemName,
    SUM(CASE WHEN returnReason IS NOT NULL THEN 1 ELSE 0 END) AS WithReturnReason
FROM borrowed_items;

-- Show sample data
SELECT 
    borrowId,
    itemType,
    itemId,
    itemName,
    borrowerName,
    borrowDate,
    returnReason,
    status
FROM borrowed_items
ORDER BY borrowId DESC
LIMIT 5;

-- ================================================================
-- TEST 6: Sample borrowed_items queries
-- ================================================================

SELECT '========================================' AS '';
SELECT 'TEST 6: Sample Queries' AS TestName;
SELECT '========================================' AS '';

-- Query 1: All currently borrowed items (no JOIN needed!)
SELECT 
    'Currently Borrowed Items (Fast Query)' AS QueryDescription;
    
SELECT 
    borrowId,
    itemType,
    itemName,
    borrowerName,
    borrowDate,
    status
FROM borrowed_items
WHERE status = 'Borrowed'
ORDER BY borrowDate DESC
LIMIT 5;

-- Query 2: Items with return reasons
SELECT 
    'Items Returned with Reasons' AS QueryDescription;

SELECT 
    borrowId,
    itemType,
    itemName,
    borrowerName,
    returnReason,
    actualReturnDate
FROM borrowed_items
WHERE status = 'Returned' 
  AND returnReason IS NOT NULL
ORDER BY actualReturnDate DESC
LIMIT 5;

-- ================================================================
-- TEST 7: Test supplies with assignments
-- ================================================================

SELECT '========================================' AS '';
SELECT 'TEST 7: Supplies Assignment' AS TestName;
SELECT '========================================' AS '';

-- Count supplies with and without assignments
SELECT 
    COUNT(*) AS TotalSupplies,
    SUM(CASE WHEN assignedTo IS NOT NULL THEN 1 ELSE 0 END) AS AssignedSupplies,
    SUM(CASE WHEN assignedTo IS NULL THEN 1 ELSE 0 END) AS UnassignedSupplies,
    SUM(CASE WHEN departmentId IS NOT NULL THEN 1 ELSE 0 END) AS WithDepartment
FROM supplies;

-- Show sample supply data
SELECT 
    supplyId,
    itemName,
    quantity,
    assignedTo,
    departmentId,
    stockStatus
FROM supplies
LIMIT 5;

-- ================================================================
-- TEST 8: Final Summary
-- ================================================================

SELECT '========================================' AS '';
SELECT 'FINAL SUMMARY' AS TestName;
SELECT '========================================' AS '';

SELECT 
    'Schema Migration' AS Category,
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'borrowed_items' 
            AND COLUMN_NAME = 'itemName'
        ) 
        AND EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'borrowed_items' 
            AND COLUMN_NAME = 'returnReason'
        )
        AND NOT EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'borrowed_items' 
            AND COLUMN_NAME = 'expectedReturnDate'
        )
        AND EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'supplies' 
            AND COLUMN_NAME = 'assignedTo'
        )
        AND EXISTS (
            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_SCHEMA = 'teamcruzim' 
            AND TABLE_NAME = 'supplies' 
            AND COLUMN_NAME = 'departmentId'
        )
        THEN '✓ ALL TESTS PASSED'
        ELSE '✗ SOME TESTS FAILED - Check above for details'
    END AS Status;

-- ================================================================
-- DONE! Review the results above
-- ================================================================

SELECT '========================================' AS '';
SELECT 'Testing Complete!' AS '';
SELECT 'Review the results above to verify your schema changes.' AS '';
SELECT '========================================' AS '';
