using Character;
using Factories;
using Factories.Interfaces;
using Obstacles;
using Obstacles.Intefaces;
using UnityEngine;
using Utils;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private ObstacleConfig _obstacleConfig;
        [SerializeField] private ObstacleSpawnerConfig _spawnerConfig;
        [SerializeField] private Updater _updater;
        [SerializeField] private CameraFollower _cameraFollower;

        private void Awake()
        {
            InputService inputService = new InputService(_updater);

            IFactory<IObstacle> obstacleFactory = new ObstacleFactory(_updater, _obstacleConfig);

            IFactory<MainCharacter> mainCharacteFactory = new MainCharacterFactory(_characterConfig, _updater, inputService);
            MainCharacter mainCharacter = mainCharacteFactory.Create();

            ObstacleSpawner obstacleSpawner = new ObstacleSpawner(_updater, obstacleFactory, mainCharacter, _spawnerConfig);
            _cameraFollower.Initialize(mainCharacter.Transform);

            Level level = new Level(mainCharacter, inputService, _cameraFollower, obstacleSpawner);
            level.Start();
        }
    }
}

