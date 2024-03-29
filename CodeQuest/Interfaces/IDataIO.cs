﻿using CodeQuest.Player;

namespace CodeQuest.Interfaces
{
    public interface IDataIO
    {
        List<string> GetPlayerNames();
        List<(string Name, int NumberOfGames, double AverageGuesses)> GetTopPlayers();
        PlayerData LoadPlayerData(string playerName);
        Task SavePlayerData(PlayerData playerDataToUpdate);
        void SubscribeToPlayerData(PlayerData newPlayerData);
    }
}
