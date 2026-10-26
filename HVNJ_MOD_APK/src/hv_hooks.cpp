#include "hv_runtime.h"
#include "hv_protocol.h"
#include "hv_profile.h"
#include <dobby.h>
#include <dlfcn.h>
#include <jni.h>
#include <pthread.h>
#include <unistd.h>
#include <cstring>
#include <mutex>
#include <atomic>

bool hv_runtime_init(void*);
void* hv_attach();void hv_detach(void*);
void hv_menu_load();void hv_menu_append();void hv_menu_gui();bool hv_menu_action(void*);
namespace {
using VoidMethod=void(*)(void*,void*);
VoidMethod orig_update=nullptr,orig_init=nullptr,orig_menu=nullptr,orig_gui=nullptr,orig_command=nullptr,orig_focus=nullptr,orig_auto_focus=nullptr;
void* (*orig_task)(void*,void*,void*)=nullptr;
void* (*orig_phu)(void*)=nullptr;
void (*orig_receive)(void*,void*,void*)=nullptr;
void (*orig_open)(void*,int,void*)=nullptr;
void (*orig_select)(void*,int,int,int,void*)=nullptr;
void (*orig_store)(void*,int,void*)=nullptr;
void (*orig_withdraw)(void*,int,void*)=nullptr;
void (*orig_upgrade)(void*,void*,void*,bool,void*)=nullptr;
void (*orig_buy)(void*,int,int,int,void*)=nullptr;
void (*orig_sell)(void*,int,int,void*)=nullptr;
void (*orig_stone)(void*,void*,void*)=nullptr;
HvProtocol protocol;
std::mutex protocol_lock;
thread_local bool internal=false;
std::atomic<bool> enabled{false};
std::atomic<uint64_t> trace_until{0};std::atomic<int> trace_budget{0};
void trace_transaction(const char* name){trace_budget.store(64);trace_until.store(hv_now_ms()+10000);hv_log("TX %s map=%d",name,hv_map_id());}
void store_hook(void* self,int slot,void* method){trace_transaction("itemBagToBox");hv_log("TX slot=%d",slot);orig_store(self,slot,method);}
void withdraw_hook(void* self,int slot,void* method){trace_transaction("itemBoxToBag");hv_log("TX slot=%d",slot);orig_withdraw(self,slot,method);}
void upgrade_hook(void* self,void* item,void* stones,bool gold,void* method){trace_transaction("upgradeItem");hv_log("TX upgrade slot=%lld stones=%zu gold=%d",(long long)hv_int(item,"ItemGame","indexUI"),hv_array_count(stones),gold);orig_upgrade(self,item,stones,gold,method);}
void buy_hook(void* self,int ui,int slot,int qty,void* method){trace_transaction("buyItem");hv_log("TX shop_ui=%d slot=%d qty=%d",ui,slot,qty);orig_buy(self,ui,slot,qty,method);}
void sell_hook(void* self,int slot,int qty,void* method){trace_transaction("sellItem");hv_log("TX slot=%d qty=%d",slot,qty);orig_sell(self,slot,qty,method);}
void stone_hook(void* self,void* items,void* method){trace_transaction("crystalCollectLock");orig_stone(self,items,method);}

bool service_busy(){std::lock_guard<std::mutex> lock(protocol_lock);return protocol.phase!=HvProtocol::IDLE||hv_now_ms()<protocol.manual_until;}

bool allow_external(){
    if(internal||!enabled.load())return true;
    std::lock_guard<std::mutex> lock(protocol_lock);
    bool ok=protocol.external(hv_now_ms());
    if(!ok)hv_log("NPC request deferred: mod handshake active");
    return ok;
}
void open_hook(void* self,int npc,void* method){hv_log("TX openMenu npc=%d internal=%d",npc,internal);if(allow_external())orig_open(self,npc,method);}
void select_hook(void* self,int npc,int menu,int option,void* method){hv_log("TX menu npc=%d menu=%d option=%d internal=%d",npc,menu,option,internal);if(allow_external())orig_select(self,npc,menu,option,method);}
void service_tick(uint64_t now){
    bool send=false,timeout=false;int npc=0;
    {std::lock_guard<std::mutex> lock(protocol_lock);
     bool waiting=protocol.phase==HvProtocol::SEND;
     timeout=protocol.tick(now);send=waiting&&protocol.phase==HvProtocol::PANEL;
     npc=protocol.ui==4?5:6;}
    if(timeout){hv_call(nullptr,"GameCanvas","endDlg");hv_notice("NPC không phản hồi. Hãy đến đúng map và thử lại.");hv_log("NPC handshake timed out; no transaction sent");}
    if(send){void* svc=hv_call(nullptr,"Service","gI");int zero=0;void* a[]={&npc,&zero,&zero};internal=true;hv_call(svc,"Service","menu",3,a);internal=false;hv_log("NPC menu sent npc=%d",npc);}
}
void receive_hook(void* self,void* msg,void* method){
    if(!enabled.load()){orig_receive(self,msg,method);return;}
    int cmd=(int)hv_int(msg,"Message","command"),panel=-1;
    if(hv_now_ms()<trace_until.load()&&trace_budget.fetch_sub(1)>0){
        void* reader=hv_obj(msg,"Message","dis");size_t length=hv_array_count(hv_obj(reader,"ReaderG4M","buffer"));
        hv_log("RX after_transaction cmd=%d bytes=%zu",cmd,length);
    }
    if(cmd==30){void* reader=hv_obj(msg,"Message","dis");void* data=hv_obj(reader,"ReaderG4M","buffer");int pos=(int)hv_int(reader,"ReaderG4M","posRead");if(pos>=0&&(size_t)pos<hv_array_count(data))panel=(int)hv_array_int(data,(size_t)pos,1);}
    bool consume=false;
    {std::lock_guard<std::mutex> lock(protocol_lock);consume=protocol.receive(cmd,panel,hv_now_ms());}
    if(cmd==40||cmd==30)hv_log("NPC rx cmd=%d panel=%d consumed=%d",cmd,panel,consume);
    if(!consume)orig_receive(self,msg,method);
}
void filter_focus(void* self){
    if(!enabled.load())return;
    if(self!=hv_self())return;
    void* old=hv_obj(self,"Char","monsterFocus");if(!old)return;
    void* task=hv_obj(hv_map_scr(),"MapScr","taskOrder");
    void* target=hv_features_target(old,task);if(target!=old)hv_set_obj(self,"Char","monsterFocus",target);
}
void focus_hook(void* self,void* method){orig_focus(self,method);filter_focus(self);}
void auto_focus_hook(void* self,void* method){orig_auto_focus(self,method);filter_focus(hv_self());}
void* task_hook(void* self,void* task,void* method){void* result=orig_task(self,task,method);return enabled.load()?hv_features_target(result,task):result;}
void* phu_hook(void* method){void* result=orig_phu(method);return enabled.load()?hv_features_target(result,nullptr):result;}
void init_hook(void* self,void* method){
    bool was=enabled.load()&&hv_cfg.enabled[HV_TRIAL]&&hv_bool(nullptr,"AutomaticPopupG4M","isAuto");
    orig_init(self,method);
    if(was&&hv_map_id()==161){bool yes=true;void* args[]={&yes};hv_call(nullptr,"MapScr","setAuto",1,args);}
}
void update_hook(void* self,void* method){
    orig_update(self,method);if(!enabled.load())return;
    hv_log_start_file();
    static int last_map=-999;int map=hv_map_id();
    if(map!=last_map){hv_log("MAP change old=%d new=%d",last_map,map);last_map=map;}
    hv_menu_load();uint64_t now=hv_now_ms();service_tick(now);
    if(service_busy())return;
    // Inventory consumes the same service channel; quest engine observes bag busy.
    hv_bag_tick(now);hv_features_tick(now);
}
void menu_hook(void* self,void* method){orig_menu(self,method);if(enabled.load())hv_menu_append();}
void command_hook(void* self,void* method){if(!enabled.load()||!hv_menu_action(self))orig_command(self,method);}
void gui_hook(void* self,void* method){
    orig_gui(self,method);hv_log_start_file();
    static void* previous_popup=nullptr;static void* previous_screen=nullptr;
    void* popup=hv_obj(nullptr,"GameCanvas","currentPop");void* screen=hv_obj(nullptr,"GameCanvas","currentScr");
    if(popup!=previous_popup||screen!=previous_screen){hv_log("UI screen=%s popup=%s",hv_type_name(screen),hv_type_name(popup));previous_popup=popup;previous_screen=screen;}
    if(enabled.load())hv_menu_gui();
}

template<class F> bool install(uintptr_t base,const char* cls,const char* name,F hook,F* original){
    for(const auto& p:hv_hook_profiles){
        if(std::strcmp(p.owner,cls)||std::strcmp(p.name,name))continue;
        void* addr=reinterpret_cast<void*>(base+p.va);
        if(p.size<4||std::memcmp(addr,p.guard,p.size)){hv_log("Guard rejected %s.%s",cls,name);return false;}
        int result=DobbyHook(addr,reinterpret_cast<func_t>(hook),reinterpret_cast<func_t*>(original));
        hv_log("Hook %s.%s VA=%lx status=%d",cls,name,(unsigned long)p.va,result);return result==0;
    }
    hv_log("No profile for %s.%s",cls,name);return false;
}
void* worker(void*){
    hv_log("BOOT build=185-arm64-log-v1 waiting for IL2CPP");
    for(int attempt=0;attempt<300;++attempt){
        void* lib=dlopen("libil2cpp.so",RTLD_NOW|RTLD_NOLOAD);
        if(!lib){usleep(100000);continue;}
        if(!hv_runtime_init(lib)){dlclose(lib);usleep(100000);continue;}
        void* thread=hv_attach();
        if(!hv_class("MapScr")){hv_detach(thread);dlclose(lib);usleep(100000);continue;}
        Dl_info info{};dladdr(dlsym(lib,"il2cpp_domain_get"),&info);uintptr_t base=(uintptr_t)info.dli_fbase;
        if(!base){hv_detach(thread);dlclose(lib);return nullptr;}
        // Validate every target before any code patch. If installation then fails,
        // all wrappers remain transparent and no mod menu or engine is activated.
        for(const auto& p:hv_hook_profiles){
            if(p.size<4||std::memcmp(reinterpret_cast<void*>(base+p.va),p.guard,p.size)){
                hv_log("Profile preflight rejected %s.%s; mod disabled",p.owner,p.name);
                hv_detach(thread);dlclose(lib);return nullptr;
            }
        }
        bool ok=true;
#define HOOK(c,n,f,o) ok=install(base,c,n,f,&o)&&ok
        HOOK("CommandGame","performAction",command_hook,orig_command);
        HOOK("MapScr","doMenuChar",menu_hook,orig_menu);
        HOOK("MapScr","initData",init_hook,orig_init);
        HOOK("MapScr","getTaskMob",task_hook,orig_task);
        HOOK("MapScr","getTaskPhuMonster",phu_hook,orig_phu);
        HOOK("MapScr","autoFocus",auto_focus_hook,orig_auto_focus);
        HOOK("Char","findFocus",focus_hook,orig_focus);
        HOOK("Service","openMenu",open_hook,orig_open);
        HOOK("Service","menu",select_hook,orig_select);
        HOOK("GlobalMessage","onMessage",receive_hook,orig_receive);
        HOOK("Main","OnGUI",gui_hook,orig_gui);
        HOOK("MapScr","update",update_hook,orig_update);
#undef HOOK
        // Diagnostic hooks are transparent; their failure must not disable gameplay.
        install(base,"Service","itemBagToBox",store_hook,&orig_store);
        install(base,"Service","itemBoxToBag",withdraw_hook,&orig_withdraw);
        install(base,"Service","upgradeItem",upgrade_hook,&orig_upgrade);
        install(base,"Service","buyItem",buy_hook,&orig_buy);
        install(base,"Service","sellItem",sell_hook,&orig_sell);
        install(base,"Service","crystalCollectLock",stone_hook,&orig_stone);
        enabled.store(ok);
        hv_log("ARM64 profile185 hook installation complete status=%d; defaults off",ok);
        hv_detach(thread);return nullptr; // retain dlopen handle while hooks live
    }
    hv_log("IL2CPP startup timeout; mod disabled");return nullptr;
}
__attribute__((constructor)) void load(){pthread_t thread;if(pthread_create(&thread,nullptr,worker,nullptr)==0)pthread_detach(thread);}
}
void hv_service_open(int ui){
    if(!enabled.load()||!orig_open||!orig_select||!orig_receive){hv_notice("Mod NPC chưa khởi tạo.");return;}
    if(hv_bag_busy()){hv_notice("Đang xử lý hành trang, hãy thử lại sau.");return;}
    {std::lock_guard<std::mutex> lock(protocol_lock);if(!protocol.start(ui,hv_now_ms())){hv_notice("Đang chờ phản hồi NPC, hãy thử lại sau.");return;}}
    int npc=ui==4?5:6;void* args[]={&npc};
    internal=true;hv_call(hv_call(nullptr,"Service","gI"),"Service","openMenu",1,args);internal=false;
    hv_log("NPC handshake requested ui=%d npc=%d map=%d",ui,npc,hv_map_id());
}
extern "C" JNIEXPORT jint JNI_OnLoad(JavaVM*,void*){return JNI_VERSION_1_6;}
