using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterActive : MonoBehaviour
{
    public static WaterActive manage;
    public bool isLavaDestroy = false;

    public int cnt;
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Lava" && PlayerPrefs.GetInt("level")!=19)
        {
            PlayerPrefs.SetInt("count", cnt++);
        }
            if (col.collider.tag == "Non")
        {
            Destroy(gameObject);
        }

        if (col.collider.tag == "EnemyDestroy")
        {

            Destroy(gameObject);
        }

        if (col.collider.tag == "Stones")
        {
            if (PlayerPrefs.GetInt("level")== 8 || PlayerPrefs.GetInt("level") == 9)
            {
                Destroy(gameObject);
            }
        }

        if (col.collider.tag == "Grnd")
        {
          //  cnt += 1;
          //  if (cnt == 1)
          //  {
          //      GameObject wtrSound = GameObject.Find("wtrSnd");
         //       wtrSound.GetComponent<AudioSource>().volume = 0.04f;
          //      wtrSound.GetComponent<AudioSource>().Play();
         //   }
        }


        if (col.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    void Latency()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider col)
  {
      if (col.tag == "FailedFromWater")
      {
            if (PlayerPrefs.GetInt("level") != 18 && PlayerPrefs.GetInt("level") != 22)
            {
                GoAway.manage.isFailed = true;
            }

            if (PlayerPrefs.GetInt("level")== 22)
            {
                GoAway.manage.isFailed = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
      }

        if (col.name == "SoftFireAdditiveRed")
        {
            GameObject fire = GameObject.Find("SoftFireAdditiveRed");
            fire.GetComponent<ParticleSystem>().Stop();
            
        }

    }
    private void Awake()
    {
        manage = this;
        PlayerPrefs.SetInt("count", 0);
    }
    private void Update()
  {
        
  }
}
