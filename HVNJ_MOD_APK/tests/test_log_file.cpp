#include "../src/hv_log_file.h"
#include <cassert>
#include <fstream>
#include <iterator>
#include <string>
std::string read(const char* p){std::ifstream f(p);return {std::istreambuf_iterator<char>(f),{}};}
int main(){
    const char* path="HVNJ_MOD_APK/build/test diagnostic.log";
    std::remove(path);std::remove("HVNJ_MOD_APK/build/test diagnostic.log.previous");
    {HvLogFile log(32);assert(log.open(path));assert(log.write("BOOT apk185"));assert(read(path)=="BOOT apk185\n");assert(log.write("NPC cmd40 received"));assert(log.write("NPC cmd30 UI4"));}
    assert(read("HVNJ_MOD_APK/build/test diagnostic.log.previous")=="BOOT apk185\nNPC cmd40 received\n");
    assert(read(path)=="NPC cmd30 UI4\n");
    {HvLogFile log(32);assert(log.open(path));assert(log.write("REOPEN"));assert(!log.write("a line longer than the configured file limit"));}
    assert(read(path)=="NPC cmd30 UI4\nREOPEN\n");
    {HvLogFile bad;assert(!bad.open("HVNJ_MOD_APK/build/missing-directory/log"));assert(!bad.write("ignored"));}
    puts("log file tests passed");
}
