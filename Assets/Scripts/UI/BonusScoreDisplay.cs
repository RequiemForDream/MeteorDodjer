using TMPro;
using UnityEngine;

namespace UI
{
    public class BonusScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bonusScoreCalclator;
        [SerializeField] private TMP_Text _finalBonusScoreDisplay;

        public void CountBonusScore(int multiplier, float bonusScore)
        {
            int value = Mathf.FloorToInt(bonusScore);
            _bonusScoreCalclator.text = value + " * " + multiplier.ToString();
        }

        public void SetFinalScore(float bonusScore)
        {
            int value = Mathf.FloorToInt(bonusScore);
            _finalBonusScoreDisplay.text = value.ToString();
        }

        public void Clear()
        {
            _bonusScoreCalclator.text = null;
            _finalBonusScoreDisplay.text = null;
        }
    }
}
