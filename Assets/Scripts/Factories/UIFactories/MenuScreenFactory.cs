using Factories.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories.UI
{
    public class MenuScreenFactory : IFactory<MenuScreen>
    {
        private readonly MenuScreen _menuScreen;

        public MenuScreenFactory(MenuScreen menuScreen)
        {
            _menuScreen = menuScreen;
        }

        public MenuScreen Create()
        {
            var menuScreen = Object.Instantiate(_menuScreen);

            return menuScreen;
        }
    }
}
