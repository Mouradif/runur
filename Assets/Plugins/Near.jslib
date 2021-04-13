mergeInto(LibraryManager.library, {
  JSAlert: function (str) {
    window.alert(Pointer_stringify(str));
  },
});