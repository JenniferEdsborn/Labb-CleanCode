﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.GameFactory
{
    public class MasterMindFactory : IGameFactory
    {
        public IGame CreateGame()
        {
            return new MasterMind();
        }
    }
}
