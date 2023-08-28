﻿using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Player;
using CodeQuest.Utilities;

namespace CodeQuest.Game
{
    public class MenuController : IMenuController
    {
        IConsoleIO io;
        IGameFactory masterMindFactory;
        IGameFactory mooGameFactory;

        ErrorMessages errorMessages = new ErrorMessages();
        MenuUtils menuUtils;
        PlayerData playerData;

        private readonly string[] menu;
        private readonly List<string> games;

        private Dictionary<int, Action> menuActions = new Dictionary<int, Action>();
        private Dictionary<int, Action> gameChoiceActions = new Dictionary<int, Action>();
        private Dictionary<string, IGameFactory> gameFactories = new Dictionary<string, IGameFactory>();

        public MenuController(IConsoleIO io, PlayerData playerData, IGameFactory masterMindFactory, IGameFactory mooGameFactory)
        {
            this.io = io;
            this.playerData = playerData;
            this.masterMindFactory = masterMindFactory;
            this.mooGameFactory = mooGameFactory;

            menu = new string[] { "Choose Game", "Show Scoreboard", "Change Player", "Settings", "Exit" };
            games = GameClassLocator.GetAvailableGames();
            menuUtils = new MenuUtils(io);

            gameFactories.Add("MasterMind", masterMindFactory);
            gameFactories.Add("MooGame", mooGameFactory);

            InitializeMenuActions();
            InitializeGameChoiceActions();
        }

        private void InitializeMenuActions()
        {
            menuActions.Add(1, ChooseGame);
            menuActions.Add(2, ShowScoreboard);
            menuActions.Add(3, InitiatePlayerCreation);
            menuActions.Add(4, Settings);
            menuActions.Add(5, io.Exit);
        }
        private void InitializeGameChoiceActions()
        {
            List<string> availableGames = GameClassLocator.GetAvailableGames();

            for (int i = 0; i < availableGames.Count; i++)
            {
                int gameChoice = i + 1;
                string gameName = availableGames[i];

                if (gameFactories.ContainsKey(gameName))
                {
                    IGameFactory factory = gameFactories[gameName];
                    gameChoiceActions.Add(gameChoice, () => StartGame(factory.CreateGame()));
                }
            }
        }

        public void DisplayMenu()
        {
            var menuIterator = new MenuIterator(menu);
            menuUtils.PrintMenuOptions(menuIterator);

            int menuChoice = menuUtils.GetValidMenuChoice(menu);
            ProcessMenuChoice(menuChoice);
        }

        public void ChooseGame()
        {
            var menuIterator = new MenuIterator(games.ToArray());
            menuUtils.PrintMenuOptions(menuIterator);

            int gameChoice = menuUtils.GetValidMenuChoice(games.ToArray());

            if (gameChoiceActions.ContainsKey(gameChoice))
            {
                gameChoiceActions[gameChoice].Invoke();
            }
            else
            {
                io.PrintString(errorMessages.InvalidInput());
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

        private void StartGame(IGame game)
        {
            GameController controller = new GameController(io, game, playerData);
            controller.GameMenu();
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
