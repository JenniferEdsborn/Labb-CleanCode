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
        IConsoleIO io = new ConsoleIO();

        PlayerCreation playerCreation = new PlayerCreation(io);
        PlayerData playerData = playerCreation.CreateOrLoadPlayer();

        IGameFactory masterMindFactory = new MasterMindFactory();
        IGameFactory mooGameFactory = new MooGameFactory();

        MenuController menuController = new MenuController(io, playerData, masterMindFactory, mooGameFactory);
        menuController.DisplayMenu();
    }
}

// LÄGGA IN ETT NYTT SPEL
// Skapa en factory för spelet (class GameName, samt class GameNameFactory) i mappen GameFactory, ärv från korrekt interfaces
// Instansiera interface för spelet i Program.cs
// Lägg till spelet i MainMenu constructor, samt i GameChoice()-metoden
// Klar!