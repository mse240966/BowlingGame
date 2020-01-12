using NUnit.Framework;

namespace BowlingGame.Test
{
    [TestFixture]
    public class FrameTests
    {
        public Frame _frame;

        [Test]
        public void Test_Frame_Constructor_Successful()
        {
            Assert.DoesNotThrow(new TestDelegate(CreateNewFrame));
        }

        [TestCase(7, 3, true)]
        [TestCase(7, 2, false)]
        public void Test_IsSpare_Returns_Correct_Value(int firstRoll, int secondRoll, bool expectedResult)
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(firstRoll);
            _frame.Roll(secondRoll);

            // Assert
            Assert.AreEqual(expectedResult, _frame.IsSpare());
        }

        [Test]
        public void Test_Frame_Complete_Is_True()
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(5);
            _frame.Roll(4);

            // Assert
            Assert.True(_frame.IsComplete());
        }

        [Test]
        public void Test_Frame_Complete_Is_True_With_A_Strike()
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(10);

            // Assert
            Assert.True(_frame.IsComplete());
        }

        [Test]
        public void Test_Frame_Complete_Is_False()
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(5);

            // Assert
            Assert.False(_frame.IsComplete());
        }

        private void CreateNewFrame()
        {
            _frame = new Frame();
        }
    }
}
