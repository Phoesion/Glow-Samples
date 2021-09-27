@echo off

set errorlevel=0

ECHO ===================================
ECHO    Removing migration
ECHO ===================================
ECHO;

:: one dir up
cd ..

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
