using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayer : MonoBehaviour
{
    private GameObject _player;
    public Transform playerSpawnFromCar;
    public GameObject _car;
    public static ReturnPlayer rtpl;

    public ReturnPlayer()
    {
       rtpl = this;
    }
    private void Start()
    {
        _player = GameObject.Find("player");
    }

    public void Disabled()
    {
        _player.SetActive(false);
    }
    public void Return()
    {
        _player.SetActive(true);
        _player.transform.position = playerSpawnFromCar.position;
    }

    public void CarDestroy()
    {
        Destroy(_car);
    }
   
}
