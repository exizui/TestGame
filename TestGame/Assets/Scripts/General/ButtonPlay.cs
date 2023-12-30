using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ButtonPlay : MonoBehaviour
{
    private void Start()
    {
        Pause.Instance.panel.SetActive(false);
        Pause.Instance.loose.SetActive(false);
       
    }  

    public void Restart()
    {
        Pause.Instance.RestartLevel();
        if (Coins.coinsValue > 0)
        {
            Coins.coinsValue = 0;
            Coins.Instance.UpdateCoinsText();
        }
       
    }
   
    public void _Pause()
    {
        Pause.Instance.PauseMode();
    }

    public void Play()
    {
       Pause.Instance.DisablePanel();
    }

   
}
