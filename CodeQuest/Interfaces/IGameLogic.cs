using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Interfaces
{
    public interface IGameLogic
    {
        void CheckUserGuess();
        string GenerateFeedback();
        int GenerateMagicNumber();
        void GetUserGuess();
        void WinGame();
    }
}
