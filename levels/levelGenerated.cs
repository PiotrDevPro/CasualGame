using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class levelGenerated : MonoBehaviour
{
    public static levelGenerated manage;
    public GameObject[] levelPrefabs;
    public Text lvl;
    public GameObject enemySpawn;
    public bool isResetTime = false;
    

    private Transform playerTransform;
    private float spawnX = 1f;
    private float tileLength = 1f;
    private int firstPrefabIndex = 0;

    public int count = 0;
    private int counter = 0;

    private List<GameObject> activeTiles;

    private void Awake()
    {
        manage = this;
        
    }

    void Start()
    {
        
        //PlayerPrefs.SetInt("level",29);
        //PlayerPrefs.SetInt("levelCount",30);
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (PlayerPrefs.GetInt("Subscribe")== 1)
        {
            Main.manage.SubscribePanel.SetActive(false);
        }
        SpawnTile();
        FacebookAds.manage.LoadRewardedVideo();
        PlayerSpawnPosition();
        MusicOnStartLevel();
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        // if(prefabIndex == -1)
        //   {
        //      go = Instantiate(levelPrefabs[RandomPrefabIndex()]) as GameObject;
        // } else
        go = Instantiate(levelPrefabs[PlayerPrefs.GetInt("level")]) as GameObject;
        go.transform.SetParent(transform);
        if (PlayerPrefs.GetInt("level") == 23)
        {
            go.transform.position = new Vector2(-2.090479f, -6.524171f);//.one * spawnX;
        }
        else
        {
            go.transform.position = new Vector2(-1.890479f, -6.524171f);
        }
        spawnX += tileLength;
        activeTiles.Add(go);
        TimerSpawn();
        EnemySpawn();
        
        if (PlayerPrefs.GetInt("level") == 13 || PlayerPrefs.GetInt("level") == 14 || PlayerPrefs.GetInt("level") == 16
            || PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 23
            || PlayerPrefs.GetInt("level") == 26 || PlayerPrefs.GetInt("level") == 27 || PlayerPrefs.GetInt("level") == 30 || PlayerPrefs.GetInt("level") == 33)
        {
            Enemy.manage.EnemyPos();

        }

        // EnemyPosition();
    }

    private void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (levelPrefabs.Length <= 1)
            return 0;
        int randomIndex = firstPrefabIndex;
        while (randomIndex == firstPrefabIndex)
        {
            randomIndex = Random.Range(0, levelPrefabs.Length);

        }
        firstPrefabIndex = randomIndex;
        return randomIndex;
    }

    public void Next()
    {
        //levelNextAnalitics();
        if (levelPrefabs.Length > PlayerPrefs.GetInt("level") + 1)
        {
            
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            GameObject natureSound = GameObject.Find("nature");
            natureSound.GetComponent<AudioSource>().Stop();
            GameObject wp1 = GameObject.Find("SwordP1P");
            wp1.GetComponent<SpriteRenderer>().enabled = false;
            wp1.GetComponent<BoxCollider>().enabled = false;
            GameObject MainSound = GameObject.Find("MainTheme");
            MainSound.GetComponent<AudioSource>().Stop();
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            PlayerPrefs.SetInt("levelCount", 1 + PlayerPrefs.GetInt("levelCount")); 
            PlayerSpawnPosition();
            SpawnTile();
            DeleteTiles();
            NewLevel();
            MusicOnStartLevel();
            counter = 0;
            count = 0;
            Time.timeScale = 1;
            Main.manage._coinFx.SetActive(false);
            PlayerController.manage.isMoveBack = false;
            Main.manage.NextBtn.SetActive(false);
            Main.manage.isTapToPlay = false;
            FacebookAds.manage.ShowRewardedVideo();
            if (PlayerPrefs.GetInt("level") == 4 || PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 14 ||
            PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 23 ||
            PlayerPrefs.GetInt("level") == 26 || PlayerPrefs.GetInt("level") == 30)
            {
                Main.manage.MgBox();
                //AppDealManager.manage.ShowInterstatial();
            }
            if (PlayerPrefs.GetInt("level") == 10)
            {
                Main.manage.SubscribePanel.SetActive(true);
            }
        }
    }
    void Update()
    {
        
        if (!Main.manage.isGo)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Main.manage.audioUI.main.mute = false;
        }
        else
        {
            Main.manage.audioUI.main.mute = true;
        }
        if (PlayerPrefs.GetInt("levelCount") == 0)
        {
            PlayerPrefs.SetInt("levelCount", +1);
        }
        else

            lvl.text = "LEVEL " + PlayerPrefs.GetInt("levelCount").ToString();
    }
    void NewLevel()
    {
        PlayerController.manage.isFinish = false;
        Main.manage.isTapToPlay = false;
        PlayerSpawnPosition();
        PlayerController.manage.FinishCoin.SetActive(false);
        PlayerController.manage.FinishEffect.SetActive(false);
        PlayerController.manage.FinishPanel.SetActive(false);
        PlayerController.manage.FinishCoin.SetActive(false);
        Main.manage.TapToPlayButton.SetActive(true);
        Main.manage.audioUI.main.mute = false;
        Main.manage.isAdShowed = false;
        playerTransform.GetComponentInChildren<Animator>().SetBool("Stand", true);
        playerTransform.GetComponentInChildren<Animator>().SetBool("Finish", false);
        playerTransform.GetComponentInChildren<Animator>().SetBool("Crouch", false);
        ///Timer
        TimeSetting();
        NoticeSetting();
    }
    public void PlayerSpawnPosition()
    {

        Main.manage.isCutTheRope = false;
        Main.manage.isGo = false;
        PlayerController.manage.isMoveBack = false;


        if (PlayerPrefs.GetInt("level") == 2 || PlayerPrefs.GetInt("level") == 17 ||
            PlayerPrefs.GetInt("level") == 10 || PlayerPrefs.GetInt("level") == 23 || PlayerPrefs.GetInt("level") == 24
         ||  PlayerPrefs.GetInt("level") == 30)
        {
            playerTransform.transform.position = new Vector2(-2.63f, -0.5f);
        }
        else
        {
            playerTransform.transform.position = new Vector2(-2.63f, -3.19f);

        }
        if (PlayerPrefs.GetInt("level") == 8)
        {
            playerTransform.transform.position = new Vector2(-2.78f, -3.20f);
        }
        if (PlayerPrefs.GetInt("level") == 11)
        {
            playerTransform.transform.position = new Vector2(-2.23f, -3.20f);
            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
        }

        if (PlayerPrefs.GetInt("level") == 19)
        {
            playerTransform.transform.position = new Vector2(0.51f, 1.96f);
            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
        }

        if (PlayerPrefs.GetInt("level") == 20)
        {

            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
        }
        if (PlayerPrefs.GetInt("level") == 23)
        {
            playerTransform.transform.position = new Vector2(-1.7f, -2.25f);
        }
        if (PlayerPrefs.GetInt("level") == 25)
        {

            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
        }

        if (PlayerPrefs.GetInt("level") == 27)
        {
            playerTransform.transform.position = new Vector2(-0.78f, 1.94f);

        }

        if (PlayerPrefs.GetInt("level") == 28)
        {
            playerTransform.transform.position = new Vector2(-2.63f, 0.39f);
            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
        }
        if (PlayerPrefs.GetInt("level") == 32)
        {
            playerTransform.transform.position = new Vector2(-1.25f, 0.55f);
            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
        }

        if (PlayerPrefs.GetInt("level") == 33)
        {
            playerTransform.transform.position = new Vector2(2.43f, -0.88f);
            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
        }
        if (PlayerPrefs.GetInt("level") == 34)
        {
            playerTransform.GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
        }


        if (PlayerPrefs.GetInt("level") == 0)
        {
            //GameObject enemy1 = GameObject.Find("Enemy14lev");
            // enemy1.GetComponentInChildren<Sprites
            GameObject background = GameObject.Find("backgroundA");
            background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("level") == 1)
        {
            GameObject background = GameObject.Find("backgroundA");
            background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = false;
        }
        if (PlayerPrefs.GetInt("level") == 2)
        {
            GameObject background = GameObject.Find("backgroundA");
            background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("level") == 3)
        {
            GameObject background = GameObject.Find("backgroundA");
            background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = false;
        }
        if (PlayerPrefs.GetInt("level") == 4)
        {
            GameObject background = GameObject.Find("backgroundA");
            background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("level") == 5)
        {

            GameObject background = GameObject.Find("backgroundA");
            background.GetComponent<Image>().enabled = false;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = true;
        }
        if (PlayerPrefs.GetInt("level") == 6)
        {
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
        }
        if (PlayerPrefs.GetInt("level") == 7)
        {
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("level") == 8)
        {
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = true;
            GameObject background1 = GameObject.Find("backgroundC");
            background1.GetComponent<Image>().enabled = false;
            GameObject background2 = GameObject.Find("backgroundA");
            background2.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("level") == 9)
        {
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = true;
            GameObject _background1 = GameObject.Find("backgroundC");
            _background1.GetComponent<Image>().enabled = false;
        }
        if (PlayerPrefs.GetInt("level") == 10)
        {
            GameObject _background = GameObject.Find("backgroundC");
            _background.GetComponent<Image>().enabled = true;
        }

        if (PlayerPrefs.GetInt("level") == 21)
        {
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = true;
            GameObject _background1 = GameObject.Find("backgroundC");
            _background1.GetComponent<Image>().enabled = false;
        }
        if (PlayerPrefs.GetInt("level") == 22)
        {
            GameObject background2 = GameObject.Find("backgroundA");
            background2.GetComponent<Image>().enabled = false;
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = true;
            GameObject _background1 = GameObject.Find("backgroundC");
            _background1.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("level") == 23)
        {
            GameObject _background = GameObject.Find("backgroundB");
            _background.GetComponent<Image>().enabled = false;
            GameObject _background1 = GameObject.Find("backgroundC");
            _background1.GetComponent<Image>().enabled = true;
        }

        if (PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 29)
        {
            GameObject timerr = GameObject.Find("PanelT");
            timerr.GetComponent<Animator>().SetBool("Timez", false);
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
            PlayerController.manage.starttime = 30f;

        }

    }
    void MusicOnStartLevel()
    {
        if (PlayerPrefs.GetInt("level") == 5 )
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
            GameObject lavaSnd = GameObject.Find("LavaD");
            lavaSnd.GetComponent<AudioSource>().Play();
            GameObject lavaParticlePlay = GameObject.Find("LavaBoiling");
            lavaParticlePlay.GetComponent<ParticleSystem>().Play();
            }
        }

        if (PlayerPrefs.GetInt("level") == 6)
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
            UnderwaterSndd.GetComponent<AudioSource>().Play();
            }

        }
        if (PlayerPrefs.GetInt("level") == 7)
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
                UnderwaterSndd.GetComponent<AudioSource>().Play();
            }

        }
        if (PlayerPrefs.GetInt("level") == 8)
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
                UnderwaterSndd.GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
                UnderwaterSndd.GetComponent<AudioSource>().Stop();
            }

        }
        if (PlayerPrefs.GetInt("level") == 9)
        {
            GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
            UnderwaterSndd.GetComponent<AudioSource>().Stop();
            GameObject NatureSnd = GameObject.Find("nature");
            NatureSnd.GetComponent<AudioSource>().Stop();
        }

        if (PlayerPrefs.GetInt("level") == 21)
        {

            GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
            UnderwaterSndd.GetComponent<AudioSource>().Play();
            GameObject NatureSnd = GameObject.Find("nature");
            NatureSnd.GetComponent<AudioSource>().Stop();

        }

        if (PlayerPrefs.GetInt("level") == 22)
        {

            GameObject NatureSnd = GameObject.Find("nature");
            NatureSnd.GetComponent<AudioSource>().Stop();

        }
        if (PlayerPrefs.GetInt("level") == 30)
        {
            GameObject saluteSnd = GameObject.Find("salute");
            saluteSnd.GetComponent<AudioSource>().Stop();
        }

    }
    void EnemySpawn()
    {
        if (PlayerPrefs.GetInt("level") != 13 && PlayerPrefs.GetInt("level") != 14 && PlayerPrefs.GetInt("level") != 16 && PlayerPrefs.GetInt("level") != 19
            && PlayerPrefs.GetInt("level") != 23 && PlayerPrefs.GetInt("level") != 26 && PlayerPrefs.GetInt("level") != 27 && PlayerPrefs.GetInt("level") != 30
            && PlayerPrefs.GetInt("level") != 33)
        {

            enemySpawn.SetActive(false);
            GameObject enemyDetect = GameObject.Find("Enemy14lev");
            enemyDetect.GetComponent<Rigidbody>().isKinematic = true;
            enemyDetect.GetComponent<CapsuleCollider>().isTrigger = true;
            enemyDetect.GetComponent<Transform>().position = new Vector2(100, 100);

        }
        else
        {

            enemySpawn.SetActive(true);

            Enemy.manage.countDead = 0;
        }

    }
    public void Notice()
    {
        
        if (Main.manage.isTapToPlay)
        {

            if (PlayerPrefs.GetInt("level") == 0) //&& !isResetTime)
            {
                GameObject animStrt = GameObject.Find("panelClear");
                animStrt.GetComponent<Animator>().SetBool("goo", true);
                GameObject lvText = GameObject.Find("lv1");
                lvText.GetComponent<Text>().enabled = true;
                GameObject lv1Text = GameObject.Find("lv2");
                lv1Text.GetComponent<Text>().enabled = false;
                GameObject snd = GameObject.Find("noticeOpen");
                snd.GetComponent<AudioSource>().Play();
            }

            if (PlayerPrefs.GetInt("level") == 1)
            {
                GameObject animStrt = GameObject.Find("panelClear");
                animStrt.GetComponent<Animator>().SetBool("goo", true);
                GameObject lvText = GameObject.Find("lv1");
                lvText.GetComponent<Text>().enabled = false;
                GameObject lv1Text = GameObject.Find("lv2");
                lv1Text.GetComponent<Text>().enabled = true;
                GameObject snd = GameObject.Find("noticeOpen");
                snd.GetComponent<AudioSource>().Play();
                }
            }

        if (PlayerPrefs.GetInt("level") == 2)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = true;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("level") == 3)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = true;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("level") == 4)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = true;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("level") == 5)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = true;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }

        if (PlayerPrefs.GetInt("level") == 6)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = true;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }

        if (PlayerPrefs.GetInt("level") == 7 | PlayerPrefs.GetInt("level") == 10 |
            PlayerPrefs.GetInt("level") == 11 | PlayerPrefs.GetInt("level") == 18 |  
           PlayerPrefs.GetInt("level") == 16 |
            PlayerPrefs.GetInt("level") == 17 | PlayerPrefs.GetInt("level") == 21 | PlayerPrefs.GetInt("level") == 22
            | PlayerPrefs.GetInt("level") == 25 | PlayerPrefs.GetInt("level") == 26)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = true;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = false;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = false;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = false;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = false;
            GameObject lv20Text = GameObject.Find("lv20");
            lv20Text.GetComponent<Text>().enabled = false;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("level") == 8)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = true;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = false;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = false;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = false;
            GameObject lv20Text = GameObject.Find("lv20");
            lv20Text.GetComponent<Text>().enabled = false;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("level") == 9)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = false;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = true;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = false;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = false;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }

        if (PlayerPrefs.GetInt("level") == 13 | PlayerPrefs.GetInt("level") == 14 )
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = false;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = false;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = true;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = false;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("level") == 15)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = true;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = false;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = false;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = false;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = false;
            GameObject lv20Text = GameObject.Find("lv20");
            lv20Text.GetComponent<Text>().enabled = false;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }

        if (PlayerPrefs.GetInt("level") == 12 | PlayerPrefs.GetInt("level") == 20
            | PlayerPrefs.GetInt("level") == 23 | PlayerPrefs.GetInt("level") == 24
            | PlayerPrefs.GetInt("level") == 27 | PlayerPrefs.GetInt("level") == 28)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = false;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = false;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = false;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = true;
            GameObject lv20Text = GameObject.Find("lv20");
            lv20Text.GetComponent<Text>().enabled = false;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }

        if (PlayerPrefs.GetInt("level") == 19)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = false;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = false;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = false;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = false;
            GameObject lv20Text = GameObject.Find("lv20");
            lv20Text.GetComponent<Text>().enabled = true;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }

        if (PlayerPrefs.GetInt("level") == 29)
        {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", true);
            GameObject lvText = GameObject.Find("lv1");
            lvText.GetComponent<Text>().enabled = false;
            GameObject lv1Text = GameObject.Find("lv2");
            lv1Text.GetComponent<Text>().enabled = false;
            GameObject lv2Text = GameObject.Find("lv3");
            lv2Text.GetComponent<Text>().enabled = false;
            GameObject lv3Text = GameObject.Find("lv4");
            lv3Text.GetComponent<Text>().enabled = false;
            GameObject lv6Text = GameObject.Find("lv6");
            lv6Text.GetComponent<Text>().enabled = false;
            GameObject lv9Text = GameObject.Find("lv9");
            lv9Text.GetComponent<Text>().enabled = false;
            GameObject lv10Text = GameObject.Find("lv10");
            lv10Text.GetComponent<Text>().enabled = false;
            GameObject lv14Text = GameObject.Find("lv14");
            lv14Text.GetComponent<Text>().enabled = false;
            GameObject lv19Text = GameObject.Find("lv19");
            lv19Text.GetComponent<Text>().enabled = false;
            GameObject lv20Text = GameObject.Find("lv20");
            lv20Text.GetComponent<Text>().enabled = false;
            GameObject lv30Text = GameObject.Find("lv30");
            lv30Text.GetComponent<Text>().enabled = true;
            GameObject snd = GameObject.Find("noticeOpen");
            snd.GetComponent<AudioSource>().Play();
        }
    }
    public void NoticeSetting()
    {
            GameObject animStrt = GameObject.Find("panelClear");
            animStrt.GetComponent<Animator>().SetBool("goo", false);
    }
    void TimeSetting()
    {
        if (PlayerPrefs.GetInt("level") == 9 | PlayerPrefs.GetInt("level") == 19 | PlayerPrefs.GetInt("level") == 29 | PlayerPrefs.GetInt("level") == 31 | PlayerPrefs.GetInt("level") == 34)
        {
            GameObject timerr = GameObject.Find("PanelT");
            timerr.GetComponent<Animator>().SetBool("Timez", false);
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
        }
    }
    public void TimerSpawn()
    {
        if (Main.manage.isTapToPlay)
        {
            
            if (PlayerPrefs.GetInt("level") == 9 | PlayerPrefs.GetInt("level") == 19 | PlayerPrefs.GetInt("level") == 29 | PlayerPrefs.GetInt("level") == 31 | PlayerPrefs.GetInt("level") == 34)
            {
                PlayerController.manage.curr = 25f;
                GameObject timerr = GameObject.Find("PanelT");
                timerr.GetComponent<Animator>().SetBool("Timez", true);
                timerr.GetComponent<Animator>().SetTrigger("bubble");
                GameObject timerSnd = GameObject.Find("Timerr");
                timerSnd.GetComponent<AudioSource>().Play();
               // print("yess");
            }
             else
            {
                
                GameObject timerr = GameObject.Find("PanelT");
                timerr.GetComponent<Animator>().SetBool("Timez", false);
                timerr.GetComponent<Animator>().ResetTrigger("bubble");
                timerr.GetComponent<Animator>().ResetTrigger("timeTen");
                PlayerController.manage.curr = 30f;
                GameObject timerSnd = GameObject.Find("Timerr");
                timerSnd.GetComponent<AudioSource>().Stop();
                //print("noo");
            }
        }
    }

    #region Dictonary of Events
    Dictionary<string, object> Level1 = new Dictionary<string, object>() {
            {"LVL Number" , 1},
        };
    Dictionary<string, object> Level2 = new Dictionary<string, object>() {
            {"LVL Number" , 2},
        };
    Dictionary<string, object> Level3 = new Dictionary<string, object>() {
            {"LVL Number" , 3},
        };
    Dictionary<string, object> Level4 = new Dictionary<string, object>() {
            {"LVL Number" , 4},
        };
    Dictionary<string, object> Level5 = new Dictionary<string, object>() {
            {"LVL Number" , 5},
        };
    Dictionary<string, object> Level6 = new Dictionary<string, object>() {
            {"LVL Number" , 6},
        };
    Dictionary<string, object> Level7 = new Dictionary<string, object>() {
            {"LVL Number" , 7},
        };
    Dictionary<string, object> Level8 = new Dictionary<string, object>() {
            {"LVL Number" , 8},
        };
    Dictionary<string, object> Level9 = new Dictionary<string, object>() {
            {"LVL Number" , 9},
        };
    Dictionary<string, object> Level10 = new Dictionary<string, object>() {
            {"LVL Number" , 10},
        };
    Dictionary<string, object> Level11 = new Dictionary<string, object>() {
            {"LVL Number" , 11},
        };
    Dictionary<string, object> Level12 = new Dictionary<string, object>() {
            {"LVL Number" , 12},
        };
    Dictionary<string, object> Level13 = new Dictionary<string, object>() {
            {"LVL Number" , 13},
        };
    Dictionary<string, object> Level14 = new Dictionary<string, object>() {
            {"LVL Number" , 14},
        };
    Dictionary<string, object> Level15 = new Dictionary<string, object>() {
            {"LVL Number" , 15},
        };
    Dictionary<string, object> Level16 = new Dictionary<string, object>() {
            {"LVL Number" , 16},
        };
    Dictionary<string, object> Level17 = new Dictionary<string, object>() {
            {"LVL Number" , 17},
        };
    Dictionary<string, object> Level18 = new Dictionary<string, object>() {
            {"LVL Number" , 18},
        };
    Dictionary<string, object> Level19 = new Dictionary<string, object>() {
            {"LVL Number" , 19},
        };
    Dictionary<string, object> Level20 = new Dictionary<string, object>() {
            {"LVL Number" , 20},
        };
    Dictionary<string, object> Level21 = new Dictionary<string, object>() {
            {"LVL Number" , 21},
        };
    Dictionary<string, object> Level22 = new Dictionary<string, object>() {
            {"LVL Number" , 22},
        };
    Dictionary<string, object> Level23 = new Dictionary<string, object>() {
            {"LVL Number" , 23},
        };
    Dictionary<string, object> Level24 = new Dictionary<string, object>() {
            {"LVL Number" , 24},
        };
    Dictionary<string, object> Level25 = new Dictionary<string, object>() {
            {"LVL Number" , 25},
        };
    Dictionary<string, object> Level26 = new Dictionary<string, object>() {
            {"LVL Number" , 26},
        };
    Dictionary<string, object> Level27 = new Dictionary<string, object>() {
            {"LVL Number" , 27},
        };
    Dictionary<string, object> Level28 = new Dictionary<string, object>() {
            {"LVL Number" , 28},
        };
    Dictionary<string, object> Level29 = new Dictionary<string, object>() {
            {"LVL Number" , 29},
        };
    Dictionary<string, object> Level30 = new Dictionary<string, object>() {
            {"LVL Number" , 30},
        };
    Dictionary<string, object> Level31 = new Dictionary<string, object>() {
            {"LVL Number" , 31},
        };
    Dictionary<string, object> Level32 = new Dictionary<string, object>() {
            {"LVL Number" , 32},
        };
    Dictionary<string, object> Level33 = new Dictionary<string, object>() {
            {"LVL Number" , 33},
        };
    Dictionary<string, object> Level34 = new Dictionary<string, object>() {
            {"LVL Number" , 34},
        };
    Dictionary<string, object> Level35 = new Dictionary<string, object>() {
            {"LVL Number" , 35},
        };
    Dictionary<string, object> LevelTry1 = new Dictionary<string, object>() {
            {"LVL Number" , 1},
        };
    Dictionary<string, object> LevelTry2 = new Dictionary<string, object>() {
            {"LVL Number" , 2},
        };
    Dictionary<string, object> LevelTry3 = new Dictionary<string, object>() {
            {"LVL Number" , 3},
        };
    Dictionary<string, object> LevelTry4 = new Dictionary<string, object>() {
            {"LVL Number" , 4},
        };
    Dictionary<string, object> LevelTry5 = new Dictionary<string, object>() {
            {"LVL Number" , 5},
        };
    Dictionary<string, object> LevelTry6 = new Dictionary<string, object>() {
            {"LVL Number" , 6},
        };
    Dictionary<string, object> LevelTry7 = new Dictionary<string, object>() {
            {"LVL Number" , 7},
        };
    Dictionary<string, object> LevelTry8 = new Dictionary<string, object>() {
            {"LVL Number" , 8},
        };
    Dictionary<string, object> LevelTry9 = new Dictionary<string, object>() {
            {"LVL Number" , 9},
        };
    Dictionary<string, object> LevelTry10 = new Dictionary<string, object>() {
            {"LVL Number" , 10},
        };
    Dictionary<string, object> LevelTry11 = new Dictionary<string, object>() {
            {"LVL Number" , 11},
        };
    Dictionary<string, object> LevelTry12 = new Dictionary<string, object>() {
            {"LVL Number" , 12},
        };
    Dictionary<string, object> LevelTry13 = new Dictionary<string, object>() {
            {"LVL Number" , 13},
        };
    Dictionary<string, object> LevelTry14 = new Dictionary<string, object>() {
            {"LVL Number" , 14},
        };
    Dictionary<string, object> LevelTry15 = new Dictionary<string, object>() {
            {"LVL Number" , 15},
        };
    Dictionary<string, object> LevelTry16 = new Dictionary<string, object>() {
            {"LVL Number" , 16},
        };
    Dictionary<string, object> LevelTry17 = new Dictionary<string, object>() {
            {"LVL Number" , 17},
        };
    Dictionary<string, object> LevelTry18 = new Dictionary<string, object>() {
            {"LVL Number" , 18},
        };
    Dictionary<string, object> LevelTry19 = new Dictionary<string, object>() {
            {"LVL Number" , 19},
        };
    Dictionary<string, object> LevelTry20 = new Dictionary<string, object>() {
            {"LVL Number" , 20},
        };
    Dictionary<string, object> LevelTry21 = new Dictionary<string, object>() {
            {"LVL Number" , 21},
        };
    Dictionary<string, object> LevelTry22 = new Dictionary<string, object>() {
            {"LVL Number" , 22},
        };
    Dictionary<string, object> LevelTry23 = new Dictionary<string, object>() {
            {"LVL Number" , 23},
        };
    Dictionary<string, object> LevelTry24 = new Dictionary<string, object>() {
            {"LVL Number" , 24},
        };
    Dictionary<string, object> LevelTry25 = new Dictionary<string, object>() {
            {"LVL Number" , 25},
        };
    Dictionary<string, object> LevelTry26 = new Dictionary<string, object>() {
            {"LVL Number" , 26},
        };
    Dictionary<string, object> LevelTry27 = new Dictionary<string, object>() {
            {"LVL Number" , 27},
        };
    Dictionary<string, object> LevelTry28 = new Dictionary<string, object>() {
            {"LVL Number" , 28},
        };
    Dictionary<string, object> LevelTry29 = new Dictionary<string, object>() {
            {"LVL Number" , 29},
        };
    Dictionary<string, object> LevelTry30 = new Dictionary<string, object>() {
            {"LVL Number" , 30},
        };
    Dictionary<string, object> LevelTry31 = new Dictionary<string, object>() {
            {"LVL Number" , 31},
        };
    Dictionary<string, object> LevelTry32 = new Dictionary<string, object>() {
            {"LVL Number" , 32},
        };
    Dictionary<string, object> LevelTry33 = new Dictionary<string, object>() {
            {"LVL Number" , 33},
        };
    Dictionary<string, object> LevelTry34 = new Dictionary<string, object>() {
            {"LVL Number" , 34},
        };
    Dictionary<string, object> LevelTry35 = new Dictionary<string, object>() {
            {"LVL Number" , 35},
        };
    #endregion
    /* public void levelAnalitics()
     {

         if (PlayerPrefs.GetInt("levelCount") == 1)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level1(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("Level 1 Start",Level1);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 2)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level2(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("Level 1 Start", Level2);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 3)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level3(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("Level 1 Start", Level3);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 4)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level4(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level4);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 5)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level5(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level5);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 6)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level6(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level6);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 7)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level7(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level7);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 8)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level8(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level8);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 9)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level9(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level9);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 10)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level10(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level10);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 11)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level11(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level11);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 12)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level12(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level12);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 13)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level13(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level13);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 14)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level14(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level14);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 15)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level15(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level15);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 16)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level16(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level16);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 17)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level17(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level17);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 18)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level18(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level18);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 19)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level19(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level19);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 20)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level20(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level20);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 21)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level21(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level21);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 22)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level22(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level22);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 23)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level23(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level23);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 24)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level24(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level24);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 25)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level25(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level25);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 26)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level26(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level26);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 27)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level27(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level27);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 28)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level28(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level28);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 29)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level29(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level29);
             }
         }

         if (PlayerPrefs.GetInt("levelCount") == 30)
         {
             count += 1;
             if (count == 1)
             {
                 //FbManager.manage.level30(PlayerPrefs.GetInt("Coin"));
                 Amplitude.Instance.logEvent("StartedLVL", Level30);
             }
         }
     }
     */
    /* public void levelNextAnalitics()
    {
        
        
        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
                //FbManager.manage.level1Next(PlayerPrefs.GetInt("Coin"));
                Amplitude.Instance.logEvent("Level 1 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 2)
        {
                //FbManager.manage.level2Next(PlayerPrefs.GetInt("Coin"));
                Amplitude.Instance.logEvent("Level 2 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
            //FbManager.manage.level3Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 3 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {
            //FbManager.manage.level4Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 4 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
            //FbManager.manage.level5Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 5 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {
            //FbManager.manage.level6Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 6 Next");

        }
        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            //FbManager.manage.level7Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 7 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {
            //FbManager.manage.level8Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 8 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
            //FbManager.manage.level9Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 9 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {
            //FbManager.manage.level10Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 10 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            //FbManager.manage.level11Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 11 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 12)
        {
            //FbManager.manage.level12Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 12 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            //FbManager.manage.level13Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 13 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {
            //FbManager.manage.level14Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 14 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            //FbManager.manage.level15Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 15 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {
            //FbManager.manage.level16Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 16 Next");
        }
        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            //FbManager.manage.level17Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 17 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {
            //FbManager.manage.level18Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("level 18 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            //FbManager.manage.level19Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 19 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {
            //FbManager.manage.level20Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 20 Next");
        }


        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
            //FbManager.manage.level21Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 21 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 22)
        {
            //FbManager.manage.level22Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 22 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
            //FbManager.manage.level23Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 23 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {
            //FbManager.manage.level24Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 24 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
            //FbManager.manage.level25Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 25 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {
            //FbManager.manage.level26Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 26 Next");
        }
        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
            //FbManager.manage.level27Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 27 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {
            //FbManager.manage.level28Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 28 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
            //FbManager.manage.level29Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 29 Next");
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {
            //FbManager.manage.level30Next(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 30 Next");
        }
    }

  /*  public void levelCoin4xAnalitics()
    {
        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
            //FbManager.manage.level1CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 1 Coin4X", Level1);
        }

        if (PlayerPrefs.GetInt("levelCount") == 2)
        {

                //FbManager.manage.level2CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 2 Coin4X",Level2);
        }

        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
            //FbManager.manage.level3CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 3 Coin4X", Level3);
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {

            //FbManager.manage.level4CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 4 Coin4X", Level4);
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
            //FbManager.manage.level5CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 5 Coin4X", Level5);
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {

            //FbManager.manage.level6CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 6 Coin4X", Level6);
        }

        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            //FbManager.manage.level7CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 7 Coin4X", Level7);
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {

            //FbManager.manage.level8CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 8 Coin4X", Level8);
        }


        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
            //FbManager.manage.level9CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 9 Coin4X", Level9);
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {

            //FbManager.manage.level10CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 10 Coin4X", Level10);
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            //FbManager.manage.level11CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 11 Coin4X", Level11);
        }

        if (PlayerPrefs.GetInt("levelCount") == 12)
        {

            //FbManager.manage.level12CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 12 Coin4X", Level12);
        }

        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            //FbManager.manage.level13CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 13 Coin4X", Level13);
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {

            //FbManager.manage.level14CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 14 Coin4X", Level14);
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            //FbManager.manage.level15CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 15 Coin4X", Level5);
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {

            //FbManager.manage.level16CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 16 Coin4X", Level16);
        }

        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            //FbManager.manage.level17CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 17 Coin4X", Level17);
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {

            //FbManager.manage.level18CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 18 Coin4X", Level18);
        }


        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            //FbManager.manage.level19CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 19 Coin4X", Level19);
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {

            //FbManager.manage.level20CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 20 Coin4X", Level20);
        }

        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
            //FbManager.manage.level21CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 21 Coin4X", Level21);
        }

        if (PlayerPrefs.GetInt("levelCount") == 22)
        {

            //FbManager.manage.level22CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 22 Coin4X", Level22);
        }

        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
            //FbManager.manage.level23CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 23 Coin4X", Level23);
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {

            //FbManager.manage.level24CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 24 Coin4X", Level24);
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
            //FbManager.manage.level25CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 25 Coin4X", Level25);
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {

            //FbManager.manage.level26CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 26 Coin4X", Level26);
        }

        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
            //FbManager.manage.level27CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 27 Coin4X", Level27);
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {

            //FbManager.manage.level28CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 28 Coin4X", Level28);
        }


        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
            //FbManager.manage.level29CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 29 Coin4X", Level29);
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {

            //FbManager.manage.level30CoinX4(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 30 Coin4X", Level30);
        }
    }

    /*  public void levelPlayAnalitics()
    {
        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
             //   FbManager.manage.level1Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 1 Play", Level1);
        }

        if (PlayerPrefs.GetInt("levelCount") == 2)
        {
            
            //FbManager.manage.level2Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 2 Play", Level2);
        }

        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
            //FbManager.manage.level3Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 3 Play", Level3);
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {

            //FbManager.manage.level4Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 4 Play", Level4);
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
            //FbManager.manage.level5Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 5 Play", Level5);
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {

            //FbManager.manage.level6Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 6 Play", Level6);
        }

        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            //FbManager.manage.level7Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 7 Play", Level7);
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {

            //FbManager.manage.level8Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 8 Play", Level8);
        }


        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
           //FbManager.manage.level9Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 9 Play", Level9);
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {

            //FbManager.manage.level10Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 10 Play", Level10);
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            //FbManager.manage.level11Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 11 Play", Level11);
        }

        if (PlayerPrefs.GetInt("levelCount") == 12)
        {

            //FbManager.manage.level12Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 12 Play", Level12);
        }

        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            //FbManager.manage.level13Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 13 Play", Level13);
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {

            //FbManager.manage.level14Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 14 Play",Level14);
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            //FbManager.manage.level15Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 15 Play", Level15);
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {

            //FbManager.manage.level16Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 16 Play", Level16);
        }

        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            //FbManager.manage.level17Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 17 Play", Level17);
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {

            //FbManager.manage.level18Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 18 Play", Level18);
        }


        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            //FbManager.manage.level19Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 19 Play", Level19);
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {

            //FbManager.manage.level20Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 20 Play", Level20);
        }
        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
            //FbManager.manage.level21Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 21 Play", Level21);
        }

        if (PlayerPrefs.GetInt("levelCount") == 22)
        {

            //FbManager.manage.level22Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 22 Play", Level22);
        }

        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
            //FbManager.manage.level23Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 23 Play", Level23);
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {

            //FbManager.manage.level24Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 24 Play", Level24);
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
            //FbManager.manage.level25Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 25 Play", Level25);
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {

            //FbManager.manage.level26Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 26 Play", Level26);
        }

        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
            //FbManager.manage.level27Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 27 Play", Level27);
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {

            //FbManager.manage.level28Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 28 Play", Level28);
        }


        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
            //FbManager.manage.level29Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 29 Play", Level29);
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {

            //FbManager.manage.level30Play(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("Level 30 Play", Level30);
        }
    }
    */

    public void LevelsFinishAnalitycs()
    {
        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
            FbManager.manage.level1Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level1);
            
        }

        if (PlayerPrefs.GetInt("levelCount") == 2)
        {
            FbManager.manage.level2Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level2);
        }

        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
            FbManager.manage.level3Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level3);
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {
            FbManager.manage.level4Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level4);
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
            FbManager.manage.level5Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level5);
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {
            FbManager.manage.level6Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level6);
        }

        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            FbManager.manage.level7Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level7);
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {
           FbManager.manage.level8Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level8);
        }

        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
            FbManager.manage.level9Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level9);
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {
            FbManager.manage.level10Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level10);
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            FbManager.manage.level11Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level11);
        }

        if (PlayerPrefs.GetInt("levelCount") == 12)
        {
            FbManager.manage.level12Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level12);
        }

        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            FbManager.manage.level13Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level13);
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {
            FbManager.manage.level14Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level14);
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            FbManager.manage.level15Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level15);
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {
            FbManager.manage.level16Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level16);
        }
        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            FbManager.manage.level17Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level17);
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {
            FbManager.manage.level18Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level18);
        }
        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            FbManager.manage.level19Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level19);
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {
            FbManager.manage.level20Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level20);
        }

        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
            FbManager.manage.level21Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level21);
        }

        if (PlayerPrefs.GetInt("levelCount") == 22)
        {
            FbManager.manage.level22Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level22);
        }

        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
            FbManager.manage.level23Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level23);
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {
           FbManager.manage.level24Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level24);
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
            FbManager.manage.level25Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level25);
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {
            FbManager.manage.level26Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level26);
        }

        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
            FbManager.manage.level27Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level27);
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {
            FbManager.manage.level28Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level28);
        }

        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
            FbManager.manage.level29Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level29);
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {
            FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level30);
        }
        if (PlayerPrefs.GetInt("levelCount") == 31)
        {
            FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level31);
        }
        if (PlayerPrefs.GetInt("levelCount") == 32)
        {
            FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level32);
        }
        if (PlayerPrefs.GetInt("levelCount") == 33)
        {
            FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level33);
        }
        if (PlayerPrefs.GetInt("levelCount") == 34)
        {
            FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level34);
        }
        if (PlayerPrefs.GetInt("levelCount") == 35)
        {
            FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FinishedLVL", Level35);
        }
    }
    public void levelsFailedAnalitycs()
    {
        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
            //FbManager.manage.level1Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level1);
        }

        if (PlayerPrefs.GetInt("levelCount") == 2)
        {
             //  FbManager.manage.level2Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level2);
        }

        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
             //  FbManager.manage.level3Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level3);
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {
             //  FbManager.manage.level4Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level4);
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
             //  FbManager.manage.level5Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level5);
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {
           // FbManager.manage.level6Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level6);
        }

        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            // FbManager.manage.level7Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level7);
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {
            //FbManager.manage.level8Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level8);
        }

        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
              // FbManager.manage.level9Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level9);
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {
           //  FbManager.manage.level10Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level10);
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            //FbManager.manage.level11Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level11);
        }

        if (PlayerPrefs.GetInt("levelCount") == 12)
        {
            // FbManager.manage.level12Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level12);
        }

        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            // FbManager.manage.level13Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level13);
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {
             //  FbManager.manage.level14Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level14);
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            //   FbManager.manage.level15Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level15);
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {
            //  FbManager.manage.level16Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level16);
        }
        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            //  FbManager.manage.level17Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level17);
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {
            //   FbManager.manage.level18Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level18);
        }
        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            //  FbManager.manage.level19Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level19);
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {
             //  FbManager.manage.level20Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level20);
        }

        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
           //  FbManager.manage.level21Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level21);
        }

        if (PlayerPrefs.GetInt("levelCount") == 22)
        {
           //    FbManager.manage.level22Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level22);
        }

        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
           //   FbManager.manage.level23Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level23);
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {
           //   FbManager.manage.level24Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level24);
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
           //   FbManager.manage.level25Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level25);
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {
           //    FbManager.manage.level26Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level26);
        }

        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
           //   FbManager.manage.level27Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level27);
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {
           //  FbManager.manage.level28Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level28);
        }

        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
           //   FbManager.manage.level29Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level29);
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {
           //  FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level30);
        }
        if (PlayerPrefs.GetInt("levelCount") == 31)
        {
            //  FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level31);
        }
        if (PlayerPrefs.GetInt("levelCount") == 32)
        {
            //  FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level32);
        }

        if (PlayerPrefs.GetInt("levelCount") == 33)
        {
            //  FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level33);
        }
        if (PlayerPrefs.GetInt("levelCount") == 34)
        {
            //  FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level34);
        }
        if (PlayerPrefs.GetInt("levelCount") == 35)
        {
            //  FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("FailedLVL", Level35);
        }
    }
    public void levelGoButton()
    {
        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
        //FbManager.manage.level1go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL",Level1);
        }
        if (PlayerPrefs.GetInt("levelCount") == 2)
        {
           // FbManager.manage.level2go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level2);
        }
        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
            //FbManager.manage.level3go(PlayerPrefs.GetInt("Coin"));          
            Amplitude.Instance.logEvent("StartedLVL", Level3);
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {

            //FbManager.manage.level4go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level4);
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
           // FbManager.manage.level5go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level5);
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {
            //FbManager.manage.level6go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level6);
        }

        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            //FbManager.manage.level7go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level7);
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {
            //FbManager.manage.level8go(PlayerPrefs.GetInt("Coin"));    
            Amplitude.Instance.logEvent("StartedLVL", Level8);
        }

        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
            //FbManager.manage.level9go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level9);
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {

            //FbManager.manage.level10go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level10);
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            //FbManager.manage.level11go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level11);
        }
        if (PlayerPrefs.GetInt("levelCount") == 12)
        {
            //FbManager.manage.level12go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level12);
        }
        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            //FbManager.manage.level13go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level13);
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {
            //FbManager.manage.level14go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level14);
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            //FbManager.manage.level15go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level15);
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {
            //FbManager.manage.level16go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level16);
        }

        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            //FbManager.manage.level17go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level17);
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {
            //FbManager.manage.level18go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level18);
        }

        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            //FbManager.manage.level19go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level19);
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {
            //FbManager.manage.level20go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level20);
        }

        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
            //FbManager.manage.level21go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level21);
        }
        if (PlayerPrefs.GetInt("levelCount") == 22)
        {
            //FbManager.manage.level22go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level22);
        }
        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
            //FbManager.manage.level23go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level23);
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {
            //FbManager.manage.level24go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level24);
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
            //FbManager.manage.level25go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level25);
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {
            //FbManager.manage.level26go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level26);
        }

        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
            //FbManager.manage.level27go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level27);
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {
            //FbManager.manage.level28go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level28);
        }

        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
            //FbManager.manage.level29go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level29);
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {
            //FbManager.manage.level30go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level30);
        }

        if (PlayerPrefs.GetInt("levelCount") == 31)
        {
            //FbManager.manage.level30go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level31);
        }
        if (PlayerPrefs.GetInt("levelCount") == 32)
        {
            //FbManager.manage.level30go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level32);
        }
        if (PlayerPrefs.GetInt("levelCount") == 33)
        {
            //FbManager.manage.level30go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level33);
        }
        if (PlayerPrefs.GetInt("levelCount") == 34)
        {
            //FbManager.manage.level30go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level34);
        }
        if (PlayerPrefs.GetInt("levelCount") == 35)
        {
            //FbManager.manage.level30go(PlayerPrefs.GetInt("Coin"));
            Amplitude.Instance.logEvent("StartedLVL", Level35);
        }
    }
} 
