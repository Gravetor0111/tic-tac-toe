using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartDoublePlayerGame : MonoBehaviour
{
    public TMP_InputField player1Name, player2Name;
    public static string p1, p2;
    public void StartGame()
    {
        if (player1Name.text.Length == 0 || player2Name.text.Length == 0)
        {
            return;
        }
        else
        {
            p1 = player1Name.text;
            p2 = player2Name.text;
            SceneManager.LoadScene("DoublePlayerLevel");
        }
    }

}
