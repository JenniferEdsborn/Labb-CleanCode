using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Utilities;
using System.ComponentModel.Design;

namespace CodeQuest.Game
{
    public class GameController
    {
        IConsoleIO io;
        IGameLogic gameLogic;
        IGame game;
        ErrorMessages errorMessages = new ErrorMessages();
        MenuUtils menuUtils;
        
        private readonly string[] gameMenu;
        private Dictionary<int, Action> menuActions = new Dictionary<int, Action>();

        public GameController(IConsoleIO io, IGame game)
        {
            this.io = io;
            this.game = game;
            gameLogic = new GameLogic(game, io);
            menuUtils = new MenuUtils(io);

            gameMenu = new string[] { "Start Game", "Help", "Back" };
            InitializeMenuActions();
        }

        private void InitializeMenuActions()
        {
            menuActions.Add(1, StartGame);
            menuActions.Add(2, Help);
            menuActions.Add(3, Back);
        }

        public void GameMenu()
        {
            io.PrintString(game.GetGameName());

            var menuIterator = new MenuIterator(gameMenu);
            menuUtils.PrintMenuOptions(menuIterator);

            int menuChoice = menuUtils.GetValidMenuChoice(gameMenu);
            ProcessMenuChoice(menuChoice);
        }

        private void ProcessMenuChoice(int choice)
        {
            if (menuActions.ContainsKey(choice))
            {
                menuActions[choice].Invoke();
            }
            else
            {
                io.PrintString(errorMessages.InvalidInput());
            }
        }

        public void StartGame()
        {
            int magicNumber = gameLogic.GenerateMagicNumber();
            int userGuess = 0;

            while (userGuess != magicNumber) // måste jämföras - så måste ha ett int-värde
            {
                gameLogic.GetUserGuess();
                if (// game logic is ok, number is 4 digits)
                    // userGuess = gameLogic.CheckUserGuess();
                    // >> generate feedback
                // errorMessage.NoWay();
                gameLogic.CheckUserGuess(); // return the int
                gameLogic.GenerateFeedback(); // on the int
            }

            gameLogic.WinGame();
            return;
        }

        public void Help()
        {
            var menuIterator = new MenuIterator(game.GetInstructions());
            menuUtils.PrintMenuOptions(menuIterator);
        }

        public void Back()
        {
            return;
        }
    }
}