; =============================================================================
;  HVNJ 186 - Code cave cho ban mod (assemble bang ml64, xem build_payload.py)
;
;  Toan bo code nam trong section moi ".hvnj" (RX), du lieu/trang thai nam
;  trong section ".hvnjd" (RW). Khong ghi vao vung code cua game, khong dung
;  dia chi tuyet doi (chi RIP-relative) nen tuong thich ASLR.
;
;  Quy uoc:
;   - Cac khoi dgj_ret / dgj_filter / clo_stage chay BEN TRONG stack frame cua
;     ham game (duoc nhay toi bang jmp). Khong duoc doi rsp, chi dung thanh ghi
;     volatile (+ doc rbx cua host). Unwind info dang "chained" toi ham host
;     do build_payload.py tao.
;   - Lenh ngay sau moi lenh call KHONG duoc la jmp/ret/add rsp/pop (de bo
;     unwinder cua Windows khong nham la epilogue).
;   - Ham IL2CPP: tham so cuoi cung la MethodInfo* (truyen 0).
; =============================================================================
OPTION CASEMAP:NONE

; ---- Ham game (RVA duoc build_payload.py resolve) ---------------------------
EXTERN mo_dgd:PROC              ; mo.dgd()  - xu ly NPC 25 khi toi noi (goc)
EXTERN mo_dga:PROC              ; mo.dga(sbyte index, la taskOrder) - bat auto nhiem vu cua game
EXTERN mo_dgf:PROC              ; mo.dgf(int idMap, int idNpc, sbyte option) - tim duong toi NPC
EXTERN mo_dgj:PROC              ; static mt mo.dgj() - chon quai cho auto thuong
EXTERN mo_dgv:PROC              ; static mo.dgv(bool isAuto) - bat/tat nut Auto
EXTERN mo_dgw:PROC              ; static mo.dgw(bool isAuto) - luu/xoa "bai train" ca.fxi
EXTERN eq_bkx:PROC              ; static eq eq.bkx() - bo tim duong; eq.hcr (+0FCh) = game dang tu quay ve
EXTERN lj_cpt:PROC              ; lj.cpt() - gui lenh ve lang khi chet (0xF7)
EXTERN mo_dky:PROC              ; static kk mo.dky(int npcId) - tim NPC trong map
EXTERN mo_djf:PROC              ; static lm mo.djf(int charId) - tim nhan vat khac trong map
EXTERN lm_cua:PROC              ; static lm lm.cua() - nhan vat cua minh
EXTERN lm_czd:PROC              ; lm.czd(float xTo, float yTo) - di bo toi toa do
EXTERN lj_cmy:PROC              ; static lj lj.cmy() - Service
EXTERN lj_menu:PROC             ; lj.menu(int npcId, int menuId, int optionId)
EXTERN ht_cbt:PROC              ; static float ht.cbt(x1, y1, x2, y2) - khoang cach
EXTERN bc_ctor:PROC             ; bc..ctor(sbyte command) - Message
EXTERN bl_bat:PROC              ; bl.bat(int value) - writeByte
EXTERN imp_GetSystemTimeAsFileTime:QWORD   ; o IAT cua KERNEL32

; ---- Ham runtime IL2CPP (game cung goi y nhu vay) ----------------------------
EXTERN il2cpp_init_md:PROC      ; InitializeRuntimeMetadata(void** slot) - resolve con tro TypeInfo
EXTERN il2cpp_class_init:PROC   ; chay static constructor cua class (Il2CppClass*)
EXTERN il2cpp_object_new:PROC   ; object_new(Il2CppClass*)
EXTERN il2cpp_array_new:PROC    ; array_new_specific(Il2CppClass* arrayClass, length)
EXTERN il2cpp_iface_invoke1:PROC ; InterfaceActionInvoker1: (slot, interface, obj, arg)

; ---- Con tro TypeInfo (Il2CppClass*), static fields o +0B8h -----------------
EXTERN ca_TypeInfo:QWORD        ; ca.fxf (+16h) = trang thai nut Auto
EXTERN mb_TypeInfo:QWORD        ; mb.naj (+5Ch) = map hien tai, mb.nal (+60h) = List<le> cong
EXTERN mo_TypeInfo:QWORD        ; mo.nfl (+80h) = List<la> nhiem vu (task order)
EXTERN gb_TypeInfo:QWORD        ; gb.hxf (+18h) = List<ko> thanh vien nhom, [0] = truong nhom
EXTERN mc_TypeInfo:QWORD        ; mc.nde (+108h) = diem cua da theo id, mc.ncx (+0D0h) = phi luyen
EXTERN hw_TypeInfo:QWORD        ; hw.jul (+128h) = popup dang mo
EXTERN ek_TypeInfo:QWORD        ; ek = popup Luyen da: ek.gxw (+0) = instance, ek.gyo (+8) = o luyen
EXTERN jr_array_TypeInfo:QWORD  ; jr[] (mang vat pham)
EXTERN bc_TypeInfo:QWORD        ; bc = Message
EXTERN hs_TypeInfo:QWORD        ; hs = interface ISession (slot 3 = gui message)

; ---- Diem quay lai ben trong ham game ---------------------------------------
EXTERN dgj_accept:PROC          ; mo.dgj: tiep tuc xet con quai (tinh khoang cach)
EXTERN dgj_skip:PROC            ; mo.dgj: bo qua con quai nay (inc ebx; vong lap)
EXTERN dgj_epilogue_tail:PROC   ; mo.dgj: epilogue, ngay sau "xor eax, eax"
EXTERN clo_store:PROC           ; lm.clo: "mov [rbx+200h], rax" roi return
EXTERN dgl_accept:PROC          ; mo.dgl: quai hop le -> tinh khoang cach
EXTERN dgl_skip:PROC            ; mo.dgl: bo qua quai nay (inc edi; vong lap)

PUBLIC dgj_ret, dgj_ret_end, dgj_filter, dgj_filter_end, clo_stage, clo_stage_end, dgl_filter, dgl_filter_end
PUBLIC quest_tick, party_leader, party_tick, die_tick, stone_tick
PUBLIC cfg_block, cfg_mob, cfg_stage, cfg_quest, cfg_accept, cfg_party, cfg_die, cfg_stone, cfg_stone_xu
PUBLIC cfg_stone_lo, cfg_stone_hi, cfg_tathu

; ---- Offset field (tu il2cpp dump) -----------------------------------------
STATICS         EQU 0B8h        ; Il2CppClass::static_fields
LM_STATUS       EQU 05Ch        ; lm.mfx (statusMe): 14 = chet, 5 = chet bay
LM_CLASS        EQU 170h        ; lm.mil (he phai 1..8)
LM_X            EQU 0B8h        ; lm.mgv
LM_Y            EQU 0BCh        ; lm.mgw
LM_CHARID       EQU 060h        ; lm.charId
LM_TARGET       EQU 200h        ; lm.mjn: con quai dang danh (nhan vat khac: game ghi khi nhan goi tan cong)
KO_CHARID       EQU 010h        ; ko.charId (thanh vien nhom)
MO_NKU          EQU 201h        ; mo.nku: pipeline nhiem vu cua game dang chay
MT_ALIVE        EQU 044h        ; mt.nut: 0 = quai khong con danh duoc (mo.dgj bo qua)
MT_LEVELBOSS    EQU 0B0h        ; mt.nvw (short): 1 = tinh anh, 2 = thu linh
MT_ISBOSS       EQU 0B4h        ; mt.nvy (bool): boss
LA_TASKID       EQU 10h         ; la.mad: 0 = nhiem vu hang ngay
LA_COUNT        EQU 14h         ; la.mae
LA_MAX          EQU 18h         ; la.maf
LA_KILLID       EQU 38h         ; la.maj: template quai can giet
LA_MAP          EQU 3Ch         ; la.mak
MT_TEMPLATE     EQU 78h         ; mt: template id (mo.dgl so voi la.maj)
TASK_DAILY      EQU 0           ; la.mad: nhiem vu hang ngay (NPC 25 menu 0)
TASK_TATHU      EQU 1           ; la.mad: nhiem vu ta thu (NPC 25 menu 1, xem mo.dgd)
LM_XU           EQU 140h        ; lm.mie (long)
LM_YEN          EQU 150h        ; lm.mig (long)
LM_BAG          EQU 1B8h        ; lm.miv: jr[] hanh trang
LM_BOX          EQU 1C0h        ; lm.miw: jr[] ruong do (null khi chua mo ruong lan nao)
JR_TEMPLATE     EQU 10h         ; jr.leu: js (template)
JR_INDEX        EQU 28h         ; jr.ley: indexUI
JR_LOCK         EQU 38h         ; jr.lfc: da khoa
JR_SELECTED     EQU 5Eh         ; jr.lfn: dang nam trong o cua popup Luyen da
JS_ID           EQU 10h         ; js.lfv (short)
JS_TYPE         EQU 12h         ; js.lfw (sbyte)
MC_CRYSTALS     EQU 108h        ; mc.nde: int[] diem cua da theo id
MC_CRYSTAL_FEE  EQU 0D0h        ; mc.ncx: int[] phi luyen ra da id t
HW_POPUP        EQU 128h        ; hw.jul
EK_STANDS       EQU 8           ; ek.gyo
LJ_SESSION      EQU 10h         ; lj.mdv: hs
BC_WRITER       EQU 20h         ; bc.frf: bl
CLASS_HAS_CCTOR EQU 133h        ; Il2CppClass: bit 2 = co static constructor
CLASS_CCTOR_DONE EQU 0E0h       ; Il2CppClass: static constructor da chay

STATUS_DEAD     EQU 14
STATUS_DEADFLY  EQU 5
MAP_TRIAL_FIRST EQU 161
MAP_TRIAL_LAST  EQU 167
NPC_TEACHER     EQU 25

STAGE_CLEAR_MS  EQU 2500        ; khong con quai lien tuc 2.5s moi coi la sach ai
STAGE_ACT_MS    EQU 1500        ; lap lai lenh di toi cong toi da moi 1.5s
Q_TICK_MS       EQU 500         ; nhip xu ly auto nhiem vu
Q_KICK_MS       EQU 8000        ; cach nhau toi thieu giua 2 lan goi mo.dga
Q_MAX_KICKS     EQU 3           ; so lan goi dga lien tiep khong tien trien -> dung
Q_NAV_MS        EQU 10000       ; tim duong ve truong toi da moi 10s
Q_MAX_NAV       EQU 6           ; 6 lan (~60s) khong ve duoc truong -> dung
Q_WALK_MS       EQU 2000        ; lenh di bo toi NPC toi da moi 2s
Q_ACCEPT_MS     EQU 4000        ; gui lenh nhan nhiem vu toi da moi 4s
Q_MAX_ACCEPT    EQU 4           ; 4 lan nhan khong duoc -> het luot / dung
T_KICK_MS       EQU 15000       ; dang o map ta thu: goi lai pipeline moi 15s de bat ta thu khi no xuat hien
P_TICK_MS       EQU 100         ; nhip xu ly danh theo nhom
P_MOVE_MS       EQU 500         ; lap lai lenh chay theo truong nhom toi da moi 0.5s
EQ_RETURNING    EQU 0FCh        ; eq.hcr: game dang tu ve lang / tu quay lai map
R_TICK_MS       EQU 200         ; nhip xu ly chet - quay ve
R_CPT_DELAY_MS  EQU 2000        ; chet 2s ma game chua tu ve lang -> mod gui lenh ve lang
R_CPT_MS        EQU 3000        ; lap lai lenh ve lang toi da moi 3s
R_NAV_MS        EQU 10000       ; tim duong ve map cu toi da moi 10s
R_MAX_NAV       EQU 6           ; 6 lan (~60s) khong ve duoc -> bo
R_RESUME_MS     EQU 1500        ; ve toi map cu, cho game tu bat Auto 1.5s roi moi bat
S_TICK_MS       EQU 1000        ; nhip kiem tra hanh trang
S_WAIT_MS       EQU 3000        ; sau moi lan luyen, cho server cap nhat hanh trang
S_IDLE_MS       EQU 30000       ; khong co cach luyen 100% / khong du tien -> xet lai sau 30s
S_FAIL_MS       EQU 300000      ; server khong xu ly S_MAX_FAILS lan lien tiep -> nghi 5 phut
S_BOX_FAIL_MS   EQU 1800000     ; server khong cho cat ruong -> 30 phut moi thu cat lai
S_MAX_FAILS     EQU 2
S_FREE_MAX      EQU 1           ; con <= 1 o trong thi coi la day
S_MAX_STONES    EQU 24          ; popup Luyen da co 24 o
S_MAX_ID        EQU 12          ; da id 0..11 (cap 1..12)
ITEM_TYPE_STONE EQU 26
CMD_STONE_XU    EQU 19          ; lj.cpc: luyen bang xu (giu trang thai khoa)
CMD_STONE_YEN   EQU 20          ; lj.cpe: luyen bang yen (+ xu neu thieu), da ra bi khoa
CMD_BAG_TO_BOX  EQU 17          ; lj.itemBagToBox: cat vat pham tu hanh trang vao ruong

; =============================================================================
_DATA SEGMENT ALIGN(16)
cfg_block       LABEL BYTE
cfg_magic       DB 'H','V','N','J'
cfg_version     DB 2
cfg_mob         DB 0            ; 1 = ne tinh anh/thu linh/boss
cfg_stage       DB 0            ; 1 = tu qua ai Thi Luyen
cfg_quest       DB 0            ; 1 = auto nhiem vu hang ngay
cfg_accept      DB 0            ; optionId cua menu(25, 0, ?) de NHAN nhiem vu
cfg_party       DB 0            ; 1 = danh theo nhom (di theo + danh cung muc tieu truong nhom)
cfg_die         DB 0            ; 1 = chet: ve lang ngay, quay lai map cu, bat lai Auto
cfg_stone       DB 0            ; 1 = tu luyen da tai cho khi hanh trang day (luc Auto)
cfg_stone_xu    DB 0            ; 1 = tra phi luyen bang xu, 0 = bang yen
cfg_stone_lo    DB 0            ; --stone-levels A-B: dung da tu cap A, luyen len toi cap B
cfg_stone_hi    DB 0            ;   (da cap B cat vao ruong); 0 = moi cap, khong cat ruong
cfg_tathu       DB 0            ; 1 = auto nhiem vu ta thu (cung vong lap voi auto nhiem vu ngay)
ALIGN 8
st_map          DD 0
st_party_map    DD -1           ; map co truong nhom o lan cuoi thay (danh theo nhom)
st_empty_since  DQ 0
st_last_act     DQ 0
st_ft           DQ 0
q_last_run      DQ 0
q_last_nav      DQ 0
q_last_accept   DQ 0
q_last_kick     DQ 0
q_last_task     DQ 0
q_last_count    DD 0
q_engaged       DB 0
q_prev_auto     DB 0
q_accept_tries  DB 0
q_kicks         DB 0
q_nav_tries     DB 0
p_active        DB 0
q_kind          DB 0            ; loai nhiem vu dang di nhan: TASK_DAILY / TASK_TATHU
q_done_daily    DB 0            ; 1 = nhan nhiem vu ngay khong duoc nua (het luot) trong lan bat Auto nay
q_done_tathu    DB 0
                DB 3 DUP (0)
p_last_tick     DQ 0
p_last_move     DQ 0
r_last_tick     DQ 0
r_dead_at       DQ 0
r_last_cpt      DQ 0
r_last_nav      DQ 0
r_resume_at     DQ 0
r_map           DD 0
r_pending       DB 0            ; 1 = da chet luc dang Auto, chua quay lai map cu
r_active        DB 0
r_nav_tries     DB 0
                DB 0
s_last_tick     DQ 0
s_wait_until    DQ 0
s_sent_item     DQ 0            ; vien da dau tien cua lenh truoc (de biet server da xu ly chua)
s_box_wait_until DQ 0
s_sent_slot     DD 0
s_fails         DB 0
s_sent_kind     DB 0            ; lenh truoc: 0 = luyen, 1 = cat ruong
s_active        DB 0            ; 1 = dang trong dot luyen (bat dau khi hanh trang day)
                DB 1 DUP (0)
s_cnt           DD 2 * S_MAX_ID DUP (0)  ; so da theo [nhom][id]; nhom 1 = da khoa (chi khi tra xu)
s_idx           DB S_MAX_STONES DUP (0)  ; indexUI cac vien se luyen
_DATA ENDS

_TEXT SEGMENT ALIGN(16)

; -----------------------------------------------------------------------------
; rax = mt. Nhay toi "yes" neu template cua con quai la con can giet cua mot
; nhiem vu ta thu dang nhan (la.mad = TASK_TATHU trong mo.nfl). Con ta thu la
; boss nen --mob khong duoc ne no. Chi dung rcx, rdx, r8-r10 (ca hai cho goi
; deu da het gia tri trong cac thanh ghi volatile).
; -----------------------------------------------------------------------------
TATHU_TARGET MACRO yes
    LOCAL tt_loop, tt_next, tt_no
    mov     rcx, qword ptr [mo_TypeInfo]
    test    rcx, rcx
    jz      tt_no
    mov     rcx, qword ptr [rcx+STATICS]
    test    rcx, rcx
    jz      tt_no
    mov     rcx, qword ptr [rcx+80h]    ; mo.nfl: List<la>
    test    rcx, rcx
    jz      tt_no
    mov     r8d, dword ptr [rcx+18h]
    mov     rcx, qword ptr [rcx+10h]
    test    rcx, rcx
    jz      tt_no
    mov     r9d, dword ptr [rax+MT_TEMPLATE]
    xor     edx, edx
tt_loop:
    cmp     edx, r8d
    jge     tt_no
    cmp     edx, dword ptr [rcx+18h]
    jae     tt_no
    mov     r10, qword ptr [rcx+rdx*8+20h]
    test    r10, r10
    jz      tt_next
    cmp     dword ptr [r10+LA_TASKID], TASK_TATHU
    jne     tt_next
    cmp     dword ptr [r10+LA_KILLID], r9d
    je      yes
tt_next:
    inc     edx
    jmp     tt_loop
tt_no:
ENDM

; -----------------------------------------------------------------------------
; mo.dgj: ket thuc vong lap -> tra ve con quai tot nhat (r14) thay vi null.
; Nhay toi tu "jge" cuoi vong lap. Tai dia chi 1BA085 game lam:
;   movaps xmm7,[rsp+30h] / xor eax,eax / movaps xmm6,[rsp+40h] / ...
; nen o day khoi phuc xmm7 roi vao thang sau "xor eax, eax".
; -----------------------------------------------------------------------------
ALIGN 16
dgj_ret PROC
    movaps  xmm7, xmmword ptr [rsp+30h]
    mov     rax, r14
    jmp     dgj_epilogue_tail
dgj_ret ENDP
dgj_ret_end LABEL NEAR

; -----------------------------------------------------------------------------
; mo.dgj: loc tung con quai. rax = mt (con quai dang xet), r12 = 0.
; -----------------------------------------------------------------------------
ALIGN 16
dgj_filter PROC
    cmp     byte ptr [cfg_stage], 0
    je      no_trial
    mov     rcx, qword ptr [mb_TypeInfo]
    test    rcx, rcx
    jz      no_trial
    mov     rcx, qword ptr [rcx+STATICS]
    test    rcx, rcx
    jz      no_trial
    movsx   ecx, word ptr [rcx+5Ch]
    sub     ecx, MAP_TRIAL_FIRST
    cmp     ecx, MAP_TRIAL_LAST - MAP_TRIAL_FIRST
    jbe     dgj_accept                  ; Thi Luyen: danh tat ca de don ai
no_trial:
    cmp     byte ptr [cfg_mob], 0
    je      dgj_accept
    cmp     word ptr [rax+MT_LEVELBOSS], 0
    jne     dgj_boss
    cmp     byte ptr [rax+MT_ISBOSS], 0
    je      dgj_accept
dgj_boss:
    TATHU_TARGET dgj_accept             ; con ta thu cua nhiem vu thi van danh
    jmp     dgj_skip
dgj_filter ENDP
dgj_filter_end LABEL NEAR

; -----------------------------------------------------------------------------
; mo.dgl (chon quai cho auto nhiem vu, cai cung --mob): thay cho doan kiem tra
; class init ngay sau "cmp [rax+44h], ebp / je". rax = mt cung template voi
; la.maj. Ne tinh anh / thu linh / boss, TRU con ta thu cua nhiem vu ta thu.
; -----------------------------------------------------------------------------
ALIGN 16
dgl_filter PROC
    cmp     word ptr [rax+MT_LEVELBOSS], 0
    jne     dgl_boss
    cmp     byte ptr [rax+MT_ISBOSS], 0
    je      dgl_accept
dgl_boss:
    TATHU_TARGET dgl_accept
    jmp     dgl_skip
dgl_filter ENDP
dgl_filter_end LABEL NEAR

; -----------------------------------------------------------------------------
; lm.clo: thay cho "call mo.dgj ; jmp 24B26F". rbx = lm (nhan vat).
; Danh theo nhom: neu dang di theo truong nhom thi muc tieu = con quai truong
;   nhom dang danh (hoac khong danh gi de chay theo), bo qua mo.dgj.
; Trong Thi Luyen (161..167): neu khong con quai lien tuc STAGE_CLEAR_MS thi
;   - map 161..166: di toi cong sang map ke tiep
;   - map 167     : tat Auto (dung o ai cuoi)
; -----------------------------------------------------------------------------
ALIGN 16
clo_stage PROC
    cmp     byte ptr [cfg_party], 0
    je      no_party
    call    party_leader
    test    rax, rax
    jz      no_party
    mov     rax, qword ptr [rax+LM_TARGET]
    test    rax, rax
    jz      party_store
    cmp     dword ptr [rax+MT_ALIVE], 0
    jne     party_store
    xor     eax, eax
party_store:
    jmp     clo_store
no_party:
    xor     ecx, ecx
    call    mo_dgj
    test    rax, rax
    jnz     found
    cmp     byte ptr [cfg_stage], 0
    je      store
    mov     rcx, qword ptr [mb_TypeInfo]
    test    rcx, rcx
    jz      reset_store
    mov     rcx, qword ptr [rcx+STATICS]
    test    rcx, rcx
    jz      reset_store
    movsx   edx, word ptr [rcx+5Ch]
    lea     ecx, [rdx-MAP_TRIAL_FIRST]
    cmp     ecx, MAP_TRIAL_LAST - MAP_TRIAL_FIRST
    ja      reset_store
    mov     ecx, dword ptr [rbx+LM_STATUS]
    cmp     ecx, STATUS_DEAD
    je      reset_store
    cmp     ecx, STATUS_DEADFLY
    je      reset_store
    cmp     edx, dword ptr [st_map]
    je      same_map
    mov     dword ptr [st_map], edx
    mov     qword ptr [st_empty_since], 0
    mov     qword ptr [st_last_act], 0
same_map:
    lea     rcx, [st_ft]
    call    qword ptr [imp_GetSystemTimeAsFileTime]
    mov     rax, qword ptr [st_ft]
    xor     edx, edx
    mov     ecx, 10000
    div     rcx                         ; rax = thoi gian (ms)
    ; danh theo nhom: truong nhom vua roi ai nay (vua thay o map nay, gio khong con)
    ; -> di toi cong ngay, khong cho STAGE_CLEAR_MS
    cmp     byte ptr [cfg_party], 0
    je      no_party_skip
    mov     ecx, dword ptr [st_map]
    cmp     ecx, dword ptr [st_party_map]
    jne     no_party_skip
    mov     dword ptr [st_party_map], -1
    lea     rcx, [rax-STAGE_CLEAR_MS]
    mov     qword ptr [st_empty_since], rcx
    mov     qword ptr [st_last_act], 0
no_party_skip:
    mov     rcx, qword ptr [st_empty_since]
    test    rcx, rcx
    jnz     have_since
    mov     qword ptr [st_empty_since], rax
    jmp     store_null
have_since:
    mov     rdx, rax
    sub     rdx, rcx
    cmp     rdx, STAGE_CLEAR_MS
    jb      store_null
    mov     rcx, rax
    sub     rcx, qword ptr [st_last_act]
    cmp     rcx, STAGE_ACT_MS
    jb      store_null
    mov     qword ptr [st_last_act], rax
    cmp     dword ptr [st_map], MAP_TRIAL_LAST
    jne     portal
    xor     ecx, ecx                    ; ai cuoi: tat Auto
    xor     edx, edx
    call    mo_dgv
    mov     qword ptr [st_empty_since], 0
    jmp     store_null
portal:
    mov     rcx, qword ptr [mb_TypeInfo]
    test    rcx, rcx
    jz      store_null
    mov     rcx, qword ptr [rcx+STATICS]
    test    rcx, rcx
    jz      store_null
    mov     r8, qword ptr [rcx+60h]     ; List<le> cong dich chuyen
    test    r8, r8
    jz      store_null
    mov     r10d, dword ptr [r8+18h]    ; _size
    mov     r8, qword ptr [r8+10h]      ; _items (le[])
    test    r8, r8
    jz      store_null
    ; mb.nal chua cong cua MOI map: le.mco (+18h) = map chua cong, le.mcp (+1Ah) = map dich
    ; (giong eq.bld). Uu tien cong sang map+1; khong co thi lay cong dau tien di toi
    ; mot ai lon hon (<= MAP_TRIAL_LAST).
    mov     edx, dword ptr [st_map]
    xor     ecx, ecx
    xor     eax, eax                    ; rax = cong du phong
wp_loop:
    cmp     ecx, r10d
    jge     wp_end
    cmp     ecx, dword ptr [r8+18h]     ; max_length cua mang
    jae     wp_end
    mov     r9, qword ptr [r8+rcx*8+20h]
    test    r9, r9
    jz      wp_next
    movsx   r11d, word ptr [r9+18h]
    cmp     r11d, edx
    jne     wp_next                     ; cong cua map khac
    movsx   r11d, word ptr [r9+1Ah]
    sub     r11d, edx
    cmp     r11d, 1
    je      wp_found                    ; cong sang map+1
    jl      wp_next                     ; cong lui
    test    rax, rax
    jnz     wp_next
    movsx   r11d, word ptr [r9+1Ah]
    cmp     r11d, MAP_TRIAL_LAST
    jg      wp_next
    mov     rax, r9
wp_next:
    inc     ecx
    jmp     wp_loop
wp_end:
    test    rax, rax
    jz      store_null
    mov     r9, rax
wp_found:
    movsx   eax, word ptr [r9+10h]      ; tam cua vung cong
    movsx   ecx, word ptr [r9+14h]
    add     eax, ecx
    sar     eax, 1
    movsx   ecx, word ptr [r9+12h]
    movsx   edx, word ptr [r9+16h]
    add     ecx, edx
    sar     ecx, 1
    cvtsi2ss xmm1, eax
    cvtsi2ss xmm2, ecx
    mov     rcx, rbx
    xor     r9d, r9d
    call    lm_czd
    xor     eax, eax
    jmp     clo_store
reset_store:
    mov     qword ptr [st_empty_since], 0
store_null:
    xor     eax, eax
store:
    jmp     clo_store
found:
    mov     qword ptr [st_empty_since], 0
    jmp     clo_store
clo_stage ENDP
clo_stage_end LABEL NEAR

; -----------------------------------------------------------------------------
; Goi tu mo.ctq thay cho "call mo.dgd". rcx = mo (this).
; Luyen da (stone_tick) chay doc lap. Danh theo nhom (party_tick) chay truoc
; auto nhiem vu; khi dang di theo truong nhom thi auto nhiem vu tam dung.
; Auto nhiem vu hang ngay dua tren pipeline "tu dong lam nhiem vu" cua game:
;   - Nguoi choi bat Auto (canh len cua ca.fxf) ngoai Thi Luyen -> kich hoat.
;   - Chua co nhiem vu ngay: ve truong theo he phai, toi NPC 25, gui
;     menu(25, 0, cfg_accept) de nhan.
;   - Co nhiem vu: goi mo.dga(index+2, task) (giong bam vao nhiem vu tren UI).
;     Game tu dich chuyen bang NPC (option 3), tu danh, tu ve tra (option 2).
;   - Dung khi: tat Auto luc dang danh trong map nhiem vu, het luot nhan,
;     pipeline ket nhieu lan, nhan vat chua vao lop.
; --tathu: nhiem vu ta thu (la.mad = 1) di cung pipeline. Nhan bang
;   menu(25, 1, cfg_accept) (game tra bang menu(25, 1, 2) trong mo.dgd), lam
;   sau nhiem vu ngay. Game tu tim duong toi map (khong dich chuyen). O map ma
;   ta thu chua xuat hien thi Auto danh quai thuong, cu T_KICK_MS goi lai
;   pipeline de no bat ta thu khi xuat hien (khong tinh vao Q_MAX_KICKS).
; -----------------------------------------------------------------------------
ALIGN 16
quest_tick PROC FRAME
    push    rbx
    .pushreg rbx
    push    rsi
    .pushreg rsi
    push    rdi
    .pushreg rdi
    push    r12
    .pushreg r12
    push    r13
    .pushreg r13
    push    r14
    .pushreg r14
    push    r15
    .pushreg r15
    sub     rsp, 40h
    .allocstack 40h
    .endprolog
    ; [rsp+20h] tham so thu 5 | [rsp+28h] npc x | [rsp+2Ch] npc y
    ; [rsp+30h] FILETIME      | [rsp+38h] trang thai Auto lan truoc | [rsp+3Ch] vi tri nhiem vu ta thu
    mov     rbx, rcx
    xor     edx, edx
    call    mo_dgd                      ; giu nguyen hanh vi goc
    cmp     byte ptr [cfg_stone], 0
    je      q_no_stone
    call    stone_tick
q_no_stone:
    cmp     byte ptr [cfg_die], 0
    je      q_no_die
    mov     rcx, rbx
    call    die_tick
    test    eax, eax
    jnz     q_resync_auto               ; dang xu ly chet / quay ve map cu
q_no_die:
    cmp     byte ptr [cfg_party], 0
    je      q_no_party
    call    party_tick
    test    eax, eax
    jnz     q_resync_auto               ; dang di theo truong nhom -> tam dung auto nhiem vu
q_no_party:
    cmp     byte ptr [cfg_quest], 0
    jne     q_on
    cmp     byte ptr [cfg_tathu], 0
    je      q_exit
q_on:

    lea     rcx, [rsp+30h]
    call    qword ptr [imp_GetSystemTimeAsFileTime]
    mov     rax, qword ptr [rsp+30h]
    xor     edx, edx
    mov     ecx, 10000
    div     rcx
    mov     r15, rax                    ; r15 = bay gio (ms)
    mov     rcx, rax
    sub     rcx, qword ptr [q_last_run]
    cmp     rcx, Q_TICK_MS
    jb      q_exit
    mov     qword ptr [q_last_run], r15

    mov     rax, qword ptr [mb_TypeInfo]
    test    rax, rax
    jz      q_exit
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      q_exit
    movsx   r13d, word ptr [rax+5Ch]    ; r13d = map hien tai
    mov     rax, qword ptr [ca_TypeInfo]
    test    rax, rax
    jz      q_exit
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      q_exit
    movzx   r12d, byte ptr [rax+16h]    ; r12d = Auto dang bat?
    movzx   eax, byte ptr [q_prev_auto]
    mov     byte ptr [rsp+38h], al
    mov     byte ptr [q_prev_auto], r12b

    lea     eax, [r13-MAP_TRIAL_FIRST]
    cmp     eax, MAP_TRIAL_LAST - MAP_TRIAL_FIRST
    jbe     q_exit                      ; Thi Luyen: tam dung

    cmp     byte ptr [q_engaged], 0
    jne     q_engaged_ok
    test    r12d, r12d
    jz      q_exit
    cmp     byte ptr [rsp+38h], 0
    jne     q_exit
    mov     byte ptr [q_engaged], 1     ; nguoi choi vua bat Auto
    mov     byte ptr [q_accept_tries], 0
    mov     byte ptr [q_kicks], 0
    mov     byte ptr [q_nav_tries], 0
    mov     byte ptr [q_done_daily], 0
    mov     byte ptr [q_done_tathu], 0
    mov     qword ptr [q_last_task], 0
q_engaged_ok:
    xor     ecx, ecx
    call    lm_cua
    test    rax, rax
    jz      q_exit
    mov     r14, rax                    ; r14 = nhan vat
    mov     eax, dword ptr [r14+LM_STATUS]
    cmp     eax, STATUS_DEAD
    je      q_exit
    cmp     eax, STATUS_DEADFLY
    je      q_exit

    ; ---- tim nhiem vu trong mo.nfl: nhiem vu ngay (--quest) truoc, roi ta thu (--tathu) ----
    xor     esi, esi                    ; rsi = nhiem vu ta thu tim thay, [rsp+3Ch] = vi tri
    mov     rax, qword ptr [mo_TypeInfo]
    test    rax, rax
    jz      q_exit
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      q_exit
    mov     rax, qword ptr [rax+80h]
    test    rax, rax
    jz      q_no_task
    mov     ecx, dword ptr [rax+18h]
    mov     rdx, qword ptr [rax+10h]
    test    rdx, rdx
    jz      q_no_task
    xor     edi, edi
q_find:
    cmp     edi, ecx
    jge     q_find_end
    cmp     edi, dword ptr [rdx+18h]
    jae     q_find_end
    mov     rax, qword ptr [rdx+rdi*8+20h]
    test    rax, rax
    jz      q_find_next
    mov     r8d, dword ptr [rax+LA_TASKID]
    cmp     r8d, TASK_DAILY
    jne     q_find_tathu
    cmp     byte ptr [cfg_quest], 0
    jne     q_have_task
    jmp     q_find_next
q_find_tathu:
    cmp     r8d, TASK_TATHU
    jne     q_find_next
    cmp     byte ptr [cfg_tathu], 0
    je      q_find_next
    test    rsi, rsi
    jnz     q_find_next
    mov     rsi, rax
    mov     dword ptr [rsp+3Ch], edi
q_find_next:
    inc     edi
    jmp     q_find
q_find_end:
    test    rsi, rsi
    jz      q_no_task
    mov     rax, rsi
    mov     edi, dword ptr [rsp+3Ch]

    ; ---- da co nhiem vu: dua cho pipeline cua game ----
q_have_task:
    mov     rsi, rax                    ; rsi = la, edi = vi tri trong list
    mov     byte ptr [q_accept_tries], 0
    mov     byte ptr [q_nav_tries], 0
    mov     eax, dword ptr [rsi+LA_COUNT]
    cmp     rsi, qword ptr [q_last_task]
    jne     q_progress
    cmp     eax, dword ptr [q_last_count]
    je      q_no_progress
q_progress:
    mov     qword ptr [q_last_task], rsi
    mov     dword ptr [q_last_count], eax
    mov     byte ptr [q_kicks], 0
q_no_progress:
    cmp     byte ptr [rbx+MO_NKU], 0
    jne     q_exit                      ; game dang tu di / tu tra nhiem vu
    mov     eax, dword ptr [rsi+LA_MAX]
    test    eax, eax
    jle     q_not_done
    cmp     dword ptr [rsi+LA_COUNT], eax
    jge     q_kick                      ; du so luong -> ve tra
q_not_done:
    cmp     r13d, dword ptr [rsi+LA_MAP]
    jne     q_kick                      ; chua o map nhiem vu -> di
    cmp     dword ptr [rsi+LA_TASKID], TASK_TATHU
    je      q_tathu_wait
    test    r12d, r12d
    jnz     q_exit                      ; dang Auto danh quai nhiem vu
    cmp     byte ptr [rsp+38h], 0
    jne     q_disengage                 ; nguoi choi vua tat Auto -> dung
q_kick:
    mov     rax, r15
    sub     rax, qword ptr [q_last_kick]
    cmp     rax, Q_KICK_MS
    jb      q_exit
    cmp     byte ptr [q_kicks], Q_MAX_KICKS
    jae     q_disengage
    inc     byte ptr [q_kicks]
    mov     qword ptr [q_last_kick], r15
    jmp     q_call_dga

    ; ---- o map ta thu: ta thu co the chua xuat hien. Goi lai pipeline moi
    ; T_KICK_MS (game tu tim con ta thu, thay thi bat Auto danh no), khong tinh
    ; vao Q_MAX_KICKS de cho duoc lau ----
q_tathu_wait:
    test    r12d, r12d
    jnz     q_tathu_kick
    cmp     byte ptr [rsp+38h], 0
    jne     q_disengage                 ; nguoi choi vua tat Auto -> dung
q_tathu_kick:
    mov     rax, r15
    sub     rax, qword ptr [q_last_kick]
    cmp     rax, T_KICK_MS
    jb      q_exit
    mov     qword ptr [q_last_kick], r15
    mov     byte ptr [q_kicks], 0
q_call_dga:
    mov     rcx, rbx
    lea     edx, [rdi+2]                ; index tren UI = vi tri + 2 (bat co 1A3h)
    mov     r8, rsi
    xor     r9d, r9d
    call    mo_dga
    nop
    jmp     q_resync_auto

    ; ---- chua co nhiem vu: ve truong nhan ----
q_no_task:
    mov     qword ptr [q_last_task], 0
    ; chon loai can nhan: nhiem vu ngay truoc, nhan het luot thi sang ta thu
    xor     eax, eax
    cmp     byte ptr [cfg_quest], 0
    je      q_pick_tathu
    cmp     byte ptr [q_done_daily], 0
    je      q_kind_ok
q_pick_tathu:
    mov     eax, TASK_TATHU
    cmp     byte ptr [cfg_tathu], 0
    je      q_disengage
    cmp     byte ptr [q_done_tathu], 0
    jne     q_disengage
q_kind_ok:
    cmp     al, byte ptr [q_kind]
    je      q_kind_same
    mov     byte ptr [q_kind], al
    mov     byte ptr [q_accept_tries], 0
q_kind_same:
    movsx   eax, byte ptr [r14+LM_CLASS]
    dec     eax
    cmp     eax, 7
    ja      q_disengage                 ; chua vao lop -> khong nhan duoc
    lea     rcx, [school_map]
    movzx   esi, byte ptr [rcx+rax]     ; esi = map truong
    cmp     r13d, esi
    je      q_in_school
    mov     byte ptr [q_accept_tries], 0
    cmp     byte ptr [rbx+MO_NKU], 0
    jne     q_exit                      ; dang tim duong
    mov     rax, r15
    sub     rax, qword ptr [q_last_nav]
    cmp     rax, Q_NAV_MS
    jb      q_exit
    cmp     byte ptr [q_nav_tries], Q_MAX_NAV
    jae     q_disengage
    inc     byte ptr [q_nav_tries]
    mov     qword ptr [q_last_nav], r15
    mov     rcx, rbx
    mov     edx, esi
    mov     r8d, NPC_TEACHER
    xor     r9d, r9d
    mov     qword ptr [rsp+20h], 0
    call    mo_dgf
    nop
    jmp     q_resync_auto

q_in_school:
    mov     byte ptr [q_nav_tries], 0
    mov     ecx, NPC_TEACHER
    xor     edx, edx
    call    mo_dky
    test    rax, rax
    jz      q_exit
    mov     rdi, rax                    ; rdi = NPC
    mov     r8, qword ptr [rdi]
    mov     rcx, rdi
    mov     rdx, qword ptr [r8+180h]
    call    qword ptr [r8+178h]         ; kk.cit() = x
    movss   dword ptr [rsp+28h], xmm0
    mov     r8, qword ptr [rdi]
    mov     rcx, rdi
    mov     rdx, qword ptr [r8+190h]
    call    qword ptr [r8+188h]         ; kk.ciu() = y
    movss   dword ptr [rsp+2Ch], xmm0
    movss   xmm0, dword ptr [rsp+28h]
    movss   xmm1, dword ptr [rsp+2Ch]
    movss   xmm2, dword ptr [r14+LM_X]
    movss   xmm3, dword ptr [r14+LM_Y]
    mov     qword ptr [rsp+20h], 0
    call    ht_cbt
    comiss  xmm0, dword ptr [near_dist]
    jb      q_near
    mov     rax, r15
    sub     rax, qword ptr [q_last_nav]
    cmp     rax, Q_WALK_MS
    jb      q_exit
    mov     qword ptr [q_last_nav], r15
    mov     rcx, r14
    movss   xmm1, dword ptr [rsp+28h]
    movss   xmm2, dword ptr [rsp+2Ch]
    xor     r9d, r9d
    call    lm_czd
    nop
    jmp     q_exit
q_near:
    mov     rax, r15
    sub     rax, qword ptr [q_last_accept]
    cmp     rax, Q_ACCEPT_MS
    jb      q_exit
    cmp     byte ptr [q_accept_tries], Q_MAX_ACCEPT
    jae     q_kind_exhausted            ; het luot loai nhiem vu nay trong ngay
    inc     byte ptr [q_accept_tries]
    mov     qword ptr [q_last_accept], r15
    xor     ecx, ecx
    call    lj_cmy
    test    rax, rax
    jz      q_exit
    mov     rcx, rax
    mov     edx, NPC_TEACHER
    movzx   r8d, byte ptr [q_kind]      ; menu 0 = nhiem vu ngay, menu 1 = ta thu
    movzx   r9d, byte ptr [cfg_accept]
    mov     qword ptr [rsp+20h], 0
    call    lj_menu
    nop
    jmp     q_exit
q_kind_exhausted:
    mov     byte ptr [q_accept_tries], 0
    cmp     byte ptr [q_kind], TASK_DAILY
    jne     q_tathu_exhausted
    mov     byte ptr [q_done_daily], 1  ; lan sau chuyen sang nhan ta thu (neu bat --tathu)
    jmp     q_exit
q_tathu_exhausted:
    mov     byte ptr [q_done_tathu], 1
    jmp     q_exit

q_disengage:
    mov     byte ptr [q_engaged], 0
    jmp     q_exit
q_resync_auto:
    ; dga/dgf tu tat Auto -> cap nhat de khong hieu nham la nguoi choi tat
    mov     rax, qword ptr [ca_TypeInfo]
    test    rax, rax
    jz      q_exit
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      q_exit
    movzx   eax, byte ptr [rax+16h]
    mov     byte ptr [q_prev_auto], al
q_exit:
    add     rsp, 40h
    pop     r15
    pop     r14
    pop     r13
    pop     r12
    pop     rdi
    pop     rsi
    pop     rbx
    ret
quest_tick ENDP

; -----------------------------------------------------------------------------
; Truong nhom de di theo. Tra ve rax = lm cua truong nhom, hoac 0 khi: tat
; --party, Auto dang tat, chua co nhom, minh la truong nhom (phan tu [0] cua
; danh sach nhom), truong nhom khong o cung map, hoac minh dang chet.
; -----------------------------------------------------------------------------
ALIGN 16
party_leader PROC FRAME
    push    rbx
    .pushreg rbx
    push    rsi
    .pushreg rsi
    sub     rsp, 28h
    .allocstack 28h
    .endprolog
    xor     esi, esi
    cmp     byte ptr [cfg_party], 0
    je      pl_done
    mov     rax, qword ptr [ca_TypeInfo]
    test    rax, rax
    jz      pl_done
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      pl_done
    cmp     byte ptr [rax+16h], 0       ; Auto phai dang bat
    je      pl_done
    xor     ecx, ecx
    call    lm_cua
    test    rax, rax
    jz      pl_done
    mov     rbx, rax                    ; rbx = nhan vat cua minh
    mov     eax, dword ptr [rbx+LM_STATUS]
    cmp     eax, STATUS_DEAD
    je      pl_done
    cmp     eax, STATUS_DEADFLY
    je      pl_done
    mov     rax, qword ptr [gb_TypeInfo]
    test    rax, rax
    jz      pl_done
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      pl_done
    mov     rax, qword ptr [rax+18h]    ; List<ko>
    test    rax, rax
    jz      pl_done
    cmp     dword ptr [rax+18h], 2      ; it nhat 2 nguoi
    jl      pl_done
    mov     rax, qword ptr [rax+10h]    ; ko[]
    test    rax, rax
    jz      pl_done
    cmp     dword ptr [rax+18h], 0
    je      pl_done
    mov     rax, qword ptr [rax+20h]    ; ko[0] = truong nhom
    test    rax, rax
    jz      pl_done
    mov     ecx, dword ptr [rax+KO_CHARID]
    cmp     ecx, dword ptr [rbx+LM_CHARID]
    je      pl_done                     ; minh la truong nhom
    xor     edx, edx
    call    mo_djf
    test    rax, rax
    jz      pl_done                     ; truong nhom khong o map nay
    cmp     rax, rbx
    je      pl_done
    mov     rsi, rax
pl_done:
    mov     rax, rsi
    add     rsp, 28h
    pop     rsi
    pop     rbx
    ret
party_leader ENDP

; -----------------------------------------------------------------------------
; Goi tu quest_tick moi frame. Tra ve eax = 1 neu dang danh theo nhom.
;  - Truong nhom dang danh mot con quai con song -> danh cung con do.
;  - Truong nhom khong danh gi -> bo muc tieu, chay toi cho truong nhom.
; -----------------------------------------------------------------------------
ALIGN 16
party_tick PROC FRAME
    push    rbx
    .pushreg rbx
    push    rsi
    .pushreg rsi
    push    rdi
    .pushreg rdi
    sub     rsp, 30h
    .allocstack 30h
    .endprolog
    lea     rcx, [rsp+20h]
    call    qword ptr [imp_GetSystemTimeAsFileTime]
    mov     rax, qword ptr [rsp+20h]
    xor     edx, edx
    mov     ecx, 10000
    div     rcx
    mov     rdi, rax                    ; rdi = bay gio (ms)
    mov     rcx, rax
    sub     rcx, qword ptr [p_last_tick]
    cmp     rcx, P_TICK_MS
    jb      pt_done
    mov     qword ptr [p_last_tick], rdi
    call    party_leader
    test    rax, rax
    jz      pt_inactive
    mov     rsi, rax                    ; rsi = truong nhom
    mov     byte ptr [p_active], 1
    mov     rax, qword ptr [mb_TypeInfo] ; nho map co truong nhom (Thi Luyen: truong nhom
    test    rax, rax                     ; roi ai thi thanh vien di toi cong ngay)
    jz      pt_no_map
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      pt_no_map
    movsx   eax, word ptr [rax+5Ch]
    mov     dword ptr [st_party_map], eax
pt_no_map:
    xor     ecx, ecx
    call    lm_cua
    test    rax, rax
    jz      pt_done
    mov     rbx, rax                    ; rbx = nhan vat cua minh
    mov     rax, qword ptr [rsi+LM_TARGET]
    test    rax, rax
    jz      pt_follow
    cmp     dword ptr [rax+MT_ALIVE], 0
    je      pt_follow
    mov     qword ptr [rbx+LM_TARGET], rax
    jmp     pt_done
pt_follow:
    mov     qword ptr [rbx+LM_TARGET], 0
    movss   xmm0, dword ptr [rbx+LM_X]
    subss   xmm0, dword ptr [rsi+LM_X]
    andps   xmm0, xmmword ptr [abs_mask]
    comiss  xmm0, dword ptr [follow_dist]
    ja      pt_move
    movss   xmm0, dword ptr [rbx+LM_Y]
    subss   xmm0, dword ptr [rsi+LM_Y]
    andps   xmm0, xmmword ptr [abs_mask]
    comiss  xmm0, dword ptr [follow_dist]
    jbe     pt_done
pt_move:
    mov     rax, rdi
    sub     rax, qword ptr [p_last_move]
    cmp     rax, P_MOVE_MS
    jb      pt_done
    mov     qword ptr [p_last_move], rdi
    mov     rcx, rbx
    movss   xmm1, dword ptr [rsi+LM_X]
    movss   xmm2, dword ptr [rsi+LM_Y]
    xor     r9d, r9d
    call    lm_czd
    nop
    jmp     pt_done
pt_inactive:
    mov     byte ptr [p_active], 0
pt_done:
    movzx   eax, byte ptr [p_active]
    add     rsp, 30h
    pop     rdi
    pop     rsi
    pop     rbx
    ret
party_tick ENDP

; -----------------------------------------------------------------------------
; Chet - quay ve (goi tu quest_tick moi frame, rcx = mo). Tra ve eax = 1 khi
; dang xu ly (de tam dung danh theo nhom / auto nhiem vu trong luc do).
; Game da co san chuoi: chet -> ve lang (lj.cpt) -> tu tim duong ve -> bat
; Auto, chi chay khi tuy chon Auto ca.fxg bat; --die rut thoi gian cho phat
; hien chet 15s -> ~1s. Ham nay bao dam phan con lai:
;  - Chet luc Auto dang bat: nho map. Sau 2s ma game chua tu ve lang (eq.hcr
;    = 0) thi gui lj.cpt().
;  - Song lai o map khac: neu game khong tu quay ve (eq.hcr = 0, khong dang
;    tim duong) thi mo.dgf(map cu) (toi da 6 lan, cach nhau 10s).
;  - Ve toi map cu ma Auto van tat: cho 1.5s roi bat Auto (dgv + dgw).
;  - Bo qua Thi Luyen; khi auto nhiem vu ngay dang chay thi de no tu lo.
; -----------------------------------------------------------------------------
ALIGN 16
die_tick PROC FRAME
    push    rbx
    .pushreg rbx
    push    rsi
    .pushreg rsi
    push    rdi
    .pushreg rdi
    push    r12
    .pushreg r12
    sub     rsp, 38h
    .allocstack 38h
    .endprolog
    ; [rsp+20h] tham so thu 5 | [rsp+28h] FILETIME
    mov     rbx, rcx                    ; rbx = mo
    lea     rcx, [rsp+28h]
    call    qword ptr [imp_GetSystemTimeAsFileTime]
    mov     rax, qword ptr [rsp+28h]
    xor     edx, edx
    mov     ecx, 10000
    div     rcx
    mov     r12, rax                    ; r12 = bay gio (ms)
    mov     rcx, rax
    sub     rcx, qword ptr [r_last_tick]
    cmp     rcx, R_TICK_MS
    jb      dt_cached
    mov     qword ptr [r_last_tick], r12
    mov     byte ptr [r_active], 0
    xor     ecx, ecx
    call    lm_cua
    test    rax, rax
    jz      dt_cached
    mov     rsi, rax                    ; rsi = nhan vat
    mov     rax, qword ptr [mb_TypeInfo]
    test    rax, rax
    jz      dt_cached
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      dt_cached
    movsx   edi, word ptr [rax+5Ch]     ; edi = map hien tai
    mov     eax, dword ptr [rsi+LM_STATUS]
    cmp     eax, STATUS_DEAD
    je      dt_dead
    cmp     eax, STATUS_DEADFLY
    je      dt_dead

    ; ---- dang song ----
    cmp     byte ptr [r_pending], 0
    je      dt_cached
    cmp     byte ptr [q_engaged], 0
    jne     dt_clear                    ; auto nhiem vu ngay tu dua ve
    cmp     edi, dword ptr [r_map]
    jne     dt_away
    mov     rax, qword ptr [ca_TypeInfo]
    test    rax, rax
    jz      dt_busy
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      dt_busy
    cmp     byte ptr [rax+16h], 0
    jne     dt_clear                    ; da ve map cu, Auto dang bat -> xong
    mov     rax, qword ptr [r_resume_at]
    test    rax, rax
    jnz     dt_check_resume
    lea     rax, [r12+R_RESUME_MS]
    mov     qword ptr [r_resume_at], rax
    jmp     dt_busy
dt_check_resume:
    cmp     r12, rax
    jb      dt_busy
    mov     cl, 1                       ; bat lai Auto nhu khi bam nut Auto
    xor     edx, edx
    call    mo_dgv
    mov     cl, 1
    xor     edx, edx
    call    mo_dgw
    nop
    jmp     dt_clear
dt_away:
    mov     qword ptr [r_resume_at], 0
    xor     ecx, ecx
    call    eq_bkx
    test    rax, rax
    jz      dt_busy
    cmp     byte ptr [rax+EQ_RETURNING], 0
    jne     dt_busy                     ; game dang tu quay ve
    cmp     byte ptr [rbx+MO_NKU], 0
    jne     dt_busy                     ; dang tim duong
    mov     rax, r12
    sub     rax, qword ptr [r_last_nav]
    cmp     rax, R_NAV_MS
    jb      dt_busy
    cmp     byte ptr [r_nav_tries], R_MAX_NAV
    jae     dt_clear                    ; khong ve duoc -> bo
    inc     byte ptr [r_nav_tries]
    mov     qword ptr [r_last_nav], r12
    mov     rcx, rbx
    mov     edx, dword ptr [r_map]
    mov     r8d, -1                     ; khong can toi NPC nao
    xor     r9d, r9d
    mov     qword ptr [rsp+20h], 0
    call    mo_dgf
    nop
    jmp     dt_busy

    ; ---- dang chet ----
dt_dead:
    lea     eax, [rdi-MAP_TRIAL_FIRST]
    cmp     eax, MAP_TRIAL_LAST - MAP_TRIAL_FIRST
    jbe     dt_cached                   ; Thi Luyen: de game tu xu ly
    cmp     byte ptr [r_pending], 0
    jne     dt_dead_pending
    mov     rax, qword ptr [ca_TypeInfo]
    test    rax, rax
    jz      dt_cached
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      dt_cached
    cmp     byte ptr [rax+16h], 0
    jne     dt_record                   ; chet luc dang Auto
    xor     ecx, ecx
    call    eq_bkx
    test    rax, rax
    jz      dt_cached
    cmp     byte ptr [rax+EQ_RETURNING], 0
    je      dt_cached                   ; khong Auto, game cung khong xu ly -> khong lam gi
dt_record:
    mov     byte ptr [r_pending], 1
    mov     dword ptr [r_map], edi
    mov     qword ptr [r_dead_at], r12
    mov     qword ptr [r_last_nav], 0
    mov     qword ptr [r_resume_at], 0
    mov     byte ptr [r_nav_tries], 0
dt_dead_pending:
    mov     rax, r12
    sub     rax, qword ptr [r_dead_at]
    cmp     rax, R_CPT_DELAY_MS
    jb      dt_busy
    mov     rax, r12
    sub     rax, qword ptr [r_last_cpt]
    cmp     rax, R_CPT_MS
    jb      dt_busy
    xor     ecx, ecx
    call    eq_bkx
    test    rax, rax
    jz      dt_busy
    cmp     byte ptr [rax+EQ_RETURNING], 0
    jne     dt_busy                     ; game da tu gui lenh ve lang
    mov     qword ptr [r_last_cpt], r12
    xor     ecx, ecx
    call    lj_cmy
    test    rax, rax
    jz      dt_busy
    mov     rcx, rax
    xor     edx, edx
    call    lj_cpt
    nop
    jmp     dt_busy
dt_clear:
    mov     byte ptr [r_pending], 0
    jmp     dt_cached
dt_busy:
    mov     byte ptr [r_active], 1
dt_cached:
    movzx   eax, byte ptr [r_active]
    add     rsp, 38h
    pop     r12
    pop     rdi
    pop     rsi
    pop     rbx
    ret
die_tick ENDP

; -----------------------------------------------------------------------------
; Luyen da tai cho (goi tu quest_tick moi frame). Khi Auto dang bat va hanh
; trang con <= S_FREE_MAX o trong: chon mot nhom da co tong diem (mc.nde) BANG
; DUNG diem cua mot cap cao hon (= ti le 100%, khong mat da), uu tien cap
; thap nhat, toi da 24 vien, du phi (mc.ncx), roi gui packet giong nut "Luyen"
; cua popup Luyen da (ek.bjx -> lj.cpe / lj.cpc) nhung khong mo hop thoai:
;   - tra yen: cmd 20, da ra bi khoa;
;   - tra xu : cmd 19, chi gop da cung trang thai khoa de da khong khoa van
;              khong khoa.
; Hanh trang day thi bat dau mot dot luyen: luyen tung nhom, moi lan cho
; S_WAIT_MS de server cap nhat hanh trang, cu the cho toi khi khong con nhom
; nao luyen 100% duoc (da cap thap duoc nang dan len).
; --stone-levels A-B: chi dung da tu cap A, luyen dan len toi cap B; vien da
; cap B duoc cat vao ruong do (cmd 17 giong lj.itemBagToBox) neu client da nap
; ruong (lm.miw) va ruong con cho.
; Neu sau S_MAX_FAILS lan hanh trang khong doi (server tu choi, vd khong o gan
; NPC): luyen -> nghi S_FAIL_MS; cat ruong -> chi ngung cat S_BOX_FAIL_MS.
; Bo qua da dang chon trong popup va khi popup Luyen da dang mo.
; -----------------------------------------------------------------------------
ALIGN 16
stone_tick PROC FRAME
    push    rbx
    .pushreg rbx
    push    rbp
    .pushreg rbp
    push    rsi
    .pushreg rsi
    push    rdi
    .pushreg rdi
    push    r12
    .pushreg r12
    push    r13
    .pushreg r13
    push    r14
    .pushreg r14
    push    r15
    .pushreg r15
    sub     rsp, 68h
    .allocstack 68h
    .endprolog
    ; [rsp+20h] FILETIME | [rsp+28h] cmd se gui | [rsp+30h] so vien lay theo id (S_MAX_ID x DD)
    lea     rcx, [rsp+20h]
    call    qword ptr [imp_GetSystemTimeAsFileTime]
    mov     rax, qword ptr [rsp+20h]
    xor     edx, edx
    mov     ecx, 10000
    div     rcx
    mov     r15, rax                    ; r15 = bay gio (ms)
    mov     rcx, rax
    sub     rcx, qword ptr [s_last_tick]
    cmp     rcx, S_TICK_MS
    jb      sk_done
    mov     qword ptr [s_last_tick], r15
    cmp     r15, qword ptr [s_wait_until]
    jb      sk_done

    mov     rax, qword ptr [ca_TypeInfo]
    test    rax, rax
    jz      sk_done
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      sk_done
    cmp     byte ptr [rax+16h], 0       ; chi khi Auto dang bat
    je      sk_done
    mov     rax, qword ptr [hw_TypeInfo] ; popup Luyen da dang mo -> nguoi choi tu luyen
    test    rax, rax
    jz      sk_done
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      sk_done
    mov     rcx, qword ptr [rax+HW_POPUP]
    test    rcx, rcx
    jz      sk_no_popup
    mov     rax, qword ptr [ek_TypeInfo]
    test    rax, rax
    jz      sk_no_popup
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      sk_no_popup
    cmp     rcx, qword ptr [rax]
    je      sk_done
sk_no_popup:
    xor     ecx, ecx
    call    lm_cua
    test    rax, rax
    jz      sk_done
    mov     rbx, rax                    ; rbx = nhan vat
    mov     eax, dword ptr [rbx+LM_STATUS]
    cmp     eax, STATUS_DEAD
    je      sk_done
    cmp     eax, STATUS_DEADFLY
    je      sk_done
    mov     rsi, qword ptr [rbx+LM_BAG]
    test    rsi, rsi
    jz      sk_done                     ; rsi = jr[] hanh trang
    mov     rax, qword ptr [mc_TypeInfo]
    test    rax, rax
    jz      sk_done
    mov     rax, qword ptr [rax+STATICS]
    test    rax, rax
    jz      sk_done
    mov     r12, qword ptr [rax+MC_CRYSTALS]
    test    r12, r12
    jz      sk_done
    mov     r13, qword ptr [rax+MC_CRYSTAL_FEE]
    test    r13, r13
    jz      sk_done
    ; r14d = cap dich lon nhat = min(len diem, len phi, S_MAX_ID) - 1
    mov     eax, dword ptr [r12+18h]
    mov     ecx, dword ptr [r13+18h]
    cmp     ecx, eax
    cmovb   eax, ecx
    mov     ecx, S_MAX_ID
    cmp     eax, ecx
    cmova   eax, ecx
    dec     eax
    movzx   ecx, byte ptr [cfg_stone_hi] ; --stone-levels A-B: da ra toi da cap B (id B-1)
    test    ecx, ecx
    jz      sk_hi_ok
    dec     ecx
    cmp     eax, ecx
    cmova   eax, ecx
sk_hi_ok:
    cmp     eax, 1
    jl      sk_done
    mov     r14d, eax

    ; ---- dem o trong va da theo [nhom][id] ----
    lea     rdi, [s_cnt]
    xor     eax, eax
    mov     ecx, 2 * S_MAX_ID
    rep stosd
    movzx   r11d, byte ptr [cfg_stone_lo] ; r11d = id nho nhat duoc dung (= cap - 1)
    test    r11d, r11d
    jz      sk_lo_ok
    dec     r11d
sk_lo_ok:
    lea     r10, [s_cnt]
    mov     r9d, dword ptr [rsi+18h]
    xor     edi, edi                    ; edi = so o trong
    mov     ebp, -1                     ; ebp = o cua vien da dat cap B (de cat ruong)
    xor     ecx, ecx
sk_scan:
    cmp     ecx, r9d
    jae     sk_scanned
    mov     rax, qword ptr [rsi+rcx*8+20h]
    test    rax, rax
    jnz     sk_scan_item
    inc     edi
    jmp     sk_scan_next
sk_scan_item:
    mov     rdx, qword ptr [rax+JR_TEMPLATE]
    test    rdx, rdx
    jz      sk_scan_next
    cmp     byte ptr [rdx+JS_TYPE], ITEM_TYPE_STONE
    jne     sk_scan_next
    cmp     byte ptr [rax+JR_SELECTED], 0
    jne     sk_scan_next
    movsx   edx, word ptr [rdx+JS_ID]
    movzx   r8d, byte ptr [cfg_stone_hi]
    test    r8d, r8d
    jz      sk_scan_stone
    dec     r8d
    cmp     edx, r8d
    jne     sk_scan_stone
    test    ebp, ebp
    jns     sk_scan_next
    mov     ebp, ecx                    ; vien dau tien dat cap B
    jmp     sk_scan_next
sk_scan_stone:
    cmp     edx, r14d
    jae     sk_scan_next                ; id < cap dich lon nhat (loai ca id am)
    cmp     edx, r11d
    jb      sk_scan_next                ; duoi cap thap nhat cua --stone-levels
    cmp     byte ptr [cfg_stone_xu], 0
    je      sk_scan_count
    cmp     byte ptr [rax+JR_LOCK], 0
    je      sk_scan_count
    add     edx, S_MAX_ID               ; nhom da khoa
sk_scan_count:
    inc     dword ptr [r10+rdx*4]
sk_scan_next:
    inc     ecx
    jmp     sk_scan
sk_scanned:
    ; ---- lenh truoc (luyen / cat ruong) da duoc server xu ly chua? ----
    mov     rax, qword ptr [s_sent_item]
    test    rax, rax
    jz      sk_check_box
    mov     qword ptr [s_sent_item], 0
    mov     ecx, dword ptr [s_sent_slot]
    cmp     ecx, r9d
    jae     sk_changed
    cmp     rax, qword ptr [rsi+rcx*8+20h]
    jne     sk_changed
    inc     byte ptr [s_fails]
    cmp     byte ptr [s_fails], S_MAX_FAILS
    jb      sk_check_box
    mov     byte ptr [s_fails], 0
    cmp     byte ptr [s_sent_kind], 0
    jne     sk_box_failed
    mov     byte ptr [s_active], 0
    mov     rax, r15
    add     rax, S_FAIL_MS
    mov     qword ptr [s_wait_until], rax
    jmp     sk_done
sk_box_failed:
    mov     rax, r15                    ; server khong cho cat ruong: chi ngung cat, van luyen
    add     rax, S_BOX_FAIL_MS
    mov     qword ptr [s_box_wait_until], rax
    jmp     sk_check_full
sk_changed:
    mov     byte ptr [s_fails], 0

    ; ---- cat vien da cap B vao ruong do ----
sk_check_box:
    test    ebp, ebp
    js      sk_check_full
    cmp     r15, qword ptr [s_box_wait_until]
    jb      sk_check_full
    mov     rax, qword ptr [rbx+LM_BOX]
    test    rax, rax
    jz      sk_check_full               ; client chua nap ruong (chua mo ruong lan nao)
    mov     r9d, dword ptr [rax+18h]
    xor     ecx, ecx
sk_box_free:
    cmp     ecx, r9d
    jae     sk_check_full               ; ruong day
    cmp     qword ptr [rax+rcx*8+20h], 0
    je      sk_box_send
    inc     ecx
    jmp     sk_box_free
sk_box_send:
    mov     rax, qword ptr [rsi+rbp*8+20h]
    mov     qword ptr [s_sent_item], rax
    mov     dword ptr [s_sent_slot], ebp
    mov     edx, dword ptr [rax+JR_INDEX]
    mov     byte ptr [s_idx], dl
    mov     r14d, 1
    mov     byte ptr [s_sent_kind], 1
    mov     dword ptr [rsp+28h], CMD_BAG_TO_BOX
    jmp     sk_send

    ; ---- dot luyen: bat dau khi hanh trang day, chay toi khi het nhom luyen duoc ----
sk_check_full:
    cmp     byte ptr [s_active], 0
    jne     sk_plan
    cmp     edi, S_FREE_MAX
    ja      sk_done
    mov     byte ptr [s_active], 1
sk_plan:

    ; ---- chon nhom da: rdi = hang dem cua nhom, ebp = cap dich t ----
    lea     rdi, [s_cnt]
sk_group:
    mov     ebp, 1
sk_target:
    cmp     ebp, r14d
    jg      sk_next_group
    movsxd  r8, dword ptr [r12+rbp*4+20h]   ; r8 = diem can = mc.nde[t]
    test    r8, r8
    jle     sk_next_target
    xor     r10d, r10d                  ; r10 = tong diem
    xor     r11d, r11d                  ; r11d = so vien
    lea     ecx, [rbp-1]                ; lay tu cap t-1 xuong 0
sk_take:
    movsxd  r9, dword ptr [r12+rcx*4+20h]
    xor     eax, eax
    test    r9, r9
    jle     sk_take_put
    mov     rax, r8
    sub     rax, r10
    xor     edx, edx
    div     r9                          ; rax = so vien toi da con vua
    mov     edx, dword ptr [rdi+rcx*4]
    cmp     rax, rdx
    cmova   rax, rdx
    mov     edx, S_MAX_STONES
    sub     edx, r11d
    cmp     rax, rdx
    cmova   rax, rdx
    add     r11d, eax
    mov     rdx, rax
    imul    rdx, r9
    add     r10, rdx
sk_take_put:
    mov     dword ptr [rsp+rcx*4+30h], eax
    dec     ecx
    jns     sk_take
    cmp     r10, r8
    jne     sk_next_target              ; khong ra dung 100%
    cmp     r11d, 2
    jb      sk_next_target
    movsxd  rax, dword ptr [r13+rbp*4+20h]  ; phi luyen ra da t
    mov     rdx, qword ptr [rbx+LM_XU]
    cmp     byte ptr [cfg_stone_xu], 0
    jne     sk_fee
    add     rdx, qword ptr [rbx+LM_YEN]
sk_fee:
    cmp     rax, rdx
    jle     sk_found
sk_next_target:
    inc     ebp
    jmp     sk_target
sk_next_group:
    cmp     byte ptr [cfg_stone_xu], 0
    je      sk_idle
    lea     rax, [s_cnt + 4 * S_MAX_ID]
    cmp     rdi, rax
    je      sk_idle
    mov     rdi, rax
    jmp     sk_group

    ; ---- lay indexUI cac vien da chon ----
sk_found:
    lea     rax, [s_cnt + 4 * S_MAX_ID]
    xor     r9d, r9d
    cmp     rdi, rax
    sete    r9b                         ; r9d = nhom (1 = da khoa)
    mov     r10d, dword ptr [rsi+18h]
    lea     rdi, [s_idx]
    xor     ecx, ecx
    xor     r11d, r11d
sk_pick:
    cmp     ecx, r10d
    jae     sk_picked
    mov     rax, qword ptr [rsi+rcx*8+20h]
    test    rax, rax
    jz      sk_pick_next
    mov     rdx, qword ptr [rax+JR_TEMPLATE]
    test    rdx, rdx
    jz      sk_pick_next
    cmp     byte ptr [rdx+JS_TYPE], ITEM_TYPE_STONE
    jne     sk_pick_next
    movsx   edx, word ptr [rdx+JS_ID]
    cmp     edx, ebp
    jae     sk_pick_next
    cmp     byte ptr [rax+JR_SELECTED], 0
    jne     sk_pick_next
    cmp     byte ptr [cfg_stone_xu], 0
    je      sk_pick_take
    movzx   r8d, byte ptr [rax+JR_LOCK]
    test    r8d, r8d
    setnz   r8b
    cmp     r8d, r9d
    jne     sk_pick_next
sk_pick_take:
    cmp     dword ptr [rsp+rdx*4+30h], 0
    je      sk_pick_next
    dec     dword ptr [rsp+rdx*4+30h]
    mov     edx, dword ptr [rax+JR_INDEX]
    mov     byte ptr [rdi+r11], dl
    test    r11d, r11d
    jnz     sk_pick_more
    mov     qword ptr [s_sent_item], rax
    mov     dword ptr [s_sent_slot], ecx
sk_pick_more:
    inc     r11d
    cmp     r11d, S_MAX_STONES
    jae     sk_picked
sk_pick_next:
    inc     ecx
    jmp     sk_pick
sk_picked:
    cmp     r11d, 2
    jb      sk_abort
    mov     r14d, r11d                  ; r14d = so vien se gui
    mov     byte ptr [s_sent_kind], 0
    mov     dword ptr [rsp+28h], CMD_STONE_YEN
    cmp     byte ptr [cfg_stone_xu], 0
    je      sk_cmd_ok
    mov     dword ptr [rsp+28h], CMD_STONE_XU
sk_cmd_ok:

    ; ---- ek.gyo phai khac null: ham nhan ket qua cua game (lm.cyg) duyet mang nay ----
    lea     rcx, [ek_TypeInfo]
    call    il2cpp_init_md
    mov     rcx, qword ptr [ek_TypeInfo]
    test    rcx, rcx
    jz      sk_abort
    test    byte ptr [rcx+CLASS_HAS_CCTOR], 2
    jz      sk_ek_ready
    cmp     dword ptr [rcx+CLASS_CCTOR_DONE], 0
    jne     sk_ek_ready
    call    il2cpp_class_init
    mov     rcx, qword ptr [ek_TypeInfo]
sk_ek_ready:
    mov     rax, qword ptr [rcx+STATICS]
    test    rax, rax
    jz      sk_abort
    cmp     qword ptr [rax+EK_STANDS], 0
    jne     sk_have_stands
    lea     rcx, [jr_array_TypeInfo]
    call    il2cpp_init_md
    mov     rcx, qword ptr [jr_array_TypeInfo]
    test    rcx, rcx
    jz      sk_abort
    mov     edx, S_MAX_STONES           ; giong ek.bjt: gyo = new jr[24]
    call    il2cpp_array_new
    test    rax, rax
    jz      sk_abort
    mov     rcx, qword ptr [ek_TypeInfo]
    mov     rcx, qword ptr [rcx+STATICS]
    mov     qword ptr [rcx+EK_STANDS], rax
sk_have_stands:
sk_send:
    ; ---- gui packet: new Message([rsp+28h]), writeByte(s_idx[0..r14d)), session.zs(msg) ----
    xor     ecx, ecx
    call    lj_cmy
    test    rax, rax
    jz      sk_abort
    mov     rbp, rax                    ; rbp = Service
    cmp     qword ptr [rbp+LJ_SESSION], 0
    je      sk_abort
    lea     rcx, [bc_TypeInfo]
    call    il2cpp_init_md
    lea     rcx, [hs_TypeInfo]
    call    il2cpp_init_md
    mov     rcx, qword ptr [bc_TypeInfo]
    test    rcx, rcx
    jz      sk_abort
    call    il2cpp_object_new
    test    rax, rax
    jz      sk_abort
    mov     rdi, rax                    ; rdi = Message
    mov     rcx, rax
    mov     edx, dword ptr [rsp+28h]
    xor     r8d, r8d
    call    bc_ctor
    xor     esi, esi
sk_write:
    cmp     esi, r14d
    jae     sk_flush
    mov     rcx, qword ptr [rdi+BC_WRITER]
    test    rcx, rcx
    jz      sk_abort
    lea     rax, [s_idx]
    movzx   edx, byte ptr [rax+rsi]
    xor     r8d, r8d
    call    bl_bat
    inc     esi
    jmp     sk_write
sk_flush:
    mov     r8, qword ptr [rbp+LJ_SESSION]
    test    r8, r8
    jz      sk_abort
    mov     rdx, qword ptr [hs_TypeInfo]
    test    rdx, rdx
    jz      sk_abort
    mov     ecx, 3                      ; hs slot 3 = zs(bc message)
    mov     r9, rdi
    call    il2cpp_iface_invoke1
    nop
    mov     rax, r15
    add     rax, S_WAIT_MS
    mov     qword ptr [s_wait_until], rax
    jmp     sk_done
sk_abort:
    mov     qword ptr [s_sent_item], 0
sk_idle:
    mov     byte ptr [s_active], 0      ; het nhom luyen duoc -> ket thuc dot luyen
    mov     rax, r15
    add     rax, S_IDLE_MS
    mov     qword ptr [s_wait_until], rax
sk_done:
    add     rsp, 68h
    pop     r15
    pop     r14
    pop     r13
    pop     r12
    pop     rdi
    pop     rsi
    pop     rbp
    pop     rbx
    ret
stone_tick ENDP

; ---- hang so chi doc --------------------------------------------------------
ALIGN 16
abs_mask        DD 7FFFFFFFh, 7FFFFFFFh, 7FFFFFFFh, 7FFFFFFFh
near_dist       REAL4 24.0                          ; nguong "dung canh NPC" cua game
follow_dist     REAL4 40.0                          ; cach truong nhom hon 40 thi chay theo
school_map      DB 1, 1, 72, 72, 27, 27, 160, 160   ; he phai 1..8 -> map truong

_TEXT ENDS
END
