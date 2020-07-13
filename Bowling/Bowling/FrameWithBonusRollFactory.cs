using System;

namespace BowlingApp
{
    public class FrameWithBonusRollFactory
    {
        private int _totalPinsCount;

        public FrameWithBonusRollFactory()
        {
            _totalPinsCount = 10;
        }
        
        public Frame Create(string bowlingMarks)
        {
            var rollsRemaining = bowlingMarks.Length;
            var roll1 = bowlingMarks[0].ToString();
            var roll2 = bowlingMarks[1].ToString();
            var roll3 = rollsRemaining == 3 ? bowlingMarks[2].ToString() : "0";

            return ScoreRollsWithBonus(roll1, roll2, roll3);
        }

        private Frame ScoreRollsWithBonus(string roll1, string roll2, string roll3)
        {
            var scoreRoll1 = BonusScoreCalculation(roll1);
            var scoreRoll2 = roll2.Equals(RollMarks.spareMark) ? _totalPinsCount - scoreRoll1 : BonusScoreCalculation(roll2);
            var scoreRoll3 = BonusScoreCalculation(roll3);

            return new Frame()
            {
                frameNumber = 10,
                firstRoll = scoreRoll1,
                secondRoll = scoreRoll2,
                bonusRoll = scoreRoll3,
                frameOutcome = RollTypes.final,
                frameScore = scoreRoll1 + scoreRoll2 + scoreRoll3
            };
        }


        private int BonusScoreCalculation(string roll)
        {
            switch (roll)
            {
                case (RollMarks.zeroPinsMark):
                    return 0;

                case (RollMarks.strikeMark):
                    return _totalPinsCount;

                default:
                    return Convert.ToInt32(roll);
            }
        }
    }
}
