using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class Game
    {
        private List<Frame> _frames;
        private int _currentFrame;

        public Game()
        {
            _frames = new List<Frame>
            {
                new Frame()
            };
            _currentFrame = 0;
        }

        public void Roll(int pins)
        {
            _frames[_currentFrame].Roll(pins);
        }

        public int Score()
        {
            var score = 0;
            for(int frame=0; frame < _frames.Count; frame++)
            {
                score += _frames[frame].Score();
            }

            return score;
        }
    }
}
