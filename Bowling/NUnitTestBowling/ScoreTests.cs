using System.Linq;
using BowlingApp;
using NUnit.Framework;

namespace NUnitTestBowling
{
    class ScoreTests
    {
        private Score _subject;

        public ScoreTests()
        {
            _subject = new Score();
        }
        
        [Test]
        public void CreateScoreCard_GivenPerfectGame_ReturnsTenFrameObjectsInCollection()
        {
            var result = _subject.CreateScoreCard("XXXXXXXXXXXX");
            Assert.That(result.Count<Frame>, Is.EqualTo(10));
        }

        [Test]
        public void CreateScoreCard_GivenAllSparesPlusBonusRollOfFive_ReturnsTenFrameObjectsInCollection()
        {
            var result = _subject.CreateScoreCard("5/5/5/5/5/5/5/5/5/5/5");
            Assert.That(result.Count, Is.EqualTo(10));
        }

        [Test]
        public void CreateScoreCard_GivenAllOpenFrames_ReturnsTenFrameObjectsInCollection()
        {
            var result = _subject.CreateScoreCard("54545454545454545454");
            Assert.That(result.Count, Is.EqualTo(10));
        }

        [Test]
        public void CreateScoreCard_GivenRandomScores_ReturnsTenFrameObjectsInCollection()
        {
            var result = _subject.CreateScoreCard("545/X449/54XX72XXX");
            Assert.That(result.Count, Is.EqualTo(10));
        }

        [Test]
        public void CalculateScoreCardTotals_GivenRandomScores_ReturnsCorrectGrandTotal()
        {
            var framesCollection = _subject.CreateScoreCard("545/X449/54XX72XXX");
            var result = _subject.CalculateGrandScore(framesCollection);
            Assert.That(result, Is.EqualTo(164));
        }

        [Test]
        public void CalculateScoreCardTotals_GivenPerfectGame_ReturnsCorrectGrandTotal()
        {
            var framesCollection = _subject.CreateScoreCard("XXXXXXXXXXXX");
            var result = _subject.CalculateGrandScore(framesCollection);
            Assert.That(result, Is.EqualTo(300));
        }

        [Test]
        public void CalculateScoreCardTotals_GivenAllOpenFrames_ReturnsCorrectUpdatedScoreForFrameFive()
        {
            var framesCollection = _subject.CreateScoreCard("54545454545454545454");
            var grandTotal = _subject.CalculateGrandScore(framesCollection);
            var result = framesCollection.ElementAt(4).frameScore;
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void CalculateScoreCardTotals_GivenPerfectGame_ReturnsCorrectUpdatedScoreForFrameFour()
        {
            var framesCollection = _subject.CreateScoreCard("XXXXXXXXXXXX");
            var frameTotal = _subject.CalculateScoreCardTotals(framesCollection);
            var result = frameTotal.ElementAt(3);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void CalculateScoreCardTotals_GivenAllSparesPlusBonusRollOfFive_ReturnsCorrectUpdatedScoreForFrameEight()
        {
            var framesCollection = _subject.CreateScoreCard("5/5/5/5/5/5/5/5/5/5/5");
            var frameTotal = _subject.CalculateScoreCardTotals(framesCollection);
            var result = frameTotal.ElementAt(7);
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void CalculateScoreCardTotals_GivenRandomScores_ReturnsCorrectUpdatedScoreForFrameTwoThatContainsASpareFollowedByAStrike()
        {
            var framesCollection = _subject.CreateScoreCard("545/X449/54XX72XXX");
            var frameTotal = _subject.CalculateScoreCardTotals(framesCollection);
            var result = frameTotal.ElementAt(1);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void CalculateScoreCardTotals_GivenRandomScores_ReturnsCorrectUpdatedScoreForFrameSevenThatContainsAStrikeFollowedByAStrikeAndOpenFrame()
        {
            var framesCollection = _subject.CreateScoreCard("545/X449/54XX72XXX");
            var frameTotal = _subject.CalculateScoreCardTotals(framesCollection);
            var result = frameTotal.ElementAt(6);
            Assert.That(result, Is.EqualTo(27));
        }


    }
}
