import struct
import capstone

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

# Let's write an exact byte compiler for this routine
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

    def jmp_label(self, name, opcode=b'\xeb'): # short jump
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

# Let's test assembling Cave_AutoDailyQuest at 0x18018eb74
VA_START = 0x18018eb74
a = AsmBuilder(VA_START)

# call mo::dgd (0x1801b56b0)
a.emit(b'\xe8')
a.rel32(0x1801b56b0)

# push rbx, rsi, rdi, r12, r14, r15, sub rsp, 0x28
a.emit(b'\x53\x56\x57\x41\x54\x41\x56\x41\x57\x48\x83\xec\x28')

# cmp byte ptr [rbx + 0x488], 0
a.emit(b'\x80\xbb\x88\x04\x00\x00\x00')
a.jmp_label('exit', b'\x0f\x84')

# tick counter: inc byte ptr [rip + timer]
# cmp byte ptr [rip + timer], 45
# jb exit
# mov byte ptr [rip + timer], 0
# Let's put timer at the very end of cave
a.emit(b'\xfe\x05') # inc byte ptr [rip + disp]
a.rip_disp32(VA_START + 300) # timer placeholder
a.emit(b'\x80\x3d') # cmp byte ptr [rip + disp], 45
a.rip_disp32(VA_START + 300)
a.emit(b'\x2d') # 45
a.jmp_label('exit', b'\x72') # jb short exit
a.emit(b'\xc6\x05') # mov byte ptr [rip + disp], 0
a.rip_disp32(VA_START + 300)
a.emit(b'\x00')

# xor ecx, ecx; call lm::cua (0x18024e520)
a.emit(b'\x31\xc9\xe8')
a.rel32(0x18024e520)
a.emit(b'\x48\x85\xc0') # test rax, rax
a.jmp_label('exit', b'\x74')
# cmp byte ptr [rax + 0x68d], 0 (isDie)
a.emit(b'\x80\xb8\x8d\x06\x00\x00\x00')
a.jmp_label('exit', b'\x75')
a.emit(b'\x49\x89\xc6') # mov r14, rax

# mov rax, [rip + mo_class (0x180E5C158)]
a.emit(b'\x48\x8b\x05')
a.rip_disp32(0x180E5C158)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x74')
a.emit(b'\x48\x8b\x80\xb8\x00\x00\x00') # mov rax, [rax + 0xb8]
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x74')
a.emit(b'\x48\x8b\xb0\x80\x00\x00\x00') # mov rsi, [rax + 0x80] (mo.nfl)
a.emit(b'\x48\x85\xf6')
a.jmp_label('exit', b'\x74')

# mov edx, [rsi + 0x18] (nfl.Count)
a.emit(b'\x8b\x56\x18\x85\xd2') # test edx, edx
a.jmp_label('has_quest', b'\x7f')

# === NO QUEST ===
a.emit(b'\x80\xbb\xe9\x01\x00\x00\x00') # cmp [rbx + 0x1e9], 0 (nkl)
a.jmp_label('exit', b'\x75')
a.emit(b'\x80\xbb\xea\x01\x00\x00\x00') # cmp [rbx + 0x1ea], 0 (nkm)
a.jmp_label('exit', b'\x75')

# movzx ecx, byte ptr [r14 + 0x170] (player.classId)
a.emit(b'\x41\x0f\xb6\x8e\x70\x01\x00\x00')
a.emit(b'\xba\x01\x00\x00\x00') # mov edx, 1 (Hirosaki)
a.emit(b'\x83\xf9\x03') # cmp ecx, 3
a.jmp_label('kojin', b'\x74')
a.emit(b'\x83\xf9\x04') # cmp ecx, 4
a.jmp_label('kojin', b'\x74')
a.emit(b'\x83\xf9\x05') # cmp ecx, 5
a.jmp_label('haruna', b'\x74')
a.emit(b'\x83\xf9\x06') # cmp ecx, 6
a.jmp_label('haruna', b'\x74')
a.jmp_label('cmp_map', b'\xeb')

a.label('kojin')
a.emit(b'\xba\x48\x00\x00\x00') # mov edx, 72
a.jmp_label('cmp_map', b'\xeb')

a.label('haruna')
a.emit(b'\xba\x1b\x00\x00\x00') # mov edx, 27

a.label('cmp_map')
# mov rax, [rip + eq_class (0x180E5C0E8)]
a.emit(b'\x48\x8b\x05')
a.rip_disp32(0x180E5C0E8)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x74')
a.emit(b'\x48\x8b\x80\xb8\x00\x00\x00')
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x74')
a.emit(b'\x0f\xb7\x48\x5c') # movzx ecx, word ptr [rax + 0x5c] (currentMap)
a.emit(b'\x39\xd1') # cmp ecx, edx
a.jmp_label('in_school', b'\x74')

# Travel to school: mo::dgf(schoolMap: edx, 25, 0)
a.emit(b'\x48\x89\xd9') # mov rcx, rbx
a.emit(b'\x41\xb8\x19\x00\x00\x00') # mov r8d, 25
a.emit(b'\x45\x31\xc9') # xor r9d, r9d
a.emit(b'\xe8')
a.rel32(0x1801b5a10) # call mo::dgf
a.jmp_label('exit', b'\xeb')

a.label('in_school')
# Find NPC 25:
a.emit(b'\xb9\x19\x00\x00\x00\x31\xd2\xe8') # mov ecx, 25; xor edx, edx; call 0x1801e98e0
a.rel32(0x1801e98e0)
a.emit(b'\x48\x85\xc0')
a.jmp_label('walk_npc', b'\x74')

# Close enough, send menu: Service.cmy().menu(25, 0, 2)
a.emit(b'\x31\xc9\xe8') # xor ecx, ecx; call Service::cmy (0x180237b00)
a.rel32(0x180237b00)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x74')
a.emit(b'\x48\x89\xc1') # mov rcx, rax
a.emit(b'\xba\x19\x00\x00\x00') # mov edx, 25
a.emit(b'\x45\x31\xc0') # xor r8d, r8d (menuId = 0)
a.emit(b'\x41\xb9\x02\x00\x00\x00') # mov r9d, 2 (optionId = 2)
a.emit(b'\xe8')
a.rel32(0x1802436e0) # call Service::menu
a.jmp_label('exit', b'\xeb')

a.label('walk_npc')
a.emit(b'\x48\x89\xd9') # mov rcx, rbx
a.emit(b'\x41\xb8\x19\x00\x00\x00') # mov r8d, 25
a.emit(b'\x45\x31\xc9') # xor r9d, r9d
a.emit(b'\xe8')
a.rel32(0x1801b5a10) # call mo::dgf
a.jmp_label('exit', b'\xeb')

# === HAS QUEST ===
a.label('has_quest')
a.emit(b'\x48\x8b\x46\x10') # mov rax, [rsi + 0x10] (items)
a.emit(b'\x48\x85\xc0')
a.jmp_label('exit', b'\x74')
a.emit(b'\x4c\x8b\x78\x20') # mov r15, [rax + 0x20] (taskOrder la)
a.emit(b'\x4d\x85\xff')
a.jmp_label('exit', b'\x74')

# Check count vs maxCount:
a.emit(b'\x41\x8b\x47\x10') # mov eax, [r15 + 0x10]
a.emit(b'\x41\x3b\x47\x14') # cmp eax, [r15 + 0x14]
a.jmp_label('quest_done', b'\x7d') # jge quest_done

# In progress: check if [rbx + 0x1f8] == r15
a.emit(b'\x49\x3b\xbb\xf8\x01\x00\x00')
a.jmp_label('exit', b'\x74')
# call mo::dga(0, taskOrder):
a.emit(b'\x48\x89\xd9\x31\xd2\x4d\x89\xf8\xe8')
a.rel32(0x1801b3dd0)
a.jmp_label('exit', b'\xeb')

a.label('quest_done')
# Check if nkm == 1:
a.emit(b'\x80\xbb\xea\x01\x00\x00\x00')
a.jmp_label('exit', b'\x75')
# call mo::dga(0, taskOrder) to return to school:
a.emit(b'\x48\x89\xd9\x31\xd2\x4d\x89\xf8\xe8')
a.rel32(0x1801b3dd0)

a.label('exit')
a.emit(b'\x48\x83\xc4\x28\x41\x5f\x41\x5e\x41\x5c\x5f\x5e\x5b\xc3')

# Resolve labels
a.resolve()

print(f"Generated {len(a.bytes)} bytes of machine code!")
for ins in md.disasm(bytes(a.bytes), VA_START):
    print(f"{hex(ins.address)}: {ins.mnemonic} {ins.op_str}")
