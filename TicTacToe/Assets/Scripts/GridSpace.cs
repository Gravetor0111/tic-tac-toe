using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    GameObject DPGLObj;
    DoublePlayerGameLogic dl;
    HighScoreManager hs;

    public AudioClip sound;
    public Button button;
    public TextMeshProUGUI buttonText;
    public string playerSide;
    

    void Awake()
    {
        DPGLObj = GameObject.Find("GameTracker");
        dl = DPGLObj.GetComponent<DoublePlayerGameLogic>();
        hs = DPGLObj.GetComponent<HighScoreManager>();
    }
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }
    public void SetSpace()
    {
        if (DoublePlayerGameLogic.p1.turn)
        {
            playerSide = DoublePlayerGameLogic.p1.sign;
        }
        else
        {
            playerSide = DoublePlayerGameLogic.p2.sign;
        }
        buttonText.text = playerSide;
        Debug.Log(playerSide);
        GameStatus();
        button.interactable = false;
        
        
    }
    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
    }

    void GameStatus()
    {
        string winSign = dl.CheckWin();
        if (winSign == "X" || winSign == "O")
        {
            Debug.Log(winSign + " WON");
            dl.DisableButtons();
            if (winSign == DoublePlayerGameLogic.p1.sign)
            {
                dl.ShowResult(DoublePlayerGameLogic.p1.name);
                Debug.Log(DoublePlayerGameLogic.p1.name + " WON");
                hs.AddPlayerScore(DoublePlayerGameLogic.p1.name, 100);
            }
            else
            {
                dl.ShowResult(DoublePlayerGameLogic.p2.name);
                Debug.Log(DoublePlayerGameLogic.p2.name + " WON");
                hs.AddPlayerScore(DoublePlayerGameLogic.p2.name, 100);
            }
        }
        else if(!dl.CheckAvailableButtons())
        {
            Debug.Log("DRAW");
            dl.ShowResult("Draw");
        }
        else
        {
            DoublePlayerGameLogic.ShiftTurn();
        }
    }
}
