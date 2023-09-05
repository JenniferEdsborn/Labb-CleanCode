using CodeQuest.GameFactory;

namespace CodeQuest.Game.Tests
{
    [TestClass]
    public class MooGameTests
    {
        private IGameFactory? gameFactory;

        [TestInitialize]
        public void Initialize()
        {
            gameFactory = new MooGameFactory();
        }

        [TestMethod]
        public void GenerateMagicNumber_WhenCalled_ReturnsStringOfLengthFour()
        {
            IGame game = gameFactory.CreateGame();
            string magicNumber = game.GenerateMagicNumber();
            Assert.AreEqual(4, magicNumber.Length);
        }

        [TestMethod]
        public void GenerateMagicNumber_WhenCalled_ReturnsStringOfDigitsOnly()
        {
            IGame game = gameFactory.CreateGame();
            string magicNumber = game.GenerateMagicNumber();
            Assert.IsTrue(magicNumber.All(char.IsDigit));
        }

        [TestMethod]
        public void GenerateMagicNumber_WhenCalled_ReturnsStringOfUniqueDigits()
        {
            IGame game = gameFactory.CreateGame();
            string magicNumber = game.GenerateMagicNumber();
            var uniqueDigits = new HashSet<char>(magicNumber);
            Assert.AreEqual(4, uniqueDigits.Count);
        }

        [TestMethod]
        public void IsValidInput_WhenGivenFourCharacters_ReturnsTrue()
        {
            IGame game = gameFactory.CreateGame();
            Assert.IsTrue(game.IsValidInput("1234"));
        }

        [TestMethod]
        public void IsValidInput_WhenGivenLessThanFourCharacters_ReturnsFalse()
        {
            IGame game = gameFactory.CreateGame();
            Assert.IsFalse(game.IsValidInput("123"));
        }

        [TestMethod]
        public void GenerateFeedback_WhenGivenGuessAndMagicNumber_ReturnsCorrectFeedback()
        {
            IGame game = gameFactory.CreateGame();
            string magicNumber = "1234";
            string userGuess = "1562";
            string feedback = game.GenerateFeedback(userGuess, magicNumber);
            Assert.AreEqual("B,,C", feedback);
        }

        [TestMethod]
        public void GetGameName_WhenCalled_ReturnsMooGame()
        {
            IGame game = gameFactory.CreateGame();
            Assert.AreEqual("MooGame", game.GetGameName());
        }
    }
}