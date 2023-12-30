using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions.Must;
using System;

public class Coins : MonoBehaviour
{
    private static Coins mInstance;
    public static Coins Instance => mInstance;

    public static int coinsValue = 0;
    public const string CoinsPlayerPrefsKey = "coinsValue";
    public TextMeshProUGUI moneytxt;
    [HideInInspector] public bool canResetCoins;
   
    private void Awake()
    {
        if (mInstance == null) mInstance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {        
            coinsValue++;                   
            SoundManager.Instance.PickUpMoney();
            UpdateCoinsText();    
            Destroy(other.gameObject);            
        }
      
    }

    public void UpdateCoinsText()
    {
        if (moneytxt != null)
        {
            moneytxt.text = coinsValue.ToString();
        }
        else
        {
            Debug.LogWarning("TextCoins is not assigned.");
        }
    }

    public void MinusCoins(int minusValue)
    {
        coinsValue -= minusValue;
        UpdateCoinsText();
    }

    public void ResetCoins()
    {
        //if(canResetCoins)
        //{
            if (coinsValue > 0)
            {
                coinsValue = 0;
                UpdateCoinsText();
            }
       // }    
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinsPlayerPrefsKey,coinsValue);
        PlayerPrefs.Save();
    }

    public void LoadCoins()
    {
        if (PlayerPrefs.HasKey(CoinsPlayerPrefsKey))
        {
            coinsValue = PlayerPrefs.GetInt(CoinsPlayerPrefsKey);
            UpdateCoinsText();
        }
    }

    public void SavingCoins()
    {
        SaveCoins();
        LoadCoins();
    }

    public void DeleteCoinsValue(bool _switch)
    {
        if(_switch == true)
        {
            moneytxt.enabled = true;
        }
        else
        {
            moneytxt.enabled = false;
        }
      
    }
    #region 4
    //public void UseCoins(int varcoins)
    //{
    //    if (varcoins == 1)
    //    {
    //        if (coinsValue >= 20)
    //        {
    //            coinsValue -= 20;
    //            isCanBuy[0] = true;
    //        }
    //    }

    //    if (varcoins == 2)
    //    {
    //        if (coinsValue >= 40)
    //        {
    //            coinsValue -= 40;
    //            isCanBuy[1] = true;
    //        }
    //    }
    //    if (varcoins == 3)
    //    {
    //        if (coinsValue >= 60)
    //        {
    //            coinsValue -= 60;
    //            isCanBuy[2] = true;
    //        }
    //    }
    //    UpdateCoinsText();
    //}
    //public bool CanPickUp()
    //{
    //    if (isCanBuy[0])       
    //        return true;     
    //    if (isCanBuy[1])
    //        return true;
    //    if (isCanBuy[0])
    //        return true;

    //    return true;
    //}
    #endregion


}
