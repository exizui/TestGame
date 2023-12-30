using RootMotion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenCar : MonoBehaviour
{
    public static OpenCar opencar;
    private GameObject player;
    [SerializeField] private SimpleCarController car;
    //[SerializeField] private GameObject newCameraCar;
    [SerializeField] private CameraController CamerCarScr;
    [SerializeField] private Camera CameraCar;
    [SerializeField] private AudioListener audioListener;
    [SerializeField] private KeyCode enter = KeyCode.Return;
    private string clueforCar = "щоб сісти в машину треба навести камеру на ручку дверей та натиснути Enter";

    public AudioSource door, music;
    public Transform playerSpawnFromCar;
    public GameObject playerPrefab, bublick;

    [HideInInspector] public static int canOpenCar = 0;
    private void Awake()
    {
        opencar = this;
    }
    private void Start()
    {
        player = GameObject.Find("player");
        CarControl(false);
        GameLogic.Instance.ClueforCar(clueforCar);
    }
    void CarControl(bool canDrive)
    {
        switch (canDrive)
        {
            case true:
                car.enabled = true;
                break;
            case false: 
                car.enabled = false;
                break;
        }
    }
    public void GetIntTheCar()
    {
      
        if (Input.GetKeyDown(enter))
        {           
            if(canOpenCar == 2)
            {
                CamerCarScr.enabled = true;
                CameraCar.enabled = true;
                audioListener.enabled = true;
                Destroy(PickupWeapon.singl.currentWeapon.gameObject);
                player.SetActive(false);             
                bublick.SetActive(true);
                CarControl(true);
            }
           
            
        }       
    }
    public static void AddNumber()
    {
        canOpenCar+=1;
        print(canOpenCar);
    }

    public void GetOut()
    {
        CamerCarScr.enabled = false;
        CameraCar.enabled = false;
        audioListener.enabled = false;
        CarControl(true);
       // player.transform.position = playerSpawnFromCar.position;
        player.SetActive(true);
        Destroy(playerSpawnFromCar.gameObject);
    }
}