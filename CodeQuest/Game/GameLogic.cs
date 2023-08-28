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

        IGame game;
        IConsoleIO io;

        PlayerData playerData;
        ErrorMessages errorMessages = new ErrorMessages();

        public GameLogic(IGame game, IConsoleIO io, PlayerData playerData)
        {
            this.game = game;
            this.io = io;
            this.playerData = playerData;
        }

        public void RunGameLoop()
        {
            int magicNumber = game.GenerateMagicNumber();
            int parsedUserGuess = 0;

            while (parsedUserGuess != magicNumber)
            {
                io.PrintPrompt();
                string userGuess = io.GetUserInput();
                if (CheckUserGuess(userGuess))
                {
                    guesses++;
                    parsedUserGuess = io.ConvertToInt(userGuess);
                    io.PrintString(game.GenerateFeedback(userGuess, magicNumber));
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
            // PRINT TOPLIST (från DataIO + AverageGuesses-beräkning?)

            this.guesses = 0;

            return;
        }
    }
}
