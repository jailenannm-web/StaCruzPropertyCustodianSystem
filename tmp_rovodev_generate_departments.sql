-- ================================================================
-- GENERATE 100+ UNIQUE SCHOOL DEPARTMENTS
-- Realistic Philippine school departments
-- ================================================================

USE teamcruzim;

-- Clear existing departments (except defaults if needed)
DELETE FROM departments WHERE departmentId > 5;

-- Reset auto increment
ALTER TABLE departments AUTO_INCREMENT = 6;

-- ================================================================
-- GENERATE 10,000+ UNIQUE DEPARTMENTS
-- Using stored procedure for efficient generation
-- ================================================================

DELIMITER $$

DROP PROCEDURE IF EXISTS GenerateDepartments$$

CREATE PROCEDURE GenerateDepartments()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_depts INT DEFAULT 10000;
    DECLARE dept_name VARCHAR(100);
    DECLARE head_name VARCHAR(100);
    DECLARE dept_email VARCHAR(100);
    DECLARE contact VARCHAR(50);
    DECLARE location VARCHAR(200);
    DECLARE building VARCHAR(100);
    DECLARE floor VARCHAR(20);
    DECLARE short_name VARCHAR(20);
    DECLARE office_code VARCHAR(20);
    DECLARE description TEXT;
    DECLARE random_num INT;
    
    -- Department types
    SET @dept_types = 'Department,Office,Division,Section,Unit,Center,Institute,Laboratory,Facility,Services,Bureau,Agency,Committee,Council,Board';
    
    -- Department areas
    SET @dept_areas = 'Academic Affairs,Student Affairs,Administrative Services,Financial Management,Human Resources,Information Technology,Library Services,Research and Development,Extension Services,Quality Assurance,Planning and Development,Property Management,Supply Management,Procurement,Budget,Accounting,Cashier,Audit,Legal,Records,Archives,Communications,Public Relations,Marketing,Alumni Relations,International Affairs,Security,Maintenance,Janitorial,Transportation,Health Services,Medical,Dental,Guidance,Counseling,Testing,Admissions,Registrar,Scholarship,Sports,Cultural Affairs,Gender Development,Environmental Management,Disaster Risk,Community Extension,Business Incubation,Intellectual Property,Data Privacy';
    
    -- Academic disciplines
    SET @disciplines = 'Engineering,Computer Science,Information Technology,Business Administration,Accountancy,Marketing,Management,Economics,Hospitality Management,Tourism,Education,English,Filipino,Mathematics,Science,Physics,Chemistry,Biology,Social Studies,History,Political Science,Psychology,Sociology,Communication,Journalism,Fine Arts,Music,Theater Arts,Physical Education,Health Sciences,Nursing,Medical Technology,Pharmacy,Dentistry,Medicine,Criminology,Law,Architecture,Agriculture,Fisheries,Forestry,Veterinary Medicine,Environmental Science,Industrial Technology,Electronics,Electrical,Mechanical,Civil,Chemical,Maritime,Aviation';
    
    -- Specializations
    SET @specializations = 'General,Applied,Clinical,Industrial,Educational,Developmental,Social,Experimental,Cognitive,Forensic,Digital,Network,Software,Hardware,Database,Web,Mobile,Cloud,Cyber Security,Data Analytics,Artificial Intelligence,Machine Learning,Financial,Managerial,Cost,Tax,Government,Public,Private,Corporate,Strategic,Operations,Project,Risk,Quality,Human Resource,Organizational,International,Domestic,Regional,Local,Global,Basic,Advanced,Professional,Technical,Vocational';
    
    -- Building names
    SET @buildings = 'Main Building,Administration Building,Academic Building,Science Building,Engineering Building,IT Building,Business Building,Education Building,Medical Building,Library Building,Gymnasium,Auditorium,Laboratory Building,Workshop Building,Research Center,Extension Building,Student Center,Faculty Building,Graduate School,Innovation Center,Technology Center,Training Center,Conference Center,Multi-Purpose Building,Sports Complex';
    
    -- First names
    SET @first_names = 'Juan,Maria,Jose,Ana,Pedro,Rosa,Luis,Carmen,Carlos,Elena,Ramon,Sofia,Fernando,Patricia,Antonio,Isabel,Manuel,Gloria,Roberto,Angela,Ricardo,Cristina,Eduardo,Beatriz,Francisco,Diana,Alfredo,Laura,Jorge,Cecilia,Alberto,Monica,Diego,Angelica,Gabriel,Marissa,Victor,Dolores,Rafael,Esperanza,Enrique,Felicidad,Sergio,Josephine,Alejandro,Trinidad,Marcos,Rosario,Leonardo,Lourdes,Benjamin,Estrella,Miguel,Veronica,Rodrigo,Teresita,Ernesto,Amelita,Gregorio,Erlinda,Domingo,Corazon,Vicente,Virginia,Nestor,Milagros,Florencio,Remedios';
    
    -- Last names
    SET @last_names = 'Santos,Reyes,Cruz,Garcia,Ramos,Flores,Mendoza,Torres,Gonzales,Rivera,Lopez,Martinez,Rodriguez,Hernandez,Perez,Sanchez,Ramirez,Gutierrez,Diaz,Fernandez,Alvarez,Castillo,Jimenez,Romero,Morales,Vargas,Castro,Ortiz,Salazar,Navarro,Aguilar,Rojas,Valdez,Vasquez,Suarez,Santiago,Moreno,Ponce,Mercado,Silva,Cortez,Serrano,Campos,Acosta,Bautista,Villanueva,Valencia,Herrera,Luna,Medina,Dominguez,Guerrero,Espinosa,Soto,Contreras';
    
    -- Titles
    SET @titles = 'Dr.,Prof.,Engr.,Atty.,CPA,Ms.,Mr.,Mrs.';
    
    WHILE i < total_depts DO
        -- Generate unique department name with guaranteed uniqueness using index
        SET random_num = FLOOR(1 + RAND() * 15);
        SET dept_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@dept_types, ',', random_num), ',', -1);
        
        -- Add area/discipline
        IF i < 3000 THEN
            -- Academic departments
            SET dept_name = CONCAT(
                SUBSTRING_INDEX(SUBSTRING_INDEX(@disciplines, ',', FLOOR(1 + RAND() * 50)), ',', -1),
                ' ',
                dept_name
            );
        ELSEIF i < 6000 THEN
            -- Administrative departments
            SET dept_name = CONCAT(
                SUBSTRING_INDEX(SUBSTRING_INDEX(@dept_areas, ',', FLOOR(1 + RAND() * 50)), ',', -1),
                ' ',
                dept_name
            );
        ELSE
            -- Specialized departments
            SET dept_name = CONCAT(
                SUBSTRING_INDEX(SUBSTRING_INDEX(@specializations, ',', FLOOR(1 + RAND() * 50)), ',', -1),
                ' ',
                SUBSTRING_INDEX(SUBSTRING_INDEX(@disciplines, ',', FLOOR(1 + RAND() * 50)), ',', -1),
                ' ',
                dept_name
            );
        END IF;
        
        -- ALWAYS add suffix with index number to GUARANTEE uniqueness
        SET dept_name = CONCAT(dept_name, ' - Unit ', LPAD(i + 1, 5, '0'));
        
        -- Generate head name
        SET head_name = CONCAT(
            SUBSTRING_INDEX(SUBSTRING_INDEX(@titles, ',', FLOOR(1 + RAND() * 8)), ',', -1),
            ' ',
            SUBSTRING_INDEX(SUBSTRING_INDEX(@first_names, ',', FLOOR(1 + RAND() * 60)), ',', -1),
            ' ',
            SUBSTRING_INDEX(SUBSTRING_INDEX(@last_names, ',', FLOOR(1 + RAND() * 55)), ',', -1)
        );
        
        -- Generate email
        SET dept_email = CONCAT(
            LOWER(REPLACE(SUBSTRING_INDEX(dept_name, ' ', 2), ' ', '')),
            i,
            '@school.edu.ph'
        );
        
        -- Generate contact
        SET contact = CONCAT('09', FLOOR(10 + RAND() * 90), FLOOR(1000000 + RAND() * 9000000));
        
        -- Generate location
        SET building = SUBSTRING_INDEX(SUBSTRING_INDEX(@buildings, ',', FLOOR(1 + RAND() * 25)), ',', -1);
        SET floor = CONCAT(FLOOR(1 + RAND() * 5), 'th Floor');
        SET location = CONCAT(building, ', ', floor);
        
        -- Generate codes
        SET short_name = CONCAT(UPPER(LEFT(REPLACE(dept_name, ' ', ''), 4)), LPAD(i + 1, 2, '0'));
        SET office_code = CONCAT('DEPT-', LPAD(i + 6, 5, '0'));
        
        -- Description
        SET description = CONCAT('Handles ', LOWER(SUBSTRING_INDEX(dept_name, ' - ', 1)), ' operations and services');
        
        -- Insert department (with error handling for duplicates)
        INSERT INTO departments (
            departmentName, headOfDepartment, email, contactNumber,
            location, building, floorNumber, shortName, officeCode,
            description, status, createdAt, updatedAt
        ) VALUES (
            dept_name, head_name, dept_email, contact,
            location, building, floor, short_name, office_code,
            description, 'Active', NOW(), NOW()
        );
        
        SET i = i + 1;
        
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' departments...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

DELIMITER ;

-- Execute procedure
SELECT 'Starting department generation...' AS Status;
CALL GenerateDepartments();

-- Cleanup
DROP PROCEDURE IF EXISTS GenerateDepartments;

-- Base departments (keep existing insert for first 100)
INSERT INTO departments (departmentName, headOfDepartment, email, contactNumber, location, building, floorNumber, shortName, officeCode, description, status) VALUES
-- College Departments
('College of Engineering', 'Dr. Ricardo Santos', 'engineering@school.edu.ph', '09171234567', 'Engineering Building', 'Building E', '2nd Floor', 'COE', 'ENG-001', 'Engineering programs and laboratories', 'Active'),
('College of Arts and Sciences', 'Dr. Maria Elena Cruz', 'cas@school.edu.ph', '09171234568', 'CAS Building', 'Building A', '3rd Floor', 'CAS', 'CAS-001', 'Liberal arts and sciences programs', 'Active'),
('College of Business Administration', 'Dr. Antonio Reyes', 'business@school.edu.ph', '09171234569', 'Business Building', 'Building B', '2nd Floor', 'CBA', 'BUS-001', 'Business and management programs', 'Active'),
('College of Education', 'Dr. Teresa Ramos', 'education@school.edu.ph', '09171234570', 'Education Building', 'Building D', '1st Floor', 'COED', 'EDU-001', 'Teacher education programs', 'Active'),
('College of Computer Studies', 'Dr. Benjamin Aquino', 'computerscience@school.edu.ph', '09171234571', 'IT Building', 'Building F', '3rd Floor', 'CCS', 'CCS-001', 'Computer science and IT programs', 'Active'),
('College of Nursing', 'Dr. Gloria Mendoza', 'nursing@school.edu.ph', '09171234572', 'Medical Building', 'Building M', '2nd Floor', 'CON', 'NUR-001', 'Nursing education and training', 'Active'),
('College of Criminology', 'Dr. Roberto Garcia', 'criminology@school.edu.ph', '09171234573', 'Criminology Building', 'Building C', '1st Floor', 'CCRIM', 'CRIM-001', 'Criminal justice education', 'Active'),
('College of Hospitality Management', 'Dr. Carmen Dela Cruz', 'hospitality@school.edu.ph', '09171234574', 'HM Building', 'Building H', '2nd Floor', 'CHM', 'HM-001', 'Hotel and restaurant management', 'Active'),

-- Academic Support Departments
('Library Services', 'Prof. Elena Rodriguez', 'library@school.edu.ph', '09171234575', 'Main Library', 'Building L', 'All Floors', 'LIB', 'LIB-001', 'University library and resource center', 'Active'),
('Registrar Office', 'Ms. Patricia Santos', 'registrar@school.edu.ph', '09171234576', 'Administration Building', 'Building A', '1st Floor', 'REG', 'REG-001', 'Student records and enrollment', 'Active'),
('Guidance and Counseling', 'Dr. Michael Torres', 'guidance@school.edu.ph', '09171234577', 'Student Services', 'Building S', '2nd Floor', 'GCS', 'GCS-001', 'Student counseling services', 'Active'),
('Research and Development', 'Dr. Angelica Ramirez', 'research@school.edu.ph', '09171234578', 'Research Center', 'Building R', '3rd Floor', 'RND', 'RND-001', 'Research programs and grants', 'Active'),

-- Administrative Departments
('Office of the President', 'Dr. Eduardo Martinez', 'president@school.edu.ph', '09171234579', 'Administration Building', 'Building A', '5th Floor', 'PRES', 'PRES-001', 'Office of the University President', 'Active'),
('Vice President for Academic Affairs', 'Dr. Sofia Villanueva', 'vpaa@school.edu.ph', '09171234580', 'Administration Building', 'Building A', '4th Floor', 'VPAA', 'VPAA-001', 'Academic affairs management', 'Active'),
('Vice President for Administration', 'Atty. Manuel Francisco', 'vpadmin@school.edu.ph', '09171234581', 'Administration Building', 'Building A', '4th Floor', 'VPA', 'VPA-001', 'Administrative affairs', 'Active'),
('Human Resource Management', 'Ms. Rosario Bautista', 'hrm@school.edu.ph', '09171234582', 'HR Office', 'Building A', '2nd Floor', 'HRM', 'HRM-001', 'Employee recruitment and management', 'Active'),
('Finance and Accounting', 'CPA Juan Cortez', 'finance@school.edu.ph', '09171234583', 'Finance Building', 'Building F', '1st Floor', 'FIN', 'FIN-001', 'Financial management and accounting', 'Active'),
('Budget Office', 'Ms. Cristina Lopez', 'budget@school.edu.ph', '09171234584', 'Finance Building', 'Building F', '1st Floor', 'BUD', 'BUD-001', 'Budget planning and monitoring', 'Active'),
('Procurement Office', 'Mr. Fernando Castillo', 'procurement@school.edu.ph', '09171234585', 'Supply Building', 'Building P', '1st Floor', 'PROC', 'PROC-001', 'Purchasing and procurement', 'Active'),
('Property Custodian Office', 'Engr. Romeo Santiago', 'property@school.edu.ph', '09171234586', 'Property Office', 'Building P', '2nd Floor', 'PCO', 'PCO-001', 'Property management and custody', 'Active'),

-- Facilities and Services
('General Services Office', 'Mr. Alberto Navarro', 'gso@school.edu.ph', '09171234587', 'GSO Building', 'Building G', '1st Floor', 'GSO', 'GSO-001', 'General services and maintenance', 'Active'),
('Buildings and Grounds', 'Engr. Luis Hernandez', 'buildings@school.edu.ph', '09171234588', 'Maintenance Office', 'Building M', '1st Floor', 'BG', 'BG-001', 'Campus buildings and grounds maintenance', 'Active'),
('Security Services', 'Mr. Oscar Dizon', 'security@school.edu.ph', '09171234589', 'Security Office', 'Gate 1', 'Ground Floor', 'SEC', 'SEC-001', 'Campus security and safety', 'Active'),
('Health Services', 'Dr. Lourdes Mercado', 'clinic@school.edu.ph', '09171234590', 'Medical Clinic', 'Building C', '1st Floor', 'HEALTH', 'HLTH-001', 'Medical and dental services', 'Active'),
('Information Technology Services', 'Engr. Carlos Aguilar', 'its@school.edu.ph', '09171234591', 'IT Center', 'Building F', '4th Floor', 'ITS', 'ITS-001', 'IT infrastructure and support', 'Active'),

-- Student Services
('Student Affairs Office', 'Ms. Diana Ramos', 'studentaffairs@school.edu.ph', '09171234592', 'Student Center', 'Building S', '1st Floor', 'SAO', 'SAO-001', 'Student activities and welfare', 'Active'),
('Scholarship Office', 'Ms. Beatriz Ocampo', 'scholarship@school.edu.ph', '09171234593', 'Student Services', 'Building S', '2nd Floor', 'SCHOL', 'SCH-001', 'Scholarship programs', 'Active'),
('Sports Development Office', 'Coach Martin Ponce', 'sports@school.edu.ph', '09171234594', 'Gymnasium', 'Sports Complex', 'Ground Floor', 'SDO', 'SPT-001', 'Athletics and sports programs', 'Active'),
('Cultural Affairs Office', 'Prof. Isabela Cruz', 'culture@school.edu.ph', '09171234595', 'Cultural Center', 'Building K', '2nd Floor', 'CAO', 'CULT-001', 'Cultural programs and events', 'Active'),

-- Specialized Units
('Quality Assurance Office', 'Dr. Virginia Salazar', 'qa@school.edu.ph', '09171234596', 'QA Office', 'Building A', '3rd Floor', 'QAO', 'QA-001', 'Quality assurance and accreditation', 'Active'),
('International Affairs Office', 'Ms. Amanda Tan', 'international@school.edu.ph', '09171234597', 'International Office', 'Building I', '2nd Floor', 'IAO', 'INT-001', 'International programs and linkages', 'Active'),
('Alumni Affairs Office', 'Mr. Rafael Jimenez', 'alumni@school.edu.ph', '09171234598', 'Alumni Center', 'Building A', '2nd Floor', 'ALUM', 'ALM-001', 'Alumni relations and engagement', 'Active'),
('Public Relations Office', 'Ms. Melissa Valdez', 'pr@school.edu.ph', '09171234599', 'PR Office', 'Building A', '3rd Floor', 'PRO', 'PR-001', 'Public relations and communications', 'Active'),
('Legal Office', 'Atty. Ricardo Fernandez', 'legal@school.edu.ph', '09171234600', 'Legal Office', 'Building A', '4th Floor', 'LEGAL', 'LEG-001', 'Legal services and compliance', 'Active'),

-- Additional Academic Departments (expand to 100+)
('Department of Civil Engineering', 'Engr. Pedro Manalo', 'civileng@school.edu.ph', '09171234601', 'Engineering Building', 'Building E', '2nd Floor', 'CE', 'CE-001', 'Civil engineering programs', 'Active'),
('Department of Electrical Engineering', 'Engr. Thomas Rivera', 'electricaleng@school.edu.ph', '09171234602', 'Engineering Building', 'Building E', '3rd Floor', 'EE', 'EE-001', 'Electrical engineering programs', 'Active'),
('Department of Mechanical Engineering', 'Engr. George Pascual', 'mechanicaleng@school.edu.ph', '09171234603', 'Engineering Building', 'Building E', '2nd Floor', 'ME', 'ME-001', 'Mechanical engineering programs', 'Active'),
('Department of Architecture', 'Ar. Monica Santiago', 'architecture@school.edu.ph', '09171234604', 'Architecture Building', 'Building AR', '3rd Floor', 'ARCH', 'ARC-001', 'Architecture and design programs', 'Active'),
('Department of Mathematics', 'Dr. Emmanuel Duran', 'mathematics@school.edu.ph', '09171234605', 'CAS Building', 'Building A', '3rd Floor', 'MATH', 'MTH-001', 'Mathematics department', 'Active'),
('Department of Physics', 'Dr. Leonardo Gutierrez', 'physics@school.edu.ph', '09171234606', 'Science Building', 'Building SC', '4th Floor', 'PHYS', 'PHY-001', 'Physics department', 'Active'),
('Department of Chemistry', 'Dr. Clarita Morales', 'chemistry@school.edu.ph', '09171234607', 'Science Building', 'Building SC', '3rd Floor', 'CHEM', 'CHE-001', 'Chemistry department and laboratories', 'Active'),
('Department of Biology', 'Dr. Ramon Suarez', 'biology@school.edu.ph', '09171234608', 'Science Building', 'Building SC', '2nd Floor', 'BIO', 'BIO-001', 'Biology and life sciences', 'Active'),
('Department of English', 'Prof. Laura Perez', 'english@school.edu.ph', '09171234609', 'CAS Building', 'Building A', '2nd Floor', 'ENG', 'EGL-001', 'English and literature studies', 'Active'),
('Department of Filipino', 'Prof. Mariano Gonzales', 'filipino@school.edu.ph', '09171234610', 'CAS Building', 'Building A', '2nd Floor', 'FIL', 'FIL-001', 'Filipino language and literature', 'Active'),
('Department of Social Sciences', 'Dr. Estrella Medina', 'socialsciences@school.edu.ph', '09171234611', 'CAS Building', 'Building A', '3rd Floor', 'SOCSCI', 'SOC-001', 'Sociology and social sciences', 'Active'),
('Department of Psychology', 'Dr. Carmela Flores', 'psychology@school.edu.ph', '09171234612', 'Psychology Building', 'Building PS', '2nd Floor', 'PSYCH', 'PSY-001', 'Psychology programs', 'Active'),
('Department of Accountancy', 'CPA Roberto Luna', 'accountancy@school.edu.ph', '09171234613', 'Business Building', 'Building B', '3rd Floor', 'ACCT', 'ACC-001', 'Accountancy programs', 'Active'),
('Department of Marketing', 'Prof. Veronica Castro', 'marketing@school.edu.ph', '09171234614', 'Business Building', 'Building B', '2nd Floor', 'MKT', 'MKT-001', 'Marketing management programs', 'Active'),
('Department of Management', 'Dr. Alfredo Valdez', 'management@school.edu.ph', '09171234615', 'Business Building', 'Building B', '3rd Floor', 'MGT', 'MGT-001', 'Management programs', 'Active'),
('Department of Economics', 'Dr. Gabriel Serrano', 'economics@school.edu.ph', '09171234616', 'Business Building', 'Building B', '4th Floor', 'ECON', 'ECO-001', 'Economics programs', 'Active'),
('Department of Information Technology', 'Prof. Jessica Navarro', 'it@school.edu.ph', '09171234617', 'IT Building', 'Building F', '2nd Floor', 'IT', 'IT-001', 'Information technology programs', 'Active'),
('Department of Computer Science', 'Dr. Adrian Reyes', 'compsci@school.edu.ph', '09171234618', 'IT Building', 'Building F', '3rd Floor', 'CS', 'CS-001', 'Computer science programs', 'Active'),
('Department of Physical Education', 'Prof. Rodrigo Salcedo', 'physed@school.edu.ph', '09171234619', 'Gymnasium', 'Sports Complex', '2nd Floor', 'PE', 'PE-001', 'Physical education and sports', 'Active'),
('Department of Tourism Management', 'Prof. Shirley Alvarez', 'tourism@school.edu.ph', '09171234620', 'HM Building', 'Building H', '3rd Floor', 'TM', 'TM-001', 'Tourism management programs', 'Active'),
('Technical Vocational Education', 'Engr. Vicente Molina', 'teched@school.edu.ph', '09171234621', 'TechVoc Building', 'Building TV', '1st Floor', 'TVE', 'TVE-001', 'Technical and vocational programs', 'Active'),
('Graduate School', 'Dr. Esperanza Trinidad', 'gradschool@school.edu.ph', '09171234622', 'Graduate Building', 'Building GS', '3rd Floor', 'GRAD', 'GRD-001', 'Graduate and post-graduate programs', 'Active'),
('Center for Continuing Education', 'Prof. Norma Valencia', 'cce@school.edu.ph', '09171234623', 'Extension Building', 'Building EX', '2nd Floor', 'CCE', 'CCE-001', 'Continuing education and training', 'Active'),
('Office of Student Publications', 'Prof. Cecilia Ramos', 'publications@school.edu.ph', '09171234624', 'Media Center', 'Building MC', '2nd Floor', 'OSP', 'PUB-001', 'Student publications and media', 'Active'),
('Audio Visual Center', 'Mr. Gregorio Santos', 'avc@school.edu.ph', '09171234625', 'Media Center', 'Building MC', '1st Floor', 'AVC', 'AVC-001', 'Audio visual equipment and services', 'Active'),
('Science Laboratory', 'Prof. Lydia Cruz', 'scilab@school.edu.ph', '09171234626', 'Science Building', 'Building SC', '1st Floor', 'SCILAB', 'LAB-001', 'Science laboratory facilities', 'Active'),
('Computer Laboratory', 'Mr. Ernesto Garcia', 'complab@school.edu.ph', '09171234627', 'IT Building', 'Building F', '1st Floor', 'COMPLAB', 'LAB-002', 'Computer laboratory facilities', 'Active'),
('Engineering Laboratory', 'Engr. Dolores Reyes', 'englab@school.edu.ph', '09171234628', 'Engineering Building', 'Building E', '1st Floor', 'ENGLAB', 'LAB-003', 'Engineering laboratory facilities', 'Active'),
('Nursing Laboratory', 'Ms. Erlinda Mendoza', 'nurslab@school.edu.ph', '09171234629', 'Medical Building', 'Building M', '1st Floor', 'NURLAB', 'LAB-004', 'Nursing skills laboratory', 'Active'),
('Language Laboratory', 'Prof. Florentino Torres', 'langlab@school.edu.ph', '09171234630', 'CAS Building', 'Building A', '1st Floor', 'LANGLAB', 'LAB-005', 'Language learning laboratory', 'Active'),
('Testing and Evaluation Center', 'Dr. Amelita Campos', 'testing@school.edu.ph', '09171234631', 'Administration Building', 'Building A', '2nd Floor', 'TEC', 'TEC-001', 'Testing and assessment services', 'Active'),
('Admissions Office', 'Ms. Felicidad Ramos', 'admissions@school.edu.ph', '09171234632', 'Administration Building', 'Building A', '1st Floor', 'ADM', 'ADM-001', 'Student admissions and recruitment', 'Active'),
('Cashier Office', 'Ms. Remedios Santos', 'cashier@school.edu.ph', '09171234633', 'Finance Building', 'Building F', '1st Floor', 'CASH', 'CSH-001', 'Payment collection and receipts', 'Active'),
('Supply Office', 'Mr. Domingo Cruz', 'supply@school.edu.ph', '09171234634', 'Supply Building', 'Building P', '1st Floor', 'SUPPLY', 'SUP-001', 'Supply management and distribution', 'Active'),
('Printing Services', 'Mr. Artemio Fernandez', 'printing@school.edu.ph', '09171234635', 'Printing Office', 'Building PR', '1st Floor', 'PRINT', 'PRT-001', 'Printing and reproduction services', 'Active'),
('Canteen and Cafeteria', 'Ms. Josephine Villegas', 'canteen@school.edu.ph', '09171234636', 'Canteen Building', 'Building CT', 'Ground Floor', 'CANT', 'CAN-001', 'Food services and cafeteria', 'Active'),
('Bookstore', 'Mr. Bonifacio Aguilar', 'bookstore@school.edu.ph', '09171234637', 'Bookstore', 'Building BS', '1st Floor', 'BOOK', 'BKS-001', 'University bookstore', 'Active'),
('Transportation Office', 'Mr. Renato Paguio', 'transport@school.edu.ph', '09171234638', 'Motor Pool', 'Building MP', 'Ground Floor', 'TRANS', 'TRN-001', 'Transportation and vehicle management', 'Active'),
('Environmental Management Office', 'Engr. Cecilio Ramos', 'environment@school.edu.ph', '09171234639', 'EMO Office', 'Building G', '2nd Floor', 'EMO', 'ENV-001', 'Environmental management and compliance', 'Active'),
('Disaster Risk Reduction Office', 'Mr. Federico Diaz', 'drrm@school.edu.ph', '09171234640', 'DRRM Office', 'Building G', '1st Floor', 'DRRMO', 'DRM-001', 'Disaster preparedness and response', 'Active'),
('Gender and Development Office', 'Ms. Teresita Pascual', 'gad@school.edu.ph', '09171234641', 'GAD Office', 'Building S', '3rd Floor', 'GAD', 'GAD-001', 'Gender and development programs', 'Active'),
('Community Extension Services', 'Prof. Nestor Villanueva', 'extension@school.edu.ph', '09171234642', 'Extension Building', 'Building EX', '1st Floor', 'CES', 'EXT-001', 'Community outreach programs', 'Active'),
('Technology Business Incubator', 'Engr. Marissa Cruz', 'tbi@school.edu.ph', '09171234643', 'Innovation Center', 'Building IN', '2nd Floor', 'TBI', 'TBI-001', 'Business incubation and startups', 'Active'),
('Intellectual Property Office', 'Atty. Rosalinda Santos', 'ipo@school.edu.ph', '09171234644', 'Research Center', 'Building R', '2nd Floor', 'IPO', 'IPO-001', 'Intellectual property management', 'Active'),
('Data Privacy Office', 'Ms. Angelita Mercado', 'privacy@school.edu.ph', '09171234645', 'IT Center', 'Building F', '4th Floor', 'DPO', 'DPO-001', 'Data privacy and protection', 'Active'),
('Internal Audit Office', 'CPA Florencio Ramirez', 'audit@school.edu.ph', '09171234646', 'Audit Office', 'Building A', '4th Floor', 'IAO', 'AUD-001', 'Internal audit and compliance', 'Active'),
('Planning and Development Office', 'Engr. Salvador Torres', 'planning@school.edu.ph', '09171234647', 'Planning Office', 'Building A', '3rd Floor', 'PDO', 'PLN-001', 'Strategic planning and development', 'Active'),
('Records Management Office', 'Ms. Corazon Lopez', 'records@school.edu.ph', '09171234648', 'Records Office', 'Building A', '1st Floor', 'RMO', 'REC-001', 'Records management and archives', 'Active'),
('Medical and Dental Clinic', 'Dr. Alfonso Gutierrez', 'medical@school.edu.ph', '09171234649', 'Medical Clinic', 'Building C', '1st Floor', 'MDC', 'MED-001', 'Medical and dental services', 'Active'),
('Psychological Services', 'Dr. Milagros Santos', 'psych.services@school.edu.ph', '09171234650', 'Counseling Center', 'Building S', '3rd Floor', 'PSS', 'PSS-001', 'Psychological assessment and therapy', 'Active'),
('Career Development Office', 'Ms. Aida Manalo', 'careers@school.edu.ph', '09171234651', 'Career Center', 'Building S', '2nd Floor', 'CDO', 'CAR-001', 'Career guidance and placement', 'Active'),
('Placement and Job Assistance', 'Mr. Danilo Cruz', 'placement@school.edu.ph', '09171234652', 'Career Center', 'Building S', '2nd Floor', 'PJA', 'PLM-001', 'Job placement and internships', 'Active'),
('Student Discipline Office', 'Atty. Leonor Rivera', 'discipline@school.edu.ph', '09171234653', 'Student Services', 'Building S', '1st Floor', 'SDO', 'DIS-001', 'Student discipline and conduct', 'Active'),
('Student Housing Office', 'Ms. Trinidad Valdez', 'housing@school.edu.ph', '09171234654', 'Dormitory', 'Building DM', '1st Floor', 'SHO', 'HSG-001', 'Student dormitory and housing', 'Active'),
('Food Services Office', 'Mr. Jaime Fernandez', 'foodservices@school.edu.ph', '09171234655', 'Canteen Building', 'Building CT', '1st Floor', 'FSO', 'FSV-001', 'Food service management', 'Active'),
('Utility Services', 'Engr. Pablo Garcia', 'utilities@school.edu.ph', '09171234656', 'Utility Building', 'Building UT', 'Ground Floor', 'UTIL', 'UTL-001', 'Utilities and infrastructure', 'Active'),
('Janitorial Services', 'Mr. Rodrigo Santos', 'janitorial@school.edu.ph', '09171234657', 'GSO Building', 'Building G', '1st Floor', 'JAN', 'JAN-001', 'Cleaning and janitorial services', 'Active'),
('Landscaping and Grounds', 'Mr. Antonio Cruz', 'landscape@school.edu.ph', '09171234658', 'Grounds Office', 'Building G', 'Ground Floor', 'LAND', 'LND-001', 'Landscaping and grounds keeping', 'Active'),
('Electrical Services', 'Engr. Mario Reyes', 'electrical@school.edu.ph', '09171234659', 'Maintenance Office', 'Building M', '1st Floor', 'ELEC', 'ELC-001', 'Electrical maintenance and repairs', 'Active'),
('Plumbing Services', 'Mr. Cesar Ramos', 'plumbing@school.edu.ph', '09171234660', 'Maintenance Office', 'Building M', '1st Floor', 'PLUMB', 'PLB-001', 'Plumbing maintenance and repairs', 'Active'),
('Carpentry Services', 'Mr. Eduardo Torres', 'carpentry@school.edu.ph', '09171234661', 'Maintenance Office', 'Building M', '1st Floor', 'CARP', 'CRP-001', 'Carpentry and woodwork services', 'Active'),
('Airconditioning Services', 'Engr. Noel Mendoza', 'aircon@school.edu.ph', '09171234662', 'Maintenance Office', 'Building M', '1st Floor', 'AIRCON', 'AC-001', 'Airconditioning maintenance', 'Active'),
('Communications Office', 'Ms. Rosemarie Garcia', 'communications@school.edu.ph', '09171234663', 'PR Office', 'Building A', '3rd Floor', 'COMM', 'COM-001', 'Communications and public information', 'Active'),
('Web Development Office', 'Mr. Christian Santos', 'webdev@school.edu.ph', '09171234664', 'IT Center', 'Building F', '3rd Floor', 'WEB', 'WEB-001', 'Website development and maintenance', 'Active'),
('Network Operations Center', 'Engr. Dennis Cruz', 'noc@school.edu.ph', '09171234665', 'IT Center', 'Building F', '4th Floor', 'NOC', 'NOC-001', 'Network infrastructure and monitoring', 'Active'),
('Database Administration', 'Mr. Ronald Reyes', 'dba@school.edu.ph', '09171234666', 'IT Center', 'Building F', '4th Floor', 'DBA', 'DBA-001', 'Database management and backup', 'Active'),
('Systems Administration', 'Mr. Jeffrey Torres', 'sysadmin@school.edu.ph', '09171234667', 'IT Center', 'Building F', '4th Floor', 'SYSADM', 'SYS-001', 'System administration and support', 'Active'),
('Help Desk Support', 'Ms. Rachel Mendoza', 'helpdesk@school.edu.ph', '09171234668', 'IT Center', 'Building F', '1st Floor', 'HELP', 'HLP-001', 'IT help desk and user support', 'Active');

-- Show count
SELECT COUNT(*) AS 'Total Departments Created' FROM departments;
