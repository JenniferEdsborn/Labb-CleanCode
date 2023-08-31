namespace CodeQuest.GameFactory
{
    public interface IGame
    {
        string GenerateFeedback(string input, int magicNumber);
        int GenerateMagicNumber();
        bool IsValidInput(string userGuess);
        string GetGameName();
        string[] GetInstructions();
    }
}
