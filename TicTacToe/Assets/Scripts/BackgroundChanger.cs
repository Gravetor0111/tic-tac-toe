using UnityEngine;
using System;

public class BackgroundChanger : MonoBehaviour
{
    private enum TimeOfDay { d, e, n }
    private TimeOfDay currentTimeOfDay;
    public GameObject Sky, BigMountain1, BigMountain2, SmallMountain1, SmallMountain2, SmallMountain3, Cloud1, Cloud2, Cloud3;
    private SpriteRenderer[] bgObjects;


    void Start()
    {
        bgObjects = GetComponentsInChildren<SpriteRenderer>();

        DateTime now = DateTime.Now;

        // Determine which time of day it is
        if (now.TimeOfDay >= new TimeSpan(5, 0, 1) && now.TimeOfDay <= new TimeSpan(12, 0, 0))
        {
            currentTimeOfDay = TimeOfDay.d;
        }
        else if (now.TimeOfDay >= new TimeSpan(12, 0, 1) && now.TimeOfDay <= new TimeSpan(20, 0, 0))
        {
            currentTimeOfDay = TimeOfDay.e;
        }
        else
        {
            currentTimeOfDay = TimeOfDay.n;
        }

        

        Debug.Log("Current time in 24-hour format: " + currentTimeOfDay);
        // Sky.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Backgrounds/night/" + (currentTimeOfDay + Sky.GetComponent<SpriteRenderer>().sprite.name.Substring(1)));
        Debug.Log(Sky.GetComponent<SpriteRenderer>().sprite.name);
        ChangeBG(currentTimeOfDay);
        

        
        
    }
    private void ChangeBG(TimeOfDay timeNow)
    {
        foreach (var bgObj in bgObjects)
        {
            bgObj.sprite = Resources.Load<Sprite>("Sprites/Backgrounds/" + (timeNow + bgObj.sprite.name.Substring(1)));
        }
    }
}


