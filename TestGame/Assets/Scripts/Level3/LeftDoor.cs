using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeftDoor : MonoBehaviour
{
    Animator leftD;
    private void Start()
    {
        leftD = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {     
        if(GarageDoors.canOpen == true)
        {
            if (Input.GetKey(KeyCode.E))
                SetAnimation();         
        }
       
    }

    void SetAnimation()
    {
        leftD.SetBool("isLeftOpen", true);
        OpenCar.AddNumber();
        Destroy(this);
    }
}
