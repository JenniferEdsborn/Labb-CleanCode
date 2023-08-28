using CodeQuest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Utilities
{
    public class MenuUtils
    {
        private IConsoleIO io;

        public MenuUtils(IConsoleIO io)
        {
            this.io = io;
        }

        public void PrintMenuOptions(IEnumerable<string> menuItems)
        {
            foreach (var menuItem in menuItems)
            {
                io.PrintString(menuItem);
            }
        }

        public int GetValidMenuChoice(string[] menu)
        {
            while (true)
            {
                string userInput = io.GetUserInput();

                if (int.TryParse(userInput, out int menuChoice) && menuChoice >= 1 && menuChoice <= menu.Length)
                {
                    return menuChoice;
                }

                io.PrintString("Invalid input. Please enter a valid menu choice.");
            }
        }
    }
}
