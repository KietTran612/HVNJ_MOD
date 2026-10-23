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
EXTERN mo_dky:PROC              ; static kk mo.dky(int npcId) - tim NPC trong map
EXTERN mo_djf:PROC              ; static lm mo.djf(int charId) - tim nhan vat khac trong map
EXTERN lm_cua:PROC              ; static lm lm.cua() - nhan vat cua minh
EXTERN lm_czd:PROC              ; lm.czd(float xTo, float yTo) - di bo toi toa do
EXTERN lj_cmy:PROC              ; static lj lj.cmy() - Service
EXTERN lj_menu:PROC             ; lj.menu(int npcId, int menuId, int optionId)
EXTERN ht_cbt:PROC              ; static float ht.cbt(x1, y1, x2, y2) - khoang cach
EXTERN imp_GetSystemTimeAsFileTime:QWORD   ; o IAT cua KERNEL32

; ---- Con tro TypeInfo (Il2CppClass*), static fields o +0B8h -----------------
EXTERN ca_TypeInfo:QWORD        ; ca.fxf (+16h) = trang thai nut Auto
EXTERN mb_TypeInfo:QWORD        ; mb.naj (+5Ch) = map hien tai, mb.nal (+60h) = List<le> cong
EXTERN mo_TypeInfo:QWORD        ; mo.nfl (+80h) = List<la> nhiem vu (task order)
EXTERN gb_TypeInfo:QWORD        ; gb.hxf (+18h) = List<ko> thanh vien nhom, [0] = truong nhom

; ---- Diem quay lai ben trong ham game ---------------------------------------
EXTERN dgj_accept:PROC          ; mo.dgj: tiep tuc xet con quai (tinh khoang cach)
EXTERN dgj_skip:PROC            ; mo.dgj: bo qua con quai nay (inc ebx; vong lap)
EXTERN dgj_epilogue_tail:PROC   ; mo.dgj: epilogue, ngay sau "xor eax, eax"
EXTERN clo_store:PROC           ; lm.clo: "mov [rbx+200h], rax" roi return

PUBLIC dgj_ret, dgj_ret_end, dgj_filter, dgj_filter_end, clo_stage, clo_stage_end
PUBLIC quest_tick, party_leader, party_tick
PUBLIC cfg_block, cfg_mob, cfg_stage, cfg_quest, cfg_accept, cfg_party

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
LA_MAP          EQU 3Ch         ; la.mak

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
P_TICK_MS       EQU 100         ; nhip xu ly danh theo nhom
P_MOVE_MS       EQU 500         ; lap lai lenh chay theo truong nhom toi da moi 0.5s

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
                DB 6 DUP (0)
ALIGN 8
st_map          DD 0
                DD 0
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
                DB 6 DUP (0)
p_last_tick     DQ 0
p_last_move     DQ 0
_DATA ENDS

_TEXT SEGMENT ALIGN(16)

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
    jne     dgj_skip
    cmp     byte ptr [rax+MT_ISBOSS], 0
    jne     dgj_skip
    jmp     dgj_accept
dgj_filter ENDP
dgj_filter_end LABEL NEAR

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
    mov     edx, dword ptr [st_map]
    inc     edx                         ; map dich = map hien tai + 1
    xor     ecx, ecx
wp_loop:
    cmp     ecx, r10d
    jge     store_null
    cmp     ecx, dword ptr [r8+18h]     ; max_length cua mang
    jae     store_null
    mov     r9, qword ptr [r8+rcx*8+20h]
    test    r9, r9
    jz      wp_next
    movsx   r11d, word ptr [r9+1Ah]     ; le.mcp = map dich
    cmp     r11d, edx
    je      wp_found
wp_next:
    inc     ecx
    jmp     wp_loop
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
; Danh theo nhom (party_tick) chay truoc; khi dang di theo truong nhom thi
; auto nhiem vu tam dung.
; Auto nhiem vu hang ngay dua tren pipeline "tu dong lam nhiem vu" cua game:
;   - Nguoi choi bat Auto (canh len cua ca.fxf) ngoai Thi Luyen -> kich hoat.
;   - Chua co nhiem vu ngay: ve truong theo he phai, toi NPC 25, gui
;     menu(25, 0, cfg_accept) de nhan.
;   - Co nhiem vu: goi mo.dga(index+2, task) (giong bam vao nhiem vu tren UI).
;     Game tu dich chuyen bang NPC (option 3), tu danh, tu ve tra (option 2).
;   - Dung khi: tat Auto luc dang danh trong map nhiem vu, het luot nhan,
;     pipeline ket nhieu lan, nhan vat chua vao lop.
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
    ; [rsp+30h] FILETIME      | [rsp+38h] trang thai Auto lan truoc
    mov     rbx, rcx
    xor     edx, edx
    call    mo_dgd                      ; giu nguyen hanh vi goc
    cmp     byte ptr [cfg_party], 0
    je      q_no_party
    call    party_tick
    test    eax, eax
    jnz     q_resync_auto               ; dang di theo truong nhom -> tam dung auto nhiem vu
q_no_party:
    cmp     byte ptr [cfg_quest], 0
    je      q_exit

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

    ; ---- tim nhiem vu hang ngay (la.mad == 0) trong mo.nfl ----
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
    jge     q_no_task
    cmp     edi, dword ptr [rdx+18h]
    jae     q_no_task
    mov     rax, qword ptr [rdx+rdi*8+20h]
    test    rax, rax
    jz      q_find_next
    cmp     dword ptr [rax+LA_TASKID], 0
    je      q_have_task
q_find_next:
    inc     edi
    jmp     q_find

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
    jae     q_disengage                 ; het luot nhiem vu trong ngay
    inc     byte ptr [q_accept_tries]
    mov     qword ptr [q_last_accept], r15
    xor     ecx, ecx
    call    lj_cmy
    test    rax, rax
    jz      q_exit
    mov     rcx, rax
    mov     edx, NPC_TEACHER
    xor     r8d, r8d
    movzx   r9d, byte ptr [cfg_accept]
    mov     qword ptr [rsp+20h], 0
    call    lj_menu
    nop
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

; ---- hang so chi doc --------------------------------------------------------
ALIGN 16
abs_mask        DD 7FFFFFFFh, 7FFFFFFFh, 7FFFFFFFh, 7FFFFFFFh
near_dist       REAL4 24.0                          ; nguong "dung canh NPC" cua game
follow_dist     REAL4 40.0                          ; cach truong nhom hon 40 thi chay theo
school_map      DB 1, 1, 72, 72, 27, 27, 160, 160   ; he phai 1..8 -> map truong

_TEXT ENDS
END
