@echo off
setlocal

echo Clean Solution:
dotnet clean ./HydrothermalVents.sln

echo Build Release
dotnet build ./HydrothermalVents.sln --configuration Release

HydrothermalVents\bin\Release\net6.0\HydrothermalVents.exe -i "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testin_short.txt" -o "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testout_short.txt" -d