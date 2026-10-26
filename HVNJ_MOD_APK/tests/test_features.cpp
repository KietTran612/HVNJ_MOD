#include "../src/hv_runtime.h"
#include <cassert>
#include <map>
#include <string>
#include <vector>
#include <cstdio>
#include <cstdlib>
#undef assert
#define assert(x) do { if(!(x)){std::fprintf(stderr,"FAIL line %d: %s\n",__LINE__,#x);std::exit(1);} } while(0)
struct O { std::map<std::string,void*> p; std::map<std::string,int64_t> n; std::map<std::string,float> f; std::vector<void*> a; };
HvConfig hv_cfg;
static O me,scr,svc,globals,automatic,mobs,tasks,party,links,popup,chars;
static int mapid, notices; static bool busy,missing;
struct Call { std::string name; std::vector<int64_t> args; };
static std::vector<Call> calls;
void* hv_obj(void* p,const char* c,const char* f){if(!p){if(std::string(c)=="AutomaticPopupG4M")p=&automatic;else p=&globals;}return ((O*)p)->p[f];}
int64_t hv_int(void* p,const char* c,const char* f){if(!p)p=std::string(c)=="AutomaticPopupG4M"?(void*)&automatic:(void*)&globals;return ((O*)p)->n[f];}
float hv_float(void*p,const char*,const char*f){return p?((O*)p)->f[f]:0;}
bool hv_bool(void*p,const char*c,const char*f){return hv_int(p,c,f)!=0;}
bool hv_set_obj(void*p,const char*,const char*f,void*v){if(!p)p=&globals;((O*)p)->p[f]=v;return true;}
bool hv_set_int(void*p,const char*c,const char*f,int64_t v){if(!p)p=std::string(c)=="AutomaticPopupG4M"?(void*)&automatic:(void*)&globals;((O*)p)->n[f]=v;return true;}
bool hv_has_field(const char*,const char*){return !missing;}bool hv_has_method(const char*,const char*,int){return !missing;}
void* hv_call(void*p,const char*c,const char*m,int argc,void**a){std::string n=m;if(n=="gI")return std::string(c)=="Service"?(void*)&svc:(void*)&popup;
 if(n=="getHP")return (void*)(intptr_t)((O*)p)->n["hpNew"];
 Call call{n,{}}; if(n=="setAuto"){automatic.n["isAuto"]=*(bool*)a[0];call.args.push_back(*(bool*)a[0]);}
 if(n=="clickTask"){call.args.push_back(*(int8_t*)a[0]);call.args.push_back((intptr_t)a[1]);}
 if(n=="findPathMap"||n=="menu"){for(int i=0;i<argc;++i)call.args.push_back(*(int*)a[i]);}
 calls.push_back(call);return nullptr;}
int64_t hv_unbox_int(void*p){return (intptr_t)p;}
size_t hv_array_count(void*p){return p?((O*)p)->a.size():0;}void*hv_array_at(void*p,size_t i){return p&&i<((O*)p)->a.size()?((O*)p)->a[i]:nullptr;} size_t hv_list_count(void*p){return p?((O*)p)->a.size():0;}void*hv_list_at(void*p,size_t i){return p&&i<((O*)p)->a.size()?((O*)p)->a[i]:nullptr;}
void*hv_self(){return &me;}void*hv_map_scr(){return &scr;}int hv_map_id(){return mapid;}bool hv_bag_busy(){return busy;}
void hv_notice(const char*){++notices;}void hv_log(const char*,...){}
static int count(const char*n){int r=0;for(auto&c:calls)r+=c.name==n;return r;}
static void setup(){hv_cfg={};me={};scr={};globals={};automatic={};mobs={};tasks={};party={};links={};popup={};chars={};calls.clear();mapid=10;notices=0;busy=false;missing=false;me.n["hpNew"]=100;automatic.n["isAuto"]=1;globals.p["listMob"]=&mobs;globals.p["taskOrders"]=&tasks;globals.p["listParty"]=&party;globals.p["vLink"]=&links;globals.p["listCharInMap"]=&chars;hv_features_reset(-1);}
int main(){
 setup();O boss;boss.n["hp"]=10;boss.n["status"]=2;boss.n["levelBoss"]=1;mobs.a={&boss};assert(hv_features_target(&boss,nullptr)==&boss);hv_cfg.enabled[HV_MOB]=true;assert(!hv_features_target(&boss,nullptr));
 O task;task.n["taskId"]=1;task.n["killId"]=7;task.n["maxCount"]=3;task.n["mapId"]=10;boss.n["templateId"]=7;assert(hv_features_target(&boss,&task)==&boss);task.n["count"]=3;assert(!hv_features_target(&boss,&task));
 setup();hv_cfg.enabled[HV_MOB]=true;missing=true;assert(hv_features_target(&boss,nullptr)==&boss);
 setup();hv_cfg.enabled[HV_DIE]=true;automatic.n["isGoBack"]=1;hv_features_tick(1000);me.n["hpNew"]=0;hv_features_tick(1100);assert(count("returnTownFromDead")==1);hv_features_tick(1200);assert(count("returnTownFromDead")==1);mapid=1;me.n["hpNew"]=100;hv_features_tick(4000);assert(count("findPathMap")==1);mapid=10;hv_features_tick(7000);assert(automatic.n["isAuto"]==1);
 setup();hv_cfg.enabled[HV_DIE]=true;automatic.n["isGoBack"]=1;hv_features_tick(1000);mapid=161;me.n["hpNew"]=0;hv_features_tick(2000);assert(count("returnTownFromDead")==0);
 setup();mapid=161;hv_cfg.enabled[HV_TRIAL]=true;hv_features_tick(1000);automatic.n["isAuto"]=0;hv_features_tick(2000);assert(automatic.n["isAuto"]==0);
 setup();mapid=160;hv_cfg.enabled[HV_TRIAL]=true;hv_features_tick(1000);mapid=161;automatic.n["isAuto"]=0;hv_features_tick(2000);assert(automatic.n["isAuto"]==1);
 setup();mapid=162;hv_cfg.enabled[HV_STAGE]=true;O gate;gate.n["idMapFrom"]=162;gate.n["idMapTo"]=163;gate.n["minX"]=100;gate.n["maxX"]=120;gate.n["minY"]=20;gate.n["maxY"]=40;links.a={&gate};hv_features_tick(1000);hv_features_tick(3499);assert(!count("moveAutoToTarget"));hv_features_tick(3500);assert(count("moveAutoToTarget")==1);
 setup();hv_cfg.enabled[HV_QUEST]=true;task.n["taskId"]=0;task.n["count"]=0;task.n["mapId"]=11;tasks.a={&task};busy=true;hv_features_tick(1000);assert(!count("clickTask"));busy=false;hv_features_tick(2000);assert(count("clickTask")==1);hv_features_tick(2100);assert(count("clickTask")==1);assert(calls.back().args[0]==2);
 setup();hv_cfg.enabled[HV_PARTY]=true;hv_cfg.enabled[HV_QUEST]=true;O leader,member;leader.n["charID"]=88;member.n["charId"]=88;leader.n["hpNew"]=100;member.p["c"]=&leader;party.a={&member};chars.a={&leader};tasks.a={&task};hv_features_tick(1000);assert(!count("clickTask"));assert(count("setMoveAutoToTarget")==1);calls.clear();chars.a.clear();hv_features_tick(4000);assert(!count("setMoveAutoToTarget"));
 setup();hv_cfg.enabled[HV_DIE]=true;automatic.n["isGoBack"]=1;hv_features_tick(1000);me.n["hpNew"]=0;for(int i=0;i<10;++i)hv_features_tick(2000+i*4000);assert(count("returnTownFromDead")==3);
 setup();hv_cfg.enabled[HV_QUEST]=true;task.n["taskId"]=0;task.n["mapId"]=11;tasks.a={&task};for(int i=0;i<8;++i)hv_features_tick(1000+i*4000);assert(count("clickTask")==5);automatic.n["isAuto"]=0;hv_features_tick(34000);automatic.n["isAuto"]=1;hv_features_tick(38000);assert(count("clickTask")==6);
 setup();hv_cfg.enabled[HV_QUEST]=true;me.n["classMainID"]=3;mapid=72;O teacher,templ,npcs,menus,options;teacher.p["template"]=&templ;templ.n["npcTemplateId"]=25;npcs.a={&teacher};globals.p["listNpc"]=&npcs;templ.p["menu"]=&menus;menus.a={&options,&options};options.a={(void*)1};hv_features_tick(1000);assert(count("menu")==1);assert(calls.back().args[0]==25&&calls.back().args[1]==0&&calls.back().args[2]==0);hv_features_tick(2000);assert(count("menu")==1);hv_features_tick(6000);hv_features_tick(11000);hv_features_tick(16000);hv_features_tick(21000);assert(count("menu")==3);
 setup();hv_cfg.enabled[HV_QUEST]=true;missing=true;me.n["classMainID"]=1;hv_features_tick(1000);assert(calls.empty());
 setup();hv_cfg.enabled[HV_DIE]=true;automatic.n["isGoBack"]=1;hv_features_tick(1000);me.n["hpNew"]=0;
 hv_features_tick(2000);hv_features_tick(5000);hv_features_tick(8000);hv_features_tick(92001);
 assert(count("returnTownFromDead")==3&&notices==1);
 for(int i=0;i<10;++i)hv_features_tick(95000+i*20000);
 assert(count("returnTownFromDead")==3&&notices==1);
 hv_features_reset(HV_DIE);hv_features_tick(300000);assert(count("returnTownFromDead")==4);
 puts("feature tests passed");
}
