using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpTrigger : MonoBehaviour
{
    public float jumpForce = 18f;
    
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        
        
        if (other.CompareTag("Player"))
        {
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                SoundManager.Instance.Jump();
            }
            
        }
      
    }
}
