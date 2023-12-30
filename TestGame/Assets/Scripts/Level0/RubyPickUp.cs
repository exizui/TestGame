using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyPickUp : MonoBehaviour
{

    private bool isTP = false;
    private bool IsSecondTouch = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isTP!=true) 
                TP();

            if (IsSecondTouch!=true)
                Destroy(gameObject);

        }
    }
    private void TP()
    {
        WorldController.shared.LoadPrevLevel();
        isTP= true;
        IsSecondTouch = true;
    }
}
