using CodeQuest.Interfaces;
using CodeQuest.Player;
using System.Text.Json;

namespace CodeQuest.Utilities
{
    public class DataIO : IDataIO
    {
        private List<PlayerData> playerDataList;
        private string filePath;

        public DataIO()
        {
            filePath = "CodeQuestSaveGames.json";
            LoadPlayerDataList();

            foreach (var playerData in playerDataList)
            {
                playerData.PlayerDataUpdated += PlayerDataUpdatedHandler;
            }
        }

        public void SubscribeToPlayerData(PlayerData newPlayerData)
        {
            newPlayerData.PlayerDataUpdated += PlayerDataUpdatedHandler;
            playerDataList.Add(newPlayerData);
            SavePlayerDataList();
        }

        private void PlayerDataUpdatedHandler(PlayerData playerData)
        {
            SavePlayerData(playerData);
        }

        public List<string> GetPlayerNames()
        {
            if (playerDataList == null)
            {
                return new List<string>();
            }

            List<string> playerNames = playerDataList.Select(playerData => playerData.Name).ToList();
            return playerNames;
        }

        public PlayerData LoadPlayerData(string playerName)
        {
            if (playerDataList == null)
            {
                return null;
            }

            PlayerData playerData = playerDataList.FirstOrDefault(data => data.Name == playerName);
            return playerData;
        }

        public void SavePlayerData(PlayerData playerDataToUpdate)
        {
            if (playerDataList == null)
            {
                playerDataList = new List<PlayerData>();
            }

            int indexToUpdate = playerDataList.FindIndex(data => data.Name == playerDataToUpdate.Name);
            if (indexToUpdate != -1)
            {
                playerDataList[indexToUpdate] = playerDataToUpdate;
            }
            else
            {
                playerDataList.Add(playerDataToUpdate);
            }

            SavePlayerDataList();
        }

        private void SavePlayerDataList()
        {
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string jsonData = JsonSerializer.Serialize(playerDataList);
            File.WriteAllText(filePath, jsonData);
        }    

        private void LoadPlayerDataList()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                playerDataList = JsonSerializer.Deserialize<List<PlayerData>>(jsonData);
            }
            else
            {
                playerDataList = new List<PlayerData>();
            }
        }

        public List<(string Name, double AverageGuesses)> GetTopPlayers()
        {
            var topPlayers = playerDataList
                .Select(playerData => (playerData.Name, AverageGuesses: playerData.AverageGuesses()))
                .OrderBy(player => player.AverageGuesses)
                .Take(10)
                .ToList();

            return topPlayers;
        }
    }
}
