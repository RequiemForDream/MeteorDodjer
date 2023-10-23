using UI;
using UnityEngine;

namespace Core
{
    public class UIContainer
    {
        public readonly MenuScreen MenuScreen;
        public readonly GameEndScreen GameEndScreen;
        public readonly Canvas Canvas;
        public readonly GameplayScreen GameplayScreen;

        public UIContainer(MenuScreen menuScreen, GameplayScreen gameplayScreen, GameEndScreen gameEndScreen, Canvas canvas)
        {
            MenuScreen = menuScreen;
            GameEndScreen = gameEndScreen;
            Canvas = canvas;
            GameplayScreen = gameplayScreen;
        }
    }
}
