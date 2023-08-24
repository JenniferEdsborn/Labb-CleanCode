namespace CodeQuest.GameFactory
{
    public interface IGame
    {
        void CheckUserGuess(int userGuess);

        string GenerateFeedback(string input);

        void WinGame();

        // Defines the common methods that all game objects should implement, just as mentioned before.
    }
}
