param([string]$Serial, [switch]$Snapshot, [string]$AdbPath)
$ErrorActionPreference='Stop'
$artifactRoot=Split-Path $PSScriptRoot -Parent
if (!$AdbPath) {$AdbPath=Join-Path $artifactRoot 'tools/adb/platform-tools/adb.exe'}
if (!(Test-Path -LiteralPath $AdbPath)) {throw 'ADB missing. Use bundled tools/adb/platform-tools/adb.exe or pass -AdbPath.'}
$deviceLines=@(& $AdbPath devices)
if ($LASTEXITCODE -ne 0) {throw 'Cannot query ADB devices.'}
$available=@($deviceLines | Where-Object {$_ -match '^\S+\s+device$'} | ForEach-Object {($_ -split '\s+')[0]})
if (!$Serial) {
  if ($available.Count -ne 1) {
    $deviceLines | Write-Host
    throw 'Connect one phone with USB debugging enabled, unlock it and accept Allow USB debugging. For multiple devices use -Serial <device-id>.'
  }
  $Serial=$available[0]
}
if ($available -notcontains $Serial) {throw 'Selected device is offline or unauthorized. Unlock phone and accept USB debugging.'}
$deviceArgs=@('-s',$Serial)
$out=Join-Path $artifactRoot ('logs/'+(Get-Date -Format 'yyyyMMdd-HHmmss-fff'))
New-Item -ItemType Directory -Path $out | Out-Null
$filter=@('HVNJ-MOD:I','Unity:E','AndroidRuntime:E','DEBUG:E','*:S')
if ($Snapshot) {
  & $AdbPath @deviceArgs logcat -d -v threadtime @filter | Set-Content -Encoding UTF8 (Join-Path $out 'logcat.txt')
} else {
  # This is our own capture helper, hidden; no game process is launched/stopped.
  $captureArgs=$deviceArgs+@('logcat','-v','threadtime')+$filter
  $capture=Start-Process -FilePath $AdbPath -ArgumentList $captureArgs -WindowStyle Hidden -PassThru -RedirectStandardOutput (Join-Path $out 'logcat.txt') -RedirectStandardError (Join-Path $out 'adb-errors.txt')
  Write-Host 'CAPTURING. Open the logging APK, log in and reproduce the problem.'
  Write-Host 'When finished, return here and press Enter. The game will stay running.'
  try {Read-Host | Out-Null} finally {
    if (!$capture.HasExited) {Stop-Process -Id $capture.Id; $capture.WaitForExit()}
  }
}
& $AdbPath @deviceArgs logcat -b crash -d -v threadtime AndroidRuntime:E DEBUG:E '*:S' | Set-Content -Encoding UTF8 (Join-Path $out 'crash.txt')
$remote='/sdcard/Android/data/com.g4m.hocvienninja/files/'
foreach ($name in @('hvnj-mod.log','hvnj-mod.log.previous')) {
  $probe=& $AdbPath @deviceArgs shell test -f ($remote+$name) 2>&1
  if ($LASTEXITCODE -eq 0) {
    & $AdbPath @deviceArgs pull ($remote+$name) (Join-Path $out $name)
    if ($LASTEXITCODE -ne 0) {Write-Warning "Cannot pull $name; logcat capture is still saved."}
  }
}
"Build marker: 185-arm64-log-v5`r`nCaptured locally. No upload performed." | Set-Content -Encoding UTF8 (Join-Path $out 'capture-info.txt')
Write-Host "Log folder: $out"
Write-Host 'Tell Codex that capture is finished; these files are in the project logs folder.'
