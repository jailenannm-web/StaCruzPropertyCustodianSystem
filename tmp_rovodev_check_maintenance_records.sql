-- Check if maintenance records exist
USE teamcruzim;

-- Show all maintenance records
SELECT 
    maintenanceId,
    requestId,
    propertyItemName,
    serialNumber,
    status,
    assignedTechnician,
    maintenanceDate,
    createdAt
FROM maintenance
ORDER BY createdAt DESC
LIMIT 20;

-- Check if the TV item has a maintenance record
SELECT * FROM maintenance WHERE propertyItemName = 'TV';

-- Show all borrowed items
SELECT 
    borrowId,
    itemType,
    itemId,
    borrowerName,
    status
FROM borrowed_items
WHERE status != 'Returned'
ORDER BY borrowDate DESC
LIMIT 20;

-- Check if TV property exists
SELECT itemName, propertyNumber, serialNumber, status FROM properties WHERE itemName = 'TV';
