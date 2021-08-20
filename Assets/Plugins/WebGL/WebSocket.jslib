mergeInto(LibraryManager.library, {
  Hello: function () {
    window.alert('Hello world!');
  },
  SendPacket: function(str) {
    ReactUnityWebGL.SendPacket(str);
  }
});