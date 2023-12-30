using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private float jumpdefalut = 2.7f;
   
    private void OnTriggerEnter(Collider other)
    {
        TriggerForFigure triggerForFigure = GetComponent<TriggerForFigure>();
        Jump jumpscrp = other.GetComponent<Jump>();
       
        if (other.CompareTag("Player"))
        {
            jumpscrp.jumpStrength = jumpdefalut;
            /*
            if (TriggerForFigure.FigureValue == 10 && triggerForFigure != null)
            {
                triggerForFigure.enabled = false;
            }
            else
            {
                print("лох");
            }
           
            /*
            if (triggerForFigure != null)
            {
                triggerForFigure.enabled = false;
                print("моржы не обосрались");
            }
            else
            {
                Debug.LogFormat("моржи ебались сели и обосрались");
            }
            */
        }
    }
}
