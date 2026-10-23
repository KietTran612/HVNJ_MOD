import capstone

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)

# We want to create the AutoDailyQuest routine:
# Base VA: 0x18018eb74 (File offset: 0x18DF74)
# Cave start: 0x18018eb74
# Let's write the assembly bytes and test length

# Functions to call:
# mo::dgd: 0x1801B56B0
# lm::cua: 0x18024E520
# mo::dga: 0x1801B3DD0
# mo::dgf: 0x1801B5A10
# Service::cmy: 0x180237B00
# Service::menu: 0x1802436E0

# Static pointers:
# mo_class: 0x180E5C158
# eq_class: 0x180E5BFD8 (let's verify eq_class pointer)

print("Writing assembly generator...")
