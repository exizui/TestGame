using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YourNamespace;

public class Chest : MonoBehaviour
{
  
    bool flag = false;
    public AudioSource openCh, closeCh;
    public void Interaction()
    {    
        flag = !flag;
        GetComponentInChildren<Animator>().SetBool("Open", flag);
        GetComponentInChildren<Animator>().SetBool("Close", !flag);
        ChestSound(flag);

    }

    void ChestSound(bool flag)
    {
        if(flag)
        {
            openCh.Play();
        }
        else
        {
            closeCh.Play();
        }
    }
}
