using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Utilities;

namespace CodeQuest.Game
{
    public class GameController
    {
        IConsoleIO io;
        IGameLogic gameLogic;
        IGame game;
        ErrorMessages errorMessages = new ErrorMessages();

        private readonly string[] gameMenu;

        public GameController(IConsoleIO io, IGame game)
        {
            this.io = io;
            this.game = game;
            gameLogic = new GameLogic(game);

            gameMenu = new string[] { "Start Game", "Help", "Back" };

            // populate gameMenu
            // create the game from factory
        }

        public void GameMenu()
        {
            io.PrintString(game.GetGameName());

            for (int i = 0; i < gameMenu.Length; i++)
            {
                io.PrintString($"{i + 1}{gameMenu[i]}");
            }


            // Error handling needed?

            int menuChoice = io.ConvertToInt(io.GetUserInput());
            while (true)
            {
                switch (menuChoice)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        Help();
                        break;
                    case 3:
                        return;
                    default:
                        io.PrintString(errorMessages.InvalidInput());
                        break;
                }
            }
        }

        public void Help()
        {
            io.PrintString(game.GetInstructions());
        }

        public void StartGame()
        {
            int number = gameLogic.GenerateMagicNumber();
            int userGuess = 1111;

            while (userGuess != number)
            {
                gameLogic.GetUserGuess();
                gameLogic.CheckUserGuess();
                gameLogic.GenerateFeedback();
            }
            gameLogic.WinGame();
            return;

            // game logic
        }
    }
}
