﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Interfaces
{
    public interface IConsoleIO
    {
        void Clear();
        int ConvertToInt(string userInput);
        void Exit();
        string GetUserGuess(string userGuess);
        string GetUserName();
        bool IsNumber(string userInput);
        void PressAnyKey();
        void PrintString(string output);
    }
}