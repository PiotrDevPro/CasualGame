using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public static Enemy manage;
    public bool isDead = false;
    bool isPlayerDetect = false;
    bool isPlayerDetectOnDistance = false;
    bool isClinDetect = false;
    float speed = 1.2f;
    public int countDead = 0;

    private void Awake()
    {
        manage = this;
    }

    private void Start()
    {
        EnemyPos();
    }

    public void EnemyPos()
    {
        if (PlayerPrefs.GetInt("level") == 13)
        {
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
            isDead = false;
            GetComponent<Transform>().position = new Vector2(1.3f, -3.2f);
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }
            if (PlayerPrefs.GetInt("level") == 14)
        {
            
            isDead = false;
            GetComponent<Transform>().position = new Vector2(2.3f,-3.2f);
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }
        if (PlayerPrefs.GetInt("level") == 16)
        {
            
            isDead = false;
            GetComponent<Transform>().position = new Vector2(1.7f, -3.2f);
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
            
        }

        if (PlayerPrefs.GetInt("level") == 19)
        {

            isDead = false;
            GetComponent<Transform>().position = new Vector2(0, -3.27f);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("DieBack", false);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }

        if (PlayerPrefs.GetInt("level") == 23)
        {
            isDead = false;
            GetComponent<Transform>().position = new Vector2(0.90f, -3.01f);
            GetComponent<Transform>().eulerAngles = new Vector2(0,180);
            GetComponentInChildren<Animator>().SetBool("DieBack", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }

        if (PlayerPrefs.GetInt("level") == 26)
        {
            isDead = false;
            GetComponent<Transform>().position = new Vector2(2.03f, -0.76f);
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
            
        }

        if (PlayerPrefs.GetInt("level") == 27)
        {
            isDead = false;
            GetComponent<Transform>().position = new Vector2(2.37f, 0.48f);
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
            
        }

        if (PlayerPrefs.GetInt("level") == 30)
        {
            isDead = false;
            GetComponent<Transform>().position = new Vector2(2.37f, -3.728321f);
            GetComponent<Transform>().eulerAngles = new Vector2(0, 180);
            GetComponentInChildren<Animator>().SetBool("DieBack", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;

        }

        if (PlayerPrefs.GetInt("level") == 33)
        {
            isDead = false;
            GetComponent<Transform>().position = new Vector2(-2.57f, -2.95f);
            GetComponent<Transform>().eulerAngles = new Vector2(0, 0);
            GetComponentInChildren<Animator>().SetBool("DieBack", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", false);
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;

        }
    }

    void Move()
    {
        Vector3 temp = -Vector3.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
        GetComponentInChildren<Animator>().SetBool("Walk", true);
        GetComponentInChildren<Animator>().SetBool("Stand", false);
        GetComponentInChildren<Animator>().SetBool("Climb", false);
        //print("move");
    }
    void MoveBack()
    {
        Vector3 temp = Vector3.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
        GetComponentInChildren<Animator>().SetBool("Walk", true);
        GetComponentInChildren<Animator>().SetBool("Stand", false);
        GetComponentInChildren<Animator>().SetBool("Climb", false);
        //print("move");
    }
    void ClinDetected()
    {
        Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 4.5f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 4.5f, out info, 4.5f, mask))
        {

            isClinDetect = true;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            
        }
        else
        {
           
            isClinDetect = false;
            //print("ClinNoDetect");
        }
    }
    void PlayerDetect()
    {
        Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 0.5f, Color.cyan);
        RaycastHit info;
        int mask = 1 << 11;
        if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 0.5f, out info, 0.5f, mask) && !PlayerController.manage.isDead)
        {
            print("playerDetect");
            isPlayerDetect = true;
            GameObject Attack = GameObject.Find("MeleeWeapon");
            Attack.GetComponent<BoxCollider>().enabled = true;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Ready", true);
            GetComponentInChildren<Animator>().SetTrigger("Slash");
            if (PlayerController.manage.isDead)
            {
                Attack.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            isPlayerDetect = false;
            print("playerNoDetect");
        }
    }
    void PlayerDetectOnDistance()
    {
        Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 5.7f, Color.green);
        RaycastHit info;
        int mask = 1 << 11;
        if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 5.7f, out info, 5.7f, mask) && !PlayerController.manage.isDead)
        {
            isPlayerDetectOnDistance = true;
        }
        else
        {
            isPlayerDetectOnDistance = false;
        }
    }
    void Update()
    {
        if (!isDead)
        {
            if (Main.manage.isTapToPlay && !isClinDetect && !isPlayerDetect && !PlayerController.manage.isDead)
            {
                if (PlayerPrefs.GetInt("level") != 19 && PlayerPrefs.GetInt("level") != 23 && PlayerPrefs.GetInt("level") != 26 && PlayerPrefs.GetInt("level") != 27 && PlayerPrefs.GetInt("level") != 33)
                {
                    Move();
                }

                if (isPlayerDetectOnDistance)
                {
                    MoveBack();
                }
            }
                ClinDetected();

                if (PlayerPrefs.GetInt("level") == 33)
                {
                    PlayerDetectOnDistance();
                }
                if (!PlayerController.manage.isWeaponGet)
                {
                    //print("PlayerDetect");
                    PlayerDetect();
                }
            }
            if (isDead)
            {
                GetComponentInChildren<Animator>().SetBool("Walk", false);
                GetComponentInChildren<Animator>().SetBool("Climb", false);
                GetComponentInChildren<Animator>().SetBool("DieFront", true);
            }

        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "EnemyDestroy")
        {
            countDead += 1;
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None|RigidbodyConstraints.FreezePositionX;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().isTrigger = true;
            GameObject Pain = GameObject.Find("EnemyDown");
            Pain.GetComponent<AudioSource>().Play();
            isDead = true;
            GameObject effect = GameObject.Find("Rip");
            effect.GetComponent<Transform>().position = transform.position;
            effect.GetComponent<ParticleSystem>().Play();
            effect.GetComponent<AudioSource>().Play();
            if (countDead == 1) 
            {
            GameObject Playa = GameObject.FindGameObjectWithTag("Player");
            Playa.GetComponentInChildren<Animator>().SetBool("Climb", false);
            Playa.GetComponentInChildren<Animator>().SetBool("Finish", true);
            GameObject sound = GameObject.Find("Yeahyyy");
            sound.GetComponent<AudioSource>().Play();
            Invoke("StopAnim",0.03f);
            }
        }

        if(col.collider.tag == "Finish" && PlayerPrefs.GetInt("level") == 23)
        {
            countDead += 1;
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionX;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().isTrigger = true;
            GameObject Pain = GameObject.Find("EnemyDown");
            Pain.GetComponent<AudioSource>().Play();
            isDead = true;
            GameObject effect = GameObject.Find("Rip");
            effect.GetComponent<Transform>().position = transform.position;
            effect.GetComponent<ParticleSystem>().Play();
            effect.GetComponent<AudioSource>().Play();
            if (countDead == 1)
            {
                GameObject Playa = GameObject.FindGameObjectWithTag("Player");
                Playa.GetComponentInChildren<Animator>().SetBool("Climb", false);
                Playa.GetComponentInChildren<Animator>().SetBool("Finish", true);
                GameObject sound = GameObject.Find("Yeahyyy");
                sound.GetComponent<AudioSource>().Play();
                Invoke("StopAnim", 0.03f);
            }
        }

        if (col.collider.tag == "Finish" && PlayerPrefs.GetInt("level") == 33)
        {
            countDead += 1;
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionX;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().isTrigger = true;
            GameObject Pain = GameObject.Find("EnemyDown");
            Pain.GetComponent<AudioSource>().Play();
            isDead = true;
            GameObject effect = GameObject.Find("Rip");
            effect.GetComponent<Transform>().position = transform.position;
            effect.GetComponent<ParticleSystem>().Play();
            effect.GetComponent<AudioSource>().Play();
            if (countDead == 1)
            {
                GameObject Playa = GameObject.FindGameObjectWithTag("Player");
                Playa.GetComponentInChildren<Animator>().SetBool("Climb", false);
                Playa.GetComponentInChildren<Animator>().SetBool("Finish", true);
                GameObject sound = GameObject.Find("Yeahyyy");
                sound.GetComponent<AudioSource>().Play();
                Invoke("StopAnim", 0.03f);
            }
        }
        if (col.collider.tag == "Player")
        {
            if (isDead)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<CapsuleCollider>().enabled=false;
            }
        }

      if (col.collider.tag == "Gas")
        {
            countDead += 1;
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionX;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().isTrigger = true;
            GameObject Pain = GameObject.Find("EnemyDownGas");
            Pain.GetComponent<AudioSource>().Play();
            isDead = true;
            GameObject effect = GameObject.Find("Rip");
            effect.GetComponent<Transform>().position = transform.position;
            effect.GetComponent<ParticleSystem>().Play();
            effect.GetComponent<AudioSource>().Play();
            if (countDead == 1)
            {
                GameObject Playa = GameObject.FindGameObjectWithTag("Player");
                Playa.GetComponentInChildren<Animator>().SetBool("Climb", false);
                Playa.GetComponentInChildren<Animator>().SetBool("Finish", true);
                GameObject sound = GameObject.Find("PlayerWin");
                sound.GetComponent<AudioSource>().Play();
                Invoke("StopAnim", 0.03f);
            }
        }

        if (col.collider.tag == "Lava")
        {

            countDead += 1;
            isDead = true;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieBack", true);
            
           //  if (PlayerPrefs.GetInt("level") != 27)
           //  {
                GetComponent<CapsuleCollider>().isTrigger = true;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionX;
           // }

            if (countDead == 1)
            {
                GameObject WaterFireSnd = GameObject.Find("WaterFire");
                WaterFireSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion.GetComponent<Transform>().position = transform.position + transform.up * 0.5f + transform.right * 0.1f;
                SmokeExplosion.GetComponent<ParticleSystem>().Play();
                GameObject SmokeDarkGo = GameObject.Find("SmokeDark");
                SmokeDarkGo.GetComponent<Transform>().position = transform.position + transform.up * 0.1f + transform.right * 0.1f;
                SmokeDarkGo.GetComponent<ParticleSystem>().Play();
                GameObject sound = GameObject.Find("EnemyDownGas");
                sound.GetComponent<AudioSource>().Play();
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Lava")
        {
            countDead += 1;
            isDead = true;
            GetComponentInChildren<Animator>().SetBool("Walk", false);
            GetComponentInChildren<Animator>().SetBool("Stand", true);
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieBack", true);
            if (PlayerPrefs.GetInt("level") != 27)
            {
                GetComponent<CapsuleCollider>().isTrigger = true;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionX;
            }

            if (countDead == 1)
            {
                GameObject WaterFireSnd = GameObject.Find("WaterFire");
                WaterFireSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion.GetComponent<Transform>().position = transform.position + transform.up * 0.5f + transform.right * 0.1f;
                SmokeExplosion.GetComponent<ParticleSystem>().Play();
                GameObject SmokeDarkGo = GameObject.Find("SmokeDark");
                SmokeDarkGo.GetComponent<Transform>().position = transform.position + transform.up * 0.5f + transform.right * 0.1f;
                SmokeDarkGo.GetComponent<ParticleSystem>().Play();
                GameObject sound = GameObject.Find("EnemyDownGas");
                sound.GetComponent<AudioSource>().Play();

            }
        }

        if (col.tag == "SwordP1")
        {
            countDead += 1;
            GetComponentInChildren<Animator>().SetBool("Climb", false);
            GetComponentInChildren<Animator>().SetBool("DieFront", true);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionX;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().isTrigger = true;
            GameObject Pain = GameObject.Find("EnemyDown");
            Pain.GetComponent<AudioSource>().Play();
            isDead = true;
            GameObject effect = GameObject.Find("Rip");
            effect.GetComponent<Transform>().position = transform.position;
            effect.GetComponent<ParticleSystem>().Play();
            effect.GetComponent<AudioSource>().Play();
            Invoke("latencyAttack",0.2f);


            if (countDead == 1)
            {
                GameObject Playa = GameObject.FindGameObjectWithTag("Player");
                Playa.GetComponentInChildren<Animator>().SetBool("Climb", false);
                Playa.GetComponentInChildren<Animator>().SetBool("Finish", true); 
                GameObject death = GameObject.Find("SwordP1P");
                death.GetComponent<BoxCollider>().enabled = false;
                Invoke("latency",0.7f);
            }
        }
    }
    void StopAnim()
    {
        GameObject Playa = GameObject.FindGameObjectWithTag("Player");
        Playa.GetComponentInChildren<Animator>().SetBool("Finish", false);
    }

    void latency()
    {
        PlayerController.manage.isEnemyDetected = false;
    }

    void latencyAttack()
    {
        GameObject AttackSnd = GameObject.Find("SwordAttack");
        AttackSnd.GetComponent<AudioSource>().Play();
    }
}
