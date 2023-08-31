using CodeQuest.Interfaces;
using CodeQuest.Player;
using CodeQuest.Utilities;

namespace CodeQuest.Game
{
    public class PlayerCreation
    {
        private readonly IConsoleIO io;
        private readonly DataIO dataIO;

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
                        string userName = io.GetUserName();
                        playerData = new PlayerData(userName);
                        menuRunning = false;
                        break;
                    case 2:
                        // dataIO DO STUFF
                        playerData = new PlayerData("LOADED PLAYER");
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
    }
}
