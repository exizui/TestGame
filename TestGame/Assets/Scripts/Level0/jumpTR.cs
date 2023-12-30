using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class jumpTR : MonoBehaviour
{
    public float launchForce = 20f;
    public float upwardForceMultiplier = 2f;
    public float jumpStrengthA = 7f; // Первое значение прыжка
    public float jumpStrengthB = 2.7f; // Второе значение прыжка

    private bool isFirstTouch = false;
   

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        
        if (other.CompareTag("Player"))
        {
                 
            Vector3 launchDirection = (transform.up + transform.forward).normalized;
            Vector3 upwardForce = transform.up * upwardForceMultiplier;
            rb.AddForce((launchDirection + upwardForce) * launchForce, ForceMode.Impulse);

            Jump jumpScript = other.GetComponent<Jump>();
            if (jumpScript != null)
            {
               if(isFirstTouch != true)
               {
                    RedMassage();
               } 
                jumpScript.jumpStrength = jumpStrengthA;
              
            }
        }
       
    }

    private void RedMassage()
    {
        GameLogic.Instance.ShowMessage("ВИ ВИЩЕ ПІДСТРИБУЄТЕ");
        isFirstTouch = true;
    }
}
