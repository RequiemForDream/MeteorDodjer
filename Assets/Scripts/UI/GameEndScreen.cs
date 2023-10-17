using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class GameEndScreen : GameScreen
    {
        public event Action OnRestartButtonPressed;

        [SerializeField] private Button _restartButton;

        protected override void OnAwake()
        {
            Extensions.Subscribe(_restartButton, OnGameRestart);
        }

        private void OnGameRestart()
        {
            OnRestartButtonPressed?.Invoke();
        }
    }
}
