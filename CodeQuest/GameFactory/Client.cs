namespace CodeQuest.GameFactory
{
    public class Client
    {
        private IGameFactory _gameFactory;

        public Client(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void PlayGame()
        {
            IGame game = _gameFactory.CreateGame();
        }
    }
}
