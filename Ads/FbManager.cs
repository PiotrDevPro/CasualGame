using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FbManager : MonoBehaviour
{

    public static FbManager manage;

    
    void Awake()
      {
         manage = this;
        
        if (!FB.IsInitialized)
            {
           //Initialize the Facebook SDK
              FB.Init(InitCallback, OnHideUnity);
            

        }
            else
            {
          //s Already initialized, signal an app activation App Event
             FB.ActivateApp();
             }
          //DontDestroyOnLoad(this);

      }


      private void InitCallback()
     {
      if (FB.IsInitialized)
      {
    //  Signal an app activation App Event
       FB.ActivateApp();
    // Continue with Facebook SDK
    // ...
      }
      else
      {
          Debug.Log("Failed to Initialize the Facebook SDK");
     }
     }

    private void OnHideUnity(bool isGameShown)
   {
     if (!isGameShown)
    {
  // Pause the game - we will need to hide
         Time.timeScale = 0;
     }
     else
    {
  // Resume the game - we're getting focus again
        Time.timeScale = 1;
     }

    }
    #region Shop

    public void Gold100(int price)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams[""] = price.ToString();

        FB.LogAppEvent(
             "100 Gold",
             parameters: tutParams
         );
        print("100 Gold:" + price);
    }

    public void Ads20Gold(int price)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Ads20Gold"] = price.ToString();

        FB.LogAppEvent(
             "Ads20Gold",
             parameters: tutParams
         );
        print("Ads20Gold:" + price);
    }

    public void Gold500(int price)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["500 Gold"] = price.ToString();

        FB.LogAppEvent(
             "500 Gold",
             parameters: tutParams
         );
        print("500 Gold:" + price);
    }

    public void Gold1000(int price)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["1000 Gold"] = price.ToString();

        FB.LogAppEvent(
             "1000 Gold",
             parameters: tutParams
         );
        print("1000 Gold:" + price);
    }

    public void Gold2000(int price)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["2000 Gold"] = price.ToString();

        FB.LogAppEvent(
             "2000 Gold",
             parameters: tutParams
         );
        print("2000 Gold:" + price);
    }

    public void Gold10000(int price)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["10000 Gold"] = price.ToString();

        FB.LogAppEvent(
             "10000 Gold",
             parameters: tutParams
         );
        print("10000 Gold:" + price);
    }

    public void NoAds(string status)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["No Ads"] = status;

        FB.LogAppEvent(
             "No Ads",
             parameters: tutParams
         );
        print("No Ads:" + status);
    }

    public void Coin4X(int coins)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coin4X"] = coins.ToString();

        FB.LogAppEvent(
             "Coin4X",
             parameters: tutParams
         );
        print("Coin4X:" + coins);
    }

    public void LevelEnded(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = level.ToString();

        FB.LogAppEvent(
             "Levels Finish",
             parameters: tutParams
         );
        print("Levels Finish: " + level);
    }

    public void SettingOpen(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "Options Open",
             parameters: tutParams
         );
    }

    public void SettingClose(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "Options Close",
             parameters: tutParams
         );
    }

    public void Shop(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "Shop",
             parameters: tutParams
         );
    }

    public void MusicOff(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "MusicOFF",
             parameters: tutParams
         );
    }

    public void MusicOn(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "MusicON",
             parameters: tutParams
         );
    }

    public void SoundOff(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "SoundOFF",
             parameters: tutParams
         );
    }

    public void SoundOn(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "SoundON",
             parameters: tutParams
         );
    }

    public void VibroOff(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "VibroOFF",
             parameters: tutParams
         );
    }

    public void VibroOn(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "VibroON",
             parameters: tutParams
         );
    }

    public void ResetAll(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Number"] = gold.ToString();

        FB.LogAppEvent(
             "ResetALL",
             parameters: tutParams
         );
    }

    #endregion

    #region Levels Start
    public void level1(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 1 Start",
            parameters: tutParams
         );
        print("level 1 Start: " + level + " Coins");
    }

    public void level2(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 2 Start",
            parameters: tutParams
         );
        print("level 2 Start: " + level + " Coins");
    }

    public void level3(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 3 Start",
            parameters: tutParams
         );
        print("level 3 Start: " + level + " Coins");
    }

    public void level4(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 4 Start",
            parameters: tutParams
         );
        print("level 4 Start: " + level + " Coins");
    }

    public void level5(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 5 Start",
            parameters: tutParams
         );
        print("level 5 Start: " + level + " Coins");
    }

        public void level6(int level)
        {
            var tutParams = new Dictionary<string, object>();
            tutParams["Coins"] = level.ToString();

            FB.LogAppEvent(
                "Level 6 Start",
                parameters: tutParams
             );
            print("level 6 Start: " + level + " Coins");
        }

    public void level7(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 7 Start",
            parameters: tutParams
         );
        print("level 7 Start: " + level + " Coins");
    }

    public void level8(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 8 Start",
            parameters: tutParams
         );
        print("level 8 Start: " + level + " Coins");
    }

    public void level9(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 9 Start",
            parameters: tutParams
         );
        print("level 9 Start: " + level + " Coins");
    }

    public void level10(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 10 Start",
            parameters: tutParams
         );
        print("level 10 Start: " + level + " Coins");
    }

    public void level11(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 11 Start",
            parameters: tutParams
         );
        print("level 11 Start: " + level + " Coins");
    }

    public void level12(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 12 Start",
            parameters: tutParams
         );
        print("level 12 Start: " + level + " Coins");
    }

    public void level13(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 13 Start",
            parameters: tutParams
         );
        print("level 13 Start: " + level + " Coins");
    }

    public void level14(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 14 Start",
            parameters: tutParams
         );
        print("level 14 Start: " + level + " Coins");
    }

    public void level15(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 15 Start",
            parameters: tutParams
         );
        print("level 15 Start: " + level + " Coins");
    }

    public void level16(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 16 Start",
            parameters: tutParams
         );
        print("level 16 Start: " + level + " Coins");
    }

    public void level17(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 17 Start",
            parameters: tutParams
         );
        print("level 17 Start: " + level + " Coins");
    }

    public void level18(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 18 Start",
            parameters: tutParams
         );
        print("level 18 Start: " + level + " Coins");
    }

    public void level19(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 19 Start",
            parameters: tutParams
         );
        print("level 19 Start: " + level + " Coins");
    }

    public void level20(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 20 Start",
            parameters: tutParams
         );
        print("level 20 Start: " + level + " Coins");
    }

    public void level21(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 21 Start",
            parameters: tutParams
         );
        print("level 21 Start: " + level + " Coins");
    }

    public void level22(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 22 Start",
            parameters: tutParams
         );
        print("level 22 Start: " + level + " Coins");
    }

    public void level23(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 23 Start",
            parameters: tutParams
         );
        print("level 23 Start: " + level + " Coins");
    }

    public void level24(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 24 Start",
            parameters: tutParams
         );
        print("level 24 Start: " + level + " Coins");
    }

    public void level25(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 25 Start",
            parameters: tutParams
         );
        print("level 25 Start: " + level + " Coins");
    }

    public void level26(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 26 Start",
            parameters: tutParams
         );
        print("level 26 Start: " + level + " Coins");
    }

    public void level27(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 27 Start",
            parameters: tutParams
         );
        print("level 27 Start: " + level + " Coins");
    }

    public void level28(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 28 Start",
            parameters: tutParams
         );
        print("level 28 Start: " + level + " Coins");
    }

    public void level29(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 29 Start",
            parameters: tutParams
         );
        print("level 29 Start: " + level + " Coins");
    }

    public void level30(int level)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = level.ToString();

        FB.LogAppEvent(
            "Level 30 Start",
            parameters: tutParams
         );
        print("level 30 Start: " + level + " Coins");
    }

    #endregion

    #region Levels Finish

    public void level1Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 1 Finish",
            parameters: tutParams
         );
        print("level 1 Finish: " + gold + " Coins");
    }

    public void level2Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 2 Finish",
            parameters: tutParams
         );
        print("level 2 Finish: " + gold + " Coins");
    }

    public void level3Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 3 Finish",
            parameters: tutParams
         );
        print("level 3 Finish: " + gold + " Coins");
    }

    public void level4Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 4 Finish",
            parameters: tutParams
         );
        print("level 4 Finish: " + gold + " Coins");
    }

    public void level5Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 5 Finish",
            parameters: tutParams
         );
        print("level 5 Finish: " + gold + " Coins");
    }

    public void level6Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 6 Finish",
            parameters: tutParams
         );
        print("level 6 Finish: " + gold + " Coins");
    }

    public void level7Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 7 Finish",
            parameters: tutParams
         );
        print("level 7 Finish: " + gold + " Coins");
    }

    public void level8Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 8 Finish",
            parameters: tutParams
         );
        print("level 8 Finish: " + gold + " Coins");
    }

    public void level9Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 9 Finish",
            parameters: tutParams
         );
        print("level 9 Finish: " + gold + " Coins");
    }

    public void level10Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 10 Finish",
            parameters: tutParams
         );
        print("level 10 Finish: " + gold + " Coins");
    }

    public void level11Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 11 Finish",
            parameters: tutParams
         );
        print("level 11 Finish: " + gold + " Coins");
    }

    public void level12Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 12 Finish",
            parameters: tutParams
         );
        print("level 12 Finish: " + gold + " Coins");
    }

    public void level13Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 13 Finish",
            parameters: tutParams
         );
        print("level 13 Finish: " + gold + " Coins");
    }

    public void level14Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 14 Finish",
            parameters: tutParams
         );
        print("level 14 Finish: " + gold + " Coins");
    }

    public void level15Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 15 Finish",
            parameters: tutParams
         );
        print("level 15 Finish: " + gold + " Coins");
    }

    public void level16Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 16 Finish",
            parameters: tutParams
         );
        print("level 16 Finish: " + gold + " Coins");
    }

    public void level17Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 17 Finish",
            parameters: tutParams
         );
        print("level 17 Finish: " + gold + " Coins");
    }

    public void level18Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 18 Finish",
            parameters: tutParams
         );
        print("level 18 Finish: " + gold + " Coins");
    }

    public void level19Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 19 Finish",
            parameters: tutParams
         );
        print("level 19 Finish: " + gold + " Coins");
    }

    public void level20Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 20 Finish",
            parameters: tutParams
         );
        print("level 20 Finish: " + gold + " Coins");
    }

    public void level21Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 21 Finish",
            parameters: tutParams
         );
        print("level 21 Finish: " + gold + " Coins");
    }

    public void level22Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 22 Finish",
            parameters: tutParams
         );
        print("level 22 Finish: " + gold + " Coins");
    }

    public void level23Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 23 Finish",
            parameters: tutParams
         );
        print("level 23 Finish: " + gold + " Coins");
    }

    public void level24Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 24 Finish",
            parameters: tutParams
         );
        print("level 24 Finish: " + gold + " Coins");
    }

    public void level25Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 25 Finish",
            parameters: tutParams
         );
        print("level 25 Finish: " + gold + " Coins");
    }

    public void level26Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 26 Finish",
            parameters: tutParams
         );
        print("level 26 Finish: " + gold + " Coins");
    }

    public void level27Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 27 Finish",
            parameters: tutParams
         );
        print("level 27 Finish: " + gold + " Coins");
    }

    public void level28Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 28 Finish",
            parameters: tutParams
         );
        print("level 28 Finish: " + gold + " Coins");
    }

    public void level29Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 29 Finish",
            parameters: tutParams
         );
        print("level 29 Finish: " + gold + " Coins");
    }

    public void level30Finish(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 30 Finish",
            parameters: tutParams
         );
        print("level 30 Finish: " + gold + " Coins");
    }

    #endregion

    #region Level Next

    public void level1Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 1 Next",
            parameters: tutParams
         );
        print("level 1 Next: " + gold + " Coins");
    }

    public void level2Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 2 Next",
            parameters: tutParams
         );
        print("level 2 Next: " + gold + " Coins");
    }

    public void level3Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 3 Next",
            parameters: tutParams
         );
        print("level 3 Next: " + gold + " Coins");
    }

    public void level4Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 4 Next",
            parameters: tutParams
         );
        print("level 4 Next: " + gold + " Coins");
    }

    public void level5Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 5 Next",
            parameters: tutParams
         );
        print("level 5 Next: " + gold + " Coins");
    }

    public void level6Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 6 Next",
            parameters: tutParams
         );
        print("level 6 Next: " + gold + " Coins");
    }

    public void level7Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 7 Next",
            parameters: tutParams
         );
        print("level 7 Next: " + gold + " Coins");
    }

    public void level8Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 8 Next",
            parameters: tutParams
         );
        print("level 8 Next: " + gold + " Coins");
    }

    public void level9Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 9 Next",
            parameters: tutParams
         );
        print("level 9 Next: " + gold + " Coins");
    }

    public void level10Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 10 Next",
            parameters: tutParams
         );
        print("level 10 Next: " + gold + " Coins");
    }

    public void level11Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 11 Next",
            parameters: tutParams
         );
        print("level 11 Next: " + gold + " Coins");
    }

    public void level12Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 12 Next",
            parameters: tutParams
         );
        print("level 12 Next: " + gold + " Coins");
    }

    public void level13Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 13 Next",
            parameters: tutParams
         );
        print("level 13 Next: " + gold + " Coins");
    }

    public void level14Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 14 Next",
            parameters: tutParams
         );
        print("level 14 Next: " + gold + " Coins");
    }

    public void level15Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 15 Next",
            parameters: tutParams
         );
        print("level 15 Next: " + gold + " Coins");
    }

    public void level16Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 16 Next",
            parameters: tutParams
         );
        print("level 16 Next: " + gold + " Coins");
    }

    public void level17Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 17 Next",
            parameters: tutParams
         );
        print("level 17 Next: " + gold + " Coins");
    }

    public void level18Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 18 Next",
            parameters: tutParams
         );
        print("level 18 Next: " + gold + " Coins");
    }

    public void level19Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 19 Next",
            parameters: tutParams
         );
        print("level 19 Next: " + gold + " Coins");
    }

    public void level20Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 20 Next",
            parameters: tutParams
         );
        print("level 20 Next: " + gold + " Coins");
    }

    public void level21Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 21 Next",
            parameters: tutParams
         );
        print("level 21 Next: " + gold + " Coins");
    }

    public void level22Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 22 Next",
            parameters: tutParams
         );
        print("level 22 Next: " + gold + " Coins");
    }

    public void level23Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 23 Next",
            parameters: tutParams
         );
        print("level 23 Next: " + gold + " Coins");
    }

    public void level24Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 24 Next",
            parameters: tutParams
         );
        print("level 24 Next: " + gold + " Coins");
    }

    public void level25Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 25 Next",
            parameters: tutParams
         );
        print("level 25 Next: " + gold + " Coins");
    }

    public void level26Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 26 Next",
            parameters: tutParams
         );
        print("level 26 Next: " + gold + " Coins");
    }

    public void level27Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 27 Next",
            parameters: tutParams
         );
        print("level 27 Next: " + gold + " Coins");
    }

    public void level28Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 28 Next",
            parameters: tutParams
         );
        print("level 28 Next: " + gold + " Coins");
    }

    public void level29Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 29 Next",
            parameters: tutParams
         );
        print("level 29 Next: " + gold + " Coins");
    }

    public void level30Next(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 30 Next",
            parameters: tutParams
         );
        print("level 30 Next: " + gold + " Coins");
    }

    #endregion

    #region Level CoinX4

    public void level1CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 1 Coin4x",
            parameters: tutParams
         );
        print("level 1 Coin4x: " + gold + " Coins");
    }

    public void level2CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 2 Coin4x",
            parameters: tutParams
         );
        print("level 2 Coin4x: " + gold + " Coins");
    }

    public void level3CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 3 Coin4x",
            parameters: tutParams
         );
        print("level 3 Coin4x: " + gold + " Coins");
    }

    public void level4CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 4 Coin4x",
            parameters: tutParams
         );
        print("level 4 Coin4x: " + gold + " Coins");
    }

    public void level5CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 5 Coin4x",
            parameters: tutParams
         );
        print("level 5 Coin4x: " + gold + " Coins");
    }

    public void level6CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 6 Coin4x",
            parameters: tutParams
         );
        print("level 6 Coin4x: " + gold + " Coins");
    }

    public void level7CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 7 Coin4x",
            parameters: tutParams
         );
        print("level 7 Coin4x: " + gold + " Coins");
    }

    public void level8CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 8 Coin4x",
            parameters: tutParams
         );
        print("level 8 Coin4x: " + gold + " Coins");
    }

    public void level9CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 9 Coin4x",
            parameters: tutParams
         );
        print("level 9 Coin4x: " + gold + " Coins");
    }

    public void level10CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 10 Coin4x",
            parameters: tutParams
         );
        print("level 10 Coin4x: " + gold + " Coins");
    }

    public void level11CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 11 Coin4x",
            parameters: tutParams
         );
        print("level 11 Coin4x: " + gold + " Coins");
    }

    public void level12CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 12 Coin4x",
            parameters: tutParams
         );
        print("level 12 Coin4x: " + gold + " Coins");
    }

    public void level13CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 13 Coin4x",
            parameters: tutParams
         );
        print("level 13 Coin4x: " + gold + " Coins");
    }

    public void level14CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 14 Coin4x",
            parameters: tutParams
         );
        print("level 14 Coin4x: " + gold + " Coins");
    }

    public void level15CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 15 Coin4x",
            parameters: tutParams
         );
        print("level 15 Coin4x: " + gold + " Coins");
    }

    public void level16CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 16 Coin4x",
            parameters: tutParams
         );
        print("level 16 Coin4x: " + gold + " Coins");
    }

    public void level17CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 17 Coin4x",
            parameters: tutParams
         );
        print("level 17 Coin4x: " + gold + " Coins");
    }

    public void level18CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 18 Coin4x",
            parameters: tutParams
         );
        print("level 18 Coin4x: " + gold + " Coins");
    }

    public void level19CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 19 Coin4x",
            parameters: tutParams
         );
        print("level 19 Coin4x: " + gold + " Coins");
    }

    public void level20CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 20 Coin4x",
            parameters: tutParams
         );
        print("level 20 Coin4x: " + gold + " Coins");
    }

    public void level21CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 21 Coin4x",
            parameters: tutParams
         );
        print("level 21 Coin4x: " + gold + " Coins");
    }

    public void level22CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 22 Coin4x",
            parameters: tutParams
         );
        print("level 22 Coin4x: " + gold + " Coins");
    }

    public void level23CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 23 Coin4x",
            parameters: tutParams
         );
        print("level 23 Coin4x: " + gold + " Coins");
    }

    public void level24CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 24 Coin4x",
            parameters: tutParams
         );
        print("level 24 Coin4x: " + gold + " Coins");
    }

    public void level25CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 25 Coin4x",
            parameters: tutParams
         );
        print("level 25 Coin4x: " + gold + " Coins");
    }

    public void level26CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 26 Coin4x",
            parameters: tutParams
         );
        print("level 26 Coin4x: " + gold + " Coins");
    }

    public void level27CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 27 Coin4x",
            parameters: tutParams
         );
        print("level 27 Coin4x: " + gold + " Coins");
    }

    public void level28CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 28 Coin4x",
            parameters: tutParams
         );
        print("level 28 Coin4x: " + gold + " Coins");
    }

    public void level29CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 29 Coin4x",
            parameters: tutParams
         );
        print("level 29 Coin4x: " + gold + " Coins");
    }

    public void level30CoinX4(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 30 Coin4x",
            parameters: tutParams
         );
        print("level 30 Coin4x: " + gold + " Coins");
    }

    #endregion

    #region Play
    public void level1Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 1 Play",
            parameters: tutParams
         );
    //    print("level 1 Play: " + gold + " Coins");
    }

    public void level2Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 2 Play",
            parameters: tutParams
         );
    //    print("level 2 Play: " + gold + " Coins");
    }

    public void level3Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 3 Play",
            parameters: tutParams
         );
     //   print("level 3 Play: " + gold + " Coins");
    }

    public void level4Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 4 Play",
            parameters: tutParams
         );
      //  print("level 4 Play: " + gold + " Coins");
    }

    public void level5Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 5 Play",
            parameters: tutParams
         );
       // print("level 5 Play: " + gold + " Coins");
    }

    public void level6Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 6 Play",
            parameters: tutParams
         );
      //  print("level 6 Play: " + gold + " Coins");
    }

    public void level7Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 7 Play",
            parameters: tutParams
         );
      //  print("level 7 Play: " + gold + " Coins");
    }

    public void level8Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 8 Play",
            parameters: tutParams
         );
      //  print("level 8 Play: " + gold + " Coins");
    }

    public void level9Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 9 Play",
            parameters: tutParams
         );
       // print("level 9 Play: " + gold + " Coins");
    }

    public void level10Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 10 Play",
            parameters: tutParams
         );
       // print("level 10 Play: " + gold + " Coins");
    }

    public void level11Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 11 Play",
            parameters: tutParams
         );
     //   print("level 11 Play: " + gold + " Coins");
    }

    public void level12Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 12 Play",
            parameters: tutParams
         );
     //  print("level 12 Play: " + gold + " Coins");
    }

    public void level13Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 13 Play",
            parameters: tutParams
         );
     //   print("level 13 Play: " + gold + " Coins");
    }

    public void level14Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 14 Play",
            parameters: tutParams
         );
     //   print("level 14 Play: " + gold + " Coins");
    }

    public void level15Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 15 Play",
            parameters: tutParams
         );
     //   print("level 15 Play: " + gold + " Coins");
    }

    public void level16Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 16 Play",
            parameters: tutParams
         );
     //   print("level 16 Play: " + gold + " Coins");
    }

    public void level17Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 17 Play",
            parameters: tutParams
         );
     //   print("level 17 Play: " + gold + " Coins");
    }

    public void level18Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 18 Play",
            parameters: tutParams
         );
     //   print("level 18 Play: " + gold + " Coins");
    }

    public void level19Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 19 Play",
            parameters: tutParams
         );
     //   print("level 19 Play: " + gold + " Coins");
    }

    public void level20Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 20 Play",
            parameters: tutParams
         );
      //  print("level 20 Play: " + gold + " Coins");
    }

    public void level21Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 21 Play",
            parameters: tutParams
         );
      //  print("level 21 Play: " + gold + " Coins");
    }

    public void level22Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 22 Play",
            parameters: tutParams
         );
    //    print("level 22 Play: " + gold + " Coins");
    }

    public void level23Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 23 Play",
            parameters: tutParams
         );
    //    print("level 23 Play: " + gold + " Coins");
    }

    public void level24Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 24 Play",
            parameters: tutParams
         );
    //    print("level 24 Play: " + gold + " Coins");
    }

    public void level25Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 25 Play",
            parameters: tutParams
         );
     //   print("level 25 Play: " + gold + " Coins");
    }

    public void level26Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 26 Play",
            parameters: tutParams
         );
     //   print("level 26 Play: " + gold + " Coins");
    }

    public void level27Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 27 Play",
            parameters: tutParams
         );
     //   print("level 27 Play: " + gold + " Coins");
    }

    public void level28Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 28 Play",
            parameters: tutParams
         );
      //  print("level 28 Play: " + gold + " Coins");
    }

    public void level29Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 29 Play",
            parameters: tutParams
         );
    //    print("level 29 Play: " + gold + " Coins");
    }

    public void level30Play(int gold)
    {
        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 30 Play",
            parameters: tutParams
         );
    //    print("level 30 Play: " + gold + " Coins");
    }
    #endregion

    #region Level Go
    public void level1go(int gold)
    {
        
            var tutParams = new Dictionary<string, object>();
            tutParams["Coins"] = gold.ToString();

            FB.LogAppEvent(
                "Level 1 Go",
                parameters: tutParams
             );
            print("level 1 Go: " + gold + " Coins");
        }

    public void level2go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 2 Go",
            parameters: tutParams
         );
        print("level 2 Go: " + gold + " Coins");
    }

    public void level3go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 3 Go",
            parameters: tutParams
         );
        print("level 3 Go: " + gold + " Coins");
    }
    public void level4go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 4 Go",
            parameters: tutParams
         );
        print("level 4 Go: " + gold + " Coins");
    }

    public void level5go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 5 Go",
            parameters: tutParams
         );
        print("level 5 Go: " + gold + " Coins");
    }

    public void level6go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 6 Go",
            parameters: tutParams
         );
        print("level 6 Go: " + gold + " Coins");
    }

    public void level7go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 7 Go",
            parameters: tutParams
         );
        print("level 7 Go: " + gold + " Coins");
    }

    public void level8go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 8 Go",
            parameters: tutParams
         );
        print("level 8 Go: " + gold + " Coins");
    }

    public void level9go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 9 Go",
            parameters: tutParams
         );
        print("level 9 Go: " + gold + " Coins");
    }

    public void level10go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 10 Go",
            parameters: tutParams
         );
        print("level 10 Go: " + gold + " Coins");
    }

    public void level11go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 11 Go",
            parameters: tutParams
         );
        print("level 11 Go: " + gold + " Coins");
    }

    public void level12go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 12 Go",
            parameters: tutParams
         );
        print("level 12 Go: " + gold + " Coins");
    }

    public void level13go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 13 Go",
            parameters: tutParams
         );
        print("level 13 Go: " + gold + " Coins");
    }
    public void level14go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 14 Go",
            parameters: tutParams
         );
        print("level 14 Go: " + gold + " Coins");
    }

    public void level15go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 15 Go",
            parameters: tutParams
         );
        print("level 15 Go: " + gold + " Coins");
    }

    public void level16go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 16 Go",
            parameters: tutParams
         );
        print("level 16 Go: " + gold + " Coins");
    }

    public void level17go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 17 Go",
            parameters: tutParams
         );
        print("level 17 Go: " + gold + " Coins");
    }

    public void level18go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 18 Go",
            parameters: tutParams
         );
        print("level 18 Go: " + gold + " Coins");
    }

    public void level19go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 19 Go",
            parameters: tutParams
         );
        print("level 19 Go: " + gold + " Coins");
    }

    public void level20go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 20 Go",
            parameters: tutParams
         );
        print("level 20 Go: " + gold + " Coins");
    }

    public void level21go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 21 Go",
            parameters: tutParams
         );
        print("level 21 Go: " + gold + " Coins");
    }

    public void level22go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 22 Go",
            parameters: tutParams
         );
        print("level 22 Go: " + gold + " Coins");
    }

    public void level23go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 23 Go",
            parameters: tutParams
         );
        print("level 23 Go: " + gold + " Coins");
    }
    public void level24go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 24 Go",
            parameters: tutParams
         );
        print("level 24 Go: " + gold + " Coins");
    }

    public void level25go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 25 Go",
            parameters: tutParams
         );
        print("level 25 Go: " + gold + " Coins");
    }

    public void level26go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 26 Go",
            parameters: tutParams
         );
        print("level 26 Go: " + gold + " Coins");
    }

    public void level27go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 27 Go",
            parameters: tutParams
         );
        print("level 27 Go: " + gold + " Coins");
    }

    public void level28go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 28 Go",
            parameters: tutParams
         );
        print("level 28 Go: " + gold + " Coins");
    }

    public void level29go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 29 Go",
            parameters: tutParams
         );
        print("level 29 Go: " + gold + " Coins");
    }

    public void level30go(int gold)
    {

        var tutParams = new Dictionary<string, object>();
        tutParams["Coins"] = gold.ToString();

        FB.LogAppEvent(
            "Level 30 Go",
            parameters: tutParams
         );
        print("level 30 Go: " + gold + " Coins");
    }
    #endregion

    #region settings

    public void OpenApp()
    {

        FB.LogAppEvent(
            "AppOpen");
         //print("AppOpen");
    }
    public void CloseApp()
    {

        FB.LogAppEvent(
            "AppClose");
        //print("AppClose");
    }

    
}

    #endregion
    
    




