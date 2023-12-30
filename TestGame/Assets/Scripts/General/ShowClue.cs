using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowClue : MonoBehaviour
{
    private Transform plcam;
    private int maxdist = 3;
    
    //public TextMeshProUGUI 
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(plcam.position, plcam.forward, out hit, maxdist))
        {
           
            //tmp.SetActive(true); //
            if (hit.transform.CompareTag("Drag"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //tmp.SetActive(false); 
                    //PrepareForDrag(hit);
                }
                else
                {
                  //  tmp.SetActive(true);
                }
            }
            else
            {
               // tmp.SetActive(false);
            }
        }
        else
        {
          //  tmp.SetActive(false);
        }
    }



   
}
