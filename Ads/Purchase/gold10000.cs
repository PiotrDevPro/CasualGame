using System.Collections;
using UnityEngine.Purchasing;
using System.Collections.Generic;
using UnityEngine;

public class gold10000 : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10000);
        Main.manage._coinFx.SetActive(true);
        //FbManager.manage.Gold10000(10000);
        Invoke("TimeToDeactivate", 0.5f);
        Amplitude.Instance.logRevenue("com.mystream.taptapboyboy.gold1000", 1, 6.99);
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
