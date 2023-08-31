using CodeQuest.Interfaces;
using System.Text.Json;

namespace CodeQuest.Utilities
{
    public class DataIO : IDataIO
    {
        Player.PlayerData playerData;
        private string filePath;

        public DataIO()
        {
            //filePath = $"{playerData.GetPlayerName()}_data.json";
        }

        public void AssessPlayerData()
        {
            if (File.Exists(filePath))
            {
                LoadPlayerData();
            }
            SavePlayerData();
        }

        public void SavePlayerData()
        {
            string jsonData = JsonSerializer.Serialize(playerData);

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(jsonData);
            }
        }

        public void LoadPlayerData()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string jsonData = reader.ReadToEnd();
                playerData = JsonSerializer.Deserialize<Player.PlayerData>(jsonData);
            }
        }
    }

    // error handling ?
    // observer

}
