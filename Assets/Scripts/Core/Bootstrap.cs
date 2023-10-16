using Character;
using Character.Interfaces;
using Core.Interfaces;
using Factories;
using Factories.Interfaces;
using Factories.UI;
using Obstacles;
using Obstacles.Intefaces;
using UI;
using UnityEngine;
using Utils;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Updater _updater;
        [SerializeField] private CameraFollower _cameraFollower;

        [Header("Configurations")]
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private ObstacleConfig _obstacleConfig;
        [SerializeField] private ObstacleSpawnerConfig _spawnerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private UIConfig _uiConfig;

        private void Awake()
        {
            Initializator initializator = new Initializator();
            Clearer clearer = new Clearer();
            UIFactory uIFactory = new UIFactory(_uiConfig);

            InputService inputService = new InputService(_updater);

            IFactory<IObstacle> obstacleFactory = new ObstacleFactory(_updater, _obstacleConfig);

            IFactory<ICharacter> mainCharacteFactory = new MainCharacterFactory(_characterConfig, _updater, inputService);
            ICharacter mainCharacter = mainCharacteFactory.Create();

            ObstacleSpawner obstacleSpawner = new ObstacleSpawner(_updater, obstacleFactory, mainCharacter, _spawnerConfig, initializator,
                clearer);
            _cameraFollower.Initialize(mainCharacter.Transform, _cameraConfig.CameraModel);

            IClearable[] clearables = new IClearable[] { mainCharacter, obstacleSpawner };
            IInitializable[] initializables = new IInitializable[] {mainCharacter, obstacleSpawner, inputService }; 
            Level level = new Level(mainCharacter, initializables, clearables, uIFactory, mainCharacteFactory);
        }
    }
}

