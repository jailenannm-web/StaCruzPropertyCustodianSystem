# 📍 WHERE TO FIND ERD & NORMALIZATION IN YOUR SYSTEM

---

## ✅ **YOU ALREADY HAVE COMPLETE DOCUMENTATION!**

Good news! You already have comprehensive ERD and Normalization documentation in your project files!

---

## 📊 **ERD (Entity Relationship Diagram)**

### **File 1: ERD_DOCUMENTATION.md** ⭐ **MAIN DOCUMENT**
**Location:** Root directory of your project

**What's Inside:**
- ✅ All 14 entities documented
- ✅ All relationships explained (1:1, 1:N, M:N)
- ✅ Cardinality for each relationship
- ✅ Participation constraints (mandatory/optional)
- ✅ Foreign key documentation
- ✅ 20+ relationships mapped
- ✅ Complete with code references

**Key Sections:**
- **Lines 1-82:** Entity overview
- **Lines 298-396:** Relationships (DEPARTMENTS → USERS, etc.)
- **Lines 844-891:** Scoring and compliance
- **Lines 973-988:** Participation constraints
- **Lines 1016-1030:** How to create visual ERD

**Score Evidence:** Lines 844-891
```
Your Score: 5/5 Points (Maximum)
- 14 main entities (requirement: 5+)
- 20+ relationships properly implemented
- Correct cardinality (1:1, 1:N, M:N)
```

---

### **File 2: teamcruzim_database.sql** (Actual Implementation)
**Location:** Root directory

**What to Show:**
- **Lines 39-370:** All 14 table definitions
- **Lines 91, 166, 167, etc.:** FOREIGN KEY definitions (shows relationships)

**Example ERD in Code:**
```sql
-- Line 39: DEPARTMENTS entity
CREATE TABLE departments (
  departmentId INT AUTO_INCREMENT PRIMARY KEY,
  departmentName VARCHAR(100) NOT NULL UNIQUE,
  ...
)

-- Line 61: USERS entity
CREATE TABLE users (
  userId INT AUTO_INCREMENT PRIMARY KEY,
  departmentId INT DEFAULT NULL,  -- ← Relationship to departments
  ...
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId)  -- ← Shows 1:N relationship
)

-- Line 146: PROPERTIES entity
CREATE TABLE properties (
  propertyId INT AUTO_INCREMENT PRIMARY KEY,
  assignedTo INT DEFAULT NULL,      -- ← Relationship to users
  departmentId INT DEFAULT NULL,    -- ← Relationship to departments
  ...
  FOREIGN KEY (assignedTo) REFERENCES users(userId),           -- ← 1:N relationship
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId)  -- ← 1:N relationship
)
```

**Your 14 Entities:**
1. **departments** (Line 39) - Primary Key: departmentId
2. **users** (Line 61) - Primary Key: userId
3. **staff_accounts** (Line 98) - Primary Key: staffId
4. **categories** (Line 135) - Primary Key: categoryId
5. **properties** (Line 146) - Primary Key: propertyId
6. **supplies** (Line 176) - Primary Key: supplyId
7. **property_requests** (Line 198) - Primary Key: requestId
8. **supplies_requests** (Line 223) - Primary Key: requestId
9. **maintenance_requests** (Line 248) - Primary Key: requestId
10. **maintenance** (Line 274) - Primary Key: maintenanceId
11. **custodian** (Line 302) - Primary Key: custodianId
12. **borrowed_items** (Line 320) - Primary Key: borrowId
13. **system_config** (Line 343) - Primary Key: configId
14. **audit_logs** (Line 356) - Primary Key: logId

---

## 📐 **NORMALIZATION (3NF Compliance)**

### **File 1: NORMALIZATION_DOCUMENTATION.md** ⭐ **MAIN DOCUMENT**
**Location:** Root directory of your project

**What's Inside:**
- ✅ Detailed 3NF analysis for ALL 14 entities
- ✅ Functional dependencies documented (173+ FDs)
- ✅ No transitive dependencies proof
- ✅ Redundancy reduction strategies (10 strategies)
- ✅ 1NF, 2NF, 3NF compliance proof

**Key Sections:**
- **Lines 17-31:** Executive summary (all 14 entities in 3NF)
- **Lines 34-65:** What is normalization (1NF, 2NF, 3NF explained)
- **Lines 549-896:** Complete 3NF analysis for all 14 entities
- **Lines 987-1150:** Functional dependencies
- **Lines 1297-1581:** Redundancy reduction strategies
- **Lines 1584-1626:** CNSC rubric scoring

**Score Evidence:** Lines 1599-1626
```
Your Score: 5/5 Points (Maximum)

14 entities in 3NF (requirement: 5+)
- All 14 are 1NF compliant ✓
- All 14 are 2NF compliant ✓
- All 14 are 3NF compliant ✓
```

---

### **3NF Examples from Documentation:**

#### **Example 1: USERS Table (3NF Compliant)**
**From:** NORMALIZATION_DOCUMENTATION.md Lines 598-627

```
USERS Entity - 3NF Compliant ✓

Direct Functional Dependencies:
- userId → firstName (Direct)
- userId → lastName (Direct)
- userId → departmentId (Direct - FK reference, not transitive)

Checking for Transitive Dependencies:
✓ Potential Issue: Does userId → departmentId → departmentName create transitive dependency?
✓ Resolution: NO violation - Department information is in separate table
  - users.departmentId is a foreign key
  - Department details stored in departments table
  - This is proper normalization via referencing

3NF Compliance: ✓ No transitive dependencies
```

#### **Example 2: PROPERTIES Table (3NF Compliant)**
**From:** NORMALIZATION_DOCUMENTATION.md Lines 660-698

```
PROPERTIES Entity - 3NF Compliant ✓

Checking for Transitive Dependencies:
✓ Issue 1: Does propertyId → assignedTo → user details create transitive dependency?
  Resolution: NO - assignedTo is FK to users.userId (proper referencing)

✓ Issue 2: Does propertyId → departmentId → department details create transitive dependency?
  Resolution: NO - departmentId is FK to departments (proper separation)

3NF Compliance: ✓ All foreign keys properly reference other tables
```

---

## 🎯 **FOR YOUR PRESENTATION**

### **What to Open:**

1. **For ERD Criterion:**
   - Open: `ERD_DOCUMENTATION.md` (show on screen)
   - Open: `teamcruzim_database.sql` (show actual code)
   - **Say:** "Here are our 14 entities with relationships"
   - Point to FOREIGN KEY lines in SQL

2. **For Normalization Criterion:**
   - Open: `NORMALIZATION_DOCUMENTATION.md` (show on screen)
   - **Say:** "All 14 entities are in 3rd Normal Form"
   - Show specific example: Lines 598-627 (users table 3NF analysis)
   - Show functional dependencies: Lines 987-1150

---

## 📝 **QUICK TALKING POINTS**

### **ERD (Criterion 1):**
**Opening Statement:**
> "Our system has **14 entities** - departments, users, properties, supplies, and 10 more. Here's the ERD documentation showing all relationships."

**Show ERD_DOCUMENTATION.md:**
- Point to entity list (Lines 1-82)
- Show relationship example: "departments has many users (1:N)"

**Show teamcruzim_database.sql:**
- Point to Line 91: `FOREIGN KEY (departmentId) REFERENCES departments(departmentId)`
- **Say:** "This foreign key creates the 1:N relationship"

**Cardinality Examples:**
- **1:N** - One department has many users
- **1:N** - One user can have many property requests
- **M:N** - Properties can be borrowed by multiple users over time (via borrowed_items)

**Participation:**
- **Optional:** `assignedTo INT DEFAULT NULL` - property may not be assigned
- **Mandatory:** `itemName VARCHAR(200) NOT NULL` - property must have name

---

### **Normalization (Criterion 2):**
**Opening Statement:**
> "All 14 entities are normalized to 3rd Normal Form. Let me show you the documentation and proof."

**Show NORMALIZATION_DOCUMENTATION.md:**
- Point to Lines 17-31: "All 14 entities in 3NF summary"
- Show specific example: Lines 598-627 (users table analysis)

**Explain 3NF:**
> "3NF means no transitive dependencies. For example, we store departmentId in the users table, not department name. The department details are in a separate table. This prevents redundancy."

**Show Code Example:**
```sql
-- ✓ CORRECT (3NF):
users: userId, firstName, departmentId (FK)
departments: departmentId, departmentName

-- ✗ WRONG (Not 3NF):
users: userId, firstName, departmentName  -- Redundant!
```

**Key Points:**
- ✓ No duplicate data
- ✓ Foreign keys used for relationships
- ✓ 173+ functional dependencies documented
- ✓ 10 redundancy reduction strategies

---

## 🖼️ **VISUAL ERD (Optional)**

### **If Asked to Show a Diagram:**

**Option 1: Use MySQL Workbench**
1. Open MySQL Workbench
2. Connect to database `teamcruzim`
3. Database → Reverse Engineer
4. Select all tables → Execute
5. **Result:** Visual ERD diagram automatically generated!

**Option 2: Describe Structure**
```
DEPARTMENTS (1) ─────┐
                     │
                     ▼ (Many)
                   USERS (1) ──────────┐
                     │                 │
                     │                 ▼ (Many)
                     ▼ (Many)      PROPERTIES
                PROPERTY_REQUESTS     │
                                      │
                                      ▼ (Many)
                              BORROWED_ITEMS
```

**Say:** "We have the full ERD documented in ERD_DOCUMENTATION.md with all relationships, cardinality, and constraints."

---

## ✅ **PRESENTATION CHECKLIST**

**Before Presentation:**
- [x] ERD_DOCUMENTATION.md exists ✓
- [x] NORMALIZATION_DOCUMENTATION.md exists ✓
- [x] teamcruzim_database.sql has all 14 tables ✓
- [x] All foreign keys defined ✓
- [x] All 14 entities in 3NF ✓

**During Presentation:**
- [ ] Open ERD_DOCUMENTATION.md
- [ ] Open NORMALIZATION_DOCUMENTATION.md
- [ ] Open teamcruzim_database.sql
- [ ] Show foreign key examples
- [ ] Explain 3NF with users/departments example
- [ ] Point to score evidence in docs

---

## 🎬 **DEMO SCRIPT**

### **When Asked About ERD:**
1. **Say:** "I have complete ERD documentation. Let me show you."
2. Open `ERD_DOCUMENTATION.md`
3. **Say:** "Here are our 14 entities and 20+ relationships"
4. Open `teamcruzim_database.sql` Line 91
5. **Say:** "See this FOREIGN KEY? That's the relationship between users and departments"
6. **Conclude:** "All relationships have proper cardinality and participation constraints"

### **When Asked About Normalization:**
1. **Say:** "All 14 entities are in 3rd Normal Form. Here's the documentation."
2. Open `NORMALIZATION_DOCUMENTATION.md` Line 598
3. **Say:** "Look at the users table analysis - no transitive dependencies"
4. **Explain:** "We use foreign keys to departments instead of storing department name directly"
5. **Show code:** Point to `departmentId` FK in users table
6. **Conclude:** "This eliminates redundancy - department info stored once, referenced everywhere"

---

## 📊 **SCORE SUMMARY**

### **ERD (Criterion 1):**
- **Requirement:** 5+ entities for full marks
- **Your System:** 14 entities
- **Score:** 5/5 ✓

**Evidence Files:**
- ERD_DOCUMENTATION.md (Lines 844-891)
- teamcruzim_database.sql (Lines 39-370)

---

### **Normalization (Criterion 2):**
- **Requirement:** 5+ entities in 3NF for full marks
- **Your System:** 14 entities all in 3NF
- **Score:** 5/5 ✓

**Evidence Files:**
- NORMALIZATION_DOCUMENTATION.md (Lines 1599-1626)
- teamcruzim_database.sql (shows proper FK usage)

---

## 🎯 **FINAL ANSWER TO YOUR QUESTION**

**Q: "Where can I find the ERD and normalization in my code?"**

**A: You have TWO comprehensive documentation files:**

1. **ERD_DOCUMENTATION.md** - 1,063 lines of ERD analysis
   - All 14 entities
   - All 20+ relationships
   - Cardinality and participation
   - Code references

2. **NORMALIZATION_DOCUMENTATION.md** - 2,061 lines of normalization proof
   - All 14 entities in 3NF
   - 173+ functional dependencies
   - No transitive dependencies proof
   - Redundancy reduction strategies

**Plus the actual implementation:**
3. **teamcruzim_database.sql** - Lines 39-370
   - CREATE TABLE statements for all 14 entities
   - FOREIGN KEY definitions showing relationships
   - PRIMARY KEY definitions
   - Proper constraints and indexes

**You're fully prepared!** 🌟

---

## 📞 **IF ASKED SPECIFIC QUESTIONS**

**Q: "Show me your ERD."**
**A:** "Open ERD_DOCUMENTATION.md and teamcruzim_database.sql"

**Q: "How many entities do you have?"**
**A:** "14 entities - here they are in teamcruzim_database.sql lines 39-370"

**Q: "Are they normalized?"**
**A:** "Yes, all 14 are in 3NF - see NORMALIZATION_DOCUMENTATION.md"

**Q: "Show me a relationship."**
**A:** "Open teamcruzim_database.sql Line 91 - this FOREIGN KEY creates the users-departments relationship"

**Q: "How do you know it's 3NF?"**
**A:** "NORMALIZATION_DOCUMENTATION.md lines 598-627 proves users table has no transitive dependencies. We use FKs to reference departments, not embed department data."

---

**YOU HAVE EVERYTHING YOU NEED!** ✅🎓
