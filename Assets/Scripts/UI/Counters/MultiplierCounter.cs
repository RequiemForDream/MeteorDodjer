using System;
using UI.Interfaces;

namespace UI
{
    public class MultiplierCounter : ICounter<int>
    {
        public event Action<int> OnMultiplierValueChanged;
        public int _multiplierCount = 1;

        public void AddValue(int multiplier)
        {
            _multiplierCount += multiplier;
            OnMultiplierValueChanged?.Invoke(_multiplierCount);
        }

        public void ResetValue()
        {
            _multiplierCount = 1;
        }
    }
}
