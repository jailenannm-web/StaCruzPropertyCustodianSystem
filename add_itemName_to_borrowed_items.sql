-- ================================================================
-- ADD itemName COLUMN TO borrowed_items TABLE
-- Database: teamcruzim
-- This stores the item name directly for easier queries and reporting
-- ================================================================

USE teamcruzim;

-- Step 1: Check current table structure
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

-- Step 2: Add itemName column after itemId
ALTER TABLE borrowed_items 
ADD COLUMN itemName VARCHAR(200) NULL DEFAULT NULL
AFTER itemId;

-- Step 3: Populate itemName for existing records from properties table
UPDATE borrowed_items bi
INNER JOIN properties p ON bi.itemId = p.propertyId
SET bi.itemName = p.itemName
WHERE bi.itemType = 'property' AND bi.itemName IS NULL;

-- Step 4: Populate itemName for existing records from supplies table
UPDATE borrowed_items bi
INNER JOIN supplies s ON bi.itemId = s.supplyId
SET bi.itemName = s.itemName
WHERE bi.itemType = 'supply' AND bi.itemName IS NULL;

-- Step 5: Verify the changes
SELECT 
    borrowId,
    itemType,
    itemId,
    itemName,
    borrowerName,
    status
FROM borrowed_items
ORDER BY borrowId DESC
LIMIT 20;

-- Step 6: Show updated table structure
SELECT 
    COLUMN_NAME, 
    DATA_TYPE, 
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
  AND TABLE_NAME = 'borrowed_items'
ORDER BY ORDINAL_POSITION;

-- Step 7: Confirmation
SELECT 
    'Migration completed successfully!' AS Status,
    'itemName column added to borrowed_items' AS Change,
    'Existing records populated with item names' AS Details;
