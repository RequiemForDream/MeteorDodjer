using UI;
using UnityEngine;

namespace Core
{
    public class UIContainer
    {
        public readonly MenuScreen MenuScreen;
        public readonly GameEndScreen GameEndScreen;
        public readonly SettingsScreen SettingsScreen;
        public readonly Canvas Canvas;
        public readonly GameplayScreen GameplayScreen;

        public UIContainer(MenuScreen menuScreen, GameplayScreen gameplayScreen, GameEndScreen gameEndScreen,
            SettingsScreen settingsScreen, Canvas canvas)
        {
            MenuScreen = menuScreen;
            GameEndScreen = gameEndScreen;
            SettingsScreen = settingsScreen;
            Canvas = canvas;
            GameplayScreen = gameplayScreen;
        }
    }
}
