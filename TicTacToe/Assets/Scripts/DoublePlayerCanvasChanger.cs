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
        buttonX.interactable = false;
        buttonO.interactable = false;
        selectCanvas.enabled = false;
        gameCanvas.enabled = true;
        Debug.Log("X Selected");
        DoublePlayerGameLogic.p1.sign = "X";
        DoublePlayerGameLogic.p2.sign = "O";
        dl.ShiftTurn();
    }
    public void SelectedO()
    {
        buttonX.interactable = false;
        buttonO.interactable = false;
        selectCanvas.enabled = false;
        gameCanvas.enabled = true;
        Debug.Log("O Selected");
        DoublePlayerGameLogic.p1.sign = "O";
        DoublePlayerGameLogic.p2.sign = "X";
        dl.ShiftTurn();
    }
}
