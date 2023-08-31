namespace CodeQuest.GameFactory
{
    public class MooGame : IGame
    {
        public int GenerateMagicNumber()
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
            int parsedMagicNumber = int.Parse(magicNumber);
            return parsedMagicNumber;
        }

        public bool IsValidInput(string userGuess)
        {
            if (userGuess.Length == 4 && HasUniqueCharacters(userGuess))
                return true; return false;
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
            char[] feedback = new char[4];

            for (int i = 0; i < 4; i++)
            {
                if (_magicNumber[i] == userGuess[i])
                {
                    feedback[i] = 'B';
                }
                else
                {
                    feedback[i] = ',';
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (feedback[i] == 'B')
                    continue;

                for (int j = 0; j < 4; j++)
                {
                    if (feedback[j] != ',')
                        continue;

                    if (_magicNumber[i] == userGuess[j])
                    {
                        feedback[j] = 'C';
                        break;
                    }
                }
            }

            return new string(feedback);
        }

        public string GetGameName()
        {
            return "MooGame";
        }

        public string[] GetInstructions()
        {
            string[] instructions = new string[] { "Guess the magic number!", "Digits 0-9, only unique numbers.",
                "B = right digit, right place", "C = right digit, wrong place", ", = digit not part of sequence" };

            return instructions;
        }
    }
}
