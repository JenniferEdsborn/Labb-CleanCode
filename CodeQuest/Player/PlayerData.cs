﻿using CodeQuest.Interfaces;

namespace CodeQuest.Player
{
    public class PlayerData
    {

        public string Name { get; private set; }
        private int NumberOfGames { get; set; }
        private int NumberOfGuesses { get; set; }

        private Dictionary<string, List<int>> Scoreboard = new Dictionary<string, List<int>>();
        public event Action<PlayerData> PlayerDataUpdated;

        public PlayerData(string name)
        {
            Name = name;
        }

        public void UpdatePlayerData(PlayerData newPlayerData)
        {
            this.Name = newPlayerData.Name;
            this.NumberOfGames = newPlayerData.NumberOfGames;
            this.NumberOfGuesses = newPlayerData.NumberOfGuesses;
            this.Scoreboard = new Dictionary<string, List<int>>(newPlayerData.Scoreboard);

            PlayerDataUpdated?.Invoke(this);
        }

        public void AddGameToScoreboard(string gameTitle, int guesses)
        {
            if (Scoreboard.ContainsKey(gameTitle))
            {
                Scoreboard[gameTitle].Add(guesses);
            }
            else
            {
                Scoreboard.Add(gameTitle, new List<int> { guesses});
            }
        }

        public IReadOnlyDictionary<string, List<int>> GetScoreboard()
        {
            return Scoreboard;
        }

        public void UpdateGuesses(int guesses)
        {
            NumberOfGuesses += guesses;
            NumberOfGames++;
        }

        public void UpdateNumberOfGames()
        {
            NumberOfGames++;
        }

        public double AverageGuesses()
        {
            return (double)NumberOfGuesses / NumberOfGames;
        }
        public string GetPlayerName()
        {
            return Name;
        }        
    }
}
