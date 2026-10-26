#include "../src/hv_startup_gate.h"
#include <cassert>
#include <cstdio>
int main(){
    HvStartupGate gate;int init=0,install=0;
    auto initialize=[&](void* lib){assert(lib==(void*)0x1000);++init;return true;};
    auto patch=[&](uintptr_t base){assert(base==0x2000);++install;};
    assert(!gate.on_managed(initialize,patch));assert(init==0&&install==0);
    gate.discover((void*)0x1000,0x2000);
    assert(init==0&&install==0); // discovering a mapped ELF must not touch VM APIs
    assert(gate.on_managed(initialize,patch));assert(init==1&&install==1);
    assert(gate.on_managed(initialize,patch));assert(init==1&&install==1);
    HvStartupGate failed;failed.discover((void*)0x1000,0x2000);
    auto unavailable=[&](void*){++init;return false;};
    assert(!failed.on_managed(unavailable,patch));assert(init==2&&install==1);
    assert(!failed.on_managed(unavailable,patch));assert(init==2&&install==1);
    puts("startup gate tests passed");
}
