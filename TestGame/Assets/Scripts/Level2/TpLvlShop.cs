using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpLvlShop : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other)
    {
        GameObject arrow = GameObject.Find("3Darrow").gameObject;
        if (other.CompareTag("Player"))
        {
            WorldController.shared.LoadLevel("LevelShop");
            Destroy(arrow);
            Destroy(gameObject);
            WorldController.shared.islevelshop = true;
        }
    } 
}
