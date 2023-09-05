using CodeQuest.Interfaces;
using CodeQuest.Player;
using System.IO;
using System.Data;

namespace CodeQuest.Utilities.Tests
{
    [TestClass]
    public class DataIOTests
    {
        private DataIO dataIO;

        [TestInitialize]
        public void Initialize()
        {
            dataIO = new DataIO();
        }

        [TestMethod]
        public void SavePlayerData_LoadPlayerData()
        {
            PlayerData playerData = new PlayerData("TestPlayer");
            playerData.NumberOfGames = 5;
            playerData.NumberOfGuesses = 20;

            dataIO.SavePlayerData(playerData).Wait();

            PlayerData loadedPlayerData = dataIO.LoadPlayerData("TestPlayer");

            Assert.IsNotNull(loadedPlayerData);
            Assert.AreEqual("TestPlayer", loadedPlayerData.Name);
            Assert.AreEqual(5, loadedPlayerData.NumberOfGames);
            Assert.AreEqual(20, loadedPlayerData.NumberOfGuesses);

            dataIO.SavePlayerDataList().Wait();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PlayerData playerData = dataIO.LoadPlayerData("TestPlayer");
            if (playerData != null)
            {
                dataIO.DeletePlayerData("TestPlayer").Wait();
            }
        }
    }
}