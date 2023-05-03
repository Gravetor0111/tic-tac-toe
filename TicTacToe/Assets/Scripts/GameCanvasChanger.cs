using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasChanger : MonoBehaviour
{

    GameObject glObj;
    GameLogic gl;
    public Canvas selectCanvas, gameCanvas;
    public Button buttonX, buttonO;
    // Start is called before the first frame update
    void Start()
    {
        selectCanvas.enabled = true;
        gameCanvas.enabled = false;
        glObj = GameObject.Find("GameTracker");
        gl = glObj.GetComponent<GameLogic>();
    }

    public void SelectedX()
    {
        ChangeButtonsAndCanvas();
        GameLogic.SetSymbols("X");
        GameLogic.ShiftTurn();
    }
    public void SelectedO()
    {
        ChangeButtonsAndCanvas();
        GameLogic.SetSymbols("O");
        GameLogic.ShiftTurn();
    }

    void ChangeButtonsAndCanvas()
    {
        buttonX.interactable = false;
        buttonO.interactable = false;
        selectCanvas.enabled = false;
        gameCanvas.enabled = true;
    }
}
