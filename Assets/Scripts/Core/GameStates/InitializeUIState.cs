using Core;
using UI;
using UnityEngine;

namespace StateMachine
{
    public class InitializeUIState : State
    {
        private readonly MenuScreen _menuScreen;
        private readonly GameEndScreen _gameEndScreen;
        private readonly SettingsScreen _settingsScreen;
        private readonly Canvas _canvas;

        public InitializeUIState(UIFactory uiFactory)
        {
            _menuScreen = uiFactory.MenuScreen;   
            _gameEndScreen = uiFactory.GameEndScreen;
            _settingsScreen = uiFactory.SettingsScreen;
            _canvas = uiFactory.Canvas;
        }

        public override void Enter()
        {
            InitializeMenuScreen();
            InitializeSettingsScreen();
            InitializeGameEndScreen();
        }

        private void InitializeMenuScreen()
        {
            _menuScreen.OnGameStartPressed += SetInitState;
            _menuScreen.SetCanvas(_canvas);
            _menuScreen.Show();
        }

        private void InitializeSettingsScreen()
        {
            _settingsScreen.SetCanvas(_canvas);
            _settingsScreen.Hide();
        }

        private void InitializeGameEndScreen()
        {
            _gameEndScreen.SetCanvas(_canvas);
            _gameEndScreen.Hide();
        }

        private void SetInitState()
        {
            StateMachine.ChangeState<InitializeState>();
        }

        public override void Exit()
        {
            _menuScreen.Hide();
            _settingsScreen.Hide();
            _gameEndScreen.Hide();
        }
    }
}
