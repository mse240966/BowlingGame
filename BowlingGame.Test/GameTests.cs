using NUnit.Framework;

namespace BowlingGame.Test
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [Test]
        public void Test_Game_Constructor_Successful()
        {
            Assert.DoesNotThrow(new TestDelegate(CreateNewGame));
        }

        [TestCase(0, 0)]
        [TestCase(1, 20)]
        public void First_Game(int numberOfPins, int expectedScore)
        {
            // Arrange
            CreateNewGame();

            // Act
            RollMany(20, numberOfPins);

            // Assert
            Assert.AreEqual(expectedScore, _game.Score());
        }

        [Test]
        public void Test_Rolling_A_Spare()
        {
            // Arrange
            CreateNewGame();

            // Act
            RollASpare();

            _game.Roll(3);

            RollMany(17, 0);

            // Assert
            Assert.AreEqual(16, _game.Score());
        }

        [Test]
        public void Test_Rolling_A_Stike()
        {
            // Arrange
            CreateNewGame();

            // Act
            RollAStrike();

            _game.Roll(3);
            _game.Roll(4);

            RollMany(16, 0);

            // Assert
            Assert.AreEqual(24, _game.Score());
        }

        private void CreateNewGame()
        {
            _game = new Game();
        }

        private void RollMany(int numberOfRolls, int numberOfPins)
        {
            for (int roll = 0; roll < numberOfRolls; roll++)
            {
                _game.Roll(numberOfPins);
            }
        }

        private void RollASpare()
        {
            _game.Roll(6);
            _game.Roll(4);
        }

        private void RollAStrike()
        {
            _game.Roll(10);
        }
    }
}
