-- ================================================================
-- POPULATE BORROWED ITEMS FROM APPROVED REQUESTS
-- Run this in phpMyAdmin (XAMPP) to create borrowed items
-- ================================================================

USE teamcruzim;

-- ================================================================
-- STEP 1: Create borrowed items from approved PROPERTY requests
-- ================================================================

INSERT INTO borrowed_items (
    requestId, 
    itemType, 
    itemId, 
    borrowerName, 
    borrowerPosition, 
    departmentId, 
    borrowDate, 
    expectedReturnDate,
    status, 
    remarks,
    createdAt,
    updatedAt
)
SELECT 
    pr.requestId,
    'property' AS itemType,
    p.propertyId AS itemId,
    pr.requesterName AS borrowerName,
    pr.position AS borrowerPosition,
    pr.departmentId,
    pr.approvedDate AS borrowDate,
    DATE_ADD(pr.approvedDate, INTERVAL 30 DAY) AS expectedReturnDate, -- 30 days from approval
    'Borrowed' AS status,
    CONCAT('Approved request for: ', pr.purpose) AS remarks,
    NOW() AS createdAt,
    NOW() AS updatedAt
FROM property_requests pr
INNER JOIN properties p ON pr.itemName = p.itemName
WHERE pr.status = 'Approved'
AND NOT EXISTS (
    -- Avoid duplicates if you run this script multiple times
    SELECT 1 FROM borrowed_items bi 
    WHERE bi.requestId = pr.requestId 
    AND bi.itemType = 'property'
)
ORDER BY pr.approvedDate DESC;

-- Show how many property items were added
SELECT CONCAT('Added ', ROW_COUNT(), ' property borrowed items') AS Result;

-- ================================================================
-- STEP 2: Create borrowed items from approved SUPPLY requests
-- ================================================================

INSERT INTO borrowed_items (
    requestId, 
    itemType, 
    itemId, 
    borrowerName, 
    borrowerPosition, 
    departmentId, 
    borrowDate, 
    expectedReturnDate,
    status, 
    remarks,
    createdAt,
    updatedAt
)
SELECT 
    sr.requestId,
    'supply' AS itemType,
    s.supplyId AS itemId,
    sr.requesterName AS borrowerName,
    sr.position AS borrowerPosition,
    sr.departmentId,
    sr.approvedDate AS borrowDate,
    DATE_ADD(sr.approvedDate, INTERVAL 7 DAY) AS expectedReturnDate, -- 7 days for supplies
    'Borrowed' AS status,
    CONCAT('Approved request for: ', sr.purpose) AS remarks,
    NOW() AS createdAt,
    NOW() AS updatedAt
FROM supplies_requests sr
INNER JOIN supplies s ON sr.itemName = s.itemName
WHERE sr.status = 'Approved'
AND NOT EXISTS (
    -- Avoid duplicates if you run this script multiple times
    SELECT 1 FROM borrowed_items bi 
    WHERE bi.requestId = sr.requestId 
    AND bi.itemType = 'supply'
)
ORDER BY sr.approvedDate DESC;

-- Show how many supply items were added
SELECT CONCAT('Added ', ROW_COUNT(), ' supply borrowed items') AS Result;

-- ================================================================
-- STEP 3: Show summary of created borrowed items
-- ================================================================

SELECT 
    '=== BORROWED ITEMS SUMMARY ===' AS Info;

SELECT 
    itemType AS 'Item Type',
    COUNT(*) AS 'Total Items',
    SUM(CASE WHEN status = 'Borrowed' THEN 1 ELSE 0 END) AS 'Currently Borrowed',
    SUM(CASE WHEN status = 'Returned' THEN 1 ELSE 0 END) AS 'Returned'
FROM borrowed_items
GROUP BY itemType
WITH ROLLUP;

-- ================================================================
-- STEP 4: Show detailed list of borrowed items
-- ================================================================

SELECT 
    '=== YOUR BORROWED ITEMS ===' AS Info;

SELECT 
    bi.borrowId,
    bi.itemType AS 'Type',
    CASE 
        WHEN bi.itemType = 'property' THEN p.itemName
        WHEN bi.itemType = 'supply' THEN s.itemName
        ELSE 'Unknown'
    END AS 'Item Name',
    CASE 
        WHEN bi.itemType = 'property' THEN p.propertyNumber
        ELSE 'N/A'
    END AS 'Property No.',
    CASE 
        WHEN bi.itemType = 'property' THEN p.serialNumber
        ELSE 'N/A'
    END AS 'Serial No.',
    bi.borrowerName AS 'Borrower',
    bi.borrowDate AS 'Borrow Date',
    bi.expectedReturnDate AS 'Expected Return',
    bi.status AS 'Status',
    bi.remarks AS 'Remarks'
FROM borrowed_items bi
LEFT JOIN properties p ON bi.itemId = p.propertyId AND bi.itemType = 'property'
LEFT JOIN supplies s ON bi.itemId = s.supplyId AND bi.itemType = 'supply'
ORDER BY bi.borrowDate DESC;

-- ================================================================
-- OPTIONAL: Update property status to 'Borrowed'
-- ================================================================

-- Uncomment the lines below if you want to mark properties as borrowed
-- UPDATE properties p
-- INNER JOIN borrowed_items bi ON p.propertyId = bi.itemId AND bi.itemType = 'property'
-- SET p.status = 'Borrowed'
-- WHERE bi.status = 'Borrowed';

-- SELECT CONCAT('Updated ', ROW_COUNT(), ' properties to Borrowed status') AS Result;

-- ================================================================
-- VERIFICATION QUERIES
-- ================================================================

-- Check if borrowed_items table has data
SELECT 
    CASE 
        WHEN COUNT(*) > 0 THEN CONCAT('✓ SUCCESS! You have ', COUNT(*), ' borrowed items')
        ELSE '✗ No borrowed items found. Check if you have approved requests.'
    END AS 'Verification Result'
FROM borrowed_items;

-- Show which users have borrowed items
SELECT 
    borrowerName AS 'Borrower',
    COUNT(*) AS 'Total Items Borrowed',
    SUM(CASE WHEN itemType = 'property' THEN 1 ELSE 0 END) AS 'Properties',
    SUM(CASE WHEN itemType = 'supply' THEN 1 ELSE 0 END) AS 'Supplies'
FROM borrowed_items
GROUP BY borrowerName
ORDER BY COUNT(*) DESC;

-- ================================================================
-- DONE!
-- Now refresh "My Borrowed Items" in your application
-- ================================================================
