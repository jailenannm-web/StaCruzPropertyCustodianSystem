-- =====================================================
-- DUMMY DATA FOR STA CRUZ PROPERTY CUSTODIAN SYSTEM
-- =====================================================
-- This file contains sample data for testing the system
-- Run this after creating the database schema
-- =====================================================

-- =====================================================
-- 1. DEPARTMENTS (15 attributes)
-- =====================================================
INSERT INTO departments (department_name, head_of_department, contact_number, email, location, 
                        no_of_employees, department_code, office_hours, established_date, 
                        parent_department_id, status, budget_allocation, created_at, updated_at)
VALUES
('Information Technology', 'John Smith', '09123456789', 'it@stacruz.edu', 'Building A, 2nd Floor', 
 15, 'IT', '8:00 AM - 5:00 PM', '2020-01-15', NULL, 'active', 500000.00, NOW(), NOW()),

('Human Resources', 'Maria Garcia', '09123456790', 'hr@stacruz.edu', 'Building B, 1st Floor', 
 8, 'HR', '8:00 AM - 5:00 PM', '2019-03-20', NULL, 'active', 300000.00, NOW(), NOW()),

('Finance', 'Robert Johnson', '09123456791', 'finance@stacruz.edu', 'Building A, 3rd Floor', 
 12, 'FIN', '8:00 AM - 5:00 PM', '2018-06-10', NULL, 'active', 800000.00, NOW(), NOW()),

('Administration', 'Sarah Williams', '09123456792', 'admin@stacruz.edu', 'Building C, 1st Floor', 
 20, 'ADMIN', '7:00 AM - 6:00 PM', '2017-01-05', NULL, 'active', 1000000.00, NOW(), NOW()),

('Maintenance', 'Michael Brown', '09123456793', 'maintenance@stacruz.edu', 'Building D, Ground Floor', 
 10, 'MAINT', '7:00 AM - 4:00 PM', '2019-08-15', NULL, 'active', 400000.00, NOW(), NOW()),

('Library', 'Emily Davis', '09123456794', 'library@stacruz.edu', 'Building E, 2nd Floor', 
 6, 'LIB', '7:00 AM - 7:00 PM', '2018-02-28', NULL, 'active', 250000.00, NOW(), NOW()),

('Security', 'David Martinez', '09123456795', 'security@stacruz.edu', 'Building A, Ground Floor', 
 18, 'SEC', '24/7', '2017-05-12', NULL, 'active', 600000.00, NOW(), NOW());

-- =====================================================
-- 2. SUPPLIES (Supply Management)
-- =====================================================
INSERT INTO supplies (supply_id, supply_name, category, quantity_in_stock, unit_cost, 
                     total_value, status, location, description, unit_of_measure, 
                     reorder_level, supplier_name, supplier_contact, acquisition_date, 
                     expiration_date, created_at, updated_at)
VALUES
('SUP001', 'Projector Lamp', 'Electronics', 12, 3850.00, 46200.00, 'active', 'AV Room', 
 'High-quality projector lamp for classroom projectors', 'piece', 5, 'Tech Supplies Inc.', 
 '09123456780', '2024-01-15', NULL, NOW(), NOW()),

('SUP002', 'Cleaning Mop Set', 'Equipment', 25, 450.00, 11250.00, 'active', 'Storage Room 1', 
 'Complete mop set with bucket and wringer', 'set', 10, 'CleanPro Supplies', 
 '09123456781', '2024-02-10', NULL, NOW(), NOW()),

('SUP003', 'USB Flash Drive 32GB', 'Electronics', 50, 250.00, 12500.00, 'active', 'IT Office', 
 '32GB USB 3.0 flash drive', 'piece', 20, 'Tech Supplies Inc.', 
 '09123456780', '2024-03-05', NULL, NOW(), NOW()),

('SUP004', 'LED Tube Light 18W', 'Equipment', 30, 350.00, 10500.00, 'active', 'Storage Room 2', 
 'Energy-efficient LED tube light', 'piece', 15, 'Lighting Solutions', 
 '09123456782', '2024-01-20', NULL, NOW(), NOW()),

('SUP005', 'Alcohol 70% 1L', 'Stationery', 40, 120.00, 4800.00, 'active', 'Medical Supply Room', 
 '70% isopropyl alcohol for disinfection', 'bottle', 20, 'Medical Supplies Co.', 
 '09123456783', '2024-02-15', '2025-02-15', NOW(), NOW()),

('SUP006', 'Filing Box Large', 'Stationery', 20, 280.00, 5600.00, 'active', 'Storage Room 1', 
 'Large filing box for document storage', 'piece', 10, 'Office Supplies Plus', 
 '09123456784', '2024-01-10', NULL, NOW(), NOW()),

('SUP007', 'Laser Printer Toner', 'Electronics', 15, 1200.00, 18000.00, 'active', 'IT Office', 
 'HP LaserJet compatible toner cartridge', 'cartridge', 5, 'Tech Supplies Inc.', 
 '09123456780', '2024-03-01', NULL, NOW(), NOW()),

('SUP008', 'Ethernet Cable CAT6 10m', 'Electronics', 35, 180.00, 6300.00, 'active', 'IT Office', 
 'CAT6 Ethernet cable 10 meters', 'piece', 15, 'Tech Supplies Inc.', 
 '09123456780', '2024-02-20', NULL, NOW(), NOW()),

('SUP009', 'Whiteboard Marker Set', 'Stationery', 45, 150.00, 6750.00, 'active', 'Storage Room 1', 
 'Set of 4 whiteboard markers (black, blue, red, green)', 'set', 20, 'Office Supplies Plus', 
 '09123456784', '2024-01-25', NULL, NOW(), NOW()),

('SUP010', 'Bond Paper A4', 'Stationery', 100, 250.00, 25000.00, 'active', 'Storage Room 1', 
 'A4 bond paper 500 sheets per ream', 'ream', 30, 'Office Supplies Plus', 
 '09123456784', '2024-03-10', NULL, NOW(), NOW()),

('SUP011', 'Desk Chair', 'Furniture', 8, 2500.00, 20000.00, 'active', 'Storage Room 2', 
 'Ergonomic office desk chair', 'piece', 3, 'Furniture World', 
 '09123456785', '2024-02-05', NULL, NOW(), NOW()),

('SUP012', 'Printer Paper A4', 'Stationery', 60, 220.00, 13200.00, 'low_stock', 'Storage Room 1', 
 'A4 printer paper 500 sheets', 'ream', 50, 'Office Supplies Plus', 
 '09123456784', '2024-01-30', NULL, NOW(), NOW());

-- =====================================================
-- 3. PROPERTIES (Property Management)
-- =====================================================
-- Note: Make sure you have at least one user in the users table for custodian_id
-- and departments exist for department_id references

INSERT INTO properties (property_name, category, description, serial_number, acquisition_date, 
                       acquisition_cost, supplier_name, supplier_contact, condition_status, 
                       location, custodian_id, department_id, warranty_details, life_span, 
                       depreciation_value, status, created_at, updated_at)
VALUES
('Desktop Computer Dell OptiPlex', 'IT Equipment', 'Dell OptiPlex 7090 Desktop Computer', 
 'DEL-2024-001', '2024-01-15', 45000.00, 'Dell Technologies', '09123456770', 
 'good', 'IT Office', NULL, 1, '3 years warranty', 5, 0.00, 'active', NOW(), NOW()),

('Laptop HP EliteBook', 'IT Equipment', 'HP EliteBook 840 G8 Laptop', 
 'HP-2024-002', '2024-02-10', 55000.00, 'HP Philippines', '09123456771', 
 'good', 'IT Office', NULL, 1, '2 years warranty', 4, 0.00, 'active', NOW(), NOW()),

('Projector Epson', 'IT Equipment', 'Epson Projector XGA 3500 lumens', 
 'EPS-2024-003', '2024-01-20', 25000.00, 'Epson Philippines', '09123456772', 
 'good', 'AV Room', NULL, 1, '2 years warranty', 5, 0.00, 'active', NOW(), NOW()),

('Office Desk Executive', 'Furniture', 'Executive office desk with drawers', 
 'FUR-2024-004', '2024-02-05', 12000.00, 'Furniture World', '09123456785', 
 'good', 'Admin Office', NULL, 4, '1 year warranty', 10, 0.00, 'active', NOW(), NOW()),

('Filing Cabinet 4-Drawer', 'Furniture', '4-drawer filing cabinet', 
 'FUR-2024-005', '2024-01-10', 8000.00, 'Furniture World', '09123456785', 
 'good', 'HR Office', NULL, 2, '1 year warranty', 15, 0.00, 'active', NOW(), NOW()),

('Air Conditioner 2HP', 'Building and Fixtures', 'Split-type air conditioner 2HP', 
 'AC-2024-006', '2024-03-01', 35000.00, 'Cool Air Solutions', '09123456786', 
 'good', 'IT Office', NULL, 1, '5 years warranty', 10, 0.00, 'active', NOW(), NOW()),

('Photocopier Canon', 'Office Supplies', 'Canon imageRUNNER ADVANCE C5560i', 
 'CAN-2024-007', '2024-02-15', 180000.00, 'Canon Philippines', '09123456787', 
 'good', 'Admin Office', NULL, 4, '3 years warranty', 7, 0.00, 'active', NOW(), NOW()),

('Network Switch 24-Port', 'IT Equipment', '24-port managed network switch', 
 'NET-2024-008', '2024-01-25', 15000.00, 'Network Solutions', '09123456788', 
 'good', 'IT Office', NULL, 1, '2 years warranty', 5, 0.00, 'active', NOW(), NOW()),

('Bookshelf 5-Tier', 'Furniture', '5-tier wooden bookshelf', 
 'FUR-2024-009', '2024-02-20', 5000.00, 'Furniture World', '09123456785', 
 'good', 'Library', NULL, 6, '1 year warranty', 10, 0.00, 'active', NOW(), NOW()),

('Security Camera System', 'IT Equipment', '8-channel security camera system with DVR', 
 'SEC-2024-010', '2024-03-05', 45000.00, 'Security Systems Inc.', '09123456789', 
 'good', 'Security Office', NULL, 7, '2 years warranty', 5, 0.00, 'active', NOW(), NOW()),

('Printer HP LaserJet', 'Office Supplies', 'HP LaserJet Pro M404dn', 
 'HP-2024-011', '2024-01-30', 18000.00, 'HP Philippines', '09123456771', 
 'needs repair', 'IT Office', NULL, 1, '1 year warranty', 5, 0.00, 'active', NOW(), NOW()),

('Vehicle - Service Van', 'Vehicles', 'Toyota Hiace Service Van', 
 'VEH-2024-012', '2023-06-15', 1200000.00, 'Toyota Philippines', '09123456790', 
 'good', 'Parking Area', NULL, 5, '3 years warranty', 10, 120000.00, 'active', NOW(), NOW());

-- =====================================================
-- 4. USERS (for custodian references - optional)
-- =====================================================
-- Note: Adjust these based on your actual users table structure
-- This is just an example - modify according to your schema

-- INSERT INTO users (user_id, username, password, first_name, last_name, email, 
--                    role, department_id, status, created_at, updated_at)
-- VALUES
-- (1, 'admin', 'hashed_password', 'Admin', 'User', 'admin@stacruz.edu', 
--  'admin', 4, 'active', NOW(), NOW()),
-- (2, 'custodian1', 'hashed_password', 'John', 'Custodian', 'custodian1@stacruz.edu', 
--  'custodian', 1, 'active', NOW(), NOW());

-- =====================================================
-- NOTES:
-- =====================================================
-- 1. Make sure to run the main database schema first
-- 2. Adjust foreign key references (custodian_id, department_id) based on your actual data
-- 3. Update dates and values as needed for your testing
-- 4. Some properties may need valid user IDs for custodian_id if your schema requires it
-- 5. Check that department IDs match the departments you inserted above
-- =====================================================

