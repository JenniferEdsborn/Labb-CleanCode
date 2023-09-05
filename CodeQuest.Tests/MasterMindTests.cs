using CodeQuest.GameFactory;
using System.Text.RegularExpressions;

namespace CodeQuest.Game.Tests
{
    [TestClass]
    public class MasterMindTests
    {
        private IGameFactory gameFactory;

        [TestInitialize]
        public void Initialize()
        {
            gameFactory = new MasterMindFactory();
        }

        [TestMethod]
        public void GenerateFeedback_CorrectGuess_ReturnsBBBB()
        {
            IGame game = gameFactory.CreateGame();
            string magicNumber = "1234";
            string userGuess = "1234";

            string feedback = game.GenerateFeedback(magicNumber, userGuess);

            Assert.AreEqual("BBBB", feedback);
        }

        [TestMethod]
        public void GenerateFeedback_SomeCorrectDigitsInWrongPlace_ReturnsCCC()
        {
            IGame game = gameFactory.CreateGame();
            string magicNumber = "1235";
            string userGuess = "4321";

            string feedback = game.GenerateFeedback(magicNumber, userGuess);

            Assert.AreEqual(",CCC", feedback);
        }

        [TestMethod]
        public void GenerateFeedback_NoCorrectDigits_ReturnsCommas()
        {
            IGame game = gameFactory.CreateGame();
            string magicNumber = "1234";
            string userGuess = "5678";

            string feedback = game.GenerateFeedback(magicNumber, userGuess);

            Assert.AreEqual(",,,,", feedback);
        }

        [TestMethod]
        public void IsValidInput_ValidInput_ReturnsTrue()
        {
            IGame game = gameFactory.CreateGame();
            string validGuess = "1234";

            bool isValid = game.IsValidInput(validGuess);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsValidInput_InvalidInput_ReturnsFalse()
        {
            IGame game = gameFactory.CreateGame();
            string invalidGuess = "12";

            bool isValid = game.IsValidInput(invalidGuess);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void GenerateMagicNumber_ReturnsValidNumber()
        {
            IGame game = gameFactory.CreateGame();

            string magicNumber = game.GenerateMagicNumber();

            Assert.AreEqual(4, magicNumber.Length);
            Assert.IsTrue(Regex.IsMatch(magicNumber, "^[0-5]+$"));
        }
    }
}