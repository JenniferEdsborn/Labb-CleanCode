using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Interfaces
{
    public interface IGameLogic
    {
        string CheckUserGuess();
        string GenerateFeedback();
        int GenerateMagicNumber();
        string GetUserGuess();
        void WinGame();
    }
}
