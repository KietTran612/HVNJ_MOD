#include "hv_runtime.h"
#include <limits>

namespace {
constexpr const char* C = "char"; // Cpp2IL spelling; runtime resolves Char/char aliases.
constexpr int FIRST = 161, LAST = 167, TEACHER = 25;
struct State {
    int map=-1, character=-1, alive_map=-1;
    bool was_auto=false, quest_armed=false;
    bool returning=false, death_stopped=false, quest_stopped=false;
    uint64_t death_start=0, death_next=0, nav_next=0, stage_empty=0, stage_next=0;
    uint64_t party_next=0, quest_next=0;
    int death_tries=0, nav_tries=0, stage_tries=0, quest_tries=0;
    int task_kind=-1, task_kill=-1, task_count=-1, task_map=-1;
    int accept_tries[2]{}, accept_nav_tries=0;
    bool exhausted[2]{};
} s;
bool on(int f) { return hv_cfg.enabled[f]; }
bool ready(const char* c,const char* f) { return hv_has_field(c,f); }
bool method(const char* c,const char* m,int n) { return hv_has_method(c,m,n); }
bool trial(int map) { return map>=FIRST && map<=LAST; }
bool automatic() { return ready("AutomaticPopupG4M","isAuto") && hv_bool(nullptr,"AutomaticPopupG4M","isAuto"); }
bool set_auto(bool value) {
    if(!method("MapScr","setAuto",1)) return false;
    void* a[]={&value}; hv_call(nullptr,"MapScr","setAuto",1,a); return true;
}
bool moving(void* me,void* scr) {
    return hv_bool(nullptr,C,"ischangingMap") || hv_bool(me,C,"isMoveAutoToTarget") ||
        hv_bool(scr,"MapScr","isFindPathMap") || hv_bool(scr,"MapScr","isClickAutoFind");
}
bool live(void* m) {
    return m && hv_int(m,"MonsterGame","hp")>0 && !hv_bool(m,"MonsterGame","isDisable") &&
        hv_int(m,"MonsterGame","status")!=0 && hv_int(m,"MonsterGame","status")!=1;
}
bool monster_fields() {
    return ready("MonsterGame","hp") && ready("MonsterGame","status") && ready("MonsterGame","isDisable") &&
        ready("MonsterGame","isBoss") && ready("MonsterGame","levelBoss") && ready("MonsterGame","templateId");
}
bool task_matches(void* m,void* task) {
    if(!task || !m) return false;
    int max=(int)hv_int(task,"TaskOrderGame","maxCount");
    return hv_int(task,"TaskOrderGame","taskId")==1 && max>0 &&
        hv_int(task,"TaskOrderGame","count")<max && hv_int(task,"TaskOrderGame","mapId")==hv_map_id() &&
        hv_int(task,"TaskOrderGame","killId")==hv_int(m,"MonsterGame","templateId");
}
bool allowed(void* m,void* task) {
    if(!live(m)) return false;
    if(task_matches(m,task)) return true;
    if(hv_bool(m,"MonsterGame","isBoss") || hv_int(m,"MonsterGame","levelBoss")>0) {
        void* tasks=hv_obj(nullptr,"MapScr","taskOrders");
        for(size_t i=0;i<hv_list_count(tasks);++i) if(task_matches(m,hv_list_at(tasks,i))) return true;
        return false;
    }
    return !task || hv_int(task,"TaskOrderGame","killId")==hv_int(m,"MonsterGame","templateId");
}
bool path(void* scr,int from,int to) {
    if(to<0 || !method("MapScr","findPathMap",2)) return false;
    void* a[]={&from,&to}; hv_call(scr,"MapScr","findPathMap",2,a); return true;
}
bool death(void* me,void* scr,int map,bool auto_now,uint64_t now) {
    if(!on(HV_DIE)) {s.returning=false;s.death_stopped=false;return false;}
    if(!ready(C,"hpNew") || !ready("AutomaticPopupG4M","isGoBack")) return false;
    bool dead=hv_int(me,C,"hpNew")<=0 || hv_int(me,C,"statusM")==5 || hv_int(me,C,"statusM")==14;
    if(s.death_stopped)return dead; // Only an explicit feature reset/re-enable starts a new retry budget.
    if(!dead && !s.returning) {s.alive_map=map;return false;}
    // Existing game setting opts into returning. Challenge deaths must use the game's revival flow.
    if(dead && !s.returning) {
        if(trial(map) || !hv_bool(nullptr,"AutomaticPopupG4M","isGoBack") || !(auto_now||s.was_auto)) return true;
        s.returning=true;s.death_start=now;s.death_next=now;s.death_tries=0;s.nav_tries=0;
        s.alive_map=map; s.nav_next=now;
    }
    if(now-s.death_start>90000) {s.returning=false;s.death_stopped=true;hv_notice("Auto return timed out; enable again to retry.");return true;}
    if(dead) {
        if(now>=s.death_next && s.death_tries<3 && method("Service","returnTownFromDead",0)) {
            void* service=hv_call(nullptr,"Service","gI");
            if(service){hv_call(service,"Service","returnTownFromDead");++s.death_tries;s.death_next=now+3000;}
        }
        return true;
    }
    if(map==s.alive_map) {set_auto(true);s.returning=false;s.was_auto=automatic();return true;}
    if(!hv_bag_busy() && !moving(me,scr) && now>=s.nav_next && s.nav_tries<5) {
        if(path(scr,map,s.alive_map)){++s.nav_tries;s.nav_next=now+5000;}
    }
    return true;
}
void* leader(void* me) {
    if(!ready("TeamListPopupG4M","listParty") || !ready("PartyObj","c")) return nullptr;
    void* list=hv_obj(nullptr,"TeamListPopupG4M","listParty");
    if(hv_list_count(list)<1) return nullptr;
    void* first=hv_list_at(list,0); if(!first)return nullptr;
    int id=(int)hv_int(first,"PartyObj","charId");
    if(id==(int)hv_int(me,C,"charID")) return nullptr;
    void* c=nullptr;
    // A cached PartyObj.c can survive map changes. Only follow currently visible map members.
    void* listmap=hv_obj(nullptr,"MapScr","listCharInMap");
    for(size_t i=0;i<hv_list_count(listmap);++i){void* v=hv_list_at(listmap,i);if(v&&hv_int(v,C,"charID")==id){c=v;break;}}
    return c && c!=me && hv_int(c,C,"hpNew")>0 ? c:nullptr;
}
bool party(void* me,uint64_t now) {
    if(!on(HV_PARTY)) return false;
    void* lead=leader(me); if(!lead) return false;
    if(now>=s.party_next && method(C,"setMoveAutoToTarget",1)) {
        void* a[]={lead};hv_call(me,C,"setMoveAutoToTarget",1,a);s.party_next=now+1500;
    }
    void* target=hv_obj(lead,C,"monsterFocus");
    if(target && monster_fields() && (!on(HV_MOB)?live(target):allowed(target,nullptr))) hv_set_obj(me,C,"monsterFocus",target);
    return true;
}
bool stage(void* me,int map,uint64_t now) {
    if(!on(HV_STAGE)||!trial(map)||!automatic()){s.stage_empty=0;return false;}
    if(!monster_fields() || !ready("MapScr","listMob") || !ready("LoadMapgame","vLink")) return false;
    void* mobs=hv_obj(nullptr,"MapScr","listMob");if(!mobs){s.stage_empty=0;return false;}
    for(size_t i=0;i<hv_list_count(mobs);++i)if(live(hv_list_at(mobs,i))){s.stage_empty=0;s.stage_tries=0;return true;}
    if(!s.stage_empty){s.stage_empty=now;return true;}
    if(now-s.stage_empty<2500 || now<s.stage_next || hv_bool(me,C,"isMoveAutoToTarget"))return true;
    if(map==LAST){set_auto(false);return true;}
    void* links=hv_obj(nullptr,"LoadMapgame","vLink");void* gate=nullptr;
    for(size_t i=0;i<hv_list_count(links);++i){void* p=hv_list_at(links,i);if(p && hv_int(p,"WaypointMap","idMapFrom")==map && hv_int(p,"WaypointMap","idMapTo")==map+1){gate=p;break;}}
    if(!gate || s.stage_tries>=5 || !method(C,"moveAutoToTarget",2) ||
        !ready("WaypointMap","minX")||!ready("WaypointMap","maxX")||!ready("WaypointMap","minY")||!ready("WaypointMap","maxY"))return true;
    float x=(float)(hv_int(gate,"WaypointMap","minX")+hv_int(gate,"WaypointMap","maxX"))/2.f;
    float y=(float)(hv_int(gate,"WaypointMap","minY")+hv_int(gate,"WaypointMap","maxY"))/2.f;
    void* a[]={&x,&y};hv_call(me,C,"moveAutoToTarget",2,a);++s.stage_tries;s.stage_next=now+3000;return true;
}
void accept(void* me,void* scr,int map,uint64_t now) {
    int kind=(on(HV_QUEST)&&!s.exhausted[0])?0:1;
    if((kind==1 && (!on(HV_TATHU)||s.exhausted[1])) || now<s.quest_next)return;
    int cls=(int)hv_int(me,C,"classMainID");
    // Verified APK185 clickTaskAuto VA1787710..178785c, not inferred PC constants.
    constexpr int school[]={1,1,72,72,27,27,160,160};
    if(cls<1||cls>8)return;
    if(map!=school[cls-1]) {
        if(s.accept_nav_tries>=5 || !method("MapScr","moveToNpc",3))return;
        int to=school[cls-1],npc=TEACHER;int8_t option=0;void* a[]={&to,&npc,&option};
        hv_call(scr,"MapScr","moveToNpc",3,a);++s.accept_nav_tries;s.quest_next=now+5000;return;
    }
    void* npcs=hv_obj(nullptr,"MapScr","listNpc");void* teacher=nullptr;void* templ=nullptr;
    for(size_t i=0;i<hv_list_count(npcs);++i){void* p=hv_list_at(npcs,i);if(!p)continue;void* t=hv_obj(p,"NpcGame","template");if(t&&hv_int(t,"NpcGameTemplate","npcTemplateId")==TEACHER){teacher=p;templ=t;break;}}
    if(!teacher)return;
    float x=hv_float(teacher,C,"x"),y=hv_float(teacher,C,"y");float dx=x-hv_float(me,C,"x"),dy=y-hv_float(me,C,"y");
    if(dx*dx+dy*dy>=24.f*24.f){if(method(C,"moveAutoToTarget",2)){void* a[]={&x,&y};hv_call(me,C,"moveAutoToTarget",2,a);s.quest_next=now+1500;}return;}
    if(s.accept_tries[kind]>=3){s.exhausted[kind]=true;s.quest_next=now+1000;return;}
    // The configured accept option must exist in actual NPC data; never invent a packet field.
    void* menu=hv_obj(templ,"NpcGameTemplate","menu");
    void* options=hv_array_at(menu,(size_t)kind);int option=hv_cfg.accept_option;
    if(option<0 || (size_t)option>=hv_array_count(options) || !method("Service","menu",3))return;
    void* service=hv_call(nullptr,"Service","gI");if(!service)return;
    int npc=TEACHER;void* a[]={&npc,&kind,&option};hv_call(service,"Service","menu",3,a);
    ++s.accept_tries[kind];s.quest_next=now+5000;
}
void quest(void* me,void* scr,int map,bool auto_now,uint64_t now) {
    if(!on(HV_QUEST)&&!on(HV_TATHU))return;
    if(auto_now){s.quest_armed=true;if(!s.was_auto){s.quest_stopped=false;s.quest_tries=0;}}
    if(!s.quest_armed||s.quest_stopped||moving(me,scr))return;
    if(!auto_now&&s.was_auto){s.quest_stopped=true;s.quest_armed=false;return;}
    if(!ready("MapScr","taskOrders")||!method("MapScr","clickTask",2) ||
        !ready("TaskOrderGame","taskId")||!ready("TaskOrderGame","count")||!ready("TaskOrderGame","maxCount")||
        !ready("TaskOrderGame","killId")||!ready("TaskOrderGame","mapId")||!ready(C,"classMainID"))return;
    void* tasks=hv_obj(nullptr,"MapScr","taskOrders");if(!tasks)return;
    void* chosen=nullptr;size_t index=0;
    for(int kind=0;kind<2&&!chosen;++kind){if(!on(kind?HV_TATHU:HV_QUEST))continue;for(size_t i=0;i<hv_list_count(tasks);++i){void* t=hv_list_at(tasks,i);if(t&&hv_int(t,"TaskOrderGame","taskId")==kind){chosen=t;index=i;break;}}}
    if(!chosen){accept(me,scr,map,now);s.was_auto=automatic();return;}
    s.accept_tries[0]=s.accept_tries[1]=s.accept_nav_tries=0;
    int kind=(int)hv_int(chosen,"TaskOrderGame","taskId"),kill=(int)hv_int(chosen,"TaskOrderGame","killId");
    int count=(int)hv_int(chosen,"TaskOrderGame","count"),to=(int)hv_int(chosen,"TaskOrderGame","mapId");
    if(kind!=s.task_kind||kill!=s.task_kill||count!=s.task_count||to!=s.task_map){s.quest_tries=0;s.task_kind=kind;s.task_kill=kill;s.task_count=count;s.task_map=to;}
    int max=(int)hv_int(chosen,"TaskOrderGame","maxCount");bool complete=max>0&&count>=max;
    if(kind==0&&map==to&&auto_now&&!complete)return;
    if(now<s.quest_next||index>125)return;
    if(s.quest_tries>=5 && !(kind==1&&map==to&&!complete)){s.quest_stopped=true;hv_notice("Quest made no progress; enable Auto again to retry.");return;}
    int8_t ui=(int8_t)(index+2);void* a[]={&ui,chosen};hv_call(scr,"MapScr","clickTask",2,a);
    ++s.quest_tries;s.quest_next=now+(kind==1?5000:3000);s.was_auto=automatic();
}
}

void* hv_features_target(void* original,void* task) {
    if(!original||!on(HV_MOB)||!automatic()||!monster_fields())return original;
    if(original&&allowed(original,task))return original;
    void* me=hv_self();if(!me)return original;
    void* mobs=hv_obj(nullptr,"MapScr","listMob");void* best=nullptr;double distance=std::numeric_limits<double>::max();
    for(size_t i=0;i<hv_list_count(mobs);++i){void* m=hv_list_at(mobs,i);if(!allowed(m,task))continue;
        double dx=hv_int(m,"MonsterGame","x")-hv_float(me,C,"x"),dy=hv_int(m,"MonsterGame","y")-hv_float(me,C,"y");
        double d=dx*dx+dy*dy;if(d<distance){best=m;distance=d;}}
    return best;
}
void hv_features_reset(int feature) {
    if(feature<0){s=State{};return;}
    if(feature==HV_DIE){s.returning=false;s.death_stopped=false;s.death_tries=s.nav_tries=0;}
    if(feature==HV_STAGE){s.stage_empty=s.stage_next=0;s.stage_tries=0;}
    if(feature==HV_PARTY)s.party_next=0;
    if(feature==HV_QUEST||feature==HV_TATHU){s.quest_armed=false;s.quest_stopped=false;s.quest_next=0;s.quest_tries=0;s.accept_nav_tries=0;for(int i=0;i<2;++i){s.accept_tries[i]=0;s.exhausted[i]=false;}}
}
void hv_features_tick(uint64_t now) {
    bool any=false;for(int i=0;i<=HV_PARTY;++i)any|=on(i);if(!any)return;
    void* me=hv_self();void* scr=hv_map_scr();int map=hv_map_id();
    if(!me||!scr||map<0){s=State{};return;}
    int id=(int)hv_int(me,C,"charID");if(s.character!=-1&&s.character!=id)s=State{};s.character=id;
    bool auto_now=automatic();
    bool entered=map!=s.map;
    if(entered){s.stage_empty=s.stage_next=0;s.stage_tries=0;s.map=map;}
    if(death(me,scr,map,auto_now,now)){s.was_auto=automatic();return;}
    if(hv_int(me,C,"hpNew")<=0)return;
    if(hv_bag_busy()){s.was_auto=auto_now;return;}
    if(on(HV_TRIAL)&&entered&&map==FIRST&&s.was_auto&&!auto_now){set_auto(true);auto_now=automatic();}
    if(auto_now&&party(me,now)){s.was_auto=automatic();return;}
    if(stage(me,map,now)){s.was_auto=automatic();return;}
    quest(me,scr,map,auto_now,now);
    if(on(HV_MOB)&&auto_now){void* old=hv_obj(me,C,"monsterFocus");if(old){void* task=hv_obj(scr,"MapScr","taskOrder");void* target=hv_features_target(old,task);if(target!=old)hv_set_obj(me,C,"monsterFocus",target);}}
    s.was_auto=automatic();
}
