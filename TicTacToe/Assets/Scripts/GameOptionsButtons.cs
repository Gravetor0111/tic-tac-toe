using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptionsButtons : MonoBehaviour
{

    GameObject DPGLObj;
    GameLogic dl;
    public AudioClip sound1, sound2;
    GameObject canvasChanger;

    void Start()
    {
        DPGLObj = GameObject.Find("GameTracker");
        dl = DPGLObj.GetComponent<GameLogic>();
        canvasChanger = GameObject.Find("CanvasChanger");

        if (sound1 != null)
            GetComponent<Button>().onClick.AddListener(PlaySound_Select);

        else
            GetComponent<Button>().onClick.AddListener(PlaySound_Deselect);

    }

    //Restart Button
    void PlaySound_Select()
    {
        AudioSource.PlayClipAtPoint(sound1, Camera.main.transform.position);
        dl.RestartGame();
    }

    void PlaySound_Deselect()
    {
        AudioSource.PlayClipAtPoint(sound2, Camera.main.transform.position);
        SceneManager.LoadScene("Title");
    }
    
}
