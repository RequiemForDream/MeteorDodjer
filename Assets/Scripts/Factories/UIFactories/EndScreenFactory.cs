using Factories.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories.UI
{
    public class EndScreenFactory : IFactory<GameEndScreen>
    {
        private readonly GameEndScreen _gameEndScreen;
        private readonly ScoreCounter _scoreCounter;

        public EndScreenFactory(GameEndScreen gameEndScreen, ScoreCounter scoreCounter)
        {
            _gameEndScreen = gameEndScreen;
            _scoreCounter = scoreCounter;
        }

        public GameEndScreen Create()
        {
            var gameEndScreen = Object.Instantiate(_gameEndScreen);
            gameEndScreen.Construct(_scoreCounter);

            return gameEndScreen;
        }
    }
}
