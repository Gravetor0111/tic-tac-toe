using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HighScoreManager : MonoBehaviour
{
    public class HighScore {
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }

    public List<HighScore> highScores = new List<HighScore>();

    void Start()
    {
        // Add some sample high scores to the list
        highScores.Add(new HighScore { PlayerName = "Player 1", Score = 100 });
        highScores.Add(new HighScore { PlayerName = "Player 2", Score = 50 });
        highScores.Add(new HighScore { PlayerName = "Player 3", Score = 75 });

        // Sort the list in descending order based on the player's score
        List<HighScore> sortedHighScores = highScores.OrderByDescending(x => x.Score).ToList();

        // Display the high scores to the user
        foreach (HighScore highScore in sortedHighScores)
        {
            Debug.Log(highScore.PlayerName + ": " + highScore.Score);
        }
    }
}