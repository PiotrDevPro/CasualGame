using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DailyRewardSubscribe : MonoBehaviour
{
    public static DailyRewardSubscribe manage;
    public float msToWait = 5000f;

    public Text Timer;
    public Button RewardButton;
    private ulong lastOpen;
    public bool isReadyB;
    private void Awake()
    {
        manage = this;
    }
    void Start()
    {
        lastOpen = ulong.Parse(PlayerPrefs.GetString("lastOpenBonus"));
        if (PlayerPrefs.GetInt("Subscribe")!=0) 
        {
           // Main.manage.ButtonStateBonus.SetActive(true);
            if (!isReady())
            {
                //RewardButton.interactable = false;
                Main.manage.ButtonStateBonus.SetActive(true);
                //isReadyB = true;
            }
        }

        if (PlayerPrefs.GetInt("Subscribe") == 0)
        {
                Main.manage.ButtonStateBonus.SetActive(false);
        }
        
    }


    void Update()
    {
        print(PlayerPrefs.GetInt("Subscribe"));
        if (PlayerPrefs.GetInt("Subscribe")!=0)
        {
            
          
                if (isReady())
                {
                    Main.manage.ButtonStateBonus.SetActive(false);
                    Timer.text = "Get 500 Coins";
                    //isReadyB = false;
                    return;
                }
                ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
                ulong m = diff / TimeSpan.TicksPerMillisecond;
                float seconleft = (float)(msToWait - m) / 1000f;
                string t = "";
                t += ((int)seconleft / 3600).ToString() + ":";
                seconleft -= ((int)seconleft / 3600) * 3600;
                t += ((int)seconleft / 60).ToString("00") + ":";
                t += ((int)seconleft % 60).ToString("00") + "";
                Timer.text = t.ToString();
            }

    }

    public void Click()
    {
       if  (PlayerPrefs.GetInt("Subscribe") != 0)   
        {
            lastOpen = ((ulong)DateTime.Now.Ticks);
            PlayerPrefs.SetString("lastOpenBonus", lastOpen.ToString());
            //RewardButton.interactable = false;
            Main.manage.ButtonStateBonus.SetActive(true);
            //Amplitude.Instance.logEvent("Daily Reward");
            Invoke("latencyCoinUpdate", 1.6f);
            Invoke("latencySpawnCoin", 1f);
            //GameObject fx = GameObject.Find("PS_A5_Coin_Pickup_Blue");
            //fx.GetComponent<ParticleSystem>().Play();
            //RewardButton.GetComponent<Animator>().SetBool("push", false);
            //GameObject anim = GameObject.Find("DailyRewAnimClicked");
            //anim.GetComponent<Animator>().SetBool("push", true);
            Invoke("LatencySound", 0.3f);
            Invoke("TimeToDeactivate", 0.5f);
        }
        else
        {
            Main.manage.ButtonStateBonus.SetActive(false);
        }
    }

    void LatencySound()
    {
        GameObject snd = GameObject.Find("coinFx");
        snd.GetComponent<AudioSource>().Play();
    }


    void latencySpawnCoin()
    {
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(150);
    }
    void latencyCoinUpdate()
    {

        StartCoroutine(CoinGet());
        Main.manage._coinFx.SetActive(true);

    }

    IEnumerator CoinGet()
    {
        ;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
        sndfx.GetComponent<AudioSource>().Play();
    }

    private bool isReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float seconleft = (float)(msToWait - m) / 1000f;

        if (seconleft < 0)
        {
            Timer.text = "Get 500 Coins";
            return true;
        }

        return false;
    }

    void TimeToDeactivate()
    {
        Main.manage._coinFx.SetActive(false);
    }
}
