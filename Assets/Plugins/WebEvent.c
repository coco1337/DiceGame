#include "emscripten.h"

typedef void (*TestIt)(const char* ptr);

TestIt OnTestRef;

void SetEvents(TestIt _OnTest) {
  OnTestRef = _OnTest;
}

void EMSCRIPTEN_KEEPALIVE OnTest(const char* str){
  OnTestRef(str);
}