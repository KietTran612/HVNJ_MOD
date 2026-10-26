# Android ARM64 build

All tools are portable and local to `tools/`. Run `scripts/prepare_tools.ps1 -Download` once to fetch official Google Android NDK r29, build-tools 36.0.0, SDK CMake 3.31.6, Eclipse Temurin JDK 17 and Apktool 3.0.3. Google repository checksums and publisher SHA256 values are checked before extraction. Exact installed paths are written to `tools/toolchain.json`; downloaded archive SHA256 values and sources are recorded in `tools/provenance.json`. Tool licenses remain inside their distributions.

Build `libhvnjmod.so` using the root CMake project, Android NDK toolchain, `ANDROID_ABI=arm64-v8a`, `ANDROID_PLATFORM=android-25`. The native build must support 16KB pages. Then run from the repository root:

Use `python HVNJ_MOD_APK/scripts/build_native.py --download-dobby` to download the pinned hook dependency and build the native library. The native profile generator requires the current APK's analysis/Cpp2IL outputs already present in this artifact folder.

The root CMake project pins Dobby commit `31e4ab0cfc2bfa4512b4ea520786ea2403f97dfc` under `third_party/dobby-2021`, from the upstream codeload archive with SHA256 `4522472367e783a51579fbb45f42bb8c674043964a2183e56807a7a55e00b525`. No Dobby source changes are needed; CMake preincludes `android/log.h` for NDK29 compatibility.

```powershell
python HVNJ_MOD_APK/scripts/build_apk.py --library HVNJ_MOD_APK/build/android/libhvnjmod.so
```

The script verifies the original APK SHA256, rebuilds its primary DEX with one startup `System.loadLibrary("hvnjmod")` call, preserves existing activity instructions, and copies the original archive entries directly. Resources, manifest, assets, other DEX files and existing ARM64 libraries retain their contents. Original signing files and non-ARM64 native libraries are removed. Apktool resource rebuilding is disabled. It aligns the new APK for 16KB pages and signs it with a generated local RSA key, then verifies the signature, alignment, retained archive contents and original input hash.

Output: `output/HVNJ_185_mod_arm64.apk`, plus `output/apk-build-report.json`. The input `HVNJ_185.apk` is never overwritten. The local `keys/hvnjmod.p12` key uses the documented local build password `hvnjmod-local`; this is a development identity, not a publisher identity. Keys and generated tools/build/output directories must remain excluded from Git and must not be uploaded.

Run archive/bootstrap tests with:

```powershell
python -m unittest discover -s HVNJ_MOD_APK/tests -p test_apk_pipeline.py
```

A valid signed archive does not establish Android startup, SDK login or gameplay compatibility. Those require a suitable ARM64 device/emulator. A new signing key prevents installing this as an update over the publisher-signed app. This build does not install or uninstall any application.
