namespace CodeQuest.GameFactory
{
    public class MooGameFactory : IGameFactory
    {
        public IGame CreateGame()
        {
            return new MooGame();
        }
    }
}
