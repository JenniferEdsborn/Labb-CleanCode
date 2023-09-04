using CodeQuest.Interfaces;
using CodeQuest.Player;
using CodeQuest.Utilities;

namespace CodeQuest.Game
{
    public class PlayerCreation
    {
        private readonly IConsoleIO io;
        private readonly IDataIO dataIO;

        private readonly MenuUtils menuUtils;
        private readonly ErrorMessages errorMessages;

        private readonly string[] menu;
        bool menuRunning = true;

        public PlayerCreation(IConsoleIO io)
        {
            this.io = io;
            menu = new string[] { "New Player", "Load Player", "Exit" };
            menuUtils = new MenuUtils(io);
            errorMessages = new ErrorMessages();
            dataIO = new DataIO();
        }

        public PlayerData CreateOrLoadPlayer()
        {
            PlayerData? playerData = null;

            while (menuRunning)
            {
                var menuIterator = new MenuIterator(menu);
                menuUtils.PrintMenuOptions(menuIterator);

                int menuChoice = menuUtils.GetValidMenuChoice(menu);

                switch (menuChoice)
                {
                    case 1:
                        io.PrintString("Enter user name:");
                        io.PrintPrompt();
                        string userName = io.GetUserName();
                        if (dataIO.GetPlayerNames().Contains(userName))
                        {
                            io.PrintString(errorMessages.UserNameAlreadyExist());
                        }
                        else
                        {
                            playerData = new PlayerData(userName);
                            dataIO.SavePlayerData(playerData);
                            menuRunning = false;
                        }
                        break;
                    case 2:
                        playerData = LoadExistingPlayer();
                        if (playerData == null)
                        {
                            errorMessages.PlayerDataDoesntExist();
                        }
                        else
                            menuRunning = false; 
                        break;
                    case 3:
                        io.Exit();
                        menuRunning = false;
                        break;
                    default:
                        io.PrintString(errorMessages.InvalidInput());
                        break;
                }

                if (playerData != null)
                {
                    break;
                }
            }

            playerData ??= new PlayerData("");
            return playerData;
        }

        private PlayerData LoadExistingPlayer()
        {
            List<string> playerNames = dataIO.GetPlayerNames();

            if (!playerNames.Any())
            {
                io.PrintString(errorMessages.PlayerDataDoesntExist());
                return null;
            }

            while (true)
            {
                var menuIterator = new MenuIterator(playerNames.ToArray());
                menuUtils.PrintMenuOptions(menuIterator);

                int menuChoice = menuUtils.GetValidMenuChoice(menu);

                string selectedPlayerName = playerNames[menuChoice - 1];
                PlayerData selectedPlayerData = dataIO.LoadPlayerData(selectedPlayerName);

                if (selectedPlayerData != null)
                {
                    return selectedPlayerData;
                }
                else
                {
                    errorMessages.PlayerDataDoesntExist();
                }
            }
        }
    }
}
