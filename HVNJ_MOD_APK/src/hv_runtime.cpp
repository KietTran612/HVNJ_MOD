#include "hv_runtime.h"
#include "hv_field_write.h"
#include "hv_log_file.h"
#include <android/log.h>
#include <dlfcn.h>
#include <cstdarg>
#include <cstdio>
#include <cstring>
#include <ctime>
#include <mutex>
#include <string>
#include <unordered_map>
#include <deque>
#include <unistd.h>

HvConfig hv_cfg;
namespace {
struct Api {
    void* (*domain_get)();
    void** (*domain_get_assemblies)(void*, size_t*);
    void* (*assembly_get_image)(void*);
    void* (*class_from_name)(void*, const char*, const char*);
    void* (*class_from_type)(void*);
    void* (*class_get_parent)(void*);
    void* (*class_get_type)(void*);
    void* (*class_get_field_from_name)(void*, const char*);
    void* (*class_get_method_from_name)(void*, const char*, int);
    void* (*object_get_class)(void*);
    const char* (*class_get_name)(void*);
    void* (*field_get_type)(void*);
    int (*type_get_type)(void*);
    unsigned (*field_get_flags)(void*);
    void (*field_get_value)(void*, void*, void*);
    void (*field_set_value)(void*, void*, void*);
    void (*field_static_get_value)(void*, void*);
    void (*field_static_set_value)(void*, void*);
    void (*runtime_class_init)(void*);
    void* (*runtime_invoke)(void*, void*, void**, void**);
    void* (*object_new)(void*);
    void* (*object_unbox)(void*);
    void* (*string_new)(const char*);
    const char16_t* (*string_chars)(void*);
    int (*string_length)(void*);
    void* (*array_new)(void*, size_t);
    void (*gc_wbarrier_set_field)(void*, void**, void*);
    uintptr_t (*gchandle_new)(void*,bool);
    void* (*gchandle_get_target)(uintptr_t);
    void (*gchandle_free)(uintptr_t);
    void* (*thread_attach)(void*);
    void (*thread_detach)(void*);
} a{};
std::mutex class_lock, field_lock;
std::unordered_map<std::string, void*> classes, fields;
bool ready = false;

void* field(const char* cls, const char* name) {
    if (!ready || !cls || !name) return nullptr;
    std::string key = std::string(cls) + ":" + name;
    std::lock_guard<std::mutex> lock(field_lock);
    auto it = fields.find(key);
    if (it != fields.end()) return it->second;
    void* k = hv_class(cls);
    void* f = nullptr;
    while (k && !f) { f = a.class_get_field_from_name(k, name); k = a.class_get_parent(k); }
    if (!f) hv_log("missing field %s.%s", cls, name);
    fields[key] = f;
    return f;
}
bool read(void* obj, const char* cls, const char* name, void* value) {
    void* f = field(cls, name);
    if (!f) return false;
    if (a.field_get_flags(f) & 0x10) {
        a.runtime_class_init(hv_class(cls)); a.field_static_get_value(f, value);
    } else if (obj) a.field_get_value(obj, f, value);
    else return false;
    return true;
}
bool write(void* obj, const char* cls, const char* name, void* value) {
    void* f = field(cls, name);
    if (!f) return false;
    if (a.field_get_flags(f) & 0x10) {
        a.runtime_class_init(hv_class(cls)); a.field_static_set_value(f, value);
    } else if (obj) a.field_set_value(obj, f, value);
    else return false;
    return true;
}
int kind(const char* cls, const char* name) {
    void* f = field(cls, name);
    return f ? a.type_get_type(a.field_get_type(f)) : 0;
}
}

bool hv_runtime_init(void* lib) {
    // Must run inside an original managed callback after Unity has initialized.
    // il2cpp_domain_get is a lazy allocator, not a safe native-worker readiness test.
#define LOAD(name) a.name = reinterpret_cast<decltype(a.name)>(dlsym(lib, "il2cpp_" #name)); if (!a.name) { hv_log("missing export il2cpp_%s", #name); return false; }
    LOAD(domain_get); LOAD(domain_get_assemblies); LOAD(assembly_get_image); LOAD(class_from_name); LOAD(class_from_type);
    LOAD(gchandle_new); LOAD(gchandle_get_target); LOAD(gchandle_free);
    LOAD(class_get_parent); LOAD(class_get_type); LOAD(class_get_field_from_name); LOAD(class_get_method_from_name);
    LOAD(object_get_class); LOAD(class_get_name); LOAD(field_get_type); LOAD(type_get_type); LOAD(field_get_flags);
    LOAD(field_get_value); LOAD(field_set_value); LOAD(field_static_get_value); LOAD(field_static_set_value);
    LOAD(runtime_class_init); LOAD(runtime_invoke); LOAD(object_new); LOAD(object_unbox);
    LOAD(string_new); LOAD(string_chars); LOAD(string_length); LOAD(array_new);
    LOAD(gc_wbarrier_set_field); LOAD(thread_attach); LOAD(thread_detach);
#undef LOAD
    if (!a.domain_get()) return false;
    ready = true;
    return true;
}
void* hv_attach() { return ready ? a.thread_attach(a.domain_get()) : nullptr; }
void hv_detach(void* t) { if (ready && t) a.thread_detach(t); }
void* hv_class(const char* full) {
    if (!ready || !full) return nullptr;
    std::lock_guard<std::mutex> lock(class_lock);
    auto it = classes.find(full); if (it != classes.end()) return it->second;
    std::string ns, name(full); size_t dot = name.rfind('.');
    if (dot != std::string::npos) { ns = name.substr(0, dot); name.erase(0, dot + 1); }
    size_t n = 0; void** asmbl = a.domain_get_assemblies(a.domain_get(), &n);
    void* k = nullptr;
    for (size_t i = 0; i < n && !k; ++i) k = a.class_from_name(a.assembly_get_image(asmbl[i]), ns.c_str(), name.c_str());
    if (!k && ns.empty() && (name=="Char" || name=="char")) {
        const char* other=name=="Char"?"char":"Char";
        for(size_t i=0;i<n&&!k;++i)k=a.class_from_name(a.assembly_get_image(asmbl[i]),"",other);
    }
    if (k) classes[full] = k; // a class may appear after initial domain registration
    return k;
}
bool hv_has_field(const char* c, const char* f) { return field(c, f) != nullptr; }
const char* hv_type_name(void* o){return o?a.class_get_name(a.object_get_class(o)):"none";}
void* hv_obj(void* o, const char* c, const char* f) { void* v = nullptr; read(o,c,f,&v); return v; }
int64_t hv_int(void* o, const char* c, const char* f) {
    uint64_t v = 0; if (!read(o,c,f,&v)) return 0;
    switch (kind(c,f)) {
        case 2: case 5: return static_cast<uint8_t>(v);
        case 4: return static_cast<int8_t>(v);
        case 3: case 7: return static_cast<uint16_t>(v);
        case 6: return static_cast<int16_t>(v);
        case 9: return static_cast<uint32_t>(v);
        case 10: case 11: case 0x18: case 0x19: return static_cast<int64_t>(v);
        default: return static_cast<int32_t>(v);
    }
}
float hv_float(void* o,const char* c,const char* f) { float v=0; read(o,c,f,&v); return v; }
bool hv_bool(void* o,const char* c,const char* f) { return hv_int(o,c,f)!=0; }
// IL2CPP SetValueRaw(w3=0) takes reference objects directly; only primitives
// take an address. Passing &v stores a dangling native-stack pointer in the GC heap.
bool hv_set_obj(void* o,const char* c,const char* f,void* v) { return write(o,c,f,HvFieldWrite::reference(v).argument); }
bool hv_set_int(void* o,const char* c,const char* f,int64_t v) { return write(o,c,f,HvFieldWrite::primitive(v).argument); }
bool hv_set_float(void* o,const char* c,const char* f,float v) { return write(o,c,f,HvFieldWrite::primitive(v).argument); }
bool hv_has_method(const char* c,const char* n,int argc) {
    void* k=hv_class(c); return k && a.class_get_method_from_name(k,n,argc);
}
void* hv_call(void* o,const char* c,const char* n,int argc,void** args) {
    void* k = c ? hv_class(c) : (o ? a.object_get_class(o) : nullptr);
    if (!k) return nullptr;
    void* m=a.class_get_method_from_name(k,n,argc);
    if (!m) { hv_log("missing method %s.%s/%d",c?c:"<runtime>",n,argc); return nullptr; }
    void* ex=nullptr; void* result=a.runtime_invoke(m,o,args,&ex);
    if (ex) { hv_log("managed exception %s.%s",c?c:"<runtime>",n); return nullptr; }
    return result;
}
int64_t hv_unbox_int(void* o) {
    if (!o) return 0;
    void* p=a.object_unbox(o);if(!p)return 0;
    int t=a.type_get_type(a.class_get_type(a.object_get_class(o)));
    switch(t){case 2:case 5:return *static_cast<uint8_t*>(p);case 4:return *static_cast<int8_t*>(p);case 3:case 7:return *static_cast<uint16_t*>(p);case 6:return *static_cast<int16_t*>(p);case 10:case 11:return *static_cast<int64_t*>(p);default:return *static_cast<int32_t*>(p);}
}
void* hv_new(const char* cls) {
    void* k=hv_class(cls); if (!k) return nullptr;
    a.runtime_class_init(k); void* o=a.object_new(k);
    if (o && a.class_get_method_from_name(k,".ctor",0)) hv_call(o,cls,".ctor");
    return o;
}
void* hv_new_field_object(const char* owner,const char* name){
    hv_log("MENU allocate field %s.%s",owner,name);
    void* f=field(owner,name);if(!f)return nullptr;
    hv_log("MENU field resolved");
    void* k=a.class_from_type(a.field_get_type(f));if(!k)return nullptr;
    hv_log("MENU field class resolved");
    a.runtime_class_init(k);void* o=a.object_new(k);if(!o)return nullptr;
    hv_log("MENU field object allocated");
    void* ctor=a.class_get_method_from_name(k,".ctor",0);void* ex=nullptr;
    if(ctor)a.runtime_invoke(ctor,o,nullptr,&ex);
    if(ex){hv_log("field object constructor failed %s.%s",owner,name);return nullptr;}
    return o;
}
uintptr_t hv_hold(void* o){return o?a.gchandle_new(o,false):0;}
void* hv_held(uintptr_t h){return h?a.gchandle_get_target(h):nullptr;}
void hv_release(uintptr_t h){if(h)a.gchandle_free(h);}
void* hv_string(const char* s) { return ready ? a.string_new(s?s:"") : nullptr; }
const char* hv_utf8(void* o) {
    static thread_local std::string out; out.clear(); if (!o) return "";
    const char16_t* s=a.string_chars(o); int n=a.string_length(o);
    if (!s || n<0 || n>65536) return "";
    for(int i=0;i<n;++i) {
        unsigned c=s[i];
        if(c>=0xd800 && c<=0xdbff && i+1<n && s[i+1]>=0xdc00 && s[i+1]<=0xdfff) c=0x10000+((c-0xd800)<<10)+(s[++i]-0xdc00);
        if(c<0x80) out.push_back(static_cast<char>(c));
        else if(c<0x800) {out.push_back(char(0xc0|(c>>6)));out.push_back(char(0x80|(c&63)));}
        else if(c<0x10000) {out.push_back(char(0xe0|(c>>12)));out.push_back(char(0x80|((c>>6)&63)));out.push_back(char(0x80|(c&63)));}
        else {out.push_back(char(0xf0|(c>>18)));out.push_back(char(0x80|((c>>12)&63)));out.push_back(char(0x80|((c>>6)&63)));out.push_back(char(0x80|(c&63)));}
    } return out.c_str();
}
void* hv_new_array(const char* cls,size_t n) {void* k=hv_class(cls);return k && n<=65536?a.array_new(k,n):nullptr;}
size_t hv_array_count(void* o) {if(!o)return 0;size_t n=*reinterpret_cast<size_t*>(static_cast<char*>(o)+24);return n<=65536?n:0;}
void* hv_array_at(void* o,size_t i) {return i<hv_array_count(o)?reinterpret_cast<void**>(static_cast<char*>(o)+32)[i]:nullptr;}
bool hv_array_set(void* o,size_t i,void* v) {if(i>=hv_array_count(o))return false;a.gc_wbarrier_set_field(o,reinterpret_cast<void**>(static_cast<char*>(o)+32)+i,v);return true;}
int64_t hv_array_int(void* o,size_t i,int bytes) {
    if(i>=hv_array_count(o))return 0;char* p=static_cast<char*>(o)+32+i*bytes;
    switch(bytes){case 1:return *reinterpret_cast<int8_t*>(p);case 2:return *reinterpret_cast<int16_t*>(p);case 4:return *reinterpret_cast<int32_t*>(p);case 8:return *reinterpret_cast<int64_t*>(p);default:return 0;}
}
bool hv_array_set_int(void* o,size_t i,int bytes,int64_t value){
    if(i>=hv_array_count(o))return false;char* p=static_cast<char*>(o)+32+i*bytes;
    switch(bytes){case 1:*reinterpret_cast<int8_t*>(p)=(int8_t)value;break;case 2:*reinterpret_cast<int16_t*>(p)=(int16_t)value;break;case 4:*reinterpret_cast<int32_t*>(p)=(int32_t)value;break;case 8:*reinterpret_cast<int64_t*>(p)=value;break;default:return false;}
    return true;
}
size_t hv_list_count(void* o) {if(!o)return 0;int v=0;void* f=a.class_get_field_from_name(a.object_get_class(o),"_size");if(f)a.field_get_value(o,f,&v);return v>=0&&v<=65536?static_cast<size_t>(v):0;}
void* hv_list_at(void* o,size_t i) {if(i>=hv_list_count(o))return nullptr;void* ar=nullptr;void* f=a.class_get_field_from_name(a.object_get_class(o),"_items");if(f)a.field_get_value(o,f,&ar);return hv_array_at(ar,i);}
void* hv_self() {return hv_call(nullptr,"Char","itMe");}
void* hv_map_scr() {return hv_call(nullptr,"MapScr","gI");}
int hv_map_id() {return static_cast<int>(hv_int(nullptr,"LoadMapgame","mapID"));}
uint64_t hv_now_ms() {timespec t{};clock_gettime(CLOCK_MONOTONIC,&t);return uint64_t(t.tv_sec)*1000+t.tv_nsec/1000000;}
namespace {
struct LogState{std::mutex lock;HvLogFile file;std::deque<std::string> early;bool opened=false;};
LogState& logs(){static LogState state;return state;}
}
void hv_log(const char* f,...) {
    char message[1536],line[1664];va_list args;va_start(args,f);std::vsnprintf(message,sizeof(message),f,args);va_end(args);
    std::snprintf(line,sizeof(line),"t=%llu tid=%d %s",(unsigned long long)hv_now_ms(),gettid(),message);
    __android_log_write(ANDROID_LOG_INFO,"HVNJ-MOD",line);
    auto& log=logs();std::lock_guard<std::mutex> lock(log.lock);
    if(log.opened)log.file.write(line);
    else{if(log.early.size()>=64)log.early.pop_front();log.early.emplace_back(line);}
}
void hv_log_start_file(){
    static bool attempted=false;if(attempted)return;attempted=true;
    std::string dir=hv_utf8(hv_call(nullptr,"UnityEngine.Application","get_persistentDataPath"));
    if(dir.empty()||dir[0]!='/'){hv_log("FILE_LOG unavailable: persistentDataPath missing");return;}
    auto& log=logs();
    {std::lock_guard<std::mutex> lock(log.lock);log.opened=log.file.open(dir+"/hvnj-mod.log");
     if(log.opened){for(const auto& s:log.early)log.file.write(s.c_str());log.early.clear();}}
    hv_log("FILE_LOG %s build=185-arm64-log-v5",log.opened?"enabled":"open failed");
}
void hv_notice(const char* s) {void* args[]={hv_string(s)};hv_call(nullptr,"GameCanvas","startOKDlg",1,args);}

// Generic managed List<T> factory from the current MenuG4M list's actual class.
void* hv_clone_empty_list(void* example) {
    hv_log("MENU clone list begin");
    if(!example)return nullptr;void* k=a.object_get_class(example);void* o=a.object_new(k);
    void* m=a.class_get_method_from_name(k,".ctor",0);void* ex=nullptr;
    if(m)a.runtime_invoke(m,o,nullptr,&ex);return ex?nullptr:o;
}
