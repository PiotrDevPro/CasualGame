using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager manage;
    string gameID = "3551971";
    string placementId = "Banner";

    public bool isNoDoubleAds = false;

    private void Awake()
    {
        Advertisement.Initialize(gameID);
        manage = this;
    }

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            gameID = "3551970";
        }

        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameID = "3551971";
        }

        if (PlayerPrefs.GetInt("NoAds") != 1)
        {
            StartCoroutine(ShowBannerWhenReady());
        }
    }

IEnumerator ShowBannerWhenReady()
    {
        if (PlayerPrefs.GetInt("NoAds") != 1)
        {
            while (!Advertisement.IsReady(placementId)) { yield return new WaitForSeconds(0.5f); }
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementId);
        }
    }


    public void ShowBanner()
    {
        //  while (!Advertisement.IsReady(placementId))
        //  {
        //      yield return new WaitForSeconds(0.5f);
        // }
        if (PlayerPrefs.GetInt("NoAds") != 1)
        {
            
                if (Advertisement.IsReady(placementId)) //&& Advertisement.isInitialized)
                {
                    Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
                    Advertisement.Banner.Show(placementId);
                }
        }
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady()) //&& Advertisement.isInitialized)
          
            {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
            
        }
    }

    public void ShowAdTwo()
    {
        if (Advertisement.IsReady()) //&& Advertisement.isInitialized)

        {
            FbManager.manage.Ads20Gold(20);
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResultTwo });
            
        }
    }

    public void SkipLevel()
    {
         
            if (Advertisement.IsReady()) //&& Advertisement.isInitialized)

            {
                Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResultSkipLevel });
            }
        
    }

    public void ShowAdDefault()
    {
        if (PlayerPrefs.GetInt("NoAds") != 1)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdVideoResult });
            }
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                isNoDoubleAds = true;
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 15);
                Main.manage._coinFx.SetActive(true);
                Invoke("TimeToDeactivate", 0.5f);
                FbManager.manage.Coin4X(PlayerPrefs.GetInt("Coin"));
                levelGenerated.manage.Next();
                break;
            case ShowResult.Skipped:
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 0);
                //Main.manage.isAdShowed = false;
                break;
            case ShowResult.Failed:
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 0);
                //Main.manage.isAdShowed = false;
                break;
        }
    }

    private void HandleAdResultTwo(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 20);
                Main.manage._coinFx.SetActive(true);
                Invoke("TimeToDeactivate", 0.5f);
                break;
            case ShowResult.Skipped:
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 0);
                //Main.manage.isAdShowed = false;
                break;
            case ShowResult.Failed:
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 0);
                //Main.manage.isAdShowed = false;
                break;
        }
    }

    private void HandleAdResultSkipLevel(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                if (PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 29)
                {
                    GameObject timerr = GameObject.Find("PanelT");
                    timerr.GetComponent<Animator>().SetBool("Timez", false);
                    GameObject timerSnd = GameObject.Find("Timerr");
                    timerSnd.GetComponent<AudioSource>().Stop();
                    PlayerController.manage.starttime = 30f;
                    isNoDoubleAds = true;
                }
                levelGenerated.manage.Next();
                PlayerController.manage.losePanel.SetActive(false);
                PlayerController.manage._loseMessage.SetActive(false);
                GameObject playa = GameObject.Find("Default");
                PlayerController.manage.isDead = false;
                Main.manage.isGo = false;
                Main.manage.isTapToPlay = false;
                playa.GetComponentInChildren<Animator>().SetBool("DieFront", false);
                playa.GetComponentInChildren<Animator>().SetBool("Walk", false);
                playa.GetComponentInChildren<Animator>().SetBool("Ready", true);
                playa.GetComponentInChildren<Animator>().SetBool("Stand", true);
               
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

    public void CoinX4()
    {
        
        ShowAd();
        GameObject ButtnCoin = GameObject.Find("x2Coin");
        ButtnCoin.SetActive(false);
        Main.manage._coinFx.SetActive(true);
      //  PlayerController.manage.isStart = true;
        Invoke("TimeToDeactivate", 0.5f);
        

    }
    public void CoinAdRewerded()
    {
        ShowAdTwo();
    }

    void TimeToDeactivate()
    {
        Main.manage._coinFx.SetActive(false);
        isNoDoubleAds = false;
    }

    private void Update()
    {
        //print(Advertisement.isInitialized);
        //print(gameID);
        //print(Advertisement.IsReady());
        //print(isNoDoubleAds);
        // print(PlayerPrefs.GetInt("NoAds"));
  
    }
}

