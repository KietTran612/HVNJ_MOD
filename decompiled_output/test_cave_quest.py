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

# 2. Save registers
a.emit(b'\x53\x56\x57\x41\x54\x41\x56\x41\x57\x48\x83\xec\x28')

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
# 5. Cooldown timer:
TIMER_VA = CAVE_VA + 550
a.emit(b'\xfe\x05') # inc byte ptr [rip + TIMER]
a.rip_disp32(TIMER_VA)
a.emit(b'\x80\x3d') # cmp byte ptr [rip + TIMER], 45 (~1.5s)
a.rip_disp32(TIMER_VA)
a.emit(b'\x2d')
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
a.emit(b'\x49\x89\xc6') # mov r14, rax

# 7. Check mo.nfl: mo_class (0x180E5C158)
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

# === NO QUEST ===
# Check if already travelling/interacting
a.emit(b'\x80\xbb\xe9\x01\x00\x00\x00') # nkl
a.jmp_label('exit', b'\x0f\x85')
a.emit(b'\x80\xbb\xea\x01\x00\x00\x00') # nkm
a.jmp_label('exit', b'\x0f\x85')

# Determine school map:
a.emit(b'\x41\x0f\xb6\x8e\x70\x01\x00\x00') # movzx ecx, byte ptr [r14 + 0x170]
a.emit(b'\xba\x01\x00\x00\x00') # mov edx, 1
a.emit(b'\x83\xf9\x03')
a.jmp_label('kojin', b'\x74')
a.emit(b'\x83\xf9\x04')
a.jmp_label('kojin', b'\x74')
a.emit(b'\x83\xf9\x05')
a.jmp_label('haruna', b'\x74')
a.emit(b'\x83\xf9\x06')
a.jmp_label('haruna', b'\x74')
a.jmp_label('cmp_map', b'\xeb')

a.label('kojin')
a.emit(b'\xba\x48\x00\x00\x00') # 72
a.jmp_label('cmp_map', b'\xeb')

a.label('haruna')
a.emit(b'\xba\x1b\x00\x00\x00') # 27

a.label('cmp_map')
# Compare currentMap: eq_class (0x180E5C0E8)
a.emit(b'\x48\x8b\x05')
a.rip_disp32(0x180E5C0E8)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x8b\x80\xb8\x00\x00\x00')
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x0f\xb7\x48\x5c') # movzx ecx, word ptr [rax + 0x5c]
a.emit(b'\x39\xd1') # cmp ecx, edx
a.jmp_label('in_school', b'\x74')

# Travel to school: mo::dgf(schoolMap: edx, 25, 0)
a.emit(b'\x48\x89\xd9\x41\xb8\x19\x00\x00\x00\x45\x31\xc9\xe8')
a.rel32(0x1801b5a10)
a.jmp_label('exit', b'\xe9')

a.label('in_school')
# Find NPC 25:
a.emit(b'\xb9\x19\x00\x00\x00\x31\xd2\xe8')
a.rel32(0x1801e98e0)
a.emit(b'\x48\x85\xc0')
a.jmp_label('walk_npc', b'\x74')

# Send accept menu: Service.cmy().menu(25, 0, 2)
a.emit(b'\x31\xc9\xe8')
a.rel32(0x180237b00)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x89\xc1\xba\x19\x00\x00\x00\x45\x31\xc0\x41\xb9\x02\x00\x00\x00\xe8')
a.rel32(0x1802436e0)
a.jmp_label('exit', b'\xe9')

a.label('walk_npc')
a.emit(b'\x48\x89\xd9\x41\xb8\x19\x00\x00\x00\x45\x31\xc9\xe8')
a.rel32(0x1801b5a10)
a.jmp_label('exit', b'\xe9')

# === HAS QUEST ===
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
a.jmp_label('quest_done', b'\x7d')

# In progress: check if [rbx + 0x1f8] == r15
a.emit(b'\x4c\x39\xbb\xf8\x01\x00\x00') # cmp [rbx + 0x1f8], r15
a.jmp_label('exit', b'\x0f\x84')
a.emit(b'\x48\x89\xd9\x31\xd2\x4d\x89\xf8\xe8')
a.rel32(0x1801b3dd0) # mo::dga(0, taskOrder)
a.jmp_label('exit', b'\xe9')

a.label('quest_done')
# Check if nkm == 1:
a.emit(b'\x80\xbb\xea\x01\x00\x00\x00')
a.jmp_label('exit', b'\x0f\x85')
# call mo::dga(0, taskOrder) to return to school:
a.emit(b'\x48\x89\xd9\x31\xd2\x4d\x89\xf8\xe8')
a.rel32(0x1801b3dd0) # mo::dga(0, taskOrder)

a.label('exit')
a.emit(b'\x48\x83\xc4\x28\x41\x5f\x41\x5e\x41\x5c\x5f\x5e\x5b\xc3')

current_len = len(a.bytes)
a.emit(b'\x00' * (560 - current_len))

a.resolve()

print(f"SUCCESS! Total machine code size: {current_len} bytes! (Cave capacity: 1328 bytes)")
for ins in md.disasm(bytes(a.bytes[:current_len]), CAVE_VA):
    print(f"{hex(ins.address)}: {ins.mnemonic} {ins.op_str}")
