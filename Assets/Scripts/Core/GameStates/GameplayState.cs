using Core;
using UI;

namespace StateMachine
{
    public class GameplayState : State
    {
        private readonly SceneInitializator _initializator;
        private readonly SceneClearer _clearer;
        private readonly GameplayScreen _gameplayScreen;

        public GameplayState(SceneInitializator initializator, SceneClearer clearer, GameplayScreen gameplayScreen)
        {
            _gameplayScreen = gameplayScreen;
            _initializator = initializator;
            _clearer = clearer;
        }

        public override void Enter()
        {           
            _initializator.InitializeListeners();
            _gameplayScreen.Show();
        }

        public override void Exit()
        {
            _clearer.Clear();
            _gameplayScreen.Hide();
        }
    }
}
