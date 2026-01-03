-- ================================================================
-- GENERATE BORROWED ITEMS, CUSTODIAN ASSIGNMENTS, AND AUDIT LOGS
-- Complete system workflow with proper tracking
-- Database: teamcruzim
-- ================================================================

USE teamcruzim;

SET FOREIGN_KEY_CHECKS = 0;
SET AUTOCOMMIT = 0;

-- Clear existing records
DELETE FROM borrowed_items;
DELETE FROM custodian;
DELETE FROM audit_logs;

ALTER TABLE borrowed_items AUTO_INCREMENT = 1;
ALTER TABLE custodian AUTO_INCREMENT = 1;
ALTER TABLE audit_logs AUTO_INCREMENT = 1;

-- ================================================================
-- PART 1: BORROWED ITEMS (from approved requests)
-- ================================================================

DELIMITER $$

DROP PROCEDURE IF EXISTS GenerateBorrowedItems$$

CREATE PROCEDURE GenerateBorrowedItems()
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE req_id INT;
    DECLARE req_name VARCHAR(200);
    DECLARE position VARCHAR(100);
    DECLARE dept_id INT;
    DECLARE item_name VARCHAR(200);
    DECLARE approved_date DATETIME;
    DECLARE item_id INT;
    DECLARE borrow_date DATE;
    DECLARE return_reason VARCHAR(200);
    DECLARE actual_return DATE;
    DECLARE condition_return ENUM('Good','Needs Repair','Damaged');
    DECLARE status ENUM('Borrowed','Returned','Overdue','Lost');
    DECLARE remarks TEXT;
    DECLARE random_num INT;
    DECLARE days_diff INT;
    
    -- Cursor for approved property requests
    DECLARE prop_cur CURSOR FOR 
        SELECT pr.requestId, pr.requesterName, pr.position, pr.departmentId,
               pr.itemName, pr.approvedDate
        FROM property_requests pr
        WHERE pr.status = 'Approved' 
        AND pr.approvedDate IS NOT NULL
        LIMIT 5000;
    
    -- Cursor for approved supply requests
    DECLARE supply_cur CURSOR FOR 
        SELECT sr.requestId, sr.requesterName, sr.position, sr.departmentId,
               sr.itemName, sr.approvedDate
        FROM supplies_requests sr
        WHERE sr.status = 'Approved' 
        AND sr.approvedDate IS NOT NULL
        LIMIT 5000;
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 0;
    
    SET @return_reasons = 'Temporary use completed,Project finished,Training completed,Event concluded,Seminar ended,Returned after use,Replacement arrived,No longer needed,Department request,Administrative order,End of borrowing period,Equipment rotation,Scheduled return,Task completed,Assignment finished,Activity ended,Workshop completed,Demonstration finished,Testing completed,Evaluation done,Emergency use ended,Temporary assignment concluded,Short-term use finished,One-time use completed,Special purpose fulfilled';
    
    -- Process property requests
    OPEN prop_cur;
    
    prop_loop: LOOP
        FETCH prop_cur INTO req_id, req_name, position, dept_id, item_name, approved_date;
        
        IF done THEN
            SET done = 0;
            LEAVE prop_loop;
        END IF;
        
        -- Find matching property
        SELECT propertyId INTO item_id
        FROM properties
        WHERE itemName LIKE CONCAT('%', SUBSTRING_INDEX(item_name, ' ', 1), '%')
        AND status IN ('Active', 'Borrowed')
        ORDER BY RAND()
        LIMIT 1;
        
        IF item_id IS NOT NULL THEN
            SET borrow_date = DATE(approved_date);
            
            -- Status distribution: 40% Returned, 50% Borrowed, 8% Overdue, 2% Lost
            SET random_num = FLOOR(1 + RAND() * 100);
            
            IF random_num <= 40 THEN
                SET status = 'Returned';
                SET days_diff = FLOOR(7 + RAND() * 90);
                SET actual_return = DATE_ADD(borrow_date, INTERVAL days_diff DAY);
                SET return_reason = SUBSTRING_INDEX(SUBSTRING_INDEX(@return_reasons, ',', FLOOR(1 + RAND() * 25)), ',', -1);
                
                -- 90% Good condition on return
                IF RAND() < 0.90 THEN
                    SET condition_return = 'Good';
                ELSEIF RAND() < 0.95 THEN
                    SET condition_return = 'Needs Repair';
                ELSE
                    SET condition_return = 'Damaged';
                END IF;
                
                SET remarks = CONCAT('Item returned in ', condition_return, ' condition');
                
            ELSEIF random_num <= 90 THEN
                SET status = 'Borrowed';
                SET actual_return = NULL;
                SET return_reason = NULL;
                SET condition_return = NULL;
                SET remarks = 'Currently borrowed by user';
                
            ELSEIF random_num <= 98 THEN
                SET status = 'Overdue';
                SET actual_return = NULL;
                SET return_reason = NULL;
                SET condition_return = NULL;
                SET days_diff = FLOOR(1 + RAND() * 30);
                SET remarks = CONCAT('Item overdue by ', days_diff, ' days - follow up required');
                
            ELSE
                SET status = 'Lost';
                SET actual_return = NULL;
                SET return_reason = 'Item reported lost';
                SET condition_return = NULL;
                SET remarks = 'Item lost - investigation and replacement needed';
            END IF;
            
            INSERT INTO borrowed_items (
                requestId, itemType, itemId, borrowerName, borrowerPosition,
                departmentId, borrowDate, returnReason, actualReturnDate,
                conditionOnReturn, status, remarks, createdAt, updatedAt
            ) VALUES (
                req_id, 'property', item_id, req_name, position,
                dept_id, borrow_date, return_reason, actual_return,
                condition_return, status, remarks, borrow_date, NOW()
            );
        END IF;
        
    END LOOP;
    
    CLOSE prop_cur;
    COMMIT;
    
    -- Process supply requests
    SET done = 0;
    OPEN supply_cur;
    
    supply_loop: LOOP
        FETCH supply_cur INTO req_id, req_name, position, dept_id, item_name, approved_date;
        
        IF done THEN
            LEAVE supply_loop;
        END IF;
        
        -- Find matching supply
        SELECT supplyId INTO item_id
        FROM supplies
        WHERE itemName LIKE CONCAT('%', SUBSTRING_INDEX(item_name, ' ', 1), '%')
        AND stockStatus IN ('Available', 'Low Stock')
        ORDER BY RAND()
        LIMIT 1;
        
        IF item_id IS NOT NULL THEN
            SET borrow_date = DATE(approved_date);
            
            -- Supplies: 60% Returned, 35% Borrowed, 5% Overdue
            SET random_num = FLOOR(1 + RAND() * 100);
            
            IF random_num <= 60 THEN
                SET status = 'Returned';
                SET days_diff = FLOOR(3 + RAND() * 30);
                SET actual_return = DATE_ADD(borrow_date, INTERVAL days_diff DAY);
                SET return_reason = SUBSTRING_INDEX(SUBSTRING_INDEX(@return_reasons, ',', FLOOR(1 + RAND() * 25)), ',', -1);
                SET condition_return = 'Good';
                SET remarks = 'Supply items returned';
                
            ELSEIF random_num <= 95 THEN
                SET status = 'Borrowed';
                SET actual_return = NULL;
                SET return_reason = NULL;
                SET condition_return = NULL;
                SET remarks = 'Currently issued to user';
                
            ELSE
                SET status = 'Overdue';
                SET actual_return = NULL;
                SET return_reason = NULL;
                SET condition_return = NULL;
                SET remarks = 'Supply return overdue';
            END IF;
            
            INSERT INTO borrowed_items (
                requestId, itemType, itemId, borrowerName, borrowerPosition,
                departmentId, borrowDate, returnReason, actualReturnDate,
                conditionOnReturn, status, remarks, createdAt, updatedAt
            ) VALUES (
                req_id, 'supply', item_id, req_name, position,
                dept_id, borrow_date, return_reason, actual_return,
                condition_return, status, remarks, borrow_date, NOW()
            );
        END IF;
        
    END LOOP;
    
    CLOSE supply_cur;
    COMMIT;
END$$

-- ================================================================
-- PART 2: CUSTODIAN ASSIGNMENTS (10,000+)
-- ================================================================

DROP PROCEDURE IF EXISTS GenerateCustodianAssignments$$

CREATE PROCEDURE GenerateCustodianAssignments()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_custodians INT DEFAULT 10000;
    DECLARE user_id INT;
    DECLARE dept_id INT;
    DECLARE item_id INT;
    DECLARE item_type ENUM('property','supply');
    DECLARE assign_date DATE;
    DECLARE random_num INT;
    DECLARE user_count INT;
    DECLARE dept_count INT;
    DECLARE prop_count INT;
    DECLARE supply_count INT;
    
    SELECT COUNT(*) INTO user_count FROM users WHERE status = 'Active';
    SELECT COUNT(*) INTO dept_count FROM departments WHERE status = 'Active';
    SELECT COUNT(*) INTO prop_count FROM properties WHERE status = 'Active';
    SELECT COUNT(*) INTO supply_count FROM supplies WHERE stockStatus IN ('Available', 'Low Stock');
    
    DECLARE done INT DEFAULT 0;
    
    -- Assign custodians for properties (first 5000)
    DECLARE prop_cur CURSOR FOR
        SELECT p.propertyId, p.departmentId, p.assignedTo, p.acquisitionDate
        FROM properties p
        WHERE p.assignedTo IS NOT NULL
        AND p.status = 'Active'
        LIMIT 5000;
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 0;
    
    OPEN prop_cur;
    
    prop_loop: LOOP
        FETCH prop_cur INTO item_id, dept_id, user_id, assign_date;
        
        IF done THEN
            SET done = 0;
            LEAVE prop_loop;
        END IF;
        
        -- Create custodian record
        INSERT INTO custodian (
            userId, departmentId, itemId, itemType, assignedDate,
            status, createdAt, updatedAt
        ) VALUES (
            user_id, dept_id, item_id, 'property', assign_date,
            'Active', assign_date, NOW()
        );
        
        SET i = i + 1;
        
    END LOOP;
    
    CLOSE prop_cur;
    COMMIT;
    
    -- Assign custodians for supplies (next 3000)
    SET done = 0;
    
    DECLARE supply_cur CURSOR FOR
        SELECT s.supplyId, s.assignedTo, s.dateReceived
        FROM supplies s
        WHERE s.assignedTo IS NOT NULL
        LIMIT 3000;
    
    OPEN supply_cur;
    
    supply_loop: LOOP
        FETCH supply_cur INTO item_id, user_id, assign_date;
        
        IF done THEN
            SET done = 0;
            LEAVE supply_loop;
        END IF;
        
        -- Get user's department
        SELECT departmentId INTO dept_id
        FROM users
        WHERE userId = user_id
        LIMIT 1;
        
        IF dept_id IS NOT NULL THEN
            INSERT INTO custodian (
                userId, departmentId, itemId, itemType, assignedDate,
                status, createdAt, updatedAt
            ) VALUES (
                user_id, dept_id, item_id, 'supply', assign_date,
                'Active', assign_date, NOW()
            );
            
            SET i = i + 1;
        END IF;
        
    END LOOP;
    
    CLOSE supply_cur;
    COMMIT;
    
    -- Generate additional custodian assignments to reach 10,000+
    WHILE i < total_custodians DO
        -- Randomly assign property or supply (70% property, 30% supply)
        IF RAND() < 0.70 THEN
            SET item_type = 'property';
            -- Get random property
            SELECT propertyId, departmentId INTO item_id, dept_id
            FROM properties
            WHERE status = 'Active'
            ORDER BY RAND()
            LIMIT 1;
        ELSE
            SET item_type = 'supply';
            -- Get random supply
            SELECT supplyId INTO item_id
            FROM supplies
            WHERE stockStatus IN ('Available', 'Low Stock')
            ORDER BY RAND()
            LIMIT 1;
            
            -- Random department
            SET dept_id = FLOOR(1 + RAND() * dept_count);
        END IF;
        
        -- Random user (prefer Custodian role but any active user)
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 60 THEN
            -- 60% chance to assign to Custodian role
            SELECT userId INTO user_id
            FROM users
            WHERE status = 'Active' AND role = 'Custodian'
            ORDER BY RAND()
            LIMIT 1;
        ELSE
            -- 40% chance to assign to any staff
            SELECT userId INTO user_id
            FROM users
            WHERE status = 'Active'
            ORDER BY RAND()
            LIMIT 1;
        END IF;
        
        -- Random assignment date (within last 3 years)
        SET assign_date = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 1095) DAY);
        
        -- Check if this assignment already exists
        IF NOT EXISTS (
            SELECT 1 FROM custodian 
            WHERE userId = user_id 
            AND itemId = item_id 
            AND itemType = item_type
        ) THEN
            INSERT INTO custodian (
                userId, departmentId, itemId, itemType, assignedDate,
                status, createdAt, updatedAt
            ) VALUES (
                user_id, dept_id, item_id, item_type, assign_date,
                'Active', assign_date, NOW()
            );
            
            SET i = i + 1;
            
            IF i MOD 1000 = 0 THEN
                COMMIT;
                SELECT CONCAT('Generated ', i, ' custodian assignments...') AS Progress;
            END IF;
        END IF;
        
    END WHILE;
    
    COMMIT;
END$$

-- ================================================================
-- PART 3: AUDIT LOGS
-- ================================================================

DROP PROCEDURE IF EXISTS GenerateAuditLogs$$

CREATE PROCEDURE GenerateAuditLogs()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_logs INT DEFAULT 50000;
    DECLARE user_id INT;
    DECLARE action VARCHAR(100);
    DECLARE table_name VARCHAR(100);
    DECLARE record_id INT;
    DECLARE description TEXT;
    DECLARE ip_address VARCHAR(50);
    DECLARE user_agent VARCHAR(255);
    DECLARE created_at DATETIME;
    DECLARE random_num INT;
    DECLARE user_count INT;
    
    SELECT COUNT(*) INTO user_count FROM users WHERE status = 'Active';
    
    SET @actions = 'LOGIN,LOGOUT,CREATE,UPDATE,DELETE,VIEW,APPROVE,REJECT,ASSIGN,UNASSIGN,BORROW,RETURN,REQUEST,CANCEL,EXPORT,IMPORT,PRINT,DOWNLOAD,UPLOAD,SEARCH,FILTER,SORT,BACKUP,RESTORE,CONFIGURE,MAINTAIN,REPAIR,DISPOSE';
    
    SET @tables = 'users,properties,supplies,property_requests,supplies_requests,maintenance_requests,maintenance,borrowed_items,custodian,departments,categories';
    
    SET @descriptions = 'User logged into the system,User logged out of the system,New record created successfully,Record updated successfully,Record deleted from system,Record viewed by user,Request approved by administrator,Request rejected by administrator,Item assigned to user,Item unassigned from user,Item borrowed by user,Item returned to inventory,New request submitted,Request cancelled by user,Report exported to Excel,Data imported from file,Document printed,File downloaded,File uploaded to system,Search performed,Results filtered,Data sorted,Database backup created,Data restored from backup,System configuration updated,Maintenance performed,Repair completed,Item marked for disposal,Property registered,Supply received,Equipment inspected,Asset verified,Inventory updated,Stock adjusted,User account created,User account modified,User password changed,Permission granted,Permission revoked,Role assigned,Department created,Category added,Report generated,Transaction recorded,Audit trail updated,System accessed,Data retrieved,Changes saved,Settings modified,Profile updated,Status changed,Assignment modified,Request forwarded,Approval pending,Processing completed';
    
    SET @ips = '192.168.1.,10.0.0.,172.16.0.,192.168.0.';
    SET @browsers = 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36,Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0,Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36,Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36,Mozilla/5.0 (Windows NT 10.0; Win64; x64) Edge/91.0';
    
    WHILE i < total_logs DO
        SET user_id = FLOOR(1 + RAND() * user_count);
        SET action = SUBSTRING_INDEX(SUBSTRING_INDEX(@actions, ',', FLOOR(1 + RAND() * 28)), ',', -1);
        SET table_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@tables, ',', FLOOR(1 + RAND() * 11)), ',', -1);
        SET record_id = FLOOR(1 + RAND() * 10000);
        SET description = SUBSTRING_INDEX(SUBSTRING_INDEX(@descriptions, ',', FLOOR(1 + RAND() * 50)), ',', -1);
        
        -- Generate IP address
        SET ip_address = CONCAT(
            SUBSTRING_INDEX(SUBSTRING_INDEX(@ips, ',', FLOOR(1 + RAND() * 4)), ',', -1),
            FLOOR(1 + RAND() * 254)
        );
        
        SET user_agent = SUBSTRING_INDEX(SUBSTRING_INDEX(@browsers, ',', FLOOR(1 + RAND() * 5)), ',', -1);
        SET created_at = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 365) DAY) + INTERVAL FLOOR(RAND() * 86400) SECOND;
        
        INSERT INTO audit_logs (
            userId, action, tableName, recordId, description,
            ipAddress, userAgent, createdAt
        ) VALUES (
            user_id, action, table_name, record_id, description,
            ip_address, user_agent, created_at
        );
        
        SET i = i + 1;
        
        IF i MOD 5000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' audit logs...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

DELIMITER ;

-- ================================================================
-- EXECUTE ALL PROCEDURES
-- ================================================================

SELECT '=== STARTING FINAL DATA GENERATION ===' AS Info;

SELECT 'Generating borrowed items...' AS Status;
CALL GenerateBorrowedItems();

SELECT 'Generating custodian assignments...' AS Status;
CALL GenerateCustodianAssignments();

SELECT 'Generating audit logs...' AS Status;
CALL GenerateAuditLogs();

-- ================================================================
-- STATISTICS
-- ================================================================

SELECT '=== ALL DATA GENERATION COMPLETE ===' AS Info;

SELECT 'Borrowed Items' AS 'Type',
    COUNT(*) AS 'Total',
    SUM(CASE WHEN status = 'Borrowed' THEN 1 ELSE 0 END) AS 'Currently Borrowed',
    SUM(CASE WHEN status = 'Returned' THEN 1 ELSE 0 END) AS 'Returned',
    SUM(CASE WHEN status = 'Overdue' THEN 1 ELSE 0 END) AS 'Overdue',
    SUM(CASE WHEN status = 'Lost' THEN 1 ELSE 0 END) AS 'Lost'
FROM borrowed_items;

SELECT 
    itemType AS 'Item Type',
    COUNT(*) AS 'Borrowed Count'
FROM borrowed_items
GROUP BY itemType;

SELECT 'Custodian Assignments' AS 'Type',
    COUNT(*) AS 'Total',
    SUM(CASE WHEN itemType = 'property' THEN 1 ELSE 0 END) AS 'Properties',
    SUM(CASE WHEN itemType = 'supply' THEN 1 ELSE 0 END) AS 'Supplies',
    SUM(CASE WHEN status = 'Active' THEN 1 ELSE 0 END) AS 'Active'
FROM custodian;

SELECT 'Audit Logs' AS 'Type',
    COUNT(*) AS 'Total Records',
    COUNT(DISTINCT userId) AS 'Unique Users',
    COUNT(DISTINCT action) AS 'Unique Actions',
    MIN(createdAt) AS 'Earliest Log',
    MAX(createdAt) AS 'Latest Log'
FROM audit_logs;

SELECT 
    action AS 'Action',
    COUNT(*) AS 'Count'
FROM audit_logs
GROUP BY action
ORDER BY COUNT(*) DESC
LIMIT 10;

SET FOREIGN_KEY_CHECKS = 1;
SET AUTOCOMMIT = 1;

-- Drop procedures
DROP PROCEDURE IF EXISTS GenerateBorrowedItems;
DROP PROCEDURE IF EXISTS GenerateCustodianAssignments;
DROP PROCEDURE IF EXISTS GenerateAuditLogs;

SELECT 'All data generation completed successfully!' AS Status;
SELECT 'You can now use the system with realistic test data!' AS Message;
