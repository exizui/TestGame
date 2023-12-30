using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class RubyDisabled : MonoBehaviour
{
    public Transform continuepos;
    private float delayInSeconds = 1.5f;

    public bool isTakeRuby;

    public static RubyDisabled ruby;
    public RubyDisabled() 
    {
        ruby = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            isTakeRuby = true;
            WorldController.shared.arm = true;
            GameLogic.Instance.RubyItem();           
            StartCoroutine(MoreAfterDelay());
            IEnumerator MoreAfterDelay()
            {              
                {
                   yield return new WaitForSeconds(delayInSeconds);
                   other.transform.position = continuepos.transform.position;
                   Destroy(gameObject);
                }
            }
        }
    }    
}
