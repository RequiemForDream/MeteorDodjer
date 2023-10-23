using Core.Interfaces;
using Core.Save;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameplayScreen : GameScreen, IClearable, IInitializable
    {
        [SerializeField] private ScoreDisplay _scoreDisplay;
        [SerializeField] private TMP_Text _highScoreDisplay;
        [SerializeField] private SafeArea _safeArea;

        protected override void OnAwake()
        {
            _safeArea.UpdateSafeArea();
        }

        public void Construct(MultiplierCounter multiplierCounter, IListenersHandler<IInitializable> initializator,
            IListenersHandler<IClearable> clearer, ScoreCounter scoreCounter, GameplayScreenModel gameplayScreenModel)
        {
            multiplierCounter.OnMultiplierValueChanged += UpdateMultiplierValue;
            scoreCounter.OnScoreValueChanged += UpdatePointsValue;
            _scoreDisplay.Construct(multiplierCounter, gameplayScreenModel.MultiplierTimer, scoreCounter);
            initializator.AddListener(this);
            clearer.AddListener(this);
        }

        public void Initialize()
        {
            _scoreDisplay.gameObject.SetActive(false);
            var data = SaveSystem.LoadPlayerData();
            if (data == null)
            {
                _highScoreDisplay.text = null;
                return;
            }
            int highScore = Mathf.FloorToInt(data.HighScore);
            _highScoreDisplay.text = highScore.ToString();
        }

        private void UpdateMultiplierValue(int value)
        {
            _scoreDisplay.gameObject.SetActive(true);
            _scoreDisplay.UpdateMultiplierValue(value);
        }

        private void UpdatePointsValue(float value)
        {
            _scoreDisplay.UpdateScoreValue(value);
        }

        public void Clear()
        {
            _scoreDisplay.Clear();
        }
    }
}
