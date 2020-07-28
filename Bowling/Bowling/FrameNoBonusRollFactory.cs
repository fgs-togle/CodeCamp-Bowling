using System;

namespace BowlingApp
{
    public class FrameNoBonusRollFactory
    {
        private int _totalPinsCount { get; set; }

        public FrameNoBonusRollFactory()
        {
            _totalPinsCount = 10;
        }

        public Frame Create(int frameNumber, string bowlingMarks)
        {
            return ScoreRolls(frameNumber, bowlingMarks);
        }

        private Frame ScoreRolls(int frameNumber, string bowlingMarks)
        {
            var rollOne = bowlingMarks[0].ToString();

            if (!rollOne.Equals(RollMarks.strikeMark))
            {
                var rollTwo = bowlingMarks[1].ToString();
                return ScoreRollsOneAndTwo(frameNumber, rollOne, rollTwo);
            }
            else
            {
                return ScoreStrikeOnRoll(frameNumber);
            }
        }

        private Frame ScoreRollsOneAndTwo(int frameNumber, string rollOne, string rollTwo)
        {
            if(rollTwo.Equals(RollMarks.spareMark))
            {
                return ScoreSpareOnRolls(frameNumber, rollOne, rollTwo);
            }
            else
            {
                return ScoreOpenFrameOnRolls(frameNumber, rollOne, rollTwo);
            }
        }

        private Frame ScoreStrikeOnRoll(int currentFrame)
        {
            return new Frame
            {
                frameNumber = currentFrame,
                firstRoll = _totalPinsCount,
                secondRoll = 0,
                bonusRoll = 0,
                frameScore = _totalPinsCount,
                frameOutcome = RollTypes.strike
            };
        }

        private Frame ScoreSpareOnRolls(int currentFrame, string rollOne, string rollTwo)
        {
            var numbericalScoreOfRollOne = rollOne.Equals(RollMarks.zeroPinsMark) ? 0 : Convert.ToInt32(rollOne);
            var numericalScoreOfRollTwo = _totalPinsCount - numbericalScoreOfRollOne;

            return new Frame
            {
                frameNumber = currentFrame,
                firstRoll = numbericalScoreOfRollOne,
                secondRoll = numericalScoreOfRollTwo,
                bonusRoll = 0,
                frameScore = numbericalScoreOfRollOne + numericalScoreOfRollTwo,
                frameOutcome = RollTypes.spare
            };
        }

        private Frame ScoreOpenFrameOnRolls(int currentFrame, string rollOne, string rollTwo)
        {
            var numbericalScoreOfRollOne = rollOne.Equals(RollMarks.zeroPinsMark) ? 0 : Convert.ToInt32(rollOne);
            var numericalScoreOfRollTwo = rollTwo.Equals(RollMarks.zeroPinsMark) ? 0 : Convert.ToInt32(rollTwo);

            return new Frame
            {
                frameNumber = currentFrame,
                firstRoll = numbericalScoreOfRollOne,
                secondRoll = numericalScoreOfRollTwo,
                bonusRoll = 0,
                frameScore = numbericalScoreOfRollOne + numericalScoreOfRollTwo,
                frameOutcome = RollTypes.open
            };

        }
    }
}
