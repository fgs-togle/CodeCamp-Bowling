
namespace BowlingApp
{
    public class Game
    {
        private IUserInteraction _userInteraction;
        
        public Game(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }
        
        public int PlayGame()
        {
            var scores = _userInteraction.GetBowlingMarks();
            
            if(!scores.Equals("0"))
            {
                var scoreCalculation = new Score();
                var scoreCard = scoreCalculation.CreateScoreCard(scores);
                return scoreCalculation.CalculateGrandScore(scoreCard);
            }

            return 0;
        }
    }
}
