using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class whitetriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {           
            GameLogic.Instance.ShowMessage("ВИ БІЛЬШЕ НЕ ПРИСКОРЕНІ");
        }
        Destroy(this);
    }
}
