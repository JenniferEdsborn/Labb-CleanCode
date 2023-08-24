namespace CodeQuest.Utilities.Tests
{
    [TestClass]
    public class GameClassLocatorTests
    {
        [TestMethod]
        public void GetAvailableGames_ReturnCorrectClassNames()
        { 
            List<string> expectedClassNames = new List<string>
            {
                "MasterMind",
                "MooGame"
            };

            List<string> actualClassNames = GameClassLocator.GetAvailableGames();

            CollectionAssert.AreEqual(expectedClassNames, actualClassNames);
        }
    }
}