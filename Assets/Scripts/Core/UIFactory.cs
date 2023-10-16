using Factories.Interfaces;
using Factories.UI;
using UI;
using UnityEngine;

namespace Core
{
    public class UIFactory
    {
        public readonly MenuScreen MenuScreen;
        public readonly GameEndScreen GameEndScreen;
        public readonly SettingsScreen SettingsScreen;
        public readonly Canvas Canvas;

        public UIFactory(UIConfig uiConfig)
        {
            IFactory<MenuScreen> menuFactory = new MenuScreenFactory(uiConfig.MenuScreen);
            MenuScreen = menuFactory.Create();

            IFactory<GameEndScreen> gameEndScreenFactory = new EndScreenFactory(uiConfig.GameEndScreen);
            GameEndScreen = gameEndScreenFactory.Create();

            IFactory<SettingsScreen> settingsScreenFactory = new SettingsScreenFactory(uiConfig.SettingScreen);
            SettingsScreen = settingsScreenFactory.Create();

            IFactory<Canvas> canvasFactory = new CanvasFactory(uiConfig.Canvas);
            Canvas = canvasFactory.Create();
        }
    }
}
