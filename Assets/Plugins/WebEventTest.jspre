const testMethod = Module.cwrap("OnTest", null, ["string"]);
testMethod("asdfasdf");

// Module.cwrap("name", return, [...args]