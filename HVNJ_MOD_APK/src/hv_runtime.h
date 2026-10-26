#pragma once
#include <cstdint>
#include <cstddef>

enum HvFeature { HV_MOB, HV_DIE, HV_TRIAL, HV_STAGE, HV_QUEST, HV_TATHU,
                 HV_PARTY, HV_SELL, HV_STONE, HV_FEATURE_COUNT };
struct HvConfig {
    bool enabled[HV_FEATURE_COUNT]{};
    int stone_lo = 1;
    int stone_hi = 0;
    int accept_option = 0;
};
extern HvConfig hv_cfg;

// IL2CPP field access resolves actual class/field metadata, including base classes.
// obj == nullptr selects a static field. Missing fields return zero/false and log.
void* hv_class(const char* cls);
const char* hv_type_name(void* object);
bool hv_has_field(const char* cls, const char* field);
void* hv_obj(void* obj, const char* cls, const char* field);
int64_t hv_int(void* obj, const char* cls, const char* field);
float hv_float(void* obj, const char* cls, const char* field);
bool hv_bool(void* obj, const char* cls, const char* field);
bool hv_set_obj(void* obj, const char* cls, const char* field, void* value);
bool hv_set_int(void* obj, const char* cls, const char* field, int64_t value);
bool hv_set_float(void* obj, const char* cls, const char* field, float value);

// Values: pass &value in args. References: pass the managed object directly.
// Return is a managed object (boxed for primitive returns), null on exception.
void* hv_call(void* obj, const char* cls, const char* method, int argc = 0, void** args = nullptr);
bool hv_has_method(const char* cls, const char* method, int argc);
int64_t hv_unbox_int(void* boxed);
void* hv_new(const char* cls);
void* hv_new_field_object(const char* owner,const char* field);
uintptr_t hv_hold(void* object);
void* hv_held(uintptr_t handle);
void hv_release(uintptr_t handle);
void* hv_string(const char* utf8);
const char* hv_utf8(void* managed_string); // main-thread scratch; copy if retained
void* hv_new_array(const char* element_class, size_t count);
size_t hv_array_count(void* array);
void* hv_array_at(void* array, size_t index);
bool hv_array_set(void* array, size_t index, void* managed_reference);
int64_t hv_array_int(void* array, size_t index, int element_bytes);
bool hv_array_set_int(void* array,size_t index,int element_bytes,int64_t value);
size_t hv_list_count(void* list);
void* hv_list_at(void* list, size_t index);
void* hv_self();
void* hv_map_scr();
int hv_map_id();
uint64_t hv_now_ms();
void hv_log(const char* format, ...);
void hv_log_start_file(); // call inside a valid Unity main-thread callback
void hv_notice(const char* utf8);

// Bag and combat engines own their state. Runtime/UI owns config and persistence.
void hv_features_tick(uint64_t now);
void hv_features_reset(int feature);
void* hv_features_target(void* original, void* task);
void hv_bag_tick(uint64_t now);
void hv_bag_reset();
bool hv_bag_busy();
void hv_bag_preview();
const char* hv_bag_preview_line(size_t index); // null marks end; never transacts
void hv_service_open(int ui_type);
