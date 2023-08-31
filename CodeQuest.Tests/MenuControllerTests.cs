using CodeQuest.Game;
using CodeQuest.GameFactory;
using CodeQuest.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeQuest.Tests
{
    [TestClass]
    public class MenuControllerTests
    {
        private Mock<IConsoleIO> mockIo;
        private Mock<IGameFactory> mockGameFactory;
        // need PlayerDaya mock-object

        [TestInitialize]
        public void Setup()
        {
            mockIo = new Mock<IConsoleIO>();
            mockGameFactory = new Mock<IGameFactory>();
        }

        [TestMethod]
        public void ChooseGame_CallsCorrectAction_WhenValidChoiceIsMade()
        {
            // Arrange
            var menuController = new MenuController(mockIo.Object, null, mockGameFactory.Object, mockGameFactory.Object);

            // Simulate user input
            mockIo.SetupSequence(io => io.GetUserInput())
                .Returns("1");

            // Act
            menuController.ChooseGame();

            // Assert
            // Ensure that the appropriate action was invoked based on the user's choice
            mockGameFactory.Verify(factory => factory.CreateGame(), Times.Once);
        }

        [TestMethod]
        public void ChooseGame_PrintsErrorMessage_WhenInvalidChoiceIsMade()
        {
            // Arrange
            var menuController = new MenuController(mockIo.Object, null, mockGameFactory.Object, mockGameFactory.Object);

            // Simulate user input
            mockIo.SetupSequence(io => io.GetUserInput())
                .Returns("5"); // Assuming there is no game choice 5

            // Act
            menuController.ChooseGame();

            // Assert
            // Ensure that an error message is printed to the console
            mockIo.Verify(io => io.PrintString(It.IsAny<string>()), Times.Once);
        }
    }
}
