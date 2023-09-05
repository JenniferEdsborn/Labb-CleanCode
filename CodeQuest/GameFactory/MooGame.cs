namespace CodeQuest.GameFactory
{
    public class MooGame : IGame
    {
        public string GenerateMagicNumber()
        {
            Random randomGenerator = new Random();
            string magicNumber = "";
            List<int> usedDigits = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                int random;
                do
                {
                    random = randomGenerator.Next(10);
                } while (usedDigits.Contains(random));

                usedDigits.Add(random);
                magicNumber += random.ToString();
            }

            return magicNumber;
        }

        public bool IsValidInput(string userGuess)
        {
            if (userGuess.Length == 4)
                return true; return false;
        }

        public string GenerateFeedback(string userGuess, string magicNumber)
        {
            char[] feedback = new char[4];

            for (int i = 0; i < 4; i++)
            {
                if (magicNumber[i] == userGuess[i])
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

                    if (magicNumber[i] == userGuess[j])
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
