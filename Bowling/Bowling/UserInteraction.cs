using System;
using System.Text.RegularExpressions;

namespace BowlingApp
{   public class UserInteraction : IUserInteraction
    {
        public string bowlingMarks { get; set; }

        public string GetBowlingMarks()
        {
            DisplayUserEntryScreen();
            var bowlingMarks = Console.ReadLine();
            bowlingMarks = RemoveEmptySpaces(bowlingMarks).ToUpper();

            if (bowlingMarks.Length == 0)
            {
                bowlingMarks = "0";
                DisplayZeroUserInputReceived();
            }

            return bowlingMarks;
        }

        private string RemoveEmptySpaces(string marks)
        {
            return Regex.Replace(marks, @"\s+", String.Empty);
        }

        private void DisplayUserEntryScreen()
        {
            Console.WriteLine("******************************************************");
            Console.WriteLine("******************************************************");
            Console.WriteLine("*                                                    *");
            Console.WriteLine("*     ()  ()  ()  ()                                 *");
            Console.WriteLine("*       ()  ()  ()         BOWLING                   *");
            Console.WriteLine("*         ()  ()            SCORE                    *");
            Console.WriteLine("*           ()            CALCULATOR                 *");
            Console.WriteLine("*                                                    *");
            Console.WriteLine("*                                                    *");
            Console.WriteLine("******************************************************");
            Console.WriteLine("******************************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter your marks for all 10 bowling frames.  (X = STRIKE   / = SPARE   - = ZERO)");
            Console.WriteLine("Scores can be entered as one continuous string or with spaces");
            Console.WriteLine("(ex: XXXXXXXXXXXX OR 5/ 5/ X 5/ 52 5/ 5/ 54 5/ 5/5)");
        }

        private void DisplayZeroUserInputReceived()
        {
            Console.WriteLine("No scores were entered and a score total could not be calculated.");
            Console.WriteLine("Press Any Key To Close This Window...");
            Console.ReadLine();
        }
        public void DisplayGrandTotalScore(int grandTotal)
        {
            Console.WriteLine($"Final Bowling Score is : {grandTotal}");
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Close This Window...");
            Console.ReadLine();
        }


    }
}
