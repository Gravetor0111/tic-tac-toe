using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DoublePlayerGameLogic : MonoBehaviour
{   
    public TMP_InputField player1Name, player2Name;
    public TextMeshProUGUI[] buttonList = new TextMeshProUGUI[9];
    public struct Player
    {   
        public string name;
        public string sign;
        public bool turn;
        public int wins;
    }

    public static Player p1, p2;
    public TextMeshProUGUI currentTurnPlayerTxt, player1Txt, resutTxt;
    public static string currentTurnPlayer, player1;
    void Start()
    {
        if (player1Txt == null || currentTurnPlayerTxt == null)
        {
            return;
        }
        else
        {
            player1Txt.text = p1.name + " Picks:";
            currentTurnPlayerTxt.text = currentTurnPlayer + "'s Turn";
        }
        p1.turn = false;
        p2.turn = false;
    }

    void Update()
    {
        if (currentTurnPlayerTxt == null)
        {
            return;
        }
        else
        {
            currentTurnPlayerTxt.text = currentTurnPlayer;
        }
    }

    public void MoveToGame()
    {
        if ((player1Name.text.Length == 0 || player2Name.text.Length == 0) || (player1Name.text == player2Name.text))
        {
            return;
        }
        else
        {
            SetNames();
            SceneManager.LoadScene("DoublePlayerLevel");
        }
    }
    void SetNames()
    {
        p1.name = player1Name.text;
        p2.name = player2Name.text;
        Debug.Log("P1: " + p1.name + " P2: " + p2.name);
    }

    public static void SetSymbols(string symbol)
    {   
        if (symbol == "X")
        {
            p1.sign = symbol;
            p2.sign = "O";
            Debug.Log(p1.name + " Selected " + p1.sign);
            Debug.Log(p2.name + " Selected " + p2.sign);
        }
        else
        {
            p1.sign = symbol;
            p2.sign = "X";
            Debug.Log(p1.name + " Selected " + p1.sign);
            Debug.Log(p2.name + " Selected " + p2.sign);
        }
        
    }

    public static void ShiftTurn()
    {
        if (!p1.turn && !p2.turn)
        {
            p1.turn = true;
            Debug.Log("FIRST TURN OF PLAYER " + p1.name);
            currentTurnPlayer = p1.name + "'s Turn: ";
        }
        else
        {
            if (p1.turn)
            {
                p1.turn = false;
                p2.turn = true;
                currentTurnPlayer = p2.name + "'s Turn: ";
            }
            else
            {
                p1.turn = true;
                p2.turn = false;
                currentTurnPlayer = p1.name + "'s Turn: ";
            }
        }
        
    }

    public string CheckWin()
    {
        Debug.Log("CHECK WIN CALLED!");
        if (buttonList[0].text == buttonList[1].text && buttonList[1].text == buttonList[2].text)
        {
            return buttonList[0].text;
        }
        else if (buttonList[3].text == buttonList[4].text && buttonList[4].text == buttonList[5].text)
        {
            return buttonList[3].text;
        }
        else if (buttonList[6].text == buttonList[7].text && buttonList[7].text == buttonList[8].text)
        {
            return buttonList[6].text;
        }
        else if (buttonList[0].text == buttonList[3].text && buttonList[3].text == buttonList[6].text)
        {
            return buttonList[0].text;
        }
        else if (buttonList[1].text == buttonList[4].text && buttonList[4].text == buttonList[7].text)
        {
            return buttonList[1].text;
        }
        else if (buttonList[2].text == buttonList[5].text && buttonList[5].text == buttonList[8].text)
        {
            return buttonList[2].text;
        }
        else if (buttonList[0].text == buttonList[4].text && buttonList[4].text == buttonList[8].text)
        {
            return buttonList[0].text;
        }
        else if (buttonList[2].text == buttonList[4].text && buttonList[4].text == buttonList[6].text)
        {
            return buttonList[2].text;
        }
        else
        {
            return "Going";
        }
    }

    public void DisableButtons()
    {
        foreach (var button in buttonList)
        {
            if (button.text != "X" && button.text != "O")
            {
                button.GetComponentInParent<Button>().interactable = false;
            }
        }
    }

    public bool CheckAvailableButtons()
    {
        for (int i=0; i<9; i++)
        {
            if (buttonList[i].GetComponentInParent<Button>().interactable == true)
            {
                return true;
            }
        }
        return false;
    }
    
    public void ShowResult(string winner)
    {
        if (winner == p1.name || winner == p2.name)
        {
            resutTxt.text = winner + " Won!";
            resutTxt.color = Color.green;
        }
        else
        {
            resutTxt.text = "Draw";
            resutTxt.color = Color.yellow;
        }
        
    }



    public void RestartGame()
    {
        foreach (var button in buttonList)
        {
            button.GetComponentInParent<Button>().interactable = true;
            button.text = "";
        }
        resutTxt.text = "";
    }

}
