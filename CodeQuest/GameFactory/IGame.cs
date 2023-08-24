using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.GameFactory
{
    public interface IGame
    {
        void Start();
        void Play();
        void End();

        // Defines the common methods that all game objects should implement, just as mentioned before.

    }
}
