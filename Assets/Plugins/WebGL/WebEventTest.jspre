Module['WebGLTest'].OnTest = function() {
    this.OnTest = Module.cwrap('OnTest', null, ['string']);
}
// Module.cwrap("name", return, [...args]