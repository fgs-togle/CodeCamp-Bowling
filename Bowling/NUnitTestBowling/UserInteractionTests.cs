using System;
using NUnit.Framework;
using BowlingApp;
using System.IO;

namespace NUnitTestBowling
{   
    class UserInteractionTests
    {
        private UserInteraction _subject;

        public UserInteractionTests()
        {
            _subject = new UserInteraction();
        }

        [Test]
        [TestCase("X X X X X X X X X X X X", "XXXXXXXXXXXX")]
        [TestCase("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/       5", "5/5/5/5/5/5/5/5/5/5/5/5/5")]
        [TestCase("5  4    54   54  54  54 54  54  54  5    2    54", "54545454545454545254")]

        public void GetBowlingMarks_GivenBowlingMarksWithSpaces_ReturnBowlingMarksWithNoSpaces(string marksWithSpaces, string marksWithoutSpaces)
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(marksWithSpaces))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    var result = _subject.GetBowlingMarks();
                    Assert.That(result, Is.EqualTo(marksWithoutSpaces));
                }
            }
        }

        [Test]
        [TestCase(" ", "0")]

        public void GetBowlingMarks_GivenNoInputOfBowlingMarks_ReturnZeroString(string noMarks, string zeroMark)
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(noMarks))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    var result = _subject.GetBowlingMarks();
                    Assert.That(result, Is.EqualTo(zeroMark));
                }
            }
        }
    }
}
