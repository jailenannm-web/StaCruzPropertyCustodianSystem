-- ================================================================
-- GENERATE 10,000+ REALISTIC SUPPLY RECORDS
-- School supplies with proper stock management
-- Database: teamcruzim
-- ================================================================

USE teamcruzim;

SET FOREIGN_KEY_CHECKS = 0;
SET AUTOCOMMIT = 0;

DELETE FROM supplies;
ALTER TABLE supplies AUTO_INCREMENT = 1;

DELIMITER $$

DROP PROCEDURE IF EXISTS GenerateSupplies$$

CREATE PROCEDURE GenerateSupplies()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_supplies INT DEFAULT 10000;
    DECLARE item_name VARCHAR(200);
    DECLARE category VARCHAR(100);
    DECLARE description TEXT;
    DECLARE unit_measure VARCHAR(50);
    DECLARE quantity INT;
    DECLARE date_received DATE;
    DECLARE unit_cost DECIMAL(15,2);
    DECLARE total_cost DECIMAL(15,2);
    DECLARE supplier VARCHAR(200);
    DECLARE source_funds VARCHAR(200);
    DECLARE assigned_to INT;
    DECLARE location VARCHAR(200);
    DECLARE stock_status ENUM('Available','Low Stock','Out of Stock');
    DECLARE random_num INT;
    DECLARE user_count INT;
    
    SELECT COUNT(*) INTO user_count FROM users WHERE status = 'Active';
    
    -- Supply categories
    SET @office_supplies = 'Bond Paper (Short),Bond Paper (Long),Bond Paper (A4),Bond Paper (Legal),Colored Paper,Construction Paper,Cardboard,Manila Paper,Pad Paper,Yellow Pad,Notebook,Spiral Notebook,Record Book,Logbook,Attendance Sheet,Ballpen (Black),Ballpen (Blue),Ballpen (Red),Marker (Permanent Black),Marker (Permanent Blue),Marker (Permanent Red),Marker (Whiteboard Black),Marker (Whiteboard Blue),Marker (Whiteboard Red),Highlighter (Yellow),Highlighter (Green),Highlighter (Pink),Highlighter (Orange),Pencil (#1),Pencil (#2),Mechanical Pencil,Colored Pencil Set,Crayon Set,Oil Pastel Set,Watercolor Set,Eraser,Pencil Sharpener,Ruler (12 inch),Ruler (18 inch),Triangle Set,Protractor,Compass,Scissors,Paper Cutter,Stapler,Staple Wire,Staple Remover,Paper Clips,Binder Clips (Small),Binder Clips (Medium),Binder Clips (Large),Push Pins,Thumb Tacks,Rubber Bands,Paper Fastener,Folder (Plastic),Folder (Expandable),Envelope (Short),Envelope (Long),Envelope (Mailing),Clear Book,Clear Folder,Document Holder,File Organizer,Magazine File,Paper Tray,Desk Organizer,Pen Holder,Tape Dispenser,Scotch Tape,Masking Tape,Double Sided Tape,Packing Tape,Glue Stick,Liquid Glue,Rubber Cement,Correction Tape,Correction Fluid,Calculator,Date Stamp,Stamp Pad,Ink (Black),Ink (Blue),Ink (Red),Sign Pen,Permanent Marker,Whiteboard Eraser,Chalk (White),Chalk (Colored),Index Card,Index Tab,Post-it Notes,Sticky Notes,Carbon Paper,Tracing Paper,Graph Paper,Art Paper,Cartolina,Bristol Board';
    
    SET @cleaning_supplies = 'Detergent Powder,Liquid Detergent,Dishwashing Liquid,Fabric Conditioner,Bleach (Chlorine),Bleach (Color Safe),Floor Wax,Furniture Polish,Glass Cleaner,Toilet Bowl Cleaner,Disinfectant,Air Freshener,Room Deodorizer,Hand Soap (Bar),Hand Soap (Liquid),Alcohol (70% Ethyl),Alcohol (Isopropyl),Hand Sanitizer,Tissue Paper,Toilet Paper,Paper Towel,Napkins,Garbage Bag (Small),Garbage Bag (Medium),Garbage Bag (Large),Trash Bag,Plastic Bag,Sponge,Scrubbing Pad,Steel Wool,Cleaning Cloth,Microfiber Cloth,Mop,Broom,Dustpan,Walis Tingting,Walis Tambo,Feather Duster,Vacuum Cleaner Bag,Bucket,Pail,Basin,Dipper,Rubber Gloves,Apron,Face Mask,Insect Spray,Rat Poison,Cockroach Killer,Mosquito Coil,Air Purifier Filter,Water Filter,Sponge Mop,Squeegee,Window Wiper,Brush (Toilet),Brush (Scrubbing),Soap Dish,Soap Dispenser,Urinal Screen,Deodorizer Block,Drain Cleaner,Rust Remover,Stain Remover,Tile Cleaner,Wood Cleaner,Metal Polish,Chrome Polish,Leather Conditioner';
    
    SET @medical_supplies = 'Gauze Pad,Cotton Ball,Cotton Buds,Bandage,Adhesive Bandage,Elastic Bandage,Surgical Tape,Micropore Tape,Plaster,Band Aid,Alcohol Swab,Betadine,Hydrogen Peroxide,Povidone Iodine,Antiseptic Solution,Antibiotic Ointment,Pain Reliever,Fever Reducer,Cough Syrup,Cold Medicine,Antacid,Anti-diarrheal,Antihistamine,Vitamins (Multivitamin),Vitamin C,Vitamin B Complex,Calcium,Iron Supplement,Oral Rehydration Salt,Medical Gloves (Latex),Medical Gloves (Nitrile),Face Mask (Surgical),Face Mask (N95),Face Shield,Thermometer Cover,Syringe (3ml),Syringe (5ml),Syringe (10ml),Needle (21G),Needle (23G),Needle (25G),IV Catheter,IV Set,IV Fluids,Suture Set,Surgical Blade,Scalpel Handle,Forceps,Scissors (Medical),Stethoscope Cover,BP Cuff,Oximeter Probe,Tongue Depressor,Specimen Container,Urine Cup,Test Tube,Lancet,Blood Collection Tube,Laboratory Reagent,Disinfectant Solution,Sterilization Pouch,Medical Chart,Prescription Pad,Medical Records Folder';
    
    SET @computer_supplies = 'Printer Ink (Black),Printer Ink (Cyan),Printer Ink (Magenta),Printer Ink (Yellow),Toner Cartridge (Black),Toner Cartridge (Colored),Ribbon Cartridge,CD-R,DVD-R,USB Cable,HDMI Cable,VGA Cable,Network Cable (Cat5e),Network Cable (Cat6),RJ45 Connector,Cable Tie,Cable Organizer,Keyboard Protector,Mouse Pad,Screen Protector,Laptop Cooler,Compressed Air,Cleaning Kit,Monitor Cleaner,Keyboard Cleaner,Thermal Paste,Cable Tester,Crimping Tool,LAN Tester,Screw Driver Set,Tool Kit,Anti-static Wrist Strap,Cable Label,Velcro Strap,Power Strip,Extension Cord,Adapter,Battery (AA),Battery (AAA),Battery (9V),Rechargeable Battery,Battery Charger,External HDD Case,USB Hub,Card Reader,Webcam Cover,Privacy Filter,Desk Lamp,LED Light Strip,Cooling Fan,Dust Cover';
    
    SET @laboratory_supplies = 'Beaker (50ml),Beaker (100ml),Beaker (250ml),Beaker (500ml),Beaker (1000ml),Erlenmeyer Flask (125ml),Erlenmeyer Flask (250ml),Erlenmeyer Flask (500ml),Test Tube,Test Tube Rack,Petri Dish,Pipette (1ml),Pipette (5ml),Pipette (10ml),Graduated Cylinder (10ml),Graduated Cylinder (50ml),Graduated Cylinder (100ml),Burette,Funnel,Watch Glass,Stirring Rod,Spatula,Crucible,Evaporating Dish,Florence Flask,Volumetric Flask,Dropper,Rubber Stopper,Cork Stopper,Tubing (Rubber),Tubing (Glass),Clamp,Stand,Ring Stand,Wire Gauze,Alcohol Lamp,Litmus Paper,pH Paper,Filter Paper,Weighing Paper,Parafilm,Marking Pen,Lab Tape,Disposable Gloves,Lab Coat,Safety Goggles,Face Shield,Chemical Bottle,Reagent Bottle,Wash Bottle,Desiccator,Microscope Slide,Cover Slip,Staining Rack,Slide Box,Dissecting Tray,Dissecting Kit,Scalpel Blade,Forceps (Fine),Forceps (Blunt),Needle (Dissecting),Pin (Insect),Collection Net,Specimen Bottle,Preservation Fluid';
    
    SET @kitchen_supplies = 'Cooking Oil,Salt,Sugar,Pepper,Soy Sauce,Vinegar,Fish Sauce,Oyster Sauce,Ketchup,Mayonnaise,Butter,Margarine,Flour,Baking Powder,Baking Soda,Yeast,Cornstarch,Vanilla Extract,Food Color,Seasoning Mix,Bouillon Cube,MSG,Garlic (Powdered),Onion (Powdered),Ginger (Powdered),Coffee,Creamer,Milk (Powdered),Milk (Condensed),Milk (Evaporated),Chocolate Powder,Tea Bags,Juice Powder,Bottled Water,Disposable Cup,Disposable Plate,Disposable Spoon,Disposable Fork,Disposable Knife,Plastic Spoon,Plastic Fork,Straw,Napkin,Table Cloth,Aluminum Foil,Plastic Wrap,Ziplock Bag,Food Container,Take Out Box,Styrofoam Container,Paper Bag,Shopping Bag,Apron,Hairnet,Chef Hat,Kitchen Towel,Oven Mitt,Pot Holder,Cutting Board,Knife Set,Measuring Cup,Measuring Spoon,Mixing Bowl,Colander,Grater,Peeler,Can Opener,Bottle Opener,Ladle,Turner,Tongs,Whisk,Rolling Pin';
    
    SET @sports_supplies = 'Sports Tape,Athletic Tape,Bandage Wrap,Ice Pack,Hot Pack,Pain Relief Spray,Muscle Rub,First Aid Kit,Water Bottle,Sports Drink,Energy Bar,Protein Powder,Towel,Sweatband,Wristband,Headband,Sports Socks,Shoelace,Insole,Knee Pad,Elbow Pad,Shin Guard,Mouth Guard,Protective Cup,Sports Bag,Gym Bag,Equipment Bag,Ball Pump,Needle Adapter,Air Pressure Gauge,Score Sheet,Tally Sheet,Whistle Lanyard,Stopwatch Battery,Timer Battery,Marker Cone,Field Marker,Line Marker,Chalk Line,Measuring Tape,Clipboard,Pen,Paper,ID Holder,Lanyard,Cap,Visor,Sunglasses,Sunscreen,Insect Repellent,Cooling Towel,Hand Grip,Resistance Band,Exercise Mat,Yoga Block,Jump Rope,Speed Ladder,Training Vest,Pinnies,Scrimmage Vest,Training Cone,Agility Pole,Hurdle,Whistle';
    
    SET @art_supplies = 'Drawing Paper,Sketch Pad,Canvas Board,Canvas Cloth,Watercolor Paper,Acrylic Paint,Oil Paint,Watercolor Paint,Poster Paint,Tempera Paint,Paint Brush (Small),Paint Brush (Medium),Paint Brush (Large),Palette,Paint Roller,Paint Tray,Easel,Drawing Pencil (2B),Drawing Pencil (4B),Drawing Pencil (6B),Charcoal Pencil,Charcoal Stick,Pastel (Soft),Pastel (Oil),Colored Pencil,Marker (Art),Paint Pen,Calligraphy Pen,Ink Pen,India Ink,Acrylic Ink,Palette Knife,Modeling Clay,Sculpture Clay,Pottery Clay,Clay Tools,Wire Armature,Plaster of Paris,Modeling Paste,Gesso,Varnish,Fixative Spray,Turpentine,Linseed Oil,Paint Thinner,Craft Glue,Hot Glue Stick,Glue Gun,Craft Knife,Cutting Mat,T-Square,French Curve,Stencil,Template,Tracing Paper,Transfer Paper,Masking Film,Spray Adhesive,Mounting Board,Mat Board,Backing Board,Frame,Glass Cutter,Staple Gun';
    
    -- Combined for random selection
    SET @all_supplies = CONCAT(@office_supplies, ',', @cleaning_supplies, ',', @medical_supplies, ',', @computer_supplies, ',', @laboratory_supplies, ',', @kitchen_supplies, ',', @sports_supplies, ',', @art_supplies);
    
    SET @units = 'piece,box,pack,ream,bundle,roll,bottle,gallon,liter,kilogram,gram,dozen,set,pad,tube,can,sachet,bag';
    
    SET @suppliers = 'National Bookstore,Ace Hardware,SM Supplies,Office Warehouse,Office Plus,Landmark Supplies,Lazada Supplier,Shopee Seller,Abenson,Western Marketing,Wilcon Depot,Handyman,True Value,Robinsons Supplies,Metro Gaisano,Unitop,Savers Appliance Center,Ansons,Rustan''s,All Home,Our Home,MR.DIY,Japan Home Center,Daiso,CDR King,Octagon Computer,PC Hub,PC Corner,PC Express,Dynaquest,Silicon Valley,Tech Depot,Complink,MSI-ECS,Asus Concept Store,Acer Store,Dell Store,HP Store,Lenovo Store,Apple Store,Samsung Store,LG Store,Sony Center,Canon Service Center,Epson Service Center,Brother International,Xerox Philippines,Mercury Drug,Watsons,South Star Drug,Rose Pharmacy,Generika,The Generics Pharmacy,Manson Drug,TGP,Southstar Drug,Shopwise,Puregold,SM Supermarket,Robinsons Supermarket,Savemore,Landmark Supermarket,Walter Mart,Gaisano,Unitop Supermarket,Rustan''s Supermarket,S&R,Landers,Landmark Department Store,Robinson''s Department Store,SM Department Store,Rustan''s Department Store,Metro Department Store,Gaisano Capital,Handyman Do It Best,All Day Supermarket,Alfamart,7-Eleven,Ministop,FamilyMart,Lawson,Circle K,Shell Select,Petron Treats,Caltex Starmart,Total Corner Store,Phoenix Fuel Station,Seaoil,Unioil,Flying V,PTT,Eastern Petroleum,Chevron,Petro Gazz';
    
    SET @fund_sources = 'General Fund,Special Education Fund,Trust Fund,MOOE,Operating Budget,Maintenance Budget,School Fund,Local Budget,National Budget,Government Grant';
    
    SET @locations = 'Main Supply Room,Supply Office,Stock Room,Storage Room,Warehouse,Faculty Room,Department Office,Laboratory Storage,Clinic Storage,Canteen Storage,Kitchen Storage,Maintenance Room,Janitorial Room,IT Stock Room,Library Storage,Records Room,Archives,Property Room,Equipment Room,Tool Room';
    
    -- Generate supplies
    WHILE i < total_supplies DO
        -- Select random item
        SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@all_supplies, ',', FLOOR(1 + RAND() * 500)), ',', -1);
        
        -- Determine category based on item
        IF item_name REGEXP 'Paper|Pen|Pencil|Notebook|Folder|Envelope|Tape|Glue|Scissors|Stapler|Clip|Rubber|Calculator|Stamp|Ink|Marker|Eraser|Ruler' THEN
            SET category = 'Office Supplies';
        ELSEIF item_name REGEXP 'Detergent|Cleaner|Soap|Alcohol|Disinfectant|Tissue|Towel|Mop|Broom|Garbage|Trash|Sponge|Brush|Gloves|Mask|Bleach|Wax|Polish|Deodorizer' THEN
            SET category = 'Cleaning Supplies';
        ELSEIF item_name REGEXP 'Gauze|Cotton|Bandage|Medical|Surgical|Medicine|Drug|Vitamin|Syringe|Needle|Gloves|Thermometer|Stethoscope|Antibiotic|Pain|Fever' THEN
            SET category = 'Medical Supplies';
        ELSEIF item_name REGEXP 'Printer|Toner|Cable|USB|CD|DVD|Mouse|Keyboard|Monitor|Network|Computer|Battery|Adapter' THEN
            SET category = 'Computer Supplies';
        ELSEIF item_name REGEXP 'Beaker|Flask|Test|Petri|Pipette|Cylinder|Microscope|Lab|Chemical|Reagent|Slide|Specimen|Dissecting' THEN
            SET category = 'Laboratory Supplies';
        ELSEIF item_name REGEXP 'Oil|Salt|Sugar|Sauce|Flour|Coffee|Milk|Cup|Plate|Spoon|Fork|Cooking|Kitchen|Food' THEN
            SET category = 'Kitchen Supplies';
        ELSEIF item_name REGEXP 'Sports|Athletic|Ball|Water Bottle|Towel|Tape|Guard|Pad|Whistle|Cone|Mat|Band' THEN
            SET category = 'Sports Supplies';
        ELSE
            SET category = 'Art Supplies';
        END IF;
        
        SET description = CONCAT('School supply item: ', item_name);
        SET unit_measure = SUBSTRING_INDEX(SUBSTRING_INDEX(@units, ',', FLOOR(1 + RAND() * 18)), ',', -1);
        
        -- Quantity based on category
        IF category = 'Office Supplies' THEN
            SET quantity = FLOOR(10 + RAND() * 490);
        ELSEIF category = 'Cleaning Supplies' THEN
            SET quantity = FLOOR(5 + RAND() * 95);
        ELSEIF category = 'Medical Supplies' THEN
            SET quantity = FLOOR(20 + RAND() * 180);
        ELSEIF category = 'Laboratory Supplies' THEN
            SET quantity = FLOOR(10 + RAND() * 90);
        ELSE
            SET quantity = FLOOR(5 + RAND() * 95);
        END IF;
        
        -- Date received (within last 2 years)
        SET date_received = DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 730) DAY);
        
        -- Unit cost
        IF category = 'Office Supplies' THEN
            SET unit_cost = 5 + FLOOR(RAND() * 495);
        ELSEIF category = 'Cleaning Supplies' THEN
            SET unit_cost = 20 + FLOOR(RAND() * 480);
        ELSEIF category = 'Medical Supplies' THEN
            SET unit_cost = 10 + FLOOR(RAND() * 990);
        ELSEIF category = 'Computer Supplies' THEN
            SET unit_cost = 50 + FLOOR(RAND() * 4950);
        ELSEIF category = 'Laboratory Supplies' THEN
            SET unit_cost = 15 + FLOOR(RAND() * 985);
        ELSE
            SET unit_cost = 10 + FLOOR(RAND() * 490);
        END IF;
        
        SET total_cost = unit_cost * quantity;
        SET supplier = SUBSTRING_INDEX(SUBSTRING_INDEX(@suppliers, ',', FLOOR(1 + RAND() * 100)), ',', -1);
        SET source_funds = SUBSTRING_INDEX(SUBSTRING_INDEX(@fund_sources, ',', FLOOR(1 + RAND() * 10)), ',', -1);
        
        -- Assigned to (50% assigned)
        IF RAND() < 0.50 THEN
            SET assigned_to = FLOOR(2 + RAND() * (user_count - 1));
        ELSE
            SET assigned_to = NULL;
        END IF;
        
        SET location = SUBSTRING_INDEX(SUBSTRING_INDEX(@locations, ',', FLOOR(1 + RAND() * 20)), ',', -1);
        
        -- Stock status based on quantity
        IF quantity > 50 THEN
            SET stock_status = 'Available';
        ELSEIF quantity > 10 THEN
            SET stock_status = 'Low Stock';
        ELSE
            SET stock_status = 'Out of Stock';
        END IF;
        
        INSERT INTO supplies (
            itemName, category, description, unitOfMeasure, quantity,
            dateReceived, unitCost, totalCost, supplier, sourceOfFunds,
            assignedTo, location, stockStatus, createdAt, updatedAt
        ) VALUES (
            item_name, category, description, unit_measure, quantity,
            date_received, unit_cost, total_cost, supplier, source_funds,
            assigned_to, location, stock_status, date_received, NOW()
        );
        
        SET i = i + 1;
        
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' supplies...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

DELIMITER ;

SELECT 'Starting supply generation...' AS Status;
CALL GenerateSupplies();

SELECT '=== SUPPLY GENERATION COMPLETE ===' AS Info;

SELECT 
    category AS 'Category',
    COUNT(*) AS 'Count',
    SUM(quantity) AS 'Total Quantity',
    CONCAT('₱', FORMAT(SUM(totalCost), 2)) AS 'Total Value'
FROM supplies
GROUP BY category
ORDER BY SUM(totalCost) DESC;

SELECT 
    stockStatus AS 'Stock Status',
    COUNT(*) AS 'Count'
FROM supplies
GROUP BY stockStatus;

SELECT COUNT(*) AS 'Total Supplies Created' FROM supplies;
SELECT CONCAT('₱', FORMAT(SUM(totalCost), 2)) AS 'Total Supply Value' FROM supplies;

SET FOREIGN_KEY_CHECKS = 1;
SET AUTOCOMMIT = 1;

DROP PROCEDURE IF EXISTS GenerateSupplies;

SELECT 'Supply generation completed successfully!' AS Status;
