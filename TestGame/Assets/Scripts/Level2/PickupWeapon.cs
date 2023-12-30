using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PickupWeapon : MonoBehaviour
{ 
    public GameObject _camer;
    private float distance = 1.7f;
    public GameObject currentWeapon;
    bool canPickUp;
    private KeyCode e_ = KeyCode.E;

    private string[] weapons = { "LPAxe(Clone)", "LPHammer(Clone)", "LPSword(Clone)" };

    public static PickupWeapon singl;

    private void Awake()
    {
        singl = this;     
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
            Drop();
        
        RaycastHit hit;
        if (Physics.Raycast(_camer.transform.position, _camer.transform.forward, out hit, distance))
        {
            string _hit = hit.collider.gameObject.name;  

            if (hit.transform.tag == "Weapon")
            {
               GameLogic.Instance.ShowPressButton("натисни У");

                if (Input.GetKeyDown(e_))
                    PickUp(hit);


                if (_hit == weapons[0])
                    ItemManager._public._ConvertData(1);
                      
                else if (_hit == weapons[1])
                    ItemManager._public._ConvertData(2);
                       
                else if (_hit == weapons[2])
                    ItemManager._public._ConvertData(3);
                           
                                   
            }
            else
            {
               
                GameLogic.Instance.HidePressButton();
            }
        }
        else
        {
            GameLogic.Instance.HidePressButton();
        }

    }

   
    void PickUp(RaycastHit hit)
    {
        if (canPickUp) Drop();
        {
            GameLogic.Instance.HidePressButton();
            currentWeapon = hit.transform.gameObject;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
            currentWeapon.transform.parent = transform;
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
            currentWeapon.GetComponent< Collider>().isTrigger = true;
            canPickUp = true;
            currentWeapon.GetComponent<MeshCollider>().enabled = false;
            MountTranform();
        }
    }

    public void Drop()
    {
        if (currentWeapon != null)
        {
            GameLogic.Instance.HidePressButton();
            currentWeapon.transform.parent = null;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.GetComponent<MeshCollider>().isTrigger = false; 
            currentWeapon.GetComponent<MeshCollider>().enabled = true;
            currentWeapon = null;
            canPickUp = false;
        }
          
    }

    public void EnableAndDisableCollider(bool a)
    {
       currentWeapon.GetComponent<MeshCollider>().enabled = a;
    }
    public void MountTranform()
    {
        if (currentWeapon.name == "mount") 
        {
            currentWeapon.transform.localPosition = new Vector3(x: 0f, y: 0.403f, z: 0f);
            currentWeapon.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
        }
    }
    #region моя логика
    //public void CheckCoin()
    //{
    //    if (coinvar.isCanBuy[0] == false)
    //    {
    //        //if (currentWeapon.name == weapons[0])           
    //            coinvar.UseCoins(1);
    //    }
    //    if (coinvar.isCanBuy[1] == false)
    //    {
    //       // if (currentWeapon.name == weapons[1])
    //            coinvar.UseCoins(2);
    //    }
    //    if (coinvar.isCanBuy[2] == false)
    //    {
    //        //if (currentWeapon.name == weapons[2])
    //            coinvar.UseCoins(3);
    //    }

    //    // Я ЗНАЮ ЧТО ЭТО ГОВНО КОД, НО ЗАТО ЭТО МОЙ КОД

    //}
    
    //void CheckPickUp(RaycastHit hit)
    //{
    //    if (coinvar.CanPickUp())
    //    {
    //        PickUp(hit);
    //    }
    //}

    
    #endregion
}
