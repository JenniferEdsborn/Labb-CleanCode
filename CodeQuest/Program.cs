using CodeQuest.Game;
using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Player;
using CodeQuest.Utilities;

namespace CodeQuest;

class Program
{
    static void Main(string[] args)
    {
        // FIXA init PlayerData
        PlayerData playerData = new PlayerData("Test");
        IConsoleIO io = new ConsoleIO();

        IGameFactory masterMindFactory = new MasterMindFactory();
        IGameFactory mooGameFactory = new MooGameFactory();

        MenuController menuController = new MenuController(io, playerData, masterMindFactory, mooGameFactory);
        menuController.DisplayMenu();
    }
}