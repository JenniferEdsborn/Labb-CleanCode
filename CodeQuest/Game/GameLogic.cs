using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Utilities;

namespace CodeQuest.Game
{
    public class GameLogic : IGameLogic
    {
        private int guesses;
        private int score;

        IGame game;
        IConsoleIO io;

        public GameLogic(IGame game, IConsoleIO io)
        {
            this.game = game;
            this.io = io;
            // create the dictionarystuff to PlayerData
        }

        public int GenerateMagicNumber()
        {
            int magicNumber = game.GenerateMagicNumber();
            return magicNumber;
        }

        public string GetUserGuess()
        {
            string userGuess = io.GetUserInput();

            return CheckUserGuess(userGuess);
        }

        public string CheckUserGuess(string userGuess)
        {
            if (io.IsNumber(userGuess))
            {
                io.ConvertToInt(userGuess);
            }

            return "";
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
