#include "hv_runtime.h"
#include <cstdio>
#include <cstring>
#include <string>

void* hv_clone_empty_list(void*);
namespace {
constexpr int BASE=0x48560000;
bool building=false, loaded=false;
const char* labels[]={"Né Boss / Tinh Anh / Thủ Lĩnh khi Auto","Chết: về làng, quay lại map, bật Auto",
"Giữ Auto trong Thí Luyện","Tự qua ải Thí Luyện","Auto nhiệm vụ hàng ngày","Auto nhiệm vụ tà thú",
"Đánh theo trưởng nhóm","Bán đồ thiếu dòng / cất đồ đủ dòng","Luyện đá khi đầy (chỉ dùng yên)"};
void* menu(){return hv_call(nullptr,"MenuG4M","gI");}
void add(void* list,const char* text,int id){
    void* command=hv_new("CommandGame");if(!command)return;
    hv_set_obj(command,"CommandGame","caption",hv_string(text));
    hv_set_int(command,"CommandGame","idAction",id);
    void* args[]={command};hv_call(list,nullptr,"Add",1,args);
}
void present(void* list){
    int pos=0;bool no=false;void* args[]={list,&pos,&no,&no,&no};
    hv_call(menu(),"MenuG4M","startAt",5,args);
}
void save(){
    char b[64];for(int i=0;i<HV_FEATURE_COUNT;++i)b[i]=hv_cfg.enabled[i]?'1':'0';
    std::snprintf(b+9,sizeof(b)-9,":%d:%d:%d",hv_cfg.stone_lo,hv_cfg.stone_hi,hv_cfg.accept_option);
    void* args[]={hv_string("HVNJ_MOD_ANDROID_V1"),hv_string(b)};
    hv_call(nullptr,"UnityEngine.PlayerPrefs","SetString",2,args);
    hv_call(nullptr,"UnityEngine.PlayerPrefs","Save");
}
void* fresh_list(){
    void* m=menu();if(!m)return nullptr;void* example=hv_obj(m,"MenuG4M","listMenu");
    if(!example){building=true;hv_call(hv_map_scr(),"MapScr","doMenuChar");building=false;example=hv_obj(m,"MenuG4M","listMenu");}
    void* list=hv_clone_empty_list(example);
    if(list)hv_set_obj(m,"MenuG4M","listMenu",list); // strong managed root while building
    return list;
}
void show_preview(){
    void* list=fresh_list();if(!list)return;
    add(list,"Xem trước (bấm dòng bất kỳ để làm mới)",BASE+14);
    int total=0;
    for(size_t i=0;i<24;++i){const char* line=hv_bag_preview_line(i);if(!line)break;add(list,line,BASE+14);++total;}
    if(!total)add(list,"Không có trang bị phù hợp trong hành trang",BASE+14);
    add(list,"Quay lại",BASE);add(list,"Đóng",BASE+13);present(list);
}
}
void hv_menu_load(){
    if(loaded)return;loaded=true;
    void* args[]={hv_string("HVNJ_MOD_ANDROID_V1"),hv_string("")};
    std::string s=hv_utf8(hv_call(nullptr,"UnityEngine.PlayerPrefs","GetString",2,args));
    if(s.size()<15||s[9]!=':')return;
    for(int i=0;i<9;++i)if(s[i]!='0'&&s[i]!='1')return;
    int lo=0,hi=0,accept=0;
    if(std::sscanf(s.c_str()+9,":%d:%d:%d",&lo,&hi,&accept)!=3||lo<1||lo>11||hi<0||hi>12||accept<0||accept>3||(hi&&lo>=hi))return;
    for(int i=0;i<9;++i)hv_cfg.enabled[i]=s[i]=='1';
    hv_cfg.stone_lo=lo;hv_cfg.stone_hi=hi;hv_cfg.accept_option=accept;
}
void hv_menu_show(){
    hv_log("MENU open Mod HVNJ map=%d",hv_map_id());
    void* list=fresh_list();if(!list)return;
    char b[192];
    for(int i=0;i<9;++i){std::snprintf(b,sizeof(b),"[%s] %s",hv_cfg.enabled[i]?"x":" ",labels[i]);add(list,b,BASE+1+i);}
    add(list,"Xem trước trang bị sẽ bán / cất",BASE+14);
    if(hv_cfg.stone_hi)std::snprintf(b,sizeof(b),"Luyện đá đến cấp %d (cất vào rương)",hv_cfg.stone_hi);
    else std::snprintf(b,sizeof(b),"Luyện đá: mọi cấp, không cất rương");
    add(list,b,BASE+10);
    if(hv_cfg.stone_hi){std::snprintf(b,sizeof(b),"Luyện đá từ cấp %d",hv_cfg.stone_lo);add(list,b,BASE+11);}
    std::snprintf(b,sizeof(b),"Option nhận nhiệm vụ: %d",hv_cfg.accept_option);add(list,b,BASE+12);
    add(list,"Mở rương đồ",BASE+15);add(list,"Mở nâng cấp trang bị",BASE+16);add(list,"Đóng",BASE+13);present(list);
}
void hv_menu_append(){
    if(building)return;void* list=hv_obj(menu(),"MenuG4M","listMenu");if(!list)return;
    for(size_t i=0;i<hv_list_count(list);++i)if(hv_int(hv_list_at(list,i),"CommandGame","idAction")==BASE)return;
    add(list,"Mod HVNJ",BASE);present(list);
}
bool hv_menu_action(void* command){
    int id=static_cast<int>(hv_int(command,"CommandGame","idAction"))-BASE;
    if(id<0||id>16)return false;
    hv_log("MENU action=%d map=%d",id,hv_map_id());
    hv_call(menu(),"MenuG4M","closeM");
    if(id>=1&&id<=9){int f=id-1;hv_cfg.enabled[f]=!hv_cfg.enabled[f];hv_features_reset(f);if(f==HV_SELL||f==HV_STONE)hv_bag_reset();save();}
    else if(id==10){hv_cfg.stone_hi=hv_cfg.stone_hi?hv_cfg.stone_hi+1:2;if(hv_cfg.stone_hi>12)hv_cfg.stone_hi=0;if(hv_cfg.stone_hi&&hv_cfg.stone_lo>=hv_cfg.stone_hi)hv_cfg.stone_lo=1;hv_bag_reset();save();}
    else if(id==11){if(hv_cfg.stone_hi){++hv_cfg.stone_lo;if(hv_cfg.stone_lo>=hv_cfg.stone_hi)hv_cfg.stone_lo=1;}hv_bag_reset();save();}
    else if(id==12){hv_cfg.accept_option=(hv_cfg.accept_option+1)%4;hv_features_reset(HV_QUEST);hv_features_reset(HV_TATHU);save();}
    else if(id==13)return true;
    else if(id==14){hv_bag_preview();show_preview();return true;}
    else if(id==15||id==16){hv_service_open(id==15?4:10);return true;}
    unsigned flags=0;for(int i=0;i<9;++i)if(hv_cfg.enabled[i])flags|=1u<<i;
    hv_log("CONFIG flags=%03x stone=%d..%d npc_option=%d",flags,hv_cfg.stone_lo,hv_cfg.stone_hi,hv_cfg.accept_option);
    hv_menu_show();return true;
}

// Touch-friendly overlay shortcuts, drawn inside Main.OnGUI's valid GUI context.
// GUI.Button(Rect, GUIContent) is the only two-argument Button retained in APK185.
void hv_menu_gui(){
    void* screen=hv_obj(nullptr,"GameCanvas","currentScr");
    if(!screen||screen!=hv_obj(nullptr,"MapScr","instance")||!hv_self())return;
    int width=static_cast<int>(hv_unbox_int(hv_call(nullptr,"UnityEngine.Screen","get_width")));
    if(width<200)return;
    float scale=width/1280.0f;if(scale<0.75f)scale=0.75f;if(scale>2.5f)scale=2.5f;
    const char* names[]={"Mod HVNJ","Rương","Nâng cấp"};
    for(int i=0;i<3;++i){
        struct Rect{float x,y,w,h;} r{width-(330.0f-i*110)*scale,74.0f*scale,106.0f*scale,45.0f*scale};
        void* content=hv_new("UnityEngine.GUIContent");if(!content)continue;
        void* t=hv_string(names[i]);void* ta[]={t};hv_call(content,"UnityEngine.GUIContent","set_text",1,ta);
        void* args[]={&r,content};
        if(hv_unbox_int(hv_call(nullptr,"UnityEngine.GUI","Button",2,args))){
            if(i==0)hv_menu_show();else hv_service_open(i==1?4:10);
        }
    }
}
