-- ================================================================
-- GENERATE 10,000+ REALISTIC PROPERTY RECORDS
-- School equipment with proper assignments and tracking
-- Database: teamcruzim
-- ================================================================

USE teamcruzim;

SET FOREIGN_KEY_CHECKS = 0;
SET AUTOCOMMIT = 0;

-- Clear existing properties
DELETE FROM properties;
ALTER TABLE properties AUTO_INCREMENT = 1;

-- ================================================================
-- STORED PROCEDURE: Generate Properties
-- ================================================================

DELIMITER $$

DROP PROCEDURE IF EXISTS GenerateProperties$$

CREATE PROCEDURE GenerateProperties()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_props INT DEFAULT 10000;
    DECLARE item_name VARCHAR(200);
    DECLARE category VARCHAR(100);
    DECLARE description TEXT;
    DECLARE unit_measure VARCHAR(50);
    DECLARE prop_number VARCHAR(100);
    DECLARE serial_number VARCHAR(100);
    DECLARE acq_date DATE;
    DECLARE acq_cost DECIMAL(15,2);
    DECLARE total_cost DECIMAL(15,2);
    DECLARE source_funds VARCHAR(200);
    DECLARE assigned_to INT;
    DECLARE dept_id INT;
    DECLARE location VARCHAR(200);
    DECLARE condition_val ENUM('Good','Needs Repair','Damaged');
    DECLARE status_val ENUM('Active','Borrowed','For Disposal','Lost','Cost');
    DECLARE random_num INT;
    DECLARE user_count INT;
    DECLARE dept_count INT;
    DECLARE category_type VARCHAR(50);
    
    -- Get counts
    SELECT COUNT(*) INTO user_count FROM users WHERE status = 'Active';
    SELECT COUNT(*) INTO dept_count FROM departments WHERE status = 'Active';
    
    -- Property categories and items
    SET @office_equipment = 'Desktop Computer,Laptop Computer,Printer (Laser),Printer (Inkjet),Scanner,Photocopier Machine,Fax Machine,Telephone Set,Mobile Phone,Tablet Device,Projector (LCD),Projector (LED),Document Camera,Digital Camera,Video Camera,Air Conditioning Unit (Wall Type),Air Conditioning Unit (Split Type),Electric Fan (Stand),Electric Fan (Wall),Water Dispenser,Coffee Maker,Microwave Oven,Refrigerator,Filing Cabinet (4-Drawer),Filing Cabinet (2-Drawer),Office Desk (Executive),Office Desk (Standard),Office Chair (Executive),Office Chair (Staff),Conference Table,Conference Chair,Visitor Chair,Sofa Set,Reception Desk,Book Shelf,Display Cabinet,Whiteboard,Bulletin Board,Clock (Wall),Calculator,Paper Shredder,Laminating Machine,Binding Machine,Typewriter (Manual),Typewriter (Electric)';
    
    SET @it_equipment = 'Server (Rack Mount),Server (Tower),Network Switch (24-port),Network Switch (48-port),Router (Enterprise),Router (Office),Wireless Access Point,Firewall Device,UPS (1000VA),UPS (2000VA),UPS (3000VA),Surge Protector,Network Cable Tester,Crimping Tool,Patch Panel,Cable Organizer,External Hard Drive (1TB),External Hard Drive (2TB),External Hard Drive (4TB),USB Flash Drive (32GB),USB Flash Drive (64GB),USB Flash Drive (128GB),Keyboard (Wired),Keyboard (Wireless),Mouse (Wired),Mouse (Wireless),Webcam,Headset,Speakers,Monitor (19 inch),Monitor (21 inch),Monitor (24 inch),Monitor (27 inch),KVM Switch,Docking Station,Laptop Bag,Desktop Computer Case,Power Supply Unit,RAM Module (8GB),RAM Module (16GB),SSD (256GB),SSD (512GB),SSD (1TB),HDD (1TB),HDD (2TB),Graphics Card,DVD Writer,Cooling Fan,Cable Management Box,Monitor Stand,Laptop Stand,USB Hub,HDMI Cable,VGA Cable,Display Port Cable,Ethernet Cable,Power Cable';
    
    SET @furniture = 'Office Table,Computer Table,Study Table,Conference Table,Meeting Table,Reception Desk,Information Desk,Filing Cabinet,Storage Cabinet,Book Shelf,Magazine Rack,Coat Rack,Shoe Rack,Executive Chair,Office Chair,Visitor Chair,Conference Chair,Arm Chair,Sofa (3-Seater),Sofa (2-Seater),Single Seater Sofa,Office Partition,Room Divider,Bulletin Board,Whiteboard (4x6),Whiteboard (4x8),Chalkboard,Cork Board,Display Stand,Lectern,Podium,Classroom Chair,Student Desk,Training Table,Folding Chair,Stacking Chair,Bar Stool,Counter Chair,Bench (Wooden),Bench (Metal),Cabinet (Steel),Cabinet (Wooden),Drawer (Mobile),Locker (2-Door),Locker (4-Door),Locker (6-Door),Safe (Small),Safe (Large),Trolley,Book Cart,File Cart,Waste Bin,Recycling Bin,Umbrella Stand,Plant Stand,Magazine Table,Side Table,Coffee Table,End Table,Console Table';
    
    SET @vehicles = 'Service Vehicle (Toyota Hilux),Service Vehicle (Mitsubishi L300),Service Vehicle (Isuzu D-Max),Van (Toyota Hiace),Van (Nissan Urvan),Bus (Coaster),Bus (Rosa),Motorcycle (Delivery),Motorcycle (Service),Sedan (Toyota Vios),Sedan (Honda City),SUV (Toyota Fortuner),SUV (Mitsubishi Montero),Pickup Truck,Ambulance,Fire Truck,Utility Vehicle,Golf Cart,Bicycle,Tricycle';
    
    SET @laboratory_equipment = 'Microscope (Compound),Microscope (Digital),Centrifuge,Incubator,Hot Plate,Magnetic Stirrer,pH Meter,Weighing Scale (Analytical),Weighing Scale (Electronic),Spectrophotometer,Autoclave,Laboratory Oven,Water Bath,Fume Hood,Laboratory Bench,Pipette (Micropipette),Burette,Beaker Set,Flask Set,Test Tube Rack,Bunsen Burner,Petri Dish Set,Slide Box,Dissecting Kit,Laboratory Glassware Set,Safety Goggles,Laboratory Coat,First Aid Kit,Fire Extinguisher,Emergency Shower,Eye Wash Station,Chemical Storage Cabinet,Biological Safety Cabinet,Laminar Flow Hood,PCR Machine,Gel Electrophoresis Unit,DNA Sequencer,Cell Counter,Colony Counter,Rotary Evaporator,Sonicator,Homogenizer,Vortex Mixer,Shaker Incubator,Biosafety Cabinet,Refrigerator (Laboratory),Freezer (Deep),Liquid Nitrogen Tank,Gas Cylinder Rack,Laboratory Sink,Distilled Water System';
    
    SET @engineering_equipment = 'Oscilloscope,Multimeter (Digital),Function Generator,Power Supply (Variable),Logic Analyzer,Spectrum Analyzer,Signal Generator,Breadboard,Soldering Station,Desoldering Station,Hot Air Station,Wire Stripper,Crimping Tool,Cable Tester,LAN Tester,Voltage Tester,Clamp Meter,Infrared Thermometer,Laser Distance Meter,Surveying Equipment,Total Station,Theodolite,Level Instrument,GPS Device,Drone,3D Printer,CNC Machine,Lathe Machine,Milling Machine,Drilling Machine,Grinding Machine,Welding Machine,Cutting Machine,Hydraulic Press,Pneumatic Tools,Compressor,Generator Set,Tool Box,Hand Tools Set,Power Tools Set,Measuring Tools Set,Testing Equipment,Calibration Equipment,Safety Equipment';
    
    SET @sports_equipment = 'Basketball,Basketball Hoop,Volleyball,Volleyball Net,Football,Goal Post,Tennis Racket,Tennis Net,Badminton Racket,Badminton Net,Table Tennis Table,Table Tennis Racket,Billiard Table,Billiard Cue,Chess Set,Scrabble Set,Dart Board,Exercise Bike,Treadmill,Weight Bench,Dumbbells Set,Barbell Set,Gym Mat,Yoga Mat,Boxing Gloves,Punching Bag,Stopwatch,Whistle,Score Board,Timer,Megaphone,First Aid Kit (Sports),Water Cooler,Sports Bag,Equipment Cart,Ball Rack,Cone Markers,Hurdles,Starting Blocks,Baton,Discus,Javelin,Shot Put,High Jump Bar,Pole Vault,Long Jump Pit,Gymnasium Floor Mat,Climbing Wall,Trampoline';
    
    SET @musical_instruments = 'Piano (Upright),Piano (Grand),Electronic Keyboard,Guitar (Acoustic),Guitar (Electric),Bass Guitar,Ukulele,Violin,Viola,Cello,Flute,Clarinet,Saxophone (Alto),Saxophone (Tenor),Trumpet,Trombone,French Horn,Tuba,Drum Set,Snare Drum,Bass Drum,Cymbals,Xylophone,Marimba,Tambourine,Triangle,Maracas,Castanets,Music Stand,Amplifier,Microphone,Microphone Stand,Audio Mixer,Speaker System,Tuning Fork,Metronome,Guitar Stand,Piano Bench,Instrument Case';
    
    SET @medical_equipment = 'Stethoscope,Blood Pressure Monitor,Thermometer (Digital),Thermometer (Infrared),Pulse Oximeter,Glucometer,Weighing Scale (Medical),Height Measuring Device,Examination Table,Treatment Table,Medical Cabinet,Medicine Cabinet,Instrument Cabinet,Sterilizer,Autoclave (Medical),Surgical Instruments Set,Diagnostic Set,Otoscope,Ophthalmoscope,Nebulizer,Suction Machine,Oxygen Tank,Wheelchair,Hospital Bed,IV Stand,Medical Cart,Crash Cart,Defibrillator,ECG Machine,Ultrasound Machine,X-Ray Machine,Laboratory Equipment,Dental Chair,Dental Unit,Dental Instruments,Autoclave (Dental)';
    
    SET @library_equipment = 'Book Shelf (Steel),Book Shelf (Wooden),Library Table,Reading Table,Study Carrel,Computer Workstation,Barcode Scanner,RFID Reader,Book Scanner,Book Cart,Book Truck,Card Catalog Cabinet,Display Rack,Magazine Rack,Newspaper Stand,Atlas Stand,Dictionary Stand,Circulation Desk,Reference Desk,Librarian Desk,Book Drop Box,Book Return Cart,Library Ladder,Step Stool,Book End,Book Stand,Book Rest,Reading Lamp,Table Lamp,Signage,Direction Sign,Shelf Label Holder,Book Pocket,Date Due Slip Box,Library Card Box,Stamp Pad,Date Stamp,Library Stamp,Borrowers Card,Accession Register,Catalog Card,Spine Label,Barcode Label,Book Cover,Book Jacket,Book Repair Kit,Library Supplies';
    
    -- All categories combined
    SET @all_categories = 'Office Equipment,IT Equipment,Furniture,Vehicles,Laboratory Equipment,Engineering Equipment,Sports Equipment,Musical Instruments,Medical Equipment,Library Equipment';
    
    SET @units = 'unit,piece,set,unit,piece,set';
    SET @fund_sources = 'General Fund,Special Education Fund (SEF),Trust Fund,Donation,Government Grant,National Budget,Local Budget,School Fund,Alumni Donation,Private Donation,CHED Budget,DepEd Budget,LGU Budget,Congressional Fund,Revolving Fund,Income Generating Project,Tuition Fee,Miscellaneous Fee,Laboratory Fee,Library Fee,Development Fee';
    SET @locations = 'Room 101,Room 102,Room 103,Room 201,Room 202,Room 203,Room 301,Room 302,Room 303,Laboratory 1,Laboratory 2,Laboratory 3,Computer Lab 1,Computer Lab 2,Faculty Room,Admin Office,Library,Gymnasium,Auditorium,Canteen,Clinic,Guidance Office,Registrar Office,Cashier Office,Supply Office,Property Office,Security Office,Maintenance Office,IT Office,HR Office,Finance Office,Presidents Office,Deans Office,Department Office,Conference Room,Meeting Room,Training Room,Audio Visual Room,Music Room,Arts Room,Science Lab,Physics Lab,Chemistry Lab,Biology Lab,Engineering Lab,Nursing Lab,Criminology Lab,HRM Lab,Kitchen Lab,Bakery Lab,Workshop,Stock Room,Storage Room,Archives,Records Room';
    
    -- Start generation
    WHILE i < total_props DO
        -- Select random category
        SET random_num = FLOOR(1 + RAND() * 10);
        CASE random_num
            WHEN 1 THEN 
                SET category_type = 'Office Equipment';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@office_equipment, ',', FLOOR(1 + RAND() * 45)), ',', -1);
            WHEN 2 THEN 
                SET category_type = 'IT Equipment';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@it_equipment, ',', FLOOR(1 + RAND() * 60)), ',', -1);
            WHEN 3 THEN 
                SET category_type = 'Furniture';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@furniture, ',', FLOOR(1 + RAND() * 65)), ',', -1);
            WHEN 4 THEN 
                SET category_type = 'Vehicles';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@vehicles, ',', FLOOR(1 + RAND() * 20)), ',', -1);
            WHEN 5 THEN 
                SET category_type = 'Laboratory Equipment';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@laboratory_equipment, ',', FLOOR(1 + RAND() * 50)), ',', -1);
            WHEN 6 THEN 
                SET category_type = 'Engineering Equipment';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@engineering_equipment, ',', FLOOR(1 + RAND() * 45)), ',', -1);
            WHEN 7 THEN 
                SET category_type = 'Sports Equipment';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@sports_equipment, ',', FLOOR(1 + RAND() * 50)), ',', -1);
            WHEN 8 THEN 
                SET category_type = 'Musical Instruments';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@musical_instruments, ',', FLOOR(1 + RAND() * 40)), ',', -1);
            WHEN 9 THEN 
                SET category_type = 'Medical Equipment';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@medical_equipment, ',', FLOOR(1 + RAND() * 35)), ',', -1);
            ELSE 
                SET category_type = 'Library Equipment';
                SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@library_equipment, ',', FLOOR(1 + RAND() * 45)), ',', -1);
        END CASE;
        
        SET category = category_type;
        SET description = CONCAT('School property: ', item_name, ' - ', category);
        SET unit_measure = SUBSTRING_INDEX(SUBSTRING_INDEX(@units, ',', FLOOR(1 + RAND() * 6)), ',', -1);
        
        -- Generate property number (format: PROP-YYYY-NNNNN)
        SET prop_number = CONCAT('PROP-', YEAR(NOW()), '-', LPAD(i + 1, 5, '0'));
        
        -- Generate serial number (70% have serial numbers)
        IF RAND() < 0.70 THEN
            SET serial_number = CONCAT(
                SUBSTRING('ABCDEFGHIJKLMNOPQRSTUVWXYZ', FLOOR(1 + RAND() * 26), 1),
                SUBSTRING('ABCDEFGHIJKLMNOPQRSTUVWXYZ', FLOOR(1 + RAND() * 26), 1),
                FLOOR(100000 + RAND() * 900000)
            );
        ELSE
            SET serial_number = NULL;
        END IF;
        
        -- Acquisition date (within last 10 years)
        SET acq_date = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 3650) DAY);
        
        -- Acquisition cost based on category
        CASE category_type
            WHEN 'Vehicles' THEN
                SET acq_cost = 500000 + FLOOR(RAND() * 1500000);
            WHEN 'IT Equipment' THEN
                SET acq_cost = 5000 + FLOOR(RAND() * 95000);
            WHEN 'Office Equipment' THEN
                SET acq_cost = 3000 + FLOOR(RAND() * 47000);
            WHEN 'Laboratory Equipment' THEN
                SET acq_cost = 10000 + FLOOR(RAND() * 190000);
            WHEN 'Engineering Equipment' THEN
                SET acq_cost = 15000 + FLOOR(RAND() * 285000);
            WHEN 'Medical Equipment' THEN
                SET acq_cost = 8000 + FLOOR(RAND() * 192000);
            WHEN 'Furniture' THEN
                SET acq_cost = 2000 + FLOOR(RAND() * 28000);
            WHEN 'Sports Equipment' THEN
                SET acq_cost = 1000 + FLOOR(RAND() * 19000);
            WHEN 'Musical Instruments' THEN
                SET acq_cost = 5000 + FLOOR(RAND() * 95000);
            ELSE
                SET acq_cost = 2000 + FLOOR(RAND() * 18000);
        END CASE;
        
        SET total_cost = acq_cost;
        SET source_funds = SUBSTRING_INDEX(SUBSTRING_INDEX(@fund_sources, ',', FLOOR(1 + RAND() * 21)), ',', -1);
        
        -- Assign to user (80% assigned, 20% unassigned)
        IF RAND() < 0.80 THEN
            SET assigned_to = FLOOR(2 + RAND() * (user_count - 1));
        ELSE
            SET assigned_to = NULL;
        END IF;
        
        -- Assign department
        SET dept_id = FLOOR(1 + RAND() * dept_count);
        
        -- Location
        SET location = SUBSTRING_INDEX(SUBSTRING_INDEX(@locations, ',', FLOOR(1 + RAND() * 50)), ',', -1);
        
        -- Condition (85% Good, 10% Needs Repair, 5% Damaged)
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 85 THEN
            SET condition_val = 'Good';
        ELSEIF random_num <= 95 THEN
            SET condition_val = 'Needs Repair';
        ELSE
            SET condition_val = 'Damaged';
        END IF;
        
        -- Status (90% Active, 5% Borrowed, 3% For Disposal, 1% Lost, 1% Cost)
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num <= 90 THEN
            SET status_val = 'Active';
        ELSEIF random_num <= 95 THEN
            SET status_val = 'Borrowed';
        ELSEIF random_num <= 98 THEN
            SET status_val = 'For Disposal';
        ELSEIF random_num = 99 THEN
            SET status_val = 'Lost';
        ELSE
            SET status_val = 'Cost';
        END IF;
        
        -- Insert property
        INSERT INTO properties (
            itemName, category, description, unitOfMeasure, propertyNumber,
            serialNumber, acquisitionDate, acquisitionCost, totalCost,
            sourceOfFunds, assignedTo, departmentId, location, `condition`,
            status, createdAt, updatedAt
        ) VALUES (
            item_name, category, description, unit_measure, prop_number,
            serial_number, acq_date, acq_cost, total_cost,
            source_funds, assigned_to, dept_id, location, condition_val,
            status_val, acq_date, NOW()
        );
        
        SET i = i + 1;
        
        -- Commit in batches
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' properties...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

DELIMITER ;

-- ================================================================
-- Execute
-- ================================================================

SELECT 'Starting property generation...' AS Status;
CALL GenerateProperties();

-- ================================================================
-- Statistics
-- ================================================================

SELECT '=== PROPERTY GENERATION COMPLETE ===' AS Info;

SELECT 
    category AS 'Category',
    COUNT(*) AS 'Count',
    CONCAT('₱', FORMAT(SUM(acquisitionCost), 2)) AS 'Total Value'
FROM properties
GROUP BY category
ORDER BY SUM(acquisitionCost) DESC;

SELECT 
    status AS 'Status',
    COUNT(*) AS 'Count',
    CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM properties), 2), '%') AS 'Percentage'
FROM properties
GROUP BY status;

SELECT 
    `condition` AS 'Condition',
    COUNT(*) AS 'Count'
FROM properties
GROUP BY `condition`;

SELECT COUNT(*) AS 'Total Properties Created' FROM properties;
SELECT CONCAT('₱', FORMAT(SUM(acquisitionCost), 2)) AS 'Total Property Value' FROM properties;

SET FOREIGN_KEY_CHECKS = 1;
SET AUTOCOMMIT = 1;

DROP PROCEDURE IF EXISTS GenerateProperties;

SELECT 'Property generation completed successfully!' AS Status;
