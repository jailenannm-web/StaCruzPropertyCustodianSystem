-- ================================================================
-- GENERATE 10,000+ REALISTIC USER ACCOUNTS
-- Philippine names with proper distribution across roles
-- Database: teamcruzim
-- ================================================================

USE teamcruzim;

-- Disable foreign key checks temporarily for faster inserts
SET FOREIGN_KEY_CHECKS = 0;
SET AUTOCOMMIT = 0;

-- Clear existing users (keep superadmin)
DELETE FROM users WHERE userId > 1;

-- Reset auto increment
ALTER TABLE users AUTO_INCREMENT = 2;

-- ================================================================
-- STORED PROCEDURE: Generate Users with Realistic Names
-- ================================================================

DELIMITER $$

DROP PROCEDURE IF EXISTS GenerateUsers$$

CREATE PROCEDURE GenerateUsers()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE total_users INT DEFAULT 10000;
    DECLARE dept_id INT;
    DECLARE user_role ENUM('SuperAdmin','Admin','Custodian','Staff');
    DECLARE first_name VARCHAR(50);
    DECLARE middle_name VARCHAR(50);
    DECLARE last_name VARCHAR(50);
    DECLARE suffix_val VARCHAR(10);
    DECLARE position_val VARCHAR(100);
    DECLARE emp_id VARCHAR(50);
    DECLARE contact VARCHAR(20);
    DECLARE email_val VARCHAR(100);
    DECLARE username_val VARCHAR(50);
    DECLARE province_val VARCHAR(100);
    DECLARE municipal_val VARCHAR(100);
    DECLARE barangay_val VARCHAR(100);
    DECLARE random_num INT;
    DECLARE dept_count INT;
    
    -- Get department count
    SELECT COUNT(*) INTO dept_count FROM departments WHERE status = 'Active';
    
    -- Filipino First Names (Male & Female)
    SET @first_names = 'Juan,Maria,Jose,Ana,Pedro,Rosa,Miguel,Carmen,Luis,Teresa,Carlos,Elena,Ramon,Sofia,Fernando,Patricia,Antonio,Isabel,Manuel,Gloria,Roberto,Angela,Ricardo,Cristina,Eduardo,Beatriz,Francisco,Diana,Alfredo,Laura,Jorge,Cecilia,Alberto,Monica,Diego,Angelica,Gabriel,Marissa,Victor,Dolores,Oscar,Esperanza,Rafael,Felicidad,Enrique,Remedios,Sergio,Josephine,Alejandro,Trinidad,Marcos,Rosario,Pablo,Corazon,Leonardo,Lourdes,Andres,Milagros,Felipe,Estrella,Raul,Veronica,Javier,Lydia,Daniel,Erlinda,Miguel,Teresita,Rodrigo,Amelita,Ernesto,Nestor,Benjamin,Florencio,Gregorio,Salvador,Domingo,Artemio,Bonifacio,Renato,Cecilio,Federico,Noel,Dennis,Christian,Ronald,Jeffrey,Adrian,Martin,George,Thomas,Emmanuel,Leonardo,Gabriel,Vincent,Anthony,Christopher,Michael,Matthew,Mark,John,David,James,Paul,Peter,Andrew,Stephen,Timothy,Alexander,Nicholas,Jonathan,Joshua,Samuel,Nathan,Daniel,Ryan,Kevin,Brian,Eric,Justin,Jason,Brandon,Tyler,Kyle,Sean,Adam,Jacob,Aaron,Ian,Keith,Scott,Gregory,Raymond,Gerald,Harold,Eugene,Albert,Arthur,Lawrence,Philip,Douglas,Roger,Willie,Henry,Dennis,Walter,Patrick,Donald,Ralph,Russell,Roy,Joe,Louis,Jack,Albert,Fred,Howard,Earl,Carl,Ernest,Stanley,Francis,Leonard,Herbert,Bernard,Norman,Chester,Lloyd,Milton,Harvey,Clarence,Vernon,Leon,Edwin,Glenn,Leslie,Franklin,Clinton,Floyd,Arnold,Dale,Edgar,Calvin,Herman,Curtis,Jerome,Warren,Willard,Luther,Lester,Gordon,Melvin,Cecil,Marvin,Clifford,Oscar,Julius,Wallace,Clayton,Maurice,Roland,Alvin,Theodore,Everett,Percy,Leroy,Elmer,Clyde,Virgil,Homer,Archie,Wesley,Guy,Otis,Emmett,Gilbert,Horace,Rufus,Nelson,Amos,Wilbur,Willis,Delbert,Hubert,Orville,Sidney,Elbert,Lonnie,Jessie,Nathaniel,Wade,Dewey,Alton,Lyle,Monroe,Sylvester,Roscoe,Sherman,Irving,Wilfred,Elijah';
    
    SET @middle_names = 'Alfonso,Bernardo,Celestino,Demetrio,Emilio,Felipe,Gregorio,Honorato,Ignacio,Jaime,Lorenzo,Marcelo,Nicanor,Octavio,Pascual,Quirino,Romualdo,Salvador,Teodoro,Urbano,Vicente,Xavier,Ysmael,Zacarias,Agustin,Bonifacio,Casimiro,Damian,Efren,Francisco,Guillermo,Hilario,Isidro,Joaquin,Leonardo,Mariano,Nemesio,Orlando,Pantaleon,Quintin,Rodrigo,Severino,Tomas,Ulysses,Valentino,Wilfredo,Santos,Cruz,Reyes,Garcia,Ramos,Torres,Flores,Mendoza,Castro,Morales,Santos,Dela,Cruz,Gonzales,Rivera,Lopez,Martinez,Rodriguez,Hernandez,Perez,Sanchez,Ramirez,Gutierrez,Diaz,Fernandez,Alvarez,Castillo,Jimenez,Romero,Vargas,Ortiz,Salazar,Navarro,Aguilar,Rojas,Valdez,Vasquez,Suarez,Santiago,Moreno,Ponce,Mercado,Silva,Cortez,Serrano,Campos,Acosta,Bautista,Villanueva,Valencia,Herrera,Luna,Medina,Dominguez,Guerrero,Espinosa,Soto,Contreras,Ruiz,Vega,Molina,Cabrera,Fuentes,Leon,Montoya,Carrillo,Rios,Nunez,Guzman,Calderon,Figueroa,Ibarra,Pacheco,Estrada,Padilla,Velasquez,Miranda,Ayala,Delgado,Maldonado,Bonilla,Sandoval,Cervantes,Franco,Duran,Ochoa,Orozco,Trujillo,Montes,Nava,Rosales,Benitez,Cardenas,Salas,Galvan,Esquivel,Zamora,Barrera';
    
    SET @last_names = 'Santos,Reyes,Cruz,Garcia,Ramos,Flores,Mendoza,Torres,Gonzales,Rivera,Lopez,Martinez,Rodriguez,Hernandez,Perez,Sanchez,Ramirez,Gutierrez,Diaz,Fernandez,Alvarez,Castillo,Jimenez,Romero,Morales,Vargas,Castro,Ortiz,Salazar,Navarro,Aguilar,Rojas,Valdez,Vasquez,Suarez,Santiago,Moreno,Ponce,Mercado,Silva,Cortez,Serrano,Campos,Acosta,Bautista,Villanueva,Valencia,Herrera,Luna,Medina,Dominguez,Guerrero,Espinosa,Soto,Contreras,Ruiz,Vega,Molina,Cabrera,Fuentes,Leon,Montoya,Carrillo,Rios,Nunez,Guzman,Calderon,Figueroa,Ibarra,Pacheco,Estrada,Padilla,Velasquez,Miranda,Ayala,Delgado,Maldonado,Bonilla,Sandoval,Cervantes,Franco,Duran,Ochoa,Orozco,Trujillo,Montes,Nava,Rosales,Benitez,Cardenas,Salas,Galvan,Esquivel,Zamora,Barrera,Mejia,Pena,Solis,Zavala,Lara,Camacho,Marin,Robles,Herrera,Aguilera,Carrasco,Arroyo,Cordova,Mora,Escobar,Villarreal,Santana,Lugo,Galindo,Quintero,Paredes,Villa,Beltran,Melendez,Duarte,Valdez,Zuniga,Mata,Andrade,Huerta,Carbajal,Saldana,Valenzuela,Gallegos,Rivas,Enriquez,Marquez,Rangel,Bernal,Murillo,Coronado,Nieves,Bustamante,Barajas,Davila,Delacruz,Salinas,Jaramillo,Palacios,Saenz,Esparza,Juarez,Lucero,Macias,Gamez,Armenta,Fonseca,Olivas,Cornejo,Ontiveros,Cantu,Godinez,Alonso,Alfaro,Blanco,Segura,Cisneros,Felix,Alvarado,Villegas,Navarrete,Arellano,Banuelos,Partida,Pineda,Madrid,Colon,Saavedra,Acevedo,Olmos,Mesa,Aguirre,Ocampo,Caballero,Medrano,Uribe,Gracia,Peralta,Pardo,Meza,Trevino,Rosario,Anaya,Rico,Galicia,Urena,Prieto,Ibanez,Guillen';
    
    SET @positions = 'Professor,Assistant Professor,Associate Professor,Instructor,Lecturer,Department Head,Dean,Director,Coordinator,Administrative Officer,Clerk,Secretary,Accountant,Cashier,Registrar,Librarian,Laboratory Technician,IT Specialist,Network Administrator,Database Administrator,Property Custodian,Supply Officer,Budget Officer,Human Resource Officer,Legal Officer,Guidance Counselor,Campus Nurse,Security Officer,Maintenance Staff,Electrician,Plumber,Carpenter,Driver,Utility Worker,Janitor,Groundskeeper,Research Assistant,Teaching Assistant,Program Chair,Project Manager,Quality Assurance Officer,Public Relations Officer,Alumni Coordinator,Student Affairs Officer,Scholarship Coordinator,Sports Coordinator,Cultural Affairs Officer,Extension Coordinator,Planning Officer,Records Officer,Data Privacy Officer,Internal Auditor,Systems Analyst,Web Developer,Multimedia Specialist,Audio Visual Technician,Laboratory Aide,Laboratory Assistant,Library Assistant,Office Assistant,Administrative Assistant,Executive Assistant,Procurement Officer,Property Officer,Asset Management Officer,Facility Manager,Building Administrator,Safety Officer,Environmental Officer,DRRM Officer,GAD Coordinator,Community Development Officer,Technology Transfer Officer,IPR Officer,Testing Officer,Admission Officer,Career Counselor,Placement Officer,Discipline Officer,Housing Officer,Food Service Manager,Transport Officer,Communications Officer,Information Officer,Document Controller,Encoder,Data Entry Operator,Bookkeeper,Payroll Officer,Treasury Officer,Collection Officer,Disbursement Officer,Auditor,Tax Compliance Officer,Financial Analyst,Budget Analyst,Planning Analyst,Policy Analyst,Research Officer,Publication Officer,Editor,Writer,Photographer,Videographer,Graphic Designer,Social Media Manager,Marketing Officer,Event Coordinator,Protocol Officer,Liaison Officer,Training Officer,Development Officer,Project Coordinator,Program Officer,Monitoring Officer,Evaluation Officer,Compliance Officer,Risk Officer,Chief Accountant,Accounting Supervisor,Finance Manager,Administrative Manager,Operations Manager,Facilities Manager,Services Manager,Technical Manager,Academic Supervisor,Clinical Instructor,Laboratory Supervisor,Workshop Supervisor,Field Supervisor,Senior Instructor,Senior Professor,College Secretary,University Registrar,University Librarian,Campus Director,Branch Manager,Section Chief,Unit Head,Office Head,Chief of Staff,Executive Director,Deputy Director,Assistant Director,Senior Officer,Junior Officer,Staff Nurse,Head Nurse,Medical Technologist,Pharmacist,Dentist,Physician,Psychologist,Social Worker,Nutritionist,Physical Therapist,Occupational Therapist,Speech Therapist,Midwife,Medical Records Officer,Clinical Psychologist,School Psychologist,Guidance Associate,Career Advisor,Student Development Officer,Leadership Development Officer,Peer Counselor Supervisor,Organization Adviser,Club Moderator,Team Coach,Assistant Coach,Athletic Director,Sports Development Officer,PE Instructor,Fitness Instructor,Dance Instructor,Music Instructor,Arts Instructor,Theater Director,Museum Curator,Gallery Officer,Archives Officer,Conservation Officer,Preservation Officer,Digitization Officer,Cataloguer,Acquisitions Librarian,Serials Librarian,Reference Librarian,Circulation Librarian,Digital Resources Librarian,Systems Librarian,Subject Specialist,Collection Development Officer,Learning Commons Manager,Reading Room Supervisor,Periodicals Manager,Thesis Coordinator,E-Learning Coordinator,Distance Learning Officer,Instructional Designer,Curriculum Developer,Assessment Officer,Accreditation Officer,Quality Assurance Coordinator,Standards Officer,Certification Officer,Licensing Officer,Registration Officer,Clearance Officer,Credentials Evaluator,Transfer Credit Officer,Graduation Officer,Awards Officer,Honors Coordinator,Scholarship Evaluator,Financial Aid Officer,Student Loan Officer,Grant Administrator,Fellowship Coordinator,Traineeship Coordinator,Apprenticeship Coordinator,Internship Coordinator,OJT Coordinator,Practicum Supervisor,Clinical Coordinator,Field Training Officer,Industry Linkage Officer,Job Placement Officer,Alumni Relations Officer,Donor Relations Officer,Fundraising Officer,Grants Officer,Corporate Relations Officer,Partnership Officer,Linkages Coordinator,Exchange Program Officer,International Student Officer,Foreign Affairs Officer,Protocol and Liaison Officer';
    
    SET @provinces = 'Camarines Norte,Metro Manila,Cavite,Laguna,Batangas,Rizal,Quezon,Bulacan,Pampanga,Tarlac,Nueva Ecija,Pangasinan,La Union,Ilocos Norte,Ilocos Sur,Benguet,Isabela,Cagayan,Albay,Camarines Sur,Sorsogon,Masbate,Catanduanes,Aklan,Antique,Capiz,Iloilo,Guimaras,Negros Occidental,Negros Oriental,Cebu,Bohol,Leyte,Samar,Eastern Samar,Northern Samar,Southern Leyte,Biliran,Zamboanga del Norte,Zamboanga del Sur,Zamboanga Sibugay,Misamis Occidental,Misamis Oriental,Lanao del Norte,Lanao del Sur,Bukidnon,Camiguin,Agusan del Norte,Agusan del Sur,Surigao del Norte,Surigao del Sur,Dinagat Islands,Davao del Norte,Davao del Sur,Davao Oriental,Davao de Oro,Davao Occidental,Cotabato,South Cotabato,Sultan Kudarat,Sarangani,Maguindanao,Basilan,Sulu,Tawi-Tawi';
    
    SET @suffixes = 'Jr.,Sr.,II,III,IV';
    
    -- Start generating users
    WHILE i < total_users DO
        -- Determine role based on distribution
        -- 1% SuperAdmin, 5% Admin, 15% Custodian, 79% Staff
        SET random_num = FLOOR(1 + RAND() * 100);
        IF random_num = 1 THEN
            SET user_role = 'SuperAdmin';
        ELSEIF random_num <= 6 THEN
            SET user_role = 'Admin';
        ELSEIF random_num <= 21 THEN
            SET user_role = 'Custodian';
        ELSE
            SET user_role = 'Staff';
        END IF;
        
        -- Generate random names
        SET first_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@first_names, ',', FLOOR(1 + RAND() * 250)), ',', -1);
        SET middle_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@middle_names, ',', FLOOR(1 + RAND() * 200)), ',', -1);
        SET last_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@last_names, ',', FLOOR(1 + RAND() * 200)), ',', -1);
        
        -- Random suffix (30% chance)
        IF RAND() < 0.30 THEN
            SET suffix_val = SUBSTRING_INDEX(SUBSTRING_INDEX(@suffixes, ',', FLOOR(1 + RAND() * 5)), ',', -1);
        ELSE
            SET suffix_val = NULL;
        END IF;
        
        -- Assign department
        SET dept_id = FLOOR(1 + RAND() * dept_count);
        
        -- Generate position based on role
        IF user_role IN ('SuperAdmin', 'Admin') THEN
            SET position_val = SUBSTRING_INDEX(SUBSTRING_INDEX('President,Vice President,Dean,Director,Department Head,Chief Administrative Officer,Chief Finance Officer,Chief Academic Officer,Campus Director,Registrar,University Librarian,Human Resource Manager,Finance Manager,Budget Officer,Property Custodian Officer', ',', FLOOR(1 + RAND() * 15)), ',', -1);
        ELSEIF user_role = 'Custodian' THEN
            SET position_val = SUBSTRING_INDEX(SUBSTRING_INDEX('Property Custodian,Supply Officer,Asset Management Officer,Facility Manager,Property Officer,Department Property Officer,College Property Officer,Equipment Custodian,Laboratory Custodian,Library Custodian', ',', FLOOR(1 + RAND() * 10)), ',', -1);
        ELSE
            SET position_val = SUBSTRING_INDEX(SUBSTRING_INDEX(@positions, ',', FLOOR(1 + RAND() * 250)), ',', -1);
        END IF;
        
        -- Generate employee ID
        SET emp_id = CONCAT('EMP', LPAD(i + 2, 6, '0'));
        
        -- Generate contact number
        SET contact = CONCAT('09', FLOOR(10 + RAND() * 90), FLOOR(1000000 + RAND() * 9000000));
        
        -- Generate email
        SET email_val = CONCAT(LOWER(first_name), '.', LOWER(last_name), i, '@school.edu.ph');
        
        -- Generate username
        SET username_val = CONCAT(LOWER(LEFT(first_name, 1)), LOWER(last_name), FLOOR(100 + RAND() * 900));
        
        -- Random province
        SET province_val = SUBSTRING_INDEX(SUBSTRING_INDEX(@provinces, ',', FLOOR(1 + RAND() * 55)), ',', -1);
        
        -- Municipal and Barangay (simplified)
        SET municipal_val = CONCAT(province_val, ' District ', FLOOR(1 + RAND() * 5));
        SET barangay_val = CONCAT('Barangay ', FLOOR(1 + RAND() * 50));
        
        -- Insert user
        INSERT INTO users (
            firstName, middleName, lastName, suffix, position, departmentId,
            employeeId, contactNumber, email, username, passwordEncrypted,
            province, municipal, barangay, role, status, createdAt, updatedAt
        ) VALUES (
            first_name, middle_name, last_name, suffix_val, position_val, dept_id,
            emp_id, contact, email_val, username_val, '$2a$11$YourHashedPasswordHere',
            province_val, municipal_val, barangay_val, user_role, 'Active', 
            DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 365) DAY),
            NOW()
        );
        
        SET i = i + 1;
        
        -- Commit in batches of 1000
        IF i MOD 1000 = 0 THEN
            COMMIT;
            SELECT CONCAT('Generated ', i, ' users...') AS Progress;
        END IF;
    END WHILE;
    
    COMMIT;
END$$

DELIMITER ;

-- ================================================================
-- Execute the procedure
-- ================================================================

SELECT 'Starting user generation...' AS Status;
CALL GenerateUsers();

-- ================================================================
-- Show statistics
-- ================================================================

SELECT '=== USER GENERATION COMPLETE ===' AS Info;

SELECT 
    role AS 'Role',
    COUNT(*) AS 'Count',
    CONCAT(ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM users), 2), '%') AS 'Percentage'
FROM users
GROUP BY role
ORDER BY COUNT(*) DESC;

SELECT 
    d.departmentName AS 'Department',
    COUNT(u.userId) AS 'User Count'
FROM departments d
LEFT JOIN users u ON d.departmentId = u.departmentId
WHERE d.status = 'Active'
GROUP BY d.departmentId, d.departmentName
ORDER BY COUNT(u.userId) DESC
LIMIT 20;

SELECT COUNT(*) AS 'Total Users Created' FROM users;

-- Re-enable foreign keys
SET FOREIGN_KEY_CHECKS = 1;
SET AUTOCOMMIT = 1;

-- Drop the procedure
DROP PROCEDURE IF EXISTS GenerateUsers;

SELECT 'User generation completed successfully!' AS Status;
