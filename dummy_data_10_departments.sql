-- =====================================================
-- DUMMY DATA: 10 DEPARTMENTS FOR STA CRUZ PROPERTY CUSTODIAN SYSTEM
-- =====================================================
-- This file contains 10 sample departments with all 15 attributes
-- Run this after creating the database schema
-- =====================================================

USE teamcruzim;

-- Clear existing data (optional - comment out if you want to keep existing data)
-- DELETE FROM departments;

-- Insert 10 departments with all 15 attributes
INSERT INTO departments (department_name, head_of_department, contact_number, email, location, 
                        no_of_employees, department_code, office_hours, established_date, 
                        parent_department_id, status, budget_allocation, created_at, updated_at)
VALUES
-- Department 1: Information Technology
('Information Technology', 'Dr. John Michael Santos', '09171234567', 'it.department@stacruz.edu', 
 'Building A, 2nd Floor, Room 201', 15, 'IT', '8:00 AM - 5:00 PM', '2020-01-15', 
 NULL, 'active', 500000.00, NOW(), NOW()),

-- Department 2: Human Resources
('Human Resources', 'Ms. Maria Cristina Garcia', '09171234568', 'hr.department@stacruz.edu', 
 'Building B, 1st Floor, Room 101', 8, 'HR', '8:00 AM - 5:00 PM', '2019-03-20', 
 NULL, 'active', 300000.00, NOW(), NOW()),

-- Department 3: Finance and Accounting
('Finance and Accounting', 'Mr. Robert James Johnson', '09171234569', 'finance@stacruz.edu', 
 'Building A, 3rd Floor, Room 301', 12, 'FIN', '8:00 AM - 5:00 PM', '2018-06-10', 
 NULL, 'active', 800000.00, NOW(), NOW()),

-- Department 4: Administration
('Administration', 'Dr. Sarah Elizabeth Williams', '09171234570', 'admin@stacruz.edu', 
 'Building C, 1st Floor, Room 105', 20, 'ADMIN', '7:00 AM - 6:00 PM', '2017-01-05', 
 NULL, 'active', 1000000.00, NOW(), NOW()),

-- Department 5: Maintenance
('Maintenance', 'Mr. Michael Anthony Brown', '09171234571', 'maintenance@stacruz.edu', 
 'Building D, Ground Floor, Maintenance Office', 10, 'MAINT', '7:00 AM - 4:00 PM', '2019-08-15', 
 NULL, 'active', 400000.00, NOW(), NOW()),

-- Department 6: Library
('Library', 'Ms. Emily Rose Davis', '09171234572', 'library@stacruz.edu', 
 'Building E, 2nd Floor, Library Section', 6, 'LIB', '7:00 AM - 7:00 PM', '2018-02-28', 
 NULL, 'active', 250000.00, NOW(), NOW()),

-- Department 7: Security
('Security', 'Mr. David Christopher Martinez', '09171234573', 'security@stacruz.edu', 
 'Building A, Ground Floor, Security Office', 18, 'SEC', '24/7', '2017-05-12', 
 NULL, 'active', 600000.00, NOW(), NOW()),

-- Department 8: Academic Affairs
('Academic Affairs', 'Dr. Patricia Ann Rodriguez', '09171234574', 'academic@stacruz.edu', 
 'Building B, 3rd Floor, Room 303', 25, 'ACAD', '7:30 AM - 5:30 PM', '2016-09-01', 
 NULL, 'active', 750000.00, NOW(), NOW()),

-- Department 9: Student Affairs
('Student Affairs', 'Ms. Jennifer Lynn Anderson', '09171234575', 'studentaffairs@stacruz.edu', 
 'Building C, 2nd Floor, Room 205', 14, 'STUDAFF', '8:00 AM - 5:00 PM', '2018-11-15', 
 NULL, 'active', 450000.00, NOW(), NOW()),

-- Department 10: Research and Development
('Research and Development', 'Dr. Mark Anthony Thompson', '09171234576', 'research@stacruz.edu', 
 'Building F, 1st Floor, Research Lab', 9, 'RND', '8:00 AM - 6:00 PM', '2019-04-10', 
 NULL, 'active', 550000.00, NOW(), NOW());

-- =====================================================
-- VERIFICATION QUERY
-- =====================================================
-- Run this to verify the data was inserted correctly:
-- SELECT department_id, department_name, department_code, head_of_department, 
--        no_of_employees, status, budget_allocation 
-- FROM departments 
-- ORDER BY department_name;

-- =====================================================
-- END OF DUMMY DATA
-- =====================================================
