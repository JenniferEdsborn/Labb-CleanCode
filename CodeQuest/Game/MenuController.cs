using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Utilities;

namespace CodeQuest.Game
{
    public class MenuController : IMenuController
    {
        IConsoleIO io;
        ErrorMessages errorMessages = new ErrorMessages();
        MenuUtils menuUtils;

        private readonly string[] menu;
        private readonly List<string> games;

        private Dictionary<int, Action> menuActions = new Dictionary<int, Action>();

        public MenuController(IConsoleIO io)
        {
            this.io = io;
            menu = new string[] { "Choose Game", "Show Scoreboard", "Change Player", "Settings", "Exit" };
            games = GameClassLocator.GetAvailableGames();
            menuUtils = new MenuUtils(io);
            InitializeMenuActions();
        }

        private void InitializeMenuActions()
        {
            menuActions.Add(1, ChooseGame);
            menuActions.Add(2, ShowScoreboard);
            menuActions.Add(3, InitiatePlayerCreation);
            menuActions.Add(4, Settings);
            menuActions.Add(5, io.Exit);
        }

        public void DisplayMenu()
        {
            var menuIterator = new MenuIterator(menu);
            menuUtils.PrintMenuOptions(menuIterator);

            int menuChoice = menuUtils.GetValidMenuChoice(menu);
            ProcessMenuChoice(menuChoice);
        }

        private void ChooseGame()
        {
            var menuIterator = new MenuIterator(games.ToArray());
            menuUtils.PrintMenuOptions(menuIterator);

            // get game choice, create game from factory

            StartGame(); // start the game
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

        private void StartGame()
        {
            // GameController tar över
        }

        private void Settings()
        {
            // change color of text
        }

        private void ShowScoreboard()
        {

        }
        private void InitiatePlayerCreation()
        {
            // create new player
            // load player
        }
    }
}
