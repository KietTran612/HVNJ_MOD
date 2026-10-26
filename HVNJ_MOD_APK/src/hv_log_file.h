#pragma once
#include <cstdio>
#include <cstring>
#include <string>

// Caller serializes writes. Only these two application-owned log files rotate.
class HvLogFile {
public:
    explicit HvLogFile(size_t limit=1024*1024):limit_(limit){}
    ~HvLogFile(){if(file_)std::fclose(file_);}
    bool open(const std::string& path){
        if(file_)return false;
        file_=std::fopen(path.c_str(),"ab");if(!file_)return false;
        path_=path;std::fseek(file_,0,SEEK_END);long n=std::ftell(file_);
        size_=n>0?static_cast<size_t>(n):0;return true;
    }
    bool write(const char* text){
        if(!file_||!text)return false;
        size_t n=std::strlen(text);if(n+1>limit_)return false;
        if(size_+n+1>limit_){
            std::fclose(file_);file_=nullptr;
            std::string previous=path_+".previous";
            std::remove(previous.c_str());
            if(std::rename(path_.c_str(),previous.c_str())!=0){file_=std::fopen(path_.c_str(),"ab");return false;}
            file_=std::fopen(path_.c_str(),"wb");size_=0;if(!file_)return false;
        }
        bool ok=std::fwrite(text,1,n,file_)==n&&std::fputc('\n',file_)!=EOF;
        if(std::fflush(file_)!=0)ok=false;
        size_+=n+1;return ok;
    }
private:
    FILE* file_=nullptr;
    std::string path_;
    size_t limit_,size_=0;
};
