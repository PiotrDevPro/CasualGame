using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class levelGenerated : MonoBehaviour
{
    public static levelGenerated manage;
    public GameObject[] levelPrefabs;
    public Text lvl;

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
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        //  for (int i=0; i<amnTilesOnScreen; i++)
        // {
        //  if (i < 1)
        //      SpawnTile(0);
        //  else
        PlayerSpawnPosition();
        SpawnTile();
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
        go.transform.SetParent(transform);
        go.transform.position = new Vector2(-1.890479f, -6.524171f);//.one * spawnX;
        spawnX += tileLength;
        activeTiles.Add(go);
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
        playerTransform.GetComponentInChildren<Animator>().SetBool("Stand", true);
        playerTransform.GetComponentInChildren<Animator>().SetBool("Finish", false);
        playerTransform.GetComponentInChildren<Animator>().SetBool("Crouch", false);
        
    }
    void PlayerSpawnPosition()
    {
        Main.manage.isCutTheRope = false;
        if (PlayerPrefs.GetInt("level") == 2)
        {

            playerTransform.transform.position = new Vector2(-2.63f, -0.5f);

        }
        else
        {
           playerTransform.transform.position = new Vector2(-2.63f, -3.19f);
        }
        
    }
} 
