using System;
using UI.Interfaces;

namespace UI
{
    public class ScoreCounter : ICounter<float>
    {
        public event Action<float> OnScoreValueChanged;
        public float _scoreCount;
        private readonly MultiplierCounter _multiplierCounter;

        public ScoreCounter(MultiplierCounter multiplierCounter)
        {
            _multiplierCounter = multiplierCounter;
        }
        
        public void AddValue(float value)
        {
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
