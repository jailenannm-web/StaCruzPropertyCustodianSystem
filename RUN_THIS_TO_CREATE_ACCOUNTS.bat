@echo off
echo.
echo ========================================================================
echo          CREATE TEST ACCOUNTS IN MYSQL DATABASE
echo ========================================================================
echo.
echo This will create 3 test accounts in your teamcruzim database:
echo   - superadmin / SuperAdmin@123
echo   - admin / Admin@123
echo   - staff / Staff@123
echo.
echo You will need to enter your MySQL root password.
echo.
pause
echo.
echo Searching for MySQL...
echo.

REM Try to find MySQL
set MYSQL_PATH=mysql
where mysql >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo MySQL not in PATH, checking common locations...
    
    if exist "C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe" (
        set MYSQL_PATH=C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe
        echo Found: MySQL Server 8.0
    ) else if exist "C:\Program Files\MySQL\MySQL Server 8.4\bin\mysql.exe" (
        set MYSQL_PATH=C:\Program Files\MySQL\MySQL Server 8.4\bin\mysql.exe
        echo Found: MySQL Server 8.4
    ) else if exist "C:\Program Files\MySQL\MySQL Server 5.7\bin\mysql.exe" (
        set MYSQL_PATH=C:\Program Files\MySQL\MySQL Server 5.7\bin\mysql.exe
        echo Found: MySQL Server 5.7
    ) else if exist "C:\xampp\mysql\bin\mysql.exe" (
        set MYSQL_PATH=C:\xampp\mysql\bin\mysql.exe
        echo Found: XAMPP MySQL
    ) else if exist "C:\wamp64\bin\mysql\mysql8.0.27\bin\mysql.exe" (
        set MYSQL_PATH=C:\wamp64\bin\mysql\mysql8.0.27\bin\mysql.exe
        echo Found: WAMP MySQL
    ) else (
        echo.
        echo ========================================================================
        echo   ERROR: MySQL not found!
        echo ========================================================================
        echo.
        echo MySQL is not installed or cannot be found automatically.
        echo.
        echo Please use ONE of these methods instead:
        echo.
        echo METHOD 1: MySQL Workbench (RECOMMENDED - EASIEST)
        echo   1. Open MySQL Workbench
        echo   2. File ^> Open SQL Script
        echo   3. Select: CREATE_ACCOUNTS_NOW.sql
        echo   4. Click the lightning bolt to run
        echo.
        echo METHOD 2: Copy-Paste
        echo   1. Open CREATE_ACCOUNTS_NOW.sql in Notepad
        echo   2. Copy all content (Ctrl+A, Ctrl+C^)
        echo   3. Open MySQL Workbench
        echo   4. Paste in query window (Ctrl+V^)
        echo   5. Run (lightning bolt icon^)
        echo.
        echo See STEP_BY_STEP_CREATE_ACCOUNTS.txt for detailed instructions!
        echo.
        pause
        exit /b 1
    )
)

echo.
echo Using MySQL at: %MYSQL_PATH%
echo.
echo Creating accounts in database 'teamcruzim'...
echo Enter your MySQL root password when prompted:
echo.

"%MYSQL_PATH%" -u root -p teamcruzim < CREATE_ACCOUNTS_NOW.sql

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================================================
    echo   SUCCESS! Test accounts have been created!
    echo ========================================================================
    echo.
    echo You can now login with these credentials:
    echo.
    echo   1. SuperAdmin
    echo      Username: superadmin
    echo      Password: SuperAdmin@123
    echo.
    echo   2. Admin
    echo      Username: admin
    echo      Password: Admin@123
    echo.
    echo   3. Staff
    echo      Username: staff
    echo      Password: Staff@123
    echo.
    echo ========================================================================
    echo   NEXT STEP: Run your application and test login!
    echo ========================================================================
    echo.
) else (
    echo.
    echo ========================================================================
    echo   CREATION FAILED
    echo ========================================================================
    echo.
    echo Possible problems:
    echo   - Wrong MySQL password
    echo   - Database 'teamcruzim' does not exist
    echo   - MySQL server is not running
    echo   - Tables don't exist yet (need to run schema first^)
    echo.
    echo SOLUTIONS:
    echo.
    echo 1. Make sure MySQL is running
    echo 2. Create database if needed:
    echo    mysql -u root -p
    echo    CREATE DATABASE teamcruzim;
    echo.
    echo 3. Create tables if needed:
    echo    mysql -u root -p teamcruzim ^< teamcruzim_database.sql
    echo.
    echo 4. Use MySQL Workbench instead (see STEP_BY_STEP_CREATE_ACCOUNTS.txt^)
    echo.
)

pause
