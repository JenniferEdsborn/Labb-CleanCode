using CodeQuest.GameFactory;
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
        IDataIO dataIO;

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

            menu = new string[] { "Choose Game", "Show Scoreboard", "Exit" };
            games = GameClassLocator.GetAvailableGames();
            menuUtils = new MenuUtils(io);
            dataIO = new DataIO();

            gameFactories.Add("MasterMind", masterMindFactory);
            gameFactories.Add("MooGame", mooGameFactory);

            InitializeMenuActions();
            InitializeGameChoiceActions();
        }

        private void InitializeMenuActions()
        {
            menuActions.Add(1, ChooseGame);
            menuActions.Add(2, ShowScoreboard);
            menuActions.Add(3, io.Exit);
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
            io.PrintString("- - - - CODE QUEST - - - -");
            io.PrintString("Made by: Jennifer Edsborn, Jonathan Strand\n");
            io.PrintString($"Welcome, {playerData.Name}!");

            while (true)
            {
                io.PrintString("");
                var menuIterator = new MenuIterator(menu);
                menuUtils.PrintMenuOptions(menuIterator);

                int menuChoice = menuUtils.GetValidMenuChoice(menu);
                ProcessMenuChoice(menuChoice);
            }
        }

        private void ProcessMenuChoice(int menuChoice)
        {
            if (menuActions.ContainsKey(menuChoice))
            {
                menuActions[menuChoice].Invoke();
            }
            else
            {
                io.PrintString(errorMessages.InvalidInput());
            }
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

        private void StartGame(IGame game)
        {
            GameController controller = new GameController(io, game, playerData);
            controller.GameMenu();
        }

        private void ShowScoreboard()
        {
            double playerAverage = playerData.AverageGuesses();

            if (playerAverage == 0)
                io.PrintString($"--- Your average: 0");
            else
                io.PrintString($"--- Your average: {playerData.AverageGuesses()}");

            io.PrintString("--- Top List:");
            GetTopList();

            io.PrintString("--- Your best games:");
            GetBestGames();
        }

        private void GetTopList()
        {
            List<(string, double)> topPlayers = dataIO.GetTopPlayers();
            menuUtils.PrintTopPlayers(topPlayers);
        }

        private void GetBestGames()
        {
            IReadOnlyDictionary<string, List<int>> scoreboard = playerData.GetScoreboard();

            List<(string GameName, int Guesses)> allGamesAndGuesses = new List<(string, int)>();

            foreach (var entry in scoreboard)
            {
                string gameName = entry.Key;
                List<int> guessesForGame = entry.Value;

                foreach (var guessCount in guessesForGame)
                {
                    allGamesAndGuesses.Add((gameName, guessCount));
                }
            }

            allGamesAndGuesses.Sort((a, b) => a.Guesses.CompareTo(b.Guesses));

            var topTenGames = allGamesAndGuesses.Take(10);

            for (int i = 0; i < topTenGames.Count(); i++)
            {
                var gameName = topTenGames.ElementAt(i).GameName;
                var guessCount = topTenGames.ElementAt(i).Guesses;
                io.PrintString($"{i + 1}. {gameName.Trim()}: {guessCount} guesses");
            }
        }
    }
}
