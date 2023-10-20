using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Core.Save
{
    public static class SaveSystem
    {      
        public static void SavePlayer(PlayerData playerData)
        {
            string filePath = Application.persistentDataPath + "/playerData.fun";
            BinaryFormatter formatter = new BinaryFormatter();

            // Переменная для хранения предыдущих данных игрока
            PlayerData savedPlayerData = null;

            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    savedPlayerData = (PlayerData)formatter.Deserialize(fileStream);
                }
            }

            // Проверяем, улучшился ли счет игрока
            if (savedPlayerData == null || playerData.HighScore > savedPlayerData.HighScore)
            {
                using (FileStream newFileStream = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(newFileStream, playerData);
                }
            }
        }

        public static PlayerData LoadPlayerData()
        {
            string filePath = Application.persistentDataPath + "/playerData.fun";

            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    return (PlayerData)formatter.Deserialize(fileStream);
                }
            }
            else
            {
                Debug.LogWarning("Файл данных игрока не найден.");
                return null;
            }
        }
    }
}
