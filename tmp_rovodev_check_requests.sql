-- Check if staff has any property or supply requests
USE teamcruzim;

-- Check property requests
SELECT 'Property Requests' as type, status, COUNT(*) as count
FROM property_requests 
WHERE requestedBy = 32816  -- Replace with your staff userId
GROUP BY status;

-- Check supply requests
SELECT 'Supply Requests' as type, status, COUNT(*) as count
FROM supplies_requests 
WHERE requestedBy = 32816  -- Replace with your staff userId
GROUP BY status;

-- Check who created the requests (to verify requestedBy)
SELECT requestId, requesterName, status, requestedBy, dateOfRequest
FROM property_requests
WHERE requesterName LIKE '%pjjuan%' OR requesterName LIKE '%prince%'
ORDER BY dateOfRequest DESC
LIMIT 10;

-- Check staff user ID
SELECT userId, fullName, username
FROM users
WHERE username = 'pjjuan' OR fullName LIKE '%prince%';
