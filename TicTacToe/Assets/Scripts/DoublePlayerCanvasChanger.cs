using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoublePlayerCanvasChanger : MonoBehaviour
{

    GameObject DPGLObj;
    DoublePlayerGameLogic dl;
    public Canvas selectCanvas, gameCanvas;
    public Button buttonX, buttonO;
    // Start is called before the first frame update
    void Start()
    {
        selectCanvas.enabled = true;
        gameCanvas.enabled = false;
        DPGLObj = GameObject.Find("GameTracker");
        dl = DPGLObj.GetComponent<DoublePlayerGameLogic>();
    }

    public void SelectedX()
    {
        ChangeButtonsAndCanvas();
        DoublePlayerGameLogic.SetSymbols("X");
        DoublePlayerGameLogic.ShiftTurn();
    }
    public void SelectedO()
    {
        ChangeButtonsAndCanvas();
        DoublePlayerGameLogic.SetSymbols("O");
        DoublePlayerGameLogic.ShiftTurn();
    }

    void ChangeButtonsAndCanvas()
    {
        buttonX.interactable = false;
        buttonO.interactable = false;
        selectCanvas.enabled = false;
        gameCanvas.enabled = true;
    }
}
