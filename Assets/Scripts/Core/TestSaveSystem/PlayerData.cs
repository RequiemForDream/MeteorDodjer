using System;

namespace Core.Save
{
    [Serializable]
    public class PlayerData
    {
        public float HighScore;

        public PlayerData(float score)
        {
            HighScore = score;
        }
    }
}
