"""Build the inspected APK185 ARM64 profile using the local portable toolchain."""
import argparse
import hashlib
import json
import os
from pathlib import Path
import subprocess
import urllib.request
import zipfile

ROOT=Path(__file__).resolve().parents[1]
COMMIT="31e4ab0cfc2bfa4512b4ea520786ea2403f97dfc"
SHA="4522472367e783a51579fbb45f42bb8c674043964a2183e56807a7a55e00b525"

def main():
    ap=argparse.ArgumentParser()
    ap.add_argument("--download-dobby",action="store_true")
    args=ap.parse_args()
    archive=ROOT/"third_party/dobby-2021.zip"
    dest=ROOT/"third_party/dobby-2021"
    if not archive.exists() and args.download_dobby:
        archive.parent.mkdir(parents=True,exist_ok=True)
        urllib.request.urlretrieve(f"https://codeload.github.com/jmpews/Dobby/zip/{COMMIT}",archive)
    if not archive.exists():
        raise SystemExit("Missing pinned Dobby archive: run with --download-dobby")
    if hashlib.sha256(archive.read_bytes()).hexdigest()!=SHA:
        raise SystemExit("Pinned Dobby archive hash mismatch")
    if not (dest/f"Dobby-{COMMIT}/CMakeLists.txt").exists():
        with zipfile.ZipFile(archive) as z:
            for name in z.namelist():
                if name.startswith("/") or ".." in Path(name).parts or "\\" in name or ":" in name:
                    raise SystemExit("Unsafe Dobby ZIP entry")
            z.extractall(dest)
    tc=json.loads((ROOT/"tools/toolchain.json").read_text(encoding="utf-8-sig"))
    tmp=ROOT/"build/tmp";tmp.mkdir(parents=True,exist_ok=True)
    env=os.environ.copy();env.update(TMP=str(tmp),TEMP=str(tmp))
    import sys
    subprocess.run([sys.executable,str(ROOT/"scripts/generate_profile.py")],check=True,env=env)
    build=ROOT/"build/android"
    subprocess.run([tc["cmake"],"-S",str(ROOT),"-B",str(build),"-G","Ninja",
                    "-DCMAKE_MAKE_PROGRAM="+tc["ninja"],
                    "-DCMAKE_TOOLCHAIN_FILE="+tc["ndk"]+"/build/cmake/android.toolchain.cmake",
                    "-DANDROID_ABI=arm64-v8a","-DANDROID_PLATFORM=android-25",
                    "-DANDROID_STL=c++_static","-DCMAKE_BUILD_TYPE=Release"],check=True,env=env)
    subprocess.run([tc["cmake"],"--build",str(build),"--target","hvnjmod","-j","6"],check=True,env=env)
    lib=build/"libhvnjmod.so"
    report={"apk_profile":"185-arm64-v1","dobby_commit":COMMIT,"dobby_archive_sha256":SHA,
            "library_sha256":hashlib.sha256(lib.read_bytes()).hexdigest(),"runtime_tested":False}
    (build/"native-build-report.json").write_text(json.dumps(report,indent=2)+"\n")
    print(lib)

if __name__=="__main__":main()
