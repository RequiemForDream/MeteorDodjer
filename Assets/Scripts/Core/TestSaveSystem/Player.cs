using UnityEngine;

namespace Core.Save
{
    public class Player : MonoBehaviour
    {
        public float Number;

        private void Awake()
        {
            var data = SaveSystem.LoadPlayerData();
            //Number = data.HighScore;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                PlayerData playerData = new PlayerData(Number);
                SaveSystem.SavePlayer(playerData);
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                var data = SaveSystem.LoadPlayerData();
                Number = data.HighScore;
            }
        }


    }
}
