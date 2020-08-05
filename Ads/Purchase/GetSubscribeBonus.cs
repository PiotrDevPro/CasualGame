using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;
using UnityEngine.UI;

public class GetSubscribeBonus : MonoBehaviour
{

    public void OnPurchaseComplete(Product product)
    {   
        PlayerPrefs.SetInt("Subscribe", 1);
        PlayerPrefs.SetInt("NoAds", 1);
        PlayerPrefs.SetInt("FirstBuy", PlayerPrefs.GetInt("FirstBuy") + 1);
        Main.manage.BuySubscribeBtn.GetComponent<Button>().interactable = false;
        GameObject buyBtnColor = GameObject.Find("Buy");
        buyBtnColor.GetComponent<Button>().interactable = false;
        Amplitude.Instance.logRevenue("com.mystream.taptapboyboy.subscribe", 1, 9.99);
        Invoke("Latency",0.5f);
    }
    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        print("" + product.definition.id + "failed due to" + reason);
        Amplitude.Instance.logEvent("SubscibeStart");
    }
    private void TimeToDeactivate()
    {
        Main.manage._coinFx.SetActive(false);
    }

    public void PrivacyLink()
    {
        Application.OpenURL("http://nrknvdeb.plp7.ru/");
    }
    public void Terms()
    {
        Application.OpenURL("http://p62e3rhz.plp7.ru/");
    }

    void Latency()
    {
        Main.manage.SubscribePanelClose();
    }

}
