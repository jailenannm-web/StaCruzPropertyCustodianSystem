-- ================================================================
-- GENERATE REQUESTS AND MAINTENANCE RECORDS (10,000+ each)
-- Complete workflow: Requests -> Approval -> Maintenance
-- Database: teamcruzim
-- ================================================================

USE teamcruzim;

SET FOREIGN_KEY_CHECKS = 0;
SET AUTOCOMMIT = 0;

-- Clear existing records
DELETE FROM maintenance;
DELETE FROM maintenance_requests;
DELETE FROM property_requests;
DELETE FROM supplies_requests;

ALTER TABLE maintenance AUTO_INCREMENT = 1;
ALTER TABLE maintenance_requests AUTO_INCREMENT = 1;
ALTER TABLE property_requests AUTO_INCREMENT = 1;
ALTER TABLE supplies_requests AUTO_INCREMENT = 1;

-- ================================================================
-- PART 1: PROPERTY REQUESTS
-- ================================================================

DELIMITER $$

DROP PROCEDURE IF EXISTS GeneratePropertyRequests$$

CREATE PROCEDURE GeneratePropertyRequests()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_reqs INT DEFAULT 10000;
    DECLARE req_name VARCHAR(200);
    DECLARE position VARCHAR(100);
    DECLARE dept_id INT;
    DECLARE req_date DATE;
    DECLARE item VARCHAR(200);
    DECLARE description TEXT;
    DECLARE qty INT;
    DECLARE unit VARCHAR(50);
    DECLARE purpose TEXT;
    DECLARE status ENUM('Pending','Approved','Rejected');
    DECLARE approved_by INT;
    DECLARE approved_date DATETIME;
    DECLARE remarks TEXT;
    DECLARE random_num INT;
    DECLARE user_count INT;
    DECLARE dept_count INT;
    DECLARE admin_user INT;
    
    SELECT COUNT(*) INTO user_count FROM users WHERE status = 'Active';
    SELECT COUNT(*) INTO dept_count FROM departments WHERE status = 'Active';
    SELECT userId INTO admin_user FROM users WHERE role IN ('Admin','SuperAdmin') AND status = 'Active' LIMIT 1;
    
    SET @property_items = 'Desktop Computer,Laptop Computer,Printer,Scanner,Projector,Air Conditioning Unit,Electric Fan,Office Desk,Office Chair,Filing Cabinet,Whiteboard,Conference Table,Bookshelf,Water Dispenser,Telephone Set,CCTV Camera,Modem Router,Network Switch,UPS,Monitor,Keyboard,Mouse,External Hard Drive,Flash Drive,Photocopier,Laminating Machine,Binding Machine,Paper Shredder,Calculator,Digital Camera,Microphone,Speaker System,Laboratory Equipment,Microscope,Centrifuge,Weighing Scale,Classroom Chair,Student Desk,Blackboard,Smart TV,Fire Extinguisher,First Aid Kit,Tool Set,Ladder,Generator,Vehicle,Motorcycle,Bicycle,Sports Equipment,Musical Instrument,Medical Equipment,Laboratory Apparatus,Teaching Aid,Audio Visual Equipment';
    
    SET @purposes = 'For office use and daily operations,Needed for academic instruction,Required for laboratory activities,For student training and development,Replacement of old/damaged equipment,For research and development purposes,To improve operational efficiency,For departmental requirements,Needed for special projects,For upcoming events and activities,To support teaching and learning,For administrative functions,Required for compliance and accreditation,To enhance service delivery,For faculty and staff use,Needed for community extension services,For curriculum implementation,To support student organizations,For maintenance and repair work,Required for health and safety,For documentation purposes,To improve security measures,For information technology upgrade,Needed for quality assurance,To support institutional goals,For professional development,Required for new programs,To replace obsolete equipment,For inventory replenishment,Needed for emergency preparedness';
    
    SET @positions = 'Professor,Instructor,Department Head,Dean,Director,Administrative Officer,Program Coordinator,Faculty Member,Department Secretary,College Secretary,Laboratory In-Charge,Property Custodian,Supply Officer,IT Officer,Maintenance Staff,Security Officer,Librarian,Registrar,Guidance Counselor,Campus Nurse';
    
    WHILE i < total_reqs DO
        -- Random user as requester
        SELECT CONCAT(firstName, ' ', lastName), position, departmentId
        INTO req_name, position, dept_id
        FROM users 
        WHERE status = 'Active' AND userId = FLOOR(2 + RAND() * (user_count - 1))
        LIMIT 1;
        
        IF position IS NULL THEN
            SET position = SUBSTRING_INDEX(SUBSTRING_INDEX(@positions, ',', FLOOR(1 + RAND() * 20)), ',', -1);
        END IF;
        
        SET req_date = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 365) DAY);
        SET item = SUBSTRING_INDEX(SUBSTRING_INDEX(@property_items, ',', FLOOR(1 + RAND() * 50)), ',', -1);
        SET description = CONCAT('Request for ', item, ' - School property');
        SET qty = FLOOR(1 + RAND() * 5);
        SET unit = 'unit';
        SET purpose = SUBSTRING_INDEX(SUBSTRING_INDEX(@purposes, ',', FLOOR(1 + RAND() * 30)), ',', -1);
        
        -- Status distribution: 60% Approved, 25% Pending, 15% Rejected
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 60 THEN
            SET status = 'Approved';
            SET approved_by = admin_user;
            SET approved_date = DATE_ADD(req_date, INTERVAL FLOOR(1 + RAND() * 10) DAY);
            SET remarks = 'Request approved and processed';
        ELSEIF random_num <= 85 THEN
            SET status = 'Pending';
            SET approved_by = NULL;
            SET approved_date = NULL;
            SET remarks = 'Request under review';
        ELSE
            SET status = 'Rejected';
            SET approved_by = admin_user;
            SET approved_date = DATE_ADD(req_date, INTERVAL FLOOR(1 + RAND() * 5) DAY);
            SET remarks = CASE FLOOR(1 + RAND() * 5)
                WHEN 1 THEN 'Insufficient budget'
                WHEN 2 THEN 'Item not available'
                WHEN 3 THEN 'Duplicate request'
                WHEN 4 THEN 'Request not justified'
                ELSE 'Postponed to next fiscal year'
            END;
        END IF;
        
        INSERT INTO property_requests (
            requesterName, position, departmentId, dateOfRequest, itemName,
            description, quantityRequested, unit, purpose, status,
            approvedBy, approvedDate, remarks, createdAt, updatedAt
        ) VALUES (
            req_name, position, dept_id, req_date, item,
            description, qty, unit, purpose, status,
            approved_by, approved_date, remarks, req_date, NOW()
        );
        
        SET i = i + 1;
        
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' property requests...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

-- ================================================================
-- PART 2: SUPPLY REQUESTS
-- ================================================================

DROP PROCEDURE IF EXISTS GenerateSupplyRequests$$

CREATE PROCEDURE GenerateSupplyRequests()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_reqs INT DEFAULT 10000;
    DECLARE req_name VARCHAR(200);
    DECLARE position VARCHAR(100);
    DECLARE dept_id INT;
    DECLARE req_date DATE;
    DECLARE item VARCHAR(200);
    DECLARE description TEXT;
    DECLARE qty INT;
    DECLARE unit VARCHAR(50);
    DECLARE purpose TEXT;
    DECLARE status ENUM('Pending','Approved','Rejected');
    DECLARE approved_by INT;
    DECLARE approved_date DATETIME;
    DECLARE remarks TEXT;
    DECLARE random_num INT;
    DECLARE user_count INT;
    DECLARE admin_user INT;
    
    SELECT COUNT(*) INTO user_count FROM users WHERE status = 'Active';
    SELECT userId INTO admin_user FROM users WHERE role IN ('Admin','SuperAdmin') AND status = 'Active' LIMIT 1;
    
    SET @supply_items = 'Bond Paper,Ballpen,Marker,Pencil,Notebook,Folder,Envelope,Stapler,Staple Wire,Paper Clips,Tape,Glue,Scissors,Ruler,Eraser,Correction Tape,Pad Paper,Yellow Pad,Manila Paper,Cartolina,Chalk,Whiteboard Marker,Highlighter,Post-it Notes,Calculator,Stamp Pad,Ink,Fastener,Puncher,Binder,Clear Book,Expansion Folder,Document Holder,Tissue Paper,Alcohol,Detergent,Disinfectant,Garbage Bag,Cleaning Supplies,Printer Ink,Toner,CD-R,DVD-R,USB Flash Drive,Battery,Light Bulb,Extension Cord,First Aid Supplies,Medical Supplies,Laboratory Supplies';
    
    SET @units = 'ream,box,piece,pack,dozen,bottle,roll,pad,set,bundle';
    
    WHILE i < total_reqs DO
        SELECT CONCAT(firstName, ' ', lastName), position, departmentId
        INTO req_name, position, dept_id
        FROM users 
        WHERE status = 'Active' AND userId = FLOOR(2 + RAND() * (user_count - 1))
        LIMIT 1;
        
        SET req_date = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 365) DAY);
        SET item = SUBSTRING_INDEX(SUBSTRING_INDEX(@supply_items, ',', FLOOR(1 + RAND() * 50)), ',', -1);
        SET description = CONCAT('Supply request for ', item);
        SET qty = FLOOR(1 + RAND() * 20);
        SET unit = SUBSTRING_INDEX(SUBSTRING_INDEX(@units, ',', FLOOR(1 + RAND() * 10)), ',', -1);
        SET purpose = 'For office/departmental use and operations';
        
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 65 THEN
            SET status = 'Approved';
            SET approved_by = admin_user;
            SET approved_date = DATE_ADD(req_date, INTERVAL FLOOR(1 + RAND() * 7) DAY);
            SET remarks = 'Approved and ready for release';
        ELSEIF random_num <= 85 THEN
            SET status = 'Pending';
            SET approved_by = NULL;
            SET approved_date = NULL;
            SET remarks = 'For verification';
        ELSE
            SET status = 'Rejected';
            SET approved_by = admin_user;
            SET approved_date = DATE_ADD(req_date, INTERVAL FLOOR(1 + RAND() * 3) DAY);
            SET remarks = 'Out of stock or budget constraint';
        END IF;
        
        INSERT INTO supplies_requests (
            requesterName, position, departmentId, dateOfRequest, itemName,
            description, quantityRequested, unit, purpose, status,
            approvedBy, approvedDate, remarks, createdAt, updatedAt
        ) VALUES (
            req_name, position, dept_id, req_date, item,
            description, qty, unit, purpose, status,
            approved_by, approved_date, remarks, req_date, NOW()
        );
        
        SET i = i + 1;
        
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' supply requests...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

-- ================================================================
-- PART 3: MAINTENANCE REQUESTS
-- ================================================================

DROP PROCEDURE IF EXISTS GenerateMaintenanceRequests$$

CREATE PROCEDURE GenerateMaintenanceRequests()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_reqs INT DEFAULT 10000;
    DECLARE req_date DATE;
    DECLARE item VARCHAR(200);
    DECLARE prop_num VARCHAR(100);
    DECLARE serial VARCHAR(100);
    DECLARE dept_id INT;
    DECLARE location VARCHAR(200);
    DECLARE condition_before ENUM('Good','Needs Repair','Damaged');
    DECLARE issue_type ENUM('Repair','Replace','Servicing');
    DECLARE problem TEXT;
    DECLARE status ENUM('Pending','Approved','In Progress','Completed','Rejected');
    DECLARE tech VARCHAR(200);
    DECLARE target_date DATE;
    DECLARE completion_date DATE;
    DECLARE requested_by INT;
    DECLARE random_num INT;
    DECLARE user_count INT;
    DECLARE dept_count INT;
    
    SELECT COUNT(*) INTO user_count FROM users WHERE status = 'Active';
    SELECT COUNT(*) INTO dept_count FROM departments WHERE status = 'Active';
    
    SET @equipment = 'Air Conditioning Unit,Computer Desktop,Laptop,Printer,Photocopier,Electric Fan,Water Dispenser,Projector,CCTV Camera,Telephone,Refrigerator,Microwave,Coffee Maker,Vehicle,Motorcycle,Lighting Fixture,Electrical Outlet,Plumbing Fixture,Door Lock,Window,Ceiling,Floor,Wall,Furniture,Chair,Table,Cabinet,Whiteboard,Blackboard,Generator,UPS,Modem,Router,Switch,Server,Network Equipment,Laboratory Equipment,Microscope,Centrifuge,Medical Equipment,Sports Equipment,Musical Instrument,Sound System,Amplifier,Microphone';
    
    SET @problems = 'Not working/Not functioning,Intermittent malfunction,Making unusual noise,Overheating,Not turning on,Power issue,Display problem,Printing quality issue,Paper jam,Connectivity problem,Network issue,Software malfunction,Hardware failure,Broken parts,Leaking,Clogged,Short circuit,Worn out,Cracked,Damaged,Needs cleaning,Needs replacement of parts,Battery not charging,Screen not working,Keys not functioning,No sound,Image quality poor,Slow performance,Error messages appearing,System crash,Blue screen error,Virus/malware infection,Driver issue,Configuration problem,Compatibility issue,Update required,Calibration needed,Alignment problem,Settings incorrect,Missing components,Loose connection,Rust/corrosion,Fading/discoloration,Scratches/dents,Wear and tear,Age-related deterioration,Exposure damage,Water damage,Physical damage,Accident damage';
    
    SET @technicians = 'Engr. Mario Cruz,Engr. Pedro Santos,Engr. Luis Reyes,Mr. Roberto Garcia,Mr. Antonio Torres,Mr. Carlos Mendoza,Mr. Fernando Ramos,Mr. Eduardo Silva,Mr. Ramon Gonzales,Mr. Alberto Rivera,Mr. Rodrigo Lopez,Mr. Manuel Martinez,Mr. Jose Rodriguez,Mr. Miguel Hernandez,Mr. Juan Perez,Mr. Francisco Sanchez,Engr. Ricardo Ramirez,Engr. Diego Gutierrez,Engr. Gabriel Diaz,Engr. Victor Fernandez';
    
    WHILE i < total_reqs DO
        SET req_date = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 365) DAY);
        SET item = SUBSTRING_INDEX(SUBSTRING_INDEX(@equipment, ',', FLOOR(1 + RAND() * 50)), ',', -1);
        SET prop_num = CONCAT('PROP-', YEAR(req_date), '-', LPAD(FLOOR(1 + RAND() * 9999), 5, '0'));
        
        IF RAND() < 0.7 THEN
            SET serial = CONCAT(SUBSTRING('ABCDEFGHIJKLMNOPQRSTUVWXYZ', FLOOR(1 + RAND() * 26), 1),
                              SUBSTRING('ABCDEFGHIJKLMNOPQRSTUVWXYZ', FLOOR(1 + RAND() * 26), 1),
                              FLOOR(100000 + RAND() * 900000));
        ELSE
            SET serial = NULL;
        END IF;
        
        SET dept_id = FLOOR(1 + RAND() * dept_count);
        SET location = CONCAT('Room ', FLOOR(100 + RAND() * 400));
        
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 50 THEN
            SET condition_before = 'Needs Repair';
        ELSEIF random_num <= 80 THEN
            SET condition_before = 'Good';
        ELSE
            SET condition_before = 'Damaged';
        END IF;
        
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 70 THEN
            SET issue_type = 'Repair';
        ELSEIF random_num <= 85 THEN
            SET issue_type = 'Servicing';
        ELSE
            SET issue_type = 'Replace';
        END IF;
        
        SET problem = SUBSTRING_INDEX(SUBSTRING_INDEX(@problems, ',', FLOOR(1 + RAND() * 50)), ',', -1);
        
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 50 THEN
            SET status = 'Completed';
            SET tech = SUBSTRING_INDEX(SUBSTRING_INDEX(@technicians, ',', FLOOR(1 + RAND() * 20)), ',', -1);
            SET target_date = DATE_ADD(req_date, INTERVAL FLOOR(3 + RAND() * 10) DAY);
            SET completion_date = DATE_ADD(target_date, INTERVAL FLOOR(-2 + RAND() * 5) DAY);
        ELSEIF random_num <= 70 THEN
            SET status = 'In Progress';
            SET tech = SUBSTRING_INDEX(SUBSTRING_INDEX(@technicians, ',', FLOOR(1 + RAND() * 20)), ',', -1);
            SET target_date = DATE_ADD(req_date, INTERVAL FLOOR(3 + RAND() * 10) DAY);
            SET completion_date = NULL;
        ELSEIF random_num <= 85 THEN
            SET status = 'Approved';
            SET tech = SUBSTRING_INDEX(SUBSTRING_INDEX(@technicians, ',', FLOOR(1 + RAND() * 20)), ',', -1);
            SET target_date = DATE_ADD(req_date, INTERVAL FLOOR(3 + RAND() * 10) DAY);
            SET completion_date = NULL;
        ELSEIF random_num <= 95 THEN
            SET status = 'Pending';
            SET tech = NULL;
            SET target_date = NULL;
            SET completion_date = NULL;
        ELSE
            SET status = 'Rejected';
            SET tech = NULL;
            SET target_date = NULL;
            SET completion_date = NULL;
        END IF;
        
        SET requested_by = FLOOR(2 + RAND() * (user_count - 1));
        
        INSERT INTO maintenance_requests (
            dateRequested, itemName, propertyNumber, serialNumber,
            departmentId, location, conditionBefore, typeOfIssue,
            problemDescription, status, assignedTechnician, targetDate,
            completionDate, requestedBy, createdAt, updatedAt
        ) VALUES (
            req_date, item, prop_num, serial,
            dept_id, location, condition_before, issue_type,
            problem, status, tech, target_date,
            completion_date, requested_by, req_date, NOW()
        );
        
        SET i = i + 1;
        
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' maintenance requests...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

-- ================================================================
-- PART 4: MAINTENANCE RECORDS (10,000+)
-- ================================================================

DROP PROCEDURE IF EXISTS GenerateMaintenanceRecords$$

CREATE PROCEDURE GenerateMaintenanceRecords()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_maint INT DEFAULT 10000;
    DECLARE req_id INT;
    DECLARE item VARCHAR(200);
    DECLARE serial VARCHAR(100);
    DECLARE location VARCHAR(200);
    DECLARE dept_id INT;
    DECLARE cond_before ENUM('Good','Needs Repair','Damaged');
    DECLARE maint_type ENUM('Repair','Replace','Servicing');
    DECLARE tech VARCHAR(200);
    DECLARE maint_date DATE;
    DECLARE cost DECIMAL(15,2);
    DECLARE cond_after ENUM('Good','Needs Further Repair');
    DECLARE diagnosis TEXT;
    DECLARE action_taken TEXT;
    DECLARE parts TEXT;
    DECLARE random_num INT;
    DECLARE dept_count INT;
    
    SELECT COUNT(*) INTO dept_count FROM departments WHERE status = 'Active';
    
    -- Equipment items
    SET @equipment = 'Air Conditioning Unit,Desktop Computer,Laptop Computer,Printer,Scanner,Photocopier,Electric Fan,Water Dispenser,Refrigerator,Microwave Oven,Projector,CCTV Camera,Telephone,Lighting Fixture,Electrical Outlet,Plumbing Fixture,Door Lock,Window,Ceiling Fan,Generator Set,UPS Unit,Modem Router,Network Switch,Vehicle,Motorcycle,Laboratory Equipment,Microscope,Centrifuge,Medical Equipment,Sports Equipment,Musical Instrument,Sound System,Whiteboard,Blackboard,Office Chair,Office Table,Filing Cabinet,Book Shelf,Display Cabinet';
    
    -- Technicians
    SET @technicians = 'Engr. Mario Cruz,Engr. Pedro Santos,Engr. Luis Reyes,Mr. Roberto Garcia,Mr. Antonio Torres,Mr. Carlos Mendoza,Mr. Fernando Ramos,Mr. Eduardo Silva,Mr. Ramon Gonzales,Mr. Alberto Rivera,Mr. Rodrigo Lopez,Mr. Manuel Martinez,Mr. Jose Rodriguez,Mr. Miguel Hernandez,Mr. Juan Perez,Mr. Francisco Sanchez,Engr. Ricardo Ramirez,Engr. Diego Gutierrez,Engr. Gabriel Diaz,Engr. Victor Fernandez,Engr. Sergio Alvarez,Engr. Pablo Morales,Engr. Andres Castillo,Engr. Jorge Jimenez,Engr. Cesar Romero,Mr. Felipe Vargas,Mr. Raul Castro,Mr. Javier Ortiz,Mr. Daniel Salazar,Mr. Leonardo Navarro';
    
    DECLARE done INT DEFAULT 0;
    DECLARE comp_cur CURSOR FOR 
        SELECT requestId, itemName, serialNumber, location, departmentId,
               conditionBefore, typeOfIssue, assignedTechnician, completionDate
        FROM maintenance_requests
        WHERE status = 'Completed' AND completionDate IS NOT NULL
        LIMIT 5000;
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
    
    SET @diagnoses = 'Faulty component identified,Worn out parts detected,Circuit malfunction found,Loose connections discovered,Software corruption detected,Hardware failure confirmed,Normal wear and tear,Improper installation identified,Power supply issue,Cooling system failure,Memory failure,Hard drive failure,Display malfunction,Input device failure,Network connectivity issue,Driver conflict,Configuration error,Age-related deterioration,Physical damage assessment,Environmental damage,Electrical surge damage,Water damage detected,Overuse and abuse,Lack of maintenance,Improper handling,Compatibility issue found,Component overheating,Electrical short circuit,Mechanical wear,Sensor malfunction,Actuator failure,Control system error,Communication breakdown,Data corruption,System lockup,Performance degradation,Intermittent failure,Complete shutdown,Partial functionality loss';
    
    SET @actions = 'Replaced faulty parts,Cleaned and lubricated components,Re-configured system settings,Updated software/firmware,Repaired damaged parts,Adjusted and calibrated,Tightened loose connections,Replaced worn components,Installed new parts,Reset to factory settings,Performed preventive maintenance,Applied firmware update,Changed filters,Replaced consumables,Conducted thorough cleaning,Realigned components,Reinforced structure,Applied protective coating,Tested all functions,Verified proper operation,Restored default settings,Removed malware/virus,Optimized performance,Upgraded components,Conducted stress test,Performed diagnostic testing,Replaced damaged wiring,Repaired connection points,Calibrated instruments,Cleaned ventilation system,Replaced cooling system,Updated drivers,Reconfigured network,Restored backup,Reinstalled software,Applied security patches';
    
    SET @parts = 'Power supply unit,Cooling fan,Circuit board,Memory module,Hard disk drive,Battery pack,Display screen,Keyboard,Mouse,Cable assembly,Connector,Switch,Relay,Capacitor,Resistor,Fuse,Bulb,Filter,Belt,Motor,Pump,Valve,Seal,Gasket,Bearing,Gear,Spring,Bolt,Screw,Washer,Wire,Plug,Socket,Adapter,Sensor,Controller,Actuator,Transformer,Diode,Transistor,IC chip,Heat sink,Thermal paste,Cleaning solution,Lubricant,Adhesive,Sealant,Paint,Coating,Thermostat,Pressure switch,Temperature sensor,Proximity sensor,Photoelectric sensor,Limit switch,Circuit breaker,Contactor,Solenoid,Pneumatic cylinder,Hydraulic hose';
    
    -- First, process completed maintenance requests
    OPEN comp_cur;
    
    read_loop: LOOP
        FETCH comp_cur INTO req_id, item, serial, location, dept_id, cond_before, maint_type, tech, maint_date;
        
        IF done THEN
            LEAVE read_loop;
        END IF;
        
        -- Calculate cost
        IF maint_type = 'Replace' THEN
            SET cost = 5000 + FLOOR(RAND() * 45000);
        ELSEIF maint_type = 'Repair' THEN
            SET cost = 500 + FLOOR(RAND() * 9500);
        ELSE
            SET cost = 200 + FLOOR(RAND() * 1800);
        END IF;
        
        -- Condition after maintenance
        IF RAND() < 0.9 THEN
            SET cond_after = 'Good';
        ELSE
            SET cond_after = 'Needs Further Repair';
        END IF;
        
        SET diagnosis = SUBSTRING_INDEX(SUBSTRING_INDEX(@diagnoses, ',', FLOOR(1 + RAND() * 25)), ',', -1);
        SET action_taken = SUBSTRING_INDEX(SUBSTRING_INDEX(@actions, ',', FLOOR(1 + RAND() * 25)), ',', -1);
        
        IF maint_type IN ('Repair', 'Replace') THEN
            SET parts = SUBSTRING_INDEX(SUBSTRING_INDEX(@parts, ',', FLOOR(1 + RAND() * 50)), ',', -1);
        ELSE
            SET parts = NULL;
        END IF;
        
        INSERT INTO maintenance (
            requestId, propertyItemName, serialNumber, location, departmentId,
            conditionBeforeMaint, typeOfMaintenance, assignedTechnician,
            maintenanceDate, maintenanceDetails, costMaterialsLabor,
            conditionAfterMaint, status, diagnosis, actionTaken, partsReplaced,
            createdAt, updatedAt
        ) VALUES (
            req_id, item, serial, location, dept_id,
            cond_before, maint_type, tech,
            maint_date, CONCAT('Maintenance performed on ', item),
            cost, cond_after, 'Completed', diagnosis, action_taken, parts,
            maint_date, NOW()
        );
        
    END LOOP;
    
    CLOSE comp_cur;
    COMMIT;
    
    -- Now generate additional maintenance records to reach 10,000+
    SET i = (SELECT COUNT(*) FROM maintenance);
    
    WHILE i < total_maint DO
        -- Generate random maintenance record
        SET item = SUBSTRING_INDEX(SUBSTRING_INDEX(@equipment, ',', FLOOR(1 + RAND() * 40)), ',', -1);
        
        -- Random serial number (70% have serials)
        IF RAND() < 0.70 THEN
            SET serial = CONCAT(
                SUBSTRING('ABCDEFGHIJKLMNOPQRSTUVWXYZ', FLOOR(1 + RAND() * 26), 1),
                SUBSTRING('ABCDEFGHIJKLMNOPQRSTUVWXYZ', FLOOR(1 + RAND() * 26), 1),
                FLOOR(100000 + RAND() * 900000)
            );
        ELSE
            SET serial = NULL;
        END IF;
        
        SET dept_id = FLOOR(1 + RAND() * dept_count);
        SET location = CONCAT('Room ', FLOOR(100 + RAND() * 400));
        
        -- Condition before
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 50 THEN
            SET cond_before = 'Needs Repair';
        ELSEIF random_num <= 80 THEN
            SET cond_before = 'Good';
        ELSE
            SET cond_before = 'Damaged';
        END IF;
        
        -- Maintenance type
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 70 THEN
            SET maint_type = 'Repair';
        ELSEIF random_num <= 85 THEN
            SET maint_type = 'Servicing';
        ELSE
            SET maint_type = 'Replace';
        END IF;
        
        SET tech = SUBSTRING_INDEX(SUBSTRING_INDEX(@technicians, ',', FLOOR(1 + RAND() * 30)), ',', -1);
        SET maint_date = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 730) DAY);
        
        -- Cost based on type
        IF maint_type = 'Replace' THEN
            SET cost = 5000 + FLOOR(RAND() * 45000);
        ELSEIF maint_type = 'Repair' THEN
            SET cost = 500 + FLOOR(RAND() * 9500);
        ELSE
            SET cost = 200 + FLOOR(RAND() * 1800);
        END IF;
        
        -- Condition after (90% Good)
        IF RAND() < 0.9 THEN
            SET cond_after = 'Good';
        ELSE
            SET cond_after = 'Needs Further Repair';
        END IF;
        
        SET diagnosis = SUBSTRING_INDEX(SUBSTRING_INDEX(@diagnoses, ',', FLOOR(1 + RAND() * 40)), ',', -1);
        SET action_taken = SUBSTRING_INDEX(SUBSTRING_INDEX(@actions, ',', FLOOR(1 + RAND() * 40)), ',', -1);
        
        IF maint_type IN ('Repair', 'Replace') THEN
            SET parts = SUBSTRING_INDEX(SUBSTRING_INDEX(@parts, ',', FLOOR(1 + RAND() * 60)), ',', -1);
        ELSE
            SET parts = NULL;
        END IF;
        
        -- Insert maintenance record (without requestId for generated ones)
        INSERT INTO maintenance (
            requestId, propertyItemName, serialNumber, location, departmentId,
            conditionBeforeMaint, typeOfMaintenance, assignedTechnician,
            maintenanceDate, maintenanceDetails, costMaterialsLabor,
            conditionAfterMaint, status, diagnosis, actionTaken, partsReplaced,
            createdAt, updatedAt
        ) VALUES (
            NULL, item, serial, location, dept_id,
            cond_before, maint_type, tech,
            maint_date, CONCAT('Scheduled maintenance for ', item),
            cost, cond_after, 'Completed', diagnosis, action_taken, parts,
            maint_date, NOW()
        );
        
        SET i = i + 1;
        
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' maintenance records...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

DELIMITER ;

-- ================================================================
-- EXECUTE ALL PROCEDURES
-- ================================================================

SELECT '=== STARTING DATA GENERATION ===' AS Info;

SELECT 'Generating property requests...' AS Status;
CALL GeneratePropertyRequests();

SELECT 'Generating supply requests...' AS Status;
CALL GenerateSupplyRequests();

SELECT 'Generating maintenance requests...' AS Status;
CALL GenerateMaintenanceRequests();

SELECT 'Generating maintenance records...' AS Status;
CALL GenerateMaintenanceRecords();

-- ================================================================
-- STATISTICS
-- ================================================================

SELECT '=== GENERATION COMPLETE ===' AS Info;

SELECT 'Property Requests' AS 'Type', 
    COUNT(*) AS 'Total',
    SUM(CASE WHEN status = 'Approved' THEN 1 ELSE 0 END) AS 'Approved',
    SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END) AS 'Pending',
    SUM(CASE WHEN status = 'Rejected' THEN 1 ELSE 0 END) AS 'Rejected'
FROM property_requests
UNION ALL
SELECT 'Supply Requests',
    COUNT(*),
    SUM(CASE WHEN status = 'Approved' THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Rejected' THEN 1 ELSE 0 END)
FROM supplies_requests
UNION ALL
SELECT 'Maintenance Requests',
    COUNT(*),
    SUM(CASE WHEN status IN ('Approved','In Progress','Completed') THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END),
    SUM(CASE WHEN status = 'Rejected' THEN 1 ELSE 0 END)
FROM maintenance_requests;

SELECT 'Maintenance Records' AS 'Type',
    COUNT(*) AS 'Total',
    CONCAT('₱', FORMAT(SUM(costMaterialsLabor), 2)) AS 'Total Cost'
FROM maintenance;

SET FOREIGN_KEY_CHECKS = 1;
SET AUTOCOMMIT = 1;

-- Drop procedures
DROP PROCEDURE IF EXISTS GeneratePropertyRequests;
DROP PROCEDURE IF EXISTS GenerateSupplyRequests;
DROP PROCEDURE IF EXISTS GenerateMaintenanceRequests;
DROP PROCEDURE IF EXISTS GenerateMaintenanceRecords;

SELECT 'All requests and maintenance records generated successfully!' AS Status;
