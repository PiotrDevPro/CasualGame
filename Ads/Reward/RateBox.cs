using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
public class RateBox : MonoBehaviour

{
    public static RateBox manage;

    private void Awake()
    {
        manage = this;
    }

    public void ActivePanel()
    {

#if UNITY_IOS
        Debug.LogWarning("IOS");
        Device.RequestStoreReview();
        gameObject.SetActive(true);
        GetComponent<Animator>().SetBool("push", true);
        GameObject sound = GameObject.Find("btnNextSound");
        sound.GetComponent<AudioSource>().Play();
#else
        gameObject.SetActive(true);
        GetComponent<Animator>().SetBool("push", true);
        GameObject sound = GameObject.Find("btnNextSound");
        sound.GetComponent<AudioSource>().Play();
#endif
    }

    public void ClickNoThanks()
    {
        //RateManager.Instance.rateoff = true;
        gameObject.SetActive(false);
        //Amplitude.Instance.logEvent("RateNoThanks");
    }
    public void ClickLater()
    {
        gameObject.SetActive(false);
        //Amplitude.Instance.logEvent("RateLater");
    }
    public void ClickRateNow()
    {
        Application.OpenURL("market://details?id=com.MyStream.TapTapBoy");
        gameObject.SetActive(false);
        Amplitude.Instance.logEvent("RateNow");
    }

}
