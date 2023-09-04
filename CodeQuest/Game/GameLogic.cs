using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Player;
using CodeQuest.Utilities;
using System.Reflection.Metadata.Ecma335;

namespace CodeQuest.Game
{
    public class GameLogic : IGameLogic
    {
        private int guesses = 0;
        private const string WinningFeedback = "BBBB";

        IGame game;
        IConsoleIO io;
        IDataIO dataIO;

        PlayerData playerData;
        ErrorMessages errorMessages = new ErrorMessages();

        public GameLogic(IGame game, IConsoleIO io, PlayerData playerData)
        {
            this.game = game;
            this.io = io;
            this.playerData = playerData;

            dataIO = new DataIO();
        }

        public void RunGameLoop()
        {
            string magicNumber = game.GenerateMagicNumber();
            bool correctNumberGuessed = false;

            io.PrintString($"Numret är: {magicNumber}");

            while (!correctNumberGuessed)
            {
                io.PrintPrompt();
                string userGuess = io.GetUserInput();

                if (CheckUserGuess(userGuess))
                {
                    guesses++;
                    string feedback = game.GenerateFeedback(userGuess, magicNumber);
                    io.PrintString(feedback);

                    if (feedback == WinningFeedback)
                    {
                        correctNumberGuessed = true;
                    }
                }
                else
                {
                    io.PrintString(errorMessages.GuessNotValid());
                    continue;
                }
            }

            WinGame();
        }

        private bool CheckUserGuess(string userGuess)
        {
            if (io.IsNumber(userGuess) && game.IsValidInput(userGuess))
            {
                return true;
            }
            return false;
        }

        private void WinGame()
        {
            playerData.UpdateGuesses(guesses);
            playerData.UpdateNumberOfGames();
            playerData.AddGameToScoreboard(game.GetGameName(), guesses);

            io.PrintString($"Your average amount of guesses are: {playerData.AverageGuesses()}.");
            io.PrintString("Top List:");

            List<(string, double)> topPlayers = dataIO.GetTopPlayers();

            foreach (var (name, avgGuesses) in topPlayers)
            {
                io.PrintString($"Name: {name}, Average Guesses: {avgGuesses}");
            }

            this.guesses = 0;

            return;
        }
    }
}
