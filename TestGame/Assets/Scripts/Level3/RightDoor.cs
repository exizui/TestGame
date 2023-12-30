using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    Animator leftR;
    private void Start()
    {
        leftR = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        if(GarageDoors.canOpen == true)
        {
            if (Input.GetKey(KeyCode.E))
                SetAnimation();               
        }     
    }

    private void SetAnimation()
    {
        leftR.SetBool("isRightOpen", true);
        OpenCar.AddNumber();
        Destroy(this);
    }
}
