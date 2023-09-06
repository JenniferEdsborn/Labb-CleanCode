using CodeQuest.Game;
using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using CodeQuest.Utilities;

namespace CodeQuest;

class Program
{
    static void Main(string[] args)
    {
        IConsoleIO io = new ConsoleIO();

        PlayerCreation playerCreation = new PlayerCreation(io);
        Player.PlayerData playerData = playerCreation.CreateOrLoadPlayer();

        IGameFactory masterMindFactory = new MasterMindFactory();
        IGameFactory mooGameFactory = new MooGameFactory();

        MenuController menuController = new MenuController(io, playerData, masterMindFactory, mooGameFactory);
        menuController.DisplayMenu();
    }
}