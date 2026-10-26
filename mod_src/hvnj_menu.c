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
 *  - Dong "Mo ruong do" / "Mo nang cap trang bi": mo bang cua game o bat ky map
 *    nao qua service_open: NPC5/6 -> menu(0,0) -> cho server cmd30 mo bang.
 *    Khong goi mo.djd de gia lap thanh cong khi server chua chap nhan.
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
extern void* mo_ddt(void* method);                                   /* GameScr (mo) hien tai */
extern void mo_djd(void* mo, int typeUI, void* method);              /* mo bang theo loai     */
extern void diag_ui(int type);
extern void service_open(int type);

/* nut tren thanh Top (duoi nut Shop) - cung cach game tao nut Shop trong mo.dhp */
extern void* unity_component_gameobject(void* comp, void* method);  /* Component.gameObject  */
extern void* unity_gameobject_transform(void* go, void* method);    /* GameObject.transform  */
extern void* unity_transform_find(void* tr, Il2CppString* name, void* method);
extern void unity_object_set_name(void* obj, Il2CppString* name, void* method);
extern void* ho_bzc(void* parent_go, float x, float y, void* sprite, void* action, void* method); /* nut anh */
extern void* ho_cab(void* parent_tr, Il2CppString* text, float x, float y, int font, int color,
                    int color_eff, int mode, void* method);          /* chu tren nut          */
extern float ho_caf(void* sprite, void* method);                     /* chieu cao anh (don vi game) */
extern void hm_bxl(void* label, float x, float y, void* method);     /* dat vi tri chu        */
extern void mo_mk_ctor(void* self, void* mo, int id, void* method);  /* hanh dong nut: mo.dhe(id) */
extern void* ka_TypeInfo;      /* ka static +380h: Sprite[] nen nut, [0] = nen nut Shop     */
extern void* iv_TypeInfo;      /* iv static +0Ch: mau chu cua nut thanh Top                 */
extern void* mo_mk_TypeInfo;   /* mo.mk: hanh dong cua nut thanh Top (th() -> mo.dhe(id))   */
extern void* hx_TypeInfo;      /* hx static +38h: he so doi toa do game -> UI               */
extern void unity_rt_set_anchored(void* rt, unsigned long long pos, void* method);  /* RectTransform.anchoredPosition = Vector2 */
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
extern int bag_describe(int k, wchar* buf, int max, int* st);    /* st: 1 ban, 3 cat ruong, 0 giu, 2 chua biet */

#define MOD_ACT_BASE 0x48560000   /* phai trung voi hvnj_caves.asm */
#define ACT_OPEN     0
#define ACT_TOGGLE   1            /* 1 .. N_TOGGLE */
#define ACT_HI       10
#define ACT_LO       11
#define ACT_ACCEPT   12
#define ACT_CLOSE    13
#define ACT_PREVIEW  14           /* xem truoc trang bi se ban (va lam moi) */
#define ACT_OPEN_BOX 15           /* mo ruong do o bat ky map nao */
#define ACT_OPEN_UP  16           /* mo bang nang cap trang bi o bat ky map nao */
#define ACT_MAX      16
#define UI_BOX       4            /* mo.djd: ruong do (fp che do ruong; chua co lm.miw thi xin server) */
#define UI_UPGRADE   10           /* mo.djd: nang cap trang bi (gw) */

#define AT(p, off, T) (*(T*)((char*)(p) + (off)))
#define STATICS       0xB8        /* Il2CppClass::static_fields */
#define MO_SHOP_IMAGE 0x378       /* mo.nnq: Image cua nut Shop (null khi chua tao nut) */
#define KA_SPRITES    0x380
#define IV_COLOR      0x0C
#define TOP_FONT      0x26        /* font / mau vien chu giong nut Shop */
#define TOP_COLOR_EFF 0x221F1F
#define TOP_BTN_BASE  0x48560100  /* id nut cua mod trong mo.dhe - phai trung voi hvnj_caves.asm */
#define N_TOP_BTN     2
#define TOP_CHECK_MS  250
#define MO_SHOP_HK    0x508       /* mo: hk cua nut Shop */
#define HK_X          0x18        /* hk: x game dat lan cuoi (hk.bvx), y o +1Ch */
#define HX_SCALE      0x38        /* hx static +38h: he so doi toa do game -> UI (hk.bvx) */
#define TOP_STEP      30.0f       /* khoang cach 2 nut / 2 hang tren thanh Top (mo.dhp) */
#define TOP_ROW       30.0f       /* hang 2 thap hon hang nut Shop 30 */
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
    if (i == T_SELL) return L"Tự bán đồ thiếu dòng, cất đồ đủ dòng vào rương";
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
    n = put(b, 0, L"Mở rương đồ");
    add_item(list, b, n, ACT_OPEN_BOX);
    n = put(b, 0, L"Mở nâng cấp trang bị");
    add_item(list, b, n, ACT_OPEN_UP);
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
    int k, n, st, total = 0, count = 0, store = 0, unknown = 0;
    if (!ensure_metadata()) return;
    list = il2cpp_object_new(list_iw_TypeInfo);
    if (!list) return;
    list_iw_ctor(list, list_iw_ctor_mi);
    for (k = 0; k < PREVIEW_MAX && bag_describe(k, b, BUF_MAX, &st) >= 0; k++) {
        total++;
        if (st == 1) count++;
        if (st == 3) store++;
        if (st == 2) unknown = 1;
    }
    n = put(b, 0, L"Bán: ");
    n = put_num(b, n, count);
    n = put(b, n, L", cất rương: ");
    n = put_num(b, n, store);
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

/* ---- nut "Ruong" / "Nang cap" tren thanh Top --------------------------------
 * Thanh Top (goc tren ben phai) xep nut thanh 2 hang (mo.dhp, moi frame):
 *   hang 1: nut Shop roi sang trai, moi nut cach 30 (mo +508h, 550h, 510h, 570h, 558h, 528h);
 *   hang 2: thap hon 30, bat dau lech nua nut ben phai nut Shop roi sang trai
 *           (mo +540h, 530h, 520h, 518h, 538h).
 * Moi nut co hk (RectTransform + x,y game dat lan cuoi o +18h / +1Ch). Nut cua mod la
 * con cua nut Shop (di theo va an / hien cung nut Shop khi thanh Top thu gon), dat
 * NOI TIEP CUOI HANG 2 de khong de / bi de boi nut nao cua game. Bam nut -> mo.mk.th()
 * -> mo.dhe(TOP_BTN_BASE + k) -> dhe_hook (asm) -> mod_top_click. */
static const wchar* top_btn_name(int k)
{
    return k == 0 ? L"hvnj_ruong" : L"hvnj_nangcap";
}

static const wchar* top_btn_text(int k)
{
    return k == 0 ? L"Rương" : L"Nâng cấp";
}

/* hk cua cac nut hang 2 trong mo (game xep tu phai sang trai) */
static int row2_field(int i)
{
    if (i == 0) return 0x540;
    if (i == 1) return 0x530;
    if (i == 2) return 0x520;
    if (i == 3) return 0x518;
    return 0x538;
}

static long long tb_next;

static void create_top_buttons(void* mo, void* go)
{
    void* st;
    void* sprites;
    void* spr;
    float h;
    int k, color;
    il2cpp_init_md(&ka_TypeInfo);
    il2cpp_init_md(&iv_TypeInfo);
    il2cpp_init_md(&mo_mk_TypeInfo);
    if (!ka_TypeInfo || !iv_TypeInfo || !mo_mk_TypeInfo) return;
    st = AT(ka_TypeInfo, STATICS, void*);
    sprites = st ? AT(st, KA_SPRITES, void*) : 0;
    if (!sprites || AT(sprites, 0x18, long long) < 1) return;
    spr = AT(sprites, 0x20, void*);
    if (!spr) return;
    st = AT(iv_TypeInfo, STATICS, void*);
    color = st ? AT(st, IV_COLOR, int) : 0;
    h = ho_caf(spr, 0);
    for (k = 0; k < N_TOP_BTN; k++) {
        void* act = il2cpp_object_new(mo_mk_TypeInfo);
        void* btn;
        void* bgo;
        void* btr;
        void* label;
        if (!act) return;
        mo_mk_ctor(act, mo, TOP_BTN_BASE + k, 0);
        btn = ho_bzc(go, 0.0f, TOP_ROW, spr, act, 0);                /* vi tri dat lai ngay sau */
        bgo = btn ? unity_component_gameobject(btn, 0) : 0;
        if (!bgo) return;
        unity_object_set_name(bgo, str(top_btn_name(k)), 0);
        btr = unity_gameobject_transform(bgo, 0);
        if (!btr) return;
        label = ho_cab(btr, str(top_btn_text(k)), 0.0f, 0.0f, TOP_FONT, color, TOP_COLOR_EFF, 1, 0);
        if (label) hm_bxl(label, 0.0f, h * 0.5f + 2.0f, 0);         /* giong chu cua nut Shop */
    }
}

/* quest_tick goi moi frame (now = ms): tao nut neu nut Shop da co ma chua co nut cua mod,
 * roi dat nut noi tiep cuoi hang 2 (toa do so voi nut Shop). */
void mod_top_buttons(void* mo, long long now)
{
    void* shop;
    void* go;
    void* tr;
    void* st;
    float xs, x0, scale;
    int i, found = 0, k;
    if (now < tb_next || !mo) return;
    tb_next = now + TOP_CHECK_MS;
    shop = AT(mo, MO_SHOP_HK, void*);
    if (!AT(mo, MO_SHOP_IMAGE, void*) || !shop) return;               /* chua co nut Shop */
    go = unity_component_gameobject(AT(mo, MO_SHOP_IMAGE, void*), 0);
    tr = go ? unity_gameobject_transform(go, 0) : 0;
    if (!tr) return;
    if (!unity_transform_find(tr, str(top_btn_name(0)), 0)) create_top_buttons(mo, go);
    /* x cua o trong dau tien o cuoi hang 2 */
    xs = AT(shop, HK_X, float);
    x0 = 0.0f;
    for (i = 0; i < 5; i++) {
        void* hk = AT(mo, row2_field(i), void*);
        if (!hk) continue;
        if (!found || AT(hk, HK_X, float) < x0) x0 = AT(hk, HK_X, float);
        found = 1;
    }
    x0 = found ? x0 - TOP_STEP : xs + TOP_STEP * 0.5f;           /* hang 2 trong: cho nut dau cua hang 2 */
    il2cpp_init_md(&hx_TypeInfo);
    st = hx_TypeInfo ? AT(hx_TypeInfo, STATICS, void*) : 0;
    scale = st ? AT(st, HX_SCALE, float) : 1.0f;
    for (k = 0; k < N_TOP_BTN; k++) {
        void* btr = unity_transform_find(tr, str(top_btn_name(k)), 0);
        union { float f[2]; unsigned long long q; } pos;
        if (!btr) continue;
        pos.f[0] = (x0 - TOP_STEP * (float)k - xs) * scale;         /* nhu hk.bvx: (x * s, -y * s) */
        pos.f[1] = -TOP_ROW * scale;
        unity_rt_set_anchored(btr, pos.q, 0);
    }
}

/* Bam nut cua mod (dhe_hook nhay toi tu dau mo.dhe: rcx = mo, edx = id). */
void mod_top_click(void* mo, int id)
{
    if (mo) {
        int type = id == TOP_BTN_BASE ? UI_BOX : UI_UPGRADE;
        diag_ui(type);
        service_open(type);
    }
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
    } else if (i == ACT_OPEN_BOX || i == ACT_OPEN_UP) {
        void* mo = mo_ddt(0);
        if (mo) {
            int type = i == ACT_OPEN_BOX ? UI_BOX : UI_UPGRADE;
            diag_ui(type);
            service_open(type);
        }
        return 1;
    }
    if (i != ACT_OPEN) cfg_save();
    show_menu();
    return 1;
}
