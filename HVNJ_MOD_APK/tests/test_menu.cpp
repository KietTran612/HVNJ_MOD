#include "../src/hv_runtime.h"
#include <cassert>
#include <map>
#include <string>
#include <vector>
#include <cstdio>
struct O{std::map<std::string,void*> p;std::map<std::string,int64_t> n;std::string text;std::vector<void*> refs;std::vector<int64_t> nums;};
HvConfig hv_cfg;O popup,left,icons,iconrow,me,sprites,names;O* sprite_array=&sprites;O* name_array=&names;O* shown=nullptr;int bad_fallback=0,saves=0;
void hv_menu_show();bool hv_menu_action(void*);void hv_menu_extend_main(void*,int);
void* hv_call(void* p,const char* cls,const char* method,int n,void** args){
 std::string m=method,c=cls?cls:"";
 if(m=="gI")return c=="MenuLeftG4M"?(void*)&left:(void*)&popup;
 if(m=="doMenuChar"){++bad_fallback;return nullptr;}
 if(m=="Add"){((O*)p)->refs.push_back(args[0]);return nullptr;}
 if(m=="startAt"&&n==5){shown=(O*)args[0];return nullptr;}
 if(m=="Save")++saves;
 return nullptr;
}
void* hv_obj(void* p,const char* cls,const char* f){if(!p&&std::string(cls)=="MenuLeftG4M"&&std::string(f)=="INDEX_ICON")return &icons;if(!p&&std::string(f)=="sprIconMenuLeft")return sprite_array;if(!p&&std::string(f)=="nameMenuLeft")return name_array;return p?((O*)p)->p[f]:nullptr;}
int64_t hv_int(void* p,const char*,const char* f){return p?((O*)p)->n[f]:0;}
bool hv_set_obj(void* p,const char*,const char* f,void* v){if(!p&&std::string(f)=="sprIconMenuLeft"){sprite_array=(O*)v;return true;}if(!p&&std::string(f)=="nameMenuLeft"){name_array=(O*)v;return true;}((O*)p)->p[f]=v;return true;}
bool hv_set_int(void* p,const char*,const char* f,int64_t v){((O*)p)->n[f]=v;return true;}
void* hv_new(const char*){return new O;}
void* hv_new_field_object(const char*,const char*){return new O;}
void* hv_clone_empty_list(void* example){return example?new O:nullptr;}
void* hv_string(const char* s){auto*o=new O;o->text=s;return o;}
const char* hv_utf8(void* p){return p?((O*)p)->text.c_str():"";}
size_t hv_list_count(void* p){return p?((O*)p)->refs.size():0;}
void* hv_list_at(void* p,size_t i){return p&&i<((O*)p)->refs.size()?((O*)p)->refs[i]:nullptr;}
size_t hv_array_count(void* p){if(!p)return 0;auto&o=*(O*)p;return o.refs.empty()?o.nums.size():o.refs.size();}
void* hv_array_at(void* p,size_t i){return hv_list_at(p,i);}
int64_t hv_array_int(void*p,size_t i,int){return p&&i<((O*)p)->nums.size()?((O*)p)->nums[i]:0;}
void* hv_new_array(const char* type,size_t n){auto*o=new O;if(std::string(type)=="System.SByte")o->nums.resize(n);else o->refs.resize(n);return o;}
bool hv_array_set(void*p,size_t i,void*v){if(i>=((O*)p)->refs.size())return false;((O*)p)->refs[i]=v;return true;}
bool hv_array_set_int(void*p,size_t i,int,int64_t v){if(i>=((O*)p)->nums.size())return false;((O*)p)->nums[i]=v;return true;}
void* hv_self(){return &me;}void* hv_map_scr(){return &me;}int hv_map_id(){return 160;}
int64_t hv_unbox_int(void*){return 0;}float hv_float(void*,const char*,const char*){return 0;}
void hv_log(const char*,...){}void hv_notice(const char*){}void hv_features_reset(int){}void hv_bag_reset(){}void hv_bag_preview(){}const char*hv_bag_preview_line(size_t){return nullptr;}void hv_service_open(int){}
int main(){
 // A fresh game has no prior character-context menu and no charFocus.
 hv_menu_show();assert(shown&&shown->refs.size()==15);assert(bad_fallback==0);
 void* first=shown->refs[0];assert(hv_menu_action(first)&&hv_cfg.enabled[0]);
 assert(hv_menu_action(shown->refs[0])&&!hv_cfg.enabled[0]);assert(saves==2);
 O main,old1,old2,old3,sprite;main.refs={&old1,&old2,&old3};icons.refs.resize(6);iconrow.nums={2,4,6};icons.refs[3]=&iconrow;
 sprites.refs.resize(8,&sprite);names.refs.resize(7,hv_string("Original"));
 auto original_sprites=sprites.refs,original_names=names.refs;
 hv_menu_extend_main(&main,3);assert(main.refs.size()==4);auto*row=(O*)icons.refs[3];assert(row->nums.size()>=4);assert(row->nums[0]==2&&row->nums[1]==4&&row->nums[2]==6);
 int custom=(int)row->nums[3];assert(custom==8);assert(sprite_array->refs[custom]==&sprite);assert(std::string(hv_utf8(name_array->refs[custom]))=="Mod HVNJ");
 for(size_t i=0;i<original_sprites.size();++i)assert(sprite_array->refs[i]==original_sprites[i]);
 for(size_t i=0;i<original_names.size();++i)assert(name_array->refs[i]==original_names[i]);
 hv_menu_extend_main(&main,3);assert(main.refs.size()==4);
 O main5,row5;main5.refs={&old1};row5.nums={4};icons.refs[5]=&row5;
 auto* saved_sprites=sprite_array;auto* saved_names=name_array;
 hv_menu_extend_main(&main5,5);assert(main5.refs.size()==2);assert(((O*)icons.refs[5])->nums[1]==custom);assert(sprite_array==saved_sprites&&name_array==saved_names);
 // Language/data reloads can replace static arrays: validate the cached index.
 name_array=&names;O reloaded;reloaded.refs={&old1};hv_menu_extend_main(&reloaded,5);
 assert(reloaded.refs.size()==2);int refreshed=(int)((O*)icons.refs[5])->nums[1];
 assert(refreshed==9&&std::string(hv_utf8(name_array->refs[refreshed]))=="Mod HVNJ");
 O full_sprites,full_names,overflow;full_sprites.refs.resize(128,&sprite);full_names.refs.resize(128,hv_string("Original"));
 sprite_array=&full_sprites;name_array=&full_names;overflow.refs={&old1};hv_menu_extend_main(&overflow,5);assert(overflow.refs.size()==1);
 assert(hv_menu_action(main.refs.back()));assert(shown&&shown->refs.size()==15);
 O other;other.refs={&old1};hv_menu_extend_main(&other,1);assert(other.refs.size()==1);
 puts("menu tests passed");
}
