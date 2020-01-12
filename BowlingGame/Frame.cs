using System.Collections.Generic;

namespace BowlingGame
{
    public class Frame
    {
        private readonly List<int> _rolls;
        private int _spareBonus;
        private int _strikeBonus;

        public Frame()
        {
            _rolls = new List<int>();
            _spareBonus = 0;
            _strikeBonus = 0;
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

            return score + _spareBonus + _strikeBonus;
        }

        public void SpareRoll(int pins)
        {
            _spareBonus = pins;
        }

        public void StrikeRoll(int pins)
        {
            _strikeBonus += pins;
        }

        public bool IsSpare()
        {
            return NumberOfRolls(2) && FirstRollAndSecondRoll() == 10 && _spareBonus == 0;
        }

        public bool IsStrike()
        {
            return NumberOfRolls(1) && FirstRoll() == 10;
        }

        public bool IsComplete()
        {
            return NumberOfRolls(2) || IsStrike();
        }

        private bool NumberOfRolls(int rolls)
        {
            return _rolls.Count == rolls;
        }

        private int FirstRoll()
        {
            return _rolls[0];
        }

        private int FirstRollAndSecondRoll()
        {
            return _rolls[0] + _rolls[1];
        }
    }
}
