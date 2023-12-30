using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{

    public GameObject board2;

    private void OnTriggerStay(Collider other)
    {
        board2.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        board2.SetActive(false);
    }
}
