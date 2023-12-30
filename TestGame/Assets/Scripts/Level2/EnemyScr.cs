using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScr : MonoBehaviour
{
    private static int hp = 100;
    public Animator animator;
    public Slider healthbar;
    public CapsuleCollider sword;
    private AudioSource enemyHit;

    private void Start()
    {
        enemyHit= GetComponent<AudioSource>();
    }
    void Update()
    {
        healthbar.value = hp;
    }

    public void TakeDamge(int damageAmount)
    {
        hp -= damageAmount;
        if(hp <= 0)
        {
            DeathEnemy();           
        }
        else
        {
            animator.SetTrigger("damage");
            enemyHit.Play();
        }
          
    }

    public void DeathEnemy()
    {
        animator.SetTrigger("death");
        GetComponent<Collider>().enabled = false;
        sword.enabled = false;
        healthbar.gameObject.SetActive(false);
        SoundManager.Instance.EnemyDestroyed();
        Invoke("Finish", 2.0f);
    }

    public void Finish()
    {
        //
        WorldController.shared.FinishLevel2();
        Shop.inst.DeleteObjects();
        Coins.Instance.DeleteCoinsValue(false);
    }

    public static void ResetHPenemy()
    {
        hp = 100;
    }

}
