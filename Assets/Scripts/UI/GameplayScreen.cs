﻿using Core;
using Core.Interfaces;
using Core.Save;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameplayScreen : GameScreen, IClearable, IInitializable
    {
        [SerializeField] private MultiplierTimer _timer;
        [SerializeField] private TMP_Text _highScore;

        private ScoreCounter _scoreCounter;

        protected override void OnAwake() { }

        public void Construct(MultiplierCounter multiplierCounter, IListenersHandler<IInitializable> initializator,
            IListenersHandler<IClearable> clearer, ScoreCounter scoreCounter, float multiplierTime)
        {
            multiplierCounter.OnMultiplierValueChanged += UpdateMultiplierValue;
            scoreCounter.OnScoreValueChanged += UpdatePointsValue;
            _timer.Construct(multiplierCounter, scoreCounter, multiplierTime);
            initializator.AddListener(this);
            clearer.AddListener(this);
        }

        public void Initialize()
        {
            _timer.gameObject.SetActive(false);
            //var data = SaveSystem.LoadPlayerData();
            //int highScore = Mathf.FloorToInt(data.HighScore);
            //_highScore.text = highScore.ToString();
        }

        private void UpdateMultiplierValue(int value)
        {
            _timer.gameObject.SetActive(true);
            _timer.UpdateMultiplierValue(value);
        }

        private void UpdatePointsValue(float value)
        {
            _timer.UpdateScoreValue(value);
        }

        public void Clear()
        {
            _timer.Clear();
        }
    }
}
