using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject _camer;
    private string[] chest = { "GoldChest", "WoodChest" };
    private KeyCode e_ = KeyCode.E;
    private string chestTag = "Chest";
    private string handle = "Handle";
    private float distance = 1.7f;
    public static ChestController singl;
    public GameObject txtshow;
    void Avake()
    {
        singl = this;
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camer.transform.position, _camer.transform.forward, out hit, distance))
        {
            string _hit = hit.collider.gameObject.name;
            if (hit.transform.tag == chestTag)
            {
                txtshow.SetActive(true);
                if (_hit == chest[1])
                {
                    if (Input.GetKeyDown(e_))
                        ManageButton(chest[1], hit);
                }             
                if (_hit == chest[0])
                {                   
                    if (Input.GetKeyDown(e_))
                        ManageButton(chest[0], hit);
                }
                   
            }
            if (_hit == handle)
            {
                if(Input.GetKeyDown(KeyCode.Return))
                    GetInTheCar.avake.OpenCar();
            }
            else
            {
                txtshow.SetActive(false);
            }

        }
        else
        {
            txtshow.SetActive(false);
        }
    }

    bool isfirstInteract1 = true;
    bool isfirstinteract0 = true;
    void ManageButton(string namebutton, RaycastHit hit)
    {
        Shop.inst.tpback.SetActive(true);
        if (namebutton == chest[0])
        {                 
            if (RubyDisabled.ruby.isTakeRuby == true)
            {
                hit.collider.GetComponent<Chest>().Interaction();               
                GameLogic.Instance.rubyicon.enabled = false;
                Heatlh.s.canArmor = true;             
                Heatlh.s.Armor.enabled = true;
                if (isfirstinteract0) 
                {
                    GameLogic.Instance.ShowMessage("ВИ МОЛОДЕЦЬ! ВАМ ПОЛОЖЕНА НАГОРОДА У ВИГЛЯДІ БРОНІ");
                    isfirstinteract0 = false;
                }
                    

            }
            else
            {
                GameLogic.Instance.ShowMessage("ВИ НЕ МАЄТЕ ПРАВА ВІДКРИВАТИ ЦЕЙ СУНДУК");
            }
        }
        else if (namebutton == chest[1])
        {                
                hit.collider.GetComponent<Chest>().Interaction();
                Invoke("SpawnGuns", 1.3f);
                if(isfirstInteract1)
                {
                    Coins.Instance.MinusCoins(Coins.coinsValue);
                    Coins.Instance.SavingCoins();
                    isfirstInteract1= false;
                }                    
        }
    }

    void SpawnGuns()
    {    
        Shop.inst.Spawn();
    }

}
