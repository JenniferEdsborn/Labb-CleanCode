namespace CodeQuest.GameFactory
{
    public interface IGame
    {
        void CheckUserGuess(int userGuess, int magicNumber);

        string GenerateFeedback(string input, int magicNumber);
        int GenerateMagicNumber();
        bool IsValidInput(string userGuess);
        string GetGameName();
        string[] GetInstructions();
    }
}
