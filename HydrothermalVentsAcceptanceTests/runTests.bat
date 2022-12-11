@echo off

echo [--Runing tests--]
echo [Run-------------] Successful example
..\HydrothermalVents\bin\Release\net6.0\HydrothermalVents.exe -i "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testin.txt" -o "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testout.txt" -d 

pause

