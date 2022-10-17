@echo off

set errorlevel=0

ECHO ===================================
ECHO    Removing migration
ECHO ===================================
ECHO;

:: one dir up
cd ..

:: user input
set /p "host=Host (default=localhost) : "
set /p "dbname=Database (default=myDB) : "
set /p "uname=User (default=root) : "
set /p "pass=Pass (default=root) : "

:: defaults
IF "%host%" == "" SET "host=localhost"
IF "%dbname%" == "" SET "dbname=myDB"
IF "%uname%" == "" SET "uname=root"
IF "%pass%" == "" SET "pass=root"

ECHO;
ECHO Removing migration for MySql ...
dotnet ef migrations remove -c dbSchemaContext -- "Server=%host%;Database=%dbname%;Uid=%uname%;Pwd=%pass%;"
if %errorlevel% neq 0 goto error

:: Done!!!
ECHO Done!!!
goto end

:: Error!
:error
ECHO;
ECHO;
ECHO ========================
ECHO       ERROR !!!!!
ECHO ========================
pause
EXIT /B %ERRORLEVEL%
:end
