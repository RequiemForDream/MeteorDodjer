using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MultiplierTimer : MonoBehaviour
    {
        [SerializeField] private Image _timerImage;
        [SerializeField] private TMP_Text _multiplierDisplay;
        [SerializeField] private TMP_Text _generalScoreDisplay;

        [Header("Bonus Score Counter")]
        [SerializeField] private TMP_Text _multiplierXscoreDisplay;
        [SerializeField] private TMP_Text _bonusScoreCalculator;

        private float _multiplierTime;
        private bool _isMultiplierActive;
        private MultiplierCounter _multiplierCounter;
        private ScoreCounter _scoreCounter;
        private float _bonusScore;
        private float _score;

        private TMP_Text[] _textArray => new[] { _bonusScoreCalculator, _multiplierDisplay, _multiplierXscoreDisplay, _generalScoreDisplay};

        public void Construct(MultiplierCounter multiplierCounter, ScoreCounter scoreCounter, float multiplierTime)
        {
            _multiplierTime = multiplierTime;
            _multiplierCounter = multiplierCounter;
            _scoreCounter = scoreCounter;
        }

        private void Update()
        {
            if (_isMultiplierActive)
            {
                _timerImage.fillAmount -= Time.deltaTime / _multiplierTime;
                if (_timerImage.fillAmount == 0)
                {
                    _isMultiplierActive = false;
                    ShowBonusScore();
                    ResetMultiplier();
                }
            }
        }

        public void UpdateMultiplierValue(int value)
        {
            _multiplierDisplay.text = value.ToString();
            _isMultiplierActive = true;
            _timerImage.fillAmount = 1f;
        }

        public void UpdateScoreValue(float value)
        {
            if (_isMultiplierActive)
            {
                _bonusScore += value;
                int valueToAdd = Mathf.FloorToInt(_bonusScore);
                CalculateBonusScore(valueToAdd);
                return;
            }

            _score += value;
            int integerScore = Mathf.FloorToInt(_score);                     
            _generalScoreDisplay.text = integerScore.ToString();
        }

        private void CalculateBonusScore(int value)
        {
            _multiplierXscoreDisplay.text = value + " * " + _multiplierCounter._multiplierCount.ToString();
        }

        private void ShowBonusScore()
        {
            var score = _bonusScore * _multiplierCounter._multiplierCount;
            int roundingScore = Mathf.FloorToInt(score);
            _bonusScoreCalculator.text = "+ " + roundingScore.ToString();
            UpdateScoreValue(score);
        }

        public void ResetMultiplier()
        {
            _isMultiplierActive = false;
            _multiplierCounter.ResetValue();
            _timerImage.fillAmount = 1f;
            gameObject.SetActive(false);
            _bonusScore = 0f;
        }

        public void Clear()
        {
            foreach (var text in _textArray)
            {
                text.text = null;
            }
            _score = 0f;
            _timerImage.fillAmount = 1f;
            _multiplierCounter.ResetValue();
            _isMultiplierActive = false;
            gameObject.SetActive(false);
        }
    }
}
