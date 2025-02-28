@echo off
setlocal

echo clean Solution:
dotnet clean ./HydrothermalVents.sln

echo build Release
dotnet build ./HydrothermalVents.sln --configuration Release

echo run unit tests...
dotnet test ./HydrothermalVents.sln

echo run integration tests...
./HydrothermalVentsAcceptanceTests/runTests.bat