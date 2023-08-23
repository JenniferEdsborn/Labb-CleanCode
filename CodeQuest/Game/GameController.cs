using CodeQuest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Game
{
    public class GameController
    {
        IConsoleIO io;

        private readonly string[] gameMenu;

        public GameController(IConsoleIO io)
        {
            this.io = io;

            gameMenu = new string[] { "Start Game", "Help", "Back" };

            // populate gameMenu
            // create the game from factory
        }

        public void GameMenu()
        {
            // game name on top ex. MOO-GAME
            // iterate gameMenu
        }

        public void Help()
        {
            // instructions
        }

        public void Back()
        {
            // back to menuController
        }

        public void StartGame()
        {
            // game logic
        }
    }
}
