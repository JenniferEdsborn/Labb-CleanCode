using CodeQuest.GameFactory;
using CodeQuest.Interfaces;

namespace CodeQuest.Game
{
    public class GameLogic : IGameLogic
    {
        private readonly int correctNumber;
        private int guesses;
        private int score;
        Random random;
        IGame game;

        public GameLogic(IGame game)
        {
            this.game = game;
            random = new Random();

            correctNumber = 1234; // generate random number
            // create the dictionarystuff to PlayerData
        }



        public int GenerateMagicNumber()
        {
            return 0;
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
