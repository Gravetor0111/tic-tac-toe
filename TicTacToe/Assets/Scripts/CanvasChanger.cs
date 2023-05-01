using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas titleCanvas, menuCanvas, singlePlayerCanvas, doublePlayerCanvas, highScoreCanvas;

    void Awake()
    {
        titleCanvas.enabled = false;
        menuCanvas.enabled = false;
        singlePlayerCanvas.enabled = false;
        doublePlayerCanvas.enabled = false;
        highScoreCanvas.enabled = false;
    }
    void Start()
    {
        titleCanvas.enabled = true;
    }

    public void GoToMenu()
    {
        if (titleCanvas.enabled)
        {
            titleCanvas.enabled = false;
            menuCanvas.enabled = true;
        }
    }

    public void GoToSinglePlayerMenu()
    {
        if (menuCanvas.enabled)
        {
            menuCanvas.enabled = false;
            singlePlayerCanvas.enabled = true;
        }
    }

    public void GoToDoublePlayerMenu()
    {
        if (menuCanvas.enabled)
        {
            menuCanvas.enabled = false;
            doublePlayerCanvas.enabled = true;
        }
    }

    public void GoToHighScoreMenu()
    {
        if (menuCanvas.enabled)
        {
            menuCanvas.enabled = false;
            highScoreCanvas.enabled = true;
        }
    }

    public void GoBackToMenu()
    {
        singlePlayerCanvas.enabled = false;
        doublePlayerCanvas.enabled = false;
        highScoreCanvas.enabled = false;
        menuCanvas.enabled = true;
    }

    public void StartSinglePlayer()
    {
        
    }

    public void StartDoublePlayer()
    {
        
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
