mergeInto(LibraryManager.library, {
  OnGameStartScreen: function () {
    if (typeof window.OnGameStartScreen === "function") {
      window.OnGameStartScreen();
    }
  },

  GameplayStart: function () {
    if (typeof window.GameplayStart === "function") {
      window.GameplayStart();
    }
  },

  GameplayStop: function () {
    if (typeof window.GameplayStop === "function") {
      window.GameplayStop();
    }
  },

  ShowAd: function () {
    if (typeof window.ShowAd === "function") {
      window.ShowAd();
    }
  },
});