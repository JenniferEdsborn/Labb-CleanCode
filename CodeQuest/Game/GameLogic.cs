using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Game
{
    public class GameLogic
    {
        private readonly int correctNumber;
        private int guesses;
        private int score;
        Random random;

        public GameLogic() // ta in objekt så vi vet vilket spel det gäller
        {
            // create the randomizer with correct total of numbers
            correctNumber = 1234; // generate random number
            // create the dictionarystuff to PlayerData
        }

        public void GetUserGuess()
        {

        }

        public void CheckUserGuess()
        {

        }

        public string GenerateFeedback()
        {
            // cows and bulls

            return "";
        }

        public void WinGame()
        {
            // update guesses & no of games
            // update GameScore

            guesses = 0;

            // send player back
        }
    }
}
