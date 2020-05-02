using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController manage;
    private GameObject _player;
    private int countDead = 0;
    public float speed = 1f;
    public float jumpForce = 10f;

    private Collider coll;

    //object
    private GameObject _finish;
    private GameObject loseSnd;
    private GameObject winSnd;
    private GameObject winPlayaSnd;
    private GameObject PlayaDeadSnd;
    public GameObject _loseMessage;
    public GameObject losePanel;
    public GameObject FinishEffect;
    public GameObject FinishPanel;
    public GameObject FinishCoin;
    public GameObject CoinX2;

    bool isBoxDetected = false;
    bool isDetected = false;
    bool isDetectedGround = false;
    public bool isDead = false;
    bool isJumping = false;
    bool isCutter = false;
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
        

    }

    void Move()
    {
        
            Vector3 temp = Vector3.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
       //|| PlayerPrefs.GetInt("level") != 6 || PlayerPrefs.GetInt("level") != 7 ||
            if (Air() || isBoxDetected == true)
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
        Debug.DrawRay(transform.position + transform.up /2f,transform.right * 0.3f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up/2f,transform.right * 0.3f, out info, 0.3f, mask))
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
            isDead = true;
            //Time.timeScale = 0.3f;
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


    private void Update()
    {
       
        if (!isDead)
        {
            {
                if (Main.manage.isMove && !isDetected)
                {
                    Move();
                }
                targetDetected();
                    if (PlayerPrefs.GetInt("level") == 8 || PlayerPrefs.GetInt("level") == 12 ||
                    PlayerPrefs.GetInt("level") == 9 || PlayerPrefs.GetInt("level") == 11)
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
        }
        CutterDetected();


    }

    void groundDistance()
    {
        GameObject grnd = GameObject.Find("ground");
        print(grnd.GetComponent<Transform>().position);
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
            Invoke("LatencyDieFront", 0.7f);
            Invoke("LosePanelShow", 1.2f);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Lava")
        {
           
                countDead += 1;
                // GameObject Dead = GameObject.Find("DeadTrig");
                // Dead.GetComponent<BoxCollider>().enabled = true;
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
            Invoke("EffectShowTime",0.1f);
            Invoke("NextLevelPanelShow", 1.7f);
            Invoke("FinishCoinUpdate",0.8f);
            CoinX2.SetActive(true);
            Time.timeScale = 0.8f;
            StartCoroutine(VibroWin());
            
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
                print("Endlevel15");
                _player.GetComponent<Rigidbody>().isKinematic = false;
                _player.transform.position = new Vector2(-1.64f, 1.66f);
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



    IEnumerator VibroWin()
    {
        if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            Handheld.Vibrate();
        }
        yield return new WaitForSeconds(1f);

            if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            Handheld.Vibrate();
        }
        yield return new WaitForSeconds(1f);
             if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            Handheld.Vibrate();
        }

        yield return new WaitForSeconds(1f);
        if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            Handheld.Vibrate();
        }
    }
    
}
