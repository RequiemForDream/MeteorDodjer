using Character;
using Obstacles;
using StateMachine;
using Utils;

namespace Core
{
    public class Level
    {
        private readonly MainCharacter _character;
        private readonly InputService _inputService;
        private readonly CameraFollower _cameraFollower;
        private readonly ObstacleSpawner _obstacleSpawner;

        private GameStateMachine _gameStateMachine;

        public Level(MainCharacter character, InputService inputService, CameraFollower cameraFollower,
            ObstacleSpawner obstacleSpawner)
        {
            _character = character;
            _inputService = inputService;
            _cameraFollower = cameraFollower;
            _obstacleSpawner = obstacleSpawner;

            _gameStateMachine = new GameStateMachine();
            InitializeStates();
            _character.OnDied += SetEndState;
        }

        public void InitializeStates()
        {
            InitializeState initializeState = new InitializeState();
            GameplayState gameplayState = new GameplayState();
            GameEndState gameEndState = new GameEndState();

            _gameStateMachine.AddState<InitializeState>(initializeState);
            _gameStateMachine.AddState<GameplayState>(gameplayState);
            _gameStateMachine.AddState<GameEndState>(gameEndState);
        }

        private void SetInitializeState()
        {
            _gameStateMachine.ChangeState<InitializeState>();
        }

        private void SetEndState()
        {
            _gameStateMachine.ChangeState<GameEndState>();
        }

        public void Start()
        {
            _inputService.Initialize();
            _character.Initialize();
            //_cameraFollower.Initialize(_character.Transform);
            _obstacleSpawner.Initialize();
        }
    }
}
