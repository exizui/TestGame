using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private float SpeedBoost = 15f;
    private void OnTriggerEnter(Collider other)
    {
        FirstPersonMovement fps = other.GetComponent<FirstPersonMovement>();
        if (other.CompareTag("Player"))
        {
            GameLogic.Instance.ShowMessage("ВИ ПРИСКОРИЛИСЬ");
            if (fps != null)
            {
                fps.runSpeed = SpeedBoost;
                SoundManager.Instance.SpeedBoost();
            }
            Destroy(gameObject);                 
        }
    }
}





