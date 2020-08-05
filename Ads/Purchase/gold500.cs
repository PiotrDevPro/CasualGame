using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class gold500 : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 500);
        Main.manage._coinFx.SetActive(true);
        //FbManager.manage.Gold500(500);
        Invoke("TimeToDeactivate", 0.5f);
        Amplitude.Instance.logRevenue("com.mystream.taptapboyboy.gold500", 1, 1.99);
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
