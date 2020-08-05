using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;
using UnityEngine.UI;

public class noads : MonoBehaviour
{
    public void OnPurchaseComplete(Product product)
    {
        
        PlayerPrefs.SetInt("NoAds",1);
        Main.manage._coinFx.SetActive(true);
        Main.manage.NoAdsBtn.GetComponent<Button>().interactable = false;
        GameObject btnActv = GameObject.Find("ButtonAd");
        btnActv.GetComponent<Button>().interactable = false;
        GetComponentInChildren<Text>().color = Color.cyan;
        //FbManager.manage.NoAds("No ads no more");
        Invoke("TimeToDeactivate", 0.5f);
        Amplitude.Instance.logRevenue("com.mystream.taptapboyboy.noads", 1, 2.99);
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
