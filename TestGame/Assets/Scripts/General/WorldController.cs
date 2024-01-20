using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YourNamespace;

public class WorldController : MonoBehaviour
{
    public static WorldController shared;

    private string levelName = "MainMenu";
    public string ButtonLevelName;
    [HideInInspector] public GameObject level;
    [HideInInspector] public GameObject spawnPoint;
    private string lastLevelName;
    private Vector3 lastPosition;
    private Vector3 boxposition = new Vector3(-21.48f, 3.97f, 3.52f);
    private Vector3 defaultposition = new Vector3(68.43f, 92.61866f, 72.6154f);
    [Header("Второй уровень")]  
    public GameObject LEVEL2;
    public Transform level2spawn;
    public Transform backtolvl2;
    [HideInInspector] public bool arm;
    [HideInInspector] public bool islevelshop;
    public GameObject Enemy;
    public WorldController()
    {
        shared = this;
    }
    private void Start()
    {
        LoadLevel(levelName);
        LEVEL2.SetActive(false);
    }
    private void OnEnable()
    {
        Pause.varLvl += RestartLevelTwo;
        TPToScene.OnTransit += LevelNameInvoke;
    }
    private void OnDisable()
    {
        Pause.varLvl -= RestartLevelTwo;
        TPToScene.OnTransit -= LevelNameInvoke;
    }
    public void LoadPrevLevel()
    {
        if (lastLevelName != null)
        {
            string levelName = lastLevelName;
            Vector3 position = lastPosition;

            // Reload prev level
            UnloadLevel();
            LoadLevel(levelName);

            // Revert player pos to saved          
            FirstPersonMovement.shared.gameObject.transform.position = boxposition;
        }
    }

    public void UnloadLevel()
    {
        if (level != null)
        {
            // Save old player pos and level name
            lastPosition = FirstPersonMovement.shared.transform.position;
            lastLevelName = levelName;

            spawnPoint = null;
            Destroy(level);
        }
    }

    public void LoadLevel(string name)
    {
        // Save level name
        levelName = name;

        // Load level
        GameObject levelAsset = Resources.Load<GameObject>($"Levels/{name}");

        if (levelAsset)//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<,
            level = Instantiate(levelAsset);
        // Find player spawn point
        Transform[] transforms = level.GetComponentsInChildren<Transform>();
        foreach (var childTransform in transforms)
        {
            if (childTransform.gameObject.name == "spawn")
                spawnPoint = childTransform.gameObject;
        }

        // Wrong, spawn point needed
        if (spawnPoint == null)
            throw new Exception("Level not has spawn point!");
        else
            FirstPersonMovement.shared.gameObject.transform.position = spawnPoint.transform.position;
    }

    public void LevelNameInvoke()
    {
        UnloadLevel();
        if (levelName == "Level1")   
            LoadLevel("Level0");

        if (levelName == "Level2") 
            LoadLevel("LevelShop");

        if (levelName == "LevelShop")
            ChangeSpawn(true);

        if (levelName == "LevelPuzzle")
            LoadLevel("Level3");
    }

    public void ChangeSpawn(bool isfirsttp)
    {
        if (isfirsttp == true)
            FirstPersonMovement.shared.gameObject.transform.position = backtolvl2.transform.position;
        if (isfirsttp == false)
            FirstPersonMovement.shared.gameObject.transform.position = level2spawn.transform.position;
        if (LEVEL2.activeSelf == false)
            LEVEL2.SetActive(true);
    }
    public void RestartLevelTwo()
    {
        ChangeSpawn(false);        
        Heatlh.s.ResetHealth();
        if (arm)
        {
            Heatlh.s.ResetArmor();
        }

        if (islevelshop)
            ChangeSpawn(true);
        print("Рестарт уровня");
        Coins.Instance.SavingCoins();
        Enemy.transform.position = defaultposition;
        EnemyScr.ResetHPenemy();
    }

    public void FinishLevel2()
    {
        LEVEL2.SetActive(false);
        LoadLevel("LevelPuzzle");
        Pause.Instance.ReturnRestartLogic();
    }

    public GameObject _player, canvas;
    
    public void LoadGame()
    {
        UnloadLevel();
        LoadLevel(ButtonLevelName);
        _player.SetActive(true);
        canvas.SetActive(true);
        Coins.Instance.DeleteCoinsValue(true);
    }

}




















    //void SomeMethod()
    //{
    //    if (targetTransform != null)
    //    {
    //        Vector3 targetPosition = targetTransform.position;
    //        FirstPersonMovement.shared.gameObject.transform.position = targetPosition;
    //    }
    //    else
    //    {
    //        Debug.LogError("Целевой трансформ не назначен!");
    //    }
    //}

