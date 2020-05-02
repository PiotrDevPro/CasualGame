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

    private List<GameObject> activeTiles;

    private void Awake()
    {
        manage = this;
    }

    void Start()
    {
        //PlayerPrefs.SetInt("level",7);
        //PlayerPrefs.SetInt("levelCount", 8);
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        //  for (int i=0; i<amnTilesOnScreen; i++)
        // {
        //  if (i < 1)
        //      SpawnTile(0);
        //  else
        PlayerSpawnPosition();
        SpawnTile();
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
        go.transform.position = new Vector2(-1.890479f, -6.524171f);//.one * spawnX;
        spawnX += tileLength;
        activeTiles.Add(go);
        EnemySpawn();

        if (PlayerPrefs.GetInt("level")==13 || PlayerPrefs.GetInt("level") == 14)
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
            DeleteTiles();
            NewLevel();
            MusicOnStartLevel();
            Time.timeScale = 1;

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
        } else

        lvl.text ="LEVEL " + PlayerPrefs.GetInt("levelCount").ToString();
        
        print(PlayerPrefs.GetInt("level"));
    }

    void NewLevel()
    {
        PlayerSpawnPosition();
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
        AdsManager.manage.ShowAdDefault();
    }
    void PlayerSpawnPosition()
    {
        Main.manage.isCutTheRope = false;
        Main.manage.isGo = false;
        if (PlayerPrefs.GetInt("level") == 2 || PlayerPrefs.GetInt("level") == 9 ||
            PlayerPrefs.GetInt("level") == 10)
        {
            playerTransform.transform.position = new Vector2(-2.63f, -0.5f);
        }
        else
        {
           playerTransform.transform.position = new Vector2(-2.63f, -3.19f);
        }
        if (PlayerPrefs.GetInt("level") == 0)
        {
            GameObject enemy1 = GameObject.Find("Enemy14lev");
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
            GameObject _background = GameObject.Find("backgroundC");
            _background.GetComponent<Image>().enabled = true;
        }
        if (PlayerPrefs.GetInt("level") == 10)
        {
            GameObject _background = GameObject.Find("backgroundC");
            _background.GetComponent<Image>().enabled = true;
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
            //  GameObject natureSound = GameObject.Find("nature");
            // natureSound.GetComponent<AudioSource>().Play();

        }
    }

    void EnemySpawn()
    {
        if (PlayerPrefs.GetInt("level") != 13 && PlayerPrefs.GetInt("level") != 14)
        {
            enemySpawn.SetActive(false);
        }
        else
        {
            enemySpawn.SetActive(true);
        }
        
    }

    void EnemyPosition()
    {
        if (PlayerPrefs.GetInt("level") == 14)
        {

        }
    }
} 
