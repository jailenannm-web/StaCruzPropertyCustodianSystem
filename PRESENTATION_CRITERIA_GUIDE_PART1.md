# PRESENTATION CRITERIA GUIDE - PART 1
## Property Custodian System - Code Examples & Locations

---

## 📋 TABLE OF CONTENTS
- Part 1: Design Criteria (ERD, Normalization, Data Types)
- Part 2: Functionality Criteria (CRUD, Queries, Transactions)
- Part 3: Performance & Security
- Part 4: UI, Documentation & Additional Features

---

## 🎯 DESIGN CRITERIA

### **CRITERION 1: Entity Relationship Diagram (ERD)** 
**Score: 5/5** (You have 14 entities - exceeds requirement!)

#### **Where to Find in Your Code:**
- **File:** `teamcruzim_database.sql` (Lines 38-370)

#### **Your Main Entities (5+ Required):**

1. **`users` Table** (Line 61-94)
   - Primary Key: `userId INT AUTO_INCREMENT`
   - Foreign Keys: `departmentId` → departments
   - 20+ attributes including name, role, credentials
   ```sql
   CREATE TABLE users (
       userId INT AUTO_INCREMENT PRIMARY KEY,
       firstName VARCHAR(100) NOT NULL,
       lastName VARCHAR(100) NOT NULL,
       email VARCHAR(150) UNIQUE NOT NULL,
       username VARCHAR(50) UNIQUE NOT NULL,
       passwordEncrypted VARCHAR(255) NOT NULL,
       role ENUM('SuperAdmin', 'Admin', 'Custodian', 'Staff') DEFAULT 'Staff',
       departmentId INT DEFAULT NULL,
       FOREIGN KEY (departmentId) REFERENCES departments(departmentId)
   )
   ```

2. **`properties` Table** (Line 146-172)
   - Primary Key: `propertyId INT AUTO_INCREMENT`
   - Foreign Keys: 
     - `assignedTo` → users
     - `departmentId` → departments
   - Tracks all property inventory
   ```sql
   CREATE TABLE properties (
       propertyId INT AUTO_INCREMENT PRIMARY KEY,
       itemName VARCHAR(200) NOT NULL,
       category VARCHAR(100),
       acquisitionCost DECIMAL(15,2) NOT NULL,
       assignedTo INT DEFAULT NULL,
       departmentId INT DEFAULT NULL,
       FOREIGN KEY (assignedTo) REFERENCES users(userId),
       FOREIGN KEY (departmentId) REFERENCES departments(departmentId)
   )
   ```

3. **`supplies` Table** (Line 176-197)
   - Primary Key: `supplyId INT AUTO_INCREMENT`
   - Tracks consumable inventory
   - Foreign Key: `assignedTo` → users
   ```sql
   CREATE TABLE supplies (
       supplyId INT AUTO_INCREMENT PRIMARY KEY,
       itemName VARCHAR(200) NOT NULL,
       quantity INT DEFAULT 0,
       unitCost DECIMAL(15,2),
       assignedTo INT DEFAULT NULL,
       FOREIGN KEY (assignedTo) REFERENCES users(userId)
   )
   ```

4. **`property_requests` Table** (Line 198-222)
   - Primary Key: `requestId INT AUTO_INCREMENT`
   - Foreign Keys: `userId` → users, `departmentId` → departments
   - Tracks all property/supply requests
   ```sql
   CREATE TABLE property_requests (
       requestId INT AUTO_INCREMENT PRIMARY KEY,
       userId INT NOT NULL,
       departmentId INT DEFAULT NULL,
       status ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
       FOREIGN KEY (userId) REFERENCES users(userId),
       FOREIGN KEY (departmentId) REFERENCES departments(departmentId)
   )
   ```

5. **`maintenance_requests` Table** (Line 248-270)
   - Primary Key: `requestId INT AUTO_INCREMENT`
   - Foreign Keys: `requestedBy` → users, `departmentId` → departments
   ```sql
   CREATE TABLE maintenance_requests (
       requestId INT AUTO_INCREMENT PRIMARY KEY,
       requestedBy INT NOT NULL,
       departmentId INT DEFAULT NULL,
       status ENUM('Pending', 'In Progress', 'Completed', 'Cancelled'),
       FOREIGN KEY (requestedBy) REFERENCES users(userId),
       FOREIGN KEY (departmentId) REFERENCES departments(departmentId)
   )
   ```

6. **`maintenance` Table** (Line 274-301)
   - Tracks maintenance activities and costs

7. **`borrowed_items` Table** (Line 320-342)
   - Tracks property/supply borrowing with polymorphic design
   - Links to properties OR supplies using itemType + itemId

8. **`departments` Table** (Line 39-59)
   - Organizational structure
   - Primary Key: `departmentId`

9. **`audit_logs` Table** (Line 356-370)
   - Complete audit trail for all system actions

10-14. **Additional entities:** `categories`, `custodian`, `supplies_requests`, `staff_accounts`, `system_config`

#### **Cardinality Examples (1:N, N:M):**
- **1:N** - One department has many users
- **1:N** - One user can have many property_requests
- **1:N** - One property can be assigned to one user
- **N:M** (through borrowed_items) - Users can borrow multiple properties/supplies

#### **Participation Constraints:**
- **Optional:** `assignedTo` in properties can be NULL (property may not be assigned)
- **Mandatory:** `userId` in property_requests is NOT NULL (request must have requester)

---

### **CRITERION 2: Normalization**
**Score: 5/5** (All 14 entities are in 3NF!)

#### **What is 3NF?**
1. ✅ **1NF:** No repeating groups, atomic values
2. ✅ **2NF:** No partial dependencies (all non-key attributes depend on entire primary key)
3. ✅ **3NF:** No transitive dependencies (non-key attributes don't depend on other non-key attributes)

#### **5+ Examples of 3NF Implementation:**

**Example 1: `users` Table - Perfect 3NF**
```sql
-- ✅ NORMALIZED (Current Design)
users (userId, firstName, lastName, email, departmentId)
departments (departmentId, departmentName, location)

-- ❌ DENORMALIZED (What NOT to do)
users (userId, firstName, lastName, email, departmentName, departmentLocation)
```
- **Why 3NF?** Department info is stored separately, no redundancy
- **File:** `teamcruzim_database.sql` Line 61-94

**Example 2: `properties` Table - No Redundant Data**
```sql
-- ✅ CURRENT: Department details stored separately
properties (propertyId, itemName, category, departmentId, assignedTo)
departments (departmentId, departmentName)
users (userId, firstName, lastName)

-- ❌ WRONG: Storing names directly would violate 3NF
properties (propertyId, itemName, departmentName, assignedUserName)
```
- **File:** `teamcruzim_database.sql` Line 146-172

**Example 3: `borrowed_items` - Clean Separation**
```sql
-- ✅ NO duplication of property/supply details
borrowed_items (borrowedId, itemType, itemId, borrowerName, departmentId)
-- Item details retrieved via JOIN, not stored here
```
- **File:** `teamcruzim_database.sql` Line 320-342

**Example 4: `maintenance_requests` - Proper FK Design**
```sql
-- ✅ Only references, no duplicate department/user data
maintenance_requests (requestId, requestedBy, departmentId, propertyId)
-- User and department details in separate tables
```
- **File:** `teamcruzim_database.sql` Line 248-270

**Example 5: `audit_logs` - Independent Tracking**
```sql
-- ✅ References userId, doesn't duplicate user details
audit_logs (logId, userId, action, tableName, recordId, description)
-- User details joined when needed, not stored redundantly
```
- **File:** `teamcruzim_database.sql` Line 356-370

#### **How to Demonstrate in Presentation:**
1. Open `teamcruzim_database.sql`
2. Show how `users` table only stores `departmentId`, not department details
3. Show how `properties` table references `assignedTo` and `departmentId` via FK
4. Explain: "No department name is repeated; we use JOINs to get full details"

---

### **CRITERION 3: Data Types**
**Score: 5/5** (1-2 inconsistencies = excellent!)

#### **Where to Find:** `teamcruzim_database.sql` (Lines 38-370)

#### **5+ Examples of Proper Data Types:**

**Example 1: Monetary Values - Consistent DECIMAL(15,2)**
```sql
-- ✅ ALL money fields use same type
acquisitionCost DECIMAL(15,2) NOT NULL      -- properties table
totalCost DECIMAL(15,2) DEFAULT NULL        -- properties table
unitCost DECIMAL(15,2) DEFAULT NULL         -- supplies table
costMaterialsLabor DECIMAL(15,2) DEFAULT 0  -- maintenance table
```
- **Location:** Multiple tables
- **Why correct?** DECIMAL preserves precision for financial calculations
- **Consistent:** All use (15,2) = up to 999,999,999,999.99

**Example 2: Dates - Proper DATE vs DATETIME**
```sql
-- ✅ DATE for calendar dates (no time needed)
acquisitionDate DATE NOT NULL              -- properties table

-- ✅ DATETIME for timestamps (time important)
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
```
- **Location:** All tables
- **Why correct?** Uses DATE for events, DATETIME for system timestamps

**Example 3: Status Fields - ENUM for Controlled Values**
```sql
-- ✅ ENUM limits to valid values
status ENUM('Active', 'Inactive') DEFAULT 'Active'                    -- users
role ENUM('SuperAdmin', 'Admin', 'Custodian', 'Staff') DEFAULT 'Staff' -- users
status ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending'      -- requests
status ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good'         -- maintenance
```
- **Location:** Multiple tables
- **Why correct?** Prevents invalid status entries, enforces data integrity

**Example 4: Text Fields - Appropriate VARCHAR Lengths**
```sql
-- ✅ Sized appropriately for content
itemName VARCHAR(200) NOT NULL        -- Long enough for item names
category VARCHAR(100)                 -- Categories are shorter
email VARCHAR(150)                    -- Standard email length
username VARCHAR(50)                  -- Usernames typically short
description TEXT                      -- Variable length descriptions
```
- **Location:** Multiple tables
- **Why correct?** Not too small (truncation risk) or too large (waste space)

**Example 5: Primary Keys - INT AUTO_INCREMENT**
```sql
-- ✅ ALL primary keys use same pattern
userId INT AUTO_INCREMENT PRIMARY KEY
propertyId INT AUTO_INCREMENT PRIMARY KEY
supplyId INT AUTO_INCREMENT PRIMARY KEY
requestId INT AUTO_INCREMENT PRIMARY KEY
departmentId INT AUTO_INCREMENT PRIMARY KEY
```
- **Location:** All tables
- **Why correct?** Consistent, efficient integer keys with auto-generation

#### **Minor Inconsistencies (Why still 5 points):**
- Some older fields may use snake_case vs camelCase
- But data TYPES themselves are consistent (INT is INT, DECIMAL is DECIMAL)
- Scoring focuses on type appropriateness, not naming

---

## 📝 PRESENTATION TIPS FOR DESIGN CRITERIA

### **How to Present ERD (Criterion 1):**
1. **Show database schema:** Open `teamcruzim_database.sql`
2. **Count entities:** "We have 14 main entities - users, properties, supplies, maintenance, etc."
3. **Show relationships:** "Properties table has FK to users (assignedTo) and departments"
4. **Explain cardinality:** "One user can have many properties (1:N relationship)"

### **How to Present Normalization (Criterion 2):**
1. **Open two tables:** Show `users` and `departments` side by side
2. **Explain:** "Notice we store departmentId in users, not department details"
3. **Compare:** "If we stored departmentName in users, updating department name would require changing 100+ rows"
4. **Emphasize:** "Our design eliminates redundancy - that's 3NF"

### **How to Present Data Types (Criterion 3):**
1. **Search in SQL file:** Search for "DECIMAL(15,2)" to show consistency
2. **Show ENUM:** Point to role field: "We use ENUM to enforce only valid roles"
3. **Compare dates:** Show acquisitionDate (DATE) vs createdAt (DATETIME)
4. **Conclude:** "All monetary values use DECIMAL, all IDs use INT, all status fields use ENUM"

---

**Continue to PART 2 for Functionality Criteria (CRUD, Queries, Transactions)...**
