using Core.Interfaces;
using Factories.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories.UI
{
    public class GameplayScreenFactory : IFactory<GameplayScreen>
    {
        private readonly GameplayScreen _gameplayScreen;
        private readonly MultiplierCounter _multiplierCounter;
        private readonly IListenersHandler<IInitializable> _initializator;
        private readonly IListenersHandler<IClearable> _clearer;
        private readonly ScoreCounter _scoreCounter;
        private readonly GameplayScreenModel _gameplayScreenModel;

        public GameplayScreenFactory(GameplayScreen gameplayScreen, MultiplierCounter multiplierCounter,
            IListenersHandler<IInitializable> initializator, IListenersHandler<IClearable> clearer, ScoreCounter scoreCounter,
            GameplayScreenModel gameplayScreenModel)
        {
            _gameplayScreen = gameplayScreen;
            _multiplierCounter = multiplierCounter;
            _initializator = initializator;
            _clearer = clearer;
            _scoreCounter = scoreCounter;
            _gameplayScreenModel = gameplayScreenModel;
        }

        public GameplayScreen Create()
        {
            var gameplayScreen = Object.Instantiate(_gameplayScreen);
            gameplayScreen.Construct(_multiplierCounter, _initializator, _clearer, _scoreCounter, _gameplayScreenModel);

            return gameplayScreen;
        }
    }
}
