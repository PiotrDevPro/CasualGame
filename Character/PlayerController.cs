using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController manage;
    private GameObject _player;
    private int countDead = 0;
    public float speed = 1f;
    public float jumpForce = 10f;
    public float curr = 0;
    public float starttime = 30f;

    private Collider coll;

    //object
    private GameObject _finish;
    private GameObject loseSnd;
    private GameObject winSnd;
    private GameObject winPlayaSnd;
    private GameObject PlayaDeadSnd;
    public GameObject _loseMessage;
    public GameObject losePanel;
    public GameObject skiplvlbtn;
    public GameObject FinishEffect;
    public GameObject FinishPanel;
    public GameObject FinishCoin;
    public GameObject CoinX2;

    bool isBoxDetected = false;
    bool isDetected = false;
    bool isDetectedGround = false;
    public bool isDead = false;
    public bool TimeIsOver = false;
    bool isJumping = false;
    bool isCutter = false;
    public bool isFinish = false;
   // public bool isStart = false;
    public bool isMoveBack = false;
    public bool _startTime = false;
    public bool isLoseByTime = false;
    private void Awake()
    {
        manage = this;
        coll = GetComponent<Collider>();
    }

    private void Start()
    {
        _player = GameObject.Find("Default");
        _finish = GameObject.Find("finish");
        loseSnd = GameObject.Find("loseSound");
        winSnd = GameObject.Find("winSound");
        winPlayaSnd = GameObject.Find("PlayerWin");
        PlayaDeadSnd = GameObject.Find("Dead");
        _loseMessage.SetActive(false);
        FinishEffect.SetActive(false);
        FinishPanel.SetActive(false);
        FinishCoin.SetActive(false);
        curr = starttime;
      //  isStart = false;
    }

    void Move()
    {
        
            Vector3 temp = Vector3.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
       //|| PlayerPrefs.GetInt("level") != 6 || PlayerPrefs.GetInt("level") != 7 ||
            if (Air() && PlayerPrefs.GetInt("level") != 12 || isBoxDetected == true && BoatMove.manage.isJump)
            {
                
                _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
                _player.GetComponentInChildren<Animator>().SetBool("Climb", true);
                GameObject soundWow = GameObject.Find("Bouncing");
                soundWow.GetComponent<AudioSource>().Play();

            }
            else
            {
                _player.GetComponentInChildren<Animator>().SetBool("Walk", true);
                _player.GetComponentInChildren<Animator>().SetBool("Stand", false);
                _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            
        }
    }

    void MoveBack()
    {
        
        Vector3 temp = -Vector3.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
        
        //|| PlayerPrefs.GetInt("level") != 6 || PlayerPrefs.GetInt("level") != 7 ||
        if (Air() && BoatMove.manage.isJump || isBoxDetected == true )
        {

            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", true);
            GameObject soundWow = GameObject.Find("Bouncing");
            soundWow.GetComponent<AudioSource>().Play();

        }
        else
        {
            _player.GetComponentInChildren<Animator>().SetBool("Walk", true);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", false);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);

        }
    }

    void Jump()
    {
        // if (!CheckGround())
        // {
        
            _player.GetComponent<Rigidbody>().AddForce(Vector3.up * 3f, ForceMode.Impulse);
        _player.GetComponentInChildren<Animator>().SetBool("Run", false);
            _player.GetComponentInChildren<Animator>().SetBool("Jump", true);
            speed = 1.3f;
        
       // }
    }

    bool Air()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.9f);
    }


    void targetDetected()
    {
        Debug.DrawRay(transform.position + transform.up /2f,transform.right * 0.34f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up/2f,transform.right * 0.34f, out info, 0.34f, mask))
        {
            if (PlayerPrefs.GetInt("Vibro") == 0)
            {
                Handheld.Vibrate();
            }
            isDetected = true;
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            _player.GetComponentInChildren<Animator>().SetBool("DieBack", true);
            //_player.GetComponent<Rigidbody>().position = new Vector3(transform.position.x,transform.position.y,0);
            isDead = true;
            PlayaDeadSnd.GetComponent<AudioSource>().Play();
            Invoke("LatencyDieBack", 0.3f);
            Invoke("LosePanelShow",0.6f);

        }
    }

    void Boxdetected()
    {
        Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 0.3f, Color.red);
        RaycastHit info;

        int mask = 1 << 12;
        if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 0.3f, out info, 0.3f, mask))
        {
           // if (PlayerPrefs.GetInt("Vibro") == 0)
           // {
           //     Handheld.Vibrate();
           // }
            
            
            GameObject cratePos = GameObject.Find("crate");
            _player.GetComponent<Transform>().position = new Vector2(cratePos.GetComponent<Transform>().position.x -0.5f, -2.25f);
            
            isBoxDetected = true;

        }
        else
        {
           
            isBoxDetected = false;
            
        }
    }
    

    void groundDetected()
    {
        Debug.DrawRay(transform.position + transform.up,-transform.up * 1.5f , Color.red);
        RaycastHit info;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position + transform.up, -transform.up *1.5f, out info, 0.3f, mask))
        {
            isDetectedGround = true;
        }
        else
        {
            isDetectedGround = false;
        }
    }

    void LatencyDieBack()
    {
        _loseMessage.GetComponent<Transform>().position = _player.GetComponent<Transform>().position + transform.up * 1.2f;
        _loseMessage.SetActive(true);
        Time.timeScale = 1f;
    }

    void LatencyDieFront()
    {
        _loseMessage.GetComponent<Transform>().position = _player.GetComponent<Transform>().position + transform.up * 1.4f + transform.right * 0.9f;
        _loseMessage.SetActive(true);
        Time.timeScale = 1f;
       
    }

    void LosePanelShow()
    {
        Main.manage.isTapToPlay = false;
        losePanel.SetActive(true);
        loseSnd.GetComponent<AudioSource>().Play();
        skiplvlbtn.SetActive(false);
        Main.manage.QstPanel.SetActive(false);
        Main.manage._Go.SetActive(false);
       // if (PlayerPrefs.GetInt("level") == 19)
       // {
        //    skiplvlbtn.SetActive(true);
       // }
    }

    void EffectShowTime()
    {
        FinishEffect.SetActive(true);
        if (PlayerPrefs.GetInt("level") == 2)
        {
            GameObject Cratee = GameObject.Find("crate");
            Cratee.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (PlayerPrefs.GetInt("level") == 3)
        {
            GameObject Cratee = GameObject.Find("crate");
            Cratee.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (PlayerPrefs.GetInt("level") == 5)
        {
            GameObject clinn = GameObject.Find("clin");
            clinn.GetComponent<SpriteRenderer>().sortingOrder = 0;
            GameObject clinn1 = GameObject.Find("clin (1)");
            clinn1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if (PlayerPrefs.GetInt("level") == 6)
        {
            GameObject clinn = GameObject.Find("clinHorizontal (2)");
            clinn.GetComponent<SpriteRenderer>().sortingOrder = 1;
            GameObject fix1 = GameObject.Find("Fix (5)");
            fix1.GetComponent<SpriteRenderer>().sortingOrder = 0;
            GameObject fix2 = GameObject.Find("Fix (6)");
            fix2.GetComponent<SpriteRenderer>().sortingOrder = 0;

        }
    }

    void NextLevelPanelShow()
    {
        FinishPanel.SetActive(true);

        if (PlayerPrefs.GetInt("level") == 6)
        {
            GameObject clinn = GameObject.Find("clinHorizontal (2)");
            clinn.GetComponent<SpriteRenderer>().sortingOrder = 2;
            GameObject fix1 = GameObject.Find("Fix (5)");
            fix1.GetComponent<SpriteRenderer>().sortingOrder = 1;
            GameObject fix2 = GameObject.Find("Fix (6)");
            fix2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }

    void ResetActiveFinishCoin()
    {
        FinishCoin.SetActive(false);
    }

    void FinishCoinUpdate()
    {
        FinishCoin.SetActive(true);
        Main.manage.Coins();
        Invoke("ResetActiveFinishCoin",1f);
        
    }

    void CutterDetected()
    {
        GameObject jumpTrig = GameObject.Find("jumpTrigger");
    }

    void Timer()
    {
        
        curr -= 1 * Time.deltaTime;
        if (curr <= 0)
        {
            curr = 0;
            GoAway.manage.isFailed = true;
            GameObject timerSnd1 = GameObject.Find("Timerr");
            timerSnd1.GetComponent<AudioSource>().Stop();
        }
        
    }

    private void Update()
    {
        if (!isDead && Main.manage.isTapToPlay )
        {
            {
                if (Main.manage.isMove && !isDetected && !isMoveBack && Main.manage.isGo)
                {
                    Move();
      
                }

                if (isMoveBack && Main.manage.isMove && !isDetected)
                {
                    
                    MoveBack();
                }
                targetDetected();
                    if (PlayerPrefs.GetInt("level") == 4 || PlayerPrefs.GetInt("level") == 7 || PlayerPrefs.GetInt("level") == 8 || PlayerPrefs.GetInt("level") == 12 ||
                    PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 11 || PlayerPrefs.GetInt("level") == 17 || PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 20 || PlayerPrefs.GetInt("level") == 21
                    || PlayerPrefs.GetInt("level") == 22 || PlayerPrefs.GetInt("level") == 23 || PlayerPrefs.GetInt("level") == 24 || PlayerPrefs.GetInt("level") == 27 || PlayerPrefs.GetInt("level") == 28
                    || PlayerPrefs.GetInt("level") == 29)
                    
                    {
                        lose();
                    
                }
                
                if (Main.manage.isGo)
                {
                    Boxdetected();
                }
            }
            if (isJumping)
            {

                Jump();
            }
            

            if (_startTime)
            {
              if(PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 29)
                {
                    Timer();
                    GameObject timer = GameObject.Find("Tmr");
                    timer.GetComponent<Text>().text = curr.ToString("0");
                    // print(curr);
                }
            }
        }
        CutterDetected();

       // print(isStart);
       // print(Main.manage.isMove);
    }



    void lose()
    {
        if (GoAway.manage.isFailed == true)
        {
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            GameObject failedSnd = GameObject.Find("Failed");
            failedSnd.GetComponent<AudioSource>().Play();
            isDead = true;
            Main.manage.isTapToPlay = false; 
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
            Invoke("LatencyDieFront", 0.7f);
            Invoke("LosePanelShow", 1.2f);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "failed")
        {
            GoAway.manage.isFailed = true;
        }

        if (col.collider.tag == "Finish" && Main.manage.isGo)
        {
            Main.manage.isMove = false;
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Crouch", true);
            _player.GetComponentInChildren<Animator>().SetBool("Finish", true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            winPlayaSnd.GetComponent<AudioSource>().Play();
            winSnd.GetComponent<AudioSource>().Play();
            _startTime = false;
           // isStart = true;
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
            Invoke("EffectShowTime", 0.1f);
            Invoke("NextLevelPanelShow", 1.7f);
            Invoke("FinishCoinUpdate", 0.8f);
            CoinX2.SetActive(true);
            Time.timeScale = 0.8f;
            StartCoroutine(VibroWin());
            FbManager.manage.LevelEnded(PlayerPrefs.GetInt("levelCount"));
            LevelsFinishAnalitycs();

        }
        if (col.collider.tag == "Lava")
        {
                countDead += 1;
                isDead = true;
                _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
                _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
                _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
                _player.GetComponentInChildren<Animator>().SetBool("DieFront", true);
                
                if (countDead == 1)
                {
                    GameObject WaterFireSnd = GameObject.Find("WaterFire");
                    WaterFireSnd.GetComponent<AudioSource>().Play();
                    GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
                    SmokeExplosion.GetComponent<ParticleSystem>().Play();
                    SmokeExplosion.GetComponent<Transform>().position = _player.transform.position + transform.up * 0.5f + transform.right * 0.1f;
                    GameObject SmokeDarkGo = GameObject.Find("SmokeDark");
                    SmokeDarkGo.GetComponent<ParticleSystem>().Play();
                    SmokeDarkGo.GetComponent<Transform>().position = _player.transform.position + transform.up * 0.5f + transform.right * 0.1f;
                    PlayaDeadSnd.GetComponent<AudioSource>().Play();
                    Invoke("LatencyDieFront", 0.2f);
                    Invoke("LosePanelShow", 0.6f);
           }
        }
        if (col.collider.tag == "Gas")
        {
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            _player.GetComponentInChildren<Animator>().SetBool("DieFront", true);
            isDead = true;
            PlayaDeadSnd.GetComponent<AudioSource>().Play();
            Invoke("LatencyDieFront", 0.7f);
            Invoke("LosePanelShow", 1.2f);
        }
        if (col.collider.tag == "Death")
            
            {
            if (PlayerPrefs.GetInt("level") == 11) 
            {
                GetComponent<CapsuleCollider>().isTrigger = true;
                GetComponent<Rigidbody>().isKinematic = true;
                _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
                _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
                _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
                _player.GetComponentInChildren<Animator>().SetBool("DieBack", true);
                isDead = true;
                PlayaDeadSnd.GetComponent<AudioSource>().Play();
                Invoke("LatencyDieFront", 0.7f);
                Invoke("LosePanelShow", 1.2f);
            }
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            _player.GetComponentInChildren<Animator>().SetBool("DieBack", true);
            isDead = true;
            PlayaDeadSnd.GetComponent<AudioSource>().Play();
            Invoke("LatencyDieFront", 0.7f);
            Invoke("LosePanelShow", 1.2f);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Finish")
        {
            Main.manage.isMove = false;
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Crouch", true);
            _player.GetComponentInChildren<Animator>().SetBool("Finish",true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            winPlayaSnd.GetComponent<AudioSource>().Play();
            winSnd.GetComponent<AudioSource>().Play();
            _startTime = false;
          //  isStart = true;
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
            Invoke("EffectShowTime",0.1f);
            Invoke("NextLevelPanelShow", 1.7f);
            Invoke("FinishCoinUpdate",0.8f);
            CoinX2.SetActive(true);
            Time.timeScale = 0.8f;
            StartCoroutine(VibroWin());
            FbManager.manage.LevelEnded(PlayerPrefs.GetInt("levelCount"));
            LevelsFinishAnalitycs();


        }

        if (col.tag == "failed")
        {
            GoAway.manage.isFailed = true;
        }

        if (col.name == "BackTrig")
        {
            isMoveBack = true;
            transform.Rotate(new Vector2(0, 180));

        }
        if (col.tag == "Spikes")
        {
            countDead += 1;
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            _player.GetComponentInChildren<Animator>().SetBool("DieFront", true);
            isDead = true;
            if (countDead == 1)
            {
                PlayaDeadSnd.GetComponent<AudioSource>().Play();
                Invoke("LatencyDieFront", 0.3f);
                Invoke("LosePanelShow", 0.6f);
            }

            if (PlayerPrefs.GetInt("level") == 4)
            {
                GameObject blamm = GameObject.Find("Blam");
                blamm.GetComponent<HTSpriteSequencer>().enabled = true;
                GameObject waterBlow = GameObject.Find("WaterBoiling");
                waterBlow.GetComponent<ParticleSystem>().Play();
                GameObject wtrSound = GameObject.Find("wtrSnd");
                wtrSound.GetComponent<AudioSource>().Play();
            }

            if (PlayerPrefs.GetInt("level") == 25)
            {
                GameObject wtrSound = GameObject.Find("Yeahyyy");
                wtrSound.GetComponent<AudioSource>().Play();
            }
            
        }

        if(col.tag == "jumpp")
        {
            _player.transform.position = new Vector2(0.82f, 0.93f);
            _player.GetComponentInChildren<Animator>().SetBool("Walk", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", false);
            _player.GetComponentInChildren<Animator>().SetBool("Jump", true);
            

        }
        if (col.tag == "endJump")
        {
            if (PlayerPrefs.GetInt("level") == 1)
            {
                
            _player.GetComponentInChildren<Animator>().SetBool("Climb", true);
            _player.GetComponentInChildren<Animator>().SetBool("Walk", true);
            _player.GetComponentInChildren<Animator>().SetBool("Crouch", false);
            _player.GetComponent<Rigidbody>().isKinematic = false;
            _player.transform.position = new Vector2(1.4f, -0.04f);
            GameObject sound = GameObject.Find("endJumping");
            sound.GetComponent<AudioSource>().Play();
            GameObject triggDetected = GameObject.Find("ChainPart1 (1)");
            triggDetected.GetComponent<BoxCollider>().enabled = false;
            }
            if (PlayerPrefs.GetInt("level") == 15)
            {
                
                _player.GetComponent<Rigidbody>().isKinematic = false;
                _player.transform.position = new Vector2(-1.69f, 0.14f);
                _player.GetComponentInChildren<Animator>().SetBool("Climb", true);
                _player.GetComponentInChildren<Animator>().SetBool("Walk", true);
                _player.GetComponentInChildren<Animator>().SetBool("Crouch", false);
                GameObject sound = GameObject.Find("endJumping");
                sound.GetComponent<AudioSource>().Play();
                GameObject triggDetected = GameObject.Find("ChainPart1 (1)");
                triggDetected.GetComponent<BoxCollider>().enabled = false;
            }

            if (PlayerPrefs.GetInt("level") == 26)
            {
                
                _player.GetComponent<Rigidbody>().isKinematic = false;
                _player.transform.position = new Vector2(-.53f,-.31f);
                _player.GetComponentInChildren<Animator>().SetBool("Climb", true);
                _player.GetComponentInChildren<Animator>().SetBool("Walk", true);
                _player.GetComponentInChildren<Animator>().SetBool("Crouch", false);
                GameObject sound = GameObject.Find("endJumping");
                sound.GetComponent<AudioSource>().Play();
                GameObject triggDetected = GameObject.Find("ChainPart1 (1)");
                triggDetected.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void LevelsFinishAnalitycs()
    {
        if (PlayerPrefs.GetInt("levelCount") == 1)
        {
            FbManager.manage.level1Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 2)
        {
            FbManager.manage.level2Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 3)
        {
            FbManager.manage.level3Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 4)
        {
            FbManager.manage.level4Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 5)
        {
            FbManager.manage.level5Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 6)
        {
            FbManager.manage.level6Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 7)
        {
            FbManager.manage.level7Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 8)
        {
            FbManager.manage.level8Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 9)
        {
            FbManager.manage.level9Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 10)
        {
            FbManager.manage.level10Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 11)
        {
            FbManager.manage.level11Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 12)
        {
            FbManager.manage.level12Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 13)
        {
            FbManager.manage.level13Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 14)
        {
            FbManager.manage.level14Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 15)
        {
            FbManager.manage.level15Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 16)
        {
            FbManager.manage.level16Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 17)
        {
            FbManager.manage.level17Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 18)
        {
            FbManager.manage.level18Finish(PlayerPrefs.GetInt("Coin"));
        }
        if (PlayerPrefs.GetInt("levelCount") == 19)
        {
            FbManager.manage.level19Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 20)
        {
            FbManager.manage.level20Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 21)
        {
            FbManager.manage.level21Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 22)
        {
            FbManager.manage.level22Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 23)
        {
            FbManager.manage.level23Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 24)
        {
            FbManager.manage.level24Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 25)
        {
            FbManager.manage.level25Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 26)
        {
            FbManager.manage.level26Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 27)
        {
            FbManager.manage.level27Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 28)
        {
            FbManager.manage.level28Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 29)
        {
            FbManager.manage.level29Finish(PlayerPrefs.GetInt("Coin"));
        }

        if (PlayerPrefs.GetInt("levelCount") == 30)
        {
            FbManager.manage.level30Finish(PlayerPrefs.GetInt("Coin"));
        }
    }



    IEnumerator VibroWin()
    {
        if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            Handheld.Vibrate();
        }
        yield return new WaitForSeconds(0.5f);

            if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            Handheld.Vibrate();
        }
        yield return new WaitForSeconds(0.5f);
             if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            Handheld.Vibrate();
        }

      //  yield return new WaitForSeconds(1f);
    //    if (PlayerPrefs.GetInt("Vibro") == 0)
      //  {
      //      Handheld.Vibrate();
       // }
    }
    
}
