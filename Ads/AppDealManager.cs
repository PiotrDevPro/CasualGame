using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppDealManager : MonoBehaviour, IInterstitialAdListener,INonSkippableVideoAdListener,IBannerAdListener,IRewardedVideoAdListener
{
    public static AppDealManager manage;
    public bool isAdsShop = false;
    public bool isCoin4x = false;
    public bool isSubShow = false;
    public bool isAdRestart = false;
    public bool isMagicBox = false;
    private int count = 0;
#if UNITY_IOS || UNITY_IPHONE
    private const string APP_KEY = "2cdafba685aff32e9ac3721d66d0b5204edb8607b4cea437";
#else
    private const string APP_KEY = "7d47fbb739b894fc7b8da620044fcc79c0a07ac465cc8d03";
#endif
    private void Awake()
    {
        manage = this;
    }

    private void Start()
    {
        //Appodeal.setLogLevel(Appodeal.LogLevel.Debug);
        Intiliaze(true);
        //ShowBanner();
        
    }

    private void Intiliaze(bool isTesting)
    {
        Appodeal.setTesting(isTesting);
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.initialize(APP_KEY,Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.BANNER_VIEW | Appodeal.REWARDED_VIDEO);
        Appodeal.setBannerCallbacks(this);
        Appodeal.setInterstitialCallbacks(this);
        Appodeal.setRewardedVideoCallbacks(this);
        
    }

    public void ShowInterstatial()
    {
        if (PlayerPrefs.GetInt("NoAds") != 1) 
        {

            if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            {
                Appodeal.show(Appodeal.INTERSTITIAL);
                Amplitude.Instance.logEvent("SeenAds", Interstitial);
            }
        }
    }
    public void ShowNonSkipable()
    {
        if (Appodeal.canShow(Appodeal.NON_SKIPPABLE_VIDEO))
        {
            Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
            GameObject ButtnCoin = GameObject.Find("x2Coin");
            ButtnCoin.SetActive(false);
            //levelGenerated.manage.levelCoin4xAnalitics();
            levelGenerated.manage.Next();
        }
        else
        {
            Main.manage.NoWiFi.SetActive(true);
            GameObject snd1 = GameObject.Find("Error");
            snd1.GetComponent<AudioSource>().Play();
            
        }
            
    }
    public void ShowRewardedAds20Video()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
            isAdsShop = true;
            isCoin4x = false;
        }
        else
        {
            Main.manage.NoWiFi.SetActive(true);
            GameObject snd1 = GameObject.Find("Error");
            snd1.GetComponent<AudioSource>().Play();

        }
    }
    public void ShowRewardedVideoCoin4x()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
            isCoin4x = true;
            isAdsShop = false;
            
            levelGenerated.manage.Next();
        }
        else
        {
            Main.manage.NoWiFi.SetActive(true);
            GameObject snd1 = GameObject.Find("Error");
            snd1.GetComponent<AudioSource>().Play();
        }
    }
    public void ShowRVforRestart()
    {
        {
            if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
            {
                Appodeal.show(Appodeal.REWARDED_VIDEO);
                isAdRestart = true;
            }
            else
            {
                Main.manage.NoWiFi.SetActive(true);
                GameObject snd1 = GameObject.Find("Error");
                snd1.GetComponent<AudioSource>().Play();

            }
        }
    }
    public void ShowRVForMagicBox()
    {
        
         {
           if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
           {
               Appodeal.show(Appodeal.REWARDED_VIDEO);
                isMagicBox = true;
                isAdsShop = false;
                isCoin4x = false;
                isAdRestart = false;
            }
            else
          {
              Main.manage.NoWiFi.SetActive(true);
               GameObject snd1 = GameObject.Find("Error");
               snd1.GetComponent<AudioSource>().Play();

           }
       }
    }
    public void ShowBanner()
    {
        if (PlayerPrefs.GetInt("NoAds") != 1)
        {
            
           Appodeal.show(Appodeal.BANNER_BOTTOM, "default");

        }
        
    }


    #region CoinFX

    void Latency()
    {
        isAdsShop = false;
        isCoin4x = false;
        isAdRestart = false;
        isMagicBox = false;
    }
    void latencySpawnCoin15()
    {
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(15);
    }
    void latencySpawnCoin20()
    {
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(20);
    }
    void latencyCoinUpdate15()
    {

        StartCoroutine(CoinGet());
        Main.manage._coinFx.SetActive(true);

    }
    void latencyCoinUpdate20()
    {

        StartCoroutine(CoinGet20());
        Main.manage._coinFx.SetActive(true);

    }
    IEnumerator CoinGet20()
    {
        
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 5);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 5);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 7);
        sndfx.GetComponent<AudioSource>().Play();
    }
    IEnumerator CoinGet()
    {
        ;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 4);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 4);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 4);
        sndfx.GetComponent<AudioSource>().Play();
    }
    void TimeToDeactivate()
    {
        Main.manage._coinFx.SetActive(false);
        //isNoDoubleAds = false;
    }

    #endregion

    #region Dictionary of Events
    Dictionary<string, object> Ads20 = new Dictionary<string, object>() {
            {"Source" , "Store"},
            {"Type" , "RV"},
        };
    Dictionary<string, object> Coin4x = new Dictionary<string, object>() {
            {"Source" , "EndLvl"},
            {"Type" , "RV"},
        };
    Dictionary<string, object> Interstitial = new Dictionary<string, object>() {
            {"Source" , "EndLvl"},
            {"Type" , "Skip-video"},
        };
    Dictionary<string, object> Restart = new Dictionary<string, object>() {
            {"Source" , "Restart4AD"},
            {"Type" , "RV"},
        };

    #endregion

    #region InterstitialAd
    public void onInterstitialLoaded(bool isPrecache)
    {

    }

    public void onInterstitialFailedToLoad()
    {

    }

    public void onInterstitialShowFailed()
    {

    }

    public void onInterstitialShown()
    {
        
    }

    public void onInterstitialClosed()
    {
        
    }

    public void onInterstitialClicked()
    {
        
    }

    public void onInterstitialExpired()
    {
        
    }

#endregion

    #region NonSkippableVideo

    public void onNonSkippableVideoLoaded(bool isPrecache)
    {
        
    }

    public void onNonSkippableVideoFailedToLoad()
    {
    }

    public void onNonSkippableVideoShowFailed()
    {

    }

    public void onNonSkippableVideoShown()
    {
        
    }

    public void onNonSkippableVideoFinished()
    {
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 15);
        Main.manage._coinFx.SetActive(true);
        Amplitude.Instance.logEvent("Coin4x");
        
        Invoke("TimeToDeactivate", 0.5f);
        print("onNonSkippableVideoFinished");
    }

    public void onNonSkippableVideoClosed(bool finished)
    {
        
    }

    public void onNonSkippableVideoExpired()
    {
        
    }
#endregion

    #region Banner
        public void onBannerLoaded(int height, bool isPrecache)
        {
        
        }

        public void onBannerFailedToLoad()
        {
        
    }

        public void onBannerShown()
        {
        
    }

        public void onBannerClicked()
        {
        
    }

        public void onBannerExpired()
        {
        
    }


    #endregion

    #region Rewarder Video

        public void onRewardedVideoLoaded(bool precache)
        {
        
        }

        public void onRewardedVideoFailedToLoad()
        {
        
        }

        public void onRewardedVideoShowFailed()
        {
        
        }

        public void onRewardedVideoShown()
        {
        }

        public void onRewardedVideoFinished(double amount, string name)
        {
            if (isAdsShop)
            {
                Invoke("latencyCoinUpdate20", 0.8f);
                Invoke("latencySpawnCoin20", 0.1f);
                Invoke("TimeToDeactivate", 1.8f);
                Invoke("Latency",1.3f);
                Invoke("CoinsFxActive", 0.5f);
                Amplitude.Instance.logEvent("SeenAds", Ads20);
                
            }
            if (isCoin4x)
            {
                Invoke("latencyCoinUpdate15", 0.8f);
                Invoke("latencySpawnCoin15", 0.1f);
                Invoke("TimeToDeactivate", 1.8f);
                Invoke("Latency", 1.3f);
                Amplitude.Instance.logEvent("SeenAds", Coin4x);
               
        }
        if (isAdRestart)
            {
            Invoke("Latency", 1.3f);
            Amplitude.Instance.logEvent("SeenAds", Restart);
            SceneManager.LoadScene(Application.loadedLevel);
            print(isAdRestart);
        }
        if (isMagicBox)
        {
            PlayerPrefs.SetInt("box",0);
            Invoke("Latency", 1.0f);
        }
      }
  

    public void onRewardedVideoClosed(bool finished)
        {
        
        }

        public void onRewardedVideoExpired()
        {
        
        }

        public void onRewardedVideoClicked()
        {
        
        }
    private void Update()
    {

    }
    #endregion
    
}
