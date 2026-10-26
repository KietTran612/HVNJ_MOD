#include "hv_runtime.h"
#include "hv_protocol.h"
#include "hv_profile.h"
#include "hv_startup_gate.h"
#include <dobby.h>
#include <dlfcn.h>
#include <jni.h>
#include <pthread.h>
#include <unistd.h>
#include <cstring>
#include <mutex>
#include <atomic>

bool hv_runtime_init(void*);
void hv_menu_load();void hv_menu_append();void hv_menu_gui();bool hv_menu_action(void*);
void hv_menu_extend_main(void*,int);
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
bool (*orig_connect)(void*,void*,int,void*)=nullptr;
void (*orig_close)(void*,void*)=nullptr;
void (*orig_login_sdk)(void*,int8_t,void*,void*,void*)=nullptr;
void (*orig_main_menu)(void*,void*,int8_t,void*)=nullptr;
void (*orig_npc_menu_ui)(void*,bool,void*)=nullptr;
HvProtocol protocol;
std::mutex protocol_lock;
thread_local bool internal=false;
std::atomic<bool> enabled{false};
HvStartupGate startup;
struct NpcMenuContext {uintptr_t self=0,npc=0,previous=0;int map=-1;bool shown=false;uint64_t visible_at=0,show_deadline=0;} npc_context;
void clear_npc_context(){
    void* self=hv_held(npc_context.self);void* npc=hv_held(npc_context.npc);
    if(self&&hv_obj(self,"Char","npcFocus")==npc)hv_set_obj(self,"Char","npcFocus",hv_held(npc_context.previous));
    hv_release(npc_context.self);hv_release(npc_context.npc);hv_release(npc_context.previous);npc_context={};
}
bool prepare_npc_context(int id){
    clear_npc_context();void* self=hv_self();if(!self)return false;
    void* args[]={&id};void* npc=hv_call(nullptr,"MapScr","getNpc",1,args);
    if(!npc){
        void* templates=hv_obj(nullptr,"ManagerDataGame","listNpcTemplate"),*target=nullptr;
        for(size_t i=0;i<hv_array_count(templates);++i){void* t=hv_array_at(templates,i);if(t&&hv_int(t,"NpcGameTemplate","npcTemplateId")==id){target=t;break;}}
        if(!target||!hv_array_count(hv_obj(target,"NpcGameTemplate","menu")))return false;
        // UI context only: never add this object to the map or alter server/map IDs.
        npc=hv_new("NpcGame");if(!npc||!hv_set_obj(npc,"NpcGame","template",target))return false;
    }
    npc_context.self=hv_hold(self);npc_context.npc=hv_hold(npc);
    npc_context.previous=hv_hold(hv_obj(self,"Char","npcFocus"));npc_context.map=hv_map_id();npc_context.show_deadline=hv_now_ms()+10000;
    if(!npc_context.self||!npc_context.npc){clear_npc_context();return false;}
    hv_set_obj(self,"Char","npcFocus",npc);
    hv_log("NPC menu context template=%d rows=%zu map=%d",id,hv_array_count(hv_obj(hv_obj(npc,"NpcGame","template"),"NpcGameTemplate","menu")),hv_map_id());return true;
}
void pin_npc_context(){if(npc_context.npc)hv_set_obj(hv_held(npc_context.self),"Char","npcFocus",hv_held(npc_context.npc));}
void cancel_npc_context(uint64_t now){
    {std::lock_guard<std::mutex> lock(protocol_lock);protocol.phase=HvProtocol::DRAIN;protocol.deadline=now+5000;}
    if(npc_context.shown)hv_call(hv_call(nullptr,"MenuG4M","gI"),"MenuG4M","closeM");
    clear_npc_context();hv_log("NPC menu context cancelled; drain late replies");
}
void install_runtime_hooks(uintptr_t);
std::atomic<uint64_t> trace_until{0};std::atomic<int> trace_budget{0};
void trace_transaction(const char* name){trace_budget.store(64);trace_until.store(hv_now_ms()+10000);hv_log("TX %s map=%d",name,hv_map_id());}
void store_hook(void* self,int slot,void* method){trace_transaction("itemBagToBox");hv_log("TX slot=%d",slot);orig_store(self,slot,method);}
void withdraw_hook(void* self,int slot,void* method){trace_transaction("itemBoxToBag");hv_log("TX slot=%d",slot);orig_withdraw(self,slot,method);}
void upgrade_hook(void* self,void* item,void* stones,bool gold,void* method){trace_transaction("upgradeItem");hv_log("TX upgrade slot=%lld stones=%zu gold=%d",(long long)hv_int(item,"ItemGame","indexUI"),hv_array_count(stones),gold);orig_upgrade(self,item,stones,gold,method);}
void buy_hook(void* self,int ui,int slot,int qty,void* method){trace_transaction("buyItem");hv_log("TX shop_ui=%d slot=%d qty=%d",ui,slot,qty);orig_buy(self,ui,slot,qty,method);}
void sell_hook(void* self,int slot,int qty,void* method){trace_transaction("sellItem");hv_log("TX slot=%d qty=%d",slot,qty);orig_sell(self,slot,qty,method);}
void stone_hook(void* self,void* items,void* method){trace_transaction("crystalCollectLock");orig_stone(self,items,method);}
bool connect_hook(void* self,void* host,int port,void* method){
    hv_log("NET connect host=%s port=%d",hv_utf8(host),port);
    bool result=orig_connect(self,host,port,method);
    hv_log("NET connect result=%d connected=%d tx_bytes=%lld rx_bytes=%lld",result,hv_bool(self,"Session_ME","connected"),(long long)hv_int(nullptr,"Session_ME","sendByteCount"),(long long)hv_int(nullptr,"Session_ME","recvByteCount"));
    return result;
}
void close_hook(void* self,void* method){
    hv_log("NET close connected=%d tx_bytes=%lld rx_bytes=%lld",hv_bool(self,"Session_ME","connected"),(long long)hv_int(nullptr,"Session_ME","sendByteCount"),(long long)hv_int(nullptr,"Session_ME","recvByteCount"));
    orig_close(self,method);
}
void login_sdk_hook(void* self,int8_t type,void* name,void* password,void* method){
    hv_log("LOGIN G4M begin type=%d",(int)type);
    orig_login_sdk(self,type,name,password,method);
    hv_log("LOGIN G4M original returned"); // never log name/password or packet data
}
void main_menu_hook(void* self,void* list,int8_t type,void* method){if(enabled.load())hv_menu_extend_main(list,(int)type);orig_main_menu(self,list,type,method);}
void npc_menu_ui_hook(void* self,bool is_npc,void* method){
    // Remote NPCs have no world anchor: keep native commands, center only their UI.
    bool center=enabled.load()&&npc_context.npc&&is_npc;
    if(center)hv_log("NPC menu UI centered; native options preserved");
    orig_npc_menu_ui(self,center?false:is_npc,method);
}

bool service_busy(){std::lock_guard<std::mutex> lock(protocol_lock);return npc_context.npc||protocol.phase!=HvProtocol::IDLE||hv_now_ms()<protocol.manual_until;}

bool allow_external(){
    if(internal||!enabled.load())return true;
    std::lock_guard<std::mutex> lock(protocol_lock);
    bool ok=protocol.external(hv_now_ms());
    if(!ok)hv_log("NPC request deferred: mod handshake active");
    return ok;
}
void open_hook(void* self,int npc,void* method){hv_log("TX openMenu npc=%d internal=%d",npc,internal);if(allow_external()){if(!internal&&npc_context.npc)clear_npc_context();orig_open(self,npc,method);}}
void select_hook(void* self,int npc,int menu,int option,void* method){hv_log("TX menu npc=%d menu=%d option=%d internal=%d",npc,menu,option,internal);if(allow_external())orig_select(self,npc,menu,option,method);}
void service_tick(uint64_t now){
    bool timeout=false;uint64_t manual_until=0;
    {std::lock_guard<std::mutex> lock(protocol_lock);
     timeout=protocol.tick(now);manual_until=protocol.manual_until;}
    if(timeout){clear_npc_context();hv_call(nullptr,"GameCanvas","endDlg");hv_notice("NPC chưa trả menu. Hãy thử lại.");hv_log("NPC menu timed out; no option selected");}
    if(npc_context.npc){
        if(npc_context.map!=hv_map_id()||hv_held(npc_context.self)!=hv_self()){cancel_npc_context(now);return;}
        if(hv_bool(hv_call(nullptr,"MenuG4M","gI"),"MyMenuG4M","isShow")){npc_context.shown=true;npc_context.visible_at=now;}
        else if(npc_context.shown&&now>npc_context.visible_at+500&&now>=manual_until)clear_npc_context();
        else if(!npc_context.shown&&now>=npc_context.show_deadline){cancel_npc_context(now);hv_notice("NPC chưa mở menu. Hãy thử lại.");}
        pin_npc_context();
    }
}
void receive_hook(void* self,void* msg,void* method){
    if(!enabled.load()){orig_receive(self,msg,method);return;}
    int cmd=(int)hv_int(msg,"Message","command"),panel=-1;
    if(npc_context.npc&&(npc_context.map!=hv_map_id()||hv_held(npc_context.self)!=hv_self()))cancel_npc_context(hv_now_ms());
    void* map=hv_obj(nullptr,"MapScr","instance");
    if(!map||hv_obj(nullptr,"GameCanvas","currentScr")!=map){
        void* reader=hv_obj(msg,"Message","dis");
        hv_log("LOGIN_RX cmd=%d bytes=%zu",cmd,hv_array_count(hv_obj(reader,"ReaderG4M","buffer")));
    }
    if(hv_now_ms()<trace_until.load()&&trace_budget.fetch_sub(1)>0){
        void* reader=hv_obj(msg,"Message","dis");size_t length=hv_array_count(hv_obj(reader,"ReaderG4M","buffer"));
        hv_log("RX after_transaction cmd=%d bytes=%zu",cmd,length);
    }
    if(cmd==30){void* reader=hv_obj(msg,"Message","dis");void* data=hv_obj(reader,"ReaderG4M","buffer");int pos=(int)hv_int(reader,"ReaderG4M","posRead");if(pos>=0&&(size_t)pos<hv_array_count(data))panel=(int)hv_array_int(data,(size_t)pos,1);}
    bool consume=false;
    {std::lock_guard<std::mutex> lock(protocol_lock);consume=protocol.receive(cmd,panel,hv_now_ms());}
    if(cmd==40||cmd==30)hv_log("NPC rx cmd=%d panel=%d consumed=%d",cmd,panel,consume);
    if(!consume){if(cmd==40)pin_npc_context();orig_receive(self,msg,method);
        if(cmd==40&&npc_context.npc){void* menu=hv_call(nullptr,"MenuG4M","gI");void* list=hv_obj(menu,"MenuG4M","listMenu");hv_log("NPC native menu returned show=%d rows=%zu",hv_bool(menu,"MyMenuG4M","isShow"),hv_list_count(list));}
    }
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
    if(enabled.load()&&npc_context.map==hv_map_id())pin_npc_context();
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
    orig_gui(self,method);
    if(!startup.on_managed([](void* lib){
        hv_log("BOOT managed Main.OnGUI reached; resolve IL2CPP on main thread");
        return hv_runtime_init(lib)&&hv_class("MapScr");
    },install_runtime_hooks))return;
    hv_log_start_file();
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
void install_runtime_hooks(uintptr_t base){
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
        HOOK("MapScr","update",update_hook,orig_update);
        HOOK("MenuLeftG4M","startAt",main_menu_hook,orig_main_menu);
        HOOK("MenuG4M","initUI",npc_menu_ui_hook,orig_npc_menu_ui);
#undef HOOK
        // Diagnostic hooks are transparent; their failure must not disable gameplay.
        install(base,"Service","itemBagToBox",store_hook,&orig_store);
        install(base,"Service","itemBoxToBag",withdraw_hook,&orig_withdraw);
        install(base,"Service","upgradeItem",upgrade_hook,&orig_upgrade);
        install(base,"Service","buyItem",buy_hook,&orig_buy);
        install(base,"Service","sellItem",sell_hook,&orig_sell);
        install(base,"Service","crystalCollectLock",stone_hook,&orig_stone);
        install(base,"Session_ME","doConnect",connect_hook,&orig_connect);
        install(base,"Session_ME","close",close_hook,&orig_close);
        install(base,"ServiceSDK","loginG4M",login_sdk_hook,&orig_login_sdk);
        enabled.store(ok);
        hv_log("ARM64 profile185 hook installation complete status=%d; defaults off",ok);
}
void* worker(void*){
    hv_log("BOOT build=185-arm64-log-v5 waiting for mapped IL2CPP image");
    for(int attempt=0;attempt<300;++attempt){
        void* lib=dlopen("libil2cpp.so",RTLD_NOW|RTLD_NOLOAD);
        if(!lib){usleep(100000);continue;}
        // dlsym/dladdr and code-byte checks do not invoke VM APIs. domain_get
        // lazily constructs AppDomain and crashes if used as a readiness probe.
        Dl_info info{};dladdr(dlsym(lib,"il2cpp_domain_get"),&info);uintptr_t base=(uintptr_t)info.dli_fbase;
        if(!base){dlclose(lib);return nullptr;}
        for(const auto& p:hv_hook_profiles){
            if(p.size<4||std::memcmp(reinterpret_cast<void*>(base+p.va),p.guard,p.size)){
                hv_log("Profile preflight rejected %s.%s; mod disabled",p.owner,p.name);
                dlclose(lib);return nullptr;
            }
        }
        startup.discover(lib,base);
        if(install(base,"Main","OnGUI",gui_hook,&orig_gui))
            hv_log("BOOT Main.OnGUI bootstrap armed; VM APIs deferred");
        return nullptr; // retain dlopen handle while hooks live
    }
    hv_log("IL2CPP startup timeout; mod disabled");return nullptr;
}
__attribute__((constructor)) void load(){pthread_t thread;if(pthread_create(&thread,nullptr,worker,nullptr)==0)pthread_detach(thread);}
}
void hv_service_open(int ui){
    if(!enabled.load()||!orig_open||!orig_select||!orig_receive){hv_notice("Mod NPC chưa khởi tạo.");return;}
    if(ui!=4&&ui!=10)return;
    if(hv_bag_busy()){hv_notice("Đang xử lý hành trang, hãy thử lại sau.");return;}
    {std::lock_guard<std::mutex> lock(protocol_lock);if(!protocol.start(ui,hv_now_ms())){hv_notice("Đang chờ phản hồi NPC, hãy thử lại sau.");return;}}
    int npc=ui==4?5:6;
    if(!prepare_npc_context(npc)){
        {std::lock_guard<std::mutex> lock(protocol_lock);protocol=HvProtocol{};}
        hv_notice("Chưa có dữ liệu menu NPC này trong phiên.");hv_log("NPC menu missing template=%d map=%d",npc,hv_map_id());return;
    }
    hv_call(hv_call(nullptr,"MenuG4M","gI"),"MenuG4M","closeM");void* args[]={&npc};
    internal=true;hv_call(hv_call(nullptr,"Service","gI"),"Service","openMenu",1,args);internal=false;
    hv_log("NPC menu requested ui=%d npc=%d map=%d; user selects option",ui,npc,hv_map_id());
}
extern "C" JNIEXPORT jint JNI_OnLoad(JavaVM*,void*){return JNI_VERSION_1_6;}
