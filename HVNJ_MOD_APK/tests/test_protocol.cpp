#include "../src/hv_protocol.h"
#include <cassert>
#include <cstdio>
int main(){
    HvProtocol p;
    assert(!p.start(99,100));
    assert(p.start(4,100));
    assert(!p.external(110)); // manual NPC request cannot interleave
    assert(!p.start(10,120));
    assert(!p.receive(30,4,130)); // wrong order cannot finish request
    assert(!p.receive(40,-1,200)); // original client must render NPC options
    assert(p.phase==HvProtocol::IDLE);
    assert(!p.tick(210)); assert(p.phase==HvProtocol::IDLE); // no automatic menu packet
    assert(p.external(220)); // user may select any native option immediately
    assert(!p.receive(30,4,230)); assert(p.phase==HvProtocol::IDLE);
    assert(p.external(240)); assert(!p.start(10,250)); // reverse ordering
    p.receive(40,-1,260); assert(p.start(10,270));
    assert(p.tick(5270)); assert(p.phase==HvProtocol::DRAIN);
    assert(!p.start(4,5280)); assert(!p.external(5280));
    assert(p.receive(40,-1,5290)); assert(p.receive(30,10,5290));
    assert(!p.tick(10270)); assert(p.start(4,10280));
    puts("protocol tests passed");
}
