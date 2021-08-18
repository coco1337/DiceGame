mergeInto(LibraryManager.library, {
  Hello: function () {
    window.alert('Hello world!');
    Module.cwarp("OnTest", null, ['Test']);
  }
});