using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager manage;
    string placementId = "Banner";
#if UNITY_IOS
    private string gameId = "3551892";
#elif UNITY_ANDROID
    private string gameId = "3551893";
#endif

    private void Awake()
    {
        manage = this;
          Advertisement.Initialize(gameId,true);

    }

    void Start()
    {
         StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        Advertisement.Initialize(gameId);
        while (!Advertisement.IsReady(placementId)) { yield return new WaitForSeconds(0.3f); }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }




    public void ShowBanner()
    {
      //  while (!Advertisement.IsReady(placementId))
      //  {
      //      yield return new WaitForSeconds(0.5f);
       // }
      if (Advertisement.IsReady(placementId) && Advertisement.isInitialized)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementId);
        }

    }

    public void ShowAd()
    {
        if (Advertisement.IsReady() && Advertisement.isInitialized)
          
            {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }

    public void ShowAdDefault()
    {
        if (Advertisement.IsReady() && Advertisement.isInitialized)
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdVideoResult });
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Main.manage.isAdShowed = true;
                Main.manage.Coins();
                break;
            case ShowResult.Skipped:
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 0);
                Main.manage.isAdShowed = false;
                break;
            case ShowResult.Failed:
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 0);
                Main.manage.isAdShowed = false;
                break;
        }
    }

    private void HandleAdVideoResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                print("Finished");
                break;
            case ShowResult.Skipped:
                print("Skipped");
                break;
            case ShowResult.Failed:
                print("Failed");
                break;
        }
    }

    public void CoinX4()
    {
        ShowAd();
        Main.manage.isAdShowed = true;
        GameObject ButtnCoin = GameObject.Find("x2Coin");
        ButtnCoin.SetActive(false);
    }
    public void CoinAdRewerded()
    {
        ShowAd();
       // Main.manage.isAdShowed = true;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 5);
    }
}

