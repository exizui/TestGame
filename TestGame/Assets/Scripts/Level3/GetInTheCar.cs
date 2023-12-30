using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInTheCar : MonoBehaviour
{
    public static GetInTheCar avake;
    public GameObject carLayout, realCar, player, bublick;
    public Transform playerSpawnFromCar;
    public GetInTheCar()
    {
        avake = this;
    }

    private void Start()
    {
        player = GameObject.Find("player");
    }

    public void OpenCar()
    {
        Destroy(carLayout);
        Destroy(PickupWeapon.singl.currentWeapon.gameObject);
        ReturnPlayer.rtpl.Disabled();          
        bublick.SetActive(true);
        Spawncar();
    }

    public void Spawncar()
    {
        realCar.SetActive(true);
        print(realCar);
    }  
}
