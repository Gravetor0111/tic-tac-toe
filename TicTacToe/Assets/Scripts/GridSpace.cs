using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public AudioClip sound;
    public Button button;
    public TextMeshProUGUI buttonText;
    public string playerSide;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }
    public void SetSpace()
    {
        buttonText.text = playerSide;
        button.interactable = false;
    }
    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
    }
}
