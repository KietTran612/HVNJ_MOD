import struct
import capstone

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

class AsmBuilder:
    def __init__(self, base_va):
        self.base_va = base_va
        self.bytes = bytearray()
        self.labels = {}
        self.relocs = []

    def label(self, name):
        self.labels[name] = len(self.bytes)

    def emit(self, b):
        self.bytes.extend(b)

    def rel32(self, target_va):
        curr_va = self.base_va + len(self.bytes) + 4
        disp = target_va - curr_va
        self.bytes.extend(struct.pack('<i', disp))

    def jmp_label(self, name, opcode=b'\xeb'):
        self.relocs.append((len(self.bytes), name, opcode))
        if opcode == b'\xeb' or (len(opcode) == 1 and opcode[0] in range(0x70, 0x80)):
            self.bytes.extend(opcode + b'\x00')
        elif opcode.startswith(b'\x0f') or opcode == b'\xe9':
            self.bytes.extend(opcode + b'\x00\x00\x00\x00')

    def rip_disp32(self, target_va):
        curr_va = self.base_va + len(self.bytes) + 4
        disp = target_va - curr_va
        self.bytes.extend(struct.pack('<i', disp))

    def resolve(self):
        for pos, name, opcode in self.relocs:
            target_pos = self.labels[name]
            if opcode == b'\xeb' or (len(opcode) == 1 and opcode[0] in range(0x70, 0x80)):
                disp = target_pos - (pos + len(opcode) + 1)
                assert -128 <= disp <= 127, f"Short jump out of range for {name}: {disp}"
                self.bytes[pos + len(opcode)] = disp & 0xFF
            elif opcode.startswith(b'\x0f') or opcode == b'\xe9':
                disp = target_pos - (pos + len(opcode) + 4)
                self.bytes[pos+len(opcode):pos+len(opcode)+4] = struct.pack('<i', disp)

CAVE_VA = 0x18060DA90
a = AsmBuilder(CAVE_VA)

# 1. Call original mo::dgd(rcx) (0x1801b56b0)
a.emit(b'\xe8')
a.rel32(0x1801b56b0)

# 2. Save registers (8 registers * 8 = 64 bytes + 8 return addr = 72; 72 + 40 (0x28) = 112 bytes -> 16-byte aligned!)
# rbp, rbx, rsi, rdi, r12 (schoolMap), r13 (currentMap), r14 (player), r15 (taskOrder)
a.emit(b'\x55\x53\x56\x57\x41\x54\x41\x55\x41\x56\x41\x57\x48\x83\xec\x28')

# 3. Check if Auto is ON (mo.noz at [rbx + 0x488])
a.emit(b'\x80\xbb\x88\x04\x00\x00\x00')
a.jmp_label('exit', b'\x0f\x84')

# 4. Check if map is in Thí Luyện (161 to 167) -> if so, skip daily quest!
a.emit(b'\x48\x8b\x05')
a.rip_disp32(0x180E5C0E8) # eq_class
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x8b\x80\xb8\x00\x00\x00')
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x0f\xb7\x48\x5c') # movzx ecx, word ptr [rax + 0x5c]
a.emit(b'\x81\xf9\xa1\x00\x00\x00') # cmp ecx, 161
a.jmp_label('not_trial', b'\x7c')
a.emit(b'\x81\xf9\xa7\x00\x00\x00') # cmp ecx, 167
a.jmp_label('exit', b'\x0f\x8e') # jle exit

a.label('not_trial')
# 5. Cooldown timer (~1.2s = 36 ticks)
TIMER_VA = CAVE_VA + 740
a.emit(b'\xfe\x05') # inc byte ptr [rip + TIMER]
a.rip_disp32(TIMER_VA)
a.emit(b'\x80\x3d') # cmp byte ptr [rip + TIMER], 36
a.rip_disp32(TIMER_VA)
a.emit(b'\x24') # 36
a.jmp_label('exit', b'\x0f\x82') # jb exit
a.emit(b'\xc6\x05') # mov byte ptr [rip + TIMER], 0
a.rip_disp32(TIMER_VA)
a.emit(b'\x00')

# 6. Check if player alive: lm::cua (0x18024e520)
a.emit(b'\x31\xc9\xe8')
a.rel32(0x18024e520)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x80\xb8\x8d\x06\x00\x00\x00') # isDie
a.jmp_label('exit', b'\x0f\x85')
a.emit(b'\x49\x89\xc6') # mov r14, rax (player)

# 7. Determine player's School Map:
# classId at [r14 + 0x170]
# 1,2: Hirosaki (1) | 3,4: Kojin (72) | 5,6: Haruna (27)
a.emit(b'\x41\x0f\xb6\x8e\x70\x01\x00\x00') # movzx ecx, byte ptr [r14 + 0x170]
a.emit(b'\x41\xbc\x01\x00\x00\x00') # mov r12d, 1 (Hirosaki)
a.emit(b'\x83\xf9\x03')
a.jmp_label('kojin', b'\x74')
a.emit(b'\x83\xf9\x04')
a.jmp_label('kojin', b'\x74')
a.emit(b'\x83\xf9\x05')
a.jmp_label('haruna', b'\x74')
a.emit(b'\x83\xf9\x06')
a.jmp_label('haruna', b'\x74')
a.jmp_label('got_school', b'\xeb')

a.label('kojin')
a.emit(b'\x41\xbc\x48\x00\x00\x00') # mov r12d, 72 (Kojin)
a.jmp_label('got_school', b'\xeb')

a.label('haruna')
a.emit(b'\x41\xbc\x1b\x00\x00\x00') # mov r12d, 27 (Haruna)

a.label('got_school')
# 8. Check if player has Thông Thành Phù (item 35 or 37) in bag (miv at [r14 + 0x1B8])
# edi = has_ttp (0 or 1)
a.emit(b'\x31\xff') # xor edi, edi
a.emit(b'\x49\x8b\x86\xb8\x01\x00\x00') # mov rax, [r14 + 0x1B8] (miv)
a.emit(b'\x48\x85\xc0')
a.jmp_label('bag_checked', b'\x74')
a.emit(b'\x8b\x48\x18') # mov ecx, [rax + 0x18] (array length)
a.emit(b'\x85\xc9')
a.jmp_label('bag_checked', b'\x7e')
a.emit(b'\x31\xd2') # xor edx, edx (index)

a.label('bag_loop')
a.emit(b'\x48\x8b\x74\xd0\x20') # mov rsi, [rax + rdx*8 + 0x20] (Item)
a.emit(b'\x48\x85\xf6')
a.jmp_label('next_item', b'\x74')
a.emit(b'\x48\x8b\x76\x10') # mov rsi, [rsi + 0x10] (ItemTemplate js)
a.emit(b'\x48\x85\xf6')
a.jmp_label('next_item', b'\x74')
a.emit(b'\x0f\xb7\x76\x10') # movzx esi, word ptr [rsi + 0x10] (templateId)
a.emit(b'\x83\xfe\x23') # cmp esi, 35 (Thông Thành Phù)
a.jmp_label('found_ttp', b'\x74')
a.emit(b'\x83\xfe\x25') # cmp esi, 37 (Vô Hạn Thông Thành Phù)
a.jmp_label('found_ttp', b'\x74')

a.label('next_item')
a.emit(b'\xff\xc2') # inc edx
a.emit(b'\x39\xca') # cmp edx, ecx
a.jmp_label('bag_loop', b'\x7c')
a.jmp_label('bag_checked', b'\xeb')

a.label('found_ttp')
a.emit(b'\xff\xc7') # inc edi (has_ttp = 1)

a.label('bag_checked')
# 9. Get currentMap from eq_class -> r13d
a.emit(b'\x48\x8b\x05')
a.rip_disp32(0x180E5C0E8) # eq_class
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x8b\x80\xb8\x00\x00\x00')
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x44\x0f\xb7\x68\x5c') # movzx r13d, word ptr [rax + 0x5c] (currentMap)

# 10. If player has NO TTP (edi == 0) and is in School (r13d == r12d):
# Buy 10 Thông Thành Phù with Yên: Service.cmy().coj(16, 0, 10)
a.emit(b'\x85\xff')
a.jmp_label('check_quest_state', b'\x75') # if has_ttp != 0, skip buy
a.emit(b'\x45\x39\xe5') # cmp r13d, r12d
a.jmp_label('check_quest_state', b'\x75') # if currentMap != schoolMap, skip buy
# Call Service.cmy().coj(16, 0, 10):
a.emit(b'\x31\xc9\xe8')
a.rel32(0x180237b00) # Service.cmy()
a.emit(b'\x48\x85\xc0')
a.jmp_label('check_quest_state', b'\x74')
a.emit(b'\x48\x89\xc1') # rcx = Service
a.emit(b'\xba\x10\x00\x00\x00') # edx = typeUI = 16 (Tạp Hóa)
a.emit(b'\x45\x31\xc0') # r8d = indexUI = 0
a.emit(b'\x41\xb9\x0a\x00\x00\x00') # r9d = quantity = 10
a.emit(b'\x48\xc7\x44\x24\x20\x00\x00\x00\x00') # [rsp + 0x20] = 0 (MethodInfo)
a.emit(b'\xe8')
a.rel32(0x18023a220) # Service.coj

a.label('check_quest_state')
# 11. Check mo.nfl (Task Order Container): mo_class (0x180E5C158)
a.emit(b'\x48\x8b\x05')
a.rip_disp32(0x180E5C158)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x8b\x80\xb8\x00\x00\x00')
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x8b\xb0\x80\x00\x00\x00') # rsi = mo.nfl
a.emit(b'\x48\x85\xf6')
a.jmp_label('exit', b'\x0f\x84')

# mov edx, [rsi + 0x18] (Count)
a.emit(b'\x8b\x56\x18\x85\xd2')
a.jmp_label('has_quest', b'\x0f\x8f')

# ==============================================================================
# === NO QUEST (count == 0): Go to School -> NPC 25 -> Nhận NV ===
# ==============================================================================
a.label('no_quest')
# Check if already travelling/interacting
a.emit(b'\x80\xbb\xe9\x01\x00\x00\x00') # nkl
a.jmp_label('exit', b'\x0f\x85')
a.emit(b'\x80\xbb\xea\x01\x00\x00\x00') # nkm
a.jmp_label('exit', b'\x0f\x85')

# Compare currentMap (r13d) vs schoolMap (r12d):
a.emit(b'\x45\x39\xe5')
a.jmp_label('in_school_no_quest', b'\x74')

# Not in school:
# If has_ttp != 0: use Thông Thành Phù (Service.cmy().cqj(schoolMap))!
a.emit(b'\x85\xff')
a.jmp_label('walk_to_school_no_quest', b'\x74')
a.emit(b'\x31\xc9\xe8')
a.rel32(0x180237b00) # Service.cmy()
a.emit(b'\x48\x85\xc0')
a.jmp_label('walk_to_school_no_quest', b'\x74')
a.emit(b'\x48\x89\xc1') # rcx = Service
a.emit(b'\x44\x89\xe2') # edx = schoolMap (r12d)
a.emit(b'\xe8')
a.rel32(0x18023d7d0) # Service.cqj(schoolMap)

a.label('walk_to_school_no_quest')
# Pathfinding fallback: mo::dgf(schoolMap, 25, 0)
a.emit(b'\x48\x89\xd9\x44\x89\xe2\x41\xb8\x19\x00\x00\x00\x45\x31\xc9\xe8')
a.rel32(0x1801b5a10) # mo::dgf
a.jmp_label('exit', b'\xe9')

a.label('in_school_no_quest')
# Find NPC 25 in school:
a.emit(b'\xb9\x19\x00\x00\x00\x31\xd2\xe8')
a.rel32(0x1801e98e0)
a.emit(b'\x48\x85\xc0')
a.jmp_label('walk_npc_no_quest', b'\x74')

# Near NPC 25: send accept menu: Service.cmy().menu(25, 0, 2)
a.emit(b'\x31\xc9\xe8')
a.rel32(0x180237b00)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x89\xc1\xba\x19\x00\x00\x00\x45\x31\xc0\x41\xb9\x02\x00\x00\x00')
a.emit(b'\x48\xc7\x44\x24\x20\x00\x00\x00\x00\xe8')
a.rel32(0x1802436e0) # Service.menu(25, 0, 2)
a.jmp_label('exit', b'\xe9')

a.label('walk_npc_no_quest')
a.emit(b'\x48\x89\xd9\x44\x89\xe2\x41\xb8\x19\x00\x00\x00\x45\x31\xc9\xe8')
a.rel32(0x1801b5a10) # mo::dgf
a.jmp_label('exit', b'\xe9')

# ==============================================================================
# === HAS QUEST: Check progress ===
# ==============================================================================
a.label('has_quest')
a.emit(b'\x48\x8b\x46\x10') # mov rax, [rsi + 0x10] (items)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x4c\x8b\x78\x20') # mov r15, [rax + 0x20] (taskOrder)
a.emit(b'\x4d\x85\xff')
a.jmp_label('exit', b'\x0f\x84')

# Check count vs maxCount:
a.emit(b'\x41\x8b\x47\x10') # count
a.emit(b'\x41\x3b\x47\x14') # maxCount
a.jmp_label('quest_done', b'\x0f\x8d') # jge quest_done

# --- QUEST IN PROGRESS (count < maxCount) ---
# If currently in School (r13d == r12d):
# USE NPC 25 "Đi làm nhiệm vụ" (menu(25, 0, 1)) TO FAST TELEPORT TO QUEST MAP!
a.emit(b'\x45\x39\xe5')
a.jmp_label('combat_targeting', b'\x75') # if not in school, go to combat!

# In school: check if near NPC 25:
a.emit(b'\xb9\x19\x00\x00\x00\x31\xd2\xe8')
a.rel32(0x1801e98e0)
a.emit(b'\x48\x85\xc0')
a.jmp_label('walk_npc_fast_travel', b'\x74')

# At NPC 25 in School -> Send "Đi làm nhiệm vụ": Service.cmy().menu(25, 0, 1)!
a.emit(b'\x31\xc9\xe8')
a.rel32(0x180237b00) # Service.cmy()
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x89\xc1\xba\x19\x00\x00\x00\x45\x31\xc0\x41\xb9\x01\x00\x00\x00') # menu(25, 0, 1)
a.emit(b'\x48\xc7\x44\x24\x20\x00\x00\x00\x00\xe8')
a.rel32(0x1802436e0)
a.jmp_label('exit', b'\xe9')

a.label('walk_npc_fast_travel')
# Walk to NPC 25 to click "Đi làm nhiệm vụ":
a.emit(b'\x48\x89\xd9\x44\x89\xe2\x41\xb8\x19\x00\x00\x00\x45\x31\xc9\xe8')
a.rel32(0x1801b5a10) # mo::dgf(schoolMap, 25, 0)
a.jmp_label('exit', b'\xe9')

a.label('combat_targeting')
# In quest map: normal auto combat targeting
a.emit(b'\x4c\x39\xbb\xf8\x01\x00\x00') # cmp [rbx + 0x1f8], r15
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x89\xd9\x31\xd2\x4d\x89\xf8\xe8')
a.rel32(0x1801b3dd0) # mo::dga(0, taskOrder)
a.jmp_label('exit', b'\xe9')

# ==============================================================================
# === QUEST DONE (count >= maxCount): Return to School & Turn In ===
# ==============================================================================
a.label('quest_done')
# If not in school:
# 1) Use Thông Thành Phù (Service.cmy().cqj(schoolMap))!
# 2) Call mo::dga(0, taskOrder) to walk/arrive at NPC 25!
a.emit(b'\x45\x39\xe5')
a.jmp_label('in_school_quest_done', b'\x74')

# Away from school:
# Send cqj(schoolMap) if has_ttp != 0:
a.emit(b'\x85\xff')
a.jmp_label('walk_return_school', b'\x74')
a.emit(b'\x31\xc9\xe8')
a.rel32(0x180237b00) # Service.cmy()
a.emit(b'\x48\x85\xc0')
a.jmp_label('walk_return_school', b'\x74')
a.emit(b'\x48\x89\xc1') # rcx = Service
a.emit(b'\x44\x89\xe2') # edx = schoolMap (r12d)
a.emit(b'\xe8')
a.rel32(0x18023d7d0) # Service.cqj(schoolMap)

a.label('walk_return_school')
a.emit(b'\x48\x89\xd9\x31\xd2\x4d\x89\xf8\xe8')
a.rel32(0x1801b3dd0) # mo::dga(0, taskOrder)
a.jmp_label('exit', b'\xe9')

a.label('in_school_quest_done')
# In School: check if near NPC 25
a.emit(b'\xb9\x19\x00\x00\x00\x31\xd2\xe8')
a.rel32(0x1801e98e0)
a.emit(b'\x48\x85\xc0')
a.jmp_label('walk_npc_quest_done', b'\x74')

# Near NPC 25: Submit quest: Service.cmy().menu(25, 0, 2)
a.emit(b'\x31\xc9\xe8')
a.rel32(0x180237b00)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x89\xc1\xba\x19\x00\x00\x00\x45\x31\xc0\x41\xb9\x02\x00\x00\x00') # menu(25, 0, 2)
a.emit(b'\x48\xc7\x44\x24\x20\x00\x00\x00\x00\xe8')
a.rel32(0x1802436e0)
a.jmp_label('exit', b'\xe9')

a.label('walk_npc_quest_done')
a.emit(b'\x48\x89\xd9\x44\x89\xe2\x41\xb8\x19\x00\x00\x00\x45\x31\xc9\xe8')
a.rel32(0x1801b5a10) # mo::dgf(schoolMap, 25, 0)

# ==============================================================================
# === EPILOGUE ===
# ==============================================================================
a.label('exit')
a.emit(b'\x48\x83\xc4\x28\x41\x5f\x41\x5e\x41\x5d\x41\x5c\x5f\x5e\x5b\x5d\xc3')

current_len = len(a.bytes)
a.emit(b'\x00' * 32)

a.resolve()

print(f"SUCCESS! Total machine code size: {current_len} bytes! (Cave capacity: 1328 bytes)")
disasm_lines = []
for ins in md.disasm(bytes(a.bytes[:current_len]), CAVE_VA):
    disasm_lines.append(f"{hex(ins.address)}: {ins.mnemonic} {ins.op_str}")

print(f"Total disassembled instructions: {len(disasm_lines)}")
print("First 10 instructions:")
for l in disasm_lines[:10]:
    print("  ", l)
print("Last 10 instructions:")
for l in disasm_lines[-10:]:
    print("  ", l)

with open('decompiled_output/cave_v2.bin', 'wb') as f:
    f.write(a.bytes[:current_len])
