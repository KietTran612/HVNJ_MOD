#pragma once
#include <atomic>
#include <cstdint>
class HvStartupGate {
public:
    // Discovery runs on a native worker: publishing ELF addresses is safe;
    // querying the managed domain here is not (Unity6 may still be starting).
    void discover(void* lib,uintptr_t base){lib_=lib;base_=base;image_ready_.store(true,std::memory_order_release);}
    // Only called from an original managed callback on the Unity main thread.
    template<class Init,class Install> bool on_managed(Init init,Install install){
        if(!image_ready_.load(std::memory_order_acquire))return false;
        if(attempted_)return runtime_ready_;
        attempted_=true;runtime_ready_=init(lib_);
        if(runtime_ready_)install(base_);
        return runtime_ready_;
    }
private:
    void* lib_=nullptr;uintptr_t base_=0;
    std::atomic<bool> image_ready_{false};
    bool attempted_=false,runtime_ready_=false;
};
