#include "../src/hv_runtime.h"
#include <cassert>
#include <map>
#include <string>
#include <vector>
#include <cstdio>
struct O {std::map<std::string,void*> p;std::map<std::string,int64_t> n;std::vector<void*> a;};
HvConfig hv_cfg; O me,bag,box,shop,opts,fullopts,templ,item,shopitem,svc,points,fees; bool automatic=true;std::vector<std::string> calls;
void* hv_obj(void* o,const char* c,const char* f){if(!o){if(std::string(c)=="ShopItemPopup")return shop.p[f];if(std::string(f)=="crystals")return &points;if(std::string(f)=="coinUpCrystals")return &fees;return nullptr;}return ((O*)o)->p[f];}
int64_t hv_int(void* o,const char*,const char* f){return o?((O*)o)->n[f]:0;}
bool hv_bool(void* o,const char* c,const char* f){return !o?automatic:hv_int(o,c,f)!=0;}
bool hv_has_field(const char*,const char*){return true;} bool hv_has_method(const char*,const char*,int){return true;}
void* hv_call(void* o,const char*,const char* m,int,void**){if(std::string(m)=="gI")return &svc;if(std::string(m)=="isHaveGem")return (void*)(intptr_t)(1+((O*)o)->n["gem"]);calls.push_back(m);return nullptr;}
int64_t hv_unbox_int(void* p){return (intptr_t)p-1;} size_t hv_array_count(void* p){return p?((O*)p)->a.size():0;}void* hv_array_at(void*p,size_t i){return p&&i<((O*)p)->a.size()?((O*)p)->a[i]:nullptr;}size_t hv_list_count(void*p){return hv_array_count(p);}void* hv_list_at(void*p,size_t i){return hv_array_at(p,i);}int64_t hv_array_int(void*p,size_t i,int){return (intptr_t)hv_array_at(p,i);}
void* hv_self(){return &me;} void* hv_new_array(const char*,size_t n){auto*p=new O;p->a.resize(n);return p;}bool hv_array_set(void*p,size_t i,void*v){((O*)p)->a[i]=v;return true;}bool hv_set_obj(void*p,const char*c,const char*f,void*v){if(!p){shop.p[f]=v;return true;}((O*)p)->p[f]=v;return true;} const char*hv_utf8(void*){return "item";}void hv_log(const char*,...){}void hv_notice(const char*){}uint64_t hv_now_ms(){return 0;}
void setup(){hv_bag_reset();hv_cfg={};me={};bag={};box={};shop={};item={};templ={};shopitem={};calls.clear();automatic=true;opts.a.resize(1);fullopts.a.resize(2);templ.n["id"]=100;templ.n["type"]=1;item.p["template"]=&templ;item.p["options"]=&opts;item.n["quantity"]=1;shopitem.p["template"]=&templ;shopitem.p["options"]=&fullopts;shop.a={&shopitem};shop.p["arrItemWeapon"]=&shop;bag.a={&item,nullptr};box.a={nullptr};me.p["listItemBag"]=&bag;me.p["listItemChest"]=&box;hv_cfg.enabled[HV_SELL]=true;}
int main(){setup();hv_bag_tick(1000);assert(calls.size()==1&&calls[0]=="sellItem");hv_bag_tick(2000);assert(calls.size()==1);bag.a[0]=nullptr;hv_bag_tick(2100);assert(!hv_bag_busy());
setup();item.n["isLock"]=1;hv_bag_tick(1000);assert(calls.empty());setup();item.n["upgrade"]=1;hv_bag_tick(1000);assert(calls.empty());setup();item.n["gem"]=1;hv_bag_tick(1000);assert(calls.empty());
setup();shopitem.p["options"]=nullptr;hv_cfg={};hv_bag_preview();hv_bag_tick(1000);assert(calls.size()==1&&calls[0]=="requestItemInfo");shopitem.p["options"]=&fullopts;hv_bag_tick(2000);for(auto&s:calls)assert(s!="sellItem"&&s!="itemBagToBox");
setup();item.p["options"]=&fullopts;hv_bag_tick(1000);assert(calls[0]=="itemBagToBox");
setup();hv_cfg={};hv_cfg.enabled[HV_STONE]=true;hv_cfg.stone_hi=2;O t0,t1,i0,i1;t0.n["id"]=0;t0.n["type"]=26;t1=t0;i0.p["template"]=&t0;i1.p["template"]=&t1;i0.n["quantity"]=i1.n["quantity"]=1;bag.a={&i0,&i1};points.a={(void*)1,(void*)2};fees.a={(void*)0,(void*)10};me.n["yen"]=9;hv_bag_tick(1000);assert(calls.empty());hv_bag_reset();me.n["yen"]=10;hv_bag_tick(1000);assert(calls.size()==1&&calls[0]=="crystalCollectLock");hv_bag_tick(2000);assert(calls.size()==1);
hv_bag_reset();calls.clear();points.a[1]=(void*)3;hv_bag_tick(1000);assert(calls.empty());
// A completed preview must neither restart with disabled flags nor poison later sell.
setup();hv_cfg={};hv_bag_preview();hv_bag_tick(1000);assert(!hv_bag_busy());
shopitem.p["options"]=nullptr;calls.clear();hv_bag_tick(40000);assert(calls.empty()&&!hv_bag_busy());
shopitem.p["options"]=&fullopts;hv_cfg.enabled[HV_SELL]=true;hv_bag_tick(41000);assert(calls.size()==1&&calls[0]=="sellItem");
// Cancellation by character death clears preview mode, including pending fetch state.
setup();hv_cfg={};shopitem.p["options"]=nullptr;hv_bag_preview();hv_bag_tick(1000);me.n["statusM"]=14;hv_bag_tick(2000);me.n["statusM"]=0;calls.clear();hv_bag_tick(40000);assert(calls.empty()&&!hv_bag_busy());shopitem.p["options"]=&fullopts;hv_cfg.enabled[HV_SELL]=true;hv_bag_tick(41000);assert(calls.size()==1&&calls[0]=="sellItem");
// A timed-out preview also relinquishes preview mode after its backoff.
setup();hv_cfg={};shopitem.p["options"]=nullptr;hv_bag_preview();hv_bag_tick(1000);hv_bag_tick(5000);calls.clear();hv_bag_tick(400000);assert(calls.empty()&&!hv_bag_busy());shopitem.p["options"]=&fullopts;hv_cfg.enabled[HV_SELL]=true;hv_bag_tick(401000);assert(calls.size()==1&&calls[0]=="sellItem");
puts("bag tests passed");}
