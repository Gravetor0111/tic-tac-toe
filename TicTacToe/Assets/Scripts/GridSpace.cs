using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    GameObject GLObj;
    GameLogic gl;
    HighScoreManager hs;

    public AudioClip sound;
    public Button button;
    public TextMeshProUGUI buttonText;
    public string playerSide;
    

    void Awake()
    {
        GLObj = GameObject.Find("GameTracker");
        gl = GLObj.GetComponent<GameLogic>();
        hs = GLObj.GetComponent<HighScoreManager>();
    }
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }
    public void SetSpace()
    {
        if (GameLogic.availableMoves <= 0)
        {
            return;
        }
        else
        {
            GameLogic.availableMoves--;
        }
        
        if (GameLogic.p1.turn)
        {
            playerSide = GameLogic.p1.sign;
        }
        else
        {
            playerSide = GameLogic.p2.sign;
        }
        buttonText.text = playerSide;
        button.interactable = false;
        GameStatus();
    }
    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
    }

    void GameStatus()
    {
        string winSign = gl.CheckWin();
        if (winSign == "X" || winSign == "O")
        {
            gl.DisableButtons();
            if (winSign == GameLogic.p1.sign)
            {
                gl.ShowResult(GameLogic.p1.name);
                hs.AddPlayerScore(GameLogic.p1.name, 100);
            }
            else
            {
                gl.ShowResult(GameLogic.p2.name);
                hs.AddPlayerScore(GameLogic.p2.name, 100);
            }
        }
        else if(!(winSign == "X" || winSign == "O") && !gl.CheckAvailableButtons())
        {
            gl.ShowResult("Draw");
        }
        else
        {
            GameLogic.ShiftTurn();
        }
        
    }
}
