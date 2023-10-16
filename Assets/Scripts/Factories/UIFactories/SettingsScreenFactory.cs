using Factories.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories.UI
{
    public class SettingsScreenFactory : IFactory<SettingsScreen>
    {
        private readonly SettingsScreen _settingScreen;

        public SettingsScreenFactory(SettingsScreen settingsScreen)
        {
            _settingScreen = settingsScreen;
        }

        public SettingsScreen Create()
        {
            var settingsScreen = Object.Instantiate(_settingScreen);

            return settingsScreen;
        }
    }
}
