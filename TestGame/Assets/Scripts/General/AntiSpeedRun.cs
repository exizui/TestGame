using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSpeedRun : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.y > 20)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }        
    }
}
