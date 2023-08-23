using CodeQuest.Interfaces; 

namespace CodeQuest.Game
{
    public class MenuController : IMenuController
    {
        IConsoleIO io;

        private readonly string[] menu;
        private readonly string[] games;

        public MenuController(IConsoleIO io)
        {
            this.io = io;
            menu = new string[] { "Choose Game", "Show Scoreboard", "Change Player", "Settings", "Exit" };
            games = new string[] { "Moo-Game", "MasterMind" };
        }

        private void InitiatePlayerCreation()
        {
            // create new player
            // load player
        }

        public void DisplayMenu()
        {
            // iterate menu
            // ITERATOR design pattern
        }

        private void ChooseGame()
        {
            // iterate through games
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

        private void Exit()
        {
            io.Exit();
        }
    }
}
