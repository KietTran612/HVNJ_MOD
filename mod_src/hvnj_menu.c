/* =============================================================================
 *  HVNJ 186 - Menu "Mod HVNJ" trong game (bien dich bang cl.exe, ghep vao
 *  payload boi build_payload.py cung voi hvnj_caves.asm).
 *
 *  - Dong "Mod HVNJ" duoc them vao cuoi menu nhan vat (menuchar_hook).
 *  - Bam vao -> menu popup cua game (ms.dla) liet ke tung tinh nang voi [x]/[ ].
 *    Bam mot dong -> doi cfg_* tuong ung, luu PlayerPrefs, mo lai menu.
 *  - Lenh menu la iw(caption, MOD_ACT_BASE + i) khong co doi tuong xu ly ->
 *    game goi mo.djh, action_hook chuyen ve mod_action.
 *  - Dong "Xem truoc trang bi se ban" mo menu thu hai liet ke mon se ban / giu
 *    (hvnj_bag.c), dong thoi lay so dong ban shop con thieu (khong ban gi).
 *
 *  Quy uoc: khong dung CRT, khong co bang con tro (dia chi tuyet doi bi cam
 *  vi ASLR), moi doi tuong managed tao qua ham cua game / runtime IL2CPP.
 * ============================================================================= */
typedef unsigned short wchar;   /* L"..." trong C cua MSVC la unsigned short[] */
typedef struct {
    void* klass;
    void* monitor;
    int length;
    wchar chars[1];
} Il2CppString;

/* ---- ham game / runtime IL2CPP (RVA trong build_payload.py) ---------------- */
extern void il2cpp_init_md(void** slot);
extern void* il2cpp_object_new(void* klass);
extern Il2CppString* il2cpp_string_new_utf16(const wchar* text, int len);
extern void list_iw_ctor(void* list, void* method);                  /* List<iw>..ctor()      */
extern void list_iw_add(void* list, void* item, void* method);       /* List<iw>.Add(iw)      */
extern void iw_ctor_caption(void* self, Il2CppString* caption, int action, void* method);
extern void* ms_dkz(void* method);                                   /* menu popup chung      */
extern void ms_dla(void* ms, void* list, int pos, int isNpc, int isTask, int isTaskPhu, void* method);
extern Il2CppString* prefs_get_string(Il2CppString* key, void* method);
extern void prefs_set_string(Il2CppString* key, Il2CppString* value, void* method);

/* o metadata (TypeInfo / MethodInfo) cua game */
extern void* list_iw_TypeInfo;
extern void* list_iw_ctor_mi;
extern void* list_iw_add_mi;
extern void* iw_TypeInfo;

/* ---- cau hinh / trang thai trong hvnj_caves.asm ---------------------------- */
extern unsigned char cfg_mob, cfg_stage, cfg_quest, cfg_accept, cfg_party, cfg_die;
extern unsigned char cfg_stone, cfg_stone_lo, cfg_stone_hi, cfg_tathu, cfg_trial, cfg_sell;
extern unsigned char m_loaded;
extern unsigned char q_engaged, r_pending, r_active, p_active, s_active, s_fails;
extern int st_party_map;
extern long long st_empty_since, s_wait_until;

/* ---- phien don hanh trang (hvnj_bag.c) ------------------------------------- */
extern void bag_reset(void);
extern void bag_preview_start(void);
extern int bag_fetching(void);
extern int bag_describe(int k, wchar* buf, int max, int* st);    /* st: 1 ban, 0 giu, 2 chua biet */

#define MOD_ACT_BASE 0x48560000   /* phai trung voi hvnj_caves.asm */
#define ACT_OPEN     0
#define ACT_TOGGLE   1            /* 1 .. N_TOGGLE */
#define ACT_HI       10
#define ACT_LO       11
#define ACT_ACCEPT   12
#define ACT_CLOSE    13
#define ACT_PREVIEW  14           /* xem truoc trang bi se ban (va lam moi) */
#define ACT_MAX      14
#define N_TOGGLE     9
#define T_SELL       7            /* vi tri dong "Tu ban trang bi" */
#define T_STONE      8
#define STONE_LEVEL_MAX 12
#define PREF_VER     L'5'         /* '4' = ban truoc chua co dong ban trang bi (8 tick, luyen da o vi tri 7) */
#define PREF_LEN     (1 + N_TOGGLE + 3)
#define PREF_V4_LEN  (PREF_LEN - 1)
#define PREVIEW_MAX  24
#define BUF_MAX      96

/* Thu tu cac dong tick trong menu (va trong chuoi luu PlayerPrefs). */
static unsigned char* toggle(int i)
{
    if (i == 0) return &cfg_mob;
    if (i == 1) return &cfg_die;
    if (i == 2) return &cfg_trial;
    if (i == 3) return &cfg_stage;
    if (i == 4) return &cfg_quest;
    if (i == 5) return &cfg_tathu;
    if (i == 6) return &cfg_party;
    if (i == T_SELL) return &cfg_sell;
    return &cfg_stone;
}

static const wchar* toggle_name(int i)
{
    if (i == 0) return L"Né Boss / Tinh Anh / Thủ Lĩnh khi Auto";
    if (i == 1) return L"Chết: về làng ngay, quay lại map, bật Auto";
    if (i == 2) return L"Giữ Auto trong Thí Luyện";
    if (i == 3) return L"Tự qua ải Thí Luyện 161 -> 167";
    if (i == 4) return L"Auto nhiệm vụ hàng ngày";
    if (i == 5) return L"Auto nhiệm vụ tà thú";
    if (i == 6) return L"Đánh theo nhóm (theo trưởng nhóm)";
    if (i == T_SELL) return L"Tự bán trang bị thiếu dòng khi đầy";
    return L"Tự luyện đá khi đầy (chỉ trả bằng yên)";
}

/* Tat/bat mot tinh nang thi xoa trang thai dang do cua no. */
static void reset_state(int i)
{
    if (i == 1) {
        r_pending = 0;
        r_active = 0;
    } else if (i == 3) {
        st_empty_since = 0;
    } else if (i == 4 || i == 5) {
        q_engaged = 0;
    } else if (i == 6) {
        p_active = 0;
        st_party_map = -1;
    } else if (i == T_SELL) {
        bag_reset();
    } else if (i == T_STONE) {
        s_active = 0;
        s_fails = 0;
        s_wait_until = 0;
    }
}

static int put(wchar* buf, int n, const wchar* s)
{
    while (*s && n < BUF_MAX) buf[n++] = *s++;
    return n;
}

static int put_num(wchar* buf, int n, int v)
{
    if (v >= 10 && n < BUF_MAX) buf[n++] = (wchar)(L'0' + v / 10);
    if (n < BUF_MAX) buf[n++] = (wchar)(L'0' + v % 10);
    return n;
}

static Il2CppString* str(const wchar* s)
{
    int n = 0;
    while (s[n]) n++;
    return il2cpp_string_new_utf16(s, n);
}

static int ensure_metadata(void)
{
    il2cpp_init_md(&list_iw_TypeInfo);
    il2cpp_init_md(&list_iw_ctor_mi);
    il2cpp_init_md(&list_iw_add_mi);
    il2cpp_init_md(&iw_TypeInfo);
    return list_iw_TypeInfo && list_iw_ctor_mi && list_iw_add_mi && iw_TypeInfo;
}

static void add_item(void* list, const wchar* text, int len, int act)
{
    Il2CppString* caption = il2cpp_string_new_utf16(text, len);
    void* item;
    if (!caption) return;
    item = il2cpp_object_new(iw_TypeInfo);
    if (!item) return;
    iw_ctor_caption(item, caption, MOD_ACT_BASE + act, 0);
    list_iw_add(list, item, list_iw_add_mi);
}

/* ---- luu / doc lua chon: PlayerPrefs "HVNJ_MOD" = '5' + 9 tick + accept, lo, hi ----------- */
static void cfg_save(void)
{
    wchar b[PREF_LEN];
    int n = 0, i;
    b[n++] = PREF_VER;
    for (i = 0; i < N_TOGGLE; i++) b[n++] = *toggle(i) ? L'1' : L'0';
    b[n++] = (wchar)(L'a' + (cfg_accept & 15));
    b[n++] = (wchar)(L'a' + cfg_stone_lo);
    b[n++] = (wchar)(L'a' + cfg_stone_hi);
    prefs_set_string(str(L"HVNJ_MOD"), il2cpp_string_new_utf16(b, n), 0);
}

void mod_cfg_load(void)
{
    Il2CppString* v;
    int i, a, lo, hi, nt;
    m_loaded = 1;
    v = prefs_get_string(str(L"HVNJ_MOD"), 0);
    if (!v) return;
    if (v->length == PREF_LEN && v->chars[0] == PREF_VER) {
        nt = N_TOGGLE;
        for (i = 0; i < N_TOGGLE; i++) *toggle(i) = v->chars[1 + i] == L'1';
    } else if (v->length == PREF_V4_LEN && v->chars[0] == L'4') {
        nt = N_TOGGLE - 1;                  /* ban '4': luyen da o vi tri 7, chua co ban trang bi */
        for (i = 0; i < T_SELL; i++) *toggle(i) = v->chars[1 + i] == L'1';
        cfg_stone = v->chars[1 + T_SELL] == L'1';
        cfg_sell = 0;
    } else {
        return;
    }
    a = v->chars[1 + nt] - L'a';
    lo = v->chars[2 + nt] - L'a';
    hi = v->chars[3 + nt] - L'a';
    if (a >= 0 && a < 16) cfg_accept = (unsigned char)a;
    if (hi == 0) {
        cfg_stone_lo = 0;
        cfg_stone_hi = 0;
    } else if (hi >= 2 && hi <= STONE_LEVEL_MAX && lo >= 1 && lo < hi) {
        cfg_stone_lo = (unsigned char)lo;
        cfg_stone_hi = (unsigned char)hi;
    }
}

/* ---- menu ------------------------------------------------------------------ */
static void show_menu(void)
{
    wchar b[BUF_MAX];
    void* list;
    void* menu;
    int i, n;
    if (!ensure_metadata()) return;
    list = il2cpp_object_new(list_iw_TypeInfo);
    if (!list) return;
    list_iw_ctor(list, list_iw_ctor_mi);
    for (i = 0; i < N_TOGGLE; i++) {
        n = put(b, 0, *toggle(i) ? L"[x] " : L"[   ] ");
        n = put(b, n, toggle_name(i));
        add_item(list, b, n, ACT_TOGGLE + i);
        if (i == T_SELL) {
            n = put(b, 0, L"Xem trước trang bị sẽ bán");
            add_item(list, b, n, ACT_PREVIEW);
        }
    }
    n = put(b, 0, L"Luyện đá lên cấp: ");
    if (cfg_stone_hi) {
        n = put_num(b, n, cfg_stone_hi);
        n = put(b, n, L" (cất vào rương)");
    } else {
        n = put(b, n, L"mọi cấp, không cất rương");
    }
    add_item(list, b, n, ACT_HI);
    if (cfg_stone_hi) {
        n = put(b, 0, L"Luyện đá từ cấp: ");
        n = put_num(b, n, cfg_stone_lo);
        add_item(list, b, n, ACT_LO);
    }
    n = put(b, 0, L"Option nhận nhiệm vụ ở NPC: ");
    n = put_num(b, n, cfg_accept);
    add_item(list, b, n, ACT_ACCEPT);
    n = put(b, 0, L"Đóng");
    add_item(list, b, n, ACT_CLOSE);
    menu = ms_dkz(0);
    if (menu) ms_dla(menu, list, 0, 0, 0, 0, 0);
}

/* Menu "Xem truoc": so mon se ban, tung mon (ten: dong dang co / dong ban shop),
 * bam dong bat ky de xem lai (so dong shop duoc lay dan trong luc do). */
static void show_preview(void)
{
    wchar b[BUF_MAX];
    void* list;
    void* menu;
    int k, n, st, total = 0, count = 0, unknown = 0;
    if (!ensure_metadata()) return;
    list = il2cpp_object_new(list_iw_TypeInfo);
    if (!list) return;
    list_iw_ctor(list, list_iw_ctor_mi);
    for (k = 0; k < PREVIEW_MAX && bag_describe(k, b, BUF_MAX, &st) >= 0; k++) {
        total++;
        if (st == 1) count++;
        if (st == 2) unknown = 1;
    }
    n = put(b, 0, L"Sẽ bán: ");
    n = put_num(b, n, count);
    n = put(b, n, L" / ");
    n = put_num(b, n, total);
    n = put(b, n, L" món (bấm để xem lại)");
    add_item(list, b, n, ACT_PREVIEW);
    if (unknown && bag_fetching()) {
        n = put(b, 0, L"Đang lấy số dòng từ shop...");
        add_item(list, b, n, ACT_PREVIEW);
    }
    for (k = 0; k < total; k++) {
        n = bag_describe(k, b, BUF_MAX, &st);
        if (n < 0) break;
        add_item(list, b, n, ACT_PREVIEW);
    }
    n = put(b, 0, L"Quay lại");
    add_item(list, b, n, ACT_OPEN);
    n = put(b, 0, L"Đóng");
    add_item(list, b, n, ACT_CLOSE);
    menu = ms_dkz(0);
    if (menu) ms_dla(menu, list, 0, 0, 0, 0, 0);
}

/* Them dong "Mod HVNJ" vao menu nhan vat (list do mo.doMenuChar vua dung). */
void mod_menu_add_entry(void* list)
{
    if (!list || !ensure_metadata()) return;
    add_item(list, L"Mod HVNJ", 8, ACT_OPEN);
}

/* Lenh cua menu Mod (action_hook da loc dung khoang ma). Tra ve 1 = da xu ly. */
int mod_action(int action)
{
    int i = action - MOD_ACT_BASE;
    int hi;
    if (i < 0 || i > ACT_MAX) return 0;
    if (i >= ACT_TOGGLE && i < ACT_TOGGLE + N_TOGGLE) {
        unsigned char* t = toggle(i - ACT_TOGGLE);
        *t = (unsigned char)!*t;
        reset_state(i - ACT_TOGGLE);
    } else if (i == ACT_HI) {
        hi = cfg_stone_hi ? cfg_stone_hi + 1 : 2;
        if (hi > STONE_LEVEL_MAX) hi = 0;
        cfg_stone_hi = (unsigned char)hi;
        if (!hi) cfg_stone_lo = 0;
        else if (!cfg_stone_lo || cfg_stone_lo >= hi) cfg_stone_lo = 1;
        reset_state(T_STONE);
    } else if (i == ACT_LO) {
        cfg_stone_lo = (unsigned char)(cfg_stone_lo + 1 >= cfg_stone_hi ? 1 : cfg_stone_lo + 1);
        reset_state(T_STONE);
    } else if (i == ACT_ACCEPT) {
        cfg_accept = (unsigned char)((cfg_accept + 1) & 3);
    } else if (i == ACT_CLOSE) {
        return 1;
    } else if (i == ACT_PREVIEW) {
        bag_preview_start();
        show_preview();
        return 1;
    }
    if (i != ACT_OPEN) cfg_save();
    show_menu();
    return 1;
}
