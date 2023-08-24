namespace CodeQuest.GameFactory
{
    public interface IGame
    {
        void CheckUserGuess();

        string GenerateFeedback();

        void WinGame();

        // Defines the common methods that all game objects should implement, just as mentioned before.
    }
}
