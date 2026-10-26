$ErrorActionPreference = 'Stop'
$gameRoot = Split-Path -Parent $PSScriptRoot
$gameExe = Join-Path $gameRoot 'Hoc Vien Ninja.exe'
if (Get-Process -Name 'Hoc Vien Ninja' -ErrorAction SilentlyContinue) {
    throw 'Close the game before starting this diagnostic session.'
}
$logDir = Join-Path $gameRoot 'diagnostic-logs'
New-Item -ItemType Directory -Force -Path $logDir | Out-Null
$stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
$fullLog = Join-Path $logDir ($stamp + '.full.log')
$serviceLog = Join-Path $logDir ($stamp + '.service.log')
Write-Host 'Test each service at the real NPC, then outside the village. Close the game afterwards.'
Write-Host 'Only send the .service.log file; the full Unity log is local.'
Start-Process -FilePath $gameExe -WorkingDirectory $gameRoot -ArgumentList @('-logFile', ('"' + $fullLog + '"')) -Wait
if (-not (Test-Path -LiteralPath $fullLog)) { throw "Game did not create $fullLog" }
$records = @(Select-String -LiteralPath $fullLog -SimpleMatch '[HVNJ-DIAG]' | ForEach-Object { $_.Line })
$records | Set-Content -Encoding UTF8 -LiteralPath $serviceLog
Write-Host ("Captured {0} service records. Send this file:" -f $records.Count)
Write-Host $serviceLog
if ($records.Count -eq 0) { Write-Warning 'No diagnostic records. Check that the diagnostic GameAssembly.dll is installed and a service was used.' }
