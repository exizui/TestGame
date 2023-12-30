using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfromPos : MonoBehaviour
{
    public Transform secondfloor;
    [SerializeField] private float jumpstrdefault = 3.1f;
    private int Defaultspeed = 9;
    private void OnTriggerEnter(Collider other)
    {

        Jump jumpdefault = other.GetComponent<Jump>();
        FirstPersonMovement _defspede = other.GetComponent<FirstPersonMovement>();
        if (other.CompareTag("Player"))
        {
            other.transform.position = secondfloor.transform.position;
            _defspede.runSpeed = Defaultspeed;
            jumpdefault.jumpStrength = jumpstrdefault;
        }

    }

    


    
}
