using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//private bool isSpawned;
//private GameObject nextPrefab => Resources.Load<GameObject>("Prefabs/Next");
// public GameObject nextPrefab;
public class Puzzle : MonoBehaviour
{
    public GameObject[] celltriggers;

    public GameObject item;
    public AnimationScript a;
    public static Puzzle puz;
    [Header ("")]
    public GameObject[] PortalandTMP;
    private void Awake()
    {
        puz = this;
        
    }

    public void OpenCells()
    {
        foreach (var cell in celltriggers)
        {
            cell.SetActive(false);
        }
        item.GetComponent<AnimationScript>().enabled=false;
        item.GetComponent<Rigidbody>().isKinematic=false;
    }

    public void ClosedCells()
    {
        foreach (var cell in celltriggers)
        {
            cell.SetActive(true);
        }
    }
    public void ActivePortal()
    {
        if(SecondRedTrigger.srt == true) 
        {
            if (YellowTrigger.y == true) 
            {
                Replacement(true);
            }
            else
            {
                Replacement(false);
            }
        }
        else
        {
            Replacement(false);
        }
        
    }
    public void Replacement(bool x)
    {       
        if(x == true)
        {    
           PortalandTMP[0].SetActive(false);
           PortalandTMP[1].SetActive(true);  
        }
        if(x== false)
        {
            PortalandTMP[0].SetActive(true);
            PortalandTMP[1].SetActive(false);
        }
               
    }
  

}
