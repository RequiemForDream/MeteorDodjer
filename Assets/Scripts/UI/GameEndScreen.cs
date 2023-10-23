using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class GameEndScreen : GameScreen
    {
        public event Action OnRestartButtonPressed;

        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _scoreText;
        private ScoreCounter _scoreCounter;

        public void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        protected override void OnAwake()
        {
            Extensions.Subscribe(_restartButton, OnGameRestart);
        }

        private void OnEnable()
        {
            
        }

        public void ShowFinalScore()
        {
            int score = Mathf.FloorToInt(_scoreCounter._scoreCount);
            _scoreText.text = score.ToString();
        }

        private void OnGameRestart()
        {
            OnRestartButtonPressed?.Invoke();
        }
    }
}
