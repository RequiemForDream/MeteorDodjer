using System;
using UI.Interfaces;

namespace UI
{
    public class ScoreCounter : ICounter<float>
    {
        public event Action<float> OnScoreValueChanged;
        public float _scoreCount;
        
        public void AddValue(float value)
        {
            _scoreCount += value;
            OnScoreValueChanged?.Invoke(value);
        }
    }
}
