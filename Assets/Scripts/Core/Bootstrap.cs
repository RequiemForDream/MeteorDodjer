using Character;
using Character.Interfaces;
using Core.Interfaces;
using Factories;
using Factories.Interfaces;
using Obstacles;
using Obstacles.Intefaces;
using Sounds;
using System.Linq.Expressions;
using UI;
using UnityEngine;
using Utils;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Updater _updater;
        [SerializeField] private CameraFollower _cameraFollower;
        [SerializeField] private AudioSource _audioSource;

        [Header("Configurations")]
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private ObstacleConfig _obstacleConfig;
        [SerializeField] private ObstacleSpawnerConfig _spawnerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private UIConfig _uiConfig;
        [SerializeField] private SoundsConfig _soundConfig;

        private void Awake()
        {
            BindInitializator(out SceneInitializator initializator);
            BindClearer(out SceneClearer clearer);
            BindUIFactory(out UIFactory uiFactory);
            BindInputService(out InputService inputService, initializator, clearer);
            BindObstacleFactory(out IFactory<IObstacle> obstacleFactory);
            BindCharacterFactory(out ICharacter character, inputService, initializator,clearer);
            BindObstacleSpawner(out IObstacleSpawner obstacleSpawner, obstacleFactory, initializator, clearer, character);
            BindCameraFollower(character);
            BindSoundFactory(out SoundFactory soundFactory, inputService);
            BindLevel(out Level level, initializator, clearer, uiFactory, character);

            level.Start();
        }
        
        private void BindInitializator(out SceneInitializator initializator)
        {
            initializator = new SceneInitializator();
        }

        private void BindClearer(out SceneClearer clearer)
        {
            clearer = new SceneClearer();
        }

        private void BindUIFactory(out UIFactory uiFactory)
        {
            uiFactory = new UIFactory(_uiConfig);
        }

        private void BindInputService(out InputService inputService, SceneInitializator initializator, SceneClearer clearer)
        {
            inputService = new InputService(_updater, initializator, clearer);
        }

        private void BindObstacleFactory(out IFactory<IObstacle> obstacleFactory)
        {
            obstacleFactory = new ObstacleFactory(_updater, _obstacleConfig);
        }

        private void BindCharacterFactory(out ICharacter character, IInputService inputService,
            SceneInitializator initializator, SceneClearer clearer)
        {
            IFactory<ICharacter> characterFactory = new MainCharacterFactory(_characterConfig, _updater, inputService, initializator,
                clearer);
            character = characterFactory.Create();
        }

        private void BindObstacleSpawner(out IObstacleSpawner obstacleSpawner, IFactory<IObstacle> obstacleFactory,
            SceneInitializator initializator, SceneClearer clearer, ICharacter character)
        {
            obstacleSpawner = new ObstacleSpawner(_updater, obstacleFactory, _spawnerConfig, initializator, clearer,
                character);
        }

        private void BindCameraFollower(ICharacter character)
        {
            _cameraFollower.Initialize(_cameraConfig.CameraModel, character.Transform);
        }

        private void BindLevel(out Level level, SceneInitializator initializator, SceneClearer clearer, UIFactory uiFactory,
            ICharacter character)
        {
            level = new Level(uiFactory, initializator, clearer, character);
        }

        private void BindSoundFactory(out SoundFactory soundFactory, IInputService inputService)
        {
            soundFactory = new SoundFactory(inputService, _soundConfig, _audioSource);
        }
    }
}

