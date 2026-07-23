using System;
using UnityEngine;
using YG;

public class ADManager : MonoBehaviour
{
    public static ADManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool ShowAd()
    {
        if (YG2.isTimerAdvCompleted)
        {
            YG2.InterstitialAdvShow();
            return true;
        }
        
        return false;
    }
}
