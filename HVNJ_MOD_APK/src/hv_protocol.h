#pragma once
#include <cstdint>
struct HvProtocol {
    enum Phase { IDLE, ACK, DRAIN } phase=IDLE;
    uint64_t deadline=0, manual_until=0;
    int ui=0;
    bool start(int target, uint64_t now) {
        if((target!=4&&target!=10)||phase!=IDLE||now<manual_until)return false;
        ui=target;phase=ACK;deadline=now+5000;return true;
    }
    bool external(uint64_t now) {
        if(phase!=IDLE)return false;
        manual_until=now+5000;return true;
    }
    bool receive(int cmd,int /*panel*/,uint64_t /*now*/) {
        if(phase==DRAIN)return cmd==40||cmd==30;
        if(phase==ACK&&cmd==40){phase=IDLE;manual_until=0;return false;}
        if(phase==IDLE&&(cmd==40||cmd==30))manual_until=0;
        return false;
    }
    // Only wait for the native NPC menu. Option selection belongs to the user.
    bool tick(uint64_t now) {
        if(phase==DRAIN){if(now>=deadline)phase=IDLE;return false;}
        if(phase!=IDLE&&now>=deadline){phase=DRAIN;deadline=now+5000;return true;}
        return false;
    }
};
