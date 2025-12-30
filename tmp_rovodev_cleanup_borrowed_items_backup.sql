-- ================================================================
-- CLEANUP: Remove borrowed_items_backup table
-- This removes the old backup table that has the outdated schema
-- ================================================================

USE teamcruzim;

-- ================================================================
-- STEP 1: Verify borrowed_items table structure is correct
-- ================================================================
SELECT '=== VERIFYING borrowed_items STRUCTURE ===' AS Info;

SELECT 
    COLUMN_NAME, 
    DATA_TYPE, 
    COLUMN_TYPE,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items'
ORDER BY ORDINAL_POSITION;

-- Verify returnReason column exists (new structure)
SELECT 
    CASE 
        WHEN COUNT(*) > 0 THEN '✓ CORRECT: borrowed_items has returnReason column (new structure)'
        ELSE '✗ ERROR: borrowed_items missing returnReason column!'
    END AS 'Structure Check'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items'
  AND COLUMN_NAME = 'returnReason';

-- Verify expectedReturnDate does NOT exist
SELECT 
    CASE 
        WHEN COUNT(*) = 0 THEN '✓ CORRECT: borrowed_items does not have expectedReturnDate (old column removed)'
        ELSE '✗ WARNING: borrowed_items still has expectedReturnDate column!'
    END AS 'Structure Check'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items'
  AND COLUMN_NAME = 'expectedReturnDate';

-- ================================================================
-- STEP 2: Check if borrowed_items_backup exists
-- ================================================================
SELECT '=== CHECKING FOR BACKUP TABLE ===' AS Info;

SELECT 
    CASE 
        WHEN COUNT(*) > 0 THEN 'borrowed_items_backup table EXISTS - will be dropped'
        ELSE 'borrowed_items_backup table does NOT exist - nothing to drop'
    END AS 'Backup Status'
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items_backup';

-- ================================================================
-- STEP 3: Show data in borrowed_items (to verify it's not empty)
-- ================================================================
SELECT '=== CURRENT borrowed_items DATA ===' AS Info;

SELECT 
    COUNT(*) AS 'Total Records',
    SUM(CASE WHEN status = 'Borrowed' THEN 1 ELSE 0 END) AS 'Borrowed',
    SUM(CASE WHEN status = 'Returned' THEN 1 ELSE 0 END) AS 'Returned',
    SUM(CASE WHEN itemType = 'property' THEN 1 ELSE 0 END) AS 'Properties',
    SUM(CASE WHEN itemType = 'supply' THEN 1 ELSE 0 END) AS 'Supplies'
FROM borrowed_items;

-- ================================================================
-- STEP 4: Drop the backup table (if it exists)
-- ================================================================
SELECT '=== DROPPING BACKUP TABLE ===' AS Info;

DROP TABLE IF EXISTS borrowed_items_backup;

SELECT 'borrowed_items_backup table has been dropped (if it existed)' AS Result;

-- ================================================================
-- STEP 5: Verify the backup is gone
-- ================================================================
SELECT '=== VERIFICATION ===' AS Info;

SELECT 
    CASE 
        WHEN COUNT(*) = 0 THEN '✓ SUCCESS: borrowed_items_backup has been removed'
        ELSE '✗ ERROR: borrowed_items_backup still exists!'
    END AS 'Final Status'
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items_backup';

-- ================================================================
-- STEP 6: Final borrowed_items table check
-- ================================================================
SELECT '=== FINAL borrowed_items TABLE STATUS ===' AS Info;

SELECT 
    'borrowed_items table is active and ready to use' AS Status,
    CONCAT('Structure: Uses returnReason (VARCHAR) instead of expectedReturnDate (DATE)') AS Schema,
    CONCAT('Data: ', COUNT(*), ' records') AS Records
FROM borrowed_items;

-- ================================================================
-- DONE! borrowed_items_backup has been safely removed
-- ================================================================
