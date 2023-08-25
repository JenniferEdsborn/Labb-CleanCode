using CodeQuest.GameFactory;
using System.Reflection;

namespace CodeQuest.Utilities
{
    public class GameClassLocator
    {
        public static List<string> GetAvailableGames()
        {
            List<string> availableGames = new List<string>();

            Assembly assembly = Assembly.GetExecutingAssembly();

            var interfaceType = typeof(IGame);
            var classesImplementingIGame = assembly.GetTypes()
                .Where(type => interfaceType.IsAssignableFrom(type) && !type.IsInterface);

            foreach (var game in classesImplementingIGame)
            {
                availableGames.Add(game.Name);
            }

            return availableGames;
        }
    }
}
