
using UnityEngine;

public class EnableOrDisableText : MonoBehaviour
{
    public GameObject TextMechPro;
    public GameObject Trigger;
    private void OnTriggerStay(Collider other)
    {
       

        if (other.CompareTag("Player"))
        {      
            TextMechPro.SetActive (true);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            TextMechPro.SetActive (false);
        }
    }
    
}