@echo off &SETLOCAL

pushd "Foompany.Services.HelloWorld"

ECHO;
ECHO -----------------------------------------------------------------
ECHO     Publishing Foompany.Services.HelloWorld for linux-x64 ...
ECHO -----------------------------------------------------------------
CALL dotnet publish --configuration Debug --runtime linux-x64 --no-self-contained -o "bin\Debug\publish\linux-x64"

ECHO;
ECHO;
ECHO -----------------------------------------------------------------
ECHO           Building helloworldsample:dev image
ECHO -----------------------------------------------------------------
CALL docker build -f "Dockerfile" --force-rm -t helloworldsample:dev "bin\Debug\publish\linux-x64"

popd

ECHO;
ECHO -------------
ECHO     Done...
ECHO -------------
pause