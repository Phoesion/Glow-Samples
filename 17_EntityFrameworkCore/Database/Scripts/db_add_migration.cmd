@echo off

set errorlevel=0

ECHO ===================================
ECHO  Installing/Updating EF core tools
ECHO ===================================
ECHO;
:: https://www.nuget.org/packages/dotnet-ef
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef


ECHO;
ECHO ====================================
ECHO    Adding migration %id%
ECHO ====================================
ECHO;

:: one dir up
cd ..

:: user input
set /p "id=Enter migration name : "

ECHO;
ECHO Adding migration for MySql ...
dotnet ef migrations add %id% -c dbSchemaContext -o "Migrations" -- "Server=localhost;Database=glow;Uid=root;Pwd=root;"
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
