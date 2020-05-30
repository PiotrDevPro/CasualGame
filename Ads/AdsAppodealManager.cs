using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;


public class AdsAppodealManager : MonoBehaviour//, IInterstitialAdListener, INonSkippableVideoAdListener
{
    public static AdsAppodealManager manage;

#if UNITY_IOS
    private const string APP_KEY = "20695e31dddc43655296e1eb6f0fd6c89de2004b4a0e3092";
#elif UNITY_ANDROID
    private const string APP_KEY = "645f5e506fc00fb2347da685db2503551cd41afee06d2a21";
#endif

    private readonly string[] DISABLE_NETWORKS = { "facebook", "flurry", "pubnative","inmobi", "amazon_ads", "applovin", "appnexus"
    ,"appodealx","chartboost","inner-active","ironsource","my_target", "mintegral","mopub","mraid","mraid_va","nast","ogury","openx",
    "smaato","startapp","tapjoy","vast","vpaid","vungle","yandex", "admob", "adcolony","appodeal", "unity_ads"};
    private void Start()
    {
       // Intialize(true);
    }
    private void Intialize(bool isTesting)
    {
        //Appodeal.setTesting(isTesting);
        //Appodeal.muteVideosIfCallsMuted(true);

   //     foreach (string nw in DISABLE_NETWORKS)
           // Appodeal.disableNetwork(nw);

        //Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO);
    }

    public void ShowVideo()
    {
       // if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
        {
       //     Appodeal.show(Appodeal.INTERSTITIAL);
        }
    }

    public void ShowRewerdedVideo()
    {
     //   if (Appodeal.isLoaded(Appodeal.NON_SKIPPABLE_VIDEO))
        {
      //      Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
        }
    }

  //  public IEnumerator IEShowRewerdedVideo()
  //  {
     //   yield return new WaitUntil(() => Appodeal.canShow(Appodeal.NON_SKIPPABLE_VIDEO));
     //   Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
   // }

    #region Video
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

    #region RewerdedVideo
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
        
    }

    public void onNonSkippableVideoClosed(bool finished)
    {
        
    }

    public void onNonSkippableVideoExpired()
    {
        
    }

    #endregion
}

