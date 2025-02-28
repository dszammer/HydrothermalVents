@echo off
setlocal

echo Clean Solution:
dotnet clean ./HydrothermalVents.sln

echo Build Release
dotnet build ./HydrothermalVents.sln --configuration Release