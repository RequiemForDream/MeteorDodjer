using Core;
using UI;

namespace StateMachine
{
    public class GameEndState : State
    {
        private readonly IClearable[] _clearables;
        private readonly GameEndScreen _gameEndScreen;

        public GameEndState(IClearable[] clearables, GameEndScreen gameEndScreen)
        {
            _clearables = clearables;
            _gameEndScreen = gameEndScreen;
        }

        public override void Enter()
        {
            _gameEndScreen.Show();
            foreach (var clearable in _clearables)
            {
                clearable.Clear();
            }
        }
    }
}
