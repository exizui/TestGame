using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRedTrigger : MonoBehaviour
{
    public static bool srt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drag"))
        {
            srt = true;
            Puzzle.puz.ActivePortal();         
        }
      
    }

}
