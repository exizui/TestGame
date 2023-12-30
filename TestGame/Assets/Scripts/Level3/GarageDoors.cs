using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GarageDoors : MonoBehaviour
{
    Rigidbody rgb;
    [HideInInspector] public static bool canOpen;
    public Rigidbody rgbGeneralObj;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }
    public void DestroyLock()
    {     
        rgb.isKinematic = false;
        rgbGeneralObj.isKinematic = false;
        canOpen = true;
    }
}
