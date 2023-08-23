using CodeQuest.Interfaces;

namespace CodeQuest.Game
{
    public class PlayerCreationController
    {
        IConsoleIO io;

        public PlayerCreationController(IConsoleIO io)
        {
            this.io = io;
        }

        public void CreatePlayer()
        {

        }

        public void LoadPlayer()
        {

        }

        public void Exit()
        {
            io.Exit();
        }
    }

    // new game, load game, exit
}
