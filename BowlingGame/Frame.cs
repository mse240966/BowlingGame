using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class Frame
    {
        private List<int> _rolls;

        public Frame()
        {
            _rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int Score()
        {
            var score = 0;
            for (int roll = 0; roll < _rolls.Count; roll++)
            {
                score += _rolls[roll];
            }

            return score;
        }

        public bool IsSpare()
        {
            return _rolls.Count == 2 && Score() == 10;
        }
    }
}
