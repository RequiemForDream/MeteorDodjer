using System;
using UI.Interfaces;

namespace UI
{
    public class ScoreCounter : ICounter<float>
    {
        public event Action<float> OnScoreValueChanged;
        private bool _isMultiplierActive;
        private float _scoreCount;
        private float _bonusScoreCount;
        private readonly MultiplierCounter _multiplierCounter;

        public ScoreCounter(MultiplierCounter multiplierCounter)
        {
            _multiplierCounter = multiplierCounter;
        }
        
        public void AddValue(float value)
        {
            if (_isMultiplierActive)
            {
                _bonusScoreCount += value;
                return;
            }

            _scoreCount += value;
            OnScoreValueChanged?.Invoke(value);
        }

        public void ResetValue()
        {
            _scoreCount = 0f;
        }

        public void GetBonusScore()
        {

        }
    }
}
