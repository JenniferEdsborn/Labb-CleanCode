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
            game.Play();
            game.End();
        }



        // Responsible for using factory to create game objects

        // Interact with the factories through IGameFactory to recieve instances of IGame

    }
}
