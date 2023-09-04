namespace CodeQuest.GameFactory
{
    public interface IGame
    {
        string GenerateFeedback(string input, string magicNumber);
        string GenerateMagicNumber();
        bool IsValidInput(string userGuess);
        string GetGameName();
        string[] GetInstructions();
    }
}
