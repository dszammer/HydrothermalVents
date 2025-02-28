@echo off
setlocal

set PASSED_COUNT=0
set FAILED_COUNT=0

echo [================] Running HydrothermalVentsAcceptanceTests 
echo [----------------] Running 3 tests from HydrothermalVentsAcceptanceTests
echo [  RUN           ] Small example
..\HydrothermalVents\bin\Release\net6.0\HydrothermalVents.exe -i "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testin_short.txt" -o "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testout_short.txt" -d -q

python %~dp0check_output_file.py %~dp0testout_short.txt %~dp0reference_short.txt
if %errorlevel%==0 (
  
    echo [     PASSED     ]
    set /a PASSED_COUNT+=1
) else (

    echo [     FAILED     ]
    set /a FAILED_COUNT+=1
)

echo [  RUN           ] Full input
..\HydrothermalVents\bin\Release\net6.0\HydrothermalVents.exe -i "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testin_full.txt" -o "..\..\..\..\..\HydrothermalVentsAcceptanceTests\testout_full.txt" -d -q

python %~dp0check_output_file.py %~dp0testout_full.txt %~dp0reference_full.txt
if %errorlevel%==0 (
    
    echo [     PASSED     ]
    set /a PASSED_COUNT+=1
) else (

    echo [     FAILED     ]
    set /a FAILED_COUNT+=1
)

echo [----------------] Test Summary
if %FAILED_COUNT%==0 (
  
    echo [     PASSED     ] %PASSED_COUNT% Tests passed
    exit /b 0
) else (

    echo [     FAILED     ] %FAILED_COUNT%
    exit /b 1
)


