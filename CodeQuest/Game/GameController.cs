using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Player;
using CodeQuest.Utilities;
using System.ComponentModel.Design;

namespace CodeQuest.Game
{
    public class GameController
    {
        bool GameIsRunning = true;
        
        IConsoleIO io;
        IGameLogic gameLogic;
        IGame game;

        ErrorMessages errorMessages = new ErrorMessages();
        MenuUtils menuUtils;
        PlayerData playerData;
        
        private readonly string[] gameMenu;
        private Dictionary<int, Action> menuActions = new Dictionary<int, Action>();

        public GameController(IConsoleIO io, IGame game, PlayerData playerData)
        {
            this.io = io;
            this.game = game;
            this.playerData = playerData;

            gameLogic = new GameLogic(game, io, playerData);
            menuUtils = new MenuUtils(io);

            gameMenu = new string[] { "Play", "Help", "Back" };
            InitializeMenuActions();
        }

        private void InitializeMenuActions()
        {
            menuActions.Add(1, gameLogic.RunGameLoop);
            menuActions.Add(2, Help);
            menuActions.Add(3, Back);
        }

        public void GameMenu()
        {
            while(GameIsRunning)
            {
                io.PrintString(game.GetGameName());

                var menuIterator = new MenuIterator(gameMenu);
                menuUtils.PrintMenuOptions(menuIterator);

                int menuChoice = menuUtils.GetValidMenuChoice(gameMenu);
                ProcessMenuChoice(menuChoice);
            }
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

        public void Help()
        {
            var menuIterator = new MenuIterator(game.GetInstructions());
            menuUtils.PrintMenuOptions(menuIterator);
        }

        public void Back()
        {
            GameIsRunning = false;
        }
    }
}