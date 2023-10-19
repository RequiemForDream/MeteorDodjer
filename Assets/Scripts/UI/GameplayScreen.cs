using Core;
using Core.Interfaces;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameplayScreen : GameScreen, IClearable, IInitializable
    {
        [SerializeField] private MultiplierTimer _timer;
        [SerializeField] private TMP_Text _scoreCount;

        private ScoreCounter _scoreCounter;
        private Coroutine _coroutine;

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
