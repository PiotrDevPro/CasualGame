using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class gold100 : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        FbManager.manage.Gold100(100);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
        Main.manage._coinFx.SetActive(true);
        Invoke("TimeToDeactivate", 0.5f);
        
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
