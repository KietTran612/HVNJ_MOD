import struct
import capstone

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

# Let's write the assembly bytes and test
# We will verify all instructions with Capstone
print("Testing assembler script...")
