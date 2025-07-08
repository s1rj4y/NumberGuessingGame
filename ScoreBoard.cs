using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    internal class ScoreBoard
    {        
        public float HighScore { get; }
        public string PlayerName { get; }

        private static List<ScoreBoard> score = new List<ScoreBoard>();

        public ScoreBoard(float highScore, string playerName)
        {
            HighScore = highScore;
            PlayerName = playerName;
        }

        public static void AddScore(float highScore, string playerName)
        {
            int maxScoreNum = 10;

            if (score.Count < maxScoreNum)
            {
                score.Add(new ScoreBoard(highScore, playerName));
                score.Sort((score1, score2) => score2.HighScore.CompareTo(score1.HighScore));
            }
            else if (highScore > score[score.Count - 1].HighScore)
            {
                score[score.Count - 1] = new ScoreBoard(highScore, playerName);
                score.Sort((score1, score2) => score2.HighScore.CompareTo(score1.HighScore));
            }
            else
            {
                Console.WriteLine("\nNot good enough for the Top 10!");
            }
        }

        public static void ShowScore()
        {
            Console.WriteLine("\n------- Top 10 -------\n");

            foreach (ScoreBoard entry in score)
            {
                Console.WriteLine($"{entry.HighScore} : {entry.PlayerName}");
            }
            
        }
    }
}
