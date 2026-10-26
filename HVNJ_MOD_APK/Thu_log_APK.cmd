@echo off
setlocal
powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0scripts\collect_android_log.ps1" %*
echo.
pause
