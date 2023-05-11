using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    GameObject highScoreBoard;
    ScrollRect scrollView;
    TextMeshProUGUI scrollViewTxt;

    [System.Serializable]
    public class PlayerScore
    {
        public string playerName;
        public int score;

        public PlayerScore() {}

        public PlayerScore(string name, int score)
        {
            this.playerName = name;
            this.score = score;
        }
    }

    [System.Serializable]
    public class PlayerScores
    {
        public List<PlayerScore> players = new List<PlayerScore>();
    }

    private PlayerScores scores;

    private void Awake()
    {
        LoadScores();
    }

    private void Start()
    {
        highScoreBoard = GameObject.Find("HighScoreBoard");
        scrollView = highScoreBoard.GetComponentInChildren<ScrollRect>();
        scrollViewTxt = scrollView.GetComponentInChildren<TextMeshProUGUI>();
        if (scrollView == null || scrollViewTxt == null)
        {
            return;
        }
    }

    private void LoadScores()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerScores));

        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/highscores.xml"))
            {
                scores = (PlayerScores)serializer.Deserialize(reader);
            }
        }
        catch
        {
            scores = new PlayerScores();
        }
    }

    private void SaveScores()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerScores));

        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/highscores.xml"))
        {
            serializer.Serialize(writer, scores);
        }
    }

    public void AddPlayerScore(string playerName, int score)
    {
        if (playerName == "CPU")
        {
            return;
        }
        else
        {
            PlayerScore playerScore = scores.players.Find(x => x.playerName == playerName);

            if (playerScore != null)
            {
                playerScore.score += score;
            }
            else
            {
                playerScore = new PlayerScore(playerName, score);
                scores.players.Add(playerScore);
            }
        }
        scores.players.Sort((x, y) => y.score.CompareTo(x.score));
        SaveScores();
    }

    public void GetHighScores()
    {
        string highScores = "";

        for (int i = 0; i < scores.players.Count; i++)
        {
            highScores += (i + 1) + ". " + scores.players[i].playerName + " - " + scores.players[i].score + "\n\n";
        }
        scrollViewTxt.text = highScores;
    }
}