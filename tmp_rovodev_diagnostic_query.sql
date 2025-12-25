-- Run this in phpMyAdmin to check the ACTUAL column names in your users table

-- 1. Show the exact structure of your users table
DESCRIBE users;

-- 2. Check what data is actually in userId 32812
SELECT * FROM users WHERE userId = 32812;

-- 3. Try to manually UPDATE the address fields
UPDATE users 
SET province = 'TEST_PROVINCE', 
    municipal = 'TEST_MUNICIPAL', 
    barangay = 'TEST_BARANGAY' 
WHERE userId = 32812;

-- 4. Check if the manual UPDATE worked
SELECT userId, username, province, municipal, barangay FROM users WHERE userId = 32812;

-- If step 4 shows empty province/municipal, then the column names are wrong!
-- Run this to see ALL column names:
SHOW COLUMNS FROM users LIKE '%prov%';
SHOW COLUMNS FROM users LIKE '%munic%';
SHOW COLUMNS FROM users LIKE '%barang%';
