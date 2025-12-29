-- ================================================================
-- MIGRATE expectedReturnDate to returnReason in borrowed_items
-- Database: teamcruzim
-- This changes the column to store return reason text instead of date
-- ================================================================

USE teamcruzim;

-- Step 1: Check if expectedReturnDate column exists
SELECT 
    COLUMN_NAME, 
    DATA_TYPE, 
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items' 
  AND COLUMN_NAME = 'expectedReturnDate';

-- Step 2: Backup data if needed (optional, for safety)
-- CREATE TABLE borrowed_items_backup AS SELECT * FROM borrowed_items;

-- Step 3: Drop the expectedReturnDate column
ALTER TABLE borrowed_items 
DROP COLUMN expectedReturnDate;

-- Step 4: Add new returnReason column
ALTER TABLE borrowed_items 
ADD COLUMN returnReason VARCHAR(200) NULL DEFAULT NULL
AFTER borrowDate;

-- Step 5: Verify the change
SELECT 
    COLUMN_NAME, 
    DATA_TYPE, 
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items'
ORDER BY ORDINAL_POSITION;

-- Step 6: Show confirmation
SELECT 
    'Migration completed successfully!' AS Status,
    'expectedReturnDate column replaced with returnReason' AS Change,
    'returnReason is VARCHAR(200) and can store text' AS Details;
