using Character.Interfaces;
using Core.Interfaces;
using Factories.Interfaces;
using Utils.Visual;
using Object = UnityEngine.Object;

namespace Factories.Utils
{
    public class BackgroundFactory : IFactory<Background>
    {
        private readonly BackgroundConfig _backgroundConfig;
        private readonly ICharacter _character;
        private readonly IListenersHandler<IInitializable> _initializator;
        private readonly IListenersHandler<IClearable> _clearer;

        public BackgroundFactory(BackgroundConfig backgroundConfig, ICharacter character, IListenersHandler<IClearable> clearer,
            IListenersHandler<IInitializable> initializator)
        {
            _character = character;
            _initializator = initializator;
            _clearer = clearer;
            _backgroundConfig = backgroundConfig;
        }

        public Background Create()
        {
            var background = Object.Instantiate(_backgroundConfig.BackgroundPrefab);
            background.Construct(_backgroundConfig.FollowModel, _character.Transform);
            background.Construct(_backgroundConfig.BackgroundModel, _initializator, _clearer);
            return background;
        }
    }
}
