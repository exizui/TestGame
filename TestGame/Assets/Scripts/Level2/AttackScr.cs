using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScr : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
      
    }

    private void Update()
    {
        if(PickupWeapon.singl.currentWeapon != null)
        {
            if (Input.GetButton("Fire1"))
            {                   
                animator.SetBool("attack", true);
                PickupWeapon.singl.EnableAndDisableCollider(true);
            }

            else if (Input.GetButtonUp("Fire1"))
            {              
                animator.SetBool("attack", false);
                PickupWeapon.singl.EnableAndDisableCollider(false);
            }
        }
        
    }
}
