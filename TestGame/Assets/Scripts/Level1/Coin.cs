using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public bool IsVisible { get => gameObject.GetComponent<MeshRenderer>().enabled; set => gameObject.GetComponent<MeshRenderer>().enabled = value; }

    private static Coin mInstance;
    public static Coin Instance => mInstance;
    private float rotationSpeed = 100f;
    private void Awake()
    {
        if (mInstance == null) mInstance = this;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    
}
