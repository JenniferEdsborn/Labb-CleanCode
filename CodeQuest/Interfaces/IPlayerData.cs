namespace CodeQuest.Interfaces
{
    public interface IPlayerData
    {

        public void AddGameToScoreboard(string gameTitle, int gameScore);

        public IReadOnlyDictionary<string, int> GetScoreboard();

        public void UpdateGuesses(int guesses);

        public double AverageGuesses();

        public string GetPlayerName();
    }
}
