using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Player
{
    public class PlayerData
    {
        public int NumberOfGames { get; set; }
        public int NumberOfGuesses { get; set; }
        public Dictionary<string,int> GameScores = new Dictionary<string,int>();

        public void AddGameToScoreBoard(string nameOfGame, int gameScore)
        {
            if (GameScores.ContainsKey(nameOfGame))
            {
                GameScores[nameOfGame] += gameScore;
            }
            else
            {
                GameScores.Add(nameOfGame, 1);
            }
        }

        public Dictionary<string,int> DisplayScoreBoard()
        {
            return GameScores;
        }

        public void UpdateGuesses(int guesses)
        {
            NumberOfGuesses += guesses;
            NumberOfGames++;
        }

        public double AverageGuesses()
        {
            return (double)NumberOfGuesses / NumberOfGames;
        }
    }
}
