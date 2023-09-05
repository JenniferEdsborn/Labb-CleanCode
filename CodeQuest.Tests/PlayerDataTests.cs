using CodeQuest.GameFactory;
using CodeQuest.Player;
using CodeQuest.Utilities;
using System.Text.RegularExpressions;

namespace CodeQuest.Game.Tests
{
    [TestClass]
    public class PlayerDataTests
    {
        private PlayerData playerData;
        DataIO dataIO;

        [TestInitialize]
        public void Initialize()
        {
            playerData = new PlayerData("TestPlayer");
            dataIO = new DataIO();
        }

        [TestMethod]
        public void UpdatePlayerData_Should_Update_Player_Data()
        {
            PlayerData newPlayerData = new PlayerData("UpdatedPlayer");
            newPlayerData.NumberOfGames = 5;
            newPlayerData.NumberOfGuesses = 20;

            playerData.UpdatePlayerData(newPlayerData);

            Assert.AreEqual("UpdatedPlayer", playerData.Name);
            Assert.AreEqual(5, playerData.NumberOfGames);
            Assert.AreEqual(20, playerData.NumberOfGuesses);
        }

        [TestMethod]
        public void AddGameToScoreboard_Should_Add_Game_To_Scoreboard()
        {
            playerData.AddGameToScoreboard("Game1", 5);
            playerData.AddGameToScoreboard("Game2", 8);

            IReadOnlyDictionary<string, List<int>> scoreboard = playerData.GetScoreboard();
            Assert.IsTrue(scoreboard.ContainsKey("Game1"));
            Assert.IsTrue(scoreboard.ContainsKey("Game2"));
            Assert.AreEqual(5, scoreboard["Game1"][0]);
            Assert.AreEqual(8, scoreboard["Game2"][0]);
        }

        [TestMethod]
        public void AverageGuesses_Should_Calculate_Average_Guesses()
        {
            playerData.NumberOfGames = 3;
            playerData.NumberOfGuesses = 15;

            double averageGuesses = playerData.AverageGuesses();

            Assert.AreEqual(5.0, averageGuesses);
        }

        [TestCleanup]
        public void Cleanup()
        {
            PlayerData playerData = dataIO.LoadPlayerData("TestPlayer");

            if (playerData != null)
            {
                dataIO.DeletePlayerData("TestPlayer").Wait();
            }

            PlayerData playerData2 = dataIO.LoadPlayerData("UpdatedPlayer");

            if (playerData2 != null)
            {
                dataIO.DeletePlayerData("UpdatedPlayer").Wait();
            }
        }
    }
}