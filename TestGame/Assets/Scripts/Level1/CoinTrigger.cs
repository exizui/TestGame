using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{ 
    public GameObject D;  
    public GameObject money;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drag"))
        {
            D.SetActive(false);           
            money.SetActive(true);
        }
    }  
}






//private IEnumerator SpawnAndDestroySmallCoin(float delay)
//{
//    yield return new WaitForSeconds(delay);
//    GameObject newSmallCoin = Instantiate(GoldCoin, transform.position + UnityEngine.Random.insideUnitSphere, Quaternion.identity);
//    Rigidbody newRigidbody = newSmallCoin.AddComponent<Rigidbody>();
//    yield return new WaitForSeconds(lifetime);

//    if (newRigidbody != null)
//        Destroy(newRigidbody);

//}