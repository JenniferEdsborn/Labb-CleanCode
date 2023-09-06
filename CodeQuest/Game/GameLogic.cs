using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Player;
using CodeQuest.Utilities;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

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
        MenuUtils menuUtils;

        public GameLogic(IGame game, IConsoleIO io, PlayerData playerData)
        {
            this.game = game;
            this.io = io;
            this.playerData = playerData;

            dataIO = new DataIO();
            menuUtils = new MenuUtils(io);
        }

        public void RunGameLoop()
        {
            string magicNumber = game.GenerateMagicNumber();
            bool correctNumberGuessed = false;

            io.PrintString("Guess the magic number!");
            io.PrintString($"For testing purposes, the correct number is: {magicNumber}");

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

            AskPlayerToContinue(magicNumber);
        }

        private void AskPlayerToContinue(string magicNumber)
        {
            bool continueGame = true;

            playerData.UpdateGuesses(guesses);
            playerData.UpdateNumberOfGames();
            playerData.AddGameToScoreboard(game.GetGameName(), guesses);

            io.PrintString($"Correct! The Magic Number was {magicNumber}. It took {guesses} guesses.\nContinue (y/n)?");
            io.PrintPrompt();

            guesses = 0;

            while (continueGame)
            {
                string userInput = io.GetUserInput().ToLower();

                if (userInput == "y")
                {
                    RunGameLoop();
                }
                else if (userInput == "n")
                {
                    continueGame = false;
                    WinGame();
                }
                else
                {
                    io.PrintString(errorMessages.InvalidInput());
                }
            }
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
            playerData.UpdatePlayerData(playerData);

            io.PrintString($"--- Your average amount of guesses are: {playerData.AverageGuesses()}.");
            io.PrintString("--- Top List:");

            List<(string, int, double)> topPlayers = dataIO.GetTopPlayers();
            menuUtils.PrintTopPlayers(topPlayers);

            return;
        }
    }
}
