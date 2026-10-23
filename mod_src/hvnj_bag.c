/* =============================================================================
 *  HVNJ 186 - Phien don hanh trang (bien dich bang cl.exe, ghep vao payload
 *  boi build_payload.py cung voi hvnj_caves.asm va hvnj_menu.c).
 *
 *  quest_tick goi bag_tick(now) moi frame, sau phan xu ly chet. Moi luc chi
 *  mot viec dong vao hanh trang (lenh gui server deu theo vi tri o), theo thu tu:
 *    1. Tu ban trang bi thieu dong (cfg_sell): khi dang Auto va hanh trang con
 *       <= BAG_FREE_MAX o trong.
 *    2. Luyen da (cfg_stone, stone_tick trong asm): bat dau ngay sau buoc 1,
 *       ke ca khi buoc 1 da lam trong cho.
 *    3. Cat da cap dich vao ruong (cung trong stone_tick).
 *  Khi phien dang chay bag_tick tra ve 1 -> quest_tick tam dung auto nhiem vu.
 *
 *  Ban trang bi: mon trong hanh trang thuoc trang phuc (loai 0,2,4,6,8), trang
 *  suc (3,5,7,9) hoac vu khi (1), chua nang cap, khong khoa, khong co dong kham
 *  ngoc / truc luyen (jr.cih), co IT DONG CHI SO HON mon cung mau ban trong shop
 *  -> gui lenh ban (cmd 14, server tra ve yen). Mon cung loai DU DONG (bang hoac
 *  nhieu hon ban shop) thi cat vao ruong do (cmd 17, nhu lj.itemBagToBox) toi khi
 *  ruong day; client chi biet ruong khi da mo ruong it nhat 1 lan (lm.miw). So dong cua ban shop lay giong
 *  khi nguoi choi xem cua hang:
 *    - tai danh sach shop (cmd -30 / sub -103 + ma danh sach, nhu bam the cua hang),
 *    - xem chi tiet mon trong shop (cmd 42 + ma danh sach + o, nhu bam vao mon),
 *    - luu lai trong PlayerPrefs "HVNJ_SHOP" de lan sau khoi hoi.
 *  Chua biet so dong cua ban shop thi KHONG ban. Cua hang chua mo thi game chi
 *  luu du lieu ve (fp.boa / fp.bor thoat khi chua dung bang shop).
 *
 *  Quy uoc giong hvnj_menu.c: khong CRT, khong bang con tro.
 * ============================================================================= */
typedef unsigned short wchar;
typedef struct {
    void* klass;
    void* monitor;
    int length;
    wchar chars[1];
} Il2CppString;

#define AT(p, off, T) (*(T*)((char*)(p) + (off)))

/* ---- ham game / runtime IL2CPP (RVA trong build_payload.py) ---------------- */
extern void* lm_cua(void* method);                                    /* nhan vat cua minh   */
extern void* lj_cmy(void* method);                                    /* Service             */
extern void bc_ctor(void* self, int command, void* method);           /* new Message(cmd)    */
extern void bl_bat(void* writer, int value, void* method);            /* writeByte           */
extern void bl_bbb(void* writer, int value, void* method);            /* writeInt            */
extern void il2cpp_iface_invoke1(int slot, void* iface, void* obj, void* arg);
extern void* il2cpp_object_new(void* klass);
extern void il2cpp_init_md(void** slot);
extern unsigned char jr_cih(void* item, void* method);               /* co dong kham / truc */
extern Il2CppString* il2cpp_string_new_utf16(const wchar* text, int len);
extern Il2CppString* prefs_get_string(Il2CppString* key, void* method);
extern void prefs_set_string(Il2CppString* key, Il2CppString* value, void* method);
extern void stone_tick(void);                                        /* hvnj_caves.asm      */

extern void* ca_TypeInfo;      /* ca.fxf (+16h) = nut Auto dang bat                       */
extern void* fp_TypeInfo;      /* fp (cua hang): static jr[] danh sach hang theo ma        */
extern void* bc_TypeInfo;      /* Message                                                 */
extern void* hs_TypeInfo;      /* ISession (slot 3 = gui message)                         */

extern unsigned char cfg_sell, cfg_stone, s_active;
extern long long s_wait_until;

/* ---- offset field (tu il2cpp dump) ----------------------------------------- */
#define STATICS       0xB8      /* Il2CppClass::static_fields                     */
#define CA_AUTO       0x16
#define LM_STATUS     0x5C      /* 14 = chet, 5 = chet bay                        */
#define LM_BAG        0x1B8     /* jr[] hanh trang                                */
#define LM_BOX        0x1C0     /* jr[] ruong do (null khi chua mo ruong lan nao)  */
#define LJ_SESSION    0x10
#define BC_WRITER     0x20
#define ARR_LEN       0x18      /* Il2CppArray::max_length                        */
#define ARR_ITEMS     0x20
#define LIST_SIZE     0x18      /* List<T>._size                                  */
#define JR_TEMPLATE   0x10      /* jr.leu: js                                     */
#define JR_OPTIONS    0x18      /* jr.lev: List<jw> dong chi so                   */
#define JR_INDEX      0x28      /* jr.ley: indexUI                                */
#define JR_QTY        0x2C      /* jr.lez: so luong                               */
#define JR_LOCK       0x38      /* jr.lfc: khoa                                   */
#define JR_UPGRADE    0x40      /* jr.lfe: cap nang                               */
#define JR_SELECTED   0x5E      /* jr.lfn: dang nam trong o cua popup Luyen da    */
#define JS_ID         0x10
#define JS_TYPE       0x12
#define JS_NAME       0x18

#define STATUS_DEAD     14
#define STATUS_DEADFLY  5
#define CMD_SUB         (-30)   /* lj.cox: requestItem(typeUI) = cmd -30, sub -103 */
#define SUB_OPEN_SHOP   (-103)
#define CMD_ITEM_INFO   42      /* lj.cnz: requestItemInfo(typeUI, indexUI)       */
#define CMD_SELL        14      /* lj.coi: ban vat pham (o, so luong)             */
#define CMD_BAG_TO_BOX  17      /* lj.itemBagToBox: cat vat pham vao ruong (o)    */
#define LIST_MIN        2       /* ma danh sach shop: 2 vu khi, 16..19 trang suc,  */
#define LIST_MAX        29      /*   20..29 trang phuc (chan = nam, le = nu)       */

#define BAG_FREE_MAX     1      /* con <= 1 o trong thi coi la day (giong luyen da) */
#define SL_TICK_MS       200    /* nhip xet                                        */
#define SL_GAP_MS        500    /* cach nhau toi thieu giua 2 lenh gui server      */
#define SL_REPLY_MS      3000   /* cho server tra loi                              */
#define SL_IDLE_MS       30000  /* het viec -> 30s sau moi xet lai                 */
#define SL_FAIL_MS       300000 /* server khong tra loi SL_MAX_FAILS lan lien tiep -> nghi 5 phut */
#define SL_LIST_RETRY_MS 300000 /* mot danh sach shop khong ve -> 5 phut sau moi xin lai */
#define SL_BOX_FAIL_MS   1800000 /* server khong cho cat ruong -> 30 phut moi thu lai (van ban) */
#define SL_MAX_FAILS     3
#define SH_MAX           256    /* so mau ghi nho so dong ban shop                 */
#define NS_MAX           128    /* so mau "khong co trong shop" ghi nho trong lan choi */
#define SH_BUF           (1 + SH_MAX * 12)

#define MODE_SELL    0
#define MODE_PREVIEW 1          /* chi lay so dong ban shop, khong ban             */
#define PEND_NONE    0
#define PEND_LIST    1
#define PEND_INFO    2
#define PEND_SELL    3
#define PEND_BOX     4

/* ---- trang thai (doc ten trong kiem thu) ------------------------------------ */
/* (gan = 0 de la dinh nghia that, khong phai "common symbol" ma builder khong ho tro) */
unsigned char sl_state = 0;     /* 1 = dang chay phien ban / xem truoc             */
unsigned char sl_mode = 0;
unsigned char sl_pend = 0;      /* lenh dang cho server tra loi                     */
unsigned char sl_fails = 0;
int sl_sold = 0;                /* so mon da ban trong phien                        */
int sl_stored = 0;              /* so mon da cat vao ruong trong phien              */
long long sl_rest_until = 0;    /* khong bat dau phien ban moi truoc moc nay        */
static long long sl_last, sl_next, sl_deadline, sl_box_wait_until;
static long long sl_list_retry[LIST_MAX + 1];
static int sl_pend_type, sl_pend_tpl, sl_pend_slot, sl_pend_qty;
static void* sl_pend_item;

static short sh_id[SH_MAX];     /* mau -> so dong chi so cua ban shop               */
static unsigned char sh_cnt[SH_MAX];
static int sh_n;
static unsigned char sh_loaded;
static short ns_id[NS_MAX];     /* mau khong co trong danh sach shop nao             */
static int ns_n;
static wchar sh_buf[SH_BUF];

/* ---- tien ich -------------------------------------------------------------- */
static Il2CppString* wstr(const wchar* s)
{
    int n = 0;
    while (s[n]) n++;
    return il2cpp_string_new_utf16(s, n);
}

static int put_dec(wchar* b, int n, int max, int v)
{
    wchar d[12];
    int k = 0;
    if (v < 0) v = 0;
    do {
        d[k++] = (wchar)(L'0' + v % 10);
        v /= 10;
    } while (v && k < 11);
    while (k && n < max) b[n++] = d[--k];
    return n;
}

static int put_text(wchar* b, int n, int max, const wchar* s)
{
    while (*s && n < max) b[n++] = *s++;
    return n;
}

static int arr_len(void* arr)
{
    return arr ? (int)AT(arr, ARR_LEN, long long) : 0;
}

static void* arr_at(void* arr, int i)
{
    return AT(arr, ARR_ITEMS + 8 * i, void*);
}

static int auto_on(void)
{
    void* st;
    if (!ca_TypeInfo) return 0;
    st = AT(ca_TypeInfo, STATICS, void*);
    return st && AT(st, CA_AUTO, unsigned char);
}

/* nhan vat con song (0 neu chua vao game / dang chet) */
static void* me(void)
{
    void* ch = lm_cua(0);
    int s;
    if (!ch) return 0;
    s = AT(ch, LM_STATUS, int);
    return (s == STATUS_DEAD || s == STATUS_DEADFLY) ? 0 : ch;
}

static int bag_free(void* bag)
{
    int i, n = arr_len(bag), f = 0;
    for (i = 0; i < n; i++)
        if (!arr_at(bag, i)) f++;
    return f;
}

/* Ruong do: 1 = con cho, 0 = day, -1 = client chua co danh sach ruong (chua mo ruong lan nao). */
static int box_space(void* ch)
{
    void* box = AT(ch, LM_BOX, void*);
    if (!box) return -1;
    return bag_free(box) > 0;
}

/* ---- so dong cua ban shop (luu PlayerPrefs "HVNJ_SHOP" = "1" + "mau:so;"...) */
static int sh_find(int id)
{
    int i;
    for (i = 0; i < sh_n; i++)
        if (sh_id[i] == id) return i;
    return -1;
}

static void sh_set(int id, int cnt)
{
    int i;
    if (id < 0 || id > 32767 || cnt < 0 || cnt > 255) return;
    i = sh_find(id);
    if (i < 0) {
        if (sh_n >= SH_MAX) return;
        i = sh_n++;
        sh_id[i] = (short)id;
    }
    sh_cnt[i] = (unsigned char)cnt;
}

static void sh_load(void)
{
    Il2CppString* v;
    int i, id = 0, cnt = 0, st = 0;
    sh_loaded = 1;
    v = prefs_get_string(wstr(L"HVNJ_SHOP"), 0);
    if (!v || v->length < 1 || v->chars[0] != L'1') return;
    for (i = 1; i < v->length; i++) {
        wchar c = v->chars[i];
        if (c >= L'0' && c <= L'9') {
            if (st == 0 && id < 100000) id = id * 10 + (c - L'0');
            else if (st == 1 && cnt < 1000) cnt = cnt * 10 + (c - L'0');
        } else if (c == L':' && st == 0) {
            st = 1;
        } else {
            if (c == L';' && st == 1) sh_set(id, cnt);
            id = cnt = st = 0;      /* ky tu la: bo phan dang doc */
        }
    }
}

static void sh_save(void)
{
    int i, n = 0;
    sh_buf[n++] = L'1';
    for (i = 0; i < sh_n; i++) {
        n = put_dec(sh_buf, n, SH_BUF, sh_id[i]);
        if (n < SH_BUF) sh_buf[n++] = L':';
        n = put_dec(sh_buf, n, SH_BUF, sh_cnt[i]);
        if (n < SH_BUF) sh_buf[n++] = L';';
    }
    prefs_set_string(wstr(L"HVNJ_SHOP"), il2cpp_string_new_utf16(sh_buf, n), 0);
}

/* -1 = chua biet */
static int sh_get(int id)
{
    int i;
    if (!sh_loaded) sh_load();
    i = sh_find(id);
    return i < 0 ? -1 : sh_cnt[i];
}

static int ns_has(int id)
{
    int i;
    for (i = 0; i < ns_n; i++)
        if (ns_id[i] == id) return 1;
    return 0;
}

/* ---- danh sach hang cua shop (fp static jr[] theo ma, null = chua tai) ------- */
static void* shop_list(int type)
{
    void* st;
    int off;
    if (type == 2) off = 0x78;
    else if (type >= 16 && type <= 19) off = 0x58 + (type - 16) * 8;
    else if (type >= 20 && type <= 29) off = 0x08 + (type - 20) * 8;
    else return 0;
    il2cpp_init_md(&fp_TypeInfo);
    if (!fp_TypeInfo) return 0;
    st = AT(fp_TypeInfo, STATICS, void*);
    return st ? AT(st, off, void*) : 0;
}

/* ma cac danh sach shop co ban mon loai nay; tra ve so danh sach */
static int lists_for(int type, int* l0, int* l1)
{
    if (type == 1) {
        *l0 = 2;                                    /* vu khi            */
        return 1;
    }
    if (type == 3 || type == 5 || type == 7 || type == 9) {
        *l0 = 16 + (type - 3) / 2;                  /* trang suc         */
        return 1;
    }
    if (type == 0 || type == 2 || type == 4 || type == 6 || type == 8) {
        *l0 = 20 + type;                            /* trang phuc nam    */
        *l1 = 21 + type;                            /* trang phuc nu     */
        return 2;
    }
    return 0;
}

static void* find_tpl(void* arr, int id)
{
    int i, n = arr_len(arr);
    for (i = 0; i < n; i++) {
        void* it = arr_at(arr, i);
        void* tpl = it ? AT(it, JR_TEMPLATE, void*) : 0;
        if (tpl && AT(tpl, JS_ID, short) == id) return it;
    }
    return 0;
}

/* Mon co duoc xet ban khong; *lines = so dong chi so dang co. */
static int candidate(void* it, int* lines)
{
    void* tpl;
    void* opts;
    int type;
    if (!it) return 0;
    tpl = AT(it, JR_TEMPLATE, void*);
    if (!tpl) return 0;
    type = AT(tpl, JS_TYPE, signed char);
    if (type < 0 || type > 9) return 0;                 /* chi trang phuc / trang suc / vu khi */
    if (AT(it, JR_UPGRADE, int) > 0) return 0;          /* da nang cap (game bat tach truoc khi ban) */
    if (AT(it, JR_LOCK, unsigned char)) return 0;       /* do khoa */
    if (AT(it, JR_SELECTED, unsigned char)) return 0;   /* dang nam trong popup */
    opts = AT(it, JR_OPTIONS, void*);
    if (!opts) return 0;                                /* chua co dong chi so */
    if (jr_cih(it, 0)) return 0;                        /* kham ngoc / truc luyen */
    *lines = AT(opts, LIST_SIZE, int);
    return 1;
}

/* So dong cua ban shop: >= 0 da biet, -1 chua biet (co the dang hoi), -2 khong co trong shop.
 * Khi 'fetch' != 0 thi duoc phep gui lenh xin du lieu (tra ve -1 va dat sl_pend). */
static int shop_lines(int id, int type, long long now, int fetch)
{
    int lists[2], k, nl, missing = 0;
    void* found = 0;
    int found_list = 0;
    int c = sh_get(id);
    if (c >= 0) return c;
    if (ns_has(id)) return -2;
    nl = lists_for(type, &lists[0], &lists[1]);
    for (k = 0; k < nl && !found; k++) {          /* thay o danh sach nam thi khoi tai danh sach nu */
        void* arr = shop_list(lists[k]);
        if (!arr) {
            missing = 1;
            if (!fetch || now < sl_list_retry[lists[k]]) continue;
            sl_pend = PEND_LIST;
            sl_pend_type = lists[k];
            return -1;
        }
        found = find_tpl(arr, id);
        found_list = lists[k];
    }
    if (!found) {
        if (!missing && ns_n < NS_MAX) ns_id[ns_n++] = (short)id;
        return missing ? -1 : -2;
    }
    if (AT(found, JR_OPTIONS, void*)) {
        c = AT(AT(found, JR_OPTIONS, void*), LIST_SIZE, int);
        sh_set(id, c);
        sh_save();
        return c;
    }
    if (fetch) {
        sl_pend = PEND_INFO;
        sl_pend_type = found_list;
        sl_pend_tpl = id;
        sl_pend_slot = AT(found, JR_INDEX, int);
    }
    return -1;
}

/* ---- gui packet: new Message(cmd), ghi 0..2 byte + int, session.zs(msg) ------ */
static int send_msg(int cmd, int nbytes, int b0, int b1, int with_int, int v)
{
    void* svc;
    void* sess;
    void* msg;
    void* w;
    svc = lj_cmy(0);
    if (!svc) return 0;
    sess = AT(svc, LJ_SESSION, void*);
    if (!sess) return 0;
    il2cpp_init_md(&bc_TypeInfo);
    il2cpp_init_md(&hs_TypeInfo);
    if (!bc_TypeInfo || !hs_TypeInfo) return 0;
    msg = il2cpp_object_new(bc_TypeInfo);
    if (!msg) return 0;
    bc_ctor(msg, cmd, 0);
    w = AT(msg, BC_WRITER, void*);
    if (!w) return 0;
    if (nbytes > 0) bl_bat(w, b0, 0);
    if (nbytes > 1) bl_bat(w, b1, 0);
    if (with_int) bl_bbb(w, v, 0);
    il2cpp_iface_invoke1(3, hs_TypeInfo, sess, msg);
    return 1;
}

/* Lenh truoc da duoc server xu ly chua. */
static int pend_done(void* bag)
{
    if (sl_pend == PEND_LIST) return shop_list(sl_pend_type) != 0;
    if (sl_pend == PEND_INFO) {
        void* it = find_tpl(shop_list(sl_pend_type), sl_pend_tpl);
        void* opts = it ? AT(it, JR_OPTIONS, void*) : 0;
        if (!opts) return 0;
        sh_set(sl_pend_tpl, AT(opts, LIST_SIZE, int));
        sh_save();
        return 1;
    }
    if (sl_pend == PEND_SELL) {
        void* it;
        if (sl_pend_slot >= arr_len(bag)) return 1;
        it = arr_at(bag, sl_pend_slot);
        if (it == sl_pend_item && AT(it, JR_QTY, int) >= sl_pend_qty) return 0;
        sl_sold++;
        return 1;
    }
    if (sl_pend == PEND_BOX) {
        if (sl_pend_slot < arr_len(bag) && arr_at(bag, sl_pend_slot) == sl_pend_item) return 0;
        sl_stored++;
        return 1;
    }
    return 1;
}

static int finish(long long now, long long rest)
{
    sl_state = 0;
    sl_pend = PEND_NONE;
    sl_rest_until = now + rest;
    return 0;
}

/* Mot buoc cua phien. Tra ve 1 = con viec, 0 = xong. */
static int sell_step(long long now)
{
    void* ch;
    void* bag;
    int i, n;
    if (now - sl_last < SL_TICK_MS) return 1;
    sl_last = now;
    ch = me();
    if (!ch) return finish(now, 0);
    if (sl_mode == MODE_SELL && !auto_on()) return finish(now, 0);   /* tat Auto -> dung */
    bag = AT(ch, LM_BAG, void*);
    if (!bag) return finish(now, 0);
    if (sl_pend) {
        if (pend_done(bag)) {
            sl_pend = PEND_NONE;
            sl_fails = 0;
        } else if (now < sl_deadline) {
            return 1;
        } else if (sl_pend == PEND_BOX) {
            sl_pend = PEND_NONE;                    /* server khong cho cat ruong: thoi cat, van ban */
            sl_box_wait_until = now + SL_BOX_FAIL_MS;
        } else {
            if (sl_pend == PEND_LIST) sl_list_retry[sl_pend_type] = now + SL_LIST_RETRY_MS;
            sl_pend = PEND_NONE;
            if (++sl_fails >= SL_MAX_FAILS) return finish(now, SL_FAIL_MS);
        }
    }
    if (now < sl_next) return 1;

    n = arr_len(bag);
    for (i = 0; i < n; i++) {
        void* it = arr_at(bag, i);
        void* tpl;
        int lines, c, ok;
        if (!candidate(it, &lines)) continue;
        tpl = AT(it, JR_TEMPLATE, void*);
        c = shop_lines(AT(tpl, JS_ID, short), AT(tpl, JS_TYPE, signed char), now, 1);
        if (sl_pend == PEND_LIST) {
            ok = send_msg(CMD_SUB, 2, SUB_OPEN_SHOP, sl_pend_type, 0, 0);
        } else if (sl_pend == PEND_INFO) {
            ok = send_msg(CMD_ITEM_INFO, 2, sl_pend_type, sl_pend_slot, 0, 0);
        } else if (c >= 0 && lines < c && sl_mode == MODE_SELL) {
            sl_pend = PEND_SELL;
            sl_pend_item = it;
            sl_pend_slot = i;
            sl_pend_qty = AT(it, JR_QTY, int);
            ok = send_msg(CMD_SELL, 1, AT(it, JR_INDEX, int), 0, 1, sl_pend_qty > 1 ? sl_pend_qty : 1);
        } else if (c >= 0 && sl_mode == MODE_SELL && now >= sl_box_wait_until && box_space(ch) > 0) {
            sl_pend = PEND_BOX;                     /* du dong: cat vao ruong toi khi ruong day */
            sl_pend_item = it;
            sl_pend_slot = i;
            ok = send_msg(CMD_BAG_TO_BOX, 1, AT(it, JR_INDEX, int), 0, 0, 0);
        } else {
            continue;
        }
        if (!ok) {
            sl_pend = PEND_NONE;
            return finish(now, SL_IDLE_MS);
        }
        sl_next = now + SL_GAP_MS;
        sl_deadline = now + SL_REPLY_MS;
        return 1;
    }
    return finish(now, SL_IDLE_MS);                          /* het viec */
}

static void begin(int mode)
{
    sl_state = 1;
    sl_mode = (unsigned char)mode;
    sl_pend = PEND_NONE;
    sl_fails = 0;
    sl_sold = 0;
    sl_stored = 0;
    sl_last = 0;
    sl_next = 0;
}

/* Ban xong (khong phai xem truoc) -> luyen da ngay, tru khi luyen da dang nghi. */
static void stone_after_sell(long long now)
{
    if (sl_mode == MODE_SELL && cfg_stone && now >= s_wait_until) s_active = 1;
}

/* Goi tu quest_tick moi frame (now = ms). Tra ve 1 = dang don hanh trang. */
int bag_tick(long long now)
{
    if (sl_state) {
        if (sell_step(now)) return 1;
        stone_after_sell(now);
    } else if (cfg_sell && now >= sl_rest_until && s_active == 0 && auto_on()) {
        void* ch = me();
        void* bag = ch ? AT(ch, LM_BAG, void*) : 0;
        if (bag && bag_free(bag) <= BAG_FREE_MAX) {
            begin(MODE_SELL);
            if (sell_step(now)) return 1;
            stone_after_sell(now);
        }
    }
    if (!cfg_stone) return 0;
    stone_tick();
    return s_active != 0;
}

/* Tick / bo tick "Tu ban trang bi": bo phien dang do. */
void bag_reset(void)
{
    sl_state = 0;
    sl_pend = PEND_NONE;
    sl_fails = 0;
    sl_rest_until = 0;
    sl_box_wait_until = 0;
}

/* Dong "Xem truoc" cua menu Mod: lay so dong ban shop con thieu (khong ban gi). */
void bag_preview_start(void)
{
    if (!sl_state) begin(MODE_PREVIEW);
}

/* 1 = dang lay so dong tu shop (de menu bao "dang lay"). */
int bag_fetching(void)
{
    return sl_state != 0;
}

/* Dong thu k cua menu Xem truoc vao buf (toi da max ky tu); tra ve so ky tu,
 * -1 khi het mon. *st = 1: se ban, 3: se cat ruong, 0: giu, 2: chua biet so dong ban shop. */
int bag_describe(int k, wchar* buf, int max, int* st)
{
    void* ch = me();
    void* bag = ch ? AT(ch, LM_BAG, void*) : 0;
    int i, n = arr_len(bag), lines, c, len = 0;
    *st = 0;
    for (i = 0; i < n; i++) {
        void* it = arr_at(bag, i);
        void* tpl;
        Il2CppString* name;
        int j;
        if (!candidate(it, &lines)) continue;
        if (k-- > 0) continue;
        tpl = AT(it, JR_TEMPLATE, void*);
        name = AT(tpl, JS_NAME, Il2CppString*);
        for (j = 0; name && j < name->length && j < 40 && len < max; j++) buf[len++] = name->chars[j];
        len = put_text(buf, len, max, L": ");
        len = put_dec(buf, len, max, lines);
        c = shop_lines(AT(tpl, JS_ID, short), AT(tpl, JS_TYPE, signed char), 0, 0);
        if (c >= 0) {
            len = put_text(buf, len, max, L"/");
            len = put_dec(buf, len, max, c);
            if (lines < c) {
                *st = 1;
                len = put_text(buf, len, max, L" dòng -> bán");
            } else if (box_space(ch) > 0) {
                *st = 3;
                len = put_text(buf, len, max, L" dòng -> cất rương");
            } else if (box_space(ch) == 0) {
                len = put_text(buf, len, max, L" dòng, giữ (rương đầy)");
            } else {
                len = put_text(buf, len, max, L" dòng, giữ (mở rương 1 lần để cất)");
            }
        } else if (c == -2) {
            len = put_text(buf, len, max, L" dòng, không có trong shop, giữ");
        } else {
            *st = 2;
            len = put_text(buf, len, max, L" dòng, chưa biết số dòng shop, giữ");
        }
        return len;
    }
    return -1;
}
