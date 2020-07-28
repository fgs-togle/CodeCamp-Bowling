using BowlingApp;
using NUnit.Framework;

namespace NUnitTestBowling
{
    class FrameNoBonusRollFactoryTests
    {
        private FrameNoBonusRollFactory _subject;

        public FrameNoBonusRollFactoryTests()
        {
            _subject = new FrameNoBonusRollFactory();
        }

        [Test]
        public void Create_GivenStrikeIn5thFrame_ReturnsScoreOf5thFrameBeforeScoreUpdates()
        {
            var result = _subject.Create(5, "X");
            Assert.That(result.frameScore, Is.EqualTo(10));
        }

        [Test]
        public void Create_GivenSpareIn1stFrame_ReturnsScoreOf1stFrameBeforeScoreUpdates()
        {
            var result = _subject.Create(1, "4/");
            Assert.That(result.frameScore, Is.EqualTo(10));
        }

        [Test]
        public void Create_GivenOpenRoll4thFrame_ReturnsScoreOf4thFrameBeforeScoreUpdates()
        {
            var result = _subject.Create(4, "32");
            Assert.That(result.frameScore, Is.EqualTo(5));
        }

        [Test]
        public void Create_GivenZeroPinsHitIn8thFrame_ReturnsScoreOf8thFrameBeforeScoreUpdates()
        {
            var result = _subject.Create(8, "--");
            Assert.That(result.frameScore, Is.EqualTo(0));
        }
    }
}
