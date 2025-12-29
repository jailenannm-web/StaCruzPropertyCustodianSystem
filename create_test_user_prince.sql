-- ================================================================
-- CREATE TEST USER: prince juan jheck Jr.
-- Run this in phpMyAdmin to create the user who submitted the request
-- ================================================================

USE teamcruzim;

-- ================================================================
-- STEP 1: Insert into users table first
-- ================================================================

INSERT INTO users (
    firstName, 
    middleName,
    lastName, 
    suffix,
    departmentId, 
    position,
    username, 
    passwordEncrypted, 
    email,
    role, 
    status,
    createdAt,
    updatedAt
)
VALUES (
    'prince',           -- firstName
    'juan',             -- middleName
    'jheck',            -- lastName
    'Jr.',              -- suffix
    2,                  -- departmentId (IT Department from your schema)
    'Staff Member',     -- position
    'pjjuan',           -- username (matches your login)
    '$2a$11$YourHashedPasswordHere',  -- passwordEncrypted (replace with actual hash)
    'pjjuan@example.com',              -- email
    'Staff',            -- role
    'Active',           -- status
    NOW(),              -- createdAt
    NOW()               -- updatedAt
);

-- Get the userId that was just created
SET @newUserId = LAST_INSERT_ID();

SELECT CONCAT('✓ Created user with userId: ', @newUserId) AS Result;

-- ================================================================
-- STEP 2: Also insert into staff_accounts table (since you logged in as staff)
-- ================================================================

INSERT INTO staff_accounts (
    userId,
    firstName,
    middleName,
    lastName,
    suffix,
    departmentId,
    position,
    username,
    passwordEncrypted,
    email,
    status,
    createdAt,
    updatedAt
)
VALUES (
    @newUserId,         -- userId (links to users table)
    'prince',           -- firstName
    'juan',             -- middleName  
    'jheck',            -- lastName
    'Jr.',              -- suffix
    2,                  -- departmentId (IT Department)
    'Staff Member',     -- position
    'pjjuan',           -- username
    '$2a$11$YourHashedPasswordHere',  -- passwordEncrypted
    'pjjuan@example.com',              -- email
    'Active',           -- status
    NOW(),              -- createdAt
    NOW()               -- updatedAt
);

SELECT CONCAT('✓ Created staff_account linked to userId: ', @newUserId) AS Result;

-- ================================================================
-- STEP 3: Verify the user was created correctly
-- ================================================================

SELECT 
    '=== VERIFY USER CREATED ===' AS Info;

SELECT 
    u.userId,
    CONCAT(u.firstName, ' ', IFNULL(u.middleName, ''), ' ', u.lastName, ' ', IFNULL(u.suffix, '')) AS fullName,
    u.departmentId,
    d.departmentName,
    d.location AS departmentLocation,
    u.role,
    u.status
FROM users u
LEFT JOIN departments d ON u.departmentId = d.departmentId
WHERE u.userId = @newUserId;

-- Also check staff_accounts
SELECT 
    sa.staffId,
    sa.userId,
    CONCAT(sa.firstName, ' ', IFNULL(sa.middleName, ''), ' ', sa.lastName, ' ', IFNULL(sa.suffix, '')) AS fullName,
    sa.departmentId,
    sa.username
FROM staff_accounts sa
WHERE sa.userId = @newUserId;

-- ================================================================
-- STEP 4: Show the property request that needs approval
-- ================================================================

SELECT 
    '=== PROPERTY REQUEST TO APPROVE ===' AS Info;

SELECT 
    pr.requestId,
    pr.requesterName,
    pr.departmentId,
    pr.itemName,
    pr.purpose,
    pr.status,
    pr.dateOfRequest
FROM property_requests pr
WHERE pr.requesterName LIKE '%prince%juan%jheck%Jr%'
AND pr.status = 'Pending'
ORDER BY pr.requestId DESC
LIMIT 5;

-- ================================================================
-- NOTES
-- ================================================================
-- After running this script:
-- 1. The user "prince juan jheck Jr." will exist in both tables
-- 2. The user will be linked to departmentId = 2 (IT Department)
-- 3. The IT Department location is "Main Building"
-- 4. When you approve the request, it should now work!
--
-- Expected debug output after approval:
-- [ApprovePropertyRequest] Looking for requester: prince juan jheck Jr.
-- [ApprovePropertyRequest] Found requester in users table, userId: [NEW_ID]
-- [ApprovePropertyRequest] Found requester's departmentId in users: 2
-- [ApprovePropertyRequest] Found department location: Main Building
-- [ApprovePropertyRequest] Updating propertyId=32773: assignedTo=[NEW_ID], departmentId=2, location=Main Building
-- [ApprovePropertyRequest] Property update complete: 1 rows affected
-- ================================================================
