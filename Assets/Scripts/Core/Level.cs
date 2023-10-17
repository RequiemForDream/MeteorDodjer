using Character.Interfaces;
using StateMachine;

namespace Core
{
    public class Level
    {
        private readonly UIFactory _uiFactory;
        private readonly SceneInitializator _initializator;
        private readonly SceneClearer _clearer;
        private readonly ICharacter _character;

        private GameStateMachine _gameStateMachine;

        public Level(UIFactory uiFactory,
            SceneInitializator initializator, SceneClearer clearer, ICharacter character)
        {          
            _uiFactory = uiFactory;
            _initializator = initializator;
            _clearer = clearer;
            _character = character;


        }

        public void Start()
        {
            _gameStateMachine = new GameStateMachine();
            InitializeStates();
            SubscribeStates();
        }

        private void InitializeStates()
        {
            GameplayState initializeState = new GameplayState(_initializator, _clearer);
            GameEndState gameEndState = new GameEndState(_uiFactory.GameEndScreen);
            StartState initializeUIState = new StartState(_uiFactory);

            _gameStateMachine.AddState<GameplayState>(initializeState);
            _gameStateMachine.AddState<GameEndState>(gameEndState);
            _gameStateMachine.AddState<StartState>(initializeUIState);
            
            SetInitializeState();
        }

        private void SubscribeStates()
        {
            _uiFactory.MenuScreen.OnGameStartPressed += SetGameplayState;
            _uiFactory.GameEndScreen.OnRestartButtonPressed += SetGameplayState;
            _character.OnDied += SetEndGameState;
        }

        private void SetInitializeState()
        {
            _gameStateMachine.ChangeState<StartState>();
        }

        private void SetGameplayState()
        {
            _gameStateMachine.ChangeState<GameplayState>();
        }

        private void SetEndGameState()
        {
            _gameStateMachine.ChangeState<GameEndState>();
        }
    }
}
