"""Rebuild only the bootstrap DEX; preserve original resources and asset bytes."""
import argparse, hashlib, json, os, re, subprocess, zipfile
from pathlib import Path, PurePosixPath
ROOT=Path(__file__).resolve().parents[1]
INPUT_SHA256='2781a4fe636ea3ba52ea73f7b9c952847dd23e1b7e9bd5d7d6df0f403bd4ec0a'
ACTIVITY='com/google/firebase/MessagingUnityPlayerActivity.smali'
def verify_input(path):
 with open(path,'rb') as stream:digest=hashlib.file_digest(stream,'sha256').hexdigest()
 if digest!=INPUT_SHA256: raise ValueError('Original APK SHA256 mismatch: '+digest)
 return digest
def validate_entry(name):
 if '\\' in name or ':' in name or name.startswith('/') or '..' in PurePosixPath(name).parts: raise ValueError('Unsafe ZIP path: '+name)
def signature(name):
 return bool(re.fullmatch(r'META-INF/[^/]+\.(?:SF|RSA|DSA|EC|MF)',name,re.I))
def verify_badging(badging):
 line=next((s for s in badging.splitlines() if s.startswith('package:')),'')
 for field,value in [('name','com.g4m.hocvienninja'),('versionCode','128'),('versionName','1.8.5')]:
  if f"{field}='{value}'" not in line:raise ValueError('Unexpected APK identity: '+line)
def repack(source,target,dex,library):
 if Path(source).resolve()==Path(target).resolve():raise ValueError('Output must differ from input')
 with zipfile.ZipFile(source) as src,zipfile.ZipFile(target,'w') as dst:
  if 'classes.dex' not in src.namelist():raise ValueError('Input lacks primary classes.dex')
  seen=set()
  for info in src.infolist():
   validate_entry(info.filename)
   if info.filename in seen:raise ValueError('Duplicate ZIP path: '+info.filename)
   seen.add(info.filename)
   if signature(info.filename) or (info.filename.startswith('lib/') and not info.filename.startswith('lib/arm64-v8a/')) or info.filename=='lib/arm64-v8a/libhvnjmod.so':continue
   data=dex if info.filename=='classes.dex' else src.read(info)
   dst.writestr(info,data)
  dst.writestr('lib/arm64-v8a/libhvnjmod.so',library,compress_type=zipfile.ZIP_STORED)
def inject_loader(source):
 if '"hvnjmod"' in source:return source
 # Add a standalone helper so existing register allocation, branches and try regions stay intact.
 helper='''
.method private static hvnjLoad()V
    .locals 1
    const-string v0, "hvnjmod"
    invoke-static {v0}, Ljava/lang/System;->loadLibrary(Ljava/lang/String;)V
    return-void
.end method
'''
 pattern=r'(\.method[^\n]* onCreate\(Landroid/os/Bundle;\)V\s*\n\s*\.(?:locals|registers) \d+\s*\n)'
 source,count=re.subn(pattern,lambda m:m.group(1)+'    invoke-static {}, Lcom/google/firebase/MessagingUnityPlayerActivity;->hvnjLoad()V\n',source,count=1)
 if count!=1:raise ValueError('Expected exactly one existing activity onCreate')
 return source+helper
def run(args,env=None):
 print('Running:',Path(str(args[0])).name,flush=True)
 subprocess.run([str(x) for x in args],check=True,env=env)
def main():
 ap=argparse.ArgumentParser();ap.add_argument('--library',type=Path,required=True);args=ap.parse_args()
 source=ROOT/'HVNJ_185.apk';before=verify_input(source)
 library=args.library.read_bytes()
 if library[:4]!=b'\x7fELF' or library[4]!=2 or int.from_bytes(library[18:20],'little')!=183:raise ValueError('Expected ARM64 ELF64 library')
 tc=json.loads((ROOT/'tools/toolchain.json').read_text());java=tc['java'];jar=tc['apktool']
 env=os.environ.copy();env['JAVA_HOME']=tc['jdk'];env['PATH']=str(Path(java).parent)+os.pathsep+env['PATH']
 build=ROOT/'build/apk';build.mkdir(parents=True,exist_ok=True);decoded=build/'decoded'
 # --no-res avoids any resource table/manifest decoding and their round-trip risks.
 run([java,'-jar',jar,'d','--no-res','--force',source,'-o',decoded],env)
 matches=list(decoded.glob('smali*/'+ACTIVITY))
 if len(matches)!=1 or matches[0].relative_to(decoded).parts[0]!='smali':raise ValueError('Bootstrap activity must exist in primary classes.dex')
 matches[0].write_text(inject_loader(matches[0].read_text(encoding='utf-8')),encoding='utf-8')
 rebuilt=build/'dex-rebuilt.apk';run([java,'-jar',jar,'b',decoded,'-o',rebuilt],env)
 with zipfile.ZipFile(rebuilt) as z:dex=z.read('classes.dex')
 unsigned=build/'unsigned.apk';aligned=build/'aligned.apk';repack(source,unsigned,dex,library)
 run([tc['zipalign'],'-f','-P','16','4',unsigned,aligned],env)
 keys=ROOT/'keys';keys.mkdir(exist_ok=True);key=keys/'hvnjmod.p12'
 if not key.exists():run([tc['keytool'],'-genkeypair','-keystore',key,'-storetype','PKCS12','-storepass','hvnjmod-local','-alias','hvnjmod','-keyalg','RSA','-keysize','3072','-validity','10000','-dname','CN=HVNJ Local Mod'],env)
 out=ROOT/'output/HVNJ_185_mod_arm64.apk';out.parent.mkdir(exist_ok=True)
 run([java,'-jar',tc['apksigner'],'sign','--ks',key,'--ks-pass','pass:hvnjmod-local','--out',out,aligned],env)
 run([java,'-jar',tc['apksigner'],'verify','--verbose','--print-certs',out],env)
 run([tc['zipalign'],'-c','-P','16','-v','4',out],env)
 badging=subprocess.check_output([tc['aapt'],'dump','badging',str(out)],env=env,text=True,encoding='utf-8')
 verify_badging(badging);(build/'badging.txt').write_text(badging,encoding='utf-8')
 verify_input(source)
 with zipfile.ZipFile(source) as a,zipfile.ZipFile(out) as b:
  preserved=0
  for n in a.namelist():
   if signature(n) or n=='classes.dex' or (n.startswith('lib/') and not n.startswith('lib/arm64-v8a/')):continue
   if a.read(n)!=b.read(n):raise ValueError('Unexpected content change: '+n)
   preserved+=1
  if any(n.startswith('lib/') and not n.startswith('lib/arm64-v8a/') for n in b.namelist()):raise ValueError('Non-ARM64 native library remains')
 report={'original_sha256':before,'output_sha256':hashlib.file_digest(open(out,'rb'),'sha256').hexdigest(),'library_sha256':hashlib.sha256(library).hexdigest(),'preserved_entries':preserved,'modified':['classes.dex','lib/arm64-v8a/libhvnjmod.so'],'removed':['non-ARM64 lib entries','old signing metadata'],'verified':['apksigner','zipalign 16KB','preserved ZIP contents','original SHA256'],'runtime_tested':False}
 (out.parent/'apk-build-report.json').write_text(json.dumps(report,indent=2)+'\n');print(out)
if __name__=='__main__':main()
