using Core;
using UI;
using UnityEngine;

namespace StateMachine
{
    public class StartState : State
    {
        private readonly MenuScreen _menuScreen;
        private readonly GameEndScreen _gameEndScreen;
        private readonly SettingsScreen _settingsScreen;
        private readonly Canvas _canvas;
        private readonly GameplayScreen _gameplayScreen;

        public StartState(UIContainer uiContainer)
        {
            _menuScreen = uiContainer.MenuScreen;   
            _gameEndScreen = uiContainer.GameEndScreen;
            _settingsScreen = uiContainer.SettingsScreen;
            _canvas = uiContainer.Canvas;
            _gameplayScreen = uiContainer.GameplayScreen;
        }

        public override void Enter()
        {
            InitializeMenuScreen();
            InitializeSettingsScreen();
            InitializeGameEndScreen();
            InitializeGameplayScreen();
        }

        private void InitializeMenuScreen()
        {
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

        private void InitializeGameplayScreen()
        {
            _gameplayScreen.SetCanvas(_canvas);
            _gameplayScreen.Hide();
        }

        public override void Exit()
        {
            _menuScreen.Hide();
            _settingsScreen.Hide();
            _gameEndScreen.Hide();
        }
    }
}
