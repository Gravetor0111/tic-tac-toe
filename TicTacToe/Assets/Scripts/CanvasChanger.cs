using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas titleCanvas, menuCanvas;

    void Start()
    {
        titleCanvas.enabled = true;
        menuCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {   
            if (titleCanvas.enabled)
            {
                titleCanvas.enabled = false;
                menuCanvas.enabled = true;
            }
        }
    }
}
