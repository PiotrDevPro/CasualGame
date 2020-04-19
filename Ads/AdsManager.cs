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
        Advertisement.Initialize(gameId, true);

    }

      void Start()
     {
     StartCoroutine(ShowBannerWhenReady());
      }

    IEnumerator ShowBannerWhenReady()
    {
        Advertisement.Initialize(gameId);
        while (!Advertisement.IsReady(placementId)) { yield return new WaitForSeconds(0.5f); }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }


    private void Update()
    {
    }

     void ShowBanner()
    {
      //  while (!Advertisement.IsReady(placementId))
     //   {
       //     yield return new WaitForSeconds(0.5f);
      //  }
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
                Main.manage.Coins();
                break;
            case ShowResult.Skipped:
                print("Skipped");
                break;
            case ShowResult.Failed:
                print("Failed");
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

    public void CoinX2()
    {
        ShowAd();
        GameObject ButtnCoin = GameObject.Find("x2Coin");
        ButtnCoin.SetActive(false);
    }
}
