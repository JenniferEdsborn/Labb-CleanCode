using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.GameFactory
{
    public interface IGameFactory
    {
        IGame CreateGame();

        // Kommer ha metod, exempelvis CreateGame(); som returnar en IGame object
    }

    //
    // 
    // int magicNumber
    // int userGuess
    // etc.
}
