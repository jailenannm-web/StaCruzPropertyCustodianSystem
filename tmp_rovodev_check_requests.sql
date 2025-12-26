-- Diagnostic query to check approved requests and user matching
-- Run this in phpMyAdmin to see what's happening

-- 1. Check what user is logged in (you'll need to know the userId)
SELECT userId, firstName, middleName, lastName, fullName, username
FROM users 
WHERE username = 'test_staff' OR username = 'staff1';

-- 2. Check approved property requests
SELECT requestId, requesterName, itemName, status, dateOfRequest, approvedDate
FROM property_requests
WHERE status = 'Approved'
ORDER BY dateOfRequest DESC;

-- 3. Check if names match
-- Replace @userId with your actual staff userId (e.g., 2 or 3)
SET @userId = 2; -- Change this to your staff user ID

SELECT 
    pr.requestId,
    pr.requesterName,
    pr.itemName,
    pr.status,
    u.firstName,
    u.lastName,
    u.fullName,
    CASE 
        WHEN pr.requesterName LIKE CONCAT(u.firstName, '%') THEN 'Match by LIKE'
        WHEN pr.requesterName = CONCAT(u.firstName, ' ', u.lastName) THEN 'Match exact firstName lastName'
        WHEN pr.requesterName = CONCAT(u.firstName, ' ', u.middleName, ' ', u.lastName) THEN 'Match full name with middle'
        WHEN pr.requesterName = u.fullName THEN 'Match fullName field'
        ELSE 'NO MATCH'
    END AS MatchStatus
FROM property_requests pr
CROSS JOIN users u
WHERE pr.status = 'Approved'
AND u.userId = @userId;
