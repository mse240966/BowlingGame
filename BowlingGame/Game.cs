using System.Collections.Generic;

namespace BowlingGame
{
    public class Game
    {
        private List<Frame> _frames;
        private int _currentFrame;

        public Game()
        {
            _frames = new List<Frame> { new Frame() };
            _currentFrame = 0;
        }

        public void Roll(int pins)
        {
            if (CurrentFrame().IsComplete())
            {
                StartNewFrame();
            }

            CurrentFrame().Roll(pins);

            if (OnlyOneFrame())
            {
                return;
            }

            if (PreviousFrame().IsSpare())
            {
                PreviousFrame().SpareRoll(pins);
            }

            if (PreviousFrame().IsStrike())
            {
                PreviousFrame().StrikeRoll(pins);
            }
        }

        public int Score()
        {
            var score = 0;

            _frames.ForEach(x => score += x.Score());

            return score;
        }

        private void StartNewFrame()
        {
            _frames.Add(new Frame());
            _currentFrame++;
        }

        private Frame CurrentFrame()
        {
            return _frames[_currentFrame];
        }

        private Frame PreviousFrame()
        {
            return _frames[_currentFrame-1];
        }

        private bool OnlyOneFrame()
        {
            return _currentFrame == 0;
        }
    }
}
