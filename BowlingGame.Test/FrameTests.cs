using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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

        private void CreateNewFrame()
        {
            _frame = new Frame();
        }

        [Test]
        public void Test_IsSpare_Is_True()
        {
            // Act
            _frame.Roll(5);
            _frame.Roll(5);

            // Assert
            Assert.True(_frame.IsSpare());
        }

        [Test]
        public void Test_IsSpare_Is_False()
        {
            // Act
            _frame.Roll(5);
            _frame.Roll(4);

            // Assert
            Assert.True(_frame.IsSpare());
        }
    }
}
