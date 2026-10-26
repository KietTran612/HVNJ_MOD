import sys,re,json
from pathlib import Path
import capstone
sys.path.insert(0,str(Path.cwd()))
import patch_skill_delay as P
sys.stdout.reconfigure(encoding='utf-8')
data=Path('GameAssembly.dll.bak').read_bytes()
md=capstone.Cs(capstone.CS_ARCH_X86,capstone.CS_MODE_64)
symbols={}
for f in Path('decompiled_output/CSharp_Source').glob('*.cs'):
 s=f.read_text(encoding='utf-8-sig')
 for m in re.finditer(r'\[Address\(RVA = "0x([0-9A-F]+)"[^\n]*\)\]\s*([^\n]+)',s): symbols[int(m[1],16)]=f.stem+'.'+m[2].strip()
def dump(a,b):
 print('\n###',hex(a),symbols.get(a,''))
 off=P.rva_to_off(data,a)
 for i in md.disasm(data[off:off+b-a],a):
  note=''
  if i.mnemonic in ('call','jmp'):
   try: note=symbols.get(int(i.op_str,16),'')
   except ValueError: pass
  print(f'{i.address:x}: {i.mnemonic:8} {i.op_str:35} {note}')
if len(sys.argv)>1:
 for pair in sys.argv[1:]:
  a,b=pair.split(':');dump(int(a,16),int(b,16))
if len(sys.argv)==1:
 targets={0x23aa80,0x2436e0,0x23b660,0x243350,0x2434b0,0x23b110,0x1e0730}
 import struct,bisect
 starts=sorted(symbols)
 for name,va,vs,raw,rs in P.section_table(data)[:2]:
  sec=data[raw:raw+min(vs,rs)]
  for o in range(len(sec)-5):
   if sec[o]!=0xe8:continue
   a=va+o;t=a+5+struct.unpack_from('<i',sec,o+1)[0]
   if t in targets:
    begin=starts[bisect.bisect_right(starts,a)-1]
    print(f'{a:x} -> {t:x} in {begin:x} {symbols[begin]}')
