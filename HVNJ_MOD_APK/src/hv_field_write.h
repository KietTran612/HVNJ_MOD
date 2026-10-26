#pragma once

// APK185 Field::SetValueRaw takes object references directly, but primitive
// arguments point to storage. Keep these two API conventions explicit.
struct HvFieldWrite {
    void* argument;
    static HvFieldWrite reference(void* object) { return {object}; }
    template<class T> static HvFieldWrite primitive(T& value) { return {&value}; }
};
