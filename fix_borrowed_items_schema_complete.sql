-- ================================================================
-- COMPLETE FIX FOR BORROWED_ITEMS TABLE SCHEMA
-- Database: teamcruzim
-- This script fixes all issues with the borrowed_items table
-- ================================================================

USE teamcruzim;

-- ================================================================
-- STEP 1: Add missing itemName column
-- This is needed to display item names without always joining
-- ================================================================

ALTER TABLE borrowed_items
ADD COLUMN IF NOT EXISTS itemName VARCHAR(200) NULL
AFTER itemId;

-- Add index for itemName searches
ALTER TABLE borrowed_items
ADD INDEX IF NOT EXISTS idx_borrow_itemName (itemName);

-- ================================================================
-- STEP 2: Replace expectedReturnDate with returnReason
-- (Only if expectedReturnDate still exists)
-- ================================================================

-- Check if expectedReturnDate exists and drop it
SET @col_exists = (
    SELECT COUNT(*)
    FROM information_schema.COLUMNS
    WHERE TABLE_SCHEMA = 'teamcruzim'
    AND TABLE_NAME = 'borrowed_items'
    AND COLUMN_NAME = 'expectedReturnDate'
);

-- Drop expectedReturnDate if it exists
SET @sql = IF(@col_exists > 0,
    'ALTER TABLE borrowed_items DROP COLUMN expectedReturnDate',
    'SELECT "expectedReturnDate column already removed" AS Result'
);
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

-- Add returnReason column if it doesn't exist
ALTER TABLE borrowed_items
ADD COLUMN IF NOT EXISTS returnReason VARCHAR(200) NULL
AFTER borrowDate;

-- ================================================================
-- STEP 3: Populate itemName for existing records
-- ================================================================

-- Update itemName from properties table
UPDATE borrowed_items bi
INNER JOIN properties p ON bi.itemId = p.propertyId AND bi.itemType = 'property'
SET bi.itemName = p.itemName
WHERE bi.itemName IS NULL OR bi.itemName = '';

-- Update itemName from supplies table
UPDATE borrowed_items bi
INNER JOIN supplies s ON bi.itemId = s.supplyId AND bi.itemType = 'supply'
SET bi.itemName = s.itemName
WHERE bi.itemName IS NULL OR bi.itemName = '';

-- ================================================================
-- STEP 4: Add assignedTo column to supplies table (if not exists)
-- ================================================================

ALTER TABLE supplies
ADD COLUMN IF NOT EXISTS assignedTo INT(11) NULL DEFAULT NULL
AFTER sourceOfFunds;

-- Add index
ALTER TABLE supplies
ADD INDEX IF NOT EXISTS idx_supply_assigned (assignedTo);

-- Add foreign key (drop first if exists to avoid errors)
ALTER TABLE supplies
DROP FOREIGN KEY IF EXISTS fk_supplies_assignedTo;

ALTER TABLE supplies
ADD CONSTRAINT fk_supplies_assignedTo
FOREIGN KEY (assignedTo)
REFERENCES users(userId)
ON DELETE SET NULL
ON UPDATE CASCADE;

-- ================================================================
-- STEP 5: Add departmentId column to supplies (if not exists)
-- This helps track which department a supply belongs to
-- ================================================================

ALTER TABLE supplies
ADD COLUMN IF NOT EXISTS departmentId INT(11) NULL DEFAULT NULL
AFTER assignedTo;

-- Add index
ALTER TABLE supplies
ADD INDEX IF NOT EXISTS idx_supply_department (departmentId);

-- Add foreign key
ALTER TABLE supplies
DROP FOREIGN KEY IF EXISTS fk_supplies_departmentId;

ALTER TABLE supplies
ADD CONSTRAINT fk_supplies_departmentId
FOREIGN KEY (departmentId)
REFERENCES departments(departmentId)
ON DELETE SET NULL
ON UPDATE CASCADE;

-- ================================================================
-- STEP 6: Verify the final structure
-- ================================================================

SELECT '=== BORROWED_ITEMS TABLE STRUCTURE ===' AS Info;
DESCRIBE borrowed_items;

SELECT '=== SUPPLIES TABLE STRUCTURE ===' AS Info;
DESCRIBE supplies;

-- ================================================================
-- STEP 7: Show summary
-- ================================================================

SELECT
    'Schema fix completed successfully!' AS Status,
    CONCAT(
        'borrowed_items: ',
        'itemName column added, ',
        'returnReason column ready, ',
        'expectedReturnDate removed'
    ) AS BorrowedItemsChanges,
    CONCAT(
        'supplies: ',
        'assignedTo column added, ',
        'departmentId column added, ',
        'foreign keys configured'
    ) AS SuppliesChanges;

-- ================================================================
-- STEP 8: Show current data counts
-- ================================================================

SELECT
    'borrowed_items' AS TableName,
    COUNT(*) AS TotalRecords,
    SUM(CASE WHEN itemName IS NOT NULL THEN 1 ELSE 0 END) AS RecordsWithItemName,
    SUM(CASE WHEN status = 'Borrowed' THEN 1 ELSE 0 END) AS CurrentlyBorrowed,
    SUM(CASE WHEN status = 'Returned' THEN 1 ELSE 0 END) AS Returned
FROM borrowed_items

UNION ALL

SELECT
    'supplies' AS TableName,
    COUNT(*) AS TotalRecords,
    SUM(CASE WHEN assignedTo IS NOT NULL THEN 1 ELSE 0 END) AS AssignedSupplies,
    0 AS CurrentlyBorrowed,
    0 AS Returned
FROM supplies;

-- ================================================================
-- DONE! Your schema is now updated and ready to use
-- ================================================================
