mergeInto(LibraryManager.library, {
  UnityEvent: function(message) {
    if (window.unityEvent) {
      window.unityEvent(UTF8ToString(message));
    } else {
      console.warn('unityEvent function is not defined');
    }
  }
});
