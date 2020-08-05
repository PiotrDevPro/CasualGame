using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Daily : MonoBehaviour
{
    public static Daily manage;
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
        
        lastOpen = ulong.Parse(PlayerPrefs.GetString("lastOpen"));
        if (!isReady())
        {
            RewardButton.interactable = false;
            //isReadyB = true;
        }
    }

   
    void Update()
    {

        if (!RewardButton.IsInteractable())
        {
            if (isReady())
            {
                RewardButton.interactable = true;
                Timer.text = "DAILY REWARD";
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
            //GameObject anim = GameObject.Find("DayReward");
            //anim.GetComponent<Animator>().SetBool("push",true);
        }
    }

    public void Click()
    {
        lastOpen = ((ulong)DateTime.Now.Ticks);
        PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        RewardButton.interactable = false;
        //Amplitude.Instance.logEvent("Daily Reward");
        Invoke("latencyCoinUpdate",1.6f);
        Invoke("latencySpawnCoin", 1f);
        GameObject fx = GameObject.Find("PS_A5_Coin_Pickup_Blue");
        fx.GetComponent<ParticleSystem>().Play();
        RewardButton.GetComponent<Animator>().SetBool("push",false);
        GameObject anim = GameObject.Find("DailyRewAnimClicked");
        if (PlayerPrefs.GetInt("Subscribe") == 1)
        {
            GameObject tx500 = GameObject.Find("txReward");
            tx500.GetComponent<Text>().text = "+500";
        }
        anim.GetComponent<Animator>().SetBool("push",true);
        Invoke("LatencySound",0.3f);
        Invoke("TimeToDeactivate", 0.5f);
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
        CoinDotween.manage.animate(15);
    }
    void latencyCoinUpdate()
    {
        if (PlayerPrefs.GetInt("Subscribe") != 1)
        {
            StartCoroutine(CoinGet());
        }
        else
        {
            StartCoroutine(CoinGet500());
        }
            
        
        Main.manage._coinFx.SetActive(true);

    }

    IEnumerator CoinGet()
    {
        ;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f); 
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
        sndfx.GetComponent<AudioSource>().Play();
    }

    IEnumerator CoinGet500()
    {
        ;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
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
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 190);
        sndfx.GetComponent<AudioSource>().Play();
    }

    private bool isReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float seconleft = (float)(msToWait - m) / 1000f;

        if (seconleft < 0)
        {
            Timer.text = "DAILY REWARD";
            return true;
        }

        return false;
    }

    void TimeToDeactivate()
    {
        Main.manage._coinFx.SetActive(false);
    }
}
