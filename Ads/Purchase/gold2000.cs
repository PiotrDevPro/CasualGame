﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class gold2000 : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 2000);
        Main.manage._coinFx.SetActive(true);
        //FbManager.manage.Gold2000(2000);
        Invoke("TimeToDeactivate", 0.5f);
        Amplitude.Instance.logRevenue("com.mystream.taptapboyboy.gold2000", 1, 3.99);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        print("" + product.definition.id + "failed due to" + reason);
    }

    private void TimeToDeactivate()
    {
        Main.manage._coinFx.SetActive(false);
    }
}
