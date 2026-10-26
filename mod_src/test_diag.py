"""Exercise actual diagnostic payload with fake game messages and Unity logger."""
import ctypes
import verify_mod as V


def main():
    assert "diag_packet" in V.P.PAYLOAD_SYMBOLS, "diagnostic payload missing"
    k32 = V.ctypes.WinDLL("kernel32", use_last_error=True)
    k32.LoadLibraryExW.argtypes = [ctypes.c_wchar_p, ctypes.c_void_p, ctypes.c_uint32]
    k32.LoadLibraryExW.restype = ctypes.c_void_p
    k32.VirtualProtect.argtypes = [ctypes.c_void_p, ctypes.c_size_t, ctypes.c_uint32, ctypes.c_void_p]
    s = V.CaveSim(k32, V.P.build(open("GameAssembly.dll.bak", "rb").read()), "diag")
    logs = []
    cb = V.F(None, V.U64, V.U64)(lambda p, _mi: logs.append(s.read_str(p)))
    s.poke(s.base + V.B.GAME_SYMBOLS["unity_debug_log"],
           b"\x48\xb8" + V.struct.pack("<Q", ctypes.cast(cb, ctypes.c_void_p).value) + b"\xff\xe0")
    fn = V.F(None, ctypes.c_int, V.U64)(s.base + V.P.PAYLOAD_SYMBOLS["diag_packet"])

    def packet(tx, cmd, payload):
        msg, io, arr = s.alloc(0x30), s.alloc(0x30), s.alloc(0x20 + len(payload))
        s.w8(msg + 0x10, cmd & 255)
        s.w64(msg + (0x20 if tx else 0x18), io)
        s.w64(io + 0x10, arr)
        s.w32(io + 0x18, len(payload) if tx else 0)
        s.w64(arr + 0x18, len(payload))
        ctypes.memmove(arr + 0x20, payload, len(payload))
        before = ctypes.string_at(msg, 0x30), ctypes.string_at(io, 0x30)
        fn(tx, msg)
        assert before == (ctypes.string_at(msg, 0x30), ctypes.string_at(io, 0x30)), "logger mutated packet"
        return msg

    try:
        packet(1, -29, b"secret-password")
        packet(0, 21, b"ignored before service action")
        assert logs == [], "logging must start only with service traffic"
        packet(1, 29, bytes([4, 2, 0]))
        assert "TX" in logs[-1] and "map=1" in logs[-1] and "cmd=29" in logs[-1]
        assert "04 02 00" in logs[-1]
        packet(0, 29, bytes([4, 10]))
        assert "RX" in logs[-1] and "04 0A" in logs[-1]
        packet(0, -23, b"private-chat-text")
        assert "redacted" in logs[-1] and "private" not in logs[-1]
        n = len(logs)
        packet(1, -30, b"\x01secret")
        assert len(logs) == n, "non-service subcommand must not be dumped"
        packet(1, -30, b"\x99\x04")
        assert "99 04" in logs[-1]
        packet(1, 21, bytes(range(200)))
        assert "truncated" in logs[-1] and len(logs[-1]) < 700
        s.now += 16000
        n = len(logs)
        packet(0, 21, b"late")
        assert len(logs) == n, "receive window must expire"
        assert not any("secret" in line for line in logs)
        # Both original send queues must still receive the exact same arguments, once.
        sends = []
        send_cb = V.F(None, V.U64, V.U64, V.U64)(lambda a, b, c: sends.append((a, b, c)))
        for wrapper, target in (("diag_bg_send", "bg_zj"), ("diag_bk_send", "bk_bad")):
            s.poke(s.base + V.B.GAME_SYMBOLS[target], b"\x48\xb8" + V.struct.pack("<Q", ctypes.cast(send_cb, ctypes.c_void_p).value) + b"\xff\xe0")
            msg = packet(1, 40, b"\x00\x04")
            V.F(None, V.U64, V.U64, V.U64)(s.base + V.P.PAYLOAD_SYMBOLS[wrapper])(s.session, msg, 123)
            assert sends[-1] == (s.session, msg, 123)
        assert len(sends) == 2
        # Exercise the actual patched receive entry and its continuation.
        received = []
        recv_cb = V.F(None, V.U64, V.U64, V.U64)(lambda a, b, c: received.append((a, b, c)))
        s.poke(s.base + V.B.GAME_SYMBOLS["diag_rx_back"], b"\x48\xb8" + V.struct.pack("<Q", ctypes.cast(recv_cb, ctypes.c_void_p).value) + b"\xff\xe0")
        msg = packet(0, 29, b"\x04\x0a")
        V.F(None, V.U64, V.U64, V.U64)(s.base + 0x200DD0)(s.mo, msg, 321)
        assert received == [(s.mo, msg, 321)]
        V.F(None, ctypes.c_int)(s.base + V.P.PAYLOAD_SYMBOLS["diag_ui"])(10)
        assert "UI map=1 type=10" in logs[-1]
        print("PASS: actual logger: TX/RX, map, privacy, bounds, expiry, packets unchanged")
    finally:
        s.close()


if __name__ == "__main__":
    main()
