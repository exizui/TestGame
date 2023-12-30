using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class DamagetothePlayer : MonoBehaviour
{
   public int damagesword = 10;

   private void OnCollisionEnter(Collision other)
   {        
        if(other.gameObject.tag == "Player")
        {
            if (Heatlh.s.canArmor == false)
                StartCoroutine(FindObjectOfType<Heatlh>().Damage(damagesword));

            if (Heatlh.s.canArmor != false)
                Heatlh.s.ArmorDamage(damagesword);
        }
        

    }

   
}
