"""Native state-machine regression tests for the two NPC service shortcuts."""
import ctypes
import verify_mod as V


def main():
    assert "service_open" in V.P.PAYLOAD_SYMBOLS, "NPC service implementation missing"
    s = V.CaveSim(V.kernel32(), V.P.build(open("GameAssembly.dll.bak", "rb").read()), "service")
    cor, errors = [], []
    callbacks = {
        "lj_cor": V.F(None, V.U64, ctypes.c_int, V.U64)(lambda _s, npc, _mi: cor.append(npc)),
        "hw_cdt": V.F(None, V.U64, V.U64)(lambda p, _mi: errors.append(s.read_str(p))),
    }
    for name, cb in callbacks.items():
        s.poke(s.base + V.B.GAME_SYMBOLS[name], b"\x48\xb8" + V.struct.pack("<Q", ctypes.cast(cb, ctypes.c_void_p).value) + b"\xff\xe0")
    open_ = V.F(None, ctypes.c_int)(s.sym("service_open"))
    tick = V.F(ctypes.c_int, ctypes.c_int64)(s.sym("service_tick"))
    reset = V.F(None)(s.sym("service_reset"))
    receive = V.F(ctypes.c_int, V.U64)(s.sym("service_receive"))
    sent = V.F(ctypes.c_int, V.U64)(s.sym("service_sent"))

    def msg(cmd, payload=b"", tx=False):
        m, io, arr = s.alloc(0x30), s.alloc(0x30), s.alloc(0x20 + len(payload))
        s.w8(m + 0x10, cmd & 255)
        s.w64(m + (0x20 if tx else 0x18), io)
        s.w64(io + 0x10, arr)
        s.w64(arr + 0x18, len(payload))
        ctypes.memmove(arr + 0x20, payload, len(payload))
        return m

    try:
        for ui, npc in ((4, 5), (10, 6)):
            reset(); cor.clear(); s.menus.clear(); s.djd.clear(); s.set_map(68)
            open_(ui)
            assert cor == [npc] and not s.djd and not s.menus
            open_(ui); open_(10 if ui == 4 else 4)
            assert cor == [npc], "duplicate click must not interleave NPC requests"
            assert receive(msg(1, b"unrelated")) == 0
            assert receive(msg(30, bytes([ui]))) == 0, "unsolicited open must remain original"
            assert not s.menus
            assert receive(msg(40)) == 1, "own dialogue ack must not require selected NPC"
            assert not s.menus, "send the menu from frame tick, not recursively in parser"
            assert tick(s.now) == 1
            assert s.menus == [(npc, 0, 0)]
            tick(s.now + 10)
            assert len(s.menus) == 1, "menu must not be retried"
            m = msg(30, bytes([ui])); before = ctypes.string_at(m, 0x30)
            assert receive(m) == 0, "matching cmd30 must reach original UI handler"
            assert ctypes.string_at(m, 0x30) == before and tick(s.now) == 0
            assert not s.djd, "service must never fake local UI success"
        reset(); open_(4); tick(s.now + 5001)
        assert errors and receive(msg(40)) == 1, "suppress late NPC reply after timeout"
        assert receive(msg(30, b"\x04")) == 1
        assert not s.djd
        # No correlation id: serialize a manual request until old replies drain.
        assert sent(msg(40, tx=True)) == 1
        s.now += 11000
        assert sent(msg(40, tx=True)) == 0
        assert receive(msg(40)) == 0
        reset(); open_(10); receive(msg(40)); tick(s.now)
        tick(s.now + 5001)
        assert len(errors) >= 2 and len(s.menus) >= 1
        reset(); s.set_map(68); open_(4); s.set_map(38)
        assert receive(msg(40)) == 1 and tick(s.now) == 0
        reset(); s.set_map(68); open_(4); receive(msg(40)); tick(s.now)
        assert receive(msg(30)) == 0, "malformed cmd30 must not be treated as approval"
        assert tick(s.now) == 1
        reset(); cor.clear(); open_(7)
        assert not cor, "Shop must not be routed through this repair"
        reset(); open_(4)
        assert sent(msg(40, tx=True)) == 1
        assert receive(msg(40)) == 1, "old shortcut ack is still consumed"
        tick(s.now)
        assert sent(msg(29, tx=True)) == 1
        assert receive(msg(30, b"\x04")) == 0
        assert sent(msg(40, tx=True)) == 0, "manual request can start after shortcut completes"
        assert receive(msg(40)) == 0
        # Reverse order: a previously sent manual request must finish first.
        reset(); cor.clear()
        assert sent(msg(40, tx=True)) == 0
        open_(4)
        assert not cor, "shortcut must not steal an already outstanding manual NPC ack"
        assert receive(msg(40)) == 0
        open_(4)
        assert cor == [5]
        reset(); cor.clear()
        assert sent(msg(29, tx=True)) == 0
        open_(10)
        assert not cor
        assert receive(msg(30, b"\x04")) == 0
        open_(10)
        assert cor == [6]
        # Actual receive entry: consume our dialogue ack, forward server-open
        # with all original arguments; frame tick progresses even with Auto off.
        reset(); s.set_map(68); s.w8(s.statics["ca"] + 0x16, 0)
        forwarded = []
        cb = V.F(None, V.U64, V.U64, V.U64)(lambda a, b, c: forwarded.append((a, b, c)))
        s.poke(s.base + V.B.GAME_SYMBOLS["diag_rx_back"], b"\x48\xb8" + V.struct.pack("<Q", ctypes.cast(cb, ctypes.c_void_p).value) + b"\xff\xe0")
        native_receive = V.F(None, V.U64, V.U64, V.U64)(s.base + 0x200DD0)
        open_(4); s.menus.clear()
        queued = []
        queue_cb = V.F(None, V.U64, V.U64, V.U64)(lambda a, b, c: queued.append((a, b, c)))
        s.poke(s.base + V.B.GAME_SYMBOLS["bg_zj"], b"\x48\xb8" + V.struct.pack("<Q", ctypes.cast(queue_cb, ctypes.c_void_p).value) + b"\xff\xe0")
        native_send = V.F(None, V.U64, V.U64, V.U64)(s.sym("diag_bg_send"))
        native_send(s.session, msg(40, tx=True), 11)
        assert not queued, "blocked overlapping NPC packet must never enter original queue"
        other = msg(22, tx=True)
        native_send(s.session, other, 12)
        assert queued == [(s.session, other, 12)], "other packets must still forward unchanged"
        native_receive(s.mo, msg(40), 123)
        assert not forwarded
        s.qtick(0)
        assert s.menus == [(5, 0, 0)]
        m = msg(30, b"\x04")
        reader = V.U64.from_address(m + 0x18).value
        native_receive(s.mo, m, 456)
        assert forwarded == [(s.mo, m, 456)]
        assert ctypes.c_int.from_address(reader + 0x18).value == 0
        print("PASS: native NPC5/6 handshake, server UI, timeout/map change, manual NPC serialization, real receive/send hooks")
    finally:
        s.close()


if __name__ == "__main__":
    main()
