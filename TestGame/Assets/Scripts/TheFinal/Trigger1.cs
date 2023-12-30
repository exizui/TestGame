using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public GameObject board1;

   
    void OnTriggerStay()
    {
        ShowBoard(true);
    }
    void OnTriggerExit() 
    {
        ShowBoard(false);
    }

    private void ShowBoard(bool variable)
    {       
        switch(variable)
        {
             case true:
                board1.SetActive(true); break;
                case false:
                board1.SetActive(false); break;
        }
    }
}
