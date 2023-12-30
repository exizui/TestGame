using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScr : MonoBehaviour
{
    public int damageAmount = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<EnemyScr>().TakeDamge(damageAmount);

        if (other.gameObject.name == "Lock" || other.gameObject.name == "keymap")
            other.GetComponent<GarageDoors>().DestroyLock();
    }
}
