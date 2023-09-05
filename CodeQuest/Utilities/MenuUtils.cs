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

        public void PrintTopPlayers(List<(string Name, int NumberOfGames, double AverageGuesses)> topPlayers)
        {
            for (int i = 0; i < topPlayers.Count; i++)
            {
                var (name, numberOfGames, avgGuesses) = topPlayers[i];
                io.PrintString($"{i + 1}. {name} - {numberOfGames} games - {avgGuesses:F2} average guesses");
            }
        }
    }
}
