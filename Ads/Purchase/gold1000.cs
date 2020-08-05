using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class gold1000 : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        //FbManager.manage.Gold1000(1000);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1000);
        Main.manage._coinFx.SetActive(true);
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
