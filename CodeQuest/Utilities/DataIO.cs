using CodeQuest.Interfaces;
using CodeQuest.Player;
using System.Text.Json;

namespace CodeQuest.Utilities
{
    public class DataIO : IDataIO
    {
        private List<PlayerData> playerDataList;
        private readonly string filePath;

        public DataIO()
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "CodeQuestSaveGames.json");
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
            Task.Run(() => SavePlayerDataList());
        }

        private async void PlayerDataUpdatedHandler(PlayerData playerData)
        {
            await SavePlayerData(playerData);
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

        public async Task SavePlayerData(PlayerData playerDataToUpdate)
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

            await SavePlayerDataList();
        }

        public async Task SavePlayerDataList()
        {
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string jsonData = JsonSerializer.Serialize(playerDataList);

            using (StreamWriter writer = File.CreateText(filePath))
            {
                await writer.WriteAsync(jsonData);
            }
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
            LoadPlayerDataList();

            var topPlayers = playerDataList
                .Where(playerData => playerData.NumberOfGames > 0)
                .Select(playerData => (playerData.Name, AverageGuesses: playerData.AverageGuesses()))
                .OrderBy(player => player.AverageGuesses)
                .Take(10)
                .ToList();

            return topPlayers;
        }

        public async Task DeletePlayerData(string playerName)
        {
            if (playerDataList == null)
            {
                return;
            }

            int indexToRemove = playerDataList.FindIndex(data => data.Name == playerName);
            if (indexToRemove != -1)
            {
                playerDataList.RemoveAt(indexToRemove);
                await SavePlayerDataList();
            }
        }
    }
}
