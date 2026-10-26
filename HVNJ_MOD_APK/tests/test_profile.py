import importlib.util
import pathlib
import unittest

ROOT = pathlib.Path(__file__).resolve().parents[1]
spec = importlib.util.spec_from_file_location("profile", ROOT / "scripts/generate_profile.py")
profile = importlib.util.module_from_spec(spec)
spec.loader.exec_module(profile)


class ProfileTest(unittest.TestCase):
    def test_network_hook_uses_real_server_handler(self):
        p = profile.generate(ROOT)
        m = next((x for x in p["methods"] if x["owner"] == "GlobalMessage" and x["name"] == "onMessage"), None)
        self.assertIsNotNone(m, "NPC callback must intercept the real GlobalMessage server handler")
        # Actual APK185 handler dispatches cmd30 to MapScr.openPopup; the
        # separate ControllerTestGame simulation handler cannot open this UI.
        self.assertEqual(m["virtual_address"], 0x16FF6C8)

    def test_elf_file_offset_is_not_virtual_address(self):
        b = (ROOT / "analysis/lib/arm64-v8a/libil2cpp.so").read_bytes()
        elf = profile.Elf(b)
        self.assertEqual(elf.virtual_for_file(0x178F3C0), 0x17933C0)
        self.assertNotEqual(elf.virtual_for_file(0x178F3C0), 0x178F3C0)
        with self.assertRaises(ValueError):
            elf.virtual_for_file(len(b) + 4096)

    def test_profile_guards_real_function_entry(self):
        p = profile.generate(ROOT)
        m = next(x for x in p["methods"] if x["owner"] == "MapScr" and x["name"] == "update")
        self.assertEqual(m["file_offset"], 0x178F3C0)
        self.assertEqual(m["virtual_address"], 0x17933C0)
        b = (ROOT / "analysis/lib/arm64-v8a/libil2cpp.so").read_bytes()
        self.assertEqual(bytes.fromhex(m["guard"]), b[m["file_offset"]:m["file_offset"] + 16])
        self.assertEqual(p["apk_sha256"], "2781a4fe636ea3ba52ea73f7b9c952847dd23e1b7e9bd5d7d6df0f403bd4ec0a")


if __name__ == "__main__":
    unittest.main()
