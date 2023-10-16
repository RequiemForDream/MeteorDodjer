using Character.Interfaces;
using Core.Interfaces;
using Factories.Interfaces;

namespace StateMachine
{
    public class InitializeState : State
    {
        private readonly IInitializable[] _initializables;
        private readonly IFactory<ICharacter> _characterFactory;

        public InitializeState(IInitializable[] initializables, IFactory<ICharacter> characterFactory)
        {
            _initializables = initializables;
            _characterFactory = characterFactory;
            _characterFactory.Create();
        }

        public override void Enter()
        {
            
            foreach (var initializable in _initializables)
            {
                initializable.Initialize();
            }
        }
    }
}
