using Character;
using Character.Interfaces;
using Core.Interfaces;
using Factories;
using Factories.Interfaces;
using Factories.UI;
using Obstacles;
using Obstacles.Intefaces;
using Sounds;
using Sounds.Interfaces;
using UI;
using UI.Interfaces;
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
            BindMultiplierCounter(out MultiplierCounter multiplierCounter);
            BindScoreCounter(out ScoreCounter scoreCounter, multiplierCounter);
            BindGameplayScreen(out GameplayScreen gameplayScreen, multiplierCounter, initializator, clearer, scoreCounter,
                _uiConfig.MultiplierTime);
            BindMenuScreen(out MenuScreen menuScreen);
            BindGameEndScreen(out GameEndScreen gameEndScreen);
            BindSettingsScreen(out SettingsScreen settingsScreen);
            BindCanvas(out Canvas canvas);
            BindUIContainer(out UIContainer uiFactory, menuScreen, gameEndScreen, gameplayScreen, canvas, settingsScreen);
            BindSoundFactory(out ISoundFactory soundFactory);
            BindInputService(out InputService inputService, initializator, clearer);
            BindObstacleFactory(out IFactory<IObstacle> obstacleFactory, soundFactory, multiplierCounter);
            BindCharacterFactory(out ICharacter character, inputService, soundFactory, initializator, clearer, scoreCounter);
            BindObstacleSpawner(out IObstacleSpawner obstacleSpawner, obstacleFactory, initializator, clearer, character);
            BindCameraFollower(character);
            BindLevel(out Level level, initializator, clearer, uiFactory, character);

            level.Start();
        }
        
        private void BindInitializator(out SceneInitializator initializator)
        {
            initializator = new SceneInitializator();
        }

        private void BindMultiplierCounter(out MultiplierCounter multiplierCounter)
        {
            multiplierCounter = new MultiplierCounter();
        }

        private void BindScoreCounter(out ScoreCounter scoreCounter, MultiplierCounter multiplierCounter)
        {
            scoreCounter = new ScoreCounter(multiplierCounter);
        }

        private void BindClearer(out SceneClearer clearer)
        {
            clearer = new SceneClearer();
        }

        private void BindUIContainer(out UIContainer uiContainer, MenuScreen menuScreen, GameEndScreen gameEndScreen,
            GameplayScreen gameplayScreen, Canvas canvas, SettingsScreen settingsScreen)
        {
            uiContainer = new UIContainer(menuScreen, gameplayScreen, gameEndScreen, settingsScreen, canvas);
        }

        private void BindInputService(out InputService inputService, SceneInitializator initializator, SceneClearer clearer)
        {
            inputService = new InputService(_updater, initializator, clearer);
        }

        private void BindObstacleFactory(out IFactory<IObstacle> obstacleFactory, ISoundFactory soundFactory,
            ICounter<int> multiplierCounter)
        {
            obstacleFactory = new ObstacleFactory(_updater, _obstacleConfig, soundFactory, multiplierCounter);
        }

        private void BindCharacterFactory(out ICharacter character, IInputService inputService, ISoundFactory soundFactory,
            SceneInitializator initializator, SceneClearer clearer, ICounter<float> scoreCounter)
        {
            IFactory<ICharacter> characterFactory = new MainCharacterFactory(_characterConfig, _updater, inputService, initializator,
                clearer, soundFactory, scoreCounter);
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
            _cameraFollower.Construct(_cameraConfig.CameraModel, character.Transform);
        }

        private void BindLevel(out Level level, SceneInitializator initializator, SceneClearer clearer, UIContainer uiFactory,
            ICharacter character)
        {
            level = new Level(uiFactory, initializator, clearer, character);
        }

        private void BindSoundFactory(out ISoundFactory soundFactory)
        {
            soundFactory = new SoundFactory( _soundConfig, _audioSource);
        }

        private void BindGameplayScreen(out GameplayScreen gameplayScreen, MultiplierCounter multiplierCounter,
            SceneInitializator sceneInitializator, SceneClearer sceneClearer, ScoreCounter scoreCounter, float multiplierTime)
        {
            IFactory<GameplayScreen> gameplayScreenFactory = new GameplayScreenFactory(_uiConfig.GamePlayScreen, multiplierCounter,
                sceneInitializator, sceneClearer, scoreCounter, multiplierTime);
            gameplayScreen = gameplayScreenFactory.Create();
        }

        private void BindMenuScreen(out MenuScreen menuScreen)
        {
            IFactory<MenuScreen> menuFactory = new MenuScreenFactory(_uiConfig.MenuScreen);
            menuScreen = menuFactory.Create();
        }

        private void BindGameEndScreen(out GameEndScreen gameEndScreen)
        {
            IFactory<GameEndScreen> gameEndScreenFactory = new EndScreenFactory(_uiConfig.GameEndScreen);
            gameEndScreen = gameEndScreenFactory.Create();
        }

        private void BindSettingsScreen(out SettingsScreen settingsScreen)
        {
            IFactory<SettingsScreen> settingsScreenFactory = new SettingsScreenFactory(_uiConfig.SettingScreen);
            settingsScreen = settingsScreenFactory.Create();
        }

        private void BindCanvas(out Canvas canvas)
        {
            IFactory<Canvas> canvasFactory = new CanvasFactory(_uiConfig.Canvas, _cameraFollower.GetComponent<Camera>());
            canvas = canvasFactory.Create();
        }
    }
}

