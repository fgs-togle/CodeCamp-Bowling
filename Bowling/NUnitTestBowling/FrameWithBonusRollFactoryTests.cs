using NUnit.Framework;
using BowlingApp;

namespace NUnitTestBowling
{
    class FrameWithBonusRollFactoryTests
    {
        private FrameWithBonusRollFactory _subject;

        public FrameWithBonusRollFactoryTests()
        {
            _subject = new FrameWithBonusRollFactory();
        }

        [Test]
        public void Create_GivenPerfectTenthFrame_ReturnsScoreOfTenthFrame()
        {
            var result = _subject.Create(bowlingMarks: "XXX");
            Assert.That(result.frameScore, Is.EqualTo(30));
        }

        [Test]
        public void Create_GivenSpareAndBonusRollOf5Pins_ReturnsScoreOfTenthFrame()
        {
            var result = _subject.Create(bowlingMarks: "6/5");
            Assert.That(result.frameScore, Is.EqualTo(15));
        }

        [Test]
        public void Create_GivenSpareAndBonusRollOfAStrike_ReturnsScoreOfTenthFrame()
        {
            var result = _subject.Create(bowlingMarks: "5/X");
            Assert.That(result.frameScore, Is.EqualTo(20));
        }

        [Test]
        public void Create_GivenOpenFrameAndNoBonusRoll_ReturnsScoreOfTenthFrame()
        {
            var result = _subject.Create(bowlingMarks: "53");
            Assert.That(result.frameScore, Is.EqualTo(8));
        }

        [Test]
        public void Create_GivenSpareAndNoPinsOnBonusRoll_ReturnsScoreOfTenthFrame()
        {
            var result = _subject.Create(bowlingMarks: "4/-");
            Assert.That(result.frameScore, Is.EqualTo(10));
        }

    }
}
