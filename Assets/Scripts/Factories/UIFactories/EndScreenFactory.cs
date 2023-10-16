using Factories.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories.UI
{
    public class EndScreenFactory : IFactory<GameEndScreen>
    {
        private readonly GameEndScreen _gameEndScreen;

        public EndScreenFactory(GameEndScreen gameEndScreen)
        {
            _gameEndScreen = gameEndScreen;
        }

        public GameEndScreen Create()
        {
            var gameEndScreen = Object.Instantiate(_gameEndScreen);

            return gameEndScreen;
        }
    }
}
