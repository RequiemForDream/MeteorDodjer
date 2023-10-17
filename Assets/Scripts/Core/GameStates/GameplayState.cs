using Core;

namespace StateMachine
{
    public class GameplayState : State
    {
        private readonly SceneInitializator _initializator;
        private readonly SceneClearer _clearer;

        public GameplayState(SceneInitializator initializator, SceneClearer clearer)
        {
            _initializator = initializator;
            _clearer = clearer;
        }

        public override void Enter()
        {           
            _initializator.InitializeListeners();
        }

        public override void Exit()
        {
            _clearer.Clear();
        }
    }
}
