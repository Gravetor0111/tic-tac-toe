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
        if (now.TimeOfDay >= new TimeSpan(5, 0, 1) && now.TimeOfDay <= new TimeSpan(13, 0, 0))
        {
            currentTimeOfDay = TimeOfDay.d;
        }
        else if (now.TimeOfDay >= new TimeSpan(13, 0, 1) && now.TimeOfDay <= new TimeSpan(21, 0, 0))
        {
            currentTimeOfDay = TimeOfDay.e;
        }
        else
        {
            currentTimeOfDay = TimeOfDay.n;
        }

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


