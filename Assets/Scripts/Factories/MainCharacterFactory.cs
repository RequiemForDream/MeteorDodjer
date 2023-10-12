using Character;
using Core;
using Core.Interfaces;
using Factories.Interfaces;
using Object = UnityEngine.Object;

namespace Factories
{
    public class MainCharacterFactory : IFactory<MainCharacter>
    {
        private readonly CharacterConfig _characterConfig;
        private readonly Updater _updater;
        private readonly IInputService _inputService;

        public MainCharacterFactory(CharacterConfig characterConfig, Updater updater, IInputService inputService)
        {
            _characterConfig = characterConfig;
            _updater = updater;
            _inputService = inputService;
        }

        public MainCharacter Create()
        {
            CharacterView characterView = Object.Instantiate(_characterConfig.CharacterPrefab);

            MainCharacter mainCharacter = new MainCharacter(characterView, _characterConfig.CharacterModel,
                _updater, _inputService);

            return mainCharacter;
        }
    }
}
