using CodeQuest.Utilities;

namespace CodeQuest.GameFactory
{
    public class MooGame : IGame
    {
        ErrorMessages errorMessages = new ErrorMessages();

        public string GenerateMagicNumber()
        {
            Random randomGenerator = new Random();
            string magicNumber = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (magicNumber.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                magicNumber = magicNumber + randomDigit;
            }
            return magicNumber;
        }

        public void CheckUserGuess(int userGuess, int magicNumber)
        {
            string _userGuess = userGuess.ToString();
            if (IsValidInput(_userGuess) && HasUniqueCharacters(_userGuess))
            {
                GenerateFeedback(_userGuess, magicNumber);
            }
            errorMessages.GuessNotValid();
        }

        public bool IsValidInput(string userGuess)
        {
            return userGuess.Length == 4;
        }

        private bool HasUniqueCharacters(string userGuess)
        {
            HashSet<char> uniqueCharacters = new HashSet<char>();

            foreach (char c in userGuess)
            {
                if (uniqueCharacters.Contains(c))
                {
                    return false;
                }
                uniqueCharacters.Add(c);
            }
            return true;
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
            return "MooGame";
        }

        public string GetInstructions()
        {
            return "MooGame game instructions.";
        }
    }
}
