using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController manage;
    //private GameObject _player;
    private int countDead = 0;
    private int counter = 0;
    public float speed = 1f;
    public float jumpForce = 10f;
    public float curr = 0;
    public float starttime = 25f;

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
    public Text counterTxAnim;

    bool isBoxDetected = false;
    bool isDetected = false;
    bool isDetectedGround = false;
    public bool isDead = false;
    public bool TimeIsOver = false;
    public bool isTimeToCoinFx = false;
    bool isJumping = false;
    bool isCutter = false;
    public bool isFinish = false;
    public bool isWeaponGet = false;
   // public bool isStart = false;
    public bool isMoveBack = false;
    public bool _startTime = false;
    public bool isLoseByTime = false;
    public bool isEnemyDetected = false;
    private void Awake()
    {
        manage = this;
        Application.targetFrameRate = 200;
        coll = GetComponent<Collider>();
        
    }

    private void Start()
    {
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
    }

    void Move()
    {
        
            Vector3 temp = Vector3.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
       //|| PlayerPrefs.GetInt("level") != 6 || PlayerPrefs.GetInt("level") != 7 ||
            if (Air() && PlayerPrefs.GetInt("level") != 12 || isBoxDetected == true && BoatMove.manage.isJump)
            {
                
                GetComponentInChildren<Animator>().SetBool("Walk", false);
                GetComponentInChildren<Animator>().SetBool("Climb", true);
                GameObject soundWow = GameObject.Find("Bouncing");
                soundWow.GetComponent<AudioSource>().Play();

            }
            else
            {
                GetComponentInChildren<Animator>().SetBool("Walk", true);
                GetComponentInChildren<Animator>().SetBool("Stand", false);
                GetComponentInChildren<Animator>().SetBool("Climb", false);
        }
    }
    void MoveBack()
    {
        
        Vector3 temp = -Vector3.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
        
        //|| PlayerPrefs.GetInt("level") != 6 || PlayerPrefs.GetInt("level") != 7 ||
        if (Air() || BoatMove.manage.isJump || isBoxDetected == true )
        {
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Climb", true);
            GameObject soundWow = GameObject.Find("Bouncing");
            soundWow.GetComponent<AudioSource>().Play();

        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Walk", true);
            GetComponentInChildren<Animator>().SetBool("Stand", false);
            GetComponentInChildren<Animator>().SetBool("Climb", false);

        }
    }
    void Jump()
    { 
            GetComponent<Rigidbody>().AddForce(Vector3.up * 3f, ForceMode.Impulse);
            GetComponentInChildren<Animator>().SetBool("Run", false);
            GetComponentInChildren<Animator>().SetBool("Jump", true);
            speed = 1.3f;
    }
    bool Air()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.3f);
    }
    void targetDetected()
    {
        if (!Main.manage.isSkinShopActive)
        {
            Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 0.34f, Color.yellow);
            RaycastHit info;
            int mask = 1 << 8;
            if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 0.34f, out info, 0.34f, mask))
            {
                if (PlayerPrefs.GetInt("Vibro") == 0)
                {
                    Handheld.Vibrate();
                }
                isDetected = true;
                GetComponentInChildren<Animator>().SetBool("Walk", false);
                GetComponentInChildren<Animator>().SetBool("Stand", true);
                GetComponentInChildren<Animator>().SetBool("Climb", false);
                GetComponentInChildren<Animator>().SetBool("DieBack", true);
                //_player.GetComponent<Rigidbody>().position = new Vector3(transform.position.x,transform.position.y,0);
                isDead = true;
                levelGenerated.manage.levelsFailedAnalitycs();
                PlayaDeadSnd.GetComponent<AudioSource>().Play();
                Invoke("LatencyDieBack", 0.3f);
                Invoke("LosePanelShow", 0.6f);

            }
        }
        
    }
    void enemyDetected()
    {
        Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 0.5f, Color.red);
        RaycastHit info;
        int mask = 1 << 14;
        if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 0.5f, out info, 0.5f, mask) && !Enemy.manage.isDead && isWeaponGet)
        {
            if (PlayerPrefs.GetInt("Vibro") == 0)
            {
                Handheld.Vibrate();
            }
            isEnemyDetected = true;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetTrigger("Slash");
            GameObject snd = GameObject.Find("Attack");
            snd.GetComponent<AudioSource>().Play();
            //_player.GetComponent<Rigidbody>().position = new Vector3(transform.position.x,transform.position.y,0);
            //isDead = true;
            //PlayaDeadSnd.GetComponent<AudioSource>().Play();
        }
    }
    void Boxdetected()
    {
        Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 0.3f, Color.red);
        RaycastHit info;

        int mask = 1 << 12;
        if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 0.3f, out info, 0.3f, mask))
        {
            GameObject cratePos = GameObject.Find("crate");
            GetComponent<Transform>().position = new Vector2(cratePos.GetComponent<Transform>().position.x -0.9f, -2.15f);
            
            isBoxDetected = true;
            GameObject jumpSound = GameObject.Find("endJumping");
            jumpSound.GetComponent<AudioSource>().Play();
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
        _loseMessage.GetComponent<Transform>().position = GetComponent<Transform>().position + transform.up * 1.2f;
        _loseMessage.SetActive(true);
        Time.timeScale = 1f;
    }
    void LatencyDieFront()
    {
        _loseMessage.GetComponent<Transform>().position = GetComponent<Transform>().position + transform.up * 1.4f + transform.right * 0.9f;
        _loseMessage.SetActive(true);
        Time.timeScale = 1f;
       
    }
    void LosePanelShow()
    {
        Main.manage.isTapToPlay = false;
        losePanel.SetActive(true);
        loseSnd.GetComponent<AudioSource>().Play();
        skiplvlbtn.SetActive(false);
        //Main.manage.QstPanel.SetActive(false);
        StartCoroutine(CountAnim());

        Main.manage._Go.SetActive(false);
        GameObject MainSound = GameObject.Find("MainTheme");
        MainSound.GetComponent<AudioSource>().Stop();
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
        if (PlayerPrefs.GetInt("level") == 34)
        {
            Invoke("LatencySaluteFX",1.2f);
        }
    }
    void LatencySaluteFX()
    {

            GameObject LastLevelEfct = GameObject.Find("Firework_01");
            LastLevelEfct.GetComponent<ParticleSystem>().Play();
            GameObject saluteU = GameObject.Find("salute");
            saluteU.GetComponent<AudioSource>().Play();
            Invoke("LatencyRate", 3f);
    }
    void LatencyRate()
    {
        RateBox.manage.ActivePanel();
    }
    void NextLevelPanelShow()
    {
        FinishPanel.SetActive(true);
        
        if (PlayerPrefs.GetInt("level") != 34)
        {
            Invoke("LatencyNextButton",1.5f);
        }

        if (PlayerPrefs.GetInt("level") == 6)
        {
            GameObject clinn = GameObject.Find("clinHorizontal (2)");
            clinn.GetComponent<SpriteRenderer>().sortingOrder = 2;
            GameObject fix1 = GameObject.Find("Fix (5)");
            fix1.GetComponent<SpriteRenderer>().sortingOrder = 1;
            GameObject fix2 = GameObject.Find("Fix (6)");
            fix2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        if (PlayerPrefs.GetInt("level") == 34)
        {
            
            //Main.manage.NextBtn.SetActive(false);
            GameObject textStayTuned = GameObject.Find("Text (4)");
            textStayTuned.GetComponent<Text>().enabled = true;
            
        }
    }
    void LatencyNextButton()
    {
        Main.manage.NextBtn.SetActive(true);
        //GameObject sound = GameObject.Find("btnNextSound");
        //sound.GetComponent<AudioSource>().Play();
    }
    void ResetActiveFinishCoin()
    {
        FinishCoin.SetActive(false);
    }
    void FinishCoinUpdate()
    {
        FinishCoin.SetActive(true);
        
        Invoke("LatencyCoinSound",2.2f);
        Invoke("LatencyCoinUpdate",1.3f);
        Invoke("ResetActiveFinishCoin",2f);
        
    }
    void LatencyCoinSound()
    {

        GameObject snd = GameObject.Find("coinFx");
        snd.GetComponent<AudioSource>().Play();
        
    }
    void LatencyCoinUpdate()
    {
        Invoke("LatencyCoinUpdt", 0.5f);
        GameObject sndFx = GameObject.Find("coinStart");
        sndFx.GetComponent<AudioSource>().Play();
        CoinDotween.manage.animate(5);
    }
    void LatencyCoinUpdt()
    {
        Main.manage.Coins();
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
        if (curr <= 10)
        {
            GameObject timerr = GameObject.Find("PanelT");
            timerr.GetComponent<Animator>().SetTrigger("timeTen");
        }

    }
    void lose()
    {
        if (GoAway.manage.isFailed == true)
        {
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GameObject failedSnd = GameObject.Find("Failed");
            failedSnd.GetComponent<AudioSource>().Play();
            isDead = true;
            Main.manage.isTapToPlay = false;
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
            levelGenerated.manage.levelsFailedAnalitycs();
            Invoke("LatencyDieFront", 0.7f);
            Invoke("LosePanelShow", 1.2f);
        }
    }
    public void Vibro()
    {
        if (PlayerPrefs.GetInt("Vibro") == 0 && Main.manage.isTapToPlay)
        {
            Handheld.Vibrate();
        }
    }
    private void Update()
    {
        if (!isDead && Main.manage.isTapToPlay )
        {
            {
                if (Main.manage.isMove && !isDetected && !isMoveBack && Main.manage.isGo && !isEnemyDetected)
                {
                    Move();
      
                }

                if (isMoveBack && Main.manage.isMove && !isDetected)
                {
                    
                    MoveBack();
                }
                targetDetected();
                enemyDetected();
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
              if(PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 19 || PlayerPrefs.GetInt("level") == 29 || PlayerPrefs.GetInt("level") == 31 || PlayerPrefs.GetInt("level") == 34)
                {
                    Timer();
                    GameObject timer = GameObject.Find("Tmr");
                    timer.GetComponent<Text>().text = curr.ToString("0");
                }
            }
        }
        CutterDetected();
             //print(isWeaponGet);
            //print(Main.manage.isMove);
        }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "SwordP1")
        {
            isWeaponGet = true;
            GameObject snd = GameObject.Find("Equip");
            snd.GetComponent<AudioSource>().Play();
        }

        if(col.collider.tag == "failed")
        {
            GoAway.manage.isFailed = true;
            Vibro();
        }

        if (col.collider.tag == "ISound")
        {
            Vibro();
        }

        if (col.collider.tag == "Non" && PlayerPrefs.GetInt("level")==24)
        {
            Vibro();
        }

        if (col.collider.tag == "Grnd")
        {
            Vibro();
        }
        
        if (col.collider.tag == "Finish" && Main.manage.isGo)
        {
            Main.manage.isMove = false;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Crouch", true);
            GetComponentInChildren<Animator>().SetBool("Finish", true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            winPlayaSnd.GetComponent<AudioSource>().Play();
            Invoke("latencyWinSnd",1f);
            _startTime = false;
            isFinish = true;
            //starttime = 30f;
            //isStart = true;
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
            Invoke("EffectShowTime", 0.1f);
            Invoke("NextLevelPanelShow", 1.7f);
            Invoke("FinishCoinUpdate", 0.8f);
            CoinX2.SetActive(true);
            Time.timeScale = 0.8f;
            StartCoroutine(VibroWin());
            //FbManager.manage.LevelEnded(PlayerPrefs.GetInt("levelCount"));
            levelGenerated.manage.LevelsFinishAnalitycs();

        }
        if (col.collider.tag == "Lava")
        {
                countDead += 1;
                isDead = true;

                GetComponentInChildren<Animator>().SetBool("Walk", false);
                GetComponentInChildren<Animator>().SetBool("Stand", true);
                GetComponentInChildren<Animator>().SetBool("Climb", false);
                GetComponentInChildren<Animator>().SetBool("DieFront", true);
                
                if (countDead == 1)
                {
                    GameObject WaterFireSnd = GameObject.Find("WaterFire");
                    WaterFireSnd.GetComponent<AudioSource>().Play();
                    GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
                    SmokeExplosion.GetComponent<ParticleSystem>().Play();
                    SmokeExplosion.GetComponent<Transform>().position = transform.position + transform.up * 0.5f + transform.right * 0.1f;
                    GameObject SmokeDarkGo = GameObject.Find("SmokeDark");
                    SmokeDarkGo.GetComponent<ParticleSystem>().Play();
                    Vibro();
                    SmokeDarkGo.GetComponent<Transform>().position = transform.position + transform.up * 0.5f + transform.right * 0.1f;
                    PlayaDeadSnd.GetComponent<AudioSource>().Play();
                    levelGenerated.manage.levelsFailedAnalitycs();
                    Invoke("LatencyDieFront", 0.2f);
                    Invoke("LosePanelShow", 0.6f);
           }
        }
        if (col.collider.tag == "Gas")
        {
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", true);
            isDead = true;
            levelGenerated.manage.levelsFailedAnalitycs();
            Vibro();
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
                GetComponentInChildren<Animator>().SetBool("Walk", false);
                GetComponentInChildren<Animator>().SetBool("Stand", true);
                GetComponentInChildren<Animator>().SetBool("Climb", false);
                GetComponentInChildren<Animator>().SetBool("DieBack", true);
                isDead = true;
                levelGenerated.manage.levelsFailedAnalitycs();
                Vibro();
                PlayaDeadSnd.GetComponent<AudioSource>().Play();
                Invoke("LatencyDieFront", 0.7f);
                Invoke("LosePanelShow", 1.2f);
            }
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieBack", true);
            isDead = true;
            Vibro();
            levelGenerated.manage.levelsFailedAnalitycs();
            PlayaDeadSnd.GetComponent<AudioSource>().Play();
            Invoke("LatencyDieFront", 0.7f);
            Invoke("LosePanelShow", 1.2f);
        }
    }

    void latencyWinSnd()
    {
        winSnd.GetComponent<AudioSource>().Play();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Finish" && Main.manage.isGo)
        {
            Main.manage.isMove = false;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Crouch", true);
            GetComponentInChildren<Animator>().SetBool("Finish",true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            winPlayaSnd.GetComponent<AudioSource>().Play();
            Invoke("latencyWinSnd", 1f);
            isFinish = true;
            _startTime = false;
           // starttime = 30f;
          //  isStart = true;
            GameObject timerSnd = GameObject.Find("Timerr");
            timerSnd.GetComponent<AudioSource>().Stop();
            Invoke("EffectShowTime",0.1f);
            Invoke("NextLevelPanelShow", 1.7f);
            Invoke("FinishCoinUpdate",0.8f);
            CoinX2.SetActive(true);
            Time.timeScale = 0.8f;
            StartCoroutine(VibroWin());
            //FbManager.manage.LevelEnded(PlayerPrefs.GetInt("levelCount"));
            levelGenerated.manage.LevelsFinishAnalitycs();

        }

        if (col.tag == "failed")
        {
            GoAway.manage.isFailed = true;
            levelGenerated.manage.levelsFailedAnalitycs();
        }

        if (col.name == "BackTrig")
        {
            isMoveBack = true;
            transform.Rotate(new Vector2(0, 180));

        }

        if (col.name == "BackTrigLR")
        {
            isMoveBack = false;
            transform.Rotate(new Vector2(0, 180));
        }

        if (col.tag == "Spikes")
        {
            countDead += 1;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", true);
            
            isDead = true;
            if (countDead == 1)
            {
                PlayaDeadSnd.GetComponent<AudioSource>().Play();
                Vibro();
                //Amplitude.Instance.logEvent("Dead");
                levelGenerated.manage.levelsFailedAnalitycs();
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
            transform.position = new Vector2(0.82f, 0.93f);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", false);
            GetComponentInChildren<Animator>().SetBool("Jump", true);

        }

        if (col.tag == "endJump")
        {
            if (PlayerPrefs.GetInt("level") == 1)
            {
                
            GetComponentInChildren<Animator>().SetBool("Climb", true);
            GetComponentInChildren<Animator>().SetBool("Walk", true);
            GetComponentInChildren<Animator>().SetBool("Crouch", false);
            GetComponent<Rigidbody>().isKinematic = false;
            transform.position = new Vector2(1.4f, -0.04f);
            GameObject sound = GameObject.Find("endJumping");
            sound.GetComponent<AudioSource>().Play();
            GameObject triggDetected = GameObject.Find("ChainPart1 (1)");
            triggDetected.GetComponent<BoxCollider>().enabled = false;
            }
            if (PlayerPrefs.GetInt("level") == 15)
            {
                
                GetComponent<Rigidbody>().isKinematic = false;
                transform.position = new Vector2(-1.69f, 0.14f);
                GetComponentInChildren<Animator>().SetBool("Climb", true);
                GetComponentInChildren<Animator>().SetBool("Walk", true);
                GetComponentInChildren<Animator>().SetBool("Crouch", false);
                GameObject sound = GameObject.Find("endJumping");
                sound.GetComponent<AudioSource>().Play();
                GameObject triggDetected = GameObject.Find("ChainPart1 (1)");
                triggDetected.GetComponent<BoxCollider>().enabled = false;
            }

            if (PlayerPrefs.GetInt("level") == 26)
            {
                
                GetComponent<Rigidbody>().isKinematic = false;
                transform.position = new Vector2(-.53f,-.31f);
                GetComponentInChildren<Animator>().SetBool("Climb", true);
                GetComponentInChildren<Animator>().SetBool("Walk", true);
                GetComponentInChildren<Animator>().SetBool("Crouch", false);
                GameObject sound = GameObject.Find("endJumping");
                sound.GetComponent<AudioSource>().Play();
                GameObject triggDetected = GameObject.Find("ChainPart1 (1)");
                triggDetected.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (col.tag == "SwordP1")
        {
            isWeaponGet = true;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Finish" && Main.manage.isGo && PlayerPrefs.GetInt("level")==20)
        {
            counter += 1;
                if(counter == 1) 
            {
                Main.manage.isMove = false;
                GetComponentInChildren<Animator>().SetBool("Walk", false);
                GetComponentInChildren<Animator>().SetBool("Crouch", true);
                GetComponentInChildren<Animator>().SetBool("Finish", true);
                GetComponentInChildren<Animator>().SetBool("Climb", false);
                winPlayaSnd.GetComponent<AudioSource>().Play();
                Invoke("latencyWinSnd", 1f);
                _startTime = false;
                //  isStart = true;
                GameObject timerSnd = GameObject.Find("Timerr");
                timerSnd.GetComponent<AudioSource>().Stop();
                Invoke("EffectShowTime", 0.1f);
                Invoke("NextLevelPanelShow", 1.7f);
                Invoke("FinishCoinUpdate", 0.8f);
                CoinX2.SetActive(true);
                Time.timeScale = 0.8f;
                StartCoroutine(VibroWin());
                // FbManager.manage.LevelEnded(PlayerPrefs.GetInt("levelCount"));
                levelGenerated.manage.LevelsFinishAnalitycs();

            }
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
    IEnumerator CountAnim()
    {
        yield return new WaitForSeconds(0.4f);
        counterTxAnim.text = "5";
        GameObject snd = GameObject.Find("Count");
        GameObject sndOver = GameObject.Find("revive");
        snd.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        counterTxAnim.text = "4";
        snd.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        counterTxAnim.text = "3";
        snd.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        counterTxAnim.text = "2";
        snd.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        counterTxAnim.text = "1";
        snd.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        counterTxAnim.text = "0";
        sndOver.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.6f);
        Main.manage.Restart();
    }
}
