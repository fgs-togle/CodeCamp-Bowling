using BowlingApp;
using NUnit.Framework;

namespace NUnitTestBowling
{   
    public class DummyUserInteraction : IUserInteraction
    {
        public string bowlingMarks { get; set; }

        public string GetBowlingMarks()
        {
            return bowlingMarks; 
        }
    }

    class GameTests
    {
        private Game _subject;
        private IUserInteraction _dummyUserInteraction;

        public GameTests()
        {
            _dummyUserInteraction = new DummyUserInteraction();
            _subject = new Game(_dummyUserInteraction);
        }

        [Test]
        public void PlayGame_GivenPerfectGame_ReturnsPerfectScore()
        {
            _dummyUserInteraction.bowlingMarks = "XXXXXXXXXXXX";
            var result = _subject.PlayGame();
            Assert.That(result, Is.EqualTo(300));
        }

        [Test]
        public void PlayGame_GivenAllSparesAndBonusRollof5_ReturnsCorrectScore()
        {

            _dummyUserInteraction.bowlingMarks = "5/5/5/5/5/5/5/5/5/5/5";
            var result = _subject.PlayGame();
            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void PlayGame_GivenAllOpenFrames_ReturnsCorrectScore()
        {
            _dummyUserInteraction.bowlingMarks = "54545454545454545454";
            var result = _subject.PlayGame();
            Assert.That(result, Is.EqualTo(90));
        }

        [Test]
        public void PlayGame_GivenAllZeroes_ReturnsCorrectScore()
        {
            _dummyUserInteraction.bowlingMarks = "--------------------";
            var result = _subject.PlayGame();
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void PlayGame_GivenRandomScores_ReturnsCorrectScore()
        {
            _dummyUserInteraction.bowlingMarks = "545/X449/54XX726/X";
            var result = _subject.PlayGame();
            Assert.That(result, Is.EqualTo(154));
        }
    }
}
