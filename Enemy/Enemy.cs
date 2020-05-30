using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Enemy : MonoBehaviour
{
    public static Enemy manage;
    bool isDead = false;
    bool isPlayerDetect = false;
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
            // GetComponent<Rigidbody>().isKinematic = false;
            // GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }

        if (PlayerPrefs.GetInt("level") == 23)
        {
            isDead = false;
            GetComponent<Transform>().position = new Vector2(0.50f, -3.01f);
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
     void ClinDetected()
    {
        Debug.DrawRay(transform.position + transform.up / 2f, transform.right * 3.5f, Color.yellow);
        RaycastHit info;
        int mask = 1 << 8;
        if (Physics.Raycast(transform.position + transform.up / 2f, transform.right * 3.5f, out info, 3.5f, mask))
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
            //print("playerDetect");
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
           // print("playerNoDetect");
        }
    }

     void Update()
    {
        if (!isDead)
        {
            if (Main.manage.isTapToPlay && !isClinDetect && !isPlayerDetect && !PlayerController.manage.isDead)
            {
                if ( PlayerPrefs.GetInt("level") != 19 && PlayerPrefs.GetInt("level")!=23 && PlayerPrefs.GetInt("level") != 26 && PlayerPrefs.GetInt("level") != 27)
                {
                        Move();
                       // print("enemyMove");
                }

            }
            ClinDetected();
            PlayerDetect();
            
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
                GameObject Playa = GameObject.Find("Default");
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
                GameObject Playa = GameObject.Find("Default");
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
                GameObject Playa = GameObject.Find("Default");
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
    }
    void StopAnim()
    {
        GameObject Playa1 = GameObject.Find("Default");
        Playa1.GetComponentInChildren<Animator>().SetBool("Finish", false);
    }
}
