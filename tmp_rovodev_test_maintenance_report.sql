-- ================================================================
-- TEST DATA FOR MAINTENANCE MANAGEMENT REPORT
-- Run this in phpMyAdmin to create sample maintenance record
-- ================================================================

USE teamcruzim;

-- First, ensure we have a maintenance request
INSERT INTO maintenance_requests (
    dateRequested,
    itemName,
    propertyNumber,
    serialNumber,
    departmentId,
    location,
    conditionBefore,
    typeOfIssue,
    problemDescription,
    status,
    assignedTechnician,
    requestedBy
) VALUES (
    '2025-12-15',
    'Desktop Computer',
    'PROP-2025-001',
    'SN-DC-12345',
    2,
    'IT Department - Room 201',
    'Damaged',
    'Repair',
    'Computer not booting up, displays blue screen error',
    'Completed',
    'John Smith',
    1
);

SET @requestId = LAST_INSERT_ID();

-- Now insert the maintenance record
INSERT INTO maintenance (
    requestId,
    propertyItemName,
    serialNumber,
    location,
    departmentId,
    conditionBeforeMaint,
    typeOfMaintenance,
    assignedTechnician,
    maintenanceDate,
    maintenanceDetails,
    costMaterialsLabor,
    conditionAfterMaint,
    status,
    diagnosis,
    actionTaken,
    partsReplaced
) VALUES (
    @requestId,
    'Desktop Computer',
    'SN-DC-12345',
    'IT Department - Room 201',
    2,
    'Damaged',
    'Repair',
    'John Smith',
    '2025-12-20',
    'Computer diagnosed with faulty RAM module and corrupted operating system. Performed complete diagnostic check, replaced defective RAM, reinstalled operating system, and restored user data from backup.',
    2500.00,
    'Good',
    'Completed',
    'Faulty RAM module (8GB DDR4) and corrupted Windows 10 installation. Power supply unit showing signs of wear but still functional.',
    'Replaced RAM module, reinstalled Windows 10 Professional, updated all drivers and security patches, restored user files from backup server.',
    '8GB DDR4 RAM Module (Kingston HyperX), Windows 10 Professional License'
);

-- Get the maintenance ID for reference
SELECT 
    maintenanceId,
    'Sample maintenance record created successfully!' AS Message,
    CONCAT('Maintenance ID: ', maintenanceId) AS Info
FROM maintenance 
ORDER BY maintenanceId DESC 
LIMIT 1;

-- Display the created record
SELECT 
    m.maintenanceId AS 'Maintenance ID',
    m.requestId AS 'Request ID',
    m.propertyItemName AS 'Property Item',
    m.serialNumber AS 'Serial Number',
    m.location AS 'Location',
    m.departmentId AS 'Department ID',
    m.typeOfMaintenance AS 'Type',
    m.assignedTechnician AS 'Technician',
    m.maintenanceDate AS 'Date',
    m.costMaterialsLabor AS 'Cost',
    m.status AS 'Status'
FROM maintenance m
ORDER BY m.maintenanceId DESC
LIMIT 1;
