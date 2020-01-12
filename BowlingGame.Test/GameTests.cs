using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Test
{
    public class GameTests
    {
        private Game _game;

        [Test]
        public void Test_Game_Constructor_Successful()
        {
            Assert.DoesNotThrow(new TestDelegate(CreateNewGame));
        }

        private void CreateNewGame()
        {
            _game = new Game();
        }
    }
}
