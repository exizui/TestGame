using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{
    private static GameLogic mInstance;
    public static GameLogic Instance => mInstance;
    
    [HideInInspector]public TextMeshProUGUI Popuptext;
    private string text;
    private float waitbetchar = 0.13f;       
    public TextMeshProUGUI PressButton;
    public GameObject pressE;
    public Image rubyicon;

    [SerializeField] private TextMeshProUGUI c;
    private float wait1 = 2, wait2 = 7;
    private string cluetxt;
    private void Awake()
    {
        if (mInstance == null) mInstance = this;
    }
    private void Start()
    {             
        Popuptext.text = "";          
    }
    #region Логика для отображения текста
    public void ShowMessage(string text)
    {
        this.text = text;
        StartCoroutine(TextCoroutine());
        
    } 
    IEnumerator TextCoroutine()
    {
        foreach (char abc in text)
        {           
            Popuptext.text += abc;
            yield return new WaitForSeconds(waitbetchar);
        }
        yield return new WaitForSeconds(3.0f);
       
        Popuptext.text = "";
    }
    
    #endregion




    #region Логика для отображения weapondata

    public void ShowPressButton(string text)
    {
        if(PressButton!= null)
        {
           PressButton.enabled = true;
           PressButton.text = text;
        }
       
    }

    public void HidePressButton()
    {
        if(PressButton != null)
        {
            PressButton.enabled = false;
            PressButton.text = "";
        }
      
       
        if (ItemManager._public != null)
            ItemManager._public.Cleartxt();

    }

    #endregion



    
    public void ShowClue(bool show)
    {
        if(show == true)
        {
            pressE.SetActive(true);
        }
        else if (show == false)
        {
            pressE.SetActive(false);
        }
    }


    public void RubyItem()
    {
        rubyicon.enabled = RubyDisabled.ruby.isTakeRuby ? true : false;
    }

    public void ClueforCar(string message)
    {
        this.cluetxt = message;
        print(message);
        StartCoroutine(ShowHelp());
    }
    IEnumerator ShowHelp()
    {
        yield return new WaitForSeconds(wait1);
        c.text = cluetxt;
        yield return new WaitForSeconds(wait2);
        c.text = "";
    }


}