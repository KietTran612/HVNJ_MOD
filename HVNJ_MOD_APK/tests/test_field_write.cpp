#include "../src/hv_field_write.h"
#include "../src/hv_runtime.h"
#include <type_traits>
#include <cstdint>
#include <cstdio>
#include <cstdlib>
#include <cstring>

#define CHECK(x) do { if(!(x)){std::fprintf(stderr,"FAIL line %d: %s\n",__LINE__,#x);return 1;} } while(0)
struct ManagedString { uintptr_t klass=0x1234, monitor=0; int32_t length=3; char16_t text[4]=u"NPC"; };
// Unity6 APK185 GC handles encode native addresses, not 32-bit table indices.
static_assert(std::is_same<decltype(&hv_hold),uintptr_t(*)(void*)>::value,"GC handle must preserve pointer width");
static_assert(std::is_same<decltype(&hv_held),void*(*)(uintptr_t)>::value,"GC lookup must preserve pointer width");
static_assert(std::is_same<decltype(&hv_release),void(*)(uintptr_t)>::value,"GC release must preserve pointer width");
struct ManagedCommand { void* caption=nullptr; int32_t id=0; float scale=0; };
static void* static_reference=nullptr;

// Emulate the exported APK185 setter boundary, not the adapter implementation:
// reference branch ends in str x1,[x0], whereas scalar branches load from x2.
static void reference_setter(void** destination, void* api_argument) { *destination=api_argument; }
template<class T> static void primitive_setter(T* destination, void* api_argument) {
    std::memcpy(destination,api_argument,sizeof(T));
}
int main() {
    ManagedString caption; ManagedCommand command;
    reference_setter(&command.caption,HvFieldWrite::reference(&caption).argument);
    CHECK(command.caption==&caption); // Rejects &localPointer before dereferencing corrupt memory.
    CHECK(static_cast<ManagedString*>(command.caption)->length==3);
    CHECK(static_cast<ManagedString*>(command.caption)->text[2]==u'C');
    reference_setter(&static_reference,HvFieldWrite::reference(&command).argument);
    CHECK(static_reference==&command);
    reference_setter(&command.caption,HvFieldWrite::reference(nullptr).argument);
    CHECK(command.caption==nullptr);
    int64_t id=0x48560009; float scale=1.25f;
    primitive_setter(&command.id,HvFieldWrite::primitive(id).argument);
    primitive_setter(&command.scale,HvFieldWrite::primitive(scale).argument);
    CHECK(command.id==0x48560009 && command.scale==1.25f);
    CHECK(HvFieldWrite::primitive(id).argument==&id);
    std::puts("field setter ABI tests passed");
}
