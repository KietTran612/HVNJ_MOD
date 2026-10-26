import importlib.util
from pathlib import Path
import tempfile, unittest, zipfile, hashlib
tempfile.tempdir=str(Path(__file__).parents[1]/'build/test-temp')
Path(tempfile.tempdir).mkdir(parents=True,exist_ok=True)
spec=importlib.util.spec_from_file_location('pipeline',Path(__file__).parents[1]/'scripts/build_apk.py')
p=importlib.util.module_from_spec(spec); spec.loader.exec_module(p)
class ArchiveTests(unittest.TestCase):
 def test_only_intended_changes_and_input_preserved(self):
  with tempfile.TemporaryDirectory() as d:
   a,b=Path(d)/'a.apk',Path(d)/'b.apk'
   original={'classes.dex':b'dex old','assets/file':b'asset','META-INF/CERT.RSA':b'sig','META-INF/CERT.SF':b'sig','META-INF/MANIFEST.MF':b'sig','META-INF/services/ok':b'service','lib/armeabi-v7a/a.so':b'32','lib/arm64-v8a/a.so':b'64','resources.arsc':b'res'}
   with zipfile.ZipFile(a,'w') as z:
    for k,v in original.items(): z.writestr(k,v)
   before=a.read_bytes(); p.repack(a,b,b'new dex',b'new lib')
   self.assertEqual(a.read_bytes(),before)
   with zipfile.ZipFile(b) as z:
    self.assertEqual(z.read('classes.dex'),b'new dex'); self.assertEqual(z.read('lib/arm64-v8a/libhvnjmod.so'),b'new lib')
    for k in ['assets/file','resources.arsc','lib/arm64-v8a/a.so','META-INF/services/ok']: self.assertEqual(z.read(k),original[k])
    self.assertFalse(any('armeabi-v7a' in n or n.endswith('.RSA') for n in z.namelist()))
 def test_reject_same_path(self):
  with self.assertRaises(ValueError): p.repack(Path('a'),Path('a'),b'',b'')
 def test_reject_unsafe_zip_paths(self):
  for n in ['../bad','/absolute','lib/../bad','C:/bad','lib\\bad']:
   with self.subTest(n=n),self.assertRaises(ValueError): p.validate_entry(n)
 def test_wrong_input_hash(self):
  with tempfile.TemporaryDirectory() as d:
   a=Path(d)/'a';a.write_bytes(b'wrong')
   with self.assertRaises(ValueError):p.verify_input(a)
 def test_missing_dex_rejected(self):
  with tempfile.TemporaryDirectory() as d:
   a,b=Path(d)/'a.apk',Path(d)/'b.apk'
   with zipfile.ZipFile(a,'w') as z:z.writestr('assets/only',b'a')
   with self.assertRaises(ValueError):p.repack(a,b,b'dex',b'elf')
 def test_bootstrap_preserves_existing_instructions(self):
  source='.class public Lcom/google/firebase/MessagingUnityPlayerActivity;\n.super Landroid/app/Activity;\n.method protected onCreate(Landroid/os/Bundle;)V\n    .locals 2\n    invoke-super {p0, p1}, Landroid/app/Activity;->onCreate(Landroid/os/Bundle;)V\n    return-void\n.end method\n'
  patched=p.inject_loader(source)
  self.assertIn('System;->loadLibrary',patched);self.assertIn('invoke-super {p0, p1}',patched)
  self.assertEqual(p.inject_loader(patched),patched)
 def test_package_identity_rejected_on_change(self):
  good="package: name='com.g4m.hocvienninja' versionCode='128' versionName='1.8.5'\n"
  p.verify_badging(good)
  with self.assertRaises(ValueError):p.verify_badging(good.replace('128','129'))
  with self.assertRaises(ValueError):p.verify_badging(good.replace('hocvienninja','other'))
if __name__=='__main__':unittest.main()
