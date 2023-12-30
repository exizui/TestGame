using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static WorldController;

public class Pause : MonoBehaviour
{
    public GameObject panel, loose, _camera, buttonplay; ///
    private FirstPersonLook firstPersonLook;
    private Button mybutton;
    private float timedef = 1.0f, timestop = 0.0f;
    private bool IsLooseActive = true, IsFinish, isPause;
    public GameObject finishtxt, pauseTXT, finalpanel;
    public Button[] restart;
    public static Pause Instance {get; private set;}
    public static Action <string> OnLevelFinished;
    public static Action varLvl;
    string finish = "по идее ты коснулся тригера и сейчас на втором уровне";
    private void Awake()
    {
        if(Instance == null) { Instance = this; }
    }
    private void Start()
    {
        firstPersonLook = _camera.GetComponent<FirstPersonLook>();
        finishtxt.SetActive(false);
        mybutton = buttonplay.GetComponent<Button>();    
        panel.SetActive(false);
        loose.SetActive(false);      
    }
    [SerializeField]private FPS fpsScr;
    bool flag;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsLooseActive)
        {
            isPause = !isPause;
            if (isPause)
                PauseMode();
            else
                DisablePanel();           
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            flag = !flag;
            fpsScr.enabled = flag;
        }
    }
    
    public void PauseMode()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        panel.SetActive(true);
        Time.timeScale = timestop;
        firstPersonLook.enabled = false;
        finishtxt.SetActive(false);
        ArrowController.isAnimated = false;
    }
    public void RestartLevel()
    {  
        if(Shop.inst != null)
        {
            Shop.inst.DeleteObjects();
        }         
        if (WorldController.shared.LEVEL2 == true)
        {
            WorldController.shared.LEVEL2.SetActive(false);
        }            
        Coins.Instance.ResetCoins();
        print("рестарт1");
        WorldController.shared.UnloadLevel();
        WorldController.shared.LoadLevel("Level1");
        DisablePanel();
        GameLogic.Instance.RubyItem();
        Coins.Instance.DeleteCoinsValue(true);
    }  
    public void DisablePanel()
    {
        Time.timeScale = timedef;
        panel.SetActive(false);
        loose.SetActive(false);
        finalpanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstPersonLook.enabled = true;
        IsLooseActive= true;
        isPause = false;
        ArrowController.isAnimated = true;
        SoundManager.Instance.Stop();
      
    }

    public void Loose()
    {
        loose.SetActive(true);
        Time.timeScale = timestop;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        firstPersonLook.enabled = false;
        IsLooseActive = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            PauseMode();
            finishtxt.SetActive(true);
            NewPlayLogic();
            SoundManager.Instance.Finish();
            IsFinish = true; //булевая ставится в тру
            OnLevelFinished?.Invoke(finish);
            pauseTXT.SetActive(false);
        }
    }
    private void LevelManage()
    {
        WorldController.shared.UnloadLevel();
        if (IsFinish) //если в тру то будет перебрасывать в лвл2
        {
            WorldController.shared.ChangeSpawn(false);
            //WorldController.shared.LoadLevel("LevelShop");
            //WorldController.shared.arm = true;
            //RubyDisabled.ruby.isTakeRuby = true;
            ReturnPlayLogic();
            NewRestartLogic();
        }
    }
    public void NewPlayLogic()
    {
        mybutton.onClick.RemoveAllListeners();
        mybutton.onClick.AddListener(LevelManage);
    }

    public void NewRestartLogic()
    {
        foreach (var removebutton in restart)
        {
            removebutton.onClick = new Button.ButtonClickedEvent();
            removebutton.onClick.AddListener(CheckPoint);          
        } 
    }

    public void ReturnRestartLogic()
    {
        foreach (var removebutton in restart)
        {
            removebutton.onClick = new Button.ButtonClickedEvent();
            removebutton.onClick.AddListener(RestartLevel);
        }
    }
    public void CheckPoint() 
    {
        varLvl?.Invoke();
        DisablePanel();
    }


    private void ReturnPlayLogic()
    {
        mybutton.onClick.RemoveListener(LevelManage);
        mybutton.onClick.AddListener(DisablePanel);      
    }

    public void Exit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void Final()
    {
        finalpanel.SetActive(true);
        Time.timeScale = timestop;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        firstPersonLook.enabled = false;
        IsLooseActive = true;
    }

    public void RestartGame()
    {        
        finalpanel.SetActive(false);
        WorldController.shared.LoadGame();
        Cursor.visible = false;
        DisablePanel();
    }
}



#region менеджер паузы олдовый
/*
   public void Update()
   {

       if (Input.GetKeyDown(KeyCode.Escape))
       {
           if(loose!= null)
           {
               IsPause = !IsPause;

               if (IsPause)
               {
                   Cursor.lockState = CursorLockMode.Confined;
                   panel.SetActive(true);
                   Time.timeScale = timestop;

                   firstPersonLook.enabled = false;
               }
               else
               {
                   Cursor.lockState = CursorLockMode.Locked;
                   panel.SetActive(false);
                   Time.timeScale = timedef;

                   firstPersonLook.enabled = true;
               }


           }
       }


   }
   */
#endregion