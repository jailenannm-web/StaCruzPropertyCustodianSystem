-- ========================================
-- FIX: Add userId column to request tables
-- ========================================
-- This fixes the "Unknown column 'userId'" error in StaffDashboard

USE teamcruzim;

-- 1. Add userId column to property_requests table
ALTER TABLE property_requests 
ADD COLUMN userId INT DEFAULT NULL AFTER requestId,
ADD INDEX idx_prop_req_user (userId),
ADD FOREIGN KEY (userId) REFERENCES users(userId) ON DELETE SET NULL;

-- 2. Add userId column to supplies_requests table
ALTER TABLE supplies_requests 
ADD COLUMN userId INT DEFAULT NULL AFTER requestId,
ADD INDEX idx_supply_req_user (userId),
ADD FOREIGN KEY (userId) REFERENCES users(userId) ON DELETE SET NULL;

-- 3. Update existing records - Match requesterName to users table to populate userId
UPDATE property_requests pr
INNER JOIN users u ON TRIM(pr.requesterName) = TRIM(CONCAT(u.firstName, ' ', u.lastName))
SET pr.userId = u.userId
WHERE pr.userId IS NULL;

UPDATE supplies_requests sr
INNER JOIN users u ON TRIM(sr.requesterName) = TRIM(CONCAT(u.firstName, ' ', u.lastName))
SET sr.userId = u.userId
WHERE sr.userId IS NULL;

-- 4. Verify the changes
SELECT 'property_requests' AS table_name, COUNT(*) AS total, 
       SUM(CASE WHEN userId IS NOT NULL THEN 1 ELSE 0 END) AS with_userId
FROM property_requests
UNION ALL
SELECT 'supplies_requests', COUNT(*), 
       SUM(CASE WHEN userId IS NOT NULL THEN 1 ELSE 0 END)
FROM supplies_requests;

-- Done! Now the StaffDashboard queries will work.
