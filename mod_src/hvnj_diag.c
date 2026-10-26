/* Temporary service diagnostics. Observe messages; never modify or resend them.
 * Unity writes [HVNJ-DIAG] records to the -logFile selected by the launcher.
 * Only service TX payloads are allowed. RX outside the allowlist is header-only.
 */
typedef unsigned short wchar;
#define AT(p,o,T) (*(T*)((char*)(p)+(o)))
extern void* mb_TypeInfo;
extern void* il2cpp_string_new_utf16(const wchar*, int);
extern void unity_debug_log(void*, void*);
extern void (*imp_GetSystemTimeAsFileTime)(unsigned long long*);
extern void bg_zj(void*, void*, void*);
extern void bk_bad(void*, void*, void*);
extern int service_sent(void*);
long _InterlockedIncrement(long volatile*);
#pragma intrinsic(_InterlockedIncrement)
static volatile unsigned long long active_until;
static volatile long records;

static int text(wchar* b, int n, const wchar* s)
{
    while (*s && n < 510) b[n++] = *s++;
    return n;
}
static int number(wchar* b, int n, long long v)
{
    wchar digits[24];
    int k = 0;
    unsigned long long u;
    if (v < 0) { if (n < 510) b[n++] = L'-'; u = (unsigned long long)(-v); }
    else u = (unsigned long long)v;
    do { digits[k++] = (wchar)(L'0' + u % 10); u /= 10; } while (u);
    while (k && n < 510) b[n++] = digits[--k];
    return n;
}
static int service(int cmd, const unsigned char* p, int len)
{
    if (cmd == -30) return len > 0 && (p[0] == 0x99 || p[0] == 0x95);
    return cmd == 14 || cmd == 16 || cmd == 17 || cmd == 19 || cmd == 20 ||
           cmd == 21 || cmd == 22 || cmd == 29 || cmd == 30 || cmd == 40 || cmd == 47;
}
static int map_id(void)
{
    void* k = mb_TypeInfo;
    void* st;
    if ((unsigned long long)k < 0x10000 || ((unsigned long long)k & 7)) return -1;
    st = AT(k, 0xB8, void*);
    return st ? AT(st, 0x5C, short) : -1;
}
void diag_ui(int type)
{
    wchar b[160];
    unsigned long long ft, now;
    int n, count;
    imp_GetSystemTimeAsFileTime(&ft);
    now = ft / 10000;
    active_until = now + 15000;
    count = (int)_InterlockedIncrement(&records);
    if (count > 2000) return;
    n = text(b, 0, L"[HVNJ-DIAG] v=1 seq="); n = number(b, n, count);
    n = text(b, n, L" ms="); n = number(b, n, (long long)now);
    n = text(b, n, L" UI map="); n = number(b, n, map_id());
    n = text(b, n, L" type="); n = number(b, n, type);
    unity_debug_log(il2cpp_string_new_utf16(b, n), 0);
}
void diag_packet(int tx, void* msg)
{
    wchar b[512];
    unsigned long long ft, now, cap;
    void* io;
    void* arr;
    const unsigned char* p = 0;
    int cmd, len = 0, dump, n, i, count;
    if (!msg) return;
    cmd = AT(msg, 0x10, signed char);
    io = AT(msg, tx ? 0x20 : 0x18, void*);
    arr = io ? AT(io, 0x10, void*) : 0;
    if (arr) {
        cap = AT(arr, 0x18, unsigned long long);
        if (cap <= 0x1000000) {
            len = tx ? AT(io, 0x18, int) : (int)cap;
            if (len < 0 || (unsigned long long)len > cap) len = 0;
            p = (const unsigned char*)arr + 0x20;
        }
    }
    dump = service(cmd, p, len);
    if (tx && !dump) return;
    imp_GetSystemTimeAsFileTime(&ft);
    now = ft / 10000;
    if (tx) active_until = now + 15000;
    else if (!active_until || now > active_until) return;
    count = (int)_InterlockedIncrement(&records);
    if (count > 2000) return;
    n = text(b, 0, L"[HVNJ-DIAG] v=1 seq=");
    n = number(b, n, count);
    n = text(b, n, L" ms="); n = number(b, n, (long long)now);
    n = text(b, n, tx ? L" TX map=" : L" RX map="); n = number(b, n, map_id());
    n = text(b, n, L" cmd="); n = number(b, n, cmd);
    n = text(b, n, L" len="); n = number(b, n, len);
    n = text(b, n, dump ? L" data=" : L" data=redacted");
    if (dump) {
        for (i = 0; i < len && i < 96; i++) {
            int hi = p[i] >> 4, lo = p[i] & 15;
            b[n++] = (wchar)(hi < 10 ? L'0' + hi : L'A' + hi - 10);
            b[n++] = (wchar)(lo < 10 ? L'0' + lo : L'A' + lo - 10);
            b[n++] = L' ';
        }
        if (len > 96) n = text(b, n, L"truncated");
    }
    unity_debug_log(il2cpp_string_new_utf16(b, n), 0);
}
void diag_bg_send(void* session, void* msg, void* method)
{
    if (service_sent(msg)) return;
    diag_packet(1, msg);
    bg_zj(session, msg, method);
}
void diag_bk_send(void* session, void* msg, void* method)
{
    if (service_sent(msg)) return;
    diag_packet(1, msg);
    bk_bad(session, msg, method);
}
