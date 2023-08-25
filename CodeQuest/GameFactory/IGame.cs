namespace CodeQuest.GameFactory
{
    public interface IGame
    {
        void CheckUserGuess(int userGuess, int magicNumber);

        string GenerateFeedback(string input, int magicNumber);
        string GenerateMagicNumber();
        bool IsValidInput(string userGuess);

    }
}
