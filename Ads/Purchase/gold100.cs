using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;

public class gold100 : MonoBehaviour
{
    Dictionary<string, object> FirstTime = new Dictionary<string, object>() {
            {"First time" , true},
        };

    public void OnPurchaseComplete(Product product)
    {
        
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
        Main.manage._coinFx.SetActive(true);
        Amplitude.Instance.logRevenue("com.mystream.taptapboyboy.gold100",1,0.99);
        //FbManager.manage.Gold100(100);
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
