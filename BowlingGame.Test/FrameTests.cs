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

        [Test]
        public void Test_IsSpare_Is_True()
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(5);
            _frame.Roll(5);

            // Assert
            Assert.True(_frame.IsSpare());
        }

        [Test]
        public void Test_IsSpare_Is_False()
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(5);
            _frame.Roll(4);

            // Assert
            Assert.False(_frame.IsSpare());
        }

        [Test]
        public void Test_Next_Frame_Is_True()
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(5);
            _frame.Roll(4);

            // Assert
            Assert.True(_frame.FrameComplete());
        }

        [Test]
        public void Test_Next_Frame_Is_False()
        {
            // Arrange
            CreateNewFrame();

            // Act
            _frame.Roll(5);

            // Assert
            Assert.False(_frame.FrameComplete());
        }
        private void CreateNewFrame()
        {
            _frame = new Frame();
        }

    }
}
