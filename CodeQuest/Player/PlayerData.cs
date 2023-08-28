namespace CodeQuest.Player
{
    public class PlayerData
    {
        public string Name { get; private set; }
        private int NumberOfGames { get; set; }
        private int NumberOfGuesses { get; set; }
        private Dictionary<string, int> GameScores = new Dictionary<string, int>();

        public PlayerData(string name)
        {
            Name = name;
        }

        public void AddGameToScoreboard(string gameTitle, int guesses)
        {
            if (GameScores.ContainsKey(gameTitle))
            {
                GameScores[gameTitle]+= guesses;
            }
            else
            {
                GameScores.Add(gameTitle, guesses);
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

        public void UpdateNumberOfGames()
        {
            NumberOfGames++;
        }

        public double AverageGuesses()
        {
            return (double)NumberOfGuesses / NumberOfGames;
        }
    }
}
