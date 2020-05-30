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
}




