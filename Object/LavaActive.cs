using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaActive : MonoBehaviour
    
{
    int count = 0;
    public static LavaActive manage;
    //bool isLavaDeactive = false;
    bool isTapTopClin = false;
    bool isTapCenterClin = false;
    
    private GameObject clinLava;
    private GameObject clinTopLv12;
    private GameObject clinCenterLv12;

    private void Start()
    {
        GameObject sound = GameObject.Find("LavaSound");
        sound.GetComponent<AudioSource>().Play();
        clinLava = GameObject.Find("clinL");
        clinTopLv12 = GameObject.Find("clin (7)");
        clinCenterLv12 = GameObject.Find("clin (6)");
    }

    private void Awake()
    {
        manage = this;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") != 8 && PlayerPrefs.GetInt("level") != 19 && PlayerPrefs.GetInt("level")!=22 
            && PlayerPrefs.GetInt("level") != 31 && PlayerPrefs.GetInt("level") != 32 && PlayerPrefs.GetInt("level") != 33 && !isTapTopClin)
        {
            count += 1;
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            SmokeExplosion.GetComponent<Transform>().position = transform.position;
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Stone");
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            GetComponent<CapsuleCollider>().radius = 0.1f;
            GetComponent<CapsuleCollider>().height = 0.1f;
            GetComponent<CapsuleCollider>().tag = "Non";
            GetComponent<CapsuleCollider>().tag = "Stones";
            GameObject grndNormal = GameObject.Find("NormalGround");
            GameObject activeLava = GameObject.Find("lava");
                if (count == 5)
                {
                        activeLava.SetActive(false);
 
                        if (PlayerPrefs.GetInt("level") == 5)
                        {
                            GameObject lavaParticlePlay = GameObject.Find("LavaBoiling");
                        }

                    if (PlayerPrefs.GetInt("level") == 9)
                        {
                            grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lava"); 
                            GameObject jumpTrg = GameObject.Find("endTrig");
                            jumpTrg.GetComponent<BoxCollider>().enabled = true;
                            GameObject boomSnd = GameObject.Find("Explosive");
                            boomSnd.GetComponent<AudioSource>().Play();

                        }

                        if (PlayerPrefs.GetInt("level") == 18 && clinTopLv12.transform.position.x < 0)
                        {
                            grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                            grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                            grndNormal.GetComponent<BoxCollider>().enabled = true;
                            GameObject boomSnd = GameObject.Find("Explosive");
                            boomSnd.GetComponent<AudioSource>().Play();
                            GameObject spikes = GameObject.Find("deadthObj");
                            spikes.SetActive(false);
                        }

                if (PlayerPrefs.GetInt("level") == 24)
                    {
                        grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                        grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                        grndNormal.GetComponent<BoxCollider>().enabled = true;
                        GameObject boomSnd = GameObject.Find("Explosive");
                        boomSnd.GetComponent<AudioSource>().Play();
                    //GameObject spikes = GameObject.Find("deadthObj");
                    //spikes.SetActive(false);
                    }
                    if (PlayerPrefs.GetInt("level") == 5 ||  PlayerPrefs.GetInt("level") == 16 || PlayerPrefs.GetInt("level") == 22)
                    {
                        grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LavaStone");
                        grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                        grndNormal.GetComponent<BoxCollider>().enabled = true;
                        GameObject boomSnd = GameObject.Find("Explosive");
                        boomSnd.GetComponent<AudioSource>().Play();

                    }
                         
                         GameObject sound = GameObject.Find("LavaSound");
                         sound.GetComponent<AudioSource>().Stop();
                }
        }

        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 22)
        {

            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            SmokeExplosion.GetComponent<Transform>().position = transform.position * 1f;
            SmokeExplosion.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            if (PlayerPrefs.GetInt("count") >= 4 && transform.position.y < -3)
            {
                // GameObject blamfct = GameObject.Find("Blam");
                // blamfct.transform.position = transform.position * 0.8f;
                // blamfct.GetComponent<HTSpriteSequencer>().enabled = true;
                GameObject grndNormal = GameObject.Find("NormalGround");
                grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LavaStone");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject activeLava = GameObject.Find("lava");
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion1 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion1.GetComponent<ParticleSystem>().Play();
                SmokeExplosion1.GetComponent<Transform>().position = transform.position * 0.8f;
                SmokeExplosion1.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
                GameObject spikeobj = GameObject.Find("DeathObj");
                spikeobj.SetActive(false);
                activeLava.SetActive(false);
            } else
            {
                Destroy(gameObject);
            }
            if (PlayerPrefs.GetInt("count") >= 2 && transform.position.y > 0)
            {
                GameObject grndNormal1 = GameObject.Find("TopGround");
                grndNormal1.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal1.GetComponent<BoxCollider>().enabled = true;
                GameObject activeLava = GameObject.Find("lava");
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion1 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion1.GetComponent<ParticleSystem>().Play();
                activeLava.SetActive(false);
            }

            if (PlayerPrefs.GetInt("count") >= 3 && clinLava.transform.position.y < 0)
            {
                GameObject grndNormall = GameObject.Find("LavaTopGrnd");
                //grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LavaStone");
                grndNormall.GetComponent<SpriteRenderer>().enabled = true;
                grndNormall.GetComponent<BoxCollider>().enabled = true;
                grndNormall.AddComponent<Rigidbody>().mass = 40;
                grndNormall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
                GameObject activeLava = GameObject.Find("lava");
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosionl = GameObject.Find("SmokeExplosionDark");
                SmokeExplosionl.GetComponent<ParticleSystem>().Play();
                SmokeExplosionl.GetComponent<Transform>().position = transform.position * 0.8f;
                activeLava.SetActive(false);
            }
        }
        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 31)
        {
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            SmokeExplosion.GetComponent<Transform>().position = transform.position * 1f;
            SmokeExplosion.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            if (PlayerPrefs.GetInt("count") >= 3 )
            {
                GameObject grndNormal = GameObject.Find("NormalGround");
                grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject activeLava = GameObject.Find("lava");
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion1 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion1.GetComponent<ParticleSystem>().Play();
                SmokeExplosion1.GetComponent<Transform>().position = transform.position * 0.8f;
                SmokeExplosion1.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
                activeLava.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 32)
        {
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            SmokeExplosion.GetComponent<Transform>().position = transform.position * 1f;
            SmokeExplosion.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            if (PlayerPrefs.GetInt("count") >= 3)
            {
                GameObject grndNormal = GameObject.Find("NormalGround");
                grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject activeLava = GameObject.Find("lava");
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion1 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion1.GetComponent<ParticleSystem>().Play();
                SmokeExplosion1.GetComponent<Transform>().position = transform.position * 0.8f;
                SmokeExplosion1.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
                GameObject spikeobj = GameObject.Find("DeathObg");
                spikeobj.SetActive(false);
                activeLava.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
            if (PlayerPrefs.GetInt("count") >= 2 && transform.position.y > 0)
            {
                GameObject grndNormal1 = GameObject.Find("TopGrnd");
                grndNormal1.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal1.GetComponent<BoxCollider>().enabled = true;
                grndNormal1.AddComponent<Rigidbody>().mass = 40;
                grndNormal1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
                GameObject activeLava = GameObject.Find("lava");
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion1 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion1.GetComponent<ParticleSystem>().Play();
                activeLava.SetActive(false);
            }
        }

        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 8)
        {
            count += 1;
            //GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            //SmokeExplosion.GetComponent<ParticleSystem>().Play();
            //SmokeExplosion.GetComponent<Transform>().position = transform.position;
            GameObject SmokeExplosion2D1 = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D1.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D1.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd1 = GameObject.Find("WaterFire");
            WaterFireSnd1.GetComponent<AudioSource>().Play();
            GameObject activeLava = GameObject.Find("lava");
            GameObject grndNormal = GameObject.Find("NormalGround");
            if (PlayerPrefs.GetInt("count")>=3)
            {
                activeLava.SetActive(false);
                grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lava1");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion12 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion12.GetComponent<ParticleSystem>().Play();
                SmokeExplosion12.GetComponent<Transform>().position = transform.position * 0.7f;
                SmokeExplosion12.GetComponent<Transform>().localScale = new Vector2(1.8f, 1.8f);
                //GameObject blamfct = GameObject.Find("Blam");
                //blamfct.transform.position = transform.position * 0.5f;
                //blamfct.GetComponent<HTSpriteSequencer>().enabled = true;
                
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 19)
        {
            count += 1;
            //GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            //SmokeExplosion.GetComponent<ParticleSystem>().Play();
           //SmokeExplosion.GetComponent<Transform>().position = transform.position;
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            GameObject activeLava = GameObject.Find("lava");
            if (count == 1)
            {
                activeLava.SetActive(false);
                GameObject tile3 = GameObject.Find("tile (3)");
                GameObject tile5 = GameObject.Find("tile (5)");
                tile3.SetActive(false);
                tile5.SetActive(false);
                GameObject grndNormal23 = GameObject.Find("TopGround");
                grndNormal23.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal23.GetComponent<BoxCollider>().enabled = true;
                grndNormal23.GetComponent<BoxCollider>().tag = "EnemyDestroy";
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion12 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion12.GetComponent<ParticleSystem>().Play();
                SmokeExplosion12.GetComponent<Transform>().position = transform.position * 0.1f;
                SmokeExplosion12.GetComponent<Transform>().localScale = new Vector2(1.8f, 1.8f);
            }
        }
        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 23)
        {
            count += 1;
            //GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            //SmokeExplosion.GetComponent<ParticleSystem>().Play();
            //SmokeExplosion.GetComponent<Transform>().position = transform.position;
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            GameObject activeLava = GameObject.Find("lava");
            if (count == 6)
            {
                GameObject grndNormal = GameObject.Find("NormalGround");
                grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion12 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion12.GetComponent<ParticleSystem>().Play();
                SmokeExplosion12.GetComponent<Transform>().position = transform.position * 0.7f;
                SmokeExplosion12.GetComponent<Transform>().localScale = new Vector2(1.8f, 1.8f);
                activeLava.SetActive(false);
            }
        }
        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 18 && clinTopLv12.transform.position.x >0 && !isTapCenterClin)
        {
            count += 1;
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            SmokeExplosion.GetComponent<Transform>().position = transform.position;
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            GameObject grndNormal = GameObject.Find("loseGround");
            GameObject activeLava = GameObject.Find("LavaTop");

            if(count == 3)
            {
                //grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject spikes = GameObject.Find("deadthObj");
                //spikes.SetActive(false);
                activeLava.SetActive(false);

            }
        }
        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 18 && clinCenterLv12.transform.position.y>0)
        {
            count += 1;
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            SmokeExplosion.GetComponent<Transform>().position = transform.position;
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            GameObject grndNormal = GameObject.Find("loseGroundCenter");
            GameObject activeLava = GameObject.Find("LavaTop");

            if (count == 3)
            {
                //grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject spikes = GameObject.Find("deadthObj");
                spikes.SetActive(false);
                activeLava.SetActive(false);

            }
        }

        if (col.collider.tag == "water" && PlayerPrefs.GetInt("level") == 33)
        {
            count += 1;
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            SmokeExplosion.GetComponent<Transform>().position = transform.position * 1f;
            SmokeExplosion.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            if (PlayerPrefs.GetInt("count") >= 6)
            {
                GameObject grndNormal = GameObject.Find("NormalGround");
                grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lavalv12");
                grndNormal.GetComponent<SpriteRenderer>().enabled = true;
                grndNormal.GetComponent<BoxCollider>().enabled = true;
                GameObject activeLava = GameObject.Find("lava");
                GameObject boomSnd = GameObject.Find("Explosive");
                boomSnd.GetComponent<AudioSource>().Play();
                GameObject SmokeExplosion1 = GameObject.Find("SmokeExplosionDark");
                SmokeExplosion1.GetComponent<ParticleSystem>().Play();
                SmokeExplosion1.GetComponent<Transform>().position = transform.position * 0.8f;
                SmokeExplosion1.GetComponent<Transform>().localScale = new Vector2(2f, 2f);
                //GameObject spikeobj = GameObject.Find("DeathObg");
                //spikeobj.SetActive(false);
                activeLava.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (col.collider.name == "crate")
        {
            GameObject FireFx = GameObject.Find("SoftFireAdditiveRed");
            FireFx.GetComponent<ParticleSystem>().Play();
            FireFx.GetComponent<Transform>().position = transform.position;
            GameObject crateActive = GameObject.Find("crate");
            crateActive.GetComponent<SpriteRenderer>().enabled = false;
            crateActive.GetComponent<BoxCollider>().enabled = false;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();

            if (PlayerPrefs.GetInt("level") == 28)
            {
                GoAway.manage.isFailed = true;
            }
        }
        if (col.collider.name == "boat")
        {
            GameObject FireFx = GameObject.Find("SoftFireAdditiveRed");
            FireFx.GetComponent<ParticleSystem>().Play();
            FireFx.GetComponent<Transform>().position = transform.position;
            GameObject boatActv = GameObject.Find("boat");
            boatActv.GetComponent<SpriteRenderer>().enabled = false;
            boatActv.GetComponent<BoxCollider>().enabled = false;
            if(PlayerPrefs.GetInt("level")== 17 || PlayerPrefs.GetInt("level") == 9)
            {
                GoAway.manage.isFailed = true;
            }
        }
        if (col.collider.name == "hardColl")
        {
            GameObject FireFx = GameObject.Find("SoftFireAdditiveRed");
            FireFx.GetComponent<ParticleSystem>().Play();
            FireFx.GetComponent<Transform>().position = transform.position;
            GameObject boatActv = GameObject.Find("hardColl");
            boatActv.GetComponent<SpriteRenderer>().enabled = false;
            boatActv.GetComponent<BoxCollider>().enabled = false;
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
           // if (PlayerPrefs.GetInt("level") == 20)
          //  {
                GoAway.manage.isFailed = true;
                GameObject FxActive = GameObject.Find("Sun_Shines_02 (1)");
                FxActive.SetActive(false);
           // }
        }
        if (col.collider.tag == "NonWater")
        {
            count += 1;
            GameObject SmokeExplosion = GameObject.Find("SmokeExplosionDark");
            SmokeExplosion.GetComponent<ParticleSystem>().Play();
            GameObject SmokeExplosion2D = GameObject.Find("SparkExplosion2D");
            SmokeExplosion2D.GetComponent<ParticleSystem>().Play();
            GameObject WaterFireSnd = GameObject.Find("WaterFire");
            WaterFireSnd.GetComponent<AudioSource>().Play();
            SmokeExplosion2D.GetComponent<Transform>().position = transform.position;
            // GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Stone");
            // GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            // GetComponent<CapsuleCollider>().radius = 0.1f;
            // GetComponent<CapsuleCollider>().height = 0.1f;
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            GetComponent<CapsuleCollider>().tag = "Non";
            GameObject grndNormal = GameObject.Find("NormalGround");
            GameObject activeLava = GameObject.Find("lava");
            {
                if (count == 1)
                {
                    activeLava.SetActive(false);
                    grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LavaStone");
                    grndNormal.GetComponent<SpriteRenderer>().enabled = true;

                    if (PlayerPrefs.GetInt("level") == 5)
                    {
                        GameObject lavaParticlePlay = GameObject.Find("LavaBoiling");
                        lavaParticlePlay.GetComponent<ParticleSystem>().Stop();
                    }

                    if (PlayerPrefs.GetInt("level") == 8)
                    {
                        grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("lavaLv8");
                    }

                    if (PlayerPrefs.GetInt("level") == 9)
                    {
                        grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lava");
 
                    }

                    if (PlayerPrefs.GetInt("level") == 18)
                    {
                        grndNormal.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("lavaLv8");
                        GameObject spikes = GameObject.Find("deadthObj");
                        spikes.SetActive(false);
                    }

                    grndNormal.GetComponent<BoxCollider>().enabled = true;
                    // GameObject lavaSnd = GameObject.Find("LavaD");
                    // lavaSnd.GetComponent<AudioSource>().Stop();
                    GameObject sound = GameObject.Find("LavaSound");
                    sound.GetComponent<AudioSource>().Stop();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "clin1 (1)" && PlayerPrefs.GetInt("level") == 22)
        {
            
           // GoAway.manage.isFailed = true;
            
        }
       
    }

    void level12clinTop()
    {
        if (PlayerPrefs.GetInt("level") == 18)
        {
            if (clinTopLv12.transform.position.x > 0)
            {
                isTapTopClin = true;
            }
            if (clinCenterLv12.transform.position.y > 0)
            {
                isTapCenterClin = true;
            }
        }
    }

    private void Update()
    {
        level12clinTop();
        //print(transform.position.y);
        //print(PlayerPrefs.GetInt("count"));
        //print(clinCenterLv12.transform.position.y);
    }
}
