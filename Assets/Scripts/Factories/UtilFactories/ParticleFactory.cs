using Character.Interfaces;
using Core.Interfaces;
using Factories.Interfaces;
using Utils.Visual;
using Object = UnityEngine.Object;

namespace Factories.Utils
{
    public class ParticleFactory : IFactory<BackgroundParticle>
    {
        private readonly ParticleConfig _particleConfig;
        private readonly ICharacter _character;
        private readonly IListenersHandler<IInitializable> _initializator;
        private readonly IListenersHandler<IClearable> _clearer;

        public ParticleFactory(ParticleConfig particleConfig, ICharacter character,  IListenersHandler<IInitializable> initializator,
            IListenersHandler<IClearable> clearer)
        {
            _character = character;
            _initializator = initializator;
            _clearer = clearer;
            _particleConfig = particleConfig;
        }

        public BackgroundParticle Create()
        {
            var particle = Object.Instantiate(_particleConfig.ParticlePrefab);
            particle.Construct(_particleConfig.FollowModel, _character.Transform);
            particle.Construct(_initializator, _clearer);
            return particle;
        }
    }
}
