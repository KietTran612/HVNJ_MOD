param([switch]$Download)
$ErrorActionPreference='Stop'
$toolRoot=Join-Path (Split-Path $PSScriptRoot -Parent) 'tools'
New-Item -ItemType Directory -Force $toolRoot | Out-Null
if ($Download) {
  Invoke-WebRequest 'https://dl.google.com/android/repository/repository2-1.xml' -OutFile "$toolRoot/repository.xml"
  Invoke-WebRequest 'https://api.adoptium.net/v3/assets/latest/17/hotspot?architecture=x64&image_type=jdk&os=windows' -OutFile "$toolRoot/jdk-release.json"
  $jdkPackage=(Get-Content "$toolRoot/jdk-release.json" | ConvertFrom-Json)[0].binary.package
  $downloads=@(
    @('https://dl.google.com/android/repository/android-ndk-r29-windows.zip','ndk.zip'),
    @('https://dl.google.com/android/repository/build-tools_r36_windows.zip','build-tools.zip'),
    @('https://dl.google.com/android/repository/cmake-3.31.6-windows.zip','cmake.zip'),
    @($jdkPackage.link,'jdk.zip'),
    @('https://github.com/iBotPeaches/Apktool/releases/download/v3.0.3/apktool_3.0.3.jar','apktool.jar'))
  foreach ($entry in $downloads) {if (!(Test-Path "$toolRoot/$($entry[1])")) {Invoke-WebRequest $entry[0] -OutFile "$toolRoot/$($entry[1])"}}
}
# XML checksums supplied by Google (SHA1), SHA256 from Adoptium and GitHub.
[xml]$repository=Get-Content "$toolRoot/repository.xml"
foreach ($entry in @(@('ndk;29.0.14206865','ndk.zip'),@('build-tools;36.0.0','build-tools.zip'),@('cmake;3.31.6','cmake.zip'))) {
  $package=$repository.SelectNodes('//*[local-name()="remotePackage"]') | Where-Object {$_.path -eq $entry[0]}
  $archive=$package.archives.archive | Where-Object {$_.'host-os' -eq 'windows'}
  $expected=[string]$archive.complete.checksum
  if ((Get-FileHash "$toolRoot/$($entry[1])" -Algorithm SHA1).Hash -ne $expected) {throw "Google archive checksum mismatch: $($entry[1])"}
}
$jdkPackage=(Get-Content "$toolRoot/jdk-release.json" | ConvertFrom-Json)[0].binary.package
if ((Get-FileHash "$toolRoot/jdk.zip" -Algorithm SHA256).Hash -ne $jdkPackage.checksum) {throw 'JDK checksum mismatch'}
if ((Get-FileHash "$toolRoot/apktool.jar" -Algorithm SHA256).Hash -ne 'dbf930b076c6b9be08d57c449cacefc3bdd6b71ebd59b3066fc0e1f5b14f9423') {throw 'Apktool checksum mismatch'}
foreach ($entry in @(@('ndk.zip','ndk'),@('build-tools.zip','sdk-build-tools'),@('cmake.zip','cmake'),@('jdk.zip','jdk'))) {
 if (!(Test-Path "$toolRoot/$($entry[1])")) {Expand-Archive -LiteralPath "$toolRoot/$($entry[0])" -DestinationPath "$toolRoot/$($entry[1])"}
}
$ndk="$toolRoot/ndk/android-ndk-r29"; $jdk=(Get-ChildItem "$toolRoot/jdk" -Directory | Select-Object -First 1).FullName
$bin="$ndk/toolchains/llvm/prebuilt/windows-x86_64/bin"
$bt="$toolRoot/sdk-build-tools/android-16"
$tc=[ordered]@{ndk=$ndk;clang="$bin/clang.exe";clangxx="$bin/clang++.exe";cmake="$toolRoot/cmake/bin/cmake.exe";ninja="$toolRoot/cmake/bin/ninja.exe";jdk=$jdk;java="$jdk/bin/java.exe";keytool="$jdk/bin/keytool.exe";apktool="$toolRoot/apktool.jar";smali="$toolRoot/apktool.jar";apksigner="$bt/lib/apksigner.jar";zipalign="$bt/zipalign.exe";aapt="$bt/aapt.exe"}
foreach ($path in $tc.Values) {if (!(Test-Path $path)) {throw "Tool missing: $path"}}
$tc | ConvertTo-Json | Set-Content "$toolRoot/toolchain.json"
$provenance=[ordered]@{ndk='Google Android NDK r29 29.0.14206865';build_tools='Google Android build-tools 36.0.0';cmake='Google SDK CMake 3.31.6';jdk=$jdkPackage.link;apktool='https://github.com/iBotPeaches/Apktool/releases/tag/v3.0.3';hashes=@{}}
foreach ($archive in Get-ChildItem "$toolRoot/*.zip","$toolRoot/apktool.jar") {$provenance.hashes[$archive.Name]=(Get-FileHash $archive.FullName -Algorithm SHA256).Hash.ToLower()}
$provenance | ConvertTo-Json -Depth 5 | Set-Content "$toolRoot/provenance.json"
Write-Output "$toolRoot/toolchain.json"
