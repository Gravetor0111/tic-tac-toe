using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[Serializable]
public class HighScoreManager : MonoBehaviour
{
    public string filePath;
    public Dictionary<string, int> playerScores;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/high_scores.json";

        if (File.Exists(filePath))
        {
            Debug.Log("File Exists");
            FileAttributes attributes = File.GetAttributes(filePath);
            attributes &= ~FileAttributes.ReadOnly;
            File.SetAttributes(filePath, attributes);
            string jsonString = File.ReadAllText(filePath);
            playerScores = JsonUtility.FromJson<Dictionary<string, int>>(jsonString);
        }
        else
        {
            Debug.Log("File Created");
            playerScores = new Dictionary<string, int>();
        }
    }

    public void AddPlayerScore(string playerName, int scoreToAdd)
    {
        if (playerScores.ContainsKey(playerName))
        {
            playerScores[playerName] += scoreToAdd;
            Debug.Log("Added to existing record");
        }
        else
        {
            playerScores.Add(playerName, scoreToAdd);
            Debug.Log("Created New Record");
        }

        SavePlayerScores();
        Debug.Log("AddPlayerScore Called: " + playerName + scoreToAdd);
    }
    
    public void SavePlayerScores()
    {
        Debug.Log("Saved");
        string jsonString = JsonUtility.ToJson(playerScores);
        File.WriteAllText(filePath, jsonString);
    }
}