using CodeQuest.GameFactory;
using CodeQuest.Utilities;

public class MasterMind : IGame
{
    public int GenerateMagicNumber()
    {
        Random randomGenerator = new Random();
        string magicNumber = "";
        for (int i = 0; i < 4; i++)
        {
            int randomDigit = randomGenerator.Next(6);
            magicNumber += randomDigit.ToString();
        }
        int parsedMagicNumber = int.Parse(magicNumber);
        return parsedMagicNumber;
    }

    public bool IsValidInput(string userGuess)
    {
        return userGuess.Length == 4;
    }

    public string GenerateFeedback(string userGuess, int magicNumber)
    {
        string _magicNumber = magicNumber.ToString();
        int cows = 0, bulls = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (_magicNumber[i] == userGuess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }

    public string GetGameName()
    {
        return "MasterMind";
    }

    public string[] GetInstructions()
    {
        string[] instructions = new string[] { "Guess the magic number!", "Digits 0-5, non-unique numbers are allowed.",
                "B = right digit, right place", "C = right digit, wrong place", ", = digit not part of sequence" };

        return instructions;
    }
}