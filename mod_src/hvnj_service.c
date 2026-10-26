/* Box/Upgrade shortcuts: use the server's NPC handshake, never fake an open UI.
 * NPC ids/menu values are observed in the 20261026-103032 map38 trace.
 * Calls run on the game's main thread. Only this request's empty cmd40 dialogue
 * acknowledgement is consumed, since its default handler needs a selected NPC.
 */
typedef unsigned short wchar;
#define AT(p,o,T) (*(T*)((char*)(p)+(o)))
extern void* mb_TypeInfo;
extern void* lj_cmy(void*);
extern void lj_cor(void*, int, void*);
extern void lj_menu(void*, int, int, int, void*);
extern void hw_cdt(void*, void*);
extern void* il2cpp_string_new_utf16(const wchar*, int);
extern void unity_debug_log(void*, void*);
extern void (*imp_GetSystemTimeAsFileTime)(unsigned long long*);
static int phase, target, npc, origin_map, own_send;
static long long deadline, stale_until, busy_notice;
static int stale_type;
static long long manual_until;
static int manual_kind;

static long long clock_ms(void)
{
    unsigned long long ft;
    imp_GetSystemTimeAsFileTime(&ft);
    return (long long)(ft / 10000);
}
static int current_map(void)
{
    void* k = mb_TypeInfo;
    void* st;
    if ((unsigned long long)k < 0x10000 || ((unsigned long long)k & 7)) return -1;
    st = AT(k, 0xB8, void*);
    return st ? AT(st, 0x5C, short) : -1;
}
static void* str(const wchar* text)
{
    int n = 0;
    while (text[n]) n++;
    return il2cpp_string_new_utf16(text, n);
}
static void note(const wchar* text)
{
    unity_debug_log(str(text), 0);
}
static void fail(long long now, const wchar* text)
{
    stale_type = target;
    stale_until = now + 5000;
    phase = 0;
    note(L"[HVNJ-DIAG] SERVICE cancelled-or-timeout");
    hw_cdt(str(text), 0);
}
void service_reset(void)
{
    phase = 0;
    stale_until = 0;
    own_send = 0;
    manual_until = 0;
}
void service_open(int type)
{
    void* session;
    long long now = clock_ms();
    if (type != 4 && type != 10) return;
    if (phase || now < stale_until) return;
    if (now < manual_until) {
        hw_cdt(str(L"Đang chờ NPC đang chọn. Hãy đợi phản hồi rồi bấm lại."), 0);
        return;
    }
    session = lj_cmy(0);
    if (!session || !AT(session, 0x10, void*) || current_map() < 0) return;
    target = type;
    npc = type == 4 ? 5 : 6;
    origin_map = current_map();
    phase = 1;
    deadline = now + 5000;
    note(type == 4 ? L"[HVNJ-DIAG] SERVICE request-box NPC5" : L"[HVNJ-DIAG] SERVICE request-upgrade NPC6");
    own_send = 1;
    lj_cor(session, npc, 0);
    own_send = 0;
}
int service_tick(long long now)
{
    void* session;
    if (!phase) return 0;
    if (current_map() != origin_map) {
        fail(now, L"Đã đổi map. Hãy bấm mở dịch vụ lại khi đứng yên.");
        return 0;
    }
    if (now >= deadline) {
        fail(now, L"Server chưa cho mở dịch vụ tại đây. Hãy đến đúng NPC rồi thử lại.");
        return 0;
    }
    if (phase == 2) {
        session = lj_cmy(0);
        if (!session || !AT(session, 0x10, void*)) {
            fail(now, L"Chưa kết nối tới server.");
            return 0;
        }
        phase = 3;
        deadline = now + 5000;
        note(L"[HVNJ-DIAG] SERVICE select-menu-0-option-0");
        own_send = 1;
        lj_menu(session, npc, 0, 0, 0);
        own_send = 0;
    }
    return 1;
}
/* cmd40 has no request id: never allow a second NPC request to overlap this one.
 * Return 1 to the send wrapper to suppress only the overlapping NPC packet. */
int service_sent(void* msg)
{
    int cmd;
    long long now;
    if (!msg || own_send) return 0;
    cmd = AT(msg, 0x10, signed char);
    if (cmd != 40 && cmd != 29 && cmd != 47) return 0;
    now = clock_ms();
    if (!phase && now >= stale_until) {
        manual_until = now + 5000;
        manual_kind = cmd == 40 ? 1 : 2;
        return 0;
    }
    if (now >= busy_notice) {
        busy_notice = now + 2000;
        note(L"[HVNJ-DIAG] SERVICE blocked-overlapping-NPC-request");
        hw_cdt(str(L"Đang chờ dịch vụ trước. Hãy chờ vài giây rồi chọn NPC lại."), 0);
    }
    return 1;
}
int service_receive(void* msg)
{
    int cmd, ui = -1, pos;
    long long now;
    void* reader;
    void* arr;
    unsigned long long len;
    if (!msg || (!phase && !stale_until && !manual_until)) return 0;
    cmd = AT(msg, 0x10, signed char);
    if (cmd != 40 && cmd != 30) return 0;
    if (cmd == 30) {
        reader = AT(msg, 0x18, void*);
        arr = reader ? AT(reader, 0x10, void*) : 0;
        if (!arr) return 0;
        len = AT(arr, 0x18, unsigned long long);
        pos = AT(reader, 0x18, int);
        if (len > 0x1000000 || pos < 0 || (unsigned long long)pos >= len) return 0;
        ui = AT(arr, 0x20 + pos, signed char);
    }
    now = clock_ms();
    if (!phase) {
        if ((cmd == 40 && manual_kind == 1) || (cmd == 30 && manual_kind == 2)) manual_until = 0;
        return now < stale_until && (cmd == 40 || ui == stale_type);
    }
    if (current_map() != origin_map || now >= deadline) {
        if (cmd == 40 || ui == target) {
            fail(now, L"Yêu cầu mở dịch vụ đã hết hạn hoặc nhân vật đã đổi map.");
            return 1;
        }
        return 0;
    }
    if (cmd == 40 && (phase == 1 || phase == 2)) {
        phase = 2;
        note(L"[HVNJ-DIAG] SERVICE NPC-ack");
        return 1;
    }
    if (cmd == 30 && phase == 3 && ui == target) {
        note(L"[HVNJ-DIAG] SERVICE server-approved-open");
        service_reset();
        return 0; /* Original cmd30 handler reads the byte and opens the panel. */
    }
    return 0;
}
