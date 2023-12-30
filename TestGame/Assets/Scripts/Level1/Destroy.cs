using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Destroy : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.GetComponent<Rigidbody>() != null)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
