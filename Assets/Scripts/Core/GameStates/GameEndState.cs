using UI;

namespace StateMachine
{
    public class GameEndState : State
    {
        private readonly GameEndScreen _gameEndScreen;

        public GameEndState(GameEndScreen gameEndScreen)
        {
            _gameEndScreen = gameEndScreen;
        }

        public override void Enter()
        {
            _gameEndScreen.Show();
            _gameEndScreen.OnRestartButtonPressed += SetGameEndState;
        }

        public override void Exit()
        {
            _gameEndScreen.Hide();
        }

        private void SetGameEndState()
        {
            StateMachine.ChangeState<GameplayState>();
        }
    }
}
