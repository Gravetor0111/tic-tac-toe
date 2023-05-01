using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenuSounds : MonoBehaviour
{
    public AudioClip sound1, sound2;

    // Start is called before the first frame update
    void Start()
    {
        if (sound1 != null)
        GetComponent<Button>().onClick.AddListener(PlaySound_Select);

        else
        GetComponent<Button>().onClick.AddListener(PlaySound_Deselect);
    }

    void PlaySound_Select()
    {
        AudioSource.PlayClipAtPoint(sound1, Camera.main.transform.position);
    }

    void PlaySound_Deselect()
    {
        AudioSource.PlayClipAtPoint(sound2, Camera.main.transform.position);
    }
}
