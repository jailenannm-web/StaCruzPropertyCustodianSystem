-- ================================================================
-- ADD assignedTo FIELD TO SUPPLIES TABLE
-- This makes supplies work the same as properties for assignment
-- Run this in phpMyAdmin (XAMPP)
-- ================================================================

USE teamcruzim;

-- Check if column already exists
SET @col_exists = 0;
SELECT COUNT(*) INTO @col_exists 
FROM information_schema.COLUMNS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
AND TABLE_NAME = 'supplies' 
AND COLUMN_NAME = 'assignedTo';

-- Add assignedTo column to supplies table (if it doesn't exist)
SET @query = IF(@col_exists = 0,
    'ALTER TABLE supplies ADD COLUMN assignedTo INT(11) NULL DEFAULT NULL AFTER sourceOfFunds',
    'SELECT "Column assignedTo already exists" AS Result');
PREPARE stmt FROM @query;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

-- Add index for assignedTo (if it doesn't exist)
SET @idx_exists = 0;
SELECT COUNT(*) INTO @idx_exists 
FROM information_schema.STATISTICS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
AND TABLE_NAME = 'supplies' 
AND INDEX_NAME = 'idx_supply_assigned';

SET @query = IF(@idx_exists = 0,
    'ALTER TABLE supplies ADD INDEX idx_supply_assigned (assignedTo)',
    'SELECT "Index idx_supply_assigned already exists" AS Result');
PREPARE stmt FROM @query;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

-- Add foreign key constraint to link to users table (if it doesn't exist)
SET @fk_exists = 0;
SELECT COUNT(*) INTO @fk_exists 
FROM information_schema.TABLE_CONSTRAINTS 
WHERE TABLE_SCHEMA = 'teamcruzim' 
AND TABLE_NAME = 'supplies' 
AND CONSTRAINT_NAME = 'fk_supplies_assignedTo';

SET @query = IF(@fk_exists = 0,
    'ALTER TABLE supplies ADD CONSTRAINT fk_supplies_assignedTo FOREIGN KEY (assignedTo) REFERENCES users(userId) ON DELETE SET NULL',
    'SELECT "Foreign key fk_supplies_assignedTo already exists" AS Result');
PREPARE stmt FROM @query;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

-- Show the updated table structure
SELECT '=== SUPPLIES TABLE STRUCTURE ===' AS Info;
DESCRIBE supplies;

-- Verify the change
SELECT 
    'Supplies table updated successfully!' AS Status,
    'assignedTo column added (or already exists)' AS Change;
