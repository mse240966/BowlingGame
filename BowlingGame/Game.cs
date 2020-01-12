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

            if (_frames[_currentFrame].FrameComplete())
            {
                StartNewFrame();
                return;
            }

            if (_currentFrame > 0 && _frames[_currentFrame-1].IsSpare())
            {
                _frames[_currentFrame-1].Roll(pins);
            }
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

        private void StartNewFrame()
        {
            _frames.Add(new Frame());
            _currentFrame++;
        }
    }
}
