using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Heatlh : MonoBehaviour
{
    public static Heatlh s;
    private static int HP;
    [HideInInspector] public bool gameover;
    public TextMeshProUGUI health;
    public GameObject redoverlay;

    private static int armint;
    public TextMeshProUGUI Armor;
    [HideInInspector] public bool canArmor;

    private void Awake()
    {
        s = this;
    }
    void Start()
    {
        gameover = false;
        HP = 100;
        armint = 100;
        Armor.enabled = false;
        redoverlay.SetActive(false);
        
    }

    private void Update()
    {
        health.text = "" + HP;
        Armor.text = "" + armint;
        if (gameover)
        {
            redoverlay.SetActive(false);
            Pause.Instance.Loose();
            //health.enabled = false;
            //Armor.enabled = false;
            //HP= 100;
            //armint= 100;
            gameover = false;
        }
    }

    public IEnumerator Damage(int damagesword)
    {
        HP -= damagesword;
        SoundManager.Instance.TakeHit();
        redoverlay.SetActive(true);

        if (HP == 0)
            gameover = true;

        yield return new WaitForSeconds(.3f);
        redoverlay.SetActive(false);
    }

    public void ArmorDamage(int damagesword)
    {
        armint -= damagesword;
        if (armint == 0)
        {
            canArmor = false;
            Armor.enabled = false;
        }
            
    }

    public void ResetArmor()
    {
        canArmor = true;
        Armor.enabled = true;
       
            armint = 100;

  
    }

    public void ResetHealth()
    {
        HP = 100;
    }
}
