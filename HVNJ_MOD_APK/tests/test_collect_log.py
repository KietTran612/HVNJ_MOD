"""Collector boundary tests: a controlled ADB command replaces the absent USB phone."""
import pathlib
import re
import subprocess
import tempfile
import unittest

ROOT=pathlib.Path(__file__).resolve().parents[1]
tempfile.tempdir=str(ROOT/'build/test-temp')
pathlib.Path(tempfile.tempdir).mkdir(parents=True,exist_ok=True)

class CollectorTests(unittest.TestCase):
    def run_fixture(self,authorized):
        with tempfile.TemporaryDirectory() as d:
            adb=pathlib.Path(d)/'adb-fixture.cmd'
            state='device' if authorized else 'unauthorized'
            adb.write_text('@echo off\nif "%1"=="devices" (\necho List of devices attached\necho FIXTURE123 '+state+'\nexit /b 0\n)\nif "%3"=="logcat" (\necho HVNJ-MOD fixture capture\nexit /b 0\n)\nexit /b 1\n')
            return subprocess.run(['powershell.exe','-NoProfile','-ExecutionPolicy','Bypass','-File',str(ROOT/'scripts/collect_android_log.ps1'),'-AdbPath',str(adb),'-Snapshot'],capture_output=True,text=True,encoding='utf-8',errors='replace')

    def test_snapshot_saves_real_command_output(self):
        result=self.run_fixture(True)
        self.assertEqual(result.returncode,0,result.stdout+result.stderr)
        folder=pathlib.Path(re.search(r'Log folder: (.+)',result.stdout)[1].strip())
        self.assertIn('HVNJ-MOD fixture capture',(folder/'logcat.txt').read_text(encoding='utf-8-sig'))
        self.assertIn('HVNJ-MOD fixture capture',(folder/'crash.txt').read_text(encoding='utf-8-sig'))
        self.assertIn('No upload performed',(folder/'capture-info.txt').read_text(encoding='utf-8-sig'))

    def test_unauthorized_device_stops_before_capture(self):
        result=self.run_fixture(False)
        self.assertNotEqual(result.returncode,0)
        self.assertNotIn('Log folder:',result.stdout)
        self.assertIn('USB debugging',result.stdout+result.stderr)

if __name__=='__main__':unittest.main()
