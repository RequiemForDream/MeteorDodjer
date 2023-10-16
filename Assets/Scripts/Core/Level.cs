using Character;
using Character.Interfaces;
using Core.Interfaces;
using Factories.Interfaces;
using Obstacles;
using StateMachine;

namespace Core
{
    public class Level
    {
        private readonly ICharacter _character;
        private readonly InputService _inputService;
        private readonly ObstacleSpawner _obstacleSpawner;
        private readonly UIFactory _uiFactory;
        private readonly IInitializable[] _initializables;
        private readonly IClearable[] _clearables;
        private readonly IFactory<ICharacter> _characterFactory;

        private GameStateMachine _gameStateMachine;

        public Level(ICharacter character, IInitializable[] initializables, IClearable[] clearables, UIFactory uiFactory,
            IFactory<ICharacter> characterFactory)
        {
            //_character = character;
            //_inputService = inputService;
            //_obstacleSpawner = obstacleSpawner;
            _initializables = initializables;
            _clearables = clearables;
            _uiFactory = uiFactory;
            _characterFactory = characterFactory;

            _gameStateMachine = new GameStateMachine();
            InitializeStates();
            character.OnDied += SetEndState;
        }

        public void InitializeStates()
        {
            //IInitializable[] initializables = new IInitializable[] {_character, _inputService, _obstacleSpawner};
            InitializeState initializeState = new InitializeState(_initializables);
            GameplayState gameplayState = new GameplayState();
            GameEndState gameEndState = new GameEndState(_clearables, _uiFactory.GameEndScreen);
            InitializeUIState initializeUIState = new InitializeUIState(_uiFactory);

            _gameStateMachine.AddState<InitializeState>(initializeState);
            _gameStateMachine.AddState<GameplayState>(gameplayState);
            _gameStateMachine.AddState<GameEndState>(gameEndState);
            _gameStateMachine.AddState<InitializeUIState>(initializeUIState);

            SetInitializeState();
        }

        private void SetInitializeState()
        {
            _gameStateMachine.ChangeState<InitializeUIState>();
        }

        private void SetEndState()
        {
            _gameStateMachine.ChangeState<GameEndState>();
        }
    }
}
