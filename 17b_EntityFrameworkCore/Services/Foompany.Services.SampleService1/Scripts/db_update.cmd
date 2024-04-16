@echo off

set errorlevel=0

ECHO;
ECHO ===================================
ECHO  Installing/Updating EF core tools
ECHO ===================================

:: https://www.nuget.org/packages/dotnet-ef
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef


ECHO;
ECHO ===================================
ECHO    Update db
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


:: run
ECHO;
ECHO Updating MySql ...
dotnet ef database update -c dbSchemaContext -- "Server=%host%;Database=%dbname%;Uid=%uname%;Pwd=%pass%;"
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
