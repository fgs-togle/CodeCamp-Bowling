using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingApp
{
    public class Score
    {
        private int _frameNumberTotal;

        public Score()
        {
            _frameNumberTotal = 10;
        }

        public IEnumerable<Frame> CreateScoreCard(string bowlingMarks)
        {
            var frameNumber = 1;
            var bowlingMarksByFrame = OrganizeBowlingMarksByFrame(bowlingMarks);

            foreach (var marks in bowlingMarksByFrame)
            {
                if (!OnLastFrame(frameNumber))
                {
                    var frameNoBonusRoll = new FrameNoBonusRollFactory();
                    yield return frameNoBonusRoll.Create(frameNumber, marks.ToString());
                }
                else
                {
                    var frameWithBonusRoll = new FrameWithBonusRollFactory();
                    yield return frameWithBonusRoll.Create(marks.ToString());
                }

                frameNumber++;
            }
        }

        private bool OnLastFrame(int frameCount) => frameCount == _frameNumberTotal;

        private bool IsFrameCompleted(string bowlMark, string frameMarks) => bowlMark.Equals(RollMarks.strikeMark) || frameMarks.Length == 2;

        private IEnumerable<string> OrganizeBowlingMarksByFrame(string bowlingMarks)
        {
            var frameMarks = String.Empty;
            var bowlMark = String.Empty;
            var frameCount = 1;

            foreach (var mark in bowlingMarks)
            {
                bowlMark = mark.ToString();
                frameMarks += bowlMark;

                if (!OnLastFrame(frameCount))
                {
                    if (IsFrameCompleted(bowlMark, frameMarks))
                    {
                        yield return frameMarks;

                        frameMarks = String.Empty;
                        frameCount++;
                    }
                }
            }

            yield return frameMarks;
        }

        public int CalculateGrandScore(IEnumerable<Frame> framesCollection)
        {
            var framesValues = CalculateScoreCardTotals(framesCollection);
            var grandTotal = CalculateFramesGrandTotal(framesValues);
            return grandTotal;
        }
        
        public IEnumerable<int> CalculateScoreCardTotals(IEnumerable<Frame> framesCollection)
        {
            return UpdateFrameScoresForStrikesAndSpares(framesCollection);
        }

        private IEnumerable<int> UpdateFrameScoresForStrikesAndSpares(IEnumerable<Frame> framesCollection)
        {
            var frameNumber = 1;

            foreach (var frame in framesCollection)
            {
                var frameScore = frame.frameOutcome.Equals(RollTypes.strike) ? UpdateFrameScoreForAStrike(framesCollection, frameNumber) :
                                    frame.frameOutcome.Equals(RollTypes.spare) ? UpdateFrameScoreForASpare(framesCollection, frameNumber) :
                                    frame.frameScore;

                yield return frameScore;
                frameNumber++;
            }
        }

        private int UpdateFrameScoreForAStrike(IEnumerable<Frame> framesCollection, int frameNumber)
        {
            if (!OnLastFrame(frameNumber))
            {
                return ScoreAStrike(framesCollection, frameNumber);
            }
            else
            {
                return framesCollection.ElementAt(frameNumber - 1).frameScore;
            }
        }

        private int ScoreAStrike(IEnumerable<Frame> framesCollection, int frameNumber)
        {
            var currentFrame = framesCollection.ElementAt(frameNumber - 1);
            var oneFrameAfterCurrentFrame = framesCollection.ElementAt(frameNumber);

            if (oneFrameAfterCurrentFrame.frameOutcome == RollTypes.strike)
            {
                var twoFramesAfterCurrentFrame = framesCollection.ElementAt(frameNumber + 1);
                return currentFrame.frameScore + oneFrameAfterCurrentFrame.firstRoll + twoFramesAfterCurrentFrame.firstRoll;
            }
            else
            {
                return currentFrame.frameScore + oneFrameAfterCurrentFrame.firstRoll + oneFrameAfterCurrentFrame.secondRoll;
            }
        }

        private int UpdateFrameScoreForASpare(IEnumerable<Frame> framesCollection, int frameNumber)
        {
            if (!OnLastFrame(frameNumber))
            {
                var currentFrame = framesCollection.ElementAt(frameNumber - 1);
                var oneFrameAfterCurrentFrame = framesCollection.ElementAt(frameNumber);
                return currentFrame.frameScore += oneFrameAfterCurrentFrame.firstRoll;
            }
            else
            {
                return framesCollection.ElementAt(frameNumber - 1).frameScore;
            }
        }

        private int CalculateFramesGrandTotal(IEnumerable<int> framesScores)
        {
            return framesScores.Sum();
        }

    }
}
