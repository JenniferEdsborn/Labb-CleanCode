using CodeQuest.Interfaces;
using System.Text.Json;

namespace CodeQuest.Utilities
{
    public class DataIO : IDataIO
    {
        IConsoleIO io;
        Player.PlayerData playerData;
        private string filePath;

        public DataIO(Player.PlayerData playerData, IConsoleIO io)
        {
            this.playerData = playerData;
            this.io = io;
            filePath = $"{playerData.GetPlayerName()}_data.json";
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

        public Player.PlayerData GetPlayerData()
        {
            return playerData;
        }
    }

    // error handling ?
    // observer

}
