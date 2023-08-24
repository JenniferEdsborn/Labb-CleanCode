using CodeQuest.Utilities;

namespace CodeQuest.GameFactory
{
    public class MooGame : IGame
    {
        ErrorMessages errorMessages = new ErrorMessages();

        public void CheckUserGuess(int userGuess)
        {
            string _userGuess = userGuess.ToString();
            if (IsValidInput(_userGuess) && HasUniqueCharacters(_userGuess))
            {
                GenerateFeedBack(_userGuess);
            }
            errorMessages.GuessNotValid();
        }

        private bool IsValidInput(string input)
        {
            return input.Length == 4;
        }

        private bool HasUniqueCharacters(string input)
        {
            HashSet<char> uniqueCharacters = new HashSet<char>();

            foreach (char c in input)
            {
                if (uniqueCharacters.Contains(c))
                {
                    return false;
                }
                uniqueCharacters.Add(c);
            }
            return true;
        }


        public string GenerateFeedBack(string input)
        {
            return "";
        }

        public void WinGame()
        {
            Console.WriteLine("Conglaturation! You have completed a great game.");
        }
















        private bool playOn = true;

        public void Start()
        {
            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine();

            while (playOn)
            {
                string goal = MakeGoal();

                Console.WriteLine("New game:\n");
                Console.WriteLine("For practice, number is: " + goal + "\n");
                string guess = Console.ReadLine();

                int nGuess = 1;
                string bbcc = CheckBC(goal, guess);
                Console.WriteLine(bbcc + "\n");

                while (bbcc != "BBBB,")
                {
                    nGuess++;
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    bbcc = CheckBC(goal, guess);
                    Console.WriteLine(bbcc + "\n");
                }

                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(name + "#&#" + nGuess);
                output.Close();
                ShowTopList();
                Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = Console.ReadLine();

                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }

        public void Play()
        {
            Start();
        }

        public void End()
        {
            // Cleanup or post-game actions if needed
        }

        // ... Rest of the methods like MakeGoal, CheckBC, and ShowTopList ...
    }
}
