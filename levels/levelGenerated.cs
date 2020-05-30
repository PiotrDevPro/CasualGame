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

    private Transform playerTransform;
    private float spawnX = 1f;
    private float tileLength = 1f;
    private float safeZone = 1f;
    private int amnTilesOnScreen = 1;
    private int firstPrefabIndex = 0;

    private int count = 0;

    private List<GameObject> activeTiles;

    private void Awake()
    {
        manage = this;

    }

    void Start()
    {

        //PlayerPrefs.SetInt("level",23);
        //PlayerPrefs.SetInt("levelCount", 24);
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //  for (int i=0; i<amnTilesOnScreen; i++)
        // {
        //  if (i < 1)
        //      SpawnTile(0);
        //  else
        SpawnTile();
        PlayerSpawnPosition();
        MusicOnStartLevel();

        // }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        // if(prefabIndex == -1)
        //   {
        //      go = Instantiate(levelPrefabs[RandomPrefabIndex()]) as GameObject;
        // } else
        go = Instantiate(levelPrefabs[PlayerPrefs.GetInt("level")]) as GameObject;
        //go = Instantiate(levelPrefabs[7]) as GameObject;
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
            || PlayerPrefs.GetInt("level") == 26 || PlayerPrefs.GetInt("level") == 27)
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

        if (levelPrefabs.Length > PlayerPrefs.GetInt("level") + 1)
        {

            GameObject natureSound = GameObject.Find("nature");
            natureSound.GetComponent<AudioSource>().Stop();
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            PlayerPrefs.SetInt("levelCount", 1 + PlayerPrefs.GetInt("levelCount"));
            PlayerSpawnPosition();
            SpawnTile();
            //levelAnalitics();
            DeleteTiles();
            NewLevel();
            MusicOnStartLevel();
            count = 0;
            Time.timeScale = 1;
            Main.manage._coinFx.SetActive(false);
            PlayerController.manage.isMoveBack = false;
            //  PlayerController.manage.isStart = false;
            if (PlayerPrefs.GetInt("level") >= 10 && !AdsManager.manage.isNoDoubleAds)
            {
                AdsManager.manage.ShowAdDefault();
            }

        }

    }

    void Update()
    {


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
        levelAnalitics();
        //print(PlayerPrefs.GetInt("level"));


    }

    void NewLevel()
    {
        PlayerSpawnPosition();
        // PlayerSpawnPos();
        PlayerController.manage.FinishCoin.SetActive(false);
        PlayerController.manage.FinishEffect.SetActive(false);
        PlayerController.manage.FinishPanel.SetActive(false);
        PlayerController.manage.FinishCoin.SetActive(false);
        Main.manage.isTapToPlay = false;
        Main.manage.TapToPlayButton.SetActive(true);
        Main.manage.audioUI.main.mute = false;
        Main.manage.isAdShowed = false;
        playerTransform.GetComponentInChildren<Animator>().SetBool("Stand", true);
        playerTransform.GetComponentInChildren<Animator>().SetBool("Finish", false);
        playerTransform.GetComponentInChildren<Animator>().SetBool("Crouch", false);
        //PlayerController.manage.isStart = false;
    }

    void PlayerSpawnPosition()
    {
        Main.manage.isCutTheRope = false;
        Main.manage.isGo = false;
        PlayerController.manage.isMoveBack = false;


        if (PlayerPrefs.GetInt("level") == 2 || PlayerPrefs.GetInt("level") == 17 ||
            PlayerPrefs.GetInt("level") == 10 || PlayerPrefs.GetInt("level") == 23 || PlayerPrefs.GetInt("level") == 24)
        // ||  PlayerPrefs.GetInt("level") == 28) // ||
        {
            playerTransform.transform.position = new Vector2(-2.63f, -0.5f);
        }
        else
        {
            playerTransform.transform.position = new Vector2(-2.63f, -3.19f);

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
        if (PlayerPrefs.GetInt("level") == 5)
        {
            GameObject lavaSnd = GameObject.Find("LavaD");
            lavaSnd.GetComponent<AudioSource>().Play();
            GameObject lavaParticlePlay = GameObject.Find("LavaBoiling");
            lavaParticlePlay.GetComponent<ParticleSystem>().Play();
        }

        if (PlayerPrefs.GetInt("level") == 6)
        {

            GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
            UnderwaterSndd.GetComponent<AudioSource>().Play();

        }
        if (PlayerPrefs.GetInt("level") == 7)
        {

            GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
            UnderwaterSndd.GetComponent<AudioSource>().Play();

        }
        if (PlayerPrefs.GetInt("level") == 8)
        {

            GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
            UnderwaterSndd.GetComponent<AudioSource>().Play();

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

            // GameObject UnderwaterSndd = GameObject.Find("UnderwaterSnd");
            // UnderwaterSndd.GetComponent<AudioSource>().Play();
            GameObject NatureSnd = GameObject.Find("nature");
            NatureSnd.GetComponent<AudioSource>().Stop();

        }


    }
    void EnemySpawn()
    {
        if (PlayerPrefs.GetInt("level") != 13 && PlayerPrefs.GetInt("level") != 14 && PlayerPrefs.GetInt("level") != 16 && PlayerPrefs.GetInt("level") != 19
            && PlayerPrefs.GetInt("level") != 23 && PlayerPrefs.GetInt("level") != 26 && PlayerPrefs.GetInt("level") != 27)
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
    public void TimerSpawn()
    {
        if (Main.manage.isTapToPlay)
        {

            if (PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 29)
            {

                GameObject timerr = GameObject.Find("PanelT");
                timerr.GetComponent<Animator>().SetBool("Timez", true);
                timerr.GetComponent<Animator>().SetTrigger("bubble");
                PlayerController.manage.starttime = 30f;
                GameObject timerSnd = GameObject.Find("Timerr");
                timerSnd.GetComponent<AudioSource>().Play();

            }
            else
            {

                GameObject timerr = GameObject.Find("PanelT");
                timerr.GetComponent<Animator>().SetBool("Timez", false);
                PlayerController.manage.starttime = 30f;
                GameObject timerSnd = GameObject.Find("Timerr");
                timerSnd.GetComponent<AudioSource>().Stop();
                // PlayerController.manage.isLoseByTime = true;
            }

        }
    }
    public void levelAnalitics()
    {

        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level1(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 2)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level2(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level3(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level4(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level5(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level6(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level7(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level8(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level9(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level10(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level11(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 12)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level12(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level13(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level14(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level15(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level16(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level17(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level18(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level19(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level20(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level21(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 22)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level22(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level23(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level24(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level25(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level26(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level27(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level28(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level29(PlayerPrefs.GetInt("Coin"));
            }
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {
            count += 1;
            if (count == 1)
            {
                FbManager.manage.level30(PlayerPrefs.GetInt("Coin"));
            }
        }
    }

} 
