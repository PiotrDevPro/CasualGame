using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public static BoatMove manage;
    public bool isMove = false;
    public bool isJump = false;
    bool isActiveTrig =  false;
    public bool isWater = false;
    private int countWater = 0;
    private int counter = 0;
    private int countJump = 0;

    //float speed = 1f;

    private void Awake()
    {
        manage = this;
    }

    private void Start()
    {
       
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            if (isWater)
            {

                GameObject playa = GameObject.FindGameObjectWithTag("Player");
                playa.GetComponent<Transform>().position = transform.position * 1f;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                playa.GetComponentInChildren<Animator>().SetBool("Walk", false);
                playa.GetComponentInChildren<Animator>().SetBool("Crouch", false);
                playa.GetComponentInChildren<Animator>().SetBool("Stand", true);
                isMove = true;
                PlayerController.manage.Vibro();
            }
            else
            {

                GoAway.manage.isFailed = true;
            }
        }

        if (col.collider.name == "clin(8)")
        {

            GameObject jumpTrg = GameObject.Find("endTrig");
            jumpTrg.GetComponent<BoxCollider>().enabled = false;

        }
        if (col.collider.tag == "Non")
        {
            isMove = false;
            GameObject blamfct = GameObject.Find("Blam");
            blamfct.transform.position = transform.position;
            blamfct.GetComponent<HTSpriteSequencer>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.transform.localScale = new Vector2(1.5f,1.5f);
            SmokeExplosion.transform.position = transform.position * 1f;
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            GameObject boomSnd = GameObject.Find("Explosive");
            boomSnd.GetComponent<AudioSource>().Play();
            PlayerController.manage.Vibro();
        }

        if (col.collider.tag == "NonWater")
        {
            // isMove = true;
            isWater = true;
        }

        if (col.collider.tag == "waterlvl10")
        {
            counter += 1;
            if (counter >= 3)
            {
                isWater = true;
                GameObject NormalGround2 = GameObject.Find("NormalGround");
                NormalGround2.GetComponent<BoxCollider>().tag = "Untagged";
            }
            
        }
    }
    private void OnCollisionStay(Collision col)
    {
        
      if (col.collider.tag == "Player")
        {
            GameObject playa = GameObject.FindGameObjectWithTag("Player");
            playa.GetComponent<Transform>().position = transform.position;
            playa.GetComponent<Rigidbody>().isKinematic = true;
            playa.GetComponent<Rigidbody>().useGravity = false;
            playa.GetComponentInChildren<Animator>().SetBool("Climb", true);
            playa.GetComponentInChildren<Animator>().SetBool("Walk", false);
            playa.GetComponentInChildren<Animator>().SetBool("Crouch", false);
            playa.GetComponentInChildren<Animator>().SetBool("Stand", true);
            isMove = true;

        }

        if (col.collider.tag == "water")
        {
            countWater += 1;
            //GameObject waterBlow = GameObject.Find("WaterBoiling");
            // waterBlow.GetComponent<ParticleSystem>().Play();
            if (countWater == 1)
            {
                GameObject wtrSound = GameObject.Find("wtrSnd");
                wtrSound.GetComponent<AudioSource>().Play();
                PlayerController.manage.Vibro();
            }
            
        }

        if (col.collider.tag == "NonWater")
        {
            countWater += 1;
            if (countWater == 1)
            {
                GameObject wtrSound = GameObject.Find("wtrSnd");
                wtrSound.GetComponent<AudioSource>().Play();
                GameObject blamfct = GameObject.Find("Blam");
                blamfct.transform.position = transform.position;
                blamfct.GetComponent<HTSpriteSequencer>().enabled = true;
                GameObject waterboiling1 = GameObject.Find("WaterBoiling");
                waterboiling1.GetComponent<ParticleSystem>().Play();
            }

        }

        if (col.collider.tag == "waterlvl10")
        {
            countWater += 1;
            if (countWater == 1)
            {
                GameObject wtrSound = GameObject.Find("wtrSnd");
                wtrSound.GetComponent<AudioSource>().Play();
                GameObject blamfct = GameObject.Find("Blam");
                blamfct.transform.position = transform.position * 0.85f;
                blamfct.GetComponent<HTSpriteSequencer>().enabled = true;
                GameObject waterboiling1 = GameObject.Find("WaterBoiling");
                waterboiling1.GetComponent<ParticleSystem>().Play();
            }
            

        }

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            GameObject playa = GameObject.FindGameObjectWithTag("Player");
            playa.GetComponent<Rigidbody>().isKinematic = true;
            playa.GetComponent<Rigidbody>().useGravity = false;
            
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "endTrig")
        {
            isMove = false;
            isJump = true;
            countJump += 1;
            GameObject playa = GameObject.FindGameObjectWithTag("Player");
            playa.GetComponent<Rigidbody>().isKinematic = false;
            playa.GetComponent<Rigidbody>().useGravity = true;

            if (countJump == 1)
            {
                
                playa.GetComponent<Transform>().position = new Vector3(1.3f, -2.78f,0);
                playa.GetComponentInChildren<Animator>().SetBool("Climb", true);
                playa.GetComponentInChildren<Animator>().SetBool("Walk", false);
                playa.GetComponentInChildren<Animator>().SetBool("Crouch", false);
                GameObject sound = GameObject.Find("endJumping");
                sound.GetComponent<AudioSource>().Play();
            }
        }
        if(col.name == "boatColl")
        {
            
            GoAway.manage.isFailed = true;
            GameObject boat = GameObject.Find("boat");
            boat.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    private void Move()
    {
        Vector3 temp = Vector3.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + temp, 1.5f * Time.deltaTime);
    }

    void Update()
    {
        
        if (isMove == true && !PlayerController.manage.isDead)
        {
            Move();
        }
        
    }
}
