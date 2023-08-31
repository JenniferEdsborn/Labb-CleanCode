using CodeQuest.Interfaces;

namespace CodeQuest.Player
{
    public class PlayerData : IPlayerData
    {

        public string Name { get; private set; }
        private int NumberOfGames { get; set; }
        private int NumberOfGuesses { get; set; }

        private Dictionary<string, int> GameScores = new Dictionary<string, int>();

        public PlayerData(string name)
        {
            Name = name;
        }

        public void AddGameToScoreboard(string gameTitle, int gameScore)
        {
            if (GameScores.ContainsKey(gameTitle))
            {
                GameScores[gameTitle] += gameScore;
            }
            else
            {
                GameScores.Add(gameTitle, 1);
            }
        }

        public IReadOnlyDictionary<string, int> GetScoreboard()
        {
            return GameScores;
        }

        public void UpdateGuesses(int guesses)
        {
            NumberOfGuesses += guesses;
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
