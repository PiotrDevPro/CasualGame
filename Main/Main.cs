using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main manage;
    public SoundManager audioUI;
    public MenuGui menuGUI;

    public GameObject Settings;
    public GameObject ShopCoins;
    public GameObject TapToPlayButton;
    public GameObject _Go;
    public GameObject QstPanel;
    public GameObject _coinFx;
    public GameObject AnimTraning;
    public GameObject jumpTrig;
    public GameObject enemySpawn;
    public GameObject NoAdsBtn;
    ///public Text coins;
    //public 

    public bool isTapToPlay = false;
    public bool isMove = false;
    public bool isCutTheRope = false;
    public bool isGo = false;
    public bool isAdShowed = false;
    public bool isShowAds = false;
    public bool IsSettingActive = false;
    bool isShopOpening = false;
    private GameObject textActive;
    private GameObject _player;
    private GameObject coin;
    private GameObject coinShop;
    private GameObject trainingMouse;
    [System.Serializable]
    public class MenuGui
    {

        public Toggle vibro;

        public GameObject mainSound;
        public GameObject mainMusic;
        public GameObject VibroActive;

        //shop
        public GameObject activeSide1;
        public GameObject activeSide2;
        public GameObject paperSide1;
        public GameObject paperSide2;
        public GameObject next;
        public GameObject prev;


    }

    [System.Serializable]
    public class SoundManager
    {
        public AudioSource main;
    }
     void Awake()
    {
        manage = this;
        LoadSettings();
       
    }
     void Start()
    {
        
        Settings.SetActive(false);
        ShopCoins.SetActive(false);
        _Go.SetActive(false);
        _coinFx.SetActive(false);
        QstPanel.SetActive(false);
        _player = GameObject.Find("Default");
        _player.GetComponent<Assets.HeroEditor.Common.CharacterScripts.CharacterFlip>().enabled = false;
        //PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 150);
        if (PlayerPrefs.GetInt("NoAds") == 1)
        {
            NoAdsBtn.SetActive(false);
        }
    }

    void Update()
    {
        //PlayerPrefs.DeleteAll();
        trainingMouse = GameObject.Find("MouseIcon");
        Coinz();

    }

    #region Settings
    public void SettingsOpen()
    {

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            menuGUI.mainSound.SetActive(true);
        }
        else
        {
            menuGUI.mainSound.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            menuGUI.mainMusic.SetActive(true);
        }
        else
        {
            menuGUI.mainMusic.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            menuGUI.VibroActive.SetActive(true);
        }
        else
        {
            menuGUI.VibroActive.SetActive(false);
        }
        GameObject soundShopOpen = GameObject.Find("MenuOpen");
        soundShopOpen.GetComponent<AudioSource>().Play();
        Settings.SetActive(true);
        IsSettingActive = true;

    }

    public void SettingsClose()
    {
        GameObject sound = GameObject.Find("MenuClose");
        sound.GetComponent<AudioSource>().Play();
        IsSettingActive = false;
        Settings.SetActive(false);
    }

    public void SoundOffOn(Toggle tgl)
    {
        if (tgl.isOn)
        {
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.pause = true;
            menuGUI.mainSound.SetActive(false);
            

        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.pause = false;
            menuGUI.mainSound.SetActive(true);
        }
    }

    public void MusicOnOff(Toggle tgl)
    {
        if (tgl.isOn)
        {
            PlayerPrefs.SetInt("Music", 1);
            audioUI.main.mute = true;
            menuGUI.mainMusic.SetActive(false);

        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            audioUI.main.mute = false;
            menuGUI.mainMusic.SetActive(true);
        }
    }

    public void VibroOnOff(Toggle tgl)
    {
        if (tgl.isOn)
        {
            PlayerPrefs.SetInt("Vibro", 0);
            menuGUI.VibroActive.SetActive(true);
            Handheld.Vibrate();
        }
        else
        {
            PlayerPrefs.SetInt("Vibro", 1);
            menuGUI.VibroActive.SetActive(false);
        }
    }

    public void LoadSettings()
    {
        AudioListener.pause = (PlayerPrefs.GetInt("Sound") == 1) ? true : false;
        menuGUI.vibro.isOn=(PlayerPrefs.GetInt("Vibro") == 1) ? true : false;
        //audioUI.main.GetComponent<AudioSource>().mute = (PlayerPrefs.GetInt("Music") == 1) ? true : false;
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(Application.loadedLevel);
    }


    #endregion

    #region Shop

    public void ShopOpen()
    {
        isShopOpening = true;
        IsSettingActive = true;
        GameObject sound = GameObject.Find("MenuOpen");
        sound.GetComponent<AudioSource>().Play();
        ShopCoins.SetActive(true);
        menuGUI.activeSide1.SetActive(false);
        menuGUI.activeSide2.SetActive(false);
        menuGUI.prev.SetActive(false);
        menuGUI.next.SetActive(true);
        //textActive.SetActive(false);
    }
    public void ShopClose()
    {
        isShopOpening = false;
        IsSettingActive = false;
        ShopCoins.SetActive(false);
        menuGUI.paperSide1.SetActive(true);
        menuGUI.paperSide2.SetActive(false);
        //textActive.SetActive(true);

    }
    public void NextSide()
    {
        menuGUI.paperSide1.SetActive(false);
        menuGUI.paperSide2.SetActive(true);
        menuGUI.next.SetActive(false);
        menuGUI.prev.SetActive(true);
        menuGUI.activeSide1.SetActive(true);
        menuGUI.activeSide2.SetActive(true);
    }
    public void PrevSide()
    {
        menuGUI.paperSide1.SetActive(true);
        menuGUI.paperSide2.SetActive(false);
        menuGUI.activeSide1.SetActive(false);
        menuGUI.activeSide2.SetActive(false);
        menuGUI.next.SetActive(true);
        menuGUI.prev.SetActive(false);
    }

    #endregion

    #region Game

    void GoButtonPos()
    {
        _Go.transform.position = new Vector2(_player.transform.position.x, _player.transform.position.y - 0.5f);
        QstPanel.transform.position = new Vector2(_player.transform.position.x + 0.3f, _player.transform.position.y + 1.7f);
        // if (PlayerPrefs.GetInt("level") == 3)
        // {
        //     _Go.transform.position = new Vector3(0, 0, 0);
        //  }
        // else
        //  {
        //      
        //  }
    }

    public void TapToPlay()
    {
        isTapToPlay = true;
        _Go.SetActive(true);
        QstPanel.SetActive(true);
        GameObject animm = GameObject.Find("quest");
        animm.GetComponentInChildren<Animator>().SetBool("active",true);
        TapToPlayButton.SetActive(false);
        IsTapToPlaySetting();
        GoButtonPos();
    }

    void IsTapToPlaySetting()
    {
        if (PlayerPrefs.GetInt("level") != 5 && PlayerPrefs.GetInt("level") != 6 && PlayerPrefs.GetInt("level") != 7
            && PlayerPrefs.GetInt("level") != 8 && PlayerPrefs.GetInt("level") != 9 && PlayerPrefs.GetInt("level") != 21 && PlayerPrefs.GetInt("level") != 22)
        {
            GameObject natureSound = GameObject.Find("nature");
            natureSound.GetComponent<AudioSource>().Play();
        }
        PlayerController.manage._startTime = true;
        levelGenerated.manage.TimerSpawn();
        if (PlayerPrefs.GetInt("Coin") == 0 && PlayerPrefs.GetInt("level") == 0)
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 20);
            _coinFx.SetActive(true);
            Invoke("CoinsFxActive", 0.5f);
        }
        if (PlayerPrefs.GetInt("level") == 2)
        {
            GameObject cursorr = GameObject.Find("cursorr1");
            cursorr.SetActive(false);
        }

        if (PlayerPrefs.GetInt("level") == 4)
        {
            GameObject cursorr1 = GameObject.Find("cursorr");
            cursorr1.SetActive(false);
            GameObject cursorrHorizontal = GameObject.Find("cursorVert");
            cursorrHorizontal.SetActive(false);
        }

    }

    public void GoStart()
    {
        isMove = true;
        GameObject animm = GameObject.Find("quest");
        animm.GetComponentInChildren<Animator>().SetBool("active", false);
        _Go.SetActive(false);
        QstPanel.SetActive(false);
        isCutTheRope = true;
        isGo = true;


    }

    public void Restart()
    {
        isCutTheRope = false;
        isAdShowed = false;
        if (PlayerPrefs.GetInt("Coin") >= 20)
        {
            SceneManager.LoadScene(Application.loadedLevel);
            PlayerPrefs.GetInt("level", PlayerPrefs.GetInt("level"));
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 20);
        }
        else
        {
            Invoke("EnoughMoney",0.03f); 
        }
    }

    void EnoughMoney()
    {

        GameObject soundFx = GameObject.Find("EnoughMoneySound");
        soundFx.GetComponent<AudioSource>().Play();
        ShopOpen();
        
    }

    public void MoreMoney()
    {
       // if (PlayerPrefs.GetInt("level") == 0)
       // {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1000);
            _coinFx.SetActive(true);
            Invoke("CoinsFxActive", 0.5f);
        //}
    }

    public void Coins()
    {
  
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 5);
        _coinFx.SetActive(true);
        Invoke("CoinsFxActive",0.5f);
    }
    public void NoAdsButtonActive()
    {
        NoAdsBtn.SetActive(false);
    }
   // public void Coin

     void CoinsFxActive()
    {
        _coinFx.SetActive(false);
    }

     void Coinz()
    {
        if (isTapToPlay)
        {
            audioUI.main.mute = true;
        }

        if (PlayerPrefs.GetInt("Coin") < 0)
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
        coin = GameObject.Find("coinTx");
        coin.GetComponent<Text>().text = PlayerPrefs.GetInt("Coin").ToString();
        if (isShopOpening)
        {
            coinShop = GameObject.Find("shopCoinTx");
            coinShop.GetComponent<Text>().text = PlayerPrefs.GetInt("Coin").ToString();
        }
    }

    #endregion
}
