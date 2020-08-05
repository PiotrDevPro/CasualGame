using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEngine.Rendering;


public class Main : MonoBehaviour
{
    public static Main manage;
    public CharacterManager[] characterManager;
    public SoundManager audioUI;
    public MenuGui menuGUI;

    public GameObject Settings;
    public GameObject ShopCoins;
    public GameObject SkinStore;
    public GameObject TapToPlayButton;
    public GameObject _Go;
    public GameObject SubscribePanel;
    public GameObject BuySubscribeBtn;
    public GameObject ButtonStateBonus;
    //public GameObject QstPanel;
    public GameObject _coinFx;
    public GameObject AnimTraning;
    public GameObject jumpTrig;
    public GameObject enemySpawn;
    public GameObject NoAdsBtn;
    public GameObject NextBtn;
    public GameObject RUSurePanel;
    public GameObject LTBox;
    public GameObject LTBoxAds;
    public GameObject NoWiFi;
    public int currentCharNumber = 0;
    private CharacterManager currentCharacter;
    ///public Text coins;
    //public 

    public bool isTapToPlay = false;
    public bool isMove = false;
    public bool isCutTheRope = false;
    public bool isGo = false;
    public bool isAdShowed = false;
    public bool isShowAds = false;
    public bool IsSettingActive = false;
    public bool isSkinShopActive = false;
    public bool isOpenSubscribeShop = false;
    bool isShopOpening = false;

    private GameObject textActive;
    private GameObject _player;
    private GameObject coin;
    private GameObject coinShop;
    private GameObject trainingMouse;
    private int coinz;
    private int count = 0;
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

        //character
        public GameObject buyNewCharacter;
        public Text characterName;
        public Text characterPrice;


        public Sprite spr;
        public GameObject SubscribeButtonActive;
    }

    [System.Serializable]
    public class SoundManager
    {
        public AudioSource main;
    }

    [System.Serializable]

    public class CharacterManager
    {
        public string name = "John";
        public int price;
        public GameObject character;
        [HideInInspector]
        public bool Bought = false;
    }
    void Awake()
    {
        manage = this;
        LoadSettings();
        CharacterBuyState();
      //  if (PlayerPrefs.GetInt("Subscribe") == 0)
      //  {
        //    isOpenSubscribeShop = true;
     //       Invoke("LatencyCloseSubscribe",0.5f);
      //  }
    }
     void Start()
    {
        CurrentCharacter();
        Settings.SetActive(false);
        ShopCoins.SetActive(false);
        _Go.SetActive(false);
        _coinFx.SetActive(false);
        // SaveIncomeCoins();
        coinz = PlayerPrefs.GetInt("Coin");
        if (PlayerPrefs.GetInt("NoAds") == 1)
        {
            NoAdsBtn.SetActive(false);
        }
    }

    void Update()
    {
        //print(characterManager[currentCharNumber].Bought);
        //print(PlayerPrefs.GetInt("CurrentChar"));
        //PlayerPrefs.DeleteAll();
        trainingMouse = GameObject.Find("MouseIcon");
        Coinz();
        //BoughtSetting();
        //SaveIncomeCoins();
        if (!isGo)
        {
            
            _player = GameObject.FindGameObjectWithTag("Player");
            GoButtonPos();
            

        }
        if (!isOpenSubscribeShop)
        {
            
            count += 1;
            if (count == 1)
            {
                AppDealManager.manage.ShowBanner();
                //print("!sisOpenSubscribeShop");
                
            }   
        }
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
        Amplitude.Instance.logEvent("SeenSetting");
        //FbManager.manage.SettingOpen(PlayerPrefs.GetInt("Coin"));

    }

    public void SettingsClose()
    {
        GameObject sound = GameObject.Find("MenuClose");
        sound.GetComponent<AudioSource>().Play();
        IsSettingActive = false;
        Settings.SetActive(false);
        //Amplitude.Instance.logEvent("OptionsClose");
        //FbManager.manage.SettingClose(PlayerPrefs.GetInt("Coin"));
    }

    public void SoundOffOn(Toggle tgl)
    {
        if (tgl.isOn)
        {
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.pause = true;
            menuGUI.mainSound.SetActive(false);
            //Amplitude.Instance.logEvent("SoundOff");
           // FbManager.manage.SoundOff(PlayerPrefs.GetInt("Coin"));

        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.pause = false;
            menuGUI.mainSound.SetActive(true);
            //Amplitude.Instance.logEvent("SoundOn");
            //FbManager.manage.SoundOn(PlayerPrefs.GetInt("Coin"));
        }
    }

    public void MusicOnOff(Toggle tgl)
    {
        if (tgl.isOn)
        {
            PlayerPrefs.SetInt("Music", 1);
            audioUI.main.mute = true;
            menuGUI.mainMusic.SetActive(false);
            //Amplitude.Instance.logEvent("MusicOff");
            if (PlayerPrefs.GetInt("level") != 5 && PlayerPrefs.GetInt("level") != 6 && PlayerPrefs.GetInt("level") != 7
                && PlayerPrefs.GetInt("level") != 8 && PlayerPrefs.GetInt("level") != 9 && PlayerPrefs.GetInt("level") != 21 && PlayerPrefs.GetInt("level") != 22)
            {
                GameObject natureSound = GameObject.Find("nature");
                natureSound.GetComponent<AudioSource>().Stop();
            }
            // FbManager.manage.MusicOff(PlayerPrefs.GetInt("Coin"));

        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            audioUI.main.mute = false;
            menuGUI.mainMusic.SetActive(true);
            //Amplitude.Instance.logEvent("MusicOn");
            if (PlayerPrefs.GetInt("level") != 5 && PlayerPrefs.GetInt("level") != 6 && PlayerPrefs.GetInt("level") != 7
                && PlayerPrefs.GetInt("level") != 8 && PlayerPrefs.GetInt("level") != 9 && PlayerPrefs.GetInt("level") != 21 && PlayerPrefs.GetInt("level") != 22)
            {
                GameObject natureSound = GameObject.Find("nature");
                natureSound.GetComponent<AudioSource>().Play();
            }
            
        }
    }

    public void VibroOnOff(Toggle tgl)
    {
        if (tgl.isOn)
        {
            PlayerPrefs.SetInt("Vibro", 0);
            menuGUI.VibroActive.SetActive(true);
            Handheld.Vibrate();
            //Amplitude.Instance.logEvent("VibroOn");
          
        }
        else
        {
            PlayerPrefs.SetInt("Vibro", 1);
            menuGUI.VibroActive.SetActive(false);
            //Amplitude.Instance.logEvent("VibroOff");
         
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
           RUSurePanel.SetActive(true);
           GameObject snd = GameObject.Find("ResetSnd");
           snd.GetComponent<AudioSource>().Play();
       }

       public void ResetNo()
         {
             RUSurePanel.SetActive(false);
             GameObject sound = GameObject.Find("MenuClose");
             sound.GetComponent<AudioSource>().Play();

         }

       public void ResetYes()
         {
             //Amplitude.Instance.logEvent("ResetAll");
             PlayerPrefs.DeleteAll();
             SceneManager.LoadScene(Application.loadedLevel);
         }
       
    public void NoWiFiWindowClose()
    {
        NoWiFi.SetActive(false);
    }
    
    #endregion

    #region Shop
    public void SkinShopOpen()
    {
        if (!isGo) //!PlayerController.manage.isDead)
        {
            SkinStore.SetActive(true);
            isSkinShopActive = true;
          //  GameObject canvasLayer = GameObject.Find("CanvasM");
          //  canvasLayer.GetComponent<Canvas>().sortingOrder = 499;
          //  _player.GetComponentInChildren<SortingGroup>().sortingOrder = 500;
          //  _player.GetComponent<Rigidbody>().isKinematic = true;
          //  _player.GetComponent<CapsuleCollider>().enabled = false;
          //  _player.GetComponent<Transform>().localScale = new Vector2(1.5f, 1.5f);
          //  _player.GetComponent<Transform>().position = new Vector2(0, -1);
        }
        
    }
    public void SkinShopClose()
    {
      //  if (characterManager[currentCharNumber].Bought)
       // {
           //s CurrentCharacter();
            SkinStore.SetActive(false);
            isSkinShopActive = false;
          //  GameObject canvasLayer = GameObject.Find("CanvasM");
          //  canvasLayer.GetComponent<Canvas>().sortingOrder = 500;
         //   _player.GetComponentInChildren<SortingGroup>().sortingOrder = 200;
         //   _player.GetComponent<Rigidbody>().isKinematic = false;
         //   _player.GetComponent<CapsuleCollider>().enabled = true;
         //   _player.GetComponent<Transform>().localScale = new Vector2(0.45f, 0.45f);
            levelGenerated.manage.PlayerSpawnPosition();
       // }
}
    public void ShopOpen()
    {
        Amplitude.Instance.logEvent("SeenStore");
        // FbManager.manage.Shop(PlayerPrefs.GetInt("Coin"));
        isShopOpening = true;
        IsSettingActive = true;
        GameObject sound = GameObject.Find("MenuOpen");
        sound.GetComponent<AudioSource>().Play();
        ShopCoins.SetActive(true);
        menuGUI.activeSide1.SetActive(false);
        menuGUI.activeSide2.SetActive(false);
        menuGUI.prev.SetActive(false);
        //menuGUI.next.SetActive(true);
        
        if (Daily.manage.RewardButton.IsInteractable())
        {
            Daily.manage.RewardButton.GetComponent<Animator>().SetBool("push", true) ;
        }
        else
        {
            Daily.manage.RewardButton.GetComponent<Animator>().SetBool("push", false);
        }
    }
    public void ShopClose()
    {
        //Amplitude.Instance.logEvent("ShopClose");
        isShopOpening = false;
        IsSettingActive = false;
        ShopCoins.SetActive(false);
        menuGUI.paperSide1.SetActive(true);
        menuGUI.paperSide2.SetActive(false);
        if (isSkinShopActive)
        {
            GameObject canvasLayer = GameObject.Find("CanvasM");
            canvasLayer.GetComponent<Canvas>().sortingOrder = 499;
            _player.GetComponentInChildren<SortingGroup>().sortingOrder = 500;
        }
        if (Daily.manage.RewardButton.IsInteractable())
        {
            Daily.manage.RewardButton.GetComponent<Animator>().SetBool("push", true);
        }
        else
        {
            Daily.manage.RewardButton.GetComponent<Animator>().SetBool("push", false);
        }
        

    }
    public void NextSide()
    {
        menuGUI.paperSide1.SetActive(false);
        menuGUI.paperSide2.SetActive(true);
        menuGUI.next.SetActive(false);
        menuGUI.prev.SetActive(true);
       // menuGUI.activeSide1.SetActive(true);
       // menuGUI.activeSide2.SetActive(true);
    }
    public void PrevSide()
    {
        menuGUI.paperSide1.SetActive(true);
        menuGUI.paperSide2.SetActive(false);
       //menuGUI.activeSide1.SetActive(false);
       //menuGUI.activeSide2.SetActive(false);
        menuGUI.next.SetActive(true);
        menuGUI.prev.SetActive(false);
    }
    public void SubscribePanelClose()
    {
        Amplitude.Instance.logEvent("SubscribeClose");
        SubscribePanel.SetActive(false);
        isOpenSubscribeShop = false;
        if (PlayerPrefs.GetInt("FirstBuy") == 1)
        {
            Invoke("latencyCoinUpdate", 1.6f);
            Invoke("latencySpawnCoin", 1f);
            Invoke("LatencySound", 0.3f);
            Invoke("TimeToDeactivate", 0.5f);
        }
        
    }
  
    public void MgBox()
    {
        
        LTBox.SetActive(true);
        LTBoxAds.SetActive(false);
        isShopOpening = true;
        GameObject snd = GameObject.Find("ResetSnd");
        snd.GetComponent<AudioSource>().Play();
        //print(PlayerPrefs.GetInt("box"));

        if (PlayerPrefs.GetInt("box") == 0)
        {
            
            GameObject bx1 = GameObject.Find("bx1");
            GameObject bx2 = GameObject.Find("bx2");
            GameObject bx3 = GameObject.Find("bx3");
            GameObject bx4 = GameObject.Find("bx4");
            GameObject bx5 = GameObject.Find("bx5");
            GameObject bx6 = GameObject.Find("bx6");
            GameObject bx7 = GameObject.Find("bx7");
            GameObject bx8 = GameObject.Find("bx8");
            GameObject bx9 = GameObject.Find("bx9");
            bx1.GetComponent<Button>().interactable = true;
            bx2.GetComponent<Button>().interactable = true;
            bx3.GetComponent<Button>().interactable = true;
            bx4.GetComponent<Button>().interactable = true;
            bx5.GetComponent<Button>().interactable = true;
            bx6.GetComponent<Button>().interactable = true;
            bx7.GetComponent<Button>().interactable = true;
            bx8.GetComponent<Button>().interactable = true;
            bx9.GetComponent<Button>().interactable = true;
            bx1.GetComponentInChildren<Text>().text = "";
            bx2.GetComponentInChildren<Text>().text = "";
            bx3.GetComponentInChildren<Text>().text = "";
            bx4.GetComponentInChildren<Text>().text = "";
            bx5.GetComponentInChildren<Text>().text = "";
            bx6.GetComponentInChildren<Text>().text = "";
            bx7.GetComponentInChildren<Text>().text = "";
            bx8.GetComponentInChildren<Text>().text = "";
            bx9.GetComponentInChildren<Text>().text = "";
        }

    }
    public void MgBoxClose()
    {
        LTBox.SetActive(false);
        isShopOpening = false;
        GameObject sound = GameObject.Find("MenuClose");
        sound.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("box", 0);
    }

    #region Loot Box
    public void box1()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin3", 0.1f);
            Invoke("latencyCoinUpdate3", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bx1 = GameObject.Find("bx1");
            bx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            bx1.GetComponentInChildren<Text>().text = "+3";
            print(PlayerPrefs.GetInt("box"));
            
        }
        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }

    }
    public void box2()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin1", 0.1f);
            Invoke("latencyCoinUpdate1", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bxx1 = GameObject.Find("bx2");
            bxx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            bxx1.GetComponentInChildren<Text>().text = "+1";
            print(PlayerPrefs.GetInt("box"));
        }
        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }
    public void box3()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin3", 0.1f);
            Invoke("latencyCoinUpdate3", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bxx1 = GameObject.Find("bx3");
            bxx1.GetComponent<Button>().interactable = false;
            bxx1.GetComponentInChildren<Text>().text = "+3";
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            print(PlayerPrefs.GetInt("box"));
            
        }
        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }
    public void box4()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin3", 0.1f);
            Invoke("latencyCoinUpdate3", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bx1 = GameObject.Find("bx4");
            bx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            print(PlayerPrefs.GetInt("box"));
            bx1.GetComponentInChildren<Text>().text = "+3";
        }

        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }
    public void box5()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin1", 0.1f);
            Invoke("latencyCoinUpdate1", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bx1 = GameObject.Find("bx5");
            bx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            print(PlayerPrefs.GetInt("box"));
            bx1.GetComponentInChildren<Text>().text = "+1";
        }

        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }
    public void box6()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin10", 0.1f);
            Invoke("latencyCoinUpdate10", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bx1 = GameObject.Find("bx6");
            bx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            print(PlayerPrefs.GetInt("box"));
            bx1.GetComponentInChildren<Text>().text = "+10";
        }

        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }
    public void box7()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin1", 0.1f);
            Invoke("latencyCoinUpdate1", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bx1 = GameObject.Find("bx7");
            bx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            print(PlayerPrefs.GetInt("box"));
            bx1.GetComponentInChildren<Text>().text = "+1";
        }

        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }
    public void box8()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin1", 0.1f);
            Invoke("latencyCoinUpdate1", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bx1 = GameObject.Find("bx8");
            bx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            print(PlayerPrefs.GetInt("box"));
            bx1.GetComponentInChildren<Text>().text = "+1";
        }

        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }
    public void box9()
    {
        if (PlayerPrefs.GetInt("box") != 3)
        {
            Invoke("latencySpawnCoin1", 0.1f);
            Invoke("latencyCoinUpdate1", 0.8f);
            Invoke("TimeToDeactivate", 1.2f);
            GameObject bx1 = GameObject.Find("bx9");
            bx1.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box") + 1);
            bx1.GetComponentInChildren<Text>().text = "+1";
        }
        if (PlayerPrefs.GetInt("box") == 3)
        {
            LTBoxAds.SetActive(true);
        }
    }

    void latencySpawnCoin3()
    {
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(3);
    }
    void latencyCoinUpdate3()
    {

        StartCoroutine(CoinGet3());
        _coinFx.SetActive(true);

    }

    void latencySpawnCoin10()
    {
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(10);
    }
    void latencyCoinUpdate10()
    {

        StartCoroutine(CoinGet10());
        _coinFx.SetActive(true);

    }
    IEnumerator CoinGet3()
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

        
    }

    IEnumerator CoinGet10()
    {

        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 2);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 6);
        sndfx.GetComponent<AudioSource>().Play();



    }

    IEnumerator CoinGet1()
    {

        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
    }
    void latencySpawnCoin1()
    {
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(1);
    }
    void latencyCoinUpdate1()
    {

        StartCoroutine(CoinGet1());
        _coinFx.SetActive(true);

    }
    void TimeToDeactivate()
    {
        _coinFx.SetActive(false);
        //isNoDoubleAds = false;
    }
    #endregion

    #region Coin Fx
    void LatencySound()
    {
        GameObject snd = GameObject.Find("coinFx");
        snd.GetComponent<AudioSource>().Play();
    }
    void latencySpawnCoin()
    {
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(50);
    }
    void latencyCoinUpdate()
    {
        StartCoroutine(CoinGetFirst500());
        Main.manage._coinFx.SetActive(true);


    }
    void PanelClose()
    {
        SubscribePanel.SetActive(false);
    }
    IEnumerator CoinGetFirst500()
    {
        GameObject sndfx = GameObject.Find("coinGet");
        sndfx.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
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
    #endregion

    #region Character
    public void Buy1()
    {
        
        foreach (CharacterManager CManager in characterManager)
        {
            
            currentCharNumber=0;
            
            if (CManager == characterManager[currentCharNumber])
            {
                
                CManager.character.SetActive(true);
                PlayerPrefs.SetInt("CurrentChar", currentCharNumber);
                _player = GameObject.FindGameObjectWithTag("Player");
                _player.GetComponentInChildren<SortingGroup>().sortingOrder = 500;
                _player.GetComponent<Rigidbody>().isKinematic = true;
                _player.GetComponent<CapsuleCollider>().enabled = false;
                _player.GetComponent<Transform>().localScale = new Vector2(1.5f, 1.5f);
                _player.GetComponent<Transform>().position = new Vector2(0, -1);
                GameObject canvasLayer = GameObject.Find("CanvasM");
                canvasLayer.GetComponent<Canvas>().sortingOrder = 499;
                //levelGenerated.manage.PlayerSpawnPosition();
                GoButtonPos();
                print(currentCharNumber);
            }
            else
            {
                CManager.character.SetActive(false);
                
            }
        }
    }
    public void Buy2()
        {
        
            currentCharNumber=1;
            //currentCharNumber = (int)Mathf.Repeat(currentCharNumber, characterManager.Length);
            foreach (CharacterManager CManager in characterManager)
            {
            

            if (CManager == characterManager[currentCharNumber])
                {
                    
                    CManager.character.SetActive(true);
                    currentCharacter = CManager;
                    PlayerPrefs.SetInt("CurrentChar", currentCharNumber);
                    GameObject canvasLayer = GameObject.Find("CanvasM");
                    canvasLayer.GetComponent<Canvas>().sortingOrder = 499;
                    _player = GameObject.FindGameObjectWithTag("Player");
                    _player.GetComponentInChildren<SortingGroup>().sortingOrder = 500;
                    _player.GetComponent<Rigidbody>().isKinematic = true;
                    _player.GetComponent<CapsuleCollider>().enabled = false;
                    _player.GetComponent<Transform>().localScale = new Vector2(1.5f, 1.5f);
                    _player.GetComponent<Transform>().position = new Vector2(0, -1);
                    //levelGenerated.manage.PlayerSpawnPosition();
                    GoButtonPos();
                    print(currentCharNumber);

            }
                else
            {
                    CManager.character.SetActive(false);
            }
        }

    }
    private void CurrentCharacter()
    {

        if (currentCharNumber != PlayerPrefs.GetInt("CurrentChar"))
        {
            currentCharNumber = PlayerPrefs.GetInt("CurrentChar");
            
                PlayerPrefs.SetInt("CurrentChar", 0);

                foreach (CharacterManager CManager in characterManager)
                {
                    if (CManager == characterManager[currentCharNumber])
                    {
                        currentCharacter = CManager;
                        CManager.character.SetActive(true);
                        levelGenerated.manage.PlayerSpawnPosition();
                        //GoButtonPos();
                    }
                    else
                    {
                        CManager.character.SetActive(false);
                    }
                }
            }
        
    }
    public void BuyEquip()
    {
        if (PlayerPrefs.GetInt("Coin")>=characterManager[currentCharNumber].price && !characterManager[currentCharNumber].Bought)
        {
            PlayerPrefs.SetInt("BoughtCharacter" + currentCharNumber.ToString(), 1);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - characterManager[currentCharNumber].price);
            characterManager[currentCharNumber].Bought = true;
        }
        else
        {
            Invoke("EnoughMoney", 0.03f);
        }
    }
    void BoughtSetting()
    {
        if (characterManager[currentCharNumber].Bought)
        {
            menuGUI.characterName.text = characterManager[currentCharNumber].name;
            menuGUI.characterPrice.text = "Your";
            menuGUI.buyNewCharacter.SetActive(false);
            PlayerPrefs.SetInt("CurrentChar",currentCharNumber);
            
        }
        else
        {
            menuGUI.buyNewCharacter.SetActive(true);
            menuGUI.characterName.text = characterManager[currentCharNumber].name;
            menuGUI.characterPrice.text = characterManager[currentCharNumber].price.ToString();
        }
    }
    void CharacterBuyState()
    {
        currentCharNumber = PlayerPrefs.GetInt("CurrentChar");
        currentCharacter = characterManager[currentCharNumber];

        int i = 0;

        foreach (CharacterManager CManager in characterManager)
        {
            if (PlayerPrefs.GetInt("BoughtCharacter" + i.ToString())== 1){
                CManager.Bought = true;
            }
            if (CManager == characterManager[currentCharNumber])
            {
                CManager.character.SetActive(true);
                currentCharacter = CManager;
            }
            else
            {
                CManager.character.SetActive(false);
            }
            i++;
        }
    }
    #endregion

    #endregion

    #region Game

    void GoButtonPos()
    {
        _Go.transform.position = new Vector2(_player.transform.position.x, _player.transform.position.y);
    }
    public void TapToPlay()
    {
        
        isTapToPlay = true;
        _Go.SetActive(true);
        //levelGenerated.manage.levelPlayAnalitics();
        TapToPlayButton.SetActive(false);
        IsTapToPlaySetting();
        GoButtonPos();

    }
    void IsTapToPlaySetting()
    {
        
        if (PlayerPrefs.GetInt("level") != 5 && PlayerPrefs.GetInt("level") != 6 && PlayerPrefs.GetInt("level") != 7
            && PlayerPrefs.GetInt("level") != 8 && PlayerPrefs.GetInt("level") != 9 && PlayerPrefs.GetInt("level") != 21 && PlayerPrefs.GetInt("level") != 22)
        {
            if (PlayerPrefs.GetInt("Music") != 1)
            {
                GameObject natureSound = GameObject.Find("nature");
                natureSound.GetComponent<AudioSource>().Play();
            }
            
        }
        PlayerController.manage._startTime = true;
        levelGenerated.manage.TimerSpawn();
        Invoke("NoticeLatency", 0.8f);
        Invoke("NoticeCloseLatency", 4.3f);
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
    void NoticeLatency()
    {
        levelGenerated.manage.Notice();
    }
    void NoticeCloseLatency()
    {
        levelGenerated.manage.NoticeSetting();
    }
    public void GoStart()
    {
        isMove = true;
        _Go.SetActive(false);
        //QstPanel.SetActive(false);
        isCutTheRope = true;
        isGo = true;
        levelGenerated.manage.levelGoButton();
        if (PlayerPrefs.GetInt("level") == 32 || PlayerPrefs.GetInt("level") == 33)
        {
            PlayerController.manage.isMoveBack = true;
        }
    }
    public void Restart()
    {
        isCutTheRope = false;
        isAdShowed = false;
        
        //Amplitude.Instance.logEvent("Restart");
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
        GameObject canvasLayer = GameObject.Find("CanvasM");
        canvasLayer.GetComponent<Canvas>().sortingOrder = 500;
        _player.GetComponentInChildren<SortingGroup>().sortingOrder = 200;

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

        StartCoroutine(GoldAdd());
        //PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 5);
        _coinFx.SetActive(true);
        Invoke("CoinsFxActive",0.5f);
    }
    IEnumerator GoldAdd()
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
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        sndfx.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
    }
    public void NoAdsButtonActive()
    {
        NoAdsBtn.SetActive(false);
    }
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

    //   void SaveIncomeCoins()
    //  {
    // Utils.SetDateTime("LastSaveTime", DateTime.UtcNow);
    // } 
    /*  void CoinsGetCollect()
      {
          DateTime lastSaveTime = Utils.GetDateTime("LastSaveTime", DateTime.UtcNow);
          TimeSpan timePassed = DateTime.UtcNow - lastSaveTime;
          int secondPassed = (int)timePassed.TotalSeconds;
          secondPassed = Mathf.Clamp(secondPassed, 0, 7 * 24 * 60 * 60);
          PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + secondPassed);
          coinz += secondPassed;
         // print(coinz);
      }

      */
    #endregion


}
