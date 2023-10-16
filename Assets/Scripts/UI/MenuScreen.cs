using System;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class MenuScreen : GameScreen, IGameStarter
    {
        public event Action OnGameStartPressed;

        [SerializeField] private SettingsScreen _settingsPanel;

        [Header("Button")]
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _settingsButton;

        private bool _isActive;

        protected override void OnAwake()
        {
            Extensions.Subscribe(_startGameButton, StartGame);
            Extensions.Subscribe(_settingsButton, ActivateSettingsPanel);
        }

        private void StartGame()
        {
            OnGameStartPressed?.Invoke();
        }

        private void ActivateSettingsPanel()
        {
            _isActive = !_isActive;
            _settingsPanel.gameObject.SetActive(_isActive);
        }
    }
}
