using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController manage;
    private GameObject _player;
    
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
    
    
    bool isDetected = false;
    bool isDetectedGround = false;
    bool isDead = false;
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

            if (Air())
            {
                
                _player.GetComponentInChildren<Animator>().SetBool("Run", false);
                _player.GetComponentInChildren<Animator>().SetBool("Climb", true);
                GameObject soundWow = GameObject.Find("Bouncing");
                soundWow.GetComponent<AudioSource>().Play();

        }
            else
            {
                _player.GetComponentInChildren<Animator>().SetBool("Run", true);
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
            //_player.GetComponentInChildren<Animator>().SetBool("Ready", true);
            _player.GetComponentInChildren<Animator>().SetBool("Jump", true);
            speed = 1.3f;
        
       // }
    }

    bool Air()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.5f);
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
            _player.GetComponentInChildren<Animator>().SetBool("Run", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("DieBack", true);
            isDead = true;
            //Time.timeScale = 0.3f;
            PlayaDeadSnd.GetComponent<AudioSource>().Play();
            Invoke("LatencyDieBack", 0.7f);
            Invoke("LosePanelShow",1.2f);

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
        losePanel.SetActive(true);
        loseSnd.GetComponent<AudioSource>().Play();
    }

    void EffectShowTime()
    {
        FinishEffect.SetActive(true);
        if (PlayerPrefs.GetInt("level") == 3)
        {
            GameObject Cratee = GameObject.Find("crate");
            Cratee.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    void NextLevelPanelShow()
    {
        FinishPanel.SetActive(true);
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
                
            }
            if (isJumping)
            {

                Jump();
            }
        }
        CutterDetected();
        //groundDetected();
        //print(isDetectedGround);

    }

    void groundDistance()
    {
        GameObject grnd = GameObject.Find("ground");
        print(grnd.GetComponent<Transform>().position);
    }

     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Finish")
        {
            Main.manage.isMove = false;
            _player.GetComponentInChildren<Animator>().SetBool("Run", false);
           // _player.GetComponentInChildren<Animator>().SetBool("Jump", false);
           // _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("Crouch", true);
            _player.GetComponentInChildren<Animator>().SetBool("Finish",true);
            winPlayaSnd.GetComponent<AudioSource>().Play();
            winSnd.GetComponent<AudioSource>().Play();
            Invoke("EffectShowTime",1f);
            Invoke("NextLevelPanelShow", 4.5f);
            Invoke("FinishCoinUpdate",3.5f);
            CoinX2.SetActive(true);
            Time.timeScale = 0.8f;
            StartCoroutine(VibroWin());
            
        }
        if (col.tag == "Spikes")
        {
            _player.GetComponentInChildren<Animator>().SetBool("Run", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", true);
            _player.GetComponentInChildren<Animator>().SetBool("Climb", false);
            _player.GetComponentInChildren<Animator>().SetBool("DieFront", true);
            isDead = true;
            PlayaDeadSnd.GetComponent<AudioSource>().Play();
            Invoke("LatencyDieFront", 0.7f);
            Invoke("LosePanelShow", 1.2f);
        }

        if(col.tag == "jumpp")
        {
            //_player.transform.position = new Vector2(1.57f,0.93f);
            _player.transform.position = new Vector2(0.82f, 0.93f);
            _player.GetComponentInChildren<Animator>().SetBool("Run", false);
            _player.GetComponentInChildren<Animator>().SetBool("Stand", false);
            _player.GetComponentInChildren<Animator>().SetBool("Jump", true);
            
            // isJumping = true;
            // GameObject sound = GameObject.Find("jumpin");
            // sound.GetComponent<AudioSource>().Play();

        }
        if (col.tag == "endJump")
        {
            //isJumping = false;
            //_player.GetComponentInChildren<Animator>().SetBool("Climb", true);
            _player.GetComponentInChildren<Animator>().SetBool("Jump", false);
            GameObject sound = GameObject.Find("endJumping");
            sound.GetComponent<AudioSource>().Play();

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
