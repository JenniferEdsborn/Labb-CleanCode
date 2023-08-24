using CodeQuest.GameFactory;

namespace CodeQuest.Utilities
{
    public class GameFactoryProvider
    {
        public static List<IGameFactory> LoadGameFactories()
        {
            List<IGameFactory> factories = new List<IGameFactory>();

            // Load assemblies from a specific directory or use AppDomain.CurrentDomain.GetAssemblies()
            // Iterate through loaded assemblies and look for types implementing IGameFactory

            foreach (var assembly in loadedAssemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IGameFactory).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                    {
                        var factory = (IGameFactory)Activator.CreateInstance(type);
                        factories.Add(factory);
                    }
                }
            }

            return factories;
        }
    }
}
