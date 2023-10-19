using Character;
using Core;
using Core.Interfaces;
using Factories.Interfaces;
using Sounds.Interfaces;
using UI;
using UI.Interfaces;
using Object = UnityEngine.Object;

namespace Factories
{
    public class MainCharacterFactory : IFactory<MainCharacter>
    {
        private readonly CharacterConfig _characterConfig;
        private readonly Updater _updater;
        private readonly IInputService _inputService;
        private readonly IListenersHandler<IInitializable> _initializator;
        private readonly IListenersHandler<IClearable> _clearer;
        private readonly ISoundFactory _soundFactory;
        private readonly ICounter<float> _scoreCounter;

        public MainCharacterFactory(CharacterConfig characterConfig, Updater updater, IInputService inputService,
            IListenersHandler<IInitializable> initializator, IListenersHandler<IClearable> clearer, ISoundFactory soundFactory,
            ICounter<float> scoreCounter)
        {
            _characterConfig = characterConfig;
            _updater = updater;
            _inputService = inputService;
            _clearer = clearer;
            _initializator = initializator;
            _soundFactory = soundFactory;
            _scoreCounter = scoreCounter;
        }

        public MainCharacter Create()
        {
            CharacterView characterView = Object.Instantiate(_characterConfig.CharacterPrefab);

            MainCharacter mainCharacter = new MainCharacter(characterView, _characterConfig.CharacterModel,
                _updater, _inputService, _initializator, _clearer, _soundFactory, _scoreCounter);

            return mainCharacter;
        }
    }
}
