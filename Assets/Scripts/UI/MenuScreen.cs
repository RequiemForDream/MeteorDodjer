using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class MenuScreen : GameScreen
    {
        public event Action OnGameStartPressed;

        [Header("Button")]
        [SerializeField] private Button _startGameButton;

        protected override void OnAwake()
        {
            Extensions.Subscribe(_startGameButton, StartGame);
        }

        private void StartGame()
        {
            OnGameStartPressed?.Invoke();
        }
    }
}
