using Character;
using Obstacles;
using Utils;

namespace Core
{
    public class Level
    {
        private readonly MainCharacter _character;
        private readonly InputService _inputService;
        private readonly CameraFollower _cameraFollower;
        private readonly ObstacleSpawner _obstacleSpawner;

        public Level(MainCharacter character, InputService inputService, CameraFollower cameraFollower,
            ObstacleSpawner obstacleSpawner)
        {
            _character = character;
            _inputService = inputService;
            _cameraFollower = cameraFollower;
            _obstacleSpawner = obstacleSpawner;
        }

        public void Start()
        {
            _inputService.Initialize();
            _character.Initialize();
            _cameraFollower.Initialize(_character.CharacterView.transform);
            _obstacleSpawner.Initialize();
        }
    }
}
