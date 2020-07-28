
namespace BowlingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var getScores = new UserInteraction();
            Game bowling = new Game(getScores);
            var score = bowling.PlayGame();
            getScores.DisplayGrandTotalScore(score);
        }
    }
}
